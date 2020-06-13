using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;
using ENG.NR2003.NascarSeasonView.Forms;

namespace ENG.NR2003.NascarSeasonView.Types.BOs
{
  static class SeasonWizard
  {
    public static Season RunNewSeasonWizard()
    {
      Season ret = null;

      FrmNewSeason f = new FrmNewSeason();
      f.ShowDialog();
      var res = f.ResultData;
      if (res == null) return null;

      ret = new Season();
      ret.Name = res.SeasonName;
      ret.Scoring = Activator.CreateInstance(res.ScoringType);

      if (res.TracksFolder != "")
      {
        TrackCollection trcks = TrackIniLoader.LoadTracksFrom(res.TracksFolder);
        ret.Tracks.AddRange(trcks);
      }

      return ret;
    }
  }
}
