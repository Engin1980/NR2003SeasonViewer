using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;
using ENG.NR2003.NascarSeasonView.Types.Views.Display;

namespace ENG.NR2003.NascarSeasonView.Types.Views
{
  class RaceForChartSessionView : IView<RaceForChartSessionView.Item>
  {
    private List<RaceForChartSessionView.Item> inner = new List<Item>();

    public class Item : RaceSessionView.Item
    {
      public int LapNumber { get; set; }
      public double Time { get; set; }

      public Item(List<RaceLap> laps, int indexOfLap, RacePit[] pits, RaceSession rs)
        : base(laps, indexOfLap, pits, rs)
      {
        this.LapNumber = laps[indexOfLap].LapNumber;
        this.Time = laps[indexOfLap].Time.TotalMiliseconds;
      }

      private Time GetMeanTime(Lap item)
      {
        Meaner m = new Meaner();
        Lap l = item;
        while (l != null)
        {
          m.Add(l.Time.TotalMiliseconds);
          l = l.WorserLap;
        }

        Time ret = new Time((int)m.Mean);
        return ret;
      }
    }

    public RaceForChartSessionView(RaceSession rs)
    {
      int lapCount = rs.Weekend.Settings.RaceLapCount;

      if (rs.IsEmpty()) return;

      for (int lapNumber = 1; lapNumber <= lapCount; lapNumber++)
      {
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


    public List<RaceForChartSessionView.Item> GetAll()
    {
      return inner;
    }
  }
}
