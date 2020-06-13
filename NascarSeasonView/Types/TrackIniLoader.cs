using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.Types;

namespace ENG.NR2003.NascarSeasonView.Types
{
  public static class TrackIniLoader
  {
    public static TrackCollection LoadTracksFrom(string path)
    {
      TrackCollection ret = new TrackCollection();

      List<string> inis = GetAllTrackIniFiles(path);
      ret = LoadTracksFromIni(inis);

      return ret;
    }

    private static TrackCollection LoadTracksFromIni(List<string> files)
    {
      TrackCollection ret = new TrackCollection();
      Track t;

      foreach (var item in files)
      {
        t = LoadTrackFromIni(item);
        ret.Add(t);
      }

      return ret;
    }

    private static Track LoadTrackFromIni(string item)
    {
      TrackIniFile tif = LoadTrackIniFile(item);
      Track ret = new Track();

      ret.IniFileFolder = System.IO.Path.GetDirectoryName(item);

      ret.Name = tif.GetFirst("track_name_short");
      ret.City = tif.GetFirst("track_city");
      ret.State = tif.GetFirst("track_state");
      string pom = tif.GetFirst("track_length");
      pom = pom.Substring(0, pom.Length - 1);
      //TODO převést mile na ft?
      var culture = GetUsCulture();
      double len;
      try
      {
        len = double.Parse(pom, culture);
        ret.LengthInMiles = len;
      }
      catch
      {
        string p = null;

        while (string.IsNullOrWhiteSpace(p))
        {
          p = Microsoft.VisualBasic.Interaction.InputBox(
            "Track - " + ret.Name + " (" + ret.City + ", " + ret.State + ") :: " +
            "Unable to get length from " + pom + ". Enter track length in feet:", "Enter track length...", "1000");
        }

        len = int.Parse(p);
        ret.LengthInFeet = (int)len;
      }

      ret.AdjustedLengthInFeet = ret.LengthInFeet;

      return ret;
    }

    public static TrackIniFile LoadTrackIniFile(string fileName)
    {
      TrackIniFile ret = new TrackIniFile();

      ret.FileName = fileName;

      string[] lines = System.IO.File.ReadAllLines(fileName);
      string[] spl;
      string p;
      string currentBlock = null;

      foreach (var line in lines)
      {
        if (string.IsNullOrWhiteSpace(line)) continue;

        // cut comments
        spl = line.Split(';');
        p = spl[0];

        // is block?
        if (p.Trim().StartsWith("[") && p.Trim().EndsWith("]"))
          currentBlock = p.Substring(1, p.Length - 2).Trim();
        else
        {
          if (currentBlock == null) continue;
          if (string.IsNullOrWhiteSpace(p)) continue;

          spl = p.Split('=');

          if (spl.Length != 2) continue;
          ret.Add(
            currentBlock, spl[0].Trim(), spl[1].Trim());
        }
      }

      return ret;
    }

    private static System.Globalization.CultureInfo GetUsCulture()
    {
      return System.Globalization.CultureInfo.GetCultureInfo("en-US");
    }

    private static string GetLineValue(string[] lines, string p)
    {
      foreach (var item in lines)
      {
        int index = item.IndexOf("=");
        if (index < 0) continue;
        string prefix = item.Substring(0, index).Trim();
        if (prefix == p)
        {
          string ret = item.Substring(index + 1).Trim();
          return ret;
        }
      }

      return null;
    }

    private static List<string> GetAllTrackIniFiles(string path)
    {
      List<string> ret = new List<string>();
      string ini;
      var subPaths = System.IO.Directory.GetDirectories(path);

      foreach (var item in subPaths)
      {
        ini = System.IO.Path.Combine(item, "track.ini");
        if (System.IO.File.Exists(ini))
          ret.Add(ini);
      }

      return ret;
    }
  }
}
