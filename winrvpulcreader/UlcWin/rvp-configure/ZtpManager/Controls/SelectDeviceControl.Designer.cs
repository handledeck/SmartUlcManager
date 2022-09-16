namespace ZtpManager.Controls
{
  partial class SelectDeviceControl
  {
    /// <summary> 
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором компонентов

    /// <summary> 
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDeviceControl));
      this.flv = new ZtpManager.Controls.FilteredListViewControl();
      this.iml = new System.Windows.Forms.ImageList(this.components);
      this.tabControl = new System.Windows.Forms.TabControl();
      this.tpTree = new System.Windows.Forms.TabPage();
      this.tv = new ZtpManager.Controls.DeviceTreeView();
      this.imlTv = new System.Windows.Forms.ImageList(this.components);
      this.tpList = new System.Windows.Forms.TabPage();
      this.tabControl.SuspendLayout();
      this.tpTree.SuspendLayout();
      this.tpList.SuspendLayout();
      this.SuspendLayout();
      // 
      // flv
      // 
      this.flv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flv.Location = new System.Drawing.Point(3, 3);
      this.flv.Name = "flv";
      this.flv.Size = new System.Drawing.Size(313, 333);
      this.flv.TabIndex = 0;
      // 
      // iml
      // 
      this.iml.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml.ImageStream")));
      this.iml.TransparentColor = System.Drawing.Color.Transparent;
      this.iml.Images.SetKeyName(0, "PCI-card.png");
      this.iml.Images.SetKeyName(1, "list.png");
      this.iml.Images.SetKeyName(2, "tree_list.png");
      this.iml.Images.SetKeyName(3, "PCI-card_error.png");
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.tpTree);
      this.tabControl.Controls.Add(this.tpList);
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl.ImageList = this.iml;
      this.tabControl.Location = new System.Drawing.Point(0, 0);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(327, 366);
      this.tabControl.TabIndex = 1;
      this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
      // 
      // tpTree
      // 
      this.tpTree.Controls.Add(this.tv);
      this.tpTree.ImageIndex = 2;
      this.tpTree.Location = new System.Drawing.Point(4, 23);
      this.tpTree.Name = "tpTree";
      this.tpTree.Padding = new System.Windows.Forms.Padding(3);
      this.tpTree.Size = new System.Drawing.Size(319, 339);
      this.tpTree.TabIndex = 0;
      this.tpTree.Text = "Дерево";
      this.tpTree.UseVisualStyleBackColor = true;
      // 
      // tv
      // 
      this.tv.AutoCreateTree = true;
      this.tv.CheckBoxes = true;
      this.tv.CheckedNodes = ((System.Collections.Hashtable)(resources.GetObject("tv.CheckedNodes")));
      this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tv.FullRowSelect = true;
      this.tv.HideSelection = false;
      this.tv.ImageIndex = 0;
      this.tv.ImageList = this.imlTv;
      this.tv.Location = new System.Drawing.Point(3, 3);
      this.tv.MultiSelect = Bss.Windows.Forms.Mstv.TreeViewMultiSelect.Classic;
      this.tv.Name = "tv";
      this.tv.RubberbandGradientBlend = new Bss.Windows.Forms.Mstv.MWRubberbandGradientBlend[0];
      this.tv.RubberbandGradientColorBlend = new Bss.Windows.Forms.Mstv.MWRubberbandGradientColorBlend[0];
      this.tv.SelectedImageIndex = 0;
      this.tv.SelNodes = ((System.Collections.Hashtable)(resources.GetObject("tv.SelNodes")));
      this.tv.Size = new System.Drawing.Size(313, 333);
      this.tv.TabIndex = 0;
      // 
      // imlTv
      // 
      this.imlTv.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTv.ImageStream")));
      this.imlTv.TransparentColor = System.Drawing.Color.Transparent;
      this.imlTv.Images.SetKeyName(0, "folders_explorer.png");
      this.imlTv.Images.SetKeyName(1, "folder.png");
      this.imlTv.Images.SetKeyName(2, "PCI-card.png");
      this.imlTv.Images.SetKeyName(3, "PCI-card_error.png");
      // 
      // tpList
      // 
      this.tpList.Controls.Add(this.flv);
      this.tpList.ImageIndex = 1;
      this.tpList.Location = new System.Drawing.Point(4, 23);
      this.tpList.Name = "tpList";
      this.tpList.Padding = new System.Windows.Forms.Padding(3);
      this.tpList.Size = new System.Drawing.Size(319, 339);
      this.tpList.TabIndex = 1;
      this.tpList.Text = "Список";
      this.tpList.UseVisualStyleBackColor = true;
      // 
      // SelectDeviceControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tabControl);
      this.Name = "SelectDeviceControl";
      this.Size = new System.Drawing.Size(327, 366);
      this.tabControl.ResumeLayout(false);
      this.tpTree.ResumeLayout(false);
      this.tpList.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private FilteredListViewControl flv;
    private System.Windows.Forms.ImageList iml;
    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tpList;
    private System.Windows.Forms.ImageList imlTv;
    private System.Windows.Forms.TabPage tpTree;
    private DeviceTreeView tv;
  }
}
