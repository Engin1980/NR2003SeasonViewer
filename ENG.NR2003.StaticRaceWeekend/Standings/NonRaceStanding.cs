using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using ENG.NR2003.StaticRaceWeekend.LapRecords;

namespace ENG.NR2003.StaticRaceWeekend.Standings
{
  [Serializable()]
  public class NonRaceStanding : Standing
  {
    #region Comparers

    public class ByCalculatedPositionComparer : IComparer<Standing>
    {
      #region IComparer<Standing> Members

      public int Compare(Standing x, Standing y)
      {
        Contract.Assert(x is NonRaceStanding);
        Contract.Assert(y is NonRaceStanding);

        int ret = x.FirstTime.CompareTo(y.FirstTime);

        return ret;
      }

      #endregion
    }

    #endregion Comparers

    #region Properties

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private int _OfficialLapNumber = 0;
    ///<summary>
    /// Sets/gets OfficialLapNumber value. Default value is 0.
    ///</summary>
    public int OfficialLapNumber
    {
      get
      {
        return (_OfficialLapNumber);
      }
      internal set
      {
        Contract.Requires(value >= 0);
        _OfficialLapNumber = value;
      }
    }
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private double? _OfficialBestTime = null;
    ///<summary>
    /// Sets/gets OfficialBestTime value. Default value is null.
    ///</summary>
    public double? OfficialBestTime
    {
      get
      {
        return (_OfficialBestTime);
      }
      internal set
      {
        Contract.Requires(value != null);

        _OfficialBestTime = value;
      }
    }    
       
    internal override bool CanHavePosition
    {
      get { return FirstTime.IsEmpty == false; }
    }

    #endregion Properties

  }
}
