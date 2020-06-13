using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.TelemetryEvents
{
  [Serializable()]
  public class LapCrossing : TelemetryEvent
  {
    [Flags()]
    [Serializable()]
    public enum eLapCrossingFlags
    {
      kCrossTimeInvalid = 0x00000001,
      kCrossOffTrack = 0x00000002,
      kCrossPitted = 0x00000004,
      kCrossBlackFlag = 0x00000008
    }

    public int CarIdx { get; private set; }
    public int LapNum { get; private set; }
    public eLapCrossingFlags Flags { get; private set; }
    public double CrossedAt { get; private set; }
    public bool IsTimeInvalid
    {
      get
      {
        return (0 != (Flags & eLapCrossingFlags.kCrossTimeInvalid));
      }
    }
    public bool IsOffTrack
    {
      get
      {
        return (0 != (Flags & eLapCrossingFlags.kCrossOffTrack));
      }
    }
    public bool IsPitted
    {
      get
      {
        return (0 != (Flags & eLapCrossingFlags.kCrossPitted));
      }
    }
    public bool IsBlackFlagged
    {
      get
      {
        return (0 != (Flags & eLapCrossingFlags.kCrossBlackFlag));
      }
    }
    

    public LapCrossing(string[] pars)
    {
      CarIdx = int.Parse(pars[0]);
      LapNum = int.Parse(pars[1]);
      Flags = (eLapCrossingFlags)int.Parse(pars[2]);
      CrossedAt = Analyser.DblParse(pars[3]);
    }

    public override string ToString()
    {
      return this.GetType().Name + string.Format(
        "( {0}; {1}; {2}; {3}; {4}; {5}; {6})",
        this.CarIdx, this.LapNum, this.CrossedAt, 
        IsTimeInvalid ? "invalid" : "valid", 
        IsOffTrack ? "off-track" : "on track",
        IsPitted ? "in pit" : "not pit",
        IsBlackFlagged ? "black flag" : "no black flag");
    }
  }
}
