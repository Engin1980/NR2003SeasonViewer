using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;
using Scorings;
using ENG.NR2003.NascarSeasonView.Forms;

namespace ENG.NR2003.NascarSeasonView.Types.BOs
{
  class WeekendWizard
  {
    public static Weekend RunNewWeekendProvider(Season relativeSeason)
    {
      Weekend ret = new Weekend();

      FrmNewWeekend f = new FrmNewWeekend();
      f.Init(relativeSeason.Tracks);
      f.ShowDialog();
      var res = f.Result;

      if (res == null)
        return null;

      ret.DayOfRace = res.RaceDate;
      ret.Name = res.WeekendName;
      ret.Track = res.Track;
      ret.Realism = new WeekendRealism() { OpponentStrength = res.OpponentStrength };
      if (res.AnalyseIniFile)
        ret.IniFile = AnalyseIniFile(res.Track);

#if DEBUG
      if (ret.IsValid() == false)
        throw new ApplicationException("Created weekend is not valid.");
#endif

      return ret;
    }

    private static TrackIniFile AnalyseIniFile(Track t)
    {
      TrackIniFile ret = null;

      if (t.IniFile != null && System.IO.File.Exists(t.IniFile))
      {
        ret = TrackIniLoader.LoadTrackIniFile(t.IniFile);
      }

      return ret;
    }

    internal static void FillWeekendFromTelemetry(Weekend w, out bool changed)
    {
      changed = false;
      FrmImportLog f = new FrmImportLog();
      f.Init(w);
      f.ShowDialog();
      var res = f.Result;

      if (res == null)
        return;

      changed = true;
      FillWeekend(w, res);      
    }

    private static void FillWeekend(Weekend w, FrmImportLog.ResultData res)
    {
      if (res.Practice != null)
        FillSession(w.Practice, res.Practice);

      if (res.Qualify != null)
        FillSession(w.Qualify, res.Qualify);

      if (res.PreRace != null)
        FillSession(w.HappyHour, res.PreRace);

      if (res.Race != null)
        FillSession(w.Race, res.Race);
    }

    private static void FillSession(RaceSession session, List<ENG.NR2003.TelemetryEvents.TelemetryEvent> list)
    {
      if (session == null)
        throw new ArgumentNullException();
      if (list == null)
        throw new ArgumentNullException();
      if (session.IsEmpty() == false)
        throw new ArgumentException("Cannot fill non-empty session.");

      EventFiller ef = new EventFiller();
      Type t = typeof(EventFiller);
      foreach (var item in list)
      {
        System.Reflection.MethodInfo mi = t.GetMethod("Fill", new Type[] { session.GetType(), item.GetType() });
        mi.Invoke(ef, new object[] { session, item });
      }

      session.EvaluateLapsAndBuildPositions();
      session.RegisterPitLaps();
      session.EvaluateYellowPhasesLaps();
    }

    private static void FillSession(NonRaceSession session, List<ENG.NR2003.TelemetryEvents.TelemetryEvent> list)
    {
      if (session == null)
        throw new ArgumentNullException();
      if (list == null)
        throw new ArgumentNullException();
      if (session.IsEmpty() == false)
        throw new ArgumentException("Cannot fill non-empty session.");

      EventFiller ef = new EventFiller();
      Type t = typeof(EventFiller);
      foreach (var item in list)
      {
        System.Reflection.MethodInfo mi = t.GetMethod("Fill", new Type[] { session.GetType(), item.GetType() });
        mi.Invoke(ef, new object[] { session, item });
      }

      session.RecalculateLapTimes();
      session.RefreshLinks();
      session.BuildPositions();
    }
  }
}
