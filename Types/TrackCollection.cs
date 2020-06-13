using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  /// <summary>
  /// Represents collection of tracks.
  /// </summary>
  [Serializable()]
  public class TrackCollection : List<Track>
  {
    public new void Add (Track item)
    {
      if (item.IsValid() == false)
        throw new ArgumentException("Cannot add track. It is not valid.");

      base.Add(item);
    }

    public new void Insert(int index, Track item)
    {
      if (item.IsValid() == false)
        throw new ArgumentException("Cannot add track. It is not valid.");

      base.Insert(index,item);
    }

    public void AddRange<T>(List<T> tracks) where T : Track
    {
      foreach (var item in tracks)
      {
        this.Add(item);
      }
    }
  }
}
