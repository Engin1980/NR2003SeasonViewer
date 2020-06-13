using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  [Serializable()]
  public struct Time : IComparable<Time>, IComparable
  {
    public int Miliseconds { get; private set; }
    public int Seconds { get; private set; }
    public int Minutes { get; private set; }
    public int Hours { get; private set; }

    public int TotalMiliseconds
    {
      get
      {
        return Miliseconds + Seconds * 1000 + Minutes * 1000 * 60 + Hours * 1000 * 60 * 60;
      }
      set
      {
        if (value < 0)
          throw new Exception("Time value cannot be negative.");

        int pom = 1000 * 60 * 60;
        Hours = value / pom;
        value = value % pom;

        pom = 1000 * 60;
        Minutes = value / pom;
        value = value % pom;

        pom = 1000;
        Seconds = value / pom;
        value = value % pom;

        Miliseconds = value;
      }
    }

    public Time(TimeSpan timeSpan) : this((int) timeSpan.TotalMilliseconds) { }

    public Time(int hours, int minutes, double seconds) : 
      this((int)(hours * 60 * 60 * 1000 + minutes * 60 * 1000 + seconds*1000))
    {}

    public Time(int hours, int minutes, int seconds, int miliseconds):
      this((int)(hours * 60 * 60 * 1000 + minutes * 60 * 1000 + seconds*1000+miliseconds))
    {}

    public Time(int totalMiliseconds) : this()
    {
      this.TotalMiliseconds = totalMiliseconds;
    }

    public static Time CreateFromMiliseconds(int miliseconds)
    {
      return new Time(miliseconds);
    }
    public static Time CreateFromSeconds(double seconds)
    {
      return new Time((int)(seconds * 1000));
    }

    public override string ToString()
    {
      return
        this.ToString(false);
    }

    public string ToString(bool expand)
    {
      if (expand)
        return GetFullString();
      else
        return GetShortString();
    }

    private string GetShortString()
    {      
      StringBuilder sb = new StringBuilder();
      if (Hours > 0)
        sb.Append(Hours.ToString() + ":");

      if (Minutes > 0)
      {
        if (sb.Length == 0)
          sb.Append(Minutes.ToString() + ":");
        else
          sb.Append(Minutes.ToString("00") + ":");
      }

      if (sb.Length == 0)
        sb.Append(Seconds.ToString() + ",");
      else
        sb.Append(Seconds.ToString("00") + ",");

      sb.Append(Miliseconds.ToString("000"));

      return sb.ToString();
    }

    private string GetFullString()
    {
      return string.Format("{0}:{1}:{2},{3}",
        Hours.ToString("0"), Minutes.ToString("00"),
        Seconds.ToString("00"), Miliseconds.ToString("000"));
    }

    public static Time Parse(string value)
    {
      if (value.StartsWith("-"))
      {
        value = value.Substring(1);
        throw new ApplicationException("Negative Times are not supported.");
      }

      //TODO přepsat na lepší

      List<string> ddp = value.Split(':').ToList();

      if (ddp.Count > 3)
        throw new ArgumentException("Cannot parse " + value + " to Time.");

      while (ddp.Count > 2)
        ddp.Insert(0, "0");

      int hours;
      int mins;
      double secs;

      if (int.TryParse(ddp[0], out hours) == false) 
        throw new ArgumentException("Cannot parse hours to Time from " + value + ".");
      if (int.TryParse(ddp[1], out mins) == false)
        throw new ArgumentException("Cannot parse minutes to Time from " + value + ".");
      if (double.TryParse(ddp[0], out secs) == false)
        throw new ArgumentException("Cannot parse seconds to Time from " + value + ".");

      Time ret = new Time(hours, mins, secs);

      return ret;
    }

    public static bool TryParse(string value, out Time time)
    {
      try
      {
        time = Time.Parse(value);
        return true;
      }
      catch (Exception)
      {
        time = default(Time);
        return false;
      }
    }

    public int CompareTo(Time other)
    {
      int ret;
      ret = this.Hours.CompareTo(other.Hours);
      if (ret == 0) { 
        ret = this.Minutes.CompareTo(other.Minutes);
        if (ret == 0)
        {
          ret = this.Seconds.CompareTo(other.Seconds);
          if (ret == 0)
          {
            ret = this.Miliseconds.CompareTo(other.Miliseconds);
          }
        }
      }
      return ret;
    }

    /// <summary>
    /// Returns true if item has zero value.
    /// </summary>
    /// <returns></returns>
    public bool IsZero()
    {
      return this.TotalMiliseconds == 0;
    }

    public override bool Equals(object obj)
    {
      if (obj == null || GetType() != obj.GetType())
      {
        return false;
      }

      Time o = (Time)obj;
      return this == o;
    }

    public override int GetHashCode()
    {
      throw new NotImplementedException();
    }

    public static bool operator > (Time a, Time b)
    {
      int ret = a.CompareTo(b);
      return ret > 0;    
    }
    public static bool operator >=(Time a, Time b)
    {
      int ret = a.CompareTo(b);
      return ret > -1;
    }
    public static bool operator <(Time a, Time b)
    {
      int ret = a.CompareTo(b);
      return ret < 0;
    }
    public static bool operator <=(Time a, Time b)
    {
      int ret = a.CompareTo(b);
      return ret < 1;
    }
    public static bool operator == (Time a, Time b)
    {
      int ret = a.CompareTo(b);
      return ret == 0;
    }
    public static bool operator !=(Time a, Time b)
    {
      int ret = a.CompareTo(b);
      return ret != 0;
    }

    public static Time operator -(Time a, Time b)
    {
      int am = a.TotalMiliseconds;
      int bm = b.TotalMiliseconds;
      int diff = am - bm;

      Time ret = new Time(diff);

      return ret;
    }

    public static Time operator +(Time a, Time b)
    {
      int am = a.TotalMiliseconds;
      int bm = b.TotalMiliseconds;
      int diff = am + bm;

      Time ret = new Time(diff);

      return ret;
    }

    public int CompareTo(object obj)
    {
      if (obj == null)
        return -1;
      else if (obj is Time)
        return CompareTo((Time)obj);
      else
        return -1;
    }

    public static Time Empty { get { return new Time(); }}
  }
}
