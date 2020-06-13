using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.TelemetryEvents;
using ENG.NR2003.StaticRaceWeekend.Standings;
using System.Diagnostics.Contracts;
using ENG.NR2003.StaticRaceWeekend.Common;
using ENG.NR2003.StaticRaceWeekend.LapRecords;

namespace ENG.NR2003.StaticRaceWeekend.Updaters.Support
{
  static class LapCrossingUpdater
  {
    public static void Update(LapCrossing lc, Standing target)
    {
      Contract.Requires(lc.CarIdx == target.Driver.CarIdx, "CarIDx differs!");

      var previousLapCrossing = target.LastLapCrossing;

      // musi byt tady nahore pred tim, nez se prida dalsi kolo do kolekce kol
      // protoze se to podle toho tridi
      // taky jsem si to musel ulozit pro pozdejsi pouziti (tu puvodni hodnotu)
      target.LastLapCrossing = lc.CrossedAt;

      if (previousLapCrossing.HasValue)
      {
        double diff = lc.CrossedAt - previousLapCrossing.Value;
        LapRecord lr = new LapRecord(diff, lc.LapNum, lc.CrossedAt, (LapRecord.eFlag) lc.Flags);
        target.AddLap(lr);        
      }
      
    }
    
  }
}
