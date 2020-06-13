using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  /// <summary>
  /// Represents season.
  /// </summary>
  [Serializable()]
  public class Season
  {
    /// <summary>
    /// Gets/sets name of the season.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Gets all drivers of some race in the season.
    /// </summary>
    public DriverCollection Drivers { get; private set; }
    /// <summary>
    /// Gets all races in the race weekend
    /// </summary>
    public WeekendInfoCollection RaceWeekends { get; private set; }
    /// <summary>
    /// Gets all tracks registered in the season.
    /// </summary>
    public TrackCollection Tracks { get;  private set; }
    /// <summary>
    /// Gets scoring system.
    /// </summary>
    public object Scoring { get; set; }

    public Season()
    {
      this.Drivers = new DriverCollection(false);
      this.RaceWeekends = new WeekendInfoCollection(this);      
      this.Tracks = new TrackCollection();
    }

    public bool IsValid()
    {
      if (Scoring == null) return false;

      return true;
    }

    public WeekendStandings GetLastWeekendStandings()
    {
      int cnt = RaceWeekends.Count;
      if (cnt == 0) return null;

      var ret = RaceWeekends[cnt - 1].Standings;
      return ret;
    }
  }
}
