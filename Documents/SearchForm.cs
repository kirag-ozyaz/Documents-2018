using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

internal partial class SearchForm : Form
{
	internal SearchForm()
	{
		
		
		this.InitializeComponent();
	}

	private void radioButtonLegal_CheckedChanged(object sender, EventArgs e)
	{
		if (!this.radioButtonLegal.Checked)
		{
			return;
		}
		this.comboBoxSearchType.Items.Clear();
		this.comboBoxSearchType.Items.Add("Абоненту");
		this.comboBoxSearchType.Items.Add("Объекту");
		this.comboBoxSearchType.Items.Add("Номеру договора");
		this.comboBoxSearchType.SelectedIndex = 0;
	}

	private void radioButtonIndiviual_CheckedChanged(object sender, EventArgs e)
	{
		if (!this.radioButtonIndiviual.Checked)
		{
			return;
		}
		this.comboBoxSearchType.Items.Clear();
		this.comboBoxSearchType.Items.Add("Абоненту");
		this.comboBoxSearchType.Items.Add("Объекту");
		this.comboBoxSearchType.Items.Add("Номеру л/сч");
		this.comboBoxSearchType.SelectedIndex = 0;
	}

	private void SearchForm_Load(object sender, EventArgs e)
	{
		this.radioButtonLegal.Checked = true;
	}
}
