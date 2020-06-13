using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parentables;

namespace ENG.NR2003.Types
{
  /// <summary>
  /// Represents standing of all drivers after race weekend. Contains indexer over Driver.
  /// </summary>
  [Serializable()]
  public class WeekendStandings : ParentableList<DriverStandings, WeekendStandings>
  {
    /// <summary>
    /// Represents count of races.
    /// </summary>
    public int TotalRacesCount { get; set; }
    /// <summary>
    /// Represents total laps of all races.
    /// </summary>
    public int TotalLapsCount { get; set; }

    /// <summary>
    /// Gets standing for driver.
    /// </summary>
    /// <param name="driver"></param>
    /// <returns></returns>
    public DriverStandings this[Driver driver]
    {
      get
      {
        return this.FirstOrDefault(i => i.Driver == driver);
      }
    }
  }
}
