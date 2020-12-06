using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal partial class FormChooseDateOn : Form
{
	internal DateTime DateOn
	{
		get
		{
			return this.dtpDate.Value;
		}
	}

	internal bool method_0()
	{
		return this.checkBoxIncludeChain.Checked;
	}

	internal FormChooseDateOn()
	{
		
		
		this.InitializeComponent();
		this.dtpDate.Value = DateTime.Now;
	}
}
