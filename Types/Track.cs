using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  /// <summary>
  /// Represents track.
  /// </summary>
  [Serializable()]
  public class Track
  {
    private const string INI_FILE_NAME = "track.ini";

    /// <summary>
    /// Gets/sets track name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Gets/sets track city
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// Gets/sets track state
    /// </summary>
    public string State { get; set; }
    /// <summary>
    /// Gets/sets track length in miles as set in INI file
    /// </summary>
    public double LengthInMiles { get; set; }
    /// <summary>
    /// Gets/sets track length in feet as set in INI file. Recalculated from <see cref="LengthInMiles"/>
    /// </summary>
    public int LengthInFeet
    {
      get
      {
        return (int)(LengthInMiles * 1000);
      }
      set
      {
        LengthInMiles = value / 1000d;
      }
    }
    /// <summary>
    /// Gets/sets adjusted track length, used to reacalculate values for speed display.
    /// </summary>
    public int AdjustedLengthInFeet { get; set; }
    /// <summary>
    /// Gets/sets folder with ini file of the track, if set.
    /// </summary>
    public string IniFileFolder { get; set; }

    /// <summary>
    /// Gets name of the ini file of the track.
    /// </summary>
    public string IniFile
    {
      get
      {
        if (string.IsNullOrEmpty(IniFileFolder))
          return null;
        else
          return System.IO.Path.Combine(IniFileFolder, INI_FILE_NAME);
      }
    }

    public bool IsValid()
    {
      if (string.IsNullOrWhiteSpace(Name)) return false;
      //if (string.IsNullOrWhiteSpace(City)) return false;
      //if (string.IsNullOrWhiteSpace(State)) return false;
      if (LengthInFeet < 0) return false;
      if (AdjustedLengthInFeet < 0) return false;

      return true;
    }

    public override string ToString()
    {
      return string.Format("{0} ({1}, {2})",
        this.Name, this.City, this.State);
    }
  }
}
