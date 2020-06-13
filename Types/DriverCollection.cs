using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  /// <summary>
  /// Represents collection of drivers. Driver numbers can be unique (see .ctor).
  /// </summary>
  [Serializable()]
  public class DriverCollection : VirtualList<Driver>, IEnumerable<Driver>
  {
    private bool distinctCarNumbers = false;
    private HashSet<string> usedCarNumbers = new HashSet<string>();

    public DriverCollection(bool carNumbersMustBeDistinct)
    {
      bool distinctCarNumbers = carNumbersMustBeDistinct;
    }

    public override void Add(Driver item)
    {
      if (distinctCarNumbers){
        if (ContainsNumber(item.Number))
          throw new ArgumentOutOfRangeException("Car number already exists in driver collection.");
      }

      base.Add(item);
      usedCarNumbers.Add(item.Number);
    }

    public override void Remove(Driver item)
    {
      base.Remove(item);
      if (ContainsNumber(item.Number))
        usedCarNumbers.Remove(item.Number);
    }

    public override void Clear()
    {
      base.Clear();
      usedCarNumbers.Clear();
    }

    public bool ContainsNumber(string carNumber)
    {
      return usedCarNumbers.Contains(carNumber);
    }

    public new IEnumerator<Driver> GetEnumerator()
    {
      // TODO opravit
      return base.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return base.GetEnumerator();
    }

    public Driver TryGetBestBy(string carNumber, string driverName)
    {
      Driver pom = Driver.Create(carNumber, driverName);


      var nums = this.Where(i => i.Number == pom.Number);
      nums = nums.Where(i => i.SurnameName == pom.SurnameName);

      int cnt = nums.Count();
      if (cnt > 1)
        throw new ApplicationException("Failed to get just only one driver for entered values.");
      //TODO přepsat na nějakou lepší výjimku

      else if (cnt < 1)
        return null;
      else
        return nums.First();
    }
  }
}
