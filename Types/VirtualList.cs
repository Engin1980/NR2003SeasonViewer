using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  [Serializable()]
  public class VirtualList<T> : IEnumerable<T>
  {
    private List<T> inner = new List<T>();

    public virtual void Add(T item)
    {
      inner.Add(item);
    }

    public virtual void Remove(T item)
    {
      inner.Remove(item);
    }

    public virtual void Clear()
    {
      inner.Clear();
    }

    public T this[int index]
    {
      get { return inner[index]; }
      set { inner[index] = value; }
    }

    public IEnumerator<T> GetEnumerator()
    {
      return inner.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return inner.GetEnumerator();
    }
  }
}
