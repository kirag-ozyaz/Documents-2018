using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FormLbr;

internal partial class Form58 : FormBase
{
	internal Form58()
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.int_2 = -1;
		this.int_3 = -1;
		this.int_4 = -1;
		this.int_5 = -1;
		
		this.method_3();
	}

	internal Form58(int int_6, int int_7, int int_8, int int_9, int int_10, int int_11)
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.int_2 = -1;
		this.int_3 = -1;
		this.int_4 = -1;
		this.int_5 = -1;
		
		this.method_3();
		this.method_0(int_6, int_7, int_8, int_9, int_10, int_11);
	}

	internal Form58(int int_6, int int_7, int int_8, int int_9, int int_10, int int_11, bool bool_0)
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		this.int_2 = -1;
		this.int_3 = -1;
		this.int_4 = -1;
		this.int_5 = -1;
		
		this.method_3();
		this.method_0(int_6, int_7, int_8, int_9, int_10, int_11);
		if (bool_0)
		{
			this.dateTimePicker_0.Enabled = false;
			this.textBox_1.ReadOnly = true;
			this.textBox_0.ReadOnly = true;
			this.comboBox_4.Enabled = false;
			this.textBox_4.ReadOnly = true;
			this.textBox_3.ReadOnly = true;
			this.textBox_2.ReadOnly = true;
			this.textBox_6.ReadOnly = true;
			this.textBox_5.ReadOnly = true;
			this.textBox_8.ReadOnly = true;
			this.textBox_7.ReadOnly = true;
			this.textBox_10.ReadOnly = true;
			this.textBox_9.ReadOnly = true;
			this.comboBox_6.Enabled = false;
			this.comboBox_5.Enabled = false;
			this.textBox_12.ReadOnly = true;
			this.textBox_11.ReadOnly = true;
			this.richTextBox_0.ReadOnly = true;
			this.comboBox_7.Enabled = false;
			Control control = this.checkBox_1;
			this.checkBox_0.Enabled = false;
			control.Enabled = false;
			this.checkBox_2.Enabled = false;
		}
	}

	private void method_0(int int_6, int int_7, int int_8, int int_9, int int_10, int int_11)
	{
		this.int_0 = int_6;
		this.int_1 = int_7;
		this.int_2 = int_8;
		this.int_3 = int_9;
		this.int_4 = int_10;
		this.int_5 = int_11;
		this.dateTimePicker_0.Value = DateTime.Now.Date;
		if (this.int_4 == -1)
		{
			this.Text = "Новая уставка";
			return;
		}
		if (this.int_5 < 0)
		{
			this.Text = "Новые значения";
			return;
		}
		this.Text = "Редактирование";
	}

	private void Form58_Load(object sender, EventArgs e)
	{
		this.dataTable_0 = this.method_1();
		this.dataTable_1 = this.method_1();
		this.dataTable_2 = new DataTable("vSChm_treeCellLine");
		DataColumn column = new DataColumn("id", Type.GetType("System.Int32"));
		this.dataTable_2.Columns.Add(column);
		DataColumn column2 = new DataColumn("Name", Type.GetType("System.String"));
		this.dataTable_2.Columns.Add(column2);
		this.method_2();
		this.comboBox_0.SelectedValue = this.int_0;
		this.comboBox_1.SelectedValue = this.int_1;
		this.comboBox_2.SelectedValue = this.int_2;
		this.comboBox_3.SelectedValue = this.int_3;
		if (this.int_4 < 0)
		{
			DataRow dataRow = this.class255_0.tJ_RelayProtectionAutomation.NewRow();
			if (this.comboBox_3.SelectedIndex >= 0)
			{
				dataRow["IdSchmObj"] = this.comboBox_3.SelectedValue;
			}
			else
			{
				dataRow["IdSchmObj"] = -1;
			}
			dataRow["deleted"] = false;
			this.class255_0.tJ_RelayProtectionAutomation.Rows.Add(dataRow);
			dataRow = this.class255_0.tJ_RelayProtectionAutomationValue.NewRow();
			dataRow["IdRelay"] = -1;
			dataRow["DateIn"] = DateTime.Now.Date;
			dataRow["Datecreate"] = DateTime.Now;
			dataRow["deleted"] = false;
			this.class255_0.tJ_RelayProtectionAutomationValue.Rows.Add(dataRow);
			return;
		}
		this.comboBox_1.Enabled = false;
		this.comboBox_2.Enabled = false;
		this.comboBox_0.Enabled = false;
		this.comboBox_3.Enabled = false;
		base.SelectSqlData(this.class255_0, this.class255_0.tJ_RelayProtectionAutomation, true, "where id = " + this.int_4.ToString());
		if (this.int_5 < 0)
		{
			base.SelectSqlData(this.class255_0, this.class255_0.tJ_RelayProtectionAutomationValue, true, " where idRelay = " + this.int_4.ToString() + " order by dateIn desc");
			if (this.class255_0.tJ_RelayProtectionAutomationValue.Rows.Count > 0)
			{
				this.dateTimePicker_0.MinDate = Convert.ToDateTime(this.class255_0.tJ_RelayProtectionAutomationValue.Rows[0]["DateIn"]).AddDays(1.0);
				this.class255_0.tJ_RelayProtectionAutomationValue.Clear();
			}
			DataRow dataRow2 = this.class255_0.tJ_RelayProtectionAutomationValue.NewRow();
			dataRow2["IdRelay"] = this.int_4;
			if (this.dateTimePicker_0.MinDate > DateTime.Now.Date)
			{
				dataRow2["DateIn"] = this.dateTimePicker_0.MinDate;
			}
			else
			{
				dataRow2["DateIn"] = DateTime.Now.Date;
			}
			dataRow2["Datecreate"] = DateTime.Now;
			dataRow2["deleted"] = false;
			this.class255_0.tJ_RelayProtectionAutomationValue.Rows.Add(dataRow2);
			return;
		}
		base.SelectSqlData(this.class255_0, this.class255_0.tJ_RelayProtectionAutomationValue, true, " where id = " + this.int_5.ToString());
	}

	private DataTable method_1()
	{
		Type type = Type.GetType("System.Int32");
		DataTable dataTable = new DataTable("tSchm_ObjList");
		DataColumn dataColumn = new DataColumn("id", type);
		dataTable.Columns.Add(dataColumn);
		DataColumn column = new DataColumn("Name", Type.GetType("System.String"));
		dataTable.Columns.Add(column);
		dataTable.PrimaryKey = new DataColumn[]
		{
			dataColumn
		};
		return dataTable;
	}

	private void method_2()
	{
		Class255 @class = new Class255();
		base.SelectSqlData(@class, @class.tR_Classifier, true, " where ParentKey = ';SCM;PS;' and isgroup = 0 and deleted = 0 order by name");
		this.comboBox_0.DisplayMember = "Name";
		this.comboBox_0.ValueMember = "id";
		this.comboBox_0.DataSource = @class.tR_Classifier;
		this.comboBox_1.DisplayMember = "Name";
		this.comboBox_1.ValueMember = "Id";
		this.comboBox_1.DataSource = this.dataTable_0;
		this.comboBox_2.DisplayMember = "Name";
		this.comboBox_2.ValueMember = "Id";
		this.comboBox_2.DataSource = this.dataTable_1;
		this.comboBox_3.DisplayMember = "Name";
		this.comboBox_3.ValueMember = "Id";
		this.comboBox_3.DataSource = this.dataTable_2;
		Class255 class2 = new Class255();
		base.SelectSqlData(class2, class2.tR_Classifier, true, " where ParentKey = ';TypeTransformatorAmperage;' and isgroup = 0 and deleted = 0 order by name");
		this.comboBox_4.DisplayMember = "Name";
		this.comboBox_4.ValueMember = "id";
		this.comboBox_4.DataSource = class2.tR_Classifier;
		DataTable dataTable = new DataTable("tJ_RelayProtectionAutomationValue");
		DataColumn column = new DataColumn("type_relay");
		dataTable.Columns.Add(column);
		base.SelectSqlData(dataTable, true, " group by type_relay order by type_relay", null, false, 0);
		foreach (object obj in dataTable.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			this.comboBox_6.Items.Add(dataRow["type_relay"].ToString());
		}
		dataTable = new DataTable("tJ_RelayProtectionAutomationValue");
		DataColumn column2 = new DataColumn("type_proc");
		dataTable.Columns.Add(column2);
		base.SelectSqlData(dataTable, true, " group by type_proc order by type_proc", null, false, 0);
		foreach (object obj2 in dataTable.Rows)
		{
			DataRow dataRow2 = (DataRow)obj2;
			this.comboBox_5.Items.Add(dataRow2["type_proc"].ToString());
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.comboBox_0.SelectedIndex < 0)
		{
			this.dataTable_0.Clear();
			return;
		}
		base.SelectSqlData(this.dataTable_0, true, " where typeCodeId = " + this.comboBox_0.SelectedValue.ToString() + " and deleted = 0 order by name", null, false, 0);
		this.comboBox_1.SelectedIndex = -1;
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.comboBox_1.SelectedIndex < 0)
		{
			this.dataTable_1.Clear();
			return;
		}
		Class469 @class = new Class469();
		base.SelectSqlData(@class, @class.tR_Classifier, true, " where ParentKey in (';SCM;BUS;BUSHV;', ';SCM;BUS;BUSMV;') and deleted = 0 and isgroup = 0 ");
		string text = "";
		foreach (object obj in @class.tR_Classifier.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			text = text + dataRow["id"].ToString() + ",";
		}
		text = text.Remove(text.Length - 1);
		base.SelectSqlData(this.dataTable_1, true, string.Concat(new string[]
		{
			" where idParent = ",
			this.comboBox_1.SelectedValue.ToString(),
			" and typecodeId in (",
			text,
			") and deleted = 0 order by name"
		}), null, false, 0);
		this.comboBox_2.SelectedIndex = -1;
	}

	private void comboBox_2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.comboBox_2.SelectedIndex < 0)
		{
			this.dataTable_2.Clear();
			return;
		}
		base.SelectSqlData(this.dataTable_2, true, " where ParentLink = " + this.comboBox_2.SelectedValue.ToString() + " order by name", null, false, 0);
		this.comboBox_3.SelectedIndex = -1;
	}

	private void Form58_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.comboBox_3.SelectedValue == null)
			{
				MessageBox.Show("Выберите ячейку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				e.Cancel = true;
				return;
			}
			this.class255_0.tJ_RelayProtectionAutomation.Rows[0].EndEdit();
			if (this.int_4 < 0)
			{
				try
				{
					this.int_4 = base.InsertSqlDataOneRow(this.class255_0, this.class255_0.tJ_RelayProtectionAutomation);
					if (this.int_4 > 0)
					{
						this.class255_0.tJ_RelayProtectionAutomationValue.Rows[0]["idRelay"] = this.int_4;
						this.class255_0.tJ_RelayProtectionAutomationValue.Rows[0].EndEdit();
						base.InsertSqlDataOneRow(this.class255_0, this.class255_0.tJ_RelayProtectionAutomationValue);
					}
					else
					{
						e.Cancel = true;
					}
					return;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
					return;
				}
			}
			this.class255_0.tJ_RelayProtectionAutomation.Rows[0].EndEdit();
			base.UpdateSqlData(this.class255_0, this.class255_0.tJ_RelayProtectionAutomation);
			if (this.int_5 < 0)
			{
				this.class255_0.tJ_RelayProtectionAutomationValue.Rows[0].EndEdit();
				base.InsertSqlDataOneRow(this.class255_0, this.class255_0.tJ_RelayProtectionAutomationValue);
				return;
			}
			this.class255_0.tJ_RelayProtectionAutomationValue.Rows[0].EndEdit();
			base.UpdateSqlData(this.class255_0, this.class255_0.tJ_RelayProtectionAutomationValue);
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	private void comboBox_6_TextUpdate(object sender, EventArgs e)
	{
		this.class255_0.tJ_RelayProtectionAutomationValue.Rows[0]["type_relay"] = this.comboBox_6.Text;
	}

	private void comboBox_5_TextUpdate(object sender, EventArgs e)
	{
		this.class255_0.tJ_RelayProtectionAutomationValue.Rows[0]["type_proc"] = this.comboBox_5.Text;
	}

	private void comboBox_7_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Delete)
		{
			this.comboBox_7.SelectedIndex = -1;
		}
	}

	private void comboBox_8_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
		{
			this.comboBox_8.SelectedIndex = -1;
		}
	}

	private void method_3()
	{
		this.icontainer_0 = new Container();
		this.class255_0 = new Class255();
		this.label_0 = new Label();
		this.dateTimePicker_0 = new DateTimePicker();
		this.label_1 = new Label();
		this.comboBox_0 = new ComboBox();
		this.label_2 = new Label();
		this.comboBox_1 = new ComboBox();
		this.label_3 = new Label();
		this.comboBox_2 = new ComboBox();
		this.label_4 = new Label();
		this.comboBox_3 = new ComboBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.groupBox_0 = new GroupBox();
		this.comboBox_4 = new ComboBox();
		this.label_5 = new Label();
		this.textBox_0 = new TextBox();
		this.textBox_1 = new TextBox();
		this.label_6 = new Label();
		this.label_7 = new Label();
		this.groupBox_1 = new GroupBox();
		this.textBox_2 = new TextBox();
		this.label_9 = new Label();
		this.textBox_3 = new TextBox();
		this.label_10 = new Label();
		this.textBox_4 = new TextBox();
		this.label_8 = new Label();
		this.groupBox_2 = new GroupBox();
		this.comboBox_7 = new ComboBox();
		this.label_20 = new Label();
		this.textBox_5 = new TextBox();
		this.label_11 = new Label();
		this.textBox_6 = new TextBox();
		this.label_12 = new Label();
		this.groupBox_3 = new GroupBox();
		this.textBox_7 = new TextBox();
		this.label_13 = new Label();
		this.textBox_8 = new TextBox();
		this.label_14 = new Label();
		this.groupBox_4 = new GroupBox();
		this.textBox_9 = new TextBox();
		this.label_15 = new Label();
		this.textBox_10 = new TextBox();
		this.label_16 = new Label();
		this.groupBox_5 = new GroupBox();
		this.comboBox_5 = new ComboBox();
		this.comboBox_6 = new ComboBox();
		this.groupBox_6 = new GroupBox();
		this.textBox_11 = new TextBox();
		this.label_17 = new Label();
		this.textBox_12 = new TextBox();
		this.label_18 = new Label();
		this.label_19 = new Label();
		this.richTextBox_0 = new RichTextBox();
		this.groupBox_7 = new GroupBox();
		this.comboBox_8 = new ComboBox();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.checkBox_0 = new CheckBox();
		this.checkBox_1 = new CheckBox();
		this.checkBox_2 = new CheckBox();
		((ISupportInitialize)this.class255_0).BeginInit();
		this.groupBox_0.SuspendLayout();
		this.groupBox_1.SuspendLayout();
		this.groupBox_2.SuspendLayout();
		this.groupBox_3.SuspendLayout();
		this.groupBox_4.SuspendLayout();
		this.groupBox_5.SuspendLayout();
		this.groupBox_6.SuspendLayout();
		this.groupBox_7.SuspendLayout();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		base.SuspendLayout();
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 18);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(33, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Дата";
		this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class255_0, "tJ_RelayProtectionAutomationValue.dateIn", true));
		this.dateTimePicker_0.Location = new Point(51, 12);
		this.dateTimePicker_0.Name = "dateTimePickerIn";
		this.dateTimePicker_0.Size = new Size(158, 20);
		this.dateTimePicker_0.TabIndex = 1;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(6, 21);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(88, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Тип подстанции";
		this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(100, 18);
		this.comboBox_0.Name = "cmbTypeSub";
		this.comboBox_0.Size = new Size(103, 21);
		this.comboBox_0.TabIndex = 3;
		this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(209, 21);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(68, 13);
		this.label_2.TabIndex = 4;
		this.label_2.Text = "Подстанция";
		this.comboBox_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_1.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(283, 18);
		this.comboBox_1.Name = "cmbSub";
		this.comboBox_1.Size = new Size(123, 21);
		this.comboBox_1.TabIndex = 5;
		this.comboBox_1.SelectedIndexChanged += this.comboBox_1_SelectedIndexChanged;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(7, 51);
		this.label_3.Name = "label4";
		this.label_3.Size = new Size(34, 13);
		this.label_3.TabIndex = 6;
		this.label_3.Text = "Шина";
		this.comboBox_2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_2.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Location = new Point(46, 48);
		this.comboBox_2.Name = "cmbBus";
		this.comboBox_2.Size = new Size(48, 21);
		this.comboBox_2.TabIndex = 7;
		this.comboBox_2.SelectedIndexChanged += this.comboBox_2_SelectedIndexChanged;
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(102, 51);
		this.label_4.Name = "label5";
		this.label_4.Size = new Size(44, 13);
		this.label_4.TabIndex = 8;
		this.label_4.Text = "Ячейка";
		this.comboBox_3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_3.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_3.DataBindings.Add(new Binding("SelectedValue", this.class255_0, "tJ_RelayProtectionAutomation.idSchmObj", true));
		this.comboBox_3.FormattingEnabled = true;
		this.comboBox_3.Location = new Point(150, 48);
		this.comboBox_3.Name = "cmbCell";
		this.comboBox_3.Size = new Size(53, 21);
		this.comboBox_3.TabIndex = 9;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(4, 552);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 10;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(344, 552);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 11;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.groupBox_0.Controls.Add(this.comboBox_4);
		this.groupBox_0.Controls.Add(this.label_5);
		this.groupBox_0.Controls.Add(this.textBox_0);
		this.groupBox_0.Controls.Add(this.textBox_1);
		this.groupBox_0.Controls.Add(this.label_6);
		this.groupBox_0.Controls.Add(this.label_7);
		this.groupBox_0.Location = new Point(4, 123);
		this.groupBox_0.Name = "groupBoxTransformator";
		this.groupBox_0.Size = new Size(415, 55);
		this.groupBox_0.TabIndex = 13;
		this.groupBox_0.TabStop = false;
		this.groupBox_0.Text = "Трансформатор";
		this.comboBox_4.DataBindings.Add(new Binding("SelectedValue", this.class255_0, "tJ_RelayProtectionAutomationValue.idTypeTr", true));
		this.comboBox_4.FormattingEnabled = true;
		this.comboBox_4.Location = new Point(228, 24);
		this.comboBox_4.Name = "cmbTypeTr";
		this.comboBox_4.Size = new Size(178, 21);
		this.comboBox_4.TabIndex = 5;
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(196, 27);
		this.label_5.Name = "label8";
		this.label_5.Size = new Size(26, 13);
		this.label_5.TabIndex = 4;
		this.label_5.Text = "Тип";
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.amp_secondary", true, DataSourceUpdateMode.OnPropertyChanged, ""));
		this.textBox_0.Location = new Point(128, 24);
		this.textBox_0.Name = "txtT2";
		this.textBox_0.Size = new Size(62, 20);
		this.textBox_0.TabIndex = 3;
		this.textBox_1.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.amp_primary", true, DataSourceUpdateMode.OnPropertyChanged, ""));
		this.textBox_1.Location = new Point(34, 24);
		this.textBox_1.Name = "txtT1";
		this.textBox_1.Size = new Size(62, 20);
		this.textBox_1.TabIndex = 2;
		this.label_6.AutoSize = true;
		this.label_6.Location = new Point(102, 27);
		this.label_6.Name = "label7";
		this.label_6.Size = new Size(20, 13);
		this.label_6.TabIndex = 1;
		this.label_6.Text = "Т2";
		this.label_7.AutoSize = true;
		this.label_7.Location = new Point(8, 27);
		this.label_7.Name = "label6";
		this.label_7.Size = new Size(20, 13);
		this.label_7.TabIndex = 0;
		this.label_7.Text = "Т1";
		this.groupBox_1.Controls.Add(this.textBox_2);
		this.groupBox_1.Controls.Add(this.label_9);
		this.groupBox_1.Controls.Add(this.textBox_3);
		this.groupBox_1.Controls.Add(this.label_10);
		this.groupBox_1.Controls.Add(this.textBox_4);
		this.groupBox_1.Controls.Add(this.label_8);
		this.groupBox_1.Location = new Point(4, 184);
		this.groupBox_1.Name = "groupBoxMTZ";
		this.groupBox_1.Size = new Size(415, 58);
		this.groupBox_1.TabIndex = 14;
		this.groupBox_1.TabStop = false;
		this.groupBox_1.Text = "МТЗ";
		this.textBox_2.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.speed_mtz", true, DataSourceUpdateMode.OnPropertyChanged, ""));
		this.textBox_2.Location = new Point(297, 22);
		this.textBox_2.Name = "txtSpeedMTZ";
		this.textBox_2.Size = new Size(109, 20);
		this.textBox_2.TabIndex = 5;
		this.label_9.AutoSize = true;
		this.label_9.Location = new Point(228, 25);
		this.label_9.Name = "label11";
		this.label_9.Size = new Size(63, 13);
		this.label_9.TabIndex = 4;
		this.label_9.Text = "Ускорение";
		this.textBox_3.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.time_mtz", true, DataSourceUpdateMode.OnPropertyChanged, ""));
		this.textBox_3.Location = new Point(148, 22);
		this.textBox_3.Name = "txtTimeMTZ";
		this.textBox_3.Size = new Size(74, 20);
		this.textBox_3.TabIndex = 3;
		this.label_10.AutoSize = true;
		this.label_10.Location = new Point(102, 25);
		this.label_10.Name = "label10";
		this.label_10.Size = new Size(40, 13);
		this.label_10.TabIndex = 2;
		this.label_10.Text = "Время";
		this.textBox_4.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.amp_mtz", true, DataSourceUpdateMode.OnPropertyChanged, ""));
		this.textBox_4.Location = new Point(34, 22);
		this.textBox_4.Name = "txtAmpMTZ";
		this.textBox_4.Size = new Size(62, 20);
		this.textBox_4.TabIndex = 1;
		this.label_8.AutoSize = true;
		this.label_8.Location = new Point(6, 25);
		this.label_8.Name = "label9";
		this.label_8.Size = new Size(26, 13);
		this.label_8.TabIndex = 0;
		this.label_8.Text = "Ток";
		this.groupBox_2.Controls.Add(this.comboBox_7);
		this.groupBox_2.Controls.Add(this.label_20);
		this.groupBox_2.Controls.Add(this.textBox_5);
		this.groupBox_2.Controls.Add(this.label_11);
		this.groupBox_2.Controls.Add(this.textBox_6);
		this.groupBox_2.Controls.Add(this.label_12);
		this.groupBox_2.Location = new Point(218, 248);
		this.groupBox_2.Name = "groupBoxOZZ";
		this.groupBox_2.Size = new Size(200, 122);
		this.groupBox_2.TabIndex = 15;
		this.groupBox_2.TabStop = false;
		this.groupBox_2.Text = "ОЗЗ";
		this.comboBox_7.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.act_ozz", true));
		this.comboBox_7.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_7.FormattingEnabled = true;
		this.comboBox_7.Items.AddRange(new object[]
		{
			"на отключение",
			"на сигнал"
		});
		this.comboBox_7.Location = new Point(9, 89);
		this.comboBox_7.Name = "comboBoxAct_OZZ";
		this.comboBox_7.Size = new Size(183, 21);
		this.comboBox_7.TabIndex = 5;
		this.comboBox_7.KeyDown += this.comboBox_7_KeyDown;
		this.label_20.AutoSize = true;
		this.label_20.Location = new Point(6, 73);
		this.label_20.Name = "label16";
		this.label_20.Size = new Size(57, 13);
		this.label_20.TabIndex = 4;
		this.label_20.Text = "Действие";
		this.textBox_5.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.time_ozz", true, DataSourceUpdateMode.OnPropertyChanged, ""));
		this.textBox_5.Location = new Point(138, 22);
		this.textBox_5.Name = "txtTimeOZZ";
		this.textBox_5.Size = new Size(54, 20);
		this.textBox_5.TabIndex = 3;
		this.label_11.AutoSize = true;
		this.label_11.Location = new Point(92, 25);
		this.label_11.Name = "label13";
		this.label_11.Size = new Size(40, 13);
		this.label_11.TabIndex = 2;
		this.label_11.Text = "Время";
		this.textBox_6.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.amp_ozz", true, DataSourceUpdateMode.OnPropertyChanged, ""));
		this.textBox_6.Location = new Point(34, 22);
		this.textBox_6.Name = "txtAmpOzz";
		this.textBox_6.Size = new Size(52, 20);
		this.textBox_6.TabIndex = 1;
		this.label_12.AutoSize = true;
		this.label_12.Location = new Point(6, 25);
		this.label_12.Name = "label14";
		this.label_12.Size = new Size(26, 13);
		this.label_12.TabIndex = 0;
		this.label_12.Text = "Ток";
		this.groupBox_3.Controls.Add(this.textBox_7);
		this.groupBox_3.Controls.Add(this.label_13);
		this.groupBox_3.Controls.Add(this.textBox_8);
		this.groupBox_3.Controls.Add(this.label_14);
		this.groupBox_3.Location = new Point(4, 248);
		this.groupBox_3.Name = "groupBoxTO";
		this.groupBox_3.Size = new Size(209, 58);
		this.groupBox_3.TabIndex = 16;
		this.groupBox_3.TabStop = false;
		this.groupBox_3.Text = "ТО";
		this.textBox_7.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.time_to", true, DataSourceUpdateMode.OnPropertyChanged, ""));
		this.textBox_7.Location = new Point(148, 22);
		this.textBox_7.Name = "txtTimeTO";
		this.textBox_7.Size = new Size(57, 20);
		this.textBox_7.TabIndex = 3;
		this.label_13.AutoSize = true;
		this.label_13.Location = new Point(102, 29);
		this.label_13.Name = "label12";
		this.label_13.Size = new Size(40, 13);
		this.label_13.TabIndex = 2;
		this.label_13.Text = "Время";
		this.textBox_8.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.amp_to", true, DataSourceUpdateMode.OnPropertyChanged, ""));
		this.textBox_8.Location = new Point(34, 22);
		this.textBox_8.Name = "txtAmpTO";
		this.textBox_8.Size = new Size(62, 20);
		this.textBox_8.TabIndex = 1;
		this.label_14.AutoSize = true;
		this.label_14.Location = new Point(6, 25);
		this.label_14.Name = "label15";
		this.label_14.Size = new Size(26, 13);
		this.label_14.TabIndex = 0;
		this.label_14.Text = "Ток";
		this.groupBox_4.Controls.Add(this.textBox_9);
		this.groupBox_4.Controls.Add(this.label_15);
		this.groupBox_4.Controls.Add(this.textBox_10);
		this.groupBox_4.Controls.Add(this.label_16);
		this.groupBox_4.Location = new Point(4, 312);
		this.groupBox_4.Name = "groupBoxUROV";
		this.groupBox_4.Size = new Size(209, 58);
		this.groupBox_4.TabIndex = 18;
		this.groupBox_4.TabStop = false;
		this.groupBox_4.Text = "УРОВ";
		this.textBox_9.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.time_urov", true, DataSourceUpdateMode.OnPropertyChanged, ""));
		this.textBox_9.Location = new Point(148, 22);
		this.textBox_9.Name = "txtTimeUrov";
		this.textBox_9.Size = new Size(57, 20);
		this.textBox_9.TabIndex = 3;
		this.label_15.AutoSize = true;
		this.label_15.Location = new Point(102, 25);
		this.label_15.Name = "label18";
		this.label_15.Size = new Size(40, 13);
		this.label_15.TabIndex = 2;
		this.label_15.Text = "Время";
		this.textBox_10.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.amp_urov", true, DataSourceUpdateMode.OnPropertyChanged, ""));
		this.textBox_10.Location = new Point(34, 22);
		this.textBox_10.Name = "txtAmpUrov";
		this.textBox_10.Size = new Size(62, 20);
		this.textBox_10.TabIndex = 1;
		this.label_16.AutoSize = true;
		this.label_16.Location = new Point(6, 25);
		this.label_16.Name = "label19";
		this.label_16.Size = new Size(26, 13);
		this.label_16.TabIndex = 0;
		this.label_16.Text = "Ток";
		this.groupBox_5.Controls.Add(this.comboBox_5);
		this.groupBox_5.Controls.Add(this.comboBox_6);
		this.groupBox_5.Location = new Point(4, 376);
		this.groupBox_5.Name = "groupBox3";
		this.groupBox_5.Size = new Size(209, 54);
		this.groupBox_5.TabIndex = 19;
		this.groupBox_5.TabStop = false;
		this.groupBox_5.Text = "Тип реле и микропроц. устр-ва";
		this.comboBox_5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_5.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_5.DataBindings.Add(new Binding("SelectedItem", this.class255_0, "tJ_RelayProtectionAutomationValue.type_proc", true));
		this.comboBox_5.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.type_proc", true));
		this.comboBox_5.FormattingEnabled = true;
		this.comboBox_5.Location = new Point(171, 19);
		this.comboBox_5.Name = "cmbMicroProc";
		this.comboBox_5.Size = new Size(38, 21);
		this.comboBox_5.Sorted = true;
		this.comboBox_5.TabIndex = 1;
		this.comboBox_5.Visible = false;
		this.comboBox_5.TextUpdate += this.comboBox_5_TextUpdate;
		this.comboBox_6.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_6.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_6.DataBindings.Add(new Binding("SelectedItem", this.class255_0, "tJ_RelayProtectionAutomationValue.type_relay", true));
		this.comboBox_6.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.type_relay", true));
		this.comboBox_6.FormattingEnabled = true;
		this.comboBox_6.Location = new Point(8, 19);
		this.comboBox_6.Name = "cmbRele";
		this.comboBox_6.Size = new Size(157, 21);
		this.comboBox_6.Sorted = true;
		this.comboBox_6.TabIndex = 0;
		this.comboBox_6.TextUpdate += this.comboBox_6_TextUpdate;
		this.groupBox_6.Controls.Add(this.textBox_11);
		this.groupBox_6.Controls.Add(this.label_17);
		this.groupBox_6.Controls.Add(this.textBox_12);
		this.groupBox_6.Controls.Add(this.label_18);
		this.groupBox_6.Location = new Point(4, 434);
		this.groupBox_6.Name = "groupBox4";
		this.groupBox_6.Size = new Size(415, 50);
		this.groupBox_6.TabIndex = 20;
		this.groupBox_6.TabStop = false;
		this.groupBox_6.Text = "Наименование присоединения";
		this.textBox_11.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.cp_cell", true));
		this.textBox_11.Location = new Point(249, 22);
		this.textBox_11.Name = "txtcp_cell";
		this.textBox_11.Size = new Size(157, 20);
		this.textBox_11.TabIndex = 3;
		this.label_17.AutoSize = true;
		this.label_17.Location = new Point(196, 25);
		this.label_17.Name = "label21";
		this.label_17.Size = new Size(44, 13);
		this.label_17.TabIndex = 2;
		this.label_17.Text = "Ячейка";
		this.textBox_12.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.cp", true));
		this.textBox_12.Location = new Point(39, 22);
		this.textBox_12.Name = "txtcp_name";
		this.textBox_12.Size = new Size(151, 20);
		this.textBox_12.TabIndex = 1;
		this.label_18.AutoSize = true;
		this.label_18.Location = new Point(8, 25);
		this.label_18.Name = "label20";
		this.label_18.Size = new Size(29, 13);
		this.label_18.TabIndex = 0;
		this.label_18.Text = "Имя";
		this.label_19.AutoSize = true;
		this.label_19.Location = new Point(12, 487);
		this.label_19.Name = "label22";
		this.label_19.Size = new Size(70, 13);
		this.label_19.TabIndex = 21;
		this.label_19.Text = "Примечание";
		this.richTextBox_0.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomationValue.comment", true));
		this.richTextBox_0.Location = new Point(4, 503);
		this.richTextBox_0.Name = "txtComment";
		this.richTextBox_0.Size = new Size(415, 43);
		this.richTextBox_0.TabIndex = 22;
		this.richTextBox_0.Text = "";
		this.groupBox_7.Controls.Add(this.comboBox_8);
		this.groupBox_7.Controls.Add(this.label_1);
		this.groupBox_7.Controls.Add(this.comboBox_0);
		this.groupBox_7.Controls.Add(this.label_2);
		this.groupBox_7.Controls.Add(this.comboBox_1);
		this.groupBox_7.Controls.Add(this.label_3);
		this.groupBox_7.Controls.Add(this.comboBox_2);
		this.groupBox_7.Controls.Add(this.label_4);
		this.groupBox_7.Controls.Add(this.comboBox_3);
		this.groupBox_7.Location = new Point(4, 38);
		this.groupBox_7.Name = "groupBoxSchmObj";
		this.groupBox_7.Size = new Size(415, 79);
		this.groupBox_7.TabIndex = 23;
		this.groupBox_7.TabStop = false;
		this.groupBox_7.Text = "Объект";
		this.comboBox_8.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_RelayProtectionAutomation.name", true));
		this.comboBox_8.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_8.FormattingEnabled = true;
		this.comboBox_8.Items.AddRange(new object[]
		{
			"1 уст.",
			"2 уст."
		});
		this.comboBox_8.Location = new Point(212, 48);
		this.comboBox_8.Name = "txtNote";
		this.comboBox_8.Size = new Size(194, 21);
		this.comboBox_8.TabIndex = 13;
		this.comboBox_8.KeyDown += this.comboBox_8_KeyDown;
		this.bindingSource_0.DataMember = "tJ_RelayProtectionAutomationValue";
		this.bindingSource_0.DataSource = this.class255_0;
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.DataBindings.Add(new Binding("Checked", this.class255_0, "tJ_RelayProtectionAutomationValue.lzsh", true));
		this.checkBox_0.Location = new Point(280, 399);
		this.checkBox_0.Name = "checkBoxLZSH";
		this.checkBox_0.Size = new Size(50, 17);
		this.checkBox_0.TabIndex = 24;
		this.checkBox_0.Text = "ЛЗШ";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_1.AutoSize = true;
		this.checkBox_1.DataBindings.Add(new Binding("Checked", this.class255_0, "tJ_RelayProtectionAutomationValue.avr", true));
		this.checkBox_1.Location = new Point(227, 399);
		this.checkBox_1.Name = "checkBoxAVR";
		this.checkBox_1.Size = new Size(47, 17);
		this.checkBox_1.TabIndex = 25;
		this.checkBox_1.Text = "АВР";
		this.checkBox_1.UseVisualStyleBackColor = true;
		this.checkBox_2.DataBindings.Add(new Binding("Checked", this.class255_0, "tJ_RelayProtectionAutomationValue.ArcProtection", true));
		this.checkBox_2.Location = new Point(336, 390);
		this.checkBox_2.Name = "chbArcProtection";
		this.checkBox_2.Size = new Size(83, 31);
		this.checkBox_2.TabIndex = 26;
		this.checkBox_2.Text = "Дуговая защита";
		this.checkBox_2.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(426, 577);
		base.Controls.Add(this.checkBox_2);
		base.Controls.Add(this.checkBox_1);
		base.Controls.Add(this.checkBox_0);
		base.Controls.Add(this.groupBox_7);
		base.Controls.Add(this.richTextBox_0);
		base.Controls.Add(this.label_19);
		base.Controls.Add(this.groupBox_6);
		base.Controls.Add(this.groupBox_5);
		base.Controls.Add(this.groupBox_4);
		base.Controls.Add(this.groupBox_3);
		base.Controls.Add(this.groupBox_2);
		base.Controls.Add(this.groupBox_1);
		base.Controls.Add(this.groupBox_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.dateTimePicker_0);
		base.Controls.Add(this.label_0);
		base.Name = "FormJRelayProtectionAutomationAddEdit";
		this.Text = "FormJRelayProtectionAutomationAddEdit";
		base.FormClosing += this.Form58_FormClosing;
		base.Load += this.Form58_Load;
		((ISupportInitialize)this.class255_0).EndInit();
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		this.groupBox_1.ResumeLayout(false);
		this.groupBox_1.PerformLayout();
		this.groupBox_2.ResumeLayout(false);
		this.groupBox_2.PerformLayout();
		this.groupBox_3.ResumeLayout(false);
		this.groupBox_3.PerformLayout();
		this.groupBox_4.ResumeLayout(false);
		this.groupBox_4.PerformLayout();
		this.groupBox_5.ResumeLayout(false);
		this.groupBox_6.ResumeLayout(false);
		this.groupBox_6.PerformLayout();
		this.groupBox_7.ResumeLayout(false);
		this.groupBox_7.PerformLayout();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	internal static void t6vIYP0QZwuMK0eMbphi(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private DataTable dataTable_0;

	private DataTable dataTable_1;

	private DataTable dataTable_2;

	private Class255 class255_0;

	private Label label_0;

	private DateTimePicker dateTimePicker_0;

	private Label label_1;

	private ComboBox comboBox_0;

	private Label label_2;

	private ComboBox comboBox_1;

	private Label label_3;

	private ComboBox comboBox_2;

	private Label label_4;

	private ComboBox comboBox_3;

	private Button button_0;

	private Button button_1;

	private GroupBox groupBox_0;

	private ComboBox comboBox_4;

	private Label label_5;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private Label label_6;

	private Label label_7;

	private GroupBox groupBox_1;

	private Label label_8;

	private TextBox textBox_2;

	private Label label_9;

	private TextBox textBox_3;

	private Label label_10;

	private TextBox textBox_4;

	private GroupBox groupBox_2;

	private TextBox textBox_5;

	private Label label_11;

	private TextBox textBox_6;

	private Label label_12;

	private GroupBox groupBox_3;

	private TextBox textBox_7;

	private Label label_13;

	private TextBox textBox_8;

	private Label label_14;

	private GroupBox groupBox_4;

	private TextBox textBox_9;

	private Label label_15;

	private TextBox textBox_10;

	private Label label_16;

	private GroupBox groupBox_5;

	private ComboBox comboBox_5;

	private ComboBox comboBox_6;

	private GroupBox groupBox_6;

	private TextBox textBox_11;

	private Label label_17;

	private TextBox textBox_12;

	private Label label_18;

	private Label label_19;

	private RichTextBox richTextBox_0;

	private GroupBox groupBox_7;

	private BindingSource bindingSource_0;

	private CheckBox checkBox_0;

	private ComboBox comboBox_7;

	private Label label_20;

	private CheckBox checkBox_1;

	private ComboBox comboBox_8;

	private CheckBox checkBox_2;
}
