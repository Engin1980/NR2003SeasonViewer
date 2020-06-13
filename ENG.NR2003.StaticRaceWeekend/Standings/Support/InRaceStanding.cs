//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Diagnostics.Contracts;
//using ENG.NR2003.TelemetryEvents;

//namespace ENG.NR2003.StaticRaceWeekend.Standings.Support
//{
//  [Serializable()]
//  public class InRaceStanding
//  {

//    #region Properties
    
//    #endregion Properties    

//    #region Public methods
//    public List<ComplexGap> GetStandingsOfLap(int lapNumber)
//    {
//      if (calculatedLaps.ContainsKey(lapNumber) == false)
//        CalculateLap(lapNumber,false);

//      return calculatedLaps[lapNumber];
//    }
//    #endregion Public methods

//    #region Internal methods
//    internal void CalculateAllLaps ()
//    {
//      for (int i = 0; i < temp.Count; i++)
//      {
//        CalculateLap(i,false);
//      }
//    }
//    #endregion Internal methods

//    #region Private methods

//    private ComplexGap GetComplexGap(int carIdx, int lapIndex)
//    {
//      throw new NotSupportedException();

//      //if (temp.Count <= lapIndex)
//      //  return null;

//      //if (calculatedLaps.ContainsKey(lapIndex) == false)
//      //  CalculateLap(lapIndex,false);

//      //throw new NotImplementedException("Tady se to musí ještě přebrat s ohledem na to že odpadlíci nebudou v dalších kolech.");
//    }
//    #endregion Private methods


//    internal int GetLapIndexByTime(double time)
//    {
//      int ret = 0;
//      for (int i = 0; i < temp.Count; i++)
//      {
//        if (temp[i][0].CrossedAt > time)
//          return ret;
//        else
//          ret = i;
//      }

//      return temp.Count-1;
//    }
//  }
//}
