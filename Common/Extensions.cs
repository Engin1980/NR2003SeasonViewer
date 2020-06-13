using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  public static class Extensions
  {
    public static string ToDisplay (this Enum enumValue)
    {
      string ret = enumValue.ToDisplay(null);
      return ret;
    }
    public static string ToDisplay (this Enum enumValue, string id = "")
    {
      string ret = null;

      if (id == null) id = "";

      Type t = enumValue.GetType();
      System.Reflection.FieldInfo fi = t.GetField(enumValue.ToString());
      object [] o = fi.GetCustomAttributes(typeof(DisplayTextAttribute), false);
      if (o.Length == 0)
        ret = enumValue.ToString();
      else
      {
        // hleda se nejlepsi podle ID
        DisplayTextAttribute sta = null;
        foreach (DisplayTextAttribute item in o)
          if (item.Id == id)
          {
            sta = (DisplayTextAttribute) item;
            break;
          }

        if (sta == null)
          sta = (DisplayTextAttribute) o[0];

        ret = sta.Text;
      }

      return ret;
    }

    public static void CloneFieldsTo(this object source, object target, List<string> excuse = null, bool cloneCloneable = true)
    {
      if (excuse == null) excuse = new List<string>();
      System.Reflection.BindingFlags flgs = 
        System.Reflection.BindingFlags.NonPublic | 
        System.Reflection.BindingFlags.Instance | 
        System.Reflection.BindingFlags.GetField | 
        System.Reflection.BindingFlags.SetField;

      Type sourceType = source.GetType();
      Type targetType = target.GetType();

      System.Reflection.MemberInfo[] fis = 
        sourceType.GetFields(flgs);

      System.Reflection.FieldInfo fi = null;

      foreach (System.Reflection.FieldInfo item in fis)
      {
        string name = item.Name;
        if (excuse.Contains(name)) continue;

        fi = targetType.GetField(name, flgs);
        if (fi == null) continue;
        if (fi.FieldType.Equals(item.FieldType) == false) continue;

        if (cloneCloneable && fi.FieldType.GetInterface("ICloneable") != null)
        {
          object value = item.GetValue(source);
          value = fi.FieldType.InvokeMember(
            "Clone", 
            System.Reflection.BindingFlags.Public | 
            System.Reflection.BindingFlags.Instance | 
            System.Reflection.BindingFlags.InvokeMethod, 
            null, value, new object[] { });
          fi.SetValue(target, value);
        }
        else
        {
          object value = item.GetValue(source);
          fi.SetValue(target, value);
        }
      }
    }
  }
}
