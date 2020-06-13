namespace ENG.NR2003.NascarSeasonView.Forms
{
  partial class FrmNewWeekend
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewWeekend));
      this.cmbRaces = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnFillFromCup = new System.Windows.Forms.Button();
      this.cmbTracks = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.dtpDate = new System.Windows.Forms.DateTimePicker();
      this.label3 = new System.Windows.Forms.Label();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.chkAnalyseIniFile = new System.Windows.Forms.CheckBox();
      this.nudOpponentStrength = new System.Windows.Forms.NumericUpDown();
      this.label4 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.nudOpponentStrength)).BeginInit();
      this.SuspendLayout();
      // 
      // cmbRaces
      // 
      this.cmbRaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbRaces.FormattingEnabled = true;
      this.cmbRaces.Location = new System.Drawing.Point(104, 12);
      this.cmbRaces.Name = "cmbRaces";
      this.cmbRaces.Size = new System.Drawing.Size(597, 24);
      this.cmbRaces.TabIndex = 0;
      this.cmbRaces.SelectedIndexChanged += new System.EventHandler(this.cmbRaces_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(86, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Race name:";
      // 
      // btnFillFromCup
      // 
      this.btnFillFromCup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFillFromCup.Location = new System.Drawing.Point(707, 12);
      this.btnFillFromCup.Name = "btnFillFromCup";
      this.btnFillFromCup.Size = new System.Drawing.Size(55, 23);
      this.btnFillFromCup.TabIndex = 2;
      this.btnFillFromCup.Text = "(+)";
      this.btnFillFromCup.UseVisualStyleBackColor = true;
      this.btnFillFromCup.Click += new System.EventHandler(this.btnFillFromCup_Click);
      // 
      // cmbTracks
      // 
      this.cmbTracks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbTracks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbTracks.FormattingEnabled = true;
      this.cmbTracks.Location = new System.Drawing.Point(104, 42);
      this.cmbTracks.Name = "cmbTracks";
      this.cmbTracks.Size = new System.Drawing.Size(597, 24);
      this.cmbTracks.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 45);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(51, 16);
      this.label2.TabIndex = 4;
      this.label2.Text = "Track:";
      // 
      // dtpDate
      // 
      this.dtpDate.Location = new System.Drawing.Point(104, 72);
      this.dtpDate.Name = "dtpDate";
      this.dtpDate.Size = new System.Drawing.Size(200, 23);
      this.dtpDate.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 75);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(75, 16);
      this.label3.TabIndex = 6;
      this.label3.Text = "Race day:";
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Location = new System.Drawing.Point(681, 154);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 7;
      this.btnOk.Text = "&Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(600, 154);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 8;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // chkAnalyseIniFile
      // 
      this.chkAnalyseIniFile.AutoSize = true;
      this.chkAnalyseIniFile.Checked = true;
      this.chkAnalyseIniFile.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkAnalyseIniFile.Location = new System.Drawing.Point(104, 130);
      this.chkAnalyseIniFile.Name = "chkAnalyseIniFile";
      this.chkAnalyseIniFile.Size = new System.Drawing.Size(221, 20);
      this.chkAnalyseIniFile.TabIndex = 9;
      this.chkAnalyseIniFile.Text = "Analyse track INI file if exists";
      this.chkAnalyseIniFile.UseVisualStyleBackColor = true;
      // 
      // nudOpponentStrength
      // 
      this.nudOpponentStrength.Location = new System.Drawing.Point(220, 101);
      this.nudOpponentStrength.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
      this.nudOpponentStrength.Minimum = new decimal(new int[] {
            70,
            0,
            0,
            0});
      this.nudOpponentStrength.Name = "nudOpponentStrength";
      this.nudOpponentStrength.Size = new System.Drawing.Size(84, 23);
      this.nudOpponentStrength.TabIndex = 10;
      this.nudOpponentStrength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.nudOpponentStrength.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 103);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(176, 16);
      this.label4.TabIndex = 11;
      this.label4.Text = "Opponents strength (%):";
      // 
      // FrmNewWeekend
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(768, 188);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.nudOpponentStrength);
      this.Controls.Add(this.chkAnalyseIniFile);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.dtpDate);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cmbTracks);
      this.Controls.Add(this.btnFillFromCup);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cmbRaces);
      this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "FrmNewWeekend";
      this.Text = "Create new weekend";
      ((System.ComponentModel.ISupportInitialize)(this.nudOpponentStrength)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox cmbRaces;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnFillFromCup;
    private System.Windows.Forms.ComboBox cmbTracks;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DateTimePicker dtpDate;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.CheckBox chkAnalyseIniFile;
    private System.Windows.Forms.NumericUpDown nudOpponentStrength;
    private System.Windows.Forms.Label label4;
  }
}