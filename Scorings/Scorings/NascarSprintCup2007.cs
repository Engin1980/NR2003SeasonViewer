using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scorings
{
  [Serializable()]
  public class NascarSprintCup2007 : NascarSprintCup2004
  {
    public override int RaceWinnerExtraPoints
    {
      get
      {
        return base.RaceWinnerExtraPoints + 5;
      }
    }

    public override string Name
    {
      get { return "Nascar sprint cup (from 2007)"; }
    }

    public override string Description
    {
      get { return "Top driver 175, winner +15 points, lap leaders +5, top leader +5. See http://en.wikipedia.org/wiki/NASCAR_rules_and_regulations."; }
    }
  }
}
