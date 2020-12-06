using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

namespace Documents.Forms.TechnologicalConnection
{
	public partial class FormTechConnectionRequestAddEdit : FormBase
	{
		public int Id
		{
			get
			{
				if (this.nullable_0 != null)
				{
					return this.nullable_0.Value;
				}
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		public FormTechConnectionRequestAddEdit()
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = 1113;
			
			this.method_8();
			this.method_0();
		}

		public FormTechConnectionRequestAddEdit(int id, int typeDoc = 1113, int? idParent = null)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = 1113;
			
			this.method_8();
			this.int_1 = id;
			this.int_0 = id;
			this.int_4 = typeDoc;
			this.nullable_0 = idParent;
			this.method_0();
		}

		private void method_0()
		{
			this.Text = ((this.int_0 == -1) ? "Новая заявка" : "Редактировать заявку");
			this.nullableDateTimePicker_0.Value = (this.dateTimePicker_0.Value = DateTime.Now.Date);
		}

		private void method_1()
		{
			Class10.Class11 @class = new Class10.Class11();
			base.SelectSqlData(@class, true, " where id = " + this.int_2.ToString(), null, false, 0);
			if (@class.Rows.Count > 0)
			{
				this.comboBox_0.SelectedValueChanged -= this.WhVvhysMrj;
				int num = Convert.ToInt32(@class.Rows[0]["typeAbn"]);
				Class10.Class16 class2 = new Class10.Class16();
				DataColumn dataColumn = new DataColumn("AddressFL");
				dataColumn.Expression = "street + ', д. ' + houseall + isnull(', кв. ' + name, '')";
				class2.Columns.Add(dataColumn);
				dataColumn = new DataColumn("AddressUL");
				dataColumn.Expression = "street + ', д. ' + houseall";
				class2.Columns.Add(dataColumn);
				base.SelectSqlData(class2, true, "where idAbn = " + this.int_2.ToString() + " order by name", null, false, 0);
				this.comboBox_0.ValueMember = "id";
				this.comboBox_0.DataSource = class2;
				if (num != 206 && num != 253)
				{
					if (num != 1037)
					{
						this.comboBox_0.DisplayMember = "name";
						goto IL_149;
					}
				}
				this.comboBox_0.DisplayMember = "AddressFL";
				IL_149:
				this.comboBox_0.SelectedValue = this.int_3;
				if (this.comboBox_0.SelectedValue == null)
				{
					this.int_3 = -1;
				}
				this.comboBox_0.SelectedValueChanged += this.WhVvhysMrj;
				return;
			}
			this.comboBox_0.Items.Clear();
			this.int_3 = -1;
		}

		private void FormTechConnectionRequestAddEdit_Load(object sender, EventArgs e)
		{
			base.SelectSqlData(this.class10_0, this.class10_0.tR_Classifier, true, " where ParentKey like ';VoltageLevels;%' and isGRoup = 0 and deleted = 0 order by value");
			if (this.int_0 == -1)
			{
				this.method_3();
				this.method_4();
			}
			else
			{
				base.SelectSqlData(this.class10_0, this.class10_0.tTC_Doc, true, "where id = " + this.int_0.ToString());
				if (this.class10_0.tTC_Doc.Rows.Count > 0)
				{
					if (this.class10_0.tTC_Doc.Rows[0]["idParent"] != DBNull.Value)
					{
						this.nullable_0 = new int?(Convert.ToInt32(this.class10_0.tTC_Doc.Rows[0]["idParent"]));
					}
					base.SelectSqlData(this.class10_0, this.class10_0.tTC_Request, true, "where id = " + this.int_0.ToString());
					if (this.class10_0.tTC_Request.Rows.Count == 0)
					{
						this.method_4();
					}
					else
					{
						this.method_2(this.int_0);
					}
				}
				else
				{
					this.method_3();
					this.method_4();
				}
			}
			if (this.class10_0.tTC_Doc.Rows.Count > 0 && this.class10_0.tTC_Doc.Rows[0]["IdParent"] != DBNull.Value)
			{
				this.toolStripButton_0.Enabled = false;
				this.comboBox_0.Enabled = false;
			}
		}

		private void method_2(int int_5)
		{
			Class10.Class13 @class = new Class10.Class13();
			base.SelectSqlData(@class, true, " where id = " + int_5.ToString(), null, false, 0);
			if (@class.Rows.Count > 0)
			{
				if (@class.Rows[0]["idAbn"] != DBNull.Value)
				{
					this.nullable_1 = new int?(this.int_2 = Convert.ToInt32(@class.Rows[0]["idAbn"]));
					Class10.Class11 class2 = new Class10.Class11();
					base.SelectSqlData(class2, true, "where id = " + this.int_2.ToString(), null, false, 0);
					if (class2.Rows.Count > 0)
					{
						this.textBox_1.Text = class2.Rows[0]["name"].ToString();
					}
				}
				if (@class.Rows[0]["idAbnObj"] != DBNull.Value)
				{
					this.nullable_2 = new int?(this.int_3 = Convert.ToInt32(@class.Rows[0]["idAbnObj"]));
				}
				this.method_1();
			}
		}

		private void method_3()
		{
			this.int_0 = -1;
			DataRow dataRow = this.class10_0.tTC_Doc.NewRow();
			dataRow["TypeDoc"] = this.int_4;
			dataRow["DateDoc"] = DateTime.Now.Date;
			if (this.nullable_0 != null)
			{
				dataRow["idParent"] = this.nullable_0;
				this.method_2(this.nullable_0.Value);
			}
			this.class10_0.tTC_Doc.Rows.Add(dataRow);
		}

		private void method_4()
		{
			this.int_1 = -1;
			DataRow dataRow = this.class10_0.tTC_Request.NewRow();
			dataRow["id"] = this.class10_0.tTC_Doc.Rows[0]["id"];
			this.class10_0.tTC_Request.Rows.Add(dataRow);
		}

		private void FormTechConnectionRequestAddEdit_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.DialogResult == DialogResult.OK)
			{
				this.class10_0.tTC_Doc.Rows[0].EndEdit();
				this.class10_0.tTC_Request.Rows[0].EndEdit();
				this.class10_0.tTC_Request.Rows[0]["idAbn"] = this.int_2;
				this.class10_0.tTC_Request.Rows[0]["idAbnObj"] = this.int_3;
				if (this.int_0 == -1)
				{
					this.int_0 = base.InsertSqlDataOneRow(this.class10_0, this.class10_0.tTC_Doc);
					this.class10_0.tTC_Request.Rows[0]["id"] = this.int_0;
					this.class10_0.tTC_Request.Rows[0].EndEdit();
					base.InsertSqlData(this.class10_0, this.class10_0.tTC_Request);
					return;
				}
				if (base.UpdateSqlData(this.class10_0, this.class10_0.tTC_Doc))
				{
					if (this.int_1 == -1)
					{
						this.class10_0.tTC_Request.Rows[0]["id"] = this.int_0;
						this.class10_0.tTC_Request.Rows[0].EndEdit();
						base.InsertSqlData(this.class10_0, this.class10_0.tTC_Request);
						return;
					}
					if (base.UpdateSqlData(this.class10_0, this.class10_0.tTC_Request) && (this.nullable_1 != this.int_2 || this.nullable_2 != this.int_3))
					{
						this.method_7();
					}
				}
			}
		}

		private void CyFvvmurq9(object sender, FormClosedEventArgs e)
		{
			FormTechConnectionAddAbn formTechConnectionAddAbn = (FormTechConnectionAddAbn)sender;
			if (formTechConnectionAddAbn.DialogResult == DialogResult.OK)
			{
				this.textBox_1.Text = formTechConnectionAddAbn.AbnName;
				this.int_2 = formTechConnectionAddAbn.IdAbn;
				this.textBox_2.Text = formTechConnectionAddAbn.GetNameAbnObj();
				this.int_3 = formTechConnectionAddAbn.GetIdAbnObj();
				this.method_1();
			}
		}

		private bool method_5()
		{
			return this.Id > 0 && base.SelectSqlData("ttc_docout", true, " inner join ttc_doc d on d.id = ttc_docout.idDocout and d.TypeDoc = " + 1123.ToString() + " where ttc_docout.idDoc = " + this.Id.ToString()).Rows.Count > 0;
		}

		private FormBase method_6(object object_0, ShowFormEventArgs showFormEventArgs_0)
		{
			return this.OnShowForm(showFormEventArgs_0);
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			FormTechConnectionAddAbn formTechConnectionAddAbn = new FormTechConnectionAddAbn(this.int_2, this.int_3, true);
			formTechConnectionAddAbn.ShowForm += this.method_6;
			formTechConnectionAddAbn.SqlSettings = this.SqlSettings;
			formTechConnectionAddAbn.MdiParent = base.MdiParent;
			formTechConnectionAddAbn.FormClosed += this.CyFvvmurq9;
			formTechConnectionAddAbn.Show();
		}

		private void WhVvhysMrj(object sender, EventArgs e)
		{
			if (this.comboBox_0.SelectedValue != null || this.comboBox_0.SelectedValue != DBNull.Value)
			{
				this.int_3 = Convert.ToInt32(this.comboBox_0.SelectedValue);
			}
		}

		private void method_7()
		{
			using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString() + ";Connection Timeout=1000"))
			{
				sqlConnection.Open();
				using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
				{
					try
					{
						using (SqlCommand sqlCommand = new SqlCommand(Class7.smethod_2("Documents.Forms.TechnologicalConnection.SqlScripts.ChangeAbnAndAbnObjRequest.sql"), sqlConnection))
						{
							sqlCommand.Transaction = sqlTransaction;
							sqlCommand.Parameters.Add("id", SqlDbType.Int).Value = this.int_0;
							sqlCommand.Parameters.Add("idAbn", SqlDbType.Int).Value = this.int_2;
							sqlCommand.Parameters.Add("idAbnObj", SqlDbType.Int).Value = this.int_3;
							sqlCommand.ExecuteNonQuery();
						}
						sqlTransaction.Commit();
					}
					catch (Exception ex)
					{
						sqlTransaction.Rollback();
						MessageBox.Show(ex.Message, ex.Source);
					}
				}
			}
		}

		private void method_8()
		{
			this.nLyvLkkUnV = new Label();
			this.dateTimePicker_0 = new DateTimePicker();
			this.class10_0 = new Class10();
			this.groupBox_0 = new GroupBox();
			this.nullableDateTimePicker_0 = new NullableDateTimePicker();
			this.label_0 = new Label();
			this.textBox_0 = new TextBox();
			this.label_1 = new Label();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.label_2 = new Label();
			this.textBox_1 = new TextBox();
			this.label_3 = new Label();
			this.textBox_2 = new TextBox();
			this.GucvzOcRw8 = new Label();
			this.textBox_3 = new TextBox();
			this.label_4 = new Label();
			this.numericUpDown_0 = new NumericUpDown();
			this.label_5 = new Label();
			this.textBox_4 = new TextBox();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStrip_0 = new ToolStrip();
			this.comboBox_0 = new ComboBox();
			this.label_6 = new Label();
			this.comboBox_1 = new ComboBox();
			this.numericUpDown_1 = new NumericUpDown();
			this.label_7 = new Label();
			this.numericUpDown_2 = new NumericUpDown();
			this.label_8 = new Label();
			((ISupportInitialize)this.class10_0).BeginInit();
			this.groupBox_0.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_0).BeginInit();
			this.toolStrip_0.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_1).BeginInit();
			((ISupportInitialize)this.numericUpDown_2).BeginInit();
			base.SuspendLayout();
			this.nLyvLkkUnV.AutoSize = true;
			this.nLyvLkkUnV.Location = new Point(40, 19);
			this.nLyvLkkUnV.Name = "label1";
			this.nLyvLkkUnV.Size = new Size(100, 13);
			this.nLyvLkkUnV.TabIndex = 0;
			this.nLyvLkkUnV.Text = "Дата поступления";
			this.dateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_Doc.dateDoc", true));
			this.dateTimePicker_0.Location = new Point(146, 12);
			this.dateTimePicker_0.Name = "dateTimePickerDate";
			this.dateTimePicker_0.Size = new Size(274, 20);
			this.dateTimePicker_0.TabIndex = 1;
			this.class10_0.DataSetName = "DataSetTechConnection";
			this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.groupBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_0.Controls.Add(this.nullableDateTimePicker_0);
			this.groupBox_0.Controls.Add(this.label_0);
			this.groupBox_0.Controls.Add(this.textBox_0);
			this.groupBox_0.Controls.Add(this.label_1);
			this.groupBox_0.Location = new Point(2, 38);
			this.groupBox_0.Name = "groupBoxDocIn";
			this.groupBox_0.Size = new Size(446, 56);
			this.groupBox_0.TabIndex = 2;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.Text = "Входящий документ";
			this.nullableDateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.nullableDateTimePicker_0.CustomFormat = "dd.MM.yyyy";
			this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_Request.dateIn", true));
			this.nullableDateTimePicker_0.Format = DateTimePickerFormat.Custom;
			this.nullableDateTimePicker_0.Location = new Point(325, 24);
			this.nullableDateTimePicker_0.Name = "dateTimePickerDateDocIn";
			this.nullableDateTimePicker_0.Size = new Size(115, 20);
			this.nullableDateTimePicker_0.TabIndex = 3;
			this.nullableDateTimePicker_0.Value = new DateTime(2013, 4, 15, 13, 28, 53, 804);
			this.label_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(286, 27);
			this.label_0.Name = "label3";
			this.label_0.Size = new Size(33, 13);
			this.label_0.TabIndex = 2;
			this.label_0.Text = "Дата";
			this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_0.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Request.numIn", true));
			this.textBox_0.Location = new Point(57, 24);
			this.textBox_0.Name = "txtNumDocIn";
			this.textBox_0.Size = new Size(223, 20);
			this.textBox_0.TabIndex = 1;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(10, 27);
			this.label_1.Name = "label2";
			this.label_1.Size = new Size(41, 13);
			this.label_1.TabIndex = 0;
			this.label_1.Text = "Номер";
			this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.button_0.DialogResult = DialogResult.OK;
			this.button_0.Location = new Point(12, 520);
			this.button_0.Name = "buttonOK";
			this.button_0.Size = new Size(75, 23);
			this.button_0.TabIndex = 21;
			this.button_0.Text = "ОК";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += this.button_0_Click;
			this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_1.DialogResult = DialogResult.Cancel;
			this.button_1.Location = new Point(373, 520);
			this.button_1.Name = "buttonCancel";
			this.button_1.Size = new Size(75, 23);
			this.button_1.TabIndex = 22;
			this.button_1.Text = "Отмена";
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += this.button_1_Click;
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(9, 97);
			this.label_2.Name = "label4";
			this.label_2.Size = new Size(49, 13);
			this.label_2.TabIndex = 3;
			this.label_2.Text = "Абонент";
			this.textBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_1.BackColor = SystemColors.Window;
			this.textBox_1.Location = new Point(12, 113);
			this.textBox_1.Name = "txtAbn";
			this.textBox_1.ReadOnly = true;
			this.textBox_1.Size = new Size(436, 20);
			this.textBox_1.TabIndex = 4;
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(12, 136);
			this.label_3.Name = "label5";
			this.label_3.Size = new Size(45, 13);
			this.label_3.TabIndex = 5;
			this.label_3.Text = "Объект";
			this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_2.BackColor = SystemColors.Window;
			this.textBox_2.Location = new Point(215, 130);
			this.textBox_2.Name = "txtAbnObj";
			this.textBox_2.ReadOnly = true;
			this.textBox_2.Size = new Size(157, 20);
			this.textBox_2.TabIndex = 7;
			this.textBox_2.Visible = false;
			this.GucvzOcRw8.AutoSize = true;
			this.GucvzOcRw8.Location = new Point(12, 175);
			this.GucvzOcRw8.Name = "label6";
			this.GucvzOcRw8.Size = new Size(73, 13);
			this.GucvzOcRw8.TabIndex = 9;
			this.GucvzOcRw8.Text = "Тело письма";
			this.textBox_3.AcceptsReturn = true;
			this.textBox_3.AcceptsTab = true;
			this.textBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_3.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Request.body", true));
			this.textBox_3.Location = new Point(12, 191);
			this.textBox_3.Multiline = true;
			this.textBox_3.Name = "txtBody";
			this.textBox_3.Size = new Size(436, 97);
			this.textBox_3.TabIndex = 10;
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(12, 344);
			this.label_4.Name = "label7";
			this.label_4.Size = new Size(139, 13);
			this.label_4.TabIndex = 15;
			this.label_4.Text = "Максимальная мощность";
			this.numericUpDown_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.numericUpDown_0.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_Request.Power", true));
			this.numericUpDown_0.DecimalPlaces = 3;
			this.numericUpDown_0.Location = new Point(158, 342);
			NumericUpDown numericUpDown = this.numericUpDown_0;
			int[] array = new int[4];
			array[0] = 100000;
			numericUpDown.Maximum = new decimal(array);
			this.numericUpDown_0.Name = "numericUpDown1";
			this.numericUpDown_0.Size = new Size(290, 20);
			this.numericUpDown_0.TabIndex = 16;
			this.numericUpDown_0.TextAlign = HorizontalAlignment.Right;
			this.label_5.AutoSize = true;
			this.label_5.Location = new Point(12, 398);
			this.label_5.Name = "label8";
			this.label_5.Size = new Size(77, 13);
			this.label_5.TabIndex = 19;
			this.label_5.Text = "Комментарий";
			this.textBox_4.AcceptsReturn = true;
			this.textBox_4.AcceptsTab = true;
			this.textBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_4.DataBindings.Add(new Binding("Text", this.class10_0, "tTC_Doc.Comment", true));
			this.textBox_4.Location = new Point(15, 414);
			this.textBox_4.Multiline = true;
			this.textBox_4.Name = "txtComment";
			this.textBox_4.Size = new Size(433, 100);
			this.textBox_4.TabIndex = 20;
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.partners;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnContractor";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Выбрать контрагента";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStrip_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.toolStrip_0.Dock = DockStyle.None;
			this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0
			});
			this.toolStrip_0.Location = new Point(421, 130);
			this.toolStrip_0.Name = "toolStrip1";
			this.toolStrip_0.Size = new Size(26, 25);
			this.toolStrip_0.TabIndex = 8;
			this.toolStrip_0.Text = "toolStrip1";
			this.comboBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(12, 151);
			this.comboBox_0.Name = "cmbAbnObj";
			this.comboBox_0.Size = new Size(436, 21);
			this.comboBox_0.TabIndex = 6;
			this.comboBox_0.SelectedValueChanged += this.WhVvhysMrj;
			this.label_6.AutoSize = true;
			this.label_6.Location = new Point(12, 372);
			this.label_6.Name = "label9";
			this.label_6.Size = new Size(71, 13);
			this.label_6.TabIndex = 17;
			this.label_6.Text = "Напряжение";
			this.comboBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_1.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.class10_0, "tTC_Request.VoltageLevel", true));
			this.comboBox_1.DataSource = this.class10_0;
			this.comboBox_1.DisplayMember = "tR_Classifier.Name";
			this.comboBox_1.FormattingEnabled = true;
			this.comboBox_1.Location = new Point(158, 369);
			this.comboBox_1.Name = "cmbVoltage";
			this.comboBox_1.Size = new Size(289, 21);
			this.comboBox_1.TabIndex = 18;
			this.comboBox_1.ValueMember = "tR_Classifier.Id";
			this.numericUpDown_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.numericUpDown_1.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_Request.PowerAdd", true));
			this.numericUpDown_1.DecimalPlaces = 3;
			this.numericUpDown_1.Location = new Point(158, 318);
			NumericUpDown numericUpDown2 = this.numericUpDown_1;
			int[] array2 = new int[4];
			array2[0] = 100000;
			numericUpDown2.Maximum = new decimal(array2);
			this.numericUpDown_1.Name = "numericUpDown2";
			this.numericUpDown_1.Size = new Size(290, 20);
			this.numericUpDown_1.TabIndex = 14;
			this.numericUpDown_1.TextAlign = HorizontalAlignment.Right;
			this.label_7.AutoSize = true;
			this.label_7.Location = new Point(12, 320);
			this.label_7.Name = "label10";
			this.label_7.Size = new Size(148, 13);
			this.label_7.TabIndex = 13;
			this.label_7.Text = "Дополнительная мощность";
			this.numericUpDown_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.numericUpDown_2.DataBindings.Add(new Binding("Value", this.class10_0, "tTC_Request.PowerCurrent", true));
			this.numericUpDown_2.DecimalPlaces = 3;
			this.numericUpDown_2.Location = new Point(158, 294);
			NumericUpDown numericUpDown3 = this.numericUpDown_2;
			int[] array3 = new int[4];
			array3[0] = 100000;
			numericUpDown3.Maximum = new decimal(array3);
			this.numericUpDown_2.Name = "numericUpDown3";
			this.numericUpDown_2.Size = new Size(290, 20);
			this.numericUpDown_2.TabIndex = 12;
			this.numericUpDown_2.TextAlign = HorizontalAlignment.Right;
			this.label_8.AutoSize = true;
			this.label_8.Location = new Point(12, 296);
			this.label_8.Name = "label11";
			this.label_8.Size = new Size(140, 13);
			this.label_8.TabIndex = 11;
			this.label_8.Text = "Существующая мощность";
			base.AcceptButton = this.button_0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.button_1;
			base.ClientSize = new Size(457, 549);
			base.Controls.Add(this.numericUpDown_2);
			base.Controls.Add(this.label_8);
			base.Controls.Add(this.numericUpDown_1);
			base.Controls.Add(this.label_7);
			base.Controls.Add(this.comboBox_1);
			base.Controls.Add(this.label_6);
			base.Controls.Add(this.comboBox_0);
			base.Controls.Add(this.textBox_4);
			base.Controls.Add(this.label_5);
			base.Controls.Add(this.toolStrip_0);
			base.Controls.Add(this.numericUpDown_0);
			base.Controls.Add(this.label_4);
			base.Controls.Add(this.textBox_3);
			base.Controls.Add(this.GucvzOcRw8);
			base.Controls.Add(this.textBox_2);
			base.Controls.Add(this.label_3);
			base.Controls.Add(this.textBox_1);
			base.Controls.Add(this.label_2);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.button_0);
			base.Controls.Add(this.groupBox_0);
			base.Controls.Add(this.dateTimePicker_0);
			base.Controls.Add(this.nLyvLkkUnV);
			base.Name = "FormTechConnectionRequestAddEdit";
			this.Text = "FormTechConnectionRequestAddEdit";
			base.FormClosing += this.FormTechConnectionRequestAddEdit_FormClosing;
			base.Load += this.FormTechConnectionRequestAddEdit_Load;
			((ISupportInitialize)this.class10_0).EndInit();
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			((ISupportInitialize)this.numericUpDown_0).EndInit();
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			((ISupportInitialize)this.numericUpDown_1).EndInit();
			((ISupportInitialize)this.numericUpDown_2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int? nullable_0;

		private int? nullable_1;

		private int? nullable_2;

		private Label nLyvLkkUnV;

		private DateTimePicker dateTimePicker_0;

		private GroupBox groupBox_0;

		private NullableDateTimePicker nullableDateTimePicker_0;

		private Label label_0;

		private TextBox textBox_0;

		private Label label_1;

		private Button button_0;

		private Button button_1;

		private Class10 class10_0;

		private Label label_2;

		private TextBox textBox_1;

		private Label label_3;

		private TextBox textBox_2;

		private Label GucvzOcRw8;

		private TextBox textBox_3;

		private Label label_4;

		private NumericUpDown numericUpDown_0;

		private Label label_5;

		private TextBox textBox_4;

		private ToolStripButton toolStripButton_0;

		private ToolStrip toolStrip_0;

		private ComboBox comboBox_0;

		private Label label_6;

		private ComboBox comboBox_1;

		private NumericUpDown numericUpDown_1;

		private Label label_7;

		private NumericUpDown numericUpDown_2;

		private Label label_8;
	}
}
