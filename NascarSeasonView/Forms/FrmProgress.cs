using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics.Contracts;

namespace ENG.NR2003.NascarSeasonView.Forms
{
  public partial class FrmProgress : Form
  {
    #region Static

    private const string DEFAULT_MESSAGE = "Work in progress, please wait...";
    public FrmProgress()
    {
      InitializeComponent();
    }

    public static void StartProgress()
    {
      StartProgress(DEFAULT_MESSAGE);
    }
    public static void StartProgress (string text)
    {
      SetProgressBarStyleStatic(ProgressBarStyle.Marquee);
      SetFrmProgressVisibilityStatic(true);
    }
    public static void StartProgress (string text, int maxValue)
    {
      SetProgressBarStyleStatic(ProgressBarStyle.Blocks);
      SetProgressBarMaximumStatic(maxValue);
      SetLabelInfoTextStatic(text);
      SetFrmProgressVisibilityStatic(true);
    }
    public static void StartProgress(int maxValue)
    {
      StartProgress(DEFAULT_MESSAGE, maxValue);
    }

    public static void StopProgress (){
      SetFrmProgressVisibilityStatic(false);
    }
    #endregion Static

    #region Private Static

    private static void SetProgressBarStyleStatic(ProgressBarStyle value)
    {
      var inst = Instance;
      inst.SetProgressBarStyle(value);
    }
    private static void SetProgressBarMaximumStatic (int value)
    {
      var i = Instance;
      i.SetProgressBarMaximum(value);
    }
    private static void SetProgressBarValueStatic(int value)
    {
      var i = Instance;
      i.SetProgressBarValue(value);
    }
    private static void SetLabelInfoTextStatic(string value)
    {
      var i = Instance;
      i.SetLabelinfoText(value);
    }
    private static void SetFrmProgressVisibilityStatic(bool value)
    {
      var i = Instance;
      i.SetFrmProgressVisibility(value);
    }

    #endregion Private Static

    #region Singleton

    private static FrmProgress _____instance = null;

    private static FrmProgress Instance
    {
      get
      {
        if (_____instance == null)
        {
          StartThreadCreatingInstance();
        }

        Contract.Ensures(_____instance != null);

        return _____instance;
      }
    }

    //private FrmProgress()
    //{
    //  lblInfo.Text = DEFAULT_MESSAGE;
    //}

    private static void CreateInstance()
    {
      _____instance = new FrmProgress();
    }

    private static void StartThreadCreatingInstance()
    {
      System.Threading.ThreadStart ts = new System.Threading.ThreadStart(FrmProgress.CreateInstance);

      System.Threading.Thread t = new System.Threading.Thread(ts);

      t.Start();

      while (_____instance == null) { Application.DoEvents(); }

    }

    #endregion Singleton

    #region Multithreading methods

    public void SetProgressBarStyle(ProgressBarStyle value)
    {
      if (prgBar.InvokeRequired)
        prgBar.Invoke(
          new Action<ProgressBarStyle> (x => SetProgressBarStyle(x)),
          new object[]{value});
      else
        prgBar.Style = value;
    }

    public void SetProgressBarMaximum(int value)
    {
      if (prgBar.InvokeRequired)
        prgBar.Invoke(
          new Action<int>(x => SetProgressBarMaximum(x)),
          new object[] { value });
      else
      {
        prgBar.Value = prgBar.Minimum;
        prgBar.Maximum = value;
      }
    }

    public void SetProgressBarValue(int value)
    {
      if (prgBar.InvokeRequired)
        prgBar.Invoke(
          new Action<int>(x => SetProgressBarValue(x)),
          new object[] { value });
      else
        prgBar.Value = value;
    }

    public void SetLabelinfoText(string value)
    {
      //if (lblInfo.InvokeRequired)
      //  lblInfo.Invoke(
      //    new Action<string>(x => SetLabelinfoText(x)),
      //    new object[] { value });
      //else
      //  lblInfo.Text = value;
    }

    public void SetFrmProgressVisibility(bool value)
    {
      if (this.InvokeRequired)
        this.Invoke(
          new Action<bool>(x => SetFrmProgressVisibility(x)),
          new object[] { value });
      else
        this.Visible = value;
    }

    #endregion Multithreading methods
  
}
}
