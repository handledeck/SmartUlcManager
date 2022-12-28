namespace UlcWin.ui
{
  partial class MeterForm
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
      this.label1 = new System.Windows.Forms.Label();
      this.lblObject = new System.Windows.Forms.Label();
      this.lstViewMeter = new System.Windows.Forms.ListView();
      this.colMeterType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colMeterFactory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colMeterValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.btnRun = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnCancel = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(9, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(63, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Объект";
      // 
      // lblObject
      // 
      this.lblObject.AutoSize = true;
      this.lblObject.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblObject.Location = new System.Drawing.Point(78, 23);
      this.lblObject.Name = "lblObject";
      this.lblObject.Size = new System.Drawing.Size(110, 16);
      this.lblObject.TabIndex = 1;
      this.lblObject.Text = "Объект опроса";
      // 
      // lstViewMeter
      // 
      this.lstViewMeter.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.lstViewMeter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMeterType,
            this.colMeterFactory,
            this.colMeterValue});
      this.lstViewMeter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstViewMeter.HideSelection = false;
      this.lstViewMeter.Location = new System.Drawing.Point(5, 5);
      this.lstViewMeter.Name = "lstViewMeter";
      this.lstViewMeter.Size = new System.Drawing.Size(612, 237);
      this.lstViewMeter.TabIndex = 2;
      this.lstViewMeter.UseCompatibleStateImageBehavior = false;
      this.lstViewMeter.View = System.Windows.Forms.View.Details;
      // 
      // colMeterType
      // 
      this.colMeterType.Text = "Тип счетчика";
      this.colMeterType.Width = 147;
      // 
      // colMeterFactory
      // 
      this.colMeterFactory.Text = "Номер счетчика";
      this.colMeterFactory.Width = 217;
      // 
      // colMeterValue
      // 
      this.colMeterValue.Text = "Значение";
      this.colMeterValue.Width = 217;
      // 
      // btnRun
      // 
      this.btnRun.Location = new System.Drawing.Point(444, 325);
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new System.Drawing.Size(87, 23);
      this.btnRun.TabIndex = 3;
      this.btnRun.Text = "Выполнить";
      this.btnRun.UseVisualStyleBackColor = true;
      this.btnRun.Click += new System.EventHandler(this.button1_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::UlcWin.Properties.Resources._1488;
      this.pictureBox1.Location = new System.Drawing.Point(574, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(60, 42);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 4;
      this.pictureBox1.TabStop = false;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.lstViewMeter);
      this.panel1.Location = new System.Drawing.Point(12, 60);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(5);
      this.panel1.Size = new System.Drawing.Size(622, 247);
      this.panel1.TabIndex = 5;
      this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(547, 325);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(87, 23);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "Выход";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // MeterForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(646, 360);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.btnRun);
      this.Controls.Add(this.lblObject);
      this.Controls.Add(this.label1);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MeterForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Опрос счетчиков объекта";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblObject;
        private System.Windows.Forms.ListView lstViewMeter;
        private System.Windows.Forms.ColumnHeader colMeterType;
        private System.Windows.Forms.ColumnHeader colMeterFactory;
        private System.Windows.Forms.ColumnHeader colMeterValue;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
    }
}