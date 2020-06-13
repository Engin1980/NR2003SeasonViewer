using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.NascarSeasonView.Forms
{
  public class ListItem
  {
    public object Value { get; set; }
    public string Text { get; set; }

    public ListItem(object value, string text)
    {
      this.Value = value;
      this.Text = text;
    }

    public override string ToString()
    {
      return this.Text;
    }
  }
}
