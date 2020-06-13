using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  /// <summary>
  /// Represents non-race session (training, qualify and happy hour.
  /// </summary>
  [Serializable()]
  public class NonRaceSession : Session
  {
    /// <summary>
    /// Gets the laps of session.
    /// </summary>
    public SessionLapCollection<NonRaceLap> Laps { get; private set; }
    /// <summary>
    /// Gets the positions in the session..
    /// </summary>
    public NonRacePositionCollection Positions { get; private set; }

    public NonRaceSession(Weekend parentWeekend) : base(parentWeekend) {
      this.Positions = new NonRacePositionCollection();
      this.Laps = new SessionLapCollection<NonRaceLap>(this);
    }

    public void RefreshLinks()
    {
      var drivers = Laps.GetDrivers();

      NonRacePositionCollection bestLaps = new NonRacePositionCollection();

      // order laps of all drivers by time
      foreach (var driver in drivers)
      {
        var laps = Laps[driver];
        LapProvider.ReLinkByCrossedAt(laps);
        LapProvider.ReLinkByTime(laps);

        laps.Sort(new Lap.ByLapTimeComparer());
        if (laps.Count > 0)
          bestLaps.Add(laps[0]);
      }

      // get positions
      bestLaps.Sort(new Lap.ByLapTimeComparer());
      Positions = bestLaps;
    }

    public override bool IsEmpty()
    {
      return this.Positions.Count == 0;
    }

    public void RecalculateLapTimes()
    {
      var drivers = Laps.GetDrivers();

      // order laps of all drivers by time
      foreach (var driver in drivers)
      {
        var laps = Laps[driver];
        laps.Sort(new Lap.ByCrossedAtTimeComparer());
        for (int i = 1; i < laps.Count; i++)
        {
          Time bef = laps[i - 1].CrossedAtTime;
          Time curr = laps[i].CrossedAtTime;
          Time diff = curr - bef;
          laps[i].Time = diff;
          laps[i].LapNumber = i;
        }

        Laps.Remove(0, driver);
      }
    }


    public void BuildPositions()
    {
      this.Positions.Clear();
      foreach (var item in this.Weekend.Drivers)
      {
        Driver d = item.Value;
        var laps = Laps[d];
        if (laps.Count == 0) continue;

        laps.Sort(new Lap.ByLapTimeComparer());

        Positions.Add(laps[0]);
      }

      Positions.Sort(new Lap.ByLapTimeComparer());
    }

    public override void Clear()
    {
      this.Positions = new NonRacePositionCollection();
      this.Laps = new SessionLapCollection<NonRaceLap>(this);
    }
  }
}
