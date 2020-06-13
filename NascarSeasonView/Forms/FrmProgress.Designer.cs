namespace ENG.NR2003.NascarSeasonView.Forms
{
  partial class FrmProgress
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.prgBar = new System.Windows.Forms.ProgressBar();
      this.txtOut = new ESystem.Forms.OutputTextBox();
      this.SuspendLayout();
      // 
      // prgBar
      // 
      this.prgBar.Location = new System.Drawing.Point(17, 13);
      this.prgBar.Name = "prgBar";
      this.prgBar.Size = new System.Drawing.Size(659, 27);
      this.prgBar.TabIndex = 0;
      // 
      // txtOut
      // 
      this.txtOut.AutoNewLine = true;
      this.txtOut.AutoScroll = true;
      this.txtOut.AutoScrollCarret = true;
      this.txtOut.AutoTime = false;
      this.txtOut.AutoTimeSeparator = " ";
      this.txtOut.Location = new System.Drawing.Point(17, 47);
      this.txtOut.Name = "txtOut";
      this.txtOut.ReadOnly = false;
      this.txtOut.Size = new System.Drawing.Size(659, 282);
      this.txtOut.TabIndex = 1;
      // 
      // FrmProgress
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(691, 341);
      this.Controls.Add(this.txtOut);
      this.Controls.Add(this.prgBar);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FrmProgress";
      this.Text = "FrmProgress";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ProgressBar prgBar;
    private ESystem.Forms.OutputTextBox txtOut;
  }
}