namespace ENG.NR2003.NascarSeasonView.Forms
{
  partial class FrmViewDetails
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
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewDetails));
      this.pnlTop = new System.Windows.Forms.Panel();
      this.cmbChartType = new System.Windows.Forms.ComboBox();
      this.lblChartType = new System.Windows.Forms.Label();
      this.btnDraw = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.cmbY = new System.Windows.Forms.ComboBox();
      this.cmbX = new System.Windows.Forms.ComboBox();
      this.txtFilter = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cmbS = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.chcChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.ttp = new System.Windows.Forms.ToolTip(this.components);
      this.txtDataFilter = new System.Windows.Forms.TextBox();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.grd = new System.Windows.Forms.DataGridView();
      this.pnlTop2 = new System.Windows.Forms.Panel();
      this.btnApplyFilter = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.cmbF = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.btnRemoveSelectedFilter = new System.Windows.Forms.Button();
      this.lstFilters = new System.Windows.Forms.ListBox();
      this.pnlTop.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chcChart)).BeginInit();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
      this.pnlTop2.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlTop
      // 
      this.pnlTop.Controls.Add(this.cmbChartType);
      this.pnlTop.Controls.Add(this.lblChartType);
      this.pnlTop.Controls.Add(this.btnDraw);
      this.pnlTop.Controls.Add(this.label4);
      this.pnlTop.Controls.Add(this.label3);
      this.pnlTop.Controls.Add(this.cmbY);
      this.pnlTop.Controls.Add(this.cmbX);
      this.pnlTop.Controls.Add(this.txtFilter);
      this.pnlTop.Controls.Add(this.label2);
      this.pnlTop.Controls.Add(this.cmbS);
      this.pnlTop.Controls.Add(this.label1);
      this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlTop.Location = new System.Drawing.Point(3, 3);
      this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
      this.pnlTop.Name = "pnlTop";
      this.pnlTop.Size = new System.Drawing.Size(859, 65);
      this.pnlTop.TabIndex = 0;
      // 
      // cmbChartType
      // 
      this.cmbChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbChartType.FormattingEnabled = true;
      this.cmbChartType.Location = new System.Drawing.Point(674, 35);
      this.cmbChartType.Name = "cmbChartType";
      this.cmbChartType.Size = new System.Drawing.Size(170, 24);
      this.cmbChartType.TabIndex = 10;
      // 
      // lblChartType
      // 
      this.lblChartType.AutoSize = true;
      this.lblChartType.Location = new System.Drawing.Point(671, 9);
      this.lblChartType.Name = "lblChartType";
      this.lblChartType.Size = new System.Drawing.Size(85, 16);
      this.lblChartType.TabIndex = 9;
      this.lblChartType.Text = "Chart type:";
      // 
      // btnDraw
      // 
      this.btnDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDraw.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnDraw.Location = new System.Drawing.Point(748, 5);
      this.btnDraw.Name = "btnDraw";
      this.btnDraw.Size = new System.Drawing.Size(99, 54);
      this.btnDraw.TabIndex = 8;
      this.btnDraw.Text = "&Draw";
      this.btnDraw.UseVisualStyleBackColor = true;
      this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(323, 39);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(53, 16);
      this.label4.TabIndex = 7;
      this.label4.Text = "Y axis:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 39);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(53, 16);
      this.label3.TabIndex = 6;
      this.label3.Text = "X axis:";
      // 
      // cmbY
      // 
      this.cmbY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbY.FormattingEnabled = true;
      this.cmbY.Location = new System.Drawing.Point(411, 36);
      this.cmbY.Name = "cmbY";
      this.cmbY.Size = new System.Drawing.Size(236, 24);
      this.cmbY.TabIndex = 5;
      // 
      // cmbX
      // 
      this.cmbX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbX.FormattingEnabled = true;
      this.cmbX.Location = new System.Drawing.Point(72, 36);
      this.cmbX.Name = "cmbX";
      this.cmbX.Size = new System.Drawing.Size(236, 24);
      this.cmbX.TabIndex = 4;
      // 
      // txtFilter
      // 
      this.txtFilter.Location = new System.Drawing.Point(411, 6);
      this.txtFilter.Name = "txtFilter";
      this.txtFilter.Size = new System.Drawing.Size(236, 23);
      this.txtFilter.TabIndex = 3;
      this.ttp.SetToolTip(this.txtFilter, "Insert items delimited by \";\" or leave empty");
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(323, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(82, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "containing:";
      // 
      // cmbS
      // 
      this.cmbS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbS.FormattingEnabled = true;
      this.cmbS.Location = new System.Drawing.Point(72, 6);
      this.cmbS.Name = "cmbS";
      this.cmbS.Size = new System.Drawing.Size(236, 24);
      this.cmbS.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(54, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Series:";
      // 
      // chcChart
      // 
      chartArea1.Name = "ChartArea1";
      this.chcChart.ChartAreas.Add(chartArea1);
      this.chcChart.Dock = System.Windows.Forms.DockStyle.Fill;
      legend1.Name = "Legend1";
      this.chcChart.Legends.Add(legend1);
      this.chcChart.Location = new System.Drawing.Point(3, 68);
      this.chcChart.Name = "chcChart";
      series1.ChartArea = "ChartArea1";
      series1.Legend = "Legend1";
      series1.Name = "Series1";
      this.chcChart.Series.Add(series1);
      this.chcChart.Size = new System.Drawing.Size(859, 419);
      this.chcChart.TabIndex = 1;
      this.chcChart.Text = "chart1";
      // 
      // txtDataFilter
      // 
      this.txtDataFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDataFilter.Location = new System.Drawing.Point(664, 9);
      this.txtDataFilter.Name = "txtDataFilter";
      this.txtDataFilter.Size = new System.Drawing.Size(190, 23);
      this.txtDataFilter.TabIndex = 5;
      this.ttp.SetToolTip(this.txtDataFilter, "Values separated by \";\" or empty");
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(873, 519);
      this.tabControl1.TabIndex = 2;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.chcChart);
      this.tabPage1.Controls.Add(this.pnlTop);
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(865, 490);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Graph";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.grd);
      this.tabPage2.Controls.Add(this.pnlTop2);
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(865, 490);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Data";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // grd
      // 
      this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grd.Location = new System.Drawing.Point(3, 73);
      this.grd.Name = "grd";
      this.grd.Size = new System.Drawing.Size(859, 414);
      this.grd.TabIndex = 1;
      // 
      // pnlTop2
      // 
      this.pnlTop2.Controls.Add(this.btnApplyFilter);
      this.pnlTop2.Controls.Add(this.txtDataFilter);
      this.pnlTop2.Controls.Add(this.label6);
      this.pnlTop2.Controls.Add(this.cmbF);
      this.pnlTop2.Controls.Add(this.label5);
      this.pnlTop2.Controls.Add(this.btnRemoveSelectedFilter);
      this.pnlTop2.Controls.Add(this.lstFilters);
      this.pnlTop2.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlTop2.Location = new System.Drawing.Point(3, 3);
      this.pnlTop2.Name = "pnlTop2";
      this.pnlTop2.Size = new System.Drawing.Size(859, 70);
      this.pnlTop2.TabIndex = 0;
      // 
      // btnApplyFilter
      // 
      this.btnApplyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnApplyFilter.Location = new System.Drawing.Point(732, 38);
      this.btnApplyFilter.Name = "btnApplyFilter";
      this.btnApplyFilter.Size = new System.Drawing.Size(122, 26);
      this.btnApplyFilter.TabIndex = 6;
      this.btnApplyFilter.Text = "&Apply filter";
      this.btnApplyFilter.UseVisualStyleBackColor = true;
      this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(632, 12);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(26, 16);
      this.label6.TabIndex = 4;
      this.label6.Text = "==";
      // 
      // cmbF
      // 
      this.cmbF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbF.FormattingEnabled = true;
      this.cmbF.Location = new System.Drawing.Point(424, 9);
      this.cmbF.Name = "cmbF";
      this.cmbF.Size = new System.Drawing.Size(202, 24);
      this.cmbF.TabIndex = 3;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(294, 12);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(124, 16);
      this.label5.TabIndex = 2;
      this.label5.Text = "Define filter over:";
      // 
      // btnRemoveSelectedFilter
      // 
      this.btnRemoveSelectedFilter.Location = new System.Drawing.Point(245, 37);
      this.btnRemoveSelectedFilter.Name = "btnRemoveSelectedFilter";
      this.btnRemoveSelectedFilter.Size = new System.Drawing.Size(75, 28);
      this.btnRemoveSelectedFilter.TabIndex = 1;
      this.btnRemoveSelectedFilter.Text = "Remove";
      this.btnRemoveSelectedFilter.UseVisualStyleBackColor = true;
      this.btnRemoveSelectedFilter.Click += new System.EventHandler(this.btnRemoveSelectedFilter_Click);
      // 
      // lstFilters
      // 
      this.lstFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.lstFilters.FormattingEnabled = true;
      this.lstFilters.IntegralHeight = false;
      this.lstFilters.ItemHeight = 16;
      this.lstFilters.Location = new System.Drawing.Point(5, 6);
      this.lstFilters.Name = "lstFilters";
      this.lstFilters.Size = new System.Drawing.Size(234, 58);
      this.lstFilters.TabIndex = 0;
      // 
      // FrmViewDetails
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(873, 519);
      this.Controls.Add(this.tabControl1);
      this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "FrmViewDetails";
      this.Text = "FrmChart";
      this.pnlTop.ResumeLayout(false);
      this.pnlTop.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.chcChart)).EndInit();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
      this.pnlTop2.ResumeLayout(false);
      this.pnlTop2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlTop;
    private System.Windows.Forms.DataVisualization.Charting.Chart chcChart;
    private System.Windows.Forms.Button btnDraw;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cmbY;
    private System.Windows.Forms.ComboBox cmbX;
    private System.Windows.Forms.TextBox txtFilter;
    private System.Windows.Forms.ToolTip ttp;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cmbS;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblChartType;
    private System.Windows.Forms.ComboBox cmbChartType;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.DataGridView grd;
    private System.Windows.Forms.Panel pnlTop2;
    private System.Windows.Forms.ListBox lstFilters;
    private System.Windows.Forms.Button btnApplyFilter;
    private System.Windows.Forms.TextBox txtDataFilter;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox cmbF;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btnRemoveSelectedFilter;
  }
}