using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using FormLbr;

internal partial class Form25 : FormBase
{
	internal Form25(int int_1, List<int> list_1 = null)
	{
		
		
		this.method_0();
		this.int_0 = int_1;
		this.list_0 = list_1;
	}

	private void Form25_Load(object sender, EventArgs e)
	{
		if (this.list_0 != null && this.list_0.Count != 0)
		{
			string text = "";
			foreach (int num in this.list_0)
			{
				if (string.IsNullOrEmpty(text))
				{
					text = num.ToString();
				}
				else
				{
					text = text + "," + num.ToString();
				}
			}
			base.SelectSqlData(this.class255_0.tR_Classifier, true, string.Format("where id in ({0}) order by name", text), null, false, 0);
		}
		else
		{
			base.SelectSqlData(this.class255_0.tR_Classifier, true, "where ParentKey = ';SKUEE;TypeAbn;' and isGRoup = 0 and deleted = 0 order by name", null, false, 0);
		}
		base.SelectSqlData(this.class255_0.tAbn, true, "where id = " + this.int_0.ToString(), null, false, 0);
		if (this.class255_0.tAbn.Rows.Count > 0)
		{
			base.SelectSqlData(this.dataTable_0, true, "where idAbn = " + this.int_0.ToString(), null, false, 0);
			this.nullable_0 = new int?(Convert.ToInt32(this.class255_0.tAbn.Rows[0]["TypeAbn"]));
			if (this.class255_0.tR_Classifier.Select("id = " + this.nullable_0.ToString()).Length == 0)
			{
				Class255.Class262 @class = new Class255.Class262();
				base.SelectSqlData(@class, true, "where id = " + this.nullable_0.ToString(), null, false, 0);
				if (@class.Rows.Count > 0)
				{
					this.class255_0.tR_Classifier.ImportRow(@class.Rows[0]);
					this.comboBox_0.SelectedValue = this.nullable_0.ToString();
				}
			}
		}
	}

	private void Form25_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.nullable_0 == null)
			{
				base.DialogResult = DialogResult.Cancel;
				return;
			}
			if (this.nullable_0 != Convert.ToInt32(this.comboBox_0.SelectedValue) && MessageBox.Show("Вы уверены что хотите изменить тип контрагента?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.class255_0.tAbn.Rows[0].EndEdit();
				if (base.UpdateSqlData(this.class255_0.tAbn))
				{
					int? num = null;
					int num2 = Convert.ToInt32(this.class255_0.tAbn.Rows[0]["TypeAbn"]);
					if (num2 <= 207)
					{
						if (num2 != 206)
						{
							if (num2 == 207)
							{
								num = new int?(1147);
							}
						}
						else
						{
							num = new int?(1146);
						}
					}
					else if (num2 != 1037)
					{
						if (num2 == 1038)
						{
							num = new int?(1149);
						}
					}
					else
					{
						num = new int?(1148);
					}
					using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
					{
						try
						{
							sqlConnection.Open();
							using (SqlCommand sqlCommand = new SqlCommand(string.Format("update tAbnObj set typeObj = {0} where idAbn = {1}", num, this.int_0), sqlConnection))
							{
								sqlCommand.ExecuteNonQuery();
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, ex.Source);
						}
						finally
						{
							sqlConnection.Close();
						}
					}
				}
			}
		}
	}

	private void method_0()
	{
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.class255_0 = new Class255();
		this.label_1 = new Label();
		this.textBox_1 = new TextBox();
		this.label_2 = new Label();
		this.comboBox_0 = new ComboBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.FxyomgcjJfh = new DataSet();
		this.dataTable_0 = new DataTable();
		this.dataColumn_0 = new DataColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		((ISupportInitialize)this.class255_0).BeginInit();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		((ISupportInitialize)this.FxyomgcjJfh).BeginInit();
		((ISupportInitialize)this.dataTable_0).BeginInit();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(23, 9);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(26, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Код";
		this.textBox_0.BackColor = SystemColors.Window;
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class255_0, "tAbn.CodeAbonent", true));
		this.textBox_0.Location = new Point(12, 25);
		this.textBox_0.Name = "textBox1";
		this.textBox_0.ReadOnly = true;
		this.textBox_0.Size = new Size(100, 20);
		this.textBox_0.TabIndex = 1;
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(134, 9);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(95, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Имя контрагента";
		this.textBox_1.BackColor = SystemColors.Window;
		this.textBox_1.DataBindings.Add(new Binding("Text", this.class255_0, "tAbn.Name", true));
		this.textBox_1.Location = new Point(127, 25);
		this.textBox_1.Name = "textBox2";
		this.textBox_1.ReadOnly = true;
		this.textBox_1.Size = new Size(317, 20);
		this.textBox_1.TabIndex = 3;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(23, 60);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(92, 13);
		this.label_2.TabIndex = 4;
		this.label_2.Text = "Тип контрагента";
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class255_0, "tAbn.TypeAbn", true));
		this.comboBox_0.DataSource = this.class255_0;
		this.comboBox_0.DisplayMember = "tR_Classifier.Name";
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(15, 76);
		this.comboBox_0.Name = "cmbTypeAbn";
		this.comboBox_0.Size = new Size(429, 21);
		this.comboBox_0.TabIndex = 5;
		this.comboBox_0.ValueMember = "tR_Classifier.Id";
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(15, 275);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 6;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(369, 275);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 7;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0
		});
		this.dataGridViewExcelFilter_0.DataMember = "vAbnObj";
		this.dataGridViewExcelFilter_0.DataSource = this.FxyomgcjJfh;
		this.dataGridViewExcelFilter_0.Location = new Point(12, 103);
		this.dataGridViewExcelFilter_0.Name = "dgvAbnObj";
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.RowHeadersVisible = false;
		this.dataGridViewExcelFilter_0.Size = new Size(432, 166);
		this.dataGridViewExcelFilter_0.TabIndex = 8;
		this.FxyomgcjJfh.DataSetName = "NewDataSet";
		this.FxyomgcjJfh.Tables.AddRange(new DataTable[]
		{
			this.dataTable_0
		});
		this.dataTable_0.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_0
		});
		this.dataTable_0.TableName = "vAbnObj";
		this.dataColumn_0.ColumnName = "NameObj";
		this.dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "NameObj";
		this.dataGridViewTextBoxColumn_0.HeaderText = "Объекты";
		this.dataGridViewTextBoxColumn_0.Name = "nameObjDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(456, 310);
		base.Controls.Add(this.dataGridViewExcelFilter_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.textBox_1);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormChangeTypeConsumer";
		this.Text = "Тип контрагента";
		base.FormClosing += this.Form25_FormClosing;
		base.Load += this.Form25_Load;
		((ISupportInitialize)this.class255_0).EndInit();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		((ISupportInitialize)this.FxyomgcjJfh).EndInit();
		((ISupportInitialize)this.dataTable_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private int int_0;

	private List<int> list_0;

	private int? nullable_0;

	private Label label_0;

	private TextBox textBox_0;

	private Label label_1;

	private TextBox textBox_1;

	private Label label_2;

	private ComboBox comboBox_0;

	private Button button_0;

	private Button button_1;

	private Class255 class255_0;

	private DataGridViewExcelFilter dataGridViewExcelFilter_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataSet FxyomgcjJfh;

	private DataTable dataTable_0;

	private DataColumn dataColumn_0;
}
