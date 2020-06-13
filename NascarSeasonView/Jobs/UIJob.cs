using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENG.NR2003.NascarSeasonView.Forms;

namespace ENG.NR2003.NascarSeasonView.Jobs
{
  public abstract class UIJob
  {
    public struct UIJobResult
    {
      public enum eUIJobResult
      {
        OK,
        CanceledByUser,
        Exception
      }

      public readonly eUIJobResult JobResult;
      public readonly Exception Exception;

      public UIJobResult(eUIJobResult result)
      {
        if (result == eUIJobResult.Exception) 
          throw new ArgumentException("If result is exception, use constructor with exception parameter.");

        JobResult = result;
        Exception = null;
      }
      public UIJobResult (Exception exception){
      if (exception == null)
        throw new ArgumentNullException ("Exception cannot be null. Use different constructor if necessary.");

      JobResult = eUIJobResult.Exception;
      Exception = exception;
    }
    }

    public bool IsBusy { get; private set; }
    public delegate void FinishedDelegate (UIJobResult result);

    public void Do()
    {
      this.Do("", null, null);
    }

    public void Do(string progressText, int? maximumOrNullForMarquee, FinishedDelegate methodCalledAfterFinish)
    {
      IsBusy = true;

      ShowProgressForm(progressText, maximumOrNullForMarquee);

      StartDoInThread();

      HideProgressForm();

      IsBusy = false;
      if (methodCalledAfterFinish != null)
        methodCalledAfterFinish( new UIJobResult( UIJobResult.eUIJobResult.OK));
    }

    private void StartDoInThread()
    {
      System.Threading.ThreadStart ts = new System.Threading.ThreadStart(_Do);

      System.Threading.Thread t = new System.Threading.Thread(ts);

      t.Start();

      while (t.IsAlive)
        System.Windows.Forms.Application.DoEvents();
    }

    protected abstract void _Do();

    #region Progress form

    private FrmProgress frm = new FrmProgress();

    private void ShowProgressForm(string progressText, int? maximumOrNullForMarquee)
    {
      UpdateProgressInfo(progressText);
      UpdateProgressMaximumOrMarqueeAndReset(maximumOrNullForMarquee);

      frm.Show();

      System.Windows.Forms.Application.DoEvents();
    }

    private void HideProgressForm ()
    {
      frm.Hide();
    }

    protected void UpdateProgressInfo(string text)
    {
      frm.SetLabelinfoText(text);
    }

    protected void UpdateProgressValue(int value)
    {
      frm.SetProgressBarValue(value);
    }

    protected void UpdateProgressMaximumOrMarqueeAndReset(int? maximumOrNull)
    {
      if (maximumOrNull == null)
      {
        frm.SetProgressBarStyle(System.Windows.Forms.ProgressBarStyle.Marquee);
      }
      else
      {
        frm.SetProgressBarStyle(System.Windows.Forms.ProgressBarStyle.Blocks);
        frm.SetProgressBarMaximum(maximumOrNull.Value);
      }
    }

    #endregion Progress form

  }
}
