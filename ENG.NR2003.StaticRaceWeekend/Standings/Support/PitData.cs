using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.StaticRaceWeekend.Standings.Support
{
  [Serializable()]
  public class PitData
  {
    [Serializable()]
    public class MeanPitTime
    {
      private double Sum = 0;
      private int Count = 0;
      public double? Mean {get{ if (Count == 0) return null; else return Sum/Count;}}

      internal void AddValue (double value){
        Sum += value;
        Count += 1;
      }
    }

    public double? BestPitTime { get; private set; }
    public double? WorstPitTime { get; private set; }
    public int? LastPitLap { get { if (PitLaps.Count == 0) return null; else return PitLaps[PitLaps.Count - 1]; } }
    public List<double> PitTimes { get; private set; }
    public List<int> PitLaps { get; private set; }
    public List<double> OrderedPitTimes { get { return PitTimes.OrderBy(i => i).ToList(); } }
    public int PitCount { get { return PitTimes.Count; } }
    public MeanPitTime PitMeanTime {get;private set;}

    public PitData()
    {
      PitTimes = new List<double>();
      PitLaps = new List<int>();
      PitMeanTime = new MeanPitTime();
    }

    public void AddPit(double pitTime, int lapIndex)
    {
      PitTimes.Add(pitTime);
      PitLaps.Add(lapIndex);

      AdjustBestTime(pitTime);
      AdjustWorstTime(pitTime);
      PitMeanTime.AddValue(pitTime);
    }

    private void AdjustBestTime(double pitTime)
    {
      if (BestPitTime == null)
        BestPitTime = pitTime;
      else if (BestPitTime.Value > pitTime)
        BestPitTime = pitTime;
    }
    private void AdjustWorstTime(double pitTime)
    {
      if (WorstPitTime == null)
        WorstPitTime = pitTime;
      else if (WorstPitTime.Value < pitTime)
        WorstPitTime = pitTime;
    }
  }
}
