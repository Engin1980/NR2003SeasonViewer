using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.NascarSeasonView.Types.Views
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  public class DisplayAttribute : Attribute
  {
    public string DisplayText { get; private set; }
    public string ToolTipText { get; private set; }
    public int? DisplayIndex { get; private set; }
    public bool IsHidden { get; private set; }

    public DisplayAttribute(string displayText, string toolTipText)
    {
      this.ToolTipText = toolTipText;
      this.DisplayIndex = null;
      this.DisplayText = displayText;
      this.IsHidden = false;
    }

    public DisplayAttribute(string displayText)
    {
      this.DisplayIndex = null;
      this.DisplayText = displayText;
      this.IsHidden = false;
    }

    public DisplayAttribute(int displayIndex)
    {
      this.DisplayIndex = displayIndex;
      this.IsHidden = false;
      this.DisplayText = null;
    }

    public DisplayAttribute(int displayIndex, string displayText)      
    {
      this.DisplayText = displayText;
      this.DisplayIndex = displayIndex;
      this.IsHidden = false;
    }

    public DisplayAttribute(int displayIndex, string displayText, string toolTipText)
    {
      this.ToolTipText = toolTipText;
      this.DisplayText = displayText;
      this.DisplayIndex = displayIndex;
      this.IsHidden = false;
    }

    public DisplayAttribute(bool isHidden)
    {
      this.IsHidden = isHidden;
      this.DisplayText = null;
      this.DisplayIndex = null;
    }
  }
}
