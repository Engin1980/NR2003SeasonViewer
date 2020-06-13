using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  /// <summary>
  /// Represents race pit.
  /// </summary>
  [Serializable()]
  public class RacePit
  {
    /// <summary>
    /// Gets or sets the first lap of the pit.
    /// </summary>
    /// <value>
    /// The first lap.
    /// </value>
    public RaceLap FirstLap { get; internal set; }
    /// <summary>
    /// Gets or sets the second lap of the pit.
    /// </summary>
    /// <value>
    /// The second lap.
    /// </value>
    public RaceLap SecondLap { get; internal set; }
    /// <summary>
    /// Gets or sets time of the pit, typically the total time of the both pit laps as sum.
    /// </summary>
    /// <value>
    /// The time.
    /// </value>
    public Time Time { get; internal set; }
    /// <summary>
    /// Gets the lap number of the pit.
    /// </summary>
    public int LapNumber
    {
      get
      {
        return FirstLap.LapNumber;
      }
    }
  }
}
