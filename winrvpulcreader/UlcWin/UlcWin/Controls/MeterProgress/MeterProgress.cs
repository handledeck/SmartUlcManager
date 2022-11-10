using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin.Controls.UlcMeterComponet
{
  public partial class MeterProgress : Form
  {
    CancellationTokenSource __cancellationToken = null;
    
    //CancellationToken __token;
    //long runner = 0;
    //List<Task> __tasks;
    public MeterProgress()
    {
      //__tasks = new List<Task>();
      InitializeComponent();
     
    }

    

    public void SetLabelText(string text)
    {
      this.BeginInvoke(new Action(() =>
      {
        try
        {
          this.label1.Text = text;// "Завершено " + ((Interlocked.Read(ref runner) * 100) / 500).ToString();
        }
        catch(Exception e) {
          int x = 0;
        }
      }));
    }

    public void SetProgressValue(long value)
    {
      this.BeginInvoke(new Action(() =>
      {
        try
        {
          this.progressBar1.Value += 1;
          //this.label1.Text = text;// "Завершено " + ((Interlocked.Read(ref runner) * 100) / 500).ToString();
        }
        catch (Exception e)
        {
          int x = 0;
        }
      }));
    }

    public void SetTasksToken(CancellationTokenSource cancellationToken,int progressMax) {

      __cancellationToken = cancellationToken;
      this.progressBar1.Maximum = progressMax;
      //this.__tasks = tasks;
      //__tokenSource = tokenSource;
      //__token = token;
    }

    public void TasksStart() {
      //this.progressBar1.Maximum = this.__tasks.Count;
      //this.runner = 0;
      //Task.Factory.StartNew(() =>
      //{
      //  try
      //  {
      //    foreach (var item in __tasks)
      //    {
      //      item.Start();
      //    }
      //    Task.WaitAll(__tasks.ToArray());
      //  }
      //  catch (Exception)
      //  {
      //  }
      //}, __token);
    }

    private void MeterProgress_Load(object sender, EventArgs e)
    {
      
      //for (int i = 0; i < 500; i++)
      //{
      //  __tasks.Add(new Task(() =>
      //  {
      //    for (int x = 0; x < 10; x++)
      //    {
      //      if (__token.IsCancellationRequested)
      //      {
      //        System.Diagnostics.Debug.WriteLine("Операция прервана");
      //        return;
      //      }
      //      System.Diagnostics.Debug.WriteLine(x.ToString());
      //    }
      //    this.BeginInvoke(new Action(() => {
      //      try
      //      {
      //        Interlocked.Increment(ref runner);
      //        this.progressBar1.Value += 1;
      //        this.Text = "Завершено " + ((Interlocked.Read(ref runner) * 100) / 500).ToString();
      //      }
      //      catch{}
            
      //    }), i);
      //  }, __token));
      //}
     
    }

    private void button1_Click(object sender, EventArgs e)
    {
      __cancellationToken.Cancel();
      //this.BeginInvoke(new Action(() => 
      //{
      //  this.progressBar1.Value = progressBar1.Maximum;
      //  Thread.Sleep(3000);
      //  this.Close();
      //}));
    }
  }

  public delegate void Comp(int id);
  public class TaskRunss {
    public int id { get; set; }
    public Comp MyComp { get; set; }
    
  }

  
  public class UTask : Task
  {

    public UTask(Action action) : base(action)
    {
      
    }
  }
}
