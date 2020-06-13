using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;

namespace ENG.NR2003.NascarSeasonView.Types.Views
{
  class SeasonForChartView : IView<SeasonForChartView.Item>
  {
    public class Item
    {
      [Display("#")]
      public string DriverNumber { get; set; }
      public string Name { get; set; }
      public int RaceIndex { get; set; }
      public string RaceName { get; set; }
      public int StandingAfterRace { get; set; }
      public int RacePosition { get; set; }


      public Item(int index, WeekendInfo raceWeekend, DriverStandings standing)
      {
        // TODO: Complete member initialization
        this.RaceIndex = index;
        this.RaceName = raceWeekend.Weekend.Name;
        this.Name = standing.Driver.NameSurname;
        this.DriverNumber = standing.Driver.Number;
        this.StandingAfterRace = raceWeekend.Standings[standing.Driver].Position;
        this.RacePosition = standing.Position;
      }
    }

    private List<SeasonForChartView.Item> inner = new List<Item>();

    public SeasonForChartView(Season season)
    {
      int index = 0;
      foreach (var raceWeekend in season.RaceWeekends)
      {
        index++;

        foreach (var standing in raceWeekend.Standings)
        {
          Item it = new Item(index, raceWeekend, standing);
          inner.Add(it);
        }
      }
    }

    public List<SeasonForChartView.Item> GetAll()
    {
      return inner;
    }
  }
}
