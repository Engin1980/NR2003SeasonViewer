using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;
using ENG.NR2003.NascarSeasonView.Forms;
using ENG.NR2003.NascarSeasonView.Types.BOs;

namespace ENG.NR2003.NascarSeasonView.Types
{
  public static class WindowManager
  {
    public static bool OpenSeasonInto(FrmSeason f){
      string fn = Dialogs.GetOpenSeason();
      if (fn == null) return false;

      Season p = Dialogs.LoadSeason(fn);
      f.SetSeason(p, fn);
      return true;    
    }

    public static bool NewSeasonInto(FrmSeason f)
    {
      Season s = SeasonWizard.RunNewSeasonWizard();
      if (s == null) return false;

      f.SetSeason(s, "");
      return true;
    }

    public static class FrmSeasonUpdateManager
    {
      private static HashSet<FrmSeason> set = new HashSet<FrmSeason>();

      public static void RegisterFrmSeason(FrmSeason frm)
      {
        if (frm == null)
          throw new ArgumentNullException("Argument \"frm\" is null.");

        set.Add(frm);
      }

      public static void UnregisterFrmSeason(FrmSeason frm)
      {
        set.Remove(frm);
      }

      public static void UpdateFrmSeason(WeekendInfo weekendData)
      {
        foreach (var item in set)
        {
          if (item.Season != null && item.Season.RaceWeekends.Contains(weekendData))
            item.RefreshData();
        }
      }
    }
  }
}
