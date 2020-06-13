using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENG.NR2003.Types;
using ENG.NR2003.NascarSeasonView.Types.Views;

namespace ENG.NR2003.NascarSeasonView.Forms
{
  public partial class FrmTrackList : Form
  {
    public FrmTrackList()
    {
      InitializeComponent();
    }

    public void Init(TrackCollection tracks)
    {
      TracksView  tv = new TracksView(tracks);

      Extender.BuildGridForView(grd, tv, false);
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }    
  }
}
