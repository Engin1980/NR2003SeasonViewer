using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.StaticRaceWeekend.Sessions
{
  [Serializable()]
  public abstract class Session
  {
    #region Nested
    public enum eSessionState
    {
      SessionStateInvalid,
      SessionStateGetInCar,
      SessionStateWarmup,
      SessionStateParadeLaps,
      SessionStateRacing,
      SessionStateCheckered,
      SessionStateCoolDown
    }
    #endregion Nested

    #region Properties


    public abstract bool IsEmpty { get; }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private int _SessionNum = int.MinValue;
    ///<summary>
    /// Sets/gets SessionNum value. Default value is int.MinValue.
    ///</summary>
    public int SessionNum
    {
      get
      {
        return (_SessionNum);
      }
      internal set
      {
        _SessionNum = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private Lengths.Length _Length = null;
    ///<summary>
    /// Sets/gets Length value. Default value is null.
    ///</summary>
    public Lengths.Length Length
    {
      get
      {
        return (_Length);
      }
      internal set
      {
        _Length = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private Standings.StandingCollection _Standings = new Standings.StandingCollection();
    ///<summary>
    /// Sets/gets Standings value. Default value is new Standings.StandingCollection().
    ///</summary>
    public Standings.StandingCollection Standings
    {
      get
      {
        return (_Standings);
      }
      private set
      {
        _Standings = value;
      }
    }


    #endregion Properties

    internal Session()
    {
      Standings = new Standings.StandingCollection();
    }

    internal void AddDriver(Drivers.Driver d)
    {
      var s = CreateStandingByDriver(d);
      Standings.Add(s);
    }

    protected abstract ENG.NR2003.StaticRaceWeekend.Standings.Standing CreateStandingByDriver (Drivers.Driver d);

    }
    
  }
