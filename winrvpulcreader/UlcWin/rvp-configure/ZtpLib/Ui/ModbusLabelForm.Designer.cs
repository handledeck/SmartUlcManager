namespace Ztp.Ui
{
  partial class ModbusLabelForm
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
      this.bCancel = new System.Windows.Forms.Button();
      this.bOk = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.tbModbuslabel = new System.Windows.Forms.TextBox();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // bCancel
      // 
      this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.bCancel.Location = new System.Drawing.Point(315, 36);
      this.bCancel.Name = "bCancel";
      this.bCancel.Size = new System.Drawing.Size(75, 23);
      this.bCancel.TabIndex = 1;
      this.bCancel.Text = "Cancel";
      this.bCancel.UseVisualStyleBackColor = true;
      // 
      // bOk
      // 
      this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.bOk.Location = new System.Drawing.Point(234, 36);
      this.bOk.Name = "bOk";
      this.bOk.Size = new System.Drawing.Size(75, 23);
      this.bOk.TabIndex = 2;
      this.bOk.Text = "OK";
      this.bOk.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(120, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "описание тега modbus";
      // 
      // tbModbuslabel
      // 
      this.tbModbuslabel.Location = new System.Drawing.Point(139, 10);
      this.tbModbuslabel.Name = "tbModbuslabel";
      this.tbModbuslabel.Size = new System.Drawing.Size(251, 20);
      this.tbModbuslabel.TabIndex = 0;
      this.tbModbuslabel.TextChanged += new System.EventHandler(this.tbModbuslabel_TextChanged);
      this.tbModbuslabel.Validating += new System.ComponentModel.CancelEventHandler(this.tbModbuslabel_Validating);
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // ModbusLabelForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(398, 63);
      this.Controls.Add(this.tbModbuslabel);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.bOk);
      this.Controls.Add(this.bCancel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "ModbusLabelForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Описание тега modbus";
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button bCancel;
    private System.Windows.Forms.Button bOk;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbModbuslabel;
    private System.Windows.Forms.ErrorProvider errorProvider1;
  }
}