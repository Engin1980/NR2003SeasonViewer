namespace ENG.NR2003.NascarSeasonView.Controls
{
  partial class NavigateableTrackSelector
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
      this.btnPrevious = new System.Windows.Forms.Button();
      this.btnLast = new System.Windows.Forms.Button();
      this.btnNext = new System.Windows.Forms.Button();
      this.cmbRaces = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // btnPrevious
      // 
      this.btnPrevious.Dock = System.Windows.Forms.DockStyle.Left;
      this.btnPrevious.Location = new System.Drawing.Point(0, 0);
      this.btnPrevious.Name = "btnPrevious";
      this.btnPrevious.Size = new System.Drawing.Size(41, 35);
      this.btnPrevious.TabIndex = 0;
      this.btnPrevious.Text = "<<";
      this.btnPrevious.UseVisualStyleBackColor = true;
      // 
      // btnLast
      // 
      this.btnLast.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnLast.Location = new System.Drawing.Point(495, 0);
      this.btnLast.Name = "btnLast";
      this.btnLast.Size = new System.Drawing.Size(47, 35);
      this.btnLast.TabIndex = 1;
      this.btnLast.Text = ">>|";
      this.btnLast.UseVisualStyleBackColor = true;
      // 
      // btnNext
      // 
      this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnNext.Location = new System.Drawing.Point(448, 0);
      this.btnNext.Name = "btnNext";
      this.btnNext.Size = new System.Drawing.Size(47, 35);
      this.btnNext.TabIndex = 2;
      this.btnNext.Text = ">>";
      this.btnNext.UseVisualStyleBackColor = true;
      // 
      // cmbRaces
      // 
      this.cmbRaces.Dock = System.Windows.Forms.DockStyle.Top;
      this.cmbRaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbRaces.FormattingEnabled = true;
      this.cmbRaces.Location = new System.Drawing.Point(41, 0);
      this.cmbRaces.Name = "cmbRaces";
      this.cmbRaces.Size = new System.Drawing.Size(407, 21);
      this.cmbRaces.TabIndex = 3;
      this.cmbRaces.SelectedIndexChanged += new System.EventHandler(this.cmbRaces_SelectedIndexChanged);
      // 
      // NavigateableTrackSelector
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.cmbRaces);
      this.Controls.Add(this.btnNext);
      this.Controls.Add(this.btnLast);
      this.Controls.Add(this.btnPrevious);
      this.Name = "NavigateableTrackSelector";
      this.Size = new System.Drawing.Size(542, 35);
      this.Load += new System.EventHandler(this.NavigateableTrackSelector_Load);
      this.Resize += new System.EventHandler(this.NavigateableTrackSelector_Resize);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnPrevious;
    private System.Windows.Forms.Button btnLast;
    private System.Windows.Forms.Button btnNext;
    private System.Windows.Forms.ComboBox cmbRaces;
  }
}
