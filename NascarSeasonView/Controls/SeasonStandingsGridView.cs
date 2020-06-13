using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENG.NR2003.NascarSeasonView.Types.Views;

namespace ENG.NR2003.NascarSeasonView.Controls
{
  public partial class SeasonStandingsGridView : UserControl
  {
    public SeasonStandingsGridView()
    {
      InitializeComponent();
    }

    internal void Init(WeekendStandingsView view)
    {
      Extender.BuildGridForView(grd, view, false);
    }
  }
}
