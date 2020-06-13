using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scorings
{
  [Serializable()]
  public class NascarSprintCup1982 : AbstractNRBasicScoring
  {
    public override int AtLeastOneLapLeaderPoints
    {
      get { return 0; }
    }

    public override int MostLapLeaderPoints
    {
      get { return 0; }
    }

    public override int QualifyWinnerPoints
    {
      get { return 0; }
    }

    public override int RaceWinnerExtraPoints
    {
      get { return 0; }
    }

    public override string Name
    {
      get { return "Nascar sprint cup (from 1982)"; }
    }

    public override string Description
    {
      get { return "Top driver 175, no bonus points. See http://en.wikipedia.org/wiki/NASCAR_rules_and_regulations."; }
    }

  }
}
