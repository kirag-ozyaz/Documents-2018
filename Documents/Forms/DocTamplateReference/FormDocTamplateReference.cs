using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

namespace Documents.Forms.DocTamplateReference
{
	public partial class FormDocTamplateReference : FormBase
	{
		[DefaultValue(-1)]
		public int ClassifierValue
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		public FormDocTamplateReference()
		{
			
			this.int_0 = -1;
			
			this.method_3();
		}

		public FormDocTamplateReference(int classifierValue)
		{
			
			this.int_0 = -1;
			
			this.method_3();
			this.int_0 = classifierValue;
		}

		private void FormDocTamplateReference_Load(object sender, EventArgs e)
		{
			this.toolStripComboBox_0.ComboBox.DataSource = this.bindingSource_0;
			this.toolStripComboBox_0.ComboBox.DisplayMember = "Name";
			this.toolStripComboBox_0.ComboBox.ValueMember = "id";
			string where = "WHERE ParentKey = ';TypeDoc;tR_DocTemplate;' AND Deleted = ((0)) AND isGroup = ((0))" + ((this.int_0 != -1) ? (" AND Value = " + this.int_0.ToString()) : "");
			base.SelectSqlData(this.class255_0, this.class255_0.tR_Classifier, true, where);
			if (this.int_0 != -1)
			{
				this.toolStripComboBox_0.Visible = false;
				this.Text = this.Text + " : " + this.class255_0.tR_Classifier.First<Class255.Class369>().Name;
			}
			this.method_0();
		}

		private void method_0()
		{
			if (this.bindingSource_0.Current != null)
			{
				DataTable dataSource = new SqlDataCommand(this.SqlSettings).SelectSqlData("SELECT id, FileName, LastChange FROM tR_DocTemplate WHERE Deleted = ((0)) AND idTypeDoc = " + ((DataRowView)this.bindingSource_0.Current)["id"].ToString());
				BindingSource bindingSource = new BindingSource();
				bindingSource.DataSource = dataSource;
				this.dataGridViewExcelFilter_0.DataSource = bindingSource;
			}
		}

		private void method_1(string string_0)
		{
			if (this.label_0.InvokeRequired)
			{
				Dispatcher.Invoke(this, delegate
				{
					this.label_0.Text = string_0;
				});
				return;
			}
			this.label_0.Text = string_0;
		}

		private void method_2(bool bool_2)
		{
			if (this.progressBar_0.InvokeRequired)
			{
				Dispatcher.Invoke(this, delegate
				{
					this.progressBar_0.Style = (bool_2 ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks);
				});
				return;
			}
			this.progressBar_0.Style = (bool_2 ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks);
		}

		private void FormDocTamplateReference_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.bool_0 || this.bool_1)
			{
				MessageBox.Show("Пока выполняется обработка данных, окно не закроется. Пожалуйста подождите...", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.Cancel = true;
			}
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				MessageBox.Show(this, "Выполняется обработка данных. Пожалуйста подождите завершения.");
				return;
			}
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				DoWorkAsyncArgs argument = new DoWorkAsyncArgs(this.SqlSettings, (int)((DataRowView)this.bindingSource_0.Current)["id"], openFileDialog.FileName);
				this.backgroundWorker_0.RunWorkerAsync(argument);
			}
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			if (this.bool_1)
			{
				MessageBox.Show(this, "Выполняется обработка данных. Пожалуйста подождите завершения.");
				return;
			}
			if (this.dataGridViewExcelFilter_0.SelectedRows != null && this.dataGridViewExcelFilter_0.SelectedRows.Count > 0)
			{
				DoWorkAsyncArgs argument = new DoWorkAsyncArgs(this.SqlSettings, (int)this.dataGridViewExcelFilter_0.SelectedRows[0].Cells["id"].Value);
				this.backgroundWorker_1.RunWorkerAsync(argument);
			}
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.SelectedRows != null && this.dataGridViewExcelFilter_0.SelectedRows.Count > 0 && MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				try
				{
					this.method_1("Удаление шаблона...");
					this.sqlConnection_0 = new SqlConnection(this.SqlSettings.GetConnectionString());
					this.sqlConnection_0.Open();
					DbCommand dbCommand = new SqlCommand("DELETE FROM tR_DocTemplate WHERE id = " + this.dataGridViewExcelFilter_0.SelectedRows[0].Cells["id"].Value.ToString(), this.sqlConnection_0);
					string str = this.dataGridViewExcelFilter_0.SelectedRows[0].Cells["FileName"].Value.ToString();
					dbCommand.ExecuteNonQuery();
					this.method_0();
					this.method_1("Шаблон '" + str + "' удален.");
				}
				catch (Exception ex)
				{
					this.method_1(string.Format("Ошибка: '{0}'", ex.Message));
					if (this.sqlConnection_0 != null)
					{
						this.sqlConnection_0.Close();
					}
				}
				finally
				{
					if (this.sqlConnection_0 != null && this.sqlConnection_0.State != ConnectionState.Closed)
					{
						this.sqlConnection_0.Close();
					}
				}
			}
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			DoWorkAsyncArgs doWorkAsyncArgs = (DoWorkAsyncArgs)e.Argument;
			try
			{
				FileBinary fileBinary = new FileBinary(doWorkAsyncArgs.FileName);
				this.method_1("Соединение...");
				this.sqlConnection_0 = new SqlConnection(doWorkAsyncArgs.SqlSettings.GetConnectionString());
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.Connection = this.sqlConnection_0;
				sqlCommand.CommandText = "INSERT INTO tR_DocTemplate (idTypeDoc, FileName, FileData, Size, LastChange, DateIn) VALUES (@idTypeDoc, @FileName, @FileData, @Size, @LastChange, @DateIn)";
				sqlCommand.Parameters.Add("@idTypeDoc", SqlDbType.Int).Value = doWorkAsyncArgs.Id;
				sqlCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = fileBinary.Name;
				sqlCommand.Parameters.Add("@FileData", SqlDbType.VarBinary).Value = fileBinary.ByteArray;
				sqlCommand.Parameters.Add("@Size", SqlDbType.Float).Value = fileBinary.KbSize;
				sqlCommand.Parameters.Add("@LastChange", SqlDbType.SmallDateTime).Value = DateTime.Now;
				sqlCommand.Parameters.Add("@DateIn", SqlDbType.SmallDateTime).Value = DateTime.Now;
				this.sqlConnection_0.Open();
				this.method_1("Добавление шаблона...");
				this.method_2(true);
				this.bool_0 = true;
				sqlCommand.ExecuteNonQuery();
				e.Result = fileBinary.Name;
			}
			catch (SqlException ex)
			{
				this.bool_0 = false;
				int number = ex.Number;
				if (number != 2601)
				{
					throw;
				}
				this.method_1(string.Format("Ошибка: '{0}'", "Файл с таким именем уже существует!"));
				if (this.sqlConnection_0 != null)
				{
					this.sqlConnection_0.Close();
				}
			}
			catch (Exception ex2)
			{
				this.bool_0 = false;
				this.method_1(string.Format("Ошибка: '{0}'", ex2.Message));
				if (this.sqlConnection_0 != null)
				{
					this.sqlConnection_0.Close();
				}
			}
			finally
			{
				if (this.sqlConnection_0 != null && this.sqlConnection_0.State != ConnectionState.Closed)
				{
					this.sqlConnection_0.Close();
				}
			}
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.method_2(false);
			this.method_1("Шаблон '" + e.Result.ToString() + "' добавлен.");
			this.method_0();
			this.bool_0 = false;
		}

		private void backgroundWorker_1_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				this.bool_1 = true;
				DoWorkAsyncArgs doWorkAsyncArgs = (DoWorkAsyncArgs)e.Argument;
				this.method_1("Соединение...");
				this.sqlConnection_0 = new SqlConnection(doWorkAsyncArgs.SqlSettings.GetConnectionString());
				this.sqlConnection_0.Open();
				SqlCommand sqlCommand = this.sqlConnection_0.CreateCommand();
				sqlCommand.CommandText = "SELECT id, idTypeDoc, FileName, FileData, Size, LastChange, DateIn FROM tR_DocTemplate WHERE id = " + doWorkAsyncArgs.IdTemplate.ToString();
				DbDataAdapter dbDataAdapter = new SqlDataAdapter(sqlCommand);
				this.method_1("Открытие шаблона...");
				this.class255_0.tR_DocTemplate.Clear();
				dbDataAdapter.Fill(this.class255_0.tR_DocTemplate);
				FileBinary fileBinary = new FileBinary(this.class255_0.tR_DocTemplate.First<Class255.Class406>().FileData, this.class255_0.tR_DocTemplate.First<Class255.Class406>().FileName, this.class255_0.tR_DocTemplate.First<Class255.Class406>().LastChange);
				fileBinary.SaveToDisk(Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\\");
				Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Templates) + "\\" + fileBinary.Name);
				this.method_1("");
			}
			catch (Exception ex)
			{
				this.bool_1 = false;
				this.method_1(string.Format("Ошибка: '{0}'", ex.Message));
				if (this.sqlConnection_0 != null)
				{
					this.sqlConnection_0.Close();
				}
			}
			finally
			{
				if (this.sqlConnection_0 != null && this.sqlConnection_0.State != ConnectionState.Closed)
				{
					this.sqlConnection_0.Close();
				}
			}
		}

		private void backgroundWorker_1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.bool_1 = false;
		}

		private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.bool_1)
			{
				MessageBox.Show(this, "Выполняется обработка данных. Пожалуйста подождите завершения.");
				return;
			}
			if (this.dataGridViewExcelFilter_0.SelectedRows != null && this.dataGridViewExcelFilter_0.SelectedRows.Count > 0)
			{
				DoWorkAsyncArgs argument = new DoWorkAsyncArgs(this.SqlSettings, (int)this.dataGridViewExcelFilter_0.Rows[e.RowIndex].Cells["id"].Value);
				this.backgroundWorker_1.RunWorkerAsync(argument);
			}
		}

		private void bindingSource_0_CurrentChanged(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void method_3()
		{
			this.icontainer_0 = new Container();
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			this.tableLayoutPanel_0 = new TableLayoutPanel();
			this.button_0 = new Button();
			this.progressBar_0 = new ProgressBar();
			this.label_0 = new Label();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripComboBox_0 = new ToolStripComboBox();
			this.class255_0 = new Class255();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.backgroundWorker_0 = new BackgroundWorker();
			this.backgroundWorker_1 = new BackgroundWorker();
			this.tableLayoutPanel_0.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			this.toolStrip_0.SuspendLayout();
			((ISupportInitialize)this.class255_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			base.SuspendLayout();
			this.tableLayoutPanel_0.ColumnCount = 3;
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 383f));
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 111f));
			this.tableLayoutPanel_0.Controls.Add(this.button_0, 2, 2);
			this.tableLayoutPanel_0.Controls.Add(this.progressBar_0, 0, 3);
			this.tableLayoutPanel_0.Controls.Add(this.label_0, 1, 2);
			this.tableLayoutPanel_0.Controls.Add(this.dataGridViewExcelFilter_0, 0, 1);
			this.tableLayoutPanel_0.Dock = DockStyle.Fill;
			this.tableLayoutPanel_0.Location = new Point(0, 0);
			this.tableLayoutPanel_0.Name = "tableLayoutPanel2";
			this.tableLayoutPanel_0.RowCount = 5;
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 8f));
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 8f));
			this.tableLayoutPanel_0.Size = new Size(665, 338);
			this.tableLayoutPanel_0.TabIndex = 29;
			this.button_0.Dock = DockStyle.Left;
			this.button_0.Location = new Point(564, 303);
			this.button_0.Margin = new Padding(10, 6, 3, 6);
			this.button_0.Name = "btnCancel";
			this.tableLayoutPanel_0.SetRowSpan(this.button_0, 3);
			this.button_0.Size = new Size(75, 29);
			this.button_0.TabIndex = 6;
			this.button_0.Text = "Закрыть";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += this.button_0_Click;
			this.progressBar_0.Dock = DockStyle.Fill;
			this.progressBar_0.Location = new Point(8, 308);
			this.progressBar_0.Margin = new Padding(8, 3, 3, 3);
			this.progressBar_0.Name = "pbStatus";
			this.progressBar_0.Size = new Size(160, 19);
			this.progressBar_0.TabIndex = 7;
			this.label_0.AutoSize = true;
			this.label_0.Dock = DockStyle.Fill;
			this.label_0.Location = new Point(179, 297);
			this.label_0.Margin = new Padding(8, 0, 3, 0);
			this.label_0.Name = "lbStatus";
			this.tableLayoutPanel_0.SetRowSpan(this.label_0, 3);
			this.label_0.Size = new Size(372, 41);
			this.label_0.TabIndex = 8;
			this.label_0.TextAlign = ContentAlignment.MiddleLeft;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToResizeRows = false;
			this.dataGridViewExcelFilter_0.BackgroundColor = Color.White;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dataGridViewExcelFilter_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewFilterTextBoxColumn_0,
				this.dataGridViewFilterTextBoxColumn_1,
				this.dataGridViewFilterTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_1
			});
			this.tableLayoutPanel_0.SetColumnSpan(this.dataGridViewExcelFilter_0, 3);
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.Location = new Point(3, 28);
			this.dataGridViewExcelFilter_0.Name = "dgvDocTemplates";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_0.Size = new Size(659, 266);
			this.dataGridViewExcelFilter_0.TabIndex = 9;
			this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "id";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewFilterTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "FileName";
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Наименование файла";
			this.dataGridViewFilterTextBoxColumn_0.Name = "FileName";
			this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "Size";
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Размер файла, кБ";
			this.dataGridViewFilterTextBoxColumn_1.Name = "SizeFile";
			this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.Visible = false;
			this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "LastChange";
			this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Дата последнего изменения";
			this.dataGridViewFilterTextBoxColumn_2.Name = "LastChange";
			this.dataGridViewFilterTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_2.Width = 150;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "Deleted";
			this.dataGridViewTextBoxColumn_1.HeaderText = "Deleted";
			this.dataGridViewTextBoxColumn_1.Name = "Deleted";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripButton_2,
				this.toolStripSeparator_0,
				this.toolStripButton_1,
				this.toolStripSeparator_1,
				this.toolStripComboBox_0
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStrip1";
			this.toolStrip_0.Size = new Size(665, 25);
			this.toolStrip_0.TabIndex = 30;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.ElementAdd;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "tsbAddFile";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Добавить шаблон";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.ElementDel;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "tsbDeleteFile";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Удалить шаблон";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator1";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.PrintPreView;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "tsbShowFile";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Отобразить шаблон";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator2";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripComboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
			this.toolStripComboBox_0.Name = "tscbTypeDoc";
			this.toolStripComboBox_0.Size = new Size(270, 25);
			this.class255_0.DataSetName = "DataSetGES";
			this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.bindingSource_0.DataMember = "tR_Classifier";
			this.bindingSource_0.DataSource = this.class255_0;
			this.bindingSource_0.CurrentChanged += this.bindingSource_0_CurrentChanged;
			this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
			this.backgroundWorker_0.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
			this.backgroundWorker_1.DoWork += this.backgroundWorker_1_DoWork;
			this.backgroundWorker_1.RunWorkerCompleted += this.backgroundWorker_1_RunWorkerCompleted;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(665, 338);
			base.Controls.Add(this.toolStrip_0);
			base.Controls.Add(this.tableLayoutPanel_0);
			base.Name = "FormDocTamplateReference";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Справочник шаблонов";
			base.FormClosing += this.FormDocTamplateReference_FormClosing;
			base.Load += this.FormDocTamplateReference_Load;
			this.tableLayoutPanel_0.ResumeLayout(false);
			this.tableLayoutPanel_0.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			((ISupportInitialize)this.class255_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		internal static void PvUuThrLg8bRlZcr94vg(Form form_0, bool bool_2)
		{
			form_0.Dispose(bool_2);
		}

		private bool bool_0;

		private bool bool_1;

		private SqlConnection sqlConnection_0;

		private int int_0;

		private TableLayoutPanel tableLayoutPanel_0;

		private Button button_0;

		private ProgressBar progressBar_0;

		private Label label_0;

		private ToolStrip toolStrip_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton toolStripButton_2;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripComboBox toolStripComboBox_0;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private Class255 class255_0;

		private BindingSource bindingSource_0;

		private BackgroundWorker backgroundWorker_0;

		private BackgroundWorker backgroundWorker_1;

		private delegate void Delegate72(string Text);

		private delegate void Delegate73();
	}
}
