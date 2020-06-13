using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.StaticRaceWeekend.Sessions.Support
{
  [Serializable()]
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
  sealed class StatsObjectAttribute : Attribute
  {
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private string _Title = "";
    ///<summary>
    /// Sets/gets Title value. Default value is "".
    ///</summary>
    public string Title
    {
      get
      {
        return (_Title);
      }
      private set
      {
        _Title = value;
      }
    }
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private bool _ExpandMemberNameToTitle = false;
    ///<summary>
    /// Sets/gets ExpandMemberNameToTitle value. Default value is false.
    ///</summary>
    public bool ExpandMemberNameToTitle
    {
      get
      {
        return (_ExpandMemberNameToTitle);
      }
      private set
      {
        _ExpandMemberNameToTitle = value;
      }
    }


    public StatsObjectAttribute(bool expandMemberName = false)
    {
      this.ExpandMemberNameToTitle = expandMemberName;
    }
    public StatsObjectAttribute(string title)
    {
      //Contract.Requires(string.IsNullOrEmpty(title) == false);

      this.Title = title;
    }

    public static string ExpandMemberName(string memberName)
    {
      StringBuilder ret = new StringBuilder();

      for (int i = 0; i < memberName.Length; i++)
      {
        if (i == 0)
          ret.Append(char.ToUpper(memberName[i]));
        else if (char.IsUpper(memberName[i]))
        {
          ret.Append(" ");
          ret.Append(char.ToLower(memberName[i]));
        }
        else
          ret.Append(memberName[i]);
      }

      return ret.ToString();
    }

  }

}
