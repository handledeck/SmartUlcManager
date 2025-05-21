
namespace Uart
{
  partial class UartEditor
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
      this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
      this.labHeader = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btOk = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.propertyGrid1, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.labHeader, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(354, 327);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // propertyGrid1
      // 
      this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertyGrid1.Location = new System.Drawing.Point(6, 48);
      this.propertyGrid1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.propertyGrid1.Name = "propertyGrid1";
      this.propertyGrid1.Size = new System.Drawing.Size(342, 234);
      this.propertyGrid1.TabIndex = 0;
      this.propertyGrid1.ToolbarVisible = false;
      // 
      // labHeader
      // 
      this.labHeader.AutoSize = true;
      this.labHeader.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labHeader.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.labHeader.Location = new System.Drawing.Point(6, 2);
      this.labHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labHeader.Name = "labHeader";
      this.labHeader.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
      this.labHeader.Size = new System.Drawing.Size(342, 41);
      this.labHeader.TabIndex = 1;
      this.labHeader.Text = "Caption";
      this.labHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btOk);
      this.panel1.Controls.Add(this.button1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(5, 290);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(344, 32);
      this.panel1.TabIndex = 2;
      // 
      // btOk
      // 
      this.btOk.Location = new System.Drawing.Point(199, 3);
      this.btOk.Name = "btOk";
      this.btOk.Size = new System.Drawing.Size(66, 26);
      this.btOk.TabIndex = 1;
      this.btOk.Text = "Ok";
      this.btOk.UseVisualStyleBackColor = true;
      this.btOk.Click += new System.EventHandler(this.btOk_Click);
      // 
      // button1
      // 
      this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.button1.Location = new System.Drawing.Point(271, 3);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(66, 26);
      this.button1.TabIndex = 0;
      this.button1.Text = "Отмена";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // UartEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(354, 327);
      this.ControlBox = false;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "UartEditor";
      this.ShowIcon = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Редактор тегов";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.PropertyGrid propertyGrid1;
    private System.Windows.Forms.Label labHeader;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btOk;
    private System.Windows.Forms.Button button1;
  }
}