using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;
using ENG.NR2003.NascarSeasonView.Types.Views.Display;

namespace ENG.NR2003.NascarSeasonView.Types.Views
{
  class NonRaceSessionView: IView<ENG.NR2003.NascarSeasonView.Types.Views.NonRaceSessionView.Item>    
  {
    public class Item
    {      
      [Display("X.")]
      public int Position { get; set; }
      [Display("#")]
      public string Number { get; set; }
      public string Driver { get; set; }
      public DisplayItemWithLap<Time> BestTime { get; set; }
      public DisplayItemWithLap<Time> SecondTime { get; set; }
      public DisplayItemWithLap<Time> ThirdTime { get; set; }
      public DisplayItemWithLap<Time> WorstTime { get; set; }
      [Display("Laps")]
      public int NumberOfLaps { get; set; }
      [Display("Mean time", "Mean time without pit laps")]
      public Time MeanTime { get; set; }

      public Item(NonRaceLap item, int currentPosition, int numberOfLaps)
      {
        this.Driver = item.Driver.NameSurname;
        this.Number = item.Driver.Number;
        this.Position = currentPosition;
        this.NumberOfLaps = numberOfLaps;
        if (this.NumberOfLaps > 0)
        {
          this.BestTime = item.Time;
          this.WorstTime = item.GetThrough(j => j.WorserLap).Time;
        }
        if (this.NumberOfLaps > 1)
          this.SecondTime = item.WorserLap.Time;
        if (this.NumberOfLaps > 2)
          this.ThirdTime = item.WorserLap.WorserLap.Time;

        this.MeanTime = GetMeanTime(item);
      }

      private Time GetMeanTime(Lap item)
      {
        Meaner m = new Meaner();
        Lap l = item;
        while (l != null)
        {
          if (l.IsPitted == false)
          {
            m.Add(l.Time.TotalMiliseconds);
          }
          l = l.WorserLap;
        }

        Time ret = new Time((int)m.Mean);
        return ret;
      }
    }

    private List<Item> inner = new List<Item>();

    public NonRaceSessionView(NonRaceSession nrs)
    {
      var poss = nrs.Positions;
      int currentPos = 1;
      foreach (var item in poss)
      {
        Item i = new Item(item, currentPos, nrs.Laps[item.Driver].Count);
        currentPos++;

        inner.Add(i);
      }
    }    

    public List<Item> GetAll()
    {
      return inner;
    }
  }
}
