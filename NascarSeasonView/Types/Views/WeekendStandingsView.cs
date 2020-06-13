using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;
using ENG.NR2003.NascarSeasonView.Types.Views.Display;

namespace ENG.NR2003.NascarSeasonView.Types.Views
{
  class WeekendStandingsView : IView<ENG.NR2003.NascarSeasonView.Types.Views.WeekendStandingsView.Item>
  {
    public class Item
    {
      #region Properties

      public int Position { get; set; }
      [Display("#")]
      public string Number { get; set; }
      public string Name { get; set; }
      public int Points { get; set; }

      [Display("<-")]
      public int ToPrevious { get; set; }

      [Display("1.<-")]
      public int ToFirst { get; set; }

      public int AveragePoints { get; set; }

      [Display("(prev)")]
      public int PreviousPosition { get; set; }

      public int BestPositionEver { get; set; }
      public int WorstPositionEver { get; set; }

      public DisplayWithPercentage Races { get; set; }
      public DisplayWithPercentage Finishes { get; set; }
      public DisplayWithPercentage Crashes { get; set; }

      public DisplayWithPercentage Laps { get; set; }
      [Display("Laps LL")]
      public DisplayWithPercentage LapsLL { get; set; }

      public int QualifyPositionMean { get; set; }
      public int RacePositionMean { get; set; }

      public DisplayWithPercentage Top1 { get; set; }
      public DisplayWithPercentage Top2 { get; set; }
      public DisplayWithPercentage Top3 { get; set; }
      public DisplayWithPercentage Top5 { get; set; }
      public DisplayWithPercentage Top10 { get; set; }
      public DisplayWithPercentage Top20 { get; set; }

      public DisplaySumWithMean BlackFlagsCount { get; set; }
      #endregion Properties

      #region .ctor

      public Item(DriverStandings item, DriverStandings standingOfFirstDriver)
      {
        this.Name = item.Driver.NameSurname;
        this.Number = item.Driver.Number;
        this.Points = (int)item.PointsM.Sum;
        this.Position = item.Position;
        this.PreviousPosition = item.PreviousPosition;
        if (item == standingOfFirstDriver)
          this.ToFirst = 0;
        else
          this.ToFirst = (int)(standingOfFirstDriver.PointsM.Sum - item.PointsM.Sum);
        if (item.BetterStandings == null)
          this.ToPrevious = 0;
        else
          this.ToPrevious = (int)(item.BetterStandings.PointsM.Sum - item.PointsM.Sum);

        this.BestPositionEver =
          item.Agregate(100,
          (i, m) => Math.Min(i.Position, m),
          i => i.PreviousWeekendStanding);

        this.WorstPositionEver =
          item.Agregate(1,
          (i, m) => Math.Max(i.Position, m),
          i => i.PreviousWeekendStanding);

        this.AveragePoints = (int)item.PointsM.Mean;

        this.Races = new DisplayWithPercentage(item.RacesCount, item.Parent.TotalRacesCount);
        this.Laps = new DisplayWithPercentage(item.LapsCount, item.Parent.TotalLapsCount);
        this.LapsLL = new DisplayWithPercentage(item.LapsInLead, item.Parent.TotalLapsCount);

        this.Top1 = new DisplayWithPercentage(item.Top1, item.Parent.TotalRacesCount);
        this.Top2 = new DisplayWithPercentage(item.Top2, item.Parent.TotalRacesCount);
        this.Top3 = new DisplayWithPercentage(item.Top3, item.Parent.TotalRacesCount);
        this.Top5 = new DisplayWithPercentage(item.Top5, item.Parent.TotalRacesCount);
        this.Top10 = new DisplayWithPercentage(item.Top10, item.Parent.TotalRacesCount);
        this.Top20 = new DisplayWithPercentage(item.Top20, item.Parent.TotalRacesCount);

        this.Finishes = new DisplayWithPercentage(item.FinishesCount, item.Parent.TotalRacesCount);
        this.Crashes = new DisplayWithPercentage(item.CrashesCount, item.Parent.TotalRacesCount);

        this.QualifyPositionMean = (int)item.QualifyPositionsMean.Mean;
        this.RacePositionMean = (int)item.FinishPositionsMean.Mean;

        this.BlackFlagsCount = new DisplaySumWithMean(item.BlackFlagsMean.Sum, item.BlackFlagsMean.Mean);
      }
      #endregion .ctor
    }

    List<Item> inner = new List<Item>();

    public WeekendStandingsView(WeekendStandings ws)
    {
      if (ws == null) return;

      DriverStandings standingOfFirstDriver =
        ws.FirstOrDefault(i => i.Position == 1);

      foreach (var item in ws)
      {
        Item wsvi = new Item(item, standingOfFirstDriver);

        inner.Add(wsvi);
      }
    }

    public List<Item> GetAll()
    {
      return inner;
    }
  }
}
