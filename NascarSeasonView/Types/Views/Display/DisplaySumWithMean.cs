using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.NascarSeasonView.Types.Views.Display
{
  class DisplaySumWithMean : IComparable, IComparable<DisplaySumWithMean>
  {
    public double Sum { get; set; }
    public double Mean { get; set; }

    public DisplaySumWithMean(double sum, double mean)
    {
      this.Sum = sum;
      this.Mean = mean;
    }

    public override string ToString()
    {
      return
        string.Format("{0} ({1})",
        this.Sum,
        this.Mean);
    }

    public int CompareTo(DisplaySumWithMean other)
    {
      return -(this.Sum.CompareTo(other.Sum));
    }

    public int CompareTo(object obj)
    {
      if (obj is DisplaySumWithMean)
        return this.CompareTo((DisplaySumWithMean)obj);
      else
        return -1;
    }
  }
}
