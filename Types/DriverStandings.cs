using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parentables;

namespace ENG.NR2003.Types
{
  /// <summary>
  /// Represents standing of the driver after the race event.
  /// </summary>
  [Serializable()]
  public class DriverStandings : IParentable<WeekendStandings>
  {
    #region Nested
    public class ByPointsSumComparer : IComparer<DriverStandings>
    {
      public int Compare(DriverStandings x, DriverStandings y)
      {
        return -(x.PointsM.Sum.CompareTo(y.PointsM.Sum));
      }
    }
    #endregion Nested

    #region Properties

    /// <summary>
    /// Gets/sets driver.
    /// </summary>
    public Driver Driver { get; set; }
    /// <summary>
    /// Gets/sets position in champioship of the driver.
    /// </summary>
    public int Position { get; set; }
    /// <summary>
    /// Gets previous position in champioship of the driver, or current position, if no previous race exists.
    /// </summary>
    public int PreviousPosition
    {
      get
      {
        if (PreviousWeekendStanding == null)
          return Position;
        else
          return PreviousWeekendStanding.Position;
      }
    }
    /// <summary>
    /// Gets/sets champioship points.
    /// </summary>
    public Meaner PointsM { get; set; }
    /// <summary>
    /// Gets/sets count of top 1.
    /// </summary>
    public int Top1 { get; set; }
    /// <summary>
    /// Gets/sets count of top 2.
    /// </summary>
    public int Top2 { get; set; }
    /// <summary>
    /// Gets/sets count of top 3.
    /// </summary>
    public int Top3 { get; set; }
    /// <summary>
    /// Gets/sets count of top 5.
    /// </summary>
    public int Top5 { get; set; }
    /// <summary>
    /// Gets/sets count of top 10.
    /// </summary>
    public int Top10 { get; set; }
    /// <summary>
    /// Gets/sets count of top 20.
    /// </summary>
    public int Top20 { get; set; }
    /// <summary>
    /// Gets/sets count of driver finishes in a season.
    /// </summary>
    public int FinishesCount { get; set; }
    /// <summary>
    /// Gets/sets count of driver crashes in a season.
    /// </summary>
    public int CrashesCount { get; set; }
    /// <summary>
    /// Gets/sets count of driver starts in a season.
    /// </summary>
    public int RacesCount { get; set; }
    /// <summary>
    /// Gets/sets count of races finished of all races in a season.
    /// </summary>
    public int LapsCount { get; set; }
    /// <summary>
    /// Gets/sets count of laps in lead in all races in a season.
    /// </summary>
    public int LapsInLead { get; set; }
    /// <summary>
    /// Gets/sets mean finish position in all races.
    /// </summary>
    public Meaner FinishPositionsMean { get; set; }
    /// <summary>
    /// Gets/sets mean qualify position in all races.
    /// </summary>
    public Meaner QualifyPositionsMean { get; set; }
    /// <summary>
    /// Gets/sets mean of black flags per race in all races.
    /// </summary>
    public Meaner BlackFlagsMean { get; set; }

    /// <summary>
    /// Gets/sets link to previous standing in a championship.
    /// </summary>
    public DriverStandings BetterStandings { get; set; }
    /// <summary>
    /// Gets/sets link to next standing in a championship.
    /// </summary>
    public DriverStandings WorseStandings { get; set; }
    /// <summary>
    /// Gets/sets link to standing of current driver after previous weekend.
    /// </summary>
    public DriverStandings PreviousWeekendStanding { get; set; }
    /// <summary>
    /// Gets/sets link to standing of current driver after next weekend.
    /// </summary>
    public DriverStandings NextWeeendStanding { get; set; }

    /// <summary>
    /// Gets/sets current standings of all drivers in a championship.
    /// </summary>
    public WeekendStandings Parent { get; set; }

    #endregion Properties

    #region .ctor

    public DriverStandings()
    {
      PointsM = new Meaner();
      FinishPositionsMean = new Meaner();
      QualifyPositionsMean = new Meaner();
      BlackFlagsMean = new Meaner();
    }

    #endregion .ctor

    public bool IsValid()
    {
      if (Driver == null) return false;
      if (Position < 1) return false;
      if (PointsM.Sum < 0) return false;
      if (BetterStandings == null && WorseStandings == null) return false;

      return true;
    }

    public K Agregate<K>(K initialValue,
      Func<DriverStandings, K, K> agregator, Func<DriverStandings, DriverStandings> enumerator)
    {
      K ret = initialValue;

      ret = agregator(this, initialValue);

      DriverStandings prev = enumerator(this);
      if (prev != null)
        ret = prev.Agregate(ret, agregator, enumerator);

      return ret;
    }

  }
}
