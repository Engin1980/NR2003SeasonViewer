using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.StaticRaceWeekend.Sessions;
using ENG.NR2003.TelemetryEvents;
using ENG.NR2003.StaticRaceWeekend.Standings;

namespace ENG.NR2003.StaticRaceWeekend.Updaters.Support
{
  public static class StandingsUpdater
  {
    private delegate void StandingsEntryUpdaterDelegate(Session s, StandingsEntry e);

    internal static void Update(StaticRaceWeekend.Weekend w, TelemetryEvents.Standings e, out Session updatedSession)
    {
      var s = GetSessionById(w, e.SessionNum);
      if (s == null)
        throw new Exception("Invalid session number.");

      UpdateSession (s, e);

      updatedSession = s;
    }

    private static void UpdateSession(Session sess, ENG.NR2003.TelemetryEvents.Standings e)
    {
      foreach (var fItem in e.Positions)
      {
        if (fItem.IsValid == false) continue;

        var s = GetCorrespondingStandingForStandingsentry(fItem.CarIdx, sess);
        UpdateStanding(s, fItem);
      }

      sess.Standings.Sort();
    }



    private static void UpdateStanding(Standing s, StandingsEntry se)
    {
      if (s is NonRaceStanding)
        StandingsEntryUpdater.Update(se, s as NonRaceStanding);
      else
        StandingsEntryUpdater.Update(se, s as RaceStanding);
    }

    private static Standing GetCorrespondingStandingForStandingsentry(int carIdx, Session sess)
    {
      foreach (var fItem in sess.Standings)
      {
        if (fItem.Driver.CarIdx == carIdx)
          return fItem;
      } // foreach (var fItem in sess.Standings)

      throw new Exception("Failed to find corresponding standing entry for  carIdx=" + carIdx + ".");
    }

    private static Session GetSessionById(StaticRaceWeekend.Weekend  w, int sessionNum)
    {
      Session ret = null;
      if (sessionNum == w.Practice.SessionNum)
        ret = w.Practice;
      else if (sessionNum == w.Qualify.SessionNum)
        ret = w.Qualify;
      else if (sessionNum == w.HappyHour.SessionNum)
        ret = w.HappyHour;
      else if (sessionNum == w.Race.SessionNum)
        ret = w.Race;
      else
        ret = null;

      w.SetCurrentSession(ret);

      return ret;
    }
  }
}
