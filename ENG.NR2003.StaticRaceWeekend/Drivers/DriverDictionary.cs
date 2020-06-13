//#define USE_CARIDX

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.StaticRaceWeekend.Drivers
{
  [Serializable()]
  public class DriverDictionary<T> : IEnumerable<DriverDictionary<T>.DriverTuple>
  {
    public class DriverTuple
    {
      public Driver Driver { get; internal set; }
      public T Value { get; internal set; }

      public DriverTuple(Driver driver, T value)
      {
        this.Driver = driver;
        this.Value = value;
      }

      public DriverTuple(Driver driver) : this (driver, default(T)) { }
    }

    private List<DriverTuple> inner = new List<DriverTuple>();

    public void Add (DriverDictionary<T>.DriverTuple item)
    {
      inner.Add(item);
    }
    public void Add (Driver d, T value)
    {
      inner.Add(new DriverTuple(d, value));
    }
    public T Get (Driver d)
    {
      foreach (var item in inner)
      {
        if (item.Driver == d)
          return item.Value;
      }

      throw new KeyNotFoundException("Driver " + d.ToString() + " does not exist in dictionary.");
    }

#if USE_CARIDX
    public T Get (int carIdx)
    {
      foreach (var item in inner)
      {
        if (item.Driver.CarIdx == carIdx)
          return item.Value;
      }

      throw new KeyNotFoundException("CarIdx " + carIdx + " does not exist in dictionary.");
    }
#endif

    public T Get(string carNumber)
    {
      foreach (var item in inner)
      {
        if (item.Driver.CarNumber == carNumber)
          return item.Value;
      }

      throw new KeyNotFoundException("CarIdx " + carNumber + " does not exist in dictionary.");
    }

    public T TryGet (Driver d, T defaultValue)
    {
      try
      {
        var ret = Get(d);
        return ret;
      }
      catch (Exception)
      {
        return defaultValue;
      }
    }

    private DriverTuple gt(Driver d)
    {
      foreach (var item in inner)
      {
        if (item.Driver == d) return item;
      }
      return null;
    }
    private DriverTuple gt(int carIdx)
    {
      foreach (var item in inner)
      {
        if (item.Driver.CarIdx == carIdx) return item;
      }
      return null;
    }
    private DriverTuple gt(string carNumber)
    {
      foreach (var item in inner)
      {
        if (item.Driver.CarNumber == carNumber) return item;
      }
      return null;
    }

    public void Set (Driver d, T value)
    {
      var t = gt(d);
      if (t == null)
        Add(d, value);
      else
        t.Value = value;
    }
#if USE_CARIDX
    public void Set (int carIdx, T value)
    {
      var t = gt(carIdx);
      if (t == null)
        throw new KeyNotFoundException("CarIdx " + carIdx + " not found in dictionary.");
      else
        t.Value = value;
      
    }
#endif
    public void Set (string carNumber, T value)
    {
      var t = gt(carNumber);
      if (t == null)
        throw new KeyNotFoundException("CarNumber " + carNumber + " not found in dictionary.");
      else
        t.Value = value;
      
    }

#if USE_CARIDX
    public bool ContainsCarIdx(int carIdx)
    {
      try
      {
        var t = this.Get(carIdx);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
#endif

    public bool ContainsCarNumber(string carNumber)
    {
      try
      {
        var t = this.Get(carNumber);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public IEnumerator<DriverTuple> GetEnumerator()
    {
      return inner.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return inner.GetEnumerator();
    }
  }
}
