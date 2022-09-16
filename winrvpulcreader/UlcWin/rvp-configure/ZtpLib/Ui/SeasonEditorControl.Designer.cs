namespace Ztp.Ui
{
  partial class SeasonEditorControl
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeasonEditorControl));
      this.lv = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.iml = new System.Windows.Forms.ImageList(this.components);
      this.SuspendLayout();
      // 
      // lv
      // 
      this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
      this.lv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lv.FullRowSelect = true;
      this.lv.GridLines = true;
      this.lv.HideSelection = false;
      this.lv.Location = new System.Drawing.Point(0, 0);
      this.lv.MultiSelect = false;
      this.lv.Name = "lv";
      this.lv.Size = new System.Drawing.Size(538, 253);
      this.lv.SmallImageList = this.iml;
      this.lv.TabIndex = 3;
      this.lv.UseCompatibleStateImageBehavior = false;
      this.lv.View = System.Windows.Forms.View.Details;
      this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Сезон";
      this.columnHeader1.Width = 500;
      // 
      // iml
      // 
      this.iml.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml.ImageStream")));
      this.iml.TransparentColor = System.Drawing.Color.Transparent;
      this.iml.Images.SetKeyName(0, "sizon.png");
      // 
      // SeasonEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lv);
      this.Name = "SeasonEditorControl";
      this.Size = new System.Drawing.Size(538, 253);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.ImageList iml;
    private System.Windows.Forms.ListView lv;
    private System.Windows.Forms.ColumnHeader columnHeader1;
  }
}
