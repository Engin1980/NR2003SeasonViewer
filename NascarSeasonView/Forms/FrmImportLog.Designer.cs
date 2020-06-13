namespace ENG.NR2003.NascarSeasonView.Forms
{
  partial class FrmImportLog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportLog));
      this.txtFile = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnSelectFile = new System.Windows.Forms.Button();
      this.btnScan = new System.Windows.Forms.Button();
      this.ofd = new System.Windows.Forms.OpenFileDialog();
      this.label2 = new System.Windows.Forms.Label();
      this.cmbPractice = new System.Windows.Forms.ComboBox();
      this.lblPracticeWarning = new System.Windows.Forms.Label();
      this.lblQualifyWarning = new System.Windows.Forms.Label();
      this.cmbQualify = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.lblHappyHourWarning = new System.Windows.Forms.Label();
      this.cmbHappyHour = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.lblRaceWarning = new System.Windows.Forms.Label();
      this.cmbRace = new System.Windows.Forms.ComboBox();
      this.label9 = new System.Windows.Forms.Label();
      this.btnProcess = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // txtFile
      // 
      this.txtFile.Location = new System.Drawing.Point(71, 15);
      this.txtFile.Name = "txtFile";
      this.txtFile.Size = new System.Drawing.Size(629, 21);
      this.txtFile.TabIndex = 0;
      this.txtFile.TextChanged += new System.EventHandler(this.txtFile_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(53, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Log file:";
      // 
      // btnSelectFile
      // 
      this.btnSelectFile.Location = new System.Drawing.Point(706, 13);
      this.btnSelectFile.Name = "btnSelectFile";
      this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
      this.btnSelectFile.TabIndex = 2;
      this.btnSelectFile.Text = "(...)";
      this.btnSelectFile.UseVisualStyleBackColor = true;
      this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
      // 
      // btnScan
      // 
      this.btnScan.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnScan.Location = new System.Drawing.Point(12, 50);
      this.btnScan.Name = "btnScan";
      this.btnScan.Size = new System.Drawing.Size(769, 28);
      this.btnScan.TabIndex = 3;
      this.btnScan.Text = "Scan / Rescan";
      this.btnScan.UseVisualStyleBackColor = true;
      this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
      // 
      // ofd
      // 
      this.ofd.FileName = "openFileDialog1";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 102);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(156, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Practice -- sections in file:";
      // 
      // cmbPractice
      // 
      this.cmbPractice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbPractice.FormattingEnabled = true;
      this.cmbPractice.Items.AddRange(new object[] {
            "< not defined >"});
      this.cmbPractice.Location = new System.Drawing.Point(32, 118);
      this.cmbPractice.Name = "cmbPractice";
      this.cmbPractice.Size = new System.Drawing.Size(749, 21);
      this.cmbPractice.TabIndex = 5;
      // 
      // lblPracticeWarning
      // 
      this.lblPracticeWarning.AutoSize = true;
      this.lblPracticeWarning.ForeColor = System.Drawing.Color.Red;
      this.lblPracticeWarning.Location = new System.Drawing.Point(35, 121);
      this.lblPracticeWarning.Name = "lblPracticeWarning";
      this.lblPracticeWarning.Size = new System.Drawing.Size(229, 13);
      this.lblPracticeWarning.TabIndex = 6;
      this.lblPracticeWarning.Text = "This session is already defined in race.";
      this.lblPracticeWarning.VisibleChanged += new System.EventHandler(this.lblPracticeWarning_VisibleChanged);
      // 
      // lblQualifyWarning
      // 
      this.lblQualifyWarning.AutoSize = true;
      this.lblQualifyWarning.ForeColor = System.Drawing.Color.Red;
      this.lblQualifyWarning.Location = new System.Drawing.Point(35, 174);
      this.lblQualifyWarning.Name = "lblQualifyWarning";
      this.lblQualifyWarning.Size = new System.Drawing.Size(229, 13);
      this.lblQualifyWarning.TabIndex = 9;
      this.lblQualifyWarning.Text = "This session is already defined in race.";
      this.lblQualifyWarning.VisibleChanged += new System.EventHandler(this.lblQualifyWarning_VisibleChanged);
      // 
      // cmbQualify
      // 
      this.cmbQualify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbQualify.FormattingEnabled = true;
      this.cmbQualify.Items.AddRange(new object[] {
            "< not defined >"});
      this.cmbQualify.Location = new System.Drawing.Point(32, 171);
      this.cmbQualify.Name = "cmbQualify";
      this.cmbQualify.Size = new System.Drawing.Size(749, 21);
      this.cmbQualify.TabIndex = 8;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 155);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(151, 13);
      this.label5.TabIndex = 7;
      this.label5.Text = "Qualify -- sections in file:";
      // 
      // lblHappyHourWarning
      // 
      this.lblHappyHourWarning.AutoSize = true;
      this.lblHappyHourWarning.ForeColor = System.Drawing.Color.Red;
      this.lblHappyHourWarning.Location = new System.Drawing.Point(35, 226);
      this.lblHappyHourWarning.Name = "lblHappyHourWarning";
      this.lblHappyHourWarning.Size = new System.Drawing.Size(229, 13);
      this.lblHappyHourWarning.TabIndex = 12;
      this.lblHappyHourWarning.Text = "This session is already defined in race.";
      this.lblHappyHourWarning.VisibleChanged += new System.EventHandler(this.lblHappyHourWarning_VisibleChanged);
      // 
      // cmbHappyHour
      // 
      this.cmbHappyHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbHappyHour.FormattingEnabled = true;
      this.cmbHappyHour.Items.AddRange(new object[] {
            "< not defined >"});
      this.cmbHappyHour.Location = new System.Drawing.Point(32, 223);
      this.cmbHappyHour.Name = "cmbHappyHour";
      this.cmbHappyHour.Size = new System.Drawing.Size(749, 21);
      this.cmbHappyHour.TabIndex = 11;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(12, 207);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(169, 13);
      this.label7.TabIndex = 10;
      this.label7.Text = "Rush hour -- sections in file:";
      // 
      // lblRaceWarning
      // 
      this.lblRaceWarning.AutoSize = true;
      this.lblRaceWarning.ForeColor = System.Drawing.Color.Red;
      this.lblRaceWarning.Location = new System.Drawing.Point(35, 279);
      this.lblRaceWarning.Name = "lblRaceWarning";
      this.lblRaceWarning.Size = new System.Drawing.Size(229, 13);
      this.lblRaceWarning.TabIndex = 15;
      this.lblRaceWarning.Text = "This session is already defined in race.";
      this.lblRaceWarning.VisibleChanged += new System.EventHandler(this.lblRaceWarning_VisibleChanged);
      // 
      // cmbRace
      // 
      this.cmbRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbRace.FormattingEnabled = true;
      this.cmbRace.Items.AddRange(new object[] {
            "< not defined >"});
      this.cmbRace.Location = new System.Drawing.Point(32, 276);
      this.cmbRace.Name = "cmbRace";
      this.cmbRace.Size = new System.Drawing.Size(749, 21);
      this.cmbRace.TabIndex = 14;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(12, 260);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(139, 13);
      this.label9.TabIndex = 13;
      this.label9.Text = "Race -- sections in file:";
      // 
      // btnProcess
      // 
      this.btnProcess.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnProcess.Location = new System.Drawing.Point(12, 318);
      this.btnProcess.Name = "btnProcess";
      this.btnProcess.Size = new System.Drawing.Size(769, 28);
      this.btnProcess.TabIndex = 16;
      this.btnProcess.Text = "Process";
      this.btnProcess.UseVisualStyleBackColor = true;
      this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
      // 
      // FrmImportLog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(793, 358);
      this.Controls.Add(this.btnProcess);
      this.Controls.Add(this.lblRaceWarning);
      this.Controls.Add(this.cmbRace);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.lblHappyHourWarning);
      this.Controls.Add(this.cmbHappyHour);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.lblQualifyWarning);
      this.Controls.Add(this.cmbQualify);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.lblPracticeWarning);
      this.Controls.Add(this.cmbPractice);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnScan);
      this.Controls.Add(this.btnSelectFile);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtFile);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FrmImportLog";
      this.Text = "Import telemetry log as a race...";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtFile;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnSelectFile;
    private System.Windows.Forms.Button btnScan;
    private System.Windows.Forms.OpenFileDialog ofd;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cmbPractice;
    private System.Windows.Forms.Label lblPracticeWarning;
    private System.Windows.Forms.Label lblQualifyWarning;
    private System.Windows.Forms.ComboBox cmbQualify;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lblHappyHourWarning;
    private System.Windows.Forms.ComboBox cmbHappyHour;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label lblRaceWarning;
    private System.Windows.Forms.ComboBox cmbRace;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Button btnProcess;
  }
}