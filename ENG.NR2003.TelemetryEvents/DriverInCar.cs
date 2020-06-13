using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.TelemetryEvents
{
  [Serializable()]
  public class DriverInCar : TelemetryEvent
  {
    public bool InCar { get; private set; }

    public DriverInCar (string [] pars)
    {
      InCar = pars[0] == "1";
    }

    public override string ToString()
    {
      return this.GetType().Name + string.Format(
        "( {0})",
        this.InCar);
    }
  }
}
