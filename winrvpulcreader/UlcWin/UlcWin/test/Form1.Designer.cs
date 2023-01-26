namespace UlcWin.test
{
  partial class Form1
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
      this.eventDateTimePicker1 = new UlcWin.Controls.UlcMeterComponet.EventDateTimePicker();
      this.SuspendLayout();
      // 
      // eventDateTimePicker1
      // 
      this.eventDateTimePicker1.Location = new System.Drawing.Point(189, 132);
      this.eventDateTimePicker1.Name = "eventDateTimePicker1";
      this.eventDateTimePicker1.Size = new System.Drawing.Size(200, 20);
      this.eventDateTimePicker1.TabIndex = 0;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.eventDateTimePicker1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.UlcMeterComponet.EventDateTimePicker eventDateTimePicker1;
  }
}