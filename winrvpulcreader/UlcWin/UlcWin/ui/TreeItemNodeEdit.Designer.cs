namespace UlcWin.ui
{
  partial class TreeItemNodeForm
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
      this.lblName = new System.Windows.Forms.Label();
      this.btnCancel = new System.Windows.Forms.Button();
      this.btnOk = new System.Windows.Forms.Button();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.txtNodeName = new UlcWin.ui.TextBoxPlaceHolder();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.Location = new System.Drawing.Point(9, 20);
      this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(81, 13);
      this.lblName.TabIndex = 0;
      this.lblName.Text = "Имя объекта";
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(284, 75);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(66, 21);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "Отмена";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(214, 75);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(66, 21);
      this.btnOk.TabIndex = 3;
      this.btnOk.Text = "Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // txtNodeName
      // 
      this.txtNodeName.CueText = "Макс. 32 символа";
      this.txtNodeName.IsValid = false;
      this.txtNodeName.Location = new System.Drawing.Point(10, 36);
      this.txtNodeName.MaxLength = 32;
      this.txtNodeName.Name = "txtNodeName";
      this.txtNodeName.Size = new System.Drawing.Size(340, 21);
      this.txtNodeName.TabIndex = 4;
      // 
      // TreeItemNodeForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(366, 105);
      this.ControlBox = false;
      this.Controls.Add(this.txtNodeName);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.lblName);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "TreeItemNodeForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Редактор объекта";
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        public System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public TextBoxPlaceHolder txtNodeName;
    }
}