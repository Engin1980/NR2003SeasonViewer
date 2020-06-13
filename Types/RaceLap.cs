using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  [Serializable()]
  public class RaceLap : Lap
  {
    public enum ePitState
    {
      None,
      Entry,
      Exit,
      ExitAndEntry
    }

    public int CurrentPosition { get; set; }
    public RaceLap PreviousPositionLap { get; set; }
    public RaceLap NextPositionLap { get; set; }
    public ePitState PitState { get; set; }

    public RaceLap PreviousLapAsRaceLap { get { return this.PreviousLap as RaceLap; } }

    public bool IsPitEntryOrExit()
    {
      return this.PitState != ePitState.None;
    }

    public int Sum(Func<RaceLap, int> selector, Func<RaceLap, RaceLap> enumerator)
    {
      int ret = selector(this);
      RaceLap prevLap = enumerator(this);
      if (prevLap != null)
        ret += prevLap.Sum(selector, enumerator);

      return ret;
    }

    public RaceLap Min(Func<RaceLap, double> selector, Func<RaceLap, RaceLap> enumerator)
    {
      RaceLap ret = null;

      RaceLap prevLap = enumerator(this);
      if (prevLap != null)
      {
        ret = prevLap.Min(selector, enumerator);
        if (selector(this) < selector(ret))
          ret = this;
      }
      else
        ret = this;

      return ret;
    }

    public int Count(Func<RaceLap, bool> predicate, Func<RaceLap, RaceLap> enumerator)
    {
      int ret = 0;
      if (predicate(this))
        ret++;

      RaceLap prevLap = enumerator(this);
      if (prevLap != null)
        ret += prevLap.Count(predicate, enumerator);

      return ret;
    }

    public bool Exists(Func<RaceLap, bool> predicate, Func<RaceLap, RaceLap> enumerator)
    {
      bool ret = predicate(this);
      if (ret) return true;

      RaceLap prevLap = enumerator(this);
      if (prevLap != null)
        prevLap.Exists(predicate, enumerator);

      return false;
    }
  }
}
