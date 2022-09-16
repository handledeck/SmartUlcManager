namespace UlcWin.win
{
  partial class WaitForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitForm));
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.label1 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.imlWait = new System.Windows.Forms.ImageList(this.components);
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.btnOperation = new System.Windows.Forms.Button();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.listView1 = new System.Windows.Forms.ListView();
      this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.UType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Error = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.flowLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // progressBar
      // 
      this.progressBar.BackColor = System.Drawing.SystemColors.InactiveBorder;
      this.progressBar.ForeColor = System.Drawing.Color.DarkKhaki;
      this.progressBar.Location = new System.Drawing.Point(68, 28);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(701, 32);
      this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
      this.progressBar.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.BackColor = System.Drawing.SystemColors.Control;
      this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
      this.label1.Location = new System.Drawing.Point(71, -1);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(600, 26);
      this.label1.TabIndex = 2;
      this.label1.Text = "Обмен данными с устройством";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(12, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(48, 48);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pictureBox1.TabIndex = 3;
      this.pictureBox1.TabStop = false;
      // 
      // imlWait
      // 
      this.imlWait.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlWait.ImageStream")));
      this.imlWait.TransparentColor = System.Drawing.Color.Magenta;
      this.imlWait.Images.SetKeyName(0, "Frame00.png");
      this.imlWait.Images.SetKeyName(1, "Frame01.png");
      this.imlWait.Images.SetKeyName(2, "Frame02.png");
      this.imlWait.Images.SetKeyName(3, "Frame03.png");
      this.imlWait.Images.SetKeyName(4, "Frame04.png");
      this.imlWait.Images.SetKeyName(5, "Frame05.png");
      this.imlWait.Images.SetKeyName(6, "Frame06.png");
      this.imlWait.Images.SetKeyName(7, "Frame07.png");
      this.imlWait.Images.SetKeyName(8, "Frame08.png");
      this.imlWait.Images.SetKeyName(9, "Frame09.png");
      this.imlWait.Images.SetKeyName(10, "Frame10.png");
      this.imlWait.Images.SetKeyName(11, "Frame11.png");
      this.imlWait.Images.SetKeyName(12, "Frame12.png");
      this.imlWait.Images.SetKeyName(13, "Frame13.png");
      this.imlWait.Images.SetKeyName(14, "Frame14.png");
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "check.ico");
      this.imageList1.Images.SetKeyName(1, "delete2.ico");
      this.imageList1.Images.SetKeyName(2, "refresh.ico");
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.Controls.Add(this.btnOperation);
      this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 416);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(767, 30);
      this.flowLayoutPanel1.TabIndex = 6;
      // 
      // btnOperation
      // 
      this.btnOperation.Location = new System.Drawing.Point(673, 3);
      this.btnOperation.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
      this.btnOperation.Name = "btnOperation";
      this.btnOperation.Size = new System.Drawing.Size(89, 25);
      this.btnOperation.TabIndex = 6;
      this.btnOperation.Text = "Отмена";
      this.btnOperation.UseVisualStyleBackColor = true;
      this.btnOperation.Click += new System.EventHandler(this.button2_Click);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 0);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 66);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(777, 452);
      this.tableLayoutPanel1.TabIndex = 7;
      // 
      // listView1
      // 
      this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Status,
            this.Name,
            this.Ip,
            this.UType,
            this.Error});
      this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.listView1.HideSelection = false;
      this.listView1.Location = new System.Drawing.Point(5, 5);
      this.listView1.MultiSelect = false;
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(767, 403);
      this.listView1.SmallImageList = this.imageList1;
      this.listView1.TabIndex = 5;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      // 
      // Status
      // 
      this.Status.Width = 30;
      // 
      // Name
      // 
      this.Name.Width = 270;
      // 
      // Ip
      // 
      this.Ip.Width = 120;
      // 
      // UType
      // 
      this.UType.Text = "";
      this.UType.Width = 80;
      // 
      // Error
      // 
      this.Error.Text = "";
      this.Error.Width = 250;
      // 
      // WaitForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(777, 515);
      this.ControlBox = false;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.progressBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      //this.Name = "WaitForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Подождите...";
      this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.flowLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.ImageList imlWait;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.ImageList imageList1;
    public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Ip;
        private System.Windows.Forms.ColumnHeader UType;
        private System.Windows.Forms.ColumnHeader Error;
    public System.Windows.Forms.Button btnOperation;
  }
}