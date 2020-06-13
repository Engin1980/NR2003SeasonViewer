using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarSeasonView.SeasonScoring
{
  public class MyScoring : IScoring
  {
    public string Name
    {
      get { return "NR2003 scoring"; }
    }

    public string Description
    {
      get { return "Scoring as implemented in NR2003 game."; }
    }

    public object Parameters
    {
      get
      {
        return null;
      }
      set
      {
        return;
      }
    }

    public Dictionary<int, int> GetScoring(ENG.NR2003.StaticRaceWeekend.Weekend weekend)
    {
      Dictionary<int, int> ret = new Dictionary<int, int>();
      foreach (var fItem in weekend.Drivers) ret.Add(fItem.CarIdx, 0);

      // +5 for Qualify winner
      // taken as driver first starting into race
      IncreasePoints (ret, weekend.Race.Standings[0].Driver.CarIdx, 5);

      // +5 for fastest lap
      int carIdx = weekend.Race.Statistics.BasicRaceStats.FastestLap.Driver.CarIdx;
      IncreasePoints(ret, carIdx, 5);

      // 1. - 10. od 180/-5
      int pts = 180;
      int driverCount = weekend.Race.Standings.Count;
      for (int i = 0; i < Math.Min(9, driverCount); i++)
      {
        IncreasePoints(ret, weekend.Race.Standings[i].Driver.CarIdx, pts);
        pts -=5;
      }

      // 11. - 20.  -4
      for (int i = 10; i < Math.Min(19, driverCount); i++)
      {
        IncreasePoints(ret, weekend.Race.Standings[i].Driver.CarIdx, pts);
        pts -= 4;
      }

      // 21. - vše
      for (int i = 20; i < driverCount; i++)
      {
        IncreasePoints(ret, weekend.Race.Standings[i].Driver.CarIdx, pts);
        pts -= 3;
      }

      return ret;
    }

    private void IncreasePoints (Dictionary<int, int> dct , int carIdx, int pointValue)
    {
      int val = dct[carIdx];
      val += pointValue;
      dct[carIdx] = val;
    }
  }
}
