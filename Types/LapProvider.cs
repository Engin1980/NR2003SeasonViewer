using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  [Serializable()]
  public class LapProvider
  {
    /// <summary>
    /// Refresh links of PreviousLap and NextLap and LapNumber.
    /// Same-driver data are expected.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="laps"></param>
    internal static void ReLinkByTime<T>(List<T> laps) where T : Lap
    {
      if (laps.Count == 0) return;

#if DEBUG
      Driver d = laps[0].Driver;
      laps.ForEach(i =>
      {
        if (i.Driver != d)
          throw new ApplicationException("Cannot re-link by time for different drivers.");
      }); ;
#endif

      laps.Sort(new Lap.ByLapTimeComparer());

      if (laps.Count == 1)
      {
        laps[0].BetterLap = null;
        laps[0].NextLap = null;
        laps[0].LapOrderNumber = 1;
        return;
      }


      for (int i = 0; i < laps.Count; i++)
      {
        Lap cl = laps[i];
        cl.LapOrderNumber = i + 1;
        if (i == 0)
        {
          cl.BetterLap = null;
          cl.WorserLap = laps[i + 1];
        }
        else if (i == laps.GetLastIndex())
        {
          cl.BetterLap = laps[i - 1];
          cl.WorserLap = null;
        }
        else
        {
          cl.BetterLap = laps[i - 1];
          cl.WorserLap = laps[i + 1];
        }
      }
    }

    /// <summary>
    /// Refresh links of PreviousLap and NextLap and LapNumber.
    /// Same-driver data are expected.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="laps"></param>
    internal static void ReLinkByCrossedAt<T>(List<T> laps) where T : Lap
    {
      if (laps.Count == 0) return;

#if DEBUG
      Driver d = laps[0].Driver;
      laps.ForEach(i =>
      {
        if (i.Driver != d)
          throw new ApplicationException("Cannot re-link by crossed-at for different drivers.");
      }); ;
#endif

      laps.Sort(new Lap.ByCrossedAtTimeComparer());



      if (laps.Count == 1)
      {
        laps[0].PreviousLap = null;
        laps[0].NextLap = null;
        return;
      }

      for (int i = 0; i < laps.Count; i++)
      {
        Lap cl = laps[i];
        if (i == 0)
        {
          cl.PreviousLap = null;
          cl.NextLap = laps[i + 1];
        }
        else if (i == laps.GetLastIndex())
        {
          cl.PreviousLap = laps[i - 1];
          cl.NextLap = null;
        }
        else
        {
          cl.PreviousLap = laps[i - 1];
          cl.NextLap = laps[i + 1];
        }
      }
    }
  }
}
