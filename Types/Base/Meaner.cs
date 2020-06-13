using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  [Serializable()]
  public class Meaner
  {
    private double _Count = 0;
    private double _Sum = 0;

    public void Add(int value)
    {
      _Sum += value;
      _Count++;
    }

    public void Add(int value, int count)
    {
      _Sum += value * count;
      this._Count += count;
    }

    public double Mean { get { if (_Count == 0) return double.NaN; else return _Sum / _Count; } }
    public double Sum { get { return _Sum; } }
    public double Count { get { return _Count; } }

    public override string ToString()
    {
      return this.ToString("0.00");
    }

    public string ToString(string format)
    {
      return string.Format("{}({}/{})",
        Mean.ToString(format), Sum.ToString(format), Count.ToString(format));
    }

    public Meaner Clone()
    {
      Meaner ret = new Meaner();
      ret._Count = this._Count;
      ret._Sum = this._Sum;

      return ret;
    }
  }
}
