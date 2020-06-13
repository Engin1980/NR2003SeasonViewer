using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;

namespace ENG.NR2003.NascarSeasonView.Types.Hints
{
  class QualifyTimeHint : AbstractHint
  {
    public override string Name
    {
      get { return "Qualify times"; }
    }

    public override string[] Evaluate(Weekend weekend)
    {
      List<string> ret = new List<string>();

      if (weekend.Qualify.IsEmpty())
        ret.Add("This hint can be calculated only for qualify is taken.");
      else
      {
        Driver user = TryGetUserDriver(weekend);
        if (user == null)
          ret.Add("User driver not found.");
        else
        {
          Meaner dm = new Meaner();
          Meaner am = new Meaner();

          foreach (var item in weekend.Qualify.Laps.GetAll())
          {
            if (item.Driver == user)
              dm.Add(item.Time.TotalMiliseconds);
            else
              am.Add(item.Time.TotalMiliseconds);
          }

          ret.Add("Your mean qualify time is: " + new Time((int)dm.Mean));
          ret.Add("AI mean qualify time is: " + new Time((int)am.Mean));
          ret.Add("");
          ret.Add("Your best time is: " + weekend.Qualify.Positions[user].Time);
          ret.Add("AI best time is: " + weekend.Qualify.Positions[0].Time);
        }
      }

      return ret.ToArray();
    }
  }
}
