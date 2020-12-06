using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using Documents;
using FormLbr;

internal partial class Form1 : FormBase
{
	[Browsable(false)]
	internal FormBase FormBase_0
	{
		get
		{
			return this.formBase_0;
		}
		set
		{
			this.formBase_0 = value;
		}
	}

	internal Form1()
	{
		
		this.string_0 = "tAbn";
		this.int_0 = 50;
		
		this.method_0();
		this.dataGridViewExcelFilter_0.VirtualMode = true;
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.CellValueNeeded += this.dataGridViewExcelFilter_0_CellValueNeeded;
		base.Load += this.Form1_Load;
		this.dataGridViewExcelFilter_0.DataError += this.xPjywhNtvf;
		base.KeyPreview = true;
	}

	private void dataGridViewExcelFilter_0_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
	{
		if (this.dataGridViewExcelFilter_0.Columns[e.ColumnIndex].DataPropertyName != null && !(this.dataGridViewExcelFilter_0.Columns[e.ColumnIndex].DataPropertyName == ""))
		{
			if (this.dataGridViewExcelFilter_0.Columns[e.ColumnIndex].Tag != null)
			{
				this.parametryColumnsDataGridView_0 = (ClassesDoc.ParametryColumnsDataGridView)((object[])this.dataGridViewExcelFilter_0.Columns[e.ColumnIndex].Tag)[0];
				this.dataTable_1 = (DataTable)this.parametryColumnsDataGridView_0.DataSource;
				try
				{
					e.Value = this.dataTable_1.Select(this.parametryColumnsDataGridView_0.ValueMember + " = " + this.dataGridViewExcelFilter_0[3, e.RowIndex].Value)[0][this.parametryColumnsDataGridView_0.DisplayMember];
				}
				catch
				{
				}
			}
			return;
		}
		e.Value = this.cache_0.RetrieveElement(e.RowIndex, e.ColumnIndex);
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		this.dataGridViewExcelFilter_0.Columns.Clear();
		this.dataTable_0 = base.SelectSqlData("tR_Classifier", true, "where [ParentKey] = ';SKUEE;TypeAbn;' and [ISGroup] = 'false'");
		try
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(new ClassesDoc.ParametryColumnsDataGridView("id", "", false));
			arrayList.Add(new ClassesDoc.ParametryColumnsDataGridView
			{
				Column = "CodeAbonent",
				Name = "Код"
			});
			arrayList.Add(new ClassesDoc.ParametryColumnsDataGridView("Name", "Наименование"));
			arrayList.Add(new ClassesDoc.ParametryColumnsDataGridView("TypeAbn", "Тип абонента", true, this.dataTable_0, "Name", "Id"));
			arrayList.Add(new ClassesDoc.ParametryColumnsDataGridView("Deleted", "", false));
			Documents.DataRetriever dataRetriever = new Documents.DataRetriever(this.SqlSettings, this.string_0, arrayList);
			this.cache_0 = new Documents.Cache(dataRetriever, this.int_0);
			foreach (object obj in arrayList)
			{
				DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
				dataGridViewTextBoxColumn.ReadOnly = true;
				this.dataGridViewExcelFilter_0.Columns.Add(dataGridViewTextBoxColumn);
				if (((ClassesDoc.ParametryColumnsDataGridView)obj).DataSource != null)
				{
					dataGridViewTextBoxColumn.Visible = false;
					dataGridViewTextBoxColumn.Name = (string)((ClassesDoc.ParametryColumnsDataGridView)obj).Column;
					DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
					dataGridViewTextBoxColumn2.DataPropertyName = (string)((ClassesDoc.ParametryColumnsDataGridView)obj).Column;
					dataGridViewTextBoxColumn2.Tag = new object[]
					{
						(ClassesDoc.ParametryColumnsDataGridView)obj,
						dataGridViewTextBoxColumn.Index
					};
					dataGridViewTextBoxColumn2.HeaderText = ((ClassesDoc.ParametryColumnsDataGridView)obj).Name;
					dataGridViewTextBoxColumn2.Name = (string)((ClassesDoc.ParametryColumnsDataGridView)obj).Column;
					dataGridViewTextBoxColumn2.Visible = true;
					dataGridViewTextBoxColumn2.Width = 150;
					this.dataGridViewExcelFilter_0.Columns.Add(dataGridViewTextBoxColumn2);
				}
				else
				{
					dataGridViewTextBoxColumn.Name = (string)((ClassesDoc.ParametryColumnsDataGridView)obj).Column;
					dataGridViewTextBoxColumn.HeaderText = ((ClassesDoc.ParametryColumnsDataGridView)obj).Name;
					dataGridViewTextBoxColumn.Visible = ((ClassesDoc.ParametryColumnsDataGridView)obj).Visible;
				}
			}
			this.dataGridViewExcelFilter_0.RowCount = dataRetriever.RowCount;
		}
		catch (SqlException)
		{
			MessageBox.Show("Connection could not be established. Verify that the connection string is valid.");
			Application.Exit();
		}
		this.dataGridViewExcelFilter_0.Select();
	}

	private void xPjywhNtvf(object sender, DataGridViewDataErrorEventArgs e)
	{
		MessageBox.Show("Error happened " + e.Context.ToString());
		if (e.Context == DataGridViewDataErrorContexts.Commit)
		{
			MessageBox.Show("Commit error");
		}
		if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
		{
			MessageBox.Show("Cell change");
		}
		if (e.Context == DataGridViewDataErrorContexts.Parsing)
		{
			MessageBox.Show("parsing error");
		}
		if (e.Context == DataGridViewDataErrorContexts.LeaveControl)
		{
			MessageBox.Show("leave control error");
		}
		if (e.Exception is ConstraintException)
		{
			DataGridView dataGridView = (DataGridView)sender;
			dataGridView.Rows[e.RowIndex].ErrorText = "an error";
			dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";
			e.ThrowException = false;
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void dataGridViewExcelFilter_0_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		this.FormBase_0.Tag = new ClassesDoc.Parametry
		{
			Id = this.dataGridViewExcelFilter_0.CurrentRow.Cells["id"].Value,
			Name = this.dataGridViewExcelFilter_0.CurrentRow.Cells["Name"].Value
		};
		base.Close();
	}

	private void dataGridViewExcelFilter_0_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return && this.dataGridViewExcelFilter_0.CurrentCell != null && !this.dataGridViewExcelFilter_0.CurrentCell.IsInEditMode)
		{
			this.FormBase_0.Tag = new ClassesDoc.Parametry
			{
				Id = this.dataGridViewExcelFilter_0.CurrentRow.Cells["id"].Value,
				Name = this.dataGridViewExcelFilter_0.CurrentRow.Cells["Name"].Value
			};
			base.Close();
		}
	}

	private void method_0()
	{
		this.panel_0 = new Panel();
		this.button_0 = new Button();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.panel_0.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		base.SuspendLayout();
		this.panel_0.Controls.Add(this.button_0);
		this.panel_0.Dock = DockStyle.Bottom;
		this.panel_0.Location = new Point(0, 214);
		this.panel_0.Name = "panel1";
		this.panel_0.Size = new Size(389, 34);
		this.panel_0.TabIndex = 3;
		this.button_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Location = new Point(318, 6);
		this.button_0.Name = "btnClose";
		this.button_0.Size = new Size(68, 23);
		this.button_0.TabIndex = 13;
		this.button_0.Text = "Закрыть";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_0.BackgroundColor = SystemColors.Control;
		this.dataGridViewExcelFilter_0.BorderStyle = BorderStyle.None;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_0.Location = new Point(0, 0);
		this.dataGridViewExcelFilter_0.Name = "GridView";
		this.dataGridViewExcelFilter_0.RowHeadersWidth = 21;
		this.dataGridViewExcelFilter_0.Size = new Size(389, 214);
		this.dataGridViewExcelFilter_0.TabIndex = 6;
		this.dataGridViewExcelFilter_0.VirtualMode = true;
		this.dataGridViewExcelFilter_0.CellMouseDoubleClick += this.dataGridViewExcelFilter_0_CellMouseDoubleClick;
		this.dataGridViewExcelFilter_0.KeyDown += this.dataGridViewExcelFilter_0_KeyDown;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_0;
		base.ClientSize = new Size(389, 248);
		base.Controls.Add(this.dataGridViewExcelFilter_0);
		base.Controls.Add(this.panel_0);
		base.MinimizeBox = false;
		base.Name = "FormSelectAbonent";
		this.Text = "Выбор абонента...";
		this.panel_0.ResumeLayout(false);
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		base.ResumeLayout(false);
	}

	private FormBase formBase_0;

	private Documents.Cache cache_0;

	private DataTable dataTable_0;

	private ClassesDoc.ParametryColumnsDataGridView parametryColumnsDataGridView_0;

	private DataTable dataTable_1;

	private string string_0;

	private int int_0;

	private Panel panel_0;

	private Button button_0;

	public DataGridViewExcelFilter dataGridViewExcelFilter_0;
}
