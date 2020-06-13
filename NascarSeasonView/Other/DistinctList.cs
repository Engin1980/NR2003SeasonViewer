using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarSeasonView.Other
{
  public class DistinctList<T> : IList<T>
  {
    private List<T> inner = new List<T>();

    public int IndexOf(T item)
    {
      return inner.IndexOf(item);
    }

    public void Insert(int index, T item)
    {
      if (inner.Contains(item) == false)
        inner.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
      inner.RemoveAt(index);
    }

    public T this[int index]
    {
      get
      {
        return inner[index];
      }
      set
      {
        if (inner.Contains(value) == false)
          inner[index] = value;
      }
    }

    public void Add(T item)
    {
      if (inner.Contains(item) == false)
        inner.Add(item);
    }

    public void Clear()
    {
      inner.Clear();
    }

    public bool Contains(T item)
    {
      return inner.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      for (int i = arrayIndex; i < array.Length; i++)
      {
        this.Add(array[i]);
      }
    }

    public int Count
    {
      get { return inner.Count; }
    }

    public bool IsReadOnly
    {
      get { return false; }
    }

    public bool Remove(T item)
    {
      return inner.Remove(item);
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
