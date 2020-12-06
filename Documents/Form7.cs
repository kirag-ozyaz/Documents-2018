using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

internal partial class Form7 : FormBase
{
	internal Form7(SQLSettings sqlsettings_0)
	{
		
		this.int_0 = -1;
		this.list_0 = new List<int>();
		
		this.method_2();
		this.dataTable_0 = this.dataSet_0.Tables["tblAbnReqFiles"];
		this.dataTable_1 = this.dataSet_1.Tables["tblAbnReqFiles"];
		this.SqlSettings = sqlsettings_0;
	}

	internal Form7(SQLSettings sqlsettings_0, int int_1)
	{
		
		this.int_0 = -1;
		this.list_0 = new List<int>();
		
		this.method_2();
		this.int_0 = int_1;
		this.dataTable_0 = this.dataSet_0.Tables["tblAbnReqFiles"];
		this.dataTable_1 = this.dataSet_1.Tables["tblAbnReqFiles"];
		this.method_0();
	}

	internal int IdRequest
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

	internal void method_0()
	{
		if (this.int_0 == -1)
		{
			return;
		}
		this.dataTable_0.Clear();
		base.SelectSqlData(this.dataSet_0, this.dataTable_0, true, "where IdRequest = " + this.int_0.ToString());
	}

	internal void method_1()
	{
		if (this.int_0 == -1)
		{
			return;
		}
		DataTable changes = this.dataTable_0.GetChanges(DataRowState.Added);
		if (changes != null)
		{
			this.dataTable_1.Clear();
			foreach (object obj in changes.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				DataRow dataRow2 = this.dataTable_1.NewRow();
				dataRow2["idRequest"] = this.IdRequest;
				dataRow2["FileName"] = dataRow["FileName"];
				dataRow2["AttachedFile"] = File.ReadAllBytes(dataRow["FileName"].ToString());
				this.dataTable_1.Rows.Add(dataRow2);
			}
			base.InsertSqlData(this.dataSet_1, this.dataTable_1);
		}
		base.DeleteSqlData(this.dataSet_0, this.dataTable_0);
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			this.bool_0 = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				for (int i = 0; i < openFileDialog.FileNames.Length; i++)
				{
					DataRow dataRow = this.dataSet_0.Tables[0].NewRow();
					dataRow["idRequest"] = -1;
					dataRow["FileName"] = openFileDialog.FileNames[i];
					this.dataSet_0.Tables[0].Rows.Add(dataRow);
				}
			}
			this.bool_0 = false;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.Source);
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		if (this.dataGridView_0.CurrentRow != null)
		{
			int index = this.dataGridView_0.CurrentRow.Index;
			this.dataTable_0.Rows[index].Delete();
			return;
		}
		MessageBox.Show("Не выбрано ни одного файла");
	}

	private void dataGridView_0_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
	{
		if (this.dataGridView_0.RowCount > 0 && this.dataGridView_0["filenameDgvTxtColumn", e.RowIndex].Value != null)
		{
			if (e.ColumnIndex == this.dataGridView_0.Columns["shortFileNameDgvTxtColumn"].Index)
			{
				e.Value = Path.GetFileName(this.dataGridView_0["filenameDgvTxtColumn", e.RowIndex].Value.ToString());
			}
			if (e.ColumnIndex == this.dataGridView_0.Columns["ColumnImage"].Index)
			{
				Icon icon = FormLbr.Classes.FileInfo.IconOfFile(this.dataGridView_0["filenameDgvTxtColumn", e.RowIndex].Value.ToString());
				e.Value = icon.ToBitmap();
			}
		}
	}

	private void dataGridView_0_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		if (this.dataGridView_0.CurrentRow == null)
		{
			return;
		}
		int num = Convert.ToInt32(this.dataTable_0.Rows[this.dataGridView_0.CurrentRow.Index]["Id"]);
		if (num <= 0)
		{
			return;
		}
		this.dataTable_1.Clear();
		base.SelectSqlData(this.dataSet_1, this.dataTable_1, true, "where Id =" + num.ToString());
		byte[] array = (byte[])this.dataTable_1.Rows[0]["AttachedFile"];
		string text = Path.GetTempFileName();
		text = Path.ChangeExtension(text, Path.GetExtension(this.dataTable_0.Rows[this.dataGridView_0.CurrentRow.Index]["FileName"].ToString()));
		FileStream fileStream = File.Create(text);
		fileStream.Write(array, 0, array.Length);
		fileStream.Close();
		new Process
		{
			StartInfo = 
			{
				FileName = text,
				UseShellExecute = true
			}
		}.Start();
	}

	private void dataGridView_0_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			int rowIndex = e.RowIndex;
		}
	}

	private void Form7_Load(object sender, EventArgs e)
	{
	}

	protected override void OnDeactivate(EventArgs eventArgs_0)
	{
		if (!this.bool_0)
		{
			base.OnDeactivate(eventArgs_0);
			base.Hide();
		}
	}

	private void method_2()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripButton_1 = new ToolStripButton();
		this.dataSet_0 = new DataSet();
		this.dataTable_2 = new DataTable();
		this.dataColumn_0 = new DataColumn();
		this.dataColumn_1 = new DataColumn();
		this.dataColumn_2 = new DataColumn();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
		this.dataGridViewLinkColumn_0 = new DataGridViewLinkColumn();
		this.dataSet_1 = new DataSet();
		this.dataTable_3 = new DataTable();
		this.dataColumn_3 = new DataColumn();
		this.dataColumn_4 = new DataColumn();
		this.dataColumn_5 = new DataColumn();
		this.toolStrip_0.SuspendLayout();
		((ISupportInitialize)this.dataSet_0).BeginInit();
		((ISupportInitialize)this.dataTable_2).BeginInit();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		((ISupportInitialize)this.dataSet_1).BeginInit();
		((ISupportInitialize)this.dataTable_3).BeginInit();
		base.SuspendLayout();
		this.toolStrip_0.Dock = DockStyle.None;
		this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripButton_1
		});
		this.toolStrip_0.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
		this.toolStrip_0.Location = new Point(9, 9);
		this.toolStrip_0.Name = "toolStrip";
		this.toolStrip_0.Size = new Size(24, 48);
		this.toolStrip_0.TabIndex = 16;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources.ElementAdd;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtnAdd";
		this.toolStripButton_0.Size = new Size(22, 20);
		this.toolStripButton_0.Text = "Добавить файл";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = Resources.ElementDel;
		this.toolStripButton_1.ImageTransparentColor = Color.Transparent;
		this.toolStripButton_1.Name = "toolBtnDel";
		this.toolStripButton_1.Size = new Size(22, 20);
		this.toolStripButton_1.Text = "Удалить";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.dataSet_0.DataSetName = "NewDataSet";
		this.dataSet_0.Tables.AddRange(new DataTable[]
		{
			this.dataTable_2
		});
		this.dataTable_2.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_0,
			this.dataColumn_1,
			this.dataColumn_2
		});
		this.dataTable_2.Constraints.AddRange(new Constraint[]
		{
			new UniqueConstraint("Constraint1", new string[]
			{
				"Id"
			}, true)
		});
		this.dataTable_2.PrimaryKey = new DataColumn[]
		{
			this.dataColumn_0
		};
		this.dataTable_2.TableName = "tblAbnReqFiles";
		this.dataColumn_0.AllowDBNull = false;
		this.dataColumn_0.AutoIncrement = true;
		this.dataColumn_0.ColumnName = "Id";
		this.dataColumn_0.DataType = typeof(int);
		this.dataColumn_1.ColumnName = "IdRequest";
		this.dataColumn_1.DataType = typeof(int);
		this.dataColumn_2.ColumnName = "FileName";
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.AllowUserToResizeColumns = false;
		this.dataGridView_0.AllowUserToResizeRows = false;
		this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_0.AutoGenerateColumns = false;
		this.dataGridView_0.BackgroundColor = SystemColors.Control;
		this.dataGridView_0.BorderStyle = BorderStyle.Fixed3D;
		this.dataGridView_0.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		this.dataGridView_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.ColumnHeadersVisible = false;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewImageColumnNotNull_0,
			this.dataGridViewLinkColumn_0
		});
		this.dataGridView_0.DataMember = "tblAbnReqFiles";
		this.dataGridView_0.DataSource = this.dataSet_0;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		this.dataGridView_0.DefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridView_0.GridColor = SystemColors.Control;
		this.dataGridView_0.Location = new Point(36, 9);
		this.dataGridView_0.MultiSelect = false;
		this.dataGridView_0.Name = "dgvDocs";
		this.dataGridView_0.ReadOnly = true;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		this.dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
		this.dataGridView_0.RowHeadersVisible = false;
		this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_0.Size = new Size(274, 204);
		this.dataGridView_0.TabIndex = 17;
		this.dataGridView_0.VirtualMode = true;
		this.dataGridView_0.CellContentClick += this.dataGridView_0_CellContentClick;
		this.dataGridView_0.CellMouseClick += this.dataGridView_0_CellMouseClick;
		this.dataGridView_0.CellValueNeeded += this.dataGridView_0_CellValueNeeded;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "FileName";
		this.dataGridViewTextBoxColumn_0.HeaderText = "FileName";
		this.dataGridViewTextBoxColumn_0.Name = "fileNameDgvTxtColumn";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "Id";
		this.dataGridViewTextBoxColumn_1.HeaderText = "Id";
		this.dataGridViewTextBoxColumn_1.Name = "IdDocDgvTxtColumn";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.Visible = false;
		dataGridViewCellStyle4.NullValue = null;
		this.dataGridViewImageColumnNotNull_0.DefaultCellStyle = dataGridViewCellStyle4;
		this.dataGridViewImageColumnNotNull_0.HeaderText = "";
		this.dataGridViewImageColumnNotNull_0.ImageLayout = DataGridViewImageCellLayout.Zoom;
		this.dataGridViewImageColumnNotNull_0.Name = "ColumnImage";
		this.dataGridViewImageColumnNotNull_0.ReadOnly = true;
		this.dataGridViewImageColumnNotNull_0.Width = 30;
		this.dataGridViewLinkColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewLinkColumn_0.HeaderText = "Файл";
		this.dataGridViewLinkColumn_0.Name = "shortFileNameDgvTxtColumn";
		this.dataGridViewLinkColumn_0.ReadOnly = true;
		this.dataGridViewLinkColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewLinkColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataSet_1.DataSetName = "NewDataSet";
		this.dataSet_1.Tables.AddRange(new DataTable[]
		{
			this.dataTable_3
		});
		this.dataTable_3.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_3,
			this.dataColumn_4,
			this.dataColumn_5
		});
		this.dataTable_3.TableName = "tblAbnReqFiles";
		this.dataColumn_3.ColumnName = "IdRequest";
		this.dataColumn_3.DataType = typeof(int);
		this.dataColumn_4.ColumnName = "AttachedFile";
		this.dataColumn_4.DataType = typeof(byte[]);
		this.dataColumn_5.ColumnName = "FileName";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(322, 225);
		base.ControlBox = false;
		base.Controls.Add(this.dataGridView_0);
		base.Controls.Add(this.toolStrip_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Name = "FormFiles";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.Manual;
		base.Load += this.Form7_Load;
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		((ISupportInitialize)this.dataSet_0).EndInit();
		((ISupportInitialize)this.dataTable_2).EndInit();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		((ISupportInitialize)this.dataSet_1).EndInit();
		((ISupportInitialize)this.dataTable_3).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private int int_0;

	private bool bool_0;

	private List<int> list_0;

	private DataTable dataTable_0;

	private DataTable dataTable_1;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private DataSet dataSet_0;

	private DataTable dataTable_2;

	private DataColumn dataColumn_0;

	private DataColumn dataColumn_1;

	private DataColumn dataColumn_2;

	private DataGridView dataGridView_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

	private DataGridViewLinkColumn dataGridViewLinkColumn_0;

	private DataSet dataSet_1;

	private DataTable dataTable_3;

	private DataColumn dataColumn_3;

	private DataColumn dataColumn_4;

	private DataColumn dataColumn_5;
}
