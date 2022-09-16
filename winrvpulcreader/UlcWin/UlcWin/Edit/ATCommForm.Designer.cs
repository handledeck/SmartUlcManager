namespace UlcWin.Edit
{
  partial class ATCommForm
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnExit = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.cbAtCommand = new System.Windows.Forms.ComboBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.63348F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.36652F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(538, 493);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.btnClear);
      this.panel3.Controls.Add(this.btnExit);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(6, 450);
      this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(526, 38);
      this.panel3.TabIndex = 2;
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(366, 7);
      this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(78, 23);
      this.btnClear.TabIndex = 1;
      this.btnClear.Text = "Очистить";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // btnExit
      // 
      this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnExit.Location = new System.Drawing.Point(450, 7);
      this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(72, 23);
      this.btnExit.TabIndex = 0;
      this.btnExit.Text = "Выход";
      this.btnExit.UseVisualStyleBackColor = true;
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.cbAtCommand);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(6, 5);
      this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(526, 43);
      this.panel1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(256, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Вводите команду или выбирите из списка";
      // 
      // cbAtCommand
      // 
      this.cbAtCommand.FormattingEnabled = true;
      this.cbAtCommand.Location = new System.Drawing.Point(270, 15);
      this.cbAtCommand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.cbAtCommand.Name = "cbAtCommand";
      this.cbAtCommand.Size = new System.Drawing.Size(246, 21);
      this.cbAtCommand.TabIndex = 0;
      this.cbAtCommand.SelectedIndexChanged += new System.EventHandler(this.cbAtCommand_SelectedIndexChanged);
      this.cbAtCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAtCommand_KeyPress);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.richTextBox1);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(6, 53);
      this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(526, 392);
      this.panel2.TabIndex = 1;
      // 
      // richTextBox1
      // 
      this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.richTextBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.richTextBox1.Location = new System.Drawing.Point(0, 0);
      this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new System.Drawing.Size(526, 392);
      this.richTextBox1.TabIndex = 0;
      this.richTextBox1.Text = "";
      // 
      // ATCommForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(538, 493);
      this.ControlBox = false;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.HelpButton = true;
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ATCommForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Редактор АТ команд";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbAtCommand;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
    }
}