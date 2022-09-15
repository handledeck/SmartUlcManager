using InterUlc.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UlcWin
{
  
  public partial class ConnectionDBForm : Form
  {
    string __connect_file = "db_file.bin";
    public DbReader __db;
    IniConnection GetFileConnection(string path)
    {
      IniConnection iniConnection = null;
      BinaryFormatter formatter = new BinaryFormatter();
      try
      {
        StreamReader reader = new StreamReader(path);
        iniConnection = (IniConnection)formatter.Deserialize(reader.BaseStream);
        reader.Close();
        return iniConnection;
      }
      catch
      {
        iniConnection = new IniConnection()
        {
          IpNameConnection = "127.0.0.1"
        };
        StreamWriter wr = new StreamWriter(path);
        formatter.Serialize(wr.BaseStream, iniConnection);
        wr.Close();
        return iniConnection;
      }
    }

    internal string GetPathSetting() {
      string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
      string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
      //string path = Path.GetDirectoryName(strWorkPath);
      string wpth = strWorkPath + "\\" + __connect_file;
      return wpth;
    }

    public ConnectionDBForm(DbReader db)
    {
      InitializeComponent();
      if (db != null)
      {
        this.__db = db;
        this.txtIpOrName.Text = this.__db.__dBIpAddress;
        this.txtUser.Text = this.__db.__DbUserName;
        this.txtPassword.Text = this.__db.__DbPassword;
      }
      else {
        string wpth = GetPathSetting();
        IniConnection iniConnection = GetFileConnection(wpth);
        this.txtIpOrName.Text = iniConnection.IpNameConnection;
        this.txtUser.Text = iniConnection.UserName;
        this.txtPassword.Text = iniConnection.UserPassword;
        this.__db = new DbReader(this.txtIpOrName.Text, this.txtUser.Text, this.txtPassword.Text);
      }
      
      
    }

    Exception TestConnectionDB() {
      try
      {
        this.__db.__dBIpAddress = this.txtIpOrName.Text;
        this.__db.__DbUserName = this.txtUser.Text;
        this.__db.__DbPassword = this.txtPassword.Text;
        bool res=this.__db.DbTestConnection();
        if (res)
          return null;
        else
          throw new Exception("Ошибка соединения...");
      }
      catch(Exception ex)
      {
        return ex;
      }
    }

    private void btnTest_Click(object sender, EventArgs e)
    {
      try
      {
        this.__db.__dBIpAddress = this.txtIpOrName.Text;
        this.__db.__DbUserName = this.txtUser.Text;
        this.__db.__DbPassword = this.txtPassword.Text;
        Exception exc =TestConnectionDB();
        if(exc==null)
          MessageBox.Show("Соединение успешно", "Тест соединения", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
        else
        //Exception exc= this.__db.DbTestConnection();
        MessageBox.Show("Ошибка соединения", "Тест соединения", MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        //else
        //  throw new Exception();
      }
      catch {
        MessageBox.Show("Ошибка соединения", "Тест соединения", MessageBoxButtons.OK,
           MessageBoxIcon.Error);
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {

      IniConnection iniConnection = null;
      BinaryFormatter formatter = new BinaryFormatter();
      try
      {
        string wpth = GetPathSetting();
        iniConnection = new IniConnection()
        {
          IpNameConnection = this.txtIpOrName.Text,
          UserName = this.txtUser.Text,
          UserPassword = this.txtPassword.Text
        };
        StreamWriter wr = new StreamWriter(wpth);
        formatter.Serialize(wr.BaseStream, iniConnection);
        wr.Close();
        //return iniConnection;
      }
      catch(Exception exp)
      {
        MessageBox.Show("Ошибка сохранения соединения с базой данных","Ошибка соединения с базой",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      Exception ex = TestConnectionDB();
      if (ex == null)
        this.DialogResult = DialogResult.OK;
      else {
        MessageBox.Show(ex.Message, "Ошибка соединения с базой",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }

  [Serializable]
  public partial class IniConnection
  {
    public string IpNameConnection { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
  }

}
