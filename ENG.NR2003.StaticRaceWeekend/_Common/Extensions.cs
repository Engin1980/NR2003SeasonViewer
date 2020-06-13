using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.StaticRaceWeekend.Common
{
  static class Extensions
  {
    public static int CompareTo(this double? value, double? other, IComparer<double?> comparer)
    {
      int ret = comparer.Compare(value, other);
      return ret;
    }
  }
}
