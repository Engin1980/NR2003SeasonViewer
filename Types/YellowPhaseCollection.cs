using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  [Serializable()]
  public class YellowPhaseCollection : List<YellowPhase>
  {

    public bool IsInYellow(Time time)
    {
      foreach (var yp in this)
      {
        if (yp.StartTime > time)
          return false;
        else if (yp.EndTime > time)
          return true;
      }

      return false;
    }
  }
}
