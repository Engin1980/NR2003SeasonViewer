using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.StaticRaceWeekend.Standings;
using ENG.NR2003.TelemetryEvents;
using System.Diagnostics.Contracts;

namespace ENG.NR2003.StaticRaceWeekend.Updaters.Support
{
  internal static class StandingsEntryUpdater
  {
    public static void Update(StandingsEntry source, RaceStanding target)
    {
      Update(source, target as Standing);
    }

    public static void Update(StandingsEntry source, NonRaceStanding target)
    {
      Update(source, target as Standing);

      target.OfficialBestTime = source.Time;
      target.OfficialLapNumber = source.Lap;
    }

    private static void Update(StandingsEntry source, Standing target)
    {
      Contract.Requires(source.CarIdx == target.Driver.CarIdx, "CarIdx does not match.");

      target.Incidents = source.Incidents;
      if (target is RaceStanding)
        (target as RaceStanding).Status = GetStatusFor(source.ReasonOut);
    }

    private static RaceStanding.eStatus GetStatusFor(StandingsEntry.eReasonsOut reasonsOut)
    {
      RaceStanding.eStatus ret;
      switch (reasonsOut)
      {
        case StandingsEntry.eReasonsOut.kReasonOutAccident:
          ret =RaceStanding.eStatus.Accident;
          break;
        case StandingsEntry.eReasonsOut.kReasonOutDisqualified:
          ret = RaceStanding.eStatus.DQ;
          break;
        case StandingsEntry.eReasonsOut.kReasonOutRetired:
          ret = RaceStanding.eStatus.Retired;
          break;
        case StandingsEntry.eReasonsOut.kReasonOutNotOut:
          ret = RaceStanding.eStatus.Running;
          break;
        case StandingsEntry.eReasonsOut.kReasonOutEjected:
        case StandingsEntry.eReasonsOut.kReasonOutLostConnection:
          ret = RaceStanding.eStatus.OtherReason;
          break;
        default:
          ret = RaceStanding.eStatus.TechnicalFailure;
          break;
      }
      return ret;
    }
  }
}
