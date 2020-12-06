using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using FormLbr;

internal partial class Form65 : FormBase
{
	[CompilerGenerated]
	internal int? method_0()
	{
		return this.nullable_0;
	}

	[CompilerGenerated]
	internal void method_1(int? nullable_1)
	{
		this.nullable_0 = nullable_1;
	}

	internal string NameKL { get; set; }

	internal int method_2()
	{
		return this.int_1;
	}

	internal void method_3(int int_2)
	{
		this.int_1 = int_2;
	}

	public Form65()
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		
		this.method_4();
	}

	public Form65(int int_2, int int_3)
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		
		this.method_4();
		this.int_0 = int_3;
		this.int_1 = int_2;
	}

	private void Form65_Load(object sender, EventArgs e)
	{
		DataTable dataTable = new DataTable("tSChm_ObjList");
		dataTable.Columns.Add("id", typeof(int));
		dataTable.Columns.Add("name", typeof(string));
		base.SelectSqlData(dataTable, true, " where typeCodeid = 546 and deleted = 0 order by name", null, false, 0);
		this.bindingSource_0.DataSource = dataTable;
		this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
		if (this.int_0 != -1)
		{
			if (this.int_1 != -1)
			{
				base.SelectSqlData(this.class130_0, this.class130_0.tJ_ExcavationSchmObj, true, "where id = " + this.int_1);
				base.SelectSqlData(this.class130_0, this.class130_0.vJ_ExcavationSchmObj, true, "where id = " + this.int_1);
				if (this.class130_0.tJ_ExcavationSchmObj.Rows.Count > 0)
				{
					if (this.class130_0.tJ_ExcavationSchmObj.Rows[0]["idKL"] == DBNull.Value)
					{
						this.radioButton_1.Checked = true;
						this.textBox_1.Text = this.class130_0.tJ_ExcavationSchmObj.Rows[0]["nameKL"].ToString();
						return;
					}
					this.textBox_0.Text = this.class130_0.vJ_ExcavationSchmObj.Rows[0]["name"].ToString();
					return;
				}
			}
		}
		else
		{
			if (this.method_0() != null)
			{
				this.textBox_0.Text = this.NameKL;
				return;
			}
			if (!string.IsNullOrEmpty(this.NameKL))
			{
				this.radioButton_1.Checked = true;
				this.textBox_1.Text = this.NameKL;
			}
		}
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		this.bindingSource_0.Filter = "Name like '%" + this.textBox_0.Text + "%'";
	}

	private void radioButton_0_CheckedChanged(object sender, EventArgs e)
	{
		if (this.radioButton_0.Checked)
		{
			this.textBox_0.Enabled = true;
			this.dataGridViewExcelFilter_0.Enabled = true;
			this.textBox_1.Enabled = false;
			if (string.IsNullOrEmpty(this.textBox_0.Text))
			{
				this.textBox_0.Text = this.textBox_1.Text;
				return;
			}
		}
		else
		{
			this.textBox_0.Enabled = false;
			this.dataGridViewExcelFilter_0.Enabled = false;
			this.textBox_1.Enabled = true;
			if (string.IsNullOrEmpty(this.textBox_1.Text))
			{
				this.textBox_1.Text = this.textBox_0.Text;
			}
		}
	}

	private void Form65_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.radioButton_0.Checked)
			{
				if (this.dataGridViewExcelFilter_0.CurrentRow == null)
				{
					MessageBox.Show("Не выбрана кабельная линия");
					e.Cancel = true;
					return;
				}
				if (this.int_1 == -1)
				{
					DataRow dataRow = this.class130_0.tJ_ExcavationSchmObj.NewRow();
					dataRow["idExcavation"] = this.int_0;
					dataRow["NameKL"] = (this.NameKL = this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_1.Name].Value.ToString());
					DataRow dataRow2 = dataRow;
					string columnName = "idKL";
					int? num = new int?(Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value));
					this.method_1(num);
					dataRow2[columnName] = num;
					this.class130_0.tJ_ExcavationSchmObj.Rows.Add(dataRow);
					if (this.int_0 != -1)
					{
						this.int_1 = base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationSchmObj);
						return;
					}
				}
				else
				{
					if (this.int_0 != -1)
					{
						this.class130_0.tJ_ExcavationSchmObj.Rows[0]["idExcavation"] = this.int_0;
						this.class130_0.tJ_ExcavationSchmObj.Rows[0]["NameKL"] = (this.NameKL = this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_1.Name].Value.ToString());
						DataRow dataRow3 = this.class130_0.tJ_ExcavationSchmObj.Rows[0];
						string columnName2 = "idKL";
						int? num = new int?(Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value));
						this.method_1(num);
						dataRow3[columnName2] = num;
						this.class130_0.tJ_ExcavationSchmObj.Rows[0].EndEdit();
						base.UpdateSqlData(this.class130_0, this.class130_0.tJ_ExcavationSchmObj);
						return;
					}
					this.NameKL = this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_1.Name].Value.ToString();
					this.method_1(new int?(Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value)));
					return;
				}
			}
			else
			{
				if (string.IsNullOrEmpty(this.textBox_1.Text))
				{
					MessageBox.Show("Не введено имя кабельной линии");
					e.Cancel = true;
					return;
				}
				if (this.int_1 == -1)
				{
					DataRow dataRow4 = this.class130_0.tJ_ExcavationSchmObj.NewRow();
					dataRow4["idExcavation"] = this.int_0;
					dataRow4["NameKL"] = (this.NameKL = this.textBox_1.Text);
					int? num = null;
					this.method_1(num);
					this.class130_0.tJ_ExcavationSchmObj.Rows.Add(dataRow4);
					if (this.int_0 != -1)
					{
						this.int_1 = base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationSchmObj);
						return;
					}
				}
				else
				{
					int? num = null;
					this.method_1(num);
					if (this.int_0 != -1)
					{
						this.class130_0.tJ_ExcavationSchmObj.Rows[0]["idExcavation"] = this.int_0;
						this.class130_0.tJ_ExcavationSchmObj.Rows[0]["NameKL"] = (this.NameKL = this.textBox_1.Text);
						this.class130_0.tJ_ExcavationSchmObj.Rows[0]["idKL"] = DBNull.Value;
						this.class130_0.tJ_ExcavationSchmObj.Rows[0].EndEdit();
						base.UpdateSqlData(this.class130_0, this.class130_0.tJ_ExcavationSchmObj);
						return;
					}
					this.NameKL = this.textBox_1.Text;
				}
			}
		}
	}

	private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		base.Close();
	}

	private void method_4()
	{
		this.icontainer_0 = new Container();
		this.radioButton_0 = new RadioButton();
		this.textBox_0 = new TextBox();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.radioButton_1 = new RadioButton();
		this.textBox_1 = new TextBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class130_0 = new DataSetExcavation();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class130_0).BeginInit();
		base.SuspendLayout();
		this.radioButton_0.AutoSize = true;
		this.radioButton_0.Checked = true;
		this.radioButton_0.Location = new Point(12, 12);
		this.radioButton_0.Name = "radioButtonExistKL";
		this.radioButton_0.Size = new Size(84, 17);
		this.radioButton_0.TabIndex = 0;
		this.radioButton_0.TabStop = true;
		this.radioButton_0.Text = "КЛ из базы";
		this.radioButton_0.UseVisualStyleBackColor = true;
		this.radioButton_0.CheckedChanged += this.radioButton_0_CheckedChanged;
		this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.Location = new Point(103, 9);
		this.textBox_0.Name = "textBoxFilter";
		this.textBox_0.Size = new Size(318, 20);
		this.textBox_0.TabIndex = 1;
		this.textBox_0.TextChanged += this.textBox_0_TextChanged;
		this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToResizeColumns = false;
		this.dataGridViewExcelFilter_0.AllowUserToResizeRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToVisibleColumns = false;
		this.dataGridViewExcelFilter_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1
		});
		this.dataGridViewExcelFilter_0.Location = new Point(1, 35);
		this.dataGridViewExcelFilter_0.MultiSelect = false;
		this.dataGridViewExcelFilter_0.Name = "dgvKL";
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.RowHeadersVisible = false;
		this.dataGridViewExcelFilter_0.RowHeadersWidth = 21;
		this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_0.Size = new Size(430, 209);
		this.dataGridViewExcelFilter_0.TabIndex = 2;
		this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
		this.radioButton_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.radioButton_1.AutoSize = true;
		this.radioButton_1.Location = new Point(12, 253);
		this.radioButton_1.Name = "radioButtonNewName";
		this.radioButton_1.Size = new Size(114, 17);
		this.radioButton_1.TabIndex = 3;
		this.radioButton_1.TabStop = true;
		this.radioButton_1.Text = "Собственное имя";
		this.radioButton_1.UseVisualStyleBackColor = true;
		this.textBox_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_1.Enabled = false;
		this.textBox_1.Location = new Point(132, 250);
		this.textBox_1.Name = "textBoxName";
		this.textBox_1.Size = new Size(289, 20);
		this.textBox_1.TabIndex = 4;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(12, 276);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 5;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(344, 276);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 6;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_0.HeaderText = "id";
		this.dataGridViewTextBoxColumn_0.Name = "idSgvColumn";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "name";
		this.dataGridViewTextBoxColumn_1.HeaderText = "Имя КЛ";
		this.dataGridViewTextBoxColumn_1.Name = "nameDgvColumn";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.class130_0.DataSetName = "DataSetExcavation";
		this.class130_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(431, 311);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.textBox_1);
		base.Controls.Add(this.radioButton_1);
		base.Controls.Add(this.dataGridViewExcelFilter_0);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.radioButton_0);
		base.Name = "FormFindKLExcavation";
		this.Text = "Кабельные линии";
		base.FormClosing += this.Form65_FormClosing;
		base.Load += this.Form65_Load;
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class130_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private int int_0;

	private int int_1;

	[CompilerGenerated]
	private int? nullable_0;

	[CompilerGenerated]
	private string string_0;

	private RadioButton radioButton_0;

	private TextBox textBox_0;

	private DataGridViewExcelFilter dataGridViewExcelFilter_0;

	private RadioButton radioButton_1;

	private TextBox textBox_1;

	private Button button_0;

	private Button button_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private BindingSource bindingSource_0;

	private DataSetExcavation class130_0;
}
