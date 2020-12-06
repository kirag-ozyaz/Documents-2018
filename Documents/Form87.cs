using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataSql;
using FormLbr;

internal partial class Form87 : FormBase
{
	internal IEnumerable<int> method_0()
	{
		return this.list_0.AsEnumerable<int>();
	}

	internal Form87()
	{
		
		
		this.method_2();
	}

	internal Form87(int? nullable_2 = null, List<int> list_2 = null, int? nullable_3 = null)
	{
		
		
		this.method_2();
		this.nullable_0 = nullable_2;
		this.list_1 = list_2;
		this.nullable_1 = nullable_3;
	}

	private void Form87_Load(object sender, EventArgs e)
	{
		if (this.nullable_0 != null)
		{
			this.method_1();
		}
	}

	private void method_1()
	{
		this.dataGridViewTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewComboBoxColumn_0.ReadOnly = true;
		this.dataGridView_0.Rows.Clear();
		string text = "";
		if (this.nullable_1 != null)
		{
			text = " and dd.id <> " + this.nullable_1.Value.ToString();
		}
		string text2 = "";
		if (this.list_1 != null && this.list_1.Count > 0)
		{
			foreach (int num in this.list_1)
			{
				if (string.IsNullOrEmpty(text2))
				{
					text2 = num.ToString();
				}
				else
				{
					text2 = text2 + "," + num.ToString();
				}
			}
			text2 = " and d.id not in (" + text2 + ") ";
		}
		SqlDataCommand sqlDataCommand = new SqlDataCommand(this.SqlSettings);
		this.dataTable_0 = sqlDataCommand.SelectSqlData(string.Format("select d.[ID], d.[IDDAMAGE], d.[IDSCHMOBJ],\r\n\t                                          d.[IDLINESECTION], ctype.name as typeSchm\r\n                            from tJ_DamageCharacter d\r\n\t                                left join tr_classifier cType on cType.id = d.col1 \r\n                            where d.idDamage = {0} and  d.id not in (\r\n                                      select c.idCharacterParent from tJ_damage dd\r\n\t                                         inner join tJ_damageCharacter c on c.idDAmage = dd.id\r\n                                      where idParent = {0} and typeDoc = {1} {2}) {3}", new object[]
		{
			this.nullable_0.Value,
			1874,
			text,
			text2
		}));
		int num2 = 0;
		foreach (object obj in this.dataTable_0.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			this.dataGridView_0.Rows.Add();
			this.dataGridView_0[this.dataGridViewTextBoxColumn_0.Index, num2].Value = dataRow["id"];
			this.dataGridView_0[this.dataGridViewTextBoxColumn_3.Index, num2].Value = dataRow["typeSChm"];
			if (dataRow["idSchmObj"] != DBNull.Value)
			{
				this.dataGridView_0[this.dataGridViewTextBoxColumn_2.Index, num2].Value = dataRow["idSchmObj"];
				object obj2 = base.CallSQLScalarFunction("dbo.fn_Schm_GetFullNameObjById", new string[]
				{
					dataRow["idSchmObj"].ToString()
				});
				if (obj2 != null && obj2 != DBNull.Value)
				{
					this.dataGridView_0[this.dataGridViewTextBoxColumn_4.Index, num2].Value = obj2.ToString();
				}
				DataGridViewComboBoxCell dataGridViewComboBoxCell = this.dataGridView_0[this.dataGridViewComboBoxColumn_0.Index, num2] as DataGridViewComboBoxCell;
				DataTable dataTable = new DataTable("tP_CabSection");
				dataTable.Columns.Add("id", typeof(int));
				dataTable.Columns.Add("number", typeof(int));
				base.SelectSqlData(dataTable, true, "where idObjList = " + dataRow["idSchmObj"].ToString() + " order by number", null, false, 0);
				dataGridViewComboBoxCell.DataSource = dataTable;
				dataGridViewComboBoxCell.ValueMember = "id";
				dataGridViewComboBoxCell.DisplayMember = "number";
				if (dataRow["idLineSection"] != DBNull.Value)
				{
					dataGridViewComboBoxCell.Value = Convert.ToInt32(dataRow["idLineSection"]);
				}
				else
				{
					dataGridViewComboBoxCell.Value = null;
				}
			}
			num2++;
		}
	}

	private void dataGridView_0_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		if (this.dataGridView_0.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
		{
			e.Cancel = true;
		}
	}

	private void Form87_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			this.list_0 = new List<int>();
			foreach (object obj in ((IEnumerable)this.dataGridView_0.Rows))
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)obj;
				if (dataGridViewRow.Cells[this.dataGridViewCheckBoxColumn_0.Name].Value != null && Convert.ToBoolean(dataGridViewRow.Cells[this.dataGridViewCheckBoxColumn_0.Name].Value))
				{
					this.list_0.Add(Convert.ToInt32(dataGridViewRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value));
				}
			}
			if (this.list_1 == null && this.nullable_1 == null && this.list_0.Count == 0)
			{
				DataTable dataTable = new DataTable("tJ_Damage");
				dataTable.Columns.Add("id", typeof(int));
				dataTable.Columns.Add("numRequest", typeof(string));
				dataTable.Columns.Add("dateDoc", typeof(DateTime));
				base.SelectSqlData(dataTable, true, string.Format("where idParent = {0} and typeDoc = {1} \r\n                        and not exists(select id from tJ_DamageCharacter where idDAmage = tj_damage.id)", this.nullable_0, 1874), null, false, 0);
				if (dataTable.Rows.Count > 0)
				{
					MessageBox.Show(string.Format("Акт без оборудования уже существует. (Акт №{0} от {1})\r\nНевозможно создать акт.", dataTable.Rows[0]["numRequest"].ToString(), Convert.ToDateTime(dataTable.Rows[0]["dateDoc"]).ToString("dd.MM.yyyy")), "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					base.DialogResult = DialogResult.Cancel;
					return;
				}
			}
		}
	}

	private void method_2()
	{
		this.icontainer_0 = new Container();
		this.dataGridView_0 = new DataGridView();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.dataSet_0 = new DataSet();
		this.dataTable_0 = new DataTable();
		this.dataColumn_0 = new DataColumn();
		this.dataColumn_1 = new DataColumn();
		this.dataColumn_2 = new DataColumn();
		this.dataColumn_3 = new DataColumn();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.dataColumn_4 = new DataColumn();
		this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		((ISupportInitialize)this.dataSet_0).BeginInit();
		((ISupportInitialize)this.dataTable_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		base.SuspendLayout();
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewCheckBoxColumn_0,
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewTextBoxColumn_3,
			this.dataGridViewTextBoxColumn_4,
			this.dataGridViewComboBoxColumn_0
		});
		this.dataGridView_0.EditMode = DataGridViewEditMode.EditOnEnter;
		this.dataGridView_0.Location = new Point(0, 0);
		this.dataGridView_0.Name = "dgv";
		this.dataGridView_0.Size = new Size(391, 299);
		this.dataGridView_0.TabIndex = 0;
		this.dataGridView_0.DataError += this.dataGridView_0_DataError;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(12, 305);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 1;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(306, 305);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 2;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.dataSet_0.DataSetName = "NewDataSet";
		this.dataSet_0.Tables.AddRange(new DataTable[]
		{
			this.dataTable_0
		});
		this.dataTable_0.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_0,
			this.dataColumn_1,
			this.dataColumn_2,
			this.dataColumn_3,
			this.dataColumn_4
		});
		this.dataTable_0.Constraints.AddRange(new Constraint[]
		{
			new UniqueConstraint("Constraint1", new string[]
			{
				"id"
			}, true)
		});
		this.dataTable_0.PrimaryKey = new DataColumn[]
		{
			this.dataColumn_0
		};
		this.dataTable_0.TableName = "tJ_DamageCharacter";
		this.dataColumn_0.AllowDBNull = false;
		this.dataColumn_0.ColumnName = "id";
		this.dataColumn_0.DataType = typeof(int);
		this.dataColumn_1.AllowDBNull = false;
		this.dataColumn_1.ColumnName = "idDamage";
		this.dataColumn_1.DataType = typeof(int);
		this.dataColumn_2.ColumnName = "idSchmObj";
		this.dataColumn_2.DataType = typeof(int);
		this.dataColumn_3.ColumnName = "idLineSection";
		this.bindingSource_0.DataMember = "tJ_DamageCharacter";
		this.bindingSource_0.DataSource = this.dataSet_0;
		this.dataColumn_4.ColumnName = "typeSchm";
		this.dataGridViewCheckBoxColumn_0.HeaderText = "";
		this.dataGridViewCheckBoxColumn_0.Name = "checkedColumn";
		this.dataGridViewCheckBoxColumn_0.Width = 30;
		this.dataGridViewTextBoxColumn_0.HeaderText = "idColumn";
		this.dataGridViewTextBoxColumn_0.Name = "idColumn";
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_1.HeaderText = "idDamageColumn";
		this.dataGridViewTextBoxColumn_1.Name = "idDamageColumn";
		this.dataGridViewTextBoxColumn_1.Visible = false;
		this.dataGridViewTextBoxColumn_2.HeaderText = "idSchmObj";
		this.dataGridViewTextBoxColumn_2.Name = "idSchmObjColumn";
		this.dataGridViewTextBoxColumn_2.Visible = false;
		this.dataGridViewTextBoxColumn_3.HeaderText = "Тип";
		this.dataGridViewTextBoxColumn_3.Name = "typeSchmDgvColumn";
		this.dataGridViewTextBoxColumn_3.Width = 60;
		this.dataGridViewTextBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_4.HeaderText = "Объект";
		this.dataGridViewTextBoxColumn_4.Name = "schmObjColumn";
		this.dataGridViewTextBoxColumn_4.Resizable = DataGridViewTriState.True;
		this.dataGridViewTextBoxColumn_4.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_0.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_0.FillWeight = 40f;
		this.dataGridViewComboBoxColumn_0.HeaderText = "Участок";
		this.dataGridViewComboBoxColumn_0.Name = "idLineSectionColumn";
		this.dataGridViewComboBoxColumn_0.SortMode = DataGridViewColumnSortMode.Programmatic;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(393, 336);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.dataGridView_0);
		base.Name = "FormChooseDamageCharacter";
		base.StartPosition = FormStartPosition.CenterParent;
		this.Text = "Выбор оборудования";
		base.FormClosing += this.Form87_FormClosing;
		base.Load += this.Form87_Load;
		((ISupportInitialize)this.dataGridView_0).EndInit();
		((ISupportInitialize)this.dataSet_0).EndInit();
		((ISupportInitialize)this.dataTable_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		base.ResumeLayout(false);
	}

	private int? nullable_0;

	private List<int> list_0;

	private List<int> list_1;

	private int? nullable_1;

	private DataGridView dataGridView_0;

	private Button button_0;

	private Button button_1;

	private DataSet dataSet_0;

	private DataTable dataTable_0;

	private DataColumn dataColumn_0;

	private DataColumn dataColumn_1;

	private DataColumn dataColumn_2;

	private DataColumn dataColumn_3;

	private BindingSource bindingSource_0;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataColumn dataColumn_4;
}
