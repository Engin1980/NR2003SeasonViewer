using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.TelemetryEvents
{
  [Serializable()]
  public class SessionInfo : TelemetryEvent
  {
    public enum eSessionType
    {
      kSessionTypeInvalid,
      kSessionTypeTesting,
      kSessionTypePractice,
      kSessionTypeQualifyLone,
      kSessionTypeQualifyOpen,
      kSessionTypeRace
    };

    public enum eSessionState
    {
      kSessionStateInvalid,
      kSessionStateGetInCar,
      kSessionStateWarmup,
      kSessionStateParadeLaps,
      kSessionStateRacing,
      kSessionStateCheckered,
      kSessionStateCoolDown
    };

    public enum eSessionFlag
    {
      kFlagGreen,
      kFlagYellow,
      kFlagRed
    };

    public int SessionNum { get; private set; }
    public int SessionCookie { get; private set; }
    public eSessionType SessionType { get; private set; }
    public eSessionState SessionState { get; private set; }
    public eSessionFlag SessionFlag { get; private set; }
    public double CurrentTime { get; private set; }
    public double TimeRemaining { get; private set; }
    public int LapsRemaining { get; private set; }

    public SessionInfo (string [] pars)
    {
      SessionNum = int.Parse(pars[0]);
      SessionCookie = int.Parse(pars[1]);
      SessionType = (eSessionType) int.Parse(pars[2]);
      SessionState = (eSessionState) int.Parse(pars[3]);
      SessionFlag = (eSessionFlag) int.Parse(pars[4]);
      CurrentTime = Analyser.DblParse(pars[5]);
      TimeRemaining = Analyser.DblParse(pars[6]);
      LapsRemaining = int.Parse(pars[7]);
    }

    public override string ToString()
    {
      return this.GetType().Name + string.Format(
        "( sessNum: {0}; sessCook: {1}; sessTime: {2}, timeRem: {3}; lapsRem: {4}; {5}; {6}; {7})",
        this.SessionNum, this.SessionCookie, this.CurrentTime, this.TimeRemaining, this.LapsRemaining,
        this.SessionType.ToString(), this.SessionState.ToString(), this.SessionFlag.ToString());
    }
  }
}
