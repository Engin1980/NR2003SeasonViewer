using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.TelemetryEvents;

namespace ENG.NR2003.NascarSeasonView.Jobs.SmartTelemetryLoading
{
  public static class SmartTelemetryAnalyser
  {
    private const double REMAINING_TIME_OF_NEW_SESSION = -1.0;

    internal static SessionBlock[] AnalyseTelemetry(TelemetryEvent[] events)
    {

      List<SessionBlock> ret = new List<SessionBlock>();

      CurrentWeekend currentWeekend = null;
      SessionInfo currentSession = null;
      List<TelemetryEvent> currentSessionEvents = new List<TelemetryEvent>();
      List<DriverEntry> globalDrivers = new List<DriverEntry>();
      List<DriverEntry> localDrivers = new List<DriverEntry>();
      double lastSessionTime = 0;

      for (int f = 0; f < events.Length; f++)
      {
        TelemetryEvent te = events[f];

        if (te is DriverEntry)
        {
          if (currentWeekend == null)
          {
            DriverEntry existing = globalDrivers.FirstOrDefault(i => (i.CarIdx == (te as DriverEntry).CarIdx));
            if (existing != null)
            {
              if (AreDriverEntriesTheSame(existing, te as DriverEntry) == false)
                throw new ApplicationException("Duplicit driver entry CarIdx.");
            }
            else
              globalDrivers.Add(te as DriverEntry);
          }
          else
          {
            if (localDrivers.FirstOrDefault(i => (i.CarIdx == (te as DriverEntry).CarIdx)) != null)
              throw new ApplicationException("Duplicit driver entry CarIdx.");
            localDrivers.Add(te as DriverEntry);
          }
        }
        else if (te is DriverWithdrawl)
        {
        }
        else if (te is CurrentWeekend)
        {
          if (currentWeekend != null)
          {
            SessionBlock sb = BuildNewSessionBlock(
              currentWeekend, currentSession, currentSessionEvents,
              globalDrivers, localDrivers);
            ret.Add(sb);

            currentWeekend = null;
            localDrivers = new List<DriverEntry>();
          }
          CurrentWeekend x = te as CurrentWeekend;
          if (x.AtTrack == false)
            currentWeekend = null;
          else
            currentWeekend = x;
        }
        else if (te is SessionInfo)
        {
          //if (currentWeekend == null && currentSession == null) continue;

          SessionInfo x = te as SessionInfo;
          //bool isNewSession = (currentSession == null
          //  || IsNewSession(x));
          bool isNewSession = (currentSession == null ||
            x.CurrentTime <= lastSessionTime);

          if (isNewSession)
          {
            if (currentSession != null && currentWeekend != null)
            {
              SessionBlock sb = BuildNewSessionBlock(
                currentWeekend, currentSession, currentSessionEvents,
                globalDrivers, localDrivers);
              ret.Add(sb);
            }
            currentSession = x;
            currentSessionEvents = new List<TelemetryEvent>();
          }
          else
            currentSessionEvents.Add(te);

          lastSessionTime = x.CurrentTime;
        }
        else
        {
          if (currentSession != null)
            currentSessionEvents.Add(te);
        }
      }

      return ret.ToArray();
    }

    private static bool AreDriverEntriesTheSame(DriverEntry existing, DriverEntry driverEntry)
    {
      if (existing.CarFile != driverEntry.CarFile)
        return false;
      if (existing.CarIdx != driverEntry.CarIdx)
        return false;
      if (existing.CarMake != driverEntry.CarMake)
        return false;
      if (existing.CarNum != driverEntry.CarNum)
        return false;
      if (existing.Flags != driverEntry.Flags)
        return false;
      if (existing.Name != driverEntry.Name)
        return false;

      return true;
    }

    private static bool IsNewSession(SessionInfo x)
    {
      if (x.SessionType == SessionInfo.eSessionType.kSessionTypeRace)
        return x.SessionState == SessionInfo.eSessionState.kSessionStateGetInCar;
      else if (x.SessionType == SessionInfo.eSessionType.kSessionTypePractice)
        return x.TimeRemaining == SmartTelemetryAnalyser.REMAINING_TIME_OF_NEW_SESSION;
      else
        return x.TimeRemaining == SmartTelemetryAnalyser.REMAINING_TIME_OF_NEW_SESSION;
    }

    private static SessionBlock BuildNewSessionBlock(CurrentWeekend currentWeekend, SessionInfo currentSession, List<TelemetryEvent> currentSessionEvents, List<DriverEntry> globalDrivers, List<DriverEntry> localDrivers)
    {
      SessionBlock sb = new SessionBlock();
      sb.CurrentWeekend = currentWeekend;
      sb.SessionInfo = currentSession;
      sb.Drivers.AddRange(globalDrivers);
      sb.Drivers.AddRange(localDrivers);
      sb.Events = currentSessionEvents;
      return sb;
    }
  }
}
