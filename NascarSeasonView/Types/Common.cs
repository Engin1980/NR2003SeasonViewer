using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using NascarSeasonView.Types.Cups;

namespace ENG.NR2003.NascarSeasonView.Types
{
  static class Common
  {
    public static string TryGetNR2003Path()
    {
      string ret = null;
      Microsoft.Win32.RegistryHive mainHive = Microsoft.Win32.RegistryHive.LocalMachine;
      string subkeyName = @"SOFTWARE\Papyrus\NASCAR Racing 2003 Season";
      string valueName = "Directory";
      RegistryKey key = null;


      try
      {
        key = RegistryKey.OpenRemoteBaseKey(mainHive, "");
        key = key.OpenSubKey(subkeyName);
        object value = key.GetValue(valueName);

        ret = (string)value;
      }
      catch (Exception)
      {
        ret = null;
      } // end catch
      

      return ret;
    }

    public static Cup LoadCupFromIniFile()
    {
      string fileName = Dialogs.GetOpenCupIniFile();
      if (fileName == null)
        return null;

      Cup ret = Cup.Load(fileName);

      return ret;
    }
  }
}
