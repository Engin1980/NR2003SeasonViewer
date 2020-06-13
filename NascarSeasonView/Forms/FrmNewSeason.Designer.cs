namespace ENG.NR2003.NascarSeasonView.Forms
{
  partial class FrmNewSeason
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewSeason));
      this.txtSeasonName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cmbScoring = new System.Windows.Forms.ComboBox();
      this.lblScoring = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.fbdTracks = new ESystem.Forms.FolderBrowser();
      this.label3 = new System.Windows.Forms.Label();
      this.btnCreate = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // txtSeasonName
      // 
      this.txtSeasonName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSeasonName.Location = new System.Drawing.Point(133, 9);
      this.txtSeasonName.Name = "txtSeasonName";
      this.txtSeasonName.Size = new System.Drawing.Size(503, 23);
      this.txtSeasonName.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(102, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Season name:";
      // 
      // cmbScoring
      // 
      this.cmbScoring.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbScoring.FormattingEnabled = true;
      this.cmbScoring.Location = new System.Drawing.Point(133, 38);
      this.cmbScoring.Name = "cmbScoring";
      this.cmbScoring.Size = new System.Drawing.Size(503, 24);
      this.cmbScoring.TabIndex = 2;
      this.cmbScoring.SelectedIndexChanged += new System.EventHandler(this.cmbScoring_SelectedIndexChanged);
      // 
      // lblScoring
      // 
      this.lblScoring.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblScoring.Location = new System.Drawing.Point(133, 65);
      this.lblScoring.Name = "lblScoring";
      this.lblScoring.Size = new System.Drawing.Size(503, 98);
      this.lblScoring.TabIndex = 3;
      this.lblScoring.Text = "---";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 41);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(115, 16);
      this.label2.TabIndex = 4;
      this.label2.Text = "Scoring system:";
      // 
      // fbdTracks
      // 
      this.fbdTracks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.fbdTracks.EmptyText = "Select folder of NR2003 tracks or leave empty...";
      this.fbdTracks.FolderName = "";
      this.fbdTracks.Location = new System.Drawing.Point(133, 166);
      this.fbdTracks.Name = "fbdTracks";
      this.fbdTracks.RelativePath = "";
      this.fbdTracks.Size = new System.Drawing.Size(503, 25);
      this.fbdTracks.TabIndex = 5;
      this.fbdTracks.Title = "Select folder with NR2003 tracks";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 175);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(58, 16);
      this.label3.TabIndex = 6;
      this.label3.Text = "Tracks:";
      // 
      // btnCreate
      // 
      this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnCreate.Location = new System.Drawing.Point(549, 197);
      this.btnCreate.Name = "btnCreate";
      this.btnCreate.Size = new System.Drawing.Size(87, 28);
      this.btnCreate.TabIndex = 7;
      this.btnCreate.Text = "&Create";
      this.btnCreate.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(456, 197);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(87, 28);
      this.btnCancel.TabIndex = 8;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // FrmNewSeason
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(648, 239);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnCreate);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.fbdTracks);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.lblScoring);
      this.Controls.Add(this.cmbScoring);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtSeasonName);
      this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "FrmNewSeason";
      this.Text = "New season";
      this.Load += new System.EventHandler(this.FrmNewSeason_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtSeasonName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbScoring;
    private System.Windows.Forms.Label lblScoring;
    private System.Windows.Forms.Label label2;
    private ESystem.Forms.FolderBrowser fbdTracks;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnCreate;
    private System.Windows.Forms.Button btnCancel;
  }
}