using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;
using System.Reflection;

namespace ENG.NR2003.NascarSeasonView.Types.Hints
{
  abstract class AbstractHint
  {
    private const int USER_DRIVER_CARIDX = 0;

    public abstract string Name { get; }
    public abstract string[] Evaluate(Weekend weekend);

    public static AbstractHint[] GetAllDefinedUsingReflection()
    {
      Assembly a = Assembly.GetExecutingAssembly();
      Type[] ts = a.GetTypes();
      List<AbstractHint> hts = new List<AbstractHint>();
      foreach (var item in ts)
      {
        if (typeof(AbstractHint).IsAssignableFrom(item) && item != typeof(AbstractHint))
        {
          AbstractHint instance = (AbstractHint) Activator.CreateInstance(item);
          hts.Add(instance);
        }
      }

      return hts.ToArray();
    }

    protected static Driver TryGetUserDriver(Weekend weekend)
    {
      Driver ret = weekend.Drivers[USER_DRIVER_CARIDX];
      return ret;
    }
  }
}
