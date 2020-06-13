using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.StaticRaceWeekend.Common;
using ENG.NR2003.StaticRaceWeekend.LapRecords;
using System.Diagnostics.Contracts;

namespace ENG.NR2003.StaticRaceWeekend.Standings
{
  /// <summary>
  /// Represents standing in session. Abstract.
  /// </summary>
  [Serializable()]
  public abstract class Standing : IComparable<Standing>
  {
    internal abstract bool CanHavePosition { get; }

    public static LapRecord GetLapRecordOrEmpty (LapRecordCollection laps, int index)
    {
      if (index < 0)
        return LapRecord.GetEmpty();
      if (laps.Count > index)
        return laps[index];
      else
        return LapRecord.GetEmpty();
    }

    #region Properties

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private Drivers.Driver _Driver = null;
    ///<summary>
    /// Sets/gets Driver value. Default value is null.
    ///</summary>
    public Drivers.Driver Driver
    {
      get
      {
        return (_Driver);
      }
      internal set
      {
        Contract.Requires(value != null);

        _Driver = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private LapRecordCollection _Laps = new LapRecordCollection();
    ///<summary>
    /// Sets/gets Laps value. Default value is new LapRecordCollection().
    ///</summary>
    public LapRecordCollection Laps
    {
      get
      {
        return (_Laps);
      }
      internal set
      {
        _Laps = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private LapRecordCollection _OrderedLaps = new LapRecordCollection();
    ///<summary>
    /// Sets/gets OrderedLaps value. Default value is new LapRecordCollection();.
    ///</summary>
    public LapRecordCollection OrderedLaps
    {
      get
      {
        return (_OrderedLaps);
      }
      internal set
      {
        _OrderedLaps = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private int _Incidents = 0;
    ///<summary>
    /// Sets/gets Incidents value. Default value is 0.
    ///</summary>
    public int Incidents
    {
      get
      {
        return (_Incidents);
      }
      internal set
      {
        Contract.Requires(value > -1);

        _Incidents = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private int? _Position = null;
    ///<summary>
    /// Sets/gets Position value. Default value is null.
    ///</summary>
    public int? Position
    {
      get
      {
        return (_Position);
      }
      internal set
      {
        _Position = value;
      }
    }    

    #region BestPosition
    /// <summary>
    /// Defines delegate for property change - <seealso cref="BestPosition"/>
    /// </summary>
    /// <param name="sender">Object raising event.</param>
    /// <param name="oldValue">Old value of the property..</param>
    /// <param name="newValue">New value of the property. Can be changed.</param>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    public delegate void BestPositionChangingHandler(object sender, int? oldValue, ref int? newValue);
    /// <summary>
    /// Event raised before the value of the property is changed.
    /// </summary>
    public event BestPositionChangingHandler BestPositionChanging;
    /// <summary>
    /// Event raised after the value of the property is changed.
    /// </summary>
    public event EventHandler BestPositionChanged;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private int? _BestPosition;
    ///<summary>
    /// Sets/gets BestPosition value.
    ///</summary>
    public int? BestPosition
    {
      get
      {
        return (_BestPosition);
      }
      internal set
      {
        int? newValue = value;
        if (BestPositionChanging != null)
          BestPositionChanging(this, _BestPosition, ref newValue);

        _BestPosition = newValue;

        if (BestPositionChanged != null)
          BestPositionChanged(this, new EventArgs());

      }
    }
    #endregion BestPosition

    #region WorstPosition
    /// <summary>
    /// Defines delegate for property change - <seealso cref="WorstPosition"/>
    /// </summary>
    /// <param name="sender">Object raising event.</param>
    /// <param name="oldValue">Old value of the property..</param>
    /// <param name="newValue">New value of the property. Can be changed.</param>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    public delegate void WorstPositionChangingHandler(object sender, int? oldValue, ref int? newValue);
    /// <summary>
    /// Event raised before the value of the property is changed.
    /// </summary>
    public event WorstPositionChangingHandler WorstPositionChanging;
    /// <summary>
    /// Event raised after the value of the property is changed.
    /// </summary>
    public event EventHandler WorstPositionChanged;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private int? _WorstPosition;
    ///<summary>
    /// Sets/gets WorstPosition value.
    ///</summary>
    public int? WorstPosition
    {
      get
      {
        return (_WorstPosition);
      }
      internal set
      {
        int? newValue = value;
        if (WorstPositionChanging != null)
          WorstPositionChanging(this, _WorstPosition, ref newValue);

        _WorstPosition = newValue;

        if (WorstPositionChanged != null)
          WorstPositionChanged(this, new EventArgs());
      }
    }
    #endregion WorstPosition

    #region FirstTime
    /// <summary>
    /// Defines delegate for property change - <seealso cref="FirstTime"/>
    /// </summary>
    /// <param name="sender">Object raising event.</param>
    /// <param name="oldValue">Old value of the property..</param>
    /// <param name="newValue">New value of the property. Can be changed.</param>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    public delegate void FirstTimeChangingHandler(object sender, LapRecord oldValue, ref LapRecord newValue);
    /// <summary>
    /// Event raised before the value of the property is changed.
    /// </summary>
    public event FirstTimeChangingHandler FirstTimeChanging;
    /// <summary>
    /// Event raised after the value of the property is changed.
    /// </summary>
    public event EventHandler FirstTimeChanged;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private LapRecord _FirstTime;
    ///<summary>
    /// Sets/gets FirstTime value.
    ///</summary>
    public LapRecord FirstTime
    {
      get
      {
        return (_FirstTime);
      }
      private set
      {
        if (value == _FirstTime) return;

        LapRecord newValue = value;
        if (FirstTimeChanging != null)
          FirstTimeChanging(this, _FirstTime, ref newValue);

        _FirstTime = newValue;

        if (FirstTimeChanged != null)
          FirstTimeChanged(this, new EventArgs());

      }
    }
    #endregion FirstTime

    #region SecondTime
    /// <summary>
    /// Defines delegate for property change - <seealso cref="SecondTime"/>
    /// </summary>
    /// <param name="sender">Object raising event.</param>
    /// <param name="oldValue">Old value of the property..</param>
    /// <param name="newValue">New value of the property. Can be changed.</param>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    public delegate void SecondTimeChangingHandler(object sender, LapRecord oldValue, ref LapRecord newValue);
    /// <summary>
    /// Event raised before the value of the property is changed.
    /// </summary>
    public event SecondTimeChangingHandler SecondTimeChanging;
    /// <summary>
    /// Event raised after the value of the property is changed.
    /// </summary>
    public event EventHandler SecondTimeChanged;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private LapRecord _SecondTime;
    ///<summary>
    /// Sets/gets SecondTime value.
    ///</summary>
    public LapRecord SecondTime
    {
      get
      {
        return (_SecondTime);
      }
      private set
      {
        if (value == _SecondTime) return;

        LapRecord newValue = value;
        if (SecondTimeChanging != null)
          SecondTimeChanging(this, _SecondTime, ref newValue);

        _SecondTime = newValue;

        if (SecondTimeChanged != null)
          SecondTimeChanged(this, new EventArgs());

      }
    }
    #endregion SecondTime

    #region ThirdTime
    /// <summary>
    /// Defines delegate for property change - <seealso cref="ThirdTime"/>
    /// </summary>
    /// <param name="sender">Object raising event.</param>
    /// <param name="oldValue">Old value of the property..</param>
    /// <param name="newValue">New value of the property. Can be changed.</param>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    public delegate void ThirdTimeChangingHandler(object sender, LapRecord oldValue, ref LapRecord newValue);
    /// <summary>
    /// Event raised before the value of the property is changed.
    /// </summary>
    public event ThirdTimeChangingHandler ThirdTimeChanging;
    /// <summary>
    /// Event raised after the value of the property is changed.
    /// </summary>
    public event EventHandler ThirdTimeChanged;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private LapRecord _ThirdTime;
    ///<summary>
    /// Sets/gets ThirdTime value.
    ///</summary>
    public LapRecord ThirdTime
    {
      get
      {
        return (_ThirdTime);
      }
      private set
      {
        if (value == _ThirdTime) return;

        LapRecord newValue = value;
        if (ThirdTimeChanging != null)
          ThirdTimeChanging(this, _ThirdTime, ref newValue);

        _ThirdTime = newValue;

        if (ThirdTimeChanged != null)
          ThirdTimeChanged(this, new EventArgs());

      }
    }
    #endregion ThirdTime

    #region WorstTime
    /// <summary>
    /// Defines delegate for property change - <seealso cref="WorstTime"/>
    /// </summary>
    /// <param name="sender">Object raising event.</param>
    /// <param name="oldValue">Old value of the property..</param>
    /// <param name="newValue">New value of the property. Can be changed.</param>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    public delegate void WorstTimeChangingHandler(object sender, LapRecord oldValue, ref LapRecord newValue);
    /// <summary>
    /// Event raised before the value of the property is changed.
    /// </summary>
    public event WorstTimeChangingHandler WorstTimeChanging;
    /// <summary>
    /// Event raised after the value of the property is changed.
    /// </summary>
    public event EventHandler WorstTimeChanged;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private LapRecord _WorstTime;
    ///<summary>
    /// Sets/gets WorstTime value.
    ///</summary>
    public LapRecord WorstTime
    {
      get
      {
        return (_WorstTime);
      }
      protected set
      {
        if (value == _WorstTime) return;

        LapRecord newValue = value;
        if (WorstTimeChanging != null)
          WorstTimeChanging(this, _WorstTime, ref newValue);

        _WorstTime = newValue;

        if (WorstTimeChanged != null)
          WorstTimeChanged(this, new EventArgs());

      }
    }
    #endregion WorstTime

    #region LastTime
    /// <summary>
    /// Defines delegate for property change - <seealso cref="LastTime"/>
    /// </summary>
    /// <param name="sender">Object raising event.</param>
    /// <param name="oldValue">Old value of the property..</param>
    /// <param name="newValue">New value of the property. Can be changed.</param>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    public delegate void LastTimeChangingHandler(object sender, LapRecord oldValue, ref LapRecord newValue);
    /// <summary>
    /// Event raised before the value of the property is changed.
    /// </summary>
    public event LastTimeChangingHandler LastTimeChanging;
    /// <summary>
    /// Event raised after the value of the property is changed.
    /// </summary>
    public event EventHandler LastTimeChanged;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private LapRecord _LastTime;
    ///<summary>
    /// Sets/gets LastTime value.
    ///</summary>
    public LapRecord LastTime
    {
      get
      {
        return (_LastTime);
      }
      set
      {
        if (value == _LastTime) return;

        LapRecord newValue = value;
        if (LastTimeChanging != null)
          LastTimeChanging(this, _LastTime, ref newValue);

        _LastTime = newValue;

        if (LastTimeChanged != null)
          LastTimeChanged(this, new EventArgs());

      }
    }
    #endregion LastTime

    #region MeanOfLapTimes
    /// <summary>
    /// Defines delegate for property change - <seealso cref="MeanOfLapTimes"/>
    /// </summary>
    /// <param name="sender">Object raising event.</param>
    /// <param name="oldValue">Old value of the property..</param>
    /// <param name="newValue">New value of the property. Can be changed.</param>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    public delegate void MeanOfLapTimesChangingHandler(object sender, double oldValue, ref double newValue);
    /// <summary>
    /// Event raised before the value of the property is changed.
    /// </summary>
    public event MeanOfLapTimesChangingHandler MeanOfLapTimesChanging;
    /// <summary>
    /// Event raised after the value of the property is changed.
    /// </summary>
    public event EventHandler MeanOfLapTimesChanged;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private double _MeanOfLapTimes;
    ///<summary>
    /// Sets/gets MeanOfLapTimes value.
    ///</summary>
    public double MeanOfLapTimes
    {
      get
      {
        return (_MeanOfLapTimes);
      }
      private set
      {
        double newValue = value;
        if (MeanOfLapTimesChanging != null)
          MeanOfLapTimesChanging(this, _MeanOfLapTimes, ref newValue);

        _MeanOfLapTimes = newValue;

        if (MeanOfLapTimesChanged != null)
          MeanOfLapTimesChanged(this, new EventArgs());

      }
    }
    #endregion MeanOfLapTimes

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private double? _LastLapCrossing = null;
    ///<summary>
    /// Sets/gets LastLapCrossing value. Default value is null.
    ///</summary>
    internal double? LastLapCrossing
    {
      get
      {
        return (_LastLapCrossing);
      }
      set
      {
        _LastLapCrossing = value;
      }
    }

    #endregion Properties

    #region .ctor
    public Standing()
    {
      this.Laps = new LapRecordCollection();
    }
    #endregion .ctor

    #region IComparable<NRStandingsEntry> Members

    public int CompareTo(Standing other)
    {
      if (this.Position.HasValue == false)
      {
        if (other.Position.HasValue == false)
          return this.Driver.CarNumber.CompareTo(other.Driver.CarNumber);
        else
          return 1;
      }
      else
      {
        if (other.Position.HasValue == false)
          return -1;
        else
          return this.Position.Value.CompareTo(other.Position.Value);
      }
    }

    #endregion

    public virtual void AddLap(LapRecord lr)
    {
      Laps.Add(lr);
      OrderedLaps.Add(lr);
      OrderedLaps.Sort();
      UpdateTimes();
      RecalculateMeanOfLapTimes();
    }

    private const double TRESHOLD_MULTIPLIER = 1.3;
    private void RecalculateMeanOfLapTimes()
    {
      double treshold;
      double timeSum= 0;
      int timeCount = 0;

      treshold = this.FirstTime.LapTime * TRESHOLD_MULTIPLIER;

      foreach (var fLap in OrderedLaps)
      {
        if (fLap.LapTime < treshold)
        {
          timeSum += fLap.LapTime;
          timeCount++;
        }
        else
          break;
      } // foreach (var fLap in Laps)

      if (timeCount > 0)
        this.MeanOfLapTimes = timeSum / timeCount;
    }

    protected virtual void UpdateTimes()
    {
      FirstTime = GetLapRecordOrEmpty(OrderedLaps, 0);
      SecondTime = GetLapRecordOrEmpty(OrderedLaps, 1);
      ThirdTime = GetLapRecordOrEmpty(OrderedLaps, 2);
      WorstTime = GetLapRecordOrEmpty(OrderedLaps, OrderedLaps.Count - 1);
      LastTime = GetLapRecordOrEmpty(Laps, Laps.Count - 1);
    }
  }
}
