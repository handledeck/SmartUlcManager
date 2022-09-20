using InterUlc.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ztp.Utils;
using static UlcWin.ui.TriStateTreeView;

namespace UlcWin.ui
{
  public enum EnumAccsesLevel { 
    SupUsr=-1,
    Full=0,
    ReadWrite=1,
    Read=2
  }

  public enum UserAction { 
    Add,
    Edit
  } 
  public partial class UsersAccsessForm : Form
  {
    public ImageList __imageList;
    public Dictionary<int, List<int>> __dicNode;
    public UlcUser __ulcUser;
    //string __default_user = "имя пользователя";
    //string __default_comment = "комментарий";
    public int __id_record = -1;
    DbReader __db;
    UserAction __action;
    public UsersAccsessForm(DbReader db, UserAction action)
    {
      InitializeComponent();
      this.__db = db;
      this.__action = action;
      Application.Idle += Application_Idle;
      this.triStateTreeView1.TreeChanged += TriStateTreeView1_TreeChanged;
      __dicNode = new Dictionary<int, List<int>>();
      //this.txtBoxName.Text = __default_user;
      //this.txtBoxComment.Text = __default_comment;
     // this.txtBoxName.SetPlaceHolderTextbox("Введите пользователя");
      //this.txtBoxComment.SetPlaceHolderTextbox("Введите комментарий");
      //this.txtBoxPwd.SetPlaceHolderTextbox("Введите пароль");
      this.cbLevel.SelectedIndex = 0;
      this.txtBoxName.Text=this.txtBoxName.Text;
      this.btnAllSelect.Image = global::UlcWin.Properties.Resources.btnCheck;
      this.btnUnSelect.Image = global::UlcWin.Properties.Resources.btnUncheck;
    }

    private void TriStateTreeView1_TreeChanged(TreeNode tn)
    {
      this.__dicNode = null;
      this.button3_Click(null, null);
      //UNode node = (UNode)tn;
      //if (node.Checked)
      //{
      //  if (node.Parent == null) { 
        
      //  }
      //  if (!__dicNode.ContainsKey(((UNode)node.Parent).Id))
      //  {
      //    List<int> lstInt = new List<int>();
      //    lstInt.Add(node.Id);
      //    __dicNode.Add(((UNode)node.Parent).Id, lstInt);
      //  }
      //  else
      //  {
      //    __dicNode[((UNode)node.Parent).Id].Add(node.Id);
      //  }
      //}
      //else
      //{
      //  List<int> lst = __dicNode[((UNode)node.Parent).Id];
      //  lst.Remove(node.Id);
      //  if (lst.Count == 0)
      //  {
      //    __dicNode.Remove(((UNode)node.Parent).Id);
      //    tn.Parent.Checked = false;
      //  }
      //}
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      txtBoxName_Valid(this.txtBoxName, null);
      txtPasswor_Valid(this.txtBoxPwd, null);
      if (this.txtBoxName.IsValid && this.txtBoxPwd.IsValid && 
        this.__dicNode.Count>0)
      {
        this.btnOk.Enabled = true;
      }
      else {
        this.btnOk.Enabled = false;
      }
    }

    private void triStateTreeView1_AfterExpand(object sender, TreeViewEventArgs e)
    {
      //foreach (TreeNode nItem in e.Node.Nodes)
      //{
      //  nItem.ImageIndex = 18;
      //  nItem.SelectedImageIndex = 18;
      //}
    }
    
    private void button3_Click(object sender, EventArgs e)
    {

      foreach (UNode item in this.triStateTreeView1.Nodes)
      {
        if (__dicNode == null)
          __dicNode = new Dictionary<int, List<int>>();
        TreeNode tn = (TreeNode)item;
        if (tn.StateImageIndex == (int)CheckedState.Mixed || tn.StateImageIndex == (int)CheckedState.Checked)
        {
          __dicNode.Add(item.Id, new List<int>());
        }
        else {
          continue;
        }
        foreach (UNode pItem in item.Nodes)
        {
          if (pItem.Checked)
          {
            
            
            //UNode pNode = (UNode)pItem.Parent;
            //if (!__dicNode.ContainsKey(pNode.Id))
            //{
              //__dicNode[item.Id].Add(pItem.Id);
            //}
            //else {
              __dicNode[item.Id].Add(pItem.Id);
            //}
          }
        }
      }
    }

    void GetAllCheckedNodes() {
      this.__dicNode = new Dictionary<int, List<int>>();
      foreach (UNode rNode in this.triStateTreeView1.Nodes)
      {
        foreach (UNode pNode in rNode.Nodes)
        {
          if (pNode.Checked) {
            if (!this.__dicNode.ContainsKey(rNode.Id))
            {
              List<int> lst = new List<int>();
              lst.Add(pNode.Id);
              this.__dicNode.Add(rNode.Id, lst);
            }
            else
            {
              this.__dicNode[rNode.Id].Add(pNode.Id);
            }
          }
        }
      }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (__action == UserAction.Add)
      {
        if (this.__db.CheckForUserRecord(this.txtBoxName.Text))
        {
          MessageBox.Show("Такой пользователь уже есть", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
      }
      GetAllCheckedNodes();
      __ulcUser = new UlcUser()
      {
        User = this.txtBoxName.Text,
        Pwd = this.txtBoxPwd.Text,
        Comment = this.txtBoxComment.Text
      };
      
      //UlcUserItems ulcUserItems = new UlcUserItems();
      __ulcUser.UlcItems = new List<UlcTreeItems>();
      foreach (var item in __dicNode)
      {
        UlcTreeItems lstNode = new UlcTreeItems();
        lstNode.IdRoot = item.Key;
        __ulcUser.UlcItems.Add(lstNode);
        foreach (int uItem in item.Value)
        {
          lstNode.IdItems.Add(uItem);
        }
      }
      int indAc = cbLevel.SelectedIndex;
      if (indAc == 0)
        __ulcUser.AccsessLavel = EnumAccsesLevel.ReadWrite;
      else if(indAc==1)
        __ulcUser.AccsessLavel = EnumAccsesLevel.Read;
      //__ulcUser.AccsessLavel = (EnumAccsesLevel)cbLevel.SelectedIndex;
      __ulcUser.PackUlcItems();
      //__ulcUser.UlcItems = ulcUserItems;
      this.DialogResult = DialogResult.OK;
      //}
    }

    void SetNodeSelected(bool isSelect) {
      this.__dicNode.Clear();
      foreach (UNode RNodes in this.triStateTreeView1.Nodes)
      {
        foreach (UNode pUNode in RNodes.Nodes)
        {
          if (isSelect)
          {
            pUNode.Checked = true;

          }
          else {
            pUNode.Checked = false;
          }
        }
      }
      if (isSelect)
      {
        GetAllCheckedNodes();
      }
      else {
        this.__dicNode.Clear();
      }
    }

    private void btnUnSelect_Click(object sender, EventArgs e)
    {
      this.SetNodeSelected(false);
    }

    private void btnAllSelect_Click(object sender, EventArgs e)
    {
      this.SetNodeSelected(true);
    }

    public void txtPasswor_Valid(object sender, string error)
    {
      TextBoxPlaceHolder txtName = (TextBoxPlaceHolder)sender;
      Exception exp = StringUtils.CheckPasswordString(txtName.Text);
      if (exp!=null)
      {
        this.errorProvider1.SetError(txtName, exp.Message);
        txtName.IsValid = false;
        return;
      }
      else
      {
        this.errorProvider1.SetError(txtName, "");
        txtName.IsValid = true;
      }

    }

    public void txtBoxName_Valid(object sender, string error)
    {
      TextBoxPlaceHolder txtName = (TextBoxPlaceHolder)sender;
      if (string.IsNullOrEmpty(txtName.Text))
      {
        //e.Cancel = true;
        this.errorProvider1.SetError(txtName, "Поле обязательное для ввода");
        txtName.IsValid = false;
        return;
      }

      else if(Regex.IsMatch(txtName.Text, @"\p{IsCyrillic}")){
        this.errorProvider1.SetError(txtName, "Проверьте расскладку! Поле не должено содержать символы кирилицы");
        txtName.IsValid = false;
        return;
      }
      //if (Regex.IsMatch(txtName.Text, @"^\d"))
      //{
      //  this.errorProvider1.SetError(txtName, "Имя не должно начинаться с цифры");
      //  txtName.IsValid = false;
      //  return;
      //}
      else
      {
        this.errorProvider1.SetError(txtName, "");
        txtName.IsValid = true;
      }

    }

    private void triStateTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
      int x = 0;
    }

    private void triStateTreeView1_AfterCheck(object sender, TreeViewEventArgs e)
    {
      
    }
  }

  public class UlcTreeItems
  {
    public int IdRoot { get; set; }
    public List<int> IdItems { get; set; }
    public UlcTreeItems()
    {
      this.IdItems = new List<int>();
    }
  }

  public class UlcUser
  {
    public int Id { get; set; }
    public string User { get; set; }
    public string Pwd { get; set; }
    public string Comment { get; set; }
    public List<UlcTreeItems> UlcItems { get; set; }
    public EnumAccsesLevel AccsessLavel  { get; set; }

    public UlcUser()
    {
      AccsessLavel = EnumAccsesLevel.Read;
    }

    string __nodesString;
    public string NodesString
    {
      get { return __nodesString; }
      set {
        __nodesString = value; 
      }
    }
    public string PackUlcItems() {
      string items = "";
      if (this.UlcItems.Count > 0) {
        foreach (var item in UlcItems)
        {
          items += item.IdRoot.ToString()+":";
          for (int i = 0; i < item.IdItems.Count; i++)
          {
            items += item.IdItems[i].ToString() + ",";
          }
          items = items.Substring(0, items.Length - 1);
          items += " ";
        }
      }
      if (!string.IsNullOrEmpty(items))
      {
        
        this.__nodesString = items;
      }
      return items;
    }

  }
}
