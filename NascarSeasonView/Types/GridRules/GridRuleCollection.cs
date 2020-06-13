using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.NascarSeasonView.Types.GridRules
{
  [Serializable()]
  public class GridRuleCollection : List<GridRule>
  {

    public GridRuleCollection GetRulesFor(string gridTypeName, string weekendName, string trackName)
    {
      GridRuleCollection ret = new GridRuleCollection();

      foreach (var item in this)
      {
        if (IsAccepted(gridTypeName, item.GridTypeName)
          &&
          IsAccepted(weekendName, item.WeekendNameContains)
          &&
          IsAccepted(trackName, item.TrackNameContains)
          )
          ret.Add(item);
      }

      return ret;
    }

    private static bool IsAccepted(string value, string pattern)
    {
      if (pattern == null) return true;

      return (pattern.Contains(value));
    }
  }
}
