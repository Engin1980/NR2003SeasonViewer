using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ENG.NR2003.Types
{
  public static class Extensions
  {
    public static void ForEach<TKey, TValue>(this Dictionary<TKey, TValue>.KeyCollection keyCollection, Action<TKey> action)
    {
      foreach (var item in keyCollection)
      {
        action(item);
      }
    }

    public static int GetLastIndex(this IList list)
    {
      return list.Count - 1;
    }
  }
}
