namespace UlcWin.test
{
  partial class MapForm
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
      this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
      this.SuspendLayout();
      // 
      // gMapControl1
      // 
      this.gMapControl1.Bearing = 0F;
      this.gMapControl1.CanDragMap = true;
      this.gMapControl1.GrayScaleMode = false;
      this.gMapControl1.LevelsKeepInMemmory = 5;
      this.gMapControl1.Location = new System.Drawing.Point(146, 82);
      this.gMapControl1.MarkersEnabled = true;
      this.gMapControl1.MaxZoom = 2;
      this.gMapControl1.MinZoom = 2;
      this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
      this.gMapControl1.Name = "gMapControl1";
      this.gMapControl1.NegativeMode = false;
      this.gMapControl1.PolygonsEnabled = true;
      this.gMapControl1.RetryLoadTile = 0;
      this.gMapControl1.RoutesEnabled = true;
      this.gMapControl1.ShowTileGridLines = false;
      this.gMapControl1.Size = new System.Drawing.Size(248, 233);
      this.gMapControl1.TabIndex = 1;
      this.gMapControl1.Zoom = 0D;
      this.gMapControl1.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControl1_OnMarkerClick);
      this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load);
      // 
      // MapForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.gMapControl1);
      this.Name = "MapForm";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private GMap.NET.WindowsForms.GMapControl gMapControl1;
  }
}