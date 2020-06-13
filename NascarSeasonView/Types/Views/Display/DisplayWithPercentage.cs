using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.NascarSeasonView.Types.Views.Display
{
  class DisplayWithPercentage : IComparable, IComparable<DisplayWithPercentage>
  {
    public static string Format = "0.00%";

    public int Value { get; set; }
    public int Total { get; set; }
    public double Percentage { get { return (Value / (double) Total); } }

    public DisplayWithPercentage(int value, int total)
    {
      this.Value = value;
      this.Total = total;
    }

    public override string ToString()
    {
      if (Total == 0) return "";
      else
        return string.Format("{0} ({1})",
          this.Value,
          this.Percentage.ToString(Format));
    }

    public int CompareTo(DisplayWithPercentage other)
    {
      return -(this.Value.CompareTo(other.Value));
    }

    public int CompareTo(object obj)
    {
      if (obj is DisplayWithPercentage)
        return this.CompareTo((DisplayWithPercentage)obj);
      else
        return -1;
    }
  }
}
