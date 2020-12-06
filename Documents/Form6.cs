using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using FormLbr;

internal partial class Form6 : FormBase
{
	internal Form6()
	{
		
		
		this.method_3();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (this.dataGridViewExcelFilter_0.CurrentRow != null && this.dataGridViewExcelFilter_1.CurrentRow != null && MessageBox.Show("Вы действительно хотите объединить выбранных абонентов?", "Объединение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString() + ";Connection Timeout=1000"))
			{
				sqlConnection.Open();
				using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
				{
					try
					{
						using (SqlCommand sqlCommand = new SqlCommand(Class7.smethod_2("Service.MergeAbn.sql"), sqlConnection))
						{
							sqlCommand.Transaction = sqlTransaction;
							sqlCommand.Parameters.Add("idParentAbn", SqlDbType.Int).Value = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
							sqlCommand.Parameters.Add("idChildAbn", SqlDbType.Int).Value = Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_1.Name].Value);
							sqlCommand.ExecuteNonQuery();
						}
						sqlTransaction.Commit();
						MessageBox.Show("Объединение абонетов прошло успешно");
						this.method_0();
						this.method_1();
					}
					catch (Exception ex)
					{
						sqlTransaction.Rollback();
						MessageBox.Show(ex.Message, ex.Source);
					}
				}
			}
		}
	}

	private void method_0()
	{
		this.method_2(this.dataSet_0.Tables[0], this.radioButton_1.Checked, this.textBox_1.Text, this.textBox_0.Text);
	}

	private void method_1()
	{
		this.method_2(this.dataSet_1.Tables[0], this.radioButton_3.Checked, this.textBox_3.Text, this.textBox_2.Text);
	}

	private void method_2(DataTable dataTable_1, bool bool_0, string string_0, string string_1)
	{
		string str = bool_0 ? " where deleted = 0 and typeAbn in (230,207,1038,231) " : " where deleted = 0 and TypeAbn in (206,1037,253) ";
		if (!string.IsNullOrEmpty(string_0))
		{
			str = str + " and codeAbonent = " + string_0;
		}
		if (!string.IsNullOrEmpty(string_1))
		{
			str = str + " and name like '%" + string_1 + "%' ";
		}
		if (!bool_0 && string.IsNullOrEmpty(string_0) && string.IsNullOrEmpty(string_1))
		{
			dataTable_1.Clear();
			return;
		}
		base.SelectSqlData(dataTable_1, true, str + " order by codeAbonent", null, false, 0);
	}

	private void radioButton_0_CheckedChanged(object sender, EventArgs e)
	{
		this.method_0();
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.textBox_1.Text))
		{
			this.textBox_0.Text = "";
		}
		this.method_0();
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.textBox_0.Text))
		{
			this.textBox_1.Text = "";
		}
		this.method_0();
	}

	private void radioButton_2_CheckedChanged(object sender, EventArgs e)
	{
		this.method_1();
	}

	private void textBox_3_TextChanged(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.textBox_3.Text))
		{
			this.textBox_2.Text = "";
		}
		this.method_1();
	}

	private void textBox_2_TextChanged(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.textBox_3.Text))
		{
			this.textBox_2.Text = "";
		}
		this.method_1();
	}

	private void Form6_Load(object sender, EventArgs e)
	{
		this.method_0();
		this.method_1();
	}

	private void method_3()
	{
		this.icontainer_0 = new Container();
		this.button_0 = new Button();
		this.splitContainer_0 = new SplitContainer();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.dataSet_0 = new DataSet();
		this.WgoWlVexjj = new DataTable();
		this.dataColumn_0 = new DataColumn();
		this.dataColumn_1 = new DataColumn();
		this.dataColumn_2 = new DataColumn();
		this.dataColumn_3 = new DataColumn();
		this.textBox_0 = new TextBox();
		this.label_2 = new Label();
		this.textBox_1 = new TextBox();
		this.label_3 = new Label();
		this.label_4 = new Label();
		this.radioButton_0 = new RadioButton();
		this.radioButton_1 = new RadioButton();
		this.label_0 = new Label();
		this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
		this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_4 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_5 = new DataGridViewFilterTextBoxColumn();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.dataSet_1 = new DataSet();
		this.dataTable_0 = new DataTable();
		this.dataColumn_4 = new DataColumn();
		this.dataColumn_5 = new DataColumn();
		this.dataColumn_6 = new DataColumn();
		this.dataColumn_7 = new DataColumn();
		this.textBox_2 = new TextBox();
		this.label_5 = new Label();
		this.textBox_3 = new TextBox();
		this.label_6 = new Label();
		this.label_7 = new Label();
		this.radioButton_2 = new RadioButton();
		this.radioButton_3 = new RadioButton();
		this.label_1 = new Label();
		this.splitContainer_0.Panel1.SuspendLayout();
		this.splitContainer_0.Panel2.SuspendLayout();
		this.splitContainer_0.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.dataSet_0).BeginInit();
		((ISupportInitialize)this.WgoWlVexjj).BeginInit();
		((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		((ISupportInitialize)this.dataSet_1).BeginInit();
		((ISupportInitialize)this.dataTable_0).BeginInit();
		base.SuspendLayout();
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_0.Location = new Point(585, 427);
		this.button_0.Name = "button1";
		this.button_0.Size = new Size(147, 23);
		this.button_0.TabIndex = 0;
		this.button_0.Text = "Объединить абонетов";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.splitContainer_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.splitContainer_0.Location = new Point(0, -1);
		this.splitContainer_0.Name = "splitContainer1";
		this.splitContainer_0.Panel1.Controls.Add(this.dataGridViewExcelFilter_0);
		this.splitContainer_0.Panel1.Controls.Add(this.textBox_0);
		this.splitContainer_0.Panel1.Controls.Add(this.label_2);
		this.splitContainer_0.Panel1.Controls.Add(this.textBox_1);
		this.splitContainer_0.Panel1.Controls.Add(this.label_3);
		this.splitContainer_0.Panel1.Controls.Add(this.label_4);
		this.splitContainer_0.Panel1.Controls.Add(this.radioButton_0);
		this.splitContainer_0.Panel1.Controls.Add(this.radioButton_1);
		this.splitContainer_0.Panel1.Controls.Add(this.label_0);
		this.splitContainer_0.Panel2.Controls.Add(this.dataGridViewExcelFilter_1);
		this.splitContainer_0.Panel2.Controls.Add(this.textBox_2);
		this.splitContainer_0.Panel2.Controls.Add(this.label_5);
		this.splitContainer_0.Panel2.Controls.Add(this.textBox_3);
		this.splitContainer_0.Panel2.Controls.Add(this.label_6);
		this.splitContainer_0.Panel2.Controls.Add(this.label_7);
		this.splitContainer_0.Panel2.Controls.Add(this.radioButton_2);
		this.splitContainer_0.Panel2.Controls.Add(this.radioButton_3);
		this.splitContainer_0.Panel2.Controls.Add(this.label_1);
		this.splitContainer_0.Size = new Size(745, 413);
		this.splitContainer_0.SplitterDistance = 356;
		this.splitContainer_0.TabIndex = 1;
		this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewFilterTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewFilterTextBoxColumn_1,
			this.dataGridViewFilterTextBoxColumn_2
		});
		this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
		this.dataGridViewExcelFilter_0.Location = new Point(0, 120);
		this.dataGridViewExcelFilter_0.MultiSelect = false;
		this.dataGridViewExcelFilter_0.Name = "dgvAbn1";
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_0.Size = new Size(357, 293);
		this.dataGridViewExcelFilter_0.TabIndex = 8;
		this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "codeAbonent";
		this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Код";
		this.dataGridViewFilterTextBoxColumn_0.Name = "codeAbonentDataGridViewTextBoxColumn1";
		this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_0.HeaderText = "id";
		this.dataGridViewTextBoxColumn_0.Name = "idAbn1DgvColumn";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewFilterTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "name";
		this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Имя";
		this.dataGridViewFilterTextBoxColumn_1.Name = "nameDataGridViewTextBoxColumn1";
		this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "typeNameSocr";
		this.dataGridViewFilterTextBoxColumn_2.FillWeight = 70f;
		this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Тип";
		this.dataGridViewFilterTextBoxColumn_2.Name = "typeNameSocrDataGridViewTextBoxColumn1";
		this.dataGridViewFilterTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_2.Width = 70;
		this.bindingSource_0.DataMember = "vAbn";
		this.bindingSource_0.DataSource = this.dataSet_0;
		this.dataSet_0.DataSetName = "NewDataSet";
		this.dataSet_0.Tables.AddRange(new DataTable[]
		{
			this.WgoWlVexjj
		});
		this.WgoWlVexjj.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_0,
			this.dataColumn_1,
			this.dataColumn_2,
			this.dataColumn_3
		});
		this.WgoWlVexjj.TableName = "vAbn";
		this.dataColumn_0.ColumnName = "id";
		this.dataColumn_0.DataType = typeof(int);
		this.dataColumn_1.ColumnName = "codeAbonent";
		this.dataColumn_1.DataType = typeof(int);
		this.dataColumn_2.ColumnName = "name";
		this.dataColumn_3.ColumnName = "typeNameSocr";
		this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.Location = new Point(103, 94);
		this.textBox_0.Name = "txtName1";
		this.textBox_0.Size = new Size(250, 20);
		this.textBox_0.TabIndex = 7;
		this.textBox_0.TextChanged += this.textBox_0_TextChanged;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(100, 78);
		this.label_2.Name = "label6";
		this.label_2.Size = new Size(119, 13);
		this.label_2.TabIndex = 6;
		this.label_2.Text = "Наименование (ФИО)";
		this.textBox_1.Location = new Point(15, 94);
		this.textBox_1.Name = "txtCode1";
		this.textBox_1.Size = new Size(79, 20);
		this.textBox_1.TabIndex = 5;
		this.textBox_1.TextChanged += this.textBox_1_TextChanged;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 78);
		this.label_3.Name = "label5";
		this.label_3.Size = new Size(26, 13);
		this.label_3.TabIndex = 4;
		this.label_3.Text = "Код";
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(12, 56);
		this.label_4.Name = "label3";
		this.label_4.Size = new Size(47, 13);
		this.label_4.TabIndex = 3;
		this.label_4.Text = "Фильтр";
		this.radioButton_0.AutoSize = true;
		this.radioButton_0.Location = new Point(156, 36);
		this.radioButton_0.Name = "rbFL1";
		this.radioButton_0.Size = new Size(116, 17);
		this.radioButton_0.TabIndex = 2;
		this.radioButton_0.Text = "Физическое лицо";
		this.radioButton_0.UseVisualStyleBackColor = true;
		this.radioButton_0.CheckedChanged += this.radioButton_0_CheckedChanged;
		this.radioButton_1.AutoSize = true;
		this.radioButton_1.Checked = true;
		this.radioButton_1.Location = new Point(15, 36);
		this.radioButton_1.Name = "rbLegal1";
		this.radioButton_1.Size = new Size(120, 17);
		this.radioButton_1.TabIndex = 1;
		this.radioButton_1.TabStop = true;
		this.radioButton_1.Text = "Юридическое лицо";
		this.radioButton_1.UseVisualStyleBackColor = true;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 10);
		this.label_0.Name = "label2";
		this.label_0.Size = new Size(49, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Абонент";
		this.dataGridViewExcelFilter_1.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_1.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewFilterTextBoxColumn_3,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewFilterTextBoxColumn_4,
			this.dataGridViewFilterTextBoxColumn_5
		});
		this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_1;
		this.dataGridViewExcelFilter_1.Location = new Point(3, 120);
		this.dataGridViewExcelFilter_1.MultiSelect = false;
		this.dataGridViewExcelFilter_1.Name = "dgvAbn2";
		this.dataGridViewExcelFilter_1.ReadOnly = true;
		this.dataGridViewExcelFilter_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_1.Size = new Size(379, 293);
		this.dataGridViewExcelFilter_1.TabIndex = 12;
		this.dataGridViewFilterTextBoxColumn_3.DataPropertyName = "codeAbonent";
		this.dataGridViewFilterTextBoxColumn_3.HeaderText = "Код";
		this.dataGridViewFilterTextBoxColumn_3.Name = "codeAbonentDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_3.Resizable = DataGridViewTriState.True;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_1.HeaderText = "id";
		this.dataGridViewTextBoxColumn_1.Name = "idAbn2DgvColumn";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.Visible = false;
		this.dataGridViewFilterTextBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterTextBoxColumn_4.DataPropertyName = "name";
		this.dataGridViewFilterTextBoxColumn_4.HeaderText = "Имя";
		this.dataGridViewFilterTextBoxColumn_4.Name = "nameDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_4.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_5.DataPropertyName = "typeNameSocr";
		this.dataGridViewFilterTextBoxColumn_5.FillWeight = 70f;
		this.dataGridViewFilterTextBoxColumn_5.HeaderText = "Тип";
		this.dataGridViewFilterTextBoxColumn_5.Name = "typeNameSocrDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_5.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_5.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_5.Width = 70;
		this.bindingSource_1.DataMember = "vAbn";
		this.bindingSource_1.DataSource = this.dataSet_1;
		this.dataSet_1.DataSetName = "NewDataSet";
		this.dataSet_1.Tables.AddRange(new DataTable[]
		{
			this.dataTable_0
		});
		this.dataTable_0.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_4,
			this.dataColumn_5,
			this.dataColumn_6,
			this.dataColumn_7
		});
		this.dataTable_0.TableName = "vAbn";
		this.dataColumn_4.ColumnName = "id";
		this.dataColumn_4.DataType = typeof(int);
		this.dataColumn_5.ColumnName = "codeAbonent";
		this.dataColumn_5.DataType = typeof(int);
		this.dataColumn_6.ColumnName = "name";
		this.dataColumn_7.ColumnName = "typeNameSocr";
		this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_2.Location = new Point(101, 94);
		this.textBox_2.Name = "txtName2";
		this.textBox_2.Size = new Size(250, 20);
		this.textBox_2.TabIndex = 11;
		this.textBox_2.TextChanged += this.textBox_2_TextChanged;
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(98, 78);
		this.label_5.Name = "label7";
		this.label_5.Size = new Size(119, 13);
		this.label_5.TabIndex = 10;
		this.label_5.Text = "Наименование (ФИО)";
		this.textBox_3.Location = new Point(13, 94);
		this.textBox_3.Name = "txtCode2";
		this.textBox_3.Size = new Size(79, 20);
		this.textBox_3.TabIndex = 9;
		this.textBox_3.TextChanged += this.textBox_3_TextChanged;
		this.label_6.AutoSize = true;
		this.label_6.Location = new Point(10, 78);
		this.label_6.Name = "label8";
		this.label_6.Size = new Size(26, 13);
		this.label_6.TabIndex = 8;
		this.label_6.Text = "Код";
		this.label_7.AutoSize = true;
		this.label_7.Location = new Point(10, 56);
		this.label_7.Name = "label4";
		this.label_7.Size = new Size(47, 13);
		this.label_7.TabIndex = 5;
		this.label_7.Text = "Фильтр";
		this.radioButton_2.AutoSize = true;
		this.radioButton_2.Location = new Point(154, 36);
		this.radioButton_2.Name = "rbFL2";
		this.radioButton_2.Size = new Size(116, 17);
		this.radioButton_2.TabIndex = 4;
		this.radioButton_2.Text = "Физическое лицо";
		this.radioButton_2.UseVisualStyleBackColor = true;
		this.radioButton_2.CheckedChanged += this.radioButton_2_CheckedChanged;
		this.radioButton_3.AutoSize = true;
		this.radioButton_3.Checked = true;
		this.radioButton_3.Location = new Point(13, 36);
		this.radioButton_3.Name = "rbLegal2";
		this.radioButton_3.Size = new Size(120, 17);
		this.radioButton_3.TabIndex = 3;
		this.radioButton_3.TabStop = true;
		this.radioButton_3.Text = "Юридическое лицо";
		this.radioButton_3.UseVisualStyleBackColor = true;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(3, 10);
		this.label_1.Name = "label1";
		this.label_1.Size = new Size(130, 13);
		this.label_1.TabIndex = 0;
		this.label_1.Text = "Объединяемый абонент";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(744, 453);
		base.Controls.Add(this.splitContainer_0);
		base.Controls.Add(this.button_0);
		base.Name = "MergeAbn";
		this.Text = "Объединение абонентов";
		base.Load += this.Form6_Load;
		this.splitContainer_0.Panel1.ResumeLayout(false);
		this.splitContainer_0.Panel1.PerformLayout();
		this.splitContainer_0.Panel2.ResumeLayout(false);
		this.splitContainer_0.Panel2.PerformLayout();
		this.splitContainer_0.ResumeLayout(false);
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.dataSet_0).EndInit();
		((ISupportInitialize)this.WgoWlVexjj).EndInit();
		((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		((ISupportInitialize)this.dataSet_1).EndInit();
		((ISupportInitialize)this.dataTable_0).EndInit();
		base.ResumeLayout(false);
	}

	private Button button_0;

	private SplitContainer splitContainer_0;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private Label label_0;

	private Label label_1;

	private DataGridViewExcelFilter dataGridViewExcelFilter_0;

	private TextBox textBox_0;

	private Label label_2;

	private TextBox textBox_1;

	private Label label_3;

	private Label label_4;

	private TextBox textBox_2;

	private Label label_5;

	private TextBox textBox_3;

	private Label label_6;

	private Label label_7;

	private RadioButton radioButton_2;

	private RadioButton radioButton_3;

	private DataSet dataSet_0;

	private DataTable WgoWlVexjj;

	private DataColumn dataColumn_0;

	private DataColumn dataColumn_1;

	private DataColumn dataColumn_2;

	private DataColumn dataColumn_3;

	private DataSet dataSet_1;

	private DataTable dataTable_0;

	private DataColumn dataColumn_4;

	private DataColumn dataColumn_5;

	private DataColumn dataColumn_6;

	private DataColumn dataColumn_7;

	private BindingSource bindingSource_0;

	private BindingSource bindingSource_1;

	private DataGridViewExcelFilter dataGridViewExcelFilter_1;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_4;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_5;
}
