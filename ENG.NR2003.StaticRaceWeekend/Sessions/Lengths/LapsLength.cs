using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.StaticRaceWeekend.Sessions.Lengths
{
  [Serializable()]
  public class LapsLength : Length
  {
    private int value;
    public LapsLength(int numberOfLaps)
    {
      value = numberOfLaps;
    }

    public int NumberOfLaps
    {
      get { return value; }
    }

    public override string ToString()
    {
      return value + " laps";
    }
  }
}
