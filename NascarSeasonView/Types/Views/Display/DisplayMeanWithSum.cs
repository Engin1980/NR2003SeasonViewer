using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.NascarSeasonView.Types.Views.Display
{
  class DisplayMeanWithSum : IComparable, IComparable<DisplayMeanWithSum>
  {
    public double Sum { get; set; }
    public double Mean { get; set; }

    public DisplayMeanWithSum(double sum, double mean)
    {
      this.Sum = sum;
      this.Mean = mean;
    }

    public override string ToString()
    {
      return
        string.Format("{0} ({1})",
        this.Mean,
        this.Sum);
    }

    public int CompareTo(DisplayMeanWithSum other)
    {
      return -(this.Mean.CompareTo(other.Mean));
    }

    public int CompareTo(object obj)
    {
      if (obj is DisplayMeanWithSum)
        return this.CompareTo((DisplayMeanWithSum)obj);
      else
        return -1;
    }
  }
}
