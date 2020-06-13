using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.StaticRaceWeekend.Drivers;
using ENG.NR2003.TelemetryEvents;

namespace ENG.NR2003.RaceWeekendUpdater
{
public static  class Converter
  {
  public static Driver Convert(DriverEntry driverInfo)
  {
    Driver ret = new Driver(driverInfo.CarIdx);
    ret.CarNumber = driverInfo.CarNum;
    ret.Name = driverInfo.Name;
    return ret;
  }
  }
}
