using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ENG.NR2003.NascarSeasonView.Types.Charting;
using ESystem.Extensions;

namespace ENG.NR2003.NascarSeasonView.Forms
{
  public partial class FrmViewDetails : Form
  {
    private class Filter
    {
      public PropertyInfo PropertyInfo { get; set; }
      public List<object> Values { get; set; }

      public override string ToString()
      {
        return PropertyInfo.Name + " = { " + Values.ToString(";") + "}";
      }
    }

    private System.Collections.IEnumerable data = null;

    public FrmViewDetails()
    {
      InitializeComponent();
    }

    public FrmViewDetails(System.Collections.IEnumerable data)
      : this()
    {
      this.data = data;
      ReFillComboBoxes();
      InitCmbChartType();

      RebuildDataGrid();
    }

    private void ReFillComboBoxes()
    {
      cmbX.Items.Clear();
      cmbY.Items.Clear();
      cmbS.Items.Clear();
      cmbF.Items.Clear();

      var en = data.GetEnumerator();
      if (en.MoveNext() == false) return;

      Type t = en.Current.GetType();

      PropertyInfo[] props = t.GetProperties();

      foreach (var item in props)
      {
        cmbX.Items.Add(new ListItem(item, item.Name));
        cmbY.Items.Add(new ListItem(item, item.Name));
        cmbS.Items.Add(new ListItem(item, item.Name));
        cmbF.Items.Add(new ListItem(item, item.Name));
      }
    }

    private void InitCmbChartType()
    {
      Type t = typeof(System.Windows.Forms.DataVisualization.Charting.SeriesChartType);
      var values = Enum.GetValues(t);

      cmbChartType.Items.Clear();
      foreach (var item in values)
      {
        cmbChartType.Items.Add(item);
      }

      cmbChartType.SelectedItem = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
    }

    private void btnDraw_Click(object sender, EventArgs e)
    {
      string[] filter = null;
      if (txtFilter.Text.Length > 0)
        filter = txtFilter.Text.Split(';');

      Extender.Build(
          this.data,
          filter,
          (cmbS.SelectedItem as ListItem).Value as PropertyInfo,
          (cmbX.SelectedItem as ListItem).Value as PropertyInfo,
          (cmbY.SelectedItem as ListItem).Value as PropertyInfo,
          this.chcChart,
          (System.Windows.Forms.DataVisualization.Charting.SeriesChartType)cmbChartType.SelectedItem);
    }

    private void btnApplyFilter_Click(object sender, EventArgs e)
    {
      if (cmbF.SelectedItem == null)
        return;

      Filter f = new Filter();
      f.PropertyInfo = (cmbF.SelectedItem as ListItem).Value as PropertyInfo;
      f.Values = GetDataFilterValues(f.PropertyInfo, txtDataFilter.Text);

      lstFilters.Items.Add(f);

      RebuildDataGrid();
    }

    private void RebuildDataGrid()
    {

      this.Enabled = false;

      try
      {
        List<object> filteredData = GetFilteredData();

        Types.Views.Extender.BuildGridForView(
          this.grd, filteredData, false);
      }
      finally
      {
        this.Enabled = true;
      }
    }

    private List<object> GetFilteredData()
    {

      List<object> ret = new List<object>();

      foreach (var item in data)
      {
        if (lstFilters.Items.Count == 0)
          ret.Add(item);
        else
        {
          if (IsAcceptedByFilters(item))
            ret.Add(item);
        }
      }

      return ret;
    }

    private bool IsAcceptedByFilters(object item)
    {
      foreach (Filter f in lstFilters.Items)
      {
        object val = f.PropertyInfo.GetValue(item, null);
        if (f.Values.Contains(val) == false)
          return false;
      }

      return true;
    }

    private List<object> GetDataFilterValues(PropertyInfo propertyInfo, string filters)
    {
      Func<string, object> converter;

      if (propertyInfo.PropertyType == typeof(int))
        converter = (i => int.Parse(i));
      else if (propertyInfo.PropertyType == typeof(double))
        converter = (i => double.Parse(i));
      else
        converter = (i => i);

      List<object> ret = new List<object>();

      string[] spl = filters.Split(';');

      foreach (var item in spl)
      {
        try
        {
          object val = converter(item);
          ret.Add(val);
        }
        catch (Exception ex)
        {
          throw new Exception("Failed to convert " + item + " into desired type of property " + propertyInfo.PropertyType.Name + ". Value will be ignored.", ex);
        } // end catch
      }

      return ret;
    }

    private void btnRemoveSelectedFilter_Click(object sender, EventArgs e)
    {
      List<Filter> remList = new List<Filter>();
      foreach (Filter item in lstFilters.SelectedItems)
      {
        remList.Add(item);
      }

      remList.ForEach(i => lstFilters.Items.Remove(i));

      RebuildDataGrid();
    }
  }
}
