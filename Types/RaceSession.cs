using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Types.Base;
using System.Linq.Expressions;

namespace ENG.NR2003.Types
{
  /// <summary>
  /// Represents race session.
  /// </summary>
  [Serializable()]
  public class RaceSession : Session
  {
    #region Nested

    private enum eCrossedAtLapBehavior
    {
      LastLapBefore,
      FirstLapAfter
    }

    private class RaceLapByOrderInRaceComparer : IComparer<RaceLap>
    {

      public int Compare(RaceLap x, RaceLap y)
      {
        int ret = x.LapNumber.CompareTo(y.LapNumber) * -1;
        if (ret == 0)
          ret = x.CrossedAtTime.CompareTo(y.CrossedAtTime);
        return ret;
      }
    }
    #endregion Nested


    /// <summary>
    /// Gets all the laps of the race.
    /// </summary>
    public SessionLapCollection<RaceLap> Laps { get; private set; }
    /// <summary>
    /// Gets the positions after each lap in races.
    /// </summary>
    public RacePositionCollection Positions { get; private set; }
    /// <summary>
    /// Gets the pit laps.
    /// </summary>
    public RacePitCollection PitLaps { get; private set; }
    /// <summary>
    /// Gets the yellows phases.
    /// </summary>
    public YellowPhaseCollection Yellows { get; private set; }
    /// <summary>
    /// Gets the total race time.
    /// </summary>
    public Time TotalRaceTime { get; private set; }

    public RaceSession(Weekend parentWeekend)
      : base(parentWeekend)
    {
      this.Laps = new SessionLapCollection<RaceLap>(this);
      this.Positions = new RacePositionCollection();
      this.PitLaps = new RacePitCollection();
      this.Yellows = new YellowPhaseCollection();
    }

    public override bool IsEmpty()
    {
      return Positions.LapCount == 0 || Positions[1].Count == 0;
    }

    public void EvaluateLapsAndBuildPositions()
    {
      RaceLap zeroLapOfPolePosition;
      RaceLap winLapOfWinner;
      this.EvaluateLaps(out zeroLapOfPolePosition);
      this.BuildPositions(out winLapOfWinner);

      int diffMilis = 
        winLapOfWinner.CrossedAtTime.TotalMiliseconds - zeroLapOfPolePosition.CrossedAtTime.TotalMiliseconds;

      this.TotalRaceTime = new Time(diffMilis);
    }

    private static IComparable _GetLapCrossedAtTime(RaceLap lap)
    {
      return lap.CrossedAtTime;
    }

    private void EvaluateLaps(out RaceLap zeroLapOfPolePosition)
    {      
      Minner<RaceLap> m = new Minner<RaceLap>(
        (RaceLap l) => l.CrossedAtTime
         );
      RaceLap lapZero;

      var drivers = Laps.GetDrivers();
      foreach (var driver in drivers)
      {

        RecalculateLapTimesOfDriver(driver, out lapZero);
        m.Add(lapZero as RaceLap);
        Laps.Remove(0, driver);
        RefreshLinksOfDriver(driver);
      }

      zeroLapOfPolePosition = m.MinimumItem;
    }

    private void BuildPositions(out RaceLap winLapOfWinner)
    {
      winLapOfWinner = null;

      Positions.ClearExceptDriverFinalStatuses();
      List<RaceLap> laps = null;
      for (int i = 1; i <= Weekend.Settings.RaceLapCount; i++)
      {
        laps = GetLapsByLapNumber(i, true);
        LinkLapsInSameLapNumber(laps);
        laps.ForEach(k => Positions.AddLap(i, k));

        if (i == Weekend.Settings.RaceLapCount)
        {
          winLapOfWinner = laps[0] as RaceLap;
        }
      }
    }

    private void LinkLapsInSameLapNumber(List<RaceLap> laps)
    {
      laps.Sort(new RaceLapByOrderInRaceComparer());
      for (int i = 0; i < laps.Count; i++)
      {
        laps[i].CurrentPosition = i + 1;
        if (i > 0)
          laps[i].PreviousPositionLap = laps[i - 1];
        if (i < laps.Count - 1)
          laps[i].NextPositionLap = laps[i + 1];
      }
    }

    private List<RaceLap> GetLapsByLapNumber(int lapNumber, bool searchDownForPreviousLapsForEveryDriver)
    {
      List<RaceLap> ret = new List<RaceLap>();

      ret = Laps.Get(lapNumber);

      if (searchDownForPreviousLapsForEveryDriver)
      {
        List<Driver> drivers = Laps.GetDrivers().ToList();

        foreach (var lap in ret)
        {
          if (drivers.Contains(lap.Driver))
            drivers.Remove(lap.Driver);
        }

        int lastDriversCount = drivers.Count;
        while (drivers.Count > 0)
        {
          Driver driver = drivers[0];
          for (int i = lapNumber - 1; i > 0; i--)
          {
            RaceLap lap = Laps.Get(i, driver);
            if (lap != null)
            {
              ret.Add(lap);
              drivers.Remove(driver);
              break;
            }
          }

          if (lastDriversCount == drivers.Count)
            throw new Exception("Cannot get last previous lap of driver " + driver.NameSurname + ". Invalid data.");
          else
            lastDriversCount = drivers.Count;
        }
      }

      return ret;
    }

    private void RefreshLinksOfDriver(Driver driver)
    {
      var laps = Laps[driver];
      if (laps.Count == 0) return;

      laps.Sort(new Lap.ByCrossedAtTimeComparer());
      for (int i = 0; i < laps.Count; i++)
      {
        if (i > 0)
          laps[i].PreviousLap = laps[i - 1];
        if (i < (laps.Count - 1))
          laps[i].NextLap = laps[i + 1];
      }

      laps.Sort(new Lap.ByLapTimeComparer());
      for (int i = 0; i < laps.Count; i++)
      {
        if (i > 0)
          laps[i].BetterLap = laps[i - 1];
        if (i < (laps.Count - 1))
          laps[i].WorserLap = laps[i + 1];
      }
    }

    private void RecalculateLapTimesOfDriver(Driver driver, out RaceLap lapZero)
    {
      lapZero = null;
      var laps = Laps[driver];
      if (laps.Count == 0) return;

      laps.Sort(new Lap.ByCrossedAtTimeComparer());
      lapZero = laps[0];

      Time lastCrossedAt = laps[0].CrossedAtTime;
      for (int i = 0; i < laps.Count; i++)
      {
        laps[i].LapNumber = i;
        if (i == 0) continue;

        Time diff = laps[i].CrossedAtTime - lastCrossedAt;
        laps[i].Time = diff;

        lastCrossedAt = laps[i].CrossedAtTime;
      }
    }

    public void RegisterPitLaps()
    {
      this.PitLaps.Clear();

      var drivers = Laps.GetDrivers();
      foreach (var driver in drivers)
      {
        var laps = Laps[driver];
        laps.ForEach(i => i.PitState = RaceLap.ePitState.None);
        laps.Sort(new Lap.ByCrossedAtTimeComparer());

        for (int i = 1; i < laps.Count-1; i++)
        {
          if (laps[i].IsPitted == false) continue;

          RaceLap current = laps[i];
          RaceLap next = laps[i + 1];
          this.PitLaps.Add(current, next);

          if (current.PitState == RaceLap.ePitState.Exit)
            current.PitState = RaceLap.ePitState.ExitAndEntry;
          else
            current.PitState = RaceLap.ePitState.Entry;

          next.PitState = RaceLap.ePitState.Exit;
        }
      }
    }

    public void EvaluateYellowPhasesLaps()
    {
      int lapNumber;
      foreach (var item in Yellows)
      {
        lapNumber = GetLapNumberAtCrossedAtTime(item.StartTime, eCrossedAtLapBehavior.FirstLapAfter);
        item.StartLap = lapNumber;

        int? possibleLapNumber = TryGetLapNumberAtCrossedAtTime(item.EndTime, eCrossedAtLapBehavior.LastLapBefore);
        if (possibleLapNumber != null)
          lapNumber = possibleLapNumber.Value;
        else
          lapNumber = Positions.LapCount;

        item.EndLap = lapNumber;
      }
    }

    private int GetLapNumberAtCrossedAtTime(Time time, eCrossedAtLapBehavior behavior)
    {
      Time currentFirstTime;
      for (int i = 1; i < this.Positions.LapCount; i++)
      {
        currentFirstTime = this.Positions[i][0].CrossedAtTime;
        if (time < currentFirstTime)
        {
          if (behavior == eCrossedAtLapBehavior.FirstLapAfter)
            return i;
          else
            return i - 1;
        }
      }
      throw new ApplicationException("No lap found for time " + time);
    }

    private int? TryGetLapNumberAtCrossedAtTime(Time time, eCrossedAtLapBehavior behavior)
    {
      int? ret = null;
      try
      {
        ret = GetLapNumberAtCrossedAtTime(time, behavior);
      }
      catch
      {
        ret = null;
      }
      return ret;
    }

    public override void Clear()
    {
      this.Laps = new SessionLapCollection<RaceLap>(this);
      this.Positions = new RacePositionCollection();
      this.PitLaps = new RacePitCollection();
      this.Yellows = new YellowPhaseCollection();
      this.TotalRaceTime = new Time();
    }
  }
}
