using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scorings
{
  [Serializable()]
  public abstract class AbstractNRBasicScoring : AbstractScoring
  {
    public abstract  override int AtLeastOneLapLeaderPoints{get;}

    public abstract  override int MostLapLeaderPoints{get;}

    public abstract override int QualifyWinnerPoints{get;}

    public abstract override int RaceWinnerExtraPoints{get;}

    public sealed override int GetPositionPoints(int position)
    {
      if (position <= 6)
        return 185 - position * 5;
      else if (position <= 11)
        return 150 - position * 4;
      else
        return 130 - position * 3;
    }

    public abstract override string Name { get; }

    public abstract override string Description { get; }
  }
}
