using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ENG.NR2003.Types;
using ENG.NR2003.NascarSeasonView.Types.GridRules;
using ENG.NR2003.NascarSeasonView.Forms;
using ENG.NR2003.NascarSeasonView.Types;
using ENG.NR2003.NascarSeasonView.Types.Views;

namespace ENG.NR2003.NascarSeasonView
{
  static class Program
  {
    public static GridRuleCollection GridRules { get; set; }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      InitializeGridRules();

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      FrmSeason s = null;

      while (s == null)
      {
        FrmIntro f = new FrmIntro();
        f.ShowDialog();
        if (f.EResult == FrmIntro.eResult.OpenSeason)
        {
          s = OpenSeason();
        }
        else if (f.EResult == FrmIntro.eResult.NewSeason)
        {
          s = NewSeason();
        }
        else
          break;
      }

      if (s != null)
      {
        s.Show();
        s.Activate();
        Application.Run();
      }

      Application.Exit();
    }

    public static double ConvertTimeToSpeed (double trackLength, double time)
    {
      double trackLengthInMiles = trackLength / 1609.344;
      double timeInHour = time / 3600;
      double speedInMPH = trackLengthInMiles / timeInHour;

      return speedInMPH;
    }

    private static FrmSeason NewSeason()
    {
      FrmSeason f = new FrmSeason();

      if (WindowManager.NewSeasonInto(f) == false)
        return null;

      return f;
    }

    private static FrmSeason OpenSeason()
    {
      FrmSeason f = new FrmSeason();
      if (WindowManager.OpenSeasonInto(f) == false)
        return null;

      return f;
    }

    internal static void OnImportantFormClosing(Form closedForm)
    {
      var forms = Application.OpenForms;
      List<Form> lst = new List<Form>();
      foreach (Form item in forms)
        lst.Add(item);

      if (lst.Contains(closedForm))
        lst.Remove(closedForm);

      if (lst.Count == 0)
      {
        SaveGridRules();
        Properties.Settings.Default.Save();
        Application.Exit();
      }
    }

    private static string GetGridRulesDefaultFile()
    {
      return
        System.IO.Path.Combine(
          System.IO.Path.GetDirectoryName(Application.UserAppDataPath),
         "gridRules.xml");
    }
    internal static void InitializeGridRules()
    {
      try
      {
        GridRules = Dialogs.LoadGridRules(GetGridRulesDefaultFile());
      }
      catch
      {
        GridRules = new GridRuleCollection();
      }
    }

    internal static void SaveGridRules()
    {
      Dialogs.SaveGridRules(GetGridRulesDefaultFile(), GridRules);
    }
  }
}
