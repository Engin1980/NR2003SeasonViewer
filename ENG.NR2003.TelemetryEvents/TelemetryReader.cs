using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.TelemetryEvents
{
  [Serializable()]
  public class TelemetryReader
  {
    private System.IO.Stream stream = null;
    private System.IO.StreamReader rdr = null;
    private TelemetryEvent previousItem = null;
    private bool isAtTheEnd = false;

    public TelemetryReader(System.IO.Stream stream)
    {
      this.stream = stream;
      rdr = new System.IO.StreamReader(this.stream);
    }

    public TelemetryReader(string fileName) : this(OpenFileToRead(fileName)) { }

    private static System.IO.FileStream OpenFileToRead(string fileName)
    {
      System.IO.FileStream fs = new System.IO.FileStream(
        fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);

      return fs;
    }

    public void Close()
    {
      rdr.Close();
      stream.Close();

      rdr = null;
      stream = null;
    }

    public TelemetryEvent Read()
    {
      TelemetryEvent ret = null;

      if (previousItem != null)
      {
        ret = previousItem;
        previousItem = null;
      }
      else
      {
        string line = rdr.ReadLine();
        if (line == null)
          isAtTheEnd = true;
        else
          ret = Analyser.DecodeLine(line);
      }

      return ret;
    }

    public bool IsAtTheEnd()
    {
      return isAtTheEnd;
    }

    public TelemetryEvent ReadUntilTime(double time)
    {
      TelemetryEvent item = Read();

      if (item is LapCrossing)
      {
        LapCrossing cr = item as LapCrossing;
        if (cr.CrossedAt > time)
        {
          this.previousItem = item;
          item = null;
        }
      }
      else if (item is SessionInfo)
      {
        SessionInfo si = item as SessionInfo;
        if (si.CurrentTime > time)
        {
          this.previousItem = item;
          item = null;
        }
      }

      return item;
    }
  }
}
