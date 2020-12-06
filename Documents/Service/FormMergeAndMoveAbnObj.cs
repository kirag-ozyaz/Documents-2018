using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using Documents.Properties;
using FormLbr;

namespace Documents.Service
{
	public partial class FormMergeAndMoveAbnObj : FormBase
	{
		public FormMergeAndMoveAbnObj()
		{
			
			
			this.method_4();
			this.method_0();
		}

		private void method_0()
		{
			DataColumn dataColumn = new DataColumn("AddressFL");
			dataColumn.Expression = "street + ', д. ' + houseall + ', кв. ' + isnull(name, '')";
			this.dataTable_2.Columns.Add(dataColumn);
			dataColumn = new DataColumn("AddressUL");
			dataColumn.Expression = "street + ', д. ' + houseall";
			this.dataTable_2.Columns.Add(dataColumn);
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "AddressFL";
			this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "AddressUL";
			this.bindingSource_2.DataSource = this.dataTable_2;
			dataColumn = new DataColumn("AddressFL");
			dataColumn.Expression = "street + ', д. ' + houseall + ', кв. ' + isnull(name, '')";
			this.dataTable_3.Columns.Add(dataColumn);
			dataColumn = new DataColumn("AddressUL");
			dataColumn.Expression = "street + ', д. ' + houseall";
			this.dataTable_3.Columns.Add(dataColumn);
			this.dataGridViewFilterTextBoxColumn_4.DataPropertyName = "AddressFL";
			this.dataGridViewFilterTextBoxColumn_5.DataPropertyName = "AddressUL";
			this.bindingSource_2.DataSource = this.dataTable_2;
		}

		private void method_1()
		{
			this.method_3(this.dataSet_0.Tables[0], this.radioButton_1.Checked, this.textBox_1.Text, this.textBox_0.Text);
		}

		private void method_2()
		{
			this.method_3(this.dataSet_1.Tables[0], this.radioButton_3.Checked, this.textBox_3.Text, this.textBox_2.Text);
		}

		private void method_3(DataTable dataTable_4, bool bool_0, string string_0, string string_1)
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
				dataTable_4.Clear();
				return;
			}
			base.SelectSqlData(dataTable_4, true, str + " order by codeAbonent", null, false, 0);
		}

		private void radioButton_0_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButton_1.Checked)
			{
				this.dataGridViewFilterTextBoxColumn_1.Visible = false;
				this.dataGridViewFilterTextBoxColumn_2.Visible = true;
				this.dataGridViewFilterTextBoxColumn_0.Visible = true;
			}
			else
			{
				this.dataGridViewFilterTextBoxColumn_1.Visible = true;
				this.dataGridViewFilterTextBoxColumn_2.Visible = false;
				this.dataGridViewFilterTextBoxColumn_0.Visible = false;
			}
			this.method_1();
		}

		private void textBox_1_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.textBox_1.Text))
			{
				this.textBox_0.Text = "";
			}
			this.method_1();
		}

		private void textBox_0_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.textBox_0.Text))
			{
				this.textBox_1.Text = "";
			}
			this.method_1();
		}

		private void radioButton_2_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButton_3.Checked)
			{
				this.dataGridViewFilterTextBoxColumn_4.Visible = false;
				this.dataGridViewFilterTextBoxColumn_5.Visible = true;
				this.dataGridViewFilterTextBoxColumn_3.Visible = true;
			}
			else
			{
				this.dataGridViewFilterTextBoxColumn_4.Visible = true;
				this.dataGridViewFilterTextBoxColumn_5.Visible = false;
				this.dataGridViewFilterTextBoxColumn_3.Visible = false;
			}
			this.method_2();
		}

		private void textBox_3_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.textBox_3.Text))
			{
				this.textBox_2.Text = "";
			}
			this.method_2();
		}

		private void textBox_2_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.textBox_3.Text))
			{
				this.textBox_2.Text = "";
			}
			this.method_2();
		}

		private void FormMergeAndMoveAbnObj_Load(object sender, EventArgs e)
		{
			this.method_1();
			this.method_2();
		}

		private void bindingSource_0_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				int num = Convert.ToInt32(((DataRowView)this.bindingSource_0.Current)["id"]);
				base.SelectSqlData(this.dataTable_2, true, "where idAbn = " + num.ToString(), null, false, 0);
				return;
			}
			this.dataTable_2.Clear();
		}

		private void bindingSource_1_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bindingSource_1.Current != null)
			{
				int num = Convert.ToInt32(((DataRowView)this.bindingSource_1.Current)["id"]);
				base.SelectSqlData(this.dataTable_3, true, "where idAbn = " + num.ToString(), null, false, 0);
				return;
			}
			this.dataTable_3.Clear();
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null && this.dataGridViewExcelFilter_1.CurrentRow != null)
			{
				string arg = this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_7.Name].Value.ToString() + " (" + this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_6.Name].Value.ToString() + ")";
				string arg2 = this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_10.Name].Value.ToString() + " (" + this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_9.Name].Value.ToString() + ")";
				if (Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_4.Name].Value) == Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_5.Name].Value))
				{
					MessageBox.Show("Нельзя объединять одного и того же абонента");
					return;
				}
				string str = string.Format("\r\nВсе данные, объекты и документы абонента {1} переместяться в абонента {0}.\r\nАбонент {1} удалится.", arg, arg2);
				if (MessageBox.Show("Вы действительно хотите объединить выбранных абонентов?" + str, "Объединение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString() + ";Connection Timeout=0"))
					{
						sqlConnection.Open();
						using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
						{
							try
							{
								using (SqlCommand sqlCommand = new SqlCommand(Class7.smethod_2("Service.MergeAbn.sql"), sqlConnection))
								{
									sqlCommand.Transaction = sqlTransaction;
									sqlCommand.Parameters.Add("idParentAbn", SqlDbType.Int).Value = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_4.Name].Value);
									sqlCommand.Parameters.Add("idChildAbn", SqlDbType.Int).Value = Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_5.Name].Value);
									sqlCommand.ExecuteNonQuery();
								}
								sqlTransaction.Commit();
								MessageBox.Show("Объединение абонетов прошло успешно");
								this.method_1();
								this.method_2();
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
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_2.CurrentRow != null && this.dataGridViewExcelFilter_3.CurrentRow != null)
			{
				string text = this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_7.Name].Value.ToString() + " (" + this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_6.Name].Value.ToString() + ")";
				string text2 = this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_10.Name].Value.ToString() + " (" + this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_9.Name].Value.ToString() + ")";
				string text3 = this.radioButton_1.Checked ? this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_2.Name].Value.ToString() : this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_1.Name].Value.ToString();
				string text4 = this.radioButton_3.Checked ? this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_5.Name].Value.ToString() : this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_4.Name].Value.ToString();
				if (Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value) == Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_3.Name].Value))
				{
					MessageBox.Show("Нельзя объединить один и тот же объект");
					return;
				}
				string str = string.Format("\r\nВсе данные и документы объекта {2} абонента {3} переместяться в объект {0} абонента {1}.\r\nОбъект {2} абонента {3} удалится.", new object[]
				{
					text3,
					text,
					text4,
					text2
				});
				if (MessageBox.Show("Вы действительно хотите объединить выбранные объекты?" + str, "Объединение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString() + ";Connection Timeout=1000"))
					{
						sqlConnection.Open();
						using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
						{
							try
							{
								using (SqlCommand sqlCommand = new SqlCommand(Class7.smethod_2("Service.MergeAbnObj.sql"), sqlConnection))
								{
									sqlCommand.Transaction = sqlTransaction;
									sqlCommand.Parameters.Add("idParentAbnObj", SqlDbType.Int).Value = Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
									sqlCommand.Parameters.Add("idChildAbnObj", SqlDbType.Int).Value = Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_3.Name].Value);
									sqlCommand.ExecuteNonQuery();
								}
								sqlTransaction.Commit();
								MessageBox.Show("Объединение объектов прошло успешно");
								this.method_1();
								this.method_2();
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
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_3.CurrentRow != null && this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				string arg = this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_7.Name].Value.ToString() + " (" + this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_6.Name].Value.ToString() + ")";
				string arg2 = this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_10.Name].Value.ToString() + " (" + this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_9.Name].Value.ToString() + ")";
				string arg3 = this.radioButton_3.Checked ? this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_5.Name].Value.ToString() : this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewFilterTextBoxColumn_4.Name].Value.ToString();
				string str = string.Format("\r\nОбъект {0} абонента {1} переместиться в абонента {2}.", arg3, arg2, arg);
				if (MessageBox.Show("Вы действительно хотите переместить выбранный объект?" + str, "Перемещение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString() + ";Connection Timeout=1000"))
					{
						sqlConnection.Open();
						using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
						{
							try
							{
								using (SqlCommand sqlCommand = new SqlCommand(Class7.smethod_2("Service.MoveAbnObj.sql"), sqlConnection))
								{
									sqlCommand.Transaction = sqlTransaction;
									sqlCommand.Parameters.Add("idAbnObj", SqlDbType.Int).Value = Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_3.Name].Value);
									sqlCommand.Parameters.Add("idMoveAbn", SqlDbType.Int).Value = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_4.Name].Value);
									sqlCommand.ExecuteNonQuery();
								}
								sqlTransaction.Commit();
								MessageBox.Show("Перемещение объекта прошло успешно");
								this.method_1();
								this.method_2();
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
		}

		private void button_3_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_2.CurrentRow == null)
			{
				MessageBox.Show("Не выбран объект куда перемещать заявку");
				return;
			}
			if (this.dataGridViewExcelFilter_1.CurrentRow == null)
			{
				return;
			}
			int int_ = Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_5.Name].Value);
			int? nullable_ = null;
			if (this.dataGridViewExcelFilter_3.CurrentRow != null)
			{
				nullable_ = new int?(Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_3.Name].Value));
			}
			Form3 form = new Form3(int_, nullable_);
			form.SqlSettings = this.SqlSettings;
			if (form.ShowDialog() == DialogResult.OK && this.dataGridViewExcelFilter_0.CurrentRow != null && this.dataGridViewExcelFilter_2.CurrentRow != null)
			{
				int num = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_4.Name].Value);
				int num2 = Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
				int? idRequest = form.IdRequest;
				using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString() + ";Connection Timeout=0"))
				{
					sqlConnection.Open();
					using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
					{
						try
						{
							using (SqlCommand sqlCommand = new SqlCommand(Class7.smethod_2("Documents.Forms.TechnologicalConnection.SqlScripts.ChangeAbnAndAbnObjRequest.sql"), sqlConnection))
							{
								sqlCommand.Transaction = sqlTransaction;
								sqlCommand.Parameters.Add("id", SqlDbType.Int).Value = idRequest;
								sqlCommand.Parameters.Add("idAbn", SqlDbType.Int).Value = num;
								sqlCommand.Parameters.Add("idAbnObj", SqlDbType.Int).Value = num2;
								sqlCommand.ExecuteNonQuery();
							}
							sqlTransaction.Commit();
							MessageBox.Show("Замена объекта и абонента у заявки успешно произведена");
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

		private void method_4()
		{
			this.icontainer_0 = new Container();
			this.button_0 = new Button();
			this.splitContainer_0 = new SplitContainer();
			this.pictureBox_0 = new PictureBox();
			this.splitContainer_1 = new SplitContainer();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewFilterTextBoxColumn_6 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_7 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_8 = new DataGridViewFilterTextBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.dataSet_0 = new DataSet();
			this.dataTable_0 = new DataTable();
			this.dataColumn_0 = new DataColumn();
			this.dataColumn_1 = new DataColumn();
			this.dataColumn_2 = new DataColumn();
			this.dataColumn_3 = new DataColumn();
			this.dataTable_2 = new DataTable();
			this.dataColumn_8 = new DataColumn();
			this.dataColumn_9 = new DataColumn();
			this.dataColumn_10 = new DataColumn();
			this.dataColumn_11 = new DataColumn();
			this.dataGridViewExcelFilter_2 = new DataGridViewExcelFilter();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
			this.bindingSource_2 = new BindingSource(this.icontainer_0);
			this.textBox_0 = new TextBox();
			this.label_2 = new Label();
			this.textBox_1 = new TextBox();
			this.label_3 = new Label();
			this.label_4 = new Label();
			this.radioButton_0 = new RadioButton();
			this.radioButton_1 = new RadioButton();
			this.label_0 = new Label();
			this.splitContainer_2 = new SplitContainer();
			this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
			this.dataGridViewFilterTextBoxColumn_9 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_10 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_11 = new DataGridViewFilterTextBoxColumn();
			this.bindingSource_1 = new BindingSource(this.icontainer_0);
			this.dataSet_1 = new DataSet();
			this.dataTable_1 = new DataTable();
			this.dataColumn_4 = new DataColumn();
			this.dataColumn_5 = new DataColumn();
			this.dataColumn_6 = new DataColumn();
			this.dataColumn_7 = new DataColumn();
			this.dataTable_3 = new DataTable();
			this.dataColumn_12 = new DataColumn();
			this.dataColumn_13 = new DataColumn();
			this.dataColumn_14 = new DataColumn();
			this.dataColumn_15 = new DataColumn();
			this.dataGridViewExcelFilter_3 = new DataGridViewExcelFilter();
			this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_4 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_5 = new DataGridViewFilterTextBoxColumn();
			this.bindingSource_3 = new BindingSource(this.icontainer_0);
			this.textBox_2 = new TextBox();
			this.label_5 = new Label();
			this.textBox_3 = new TextBox();
			this.label_6 = new Label();
			this.label_7 = new Label();
			this.radioButton_2 = new RadioButton();
			this.radioButton_3 = new RadioButton();
			this.label_1 = new Label();
			this.button_1 = new Button();
			this.button_2 = new Button();
			this.button_3 = new Button();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			((ISupportInitialize)this.pictureBox_0).BeginInit();
			this.splitContainer_1.Panel1.SuspendLayout();
			this.splitContainer_1.Panel2.SuspendLayout();
			this.splitContainer_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.dataSet_0).BeginInit();
			((ISupportInitialize)this.dataTable_0).BeginInit();
			((ISupportInitialize)this.dataTable_2).BeginInit();
			((ISupportInitialize)this.dataGridViewExcelFilter_2).BeginInit();
			((ISupportInitialize)this.bindingSource_2).BeginInit();
			this.splitContainer_2.Panel1.SuspendLayout();
			this.splitContainer_2.Panel2.SuspendLayout();
			this.splitContainer_2.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
			((ISupportInitialize)this.bindingSource_1).BeginInit();
			((ISupportInitialize)this.dataSet_1).BeginInit();
			((ISupportInitialize)this.dataTable_1).BeginInit();
			((ISupportInitialize)this.dataTable_3).BeginInit();
			((ISupportInitialize)this.dataGridViewExcelFilter_3).BeginInit();
			((ISupportInitialize)this.bindingSource_3).BeginInit();
			base.SuspendLayout();
			this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.button_0.Location = new Point(165, 445);
			this.button_0.Name = "buttonMergeAbnObj";
			this.button_0.Size = new Size(147, 23);
			this.button_0.TabIndex = 0;
			this.button_0.Text = "Объединить объекты";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += this.button_0_Click;
			this.splitContainer_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.splitContainer_0.Location = new Point(0, -1);
			this.splitContainer_0.Name = "splitContainer1";
			this.splitContainer_0.Panel1.Controls.Add(this.pictureBox_0);
			this.splitContainer_0.Panel1.Controls.Add(this.splitContainer_1);
			this.splitContainer_0.Panel1.Controls.Add(this.textBox_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_2);
			this.splitContainer_0.Panel1.Controls.Add(this.textBox_1);
			this.splitContainer_0.Panel1.Controls.Add(this.label_3);
			this.splitContainer_0.Panel1.Controls.Add(this.label_4);
			this.splitContainer_0.Panel1.Controls.Add(this.radioButton_0);
			this.splitContainer_0.Panel1.Controls.Add(this.radioButton_1);
			this.splitContainer_0.Panel1.Controls.Add(this.label_0);
			this.splitContainer_0.Panel2.Controls.Add(this.splitContainer_2);
			this.splitContainer_0.Panel2.Controls.Add(this.textBox_2);
			this.splitContainer_0.Panel2.Controls.Add(this.label_5);
			this.splitContainer_0.Panel2.Controls.Add(this.textBox_3);
			this.splitContainer_0.Panel2.Controls.Add(this.label_6);
			this.splitContainer_0.Panel2.Controls.Add(this.label_7);
			this.splitContainer_0.Panel2.Controls.Add(this.radioButton_2);
			this.splitContainer_0.Panel2.Controls.Add(this.radioButton_3);
			this.splitContainer_0.Panel2.Controls.Add(this.label_1);
			this.splitContainer_0.Size = new Size(896, 440);
			this.splitContainer_0.SplitterDistance = 428;
			this.splitContainer_0.TabIndex = 1;
			this.pictureBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.pictureBox_0.Image = Resources.Bitmap_3;
			this.pictureBox_0.Location = new Point(375, 3);
			this.pictureBox_0.Name = "pictureBox1";
			this.pictureBox_0.Size = new Size(50, 50);
			this.pictureBox_0.TabIndex = 10;
			this.pictureBox_0.TabStop = false;
			this.splitContainer_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.splitContainer_1.Location = new Point(0, 120);
			this.splitContainer_1.Name = "splitContainer2";
			this.splitContainer_1.Orientation = Orientation.Horizontal;
			this.splitContainer_1.Panel1.Controls.Add(this.dataGridViewExcelFilter_0);
			this.splitContainer_1.Panel2.Controls.Add(this.dataGridViewExcelFilter_2);
			this.splitContainer_1.Size = new Size(429, 320);
			this.splitContainer_1.SplitterDistance = 152;
			this.splitContainer_1.TabIndex = 9;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewFilterTextBoxColumn_6,
				this.dataGridViewTextBoxColumn_4,
				this.dataGridViewFilterTextBoxColumn_7,
				this.dataGridViewFilterTextBoxColumn_8
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.Location = new Point(0, 0);
			this.dataGridViewExcelFilter_0.MultiSelect = false;
			this.dataGridViewExcelFilter_0.Name = "dgvAbn1";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_0.Size = new Size(429, 152);
			this.dataGridViewExcelFilter_0.TabIndex = 8;
			this.dataGridViewFilterTextBoxColumn_6.DataPropertyName = "codeAbonent";
			this.dataGridViewFilterTextBoxColumn_6.HeaderText = "Код";
			this.dataGridViewFilterTextBoxColumn_6.Name = "codeAbonentDgvColumn1";
			this.dataGridViewFilterTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_6.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_4.HeaderText = "id";
			this.dataGridViewTextBoxColumn_4.Name = "idAbn1DgvColumn";
			this.dataGridViewTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.Visible = false;
			this.dataGridViewFilterTextBoxColumn_7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_7.DataPropertyName = "name";
			this.dataGridViewFilterTextBoxColumn_7.HeaderText = "Имя";
			this.dataGridViewFilterTextBoxColumn_7.Name = "nameAbnDgvColumn1";
			this.dataGridViewFilterTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_7.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_8.DataPropertyName = "typeNameSocr";
			this.dataGridViewFilterTextBoxColumn_8.FillWeight = 70f;
			this.dataGridViewFilterTextBoxColumn_8.HeaderText = "Тип";
			this.dataGridViewFilterTextBoxColumn_8.Name = "typeNameSocrDataGridViewTextBoxColumn1";
			this.dataGridViewFilterTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_8.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_8.Width = 70;
			this.bindingSource_0.DataMember = "vAbn";
			this.bindingSource_0.DataSource = this.dataSet_0;
			this.bindingSource_0.CurrentChanged += this.bindingSource_0_CurrentChanged;
			this.dataSet_0.DataSetName = "NewDataSet";
			this.dataSet_0.Tables.AddRange(new DataTable[]
			{
				this.dataTable_0,
				this.dataTable_2
			});
			this.dataTable_0.Columns.AddRange(new DataColumn[]
			{
				this.dataColumn_0,
				this.dataColumn_1,
				this.dataColumn_2,
				this.dataColumn_3
			});
			this.dataTable_0.TableName = "vAbn";
			this.dataColumn_0.ColumnName = "id";
			this.dataColumn_0.DataType = typeof(int);
			this.dataColumn_1.ColumnName = "codeAbonent";
			this.dataColumn_1.DataType = typeof(int);
			this.dataColumn_2.ColumnName = "name";
			this.dataColumn_3.ColumnName = "typeNameSocr";
			this.dataTable_2.Columns.AddRange(new DataColumn[]
			{
				this.dataColumn_8,
				this.dataColumn_9,
				this.dataColumn_10,
				this.dataColumn_11
			});
			this.dataTable_2.TableName = "vAbnObjAddress";
			this.dataColumn_8.ColumnName = "id";
			this.dataColumn_8.DataType = typeof(int);
			this.dataColumn_9.ColumnName = "Name";
			this.dataColumn_10.ColumnName = "street";
			this.dataColumn_11.ColumnName = "houseAll";
			this.dataGridViewExcelFilter_2.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_2.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_2.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_2.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewFilterTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewFilterTextBoxColumn_1,
				this.dataGridViewFilterTextBoxColumn_2
			});
			this.dataGridViewExcelFilter_2.DataSource = this.bindingSource_2;
			this.dataGridViewExcelFilter_2.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_2.Location = new Point(0, 0);
			this.dataGridViewExcelFilter_2.MultiSelect = false;
			this.dataGridViewExcelFilter_2.Name = "dgvAbnObj1";
			this.dataGridViewExcelFilter_2.ReadOnly = true;
			this.dataGridViewExcelFilter_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_2.Size = new Size(429, 164);
			this.dataGridViewExcelFilter_2.TabIndex = 0;
			this.dataGridViewFilterTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "Name";
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Объект";
			this.dataGridViewFilterTextBoxColumn_0.Name = "nameObjDgvColumn1";
			this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "idAbnObjDgvColum1";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "street";
			this.dataGridViewTextBoxColumn_1.HeaderText = "street";
			this.dataGridViewTextBoxColumn_1.Name = "streetDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "houseAll";
			this.dataGridViewTextBoxColumn_2.HeaderText = "houseAll";
			this.dataGridViewTextBoxColumn_2.Name = "houseAllDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewTextBoxColumn_2.Visible = false;
			this.dataGridViewFilterTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Адрес";
			this.dataGridViewFilterTextBoxColumn_1.Name = "addressFLDgvColumn1";
			this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.Visible = false;
			this.dataGridViewFilterTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Адрес";
			this.dataGridViewFilterTextBoxColumn_2.Name = "addressULDgvColumn1";
			this.dataGridViewFilterTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
			this.bindingSource_2.DataMember = "vAbnObjAddress";
			this.bindingSource_2.DataSource = this.dataSet_0;
			this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_0.Location = new Point(103, 94);
			this.textBox_0.Name = "txtName1";
			this.textBox_0.Size = new Size(322, 20);
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
			this.splitContainer_2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.splitContainer_2.Location = new Point(3, 120);
			this.splitContainer_2.Name = "splitContainer3";
			this.splitContainer_2.Orientation = Orientation.Horizontal;
			this.splitContainer_2.Panel1.Controls.Add(this.dataGridViewExcelFilter_1);
			this.splitContainer_2.Panel2.Controls.Add(this.dataGridViewExcelFilter_3);
			this.splitContainer_2.Size = new Size(461, 320);
			this.splitContainer_2.SplitterDistance = 152;
			this.splitContainer_2.TabIndex = 13;
			this.dataGridViewExcelFilter_1.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_1.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewFilterTextBoxColumn_9,
				this.dataGridViewTextBoxColumn_5,
				this.dataGridViewFilterTextBoxColumn_10,
				this.dataGridViewFilterTextBoxColumn_11
			});
			this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_1;
			this.dataGridViewExcelFilter_1.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_1.Location = new Point(0, 0);
			this.dataGridViewExcelFilter_1.MultiSelect = false;
			this.dataGridViewExcelFilter_1.Name = "dgvAbn2";
			this.dataGridViewExcelFilter_1.ReadOnly = true;
			this.dataGridViewExcelFilter_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_1.Size = new Size(461, 152);
			this.dataGridViewExcelFilter_1.TabIndex = 12;
			this.dataGridViewFilterTextBoxColumn_9.DataPropertyName = "codeAbonent";
			this.dataGridViewFilterTextBoxColumn_9.HeaderText = "Код";
			this.dataGridViewFilterTextBoxColumn_9.Name = "codeAbonentDgvColumn2";
			this.dataGridViewFilterTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_9.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_5.HeaderText = "id";
			this.dataGridViewTextBoxColumn_5.Name = "idAbn2DgvColumn";
			this.dataGridViewTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewTextBoxColumn_5.Visible = false;
			this.dataGridViewFilterTextBoxColumn_10.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_10.DataPropertyName = "name";
			this.dataGridViewFilterTextBoxColumn_10.HeaderText = "Имя";
			this.dataGridViewFilterTextBoxColumn_10.Name = "nameAbnDgvColumn2";
			this.dataGridViewFilterTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_10.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_11.DataPropertyName = "typeNameSocr";
			this.dataGridViewFilterTextBoxColumn_11.FillWeight = 70f;
			this.dataGridViewFilterTextBoxColumn_11.HeaderText = "Тип";
			this.dataGridViewFilterTextBoxColumn_11.Name = "typeNameSocrDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_11.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_11.Width = 70;
			this.bindingSource_1.DataMember = "vAbn";
			this.bindingSource_1.DataSource = this.dataSet_1;
			this.bindingSource_1.CurrentChanged += this.bindingSource_1_CurrentChanged;
			this.dataSet_1.DataSetName = "NewDataSet";
			this.dataSet_1.Tables.AddRange(new DataTable[]
			{
				this.dataTable_1,
				this.dataTable_3
			});
			this.dataTable_1.Columns.AddRange(new DataColumn[]
			{
				this.dataColumn_4,
				this.dataColumn_5,
				this.dataColumn_6,
				this.dataColumn_7
			});
			this.dataTable_1.TableName = "vAbn";
			this.dataColumn_4.ColumnName = "id";
			this.dataColumn_4.DataType = typeof(int);
			this.dataColumn_5.ColumnName = "codeAbonent";
			this.dataColumn_5.DataType = typeof(int);
			this.dataColumn_6.ColumnName = "name";
			this.dataColumn_7.ColumnName = "typeNameSocr";
			this.dataTable_3.Columns.AddRange(new DataColumn[]
			{
				this.dataColumn_12,
				this.dataColumn_13,
				this.dataColumn_14,
				this.dataColumn_15
			});
			this.dataTable_3.TableName = "vAbnObjAddress";
			this.dataColumn_12.ColumnName = "id";
			this.dataColumn_12.DataType = typeof(int);
			this.dataColumn_13.ColumnName = "name";
			this.dataColumn_14.ColumnName = "street";
			this.dataColumn_15.ColumnName = "houseall";
			this.dataGridViewExcelFilter_3.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_3.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_3.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_3.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewFilterTextBoxColumn_3,
				this.dataGridViewTextBoxColumn_3,
				this.dataGridViewFilterTextBoxColumn_4,
				this.dataGridViewFilterTextBoxColumn_5
			});
			this.dataGridViewExcelFilter_3.DataSource = this.bindingSource_3;
			this.dataGridViewExcelFilter_3.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_3.Location = new Point(0, 0);
			this.dataGridViewExcelFilter_3.MultiSelect = false;
			this.dataGridViewExcelFilter_3.Name = "dgvAbnObj2";
			this.dataGridViewExcelFilter_3.ReadOnly = true;
			this.dataGridViewExcelFilter_3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_3.Size = new Size(461, 164);
			this.dataGridViewExcelFilter_3.TabIndex = 1;
			this.dataGridViewFilterTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_3.DataPropertyName = "name";
			this.dataGridViewFilterTextBoxColumn_3.HeaderText = "Объект";
			this.dataGridViewFilterTextBoxColumn_3.Name = "nameObjDgvColumn2";
			this.dataGridViewFilterTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_3.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_3.HeaderText = "id";
			this.dataGridViewTextBoxColumn_3.Name = "idAbnObjDgvColum2";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.Visible = false;
			this.dataGridViewFilterTextBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_4.HeaderText = "Адрес";
			this.dataGridViewFilterTextBoxColumn_4.Name = "addressFLDgvColumn2";
			this.dataGridViewFilterTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_4.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_4.Visible = false;
			this.dataGridViewFilterTextBoxColumn_5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_5.HeaderText = "Адрес";
			this.dataGridViewFilterTextBoxColumn_5.Name = "addressULDgvColumn2";
			this.dataGridViewFilterTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_5.Resizable = DataGridViewTriState.True;
			this.bindingSource_3.DataMember = "vAbnObjAddress";
			this.bindingSource_3.DataSource = this.dataSet_1;
			this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_2.Location = new Point(101, 94);
			this.textBox_2.Name = "txtName2";
			this.textBox_2.Size = new Size(329, 20);
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
			this.label_1.Location = new Point(10, 10);
			this.label_1.Name = "label1";
			this.label_1.Size = new Size(130, 13);
			this.label_1.TabIndex = 0;
			this.label_1.Text = "Объединяемый абонент";
			this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.button_1.Location = new Point(12, 445);
			this.button_1.Name = "buttonMergeAbn";
			this.button_1.Size = new Size(147, 23);
			this.button_1.TabIndex = 2;
			this.button_1.Text = "Объединить абонентов";
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += this.button_1_Click;
			this.button_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.button_2.Location = new Point(321, 445);
			this.button_2.Name = "buttonMoveAbnObj";
			this.button_2.Size = new Size(147, 23);
			this.button_2.TabIndex = 3;
			this.button_2.Text = "Переместить объект";
			this.button_2.UseVisualStyleBackColor = true;
			this.button_2.Click += this.button_2_Click;
			this.button_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.button_3.Location = new Point(474, 445);
			this.button_3.Name = "buttonChangeAbnAbnAbnObjRequest";
			this.button_3.Size = new Size(147, 36);
			this.button_3.TabIndex = 4;
			this.button_3.Text = "Сменить объект у заявки на тех. присоединение";
			this.button_3.UseVisualStyleBackColor = true;
			this.button_3.Click += this.button_3_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(895, 480);
			base.Controls.Add(this.button_3);
			base.Controls.Add(this.button_2);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.splitContainer_0);
			base.Controls.Add(this.button_0);
			base.Name = "FormMergeAndMoveAbnObj";
			this.Text = "Сервис объединения(перемещения) абонентов(объектов)";
			base.Load += this.FormMergeAndMoveAbnObj_Load;
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.Panel2.PerformLayout();
			this.splitContainer_0.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox_0).EndInit();
			this.splitContainer_1.Panel1.ResumeLayout(false);
			this.splitContainer_1.Panel2.ResumeLayout(false);
			this.splitContainer_1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.dataSet_0).EndInit();
			((ISupportInitialize)this.dataTable_0).EndInit();
			((ISupportInitialize)this.dataTable_2).EndInit();
			((ISupportInitialize)this.dataGridViewExcelFilter_2).EndInit();
			((ISupportInitialize)this.bindingSource_2).EndInit();
			this.splitContainer_2.Panel1.ResumeLayout(false);
			this.splitContainer_2.Panel2.ResumeLayout(false);
			this.splitContainer_2.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
			((ISupportInitialize)this.bindingSource_1).EndInit();
			((ISupportInitialize)this.dataSet_1).EndInit();
			((ISupportInitialize)this.dataTable_1).EndInit();
			((ISupportInitialize)this.dataTable_3).EndInit();
			((ISupportInitialize)this.dataGridViewExcelFilter_3).EndInit();
			((ISupportInitialize)this.bindingSource_3).EndInit();
			base.ResumeLayout(false);
		}

		internal static void FQ3Pd31Pqtw38WUVZl1(Form form_0, bool bool_0)
		{
			form_0.Dispose(bool_0);
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

		private DataTable dataTable_0;

		private DataColumn dataColumn_0;

		private DataColumn dataColumn_1;

		private DataColumn dataColumn_2;

		private DataColumn dataColumn_3;

		private DataSet dataSet_1;

		private DataTable dataTable_1;

		private DataColumn dataColumn_4;

		private DataColumn dataColumn_5;

		private DataColumn dataColumn_6;

		private DataColumn dataColumn_7;

		private BindingSource bindingSource_0;

		private BindingSource bindingSource_1;

		private DataGridViewExcelFilter dataGridViewExcelFilter_1;

		private SplitContainer splitContainer_1;

		private DataGridViewExcelFilter dataGridViewExcelFilter_2;

		private BindingSource bindingSource_2;

		private DataTable dataTable_2;

		private DataColumn dataColumn_8;

		private DataColumn dataColumn_9;

		private DataColumn dataColumn_10;

		private DataColumn dataColumn_11;

		private SplitContainer splitContainer_2;

		private DataTable dataTable_3;

		private DataColumn dataColumn_12;

		private DataColumn dataColumn_13;

		private DataColumn dataColumn_14;

		private DataColumn dataColumn_15;

		private DataGridViewExcelFilter dataGridViewExcelFilter_3;

		private BindingSource bindingSource_3;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_4;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_5;

		private Button button_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_7;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_8;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_10;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_11;

		private Button button_2;

		private PictureBox pictureBox_0;

		private Button button_3;
	}
}
