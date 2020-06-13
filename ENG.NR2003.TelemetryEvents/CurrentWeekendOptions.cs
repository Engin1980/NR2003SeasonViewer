using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace ENG.NR2003.TelemetryEvents
{
  public partial class CurrentWeekend
  {
    public class cwOptions
    {
      #region Enums

      public enum eDamageLevel
      {
        None = 0,
        Moderate = 2,
        Full = 3
      }
      public enum eGameType
      {
        Simulation,
        Arcade
      }
      #endregion Enums

      #region Fields (unknowns)
      public readonly char Unknown2;
      public readonly char Unknown4;
      public readonly char Unknown7;
      public readonly char Unknown8;
      #endregion Fields (unknowns)

      #region Properties      

      //public TimeSpan PracticeLength { get; private set; }
      //public int QualifyLapCount { get; private set; }
      //public TimeSpan HappyHourLength { get; private set; }
      //public int RaceLapCount { get; private set; }
      public eDamageLevel DamageLevel { get; private set; }
      public bool IsYellowFlagEnabled { get; private set; }
      public eGameType GameType { get; private set; }
      public bool IsAdaptiveSpeedControlEnabled { get; private set; }
      public bool IsDoubleFileRestartEnabled { get; private set; }
      public bool IsFullPaceLapEnabled { get; private set; }
      public bool IsRealWeatherEnabled { get; private set; }
      private int _PitFuelMultiplier = 1;
      public int PitFuelMultiplier
      {
        get { return _PitFuelMultiplier; }
        set
        {
          Contract.Requires(value >= 1 && value <= 4, "Invalid fuel multiplier value (required 1, 2, 3 or 4).");
          _PitFuelMultiplier = value;
        }
      }

      #endregion Properties

      #region .ctor

      public cwOptions(string optionsString)
      {
        Contract.Requires(!string.IsNullOrEmpty(optionsString), "Option string cannot be empty.");

        string s = optionsString;

        DamageLevel = (eDamageLevel)(int)s[0];
        IsYellowFlagEnabled = s[1] == 'Y';
        Unknown2 = s[2];
        GameType = s[3] == 'A' ? eGameType.Arcade : eGameType.Simulation;
        Unknown4 = s[4];
        IsAdaptiveSpeedControlEnabled = s[5] == 'S';
        IsDoubleFileRestartEnabled = s[6] == 'D';
        Unknown7 = s[7];
        Unknown8 = s[8];
        IsFullPaceLapEnabled = s[9] == 'L';
        IsRealWeatherEnabled = s[10] == 'W';
        PitFuelMultiplier = int.Parse(s[11].ToString());
      }

      #endregion .ctor

    }
  }
}
