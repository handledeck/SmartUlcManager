namespace UlcWin
{
  partial class EventForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventForm));
      this.listView1 = new System.Windows.Forms.ListView();
      this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Evt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.EvtImageList = new System.Windows.Forms.ImageList(this.components);
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnSave = new System.Windows.Forms.Button();
      this.evtDsc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.tableLayoutPanel1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // listView1
      // 
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Evt,
            this.evtDsc});
      this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.listView1.HideSelection = false;
      this.listView1.Location = new System.Drawing.Point(3, 3);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(835, 602);
      this.listView1.SmallImageList = this.EvtImageList;
      this.listView1.TabIndex = 0;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      // 
      // Date
      // 
      this.Date.Text = "Дата и время";
      this.Date.Width = 181;
      // 
      // Evt
      // 
      this.Evt.Text = "Событие";
      this.Evt.Width = 168;
      // 
      // EvtImageList
      // 
      this.EvtImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("EvtImageList.ImageStream")));
      this.EvtImageList.TransparentColor = System.Drawing.Color.Transparent;
      this.EvtImageList.Images.SetKeyName(0, "information.png");
      this.EvtImageList.Images.SetKeyName(1, "warning.png");
      this.EvtImageList.Images.SetKeyName(2, "bug_green.png");
      this.EvtImageList.Images.SetKeyName(3, "error.png");
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.40491F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.595092F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(841, 652);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnSave);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(3, 611);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(835, 38);
      this.panel1.TabIndex = 1;
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(737, 6);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(89, 23);
      this.btnSave.TabIndex = 1;
      this.btnSave.Text = "Ок";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // evtDsc
      // 
      this.evtDsc.Text = "Комментарий";
      this.evtDsc.Width = 447;
      // 
      // EventForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(841, 652);
      this.Controls.Add(this.tableLayoutPanel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "EventForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Журнал сообщений контроллера";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Evt;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ImageList EvtImageList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.ColumnHeader evtDsc;
  }
}