using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ulc.Controls
{
  // Custom DataGridView column for displaying progress bars
  public class ProgressBarColumn : DataGridViewImageColumn
  {
    public Brush ProgressColor { get; set; } = Brushes.Green;//.FromSystemColor(Color.Green);//
                                                                                              
    public ProgressBarColumn()
    {
      // Set the cell template to a custom progress bar cell
      CellTemplate = new ProgressBarCell();

    }
  }

  // Custom DataGridView cell for displaying progress bars
  class ProgressBarCell : DataGridViewImageCell
  {
   

    // Static image representing an empty image
    static Image EmptyImage;

    // Static constructor to initialize the empty image
    static ProgressBarCell()
    {
      EmptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
      
    }

    public ProgressBarCell()
    {
      // Set the value type of the cell to integer
      ValueType = typeof(int);
    }

    public Brush ProgressColor { get; set; } = SystemBrushes.HotTrack;

    // Override to provide formatted value for the cell
    protected override object GetFormattedValue(object value,
                        int rowIndex, ref DataGridViewCellStyle cellStyle,
                        TypeConverter valueTypeConverter,
                        TypeConverter formattedValueTypeConverter,
                        DataGridViewDataErrorContexts context)
    {
      // Always return the empty image
      return EmptyImage;
    }

    // Override to paint the cell content
    protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle clipBounds,
        System.Drawing.Rectangle cellBounds, int rowIndex,
        DataGridViewElementStates cellState, object value, object formattedValue,
        string errorText, DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
    {
      try
      {
        if (value != null)
        {
          // Convert the value to integer representing progress value
          int progressValue = (int)value;
          // Calculate the percentage of progress
          float progressPercentage = ((float)progressValue / 100.0f);

          // Create brushes for background and foreground
          //Brush backColorBrush = new SolidBrush(cellStyle.BackColor);
          Brush foreColorBrush = new SolidBrush(cellStyle.ForeColor);

          // Paint the base cell content
          base.Paint(g, clipBounds, cellBounds,
           rowIndex, cellState, value, formattedValue, errorText,
           cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));

          // Check if progress is greater than 0
          if (progressPercentage > 0.0)
          {
            // Draw the filled progress bar
            g.FillRectangle(ProgressColor/*new SolidBrush(Color.FromArgb(203, 235, 108))*/, cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((progressPercentage * cellBounds.Width - 4)), cellBounds.Height - 4);
            // Draw the progress value as text
            if (progressPercentage > 0.5)
              g.DrawString(progressValue.ToString() + "%", cellStyle.Font,SystemBrushes.HighlightText, cellBounds.X + (cellBounds.Width / 2) - 5, cellBounds.Y + 2);
            else
              g.DrawString(progressValue.ToString() + "%", cellStyle.Font, foreColorBrush, cellBounds.X + (cellBounds.Width / 2) - 5, cellBounds.Y + 2);
          }
          else
          {
            // Draw the progress value as text
            if (DataGridView.CurrentRow.Index == rowIndex)
              g.DrawString(progressValue.ToString() + "%", cellStyle.Font, new SolidBrush(cellStyle.SelectionForeColor), cellBounds.X + 6, cellBounds.Y + 2);
            else
              g.DrawString(progressValue.ToString() + "%", cellStyle.Font, foreColorBrush, cellBounds.X + 6, cellBounds.Y + 2);
          }
        }
      }
      catch
      {

      }
    }
  }

}