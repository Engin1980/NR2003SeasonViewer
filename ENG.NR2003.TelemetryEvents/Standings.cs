using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.TelemetryEvents
{
  [Serializable()]
  public class Standings : TelemetryEvent
  {
    [Flags()]
    public enum eStandingsFlags
    {
      kStandingsOfficial = 0x00000001,
      kStandingsForRace = 0x00000002
    };

    public eStandingsFlags Flags { get; private set; }
    public int SessionNum { get; private set; }
    public double AverageLapTime { get; private set; }
    public int LapsCompleted { get; private set; }
    public int NumCautionFlags { get; private set; }
    public int NumCautionLaps { get; private set; }
    public int NumLeadChanges { get; private set; }
    public StandingsEntry FastestLap { get; private set; }
    public List<StandingsEntry> Positions { get; private set; }

    public bool IsOfficial
    {
      get
      {
        return (Flags & eStandingsFlags.kStandingsOfficial) != 0;
      }
    }

    public Standings(string [] pars)
    {
      Positions = new List<StandingsEntry>();

      Flags = (eStandingsFlags) int.Parse(pars[0]);
      SessionNum = int.Parse(pars[1]);
      AverageLapTime = Analyser.DblParse(pars[2]);
      LapsCompleted = int.Parse(pars[3]);
      NumCautionFlags = int.Parse(pars[4]);
      NumCautionLaps = int.Parse(pars[5]);
      NumLeadChanges = int.Parse(pars[6]);

      FastestLap = (StandingsEntry) Analyser.DecodeLine(pars[7]);

      for (int i = 8; i < pars.Length; i++)
        Positions.Add((StandingsEntry)Analyser.DecodeLine(pars[i]));
    }

    public override string ToString()
    {          
      return this.GetType().Name + string.Format(
        "( sessNum: {0}; {1}; lapsCompl {2})",
        this.SessionNum, this.Flags.ToString(), this.LapsCompleted.ToString());
    }
  }
}
