using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scorings
{
  [Serializable()]
  public abstract class AbstractScoring
  {
    public abstract int AtLeastOneLapLeaderPoints { get; }
    public abstract int MostLapLeaderPoints { get; }
    public abstract int QualifyWinnerPoints { get; }
    public abstract int RaceWinnerExtraPoints { get; }
    public abstract int GetPositionPoints(int position);

    public abstract string Name { get; }

    public abstract string Description { get; }

    //public D GetScoring(StaticRaceWeekend.Weekend weekend)
    //{
    //  D ret = InitEmptyScorings(weekend);

    //  string qualifyWinner = GetQualifyWinner(weekend);
    //  string raceWinner = GetRaceWinner(weekend);

    //  EvaluateDriverPoints(ret, weekend);
    //  foreach (ENG.NR2003.StaticRaceWeekend.Standings.RaceStanding item in weekend.Race.Standings)
    //  {
    //    if (item.LapInLeadCount > 0)
    //      IncreaseValue(ret, item.Driver.CarNumber, AtLeastOneLapLeaderPoints);
    //    if (item.HasTheMostLapsInLead)
    //      IncreaseValue(ret, item.Driver.CarNumber, MostLapLeaderPoints);
    //  }
    //  IncreaseValue(ret, qualifyWinner, QualifyWinnerPoints);
    //  IncreaseValue(ret, raceWinner, RaceWinnerExtraPoints);

    //  return ret;
    //}

    //private string GetQualifyWinner(StaticRaceWeekend.Weekend weekend)
    //{
    //  int carIdx = weekend.Race.DetailedStandings.GetLap(0)[0].CarIdx;
    //  string ret = weekend.Drivers.TryGetByIdx(carIdx).CarNumber;
    //  return ret;
    //}

    //private string GetRaceWinner(StaticRaceWeekend.Weekend weekend)
    //{
    //  int carIdx = weekend.Race.Standings[0].Driver.CarIdx;
    //  string ret = weekend.Drivers.TryGetByIdx(carIdx).CarNumber;
    //  return ret;
    //}

    //private void EvaluateDriverPoints(D ret, StaticRaceWeekend.Weekend weekend)
    //{
    //  for (int i = 0; i < weekend.Race.Standings.Count; i++)
    //  {
    //    int points = GetPositionPoints(i + 1);
    //    IncreaseValue(ret, weekend.Race.Standings[i].Driver.CarNumber, points);
    //  }
    //}

    //private D InitEmptyScorings(StaticRaceWeekend.Weekend weekend)
    //{
    //  D ret = new D();
    //  foreach (var item in weekend.Drivers)
    //  {
    //    ret.Add(item, 0);
    //  }
    //  return ret;
    //}
        
    //private void IncreaseValue(D dictionary, string carNumber, int value)
    //{
    //  Contract.Assert (dictionary.ContainsCarNumber(carNumber) ==  true);

    //  var current = dictionary.Get(carNumber);
    //    current = current + value;
    //    dictionary.Set(carNumber, current);
    //}

  }
}
