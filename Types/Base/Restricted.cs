using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Types.Base
{
  [Serializable()]
  public struct Restricted<T> where T : IComparable<T>
  {
    public T Minimum { get; private set; }
    public T Maximum{get;private set;}
    private T _Value;
    public T Value { 
      get
    {
      return _Value;
    } set
    {
      SetValue(value);
    }
    }

    private void SetValue(T value)
    {
      if (Minimum != null && value.CompareTo(Minimum) < 0)
        _Value = Minimum;
      else if (Maximum != null && value.CompareTo(Maximum) > 0)
        _Value = Maximum;
      else
        _Value = value;
    }

    public static implicit operator T(Restricted<T> value)
    {
      return value.Value;
    }
  }
}
