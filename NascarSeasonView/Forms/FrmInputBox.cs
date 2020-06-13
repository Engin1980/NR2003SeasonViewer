using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ENG.NR2003.NascarSeasonView.Forms
{
  public partial class FrmInputBox : Form
  {
    public FrmInputBox()
    {
      InitializeComponent();
    }

    public static string ShowDialog(string question, string title, string defaultAnswer, Func<string, bool> inputValidator)
    {
      FrmInputBox f = new FrmInputBox();

      f.Text = title;
      f.txtInput.Text = defaultAnswer;
      f.lblQuestion.Text = question;


      f.ShowDialog();

      string ret = f.txtInput.Text;

      while (inputValidator != null && inputValidator(ret) == false)
      {
        MessageBox.Show("You entered invalid value. Press \"Ok\" and enter value again.");
        f.ShowDialog();
        ret = f.txtInput.Text;
      }

      return ret;
    }

    private void FrmInputBox_Load(object sender, EventArgs e)
    {
      AdjustSize();
    }

    private void AdjustSize()
    {
      System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(this.Handle);
      var size = g.MeasureString(
        lblQuestion.Text, this.Font, lblQuestion.Width);

      this.Height = (int)(size.Height + 106);
    }
  }
}
