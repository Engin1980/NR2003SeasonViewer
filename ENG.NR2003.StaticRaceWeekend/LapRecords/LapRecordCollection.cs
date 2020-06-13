using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace ENG.NR2003.StaticRaceWeekend.LapRecords
{
  [Serializable()]
  public class LapRecordCollection : IEnumerable<LapRecord>
  {
    private List<LapRecord> inner = new List<LapRecord>();

    internal void Add(LapRecord item)
    {
      Contract.Requires(item.IsEmpty == false);
      inner.Add(item);
    }

    internal void Clear()
    {
      inner.Clear();
    }

    internal void Remove(LapRecord item)
    {
      inner.Remove(item);
    }
    internal void RemoveAt(int index)
    {
      this.Remove(this[index]);
    }

    public void Sort()
    {
      inner.Sort();
    }

    public int Count
    {
      get
      {
        return inner.Count;
      }
    }

    public LapRecord this[int index]
    {
      get { return inner[index]; }
    }

    #region IEnumerable<T> Members

    public IEnumerator<LapRecord> GetEnumerator()
    {
      return inner.GetEnumerator();
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return inner.GetEnumerator();
    }

    #endregion
  }
}
