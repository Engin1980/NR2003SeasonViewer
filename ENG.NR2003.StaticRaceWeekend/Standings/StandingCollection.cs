using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace ENG.NR2003.StaticRaceWeekend.Standings
{
  [Serializable()]
  public class StandingCollection : IEnumerable<Standing>
  {
    private List<Standing> inner = new List<Standing>();

    internal void Add(Standing item)
    {
      if (Contains(item.Driver.CarIdx))
        throw new Exception(
          "Driver with carIdx " + item.Driver.CarIdx + " (" + item.Driver.CarNumber + "-" + item.Driver.Name + ") already contained." );

      inner.Add(item);
    }

    public void SortAndSetPositionsToStandings()
    {
      if (this.Count == 0) return;
      if (this[0] is NonRaceStanding)
        OrderAsForNonRace();
      else
        OrderAsForRace();
    }

    internal void OrderAsForRace()
    {
      this.inner.Sort(new RaceStanding.ByCalculatedPositionComparer());
      ResetPositions();
      UpdateGaps();
    }

    private void UpdateGaps()
    {

      int leaderLap;
      double leaderTime;
      int prevLap;
      double prevTime;
      RaceStanding rs = this[0] as RaceStanding;

      if (rs.LastLapCrossing == null) return;

      rs.GapToFirst = new Support.Gap(0, 0);
      rs.GapToPrevious = new Support.Gap(0, 0);
      leaderLap = rs.Laps.Count;
      leaderTime = rs.LastLapCrossing.Value;
      prevLap = leaderLap;
      prevTime = rs.LastLapCrossing.Value;

      for (int i = 1; i < this.Count; i++)
      {
        rs = this[i] as RaceStanding;

        if (rs.LastLapCrossing == null) break;

        rs.GapToFirst = new Support.Gap(leaderLap - rs.Laps.Count, rs.LastLapCrossing.Value - leaderTime);
        rs.GapToPrevious = new Support.Gap(prevLap - rs.Laps.Count , rs.LastLapCrossing.Value - prevTime);

        prevLap = rs.Laps.Count;
        prevTime = rs.LastLapCrossing.Value;
      }
    }

    internal void OrderAsForNonRace()
    {
      this.inner.Sort(new NonRaceStanding.ByCalculatedPositionComparer());
      ResetPositions();
    }

    private void ResetPositions()
    {
      int nextPosition = 1;
      for (int i = 0; i < inner.Count; i++)
      {
        if (inner[i].CanHavePosition)
        {
          inner[i].Position = nextPosition;
          nextPosition++;
        }
        else
          inner[i].Position = null;
      }
    }

    public bool Contains(int carIdx)
    {
      var pom = TryGetByCarIdx(carIdx);
      return (pom != null);
    }

    public int Count { get { return inner.Count; } }

    public Standing TryGetByCarIdx(int carIdx)
    {
      foreach (var fItem in inner)
        if (fItem.Driver.CarIdx == carIdx)
          return fItem;
      return null;
    }
    public Standing GetCarByCarIdx(int carIdx)
    {
      var ret = TryGetByCarIdx(carIdx);
      if (ret == null)
        throw new Exception("CarIdx not found in the list.");
      else
        return ret;
    }

    public Standing this[int index]
    {
      get {
        Contract.Requires(index >= 0 && index < this.Count);
        return inner[index]; }
    }

    public RaceStanding TryGetRaceStanding(int index)
    {
      RaceStanding ret = this[index] as RaceStanding;
      return ret;
    }
    public NonRaceStanding TryGetNonRaceStanding(int index)
    {
      NonRaceStanding ret = this[index] as NonRaceStanding;
      return ret;
    }

    public void Sort()
    {
      inner.Sort();
    }

    #region IEnumerable<Standing> Members

    public IEnumerator<Standing> GetEnumerator()
    {
      return inner.GetEnumerator();
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return inner.GetEnumerator();
    }

    #endregion

    public Standing TryGetByCarNumber(string carNumber)
    {
      foreach (var fItem in inner)
        if (fItem.Driver.CarNumber == carNumber)
          return fItem;
      return null;
    }

    internal NonRaceStanding TryGetNonRaceStandingByDriverIdx(int carIdx)
    {
      Contract.Requires(carIdx > -1);

      foreach (var fItem in this)
      {
        if (fItem.Driver.CarIdx == carIdx)
        {
          if (fItem is NonRaceStanding)
            return fItem as NonRaceStanding;
        }
      } // foreach (var fItem in this)

      return null;
    }

    public Standing GetCarByCarNumber(string carNumber)
    {
      var ret = TryGetByCarNumber(carNumber);
      if (ret == null)
        throw new Exception("CarNumber not found in the list.");
      else
        return ret;
    }
  }
}
