using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.Fota;

namespace UlcWin.win
{

  public enum StateWaitForm { 
   
    StateSimple=0,
    StateOverSimple=1
  }


  

  public partial class WaitForm : Form
  {
    public StateWaitForm __full_view = StateWaitForm.StateSimple;
    public string _default = "Идет обработка данных";
    string _wortxt = "";//Идет обработка данных";
    public Action Worker { get; set; }
    public string WorkText { get { return _wortxt; } set { _wortxt = value; } }
    public bool __complite_work = false;
    public List<ListViewItem> __lstItems = null;


    public WaitForm(string header,Action worker, StateWaitForm stateWaitForm)
    {
      InitializeComponent();
      this.Text = header;
      Application.Idle += Application_Idle;
      if (stateWaitForm == StateWaitForm.StateSimple)
      {
        this.progressBar.Style = ProgressBarStyle.Continuous;
      }
      else
      {
        this.progressBar.Style = ProgressBarStyle.Marquee;
      }
      this.__full_view = stateWaitForm;
      if (worker == null)
        throw new ArgumentNullException();
      Worker = worker;
      this.Shown += WaitForm_Shown;

    }

    public WaitForm(Action worker,StateWaitForm stateWaitForm)
    {
      InitializeComponent();
     
      Application.Idle += Application_Idle;
      if (stateWaitForm == StateWaitForm.StateSimple)
      {
        this.progressBar.Style = ProgressBarStyle.Continuous;
      }
      else
      {
        this.progressBar.Style = ProgressBarStyle.Marquee;
      }
        this.__full_view = stateWaitForm;
      if (worker == null)
        throw new ArgumentNullException();
      Worker = worker;
      this.Shown += WaitForm_Shown;
     
    }

    public void InitListView(List<ListViewItem> lstItems)
    {

      if (lstItems != null)
      {
        this.__lstItems = lstItems;
      }
      foreach (var item in this.__lstItems)
      {
        ItemIp itemIp = (ItemIp)item.Tag;

        var it = this.listView1.Items.Add("", 1);
        it.SubItems.Add(itemIp.Name);
        it.SubItems.Add(itemIp.Ip);
        it.SubItems.Add(itemIp.UType == 1 ? "ULC 2" : "РВП-18");
        it.SubItems.Add(itemIp.Id.ToString());
        //it.SubItems.Add(ParceError(0));
        this.listView1.Items[listView1.Items.Count - 1].EnsureVisible();
      }
    }

    private void Application_Idle(object sender, EventArgs e)
    {
     
    }
    Task __tsk = null;
    private void WaitForm_Shown(object sender, EventArgs e)
    {
      this.WorkText = "Начало опроса";
      __tsk = new Task(Worker);
      __tsk.Start();
     
    }

    protected void CaclView() {
      //if (__full_view == StateWaitForm.StateSimple)
      //{
      //  tableLayoutPanel1.Visible = false;
      //  //this.listView1.Visible = false;
      //  //this.Height = this.Height - this.listView1.Height;
      //  this.Height = this.Height - this.tableLayoutPanel1.Height;
      //  this.button2.Visible = false;
      //  this.button1.Visible = true;
      //}
      //else if (__full_view == StateWaitForm.StateOverSimple) {
      //  this.listView1.Visible = false;
      //  this.Height = this.Height - this.listView1.Height;
      //  this.button2.Visible = true;
      //  //this.progressBar.Style = ProgressBarStyle.Marquee;
      //}
      //else 
      //{
      //  this.listView1.Visible = true;
      //  this.Height = this.Height + this.listView1.Height;
      //}
    }

    //public new DialogResult ShowDialog() {
    //  //Task tsk = Task.Factory.StartNew(Worker).ContinueWith(t =>
    //  //{
    //  //  this.Cursor = Cursors.Arrow;
    //  //  this.Close();
    //  //},
    //  //    TaskScheduler.FromCurrentSynchronizationContext()
    //  //  );
    //  Task tsk = new Task(Worker);
    //  tsk.Start();
    //  return base.ShowDialog();
    //}

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      this.CaclView();
      
      ////this.Cursor = Cursors.WaitCursor;
      ///


      this.timer1.Enabled = true;
    }

    public void CompleetWork(bool showResult) {
      this.__complite_work = true;
      this.timer1.Stop();
      pictureBox1.Image = imlWait.Images[0];
      this.btnOperation.Text = "Выход";
      this.label1.Text = "Операция завершена";
      if (showResult)
      {
        MessageBox.Show("Операция завершена", "Устройства", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      //if (this.__complite_work)
      //{

      //  this.timer1.Stop();
      //  pictureBox1.Image = imlWait.Images[0];
      //  this.btnOperation.Text = "Выход";
      //  this.ChangeLabelText("Операция завершена");
      //}
      //else
      //{
      //  this.btnOperation.Text = "Отмена";
      //}
      ////this.DialogResult=DialogResult.OK;
      ////this.Close();

    }

    public string ParceError(byte error) {
      switch (error)
      {
        case 0:
          return "OK";
        case 1:
          return "Ошибка соединения";
        case 2:
          return "Соединение есть. Ошибка получения данных";
        case 3:
          return "Невозможно обновить базу данных";
        case 4:
          return "ping ok";
        case 5:
          return "ping error";
        case 6:
          return "Ошибка записи в устройство";
        case 7:
          return "Неверный пароль";
        case 8:
          return "Команда отправлена успешно";
        case 9:
          return "Ошибка отправки команды";
        case 10:
          return "Ошибка получения данных";
        default:
          return "Неизвестно";
      }
    }

    public void SetLabelText(string lblText)
    {
      this.BeginInvoke(new Action(() =>
      {
        this._wortxt = lblText;

      }));
    }

    void Search() { 
    
    }

    public void ChangeItemValue(ListViewItem item)
    {

      //try
      //{
      //  this.BeginInvoke(new Action(() =>
      //  {

      //    //this._wortxt = lblText;
      //    var it = this.listView1.Items.Add("", isTrue ? 0 : 1);
      //    it.SubItems.Add(tpName);
      //    it.SubItems.Add(iPAddress);
      //    it.SubItems.Add(isUlc == 1 ? "ULC 2" : "РВП-18");
      //    it.SubItems.Add(ParceError(error));
      //    this.listView1.Items[listView1.Items.Count - 1].EnsureVisible();
      //  }));
      //}
      //catch
      //{

      //}
    }

    public void ChangeLabelText(string lblText, string tpName, string iPAddress, bool isTrue, byte isUlc, byte error)
    {
      try
      {
        this.BeginInvoke(new Action(() =>
        {

          
          var it = this.listView1.Items.Add("", isTrue ? 0 : 1);
          it.SubItems.Add(tpName);
          it.SubItems.Add(iPAddress);
          it.SubItems.Add(isUlc == 1 ? "ULC 2" : "РВП-18");
          it.SubItems.Add(ParceError(error));
          this._wortxt = lblText;
          this.listView1.Items[listView1.Items.Count - 1].EnsureVisible();
        }));
      }
      catch
      {

      }
    }

    public void ChangeLabelText(string lblText, string tpName, string iPAddress, bool isTrue, string device, string error)
    {
      try
      {
         this.BeginInvoke(new Action(() =>
        {


          var it = this.listView1.Items.Add("", isTrue ? 0 : 1);
          it.SubItems.Add(tpName);
          it.SubItems.Add(iPAddress);
          it.SubItems.Add(device);
          it.SubItems.Add(error);
          this._wortxt = lblText;
          this.listView1.Items[listView1.Items.Count - 1].EnsureVisible();
        }));
      }
      catch
      {

      }
    }

    public ListViewItem IntChangeLabelText(string lblText, string tpName, string iPAddress, bool isTrue, string device, string error)
    {
      ListViewItem listViewItem = null;
      try
      {
        IAsyncResult result= this.BeginInvoke(new Action(() =>
        {
          listViewItem = this.listView1.Items.Add("", isTrue ? 0 : 1);
          listViewItem.SubItems.Add(tpName);
          listViewItem.SubItems.Add(iPAddress);
          listViewItem.SubItems.Add(device);
          listViewItem.SubItems.Add(error);
          this._wortxt = lblText;
          this.listView1.Items[listView1.Items.Count - 1].EnsureVisible();
        }));
        result.AsyncWaitHandle.WaitOne();
        return listViewItem;
      }
      catch
      {
        return null;
      }
    }


    public void ChangeLabelText(string lblText)
    {
      this.Invoke(new Action(() =>
      {
        this._wortxt = lblText;
      }));
    }

    public void ChangePercent(double perc)
    {
      try
      {
        this.BeginInvoke(new Action(() =>
        {
          if (progressBar.Style == ProgressBarStyle.Marquee)
          {
            progressBar.Style = ProgressBarStyle.Blocks;
            label1.Text = WorkText;
          }
          this.Text = $"Обработка данных... {perc:F0}%";
          progressBar.Value = (int)perc;
        }));
      }
      catch
      {
      }
    }

    int frame = 0;
    private void timer1_Tick(object sender, EventArgs e)
    {
      pictureBox1.Image = imlWait.Images[frame];
      frame++;
      if (frame == 15)
        frame = 0;

      this.label1.Text = WorkText;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      int x = 0;
      //this.Invoke(new Action(() =>
      //{
      //  Button btn = (Button)sender;
      //  if (btn.Text == "Показать детали")
      //  {
      //    btn.Text = "Скрыть детали";
      //    this.listView1.Visible = true;
      //    this.Height = this.Height + this.listView1.Height;
      //  }
      //  else if(btn.Text == "Скрыть детали")
      //  {
      //    btn.Text = "Показать детали";
      //    this.listView1.Visible = false;
      //    this.Height = this.Height - this.listView1.Height;
      //  }
      //}));
      if (!this.__complite_work)
      {
        DialogResult result = MessageBox.Show("Операция не завершена", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.No)
        {
          this.DialogResult = DialogResult.Cancel;
        }
        else {
          this.__complite_work = true;
          this.DialogResult = DialogResult.Cancel;
        }
      }
      else {
       
        this.DialogResult = DialogResult.OK;
      }
    }
  }
}
