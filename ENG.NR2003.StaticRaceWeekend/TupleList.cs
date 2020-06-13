using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.StaticRaceWeekend
{
  [Serializable()]
  public class TupleList<T, K> : IEnumerable<Tuple<T,K>> where K : IComparable<K>
  {
    private List<Tuple<T, K>> inner = new List<Tuple<T, K>>();    

    public void Add (Tuple<T,K> item)
    {
      inner.Add(item);
    }

    public void Add (T a, K b)
    {
      inner.Add(new Tuple<T, K>(a, b));
    }

    public void Set (T a, K b)
    {
      var existing = this.TryGet(a);
      if (existing != null)
        inner.Remove(existing);

      Add(a, b);
    }

    public Tuple<T,K> Get (T a)
    {
      foreach (var item in inner)
      {
        if (item.Item1.Equals(a))
          return item;
      }

      throw new KeyNotFoundException("Key " + a.ToString() + " not found.");
    }
    public Tuple<T,K> TryGet (T a)
    {
      Tuple<T,K> ret = null;
      try
      {
      ret = Get(a);
      }
      catch (Exception)
      {
        return null;
      }
      return ret;
    }

    public Tuple<T,K> GetByIndex (int index)
    {
      return inner[index];
    }
    public K GetValueByIndex (int index)
    {
      return GetByIndex(index).Item2;
    }

    public K GetValue(T a)
    {
      var t = Get(a);
      return t.Item2;
    }

    public K TryGetValue (T a)
    {
      return TryGetValue(a, default(K));
    }

    public K TryGetValue (T a, K returnedIfNotFound)
    {
      var t = TryGet(a);
      if (t == null)
        return returnedIfNotFound;
      else
        return t.Item2;
    }
    
    public void Sort (IComparer<Tuple<T,K>> comparer)
    {
      inner.Sort(comparer);
    }

    public void Sort (Func<Tuple<T,K>, Tuple<T,K>, int> sortDelegate)
    {
      this.Sort(new DelegateComparer(sortDelegate));
    }

    public void SortByValueDescending ()
    {
      inner.Sort((a, b) => b.Item2.CompareTo(a.Item2));
    }

    #region Sort by delegate stuff

    private class DelegateComparer : IComparer<Tuple<T, K>>
    {
      private delegate int CompareDelegateMethod(Tuple<T, K> x, Tuple<T, K> y);
      private Func<Tuple<T, K>, Tuple<T, K>, int> method;

      public DelegateComparer(Func<Tuple<T, K>, Tuple<T, K>, int> comparingMethod)
      {
        this.method = comparingMethod;
      }

      public int Compare(Tuple<T, K> x, Tuple<T, K> y)
      {
        int ret = method(x, y);
        return ret;
      }
    }

    #endregion Sort by delegate stuff

    public int Count
    {
      get
      {
        return inner.Count;
      }
    }

    public IEnumerator<Tuple<T, K>> GetEnumerator()
    {
      return inner.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return inner.GetEnumerator();
    }
  }
}
