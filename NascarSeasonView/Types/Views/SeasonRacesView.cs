using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;

namespace ENG.NR2003.NascarSeasonView.Types.Views
{
  class SeasonRacesView : IView<ENG.NR2003.NascarSeasonView.Types.Views.SeasonRacesView.Item>
  {
    public class Item
    {

      public string Name { get; set; }

      public string Track { get; set; }

      public DateTime Date { get; set; }

      [Display("Oppnts (%)")]
      public int OpponentStrength { get; set; }

      public int Laps { get; set; }

      public Time RaceTime { get; set; }

      public string FillState { get; set; }

      public int Drivers { get; set; }

      public int FinishedRunning { get; set; }

      public int YellowPhases { get; set; }

      #region .ctor

      public Item(WeekendInfo item)
      {
        this.Name = item.Weekend.Name;
        this.Track = item.Weekend.Track.Name;
        this.Date = item.Weekend.DayOfRace;
        if (item.Weekend.Realism != null)
          this.OpponentStrength = item.Weekend.Realism.OpponentStrength;
        this.FillState = CreateFillState(item.Weekend);

        this.Drivers = item.Weekend.Drivers.Count;

        if (item.Weekend.Race.IsEmpty() == false)
        {
          this.FinishedRunning =
            GetFinishedRunningDrivers(item);
          this.YellowPhases = item.Weekend.Race.Yellows.Count;
          this.RaceTime = item.Weekend.Race.TotalRaceTime;
        }

        if (item.Weekend.Settings != null)
          this.Laps = item.Weekend.Settings.RaceLapCount;
      }
      #endregion .ctor

      #region Private methods


      private int GetFinishedRunningDrivers(WeekendInfo wd)
      {
        int count = 0;
        foreach (var item in wd.Weekend.Drivers.Keys)
        {
          Driver d = wd.Weekend.Drivers[item];
          if (wd.Weekend.Race.Positions.GetDriverFinalStatus(d) == RacePositionCollection.eStatus.Running)
            count++;
        }
        return count;
      }

      private string CreateFillState(Weekend weekend)
      {
        StringBuilder sb = new StringBuilder();

        if (weekend.Practice.IsEmpty() == false)
          sb.Append("P");
        if (weekend.Qualify.IsEmpty() == false)
          sb.Append("Q");
        if (weekend.HappyHour.IsEmpty() == false)
          sb.Append("H");
        if (weekend.Race.IsEmpty() == false)
          sb.Append("R");

        return sb.ToString();
      }

      #endregion Private methods
    }

    private List<Item> inner = new List<Item>();

    public SeasonRacesView(WeekendInfoCollection raceWeekends)
    {
      foreach (var item in raceWeekends)
      {
        Item srvi = new Item(item);        

        inner.Add(srvi);
      }
    }


    public List<Item> GetAll()
    {
      return inner;
    }
  }
}
