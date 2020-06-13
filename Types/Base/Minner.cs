using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Types.Base
{
  public class Minner<T>
  {
    private Func<T, IComparable> selector;
    public bool IsEmpty { get; private set; }
    public T MinimumItem { get; private set; }

    public Minner(Func<T, IComparable> selector)
    {
      if (selector == null)
        throw new ArgumentNullException("Argument \"comparator\" is null.");

      this.selector = selector;
      this.IsEmpty = true;
    }

    public void Add (T value)
    {
      if (IsEmpty)
      {
        this.MinimumItem = value;
        this.IsEmpty = false;
      }
      else if (selector(value).CompareTo(selector(MinimumItem)) < 0){
        this.MinimumItem = value;
      }
    }
  }
}
