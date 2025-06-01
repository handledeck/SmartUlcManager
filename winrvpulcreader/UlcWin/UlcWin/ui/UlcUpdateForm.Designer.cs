using Ulc.Controls;
using UlcWin.Controls;

namespace UlcWin.ui
{
  partial class UlcUpdateForm
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

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.btnRun = new System.Windows.Forms.Button();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.customProgressBar1 = new UlcWin.Controls.CustomProgressBar();
      this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ipaddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.percentDataGridViewTextBoxColumn = new Ulc.Controls.ProgressBarColumn();
      this.timeRunDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cDBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cDBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(1173, 579);
      this.tableLayoutPanel1.TabIndex = 2;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
      this.tableLayoutPanel2.Controls.Add(this.customProgressBar1, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.btnRun, 1, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(1167, 29);
      this.tableLayoutPanel2.TabIndex = 2;
      // 
      // btnRun
      // 
      this.btnRun.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnRun.Location = new System.Drawing.Point(1070, 3);
      this.btnRun.Name = "btnRun";
      this.btnRun.Size = new System.Drawing.Size(94, 23);
      this.btnRun.TabIndex = 1;
      this.btnRun.Text = "Начать";
      this.btnRun.UseVisualStyleBackColor = true;
      this.btnRun.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // dataGridView1
      // 
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.ipaddressDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.messageDataGridViewTextBoxColumn,
            this.percentDataGridViewTextBoxColumn,
            this.timeRunDataGridViewTextBoxColumn});
      this.dataGridView1.DataSource = this.cDBindingSource;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(3, 38);
      this.dataGridView1.MultiSelect = false;
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new System.Drawing.Size(1167, 538);
      this.dataGridView1.TabIndex = 3;
      // 
      // customProgressBar1
      // 
      this.customProgressBar1.CustomText = null;
      this.customProgressBar1.DisplayStyle = UlcWin.Controls.ProgressBarDisplayText.Percentage;
      this.customProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.customProgressBar1.Location = new System.Drawing.Point(3, 3);
      this.customProgressBar1.Name = "customProgressBar1";
      this.customProgressBar1.Size = new System.Drawing.Size(1061, 23);
      this.customProgressBar1.TabIndex = 0;
      // 
      // nameDataGridViewTextBoxColumn
      // 
      this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
      this.nameDataGridViewTextBoxColumn.HeaderText = "Имя";
      this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
      this.nameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // ipaddressDataGridViewTextBoxColumn
      // 
      this.ipaddressDataGridViewTextBoxColumn.DataPropertyName = "ip_address";
      this.ipaddressDataGridViewTextBoxColumn.HeaderText = "Ip адрес";
      this.ipaddressDataGridViewTextBoxColumn.Name = "ipaddressDataGridViewTextBoxColumn";
      // 
      // versionDataGridViewTextBoxColumn
      // 
      this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
      this.versionDataGridViewTextBoxColumn.HeaderText = "Версия";
      this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
      // 
      // messageDataGridViewTextBoxColumn
      // 
      this.messageDataGridViewTextBoxColumn.DataPropertyName = "Message";
      this.messageDataGridViewTextBoxColumn.HeaderText = "Прогресс";
      this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
      // 
      // percentDataGridViewTextBoxColumn
      // 
      this.percentDataGridViewTextBoxColumn.DataPropertyName = "Percent";
      this.percentDataGridViewTextBoxColumn.HeaderText = "% Исполнения";
      this.percentDataGridViewTextBoxColumn.Name = "percentDataGridViewTextBoxColumn";
      this.percentDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.percentDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      // 
      // timeRunDataGridViewTextBoxColumn
      // 
      this.timeRunDataGridViewTextBoxColumn.DataPropertyName = "TimeRun";
      this.timeRunDataGridViewTextBoxColumn.HeaderText = "Время прошивки";
      this.timeRunDataGridViewTextBoxColumn.Name = "timeRunDataGridViewTextBoxColumn";
      // 
      // cDBindingSource
      // 
      this.cDBindingSource.DataSource = typeof(UlcWin.DB.CD);
      // 
      // UlcUpdateForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1173, 579);
      this.Controls.Add(this.tableLayoutPanel1);
      this.MinimizeBox = false;
      this.Name = "UlcUpdateForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Обновление контроллеров";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UlcUpdateForm_FormClosing);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cDBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn ztpDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn isTrueDataGridViewCheckBoxColumn;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private CustomProgressBar customProgressBar1;
    private System.Windows.Forms.Button btnRun;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.BindingSource cDBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn ipaddressDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
    private ProgressBarColumn percentDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn timeRunDataGridViewTextBoxColumn;
  }
}

