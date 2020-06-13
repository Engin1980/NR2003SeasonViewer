using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using ENG.NR2003.Types;
using ENG.NR2003.NascarSeasonView.Properties;
using System.IO;

namespace ENG.NR2003.NascarSeasonView.Types
{
  internal static class Dialogs
  {
    private const string INI_FILTER = "Ini file (*.ini)|*.ini|All files (*.*)|*.*";
    private const string RACE_FILTER = "Nascar race (*.nrr)|*.nrr|All files (*.*)|*.*";
    private const string SEASON_FILTER = "Nascar season (*.nrs)|*.nrs|All files (*.*)|*.*";
    private const string PROJECT_FILTER = "Nascar project (*.npr)|*.npr|All files (*.*)|*.*";
    private const string TELEMETRY_FILTER = "Telemetry text file (*.txt)|*.txt|All files (*.*)|*.*";
    private const string GRID_RULES_FILTER = "File with grid rules (*.xml)|*.xml|All files (*.*)|*.*";

    private static Settings Sett { get { return Properties.Settings.Default; } }

    public static string GetOpenTelemetry ()
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = TELEMETRY_FILTER;

      ofd.InitialDirectory = Sett.Path_Telemetry;

      var r = ofd.ShowDialog();

      if (r != DialogResult.OK)
        return null;
      else
      {
        Sett.Path_Telemetry = System.IO.Path.GetDirectoryName(ofd.FileName);
        return ofd.FileName;
      }
    }

    public static string GetOpenGridRules()
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = GRID_RULES_FILTER;

      ofd.InitialDirectory = Sett.Path_GridRules;

      var r = ofd.ShowDialog();

      if (r != DialogResult.OK)
        return null;
      else
      {
        Sett.Path_GridRules = System.IO.Path.GetDirectoryName(ofd.FileName);
        return ofd.FileName;
      }
    }

    public static string GetOpenRace ()
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = RACE_FILTER;
      ofd.InitialDirectory = Sett.Path_Race;

      var r = ofd.ShowDialog();

      if (r != DialogResult.OK)
        return null;
      else
      {
        Sett.Path_Race = System.IO.Path.GetDirectoryName(ofd.FileName);
        return ofd.FileName;
      }
    }

    public static string GetOpenTrackIniFile()
    {
      string ret;

      string nrPath = Common.TryGetNR2003Path();
      if (nrPath != null)
      {
        nrPath = System.IO.Path.Combine(nrPath, "Tracks");
      }

      ret = GetOpenIniFile(nrPath);

      return ret;
    }

    public static string GetOpenCupIniFile()
    {
      string ret;

      string nrPath = Common.TryGetNR2003Path();
      if (nrPath != null)
        nrPath = System.IO.Path.Combine(nrPath, "Series\\Cup");

      ret = GetOpenIniFile(nrPath);

      return ret;
    }

    private static string GetOpenIniFile(string defaultPath)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = INI_FILTER;

      ofd.InitialDirectory = defaultPath;

      var r = ofd.ShowDialog();

      if (r != DialogResult.OK)
        return null;
      else
        return ofd.FileName;
    }

    public static string GetSaveRace (string file)
    {
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Filter = RACE_FILTER;
      sfd.FileName = file;

      var r = sfd.ShowDialog();

      if (r != DialogResult.OK)
        return null;
      else
      {
        Sett.Path_Race = System.IO.Path.GetDirectoryName(file);
        return sfd.FileName;
      }
    }

    public static string GetSaveGridRules()
    {
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Filter = GRID_RULES_FILTER;
      sfd.FileName = "";
      sfd.InitialDirectory = Sett.Path_GridRules;

      var r = sfd.ShowDialog();

      if (r != DialogResult.OK)
        return null;
      else
      {
        Sett.Path_GridRules = System.IO.Path.GetDirectoryName(sfd.FileName);
        return sfd.FileName;
      }
    }

    public static string GetOpenSeason()
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = SEASON_FILTER;
      ofd.InitialDirectory = Sett.Path_Season;

      var r = ofd.ShowDialog();

      if (r != DialogResult.OK)
        return null;
      else
      {
        Sett.Path_Season = System.IO.Path.GetDirectoryName(ofd.FileName);
        return ofd.FileName;
      }
    }

    public static string GetSaveSeason(string file)
    {
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Filter = SEASON_FILTER;
      sfd.FileName = file;

      var r = sfd.ShowDialog();

      if (r != DialogResult.OK)
        return null;
      else
        return sfd.FileName;
    }

    public static void SaveSeason(string fileName, Season season)
    {
      BinaryFormatter bf = new BinaryFormatter();
      using (System.IO.Stream str = new System.IO.FileStream(fileName, System.IO.FileMode.OpenOrCreate))
      {
        bf.Serialize(str, season);
        str.Close();
      }
    }
    public static Season LoadSeason(string fileName)
    {
      BinaryFormatter bf = new BinaryFormatter();
      Season s;
      using (System.IO.Stream str = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
      {
        s = (Season) bf.Deserialize(str);
        str.Close();
      }
      return s;
    }

    public static void SaveWeekend(string fileName, Weekend weekend)
    {
      BinaryFormatter bf = new BinaryFormatter();
      using (System.IO.Stream str = new System.IO.FileStream(fileName, System.IO.FileMode.OpenOrCreate))
      {
        bf.Serialize(str, weekend);
        str.Close();
      }
    }
    public static Weekend LoadWeekend(string fileName)
    {
      BinaryFormatter bf = new BinaryFormatter();
      Weekend w;
      using (System.IO.Stream str = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
      {
        w = (Weekend)bf.Deserialize(str);
        str.Close();
      }
      return w;
    }


    public static void SaveGridRules(string fileName, GridRules.GridRuleCollection rules)
    {
      FileMode mode =
        System.IO.File.Exists(fileName) ? FileMode.Truncate : FileMode.Create;
      using (FileStream fs = new FileStream(fileName, mode))
      {
        System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(
          typeof(GridRules.GridRuleCollection));

        ser.Serialize(fs, rules);
      }
    }

    public static GridRules.GridRuleCollection LoadGridRules(string fileName)
    {
      GridRules.GridRuleCollection ret = null;

      using (FileStream fs = new FileStream(fileName, FileMode.Open))
      {
        System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(
          typeof(GridRules.GridRuleCollection));

        object o = ser.Deserialize(fs);
        ret = (GridRules.GridRuleCollection)o;
      }

      return ret;
    }
  }
}
