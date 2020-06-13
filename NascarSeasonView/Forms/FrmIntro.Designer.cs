namespace ENG.NR2003.NascarSeasonView.Forms
{
  partial class FrmIntro
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
      this.btnNewSeason = new System.Windows.Forms.Button();
      this.btnOpenSeason = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnNewSeason
      // 
      this.btnNewSeason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnNewSeason.Location = new System.Drawing.Point(12, 12);
      this.btnNewSeason.Name = "btnNewSeason";
      this.btnNewSeason.Size = new System.Drawing.Size(463, 45);
      this.btnNewSeason.TabIndex = 0;
      this.btnNewSeason.Text = "&New season";
      this.btnNewSeason.UseVisualStyleBackColor = true;
      this.btnNewSeason.Click += new System.EventHandler(this.btnNewSeason_Click);
      // 
      // btnOpenSeason
      // 
      this.btnOpenSeason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOpenSeason.Location = new System.Drawing.Point(12, 63);
      this.btnOpenSeason.Name = "btnOpenSeason";
      this.btnOpenSeason.Size = new System.Drawing.Size(463, 45);
      this.btnOpenSeason.TabIndex = 1;
      this.btnOpenSeason.Text = "&Open season";
      this.btnOpenSeason.UseVisualStyleBackColor = true;
      this.btnOpenSeason.Click += new System.EventHandler(this.btnOpenSeason_Click);
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.Location = new System.Drawing.Point(12, 141);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(463, 45);
      this.btnClose.TabIndex = 2;
      this.btnClose.Text = "&Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // FrmIntro
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(487, 197);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnOpenSeason);
      this.Controls.Add(this.btnNewSeason);
      this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.Name = "FrmIntro";
      this.Text = "FrmIntro";
      this.Load += new System.EventHandler(this.FrmIntro_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnNewSeason;
    private System.Windows.Forms.Button btnOpenSeason;
    private System.Windows.Forms.Button btnClose;
  }
}