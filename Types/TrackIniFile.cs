using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.Types
{
  [Serializable]
  public class TrackIniFile
  {
    public string FileName { get; set; }
    private Dictionary<string,Dictionary<string, string>> _Content { get; set; }

    public TrackIniFile()
    {
      _Content = new Dictionary<string, Dictionary<string, string>>();
    }

    public void Add(string block, string key, string value)
    {
      if (_Content.ContainsKey(block) == false)
        _Content.Add(block, new Dictionary<string, string>());

      _Content[block][key] = value;
    }

    public string Get(string block, string key)
    {
      return _Content[block][key];
    }

    public Dictionary<string, string> Get(string block)
    {
      return _Content[block];
    }

    public string GetFirst(string key)
    {
      foreach (var block in _Content.Keys)
      {
        if (_Content[block].ContainsKey(key))
          return _Content[block][key];
      }

      return null;
    }
  }
}
