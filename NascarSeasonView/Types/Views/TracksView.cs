using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;

namespace ENG.NR2003.NascarSeasonView.Types.Views
{
  internal class TracksView : IView<TracksViewItem>
  {
    private List<TracksViewItem> inner = new List<TracksViewItem>();

    public TracksView(TrackCollection tracks)
    {
      foreach (var item in tracks)
      {
        TracksViewItem i = new TracksViewItem();
        i.AdjustedLengthInFeet = item.AdjustedLengthInFeet;
        i.City = item.City;
        i.LengthInFeet = item.LengthInFeet;
        i.LengthInMiles = item.LengthInMiles;
        i.Name = item.Name;
        i.State = item.State;

        inner.Add(i);
      }
    }


    public List<TracksViewItem> GetAll()
    {
      return inner;
    }
  }
}
