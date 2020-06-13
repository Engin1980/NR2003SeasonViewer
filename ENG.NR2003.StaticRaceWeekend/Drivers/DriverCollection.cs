using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.StaticRaceWeekend.Drivers
{
  [Serializable()]
  public class DriverCollection : IEnumerable<Driver>
  {
    private List<Driver> inner = new List<Driver>();
    internal void Add (Driver driver){
      if (ContainsIdx(driver.CarIdx))
        throw new Exception("Driver with carIdx already defined.");

      inner.Add(driver);
    }

    public int Count { get { return inner.Count; } }

    public bool ContainsIdx (int carIdx)
    {
      return TryGetByIdx(carIdx) != null;
    }

    /// <summary>
    /// Returns driver by parameter, or null if does not exist.
    /// </summary>
    /// <param name="carIdx"></param>
    /// <returns></returns>
    public Driver TryGetByIdx(int carIdx)
    {
      foreach (var fItem in this)
        if (fItem.CarIdx == carIdx) return fItem;
      return null;
    }

    #region IEnumerable<Driver> Members

    public IEnumerator<Driver> GetEnumerator()
    {
      return inner.GetEnumerator();
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return inner.GetEnumerator();
    }

    #endregion

    internal void Remove(Driver d)
    {
      inner.Remove(d);
    }
  }
}
