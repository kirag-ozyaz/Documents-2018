using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using FormLbr;

internal partial class Form15 : FormBase
{
	internal Form15()
	{
		
		
		this.method_1();
	}

	private void Form15_Load(object sender, EventArgs e)
	{
		DataTable dataTable = this.method_0();
		base.SelectSqlData(dataTable, true, string.Format("where Module = '{0}'", "TypeWorkTU"), null, false, 0);
		try
		{
			if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["Settings"] != DBNull.Value)
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(dataTable.Rows[0]["Settings"].ToString());
				XmlNodeReader xmlNodeReader = new XmlNodeReader(xmlDocument);
				this.dataSet_0.ReadXml(xmlNodeReader);
				xmlNodeReader.Close();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.Source);
		}
	}

	private void Form15_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			for (int i = this.dataGridView_0.Rows.Count - 2; i >= 0; i--)
			{
				if (this.dataGridView_0[this.dataGridViewTextBoxColumn_1.Name, i].Value == null || this.dataGridView_0[this.dataGridViewTextBoxColumn_1.Name, i].Value == DBNull.Value || string.IsNullOrEmpty(this.dataGridView_0[this.dataGridViewTextBoxColumn_1.Name, i].Value.ToString()))
				{
					this.dataGridView_0.Rows.RemoveAt(i);
				}
			}
			for (int j = this.dataGridView_1.Rows.Count - 2; j >= 0; j--)
			{
				if (this.dataGridView_1[this.dataGridViewTextBoxColumn_0.Name, j].Value == null || this.dataGridView_1[this.dataGridViewTextBoxColumn_0.Name, j].Value == DBNull.Value || string.IsNullOrEmpty(this.dataGridView_1[this.dataGridViewTextBoxColumn_0.Name, j].Value.ToString()))
				{
					this.dataGridView_1.Rows.RemoveAt(j);
				}
			}
			StringWriter stringWriter = new StringWriter();
			this.dataSet_0.WriteXml(new XmlTextWriter(stringWriter));
			XmlDocument xmlDocument = new XmlDocument();
			string xml = stringWriter.ToString();
			xmlDocument.LoadXml(xml);
			DataTable dataTable = this.method_0();
			base.SelectSqlData(dataTable, true, string.Format("where Module = '{0}'", "TypeWorkTU"), null, false, 0);
			if (dataTable.Rows.Count > 0)
			{
				dataTable.Rows[0]["Settings"] = xmlDocument.InnerXml;
				dataTable.Rows[0].EndEdit();
				if (!base.UpdateSqlData(dataTable))
				{
					e.Cancel = true;
					return;
				}
			}
			else
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["Module"] = "TypeWorkTU";
				dataRow["settings"] = xmlDocument.InnerXml;
				dataTable.Rows.Add(dataRow);
				if (!base.InsertSqlData(dataTable))
				{
					e.Cancel = true;
					return;
				}
			}
		}
	}

	private DataTable method_0()
	{
		DataTable dataTable = new DataTable("tSettings");
		DataColumn dataColumn = dataTable.Columns.Add("id", typeof(int));
		dataColumn.AutoIncrement = true;
		dataTable.PrimaryKey = new DataColumn[]
		{
			dataColumn
		};
		dataTable.Columns.Add("settings", typeof(string));
		dataTable.Columns.Add("module", typeof(string));
		return dataTable;
	}

	private void method_1()
	{
		this.icontainer_0 = new Container();
		this.dataSet_0 = new DataSet();
		this.dataTable_0 = new DataTable();
		this.dataTable_1 = new DataTable();
		this.dataColumn_0 = new DataColumn();
		this.dataColumn_1 = new DataColumn();
		this.dataGridView_0 = new DataGridView();
		this.dataGridView_1 = new DataGridView();
		this.button_0 = new Button();
		this.phxbwnnwac = new Button();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		((ISupportInitialize)this.dataSet_0).BeginInit();
		((ISupportInitialize)this.dataTable_0).BeginInit();
		((ISupportInitialize)this.dataTable_1).BeginInit();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		((ISupportInitialize)this.dataGridView_1).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		base.SuspendLayout();
		this.dataSet_0.DataSetName = "NewDataSet";
		this.dataSet_0.Tables.AddRange(new DataTable[]
		{
			this.dataTable_0,
			this.dataTable_1
		});
		this.dataTable_0.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_0
		});
		this.dataTable_0.TableName = "netWork";
		this.dataTable_1.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_1
		});
		this.dataTable_1.TableName = "clientWork";
		this.dataColumn_0.ColumnName = "Name";
		this.dataColumn_1.ColumnName = "Name";
		this.dataGridView_0.AllowUserToResizeColumns = false;
		this.dataGridView_0.AllowUserToResizeRows = false;
		this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_0.AutoGenerateColumns = false;
		this.dataGridView_0.BackgroundColor = SystemColors.Window;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_1
		});
		this.dataGridView_0.DataSource = this.bindingSource_0;
		this.dataGridView_0.Location = new Point(0, -1);
		this.dataGridView_0.Name = "dgvNet";
		this.dataGridView_0.Size = new Size(636, 244);
		this.dataGridView_0.TabIndex = 0;
		this.dataGridView_1.AllowUserToResizeColumns = false;
		this.dataGridView_1.AllowUserToResizeRows = false;
		this.dataGridView_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_1.AutoGenerateColumns = false;
		this.dataGridView_1.BackgroundColor = SystemColors.Window;
		this.dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_1.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0
		});
		this.dataGridView_1.DataMember = "clientWork";
		this.dataGridView_1.DataSource = this.dataSet_0;
		this.dataGridView_1.Location = new Point(0, 239);
		this.dataGridView_1.Name = "dgvClient";
		this.dataGridView_1.Size = new Size(636, 244);
		this.dataGridView_1.TabIndex = 1;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(12, 489);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 2;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.phxbwnnwac.DialogResult = DialogResult.Cancel;
		this.phxbwnnwac.Location = new Point(550, 489);
		this.phxbwnnwac.Name = "buttonCancel";
		this.phxbwnnwac.Size = new Size(75, 23);
		this.phxbwnnwac.TabIndex = 3;
		this.phxbwnnwac.Text = "Отмена";
		this.phxbwnnwac.UseVisualStyleBackColor = true;
		this.dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "Name";
		this.dataGridViewTextBoxColumn_0.HeaderText = "Работы заказчика";
		this.dataGridViewTextBoxColumn_0.Name = "clientWorkDgvColumn";
		this.bindingSource_0.DataMember = "netWork";
		this.bindingSource_0.DataSource = this.dataSet_0;
		this.dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "Name";
		this.dataGridViewTextBoxColumn_1.HeaderText = "Работы сетевой организации";
		this.dataGridViewTextBoxColumn_1.Name = "netWorkDgvColumn";
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.phxbwnnwac;
		base.ClientSize = new Size(637, 522);
		base.Controls.Add(this.phxbwnnwac);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.dataGridView_1);
		base.Controls.Add(this.dataGridView_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormReferenceTypeWork";
		this.Text = "Справочник типов работ";
		base.FormClosing += this.Form15_FormClosing;
		base.Load += this.Form15_Load;
		((ISupportInitialize)this.dataSet_0).EndInit();
		((ISupportInitialize)this.dataTable_0).EndInit();
		((ISupportInitialize)this.dataTable_1).EndInit();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		((ISupportInitialize)this.dataGridView_1).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		base.ResumeLayout(false);
	}

	private DataSet dataSet_0;

	private DataTable dataTable_0;

	private DataColumn dataColumn_0;

	private DataTable dataTable_1;

	private DataColumn dataColumn_1;

	private DataGridView dataGridView_0;

	private DataGridView dataGridView_1;

	private Button button_0;

	private Button phxbwnnwac;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private BindingSource bindingSource_0;
}
