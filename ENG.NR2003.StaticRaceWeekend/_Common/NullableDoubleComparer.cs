using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.StaticRaceWeekend.Common
{
  class NullableDoubleComparer : IComparer<double?>
  {
    #region IComparer<double?> Members

    public int Compare(double? x, double? y)
    {
      int ret;
      if (x == null && y == null)
        ret = 0;
      else if (x == null)
        ret = 1;
      else if (y == null)
        ret = -1;
      else
        ret = x.Value.CompareTo(y.Value);

      return ret;
    }

    #endregion
  }
}
