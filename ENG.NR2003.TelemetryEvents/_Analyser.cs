using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics.Contracts;

namespace ENG.NR2003.TelemetryEvents
{
  internal static class Analyser
  {
    private static void GetTypeEventNameAndParametersForLine(string line, out string typeString, out string[] pars)
    {
      int openingBracketIndex = line.IndexOf("{");
      int closingBracket = line.LastIndexOf("}");

      typeString = line.Substring(0, openingBracketIndex);

      string inner = line.Substring(openingBracketIndex + 1, closingBracket - openingBracketIndex - 1);

      pars = SplitItems(inner);
    }

    internal static double DblParse(string value)
    {
      return double.Parse(value, System.Globalization.CultureInfo.GetCultureInfo("en-us"));
    }

    private static string[] SplitItems(string inner)
    {
      List<string> ret = new List<string>();

      int level = 0;

      for (int i = 0; i < inner.Length; i++)
      {
        if (inner[i] == '{')
          level++;
        else if (inner[i] == '}')
          level--;
        else if (inner[i] == ';' && level == 0)
        {
          string pom = inner.Substring(0, i);
          ret.Add(pom);
          inner = inner.Substring(i + 1);
          i = -1;
        }
      }

      ret.Add(inner);

      return ret.ToArray();
    }

    internal static TelemetryEvent DecodeLine(string p)
    {
      Contract.Requires(string.IsNullOrEmpty(p) == false, "Input string cannot be empty.");

      TelemetryEvent ret = null;
      string t;
      string[] pars;

      GetTypeEventNameAndParametersForLine(p, out t, out pars);
      Type eventType = GetTypeForEvent(t);
      ret = CreateInstanceForEvent(eventType, pars);      

      return ret;
    }

    private static TelemetryEvent CreateInstanceForEvent(Type eventType, string[] pars)
    {
      TelemetryEvent ret = null;
      ret =
            Activator.CreateInstance(eventType, new object[] { pars }) as TelemetryEvent;
      return ret;
    }

    private static Type GetTypeForEvent(string t)
    {
      Type ret = null;

      foreach (Type fItem in EventTypes)
      {
        if (fItem.Name.ToLower() == t.ToLower())
        {
          ret = fItem;
          break;
        }
      } // foreach (var fItem in GetIItemTypes)

      return ret;
    }

    static Analyser ()
    {
      EventTypes = GetIItemTypes();
    }

    private readonly static Type[] EventTypes = null;
    private static Type[] GetIItemTypes()
    {
        List<Type> ret = new List<Type>();
        Assembly a = Assembly.GetExecutingAssembly();
        Type telemetryEventParent = typeof(ENG.NR2003.TelemetryEvents.TelemetryEvent);

        foreach (var fItem in a.GetTypes())
        {
          if (fItem.IsSubclassOf(telemetryEventParent))
            ret.Add(fItem);
        } // foreach (var fItem in a.GetTypes())

        return ret.ToArray();
      }
    }
  }
