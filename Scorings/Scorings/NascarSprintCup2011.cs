using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scorings
{
  [Serializable()]
  public class NascarSprintCup2011 : AbstractScoring
  {
    public override int AtLeastOneLapLeaderPoints
    {
      get { return 1; }
    }

    public override int MostLapLeaderPoints
    {
      get { return 1; }
    }

    public override int QualifyWinnerPoints
    {
      get { return 0; }
    }

    public override int RaceWinnerExtraPoints
    {
      get { return 3; }
    }

    public override int GetPositionPoints(int position)
    {
      int ret = 44 - position;
      if (ret < 0) ret = 0;
      return ret;
    }

    public override string Name
    {
      get { return "Nascar sprint cup (from 2011, no chase)"; }
    }

    public override string Description
    {
      get { return "Standard NR sprint cup scoring, no chase for cup applied."; }
    }

  }
}
