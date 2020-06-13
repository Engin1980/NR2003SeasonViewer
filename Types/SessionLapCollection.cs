using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  [Serializable()]
  public class SessionLapCollection<T> : LapCollection<T> where T:Lap
  {
    public Session Session { get; private set; }

    public SessionLapCollection(Session parentSession)
    {
      this.Session = parentSession;
    }    

    public override void Add(T item)
    {
      base.Add(item);
      item.Session = this.Session;
    }

    public override void Remove(T item)
    {
      base.Remove(item);
      item.Session = null;
    }
  }
}
