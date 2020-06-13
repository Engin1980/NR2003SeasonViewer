using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
  [AttributeUsage(AttributeTargets.Field, AllowMultiple=true)]
  public class DisplayTextAttribute : Attribute
  {
    public string Text { get; private set; }
    public string Id { get; private set; }

    public DisplayTextAttribute (string text) : this (text, null)
    {
    }
    public DisplayTextAttribute (string text, string id)
    {
      if (id == null) id = "";
      this.Text = text;
      this.Id = id;
    }
  }
}
