using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.IniFile;

namespace NascarSeasonView.Types.Cups
{
  class Cup
  {
    public CupRace[] Races { get; set; }

    public static Cup Load(string fileName)
    {
      Cup ret = new Cup();

      IniFile iniFile = IniFile.Load(fileName);

      int racesCount = int.Parse(iniFile["Season"]["numEvents"]);

      ret.Races = new CupRace[racesCount];
      for (int i = 0; i < racesCount; i++)
      {
        string eventKey = "Event" + (i+1).ToString();
        var block = iniFile[eventKey];
        CupRace cr = new CupRace();

        cr.Name = block["name"];
        cr.NumberOfLaps = int.Parse(block["numberOfLaps"]);
        cr.TrackDirectory = block["trackDirectory"];

        ret.Races[i] = cr;
      }

      return ret;
    }
  }

}
