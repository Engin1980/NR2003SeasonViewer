#define IGNORE_PACE_CAR

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.StaticRaceWeekend;
using System.Diagnostics.Contracts;
using ENG.NR2003.TelemetryEvents;
using ENG.NR2003.StaticRaceWeekend.Sessions.Lengths;
using ENG.NR2003.StaticRaceWeekend.Drivers;
using ENG.NR2003.StaticRaceWeekend.Standings;
using ENG.NR2003.StaticRaceWeekend.Sessions;

namespace ENG.NR2003.StaticRaceWeekend.Updaters
{
  public class Updater
  {
    private const int EMPTY_SESSION_NUMBER = 0;

    private Weekend w = null;

    public Updater(Weekend weekend)
    {
      w = weekend;
    }

    public Updater() : this(null) { }

    public Weekend Weekend { get { return w; } }

    public void Update(TelemetryEvent e)
    {
      Type t = this.GetType();

      t.InvokeMember("Update", System.Reflection.BindingFlags.InvokeMethod, null, this, new object[] { e });
    }

    public void Update(ApplicationExit e) { }

    public void Update(CurrentWeekend e)
    {
      if (e.AtTrack == false)
        return;

      //w.Clear();

      w.Track = e.Track;
      w.TrackLength = e.TrackLength;      
      w.Practice.Length = new TimeLength(e.Sessions.PracticeLength);
      w.Qualify.Length = new LapsLength(e.Sessions.QualifyLapCount);
      w.HappyHour.Length = new TimeLength(e.Sessions.HappyHourLength);
      w.Race.Length = new TimeLength(e.Sessions.RaceLapCount);
      w.Race.TotalLapCount = e.Sessions.RaceLapCount;
    }

    public void Update(DriverEntry e)
    {
#if IGNORE_PACE_CAR
      if (e.IsPaceCar)
        return;
#endif

      Driver d = null;
      d = w.Drivers.TryGetByIdx(e.CarIdx);
      if (d == null)
      {
        d = new Driver(e.CarIdx);
        w.AddDriver(d);
      }
      if (d.CarNumber != e.CarNum)
      {
        d.CarNumber = e.CarNum;
      }
      if (d.Name != e.Name)
      {
        d.Name = e.Name;
      }
    }

    public void Update(DriverInCar e) { }

    public void Update(DriverWithdrawl e) 
    {
      // drivers are never removed

      //Driver d = null;
      //d = w.Drivers.TryGetByIdx(e.CarIdx);
      //if (d != null)
      //{
      //  w.RemoveDriver(d);
      //}
    }

    public void Update(GamePaused e) { }


    internal List<LapCrossing> RaceLapCrossings = new List<LapCrossing>();
    public void Update(LapCrossing e)
    {
      Contract.Assert(w.CurrentSession != null);

      var sess = w.CurrentSession;
      var stand = sess.Standings.TryGetByCarIdx(e.CarIdx);

      Contract.Assert(stand != null);

      Support.LapCrossingUpdater.Update(e, stand);
      if (sess is RaceSession)
        RaceLapCrossings.Add(e);
    }

    public void Update(SessionInfo e)
    {
      Session changedSession = null;
      Support.SessionInfoUpdater.Update(w, e, out changedSession);
    }

    public void Update(SimActive e) { }

    public void Update(ENG.NR2003.TelemetryEvents.Standings e)
    {
      if (e.SessionNum == EMPTY_SESSION_NUMBER) // invalid/empty Standings, exit method
        return;

      Session updatedSession = null;
      Support.StandingsUpdater.Update(w, e, out updatedSession);
    }

    public void Update(WaitingForActive e) { }

    //    public void AddLapCrossing(LapCrossing lc)
    //    {
    //      var nrs = GetSessionById(_lastSessionNum);
    //      if (nrs == null)
    //        return;
    //#warning TODO Může to být null?

    //      if (nrs is NonRaceSession)
    //        UpdateNonRaceSession(nrs as NonRaceSession, lc);
    //      else if (nrs is RaceSession)
    //        UpdateRaceSession(nrs as RaceSession, lc);
    //      else
    //        throw new NotSupportedException();

    //      if (LapCrossingAdded != null) LapCrossingAdded(this, nrs);
    //    }

    //    private void UpdateRaceSession(RaceSession nrs, LapCrossing lc)
    //    {
    //      NRStandings x = nrs.Standings;

    //      x.AddLapCrossing(lc);
    //    }

    //    private void UpdateNonRaceSession(NonRaceSession nrs, LapCrossing lc)
    //    {
    //      NRStandings x = nrs.Standings;

    //      x.AddLapCrossing(lc);
    //    }
  }
}
