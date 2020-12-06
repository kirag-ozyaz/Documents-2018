using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FormLbr;

internal partial class Form3 : FormBase
{
	internal int? IdRequest
	{
		get
		{
			if (this.comboBox_0.SelectedIndex == -1)
			{
				return null;
			}
			return new int?(Convert.ToInt32(this.comboBox_0.SelectedValue));
		}
	}

	internal Form3()
	{
		
		
		this.method_0();
	}

	internal Form3(int int_1, int? nullable_1)
	{
		
		
		this.method_0();
		this.int_0 = int_1;
		this.nullable_0 = nullable_1;
	}

	private void Form3_Load(object sender, EventArgs e)
	{
		DataTable dataTable = new DataTable("vTC_Request");
		dataTable.Columns.Add("id", typeof(int));
		dataTable.Columns.Add("numdateIn", typeof(string));
		this.comboBox_0.DisplayMember = "numdatein";
		this.comboBox_0.ValueMember = "id";
		this.comboBox_0.DataSource = dataTable;
		string str;
		if (this.nullable_0 == null)
		{
			str = "where idAbn = " + this.int_0.ToString();
		}
		else
		{
			str = "where (idAbn = " + this.int_0.ToString() + " and idAbnObj is null) or idAbnObj = " + this.nullable_0.ToString();
		}
		base.SelectSqlData(dataTable, true, str + " order by numdatein", null, false, 0);
	}

	private void SblZnhIxyw(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK && this.comboBox_0.SelectedIndex == -1)
		{
			base.DialogResult = DialogResult.Cancel;
		}
	}

	private void method_0()
	{
		this.comboBox_0 = new ComboBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.label_0 = new Label();
		base.SuspendLayout();
		this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(12, 25);
		this.comboBox_0.Name = "comboBox1";
		this.comboBox_0.Size = new Size(226, 21);
		this.comboBox_0.TabIndex = 0;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(12, 63);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 1;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(163, 63);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 2;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 9);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(210, 13);
		this.label_0.TabIndex = 3;
		this.label_0.Text = "Выберите заявку на тех присоединение";
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(254, 102);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.comboBox_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormChoiceTechConnectionRequest";
		this.Text = "Выбор заявки на тех присоединение";
		base.FormClosing += this.SblZnhIxyw;
		base.Load += this.Form3_Load;
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	internal static void VE46Ll5iOBUw4uePaEY(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private int int_0;

	private int? nullable_0;

	private ComboBox comboBox_0;

	private Button button_0;

	private Button button_1;

	private Label label_0;
}
