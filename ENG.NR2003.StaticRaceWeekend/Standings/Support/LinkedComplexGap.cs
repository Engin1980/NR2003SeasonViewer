using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECC;

namespace ENG.NR2003.StaticRaceWeekend.Standings.Support
{
  [Serializable()]
  class LinkedComplexGap : ComplexGap
  {
    public LinkedComplexGap PreviousLap { get; private set; }
    public LinkedComplexGap NextLap { get; private set; }
    public LinkedComplexGap PreviousPosition { get; private set; }
    public LinkedComplexGap NextPosition { get; private set; }
    internal static void LinkByLap(LinkedComplexGap previous, LinkedComplexGap next)
    {
      Contract.Assert(previous != next);
        
      if (previous.NextLap != null)
        previous.NextLap.PreviousLap = null;
      if (next.PreviousLap != null)
        next.PreviousLap.NextLap = null;

      previous.NextLap = next;
      next.PreviousLap = previous;
    }
    internal static void LinkByPosition(LinkedComplexGap previous, LinkedComplexGap next)
    {
      Contract.Assert(previous != next);

      if (previous.NextPosition != null)
        previous.NextPosition.PreviousPosition = null;
      if (next.PreviousPosition != null)
        next.PreviousPosition.NextPosition = null;

      previous.NextPosition = next;
      next.PreviousPosition = previous;
    }
  }
}
