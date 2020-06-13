using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  [Serializable()]
  public abstract class Session
  {
    public Weekend Weekend {get; private set;}

    public Session(Weekend parentWeekend)
    {
      this.Weekend = parentWeekend;
    }

    public abstract bool IsEmpty();
    public abstract void Clear();
  }
}
