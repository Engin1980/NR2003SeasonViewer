using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.StaticRaceWeekend.Common;
using System.Diagnostics.Contracts;
using ENG.NR2003.StaticRaceWeekend.LapRecords;
using ENG.NR2003.StaticRaceWeekend.Standings.Support;
using Common;

namespace ENG.NR2003.StaticRaceWeekend.Standings
{
  [Serializable()]
  public class RaceStanding : Standing
  {
    #region Nested
    public enum eStatus
    {
      [DisplayText("Ok", "short")]
      [DisplayText("Running")]
      Running,
      [DisplayText("Crash", "short")]
      [DisplayText("Accident")]
      Accident,
      [DisplayText("Crash", "short")]
      [DisplayText("Retired")]
      Retired,
      [DisplayText("DQ", "short")]
      [DisplayText("Disqualified")]
      DQ,
      [DisplayText("DNQ", "short")]
      [DisplayText("Didn't qualify")]
      DNQ,
      [DisplayText("DNS", "short")]
      [DisplayText("Didn't start")]
      DNS,
      [DisplayText("Tech", "short")]
      [DisplayText("Technical")]
      TechnicalFailure,
      [DisplayText("Fail", "short")]
      [DisplayText("Other fail")]
      OtherReason
    }
    #endregion Nested

    #region Comparers

    public class ByCalculatedPositionComparer : IComparer<Standing>
    {

      #region IComparer<Standing> Members

      public int Compare(Standing x, Standing y)
      {
        Contract.Assert(x is RaceStanding);
        Contract.Assert(y is RaceStanding);

        int ret = y.Laps.Count.CompareTo(x.Laps.Count);
        if (ret == 0)
          ret = x.LastLapCrossing.CompareTo(y.LastLapCrossing,
            new ENG.NR2003.StaticRaceWeekend.Common.NullableDoubleComparer());

        return ret;
      }

      #endregion
    }
    #endregion Comparers

    private static List<int> CurrentLapPos = new List<int>();

    #region Properties


    public double TimeBehindLeader;
    public int LapsBehindLeader;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private Support.PitData _PitInfo = new Support.PitData();
    ///<summary>
    /// Sets/gets PitInfo value. Default value is new Support.PitData();.
    ///</summary>
    public Support.PitData PitInfo
    {
      get
      {
        return (_PitInfo);
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private eStatus _Status =  eStatus.Running;
    ///<summary>
    /// Sets/gets Status value. Default value is  eStatus.Running.
    ///</summary>
    public eStatus Status
    {
      get
      {
        return (_Status);
      }
      internal set
      {
        _Status = value;
      }
    }

    #region LastLap
    /// <summary>
    /// Defines delegate for property change - <seealso cref="LastLap"/>
    /// </summary>
    /// <param name="sender">Object raising event.</param>
    /// <param name="oldValue">Old value of the property..</param>
    /// <param name="newValue">New value of the property. Can be changed.</param>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    public delegate void LastLapChangingHandler(object sender, LapRecord oldValue, ref LapRecord newValue);
    /// <summary>
    /// Event raised before the value of the property is changed.
    /// </summary>
    public event LastLapChangingHandler LastLapChanging;
    /// <summary>
    /// Event raised after the value of the property is changed.
    /// </summary>
    public event EventHandler LastLapChanged;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private LapRecord _LastLap;
    ///<summary>
    /// Sets/gets LastLap value.
    ///</summary>
    public LapRecord LastLap
    {
      get
      {
        return (_LastLap);
      }
      private set
      {
        LapRecord newValue = value;
        if (LastLapChanging != null)
          LastLapChanging(this, _LastLap, ref newValue);

        _LastLap = newValue;

        if (LastLapChanged != null)
          LastLapChanged(this, new EventArgs());

      }
    }
    #endregion LastLap

    #region WorstTime2
    /// <summary>
    /// Defines delegate for property change - <seealso cref="WorstTime2"/>
    /// </summary>
    /// <param name="sender">Object raising event.</param>
    /// <param name="oldValue">Old value of the property..</param>
    /// <param name="newValue">New value of the property. Can be changed.</param>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    public delegate void WorstTime2ChangingHandler(object sender, LapRecord oldValue, ref LapRecord newValue);
    /// <summary>
    /// Event raised before the value of the property is changed.
    /// </summary>
    public event WorstTime2ChangingHandler WorstTime2Changing;
    /// <summary>
    /// Event raised after the value of the property is changed.
    /// </summary>
    public event EventHandler WorstTime2Changed;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private LapRecord _WorstTime2;
    ///<summary>
    /// Sets/gets WorstTime2 value.
    ///</summary>
    public LapRecord WorstTime2
    {
      get
      {
        return (_WorstTime2);
      }
      private set
      {
        LapRecord newValue = value;
        if (WorstTime2Changing != null)
          WorstTime2Changing(this, _WorstTime2, ref newValue);

        _WorstTime2 = newValue;

        if (WorstTime2Changed != null)
          WorstTime2Changed(this, new EventArgs());

      }
    }
    #endregion WorstTime2

    #region WorstTime3
    /// <summary>
    /// Defines delegate for property change - <seealso cref="WorstTime3"/>
    /// </summary>
    /// <param name="sender">Object raising event.</param>
    /// <param name="oldValue">Old value of the property..</param>
    /// <param name="newValue">New value of the property. Can be changed.</param>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    public delegate void WorstTime3ChangingHandler(object sender, LapRecord oldValue, ref LapRecord newValue);
    /// <summary>
    /// Event raised before the value of the property is changed.
    /// </summary>
    public event WorstTime3ChangingHandler WorstTime3Changing;
    /// <summary>
    /// Event raised after the value of the property is changed.
    /// </summary>
    public event EventHandler WorstTime3Changed;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private LapRecord _WorstTime3;
    ///<summary>
    /// Sets/gets WorstTime3 value.
    ///</summary>
    public LapRecord WorstTime3
    {
      get
      {
        return (_WorstTime3);
      }
      private set
      {
        LapRecord newValue = value;
        if (WorstTime3Changing != null)
          WorstTime3Changing(this, _WorstTime3, ref newValue);

        _WorstTime3 = newValue;

        if (WorstTime3Changed != null)
          WorstTime3Changed(this, new EventArgs());

      }
    }
    #endregion WorstTime3

    #region StartingPosition
    /// <summary>
    /// Defines delegate for property change - <seealso cref="StartingPosition"/>
    /// </summary>
    /// <param name="sender">Object raising event.</param>
    /// <param name="oldValue">Old value of the property..</param>
    /// <param name="newValue">New value of the property. Can be changed.</param>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    public delegate void StartingPositionChangingHandler(object sender, int? oldValue, ref int? newValue);
    /// <summary>
    /// Event raised before the value of the property is changed.
    /// </summary>
    public event StartingPositionChangingHandler StartingPositionChanging;
    /// <summary>
    /// Event raised after the value of the property is changed.
    /// </summary>
    public event EventHandler StartingPositionChanged;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private int? _StartingPosition;
    ///<summary>
    /// Sets/gets StartingPosition value.
    ///</summary>
    public int? StartingPosition
    {
      get
      {
        return (_StartingPosition);
      }
      internal set
      {
        int? newValue = value;
        if (StartingPositionChanging != null)
          StartingPositionChanging(this, _StartingPosition, ref newValue);

        _StartingPosition = newValue;

        if (StartingPositionChanged != null)
          StartingPositionChanged(this, new EventArgs());

      }
    }
    #endregion StartingPosition

    #region PlusMinusStatistic
    ///<summary>
    /// Sets/gets PlusMinusStatistic value.
    ///</summary>
    public int? PlusMinusStatistic
    {
      get
      {
        if (this.Position.HasValue && this.StartingPosition.HasValue)
          return (this.StartingPosition.Value - this.Position.Value);
        else
          return null;
      }
    }
    #endregion PlusMinusStatistic

    ///<summary>
    /// Sets/gets MeanPitTime value. Default value is null.
    ///</summary>
    public double? MeanPitTimeCutted
    {
      get
      {
        if (PitInfo.PitCount == 0) return null;

        double maxTreshold = PitInfo.PitMeanTime.Mean.Value * 1.2;
        double sum = 0;
        double count = 0;


        for (int i = 0; i < PitInfo.PitTimes.Count; i++)
        {
          sum += PitInfo.PitTimes[i];
          count++;
        }

        double ret = sum / count;

        return ret;
      }



    }

    // --- following properties have to be filled from outside
    #region GapToFirst
    /// <summary>
    /// Defines delegate for property change - <seealso cref="GapToFirst"/>
    /// </summary>
    /// <param name="sender">Object raising event.</param>
    /// <param name="oldValue">Old value of the property..</param>
    /// <param name="newValue">New value of the property. Can be changed.</param>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    public delegate void GapToFirstChangingHandler(object sender, Gap oldValue, ref Gap newValue);
    /// <summary>
    /// Event raised before the value of the property is changed.
    /// </summary>
    public event GapToFirstChangingHandler GapToFirstChanging;
    /// <summary>
    /// Event raised after the value of the property is changed.
    /// </summary>
    public event EventHandler GapToFirstChanged;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private Gap _GapToFirst;
    ///<summary>
    /// Sets/gets GapToFirst value.
    ///</summary>
    public Gap GapToFirst
    {
      get
      {
        return (_GapToFirst);
      }
      internal set
      {
        Gap newValue = value;
        if (GapToFirstChanging != null)
          GapToFirstChanging(this, _GapToFirst, ref newValue);

        _GapToFirst = newValue;

        if (GapToFirstChanged != null)
          GapToFirstChanged(this, new EventArgs());

      }
    }
    #endregion GapToFirst

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private Gap _GapToPrevious;
    ///<summary>
    /// Sets/gets GapToPrevious value. Default value is null.
    ///</summary>
    public Gap GapToPrevious
    {
      get
      {
        return (_GapToPrevious);
      }
      internal set
      {
        _GapToPrevious = value;
      }
    }

    public int LapInLeadCount { get; internal set; }

    public bool HasTheMostLapsInLead { get; internal set; }

    #endregion Properties

    internal override bool CanHavePosition
    {
      get { return true; }
    }

    public override void AddLap(LapRecord lr)
    {
      base.AddLap(lr);

      if (Laps.Count > 1 && Laps[Laps.Count - 2].IsPitted)
        EvaluatePit();
    }

    protected override void UpdateTimes()
    {
      base.UpdateTimes();

      if (Laps.Count > 0)
        LastLap = Laps[Laps.Count - 1];

      WorstTime = GetLapFromEndWithoutPit(0);
      WorstTime2 = GetLapFromEndWithoutPit(1);
      WorstTime3 = GetLapFromEndWithoutPit(2);
    }

    private LapRecord GetLapFromEndWithoutPit(int indexFromBackward)
    {
      int lapIndex = base.Laps.Count - PitInfo.PitCount * (indexFromBackward + 1) - 1;
      if (lapIndex < 0)
        return LapRecord.GetEmpty();
      if (lapIndex >= base.Laps.Count)
        return LapRecord.GetEmpty();
      return OrderedLaps[lapIndex];
    }

    private void EvaluatePit()
    {
      double befLap = double.MaxValue;
      double pitLap = double.MaxValue;
      double aftLap = double.MaxValue;

      if (this.Laps.Count > 3) befLap = this.Laps[this.Laps.Count - 3].LapTime;
      if (this.Laps.Count > 2) pitLap = this.Laps[this.Laps.Count - 2].LapTime;
      if (this.Laps.Count > 1) aftLap = this.Laps[this.Laps.Count - 1].LapTime;

      if (befLap < aftLap)
        pitLap += aftLap;
      else
        pitLap += befLap;

      this.PitInfo.AddPit(pitLap, this.Laps.Count - 2);
    }

  }
}
