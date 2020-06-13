using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ESystem.Extensions;
using ENG.NR2003.Types;
using ENG.NR2003.NascarSeasonView.Types.GridRules;
using ENG.NR2003.NascarSeasonView.Forms.GridRules;
using System.Collections;

namespace ENG.NR2003.NascarSeasonView.Types.Views
{
  public static class Extender
  {
    #region Nested
    private class PropertyData : IComparable<PropertyData>
    {

      public PropertyInfo Property { get; set; }
      public DisplayAttribute Attribute { get; set; }
      public string DisplayText
      {
        get
        {
          if (Attribute == null || Attribute.DisplayText == null)
            return DecomposePropertyName(Property.Name);
          else
            return Attribute.DisplayText;
        }
      }
      public int? DisplayIndex
      {
        get
        {
          if (Attribute == null)
            return null;
          else
            return Attribute.DisplayIndex;
        }
      }
      public string ToolTipText { get { if (Attribute != null) return Attribute.ToolTipText; else return null; } }

      public int CompareTo(PropertyData other)
      {
        int ret;
        ret = CompareIndices(this, other);
        if (ret == 0)
        {
          ret = CompareNames(this, other);
        }
        return ret;
      }

      private static int CompareIndices(PropertyData a, PropertyData b)
      {
        int? an = a.DisplayIndex;
        int? bn = b.DisplayIndex;

        if (an == null)
          if (bn == null)
            return 0;
          else
            return 1;
        else
          if (bn == null)
            return -1;
          else
            return an.Value.CompareTo(bn.Value);
      }

      private static int CompareNames(PropertyData a, PropertyData b)
      {
        string an = a.DisplayText;
        string bn = b.DisplayText;

        if (string.IsNullOrEmpty(an))
          if (string.IsNullOrEmpty(bn))
            return 0;
          else
            return 1;
        else
          if (string.IsNullOrEmpty(bn))
            return -1;
          else
            return an.CompareTo(bn);
      }

      private static string DecomposePropertyName(string name)
      {
        StringBuilder sb = new StringBuilder();

        sb.Append(name[0]);

        for (int i = 1; i < name.Length; i++)
        {
          if (char.IsUpper(name[i]) || char.IsDigit(name[i]))
            sb.Append(" " + char.ToLower(name[i]));
          else
            sb.Append(name[i]);
        }

        return sb.ToString();
      }
    }
    #endregion Nested

    #region Registered grids operations
    private static List<DataGridView> buildedGrids = new List<DataGridView>();

    public static void ReApplyGridRules()
    {
      foreach (var item in buildedGrids)
      {
        TryApplyGridRulesOnGrid(item);
      }
    }

    private static void TryApplyGridRulesOnGrid(DataGridView grd)
    {
        ApplyGridRules(grd);
    }


    #endregion Static - registered grids

    #region Grid registering and building

    public static void BuildGridForView<T>(DataGridView grd, IView<T> view, bool addOrderColumn)
    {
      BuildGridForView<T>(grd, view.GetAll(), addOrderColumn);
    }

    internal static void BuildGridForView<T>(DataGridView grd, List<T> data, bool addOrderColumn)
    {
      BuildGridForView(grd, (IList) data, addOrderColumn);
    }

    internal static void BuildGridForView(DataGridView grd, IList data, bool addOrderColumn)
    {
      if (data.Count == 0) return;

      Type itemType = data[0].GetType();

      List<PropertyData> pds = AnalyseColumnsForGrid(itemType);

      AdjustGridBehavior(grd);
      RegisterGridContextMenu(grd);
      BuildColumns(grd, pds, addOrderColumn);

      FillColumns(grd, data);
      if (addOrderColumn) FillOrderIndex(grd);

      TryApplyGridRulesOnGrid(grd);

      buildedGrids.Add(grd);
    }

    #endregion Grid registering and building

    #region Grid event handlers

    private static void contextMenuNewRule_Click(object sender, EventArgs e)
    {
      DataGridView grd = (sender as ToolStripMenuItem).Tag as DataGridView;
      string gridName = null;
      string weekendName = null;
      string trackName = null;
      string defaultValue = null;
      List<string> columnNames = null;

      gridName = grd.GetType().Name;

      columnNames = new List<string>();
      foreach (DataGridViewColumn c in grd.Columns)
      {
        columnNames.Add(c.HeaderText);
      }

      string prefferedColumnName = null;
      if (grd.SelectedCells.Count > 0)
      {
        defaultValue = grd.SelectedCells[0].Value.ToString();
        int ci = grd.SelectedCells[0].ColumnIndex;
        prefferedColumnName = grd.Columns[ci].HeaderText;
      }

      AddGridRule f = new AddGridRule();
      f.Init(gridName, weekendName, trackName, columnNames, prefferedColumnName, defaultValue);
      f.ShowDialog();
      var res = f.Result;

      if (res == null) return;

      Program.GridRules.Add(res);

      ReApplyGridRules();
    }

    private static void contextMenuManageRules_Click(object sender, EventArgs e)
    {
      GridRulesEditor f = new GridRulesEditor();
      f.Init(Program.GridRules);
      f.ShowDialog();
      
      ReApplyGridRules();
    }

    static void grd_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
      object a = e.CellValue1;
      object b = e.CellValue2;

      if (a is IComparable)
        e.SortResult = ((IComparable)a).CompareTo(b);
      else
        throw new NotSupportedException("Cannot sort over not IComparable types (" + a.GetType().FullName + ").");
    }

    #endregion Grid context menu event handlers

    #region Private methods

    private static void RegisterGridContextMenu(DataGridView grd)
    {
      ContextMenuStrip cms = BuildStaticContextMenuStripInstance(grd);
      grd.ContextMenuStrip = cms;
    }

    private static ContextMenuStrip BuildStaticContextMenuStripInstance(DataGridView targetGrid)
    {
      ContextMenuStrip cms = new ContextMenuStrip();

      ToolStripItem mi = null;

      mi = new ToolStripMenuItem();
      mi.Text = "Define rule for background color on this column";
      mi.Click += contextMenuNewRule_Click;
      mi.Tag = targetGrid;
      cms.Items.Add(mi);

      mi = new ToolStripMenuItem();
      mi.Text = "Manage background color rules";
      mi.Click += contextMenuManageRules_Click;
      mi.Tag = targetGrid;
      cms.Items.Add(mi);

      return cms;
    }

    private static List<PropertyData> AnalyseColumnsForGrid(Type t)
    {
      PropertyInfo[] properties = t.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);
      List<PropertyData> pds = BuildPropertyDataList(properties);
      pds = GetSortedPropertyDataList(pds);
      return pds;
    }

    private static List<PropertyData> GetSortedPropertyDataList(List<PropertyData> pds)
    {
      List<PropertyData> withoutIndex = pds.Where(i => i.DisplayIndex == null).ToList();
      List<PropertyData> withIndex = pds.Where(i => i.DisplayIndex != null).ToList();

      withIndex.Sort();

      List<PropertyData> ret = new List<PropertyData>();

      ret.AddRange(withIndex);
      ret.AddRange(withoutIndex);

      return ret;
    }

    private static void AdjustGridBehavior(DataGridView grd)
    {
      grd.AllowUserToAddRows = false;
      grd.AllowUserToDeleteRows = false;
      grd.EditMode = DataGridViewEditMode.EditProgrammatically;
      grd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      grd.MultiSelect = false;

      grd.SortCompare += new DataGridViewSortCompareEventHandler(grd_SortCompare);
    }

    private static void FillOrderIndex(DataGridView grd)
    {
      for (int i = 0; i < grd.Rows.Count; i++)
      {
        grd.Rows[i].Cells[0].Value = (i + 1).ToString() + ".";
      }
    }

    private static void FillColumns(DataGridView grd, IList data)
    {
      List<PropertyInfo> pis = new List<PropertyInfo>();
      foreach (DataGridViewColumn item in grd.Columns)
      {
        if (item.Tag != null)
          pis.Add((PropertyInfo)item.Tag);
        else
          pis.Add(null);
      }

      grd.Rows.Clear();

      if (data.Count == 0) return;

      grd.Rows.Add(data.Count);

      bool isEven = false;
      object val;
      PropertyInfo pi;
      for (int i = 0; i < data.Count; i++)
      {
        object item = data[i];
        DataGridViewRow r = grd.Rows[i];
        if (isEven)
        {
          r.DefaultCellStyle.BackColor = System.Drawing.Color.Linen;
          isEven = !isEven;
        }

        for (int j = 0; j < grd.Columns.Count; j++)
        {
          if (grd.Columns[j].Tag == null) continue;
          pi = pis[j];
          val = pi.GetValue(item, null);
          r.Cells[j].ValueType = val.GetType();
          r.Cells[j].Value = val;
        }
      }
    }

    private static void ApplyGridRules(DataGridView grd)
    {
      GridRuleCollection rules = Program.GridRules;
      GridRuleCollection rls = rules.GetRulesFor(grd.GetType().Name, null, null);

      foreach (DataGridViewRow row in grd.Rows)
      {
        GridRule gr = GetRuleApplicableForRow(rls, grd, row);
        if (gr == null)
          SetRowBackColor(row, grd.DefaultCellStyle.BackColor);
        else
          SetRowBackColor(row, gr.Color);
      }
    }

    private static GridRule GetRuleApplicableForRow(GridRuleCollection rls, DataGridView grd, DataGridViewRow row)
    {
      GridRule ret = null;
      foreach (var rule in rls)
      {
        DataGridViewColumn column = GetColumnForRule(grd, rule);
        if (column == null)
          continue;

        object ruleValue = rule.Value;
        object cellValue = row.Cells[column.Index].Value;

        if (DoValuesMatch(rule, cellValue))
        {
          ret = rule;
          break;
        }
      }

      return ret;
    }

    private static bool DoValuesMatch(GridRule rule, object cellValue)
    {
      if (rule.Value.GetType() == cellValue.GetType())
        return DovaluesMatchExactly(rule.Value, cellValue, rule.Operator);
      else
      {
        Type t = cellValue.GetType();
        if (cellValue is string)
        {
          rule.Value = rule.Value.ToString();
          return DoValuesMatch(rule, cellValue);
        }
        else if (cellValue is int)
        {
          int? nv = TryConvertToInt(rule.Value);
          if (nv == null) return false;
          rule.Value = nv;
          return DoValuesMatch(rule, cellValue);
        }
        else if (cellValue is double)
        {
          double? nv = TryConvertToDouble(rule.Value);
          if (nv == null) return false;
          rule.Value = nv;
          return DoValuesMatch(rule, cellValue);
        }
        else if (cellValue is Time)
        {
          Time? nv = TryConvertToTime(rule.Value);
          if (nv == null) return false;
          rule.Value = nv;
          return DoValuesMatch(rule, cellValue);
        }
        else
          throw new NotSupportedException("This datatype in data grid view column is not supported yet.");
      }
    }

    private static Time? TryConvertToTime(object p)
    {
      if (p is Time)
        return (Time)p;
      else if (p is string)
      {
        Time t;
        if (Time.TryParse((string)p, out t))
          return t;
        else
          return null;
      }
      else
      {
        double? d = TryConvertToDouble(p);
        if (d == null)
          return null;
        else
          return new Time((int)d.Value);
      }
    }

    private static double? TryConvertToDouble(object p)
    {
      if (p is double)
        return (double)p;
      else if (p is Time)
        return ((Time)p).TotalMiliseconds;
      else if (p is int)
        return (int)p;
      else if (p is string)
      {
        double ret;
        if (double.TryParse((string)p, out ret))
          return ret;
        else
          if (double.TryParse(
            (string)p,
            System.Globalization.NumberStyles.Number,
            System.Globalization.CultureInfo.GetCultureInfo("en-US"),
            out ret))
            return ret;
          else
            return null;
      }
      else
        throw new NotImplementedException();
    }

    private static int? TryConvertToInt(object p)
    {
      if (p is int)
        return (int)p;
      else if (p is Time)
        return ((Time)p).TotalMiliseconds;
      else if (p is double)
        return (int)((double)p);
      else if (p is string)
      {
        int ret;
        if (int.TryParse((string)p, out ret))
          return ret;
        else
          return null;
      }
      else
        throw new NotImplementedException();
    }

    private static bool DovaluesMatchExactly(object ruleValue, object cellValue, GridRule.eOperator eOperator)
    {
      IComparable ir = ruleValue as IComparable;
      IComparable ic = cellValue as IComparable;

      if (eOperator == GridRule.eOperator.Equal)
        return ir.CompareTo(ic) == 0;
      else if (eOperator == GridRule.eOperator.Less)
        return ic.CompareTo(ir) < 0;
      else if (eOperator == GridRule.eOperator.More)
        return ic.CompareTo(ir) > 0;
      else if (eOperator == GridRule.eOperator.Contains)
      {
        string sr;
        if (ruleValue is string) sr = (string)ruleValue; else sr = ruleValue.ToString();
        string sc;
        if (cellValue is string) sc = (string)cellValue; else sc = cellValue.ToString();
        return sc.Contains(sr);
      }
      else
        throw new NotImplementedException("Cannot find correct implemetation for combination of types.");
    }

    private static DataGridViewColumn GetColumnForRule(DataGridView grd, GridRule rule)
    {
      foreach (DataGridViewColumn item in grd.Columns)
      {
        if (item.HeaderText == rule.GridColumnHeaderText)
          return item;
      }
      return null;
    }

    private static void SetRowBackColor(DataGridViewRow row, System.Drawing.Color color)
    {
      row.DefaultCellStyle.BackColor = color;
    }

    private static void BuildColumns(DataGridView grd, List<PropertyData> pds, bool addOrderColumn)
    {
      DataGridViewCell template = new DataGridViewTextBoxCell();

      grd.Columns.Clear();

      if (addOrderColumn)
      {
        DataGridViewColumn c = new DataGridViewColumn(template);
        c.HeaderText = "I.";
        c.Tag = null;

        grd.Columns.Add(c);
      }

      foreach (var item in pds)
      {
        DataGridViewColumn c = new DataGridViewColumn(template);
        c.HeaderText = item.DisplayText;
        c.Tag = item.Property;
        c.ToolTipText = item.ToolTipText;
        c.SortMode = DataGridViewColumnSortMode.Automatic;

        if (item.Property.PropertyType == typeof(string))
          c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        else
          c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        grd.Columns.Add(c);
      }
    }

    private static List<PropertyData> BuildPropertyDataList(PropertyInfo[] properties)
    {
      List<PropertyData> ret = new List<PropertyData>();

      foreach (var item in properties)
      {
        var cas = item.GetCustomAttributes(typeof(DisplayAttribute), true);
        var ca = cas.FirstOrDefault();
        //if (ca == null)
        //  ca = new DisplayAttribute(item.Name);
        PropertyData pd = new PropertyData()
        {
          Property = item,
          Attribute = (DisplayAttribute)ca
        };
        ret.Add(pd);
      }

      return ret;
    }

    #endregion Private methods


      //    grid.AllowUserToAddRows = false;
      //grid.AllowUserToDeleteRows = false;
      //grid.AllowUserToOrderColumns = true;
      //DataGridViewCellStyle style = new DataGridViewCellStyle(grid.DefaultCellStyle);
      //style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      //grid.AlternatingRowsDefaultCellStyle = style;
      //grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      //grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      //grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      //grid.MultiSelect = false;
      //grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      //grid.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      //grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
  }
}
