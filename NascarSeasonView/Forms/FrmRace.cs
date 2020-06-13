using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENG.NR2003.Types;
using ENG.NR2003.NascarSeasonView.Types;
using ENG.NR2003.NascarSeasonView.Types.BOs;
using ENG.NR2003.NascarSeasonView.Types.GridRules;

namespace ENG.NR2003.NascarSeasonView.Forms
{
  public partial class FrmRace : Form
  {
    private Weekend weekend;
    private WeekendInfo weekendData;

    public FrmRace()
    {
      InitializeComponent();
    }

    public FrmRace(Weekend weekend)
      : this()
    {
      if (weekend == null)
        throw new ArgumentNullException("Argument \"weekend\" is null.");

      this.weekend = weekend;
    }

    public FrmRace(WeekendInfo weekendData)
      : this()
    {
      if (weekendData == null)
        throw new ArgumentNullException("Argument \"weekendData\" is null.");

      this.weekendData = weekendData;
      this.weekend = weekendData.Weekend;
    }

    private void telemetryFileOverviewToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //string newFile = Dialogs.GetOpenTelemetry();

      //ReadFileLogJob job = new ReadFileLogJob();
      //job.LogFileName = newFile;

      //job.Do("Scanning selected file", null, null);

      //var result = job.Result;

      //MessageBox.Show("Found " + result.Count + " blocks.");
      //foreach (var fItem in result)
      //{
      //  Dictionary<Type, List<object>> dct = new Dictionary<Type, List<object>>();

      //  foreach (var item in fItem.Events)
      //  {
      //    if (dct.ContainsKey(item.GetType()) == false)
      //      dct.Add(item.GetType(), new List<object>());
      //    dct[item.GetType()].Add(fItem);
      //  }

      //  StringBuilder sb = new StringBuilder();

      //  foreach (var item in dct.Keys)
      //  {
      //    sb.AppendLine(item.Name + " :: " + dct[item].Count);
      //  }

      //  MessageBox.Show(sb.ToString());
      //} // foreach (var fItem in result)
    }

    private void FrmRace_Load(object sender, EventArgs e)
    {
      if (DesignMode == false)
        _Refresh();
    }

    private void addRaceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      bool changed = false;
      WeekendWizard.FillWeekendFromTelemetry(weekend, out changed);

      if (changed)
      {
        if (weekend.Race.IsEmpty() == false)
          SeasonEvaluator.ReEvaluate(weekend.Season, weekend);

        _Refresh();
        TryUpdateSeasonForm();
      }
    }

    private void _Refresh()
    {
      this.Text = weekend.Name + " [weekend]";

      if (weekendData != null)
        ctrWeekend.Init(weekendData);
      else
        ctrWeekend.Init(weekend);
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void FrmRace_FormClosed(object sender, FormClosedEventArgs e)
    {
      TryUpdateSeasonForm();
    }

    private void TryUpdateSeasonForm()
    {
      if (this.weekendData == null) return;

      WindowManager.FrmSeasonUpdateManager.UpdateFrmSeason(this.weekendData);
    }

    private void renameRaceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string newName = FrmInputBox.ShowDialog(
        "Enter new race name:", "Rename race...", this.weekend.Name, i => String.IsNullOrWhiteSpace(i) == false);
      if (this.weekend.Name != newName)
      {
        this.weekend.Name = newName;
        ctrWeekend.Init(this.weekend);
        TryUpdateSeasonForm();
      }
    }

    private void changeOpponentsStrengthToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string newStrength = FrmInputBox.ShowDialog(
        "Enter new strength as number between 70 and 120:", "Enter new opponents strength...", this.weekend.Realism.OpponentStrength.ToString(),
        i =>
        {
          int p;
          if (int.TryParse(i, out p) == false) return false;
          if (p < 70 || p > 120) return false;
          return true;
        }
        );
      int newVal = int.Parse(newStrength);
      if (this.weekend.Realism.OpponentStrength != newVal)
      {
        this.weekend.Realism.OpponentStrength = newVal;
        ctrWeekend.Init(this.weekend);
        TryUpdateSeasonForm();
      }

    }

    private void telemetryFileViewToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FrmTelemetryView f = new FrmTelemetryView();
      f.Show();
    }

    private void raceLapByLapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Types.Views.RaceForChartSessionView rlsv = new Types.Views.RaceForChartSessionView(
        this.weekend.Race);

      FrmViewDetails f = new FrmViewDetails(rlsv.GetAll());

      f.Show();
    }

    private void changeRacedateToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string dateFormat = "yyyy-MM-dd";
      string newStrength = FrmInputBox.ShowDialog(
        "Enter new date of race in format yyyy-mm-dd, e.g. 2001-01-01:", "Enter new race date...", this.weekend.DayOfRace.ToString(dateFormat),
        i =>
        {
          DateTime o;
          return
            DateTime.TryParse(i, out o);
        }
        );
      DateTime newVal = DateTime.Parse(newStrength);
      if (this.weekend.DayOfRace != newVal)
      {
        this.weekend.DayOfRace = newVal;
        ctrWeekend.Init(this.weekend);
        TryUpdateSeasonForm();
      }
    }

    private void allToolStripMenuItem_Click(object sender, EventArgs e)
    {
      RemoveTelemetryDataFromCurrentRaceWeekend(true, true, true, true);
    }

    private void qualifyHappyHourRaceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      RemoveTelemetryDataFromCurrentRaceWeekend(false, true, true, true);
    }

    private void happyHourRaceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      RemoveTelemetryDataFromCurrentRaceWeekend(false, false, true, true);
    }

    private void raceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      RemoveTelemetryDataFromCurrentRaceWeekend(false, false, false, true);
    }

    private void RemoveTelemetryDataFromCurrentRaceWeekend(bool practice, bool qualify, bool happyHour, bool race)
    {
      if (race && weekend.Race.IsEmpty() == false)
        weekend.Race.Clear();
      if (happyHour && weekend.HappyHour.IsEmpty() == false)
        weekend.HappyHour.Clear();
      if (qualify && weekend.Qualify.IsEmpty() == false)
        weekend.Qualify.Clear();
      if (practice && weekend.Practice.IsEmpty() == false)
        weekend.Practice.Clear();
      _Refresh();
    }


    public IEnumerable<DataGridView> GetGrids()
    {
      return this.ctrWeekend.GetGrids();
    }
  }
}
