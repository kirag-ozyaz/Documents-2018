using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

internal partial class FormNewFileName : Form
{
	public string FileName { get; set; }

	public FormNewFileName()
	{
		
		this.string_1 = "";
		
		this.InitializeComponent();
		this.string_1 = Path.GetExtension(this.FileName);
		this.tbNewFileName.Text = Path.GetFileNameWithoutExtension(this.FileName);
	}

	public FormNewFileName(string string_2)
	{
		
		this.string_1 = "";
		
		this.InitializeComponent();
		this.string_1 = Path.GetExtension(string_2);
		this.tbNewFileName.Text = Path.GetFileNameWithoutExtension(string_2);
	}

	private void btnAccept_Click(object sender, EventArgs e)
	{
		this.FileName = this.tbNewFileName.Text + this.string_1;
		base.DialogResult = DialogResult.OK;
		base.Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	[CompilerGenerated]
	private string string_0;

	private string string_1;
}
