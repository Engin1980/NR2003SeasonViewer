using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics.Contracts;

namespace ENG.NR2003.TelemetryEvents
{
  [Serializable()]
  public partial class CurrentWeekend
  {
  public class cwSessions
  {
    private const string REGEX = @"(\d)(.)(\d+)SQ(\d+)LP(\d+)SR(\d+)L";

    #region Enums
    public enum eWeekendType
    {
      Unknown,
      NormalRace = 'P',
      QuickRace = 'Q'
    }
    #endregion Enums

    #region Fields (uknowns)

    public readonly char Unknown0;
    public readonly char WeekendTypeChar;

    #endregion Fields (uknowns)

    #region Properties
    
    public eWeekendType Type { get; private set; }
    public TimeSpan PracticeLength { get; set; }
    public int QualifyLapCount { get; set; }
    public TimeSpan HappyHourLength { get; set; }
    public int RaceLapCount { get; set; }

    #endregion Properties

    #region .ctor
    public cwSessions (string line)
    {
      Contract.Requires(!string.IsNullOrEmpty(line), "Line input for CurrentWeekend+Sessions cannot be empty.");

      Match m = Regex.Match(line, REGEX);
      var g = m.Groups;
      this.Unknown0 = g[1].Value[0];
      this.WeekendTypeChar = g[2].Value[0];
      Type = GetWeekendType(this.WeekendTypeChar);
      this.PracticeLength = GetTimeSpan(g[3].Value);
      this.QualifyLapCount = GetInt(g[4].Value);
      this.HappyHourLength = GetTimeSpan(g[5].Value);
      this.RaceLapCount = GetInt(g[6].Value);
    }

    private TimeSpan GetTimeSpan(string p)
    {
      int val = GetInt(p);
      TimeSpan ret = new TimeSpan(0, 0, val);
      return ret;
    }

    private eWeekendType GetWeekendType(char p)
    {
      switch (p)
      {
        case 'P':
          return eWeekendType.NormalRace;
        case 'Q':
          return eWeekendType.QuickRace;
        default:
          return eWeekendType.Unknown;
      }
    }

    private int GetInt(string p)
    {
      return int.Parse(p);
    }
    #endregion .ctor
  }
  }
}
