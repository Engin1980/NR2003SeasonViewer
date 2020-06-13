using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.TelemetryEvents
{
  [Serializable()]
  public class DriverEntry : TelemetryEvent
  {
    public const int INVALID_CARIDX = -1;
    private const string PACE_CAR_DRIVER_NAME = "Pace Car";

    public int Flags { get; private set; }
    public int CarIdx { get; private set; }
    public int CarMake { get; private set; }
    public string CarNum { get; private set; }
    public string Name { get; private set; }
    public string CarFile { get; private set; }

    public bool IsValid { get { return CarIdx != INVALID_CARIDX; } }
    public bool IsPaceCar { get { return Name == PACE_CAR_DRIVER_NAME; } }

    public DriverEntry(string[] pars)
    {
      Flags = int.Parse(pars[0]);
      CarIdx = int.Parse(pars[1]);
      CarMake = int.Parse(pars[2]);
      CarNum = pars[3];
      Name = pars[4];
      CarFile = pars[5];
    }

    public override string ToString()
    {
      return this.GetType().Name + string.Format(
        "( {0}; {1}; {2})",
        this.CarIdx, this.CarNum, this.Name);
    }
  }
}
