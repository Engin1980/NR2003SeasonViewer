using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  [Serializable()]
  public class WeekendSettings
  {
    public Time PracticeLength { get; set; }
    public int QualifyLapCount { get; set; }
    public Time PreRaceLength { get; set; }
    public int RaceLapCount { get; set; }
  }
}
