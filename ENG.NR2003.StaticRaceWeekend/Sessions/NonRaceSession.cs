using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.StaticRaceWeekend.Sessions
{
  [Serializable()]
  public class NonRaceSession : Session
  {
    protected override Standings.Standing CreateStandingByDriver(Drivers.Driver d)
    {
      var ret =
        new NR2003.StaticRaceWeekend.Standings.NonRaceStanding();

      ret.Driver = d;

      return ret;
    }

    public override bool IsEmpty
    {
      get
      {
        return base.Standings.Count == 0 || base.Standings[0].Laps.Count == 0;
      }
    }
  }
}
