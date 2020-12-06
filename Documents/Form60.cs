using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr;
using Documents.Properties;
using FormLbr;

internal partial class Form60 : FormBase
{
	internal Form60()
	{
		
		this.int_0 = -1;
		this.dictionary_0 = new Dictionary<string, string>();
		
		this.method_3();
		this.method_0();
	}

	internal Form60(int int_1)
	{
		
		this.int_0 = -1;
		this.dictionary_0 = new Dictionary<string, string>();
		
		this.method_3();
		this.int_0 = int_1;
		this.method_0();
	}

	private void method_0()
	{
		this.Text = ((this.int_0 == -1) ? "Новая раскопка" : "Редактирование раскопки");
		this.nullableDateTimePicker_0.Value = (this.nullableDateTimePicker_1.Value = DateTime.Now.Date);
		this.class141_0 = new DataSetExcavation.Class141();
		this.comboBox_2.DataBindings.Add(new Binding("SelectedValue", this.class141_0, "idStatus", true));
		this.dictionary_0.Add("7325", "Ленинский");
		this.dictionary_0.Add("7328", "Заволжский");
		this.dictionary_0.Add("7327", "Засвияжский");
		this.dictionary_0.Add("7326", "Железнодорожный");
	}

	private void method_1()
	{
		DataTable dataTable = base.SelectSqlData("tr_classifier", true, " where ParentKey = ';Excavation;TypeWork;' and isGRoup = 0 and deleted = 0 order by name");
		this.comboBox_1.DataSource = dataTable;
		this.comboBox_1.DisplayMember = "Name";
		this.comboBox_1.ValueMember = "Id";
		this.comboBox_1.SelectedIndex = -1;
		this.method_2();
		this.comboBox_0.SelectedIndex = -1;
		if (this.int_0 == -1)
		{
			dataTable = base.SelectSqlData("tr_classifier", true, " where ParentKey = ';Excavation;StatusOrder;' and isGRoup = 0 and value <> 4 and deleted = 0 order by name");
		}
		else
		{
			dataTable = base.SelectSqlData("tr_classifier", true, " where ParentKey = ';Excavation;StatusOrder;' and isGRoup = 0 and deleted = 0 order by name");
		}
		this.comboBox_2.DataSource = dataTable;
		this.comboBox_2.DisplayMember = "Name";
		this.comboBox_2.ValueMember = "Id";
		if (dataTable.Rows.Count > 0 && dataTable.Select("Value = 1").Length != 0)
		{
			this.comboBox_2.SelectedValue = dataTable.Select("Value = 1")[0]["id"];
		}
		else
		{
			this.comboBox_2.SelectedIndex = -1;
		}
		dataTable = base.SelectSqlData("tR_Classifier", true, " where ParentKey = ';CityRaion;UlyanovskRaion;' and isGRoup = 0 and deleted = 0 order by name");
		this.comboBox_3.DataSource = dataTable;
		this.comboBox_3.DisplayMember = "Name";
		this.comboBox_3.ValueMember = "id";
		this.comboBox_3.SelectedIndex = -1;
		dataTable = new DataTable("tSChm_ObjList");
		dataTable.Columns.Add("id", typeof(int));
		dataTable.Columns.Add("name", typeof(string));
		base.SelectSqlData(dataTable, true, " where typeCodeid = 546 and deleted = 0 order by name", null, false, 0);
		this.comboBox_4.DataSource = dataTable;
		this.comboBox_4.DisplayMember = "name";
		this.comboBox_4.ValueMember = "id";
		this.comboBox_4.SelectedIndex = -1;
		dataTable = new DataTable("vWorkerGroup");
		dataTable.Columns.Add("id", typeof(int));
		dataTable.Columns.Add("fio", typeof(string));
		base.SelectSqlData(dataTable, true, " where ParentKey in (';GroupWorker;ReconcileExcavation;') and dateEnd is null order by fio ", null, false, 0);
		this.comboBox_5.DataSource = dataTable;
		this.comboBox_5.DisplayMember = "fio";
		this.comboBox_5.ValueMember = "id";
		this.comboBox_5.SelectedIndex = -1;
	}

	private void method_2()
	{
		DataTable dataSource = base.SelectSqlData("vAbnType", true, " where typeKontragent = " + 1046.ToString() + " and deleted = 0 order by name ");
		this.comboBox_0.DataSource = dataSource;
		this.comboBox_0.DisplayMember = "Name";
		this.comboBox_0.ValueMember = "idAbn";
	}

	private void Form60_Load(object sender, EventArgs e)
	{
		this.kladrStreetControl_0.SqlSettings = this.SqlSettings;
		this.method_1();
		if (this.int_0 == -1)
		{
			DataRow dataRow = this.class130_0.tJ_Excavation.NewRow();
			dataRow["num"] = -1;
			dataRow["DateBeg"] = DateTime.Now.Date;
			this.class130_0.tJ_Excavation.Rows.Add(dataRow);
			dataRow = this.class141_0.NewRow();
			dataRow["idExcavation"] = this.int_0;
			dataRow["idType"] = 1;
			dataRow["idStatus"] = this.comboBox_2.SelectedValue;
			dataRow["dateChange"] = this.dateTimePicker_0.Value;
			this.class141_0.Rows.Add(dataRow);
			dataRow = this.class130_0.tJ_ExcavationAddress.NewRow();
			dataRow["idExcavation"] = this.int_0;
			this.class130_0.tJ_ExcavationAddress.Rows.Add(dataRow);
			dataRow = this.class130_0.tJ_ExcavationSchmObj.NewRow();
			dataRow["idExcavation"] = this.int_0;
			this.class130_0.tJ_ExcavationSchmObj.Rows.Add(dataRow);
			return;
		}
		base.SelectSqlData(this.class130_0, this.class130_0.tJ_Excavation, true, "where id = " + this.int_0.ToString());
		base.SelectSqlData(this.class141_0, true, "where idExcavation = " + this.int_0.ToString() + " and idType = 1 order by datechange desc ", null, false, 0);
		this.comboBox_2.Enabled = false;
		base.SelectSqlData(this.class130_0, this.class130_0.tJ_ExcavationAddress, true, " where idExcavation = " + this.int_0.ToString());
		if (this.class130_0.tJ_ExcavationAddress.Rows.Count == 0)
		{
			DataRow dataRow2 = this.class130_0.tJ_ExcavationAddress.NewRow();
			dataRow2["idExcavation"] = this.int_0;
			this.class130_0.tJ_ExcavationAddress.Rows.Add(dataRow2);
		}
		else
		{
			this.kladrStreetControl_0.CmbStreet.SelectedValue = this.class130_0.tJ_ExcavationAddress.Rows[0]["idStreet"];
			if (this.class130_0.tJ_ExcavationAddress.Rows.Count > 1)
			{
				this.groupBox_2.Enabled = false;
			}
			else
			{
				this.class130_0.tJ_ExcavationAddress.Rows[0].BeginEdit();
			}
		}
		base.SelectSqlData(this.class130_0, this.class130_0.tJ_ExcavationSchmObj, true, " where idExcavation = " + this.int_0.ToString());
		if (this.class130_0.tJ_ExcavationAddress.Rows.Count == 0)
		{
			DataRow dataRow3 = this.class130_0.tJ_ExcavationSchmObj.NewRow();
			dataRow3["idExcavation"] = this.int_0;
			this.class130_0.tJ_ExcavationSchmObj.Rows.Add(dataRow3);
			return;
		}
		if (this.class130_0.tJ_ExcavationSchmObj.Rows[0]["idKL"] != DBNull.Value)
		{
			this.comboBox_4.SelectedValue = this.class130_0.tJ_ExcavationSchmObj.Rows[0]["idKL"];
		}
		else
		{
			this.comboBox_4.Text = this.class130_0.tJ_ExcavationSchmObj.Rows[0]["nameKL"].ToString();
		}
		if (this.class130_0.tJ_ExcavationSchmObj.Rows.Count > 1)
		{
			this.groupBox_3.Enabled = false;
			return;
		}
		this.class130_0.tJ_ExcavationSchmObj.Rows[0].BeginEdit();
	}

	private void Form60_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.kladrStreetControl_0.CmbStreet.SelectedIndex < 0)
			{
				MessageBox.Show("Не указан адрес раскопки");
				e.Cancel = true;
				return;
			}
			if (string.IsNullOrEmpty(this.comboBox_4.Text) && this.comboBox_4.SelectedValue == null)
			{
				MessageBox.Show("Не указана кабельная линия");
				e.Cancel = true;
				return;
			}
			if (this.checkBox_0.Checked)
			{
				if (this.nullableDateTimePicker_7.Value != null)
				{
					if (this.nullableDateTimePicker_7.Value != DBNull.Value)
					{
						if (this.comboBox_5.SelectedIndex < 0 && this.comboBox_5.Items.Count > 0)
						{
							MessageBox.Show("Не указан согласующий");
							e.Cancel = true;
							return;
						}
						goto IL_D9;
					}
				}
				MessageBox.Show("Не указана дата согласования");
				e.Cancel = true;
				return;
			}
			IL_D9:
			if (this.int_0 == -1)
			{
				this.class130_0.tJ_Excavation.Rows[0].EndEdit();
				this.int_0 = base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_Excavation);
				this.class141_0.Rows[0]["idExcavation"] = this.int_0;
				this.class141_0.Rows[0]["dateChange"] = this.dateTimePicker_0.Value;
				this.class141_0.Rows[0].EndEdit();
				base.InsertSqlData(null, this.class141_0);
			}
			else
			{
				this.class130_0.tJ_Excavation.Rows[0].EndEdit();
				base.UpdateSqlData(this.class130_0, this.class130_0.tJ_Excavation);
			}
			this.class130_0.tJ_ExcavationAddress.Rows[0]["idExcavation"] = this.int_0;
			this.class130_0.tJ_ExcavationAddress.Rows[0]["idStreet"] = this.kladrStreetControl_0.CmbStreet.SelectedValue;
			this.class130_0.tJ_ExcavationAddress.Rows[0].EndEdit();
			base.InsertSqlData(this.class130_0, this.class130_0.tJ_ExcavationAddress);
			base.UpdateSqlData(this.class130_0, this.class130_0.tJ_ExcavationAddress);
			this.class130_0.tJ_ExcavationSchmObj.Rows[0]["idExcavation"] = this.int_0;
			if (this.comboBox_4.SelectedValue == null)
			{
				this.class130_0.tJ_ExcavationSchmObj.Rows[0]["idKL"] = DBNull.Value;
			}
			else
			{
				this.class130_0.tJ_ExcavationSchmObj.Rows[0]["idkl"] = this.comboBox_4.SelectedValue;
			}
			this.class130_0.tJ_ExcavationSchmObj.Rows[0]["namekl"] = this.comboBox_4.Text;
			this.class130_0.tJ_ExcavationSchmObj.Rows[0].EndEdit();
			base.InsertSqlData(this.class130_0, this.class130_0.tJ_ExcavationSchmObj);
			base.UpdateSqlData(this.class130_0, this.class130_0.tJ_ExcavationSchmObj);
		}
	}

	private void kladrStreetControl_0_ChangeStreetSelect(object sender, EventArgs e)
	{
		if (this.kladrStreetControl_0.SelectedStreet.SelectedValue != null && this.kladrStreetControl_0.SelectedStreet.SelectedValue != DBNull.Value)
		{
			DataTable dataTable = base.SelectSqlData("tr_KladrStreet", true, " where id = " + this.kladrStreetControl_0.SelectedStreet.SelectedValue.ToString());
			if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["GNINMB"] != DBNull.Value)
			{
				this.comboBox_3.Text = this.dictionary_0[dataTable.Rows[0]["GNINMB"].ToString()];
				if (this.class130_0.tJ_ExcavationAddress.Rows.Count == 1)
				{
					this.class130_0.tJ_ExcavationAddress.Rows[0]["idregion"] = this.comboBox_3.SelectedValue;
				}
			}
		}
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		if (this.checkBox_0.Checked && this.class130_0.tJ_Excavation.Rows.Count > 0)
		{
			this.nullableDateTimePicker_7.Value = DateTime.Now.Date;
			this.class130_0.tJ_Excavation.Rows[0]["dateAgreed"] = DateTime.Now.Date;
		}
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		if (new Form64
		{
			SqlSettings = this.SqlSettings
		}.ShowDialog() == DialogResult.OK)
		{
			this.method_2();
		}
	}

	private void method_3()
	{
		this.class130_0 = new DataSetExcavation();
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.label_1 = new Label();
		this.dateTimePicker_0 = new DateTimePicker();
		this.label_2 = new Label();
		this.comboBox_0 = new ComboBox();
		this.label_3 = new Label();
		this.comboBox_1 = new ComboBox();
		this.groupBox_0 = new GroupBox();
		this.comboBox_2 = new ComboBox();
		this.label_4 = new Label();
		this.nullableDateTimePicker_0 = new NullableDateTimePicker();
		this.label_5 = new Label();
		this.nullableDateTimePicker_1 = new NullableDateTimePicker();
		this.label_6 = new Label();
		this.groupBox_1 = new GroupBox();
		this.nullableDateTimePicker_2 = new NullableDateTimePicker();
		this.label_7 = new Label();
		this.textBox_1 = new TextBox();
		this.label_8 = new Label();
		this.label_9 = new Label();
		this.nullableDateTimePicker_3 = new NullableDateTimePicker();
		this.nullableDateTimePicker_4 = new NullableDateTimePicker();
		this.label_10 = new Label();
		this.nullableDateTimePicker_5 = new NullableDateTimePicker();
		this.label_11 = new Label();
		this.nullableDateTimePicker_6 = new NullableDateTimePicker();
		this.label_12 = new Label();
		this.kladrStreetControl_0 = new KladrStreetControl();
		this.groupBox_2 = new GroupBox();
		this.comboBox_3 = new ComboBox();
		this.label_15 = new Label();
		this.textBox_2 = new TextBox();
		this.label_13 = new Label();
		this.textBox_3 = new TextBox();
		this.label_14 = new Label();
		this.groupBox_3 = new GroupBox();
		this.comboBox_4 = new ComboBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.groupBox_4 = new GroupBox();
		this.comboBox_5 = new ComboBox();
		this.label_16 = new Label();
		this.label_17 = new Label();
		this.nullableDateTimePicker_7 = new NullableDateTimePicker();
		this.checkBox_0 = new CheckBox();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		((ISupportInitialize)this.class130_0).BeginInit();
		this.groupBox_0.SuspendLayout();
		this.groupBox_1.SuspendLayout();
		this.groupBox_2.SuspendLayout();
		this.groupBox_3.SuspendLayout();
		this.groupBox_4.SuspendLayout();
		this.toolStrip_0.SuspendLayout();
		base.SuspendLayout();
		this.class130_0.DataSetName = "DataSetExcavation";
		this.class130_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 9);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(41, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Номер";
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class130_0, "tJ_Excavation.num", true));
		this.textBox_0.Enabled = false;
		this.textBox_0.Location = new Point(15, 25);
		this.textBox_0.Name = "txtNum";
		this.textBox_0.Size = new Size(100, 20);
		this.textBox_0.TabIndex = 1;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(144, 9);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(71, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Дата начала";
		this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class130_0, "tJ_Excavation.dateBeg", true));
		this.dateTimePicker_0.Location = new Point(147, 25);
		this.dateTimePicker_0.Name = "dateTimePickerBeg";
		this.dateTimePicker_0.Size = new Size(157, 20);
		this.dateTimePicker_0.TabIndex = 3;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(12, 57);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(62, 13);
		this.label_2.TabIndex = 4;
		this.label_2.Text = "Подрядчик";
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class130_0, "tJ_Excavation.idContractor", true));
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(15, 73);
		this.comboBox_0.Name = "cmbContractor";
		this.comboBox_0.Size = new Size(255, 21);
		this.comboBox_0.TabIndex = 5;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 106);
		this.label_3.Name = "label4";
		this.label_3.Size = new Size(58, 13);
		this.label_3.TabIndex = 6;
		this.label_3.Text = "Вид работ";
		this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.class130_0, "tJ_Excavation.TypeWork", true));
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(15, 122);
		this.comboBox_1.Name = "cmbTypeWork";
		this.comboBox_1.Size = new Size(255, 21);
		this.comboBox_1.TabIndex = 7;
		this.groupBox_0.Controls.Add(this.comboBox_2);
		this.groupBox_0.Controls.Add(this.label_4);
		this.groupBox_0.Controls.Add(this.nullableDateTimePicker_0);
		this.groupBox_0.Controls.Add(this.label_5);
		this.groupBox_0.Controls.Add(this.nullableDateTimePicker_1);
		this.groupBox_0.Controls.Add(this.label_6);
		this.groupBox_0.Location = new Point(15, 149);
		this.groupBox_0.Name = "groupBoxOrder";
		this.groupBox_0.Size = new Size(289, 80);
		this.groupBox_0.TabIndex = 8;
		this.groupBox_0.TabStop = false;
		this.groupBox_0.Text = "Ордер";
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Location = new Point(72, 50);
		this.comboBox_2.Name = "cmbStatusOrder";
		this.comboBox_2.Size = new Size(207, 21);
		this.comboBox_2.TabIndex = 5;
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(6, 53);
		this.label_4.Name = "label7";
		this.label_4.Size = new Size(60, 13);
		this.label_4.TabIndex = 4;
		this.label_4.Text = "состояние";
		this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class130_0, "tJ_Excavation.dateEndOrder", true));
		this.nullableDateTimePicker_0.Format = DateTimePickerFormat.Short;
		this.nullableDateTimePicker_0.Location = new Point(162, 18);
		this.nullableDateTimePicker_0.Name = "datetimePickerOrderEnd";
		this.nullableDateTimePicker_0.Size = new Size(117, 20);
		this.nullableDateTimePicker_0.TabIndex = 3;
		this.nullableDateTimePicker_0.Value = new DateTime(2013, 3, 28, 9, 38, 4, 862);
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(138, 24);
		this.label_5.Name = "label6";
		this.label_5.Size = new Size(19, 13);
		this.label_5.TabIndex = 2;
		this.label_5.Text = "до";
		this.nullableDateTimePicker_1.DataBindings.Add(new Binding("Value", this.class130_0, "tJ_Excavation.dateBegOrder", true));
		this.nullableDateTimePicker_1.Format = DateTimePickerFormat.Short;
		this.nullableDateTimePicker_1.Location = new Point(30, 19);
		this.nullableDateTimePicker_1.Name = "dateTimePickerOrderBeg";
		this.nullableDateTimePicker_1.Size = new Size(102, 20);
		this.nullableDateTimePicker_1.TabIndex = 1;
		this.nullableDateTimePicker_1.Value = new DateTime(2013, 3, 28, 9, 38, 4, 862);
		this.label_6.AutoSize = true;
		this.label_6.Location = new Point(6, 24);
		this.label_6.Name = "label5";
		this.label_6.Size = new Size(18, 13);
		this.label_6.TabIndex = 0;
		this.label_6.Text = "от";
		this.groupBox_1.Controls.Add(this.nullableDateTimePicker_2);
		this.groupBox_1.Controls.Add(this.label_7);
		this.groupBox_1.Controls.Add(this.textBox_1);
		this.groupBox_1.Controls.Add(this.label_8);
		this.groupBox_1.Location = new Point(15, 235);
		this.groupBox_1.Name = "groupBoxPermission";
		this.groupBox_1.Size = new Size(289, 53);
		this.groupBox_1.TabIndex = 9;
		this.groupBox_1.TabStop = false;
		this.groupBox_1.Text = "Разрешение";
		this.nullableDateTimePicker_2.DataBindings.Add(new Binding("Value", this.class130_0, "tJ_Excavation.DatePermission", true));
		this.nullableDateTimePicker_2.Format = DateTimePickerFormat.Short;
		this.nullableDateTimePicker_2.Location = new Point(172, 19);
		this.nullableDateTimePicker_2.Name = "datetimePickerPermission";
		this.nullableDateTimePicker_2.Size = new Size(107, 20);
		this.nullableDateTimePicker_2.TabIndex = 4;
		this.nullableDateTimePicker_2.Value = new DateTime(2013, 3, 28, 9, 38, 4, 862);
		this.label_7.AutoSize = true;
		this.label_7.Location = new Point(138, 22);
		this.label_7.Name = "label9";
		this.label_7.Size = new Size(30, 13);
		this.label_7.TabIndex = 2;
		this.label_7.Text = "дата";
		this.textBox_1.DataBindings.Add(new Binding("Text", this.class130_0, "tJ_Excavation.NumPermission", true));
		this.textBox_1.Location = new Point(47, 19);
		this.textBox_1.Name = "txtNumPermission";
		this.textBox_1.Size = new Size(85, 20);
		this.textBox_1.TabIndex = 1;
		this.label_8.AutoSize = true;
		this.label_8.Location = new Point(6, 22);
		this.label_8.Name = "label8";
		this.label_8.Size = new Size(41, 13);
		this.label_8.TabIndex = 0;
		this.label_8.Text = "Номер";
		this.label_9.AutoSize = true;
		this.label_9.Location = new Point(12, 291);
		this.label_9.Name = "label10";
		this.label_9.Size = new Size(97, 13);
		this.label_9.TabIndex = 10;
		this.label_9.Text = "Сдано под асф-ие";
		this.nullableDateTimePicker_3.DataBindings.Add(new Binding("Value", this.class130_0, "tJ_Excavation.dateUnderAsphalt", true));
		this.nullableDateTimePicker_3.Format = DateTimePickerFormat.Short;
		this.nullableDateTimePicker_3.Location = new Point(15, 307);
		this.nullableDateTimePicker_3.Name = "dateTimePickerUnderAsphalt";
		this.nullableDateTimePicker_3.Size = new Size(132, 20);
		this.nullableDateTimePicker_3.TabIndex = 11;
		this.nullableDateTimePicker_3.Value = new DateTime(2013, 3, 28, 9, 38, 4, 862);
		this.nullableDateTimePicker_4.DataBindings.Add(new Binding("Value", this.class130_0, "tJ_Excavation.dateAsphalt", true));
		this.nullableDateTimePicker_4.Format = DateTimePickerFormat.Short;
		this.nullableDateTimePicker_4.Location = new Point(156, 307);
		this.nullableDateTimePicker_4.Name = "dateTimePickerAsphalt";
		this.nullableDateTimePicker_4.Size = new Size(138, 20);
		this.nullableDateTimePicker_4.TabIndex = 13;
		this.nullableDateTimePicker_4.Value = new DateTime(2013, 3, 28, 9, 38, 4, 862);
		this.label_10.AutoSize = true;
		this.label_10.Location = new Point(153, 291);
		this.label_10.Name = "label11";
		this.label_10.Size = new Size(127, 13);
		this.label_10.TabIndex = 12;
		this.label_10.Text = "Дата асфальтирования";
		this.nullableDateTimePicker_5.DataBindings.Add(new Binding("Value", this.class130_0, "tJ_Excavation.datePay", true));
		this.nullableDateTimePicker_5.Format = DateTimePickerFormat.Short;
		this.nullableDateTimePicker_5.Location = new Point(156, 346);
		this.nullableDateTimePicker_5.Name = "dateTimePcikerPay";
		this.nullableDateTimePicker_5.Size = new Size(138, 20);
		this.nullableDateTimePicker_5.TabIndex = 17;
		this.nullableDateTimePicker_5.Value = new DateTime(2013, 3, 28, 9, 38, 4, 862);
		this.label_11.AutoSize = true;
		this.label_11.Location = new Point(153, 330);
		this.label_11.Name = "label12";
		this.label_11.Size = new Size(104, 13);
		this.label_11.TabIndex = 16;
		this.label_11.Text = "Передано к оплате";
		this.nullableDateTimePicker_6.DataBindings.Add(new Binding("Value", this.class130_0, "tJ_Excavation.dateEnd", true));
		this.nullableDateTimePicker_6.Format = DateTimePickerFormat.Short;
		this.nullableDateTimePicker_6.Location = new Point(15, 346);
		this.nullableDateTimePicker_6.Name = "dateTimePickerEnd";
		this.nullableDateTimePicker_6.Size = new Size(132, 20);
		this.nullableDateTimePicker_6.TabIndex = 15;
		this.nullableDateTimePicker_6.Value = new DateTime(2013, 3, 28, 9, 38, 4, 862);
		this.label_12.AutoSize = true;
		this.label_12.Location = new Point(12, 330);
		this.label_12.Name = "label13";
		this.label_12.Size = new Size(76, 13);
		this.label_12.TabIndex = 14;
		this.label_12.Text = "Сдано адм-ии";
		this.kladrStreetControl_0.Location = new Point(6, 19);
		this.kladrStreetControl_0.Name = "kladrStreetControl1";
		this.kladrStreetControl_0.Size = new Size(203, 173);
		this.kladrStreetControl_0.SqlSettings = null;
		this.kladrStreetControl_0.TabIndex = 18;
		this.kladrStreetControl_0.VisibleCmbTypeHouse = false;
		this.kladrStreetControl_0.ChangeStreetSelect += this.kladrStreetControl_0_ChangeStreetSelect;
		this.groupBox_2.Controls.Add(this.comboBox_3);
		this.groupBox_2.Controls.Add(this.label_15);
		this.groupBox_2.Controls.Add(this.textBox_2);
		this.groupBox_2.Controls.Add(this.label_13);
		this.groupBox_2.Controls.Add(this.textBox_3);
		this.groupBox_2.Controls.Add(this.label_14);
		this.groupBox_2.Controls.Add(this.kladrStreetControl_0);
		this.groupBox_2.Location = new Point(310, 9);
		this.groupBox_2.Name = "groupBoxAddress";
		this.groupBox_2.Size = new Size(212, 303);
		this.groupBox_2.TabIndex = 19;
		this.groupBox_2.TabStop = false;
		this.groupBox_2.Text = "Адрес";
		this.comboBox_3.DataBindings.Add(new Binding("SelectedValue", this.class130_0, "tJ_ExcavationAddress.idRegion", true));
		this.comboBox_3.FormattingEnabled = true;
		this.comboBox_3.Location = new Point(13, 273);
		this.comboBox_3.Name = "cmbRegion";
		this.comboBox_3.Size = new Size(186, 21);
		this.comboBox_3.TabIndex = 24;
		this.label_15.AutoSize = true;
		this.label_15.Location = new Point(13, 257);
		this.label_15.Name = "label16";
		this.label_15.Size = new Size(38, 13);
		this.label_15.TabIndex = 23;
		this.label_15.Text = "Район";
		this.textBox_2.DataBindings.Add(new Binding("Text", this.class130_0, "tJ_ExcavationAddress.Comment", true));
		this.textBox_2.Location = new Point(13, 234);
		this.textBox_2.Name = "txtAddressComment";
		this.textBox_2.Size = new Size(186, 20);
		this.textBox_2.TabIndex = 22;
		this.label_13.AutoSize = true;
		this.label_13.Location = new Point(13, 218);
		this.label_13.Name = "label15";
		this.label_13.Size = new Size(70, 13);
		this.label_13.TabIndex = 21;
		this.label_13.Text = "Примечание";
		this.textBox_3.DataBindings.Add(new Binding("Text", this.class130_0, "tJ_ExcavationAddress.House", true));
		this.textBox_3.Location = new Point(13, 195);
		this.textBox_3.Name = "txtAddressHouse";
		this.textBox_3.Size = new Size(186, 20);
		this.textBox_3.TabIndex = 20;
		this.label_14.AutoSize = true;
		this.label_14.Location = new Point(13, 179);
		this.label_14.Name = "label14";
		this.label_14.Size = new Size(30, 13);
		this.label_14.TabIndex = 19;
		this.label_14.Text = "Дом";
		this.groupBox_3.Controls.Add(this.comboBox_4);
		this.groupBox_3.Location = new Point(310, 318);
		this.groupBox_3.Name = "groupBoxKL";
		this.groupBox_3.Size = new Size(212, 48);
		this.groupBox_3.TabIndex = 20;
		this.groupBox_3.TabStop = false;
		this.groupBox_3.Text = "Кабельная линия";
		this.comboBox_4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_4.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_4.FormattingEnabled = true;
		this.comboBox_4.Location = new Point(6, 21);
		this.comboBox_4.Name = "cmbKL";
		this.comboBox_4.Size = new Size(200, 21);
		this.comboBox_4.TabIndex = 0;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(15, 427);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 21;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(447, 427);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 22;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.groupBox_4.Controls.Add(this.comboBox_5);
		this.groupBox_4.Controls.Add(this.label_16);
		this.groupBox_4.Controls.Add(this.label_17);
		this.groupBox_4.Controls.Add(this.nullableDateTimePicker_7);
		this.groupBox_4.Controls.Add(this.checkBox_0);
		this.groupBox_4.Location = new Point(3, 374);
		this.groupBox_4.Name = "groupBoxAgreed";
		this.groupBox_4.Size = new Size(519, 47);
		this.groupBox_4.TabIndex = 24;
		this.groupBox_4.TabStop = false;
		this.groupBox_4.Text = "Согласование";
		this.comboBox_5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_5.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_5.DataBindings.Add(new Binding("SelectedValue", this.class130_0, "tJ_Excavation.workeragreed", true));
		this.comboBox_5.FormattingEnabled = true;
		this.comboBox_5.Location = new Point(392, 16);
		this.comboBox_5.Name = "cmbDispatcher";
		this.comboBox_5.Size = new Size(121, 21);
		this.comboBox_5.TabIndex = 15;
		this.label_16.AutoSize = true;
		this.label_16.Location = new Point(310, 19);
		this.label_16.Name = "label17";
		this.label_16.Size = new Size(77, 13);
		this.label_16.TabIndex = 14;
		this.label_16.Text = "Согласующий";
		this.label_17.AutoSize = true;
		this.label_17.Location = new Point(139, 20);
		this.label_17.Name = "label18";
		this.label_17.Size = new Size(33, 13);
		this.label_17.TabIndex = 13;
		this.label_17.Text = "Дата";
		this.nullableDateTimePicker_7.DataBindings.Add(new Binding("Value", this.class130_0, "tJ_Excavation.dateagreed", true));
		this.nullableDateTimePicker_7.Location = new Point(178, 17);
		this.nullableDateTimePicker_7.Name = "dateTimePickerDateAgreed";
		this.nullableDateTimePicker_7.Size = new Size(126, 20);
		this.nullableDateTimePicker_7.TabIndex = 12;
		this.nullableDateTimePicker_7.Value = new DateTime(2012, 9, 26, 9, 58, 28, 932);
		this.checkBox_0.DataBindings.Add(new Binding("Checked", this.class130_0, "tJ_Excavation.agreed", true));
		this.checkBox_0.Location = new Point(12, 16);
		this.checkBox_0.Name = "checkBoxAgreed";
		this.checkBox_0.Size = new Size(121, 31);
		this.checkBox_0.TabIndex = 11;
		this.checkBox_0.Text = "Согласовано сетевым районом";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
		this.toolStrip_0.Dock = DockStyle.None;
		this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0
		});
		this.toolStrip_0.Location = new Point(273, 73);
		this.toolStrip_0.Name = "toolStrip1";
		this.toolStrip_0.Size = new Size(26, 25);
		this.toolStrip_0.TabIndex = 25;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources.partners;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtnContractor";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Справочник подрядчиков";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(531, 457);
		base.Controls.Add(this.toolStrip_0);
		base.Controls.Add(this.groupBox_4);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.groupBox_3);
		base.Controls.Add(this.groupBox_2);
		base.Controls.Add(this.nullableDateTimePicker_5);
		base.Controls.Add(this.label_11);
		base.Controls.Add(this.nullableDateTimePicker_6);
		base.Controls.Add(this.label_12);
		base.Controls.Add(this.nullableDateTimePicker_4);
		base.Controls.Add(this.label_10);
		base.Controls.Add(this.nullableDateTimePicker_3);
		base.Controls.Add(this.label_9);
		base.Controls.Add(this.groupBox_1);
		base.Controls.Add(this.groupBox_0);
		base.Controls.Add(this.comboBox_1);
		base.Controls.Add(this.label_3);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.dateTimePicker_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_0);
		base.Name = "FormExcavationAddEdit";
		this.Text = "Новая раскопка";
		base.FormClosing += this.Form60_FormClosing;
		base.Load += this.Form60_Load;
		((ISupportInitialize)this.class130_0).EndInit();
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		this.groupBox_1.ResumeLayout(false);
		this.groupBox_1.PerformLayout();
		this.groupBox_2.ResumeLayout(false);
		this.groupBox_2.PerformLayout();
		this.groupBox_3.ResumeLayout(false);
		this.groupBox_4.ResumeLayout(false);
		this.groupBox_4.PerformLayout();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	internal int int_0;

	private DataSetExcavation.Class141 class141_0;

	private Dictionary<string, string> dictionary_0;

	private DataSetExcavation class130_0;

	private Label label_0;

	private TextBox textBox_0;

	private Label label_1;

	private DateTimePicker dateTimePicker_0;

	private Label label_2;

	private ComboBox comboBox_0;

	private Label label_3;

	private ComboBox comboBox_1;

	private GroupBox groupBox_0;

	private ComboBox comboBox_2;

	private Label label_4;

	private NullableDateTimePicker nullableDateTimePicker_0;

	private Label label_5;

	private NullableDateTimePicker nullableDateTimePicker_1;

	private Label label_6;

	private GroupBox groupBox_1;

	private NullableDateTimePicker nullableDateTimePicker_2;

	private Label label_7;

	private TextBox textBox_1;

	private Label label_8;

	private Label label_9;

	private NullableDateTimePicker nullableDateTimePicker_3;

	private NullableDateTimePicker nullableDateTimePicker_4;

	private Label label_10;

	private NullableDateTimePicker nullableDateTimePicker_5;

	private Label label_11;

	private NullableDateTimePicker nullableDateTimePicker_6;

	private Label label_12;

	private KladrStreetControl kladrStreetControl_0;

	private GroupBox groupBox_2;

	private TextBox textBox_2;

	private Label label_13;

	private TextBox textBox_3;

	private Label label_14;

	private GroupBox groupBox_3;

	private Button button_0;

	private Button button_1;

	private ComboBox comboBox_3;

	private Label label_15;

	private ComboBox comboBox_4;

	private GroupBox groupBox_4;

	private ComboBox comboBox_5;

	private Label label_16;

	private Label label_17;

	private NullableDateTimePicker nullableDateTimePicker_7;

	private CheckBox checkBox_0;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;
}
