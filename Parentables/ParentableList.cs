using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parentables
{
  [Serializable()]
  public class ParentableList <TItem,TParent> : IList<TItem> 
    where TItem:IParentable<TParent>
    where TParent:class
  {
    private List<TItem> inner = new List<TItem>();

    private TParent _Parent = default(TParent);
    public TParent Parent { get{return _Parent;}
      set {
        if (_Parent == null || value == null || _Parent.Equals(value) == false)
        {
          _Parent = value;
          foreach (var item in inner)
          {
            item.Parent = value;
          }
        }
      }
    }

    public ParentableList()
    {
    }

    public ParentableList(TParent explicitParent)
    {
      this.Parent = explicitParent;
    }

    public int IndexOf(TItem item)
    {
      return inner.IndexOf(item);
    }

    public void Insert(int index, TItem item)
    {
      inner.Insert(index, item);
      item.Parent = this.Parent;
    }

    public void RemoveAt(int index)
    {
      inner.RemoveAt(index);
    }

    public TItem this[int index]
    {
      get
      {
        return inner[index];
      }
      set
      {
        inner[index] = value;
        value.Parent = this.Parent;
      }
    }

    public void Add(TItem item)
    {
      inner.Add(item);
      item.Parent = this.Parent;
    }

    public void Clear()
    {
      inner.Clear();
    }

    public bool Contains(TItem item)
    {
      return inner.Contains(item);
    }

    public void CopyTo(TItem[] array, int arrayIndex)
    {
      inner.CopyTo(array, arrayIndex);
    }

    public int Count
    {
      get { return inner.Count; }
    }


    public bool IsReadOnly
    {
      get { return false; }
    }

    public bool Remove(TItem item)
    {
      return inner.Remove(item);
    }

    public IEnumerator<TItem> GetEnumerator()
    {
      return inner.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return inner.GetEnumerator();
    }

    public void Sort()
    {
      inner.Sort();
    }

    public void Sort(IComparer<TItem> comparer){
      inner.Sort(comparer);
    }
  }
}
