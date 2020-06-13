using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ENG.NR2003.NascarSeasonView.Types;

namespace ENG.NR2003.NascarSeasonView.Forms
{
  public partial class FrmNewSeason : Form
  {
    public class Result
    {
      public string SeasonName;
      public Type ScoringType;
      public string TracksFolder;
    }
    private class ScoringItem
    {
      public Type ScoringType;
      public string Name;
      public string Description;

      public override string ToString()
      {
        return Name;
      }
    }

    public FrmNewSeason()
    {
      InitializeComponent();
    }

    public Result ResultData
    {
      get
      {
        if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
          return new Result()
          {
            SeasonName = txtSeasonName.Text,
            ScoringType = (cmbScoring.SelectedItem as ScoringItem).ScoringType,
            TracksFolder = fbdTracks.FolderName
          };
        else
          return null;
      }
    }

    private void ReFillScoringSystems()
    {
      cmbScoring.Items.Clear();

      Type t = typeof(Scorings.AbstractScoring);
      Assembly a = t.Assembly;

      Type[] subTypes = a.GetTypes().Where(i => t.IsAssignableFrom(i) && i.IsAbstract == false).ToArray();

      foreach (var item in subTypes)
      {
        ScoringItem si = new ScoringItem();
        si.ScoringType = item;
        Scorings.AbstractScoring instance = Activator.CreateInstance(item) as Scorings.AbstractScoring;
        si.Name = instance.Name;
        si.Description = instance.Description;

        cmbScoring.Items.Add(si);
      }


    }

    private void FrmNewSeason_Load(object sender, EventArgs e)
    {
      string p = Common.TryGetNR2003Path();
      if (p != null)
      {
        p = System.IO.Path.Combine(p, "Tracks");
        fbdTracks.FolderName = p;
      }
      ReFillScoringSystems();
      cmbScoring.SelectedIndex = 0;
    }

    private void cmbScoring_SelectedIndexChanged(object sender, EventArgs e)
    {
      lblScoring.Text =
        (cmbScoring.SelectedItem as ScoringItem).Description;
    }
  }
}
