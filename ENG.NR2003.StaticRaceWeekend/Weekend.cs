using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.StaticRaceWeekend.Sessions;
using ENG.NR2003.StaticRaceWeekend.Drivers;
using ECC;

namespace ENG.NR2003.StaticRaceWeekend
{
  [Serializable()]
  public class Weekend
  {
    #region Nested
    public enum eSessionType
    {
      Invalid,
      Testing,
      Practice,
      QualifyLone,
      QualifyOpen,
      Race
    };

    public enum eDamageLevel
    {
      None,
      Reduced,
      Full
    }
    public enum eDrivingMode
    {
      Arcade,
      Simulation
    }

    [Serializable()]
    public struct OpponentsStrength
    {
      private int? value;

      public static OpponentsStrength Create (int percentageStrenghtValue)
      {
        Contract.Requires (percentageStrenghtValue < 120);
        Contract.Requires(percentageStrenghtValue > 70);

        return new OpponentsStrength(){value = percentageStrenghtValue};
      }
      public static OpponentsStrength CreateWithAutomatic ()
      {
        return new OpponentsStrength(){value = null};
      }

      public bool IsAutomatic{
        get{ return value == null;}
      }
      public int Value {get {if (IsAutomatic) throw new Exception("Cannot get Value if strengh is automatic."); else return value.Value;}}

      public override string  ToString()
{
 	if (value == null)
    return "Automatic";
  else
    return value.Value + "%";
}
    }

    [Serializable()]
    public class WeekendOptions
    {
      public OpponentsStrength OpponentsStrength { get; set; }
      public eDamageLevel DamageLevel { get; set; }
      public int DefinedRaceLength { get; set; }
      public int PitFrequency { get; set; }
      public eDrivingMode DrivingMode { get; set; }
      public bool YellowFlags { get; set; }

    }
    #endregion Nested

    #region Properties

    public string Track { get; set; }
    public double TrackLength { get; internal set; }

    public DriverCollection Drivers { get; private set; }

    public NonRaceSession Practice { get; internal set; }
    public NonRaceSession Qualify { get; internal set; }
    public NonRaceSession HappyHour { get; internal set; }
    public RaceSession Race { get; internal set; }

    internal Session CurrentSession { get; set; }
    internal eSessionType CurrentSessionType { get; set; }

    public string RaceName { get; set; }
    public DateTime Date { get; set; }

    public WeekendOptions Options { get; private set; }

    #endregion Properties

    internal Weekend()
    {
      this.Drivers = new DriverCollection();
      this.Practice = new NonRaceSession() { SessionNum = 0 };
      this.Qualify = new NonRaceSession() { SessionNum = 1 };
      this.HappyHour = new NonRaceSession() { SessionNum = 2 };
      this.Race = new RaceSession() { SessionNum = 3 };
      this.Options = new WeekendOptions();

      this.Date = DateTime.Now.Date;
    }

    public void AddDriver(Driver d)
    {
      Drivers.Add(d);

      Practice.AddDriver(d);
      Qualify.AddDriver(d);
      HappyHour.AddDriver(d);
      Race.AddDriver(d);
    }

    public void SetCurrentSession(Session session)
    {
      Contract.Requires(session == Practice || session == Qualify || session == HappyHour || session == Race);

      this.CurrentSession = session;
    }
  }
}
