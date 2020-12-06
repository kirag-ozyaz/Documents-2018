using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr;
using FormLbr;

internal partial class Form61 : FormBase
{
	internal int Id
	{
		get
		{
			return this.int_0;
		}
		set
		{
			this.int_0 = value;
		}
	}

	internal int? method_0()
	{
		if (this.comboBox_0.SelectedValue != null)
		{
			if (this.comboBox_0.SelectedValue != DBNull.Value)
			{
				return new int?(Convert.ToInt32(this.comboBox_0.SelectedValue));
			}
		}
		return null;
	}

	internal void method_1(int? nullable_2)
	{
		this.nullable_0 = nullable_2;
	}

	internal int? method_2()
	{
		if (this.kladrStreetControl_0.SelectedStreet.SelectedValue != null)
		{
			if (this.kladrStreetControl_0.SelectedStreet.SelectedValue != DBNull.Value)
			{
				return new int?(Convert.ToInt32(this.kladrStreetControl_0.SelectedStreet.SelectedValue));
			}
		}
		return null;
	}

	internal void method_3(int? nullable_2)
	{
		this.nullable_1 = nullable_2;
	}

	internal string House
	{
		get
		{
			return this.textBox_0.Text;
		}
		set
		{
			this.string_0 = value;
		}
	}

	internal string Comment
	{
		get
		{
			return this.richTextBox_0.Text;
		}
		set
		{
			this.string_1 = value;
		}
	}

	public Form61()
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.dictionary_0 = new Dictionary<string, string>();
		
		this.method_5();
		this.method_4();
	}

	public Form61(int int_2, int int_3)
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.dictionary_0 = new Dictionary<string, string>();
		
		this.method_5();
		this.int_1 = int_3;
		this.int_0 = int_2;
		this.method_4();
	}

	private void method_4()
	{
		this.Text = ((this.int_0 == -1) ? "Новый адрес" : "Редактирование адреса");
		this.dictionary_0.Add("7325", "Ленинский");
		this.dictionary_0.Add("7328", "Заволжский");
		this.dictionary_0.Add("7327", "Засвияжский");
		this.dictionary_0.Add("7326", "Железнодорожный");
		this.kladrStreetControl_0.CmbStreet.Focus();
		this.kladrStreetControl_0.CmbStreet.Select();
	}

	private void Form61_Load(object sender, EventArgs e)
	{
		base.SelectSqlData(this.class130_0, this.class130_0.tR_Classifier, true, " where ParentKey = ';CityRaion;UlyanovskRaion;' and isGRoup = 0 and deleted = 0 order by name");
		this.comboBox_0.SelectedIndex = -1;
		this.kladrStreetControl_0.SqlSettings = this.SqlSettings;
		if (this.int_1 != -1)
		{
			if (this.int_0 == -1)
			{
				DataRow dataRow = this.class130_0.tJ_ExcavationAddress.NewRow();
				dataRow["idExcavation"] = this.int_1;
				this.class130_0.tJ_ExcavationAddress.Rows.Add(dataRow);
			}
			else
			{
				base.SelectSqlData(this.class130_0, this.class130_0.tJ_ExcavationAddress, true, " where id = " + this.int_0.ToString());
				if (this.class130_0.tJ_ExcavationAddress.Rows.Count > 0)
				{
					this.kladrStreetControl_0.SetStreetValue(Convert.ToInt32(this.class130_0.tJ_ExcavationAddress.Rows[0]["idStreet"]));
				}
				else
				{
					this.button_0.Enabled = false;
				}
			}
		}
		else
		{
			DataRow dataRow2 = this.class130_0.tJ_ExcavationAddress.NewRow();
			dataRow2["idExcavation"] = this.int_1;
			if (this.nullable_1 != null)
			{
				dataRow2["idStreet"] = this.nullable_1;
				this.kladrStreetControl_0.SetStreetValue(Convert.ToInt32(this.nullable_1));
			}
			if (this.nullable_0 != null)
			{
				dataRow2["idRegion"] = this.nullable_0;
			}
			if (!string.IsNullOrEmpty(this.string_0))
			{
				dataRow2["house"] = this.string_0;
			}
			if (!string.IsNullOrEmpty(this.string_1))
			{
				dataRow2["comment"] = this.string_1;
			}
			this.class130_0.tJ_ExcavationAddress.Rows.Add(dataRow2);
		}
		this.kladrStreetControl_0.ChangeStreetSelect += this.kladrStreetControl_0_ChangeStreetSelect;
	}

	private void kladrStreetControl_0_ChangeStreetSelect(object sender, EventArgs e)
	{
		if (this.kladrStreetControl_0.SelectedStreet.SelectedValue != null && this.kladrStreetControl_0.SelectedStreet.SelectedValue != DBNull.Value)
		{
			DataTable dataTable = base.SelectSqlData("tr_KladrStreet", true, " where id = " + this.kladrStreetControl_0.SelectedStreet.SelectedValue.ToString());
			if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["GNINMB"] != DBNull.Value)
			{
				this.comboBox_0.Text = this.dictionary_0[dataTable.Rows[0]["GNINMB"].ToString()];
			}
		}
	}

	private void Form61_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.kladrStreetControl_0.SelectedStreet.SelectedValue != null)
			{
				if (this.kladrStreetControl_0.SelectedStreet.SelectedValue != DBNull.Value)
				{
					if (this.comboBox_0.SelectedIndex == -1)
					{
						MessageBox.Show("Не выбран район");
						e.Cancel = true;
						return;
					}
					if (this.comboBox_0.SelectedIndex != -1)
					{
						this.class130_0.tJ_ExcavationAddress.Rows[0]["idregion"] = this.comboBox_0.SelectedValue;
					}
					this.class130_0.tJ_ExcavationAddress.Rows[0]["idStreet"] = this.kladrStreetControl_0.SelectedStreet.SelectedValue;
					this.class130_0.tJ_ExcavationAddress.Rows[0].EndEdit();
					if (this.int_1 == -1)
					{
						return;
					}
					if (this.int_0 == -1)
					{
						this.int_0 = base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationAddress);
						return;
					}
					base.UpdateSqlData(this.class130_0, this.class130_0.tJ_ExcavationAddress);
					return;
				}
			}
			MessageBox.Show("Не выбрана улица");
			e.Cancel = true;
			return;
		}
	}

	private void method_5()
	{
		this.kladrStreetControl_0 = new KladrStreetControl();
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.class130_0 = new DataSetExcavation();
		this.label_1 = new Label();
		this.richTextBox_0 = new RichTextBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.label_2 = new Label();
		this.comboBox_0 = new ComboBox();
		((ISupportInitialize)this.class130_0).BeginInit();
		base.SuspendLayout();
		this.kladrStreetControl_0.Location = new Point(12, 12);
		this.kladrStreetControl_0.Name = "kladrStreetControl1";
		this.kladrStreetControl_0.Size = new Size(174, 168);
		this.kladrStreetControl_0.SqlSettings = null;
		this.kladrStreetControl_0.TabIndex = 0;
		this.kladrStreetControl_0.VisibleCmbTypeHouse = false;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(189, 58);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(70, 13);
		this.label_0.TabIndex = 3;
		this.label_0.Text = "Номер дома";
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class130_0, "tJ_ExcavationAddress.House", true));
		this.textBox_0.Location = new Point(192, 74);
		this.textBox_0.Name = "textBoxHouse";
		this.textBox_0.Size = new Size(211, 20);
		this.textBox_0.TabIndex = 4;
		this.class130_0.DataSetName = "DataSetExcavation";
		this.class130_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(189, 97);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(70, 13);
		this.label_1.TabIndex = 5;
		this.label_1.Text = "Примечание";
		this.richTextBox_0.DataBindings.Add(new Binding("Text", this.class130_0, "tJ_ExcavationAddress.Comment", true));
		this.richTextBox_0.Location = new Point(192, 113);
		this.richTextBox_0.Name = "richTextBoxComment";
		this.richTextBox_0.Size = new Size(211, 58);
		this.richTextBox_0.TabIndex = 6;
		this.richTextBox_0.Text = "";
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(12, 186);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 7;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(328, 186);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 8;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(192, 12);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(38, 13);
		this.label_2.TabIndex = 1;
		this.label_2.Text = "Район";
		this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class130_0, "tJ_ExcavationAddress.idRegion", true));
		this.comboBox_0.DataSource = this.class130_0;
		this.comboBox_0.DisplayMember = "tR_Classifier.Name";
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(192, 28);
		this.comboBox_0.Name = "comboBoxRegion";
		this.comboBox_0.Size = new Size(211, 21);
		this.comboBox_0.TabIndex = 2;
		this.comboBox_0.ValueMember = "tR_Classifier.Id";
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(415, 219);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.richTextBox_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.kladrStreetControl_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormExcavationAddressAddEdit";
		this.Text = "Новый адрес";
		base.FormClosing += this.Form61_FormClosing;
		base.Load += this.Form61_Load;
		((ISupportInitialize)this.class130_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private int int_0;

	private int? nullable_0;

	private int? nullable_1;

	private string string_0;

	private string string_1;

	private int int_1;

	private Dictionary<string, string> dictionary_0;

	private KladrStreetControl kladrStreetControl_0;

	private Label label_0;

	private TextBox textBox_0;

	private Label label_1;

	private RichTextBox richTextBox_0;

	private Button button_0;

	private Button button_1;

	private DataSetExcavation class130_0;

	private Label label_2;

	private ComboBox comboBox_0;
}
