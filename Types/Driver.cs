using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  /// <summary>
  /// Represents driver with common info (name, number).
  /// </summary>
  [Serializable()]
  public class Driver
  {
    public string Number { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string NameSurname { get { return Name + " " + Surname; } }
    public string SurnameName { get { return Surname + " " + Name; } }

    public override string ToString()
    {
      return this.NumberString + " - " + this.NameSurname;
    }

    public string NumberString { get { return "#" + Number.Trim(); } }

    public static Driver Create(string carNumber, string fullName)
    {
      Driver ret = new Driver();

      ret.Number = carNumber.Trim();

      int i = fullName.IndexOf(" ");
      if (i < 0)
      {
        ret.Name = "";
        ret.Surname = fullName;
      }
      else
      {
        ret.Name = fullName.Substring(0, i);
        ret.Surname = fullName.Substring(i + 1);
      }

      return ret;
    }
  }
}
