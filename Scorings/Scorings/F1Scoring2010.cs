using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scorings
{
  [Serializable()]
  public class F1Scoring2010 : AbstractScoring
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

    public override int GetPositionPoints(int position)
    {
      switch (position)
      {
        case 1:
          return 25;
        case 2:
          return 18;
        case 3:
          return 15;
        case 4:
          return 12;
        case 5:
          return 10;
        case 6:
          return 8;
        case 7:
          return 6;
        case 8:
          return 4;
        case 9:
          return 2;
        case 10:
          return 1;
        default:
          return 0;
      }
    }

    public override string Name
    {
      get { return "Formula 1 (from 2010)"; }
    }

    public override string Description
    {
      get { return "Formula 1 scorint system valid from 2010 as presented in  http://en.wikipedia.org/wiki/List_of_Formula_One_World_Championship_points_scoring_systems."; }
    }
  }
}
