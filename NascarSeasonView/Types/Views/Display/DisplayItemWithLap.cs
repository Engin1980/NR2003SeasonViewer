using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;

namespace ENG.NR2003.NascarSeasonView.Types.Views.Display
{
  struct DisplayItemWithLap<T> : IComparable where T : IComparable<T>
  {
    public static T EmptyValue {get;set;}
    public T Item { get; private set; }
    public int LapNumber { get; private set; }

    public override string ToString()
    {
      if (this.IsItemEmpty())
        return "";
      else
        if (LapNumber > 0)
          return Item.ToString() + " (" + LapNumber + ")";
        else
          return Item.ToString();
    }

    public int CompareTo(object obj)
    {
      if (obj is DisplayItemWithLap<T>)
      {
        DisplayItemWithLap<T> other = (DisplayItemWithLap<T>)obj;

        if (this.IsItemEmpty())
        {
          if (other.IsItemEmpty())
            return 0;
          else
            return 1;
        }
        else
        {
          if (other.IsItemEmpty())
            return -1;
          else
            return this.Item.CompareTo(((DisplayItemWithLap<T>)obj).Item);
        }
      }
      else
        return -1;
    }

    public bool IsItemEmpty()
    {
      return (Item.CompareTo(EmptyValue) == 0);
    }

    public DisplayItemWithLap(T item)
      : this()
    {
      this.Item = item;
    }

    public DisplayItemWithLap(T item, int lapNumber)
      : this(item)
    {
      this.LapNumber = lapNumber;
    }

    public static implicit operator DisplayItemWithLap<T>(T item)
    {
      return new DisplayItemWithLap<T>(item);
    }
  }
}
