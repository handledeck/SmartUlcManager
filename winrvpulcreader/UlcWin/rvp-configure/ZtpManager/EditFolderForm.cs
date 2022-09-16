using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ztp.Model;
using ZtpManager.Nodes;

namespace ZtpManager
{
  public partial class EditFolderForm : Form
  {
    private Node _node;
    public EditFolderForm()
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
    }

    public EditFolderForm(Node node)
    {
      InitializeComponent();
      Application.Idle += Application_Idle;
      _node = node;
      itName.Value = _node.DisplayName;
      itDescription.Value = _node.Description;
    }

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
      Application.Idle -= Application_Idle;
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      btnOk.Enabled = itName.Value.Trim().Length > 0;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if(_node == null)
      {
        _node = new NodeEx()
        {
          DisplayName = itName.Value,
          Description = itDescription.Value,
          Kind = NodeKind.Folder,
          //IdOwn = parent.Node.Id
        };
      }
      else
      {
        _node = _node.Clone();
        _node.Description = itDescription.Value;
        _node.DisplayName = itName.Value;
      }
      DialogResult = DialogResult.OK;
    }

    public Node GetChangedNode()
    {
      return _node;
    }

    public string ValueName
    {
      get { return itName.Value; }
      set { itName.Value = value; }
    }

    public string ValueDescription
    {
      get { return itDescription.Value; }
      set { itDescription.Value = value; }
    }

  }
}
