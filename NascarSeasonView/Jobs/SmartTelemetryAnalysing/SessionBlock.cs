using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.TelemetryEvents;

namespace ENG.NR2003.NascarSeasonView.Jobs.SmartTelemetryLoading
{
  class SessionBlock
  {
    public CurrentWeekend CurrentWeekend { get; set; }
    public SessionInfo SessionInfo { get; set; }
    public List<DriverEntry> Drivers { get; set; }
    public List<TelemetryEvent> Events { get; set; }

    public SessionBlock()
    {
      this.Drivers = new List<DriverEntry>();
      this.Events = new List<TelemetryEvent>();
    }
  }
}
