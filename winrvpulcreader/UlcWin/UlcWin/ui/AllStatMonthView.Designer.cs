namespace UlcWin.ui
{
  partial class AllStatMonthView
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
      this.usrUlcChartCtrl1 = new GraphStatic.UsrUlcChartCtrl();
      this.SuspendLayout();
      // 
      // usrUlcChartCtrl1
      // 
      this.usrUlcChartCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.usrUlcChartCtrl1.Location = new System.Drawing.Point(0, 0);
      this.usrUlcChartCtrl1.Name = "usrUlcChartCtrl1";
      this.usrUlcChartCtrl1.Size = new System.Drawing.Size(1042, 593);
      this.usrUlcChartCtrl1.TabIndex = 0;
      // 
      // AllStatMonthView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1042, 593);
      this.Controls.Add(this.usrUlcChartCtrl1);
      this.Name = "AllStatMonthView";
      this.Text = "AllStatMonthView";
      this.ResumeLayout(false);

    }

        #endregion

        private GraphStatic.UsrUlcChartCtrl usrUlcChartCtrl1;
    }
}