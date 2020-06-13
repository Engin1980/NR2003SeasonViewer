using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace ENG.NR2003.StaticRaceWeekend.Drivers
{
  /// <summary>
  /// Represents driver in the race weekend.
  /// </summary>
  /// 
  [Serializable()]
  public class Driver
  {
    public Driver(int carIdx)
    {
      this.CarIdx = carIdx;
    }

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
        Contract.Requires(value >= 0);

        _CarIdx = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private string _CarNumber = "???";
    ///<summary>
    /// Sets/gets CarNumber value. Default value is "".
    ///</summary>
    public string CarNumber
    {
      get
      {
        return (_CarNumber);
      }
      internal set
      {
        Contract.Requires(!string.IsNullOrEmpty(value));
        _CarNumber = value;
      }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private string _Name = "???";
    ///<summary>
    /// Sets/gets Driver value. Default value is "???".
    ///</summary>
    public string Name
    {
      get
      {
        return (_Name);
      }
      internal set
      {
        Contract.Requires(!string.IsNullOrEmpty(value));
        _Name = value;
      }
    }

    public override string ToString()
    {
      return "#" + this.CarNumber + " - " + this.Name;
    }
  }
}
