using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.TelemetryEvents
{
  [Serializable()]
  public class StandingsEntry : TelemetryEvent
  {
    public const int INVALID_CARIDX = -1;

    public enum eReasonsOut
    {
      kReasonOutNotOut,			// (default) not out of race
      kReasonOutBrakeFailure,
      kReasonOutCoolantLeak,
      kReasonOutRadiatorLeak,
      kReasonOutEngineFailure,
      kReasonOutEngineHeader,
      kReasonOutEngineValve,
      kReasonOutEnginePiston,
      kReasonOutEngineGearbox,
      kReasonOutEngineClutch,
      kReasonOutEngineCamShaft,
      kReasonOutEngineIgnition,
      kReasonOutEngineFire,
      kReasonOutEngineElectrical,
      kReasonOutFuelLeak,
      kReasonOutFuelInjector,
      kReasonOutFuelPump,
      kReasonOutFuelLine,
      kReasonOutOilLeak,
      kReasonOutOilLine,
      kReasonOutOilPump,
      kReasonOutOilPressure,
      kReasonOutSuspensionFailure,
      kReasonOutTirePuncture,
      kReasonOutTireProblem,
      kReasonOutWheelProblem,
      kReasonOutAccident,
      kReasonOutRetired,
      kReasonOutDisqualified,
      kReasonOutNoFuel,
      kReasonOutBrakeLine,
      kReasonOutLostConnection,
      kReasonOutEjected
    };

    public int CarIdx { get; private set; }
    public double Time { get; private set; }
    public int Lap { get; private set; }
    public int LapsLead { get; private set; }
    public eReasonsOut ReasonOut { get; private set; }
    public int Incidents { get; private set; }
    public bool IsOut
    {
      get
      {
        return this.ReasonOut == eReasonsOut.kReasonOutNotOut;
      }
    }

    public bool IsValid { get { return CarIdx != INVALID_CARIDX; } }

    public StandingsEntry (string [] pars)
    {
      CarIdx = int.Parse(pars[0]);
      Time = Analyser.DblParse(pars[1]);
      Lap = int.Parse(pars[2]);
      LapsLead = int.Parse(pars[3]);
      ReasonOut = (eReasonsOut) int.Parse(pars[4]);
      Incidents = int.Parse(pars[5]);
    }

    public override string ToString()
    {
      return this.GetType().Name + string.Format(
        "( carIdx: {0}; time: {1}; lap: {3}, lapsLead: {4}; reasonOut: {5}; Incidents: {6})",
        this.CarIdx, this.Time, this.LapsLead, this.ReasonOut.ToString(), this.Incidents);
    }
  }
}
