using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarSeasonView.SeasonScoring
{
  interface IScoring
  {
    string Name { get; }
    string Description { get; }
    object Parameters { get; set; }

    /// <summary>
    /// Returns score points for drivers. Key is CarIdx, second argument are points.
    /// </summary>
    /// <param name="weekend"></param>
    /// <returns></returns>
    Dictionary<int, int> GetScoring (ENG.NR2003.StaticRaceWeekend.Weekend weekend);
  }
}
