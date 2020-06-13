using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarSeasonView.Types.Cups
{
  class CupRace
  {
    public string Name { get; set; }
    public string TrackDirectory { get; set; }
    public int NumberOfLaps { get; set; }

    public override string ToString()
    {
      return Name + " (" + TrackDirectory + ")";
    }
  }
}
