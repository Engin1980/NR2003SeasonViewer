using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.NascarSeasonView.Types.Charting
{
    class Serie
    {
        public object Name { get; set; }
        public List<Point> Points = new List<Point>();
    }
}
