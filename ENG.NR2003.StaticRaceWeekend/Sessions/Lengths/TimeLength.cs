using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.StaticRaceWeekend.Sessions.Lengths
{
  [Serializable()]
  public class TimeLength :Length
  {
    TimeSpan value;

    public TimeLength(int seconds)
    {
      this.value = new TimeSpan(0, 0, seconds);
    }

    public TimeLength (TimeSpan value)
    {
      this.value = value;
    }

    public override string ToString()
    {
      return value.ToString();
    }
  }
}
