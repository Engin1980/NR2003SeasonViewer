using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.TelemetryEvents;
using ENG.NR2003.Types;

namespace ENG.NR2003.NascarSeasonView.Types.BOs
{
  public class EventFiller
  {
    private Dictionary<int, Driver> drivers = new Dictionary<int, Driver>();

    #region Non-race

    public void Fill(NonRaceSession session, ApplicationExit te) { }

    public void Fill(NonRaceSession session, SessionInfo te) { }

    public void Fill(NonRaceSession session, Standings te) { }

    public void Fill(NonRaceSession session, DriverInCar te) { }

    public void Fill(NonRaceSession session, DriverWithdrawl te) { }

    public void Fill(NonRaceSession session, GamePaused te) { }

    public void Fill(NonRaceSession session, CurrentWeekend te)
    {
      if (te.AtTrack == false) return;

      CheckForValidTrack(te.Track, session.Weekend.Track);
      session.Weekend.Track.AdjustedLengthInFeet = (int)te.TrackLength;

      FillOrCheckCurrentWeekend(session, te);
    }

    public void Fill(NonRaceSession session, LapCrossing te)
    {
      int carIdx = te.CarIdx;

      if (session.Weekend.Drivers.ContainsKey(carIdx) == false)
        throw new ApplicationException("Failed to find driver with carIdx " + carIdx + " in registered drivers of weekend.");
      Driver d = session.Weekend.Drivers[carIdx];

      NonRaceLap l = new NonRaceLap();
      l.Driver = d;
      l.CrossedAtTime = Time.CreateFromSeconds(te.CrossedAt);
      if (l.CrossedAtTime.TotalMiliseconds < 0)
        throw new ApplicationException("CrossedAt below zero.");
      l.IsBlackFlagged = te.IsBlackFlagged;
      l.IsOffTrack = te.IsOffTrack;
      l.IsPitted = te.IsPitted;

      session.Laps.Add(l);
    }

    public void Fill(NonRaceSession session, DriverEntry te)
    {
      if (te.IsPaceCar) return;

      int carIdx = te.CarIdx;

      Driver d = session.Weekend.Season.Drivers.TryGetBestBy(te.CarNum, te.Name);
      if (d == null)
      {
        d = Driver.Create(te.CarNum, te.Name);
        session.Weekend.Season.Drivers.Add(d);
      }

      if (session.Weekend.Drivers.ContainsKey(carIdx))
      {
        Driver existing = session.Weekend.Drivers[carIdx];
        if (existing.Number != d.Number || existing.NameSurname != d.NameSurname)
          throw new Exception("The driver names with same number between sessions differs, which is not allowed in one race weekend.");
      }
      else
        session.Weekend.Drivers.Add(carIdx, d);
    }

    #endregion Non-race

    #region Race

    public void Fill(RaceSession session, ApplicationExit te) { }

    public void Fill(RaceSession session, SessionInfo te)
    {
      if (te.SessionFlag == SessionInfo.eSessionFlag.kFlagGreen)
      {
        if (HasOpenedYellowSession(session))
          session.Yellows[session.Yellows.Count - 1].EndTime = Time.CreateFromSeconds(te.CurrentTime);
      }
      else if (te.SessionFlag == SessionInfo.eSessionFlag.kFlagYellow)
      {
        if (HasOpenedYellowSession(session) == false)
        {
          YellowPhase yp = new YellowPhase();
          yp.StartTime = Time.CreateFromSeconds(te.CurrentTime);
          session.Yellows.Add(yp);
        }
      }
    }

    private bool HasOpenedYellowSession(RaceSession session)
    {
      if (session.Yellows.Count == 0) return false;
      if (session.Yellows[session.Yellows.Count - 1].IsValid() == false) return true;
      return false;
    }

    public void Fill(RaceSession session, Standings te)
    {
      if (te.IsOfficial == false) return;

      foreach (var item in te.Positions)
      {
        if (item.CarIdx == -1) continue; 

        Driver d = session.Weekend.Drivers[item.CarIdx];

        session.Positions.SetDriverFinalStatus(d,
          ConvertTelemetryEnumToAppEnum(item.ReasonOut));
      }
    }



    public void Fill(RaceSession session, DriverInCar te) { }

    public void Fill(RaceSession session, DriverWithdrawl te) { }

    public void Fill(RaceSession session, GamePaused te) { }

    public void Fill(RaceSession session, CurrentWeekend te)
    {
      if (te.AtTrack == false) return;

      FillOrCheckCurrentWeekend(session, te);
    }

    private void FillOrCheckCurrentWeekend(Session session, CurrentWeekend te)
    {
      if (session.Weekend.Settings == null || session.Weekend.Realism == null)
        FillByCurrentWeekend(session.Weekend, te);
    }

    private void FillByCurrentWeekend(Weekend weekend, CurrentWeekend te)
    {
      weekend.Settings = new WeekendSettings();
      weekend.Settings.PracticeLength = new Time(te.Sessions.PracticeLength);
      weekend.Settings.QualifyLapCount = te.Sessions.QualifyLapCount;
      weekend.Settings.PreRaceLength = new Time(te.Sessions.HappyHourLength);
      weekend.Settings.RaceLapCount = te.Sessions.RaceLapCount;

      weekend.Realism = new WeekendRealism();
      switch (te.Options.DamageLevel)
      {
        case CurrentWeekend.cwOptions.eDamageLevel.Full:
          weekend.Realism.DamageLevel = WeekendRealism.eDamageLevel.Full;
          break;
        case CurrentWeekend.cwOptions.eDamageLevel.Moderate:
          weekend.Realism.DamageLevel = WeekendRealism.eDamageLevel.Moderate;
          break;
        case CurrentWeekend.cwOptions.eDamageLevel.None:
          weekend.Realism.DamageLevel = WeekendRealism.eDamageLevel.None;
          break;
      }
      weekend.Realism.IsAdaptiveSpeedControlEnabled = te.Options.IsAdaptiveSpeedControlEnabled;
      weekend.Realism.IsDoubleFileRestartEnabled = te.Options.IsDoubleFileRestartEnabled;
      weekend.Realism.IsFullPaceLapEnabled = te.Options.IsFullPaceLapEnabled;
      weekend.Realism.IsRealWeatherEnabled = te.Options.IsRealWeatherEnabled;
      weekend.Realism.IsYellowFlagEnabled = te.Options.IsYellowFlagEnabled;
      weekend.Realism.PitFuelMultiplier = te.Options.PitFuelMultiplier;
      switch (te.Options.GameType)
      {
        case CurrentWeekend.cwOptions.eGameType.Arcade:
          weekend.Realism.Mode = WeekendRealism.eMode.Arcade;
          break;
        case CurrentWeekend.cwOptions.eGameType.Simulation:
          weekend.Realism.Mode = WeekendRealism.eMode.Simulation;
          break;
      }
    }

    public void Fill(RaceSession session, LapCrossing te)
    {
      int carIdx = te.CarIdx;

      if (session.Weekend.Drivers.ContainsKey(carIdx) == false)
        throw new ApplicationException("Failed to find driver with carIdx " + carIdx + " in registered drivers of weekend.");
      Driver d = session.Weekend.Drivers[carIdx];

      RaceLap l = new RaceLap();
      l.Driver = d;
      l.CrossedAtTime = Time.CreateFromSeconds(te.CrossedAt);
      if (l.CrossedAtTime.TotalMiliseconds < 0)
        throw new ApplicationException("CrossedAt below zero.");
      l.IsBlackFlagged = te.IsBlackFlagged;
      l.IsOffTrack = te.IsOffTrack;
      l.IsPitted = te.IsPitted;

      session.Laps.Add(l);
    }

    public void Fill(RaceSession session, DriverEntry te)
    {
      if (te.IsPaceCar) return;

      int carIdx = te.CarIdx;

      Driver d = session.Weekend.Season.Drivers.TryGetBestBy(te.CarNum, te.Name);
      if (d == null)
      {
        d = Driver.Create(te.CarNum, te.Name);
        session.Weekend.Season.Drivers.Add(d);
      }

      if (session.Weekend.Drivers.ContainsKey(carIdx))
      {
        Driver existing = session.Weekend.Drivers[carIdx];
        if (existing.Number != d.Number || existing.NameSurname != d.NameSurname)
          throw new Exception("The driver names with same number between sessions differs, which is not allowed in one race weekend.");
      }
      else
        session.Weekend.Drivers.Add(carIdx, d);
    }

    #endregion Race

    #region Fatal

    public void Fill(NonRaceSession session, TelemetryEvent te)
    {
      throw new NotImplementedException("No implementation to invoke non-race fill over " + te.GetType().FullName);
    }

    public void Fill(RaceSession session, TelemetryEvent te)
    {
      throw new NotImplementedException("No implementation to invoke race fill over " + te.GetType().FullName);
    }

    #endregion Fatal

    #region Other

    private void CheckForValidTrack(string trackName, Track track)
    {
      //if (track.Name.ToLower() != trackName.ToLower())
      //  throw new ApplicationException("Invalid track to match. Event has " + trackName + ", session is " + track.Name + ".");
    }

    private RacePositionCollection.eStatus ConvertTelemetryEnumToAppEnum(StandingsEntry.eReasonsOut reasonOut)
    {
      RacePositionCollection.eStatus ret;
      switch (reasonOut)
      {
        case StandingsEntry.eReasonsOut.kReasonOutAccident:
          ret = RacePositionCollection.eStatus.Accident;
          break;
        case StandingsEntry.eReasonsOut.kReasonOutDisqualified:
          ret = RacePositionCollection.eStatus.DQ;
          break;
        case StandingsEntry.eReasonsOut.kReasonOutRetired:
          ret = RacePositionCollection.eStatus.Retired;
          break;
        case StandingsEntry.eReasonsOut.kReasonOutNotOut:
          ret = RacePositionCollection.eStatus.Running;
          break;
        case StandingsEntry.eReasonsOut.kReasonOutEjected:
        case StandingsEntry.eReasonsOut.kReasonOutLostConnection:
          ret = RacePositionCollection.eStatus.OtherReason;
          break;
        default:
          ret = RacePositionCollection.eStatus.TechnicalFailure;
          break;
      }
      return ret;
    }

    #endregion Other
  }
}
