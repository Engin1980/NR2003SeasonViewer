using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;
using Scorings;

namespace ENG.NR2003.NascarSeasonView.Types.BOs
{
  class SeasonEvaluator
  {
    private class TempData
    {
      public Driver Driver { get; set; }
      public int LapsInLead { get; set; }
      public int QualifyPosition { get; set; }

      public class ByLapsInLeadComparer : IComparer<TempData>
      {

        public int Compare(TempData x, TempData y)
        {
          return -(x.LapsInLead.CompareTo(y.LapsInLead));
        }
      }
    }

    public static void ReEvaluate(Season season, Weekend weekend)
    {
      int ci = -1;
      for (int i = 0; i < season.RaceWeekends.Count; i++)
      {
        if (season.RaceWeekends[i].Weekend == weekend)
        {
          ci = i;
          break;
        }
      }

      if (ci < 0)
        throw new ApplicationException("Cannot find weekend to update in season.");

      ReEvaluate(season, ci);
    }

    public static void ReEvaluate(Season season, int fromRaceIndexToEvaluate)
    {
      for (int i = fromRaceIndexToEvaluate; i < season.RaceWeekends.Count; i++)
      {
        if (i == 0)
          ReEvaluate(null, season.RaceWeekends[i], season.Scoring);
        else
          ReEvaluate(season.RaceWeekends[i - 1], season.RaceWeekends[i], season.Scoring);
      }

      RebuildTotalStats(season);
    }

    private static void RebuildTotalStats(Season season)
    {
      int l = 0;
      int r = 0;

      foreach (var item in season.RaceWeekends)
      {
        l += item.Weekend.Settings.RaceLapCount;
        r++;

        item.Standings.TotalLapsCount = l;
        item.Standings.TotalRacesCount = r;
      }
    }

    private static void ReEvaluate(WeekendInfo previous, WeekendInfo current, object scoringAsObject)
    {
      AbstractScoring sc = scoringAsObject as AbstractScoring;

      ReEvaluate(previous, current, sc);
    }

    private static void ReEvaluate(WeekendInfo previous, WeekendInfo current, AbstractScoring scoring)
    {
      if (current == null)
        throw new ArgumentNullException();
      if (scoring == null)
        throw new ArgumentNullException();
      if (current.Weekend.Race.IsEmpty())
        throw new ArgumentException();

      Weekend weekend = current.Weekend;
      RaceSession race = weekend.Race;

      var poss = race.Positions.GetLastLap();
      weekend.Points.Clear();

      PrepareNewStandings(previous, current);

      Dictionary<Driver, TempData> tmp = CalculateTempData(poss);

      foreach (var item in poss)
      {
        UpdateNewDriverStandingsByNewRace(previous, current, scoring, weekend, race, tmp, item);
      }

      OrderDriverStandingsByPointsAndAssignPosition(current);
    }

    private static void OrderDriverStandingsByPointsAndAssignPosition(WeekendInfo current)
    {
      current.Standings.Sort(new DriverStandings.ByPointsSumComparer());
      for (int i = 0; i < current.Standings.Count; i++)
      {
        current.Standings[i].Position = i + 1;

        if (i > 0)
        {
          current.Standings[i].BetterStandings = current.Standings[i - 1];
          current.Standings[i - 1].WorseStandings = current.Standings[i];
        }
      }
    }

    private static void UpdateNewDriverStandingsByNewRace(WeekendInfo previous, WeekendInfo current, AbstractScoring scoring, Weekend weekend, RaceSession race, Dictionary<Driver, TempData> tmp, RaceLap item)
    {
      DriverStandings prevDs = null;
      if (previous != null) prevDs = previous.Standings[item.Driver];
      if (current.Standings[item.Driver] == null)
        current.Standings.Add(new DriverStandings() { Driver = item.Driver });
      DriverStandings newDs = current.Standings[item.Driver];

      int racePoints = GetRacePoints(item, scoring, tmp);

      weekend.Points.Add(item.Driver, racePoints);

      newDs.PointsM.Add(racePoints);

      newDs.BlackFlagsMean.Add(item.Sum(
        i => i.IsBlackFlagged ? 1 : 0,
        i => i.PreviousLapAsRaceLap
        ));

      if (race.Positions.GetDriverFinalStatus(item.Driver) == RacePositionCollection.eStatus.Accident ||
        race.Positions.GetDriverFinalStatus(item.Driver) == RacePositionCollection.eStatus.Retired)
        newDs.CrashesCount++;

      if (race.Positions.GetDriverFinalStatus(item.Driver) == RacePositionCollection.eStatus.Running)
        newDs.FinishesCount++;

      newDs.FinishPositionsMean.Add(item.CurrentPosition);

      newDs.LapsInLead +=
        tmp[item.Driver].LapsInLead;

      newDs.QualifyPositionsMean.Add(
        tmp[item.Driver].QualifyPosition);

      newDs.RacesCount++;
      newDs.LapsCount += item.LapNumber;

      int pos = item.CurrentPosition;
      if (pos < 2)
        newDs.Top1++;
      if (pos < 3)
        newDs.Top2++;
      if (pos < 4)
        newDs.Top3++;
      if (pos < 6)
        newDs.Top5++;
      if (pos < 11)
        newDs.Top10++;
      if (pos < 21)
        newDs.Top20++;

      newDs.PreviousWeekendStanding = prevDs;
      if (prevDs != null)
        prevDs.NextWeeendStanding = newDs;
    }

    private static Dictionary<Driver, TempData> CalculateTempData(List<RaceLap> poss)
    {
      List<TempData> pom = new List<TempData>();

      foreach (var item in poss)
      {
        int ll =
          item.Count(i => i.CurrentPosition == 1, i => i.PreviousLapAsRaceLap);
        int q =
          item.Session.Weekend.Qualify.Positions.GetPosition(item.Driver);

        pom.Add(new TempData() { Driver = item.Driver, LapsInLead = ll, QualifyPosition = q });
      }

      pom.Sort(new TempData.ByLapsInLeadComparer());

      Dictionary<Driver, TempData> ret = new Dictionary<Driver, TempData>();

      pom.ForEach(i => ret.Add(i.Driver, i));

      return ret;
    }

    private static void PrepareNewStandings(WeekendInfo previous, WeekendInfo current)
    {
      current.Standings.Clear();

      if (previous == null) return;

      foreach (var item in previous.Standings)
      {
        DriverStandings newDs = CloneDriverStandingsForNewRace(item);
        current.Standings.Add(newDs);
      }
    }

    private static int GetRacePoints(RaceLap item, AbstractScoring scoring, Dictionary<Driver, TempData> tmp)
    {
      int ret = 0;

      ret = scoring.GetPositionPoints(item.CurrentPosition);

      if (scoring.AtLeastOneLapLeaderPoints > 0)
        if (item.Exists(
          i => i.CurrentPosition == 1,
          i => (i.PreviousLap as RaceLap)))
          ret += scoring.AtLeastOneLapLeaderPoints;

      if (scoring.MostLapLeaderPoints > 0)
        if (tmp[tmp.Keys.First()].LapsInLead == tmp[item.Driver].LapsInLead)
          ret += scoring.MostLapLeaderPoints;

      if (scoring.QualifyWinnerPoints > 0)
        if (tmp[item.Driver].QualifyPosition == 1)
          ret += scoring.QualifyWinnerPoints;

      if (scoring.RaceWinnerExtraPoints > 0)
        if (item.CurrentPosition == 1)
          ret += scoring.RaceWinnerExtraPoints;

      return ret;
    }

    private static DriverStandings CloneDriverStandingsForNewRace(DriverStandings prevDs)
    {
      DriverStandings currDs = new DriverStandings();

      currDs.Driver = prevDs.Driver;
      currDs.BetterStandings = null;
      currDs.BlackFlagsMean = prevDs.BlackFlagsMean.Clone();
      currDs.CrashesCount = prevDs.CrashesCount;
      currDs.FinishesCount = prevDs.FinishesCount;
      currDs.FinishPositionsMean = prevDs.FinishPositionsMean.Clone();
      currDs.LapsInLead = prevDs.LapsInLead;
      currDs.PointsM = prevDs.PointsM.Clone();
      currDs.Position = 0;
      currDs.QualifyPositionsMean = prevDs.QualifyPositionsMean.Clone();
      currDs.RacesCount = prevDs.RacesCount;
      currDs.LapsCount = prevDs.LapsCount;
      currDs.Top1 = prevDs.Top1;
      currDs.Top10 = prevDs.Top10;
      currDs.Top2 = prevDs.Top2;
      currDs.Top20 = prevDs.Top20;
      currDs.Top3 = prevDs.Top3;
      currDs.Top5 = prevDs.Top5;
      currDs.WorseStandings = null;

      return currDs;
    }
  }
}
