﻿namespace Ztp.Ui
{
  partial class UiLogConsoleControl
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
      this.richTextBox = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // richTextBox
      // 
      this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.richTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.richTextBox.Location = new System.Drawing.Point(0, 0);
      this.richTextBox.Multiline = true;
      this.richTextBox.Name = "richTextBox";
      this.richTextBox.ReadOnly = true;
      this.richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
      this.richTextBox.Size = new System.Drawing.Size(150, 150);
      this.richTextBox.TabIndex = 0;
      this.richTextBox.WordWrap = true;
      // 
      // UiLogConsoleControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.richTextBox);
      this.Name = "UiLogConsoleControl";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox richTextBox;
  }
}
