using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECC;
using DetailedRaceStanding = ENG.NR2003.StaticRaceWeekend.Standings.Support.ComplexGap;
using ENG.NR2003.TelemetryEvents;


namespace ENG.NR2003.StaticRaceWeekend.Standings.Support
{
  [Serializable()]
  public class DetailedRaceStandings
  {
    private class DRSFiller
    {
      #region Nested
      private class LapCrossingComparerByCrossedAt : IComparer<LapCrossing>
      {

        #region IComparer<LapCrossing> Members

        public int Compare(LapCrossing x, LapCrossing y)
        {
          return x.CrossedAt.CompareTo(y.CrossedAt);
        }

        #endregion
      }
      #endregion Nested

      private List<List<LapCrossing>> temp = new List<List<LapCrossing>>();
      private Dictionary<int, int> lapIndexHistoryDictionary = new Dictionary<int, int>();
      internal void Fill(List<TelemetryEvents.LapCrossing> laps, DetailedRaceStandings drs)
      {
        foreach (var item in laps)
          RegisterLap(item);

        LinkedComplexGap first;
        for (int i = 0; i < temp.Count; i++)
        {
          first = CalculateLapAndReturnFirst(i);
          drs.AddLapLinkedComplexGaps(first);
        }
      }

      private int GetLapIndex(int carIdx)
      {
        if (lapIndexHistoryDictionary.ContainsKey(carIdx))
          return lapIndexHistoryDictionary[carIdx];
        else
        {
          lapIndexHistoryDictionary.Add(carIdx, 0);
          return 0;
        }
      }

      private void SetLapIndex(int carIdx, int lapIndex)
      {
        lapIndexHistoryDictionary[carIdx] = lapIndex;
      }

      private void RegisterLap(TelemetryEvents.LapCrossing lapCrossing)
      {
        int lapIndex = GetLapIndex(lapCrossing.CarIdx);
        SetLapIndex(lapCrossing.CarIdx, lapIndex + 1);

        if (lapIndex >= temp.Count)
          temp.Add(new List<LapCrossing>());

        temp[lapIndex].Add(lapCrossing);
      }

      private LinkedComplexGap CalculateLapAndReturnFirst(int lapNumber)
      {
        LinkedComplexGap first;
        LinkedComplexGap current;

        SortAllLapCrossings();

        LapCrossing firstTime = temp[lapNumber][0];

        first = CreateComplexGapForDriver(lapNumber, 0);

        LinkedComplexGap previous = first;
        for (int i = 1; i < temp[lapNumber].Count; i++)
        {
          current = CreateComplexGapForDriver(lapNumber, i);
          LinkedComplexGap.LinkByPosition(previous, current);
          previous = current;
        }

        return first;
      }

      private LinkedComplexGap CreateComplexGapForDriver(int lapNumber, int positionIndex)
      {
        LapCrossing currentLC = temp[lapNumber][positionIndex];
        LinkedComplexGap cg = new LinkedComplexGap()
        {
          CarIdx = currentLC.CarIdx,
          CrossedAt = currentLC.CrossedAt,
          LapIndex = lapNumber,
          Position = positionIndex + 1,
          IsPitted = currentLC.IsPitted,
          IsOffTrack = currentLC.IsOffTrack,
          IsBlackFlagged = currentLC.IsBlackFlagged,
          IsTimeInvalid = currentLC.IsTimeInvalid
        };

        if (positionIndex > 0)
          FillComplexGapGaps(cg);
        else
        {
          cg.ToFirst = new Gap();
          cg.ToPrevious = new Gap();
        }

        return cg;
      }

      private void FillComplexGapGaps(ComplexGap currentCG)
      {
        int firstLap = -1;
        double firstTime = 0;
        int prevLap = -1;
        double prevTime = 0;

        firstLap = GetLapIndexOfFirstBeforeCrossingTime(currentCG.CrossedAt, currentCG.LapIndex);
        firstTime = temp[currentCG.LapIndex][0].CrossedAt;

        prevLap = GetLapIndexOFPreviousBeforeCrossingTime(
          currentCG.CrossedAt,
          temp[currentCG.LapIndex][currentCG.Position - 2].CarIdx,
          currentCG.LapIndex);
        prevTime = temp[currentCG.LapIndex][currentCG.Position - 2].CrossedAt;

        firstLap = firstLap - currentCG.LapIndex;
        prevLap = prevLap - currentCG.LapIndex;
        firstTime = firstTime - currentCG.CrossedAt;
        prevTime = prevTime - currentCG.CrossedAt;

        Gap g;
        g = new Gap(firstLap, firstTime);
        currentCG.ToFirst = g;
        g = new Gap(prevLap, prevTime);
        currentCG.ToPrevious = g;
      }

      private int GetLapIndexOFPreviousBeforeCrossingTime(double time, int previousCarIdx, int startLapIndex)
      {
        int ret = 0;
        for (int i = startLapIndex; i < temp.Count; i++)
        {
          for (int j = 0; j < temp[i].Count; j++)
          {
            if (temp[i][j].CarIdx == previousCarIdx)
              if (temp[i][j].CrossedAt < time)
              {
                ret = i;
                break;
              }
              else
                return ret;
          }
        }

        return ret;
      }

      private int GetLapIndexOfFirstBeforeCrossingTime(double time, int startLapIndex)
      {
        for (int i = startLapIndex; i < temp.Count; i++)
        {
          if (temp[i][0].CrossedAt > time)
            return i - 1;
        }

        return temp.Count - 1;
      }

      private void SortAllLapCrossings()
      {
        foreach (var fItem in temp)
          fItem.Sort(new LapCrossingComparerByCrossedAt());
      }
    }

    public int LapCount { get { return lapHeads.Count; } }
    private List<LinkedComplexGap> lapHeads = new List<LinkedComplexGap>();
    private LinkedComplexGap xGetLap(LinkedComplexGap head, int lapIndexToFind)
    {
      LinkedComplexGap ret =
        xFind(head, i => i.LapIndex == lapIndexToFind, i => i.NextLap, i => i.PreviousLap);

      return ret;
    }
    private LinkedComplexGap xGetCarIdx(LinkedComplexGap head, int carIdx)
    {
      LinkedComplexGap ret = 
        xFind (head, i => i.CarIdx == carIdx, i => i.NextPosition, i => i.PreviousPosition);
      return ret;
    }
    private LinkedComplexGap xGet (int lapIndex, int carIdx)
    {
      LinkedComplexGap ret = this.lapHeads[lapIndex];
      ret = xGetCarIdx(ret, carIdx);

      return ret;
    }
    private LinkedComplexGap xFind(LinkedComplexGap head, Func<LinkedComplexGap, bool> comparer,
      Func<LinkedComplexGap, LinkedComplexGap> forward, Func<LinkedComplexGap, LinkedComplexGap> backward)
    {
      LinkedComplexGap ret = null;

      ret = head;
      while (ret != null && comparer(ret) == false)
        ret = forward(ret);

      if (ret == null)
      {
        ret = head;
        while (ret != null && comparer(ret) == false)
          ret = backward(ret);
      }

      return ret;
    }

    public ComplexGap Get(int carIdx, int raceLap)
    {
      var ret = xGetLap(this.lapHeads[0], raceLap);
      ret = xGetCarIdx(ret, carIdx);
      return ret;
    }

    internal void AddLapLinkedComplexGaps(LinkedComplexGap first)
    {
      Contract.Assert(first.LapIndex == this.lapHeads.Count);
      LinkedComplexGap current = first;      

      if (first.LapIndex != 0)
      {
        while (current != null)
        {
          LinkedComplexGap prevLap = xGet(first.LapIndex - 1, first.CarIdx);

          Contract.Assert(prevLap != null);

          LinkedComplexGap.LinkByLap(prevLap, current);
          current = current.NextPosition;
        }
      }

      this.lapHeads.Add(first);
    }    

    public List<DetailedRaceStanding> GetLap(int lapIndex)
    {
      List<DetailedRaceStanding> ret = new List<DetailedRaceStanding>();

      var first = this.lapHeads[lapIndex];
      while (first.PreviousPosition != null) 
        first = first.PreviousPosition;

      ret.Add(first);
      while (first.NextPosition != null)
      {
        first = first.NextPosition;
        ret.Add(first);
      } 

      return ret;
    }

    public List<DetailedRaceStanding> GetLapsOfCarIdx(int carIdx)
    {
      List<DetailedRaceStanding> ret = new List<DetailedRaceStanding>();

      var item = xGetCarIdx(this.lapHeads[0], carIdx);
      while (item.PreviousLap != null)
        item = item.PreviousLap;

      while (item.NextLap != null)
      {
        ret.Add(item);
        item = item.NextLap;
      }

      return ret;
    }

    [Obsolete("Use GetLap")]
    public List<ComplexGap> GetStandingsOfLap(int lapNumber)
    {
      var ret = GetLap(lapNumber);
      return ret;
    }

    internal int GetLapIndexByCrossedAt(double time)
    {
      int ret = 0;

      for (int i = 0; i < LapCount; i++)
      {
        var lapData = GetLap(i);
        var first = lapData[0];

        if (first.CrossedAt > time)
          return ret;
        else
          ret = i;
      }

      return LapCount - 1;
    }

    public DetailedRaceStandings(List<TelemetryEvents.LapCrossing> raceLapCrossings)
    {
      DetailedRaceStandings.DRSFiller drsf = new DRSFiller();
      drsf.Fill(raceLapCrossings, this);
    }
    
  }
}
