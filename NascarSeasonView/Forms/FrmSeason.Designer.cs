namespace ENG.NR2003.NascarSeasonView.Forms
{
  partial class FrmSeason
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeason));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newSeasonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openSeasonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveSeasonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveSeasonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.addRaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editRaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteRaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
      this.renameSeasonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.changeScoringSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tracksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.currentSeasonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newSeasonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pnlTop = new System.Windows.Forms.Panel();
      this.rdbStandings = new System.Windows.Forms.RadioButton();
      this.rdbRaces = new System.Windows.Forms.RadioButton();
      this.pnlFill = new System.Windows.Forms.Panel();
      this.grdStandings = new System.Windows.Forms.DataGridView();
      this.grdRaces = new System.Windows.Forms.DataGridView();
      this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
      this.menuStrip1.SuspendLayout();
      this.pnlTop.SuspendLayout();
      this.pnlFill.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grdStandings)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdRaces)).BeginInit();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(771, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSeasonToolStripMenuItem,
            this.openSeasonToolStripMenuItem,
            this.saveSeasonToolStripMenuItem,
            this.saveSeasonasToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // newSeasonToolStripMenuItem
      // 
      this.newSeasonToolStripMenuItem.Name = "newSeasonToolStripMenuItem";
      this.newSeasonToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
      this.newSeasonToolStripMenuItem.Text = "&New season";
      this.newSeasonToolStripMenuItem.Click += new System.EventHandler(this.newSeasonToolStripMenuItem_Click);
      // 
      // openSeasonToolStripMenuItem
      // 
      this.openSeasonToolStripMenuItem.Name = "openSeasonToolStripMenuItem";
      this.openSeasonToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
      this.openSeasonToolStripMenuItem.Text = "&Open season";
      this.openSeasonToolStripMenuItem.Click += new System.EventHandler(this.openSeasonToolStripMenuItem_Click);
      // 
      // saveSeasonToolStripMenuItem
      // 
      this.saveSeasonToolStripMenuItem.Name = "saveSeasonToolStripMenuItem";
      this.saveSeasonToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
      this.saveSeasonToolStripMenuItem.Text = "&Save season";
      this.saveSeasonToolStripMenuItem.Click += new System.EventHandler(this.saveSeasonToolStripMenuItem_Click);
      // 
      // saveSeasonasToolStripMenuItem
      // 
      this.saveSeasonasToolStripMenuItem.Name = "saveSeasonasToolStripMenuItem";
      this.saveSeasonasToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
      this.saveSeasonasToolStripMenuItem.Text = "Save season &as";
      this.saveSeasonasToolStripMenuItem.Click += new System.EventHandler(this.saveSeasonasToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
      this.exitToolStripMenuItem.Text = "&Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRaceToolStripMenuItem,
            this.editRaceToolStripMenuItem,
            this.deleteRaceToolStripMenuItem,
            this.toolStripMenuItem3,
            this.renameSeasonToolStripMenuItem,
            this.changeScoringSystemToolStripMenuItem});
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
      this.editToolStripMenuItem.Text = "&Edit";
      // 
      // addRaceToolStripMenuItem
      // 
      this.addRaceToolStripMenuItem.Name = "addRaceToolStripMenuItem";
      this.addRaceToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
      this.addRaceToolStripMenuItem.Text = "&Add race";
      this.addRaceToolStripMenuItem.Click += new System.EventHandler(this.addRaceToolStripMenuItem_Click);
      // 
      // editRaceToolStripMenuItem
      // 
      this.editRaceToolStripMenuItem.Name = "editRaceToolStripMenuItem";
      this.editRaceToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
      this.editRaceToolStripMenuItem.Text = "&Edit/view race";
      this.editRaceToolStripMenuItem.Click += new System.EventHandler(this.editRaceToolStripMenuItem_Click);
      // 
      // deleteRaceToolStripMenuItem
      // 
      this.deleteRaceToolStripMenuItem.Name = "deleteRaceToolStripMenuItem";
      this.deleteRaceToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
      this.deleteRaceToolStripMenuItem.Text = "&Delete race";
      // 
      // toolStripMenuItem3
      // 
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new System.Drawing.Size(216, 6);
      // 
      // renameSeasonToolStripMenuItem
      // 
      this.renameSeasonToolStripMenuItem.Name = "renameSeasonToolStripMenuItem";
      this.renameSeasonToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
      this.renameSeasonToolStripMenuItem.Text = "Rename season";
      // 
      // changeScoringSystemToolStripMenuItem
      // 
      this.changeScoringSystemToolStripMenuItem.Name = "changeScoringSystemToolStripMenuItem";
      this.changeScoringSystemToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
      this.changeScoringSystemToolStripMenuItem.Text = "Change scoring system";
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tracksToolStripMenuItem,
            this.toolStripMenuItem4,
            this.detailsToolStripMenuItem});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
      this.viewToolStripMenuItem.Text = "View";
      // 
      // tracksToolStripMenuItem
      // 
      this.tracksToolStripMenuItem.Name = "tracksToolStripMenuItem";
      this.tracksToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.tracksToolStripMenuItem.Text = "Tracks";
      this.tracksToolStripMenuItem.Click += new System.EventHandler(this.tracksToolStripMenuItem_Click);
      // 
      // windowToolStripMenuItem
      // 
      this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem});
      this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
      this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
      this.windowToolStripMenuItem.Text = "Window";
      // 
      // newWindowToolStripMenuItem
      // 
      this.newWindowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentSeasonToolStripMenuItem,
            this.newSeasonToolStripMenuItem1});
      this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
      this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
      this.newWindowToolStripMenuItem.Text = "New window";
      // 
      // currentSeasonToolStripMenuItem
      // 
      this.currentSeasonToolStripMenuItem.Name = "currentSeasonToolStripMenuItem";
      this.currentSeasonToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
      this.currentSeasonToolStripMenuItem.Text = "Current season";
      // 
      // newSeasonToolStripMenuItem1
      // 
      this.newSeasonToolStripMenuItem1.Name = "newSeasonToolStripMenuItem1";
      this.newSeasonToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
      this.newSeasonToolStripMenuItem1.Text = "New season";
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      // 
      // helpToolStripMenuItem1
      // 
      this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
      this.helpToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
      this.helpToolStripMenuItem1.Text = "&Help";
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(115, 6);
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
      this.aboutToolStripMenuItem.Text = "&About";
      // 
      // pnlTop
      // 
      this.pnlTop.Controls.Add(this.rdbStandings);
      this.pnlTop.Controls.Add(this.rdbRaces);
      this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlTop.Location = new System.Drawing.Point(0, 24);
      this.pnlTop.Name = "pnlTop";
      this.pnlTop.Size = new System.Drawing.Size(771, 49);
      this.pnlTop.TabIndex = 2;
      // 
      // rdbStandings
      // 
      this.rdbStandings.Appearance = System.Windows.Forms.Appearance.Button;
      this.rdbStandings.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.rdbStandings.Location = new System.Drawing.Point(322, 3);
      this.rdbStandings.Name = "rdbStandings";
      this.rdbStandings.Size = new System.Drawing.Size(92, 35);
      this.rdbStandings.TabIndex = 4;
      this.rdbStandings.Text = "Standings";
      this.rdbStandings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.rdbStandings.UseVisualStyleBackColor = true;
      // 
      // rdbRaces
      // 
      this.rdbRaces.Appearance = System.Windows.Forms.Appearance.Button;
      this.rdbRaces.Checked = true;
      this.rdbRaces.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.rdbRaces.Location = new System.Drawing.Point(125, 3);
      this.rdbRaces.Name = "rdbRaces";
      this.rdbRaces.Size = new System.Drawing.Size(89, 35);
      this.rdbRaces.TabIndex = 3;
      this.rdbRaces.TabStop = true;
      this.rdbRaces.Text = "Races";
      this.rdbRaces.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.rdbRaces.UseVisualStyleBackColor = true;
      this.rdbRaces.CheckedChanged += new System.EventHandler(this.rdbRaces_CheckedChanged);
      // 
      // pnlFill
      // 
      this.pnlFill.Controls.Add(this.grdStandings);
      this.pnlFill.Controls.Add(this.grdRaces);
      this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlFill.Location = new System.Drawing.Point(0, 73);
      this.pnlFill.Name = "pnlFill";
      this.pnlFill.Size = new System.Drawing.Size(771, 410);
      this.pnlFill.TabIndex = 3;
      // 
      // grdStandings
      // 
      this.grdStandings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grdStandings.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grdStandings.Location = new System.Drawing.Point(0, 0);
      this.grdStandings.Name = "grdStandings";
      this.grdStandings.Size = new System.Drawing.Size(771, 410);
      this.grdStandings.TabIndex = 1;
      // 
      // grdRaces
      // 
      this.grdRaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grdRaces.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grdRaces.Location = new System.Drawing.Point(0, 0);
      this.grdRaces.Name = "grdRaces";
      this.grdRaces.Size = new System.Drawing.Size(771, 410);
      this.grdRaces.TabIndex = 0;
      this.grdRaces.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdRaces_MouseDoubleClick);
      // 
      // detailsToolStripMenuItem
      // 
      this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
      this.detailsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.detailsToolStripMenuItem.Text = "&Details";
      this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
      // 
      // toolStripMenuItem4
      // 
      this.toolStripMenuItem4.Name = "toolStripMenuItem4";
      this.toolStripMenuItem4.Size = new System.Drawing.Size(149, 6);
      // 
      // FrmSeason
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(771, 483);
      this.Controls.Add(this.pnlFill);
      this.Controls.Add(this.pnlTop);
      this.Controls.Add(this.menuStrip1);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "FrmSeason";
      this.Text = "FrmSeason";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSeason_FormClosed);
      this.Load += new System.EventHandler(this.FrmSeason_Load);
      this.Resize += new System.EventHandler(this.FrmSeason_Resize);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.pnlTop.ResumeLayout(false);
      this.pnlFill.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grdStandings)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grdRaces)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newSeasonToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openSeasonToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveSeasonToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveSeasonasToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem addRaceToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editRaceToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem deleteRaceToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.Panel pnlTop;
    private System.Windows.Forms.RadioButton rdbStandings;
    private System.Windows.Forms.RadioButton rdbRaces;
    private System.Windows.Forms.Panel pnlFill;
    private System.Windows.Forms.DataGridView grdRaces;
    private System.Windows.Forms.DataGridView grdStandings;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem renameSeasonToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem changeScoringSystemToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem currentSeasonToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newSeasonToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tracksToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
    private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
  }
}