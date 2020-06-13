using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  public static class Assert
  {
    internal static void NotNull(Object o)
    {
      if (o == null)
        throw new ArgumentNullException("Assert exception - object is null.");
    }

    internal static void NotEmpty(string s)
    {
      if (string.IsNullOrWhiteSpace(s))
        throw new ArgumentException("Assert exception - object is null");
    }
  }
}
