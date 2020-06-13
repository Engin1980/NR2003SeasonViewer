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
  public partial class RaceGridView : UserControl
  {
    public RaceGridView()
    {
      InitializeComponent();
    }
    internal void Init(RaceSessionView rsv)
    {
      Extender.BuildGridForView(grd, rsv, false);
    }

    internal DataGridView GetGrid()
    {
      return this.grd;
    }
  }
}
