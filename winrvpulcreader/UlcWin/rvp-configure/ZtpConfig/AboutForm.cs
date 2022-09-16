using System;
using System.Reflection;
using System.Windows.Forms;

namespace Ztp
{
  public partial class AboutForm : Form
  {
    public AboutForm()
    {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
      Assembly asm = Assembly.GetExecutingAssembly();
      AssemblyFileVersionAttribute[] attrs = (AssemblyFileVersionAttribute[])asm.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
      lblVersion.Text = $"Версия {attrs[0].Version}";
      AssemblyCopyrightAttribute[]  attr =  ((AssemblyCopyrightAttribute[])asm.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false));
      DateTime dt = DateTime.Now; 
      lbCopyrigth.Text = attr[0].Copyright + " - " + dt.Year.ToString() + " год.";
    }
  }
}
