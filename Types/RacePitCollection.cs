using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  /// <summary>
  /// Represents collection of race pits.
  /// </summary>
  [Serializable()]
  public class RacePitCollection
  {
    private Dictionary<Driver, List<RacePit>> inner = new Dictionary<Driver, List<RacePit>>();

    /// <summary>
    /// Adds the pit specified by enter and exit lap.
    /// </summary>
    /// <param name="firstLap">The first lap.</param>
    /// <param name="secondLap">The second lap.</param>
    public void Add(RaceLap firstLap, RaceLap secondLap)
    {
      RacePit item = new RacePit();
      item.FirstLap = firstLap;
      item.SecondLap = secondLap;
      item.Time = item.FirstLap.Time + item.SecondLap.Time;

      if (inner.ContainsKey(firstLap.Driver) == false)
        inner.Add(firstLap.Driver, new List<RacePit>());
      inner[firstLap.Driver].Add(item);
    }

    internal void Clear()
    {
      inner = new Dictionary<Driver, List<RacePit>>();
    }

    /// <summary>
    /// Gets all pits of specified driver.
    /// </summary>
    /// <param name="driver">The driver.</param>
    /// <returns></returns>
    public RacePit[] Get(Driver driver)
    {
      if (inner.ContainsKey(driver))
        return inner[driver].ToArray();
      else
        return new RacePit[0];
    }
  }
}
