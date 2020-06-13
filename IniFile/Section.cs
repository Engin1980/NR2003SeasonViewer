using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.IniFile
{
  public class Section
  {
    private Dictionary<string, string> inner = new Dictionary<string, string>();

    public string this[string key]
    {
      get { 
        return inner[key]; 
      }
      set { inner[key] = value; }
    }
  }
}
