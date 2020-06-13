using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  [Serializable()]
  public class Lap
  {
    private static int nextId=1;
    public int Id { get; private set; }
    public Lap()
    {
      this.Id = Lap.nextId++;
    }

    #region Comparers

    public class ByLapTimeComparer : IComparer<Lap>
    {
      public int Compare(Lap x, Lap y)
      {
        return x.Time.CompareTo(y.Time);
      }
    }

    public class ByCrossedAtTimeComparer : IComparer<Lap>
    {
      public int Compare(Lap x, Lap y)
      {
        return x.CrossedAtTime.CompareTo(y.CrossedAtTime);
      }
    }

    #endregion

    #region Nested
    [Serializable()]
    public enum PitStatus
    {
      /// <summary>
      /// This lap is no-pit lap.
      /// </summary>
      NoPit = 0,
      /// <summary>
      /// This lap is pit-entry lap.
      /// </summary>
      PitFirstLap = 2,
      /// <summary>
      /// This lap is pit-exit lap.
      /// </summary>
      PitLastLap = 4,
      /// <summary>
      /// This lap is pit-exit and also next pit-entry lap.
      /// </summary>
      PitBothLap = 8
    }

    #endregion

    #region Properties

    /// <summary>
    /// Represents driver of the lap.
    /// </summary>
    public Driver Driver { get; set; }
    public Session Session { get; internal set; }
    public Time Time { get; internal set; }
    /// <summary>
    /// Represents time when 
    /// </summary>
    public Time CrossedAtTime { get; set; }
    public bool IsBlackFlagged { get;  set; }
    public bool IsOffTrack { get;  set; }
    public bool IsPitted { get; set; }

    /// <summary>
    /// Number of lap. One-based.
    /// </summary>
    public int LapNumber { get; internal set; }

    /// <summary>
    /// Position of lap in the set of laps of the same driver.
    /// </summary>
    public int LapOrderNumber { get; internal set; }

    /// <summary>
    /// Link to lap with lower lap-number, or null.
    /// </summary>
    public Lap PreviousLap { get; internal set; }
    /// <summary>
    /// Link to next lap - with higher lap-number, or null.
    /// </summary>
    public Lap NextLap { get; internal set; }
    /// <summary>
    /// Link to lap with better time, or null.
    /// </summary>
    public Lap BetterLap { get; internal set; }
    /// <summary>
    /// Link to lap with more worse time, or null.
    /// </summary>
    public Lap WorserLap { get; internal set; }

    #endregion

    #region Methods

    /// <summary>
    /// Checks if object has all required attributes.
    /// </summary>
    /// <returns></returns>
    public bool IsValid()
    {
      List<bool> rets = new List<bool>();

      rets.Add(Driver != null);
      //rets.Add(Time.IsZero() == false); // removed, because Time is calculated in here as difference of two crosses.
      rets.Add(CrossedAtTime.IsZero() == false);

      bool ret =
        rets.Contains(false) == false;

      return ret;
    }

    public override string ToString()
    {
      return string.Format("Lap{4} {{{0} | {1} | {2} | {3}}}",
        Driver.NumberString, 
        LapNumber,
        CrossedAtTime.ToString(false),
        Time.ToString(false),
        this.Id);
    }

    public Lap GetThrough(Func<Lap, Lap> way)
    {
      Lap ret = null;
      Lap next = this;
      do
      {
        ret = next;
        next = way(next);
      } while (next != null);

      return ret;
    }

    #endregion Methods
  }
}
