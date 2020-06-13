using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ENG.NR2003.StaticRaceWeekend.Sessions.Support
{
  [Serializable()]
  public class RaceStatistics
  {
    #region Nested

    [Serializable()]
    public class DriverStatRecord<T> : IComparable<DriverStatRecord<T>>, IComparable<T> where T : IComparable
    {
      public Drivers.Driver Driver;
      public T Value;

      public DriverStatRecord() { }
      public DriverStatRecord(Drivers.Driver driver, T value)
      {
        this.Driver = driver;
        this.Value = value;
      }
      public DriverStatRecord(T value) : this(null, value) { }

      public int CompareTo(DriverStatRecord<T> other)
      {
        return this.Value.CompareTo(other.Value);
      }

      public int CompareTo(T other)
      {
        return this.Value.CompareTo(other);
      }

      public override string ToString()
      {
        if (Driver == null)
          return " -- fail";
        else
          return Value.ToString() + " <-- #" + Driver.CarNumber + " - " + Driver.Name;
      }
    }

    #endregion Nested

    #region BasicRaceStats

    [Serializable()]
    public class BasicRaceStatsStats
    {
      [StatsObject(true)]
      public int NumberOfLaps;
      [StatsObject(true)]
      public TimeSpan TotalRaceTime;
      [StatsObject(true)]
      public Drivers.Driver QualifyWinner;
      [StatsObject(true)]
      public Drivers.Driver RaceWinner;
      [StatsObject(true)]
      public DriverStatRecord<double> FastestLap;
    }
    [StatsObject(true)]
    public BasicRaceStatsStats BasicRaceStats = new BasicRaceStatsStats();

    private void CalculateBasicRaceStats ()
    {
      var x = this.BasicRaceStats;
      x.NumberOfLaps = r.Standings[0].Laps.Count;
      x.TotalRaceTime = ConvertDoubleToTimeSpan(r.Standings[0].Laps[r.Standings[0].Laps.Count - 1].SimulationTime);
      if (w.Qualify.Standings.Count > 0)
        x.QualifyWinner = w.Qualify.Standings[0].Driver;
      x.RaceWinner = r.Standings[0].Driver;
      x.FastestLap = GetFastestLapDriver();
    }

    private DriverStatRecord<double> GetFastestLapDriver()
    {
      DriverStatRecord<double> ret = new DriverStatRecord<double>(null, double.MaxValue);
      foreach (Standings.RaceStanding item in r.Standings)
      {
        if (item.OrderedLaps.Count > 0 && ret.CompareTo(item.OrderedLaps[0].LapTime) > 0)
          ret = new DriverStatRecord<double>(item.Driver, item.OrderedLaps[0].LapTime);
      }
      return ret;
    }

    private TimeSpan ConvertDoubleToTimeSpan(double time)
    {
      int value = (int)time;
      int hours = 0;
      int minutes = 0;
      int seconds = 0;
      int miliseconds = 0;

      miliseconds = (int)((time - value) * 1000);
      hours = value / 3600;
      value = value % 3600;
      minutes = value / 60;
      value = value % 60;
      seconds = value;

      return
        new TimeSpan(0, hours, minutes, seconds, miliseconds);
    }

    #endregion BasicRaceStats

    #region CautionStats

    [Serializable()]
    public class CautionsStats
    {
      [StatsObject(true)]
      public int NumberOfCautions;
      [StatsObject(true)]
      public int ShortestCautionBlock;
      [StatsObject(true)]
      public int LongestCautionBlock;
      [StatsObject(true)]
      public int LongestGreenBlock;
      [StatsObject(true)]
      public DriverStatRecord<int> MinimumPitCountOfFinishedDriver;
      [StatsObject(true)]
      public DriverStatRecord<int> MaximumPitCountOfFinishedDriver;
      [StatsObject(true)]
      public DriverStatRecord<int> MinimumPitCountOfAnyDriver;
      [StatsObject(true)]
      public DriverStatRecord<int> MaximumPitCountOfAnyDriver;
    }
    [StatsObject(true)]
    public CautionsStats Cautions = new CautionsStats();

    private void CalculateCautions()
    {
      this.Cautions.NumberOfCautions = r.YellowPhases.Length;

      int shortest = int.MaxValue;
      int longest = int.MinValue;
      int green = int.MinValue;
      int lastEnd = 0;
      int diff;

      foreach (var fItem in r.YellowPhases)
      {
        diff = fItem.Item2 - fItem.Item1;
        shortest = Math.Min(shortest, diff);
        longest = Math.Max(longest, diff);
        diff = fItem.Item1 - lastEnd;
        green = Math.Max(green, diff);
        lastEnd = fItem.Item2;
      } // foreach (var fItem in r.YellowPhases)

      diff = r.TotalLapCount - r.YellowPhases[r.YellowPhases.Length - 1].Item2;
      green = Math.Max(green, diff);

      this.Cautions.LongestCautionBlock = longest;
      this.Cautions.ShortestCautionBlock = shortest;
      this.Cautions.LongestGreenBlock = green;

      DriverStatRecord<int> maxF = new DriverStatRecord<int>(null, 0);
      DriverStatRecord<int> minF = new DriverStatRecord<int>(null, 0);
      DriverStatRecord<int> maxA = new DriverStatRecord<int>(null, 0);
      DriverStatRecord<int> minA = new DriverStatRecord<int>(null, 0);
      EvaluateMaximumMinimumCountOfDriver(out minF, out maxF, out minA, out maxA);
      this.Cautions.MinimumPitCountOfFinishedDriver = minF;
      this.Cautions.MaximumPitCountOfFinishedDriver = maxF;
      this.Cautions.MinimumPitCountOfAnyDriver = minA;
      this.Cautions.MaximumPitCountOfAnyDriver = maxA;
    }

    #endregion CautionStats

    #region DriverStatsStats

    [Serializable()]
    public class DriverStatsStats
    {
      [StatsObject]
      public DriverStatRecord<int> BiggestGainPerRace;
      [StatsObject]
      public DriverStatRecord<int> BiggestGainPerLap;
      [StatsObject]
      public DriverStatRecord<int> BiggestLoosePerRace;
      [StatsObject]
      public DriverStatRecord<int> BiggestLoosePerLap;

      [StatsObject]
      public DriverStatRecord<double> FastestPit;
      [StatsObject]
      public DriverStatRecord<double> SlowestPit;
    }
    [StatsObject]
    public DriverStatsStats DriverStats = new DriverStatsStats();

    private void CalculateDriverStats()
    {
      CalculateDriverStatsPerLap();
      CalculateDriverStatsPerRace();
      CalculateDriverStatsPits();
    }

    private void CalculateDriverStatsPits()
    {
      var x = this.DriverStats;

      x.FastestPit = new DriverStatRecord<double>(double.MaxValue);
      x.SlowestPit = new DriverStatRecord<double>(double.MinValue);

      foreach (var fItem in r.Standings)
      {
        Standings.RaceStanding rs = fItem as Standings.RaceStanding;
        if (rs.PitInfo.BestPitTime.HasValue)
        {
          double pitTime = rs.PitInfo.BestPitTime.Value;
          if (x.FastestPit.CompareTo(pitTime) > 0)
            x.FastestPit = new DriverStatRecord<double>(fItem.Driver, pitTime);
        }
        if (rs.PitInfo.WorstPitTime.HasValue)
        {
          double pitTime = rs.PitInfo.WorstPitTime.Value;
          if (x.SlowestPit.CompareTo(pitTime) < 0)
            x.SlowestPit = new DriverStatRecord<double>(fItem.Driver, pitTime);
        }
      } // foreach (var fItem in r.Standings)
    }

    private void CalculateDriverStatsPerRace()
    {
      var x = this.DriverStats;

      x.BiggestGainPerRace = new DriverStatRecord<int>(int.MinValue);
      x.BiggestLoosePerRace = new DriverStatRecord<int>(int.MaxValue);

      foreach (var fItem in r.Standings)
      {
        Standings.RaceStanding rs = fItem as Standings.RaceStanding;
        if (rs.Position.HasValue && rs.StartingPosition.HasValue)
        {
          int diff = rs.Position.Value - rs.StartingPosition.Value;
          if (x.BiggestGainPerRace.CompareTo(diff) < 0)
            x.BiggestGainPerRace = new DriverStatRecord<int>(fItem.Driver, diff);
          if (x.BiggestLoosePerRace.CompareTo(diff) > 0)
            x.BiggestLoosePerRace = new DriverStatRecord<int>(fItem.Driver, diff);
        }
      }
    }

    private void CalculateDriverStatsPerLap()
    {
      var x = this.DriverStats;
      x.BiggestGainPerLap = new DriverStatRecord<int>(int.MinValue);
      x.BiggestLoosePerLap = new DriverStatRecord<int>(int.MaxValue);

      Dictionary<int, int> dct = new Dictionary<int, int>();
      foreach (var fItem in w.Drivers) dct.Add(fItem.CarIdx, 0);

      var lap = r.DetailedStandings.GetLap(0);
      foreach (var fItem in lap) dct[fItem.CarIdx] = fItem.Position;

      for (int i = 1; i <= r.TotalLapCount; i++)
      {
        lap = r.DetailedStandings.GetLap(i);
        foreach (var fItem in lap)
        {
          int lastPos = dct[fItem.CarIdx]; // minule kolo aktualniho jezdce
          int diff = fItem.Position - lastPos; // difference za kolo
          if (x.BiggestGainPerLap.CompareTo(diff) < 0)
            x.BiggestGainPerLap = new DriverStatRecord<int>(w.Drivers.TryGetByIdx(fItem.CarIdx), diff);
          if (x.BiggestLoosePerLap.CompareTo(diff) > 0)
            x.BiggestLoosePerLap = new DriverStatRecord<int>(w.Drivers.TryGetByIdx(fItem.CarIdx), diff);
        } // foreach (var fItem in lap)
      }
    }

    #endregion DriverStatsStats

    #region OtherStatsStats

    [Serializable()]
    public class OtherStatsStats
    {
      [StatsObject]
      public int RetiredDrivers;
      [StatsObject]
      public int RunningDrivers;
      [StatsObject]
      public int AccidentDrivers;
      [StatsObject]
      public int TechnicalOutDrivers;
      [StatsObject]
      public int DriversInLeadLap;
      [StatsObject]
      public int LeadChanges;
      [StatsObject]
      public int DriversInLead;
    }
    [StatsObject]
    public OtherStatsStats OtherStats = new OtherStatsStats();

    private void CalculateOtherRaceStats()
    {
      var x = this.OtherStats;
      x.RetiredDrivers = r.Standings.Where(
        i => (i as Standings.RaceStanding).Status == Standings.RaceStanding.eStatus.Retired).Count();
      x.AccidentDrivers = r.Standings.Where(
        i => (i as Standings.RaceStanding).Status == Standings.RaceStanding.eStatus.Accident).Count();
      x.DriversInLeadLap = r.Standings.Where(
        i => (i as Standings.RaceStanding).Laps.Count == r.TotalLapCount).Count();
      x.TechnicalOutDrivers = r.Standings.Where(
        i => (i as Standings.RaceStanding).Status == Standings.RaceStanding.eStatus.TechnicalFailure).Count();
      x.RunningDrivers = r.Standings.Where(
        i => (i as Standings.RaceStanding).Status == Standings.RaceStanding.eStatus.Running).Count();

      var lapLeaders = GetDriversInLead();
      var lapLeadersBlocks = RemoveForBlocks(lapLeaders);
      var lapLeadersDistinct = RemoveDistinct(lapLeadersBlocks);
      x.LeadChanges = lapLeadersBlocks.Count;
      x.DriversInLead = lapLeadersDistinct.Count;
    }

    #endregion OtherStatsStats

    #region Fields & properties

    private Weekend w;
    private RaceSession r { get { return w.Race; } }

    #endregion Fields & properties

    #region .ctor

    private RaceStatistics(Weekend w)
    {
      this.w = w;
    }

    public static RaceStatistics Create(Weekend w)
    {
      RaceStatistics ret = new RaceStatistics(w);

      ret.CalculateBasicRaceStats();
      ret.CalculateCautions();
      ret.CalculateDriverStats();
      ret.CalculateOtherRaceStats();

      return ret;
    }

    #endregion .ctor

    #region GetReport() methods

    public string GetReport()
    {
      StringBuilder sb = new StringBuilder();

      ReportStatObject(sb, 0, "*** Stats report for " + w.Track, this);

      return sb.ToString();
    }

    private void ReportStatObject(StringBuilder sb, int level, string name, object statObject)
    {
      //var props = GetPropertiesWhichStatistics(statObject);
      var fields = GetFieldsWhichStatistics(statObject);

      if (fields.Length == 0)
      {      
        ReportSimpleObject(sb, level, name, statObject);
      }
      else
      {
        sb.AppendLine("".PadLeft(level) + name);
        foreach (var fItem in fields)
        {
          object value = fItem.GetValue(statObject);
          string displayName = GetTitleForMember(fItem);
          ReportStatObject(sb, level + 1, displayName, value);
        } // foreach (var fItem in fields)
      }
    }

    private void ReportSimpleObject(StringBuilder sb, int level, string name, object statObject)
    {
      sb.AppendLine("".PadLeft(level) + name + ": " + statObject.ToString());
    }

    private string GetTitleForMember(MemberInfo member)
    {
      StatsObjectAttribute soa = member.GetCustomAttributes(typeof(StatsObjectAttribute),false)[0] as StatsObjectAttribute;

      if (string.IsNullOrEmpty(soa.Title) == false)
        return soa.Title;
      else
        if (soa.ExpandMemberNameToTitle)
          return StatsObjectAttribute.ExpandMemberName(member.Name);
        else
          return member.Name;
    }

    private FieldInfo[] GetFieldsWhichStatistics(object statObject)
    {
      Type t = statObject.GetType();
      var members = t.GetFields(
        System.Reflection.BindingFlags.GetField
        | System.Reflection.BindingFlags.Instance
        | System.Reflection.BindingFlags.Public);

      var ret = members.Where(i => i.GetCustomAttributes(typeof(StatsObjectAttribute), false).Count() > 0);

      return ret.ToArray();
    }

    private PropertyInfo[] GetPropertiesWhichStatistics(object statObject)
    {
      Type t = statObject.GetType();
      var members = t.GetProperties(
        System.Reflection.BindingFlags.GetProperty
        | System.Reflection.BindingFlags.Instance
        | System.Reflection.BindingFlags.Public);

      var ret = members.Where(i => i.GetCustomAttributes(typeof(StatsObjectAttribute), false).Count() > 0);

      return ret.ToArray();
    }

    #endregion GetReport() methods

    #region Private methods

    private List<int> RemoveDistinct(List<int> lapLeadersBlocks)
    {
      List<int> ret = new List<int>();
      ret = lapLeadersBlocks.Distinct().ToList();
      return ret;
    }

    private List<int> RemoveForBlocks(List<int> lapLeaders)
    {
      List<int> ret = new List<int>();
      int last = -1;
      foreach (var fItem in lapLeaders)
      {
        if (last == fItem)
          continue;

        last = fItem;
        ret.Add(fItem);
      } // foreach (var fItem in lapLeaders)
      return ret;
    }

    private List<int>  GetDriversInLead()
    {
      List<int> ret = new List<int>();
      for (int i = 0; i < r.TotalLapCount; i++)
        ret.Add(r.DetailedStandings.GetLap(i)[0].CarIdx);
      return ret;
    }

    private void EvaluateMaximumMinimumCountOfDriver(
      out DriverStatRecord<int> minF, out DriverStatRecord<int> maxF,
      out DriverStatRecord<int> minA, out DriverStatRecord<int> maxA)
    {
      minF = new DriverStatRecord<int>(int.MaxValue);
      maxF = new DriverStatRecord<int>(int.MinValue);
      minA = new DriverStatRecord<int>(int.MaxValue);
      maxA = new DriverStatRecord<int>(int.MinValue);
      int val;

      foreach (Standings.RaceStanding item in this.w.Race.Standings)
      {
        val = item.PitInfo.PitCount;
        if (item.Status == Standings.RaceStanding.eStatus.Running)
        {
        if (minF.CompareTo(val) > 0)
          minF = new DriverStatRecord<int>(item.Driver, val);
        if (maxF.CompareTo(val) < 0)
          maxF = new DriverStatRecord<int>(item.Driver, val);
        }
        if (minA.CompareTo(val) > 0)
          minA = new DriverStatRecord<int>(item.Driver, val);
        if (maxA.CompareTo(val) < 0)
          maxA = new DriverStatRecord<int>(item.Driver, val);
      }
    }

    #endregion Private methods - Calculate_xxx
  }
}
