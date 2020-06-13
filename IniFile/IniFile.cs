using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.IniFile
{
  public class IniFile
  {
    private Dictionary<string, Section> inner = new Dictionary<string, Section>();

    public Section this[string key]
    {
      get
      {
        if (inner.ContainsKey(key) == false)
          inner[key] = new Section();

        return inner[key];
      }
    }

    public static IniFile Load(string fileName)
    {
      IniFile ret = new IniFile();

      string[] lines = System.IO.File.ReadAllLines(fileName);

      string[] spl;
      string p;
      string currentSectionKey = null;

      foreach (var line in lines)
      {
        if (string.IsNullOrWhiteSpace(line)) continue;

        // cut comments
        spl = line.Split(';');
        p = spl[0];

        // is block?
        if (p.Trim().StartsWith("[") && p.Trim().EndsWith("]"))
          currentSectionKey = p.Substring(1, p.Length - 2).Trim();
        else
        {
          if (currentSectionKey == null) continue;
          if (string.IsNullOrWhiteSpace(p)) continue;

          spl = p.Split('=');

          if (spl.Length != 2) continue;
          var key = spl[0].Trim();
          var val = spl[1].Trim();
          ret[currentSectionKey][key] = val;
        }
      }

      return ret;
    }

    public Dictionary<string, Section>.KeyCollection Keys
    {
      get
      {
        return inner.Keys;
      }
    }
  }
}
