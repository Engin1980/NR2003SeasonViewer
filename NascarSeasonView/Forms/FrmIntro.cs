using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENG.NR2003.Types;
using ENG.NR2003.NascarSeasonView.Types;

namespace ENG.NR2003.NascarSeasonView.Forms
{
  public partial class FrmIntro : Form
  {
    public enum eResult
    {
      None,
      NewSeason,
      OpenSeason,      
    }
    private eResult eresult = eResult.None;
    public eResult EResult { get { return eresult; } }

    public FrmIntro()
    {
      InitializeComponent();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.eresult = eResult.None;
      this.Close();
    }

    private void btnNewSeason_Click(object sender, EventArgs e)
    {
      this.eresult = eResult.NewSeason;
      this.Close();
          }

    private void FrmIntro_Load(object sender, EventArgs e)
    {
      this.eresult = eResult.None;
    }

    private void btnOpenSeason_Click(object sender, EventArgs e)
    {
      this.eresult = eResult.OpenSeason;
      this.Close();
    }
  }
}
