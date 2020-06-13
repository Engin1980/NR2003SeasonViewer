using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.TelemetryEvents
{
  [Serializable()]
  public class DriverWithdrawl : TelemetryEvent
  {
    public int CarIdx { get; private set; }

    public DriverWithdrawl(string[] pars)
    {
      CarIdx = int.Parse(pars[0]);
    }

    public override string ToString()
    {
      return this.GetType().Name + string.Format(
        "( {0})",
        this.CarIdx);
    }
  }
}
