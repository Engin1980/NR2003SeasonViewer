using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.NascarSeasonView.Types.Views
{
  class TracksViewItem
  {
    [Display(0)]
    public string Name { get; set; }
    [Display(1)]
    public string City { get; set; }
    [Display(2)]
    public string State { get; set; }
    [Display(3,"Length (mi)")]
    public double LengthInMiles { get; set; }
    [Display(4,"Length (ft)")]
    public int LengthInFeet { get; set; }
    [Display(5,"Adjusted length (ft)")]
    public int AdjustedLengthInFeet { get; set; }
  }
}
