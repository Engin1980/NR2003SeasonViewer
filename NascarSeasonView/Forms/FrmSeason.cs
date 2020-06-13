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
using ENG.NR2003.NascarSeasonView.Types.Views;
using ENG.NR2003.NascarSeasonView.Types.BOs;

namespace ENG.NR2003.NascarSeasonView.Forms
{
  public partial class FrmSeason : Form
  {
    private string fullFileName;
    private string fileName { get { return System.IO.Path.GetFileName(fullFileName); } }
    public Season Season{get;private set;}

    public FrmSeason()
    {
      InitializeComponent();
    }

    public FrmSeason(Season season) : this()
    {
      if (season == null)
        throw new ArgumentNullException("Argument \"season\" is null.");

      this.Season = season;

      WindowManager.FrmSeasonUpdateManager.RegisterFrmSeason(this);
    }

    public void SetSeason(Season season, string fullFileName)
    {
      if (season == null)
        throw new ArgumentNullException("Argument \"season\" is null.");

      this.Season = season;
      this.fullFileName = fullFileName;
      RefreshData();
    }

    public void RefreshData()
    {
      this.Text =
        string.Format("{0} [season - {1}]",
        Season.Name,
        string.IsNullOrEmpty(fileName) ? "" : fileName);


      BuildRacesView(this.Season.RaceWeekends);
      BuildStandingsView(this.Season.GetLastWeekendStandings());
    }

    private void BuildStandingsView(WeekendStandings weekendStandings)
    {
      WeekendStandingsView wsv = new WeekendStandingsView(weekendStandings);
      Extender.BuildGridForView(grdStandings, wsv, false);
    }

    private void BuildRacesView(WeekendInfoCollection weekendDataCollection)
    {
      SeasonRacesView srv = new SeasonRacesView(weekendDataCollection);
      Extender.BuildGridForView(grdRaces, srv, false);
    }

    private void FrmSeason_Resize(object sender, EventArgs e)
    {
      AdjustTopButtonsSize();
    }

    private void AdjustTopButtonsSize()
    {
      double middle = this.Width / 2;

      rdbRaces.Top = 3;
      rdbRaces.Left = 3;
      rdbRaces.Height = pnlTop.Height - 2 * 3;
      rdbRaces.Width = (int)(middle - 3 - 1);

      rdbStandings.Top = 3;
      rdbStandings.Left = (int)(middle + 1);
      rdbStandings.Height = pnlTop.Height - 2 * 3;
      rdbStandings.Width = (int)(middle - 3 - 3 - 3 - 1);
    }

    private void FrmSeason_Load(object sender, EventArgs e)
    {
      AdjustTopButtonsSize();
      AdjustGridVisibility();

      if (DesignMode == false)
        RefreshData();
    }

    private void AdjustGridVisibility()
    {
      grdRaces.Visible = rdbRaces.Checked;
      grdStandings.Visible = rdbStandings.Checked;
    }

    private void rdbRaces_CheckedChanged(object sender, EventArgs e)
    {
      AdjustGridVisibility();
    }

    private void addRaceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Weekend w = WeekendWizard.RunNewWeekendProvider(this.Season);

      if (w != null)
      {
        WeekendInfo wd = new WeekendInfo(w);
        this.Season.RaceWeekends.Add(wd);

        //bool changed = false;
        //WeekendWizard.FillWeekendFromTelemetry(w, out changed);
        //SeasonEvaluator.ReEvaluate(this.season, this.season.RaceWeekends.Count - 1);

        RefreshData();

        FrmRace f = new FrmRace(wd);
        f.Show();

      }
    }

    private void saveSeasonToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty( this.fullFileName ))
      {
        string fn = Dialogs.GetSaveSeason(null);
        if (fn == null) return;
        this.fullFileName = fn;
      }
      SaveSeason();
    }

    private void openSeasonToolStripMenuItem_Click(object sender, EventArgs e)
    {
      WindowManager.OpenSeasonInto(this);
    }

    private void saveSeasonasToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string fn = Dialogs.GetSaveSeason(this.fullFileName);

      if (fn != null)
      {
        this.fullFileName = fn;
        SaveSeason();
      }
    }

    private void SaveSeason()
    {
      Dialogs.SaveSeason(this.fullFileName, this.Season);
      MessageBox.Show("Season saved.");
    }

    private void tracksToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FrmTrackList f = new FrmTrackList();
      f.Init(Season.Tracks);
      f.Show();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void newSeasonToolStripMenuItem_Click(object sender, EventArgs e)
    {
      WindowManager.NewSeasonInto(this);
    }

    private void editRaceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFormWithCurrentRaceFromGrid();
    }

    private void OpenFormWithCurrentRaceFromGrid()
    {
      if (grdRaces.SelectedCells.Count == 0) return;

      int rowIndex = grdRaces.SelectedCells[0].RowIndex;

      WeekendInfo wd = this.Season.RaceWeekends[rowIndex];

      FrmRace f = new FrmRace(wd);
      f.Show();
    }

    private void grdRaces_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      OpenFormWithCurrentRaceFromGrid();
    }

    private void FrmSeason_FormClosed(object sender, FormClosedEventArgs e)
    {
      Program.OnImportantFormClosing(this);
    }

    private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //var data = 
      //  new Types.Views.WeekendForChartStandingsView()

      //FrmViewDetails f = new FrmViewDetails(data);
    }

  }
}
