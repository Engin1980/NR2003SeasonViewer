using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.StaticRaceWeekend.Standings.Support
{
  [Serializable()]
  public struct Gap : IComparable<Gap>
  {
    public readonly int Laps;
    public readonly double Time;

    public Gap(int laps, double time)
    {
      this.Laps = laps;
      this.Time = time;
    }

    public Gap(double time) : this(0, time) { }

    public string ToDisplayString()
    {
      if (Laps > 0)
        return Laps + "L";
      else
        return Time.ToString("N3");
    }

    #region IComparable<Gap> Members

    public int CompareTo(Gap other)
    {
      int ret = this.Laps.CompareTo(other.Laps);
      if (ret == 0) ret = this.Time.CompareTo(other.Time);
      return ret;
    }

    #endregion
  }
}
