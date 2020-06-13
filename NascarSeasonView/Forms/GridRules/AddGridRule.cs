using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESystem.Extensions;
using ENG.NR2003.NascarSeasonView.Types.GridRules;

namespace ENG.NR2003.NascarSeasonView.Forms.GridRules
{
  public partial class AddGridRule : Form
  {
    public AddGridRule()
    {
      InitializeComponent();
    }

    private void AddGridRule_Load(object sender, EventArgs e)
    {
      cmbOperation.SelectedIndex = 0;
    }

    private string gridName = null;
    public void Init(string gridName, string weekendName, string trackName, IEnumerable<string> columnHeaders, string prefferedCustomHeader, string defaultValue)
    {
      if (gridName == null)
      {
        rdbGridAll.Checked = true;
        rdbGridCurrentOnly.Enabled = false;
      }
      else
      {
        this.gridName = gridName;
        rdbGridCurrentOnly.Checked=true;
        rdbGridCurrentOnly.Enabled = true;
      }

      if (weekendName == null)
        rdbWeekendAll.Checked = true;
      else
      {
        rdbWeekendContains.Checked = true;
        txtWeekendContains.Text = weekendName;
      }

      if (trackName == null)
        rdbTrackAll.Checked = true;
      else
      {
        rdbTrackContains.Checked = true;
        rdbTrackContains.Text = trackName;
      }

      cmbHeaderText.Items.Clear();
      if (columnHeaders != null)
        columnHeaders.EForEach(i => cmbHeaderText.Items.Add(i));

      if (prefferedCustomHeader != null)
        cmbHeaderText.Text = prefferedCustomHeader;

      txtValue.Text = defaultValue;
    }

    public GridRule Result
    {
      get
      {
        if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
        {
          GridRule ret = new GridRule();
          ret.Color = picBackgroundColor.BackColor;
          ret.GridColumnHeaderText = cmbHeaderText.Text;
          ret.GridTypeName = gridName;
          ret.Operator = (GridRule.eOperator)cmbOperation.SelectedIndex;
          ret.TrackNameContains =
            rdbTrackContains.Checked ? txtTrackContains.Text : null;
          ret.Value = txtValue.Text;
          ret.WeekendNameContains =
            rdbWeekendContains.Checked ? txtWeekendContains.Text : null;

          return ret;
        }
        else
          return null;
      }
    }

    private void btnChangeColor_Click(object sender, EventArgs e)
    {
      if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        picBackgroundColor.BackColor = dlgColor.Color;
    }

    private void rdbWeekendContains_CheckedChanged(object sender, EventArgs e)
    {
      txtWeekendContains.Enabled = rdbWeekendContains.Checked;
    }

    private void rdbTrackContains_CheckedChanged(object sender, EventArgs e)
    {
      txtTrackContains.Enabled = rdbTrackContains.Checked;
    }

    private void cmbOperation_SelectedIndexChanged(object sender, EventArgs e)
    {
      CheckFormValidity();
    }

    private void CheckFormValidity()
    {
      btnOk.Enabled = true;

      if (string.IsNullOrWhiteSpace(cmbHeaderText.Text))
      {
        btnOk.Enabled = false;
        return;
      }

      if (cmbOperation.SelectedIndex < 0)
      {
        btnOk.Enabled = false;
        return;
      }

      if (string.IsNullOrWhiteSpace(txtValue.Text))
      {
        btnOk.Enabled = false;
        return;
      }
    }

    private void txtValue_TextChanged(object sender, EventArgs e)
    {
      CheckFormValidity();
    }

    private void cmbHeaderText_SelectedIndexChanged(object sender, EventArgs e)
    {
      CheckFormValidity();
    }
  }
}
