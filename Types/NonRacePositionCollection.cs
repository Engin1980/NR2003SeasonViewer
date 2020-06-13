using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{

  /// <summary>
  /// Represents non race positions as enumeration of driver.
  /// </summary>
  [Serializable()]
  public class NonRacePositionCollection : List<NonRaceLap>
  {
    public NonRaceLap this[Driver driver]
    {
      get
      {
        return this.FirstOrDefault(i => i.Driver == driver);
      }
    }

    public int GetPosition(Driver driver)
    {
      for (int i = 0; i < this.Count; i++)
      {
        if (this[i].Driver == driver)
          return i + 1;
      }

      //TODO FŃ
      throw new ArgumentException("Driver not found in the non-race-position list.");
    }
  }
}
