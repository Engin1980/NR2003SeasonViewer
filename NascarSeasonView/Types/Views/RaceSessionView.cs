using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;
using ENG.NR2003.NascarSeasonView.Types.Views.Display;

namespace ENG.NR2003.NascarSeasonView.Types.Views
{
  class RaceSessionView : IView<ENG.NR2003.NascarSeasonView.Types.Views.RaceSessionView.Item>
  {
    public class Item
    {
      #region Properties

      [Display("X.")]
      public int Position { get; set; }
      [Display("#")]
      public string Number { get; set; }
      public string Driver { get; set; }
      public RaceGap GapToPrevious { get; set; }
      public RaceGap GapToFirst { get; set; }
      public int LapCount { get; set; }
      public string State { get; set; }
      public int LapsInLead { get; set; }
      public int PitCount { get; set; }
      public DisplayItemWithLap<Time> BestTime { get; set; }

      [Display("Mean time", "Mean time")]
      public DisplayItemWithLap<Time> MeanTime { get; set; }

      [Display("Mean time !PY", "Mean time without pit laps")]
      public DisplayItemWithLap<Time> MeanTimePY { get; set; }

      [Display("Worst time !PY", "Worst time without pit")]
      public DisplayItemWithLap<Time> WorstTime { get; set; }

      public DisplayItemWithLap<Time> BestPitTime { get; set; }
      public DisplayItemWithLap<Time> MeanPitTime { get; set; }
      public DisplayItemWithLap<Time> WorstPitTime { get; set; }
      public int BestPosition { get; set; }
      public int WorstPosition { get; set; }
      public DisplayItemWithLap<int> MaxGainPerLap { get; set; }
      public DisplayItemWithLap<int> MaxLoosePerLap { get; set; }
      public string PitInLaps { get; set; }

      public int BlackFlags { get; set; }

      #endregion Properties

      #region .ctor

      public Item(List<RaceLap> laps, int i, RacePit [] pits, RaceSession rs)
      {
        RaceLap lap = laps[i];

        pits = pits.Where(k => k.LapNumber <= lap.LapNumber).ToArray();

        this.Driver = lap.Driver.NameSurname;
        this.Number = lap.Driver.Number;
        this.Position = lap.CurrentPosition;
        if (i == 0)
        {
          this.GapToFirst = RaceGap.Empty;
          this.GapToPrevious = RaceGap.Empty;
        }
        else
        {
          RaceLap prev = laps[i - 1];
          this.GapToFirst = new RaceGap(laps[0], lap);
          this.GapToPrevious = new RaceGap(laps[i - 1], lap);
        }
        this.LapCount = lap.LapNumber;
        this.State = rs.Positions.GetDriverFinalStatus(lap.Driver).ToString();
        this.LapsInLead = GetLapsInLead(lap);
        this.PitCount = pits.Length;
        this.BestTime = GetBestTime(lap);
        this.MeanTime = GetMeanTime(lap);
        this.MeanTimePY = GetMeanTimePY(lap);
        this.WorstTime = GetWorstTime(lap);
        this.BestPitTime = GetBestPitTime(pits);
        this.MeanPitTime = GetMeanPitTime(pits);
        this.WorstPitTime = GetWorstPitTime(pits);
        this.BestPosition = GetBestPositionSoFar(lap);
        this.WorstPosition = GetWorstPositionSoFar(lap);
        this.PitInLaps = GetPitLapsAsString(pits);
        this.MaxGainPerLap = GetMaxGainPerLap(lap);
        this.MaxLoosePerLap = GetMaxLoosePerLap(lap);

        this.BlackFlags =
          lap.Sum(k => k.IsBlackFlagged ? 1 : 0, k => k.PreviousLapAsRaceLap);
      }

      #endregion .ctor

      #region Private methods
      private DisplayItemWithLap<int> GetMaxLoosePerLap(RaceLap lap)
      {
        DisplayItemWithLap<int>? ret = null;
        int nextPos = lap.CurrentPosition;

        lap = lap.PreviousLap as RaceLap;
        while (lap != null)
        {
          int diff = -(lap.CurrentPosition - nextPos);
          if (ret == null || ret.Value.Item <= diff)
            ret = new DisplayItemWithLap<int>(diff, lap.LapNumber);

          nextPos = lap.CurrentPosition;
          lap = lap.PreviousLap as RaceLap;
        }

        if (ret == null)
          return new DisplayItemWithLap<int>();
        else
          return ret.Value;
      }

      private DisplayItemWithLap<int> GetMaxGainPerLap(RaceLap lap)
      {
        DisplayItemWithLap<int>? ret = null;
        int nextPos = lap.CurrentPosition;

        lap = lap.PreviousLap as RaceLap;
        while (lap != null)
        {
          int diff = lap.CurrentPosition - nextPos;
          if (ret == null || ret.Value.Item <= diff)
            ret = new DisplayItemWithLap<int>(diff, lap.LapNumber);

          nextPos = lap.CurrentPosition;
          lap = lap.PreviousLap as RaceLap;
        }

        if (ret == null)
          return new DisplayItemWithLap<int>();
        else
          return ret.Value;
      }

      private string GetPitLapsAsString(RacePit[] pits)
      {
        StringBuilder sb = new StringBuilder();
        foreach (var item in pits)
        {
          sb.Append(item.LapNumber + ";");// + " (" + item.Time.ToString(false) + "); ");
        }
        return sb.ToString();
      }

      private int GetWorstPositionSoFar(RaceLap lap)
      {
        int ret = int.MinValue;

        while (lap != null)
        {
          if (lap.CurrentPosition > ret)
            ret = lap.CurrentPosition;

          lap = (RaceLap)lap.PreviousLap;
        }

        return ret;
      }

      private int GetBestPositionSoFar(RaceLap lap)
      {
        int ret = int.MaxValue;

        while (lap != null)
        {
          if (lap.CurrentPosition < ret)
            ret = lap.CurrentPosition;

          lap = (RaceLap)lap.PreviousLap;
        }

        return ret;
      }

      private DisplayItemWithLap<Time> GetWorstPitTime(RacePit[] pits)
      {
        RacePit rp = null;
        foreach (var item in pits)
        {
          if (rp == null || item.Time > rp.Time)
            rp = item;
        }

        if (rp == null)
          return Time.Empty;
        else
          return new DisplayItemWithLap<Time>(rp.Time, rp.LapNumber);
      }

      private DisplayItemWithLap<Time> GetMeanPitTime(RacePit[] pits)
      {
        Meaner m = new Meaner();
        foreach (var item in pits)
        {
          m.Add(item.Time.TotalMiliseconds);
        }

        Time ret = Time.Empty;
        if (double.IsNaN(m.Mean) == false)
          ret = new Time((int)m.Mean);

        return ret;
      }

      private DisplayItemWithLap<Time> GetBestPitTime(RacePit[] pits)
      {
        RacePit rp = null;
        foreach (var item in pits)
        {
          if (rp == null || item.Time < rp.Time)
            rp = item;
        }

        if (rp == null)
          return Time.Empty;
        else
          return new DisplayItemWithLap<Time>(rp.Time, rp.LapNumber);
      }

      private int GetLapsInLead(RaceLap lap)
      {
        int ret = 0;

        while (lap != null)
        {
          if (lap.CurrentPosition == 1)
            ret++;
          lap = (RaceLap)lap.PreviousLap;
        }

        return ret;
      }

      private DisplayItemWithLap<Time> GetWorstTime(RaceLap lap)
      {
        var retLap = lap.GetThrough(i => i.WorserLap);

        DisplayItemWithLap<Time> ret = new DisplayItemWithLap<Time>(retLap.Time, retLap.LapNumber);
        return ret;
      }

      private DisplayItemWithLap<Time> GetBestTime(RaceLap lap)
      {
        var retLap = lap.GetThrough(i => i.BetterLap);

        DisplayItemWithLap<Time> ret = new DisplayItemWithLap<Time>(retLap.Time, retLap.LapNumber);
        return ret;
      }

      private DisplayItemWithLap<Time> GetMeanTime(Lap item)
      {
        Meaner m = new Meaner();
        Lap l = item;
        while (l != null)
        {
          //if (l.IsPitted == false)
          //{
          m.Add(l.Time.TotalMiliseconds);
          //}
          l = l.WorserLap;
        }

        Time ret = Time.Empty;
        if (double.IsNaN(m.Mean) == false)
          ret = new Time((int)m.Mean);

        return ret;
      }

      private DisplayItemWithLap<Time> GetMeanTimePY(Lap item)
      {
        Meaner m = new Meaner();
        Lap l = item;
        while (l != null)
        {
          if (l.IsPitted == false && (l.Session as RaceSession).Yellows.IsInYellow(l.CrossedAtTime) == false)
          {
            m.Add(l.Time.TotalMiliseconds);
          }
          l = l.WorserLap;
        }

        Time ret = Time.Empty;
        if (double.IsNaN(m.Mean) == false)
          ret = new Time((int)m.Mean);

        return ret;
      }
      #endregion Private methods
    }

    private List<Item> inner = new List<Item>();

    public List<Item> GetAll()
    {
      return inner;
    }

    public RaceSessionView(RaceSession rs, int lapNumber)
    {
      if (rs.IsEmpty()) return;

      var laps = rs.Positions[lapNumber];
      for (int i = 0; i < laps.Count; i++)
      {
        
        // pits only lower than current lap
        RacePit[] pits = rs.PitLaps.Get(laps[i].Driver);
        Item item = new Item(laps, i, pits, rs);
        

        inner.Add(item);
      }
    }


  }
}
