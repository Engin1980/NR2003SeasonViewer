using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace ENG.NR2003.TelemetryEvents
{
  public partial class CurrentWeekend : TelemetryEvent
  {
    public bool AtTrack { get; private set; }
    public String Track { get; private set; }
    public double TrackLength { get; private set; }
    public ENG.NR2003.TelemetryEvents.CurrentWeekend.cwSessions Sessions { get; private set; }
    public ENG.NR2003.TelemetryEvents.CurrentWeekend.cwOptions Options { get; private set; }    

    public CurrentWeekend(string[] pars)
    {
      AtTrack = (pars[0] == "1");
      if (AtTrack)
      {
      Track = pars[1].Trim();
      TrackLength = double.Parse(pars[2], System.Globalization.CultureInfo.GetCultureInfo("en-us"));
      Sessions = new ENG.NR2003.TelemetryEvents.CurrentWeekend.cwSessions(pars[3]);
      Options = new ENG.NR2003.TelemetryEvents.CurrentWeekend.cwOptions(pars[4]);
      }
    }

    public override string ToString()
    {
      return this.GetType().Name + string.Format(
        "( {0}; {1} mts; {2})",
        this.Track, this.TrackLength, this.AtTrack ? "(at track)" : "(not at track)");
    }
  }
}
