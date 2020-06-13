using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  [Serializable()]
  public class LapCollection<T> where T:Lap
  {
    private List<T> all = new List<T>();
    private Dictionary<Driver, List<T>> driverLaps = new Dictionary<Driver, List<T>>();
    // lap-number se nastavují až někdy pozdě, takže podle toho nemůžu dictionariovat
    //private Dictionary<int, List<T>> numberLaps = new Dictionary<int, List<T>>();

    public virtual void Add(T item)
    {
      if (item.IsValid() == false)
        throw new ApplicationException("Lap is not valid, so it cannot be added to list. " + item.ToString());
      if (Exists(item))
        throw new ApplicationException("Lap already exists in the set. " + item.ToString());

      all.Add(item);

      if (driverLaps.ContainsKey(item.Driver) == false) driverLaps.Add(item.Driver, new List<T>());
      driverLaps[item.Driver].Add(item);

      //if (numberLaps.ContainsKey(item.LapNumber) == false) numberLaps.Add(item.LapNumber, new List<T>());
      //numberLaps[item.LapNumber].Add(item);
    }

    /// <summary>
    /// Returns true if lap is already added into this set.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Exists(T item)
    {
      Assert.NotNull(item);

      if (this.driverLaps.ContainsKey(item.Driver) == false) return false;

      var laps = this[item.Driver];
      var f = laps.FirstOrDefault(i => i.CrossedAtTime == item.CrossedAtTime);
      return f != null;
    }

    internal DriverCollection GetDrivers()
    {
      DriverCollection ret = new DriverCollection(false);

      driverLaps.Keys.ForEach(i => ret.Add(i));

      return ret;
    }

    /// <summary>
    /// Returns all laps of driver.
    /// </summary>
    /// <param name="driver"></param>
    /// <returns></returns>
    public List<T> this[Driver driver]
    {
      get
      {
        Assert.NotNull(driver);

        if (driverLaps.ContainsKey(driver) == false)
          driverLaps.Add(driver, new List<T>());

        return driverLaps[driver];
      }
    }

    /// <summary>
    /// Returns all laps of all drivers in undetermined order.
    /// </summary>
    /// <returns></returns>
    public List<T> GetAll()
    {
      List<T> ret = new List<T>();
      ret.AddRange(all);
      return ret;
    }

    public List<T> Get(int lapNumber)
    {
      List<T> ret = null;

      ret = all.Where(i => i.LapNumber == lapNumber).ToList();

      return ret;
    }

    public T Get(int lapNumber, Driver driver)
    {
      if (driverLaps.ContainsKey(driver))
        return driverLaps[driver].FirstOrDefault(i => i.LapNumber == lapNumber);
      else
        return null;
    }

    public virtual void Remove(T item)
    {
      all.Remove(item);
      driverLaps[item.Driver].Remove(item);
    }

    public void Remove(int lapNumber, Driver driver)
    {
      T item = Get(lapNumber, driver);
      Remove(item);
    }
  }
}
