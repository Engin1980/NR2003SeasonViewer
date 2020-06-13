using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parentables;

namespace ENG.NR2003.Types
{

  /// <summary>
  /// Represents collection of Weekend info, which contains info about race and standings in championship after race.
  /// </summary>
  [Serializable()]
  public class WeekendInfoCollection : ParentableList<WeekendInfo, Season>
  {
    public WeekendInfoCollection(Season parentSeason)
      : base(parentSeason)
    {
      if (parentSeason == null)
        throw new ArgumentNullException();
    }

    internal WeekendInfoCollection() { }
  }
}
