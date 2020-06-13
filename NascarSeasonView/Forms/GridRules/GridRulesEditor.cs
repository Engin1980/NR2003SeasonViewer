using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENG.NR2003.NascarSeasonView.Types.GridRules;
using ENG.NR2003.NascarSeasonView.Types.Views;
using ENG.NR2003.NascarSeasonView.Types;

namespace ENG.NR2003.NascarSeasonView.Forms.GridRules
{
  public partial class GridRulesEditor : Form
  {
    public GridRulesEditor()
    {
      InitializeComponent();

      InitGridComboBoxColumnWithOperatorValues();
    }

    private void InitGridComboBoxColumnWithOperatorValues()
    {
      operatorDataGridViewTextBoxColumn.Items.Clear();
      operatorDataGridViewTextBoxColumn.Items.Add(GridRule.eOperator.Less);
      operatorDataGridViewTextBoxColumn.Items.Add(GridRule.eOperator.Equal);
      operatorDataGridViewTextBoxColumn.Items.Add(GridRule.eOperator.More);
      operatorDataGridViewTextBoxColumn.Items.Add(GridRule.eOperator.Contains);
    }

    internal void Init(GridRuleCollection gridRuleCollection)
    {
      this.gridRuleBindingSource.DataSource = gridRuleCollection;
    }

    private void reloadCurrentSetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Program.InitializeGridRules();
      Extender.ReApplyGridRules();
    }

    private void saveCurrentSetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Program.SaveGridRules();
    }

    private void importSetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var fileName = Dialogs.GetOpenGridRules();
      if (fileName == null) return;

      var rules = Dialogs.LoadGridRules(fileName);
      Program.GridRules = rules;
      Extender.ReApplyGridRules();
    }

    private void exportSetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var fileName = Dialogs.GetSaveGridRules();
      if (fileName == null) return;

      Dialogs.SaveGridRules(fileName, Program.GridRules);
    }
  }
}
