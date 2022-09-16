namespace Ztp.Ui
{
  partial class FileUploadForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //protected override void Dispose(bool disposing)
    //{
    //  if (disposing && (components != null))
    //  {
    //    components.Dispose();
    //  }
    //  base.Dispose(disposing);
    //}

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileUploadForm));
      this.bCancel = new System.Windows.Forms.Button();
      this.bUpload = new System.Windows.Forms.Button();
      this.tbPath = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.labUpFilename = new System.Windows.Forms.Label();
      this.ofd = new System.Windows.Forms.OpenFileDialog();
      this.bSearch = new System.Windows.Forms.Button();
      this.labStatusProcess = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // bCancel
      // 
      this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.bCancel.Location = new System.Drawing.Point(357, 148);
      this.bCancel.Name = "bCancel";
      this.bCancel.Size = new System.Drawing.Size(75, 23);
      this.bCancel.TabIndex = 0;
      this.bCancel.Text = "Отмена";
      this.bCancel.UseVisualStyleBackColor = true;
      // 
      // bUpload
      // 
      this.bUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bUpload.Location = new System.Drawing.Point(240, 148);
      this.bUpload.Name = "bUpload";
      this.bUpload.Size = new System.Drawing.Size(111, 23);
      this.bUpload.TabIndex = 1;
      this.bUpload.Text = "Загрузить файл";
      this.bUpload.UseVisualStyleBackColor = true;
      this.bUpload.Click += new System.EventHandler(this.bUpload_Click);
      // 
      // tbPath
      // 
      this.tbPath.Enabled = false;
      this.tbPath.Location = new System.Drawing.Point(22, 31);
      this.tbPath.Name = "tbPath";
      this.tbPath.Size = new System.Drawing.Size(329, 20);
      this.tbPath.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(22, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(110, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Загружаемый файл:";
      // 
      // labUpFilename
      // 
      this.labUpFilename.AutoSize = true;
      this.labUpFilename.Location = new System.Drawing.Point(139, 11);
      this.labUpFilename.Name = "labUpFilename";
      this.labUpFilename.Size = new System.Drawing.Size(0, 13);
      this.labUpFilename.TabIndex = 4;
      // 
      // ofd
      // 
      this.ofd.FileName = "openFileDialog1";
      // 
      // bSearch
      // 
      this.bSearch.Location = new System.Drawing.Point(357, 29);
      this.bSearch.Name = "bSearch";
      this.bSearch.Size = new System.Drawing.Size(75, 23);
      this.bSearch.TabIndex = 5;
      this.bSearch.Text = "Обзор...";
      this.bSearch.UseVisualStyleBackColor = true;
      this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
      // 
      // labStatusProcess
      // 
      this.labStatusProcess.AutoSize = true;
      this.labStatusProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.labStatusProcess.Location = new System.Drawing.Point(22, 77);
      this.labStatusProcess.Name = "labStatusProcess";
      this.labStatusProcess.Size = new System.Drawing.Size(13, 18);
      this.labStatusProcess.TabIndex = 6;
      this.labStatusProcess.Text = " ";
      // 
      // FileUploadForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(444, 183);
      this.Controls.Add(this.labStatusProcess);
      this.Controls.Add(this.bSearch);
      this.Controls.Add(this.labUpFilename);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbPath);
      this.Controls.Add(this.bUpload);
      this.Controls.Add(this.bCancel);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FileUploadForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Загрузка файла на устройство";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button bCancel;
    private System.Windows.Forms.Button bUpload;
    private System.Windows.Forms.TextBox tbPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label labUpFilename;
    private System.Windows.Forms.OpenFileDialog ofd;
    private System.Windows.Forms.Button bSearch;
    private System.Windows.Forms.Label labStatusProcess;
  }
}