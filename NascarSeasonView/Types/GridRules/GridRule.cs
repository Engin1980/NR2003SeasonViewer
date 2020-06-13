using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ENG.NR2003.NascarSeasonView.Types.GridRules
{
  [Serializable()]
  public class GridRule
  {
    public enum eOperator
    {
      Equal,
      Less,
      More,
      Contains
    }

    public string GridTypeName { get; set; }
    public string GridColumnHeaderText { get; set; }
    public string WeekendNameContains { get; set; }
    public string TrackNameContains { get; set; }
    public object Value { get; set; }
    public eOperator Operator { get; set; }
    public SerializableColor Color { get; set; }

    [XmlIgnore]
    public string ColorInHtml
    {
      get
      {
        return Color.ColorInHtml;
      }
      set
      {
        this.Color = new SerializableColor(value);
      }
    }
  }
}
