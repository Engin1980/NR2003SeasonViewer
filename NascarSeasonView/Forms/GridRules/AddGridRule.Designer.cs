namespace ENG.NR2003.NascarSeasonView.Forms.GridRules
{
  partial class AddGridRule
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.rdbGridAll = new System.Windows.Forms.RadioButton();
      this.rdbGridCurrentOnly = new System.Windows.Forms.RadioButton();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.txtWeekendContains = new System.Windows.Forms.TextBox();
      this.rdbWeekendAll = new System.Windows.Forms.RadioButton();
      this.rdbWeekendContains = new System.Windows.Forms.RadioButton();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.txtTrackContains = new System.Windows.Forms.TextBox();
      this.rdbTrackAll = new System.Windows.Forms.RadioButton();
      this.rdbTrackContains = new System.Windows.Forms.RadioButton();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.cmbHeaderText = new System.Windows.Forms.ComboBox();
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.txtValue = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cmbOperation = new System.Windows.Forms.ComboBox();
      this.btnOk = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.groupBox6 = new System.Windows.Forms.GroupBox();
      this.btnChangeColor = new System.Windows.Forms.Button();
      this.picBackgroundColor = new System.Windows.Forms.PictureBox();
      this.dlgColor = new System.Windows.Forms.ColorDialog();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.groupBox6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picBackgroundColor)).BeginInit();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.rdbGridAll);
      this.groupBox1.Controls.Add(this.rdbGridCurrentOnly);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(494, 55);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Grid:";
      // 
      // rdbGridAll
      // 
      this.rdbGridAll.AutoSize = true;
      this.rdbGridAll.Checked = true;
      this.rdbGridAll.Location = new System.Drawing.Point(375, 22);
      this.rdbGridAll.Name = "rdbGridAll";
      this.rdbGridAll.Size = new System.Drawing.Size(61, 17);
      this.rdbGridAll.TabIndex = 1;
      this.rdbGridAll.TabStop = true;
      this.rdbGridAll.Text = "All grids";
      this.rdbGridAll.UseVisualStyleBackColor = true;
      // 
      // rdbGridCurrentOnly
      // 
      this.rdbGridCurrentOnly.AutoSize = true;
      this.rdbGridCurrentOnly.Location = new System.Drawing.Point(6, 22);
      this.rdbGridCurrentOnly.Name = "rdbGridCurrentOnly";
      this.rdbGridCurrentOnly.Size = new System.Drawing.Size(81, 17);
      this.rdbGridCurrentOnly.TabIndex = 0;
      this.rdbGridCurrentOnly.Text = "Current only";
      this.rdbGridCurrentOnly.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.txtWeekendContains);
      this.groupBox2.Controls.Add(this.rdbWeekendAll);
      this.groupBox2.Controls.Add(this.rdbWeekendContains);
      this.groupBox2.Location = new System.Drawing.Point(12, 73);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(494, 55);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Weekend name:";
      // 
      // txtWeekendContains
      // 
      this.txtWeekendContains.Enabled = false;
      this.txtWeekendContains.Location = new System.Drawing.Point(115, 21);
      this.txtWeekendContains.Name = "txtWeekendContains";
      this.txtWeekendContains.Size = new System.Drawing.Size(229, 23);
      this.txtWeekendContains.TabIndex = 1;
      // 
      // rdbWeekendAll
      // 
      this.rdbWeekendAll.AutoSize = true;
      this.rdbWeekendAll.Checked = true;
      this.rdbWeekendAll.Location = new System.Drawing.Point(375, 21);
      this.rdbWeekendAll.Name = "rdbWeekendAll";
      this.rdbWeekendAll.Size = new System.Drawing.Size(111, 20);
      this.rdbWeekendAll.TabIndex = 2;
      this.rdbWeekendAll.TabStop = true;
      this.rdbWeekendAll.Text = "All weekends";
      this.rdbWeekendAll.UseVisualStyleBackColor = true;
      // 
      // rdbWeekendContains
      // 
      this.rdbWeekendContains.AutoSize = true;
      this.rdbWeekendContains.Location = new System.Drawing.Point(6, 22);
      this.rdbWeekendContains.Name = "rdbWeekendContains";
      this.rdbWeekendContains.Size = new System.Drawing.Size(83, 20);
      this.rdbWeekendContains.TabIndex = 0;
      this.rdbWeekendContains.Text = "Contains";
      this.rdbWeekendContains.UseVisualStyleBackColor = true;
      this.rdbWeekendContains.CheckedChanged += new System.EventHandler(this.rdbWeekendContains_CheckedChanged);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.txtTrackContains);
      this.groupBox3.Controls.Add(this.rdbTrackAll);
      this.groupBox3.Controls.Add(this.rdbTrackContains);
      this.groupBox3.Location = new System.Drawing.Point(12, 134);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(494, 55);
      this.groupBox3.TabIndex = 2;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Track name:";
      // 
      // txtTrackContains
      // 
      this.txtTrackContains.Enabled = false;
      this.txtTrackContains.Location = new System.Drawing.Point(115, 21);
      this.txtTrackContains.Name = "txtTrackContains";
      this.txtTrackContains.Size = new System.Drawing.Size(229, 23);
      this.txtTrackContains.TabIndex = 1;
      // 
      // rdbTrackAll
      // 
      this.rdbTrackAll.AutoSize = true;
      this.rdbTrackAll.Checked = true;
      this.rdbTrackAll.Location = new System.Drawing.Point(375, 21);
      this.rdbTrackAll.Name = "rdbTrackAll";
      this.rdbTrackAll.Size = new System.Drawing.Size(87, 20);
      this.rdbTrackAll.TabIndex = 2;
      this.rdbTrackAll.TabStop = true;
      this.rdbTrackAll.Text = "All tracks";
      this.rdbTrackAll.UseVisualStyleBackColor = true;
      // 
      // rdbTrackContains
      // 
      this.rdbTrackContains.AutoSize = true;
      this.rdbTrackContains.Location = new System.Drawing.Point(6, 22);
      this.rdbTrackContains.Name = "rdbTrackContains";
      this.rdbTrackContains.Size = new System.Drawing.Size(83, 20);
      this.rdbTrackContains.TabIndex = 0;
      this.rdbTrackContains.Text = "Contains";
      this.rdbTrackContains.UseVisualStyleBackColor = true;
      this.rdbTrackContains.CheckedChanged += new System.EventHandler(this.rdbTrackContains_CheckedChanged);
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.cmbHeaderText);
      this.groupBox4.Location = new System.Drawing.Point(12, 195);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(494, 55);
      this.groupBox4.TabIndex = 3;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Column header text:";
      // 
      // cmbHeaderText
      // 
      this.cmbHeaderText.FormattingEnabled = true;
      this.cmbHeaderText.Location = new System.Drawing.Point(6, 22);
      this.cmbHeaderText.Name = "cmbHeaderText";
      this.cmbHeaderText.Size = new System.Drawing.Size(338, 24);
      this.cmbHeaderText.TabIndex = 0;
      this.cmbHeaderText.SelectedIndexChanged += new System.EventHandler(this.cmbHeaderText_SelectedIndexChanged);
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.txtValue);
      this.groupBox5.Controls.Add(this.label1);
      this.groupBox5.Controls.Add(this.cmbOperation);
      this.groupBox5.Location = new System.Drawing.Point(12, 256);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(494, 55);
      this.groupBox5.TabIndex = 4;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Comparison:";
      // 
      // txtValue
      // 
      this.txtValue.Location = new System.Drawing.Point(259, 25);
      this.txtValue.Name = "txtValue";
      this.txtValue.Size = new System.Drawing.Size(227, 23);
      this.txtValue.TabIndex = 2;
      this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 28);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(103, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Columnn value";
      // 
      // cmbOperation
      // 
      this.cmbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbOperation.FormattingEnabled = true;
      this.cmbOperation.Items.AddRange(new object[] {
            "==",
            "<",
            ">",
            "contains"});
      this.cmbOperation.Location = new System.Drawing.Point(115, 25);
      this.cmbOperation.Name = "cmbOperation";
      this.cmbOperation.Size = new System.Drawing.Size(138, 24);
      this.cmbOperation.TabIndex = 1;
      this.cmbOperation.SelectedIndexChanged += new System.EventHandler(this.cmbOperation_SelectedIndexChanged);
      // 
      // btnOk
      // 
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Enabled = false;
      this.btnOk.Location = new System.Drawing.Point(407, 378);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(99, 30);
      this.btnOk.TabIndex = 5;
      this.btnOk.Text = "&Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.button2.Location = new System.Drawing.Point(12, 378);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(99, 30);
      this.button2.TabIndex = 6;
      this.button2.Text = "&Cancel";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // groupBox6
      // 
      this.groupBox6.Controls.Add(this.btnChangeColor);
      this.groupBox6.Controls.Add(this.picBackgroundColor);
      this.groupBox6.Location = new System.Drawing.Point(12, 317);
      this.groupBox6.Name = "groupBox6";
      this.groupBox6.Size = new System.Drawing.Size(494, 55);
      this.groupBox6.TabIndex = 5;
      this.groupBox6.TabStop = false;
      this.groupBox6.Text = "Background color to set:";
      // 
      // btnChangeColor
      // 
      this.btnChangeColor.Location = new System.Drawing.Point(9, 22);
      this.btnChangeColor.Name = "btnChangeColor";
      this.btnChangeColor.Size = new System.Drawing.Size(100, 27);
      this.btnChangeColor.TabIndex = 1;
      this.btnChangeColor.Text = "(change)";
      this.btnChangeColor.UseVisualStyleBackColor = true;
      this.btnChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
      // 
      // picBackgroundColor
      // 
      this.picBackgroundColor.BackColor = System.Drawing.Color.White;
      this.picBackgroundColor.Location = new System.Drawing.Point(115, 22);
      this.picBackgroundColor.Name = "picBackgroundColor";
      this.picBackgroundColor.Size = new System.Drawing.Size(371, 27);
      this.picBackgroundColor.TabIndex = 0;
      this.picBackgroundColor.TabStop = false;
      // 
      // dlgColor
      // 
      this.dlgColor.Color = System.Drawing.Color.White;
      // 
      // AddGridRule
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(515, 414);
      this.Controls.Add(this.groupBox6);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.groupBox5);
      this.Controls.Add(this.groupBox4);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "AddGridRule";
      this.Text = "Add new grid rule";
      this.Load += new System.EventHandler(this.AddGridRule_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.groupBox6.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.picBackgroundColor)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton rdbGridAll;
    private System.Windows.Forms.RadioButton rdbGridCurrentOnly;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox txtWeekendContains;
    private System.Windows.Forms.RadioButton rdbWeekendAll;
    private System.Windows.Forms.RadioButton rdbWeekendContains;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.TextBox txtTrackContains;
    private System.Windows.Forms.RadioButton rdbTrackAll;
    private System.Windows.Forms.RadioButton rdbTrackContains;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.ComboBox cmbHeaderText;
    private System.Windows.Forms.GroupBox groupBox5;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cmbOperation;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox txtValue;
    private System.Windows.Forms.GroupBox groupBox6;
    private System.Windows.Forms.Button btnChangeColor;
    private System.Windows.Forms.PictureBox picBackgroundColor;
    private System.Windows.Forms.ColorDialog dlgColor;
  }
}