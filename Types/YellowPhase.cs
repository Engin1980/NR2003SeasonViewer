using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  [Serializable()]
  public class YellowPhase : IComparable<YellowPhase>
  {
    public Time StartTime { get; set; }
    public int StartLap { get; set; }

    public Time EndTime { get; set; }
    public int EndLap { get; set; }
    public int Length { get { return EndLap - StartLap; } }
    public bool IsValid()
    {
      return !EndTime.IsZero() && !StartTime.IsZero();
    }

    public int CompareTo(YellowPhase other)
    {
      return this.StartTime.CompareTo(other.StartTime);
    }
  }
}
