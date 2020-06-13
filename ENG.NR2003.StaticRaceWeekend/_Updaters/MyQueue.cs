using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace ENG.NR2003.StaticRaceWeekend.Updaters
{
  public class MyQueue<T>
  {
    private Queue<T> inner = new Queue<T>();

    internal void Enqueue(T item)
    {
      Contract.Requires(item != null);

      inner.Enqueue(item);
    }

    public int Count
    {
      get
      {
        return inner.Count;
      }
    }

    public T Dequeue()
    {
      T it = inner.Dequeue();

      return it;
    }
  }
}
