namespace ENG.NR2003.NascarSeasonView.Forms.GridRules
{
  partial class GridRulesEditor
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridRulesEditor));
      this.grd = new System.Windows.Forms.DataGridView();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.reloadCurrentSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveCurrentSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.importSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exportSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.gridRuleBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.gridTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gridColumnHeaderTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.weekendNameContainsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.trackNameContainsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.operatorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.ColorInHtml = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridRuleBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // grd
      // 
      this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grd.AutoGenerateColumns = false;
      this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridTypeNameDataGridViewTextBoxColumn,
            this.gridColumnHeaderTextDataGridViewTextBoxColumn,
            this.weekendNameContainsDataGridViewTextBoxColumn,
            this.trackNameContainsDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.operatorDataGridViewTextBoxColumn,
            this.ColorInHtml});
      this.grd.DataSource = this.gridRuleBindingSource;
      this.grd.Location = new System.Drawing.Point(16, 28);
      this.grd.Margin = new System.Windows.Forms.Padding(4);
      this.grd.Name = "grd";
      this.grd.Size = new System.Drawing.Size(1063, 409);
      this.grd.TabIndex = 0;
      // 
      // menuStrip1
      // 
      this.menuStrip1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1095, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadCurrentSetToolStripMenuItem,
            this.saveCurrentSetToolStripMenuItem,
            this.toolStripMenuItem1,
            this.importSetToolStripMenuItem,
            this.exportSetToolStripMenuItem,
            this.toolStripMenuItem2,
            this.closeToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // reloadCurrentSetToolStripMenuItem
      // 
      this.reloadCurrentSetToolStripMenuItem.Name = "reloadCurrentSetToolStripMenuItem";
      this.reloadCurrentSetToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
      this.reloadCurrentSetToolStripMenuItem.Text = "Re&load current set";
      this.reloadCurrentSetToolStripMenuItem.Click += new System.EventHandler(this.reloadCurrentSetToolStripMenuItem_Click);
      // 
      // saveCurrentSetToolStripMenuItem
      // 
      this.saveCurrentSetToolStripMenuItem.Name = "saveCurrentSetToolStripMenuItem";
      this.saveCurrentSetToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
      this.saveCurrentSetToolStripMenuItem.Text = "&Save current set";
      this.saveCurrentSetToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentSetToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(208, 6);
      // 
      // importSetToolStripMenuItem
      // 
      this.importSetToolStripMenuItem.Name = "importSetToolStripMenuItem";
      this.importSetToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
      this.importSetToolStripMenuItem.Text = "&Import set";
      this.importSetToolStripMenuItem.Click += new System.EventHandler(this.importSetToolStripMenuItem_Click);
      // 
      // exportSetToolStripMenuItem
      // 
      this.exportSetToolStripMenuItem.Name = "exportSetToolStripMenuItem";
      this.exportSetToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
      this.exportSetToolStripMenuItem.Text = "&Export set";
      this.exportSetToolStripMenuItem.Click += new System.EventHandler(this.exportSetToolStripMenuItem_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(208, 6);
      // 
      // closeToolStripMenuItem
      // 
      this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
      this.closeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
      this.closeToolStripMenuItem.Text = "&Close";
      // 
      // gridRuleBindingSource
      // 
      this.gridRuleBindingSource.DataSource = typeof(ENG.NR2003.NascarSeasonView.Types.GridRules.GridRule);
      // 
      // gridTypeNameDataGridViewTextBoxColumn
      // 
      this.gridTypeNameDataGridViewTextBoxColumn.DataPropertyName = "GridTypeName";
      this.gridTypeNameDataGridViewTextBoxColumn.HeaderText = "Grid type name";
      this.gridTypeNameDataGridViewTextBoxColumn.Name = "gridTypeNameDataGridViewTextBoxColumn";
      this.gridTypeNameDataGridViewTextBoxColumn.ToolTipText = "Name of the type of the grid, or null for all grids";
      this.gridTypeNameDataGridViewTextBoxColumn.Width = 200;
      // 
      // gridColumnHeaderTextDataGridViewTextBoxColumn
      // 
      this.gridColumnHeaderTextDataGridViewTextBoxColumn.DataPropertyName = "GridColumnHeaderText";
      this.gridColumnHeaderTextDataGridViewTextBoxColumn.HeaderText = "Column header";
      this.gridColumnHeaderTextDataGridViewTextBoxColumn.Name = "gridColumnHeaderTextDataGridViewTextBoxColumn";
      this.gridColumnHeaderTextDataGridViewTextBoxColumn.ToolTipText = "Header of the column (exact match)";
      this.gridColumnHeaderTextDataGridViewTextBoxColumn.Width = 200;
      // 
      // weekendNameContainsDataGridViewTextBoxColumn
      // 
      this.weekendNameContainsDataGridViewTextBoxColumn.DataPropertyName = "WeekendNameContains";
      this.weekendNameContainsDataGridViewTextBoxColumn.HeaderText = "Weekend name";
      this.weekendNameContainsDataGridViewTextBoxColumn.Name = "weekendNameContainsDataGridViewTextBoxColumn";
      this.weekendNameContainsDataGridViewTextBoxColumn.ToolTipText = "Name of the weekend (contains), or null for all weekends";
      this.weekendNameContainsDataGridViewTextBoxColumn.Width = 200;
      // 
      // trackNameContainsDataGridViewTextBoxColumn
      // 
      this.trackNameContainsDataGridViewTextBoxColumn.DataPropertyName = "TrackNameContains";
      this.trackNameContainsDataGridViewTextBoxColumn.HeaderText = "Track name";
      this.trackNameContainsDataGridViewTextBoxColumn.Name = "trackNameContainsDataGridViewTextBoxColumn";
      this.trackNameContainsDataGridViewTextBoxColumn.ToolTipText = "Name of the track (contains), or null for all tracks";
      // 
      // valueDataGridViewTextBoxColumn
      // 
      this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
      this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
      this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
      this.valueDataGridViewTextBoxColumn.ToolTipText = "Requested value";
      // 
      // operatorDataGridViewTextBoxColumn
      // 
      this.operatorDataGridViewTextBoxColumn.DataPropertyName = "Operator";
      this.operatorDataGridViewTextBoxColumn.HeaderText = "Operator";
      this.operatorDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "==",
            "<",
            ">",
            "contains"});
      this.operatorDataGridViewTextBoxColumn.Name = "operatorDataGridViewTextBoxColumn";
      this.operatorDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.operatorDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      this.operatorDataGridViewTextBoxColumn.ToolTipText = "Compare operation";
      // 
      // ColorInHtml
      // 
      this.ColorInHtml.DataPropertyName = "ColorInHtml";
      this.ColorInHtml.HeaderText = "Color (html)";
      this.ColorInHtml.Name = "ColorInHtml";
      // 
      // GridRulesEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1095, 452);
      this.Controls.Add(this.grd);
      this.Controls.Add(this.menuStrip1);
      this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "GridRulesEditor";
      this.Text = "GridRulesEditor";
      ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridRuleBindingSource)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView grd;
    private System.Windows.Forms.BindingSource gridRuleBindingSource;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem reloadCurrentSetToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveCurrentSetToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem importSetToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exportSetToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    private System.Windows.Forms.DataGridViewTextBoxColumn gridTypeNameDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn gridColumnHeaderTextDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn weekendNameContainsDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn trackNameContainsDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewComboBoxColumn operatorDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColorInHtml;
  }
}