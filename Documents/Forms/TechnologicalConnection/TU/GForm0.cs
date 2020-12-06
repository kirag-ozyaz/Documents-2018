using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Constants;
using ControlsLbr;
using FormLbr;

namespace Documents.Forms.TechnologicalConnection.TU
{
	public partial class GForm0 : FormBase
	{
		public int? idSubPoint
		{
			get
			{
				if (this.comboBox_0.SelectedValue == null)
				{
					return null;
				}
				return new int?(Convert.ToInt32(this.comboBox_0.SelectedValue));
			}
		}

		public string SubPoint
		{
			get
			{
				return this.comboBox_0.Text;
			}
		}

		public int? idBusPoint
		{
			get
			{
				if (this.comboBox_1.SelectedValue == null)
				{
					return null;
				}
				return new int?(Convert.ToInt32(this.comboBox_1.SelectedValue));
			}
		}

		public string BusPoint
		{
			get
			{
				return this.comboBox_1.Text;
			}
		}

		public int? idCellPoint
		{
			get
			{
				if (this.comboBox_2.SelectedValue == null)
				{
					return null;
				}
				return new int?(Convert.ToInt32(this.comboBox_2.SelectedValue));
			}
		}

		public string CellPoint
		{
			get
			{
				return this.comboBox_2.Text;
			}
		}

		public int? idSubCP
		{
			get
			{
				if (this.comboBox_5.SelectedValue == null)
				{
					return null;
				}
				return new int?(Convert.ToInt32(this.comboBox_5.SelectedValue));
			}
		}

		public string SubCP
		{
			get
			{
				return this.comboBox_5.Text;
			}
		}

		public int? idBusCP
		{
			get
			{
				if (this.comboBox_4.SelectedValue == null)
				{
					return null;
				}
				return new int?(Convert.ToInt32(this.comboBox_4.SelectedValue));
			}
		}

		public string BusCP
		{
			get
			{
				return this.comboBox_4.Text;
			}
		}

		public int? idCellCP
		{
			get
			{
				if (this.comboBox_3.SelectedValue == null)
				{
					return null;
				}
				return new int?(Convert.ToInt32(this.comboBox_3.SelectedValue));
			}
		}

		public string CellCP
		{
			get
			{
				return this.comboBox_3.Text;
			}
		}

		public int? idVoltagelevel
		{
			get
			{
				if (this.comboBox_6.SelectedValue == null)
				{
					return null;
				}
				return new int?(Convert.ToInt32(this.comboBox_6.SelectedValue));
			}
		}

		public string VoltageLevel
		{
			get
			{
				return this.comboBox_6.Text;
			}
		}

		public decimal? PowerSum
		{
			get
			{
				return this.CkybfVagVQ.Value;
			}
		}

		public string DescriptionPoint
		{
			get
			{
				return this.textBox_0.Text;
			}
		}

		public GForm0()
		{
			
			
			this.method_4();
		}

		public GForm0(DataGridViewRow row)
		{
			
			
			this.method_4();
			this.dataGridViewRow_0 = row;
		}

		private void GForm0_Load(object sender, EventArgs e)
		{
			this.CkybfVagVQ.Value = null;
			this.method_1();
			this.method_2();
			this.method_3();
			if (this.dataGridViewRow_0 != null)
			{
				if (this.dataGridViewRow_0.Cells["idSubPointColumn"].Value != null && !string.IsNullOrEmpty(this.dataGridViewRow_0.Cells["idSubPointColumn"].Value.ToString()))
				{
					this.comboBox_0.SelectedValue = Convert.ToInt32(this.dataGridViewRow_0.Cells["idSubPointColumn"].Value);
				}
				if (this.dataGridViewRow_0.Cells["idBusPointColumn"].Value != null && !string.IsNullOrEmpty(this.dataGridViewRow_0.Cells["idBusPointColumn"].Value.ToString()))
				{
					this.comboBox_1.SelectedValue = Convert.ToInt32(this.dataGridViewRow_0.Cells["idBusPointColumn"].Value);
				}
				if (this.dataGridViewRow_0.Cells["idCEllPointColumn"].Value != null && !string.IsNullOrEmpty(this.dataGridViewRow_0.Cells["idCellPointColumn"].Value.ToString()))
				{
					this.comboBox_2.SelectedValue = Convert.ToInt32(this.dataGridViewRow_0.Cells["idCellPointColumn"].Value);
				}
				if (this.dataGridViewRow_0.Cells["idSubCPColumn"].Value != null && !string.IsNullOrEmpty(this.dataGridViewRow_0.Cells["idSubCPColumn"].Value.ToString()))
				{
					this.comboBox_5.SelectedValue = Convert.ToInt32(this.dataGridViewRow_0.Cells["idSubCPColumn"].Value);
				}
				if (this.dataGridViewRow_0.Cells["idBusCPColumn"].Value != null && !string.IsNullOrEmpty(this.dataGridViewRow_0.Cells["idBusCPColumn"].Value.ToString()))
				{
					this.comboBox_4.SelectedValue = Convert.ToInt32(this.dataGridViewRow_0.Cells["idBusCPColumn"].Value);
				}
				if (this.dataGridViewRow_0.Cells["idCellCPColumn"].Value != null && !string.IsNullOrEmpty(this.dataGridViewRow_0.Cells["idCellCPColumn"].Value.ToString()))
				{
					this.comboBox_3.SelectedValue = Convert.ToInt32(this.dataGridViewRow_0.Cells["idCellCPColumn"].Value);
				}
				if (this.dataGridViewRow_0.Cells["voltageLevelDgvColumn"].Value != null && !string.IsNullOrEmpty(this.dataGridViewRow_0.Cells["voltageLevelDgvColumn"].Value.ToString()))
				{
					this.comboBox_6.SelectedValue = Convert.ToInt32(this.dataGridViewRow_0.Cells["voltageLevelDgvColumn"].Value);
				}
				if (this.dataGridViewRow_0.Cells["powerSumDgvColumn"].Value != null && !string.IsNullOrEmpty(this.dataGridViewRow_0.Cells["powerSumDgvColumn"].Value.ToString()))
				{
					this.CkybfVagVQ.Value = new decimal?(Convert.ToDecimal(this.dataGridViewRow_0.Cells["powerSumDgvColumn"].Value));
				}
				if (this.dataGridViewRow_0.DataGridView.Columns.Contains("descriptionDgvColumn") && this.dataGridViewRow_0.Cells["descriptionDgvColumn"].Value != null && !string.IsNullOrEmpty(this.dataGridViewRow_0.Cells["descriptionDgvColumn"].Value.ToString()))
				{
					this.textBox_0.Text = this.dataGridViewRow_0.Cells["descriptionDgvColumn"].Value.ToString();
				}
			}
		}

		private DataTable method_0()
		{
			DataTable dataTable = new DataTable("vSchm_ObjList");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("name", typeof(string));
			dataTable.Columns.Add("typeCodeSocr", typeof(string));
			DataColumn dataColumn = new DataColumn("fullNameSub", typeof(string));
			dataColumn.Expression = "typeCodeSocr + '-' + name";
			dataTable.Columns.Add(dataColumn);
			dataColumn = new DataColumn("fullNameBus", typeof(string));
			dataColumn.Expression = "typeCodeSocr + ' ' + name";
			dataTable.Columns.Add(dataColumn);
			return dataTable;
		}

		private void method_1()
		{
			DataTable dataTable = this.method_0();
			string text = "";
			foreach (object obj in Enum.GetValues(typeof(SchmTypeSubstation)))
			{
				SchmTypeSubstation schmTypeSubstation = (SchmTypeSubstation)obj;
				if (schmTypeSubstation != SchmTypeSubstation.CP)
				{
					if (string.IsNullOrEmpty(text))
					{
						int num = (int)schmTypeSubstation;
						text = num.ToString();
					}
					else
					{
						string str = text;
						string str2 = ",";
						int num = (int)schmTypeSubstation;
						text = str + str2 + num.ToString();
					}
				}
			}
			base.SelectSqlData(dataTable, true, "where typeCodeId in (" + text + ") and deleted = 0 order by typeCodeSocr, name", null, false, 0);
			this.comboBox_0.SelectedIndexChanged -= this.comboBox_0_SelectedIndexChanged;
			this.comboBox_0.DataSource = dataTable;
			this.comboBox_0.DisplayMember = "fullNameSub";
			this.comboBox_0.ValueMember = "id";
			this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
			this.comboBox_0.SelectedIndex = -1;
		}

		private void method_2()
		{
			DataTable dataTable = this.method_0();
			base.SelectSqlData(dataTable, true, "where typeCodeId = " + 536.ToString() + " and deleted = 0 order by typeCodeSocr, name", null, false, 0);
			this.comboBox_5.SelectedIndexChanged -= this.comboBox_5_SelectedIndexChanged;
			this.comboBox_5.DataSource = dataTable;
			this.comboBox_5.DisplayMember = "fullNameSub";
			this.comboBox_5.ValueMember = "id";
			this.comboBox_5.SelectedIndexChanged += this.comboBox_5_SelectedIndexChanged;
			this.comboBox_5.SelectedIndex = -1;
		}

		private void method_3()
		{
			Class10.Class14 @class = new Class10.Class14();
			base.SelectSqlData(@class, true, " where ParentKey like ';VoltageLevels;%' and isGroup = 0 and deleted = 0 order by value", null, false, 0);
			this.comboBox_6.DataSource = @class;
			this.comboBox_6.DisplayMember = "name";
			this.comboBox_6.ValueMember = "id";
			this.comboBox_6.SelectedIndex = -1;
		}

		private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_0.SelectedIndex != -1 && this.comboBox_0.SelectedValue != null)
			{
				int num = Convert.ToInt32(this.comboBox_0.SelectedValue);
				DataTable dataTable = this.method_0();
				string text = "";
				foreach (object obj in Enum.GetValues(typeof(SchmTypeBus)))
				{
					SchmTypeBus schmTypeBus = (SchmTypeBus)obj;
					if (string.IsNullOrEmpty(text))
					{
						int num2 = (int)schmTypeBus;
						text = num2.ToString();
					}
					else
					{
						string str = text;
						string str2 = ",";
						int num2 = (int)schmTypeBus;
						text = str + str2 + num2.ToString();
					}
				}
				base.SelectSqlData(dataTable, true, string.Concat(new string[]
				{
					"where idParent = ",
					num.ToString(),
					" and typeCodeId in (",
					text,
					") and deleted = 0 order by typeCodeSocr, name"
				}), null, false, 0);
				this.comboBox_1.SelectedIndexChanged -= this.comboBox_1_SelectedIndexChanged;
				this.comboBox_1.DataSource = dataTable;
				this.comboBox_1.DisplayMember = "fullNameBus";
				this.comboBox_1.ValueMember = "id";
				this.comboBox_1.SelectedIndexChanged += this.comboBox_1_SelectedIndexChanged;
				this.comboBox_1.SelectedIndex = -1;
				return;
			}
			this.comboBox_1.SelectedIndexChanged -= this.comboBox_1_SelectedIndexChanged;
			this.comboBox_1.DataSource = null;
			this.comboBox_1.Items.Clear();
		}

		private void comboBox_5_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_5.SelectedIndex != -1 && this.comboBox_5.SelectedValue != null)
			{
				int num = Convert.ToInt32(this.comboBox_5.SelectedValue);
				DataTable dataTable = this.method_0();
				string text = "";
				foreach (object obj in Enum.GetValues(typeof(SchmTypeBus)))
				{
					SchmTypeBus schmTypeBus = (SchmTypeBus)obj;
					if (string.IsNullOrEmpty(text))
					{
						int num2 = (int)schmTypeBus;
						text = num2.ToString();
					}
					else
					{
						string str = text;
						string str2 = ",";
						int num2 = (int)schmTypeBus;
						text = str + str2 + num2.ToString();
					}
				}
				base.SelectSqlData(dataTable, true, string.Concat(new string[]
				{
					"where idParent = ",
					num.ToString(),
					" and typeCodeId in (",
					text,
					") and deleted = 0 order by typeCodeSocr, name"
				}), null, false, 0);
				this.comboBox_4.SelectedIndexChanged -= this.comboBox_4_SelectedIndexChanged;
				this.comboBox_4.DataSource = dataTable;
				this.comboBox_4.DisplayMember = "fullNameBus";
				this.comboBox_4.ValueMember = "id";
				this.comboBox_4.SelectedIndexChanged += this.comboBox_4_SelectedIndexChanged;
				this.comboBox_4.SelectedIndex = -1;
				return;
			}
			this.comboBox_4.SelectedIndexChanged -= this.comboBox_4_SelectedIndexChanged;
			this.comboBox_4.DataSource = null;
			this.comboBox_4.Items.Clear();
		}

		private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_1.SelectedIndex != -1 && this.comboBox_1.SelectedValue != null)
			{
				string str = this.comboBox_1.SelectedValue.ToString();
				DataTable dataTable = new DataTable("vSchm_TreeCellLine");
				dataTable.Columns.Add("id", typeof(int));
				dataTable.Columns.Add("FullName", typeof(string));
				this.comboBox_2.DataSource = dataTable;
				this.comboBox_2.DisplayMember = "FullName";
				this.comboBox_2.ValueMember = "id";
				base.SelectSqlData(dataTable, true, " where ParentLink = " + str + " order by fullname", null, false, 0);
				this.comboBox_2.SelectedIndex = -1;
				return;
			}
			this.comboBox_2.DataSource = null;
			this.comboBox_2.Items.Clear();
		}

		private void comboBox_4_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_4.SelectedIndex != -1 && this.comboBox_4.SelectedValue != null)
			{
				string str = this.comboBox_4.SelectedValue.ToString();
				DataTable dataTable = new DataTable("vSchm_TreeCellLine");
				dataTable.Columns.Add("id", typeof(int));
				dataTable.Columns.Add("FullName", typeof(string));
				this.comboBox_3.DataSource = dataTable;
				this.comboBox_3.DisplayMember = "FullName";
				this.comboBox_3.ValueMember = "id";
				base.SelectSqlData(dataTable, true, " where ParentLink = " + str + " order by fullname", null, false, 0);
				this.comboBox_3.SelectedIndex = -1;
				return;
			}
			this.comboBox_3.DataSource = null;
			this.comboBox_3.Items.Clear();
		}

		private void method_4()
		{
			this.AyhbZdlJo1 = new Label();
			this.comboBox_0 = new ComboBox();
			this.label_0 = new Label();
			this.comboBox_1 = new ComboBox();
			this.label_1 = new Label();
			this.comboBox_2 = new ComboBox();
			this.comboBox_3 = new ComboBox();
			this.label_2 = new Label();
			this.comboBox_4 = new ComboBox();
			this.label_3 = new Label();
			this.comboBox_5 = new ComboBox();
			this.label_4 = new Label();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.fkabuobEoP = new Label();
			this.comboBox_6 = new ComboBox();
			this.label_5 = new Label();
			this.CkybfVagVQ = new NullableNumericUpDown();
			this.label_6 = new Label();
			this.textBox_0 = new TextBox();
			((ISupportInitialize)this.CkybfVagVQ).BeginInit();
			base.SuspendLayout();
			this.AyhbZdlJo1.AutoSize = true;
			this.AyhbZdlJo1.Location = new Point(12, 9);
			this.AyhbZdlJo1.Name = "label1";
			this.AyhbZdlJo1.Size = new Size(42, 13);
			this.AyhbZdlJo1.TabIndex = 0;
			this.AyhbZdlJo1.Text = "ТП/РП";
			this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_0.BackColor = SystemColors.Window;
			this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(15, 25);
			this.comboBox_0.Name = "cmbSubPoint";
			this.comboBox_0.Size = new Size(121, 21);
			this.comboBox_0.TabIndex = 1;
			this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(163, 9);
			this.label_0.Name = "label2";
			this.label_0.Size = new Size(34, 13);
			this.label_0.TabIndex = 2;
			this.label_0.Text = "Шина";
			this.comboBox_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_1.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_1.FormattingEnabled = true;
			this.comboBox_1.Location = new Point(166, 25);
			this.comboBox_1.Name = "cmbBusPoint";
			this.comboBox_1.Size = new Size(121, 21);
			this.comboBox_1.TabIndex = 3;
			this.comboBox_1.SelectedIndexChanged += this.comboBox_1_SelectedIndexChanged;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(305, 9);
			this.label_1.Name = "label3";
			this.label_1.Size = new Size(44, 13);
			this.label_1.TabIndex = 4;
			this.label_1.Text = "Ячейка";
			this.comboBox_2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_2.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_2.FormattingEnabled = true;
			this.comboBox_2.Location = new Point(308, 25);
			this.comboBox_2.Name = "cmbCellPoint";
			this.comboBox_2.Size = new Size(121, 21);
			this.comboBox_2.TabIndex = 5;
			this.comboBox_3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_3.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_3.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_3.FormattingEnabled = true;
			this.comboBox_3.Location = new Point(308, 71);
			this.comboBox_3.Name = "cmbCellCP";
			this.comboBox_3.Size = new Size(121, 21);
			this.comboBox_3.TabIndex = 11;
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(305, 55);
			this.label_2.Name = "label4";
			this.label_2.Size = new Size(44, 13);
			this.label_2.TabIndex = 10;
			this.label_2.Text = "Ячейка";
			this.comboBox_4.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_4.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_4.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_4.FormattingEnabled = true;
			this.comboBox_4.Location = new Point(166, 71);
			this.comboBox_4.Name = "cmbBusCP";
			this.comboBox_4.Size = new Size(121, 21);
			this.comboBox_4.TabIndex = 9;
			this.comboBox_4.SelectedIndexChanged += this.comboBox_4_SelectedIndexChanged;
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(163, 55);
			this.label_3.Name = "label5";
			this.label_3.Size = new Size(34, 13);
			this.label_3.TabIndex = 8;
			this.label_3.Text = "Шина";
			this.comboBox_5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_5.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_5.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_5.FormattingEnabled = true;
			this.comboBox_5.Location = new Point(15, 71);
			this.comboBox_5.Name = "cmbSubCP";
			this.comboBox_5.Size = new Size(121, 21);
			this.comboBox_5.TabIndex = 7;
			this.comboBox_5.SelectedIndexChanged += this.comboBox_5_SelectedIndexChanged;
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(12, 55);
			this.label_4.Name = "label6";
			this.label_4.Size = new Size(23, 13);
			this.label_4.TabIndex = 6;
			this.label_4.Text = "ЦП";
			this.button_0.DialogResult = DialogResult.OK;
			this.button_0.Location = new Point(15, 250);
			this.button_0.Name = "buttonOK";
			this.button_0.Size = new Size(75, 23);
			this.button_0.TabIndex = 12;
			this.button_0.Text = "ОК";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_1.DialogResult = DialogResult.Cancel;
			this.button_1.Location = new Point(354, 250);
			this.button_1.Name = "buttonCancel";
			this.button_1.Size = new Size(75, 23);
			this.button_1.TabIndex = 13;
			this.button_1.Text = "Отмена";
			this.button_1.UseVisualStyleBackColor = true;
			this.fkabuobEoP.AutoSize = true;
			this.fkabuobEoP.Location = new Point(12, 106);
			this.fkabuobEoP.Name = "label7";
			this.fkabuobEoP.Size = new Size(116, 13);
			this.fkabuobEoP.TabIndex = 14;
			this.fkabuobEoP.Text = "Уровень напряжения";
			this.comboBox_6.FormattingEnabled = true;
			this.comboBox_6.Location = new Point(15, 122);
			this.comboBox_6.Name = "cmbVoltageLevel";
			this.comboBox_6.Size = new Size(182, 21);
			this.comboBox_6.TabIndex = 15;
			this.label_5.AutoSize = true;
			this.label_5.Location = new Point(226, 106);
			this.label_5.Name = "label8";
			this.label_5.Size = new Size(60, 13);
			this.label_5.TabIndex = 17;
			this.label_5.Text = "Мощность";
			this.CkybfVagVQ.DecimalPlaces = 2;
			this.CkybfVagVQ.Location = new Point(218, 123);
			NumericUpDown ckybfVagVQ = this.CkybfVagVQ;
			int[] array = new int[4];
			array[0] = 99999;
			ckybfVagVQ.Maximum = new decimal(array);
			this.CkybfVagVQ.Name = "numericUpDownPowerSum";
			this.CkybfVagVQ.Size = new Size(211, 20);
			this.CkybfVagVQ.TabIndex = 18;
			this.CkybfVagVQ.Value = null;
			this.label_6.AutoSize = true;
			this.label_6.Location = new Point(12, 146);
			this.label_6.Name = "label9";
			this.label_6.Size = new Size(169, 13);
			this.label_6.TabIndex = 19;
			this.label_6.Text = "Описание точки присоединения";
			this.textBox_0.Location = new Point(15, 162);
			this.textBox_0.Multiline = true;
			this.textBox_0.Name = "txtDescriptionPoint";
			this.textBox_0.Size = new Size(414, 82);
			this.textBox_0.TabIndex = 20;
			base.AcceptButton = this.button_0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.button_1;
			base.ClientSize = new Size(439, 285);
			base.Controls.Add(this.textBox_0);
			base.Controls.Add(this.label_6);
			base.Controls.Add(this.CkybfVagVQ);
			base.Controls.Add(this.label_5);
			base.Controls.Add(this.comboBox_6);
			base.Controls.Add(this.fkabuobEoP);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.button_0);
			base.Controls.Add(this.comboBox_3);
			base.Controls.Add(this.label_2);
			base.Controls.Add(this.comboBox_4);
			base.Controls.Add(this.label_3);
			base.Controls.Add(this.comboBox_5);
			base.Controls.Add(this.label_4);
			base.Controls.Add(this.comboBox_2);
			base.Controls.Add(this.label_1);
			base.Controls.Add(this.comboBox_1);
			base.Controls.Add(this.label_0);
			base.Controls.Add(this.comboBox_0);
			base.Controls.Add(this.AyhbZdlJo1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormLinkTUAndSchmObj";
			this.Text = "Выбор точки присоединения";
			base.Load += this.GForm0_Load;
			((ISupportInitialize)this.CkybfVagVQ).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private DataGridViewRow dataGridViewRow_0;

		private Label AyhbZdlJo1;

		private ComboBox comboBox_0;

		private Label label_0;

		private ComboBox comboBox_1;

		private Label label_1;

		private ComboBox comboBox_2;

		private ComboBox comboBox_3;

		private Label label_2;

		private ComboBox comboBox_4;

		private Label label_3;

		private ComboBox comboBox_5;

		private Label label_4;

		private Button button_0;

		private Button button_1;

		private Label fkabuobEoP;

		private ComboBox comboBox_6;

		private Label label_5;

		private NullableNumericUpDown CkybfVagVQ;

		private Label label_6;

		private TextBox textBox_0;
	}
}
