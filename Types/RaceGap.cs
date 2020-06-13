using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  /// <summary>
  /// Represents race gap.
  /// </summary>
  public class RaceGap : IComparable<RaceGap>, IComparable
  {
    /// <summary>
    /// Gets the race gap as time.
    /// </summary>
    public Time Time { get; private set; }

    /// <summary>
    /// Gets the race gap in laps.
    /// </summary>
    public int Laps { get; private set; }

    public RaceGap(Lap first, Lap second)
    {
      this.Laps = first.LapNumber - second.LapNumber;
      if (this.Laps == 0)
        this.Time = second.CrossedAtTime - first.CrossedAtTime;
    }
    private RaceGap()
    {
    }

    public override string ToString()
    {
      if (Laps == 0 && Time.IsZero())
        return "";
      else if (Laps > 0)
        return "- " + Laps + "L";
      else
        return "- " + Time.ToString(true); 
    }

    public int CompareTo(RaceGap obj)
    {
      int ret = this.Laps.CompareTo(obj.Laps);
      if (ret == 0)
        ret =this.Time.CompareTo(obj.Time);
      return ret;
    }

    public int CompareTo(object obj)
    {
      if (obj == null)
        return -1;
      if (obj is RaceGap)
        return this.CompareTo((RaceGap)obj);
      return -1;
    }

    public static RaceGap Empty { get { return new RaceGap(); } }
  }
}
