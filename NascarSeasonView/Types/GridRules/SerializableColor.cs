using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ENG.NR2003.NascarSeasonView.Types.GridRules
{
  [Serializable]
  public struct SerializableColor
  {
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
    private System.Drawing.Color _Color;
    ///<summary>
    /// Sets/gets Color value. Default value is default(System.Drawing.Color).
    ///</summary>
    [XmlIgnore]
    public System.Drawing.Color Color
    {
      get
      {
        return (_Color);
      }
      set
      {
        _Color = value;
      }
    }

    public SerializableColor(System.Drawing.Color color)
    {
      this._Color = color;
    }

    public SerializableColor(string colorInHtml)
    {
      this._Color = System.Drawing.ColorTranslator.FromHtml(colorInHtml);
    }

    [XmlAttribute]
    public string ColorInHtml
    {
      get
      {
        return System.Drawing.ColorTranslator.ToHtml(this.Color);
      }
      set
      {
        this.Color = System.Drawing.ColorTranslator.FromHtml(value);
      }
    }

    public static implicit operator System.Drawing.Color(SerializableColor color)
    {
      return color.Color;
    }
    public static implicit operator SerializableColor(System.Drawing.Color color)
    {
      return new SerializableColor(color);
    }
  }
}
