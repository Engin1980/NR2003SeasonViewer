using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  [Serializable()]
  public class WeekendRealism
  {
    public enum eMode
    {
      Arcade,
      Simulation
    }
    public enum eDamageLevel
    {
      Full,
      Moderate,
      None
    }

    public eMode Mode { get; set; }

    public eDamageLevel DamageLevel { get; set; }

    public int OpponentStrength { get; set; }

    public bool IsAdaptiveSpeedControlEnabled { get; set; }

    public bool IsDoubleFileRestartEnabled { get; set; }

    public bool IsFullPaceLapEnabled { get; set; }

    public bool IsRealWeatherEnabled { get; set; }

    public bool IsYellowFlagEnabled { get; set; }

    public int PitFuelMultiplier { get; set; }
  }
}
