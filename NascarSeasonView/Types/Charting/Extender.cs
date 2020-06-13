using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ENG.NR2003.NascarSeasonView.Types.Charting
{
    class Extender
    {
        public static void Build(
            System.Collections.IEnumerable datas,
            string [] seriesValueFilter,
            PropertyInfo serieSelector,
            PropertyInfo xSelector,
            PropertyInfo ySelector,            
            System.Windows.Forms.DataVisualization.Charting.Chart chart,
            System.Windows.Forms.DataVisualization.Charting.SeriesChartType chartType
            )
        {
            Serie[] data = CreateChartData(datas, serieSelector, seriesValueFilter, xSelector, ySelector);

            AdjustChart(chart, data, chartType);
        }

        private static void AdjustChart(System.Windows.Forms.DataVisualization.Charting.Chart chart, Serie[] data, System.Windows.Forms.DataVisualization.Charting.SeriesChartType chartType)
        {
            chart.SuspendLayout();

            chart.Series.Clear();

            foreach (var item in chart.ChartAreas)
            {
                item.AxisX.IsStartedFromZero = false;
                item.AxisY.IsStartedFromZero = false;
            }

            foreach (var item in data)
            {
                var ns = chart.Series.Add(item.Name.ToString());
                ns.ChartType = chartType;

                foreach (var point in item.Points)
                {
                  if (point.Y is ENG.NR2003.Types.RaceGap)
                    ns.Points.AddXY(point.X, (point.Y as ENG.NR2003.Types.RaceGap).Time.TotalMiliseconds);
                  else
                    ns.Points.AddXY(point.X, point.Y);
                }
            }

            chart.ResumeLayout();
        }

        private static Serie[] CreateChartData(
            System.Collections.IEnumerable datas, 
            PropertyInfo serieSelector, string [] seriesValueFilter,
            PropertyInfo xSelector, PropertyInfo ySelector)
        {
            Dictionary<object, Serie> dct = new Dictionary<object, Serie>();
            Serie serie;
            object s;
            object x;
            object y;
            
            foreach (var item in datas)
            {
                if (serieSelector == null)
                    s = 0;
                else
                    s = serieSelector.GetValue(item, null);

                if (seriesValueFilter != null && seriesValueFilter.Length > 0 && seriesValueFilter.Contains(s.ToString()) == false) continue;

                x = xSelector.GetValue(item, null);
                y = ySelector.GetValue(item, null);

                if (dct.ContainsKey(s) == false)
                    dct.Add(s, new Serie() { Name = s });

                serie = dct[s];
                serie.Points.Add(new Point() { X = x, Y = y });
            }

            List<Serie> ret = new List<Serie>();
            foreach (var item in dct.Keys)
            {
                ret.Add(dct[item]);
            }
            return ret.ToArray();
        }
    }
}
