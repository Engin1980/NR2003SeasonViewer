using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENG.NR2003.Types;
using ENG.NR2003.NascarSeasonView.Types.Views;
using ENG.NR2003.NascarSeasonView.Types.Hints;
using ENG.NR2003.NascarSeasonView.Types;

namespace ENG.NR2003.NascarSeasonView.Controls
{
  public partial class WeekendOverview : UserControl
  {
    private Weekend weekend;

    public WeekendOverview()
    {
      InitializeComponent();
    }

    public void Init(WeekendInfo weekendData)
    {
      Init(weekendData.Weekend);
      Init(weekendData.Standings);
    }

    private void Init(WeekendStandings weekendStandings)
    {
      WeekendStandingsView view = new WeekendStandingsView(weekendStandings);
      ctrStandings.Init(view);
    }

    public void Init(Weekend weekend)
    {
      this.weekend = weekend;

      NonRaceSessionView nrsv = null;
      RaceSessionView rsv = null;

      InitWeekendTab(weekend);

      nrsv = new NonRaceSessionView(weekend.Practice);
      ctrPractice.Init(nrsv);

      nrsv = new NonRaceSessionView(weekend.Qualify);
      ctrQualify.Init(nrsv);

      nrsv = new NonRaceSessionView(weekend.HappyHour);
      ctrPreRace.Init(nrsv);

      if (weekend.Settings != null)
      {
        rsv = new RaceSessionView(weekend.Race, weekend.Settings.RaceLapCount);
        ctrRace.Init(rsv);
      }
    }

    private void InitWeekendTab(Weekend w)
    {
      lblWeekendName.Text = w.Name;
      lblTrackInfo.Text = w.Track.Name + " (" + w.Track.City + ", " + w.Track.State + ")";
      lblDate.Text = w.DayOfRace.ToLongDateString();
      txtTag.Text = w.Tag;

      if (w.Settings != null)
      {
        lblPracticeLength.Text = w.Settings.PracticeLength.ToString(false);
        lblQualifyLength.Text = w.Settings.QualifyLapCount.ToString() + " lap(s)";
        lblPreRaceLength.Text = w.Settings.PreRaceLength.ToString(false);
        lblRaceLength.Text = w.Settings.RaceLapCount.ToString() + " lap(s)";
      }

      if (w.Realism != null)
      {
        lblDamageLevel.Text = w.Realism.DamageLevel.ToString();
        chkAdaptiveSpeedControl.Checked = w.Realism.IsAdaptiveSpeedControlEnabled;
        chkDoubleFileRestarts.Checked = w.Realism.IsDoubleFileRestartEnabled;
        chkFullPaceLap.Checked = w.Realism.IsFullPaceLapEnabled;
        chkRealWeather.Checked = w.Realism.IsRealWeatherEnabled;
        chkYellowFlags.Checked = w.Realism.IsYellowFlagEnabled;
        lblMode.Text = w.Realism.Mode.ToString();
        lblOpponentsStrength.Text = w.Realism.OpponentStrength.ToString() + "%";
        lblMultiplier.Text = w.Realism.PitFuelMultiplier.ToString() + "x";
      }

      if (w.Race.IsEmpty() == false)
      {
        lblYellowPhasesCount.Text =
          w.Race.Yellows.Count.ToString();
        lblYellowPhasesLaps.Text =
          w.Race.Yellows.Sum(i => i.Length).ToString() + " lap(s)";
        lblTotalRaceTime.Text = w.Race.TotalRaceTime.ToString();
      }
    }

    private void WeekendOverview_Load(object sender, EventArgs e)
    {

    }

    private void btnEvaluateHints_Click(object sender, EventArgs e)
    {
      txtHints.Clear();
      if (this.weekend == null) return;

      var hints = AbstractHint.GetAllDefinedUsingReflection();
      foreach (var item in hints)
      {

        txtHints.AddText("*** " + item.Name + " ***");
        string[] d = item.Evaluate(weekend);
        foreach (var txt in d)
        {
          txtHints.AddText("\t" + txt);
        }
      }
    }

    public IEnumerable<DataGridView> GetGrids()
    {
      return new List<DataGridView>()
      {
        ctrPractice.GetGrid(),
        ctrQualify.GetGrid(),
        ctrRace.GetGrid(),
        ctrPreRace.GetGrid()
      };
    }

    private void txtTag_TextChanged(object sender, EventArgs e)
    {
      this.weekend.Tag = txtTag.Text;
    }
  }
}
