using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.StaticRaceWeekend.Sessions;
using ENG.NR2003.TelemetryEvents;
using System.Diagnostics.Contracts;

namespace ENG.NR2003.StaticRaceWeekend.Updaters.Support
{
  internal static class SessionInfoUpdater
  {
    internal static void Update(StaticRaceWeekend.Weekend w, TelemetryEvents.SessionInfo e, out Session changedSession)
    {
      w.CurrentSessionType = GetSessionType(e.SessionType);
      Session s = GetSessionToUpdate(w, e);

      s.SessionNum = e.SessionNum;

      if (s is NonRaceSession)
        UpdateNonRaceSession(s as NonRaceSession, e);
      else
        UpdateRaceSession(s as RaceSession, e);

      w.SetCurrentSession(s);
      changedSession = s;
    }


    #region Private race

    private static void UpdateRaceSession(RaceSession session, SessionInfo e)
    {
      Contract.Requires(session.SessionNum == e.SessionNum);

      session.YPA.AddTime(e.CurrentTime, e.SessionFlag == SessionInfo.eSessionFlag.kFlagYellow);
    }

    #endregion Private race

    #region Private non-race
    private static void UpdateNonRaceSession(NonRaceSession session, SessionInfo e)
    {
      Contract.Requires(session.SessionNum == e.SessionNum);
    }
    #endregion Private non-race

    #region Private universal
    private static Session.eSessionState GetSessionState(SessionInfo.eSessionState eSessionState)
    {
      int val = (int)eSessionState;
      Session.eSessionState ret = (Session.eSessionState)val;
      return ret;
    }
    private static Session GetSessionToUpdate(StaticRaceWeekend.Weekend w, TelemetryEvents.SessionInfo e)
    {
      Session ret = null;
      switch (e.SessionType)
      {
        case TelemetryEvents.SessionInfo.eSessionType.kSessionTypePractice:
          ret = w.Practice;
          break;
        case TelemetryEvents.SessionInfo.eSessionType.kSessionTypeQualifyLone:
        case TelemetryEvents.SessionInfo.eSessionType.kSessionTypeQualifyOpen:
          ret = w.Qualify;
          break;
        case TelemetryEvents.SessionInfo.eSessionType.kSessionTypeTesting:
          ret = w.HappyHour;
          break;
        case TelemetryEvents.SessionInfo.eSessionType.kSessionTypeRace:
          ret = w.Race;
          break;
        default:
          throw new NotImplementedException();
      }

      return ret;
    }
    private static StaticRaceWeekend.Weekend.eSessionType GetSessionType(TelemetryEvents.SessionInfo.eSessionType eSessionType)
    {
      int val = (int)eSessionType;
      StaticRaceWeekend.Weekend.eSessionType ret = (StaticRaceWeekend.Weekend.eSessionType)val;
      return ret;
    }
    #endregion Private universal

  }
}
