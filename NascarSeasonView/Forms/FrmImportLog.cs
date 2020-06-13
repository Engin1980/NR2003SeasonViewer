using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENG.NR2003.TelemetryEvents;
using System.Diagnostics.Contracts;
using ENG.NR2003.NascarSeasonView.Jobs.SmartTelemetryLoading;
using ENG.NR2003.Types;
using ENG.NR2003.NascarSeasonView.Types;
using ENG.NR2003.NascarSeasonView.Jobs.SimpleTelemetryLoading;

namespace ENG.NR2003.NascarSeasonView.Forms
{
  public partial class FrmImportLog : Form
  {

    private  const int PRACTICE_SESSION_NUMBER = 0;
    private  const int PRE_RACE_SESSION_NUMBER = 2;
    public class ResultData
    {
      public List<TelemetryEvent> Practice { get; set; }
      public List<TelemetryEvent> Qualify { get; set; }
      public List<TelemetryEvent> PreRace { get; set; }
      public List<TelemetryEvent> Race { get; set; }
    }

    private class ComboItem
    {
      public readonly SessionBlock Item;
      private int index;

      public override string ToString()
      {
        StringBuilder ret = new StringBuilder();

        ret.Append(index + ". " + Item.CurrentWeekend.Track + " - " + Item.SessionInfo.SessionType.ToString() +
          " N/C:" + Item.SessionInfo.SessionNum + "/" + Item.SessionInfo.SessionCookie
          + " [" + Item.Events.Count + " events]");

        return ret.ToString();
      }
      public ComboItem(SessionBlock item, int index)
      {
        this.index = index;
        this.Item = item;
      }
    }
    public Weekend Weekend { get; private set; }

    public ResultData Result
    {
      get
      {
        if (this.DialogResult != System.Windows.Forms.DialogResult.OK) return null;

        ResultData ret = new ResultData();
        ret.Practice = GetSelectedTelemetryFromCombo(cmbPractice);
        ret.Qualify = GetSelectedTelemetryFromCombo(cmbQualify);
        ret.PreRace = GetSelectedTelemetryFromCombo(cmbHappyHour);
        ret.Race = GetSelectedTelemetryFromCombo(cmbRace);
        return ret;
      }
    }

    private List<TelemetryEvent> GetSelectedTelemetryFromCombo(ComboBox cmb)
    {
      if (cmb.SelectedItem == null) return null;

      ComboItem ci = cmb.SelectedItem as ComboItem;
      if (ci == null)
        return null;
      else
      {
        List<TelemetryEvent> ret = new List<TelemetryEvent>();
        ret.Add(ci.Item.CurrentWeekend);
        ret.Add(ci.Item.SessionInfo);
        ret.AddRange(ci.Item.Drivers);
        ret.AddRange(ci.Item.Events);
        return ret;
      }
    }

    public FrmImportLog()
    {
      InitializeComponent();
    }

    public void Init()
    {
      Init(null);
    }
    public void Init(Weekend raceWeekend)
    {
      Weekend = raceWeekend;

      AdjustFormByWeekendContent();
    }

    private void AdjustFormByWeekendContent()
    {
      lblPracticeWarning.Visible = false;
      lblQualifyWarning.Visible = false;
      lblHappyHourWarning.Visible = false;
      lblRaceWarning.Visible = false;

      if (Weekend == null)
        return;


      if (Weekend.Practice.IsEmpty() == false)
        lblPracticeWarning.Visible = true;
      if (Weekend.Qualify.IsEmpty() == false)
        lblQualifyWarning.Visible = true;
      if (Weekend.HappyHour.IsEmpty() == false)
        lblHappyHourWarning.Visible = true;
      if (Weekend.Race.IsEmpty() == false)
        lblRaceWarning.Visible = true;
    }

    private void txtFile_TextChanged(object sender, EventArgs e)
    {
      if (LogFileExists())
        UserGivesOkFile();
      else
        UserGivesInvalidFile();
    }

    private bool LogFileExists()
    {
      if (System.IO.File.Exists(txtFile.Text))
        return true;
      else
        return false;
    }

    private void UserGivesOkFile()
    {
      btnScan.Enabled = true;
      txtFile.ForeColor = System.Drawing.SystemColors.WindowText;
    }

    private void UserGivesInvalidFile()
    {
      btnScan.Enabled = false;
      txtFile.ForeColor = System.Drawing.Color.Red;
    }

    private void btnSelectFile_Click(object sender, EventArgs e)
    {
      string newFile = Dialogs.GetOpenTelemetry();

      if (newFile != null)
        txtFile.Text = newFile;
    }

    private void btnScan_Click(object sender, EventArgs e)
    {
      btnScan.Enabled = false;
      btnProcess.Enabled = false;
      Application.DoEvents();

      var events = SimpleTelemetryLoader.LoadTelemetry(txtFile.Text);
      var smartData = SmartTelemetryAnalyser.AnalyseTelemetry(events);

      ClearCombos();

      int index = 1;
      foreach (var fItem in smartData)
      {
        ComboItem ci = new ComboItem(fItem, index);

        if (fItem.SessionInfo.SessionType == SessionInfo.eSessionType.kSessionTypePractice 
          && fItem.SessionInfo.SessionNum == PRACTICE_SESSION_NUMBER)
          cmbPractice.Items.Add(ci);
        if (fItem.SessionInfo.SessionType == SessionInfo.eSessionType.kSessionTypeQualifyLone ||
          fItem.SessionInfo.SessionType == SessionInfo.eSessionType.kSessionTypeQualifyOpen)
          cmbQualify.Items.Add(ci);
        if (fItem.SessionInfo.SessionType == SessionInfo.eSessionType.kSessionTypePractice
          && fItem.SessionInfo.SessionNum == PRE_RACE_SESSION_NUMBER)
          cmbHappyHour.Items.Add(ci);
        if (fItem.SessionInfo.SessionType == SessionInfo.eSessionType.kSessionTypeRace)
          cmbRace.Items.Add(ci);

        index++;
      } // foreach (var fItem in result)

      btnScan.Enabled = true;
      btnProcess.Enabled = true;
    }

    private void ClearCombos()
    {
      cmbPractice.Items.Clear();
      cmbQualify.Items.Clear();
      cmbHappyHour.Items.Clear();
      cmbRace.Items.Clear();

      cmbPractice.Items.Add("< not defined >");
      cmbQualify.Items.Add("< not defined >");
      cmbHappyHour.Items.Add("< not defined >");
      cmbRace.Items.Add("< not defined >");

      cmbPractice.SelectedIndex = 0;
      cmbQualify .SelectedIndex = 0;
      cmbHappyHour.SelectedIndex = 0;
      cmbRace.SelectedIndex = 0;
    }

    private void btnProcess_Click(object sender, EventArgs e)
    {
      if (AreRequiredData() == false)
      {
        MessageBox.Show("You cannot add race data without qualify data. Process cannot continue.");
        return;
      }
      if (DoCompatibilityCheckFailed())
      {
        MessageBox.Show("Selected events are not compatible. Check if tracks are the same. Process cannot continue.");
        return;
      }

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Hide();
    }

    private bool AreRequiredData()
    {
      if (cmbRace.SelectedIndex > 0)
      {
        if (cmbQualify.SelectedIndex < 1 &&
          this.Weekend.Qualify.IsEmpty())
          return false;
      }

      return true;
    }

    private ComboItem GetSelectedComboItem(ComboBox cmb)
    {
      if (cmb.SelectedIndex < 1)
        return null;
      else
        return cmb.SelectedItem as ComboItem;
    }
    private string GetSelectedComboBoxRaceNameOrNull(ComboBox cmb)
    {
      ComboItem ci = GetSelectedComboItem(cmb);
      if (ci == null)
        return null;
      else
        return ci.Item.CurrentWeekend.Track;
    }

    private bool DoCompatibilityCheckFailed()
    {
      return false;
      //DistinctList<string> tracks = new DistinctList<string>();
      //string trackName;

      //if (Weekend != null)
      //  tracks.Add(Weekend.Track);

      //trackName = GetSelectedComboBoxRaceNameOrNull(cmbPractice);
      //if (string.IsNullOrEmpty(trackName) == false) tracks.Add(trackName);
      //trackName = GetSelectedComboBoxRaceNameOrNull(cmbQualify);
      //if (string.IsNullOrEmpty(trackName) == false) tracks.Add(trackName);
      //trackName = GetSelectedComboBoxRaceNameOrNull(cmbHappyHour);
      //if (string.IsNullOrEmpty(trackName) == false) tracks.Add(trackName);
      //trackName = GetSelectedComboBoxRaceNameOrNull(cmbRace);
      //if (string.IsNullOrEmpty(trackName) == false) tracks.Add(trackName);

      //if (tracks.Count > 1)
      //  return true; // failed
      //else
      //  return false; // ok
    }

    private void lblPracticeWarning_VisibleChanged(object sender, EventArgs e)
    {
      cmbPractice.Visible = !lblPracticeWarning.Visible;
    }

    private void lblQualifyWarning_VisibleChanged(object sender, EventArgs e)
    {
      cmbQualify.Visible = !lblQualifyWarning.Visible;
    }

    private void lblHappyHourWarning_VisibleChanged(object sender, EventArgs e)
    {
      cmbHappyHour.Visible = !lblHappyHourWarning.Visible;
    }

    private void lblRaceWarning_VisibleChanged(object sender, EventArgs e)
    {
      cmbRace.Visible = !lblRaceWarning.Visible;
    }
  }
}
