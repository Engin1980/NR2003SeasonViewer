using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  /// <summary>
  /// Represents racing weekend.
  /// </summary>
  [Serializable()]
  public class Weekend
  {
    /// <summary>
    /// Day of race
    /// </summary>
    public DateTime DayOfRace { get;  set; }
    /// <summary>
    /// Name of the race
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Track where race was taken
    /// </summary>
    public Track Track { get;  set; }

    /// <summary>
    /// Settings for the race
    /// </summary>
    public WeekendSettings Settings { get; set; }
    /// <summary>
    /// Realism for the race
    /// </summary>
    public WeekendRealism Realism { get; set; }

    /// <summary>
    /// Analysed track INI file, if exists.
    /// </summary>
    public TrackIniFile IniFile { get; set; }

    /// <summary>
    /// Any text tag of the user
    /// </summary>
    public string Tag { get; set; }

    /// <summary>
    /// Drivers registered for race
    /// </summary>
    public Dictionary<int, Driver> Drivers { get; private set; }

    /// <summary>
    /// Gets practice.
    /// </summary>
    public NonRaceSession Practice { get; private set; }
    /// <summary>
    /// Gets qualify.
    /// </summary>
    public NonRaceSession Qualify { get; private set; }
    /// <summary>
    /// Gets happy hour (pre-race).
    /// </summary>
    public NonRaceSession HappyHour { get; private set; }
    /// <summary>
    /// Gets race.
    /// </summary>
    public RaceSession Race { get; private  set; }
    /// <summary>
    /// Gets/sets points achieved by driver in this race.
    /// </summary>
    public Dictionary<Driver, int> Points { get; set; }

    /// <summary>
    /// Parent season
    /// </summary>
    public Season Season { get; set; }

    public Weekend()
    {
      this.Drivers = new Dictionary<int, Driver>();
      this.Practice = new NonRaceSession(this);
      this.Qualify = new NonRaceSession(this);
      this.HappyHour = new NonRaceSession(this);
      this.Race = new RaceSession(this);
      this.Points = new Dictionary<Driver, int>();
    }

    public bool IsValid()
    {
      if (DayOfRace == new DateTime()) return false;
      if (string.IsNullOrWhiteSpace(Name)) return false;
      if (Track == null) return false;

      return true;
    }

    public bool IsValidWithSeason()
    {
      if (IsValid() == false) return false;
      if (Season == null) return false;

      return true;
    }
  }
}
