using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parentables;

namespace ENG.NR2003.Types
{
  [Serializable()]
  public class WeekendInfo : IParentable<Season>
  {
    private Weekend _Weekend = null;
    /// <summary>
    /// Gets/sets weekend. Cannot be null.
    /// </summary>
    public Weekend Weekend
    {
      get { return _Weekend; }
      set
      {
        if (value == null) throw new ArgumentNullException();
        if (value.IsValid() == false)
          throw new ApplicationException("Cannot set Weekend property, value is not valid.");

        if (_Weekend != value)
        {
          this._Weekend = value;
          this.Standings = new WeekendStandings();
          this.Standings.Parent = this.Standings;
        }
        ;
      }
    }
    /// <summary>
    /// Gets championship standing after current weekend.
    /// </summary>
    public WeekendStandings Standings { get; private set; }
    private Season _Parent;
    /// <summary>
    /// Gets/sets parent season, or null.
    /// </summary>
    public Season Parent
    {
      get { return _Parent; }
      set
      {
        this._Parent = value;
        Weekend.Season = value;
      }
    }

    internal WeekendInfo()
    {
    }
    public WeekendInfo(Weekend weekend)
    {
      this.Weekend = weekend;
    }    
  }
}
