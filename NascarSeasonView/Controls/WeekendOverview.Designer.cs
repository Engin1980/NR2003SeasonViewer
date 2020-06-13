namespace ENG.NR2003.NascarSeasonView.Controls
{
  partial class WeekendOverview
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabOverview = new System.Windows.Forms.TabPage();
      this.lblTotalRaceTime = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.lblYellowPhasesLaps = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.lblYellowPhasesCount = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.lblMultiplier = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.lblOpponentsStrength = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.lblMode = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.chkRealWeather = new System.Windows.Forms.CheckBox();
      this.chkYellowFlags = new System.Windows.Forms.CheckBox();
      this.chkFullPaceLap = new System.Windows.Forms.CheckBox();
      this.chkDoubleFileRestarts = new System.Windows.Forms.CheckBox();
      this.chkAdaptiveSpeedControl = new System.Windows.Forms.CheckBox();
      this.lblDamageLevel = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lblRaceLength = new System.Windows.Forms.Label();
      this.lblPreRaceLength = new System.Windows.Forms.Label();
      this.lblQualifyLength = new System.Windows.Forms.Label();
      this.lblPracticeLength = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.x = new System.Windows.Forms.Label();
      this.lblDate = new System.Windows.Forms.Label();
      this.lblTrackInfo = new System.Windows.Forms.Label();
      this.lblWeekendName = new System.Windows.Forms.Label();
      this.tabPractice = new System.Windows.Forms.TabPage();
      this.ctrPractice = new ENG.NR2003.NascarSeasonView.Controls.NonRaceGridView();
      this.tabQualify = new System.Windows.Forms.TabPage();
      this.ctrQualify = new ENG.NR2003.NascarSeasonView.Controls.NonRaceGridView();
      this.tabPreRace = new System.Windows.Forms.TabPage();
      this.ctrPreRace = new ENG.NR2003.NascarSeasonView.Controls.NonRaceGridView();
      this.tabRace = new System.Windows.Forms.TabPage();
      this.ctrRace = new ENG.NR2003.NascarSeasonView.Controls.RaceGridView();
      this.tabStandings = new System.Windows.Forms.TabPage();
      this.ctrStandings = new ENG.NR2003.NascarSeasonView.Controls.SeasonStandingsGridView();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.txtHints = new ESystem.Forms.OutputTextBox();
      this.btnEvaluateHints = new System.Windows.Forms.Button();
      this.label11 = new System.Windows.Forms.Label();
      this.txtTag = new System.Windows.Forms.TextBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.tabControl1.SuspendLayout();
      this.tabOverview.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabPractice.SuspendLayout();
      this.tabQualify.SuspendLayout();
      this.tabPreRace.SuspendLayout();
      this.tabRace.SuspendLayout();
      this.tabStandings.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabOverview);
      this.tabControl1.Controls.Add(this.tabPractice);
      this.tabControl1.Controls.Add(this.tabQualify);
      this.tabControl1.Controls.Add(this.tabPreRace);
      this.tabControl1.Controls.Add(this.tabRace);
      this.tabControl1.Controls.Add(this.tabStandings);
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(605, 631);
      this.tabControl1.TabIndex = 0;
      // 
      // tabOverview
      // 
      this.tabOverview.Controls.Add(this.groupBox3);
      this.tabOverview.Controls.Add(this.txtTag);
      this.tabOverview.Controls.Add(this.label11);
      this.tabOverview.Controls.Add(this.groupBox2);
      this.tabOverview.Controls.Add(this.groupBox1);
      this.tabOverview.Controls.Add(this.lblDate);
      this.tabOverview.Controls.Add(this.lblTrackInfo);
      this.tabOverview.Controls.Add(this.lblWeekendName);
      this.tabOverview.Location = new System.Drawing.Point(4, 25);
      this.tabOverview.Name = "tabOverview";
      this.tabOverview.Padding = new System.Windows.Forms.Padding(3);
      this.tabOverview.Size = new System.Drawing.Size(597, 602);
      this.tabOverview.TabIndex = 0;
      this.tabOverview.Text = "Weekend info";
      this.tabOverview.UseVisualStyleBackColor = true;
      // 
      // lblTotalRaceTime
      // 
      this.lblTotalRaceTime.AutoSize = true;
      this.lblTotalRaceTime.Location = new System.Drawing.Point(178, 19);
      this.lblTotalRaceTime.Name = "lblTotalRaceTime";
      this.lblTotalRaceTime.Size = new System.Drawing.Size(29, 16);
      this.lblTotalRaceTime.TabIndex = 10;
      this.lblTotalRaceTime.Text = "---";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(6, 19);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(118, 16);
      this.label7.TabIndex = 9;
      this.label7.Text = "Race run length:";
      // 
      // lblYellowPhasesLaps
      // 
      this.lblYellowPhasesLaps.AutoSize = true;
      this.lblYellowPhasesLaps.Location = new System.Drawing.Point(178, 51);
      this.lblYellowPhasesLaps.Name = "lblYellowPhasesLaps";
      this.lblYellowPhasesLaps.Size = new System.Drawing.Size(29, 16);
      this.lblYellowPhasesLaps.TabIndex = 8;
      this.lblYellowPhasesLaps.Text = "---";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(6, 51);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(138, 16);
      this.label9.TabIndex = 7;
      this.label9.Text = "Yellow phases laps:";
      // 
      // lblYellowPhasesCount
      // 
      this.lblYellowPhasesCount.AutoSize = true;
      this.lblYellowPhasesCount.Location = new System.Drawing.Point(178, 35);
      this.lblYellowPhasesCount.Name = "lblYellowPhasesCount";
      this.lblYellowPhasesCount.Size = new System.Drawing.Size(29, 16);
      this.lblYellowPhasesCount.TabIndex = 6;
      this.lblYellowPhasesCount.Text = "---";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 35);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(150, 16);
      this.label5.TabIndex = 5;
      this.label5.Text = "Yellow phases count:";
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.lblMultiplier);
      this.groupBox2.Controls.Add(this.label10);
      this.groupBox2.Controls.Add(this.lblOpponentsStrength);
      this.groupBox2.Controls.Add(this.label8);
      this.groupBox2.Controls.Add(this.lblMode);
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Controls.Add(this.chkRealWeather);
      this.groupBox2.Controls.Add(this.chkYellowFlags);
      this.groupBox2.Controls.Add(this.chkFullPaceLap);
      this.groupBox2.Controls.Add(this.chkDoubleFileRestarts);
      this.groupBox2.Controls.Add(this.chkAdaptiveSpeedControl);
      this.groupBox2.Controls.Add(this.lblDamageLevel);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Location = new System.Drawing.Point(20, 191);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(565, 185);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Realism:";
      // 
      // lblMultiplier
      // 
      this.lblMultiplier.AutoSize = true;
      this.lblMultiplier.Location = new System.Drawing.Point(169, 108);
      this.lblMultiplier.Name = "lblMultiplier";
      this.lblMultiplier.Size = new System.Drawing.Size(29, 16);
      this.lblMultiplier.TabIndex = 12;
      this.lblMultiplier.Text = "---";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(17, 108);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(126, 16);
      this.label10.TabIndex = 11;
      this.label10.Text = "Physics multiplier:";
      // 
      // lblOpponentsStrength
      // 
      this.lblOpponentsStrength.AutoSize = true;
      this.lblOpponentsStrength.Location = new System.Drawing.Point(169, 82);
      this.lblOpponentsStrength.Name = "lblOpponentsStrength";
      this.lblOpponentsStrength.Size = new System.Drawing.Size(29, 16);
      this.lblOpponentsStrength.TabIndex = 10;
      this.lblOpponentsStrength.Text = "---";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(17, 82);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(146, 16);
      this.label8.TabIndex = 9;
      this.label8.Text = "Opponents strength:";
      // 
      // lblMode
      // 
      this.lblMode.AutoSize = true;
      this.lblMode.Location = new System.Drawing.Point(169, 56);
      this.lblMode.Name = "lblMode";
      this.lblMode.Size = new System.Drawing.Size(29, 16);
      this.lblMode.TabIndex = 8;
      this.lblMode.Text = "---";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(17, 56);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(49, 16);
      this.label6.TabIndex = 7;
      this.label6.Text = "Mode:";
      // 
      // chkRealWeather
      // 
      this.chkRealWeather.AutoSize = true;
      this.chkRealWeather.Enabled = false;
      this.chkRealWeather.Location = new System.Drawing.Point(325, 133);
      this.chkRealWeather.Name = "chkRealWeather";
      this.chkRealWeather.Size = new System.Drawing.Size(113, 20);
      this.chkRealWeather.TabIndex = 6;
      this.chkRealWeather.Text = "Real weather";
      this.chkRealWeather.UseVisualStyleBackColor = true;
      // 
      // chkYellowFlags
      // 
      this.chkYellowFlags.AutoSize = true;
      this.chkYellowFlags.Enabled = false;
      this.chkYellowFlags.Location = new System.Drawing.Point(325, 107);
      this.chkYellowFlags.Name = "chkYellowFlags";
      this.chkYellowFlags.Size = new System.Drawing.Size(105, 20);
      this.chkYellowFlags.TabIndex = 5;
      this.chkYellowFlags.Text = "Yellow flags";
      this.chkYellowFlags.UseVisualStyleBackColor = true;
      // 
      // chkFullPaceLap
      // 
      this.chkFullPaceLap.AutoSize = true;
      this.chkFullPaceLap.Enabled = false;
      this.chkFullPaceLap.Location = new System.Drawing.Point(325, 81);
      this.chkFullPaceLap.Name = "chkFullPaceLap";
      this.chkFullPaceLap.Size = new System.Drawing.Size(110, 20);
      this.chkFullPaceLap.TabIndex = 4;
      this.chkFullPaceLap.Text = "Full pace lap";
      this.chkFullPaceLap.UseVisualStyleBackColor = true;
      // 
      // chkDoubleFileRestarts
      // 
      this.chkDoubleFileRestarts.AutoSize = true;
      this.chkDoubleFileRestarts.Enabled = false;
      this.chkDoubleFileRestarts.Location = new System.Drawing.Point(325, 55);
      this.chkDoubleFileRestarts.Name = "chkDoubleFileRestarts";
      this.chkDoubleFileRestarts.Size = new System.Drawing.Size(152, 20);
      this.chkDoubleFileRestarts.TabIndex = 3;
      this.chkDoubleFileRestarts.Text = "Double file restarts";
      this.chkDoubleFileRestarts.UseVisualStyleBackColor = true;
      // 
      // chkAdaptiveSpeedControl
      // 
      this.chkAdaptiveSpeedControl.AutoSize = true;
      this.chkAdaptiveSpeedControl.Enabled = false;
      this.chkAdaptiveSpeedControl.Location = new System.Drawing.Point(325, 29);
      this.chkAdaptiveSpeedControl.Name = "chkAdaptiveSpeedControl";
      this.chkAdaptiveSpeedControl.Size = new System.Drawing.Size(180, 20);
      this.chkAdaptiveSpeedControl.TabIndex = 2;
      this.chkAdaptiveSpeedControl.Text = "Adaptive speed control";
      this.chkAdaptiveSpeedControl.UseVisualStyleBackColor = true;
      // 
      // lblDamageLevel
      // 
      this.lblDamageLevel.AutoSize = true;
      this.lblDamageLevel.Location = new System.Drawing.Point(169, 30);
      this.lblDamageLevel.Name = "lblDamageLevel";
      this.lblDamageLevel.Size = new System.Drawing.Size(29, 16);
      this.lblDamageLevel.TabIndex = 1;
      this.lblDamageLevel.Text = "---";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(17, 30);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(101, 16);
      this.label4.TabIndex = 0;
      this.label4.Text = "Damage level:";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.lblRaceLength);
      this.groupBox1.Controls.Add(this.lblPreRaceLength);
      this.groupBox1.Controls.Add(this.lblQualifyLength);
      this.groupBox1.Controls.Add(this.lblPracticeLength);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.x);
      this.groupBox1.Location = new System.Drawing.Point(20, 92);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(243, 93);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Settings:";
      // 
      // lblRaceLength
      // 
      this.lblRaceLength.AutoSize = true;
      this.lblRaceLength.Location = new System.Drawing.Point(112, 67);
      this.lblRaceLength.Name = "lblRaceLength";
      this.lblRaceLength.Size = new System.Drawing.Size(29, 16);
      this.lblRaceLength.TabIndex = 7;
      this.lblRaceLength.Text = "---";
      // 
      // lblPreRaceLength
      // 
      this.lblPreRaceLength.AutoSize = true;
      this.lblPreRaceLength.Location = new System.Drawing.Point(112, 51);
      this.lblPreRaceLength.Name = "lblPreRaceLength";
      this.lblPreRaceLength.Size = new System.Drawing.Size(29, 16);
      this.lblPreRaceLength.TabIndex = 6;
      this.lblPreRaceLength.Text = "---";
      // 
      // lblQualifyLength
      // 
      this.lblQualifyLength.AutoSize = true;
      this.lblQualifyLength.Location = new System.Drawing.Point(112, 35);
      this.lblQualifyLength.Name = "lblQualifyLength";
      this.lblQualifyLength.Size = new System.Drawing.Size(29, 16);
      this.lblQualifyLength.TabIndex = 5;
      this.lblQualifyLength.Text = "---";
      // 
      // lblPracticeLength
      // 
      this.lblPracticeLength.AutoSize = true;
      this.lblPracticeLength.Location = new System.Drawing.Point(112, 19);
      this.lblPracticeLength.Name = "lblPracticeLength";
      this.lblPracticeLength.Size = new System.Drawing.Size(29, 16);
      this.lblPracticeLength.TabIndex = 4;
      this.lblPracticeLength.Text = "---";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(17, 67);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(46, 16);
      this.label3.TabIndex = 3;
      this.label3.Text = "Race:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(17, 51);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(71, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "Pre-race:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(17, 35);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(59, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "Qualify:";
      // 
      // x
      // 
      this.x.AutoSize = true;
      this.x.Location = new System.Drawing.Point(17, 19);
      this.x.Name = "x";
      this.x.Size = new System.Drawing.Size(68, 16);
      this.x.TabIndex = 0;
      this.x.Text = "Practice:";
      // 
      // lblDate
      // 
      this.lblDate.AutoSize = true;
      this.lblDate.Location = new System.Drawing.Point(17, 73);
      this.lblDate.Name = "lblDate";
      this.lblDate.Size = new System.Drawing.Size(29, 16);
      this.lblDate.TabIndex = 2;
      this.lblDate.Text = "---";
      // 
      // lblTrackInfo
      // 
      this.lblTrackInfo.AutoSize = true;
      this.lblTrackInfo.Location = new System.Drawing.Point(17, 57);
      this.lblTrackInfo.Name = "lblTrackInfo";
      this.lblTrackInfo.Size = new System.Drawing.Size(29, 16);
      this.lblTrackInfo.TabIndex = 1;
      this.lblTrackInfo.Text = "---";
      // 
      // lblWeekendName
      // 
      this.lblWeekendName.AutoSize = true;
      this.lblWeekendName.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblWeekendName.Location = new System.Drawing.Point(16, 21);
      this.lblWeekendName.Name = "lblWeekendName";
      this.lblWeekendName.Size = new System.Drawing.Size(37, 23);
      this.lblWeekendName.TabIndex = 0;
      this.lblWeekendName.Text = "---";
      // 
      // tabPractice
      // 
      this.tabPractice.Controls.Add(this.ctrPractice);
      this.tabPractice.Location = new System.Drawing.Point(4, 25);
      this.tabPractice.Name = "tabPractice";
      this.tabPractice.Padding = new System.Windows.Forms.Padding(3);
      this.tabPractice.Size = new System.Drawing.Size(833, 533);
      this.tabPractice.TabIndex = 1;
      this.tabPractice.Text = "Practice";
      this.tabPractice.UseVisualStyleBackColor = true;
      // 
      // ctrPractice
      // 
      this.ctrPractice.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ctrPractice.Location = new System.Drawing.Point(3, 3);
      this.ctrPractice.Margin = new System.Windows.Forms.Padding(4);
      this.ctrPractice.Name = "ctrPractice";
      this.ctrPractice.Size = new System.Drawing.Size(827, 527);
      this.ctrPractice.TabIndex = 0;
      // 
      // tabQualify
      // 
      this.tabQualify.Controls.Add(this.ctrQualify);
      this.tabQualify.Location = new System.Drawing.Point(4, 25);
      this.tabQualify.Name = "tabQualify";
      this.tabQualify.Size = new System.Drawing.Size(833, 533);
      this.tabQualify.TabIndex = 2;
      this.tabQualify.Text = "Qualify";
      this.tabQualify.UseVisualStyleBackColor = true;
      // 
      // ctrQualify
      // 
      this.ctrQualify.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ctrQualify.Location = new System.Drawing.Point(0, 0);
      this.ctrQualify.Margin = new System.Windows.Forms.Padding(4);
      this.ctrQualify.Name = "ctrQualify";
      this.ctrQualify.Size = new System.Drawing.Size(833, 533);
      this.ctrQualify.TabIndex = 0;
      // 
      // tabPreRace
      // 
      this.tabPreRace.Controls.Add(this.ctrPreRace);
      this.tabPreRace.Location = new System.Drawing.Point(4, 25);
      this.tabPreRace.Name = "tabPreRace";
      this.tabPreRace.Size = new System.Drawing.Size(833, 533);
      this.tabPreRace.TabIndex = 3;
      this.tabPreRace.Text = "Pre race";
      this.tabPreRace.UseVisualStyleBackColor = true;
      // 
      // ctrPreRace
      // 
      this.ctrPreRace.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ctrPreRace.Location = new System.Drawing.Point(0, 0);
      this.ctrPreRace.Margin = new System.Windows.Forms.Padding(4);
      this.ctrPreRace.Name = "ctrPreRace";
      this.ctrPreRace.Size = new System.Drawing.Size(833, 533);
      this.ctrPreRace.TabIndex = 0;
      // 
      // tabRace
      // 
      this.tabRace.Controls.Add(this.ctrRace);
      this.tabRace.Location = new System.Drawing.Point(4, 25);
      this.tabRace.Name = "tabRace";
      this.tabRace.Size = new System.Drawing.Size(833, 533);
      this.tabRace.TabIndex = 4;
      this.tabRace.Text = "Race";
      this.tabRace.UseVisualStyleBackColor = true;
      // 
      // ctrRace
      // 
      this.ctrRace.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ctrRace.Location = new System.Drawing.Point(0, 0);
      this.ctrRace.Margin = new System.Windows.Forms.Padding(4);
      this.ctrRace.Name = "ctrRace";
      this.ctrRace.Size = new System.Drawing.Size(833, 533);
      this.ctrRace.TabIndex = 0;
      // 
      // tabStandings
      // 
      this.tabStandings.Controls.Add(this.ctrStandings);
      this.tabStandings.Location = new System.Drawing.Point(4, 25);
      this.tabStandings.Name = "tabStandings";
      this.tabStandings.Size = new System.Drawing.Size(833, 533);
      this.tabStandings.TabIndex = 5;
      this.tabStandings.Text = "Standings";
      this.tabStandings.UseVisualStyleBackColor = true;
      // 
      // ctrStandings
      // 
      this.ctrStandings.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ctrStandings.Location = new System.Drawing.Point(0, 0);
      this.ctrStandings.Margin = new System.Windows.Forms.Padding(4);
      this.ctrStandings.Name = "ctrStandings";
      this.ctrStandings.Size = new System.Drawing.Size(833, 533);
      this.ctrStandings.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.txtHints);
      this.tabPage1.Controls.Add(this.btnEvaluateHints);
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(833, 533);
      this.tabPage1.TabIndex = 6;
      this.tabPage1.Text = "(Hints)";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // txtHints
      // 
      this.txtHints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtHints.AutoNewLine = true;
      this.txtHints.AutoScrollCarret = false;
      this.txtHints.AutoTime = false;
      this.txtHints.AutoTimeSeparator = " ";
      this.txtHints.Location = new System.Drawing.Point(7, 39);
      this.txtHints.Margin = new System.Windows.Forms.Padding(4);
      this.txtHints.Name = "txtHints";
      this.txtHints.ReadOnly = false;
      this.txtHints.Size = new System.Drawing.Size(819, 487);
      this.txtHints.TabIndex = 1;
      // 
      // btnEvaluateHints
      // 
      this.btnEvaluateHints.Location = new System.Drawing.Point(6, 6);
      this.btnEvaluateHints.Name = "btnEvaluateHints";
      this.btnEvaluateHints.Size = new System.Drawing.Size(178, 26);
      this.btnEvaluateHints.TabIndex = 0;
      this.btnEvaluateHints.Text = "&Evaluate";
      this.btnEvaluateHints.UseVisualStyleBackColor = true;
      this.btnEvaluateHints.Click += new System.EventHandler(this.btnEvaluateHints_Click);
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(17, 379);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(71, 16);
      this.label11.TabIndex = 11;
      this.label11.Text = "Text tag:";
      // 
      // txtTag
      // 
      this.txtTag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtTag.Location = new System.Drawing.Point(20, 398);
      this.txtTag.Multiline = true;
      this.txtTag.Name = "txtTag";
      this.txtTag.Size = new System.Drawing.Size(565, 198);
      this.txtTag.TabIndex = 12;
      this.txtTag.TextChanged += new System.EventHandler(this.txtTag_TextChanged);
      // 
      // groupBox3
      // 
      this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox3.Controls.Add(this.label7);
      this.groupBox3.Controls.Add(this.label5);
      this.groupBox3.Controls.Add(this.lblYellowPhasesCount);
      this.groupBox3.Controls.Add(this.lblTotalRaceTime);
      this.groupBox3.Controls.Add(this.label9);
      this.groupBox3.Controls.Add(this.lblYellowPhasesLaps);
      this.groupBox3.Location = new System.Drawing.Point(269, 92);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(316, 93);
      this.groupBox3.TabIndex = 13;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Race run:";
      // 
      // WeekendOverview
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tabControl1);
      this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "WeekendOverview";
      this.Size = new System.Drawing.Size(605, 631);
      this.Load += new System.EventHandler(this.WeekendOverview_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabOverview.ResumeLayout(false);
      this.tabOverview.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.tabPractice.ResumeLayout(false);
      this.tabQualify.ResumeLayout(false);
      this.tabPreRace.ResumeLayout(false);
      this.tabRace.ResumeLayout(false);
      this.tabStandings.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabOverview;
    private System.Windows.Forms.TabPage tabPractice;
    private System.Windows.Forms.TabPage tabQualify;
    private System.Windows.Forms.TabPage tabPreRace;
    private System.Windows.Forms.TabPage tabRace;
    private System.Windows.Forms.TabPage tabStandings;
    private SeasonStandingsGridView ctrStandings;
    private NonRaceGridView ctrQualify;
    private NonRaceGridView ctrPreRace;
    private NonRaceGridView ctrPractice;
    private RaceGridView ctrRace;
    private System.Windows.Forms.Label lblDate;
    private System.Windows.Forms.Label lblTrackInfo;
    private System.Windows.Forms.Label lblWeekendName;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label x;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label lblRaceLength;
    private System.Windows.Forms.Label lblPreRaceLength;
    private System.Windows.Forms.Label lblQualifyLength;
    private System.Windows.Forms.Label lblPracticeLength;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblDamageLevel;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.CheckBox chkYellowFlags;
    private System.Windows.Forms.CheckBox chkFullPaceLap;
    private System.Windows.Forms.CheckBox chkDoubleFileRestarts;
    private System.Windows.Forms.CheckBox chkAdaptiveSpeedControl;
    private System.Windows.Forms.Label lblMultiplier;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label lblOpponentsStrength;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label lblMode;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.CheckBox chkRealWeather;
    private System.Windows.Forms.Label lblYellowPhasesCount;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lblYellowPhasesLaps;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TabPage tabPage1;
    private ESystem.Forms.OutputTextBox txtHints;
    private System.Windows.Forms.Button btnEvaluateHints;
    private System.Windows.Forms.Label lblTotalRaceTime;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtTag;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.GroupBox groupBox3;
  }
}
