using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.TelemetryEvents
{
  [Serializable()]
  public class GamePaused : TelemetryEvent 
  {
    public bool IsPaused { get; private set; }

    public GamePaused(string [] pars)
    {
      IsPaused = pars[0] == "1";
    }

    public override string ToString()
    {
      return this.GetType().Name + string.Format(
        "( {0})",
        this.IsPaused ? "paused" : "unpaused");
    }
  }
}
