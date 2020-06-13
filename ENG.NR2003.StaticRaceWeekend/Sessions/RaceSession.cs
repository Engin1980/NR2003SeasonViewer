using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.StaticRaceWeekend.Sessions
{
  [Serializable()]
  public class RaceSession : Session
  {
    #region Yellow phases issues

    [Serializable()]
    public class YellowPhasesAnalyses
    {
      private List<Tuple<double, double>> yellowPhases = new List<Tuple<double, double>>();
      private const double INVALID = double.MinValue;
      private double lastYellowPhaseStart = INVALID;
      private double lastYellowPhaseTime = INVALID;

      internal void AddTime(double time, bool isYellow)
      {
        if (isYellow)
        {
          if (lastYellowPhaseStart == INVALID)
            lastYellowPhaseStart = time;
          lastYellowPhaseTime = time;
        }
        else
        {
          if (lastYellowPhaseStart != INVALID)
          {
            yellowPhases.Add(new Tuple<double, double>(lastYellowPhaseStart, lastYellowPhaseTime));
            lastYellowPhaseStart = INVALID;
          }
        }
      }
      internal Tuple<double, double>[] GetYellowPhaseTimes()
      {
        return yellowPhases.ToArray();
      }
    }
    internal YellowPhasesAnalyses YPA = new YellowPhasesAnalyses();

    internal void EvaluateYellowPhases()
    {
      var times = YPA.GetYellowPhaseTimes();
      List<Tuple<int, int>> laps = new List<Tuple<int, int>>();

      foreach (var fItem in times)
      {
        int startLap = GetLapNumberAtTimeCrossedAt(fItem.Item1);
        int endLap = GetLapNumberAtTimeCrossedAt(fItem.Item2);

        laps.Add(new Tuple<int, int>(startLap, endLap));
      } // foreach (var fItem in times)

      this.YellowPhases = laps.ToArray();
    }
    #endregion Yellow phases issues

    #region Properties

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private int _TotalLapCount = 0;
    ///<summary>
    /// Sets/gets TotalLapCount value. Default value is 0.
    ///</summary>
    public int TotalLapCount
    {
      get
      {
        return (_TotalLapCount);
      }
      set
      {
        _TotalLapCount = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private Standings.Support.DetailedRaceStandings _DetailedStandings = null;
    ///<summary>
    /// Sets/gets InRaceStandings value. Default value is new Standings.Support.InRaceStanding().
    ///</summary>
    public Standings.Support.DetailedRaceStandings DetailedStandings
    {
      get
      {
        return (_DetailedStandings);
      }
      internal set
      {
        _DetailedStandings = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private Tuple<int, int>[] _YellowPhases = null;
    ///<summary>
    /// Sets/gets YellowPhases value. Default value is null.
    ///</summary>
    public Tuple<int, int>[] YellowPhases
    {
      get
      {
        return (_YellowPhases);
      }
      private set
      {
        _YellowPhases = value;
      }
    }

    public bool IsYellowLap(int lapIndex)
    {
      foreach (var fItem in YellowPhases)
      {
        if (fItem.Item1 <= lapIndex && lapIndex <= fItem.Item2)
          return true;
      } // foreach (var fItem in YellowPhases)

      return false;
    }

    public int NumberOfYellowPhases
    {
      get
      {
        int ret = YellowPhases.Length;
        return ret;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private Support.RaceStatistics _Statistics = null;
    ///<summary>
    /// Sets/gets Statistics value. Default value is null.
    ///</summary>
    public Support.RaceStatistics Statistics
    {
      get
      {
        return (_Statistics);
      }
      internal set
      {
        _Statistics = value;
      }
    }

    #endregion Properties

    protected override Standings.Standing CreateStandingByDriver(Drivers.Driver d)
    {
      var ret =
        new NR2003.StaticRaceWeekend.Standings.RaceStanding();

      ret.Driver = d;

      return ret;
    }

    internal int GetLapNumberAtTimeCrossedAt(double time)
    {
      int ret = DetailedStandings.GetLapIndexByCrossedAt(time);
      return ret;
    }

    public override bool IsEmpty
    {
      get {
        return base.Standings.Count == 0 || base.Standings[0].Laps.Count == 0;
      }
    }
  }
}
