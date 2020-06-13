using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;

namespace ENG.NR2003.NascarSeasonView.Types.Hints
{
  class PitTimeHint : AbstractHint
  {

    public override string Name
    {
      get { return "Mean pit time"; }
    }

    public override string[] Evaluate(Weekend weekend)
    {
      List<string> ret = new List<string>();

      if (weekend.Race.IsEmpty())
      {
        ret.Add("This hint is evaluated only for if race has been taken.");
      }
      else
      {
        Driver user = AbstractHint.TryGetUserDriver(weekend);
        if (user == null)
        {
          ret.Add("Cannot recognize user driver.");
        }
        else
        {

          Meaner mD = new Meaner();
          Meaner mA = new Meaner();

          foreach (Driver d in weekend.Drivers.Values)
          {
            foreach (RacePit rp in weekend.Race.PitLaps.Get(d))
            {
              if (weekend.Race.Yellows.IsInYellow(rp.Time))
                continue;

              if (d == user)
                mD.Add(rp.Time.TotalMiliseconds);
              else
                mA.Add(rp.Time.TotalMiliseconds);
            }
          }

          ret.Add("Your medium pit time is : " + new Time((int)mD.Mean));
          ret.Add("AI medium pit time is : " + new Time((int)mA.Mean));
          ret.Add("\t* pit times are taken without yellow laps");
        }
      }

      return ret.ToArray(); ;
    }
  }
}
