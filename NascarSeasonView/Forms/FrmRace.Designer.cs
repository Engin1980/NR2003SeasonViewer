namespace ENG.NR2003.NascarSeasonView.Forms
{
  partial class FrmRace
  {
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem addRaceToolStripMenuItem;

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRace));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openRaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveRaceAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.addRaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.removeTelemetryDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.qualifyHappyHourRaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.happyHourRaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.raceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
      this.renameRaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.changeOpponentsStrengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.changeRacedateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.telemetryFileOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.telemetryFileViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
      this.chartsFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.raceLapByLapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pnlBottom = new System.Windows.Forms.Panel();
      this.pnlFill = new System.Windows.Forms.Panel();
      this.ctrWeekend = new ENG.NR2003.NascarSeasonView.Controls.WeekendOverview();
      this.menuStrip1.SuspendLayout();
      this.pnlFill.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.viewToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
      this.menuStrip1.Size = new System.Drawing.Size(910, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openRaceToolStripMenuItem,
            this.saveRaceAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // openRaceToolStripMenuItem
      // 
      this.openRaceToolStripMenuItem.Name = "openRaceToolStripMenuItem";
      this.openRaceToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
      this.openRaceToolStripMenuItem.Text = "Open race";
      // 
      // saveRaceAsToolStripMenuItem
      // 
      this.saveRaceAsToolStripMenuItem.Name = "saveRaceAsToolStripMenuItem";
      this.saveRaceAsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
      this.saveRaceAsToolStripMenuItem.Text = "Save race as";
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(173, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
      this.exitToolStripMenuItem.Text = "&Close";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRaceToolStripMenuItem,
            this.removeTelemetryDataToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem4,
            this.renameRaceToolStripMenuItem,
            this.changeOpponentsStrengthToolStripMenuItem,
            this.changeRacedateToolStripMenuItem});
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
      this.editToolStripMenuItem.Text = "&Edit";
      // 
      // addRaceToolStripMenuItem
      // 
      this.addRaceToolStripMenuItem.Name = "addRaceToolStripMenuItem";
      this.addRaceToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
      this.addRaceToolStripMenuItem.Text = "&Add telemetry data";
      this.addRaceToolStripMenuItem.Click += new System.EventHandler(this.addRaceToolStripMenuItem_Click);
      // 
      // removeTelemetryDataToolStripMenuItem
      // 
      this.removeTelemetryDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.qualifyHappyHourRaceToolStripMenuItem,
            this.happyHourRaceToolStripMenuItem,
            this.raceToolStripMenuItem});
      this.removeTelemetryDataToolStripMenuItem.Name = "removeTelemetryDataToolStripMenuItem";
      this.removeTelemetryDataToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
      this.removeTelemetryDataToolStripMenuItem.Text = "Remove telemetry data";
      // 
      // allToolStripMenuItem
      // 
      this.allToolStripMenuItem.Name = "allToolStripMenuItem";
      this.allToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
      this.allToolStripMenuItem.Text = "All";
      this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
      // 
      // qualifyHappyHourRaceToolStripMenuItem
      // 
      this.qualifyHappyHourRaceToolStripMenuItem.Name = "qualifyHappyHourRaceToolStripMenuItem";
      this.qualifyHappyHourRaceToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
      this.qualifyHappyHourRaceToolStripMenuItem.Text = "Qualify, Happy hour, Race";
      this.qualifyHappyHourRaceToolStripMenuItem.Click += new System.EventHandler(this.qualifyHappyHourRaceToolStripMenuItem_Click);
      // 
      // happyHourRaceToolStripMenuItem
      // 
      this.happyHourRaceToolStripMenuItem.Name = "happyHourRaceToolStripMenuItem";
      this.happyHourRaceToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
      this.happyHourRaceToolStripMenuItem.Text = "Happy hour, Race";
      this.happyHourRaceToolStripMenuItem.Click += new System.EventHandler(this.happyHourRaceToolStripMenuItem_Click);
      // 
      // raceToolStripMenuItem
      // 
      this.raceToolStripMenuItem.Name = "raceToolStripMenuItem";
      this.raceToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
      this.raceToolStripMenuItem.Text = "Race";
      this.raceToolStripMenuItem.Click += new System.EventHandler(this.raceToolStripMenuItem_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(270, 6);
      // 
      // toolStripMenuItem4
      // 
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new System.Drawing.Size(270, 6);
      // 
      // renameRaceToolStripMenuItem
      // 
      this.renameRaceToolStripMenuItem.Name = "renameRaceToolStripMenuItem";
      this.renameRaceToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
      this.renameRaceToolStripMenuItem.Text = "&Rename race";
      this.renameRaceToolStripMenuItem.Click += new System.EventHandler(this.renameRaceToolStripMenuItem_Click);
      // 
      // changeOpponentsStrengthToolStripMenuItem
      // 
      this.changeOpponentsStrengthToolStripMenuItem.Name = "changeOpponentsStrengthToolStripMenuItem";
      this.changeOpponentsStrengthToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
      this.changeOpponentsStrengthToolStripMenuItem.Text = "Change opponents strength";
      this.changeOpponentsStrengthToolStripMenuItem.Click += new System.EventHandler(this.changeOpponentsStrengthToolStripMenuItem_Click);
      // 
      // changeRacedateToolStripMenuItem
      // 
      this.changeRacedateToolStripMenuItem.Name = "changeRacedateToolStripMenuItem";
      this.changeRacedateToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
      this.changeRacedateToolStripMenuItem.Text = "Change race &date";
      this.changeRacedateToolStripMenuItem.Click += new System.EventHandler(this.changeRacedateToolStripMenuItem_Click);
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.telemetryFileOverviewToolStripMenuItem,
            this.telemetryFileViewToolStripMenuItem});
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
      this.toolsToolStripMenuItem.Text = "Tools";
      // 
      // telemetryFileOverviewToolStripMenuItem
      // 
      this.telemetryFileOverviewToolStripMenuItem.Name = "telemetryFileOverviewToolStripMenuItem";
      this.telemetryFileOverviewToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
      this.telemetryFileOverviewToolStripMenuItem.Text = "Telemetry file analyse";
      this.telemetryFileOverviewToolStripMenuItem.Click += new System.EventHandler(this.telemetryFileOverviewToolStripMenuItem_Click);
      // 
      // telemetryFileViewToolStripMenuItem
      // 
      this.telemetryFileViewToolStripMenuItem.Name = "telemetryFileViewToolStripMenuItem";
      this.telemetryFileViewToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
      this.telemetryFileViewToolStripMenuItem.Text = "Telemetry file view";
      this.telemetryFileViewToolStripMenuItem.Click += new System.EventHandler(this.telemetryFileViewToolStripMenuItem_Click);
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.chartsFromToolStripMenuItem});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
      this.viewToolStripMenuItem.Text = "View";
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new System.Drawing.Size(163, 6);
      // 
      // chartsFromToolStripMenuItem
      // 
      this.chartsFromToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.raceLapByLapToolStripMenuItem});
      this.chartsFromToolStripMenuItem.Name = "chartsFromToolStripMenuItem";
      this.chartsFromToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
      this.chartsFromToolStripMenuItem.Text = "Charts from";
      // 
      // raceLapByLapToolStripMenuItem
      // 
      this.raceLapByLapToolStripMenuItem.Name = "raceLapByLapToolStripMenuItem";
      this.raceLapByLapToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
      this.raceLapByLapToolStripMenuItem.Text = "Race lap by lap";
      this.raceLapByLapToolStripMenuItem.Click += new System.EventHandler(this.raceLapByLapToolStripMenuItem_Click);
      // 
      // pnlBottom
      // 
      this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlBottom.Location = new System.Drawing.Point(0, 473);
      this.pnlBottom.Name = "pnlBottom";
      this.pnlBottom.Size = new System.Drawing.Size(910, 30);
      this.pnlBottom.TabIndex = 2;
      // 
      // pnlFill
      // 
      this.pnlFill.Controls.Add(this.ctrWeekend);
      this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlFill.Location = new System.Drawing.Point(0, 24);
      this.pnlFill.Name = "pnlFill";
      this.pnlFill.Size = new System.Drawing.Size(910, 449);
      this.pnlFill.TabIndex = 4;
      // 
      // ctrWeekend
      // 
      this.ctrWeekend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ctrWeekend.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ctrWeekend.Location = new System.Drawing.Point(4, 4);
      this.ctrWeekend.Margin = new System.Windows.Forms.Padding(4);
      this.ctrWeekend.Name = "ctrWeekend";
      this.ctrWeekend.Size = new System.Drawing.Size(902, 438);
      this.ctrWeekend.TabIndex = 0;
      // 
      // FrmRace
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(910, 503);
      this.Controls.Add(this.pnlFill);
      this.Controls.Add(this.pnlBottom);
      this.Controls.Add(this.menuStrip1);
      this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "FrmRace";
      this.Text = "Nascar season view";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmRace_FormClosed);
      this.Load += new System.EventHandler(this.FrmRace_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.pnlFill.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Panel pnlFill;
    private Controls.WeekendOverview ctrWeekend;
    private System.Windows.Forms.ToolStripMenuItem openRaceToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveRaceAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem telemetryFileOverviewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem renameRaceToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem changeOpponentsStrengthToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem telemetryFileViewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem chartsFromToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem raceLapByLapToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem changeRacedateToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem removeTelemetryDataToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem qualifyHappyHourRaceToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem happyHourRaceToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem raceToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
  }
}