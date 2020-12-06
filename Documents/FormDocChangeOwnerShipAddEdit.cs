using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr;
using ControlsLbr.DataGridViewExcelFilter;
using Documents.Forms.TechnologicalConnection;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

internal partial class FormDocChangeOwnerShipAddEdit : FormBase
{
	internal int? RcCjXgcuhc()
	{
		return this.nullable_0;
	}

	internal FormDocChangeOwnerShipAddEdit(int? nullable_5 = null)
	{
		
		
		this.method_12();
		this.nullable_0 = nullable_5;
	}

	private void Form17_Load(object sender, EventArgs e)
	{
		this.dateTimePicker_0.Value = DateTime.Now.Date;
		this.method_3();
		if (this.nullable_0 == null)
		{
			this.method_0();
			this.method_1();
		}
		else
		{
			base.SelectSqlData(this.class10_0, this.class10_0.tTC_Doc, true, "where id = " + this.nullable_0.ToString());
			if (this.class10_0.tTC_Doc.Rows.Count > 0)
			{
				this.method_4(Convert.ToInt32(this.nullable_0));
				base.SelectSqlData(this.class10_0.tTC_ChangeOwnership, true, "where id = " + this.nullable_0.ToString(), null, false, 0);
				if (this.class10_0.tTC_ChangeOwnership.Rows.Count == 0)
				{
					this.method_1();
				}
			}
			else
			{
				this.method_0();
				this.method_1();
			}
		}
		if (this.class10_0.tTC_ChangeOwnership.Rows[0]["isApply"] != DBNull.Value && Convert.ToBoolean(this.class10_0.tTC_ChangeOwnership.Rows[0]["isApply"]))
		{
			this.checkBox_0.Enabled = false;
		}
		this.bool_0 = false;
	}

	private void Form17_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult != DialogResult.OK)
		{
			if (!this.bool_0 || MessageBox.Show("Сохранить внесенные изменения", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				base.DialogResult = DialogResult.Cancel;
				return;
			}
		}
		if (!this.method_8())
		{
			base.DialogResult = DialogResult.None;
			e.Cancel = true;
			return;
		}
		if (this.checkBox_0.Enabled && this.checkBox_0.Checked && MessageBox.Show("Все документы и привязки от старого объекта перейдут к новому. Провести документ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
		{
			base.DialogResult = DialogResult.Cancel;
		}
		if (this.method_9())
		{
			base.DialogResult = DialogResult.OK;
			return;
		}
		base.DialogResult = DialogResult.None;
		e.Cancel = true;
	}

	private void method_0()
	{
		DataRow dataRow = this.class10_0.tTC_Doc.NewRow();
		dataRow["dateDoc"] = DateTime.Now.Date;
		dataRow["typeDoc"] = 1345;
		this.class10_0.tTC_Doc.Rows.Add(dataRow);
	}

	private void method_1()
	{
		DataRow dataRow = this.class10_0.tTC_ChangeOwnership.NewRow();
		dataRow["id"] = this.class10_0.tTC_Doc.Rows[0]["id"];
		dataRow["isApply"] = false;
		this.class10_0.tTC_ChangeOwnership.Rows.Add(dataRow);
	}

	private void method_2(ComboBox comboBox_2, int? nullable_5)
	{
		if (nullable_5 == null)
		{
			comboBox_2.Items.Clear();
			if (comboBox_2 == this.dYejQokfZM)
			{
				this.nullable_4 = null;
			}
			if (comboBox_2 == this.comboBox_1)
			{
				this.nullable_2 = null;
			}
		}
		Class10.Class11 @class = new Class10.Class11();
		base.SelectSqlData(@class, true, " where id = " + nullable_5.ToString(), null, false, 0);
		if (@class.Rows.Count > 0)
		{
			comboBox_2.SelectedValueChanged -= this.dYejQokfZM_SelectedValueChanged;
			int num = Convert.ToInt32(@class.Rows[0]["typeAbn"]);
			Class10.Class16 class2 = new Class10.Class16();
			DataColumn dataColumn = new DataColumn("AddressFL");
			dataColumn.Expression = "street + ', д. ' + houseall + isnull(', кв. ' + name, '')";
			class2.Columns.Add(dataColumn);
			dataColumn = new DataColumn("AddressUL");
			dataColumn.Expression = "street + ', д. ' + houseall";
			class2.Columns.Add(dataColumn);
			base.SelectSqlData(class2, true, "where idAbn = " + nullable_5.ToString() + " order by name", null, false, 0);
			comboBox_2.ValueMember = "id";
			comboBox_2.DataSource = class2;
			if (num != 206 && num != 253)
			{
				if (num != 1037)
				{
					comboBox_2.DisplayMember = "name";
					goto IL_172;
				}
			}
			comboBox_2.DisplayMember = "AddressFL";
			IL_172:
			if (comboBox_2 == this.dYejQokfZM)
			{
				comboBox_2.SelectedValue = this.nullable_4;
			}
			if (comboBox_2 == this.comboBox_1)
			{
				comboBox_2.SelectedValue = this.nullable_2;
			}
			if (comboBox_2.SelectedValue == null)
			{
				if (comboBox_2 == this.dYejQokfZM)
				{
					this.nullable_4 = null;
				}
				if (comboBox_2 == this.comboBox_1)
				{
					this.nullable_2 = null;
				}
			}
			comboBox_2.SelectedValueChanged += this.dYejQokfZM_SelectedValueChanged;
			return;
		}
		comboBox_2.Items.Clear();
		if (comboBox_2 == this.dYejQokfZM)
		{
			this.nullable_4 = null;
		}
		if (comboBox_2 == this.comboBox_1)
		{
			this.nullable_2 = null;
		}
	}

	private void method_3()
	{
		DataTable dataTable = new DataTable("tR_Classifier");
		dataTable.Columns.Add("id", typeof(int));
		dataTable.Columns.Add("name", typeof(string));
		base.SelectSqlData(dataTable, true, "where ParentKey = ';TechConnect;TypeDoc;Rebinding;TypeDocInRebinding;' and isGroup = 0 and deleted = 0 order by name", null, false, 0);
		this.comboBox_0.DisplayMember = "name";
		this.comboBox_0.ValueMember = "id";
		this.comboBox_0.DataSource = dataTable;
		this.comboBox_0.SelectedIndex = -1;
	}

	private void dYejQokfZM_SelectedValueChanged(object sender, EventArgs e)
	{
		ComboBox comboBox = (ComboBox)sender;
		if (comboBox.SelectedValue != null || comboBox.SelectedValue != DBNull.Value)
		{
			if (comboBox == this.dYejQokfZM)
			{
				this.nullable_4 = new int?(Convert.ToInt32(comboBox.SelectedValue));
			}
			if (comboBox == this.comboBox_1)
			{
				this.nullable_2 = new int?(Convert.ToInt32(comboBox.SelectedValue));
			}
			this.bool_0 = true;
		}
	}

	private void method_4(int int_0)
	{
		Class10.Class59 @class = new Class10.Class59();
		base.SelectSqlData(@class, true, " where id = " + int_0.ToString(), null, false, 0);
		if (@class.Rows.Count > 0)
		{
			if (@class.Rows[0]["idAbnOld"] != DBNull.Value)
			{
				this.nullable_1 = new int?(Convert.ToInt32(@class.Rows[0]["idAbnOld"]));
				Class10.Class11 class2 = new Class10.Class11();
				base.SelectSqlData(class2, true, "where id = " + this.nullable_1.ToString(), null, false, 0);
				if (class2.Rows.Count > 0)
				{
					this.textBox_2.Text = class2.Rows[0]["name"].ToString();
				}
			}
			if (@class.Rows[0]["idAbnObjOld"] != DBNull.Value)
			{
				this.nullable_2 = new int?(Convert.ToInt32(@class.Rows[0]["idAbnObjOld"]));
			}
			this.method_2(this.comboBox_1, this.nullable_1);
			if (@class.Rows[0]["idAbnNew"] != DBNull.Value)
			{
				this.nullable_3 = new int?(Convert.ToInt32(@class.Rows[0]["idAbnNew"]));
				Class10.Class11 class3 = new Class10.Class11();
				base.SelectSqlData(class3, true, "where id = " + this.nullable_3.ToString(), null, false, 0);
				if (class3.Rows.Count > 0)
				{
					this.textBox_3.Text = class3.Rows[0]["name"].ToString();
				}
			}
			if (@class.Rows[0]["idAbnObjNew"] != DBNull.Value)
			{
				this.nullable_4 = new int?(Convert.ToInt32(@class.Rows[0]["idAbnObjNEw"]));
			}
			this.method_2(this.dYejQokfZM, this.nullable_3);
		}
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		FormTechConnectionAddAbn formTechConnectionAddAbn = new FormTechConnectionAddAbn((this.nullable_1 == null) ? -1 : Convert.ToInt32(this.nullable_1), (this.nullable_2 == null) ? -1 : Convert.ToInt32(this.nullable_2), true);
		formTechConnectionAddAbn.ShowForm += this.method_5;
		formTechConnectionAddAbn.SqlSettings = this.SqlSettings;
		formTechConnectionAddAbn.MdiParent = base.MdiParent;
		formTechConnectionAddAbn.FormClosed += this.method_6;
		formTechConnectionAddAbn.Show();
	}

	private FormBase method_5(object object_0, ShowFormEventArgs showFormEventArgs_0)
	{
		return this.OnShowForm(showFormEventArgs_0);
	}

	private void method_6(object sender, FormClosedEventArgs e)
	{
		FormTechConnectionAddAbn formTechConnectionAddAbn = (FormTechConnectionAddAbn)sender;
		if (formTechConnectionAddAbn.DialogResult == DialogResult.OK)
		{
			this.textBox_2.Text = formTechConnectionAddAbn.AbnName;
			this.nullable_1 = new int?(formTechConnectionAddAbn.IdAbn);
			this.nullable_2 = new int?(formTechConnectionAddAbn.GetIdAbnObj());
			this.method_2(this.comboBox_1, this.nullable_1);
			this.bool_0 = true;
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		FormTechConnectionAddAbn formTechConnectionAddAbn = new FormTechConnectionAddAbn((this.nullable_3 == null) ? -1 : Convert.ToInt32(this.nullable_3), (this.nullable_4 == null) ? -1 : Convert.ToInt32(this.nullable_4), true);
		formTechConnectionAddAbn.ShowForm += this.method_5;
		formTechConnectionAddAbn.SqlSettings = this.SqlSettings;
		formTechConnectionAddAbn.MdiParent = base.MdiParent;
		formTechConnectionAddAbn.FormClosed += this.method_7;
		formTechConnectionAddAbn.Show();
	}

	private void method_7(object sender, FormClosedEventArgs e)
	{
		FormTechConnectionAddAbn formTechConnectionAddAbn = (FormTechConnectionAddAbn)sender;
		if (formTechConnectionAddAbn.DialogResult == DialogResult.OK)
		{
			this.textBox_3.Text = formTechConnectionAddAbn.AbnName;
			this.nullable_3 = new int?(formTechConnectionAddAbn.IdAbn);
			this.nullable_4 = new int?(formTechConnectionAddAbn.GetIdAbnObj());
			this.method_2(this.dYejQokfZM, this.nullable_3);
			this.bool_0 = true;
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private bool method_8()
	{
		if (this.nullable_1 == null)
		{
			MessageBox.Show("Не выбран старый абонент");
			return false;
		}
		if (this.nullable_2 == null)
		{
			MessageBox.Show("Не выбран старый объект абонента");
			return false;
		}
		if (this.nullable_3 == null)
		{
			MessageBox.Show("Не выбран новый абонент");
			return false;
		}
		if (this.nullable_3 == null)
		{
			MessageBox.Show("Не выбран новый объект абонента");
			return false;
		}
		return true;
	}

	private bool method_9()
	{
		return this.method_10() && this.method_11();
	}

	private bool method_10()
	{
		this.class10_0.tTC_Doc.Rows[0].EndEdit();
		if (this.nullable_0 == null)
		{
			this.nullable_0 = new int?(base.InsertSqlDataOneRow(this.class10_0, this.class10_0.tTC_Doc));
			if (this.nullable_0 == -1)
			{
				return false;
			}
		}
		else if (!base.UpdateSqlData(this.class10_0.tTC_Doc))
		{
			return false;
		}
		return true;
	}

	private bool method_11()
	{
		this.class10_0.tTC_ChangeOwnership.Rows[0]["id"] = this.nullable_0;
		this.class10_0.tTC_ChangeOwnership.Rows[0]["idAbnOld"] = this.nullable_1;
		this.class10_0.tTC_ChangeOwnership.Rows[0]["idAbnObjOld"] = this.nullable_2;
		this.class10_0.tTC_ChangeOwnership.Rows[0]["idAbnNew"] = this.nullable_3;
		this.class10_0.tTC_ChangeOwnership.Rows[0]["idAbnObjNew"] = this.nullable_4;
		this.class10_0.tTC_ChangeOwnership.Rows[0].EndEdit();
		return base.InsertSqlData(this.class10_0.tTC_ChangeOwnership) && base.UpdateSqlData(this.class10_0.tTC_ChangeOwnership);
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		if (this.checkBox_0.Checked)
		{
			this.groupBox_2.Enabled = false;
			this.groupBox_1.Enabled = false;
		}
		else
		{
			this.groupBox_1.Enabled = true;
			this.groupBox_2.Enabled = true;
		}
		this.bool_0 = true;
	}

	private void nullableDateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void comboBox_0_SelectedValueChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void richTextBox_0_TextChanged(object sender, EventArgs e)
	{
		this.bool_0 = true;
	}

	private void method_12()
	{
		this.icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.class10_0 = new Class10();
		this.label_1 = new Label();
		this.dateTimePicker_0 = new DateTimePicker();
		this.groupBox_0 = new GroupBox();
		this.comboBox_0 = new ComboBox();
		this.label_2 = new Label();
		this.nullableDateTimePicker_0 = new NullableDateTimePicker();
		this.label_3 = new Label();
		this.textBox_1 = new TextBox();
		this.label_4 = new Label();
		this.comboBox_1 = new ComboBox();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.label_5 = new Label();
		this.textBox_2 = new TextBox();
		this.label_6 = new Label();
		this.groupBox_1 = new GroupBox();
		this.groupBox_2 = new GroupBox();
		this.label_7 = new Label();
		this.dYejQokfZM = new ComboBox();
		this.textBox_3 = new TextBox();
		this.GpejzaIutZ = new ToolStrip();
		this.toolStripButton_1 = new ToolStripButton();
		this.label_8 = new Label();
		this.tabControl_0 = new TabControl();
		this.tabPage_0 = new TabPage();
		this.checkBox_0 = new CheckBox();
		this.richTextBox_0 = new RichTextBox();
		this.label_9 = new Label();
		this.tabPage_1 = new TabPage();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.toolStrip_1 = new ToolStrip();
		this.toolStripDropDownButton_0 = new ToolStripDropDownButton();
		this.toolStripMenuItem_0 = new ToolStripMenuItem();
		this.toolStripSeparator_0 = new ToolStripSeparator();
		this.toolStripButton_2 = new ToolStripButton();
		this.toolStripButton_3 = new ToolStripButton();
		this.toolStripButton_4 = new ToolStripButton();
		this.toolStripSeparator_1 = new ToolStripSeparator();
		this.toolStripButton_5 = new ToolStripButton();
		this.toolStripButton_6 = new ToolStripButton();
		this.button_0 = new Button();
		this.button_1 = new Button();
		((ISupportInitialize)this.class10_0).BeginInit();
		this.groupBox_0.SuspendLayout();
		this.toolStrip_0.SuspendLayout();
		this.groupBox_1.SuspendLayout();
		this.groupBox_2.SuspendLayout();
		this.GpejzaIutZ.SuspendLayout();
		this.tabControl_0.SuspendLayout();
		this.tabPage_0.SuspendLayout();
		this.tabPage_1.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		this.toolStrip_1.SuspendLayout();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(6, 7);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(75, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "№ документа";
		this.textBox_0.BackColor = SystemColors.Window;
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Doc.numDoc", true));
		this.textBox_0.Location = new Point(87, 4);
		this.textBox_0.Name = "txtDocNum";
		this.textBox_0.ReadOnly = true;
		this.textBox_0.Size = new Size(82, 20);
		this.textBox_0.TabIndex = 1;
		this.class10_0.DataSetName = "DataSetTechConnection";
		this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(175, 7);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(90, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Дата документа";
		this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_Doc.dateDoc", true));
		this.dateTimePicker_0.Location = new Point(271, 4);
		this.dateTimePicker_0.Name = "dtpDateDoc";
		this.dateTimePicker_0.Size = new Size(146, 20);
		this.dateTimePicker_0.TabIndex = 3;
		this.dateTimePicker_0.ValueChanged += this.nullableDateTimePicker_0_ValueChanged;
		this.groupBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_0.Controls.Add(this.comboBox_0);
		this.groupBox_0.Controls.Add(this.label_2);
		this.groupBox_0.Controls.Add(this.nullableDateTimePicker_0);
		this.groupBox_0.Controls.Add(this.label_3);
		this.groupBox_0.Controls.Add(this.textBox_1);
		this.groupBox_0.Controls.Add(this.label_4);
		this.groupBox_0.Location = new Point(6, 34);
		this.groupBox_0.Name = "groupBoxDocIn";
		this.groupBox_0.Size = new Size(530, 56);
		this.groupBox_0.TabIndex = 4;
		this.groupBox_0.TabStop = false;
		this.groupBox_0.Text = "Регламентирующий документ";
		this.comboBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_ChangeOwnership.TypeDocIn", true));
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(172, 23);
		this.comboBox_0.Name = "cmbTypeDocIn";
		this.comboBox_0.Size = new Size(192, 21);
		this.comboBox_0.TabIndex = 5;
		this.comboBox_0.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(178, 7);
		this.label_2.Name = "label5";
		this.label_2.Size = new Size(83, 13);
		this.label_2.TabIndex = 4;
		this.label_2.Text = "Тип документа";
		this.nullableDateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.nullableDateTimePicker_0.CustomFormat = "dd.MM.yyyy";
		this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_ChangeOwnership.dateDocIn", true));
		this.nullableDateTimePicker_0.Format = DateTimePickerFormat.Custom;
		this.nullableDateTimePicker_0.Location = new Point(409, 21);
		this.nullableDateTimePicker_0.Name = "dtpDateDocIn";
		this.nullableDateTimePicker_0.Size = new Size(115, 20);
		this.nullableDateTimePicker_0.TabIndex = 3;
		this.nullableDateTimePicker_0.Value = new DateTime(2013, 4, 15, 13, 28, 53, 804);
		this.nullableDateTimePicker_0.ValueChanged += this.nullableDateTimePicker_0_ValueChanged;
		this.label_3.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(370, 26);
		this.label_3.Name = "label3";
		this.label_3.Size = new Size(33, 13);
		this.label_3.TabIndex = 2;
		this.label_3.Text = "Дата";
		this.textBox_1.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_ChangeOwnership.numDocIn", true));
		this.textBox_1.Location = new Point(57, 24);
		this.textBox_1.Name = "txtNumDocIn";
		this.textBox_1.Size = new Size(106, 20);
		this.textBox_1.TabIndex = 1;
		this.textBox_1.TextChanged += this.richTextBox_0_TextChanged;
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(10, 27);
		this.label_4.Name = "label4";
		this.label_4.Size = new Size(41, 13);
		this.label_4.TabIndex = 0;
		this.label_4.Text = "Номер";
		this.comboBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBox_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_1.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(13, 70);
		this.comboBox_1.Name = "cmbAbnObjOld";
		this.comboBox_1.Size = new Size(512, 21);
		this.comboBox_1.TabIndex = 12;
		this.comboBox_1.SelectedValueChanged += this.dYejQokfZM_SelectedValueChanged;
		this.toolStrip_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.toolStrip_0.Dock = DockStyle.None;
		this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0
		});
		this.toolStrip_0.Location = new Point(504, 49);
		this.toolStrip_0.Name = "toolStripAbnOld";
		this.toolStrip_0.Size = new Size(26, 25);
		this.toolStrip_0.TabIndex = 14;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources.partners;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtnAbnOld";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Выбрать контрагента";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(13, 55);
		this.label_5.Name = "label6";
		this.label_5.Size = new Size(45, 13);
		this.label_5.TabIndex = 11;
		this.label_5.Text = "Объект";
		this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_2.BackColor = SystemColors.Window;
		this.textBox_2.Location = new Point(13, 32);
		this.textBox_2.Name = "txtAbnOld";
		this.textBox_2.ReadOnly = true;
		this.textBox_2.Size = new Size(512, 20);
		this.textBox_2.TabIndex = 10;
		this.label_6.AutoSize = true;
		this.label_6.Location = new Point(10, 16);
		this.label_6.Name = "label7";
		this.label_6.Size = new Size(49, 13);
		this.label_6.TabIndex = 9;
		this.label_6.Text = "Абонент";
		this.groupBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_1.Controls.Add(this.label_6);
		this.groupBox_1.Controls.Add(this.comboBox_1);
		this.groupBox_1.Controls.Add(this.textBox_2);
		this.groupBox_1.Controls.Add(this.toolStrip_0);
		this.groupBox_1.Controls.Add(this.label_5);
		this.groupBox_1.Location = new Point(6, 84);
		this.groupBox_1.Name = "groupBoxAbnOld";
		this.groupBox_1.Size = new Size(531, 100);
		this.groupBox_1.TabIndex = 15;
		this.groupBox_1.TabStop = false;
		this.groupBox_1.Text = "Старый собственник";
		this.groupBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_2.Controls.Add(this.label_7);
		this.groupBox_2.Controls.Add(this.dYejQokfZM);
		this.groupBox_2.Controls.Add(this.textBox_3);
		this.groupBox_2.Controls.Add(this.GpejzaIutZ);
		this.groupBox_2.Controls.Add(this.label_8);
		this.groupBox_2.Location = new Point(6, 181);
		this.groupBox_2.Name = "groupBoxAbnNew";
		this.groupBox_2.Size = new Size(531, 100);
		this.groupBox_2.TabIndex = 16;
		this.groupBox_2.TabStop = false;
		this.groupBox_2.Text = "Новый собственник";
		this.label_7.AutoSize = true;
		this.label_7.Location = new Point(10, 16);
		this.label_7.Name = "label8";
		this.label_7.Size = new Size(49, 13);
		this.label_7.TabIndex = 9;
		this.label_7.Text = "Абонент";
		this.dYejQokfZM.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.dYejQokfZM.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.dYejQokfZM.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.dYejQokfZM.FormattingEnabled = true;
		this.dYejQokfZM.Location = new Point(13, 70);
		this.dYejQokfZM.Name = "cmbAbnObjNew";
		this.dYejQokfZM.Size = new Size(512, 21);
		this.dYejQokfZM.TabIndex = 12;
		this.dYejQokfZM.SelectedValueChanged += this.dYejQokfZM_SelectedValueChanged;
		this.textBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_3.BackColor = SystemColors.Window;
		this.textBox_3.Location = new Point(13, 32);
		this.textBox_3.Name = "txtAbnNew";
		this.textBox_3.ReadOnly = true;
		this.textBox_3.Size = new Size(512, 20);
		this.textBox_3.TabIndex = 10;
		this.GpejzaIutZ.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.GpejzaIutZ.Dock = DockStyle.None;
		this.GpejzaIutZ.GripStyle = ToolStripGripStyle.Hidden;
		this.GpejzaIutZ.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_1
		});
		this.GpejzaIutZ.Location = new Point(504, 49);
		this.GpejzaIutZ.Name = "toolStripAbnNew";
		this.GpejzaIutZ.Size = new Size(26, 25);
		this.GpejzaIutZ.TabIndex = 14;
		this.GpejzaIutZ.Text = "toolStrip1";
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = Resources.partners;
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "toolStripButton1";
		this.toolStripButton_1.Size = new Size(23, 22);
		this.toolStripButton_1.Text = "Выбрать контрагента";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.label_8.AutoSize = true;
		this.label_8.Location = new Point(13, 55);
		this.label_8.Name = "label9";
		this.label_8.Size = new Size(45, 13);
		this.label_8.TabIndex = 11;
		this.label_8.Text = "Объект";
		this.tabControl_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.tabControl_0.Controls.Add(this.tabPage_0);
		this.tabControl_0.Controls.Add(this.tabPage_1);
		this.tabControl_0.Location = new Point(0, 0);
		this.tabControl_0.Name = "tabControl";
		this.tabControl_0.SelectedIndex = 0;
		this.tabControl_0.Size = new Size(552, 438);
		this.tabControl_0.TabIndex = 17;
		this.tabPage_0.Controls.Add(this.checkBox_0);
		this.tabPage_0.Controls.Add(this.richTextBox_0);
		this.tabPage_0.Controls.Add(this.label_9);
		this.tabPage_0.Controls.Add(this.label_0);
		this.tabPage_0.Controls.Add(this.groupBox_2);
		this.tabPage_0.Controls.Add(this.textBox_0);
		this.tabPage_0.Controls.Add(this.groupBox_1);
		this.tabPage_0.Controls.Add(this.label_1);
		this.tabPage_0.Controls.Add(this.groupBox_0);
		this.tabPage_0.Controls.Add(this.dateTimePicker_0);
		this.tabPage_0.Location = new Point(4, 22);
		this.tabPage_0.Name = "tabPageGeneral";
		this.tabPage_0.Padding = new Padding(3);
		this.tabPage_0.Size = new Size(544, 412);
		this.tabPage_0.TabIndex = 0;
		this.tabPage_0.Text = "Общие";
		this.tabPage_0.UseVisualStyleBackColor = true;
		this.checkBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.DataBindings.Add(new Binding("Checked", this.class10_0, "tTC_ChangeOwnership.isApply", true));
		this.checkBox_0.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
		this.checkBox_0.Location = new Point(19, 385);
		this.checkBox_0.Name = "checkBoxApply";
		this.checkBox_0.Size = new Size(103, 17);
		this.checkBox_0.TabIndex = 19;
		this.checkBox_0.Text = "Согласовано";
		this.checkBox_0.TextAlign = ContentAlignment.MiddleCenter;
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
		this.richTextBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBox_0.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Doc.Comment", true));
		this.richTextBox_0.Location = new Point(6, 302);
		this.richTextBox_0.Name = "txtComment";
		this.richTextBox_0.Size = new Size(530, 77);
		this.richTextBox_0.TabIndex = 18;
		this.richTextBox_0.Text = "";
		this.richTextBox_0.TextChanged += this.richTextBox_0_TextChanged;
		this.label_9.AutoSize = true;
		this.label_9.Location = new Point(16, 286);
		this.label_9.Name = "label10";
		this.label_9.Size = new Size(77, 13);
		this.label_9.TabIndex = 17;
		this.label_9.Text = "Комментарий";
		this.tabPage_1.Controls.Add(this.dataGridViewExcelFilter_0);
		this.tabPage_1.Controls.Add(this.toolStrip_1);
		this.tabPage_1.Location = new Point(4, 22);
		this.tabPage_1.Name = "tabPageFile";
		this.tabPage_1.Padding = new Padding(3);
		this.tabPage_1.Size = new Size(544, 412);
		this.tabPage_1.TabIndex = 1;
		this.tabPage_1.Text = "Файлы";
		this.tabPage_1.UseVisualStyleBackColor = true;
		this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToResizeColumns = false;
		this.dataGridViewExcelFilter_0.AllowUserToResizeRows = false;
		this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewFilterTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewTextBoxColumn_3,
			this.dataGridViewImageColumnNotNull_0
		});
		this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
		this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_0.EditMode = DataGridViewEditMode.EditProgrammatically;
		this.dataGridViewExcelFilter_0.Location = new Point(3, 28);
		this.dataGridViewExcelFilter_0.Name = "dgvFile";
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.RowHeadersVisible = false;
		this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_0.Size = new Size(538, 381);
		this.dataGridViewExcelFilter_0.TabIndex = 7;
		this.dataGridViewExcelFilter_0.VirtualMode = true;
		this.dataGridViewFilterTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "FileName";
		this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Файл";
		this.dataGridViewFilterTextBoxColumn_0.Name = "fileNameDgvColumn";
		this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_0.HeaderText = "id";
		this.dataGridViewTextBoxColumn_0.Name = "idFileDgvColumn";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "idDoc";
		this.dataGridViewTextBoxColumn_1.HeaderText = "idDoc";
		this.dataGridViewTextBoxColumn_1.Name = "idDocDgvColumn";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.Visible = false;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "dateChange";
		this.dataGridViewTextBoxColumn_2.HeaderText = "dateChange";
		this.dataGridViewTextBoxColumn_2.Name = "dateChangeDgvColumn";
		this.dataGridViewTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewTextBoxColumn_2.Visible = false;
		this.dataGridViewTextBoxColumn_3.DataPropertyName = "idTemplate";
		this.dataGridViewTextBoxColumn_3.HeaderText = "idTemplate";
		this.dataGridViewTextBoxColumn_3.Name = "idTemplateDgvColumn";
		this.dataGridViewTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewTextBoxColumn_3.Visible = false;
		dataGridViewCellStyle.NullValue = null;
		this.dataGridViewImageColumnNotNull_0.DefaultCellStyle = dataGridViewCellStyle;
		this.dataGridViewImageColumnNotNull_0.HeaderText = "";
		this.dataGridViewImageColumnNotNull_0.ImageLayout = DataGridViewImageCellLayout.Zoom;
		this.dataGridViewImageColumnNotNull_0.Name = "imageDgvColumn";
		this.dataGridViewImageColumnNotNull_0.ReadOnly = true;
		this.dataGridViewImageColumnNotNull_0.Width = 30;
		this.bindingSource_0.DataMember = "tTC_DocFile";
		this.bindingSource_0.DataSource = this.class10_0;
		this.toolStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripDropDownButton_0,
			this.toolStripButton_2,
			this.toolStripButton_3,
			this.toolStripButton_4,
			this.toolStripSeparator_1,
			this.toolStripButton_5,
			this.toolStripButton_6
		});
		this.toolStrip_1.Location = new Point(3, 3);
		this.toolStrip_1.Name = "toolStripFile";
		this.toolStrip_1.Size = new Size(538, 25);
		this.toolStrip_1.TabIndex = 1;
		this.toolStrip_1.Text = "toolStrip1";
		this.toolStripDropDownButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripDropDownButton_0.DropDownItems.AddRange(new ToolStripItem[]
		{
			this.toolStripMenuItem_0,
			this.toolStripSeparator_0
		});
		this.toolStripDropDownButton_0.Image = Resources.ElementAdd;
		this.toolStripDropDownButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripDropDownButton_0.Name = "toolBtnAddFile";
		this.toolStripDropDownButton_0.Size = new Size(29, 22);
		this.toolStripDropDownButton_0.Text = "Добавить файл";
		this.toolStripMenuItem_0.Name = "toolItemAddExistFile";
		this.toolStripMenuItem_0.Size = new Size(190, 22);
		this.toolStripMenuItem_0.Text = "Сущесвующий файл";
		this.toolStripSeparator_0.Name = "toolStripSeparator2";
		this.toolStripSeparator_0.Size = new Size(187, 6);
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Image = Resources.ElementEdit;
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "toolBtnEditFile";
		this.toolStripButton_2.Size = new Size(23, 22);
		this.toolStripButton_2.Text = "Редактировать файл";
		this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_3.Image = Resources.ElementInformation;
		this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_3.Name = "toolBtnOpenFile";
		this.toolStripButton_3.Size = new Size(23, 22);
		this.toolStripButton_3.Text = "Открыть файл";
		this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_4.Image = Resources.ElementDel;
		this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_4.Name = "toolBtnDelFile";
		this.toolStripButton_4.Size = new Size(23, 22);
		this.toolStripButton_4.Text = "Удалить файл";
		this.toolStripSeparator_1.Name = "toolStripSeparator3";
		this.toolStripSeparator_1.Size = new Size(6, 25);
		this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_5.Image = Resources.rename;
		this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_5.Name = "toolBtnRenameFile";
		this.toolStripButton_5.Size = new Size(23, 22);
		this.toolStripButton_5.Text = "Переименовать";
		this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_6.Image = Resources.save;
		this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_6.Name = "toolBtnSaveFile";
		this.toolStripButton_6.Size = new Size(23, 22);
		this.toolStripButton_6.Text = "Сохранить файл на диск";
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Location = new Point(466, 444);
		this.button_0.Name = "buttonClose";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 18;
		this.button_0.Text = "Закрыть";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.OK;
		this.button_1.Location = new Point(328, 444);
		this.button_1.Name = "buttonSaveAndClose";
		this.button_1.Size = new Size(132, 23);
		this.button_1.TabIndex = 19;
		this.button_1.Text = "Сохранить и закрыть";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(550, 473);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.tabControl_0);
		base.Name = "FormDocChangeOwnerShipAddEdit";
		this.Text = "Смена собственника";
		base.FormClosing += this.Form17_FormClosing;
		base.Load += this.Form17_Load;
		((ISupportInitialize)this.class10_0).EndInit();
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		this.groupBox_1.ResumeLayout(false);
		this.groupBox_1.PerformLayout();
		this.groupBox_2.ResumeLayout(false);
		this.groupBox_2.PerformLayout();
		this.GpejzaIutZ.ResumeLayout(false);
		this.GpejzaIutZ.PerformLayout();
		this.tabControl_0.ResumeLayout(false);
		this.tabPage_0.ResumeLayout(false);
		this.tabPage_0.PerformLayout();
		this.tabPage_1.ResumeLayout(false);
		this.tabPage_1.PerformLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		this.toolStrip_1.ResumeLayout(false);
		this.toolStrip_1.PerformLayout();
		base.ResumeLayout(false);
	}

	internal static void yHkeu8N1TC9cnJIUO2q(Form form_0, bool bool_1)
	{
		form_0.Dispose(bool_1);
	}

	private int? nullable_0;

	private int? nullable_1;

	private int? nullable_2;

	private int? nullable_3;

	private int? nullable_4;

	private bool bool_0;

	private Label label_0;

	private TextBox textBox_0;

	private Label label_1;

	private DateTimePicker dateTimePicker_0;

	private GroupBox groupBox_0;

	private ComboBox comboBox_0;

	private Label label_2;

	private NullableDateTimePicker nullableDateTimePicker_0;

	private Label label_3;

	private TextBox textBox_1;

	private Label label_4;

	private ComboBox comboBox_1;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private Label label_5;

	private TextBox textBox_2;

	private Label label_6;

	private GroupBox groupBox_1;

	private GroupBox groupBox_2;

	private Label label_7;

	private ComboBox dYejQokfZM;

	private TextBox textBox_3;

	private ToolStrip GpejzaIutZ;

	private ToolStripButton toolStripButton_1;

	private Label label_8;

	private TabControl tabControl_0;

	private TabPage tabPage_0;

	private CheckBox checkBox_0;

	private RichTextBox richTextBox_0;

	private Label label_9;

	private TabPage tabPage_1;

	private Button button_0;

	private Button button_1;

	private ToolStrip toolStrip_1;

	private ToolStripDropDownButton toolStripDropDownButton_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private ToolStripButton toolStripButton_4;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripButton toolStripButton_5;

	private ToolStripButton toolStripButton_6;

	private Class10 class10_0;

	private BindingSource bindingSource_0;

	private DataGridViewExcelFilter dataGridViewExcelFilter_0;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;
}
