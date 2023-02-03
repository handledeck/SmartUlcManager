using InterUlc.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UlcWin.DB;
using Ztp.Configuration;
//using ZtpManager.Controls;

namespace UlcWin.ui
{
  public partial class UsersEditForm : Form
  {
    public ImageList __imageList;
    public Dictionary<UNode, List<UNode>> __nodes;
    DbReader __db;
    public UsersEditForm(DbReader db)
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
      __db = db;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      if (this.ListUser.Items.Count == 0)
      {
        this.btnDelete.Enabled = false;
        this.btnEdit.Enabled = false;

      }
      else {
        if (this.ListUser.SelectedItems.Count > 0)
        {
          this.btnDelete.Enabled = true;
          this.btnEdit.Enabled = true;
        }
        else
        {
          this.btnEdit.Enabled = false;
          this.btnDelete.Enabled = false;
        }
      }
    }

    void UpdateUsersList()
    {
      List<UlcUser> lstUsers = this.__db.GetAllUsers();
      this.ListUser.Items.Clear();
      foreach (var item in lstUsers)
      {
        try
        {
          string asc = DBAuthUtils.Decrypt(item.Pwd, item.User);
          int iAsc;
          bool bAsc = int.TryParse(asc, out iAsc);
          if (bAsc && iAsc != -1)
          {
            ListViewItem lvi = this.ListUser.Items.Add(item.User);
            lvi.SubItems.Add(item.Comment);
            lvi.SubItems.Add(item.Pwd);
            lvi.SubItems.Add(item.NodesString);
            lvi.SubItems.Add(item.Id.ToString());
            lvi.SubItems.Add(((short)item.AccsessLavel).ToString());
          }
        }
        catch { }
      }
    }

    public void InitTree(ImageList imageList, Dictionary<UNode,List<UNode>> node) {
      //List<UlcUser> lstUsers= this.__db.GetAllUsers();
      //this.__nodes = node;
      this.__imageList = imageList;
      this.__nodes = node;
      UpdateUsersList();
      //this.__tree_nodes = tree_nodes;
      //this.triStateTreeView1.ImageList = this.imageList1;
      //form.triStateTreeView1.Nodes.Clear();
      //foreach (TreeNode item in this.treeView1.Nodes)
      //{
      //  TreeNode nItem = (TreeNode)item.Clone();
      //  nItem.ImageIndex = 17;
      //  nItem.SelectedImageIndex = 17;
      //  form.triStateTreeView1.Nodes.Add(nItem);// (TreeNode)item.Clone());
      //}
    }

    private void btnAddUser_Click(object sender, EventArgs e)
    {
      using (UsersAccsessForm uForm=new UsersAccsessForm(this.__db, UserAction.Add))
      {

        uForm.triStateTreeView1.ImageList = this.__imageList;
        uForm.triStateTreeView1.Nodes.Clear();
        uForm.__imageList = this.__imageList;
        foreach (UNode rItem in this.__nodes.Keys)
        {
          //UNode cNode = (UNode)rItem.Clone();
          UNode rNode = new UNode()
          {
            Id = rItem.Id,
            Text = rItem.Text
          };
          rNode.ImageIndex = 17;
          rNode.SelectedImageIndex = 17;
          int iNode=uForm.triStateTreeView1.Nodes.Add(rNode);
          foreach (UNode lNode in this.__nodes[rItem])
          {
            UNode pNode = new UNode()
            {
              Id = lNode.Id,
              Text = lNode.Text

            };
            pNode.ImageIndex = 18;
            pNode.SelectedImageIndex = 18;
            //UNode pNode = (UNode)lNode.Clone();
            uForm.triStateTreeView1.Nodes[iNode].Nodes.Add(pNode);
            //int xxxx = 0;
          }
          
        }

        DialogResult result=uForm.ShowDialog();
        if (result == DialogResult.OK)
        {
          int rowf= this.__db.InsertUser(uForm.__ulcUser);
          UlcUser ulcUser = uForm.__ulcUser;
          ulcUser.Id = rowf;
          //string sPwd=System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(ulcUser.Pwd));

          ListViewItem lstViewItm= this.ListUser.Items.Add(ulcUser.User);
          lstViewItm.SubItems.Add(ulcUser.Comment);
          lstViewItm.SubItems.Add(ulcUser.Pwd);
          lstViewItm.SubItems.Add(ulcUser.NodesString);
          lstViewItm.SubItems.Add(ulcUser.Id.ToString());
          lstViewItm.SubItems.Add(((short)ulcUser.AccsessLavel).ToString());
          this.__db.LogsInsertEvent(EnLogEvt.APP_NEW_USER, string.Format("{0}:{1}",
            uForm.__ulcUser.User, uForm.__ulcUser.Comment),-1);
        }
      }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {

      DialogResult result= MessageBox.Show("Удалить запись о пользователи: "+ this.ListUser.SelectedItems[0].SubItems[0].Text,
        "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (result == DialogResult.Yes)
      {
        int id = int.Parse(this.ListUser.SelectedItems[0].SubItems[4].Text);
        int res = __db.DeleteUserItem(id, this.ListUser.SelectedItems[0].SubItems[0].Text);
        if (res == 1)
        {
          this.__db.LogsInsertEvent(EnLogEvt.APP_DEL_USER, string.Format("{0}:{1}",
            this.ListUser.SelectedItems[0].SubItems[0].Text, this.ListUser.SelectedItems[0].SubItems[1].Text),-1);
          MessageBox.Show("Запись успешно удалена", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
          UpdateUsersList();
        }
        else
        {
          MessageBox.Show("Ошибка удаления записи", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    Dictionary<int, List<int>> ListCheckedNodes()
    {
      Dictionary<int, List<int>> dicLst = new Dictionary<int, List<int>>();
      ListViewItem li = this.ListUser.SelectedItems[0];
      string[] sRnode = li.SubItems[3].Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      foreach (var si in sRnode)
      {
        string[] sPNode = si.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
        int id = int.Parse(sPNode[0]);
        dicLst.Add(id, new List<int>());
        string[] sSNode = sPNode[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var itNodeParent in sSNode)
        {
          int idPNode = int.Parse(itNodeParent);
          dicLst[id].Add(idPNode);
        }
      }
      return dicLst;
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      string user_name_old = string.Empty;
      using (UsersAccsessForm uForm = new UsersAccsessForm(this.__db, UserAction.Edit))
      {
        Dictionary<int, List<int>> lstNodes = ListCheckedNodes();
        uForm.triStateTreeView1.ImageList = this.__imageList;
        uForm.triStateTreeView1.Nodes.Clear();
        uForm.__imageList = this.__imageList;
        foreach (UNode rItem in this.__nodes.Keys)
        {
          //UNode cNode = (UNode)rItem.Clone();
          UNode rNode = new UNode()
          {
            Id = rItem.Id,
            Text = rItem.Text
          };
          rNode.ImageIndex = 17;
          rNode.SelectedImageIndex = 17;
          int iNode = uForm.triStateTreeView1.Nodes.Add(rNode);
          foreach (UNode lNode in this.__nodes[rItem])
          {
            
            UNode pNode = new UNode()
            {
              Id = lNode.Id,
              Text = lNode.Text

            };
           
            pNode.ImageIndex = 18;
            pNode.SelectedImageIndex = 18;
            //UNode pNode = (UNode)lNode.Clone();
            int aNode=uForm.triStateTreeView1.Nodes[iNode].Nodes.Add(pNode);
            if (lstNodes.ContainsKey(rItem.Id) && lstNodes[rItem.Id].Contains(lNode.Id))
            {
              uForm.triStateTreeView1.Nodes[iNode].Nodes[aNode].Checked = true;
            }
            //int xxxx = 0;
          }
          ListViewItem li = this.ListUser.SelectedItems[0];
          uForm.txtBoxName.Text=li.SubItems[0].Text;//.Text = li.SubItems[0].Text;
          uForm.txtBoxComment.Text=li.SubItems[1].Text;//.Text = li.SubItems[1].Text;
          
          uForm.txtBoxPwd.Text = "";//li.SubItems[2].Text;
          if (li.SubItems[5].Text == "2")
            uForm.cbLevel.SelectedIndex = 1;// int.Parse(li.SubItems[5].Text);
          else
            uForm.cbLevel.SelectedIndex = int.Parse(li.SubItems[5].Text);
          //uForm.txtBoxPwdRepeat.Text = li.SubItems[2].Text;
          uForm.__id_record = int.Parse(li.SubItems[4].Text);
          uForm.__dicNode = lstNodes;
          user_name_old = uForm.txtBoxName.Text;
        }

        DialogResult result = uForm.ShowDialog();
        if (result == DialogResult.OK)
        {
          uForm.__ulcUser.Id = uForm.__id_record;
          using (SimpleWaitForm sfrm = new SimpleWaitForm())
          {
            sfrm.RunAction(new Action(() =>
            {

              sfrm.SetLabelText("Обновляю запись пользователя");
              int re=__db.UpdateUserRecord(uForm.__ulcUser, user_name_old);
              if (re == 1)
                sfrm.DialogResult = DialogResult.OK;
              else
                sfrm.DialogResult = DialogResult.Abort;
            }));
            DialogResult res= sfrm.ShowDialog();
            if (res == DialogResult.OK)
            {
              MessageBox.Show("Запись обновлена успешно", "Обновление БД", MessageBoxButtons.OK, MessageBoxIcon.Information);
              this.UpdateUsersList();
              this.__db.LogsInsertEvent(EnLogEvt.APP_EDIT_USER,
                string.Format("{0}:{1}", uForm.__ulcUser.User, uForm.__ulcUser.Comment),-1);
            }
            else {
              MessageBox.Show("Ошибка обновления записи", "Обновление БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
         
        }
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {

    }
  }
}
