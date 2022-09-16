using System.Windows.Forms;

namespace ZtpManager
{
  partial class MultiConfigForm
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
      Application.Idle -= Application_Idle;
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiConfigForm));
      this.selectDeviceControl = new ZtpManager.Controls.SelectDeviceControl();
      this.panel1 = new System.Windows.Forms.Panel();
      this.partitionConfigEditor = new ZtpManager.Controls.PartitionConfigEditorControl();
      this.panel2 = new System.Windows.Forms.Panel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.pnlFooter = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.selectDevTypeControl = new Ztp.Ui.SelectDevTypeControl();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.pnlFooter.SuspendLayout();
      this.SuspendLayout();
      // 
      // selectDeviceControl
      // 
      this.selectDeviceControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectDeviceControl.Location = new System.Drawing.Point(12, 12);
      this.selectDeviceControl.Name = "selectDeviceControl";
      this.selectDeviceControl.Size = new System.Drawing.Size(352, 467);
      this.selectDeviceControl.TabIndex = 0;
      this.selectDeviceControl.SelectionChanged += new System.EventHandler(this.selectDeviceControl_SelectionChanged);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.partitionConfigEditor);
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel1.Location = new System.Drawing.Point(370, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(558, 503);
      this.panel1.TabIndex = 1;
      // 
      // partitionConfigEditor
      // 
      this.partitionConfigEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.partitionConfigEditor.Location = new System.Drawing.Point(12, 60);
      this.partitionConfigEditor.Name = "partitionConfigEditor";
      this.partitionConfigEditor.Size = new System.Drawing.Size(543, 431);
      this.partitionConfigEditor.TabIndex = 1;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.pictureBox1);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(558, 54);
      this.panel2.TabIndex = 0;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(3, 3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(48, 48);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(57, 14);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(478, 26);
      this.label1.TabIndex = 0;
      this.label1.Text = "Внимание!\r\nБудут записаны все отмеченные Вами параметры конфигурации на выбранные" +
    " устройства.\r\n";
      // 
      // pnlFooter
      // 
      this.pnlFooter.Controls.Add(this.label2);
      this.pnlFooter.Controls.Add(this.btnCancel);
      this.pnlFooter.Controls.Add(this.btnOk);
      this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlFooter.Location = new System.Drawing.Point(0, 503);
      this.pnlFooter.Name = "pnlFooter";
      this.pnlFooter.Size = new System.Drawing.Size(928, 48);
      this.pnlFooter.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(21, 18);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "label2";
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(841, 13);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(760, 13);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 0;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // selectDevTypeControl
      // 
      this.selectDevTypeControl.Caption = "Тип устройства";
      this.selectDevTypeControl.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.selectDevTypeControl.Location = new System.Drawing.Point(0, 477);
      this.selectDevTypeControl.Name = "selectDevTypeControl";
      this.selectDevTypeControl.Size = new System.Drawing.Size(370, 26);
      this.selectDevTypeControl.TabIndex = 3;
      this.selectDevTypeControl.Value = Ztp.Enums.DevType.RVP18;
      // 
      // MultiConfigForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(928, 551);
      this.Controls.Add(this.selectDevTypeControl);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.selectDeviceControl);
      this.Controls.Add(this.pnlFooter);
      this.MinimizeBox = false;
      this.Name = "MultiConfigForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Пакетное изменение параметров устройств";
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.pnlFooter.ResumeLayout(false);
      this.pnlFooter.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.SelectDeviceControl selectDeviceControl;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label1;
    private Controls.PartitionConfigEditorControl partitionConfigEditor;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Panel pnlFooter;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOk;
    private Label label2;
    private Ztp.Ui.SelectDevTypeControl selectDevTypeControl;
  }
}