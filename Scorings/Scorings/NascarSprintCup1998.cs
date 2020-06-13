using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scorings
{
  [Serializable()]
  public class NascarSprintCup1998 : AbstractNRBasicScoring
  {
    public override int AtLeastOneLapLeaderPoints
    {
      get { return 5; }
    }

    public override int MostLapLeaderPoints
    {
      get { return 5; }
    }

    public override int QualifyWinnerPoints
    {
      get { return 0; }
    }

    public override int RaceWinnerExtraPoints
    {
      get { return 5; }
    }

    public override string Name
    {
      get { return "Nascar sprint cup (from 1998)"; }
    }

    public override string Description
    {
      get { return "Top driver 175, winner +5 points, lap leaders +5, top leader +5. See http://en.wikipedia.org/wiki/NASCAR_rules_and_regulations."; }
    }
  }
}
