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
using NascarSeasonView.Types.Cups;

namespace ENG.NR2003.NascarSeasonView.Forms
{
  public partial class FrmNewWeekend : Form
  {
    public class ResultData
    {
      public string WeekendName { get; set; }
      public Track Track { get; set; }
      public DateTime RaceDate { get; set; }
      public bool AnalyseIniFile { get; set; }
      public int OpponentStrength { get; set; }
    }

    public FrmNewWeekend()
    {
      InitializeComponent();
    }

    public ResultData Result
    {
      get
      {
        if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
          return new ResultData()
          {
            RaceDate = dtpDate.Value,
            WeekendName = cmbRaces.Text,
            Track = (Track)cmbTracks.SelectedItem,
            AnalyseIniFile = chkAnalyseIniFile.Checked,
            OpponentStrength = (int) nudOpponentStrength.Value
          };
        else
          return null;
      }
    } 

    internal void Init(TrackCollection trackCollection)
    {
      FillTracks(trackCollection);
    }

    private void FillTracks(TrackCollection trackCollection)
    {
      cmbTracks.Items.Clear();

      foreach (var item in trackCollection)
      {
        cmbTracks.Items.Add(item);
      }
    }

    private void btnFillFromCup_Click(object sender, EventArgs e)
    {
      var cup = Common.LoadCupFromIniFile();
      if (cup == null) return;

      cmbRaces.Items.Clear();
      foreach (var item in cup.Races)
      {
        cmbRaces.Items.Add(item);
      }
    }

    private void cmbRaces_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (cmbRaces.SelectedIndex > -1)
      {
        CupRace cr = cmbRaces.SelectedItem as CupRace;

        foreach (Track track in cmbTracks.Items)
        {
          if (track.IniFileFolder.EndsWith(cr.TrackDirectory))
          {
            cmbTracks.SelectedItem = track;
            return;
          }
        }
      }
    }
  }
}
