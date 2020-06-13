using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.StaticRaceWeekend.Standings.Support
{
  [Serializable()]
  public class ComplexGap
  {
    #region Nested

    public class ByPositionComparer : IComparer<ComplexGap>
    {
      public int Compare(ComplexGap x, ComplexGap y)
      {
        return x.Position.CompareTo(y.Position);
      }
    }

    #endregion Nested

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private int _CarIdx = 0;
    ///<summary>
    /// Sets/gets CarIdx value. Default value is 0.
    ///</summary>
    public int CarIdx
    {
      get
      {
        return (_CarIdx);
      }
      internal set
      {
        _CarIdx = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private int _Position = 0;
    ///<summary>
    /// Sets/gets Position value. Default value is 0.
    ///</summary>
    public int Position
    {
      get
      {
        return (_Position);
      }
      internal set
      {
        _Position = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private int _LapIndex = 0;
    ///<summary>
    /// Sets/gets LapIndex value. Default value is 0.
    ///</summary>
    public int LapIndex
    {
      get
      {
        return (_LapIndex);
      }
      set
      {
        _LapIndex = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private double _CrossedAt = 0;
    ///<summary>
    /// Sets/gets CrossedAt value. Default value is 0.
    ///</summary>
    public double CrossedAt
    {
      get
      {
        return (_CrossedAt);
      }
      internal set
      {
        _CrossedAt = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private Gap _ToFirst = new Gap();
    ///<summary>
    /// Sets/gets ToFirst value. Default value is new Gap().
    ///</summary>
    public Gap ToFirst
    {
      get
      {
        return (_ToFirst);
      }
      internal set
      {
        _ToFirst = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private Gap _ToPrevious = new Gap();
    ///<summary>
    /// Sets/gets ToPrevious value. Default value is new Gap().
    ///</summary>
    public Gap ToPrevious
    {
      get
      {
        return (_ToPrevious);
      }
      internal set
      {
        _ToPrevious = value;
      }
    }

    public bool IsTimeInvalid { get; internal set; }
    public bool IsPitted { get; internal set; }
    public bool IsBlackFlagged { get; internal set; }
    public bool IsOffTrack { get; internal set; }

    public string FlagsInString
    {
      get
      {
        StringBuilder ret = new StringBuilder();

        if (IsPitted)
          ret.Append("Pit; ");
        if (IsBlackFlagged)
          ret.Append("Black flag; ");
        if (IsOffTrack)
          ret.Append("Off track; ");
        if (IsTimeInvalid)
          ret.Append("Invalid time; ");

        return ret.ToString();
      }
    }

    public override string ToString()
    {
      return
        string.Format("CG ilt {0}x{1}x{2}", this.CarIdx, this.LapIndex, this.CrossedAt);
    }
  }
}
