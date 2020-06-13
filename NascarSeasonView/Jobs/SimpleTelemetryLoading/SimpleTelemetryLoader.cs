using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.TelemetryEvents;

namespace ENG.NR2003.NascarSeasonView.Jobs.SimpleTelemetryLoading
{
  public static class SimpleTelemetryLoader
  {
    public static TelemetryEvent[] LoadTelemetry(string fileName)
    {
      var lines = ReadFileContent(fileName);
      var ret = AnalyseLines(lines);

      return ret;
    }

    private static TelemetryEvent[] AnalyseLines(string[] lines)
    {
      TelemetryEvent evnt;
      List<TelemetryEvent> events = new List<TelemetryEvent>();

      for (int i = 0; i < lines.Length; i++)
      {
        evnt = TelemetryEvent.Create(lines[i]);
        events.Add(evnt);
      }

      TelemetryEvent[] ret = events.ToArray();

      return ret;
    }

    private static string[] ReadFileContent(string logFileName)
    {
      string[] ret;

      var lines = System.IO.File.ReadLines(logFileName);

      ret = lines.ToArray();

      return ret;
    }
  }
}
