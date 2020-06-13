using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace ENG.NR2003.StaticRaceWeekend.LapRecords
{
  [Serializable()]
  public struct LapRecord : IComparable<LapRecord>
  {
    [Flags()]
    public enum eFlag
    {
      None,
      Invalid,
      OffTrack,
      BlackFlag,
      Pitted
    }

    public double LapTime { get; internal set; }
    public int LapNumber { get; internal set; }
    public double SimulationTime { get; internal set; }
    public eFlag Flag { get; internal set; }

    public bool IsPitted { get { return (Flag & eFlag.Pitted) > 0; } }
    public bool IsEmpty { get { return this.LapTime == 0; } }

    public static LapRecord GetEmpty()
    {
      return new LapRecord();
    }

    public LapRecord(double lapTime, int lapNumber, double simulationTime, eFlag flag) :this()
    {
      Contract.Requires(lapTime != 0);
      Contract.Requires(lapNumber != 0);
      Contract.Requires(simulationTime != 0);

      this.LapTime = lapTime;
      this.LapNumber = lapNumber;
      this.SimulationTime = simulationTime;
      this.Flag = flag;
    }

    public override string ToString()
    {
      return this.LapTime.ToString("N3") + " <" + this.LapNumber + ">";
    }

    #region IComparable<LapTime> Members

    public int CompareTo(LapRecord other)
    {
      int ret;
      if (this.IsEmpty)
        if (other.IsEmpty)
          ret= 0;
        else
          ret=1;
      else
        if (other.IsEmpty)
          ret=-1;
        else
        {
          ret = this.LapTime.CompareTo(other.LapTime);
          if (ret == 0)
            ret = this.LapNumber.CompareTo(other.LapNumber);
        }

      return ret;
    }

    #endregion

    public static bool operator == (LapRecord a, LapRecord b)
    {
      return
        (a.Flag == b.Flag) &&
        (a.LapNumber == b.LapNumber) &&
        (a.LapTime == b.LapTime) &&
        (a.SimulationTime == b.SimulationTime);
    }

    public override bool Equals(object obj)
    {
      if (obj is LapRecord)
        return this == (LapRecord)obj;
      else
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public static bool operator !=(LapRecord a, LapRecord b)
    {
      return ((a == b) == false);
    }
  }
}
