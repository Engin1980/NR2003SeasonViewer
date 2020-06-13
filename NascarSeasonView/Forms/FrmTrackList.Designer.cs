namespace ENG.NR2003.NascarSeasonView.Forms
{
  partial class FrmTrackList
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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.addTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editCurrentTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteCurrentTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.grd = new System.Windows.Forms.DataGridView();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(808, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTrackToolStripMenuItem,
            this.editCurrentTrackToolStripMenuItem,
            this.deleteCurrentTrackToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // addTrackToolStripMenuItem
      // 
      this.addTrackToolStripMenuItem.Name = "addTrackToolStripMenuItem";
      this.addTrackToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
      this.addTrackToolStripMenuItem.Text = "&Add track";
      // 
      // editCurrentTrackToolStripMenuItem
      // 
      this.editCurrentTrackToolStripMenuItem.Name = "editCurrentTrackToolStripMenuItem";
      this.editCurrentTrackToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
      this.editCurrentTrackToolStripMenuItem.Text = "&Edit current track";
      // 
      // deleteCurrentTrackToolStripMenuItem
      // 
      this.deleteCurrentTrackToolStripMenuItem.Name = "deleteCurrentTrackToolStripMenuItem";
      this.deleteCurrentTrackToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
      this.deleteCurrentTrackToolStripMenuItem.Text = "&Delete current track";
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
      // 
      // closeToolStripMenuItem
      // 
      this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
      this.closeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
      this.closeToolStripMenuItem.Text = "&Close";
      this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
      // 
      // grd
      // 
      this.grd.AllowUserToAddRows = false;
      this.grd.AllowUserToDeleteRows = false;
      this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.grd.Location = new System.Drawing.Point(12, 27);
      this.grd.MultiSelect = false;
      this.grd.Name = "grd";
      this.grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.grd.Size = new System.Drawing.Size(784, 495);
      this.grd.TabIndex = 1;
      // 
      // FrmTrackList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(808, 534);
      this.Controls.Add(this.grd);
      this.Controls.Add(this.menuStrip1);
      this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "FrmTrackList";
      this.Text = "List of defined tracks";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem addTrackToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editCurrentTrackToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem deleteCurrentTrackToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    private System.Windows.Forms.DataGridView grd;
  }
}