using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  /// <summary>
  /// Represents positions in the race as enumeration of lap numbers.
  /// </summary>
  [Serializable()]
  public class RacePositionCollection
  {
    public enum eStatus
    {
      //[DisplayText("Ok", "short")]
      //[DisplayText("Running")]
      Running,
      //[DisplayText("Crash", "short")]
      //[DisplayText("Accident")]
      Accident,
      //[DisplayText("Crash", "short")]
      //[DisplayText("Retired")]
      Retired,
      //[DisplayText("DQ", "short")]
      //[DisplayText("Disqualified")]
      DQ,
      //[DisplayText("DNQ", "short")]
      //[DisplayText("Didn't qualify")]
      DNQ,
      //[DisplayText("DNS", "short")]
      //[DisplayText("Didn't start")]
      DNS,
      //[DisplayText("Tech", "short")]
      //[DisplayText("Technical")]
      TechnicalFailure,
      //[DisplayText("Fail", "short")]
      //[DisplayText("Other fail")]
      OtherReason
    }

    private List<List<RaceLap>> inner = new List<List<RaceLap>>();
    private Dictionary<Driver, eStatus> driversFinalRaceStatuses = new Dictionary<Driver, eStatus>();

    /// <summary>
    /// Sets the driver final status in the race.
    /// </summary>
    /// <param name="driver">The driver.</param>
    /// <param name="status">The status.</param>
    public void SetDriverFinalStatus(Driver driver, eStatus status)
    {
      driversFinalRaceStatuses[driver] = status;
    }

    /// <summary>
    /// Gets the driver final status in the race.
    /// </summary>
    /// <param name="driver">The driver.</param>
    /// <returns></returns>
    public eStatus GetDriverFinalStatus(Driver driver)
    {
      if (driversFinalRaceStatuses.ContainsKey(driver) == false)
        throw new ArgumentException("Driver " + driver.ToString() + " has no status set.");

      return driversFinalRaceStatuses[driver];
    }

    /// <summary>
    /// Gets the <see cref="System.Collections.Generic.List&lt;ENG.NR2003.Types.RaceLap&gt;"/> with the specified lap number.
    /// </summary>
    public List<RaceLap> this[int lapNumber]
    {
      get {
        if (lapNumber < 1)
          throw new ArgumentException("Lap number must be greater than 0.");

        int li = GetLapIndex(lapNumber);
        return inner[li];
      }
    }

    /// <summary>
    /// Gets the count of laps for the first driver.
    /// </summary>
    public int LapCount { get { return inner.Count; } }

    private static int GetLapIndex(int lapNumber)
    {
      return lapNumber - 1;
    }

    /// <summary>
    /// Gets the specified lap by lapnumber and driver.
    /// </summary>
    /// <param name="lapNumber">The lap number.</param>
    /// <param name="driver">The driver.</param>
    /// <returns></returns>
    public RaceLap Get(int lapNumber, Driver driver)
    {
      var l = this[GetLapIndex( lapNumber)];
      RaceLap ret = l.FirstOrDefault(i => i.Driver == driver);
      return ret;
    }

    /// <summary>
    /// Gets lap of all drivers with specified lap number.
    /// </summary>
    /// <param name="lapNumber">The lap number.</param>
    /// <returns></returns>
    public List<RaceLap> Get(int lapNumber)
    {
      return this[GetLapIndex(lapNumber)];
    }

    /// <summary>
    /// Adds the lap.
    /// </summary>
    /// <param name="lapNumber">The lap number.</param>
    /// <param name="lap">The lap.</param>
    public void AddLap(int lapNumber, RaceLap lap)
    {
      while (inner.Count <= lapNumber)
        inner.Add(new List<RaceLap>());

      inner[GetLapIndex(lapNumber)].Add(lap);
    }

    internal void ClearExceptDriverFinalStatuses()
    {
      inner.Clear();
    }

    /// <summary>
    /// Gets the last lap of all drivers.
    /// </summary>
    /// <returns></returns>
    public List<RaceLap> GetLastLap()
    {
      return this[LapCount - 1];
    }
  }
}
