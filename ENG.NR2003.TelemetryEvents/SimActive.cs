using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.TelemetryEvents
{
  [Serializable()]
  public class SimActive : TelemetryEvent
  {
    public SimActive(string[] pars) { }

    public override string ToString()
    {
      return this.GetType().Name;
    }
  }
}
