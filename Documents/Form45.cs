using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using Documents.Properties;
using FormLbr;

internal partial class Form45 : FormBase
{
	internal Form45(SQLSettings sqlsettings_0, int int_0)
	{
		
		
		this.method_0();
		this.SqlSettings = sqlsettings_0;
		base.SelectSqlData(this.dataTable_1, true, "where deleted = 0 and [year] is not null group by [Year] order by [Year]", null, false, 0);
		foreach (object obj in this.dataTable_1.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			this.toolStripComboBox_0.Items.Add(dataRow[0]);
			this.toolStripComboBox_1.Items.Add(dataRow[0]);
			if ((int)dataRow[0] == int_0)
			{
				this.toolStripComboBox_0.SelectedIndex = this.toolStripComboBox_0.Items.Count - 1;
				this.toolStripComboBox_1.SelectedIndex = this.toolStripComboBox_1.Items.Count - 1;
			}
		}
		if (this.toolStripComboBox_0.SelectedIndex == -1)
		{
			this.toolStripComboBox_0.SelectedIndex = this.toolStripComboBox_0.Items.Count - 1;
			this.toolStripComboBox_1.SelectedIndex = this.toolStripComboBox_1.Items.Count - 1;
		}
	}

	private void Form45_Load(object sender, EventArgs e)
	{
		this.cRboiYehpbD();
	}

	private void toolStripComboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.toolStripComboBox_0.SelectedIndex > this.toolStripComboBox_1.SelectedIndex)
		{
			this.toolStripComboBox_1.SelectedIndex = this.toolStripComboBox_0.SelectedIndex;
		}
	}

	private void toolStripComboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.toolStripComboBox_0.SelectedIndex > this.toolStripComboBox_1.SelectedIndex)
		{
			this.toolStripComboBox_0.SelectedIndex = this.toolStripComboBox_1.SelectedIndex;
		}
	}

	private void cRboiYehpbD()
	{
		this.Cursor = Cursors.WaitCursor;
		int num = (int)this.toolStripComboBox_0.SelectedItem;
		int num2 = (int)this.toolStripComboBox_1.SelectedItem;
		if (num > num2)
		{
			this.Cursor = Cursors.Default;
			return;
		}
		DataGridViewCell cellTemplate = this.dataGridViewExcelFilter_0.Columns[0].CellTemplate;
		this.bindingSource_0.Filter = string.Empty;
		if (this.dataTable_0.Rows.Count > 0)
		{
			this.dataTable_0.Rows.Clear();
		}
		if (this.dataTable_0.Columns.Count > 0)
		{
			this.dataTable_0.Columns.Clear();
		}
		if (this.dataGridViewExcelFilter_0.Rows.Count > 0)
		{
			this.dataGridViewExcelFilter_0.Rows.Clear();
		}
		if (this.dataGridViewExcelFilter_0.Columns.Count > 0)
		{
			this.dataGridViewExcelFilter_0.Columns.Clear();
		}
		int num3 = 5 + (num2 - num);
		DataGridViewColumn[] array = new DataGridViewColumn[num3];
		DataColumn[] array2 = new DataColumn[num3 + 2];
		array2[0] = new DataColumn();
		array2[0].ColumnName = "tpname";
		array2[1] = new DataColumn();
		array2[1].ColumnName = "CharValue";
		array2[2] = new DataColumn();
		array2[2].ColumnName = "transname";
		array2[3] = new DataColumn();
		array2[3].ColumnName = "typeCaption";
		array[0] = new DataGridViewFilterTextBoxColumn();
		array[0].HeaderText = "Объект";
		array[0].DataPropertyName = "tpname";
		array[0].Name = "tpname";
		array[0].ReadOnly = true;
		array[0].ValueType = typeof(string);
		array[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		array[0].MinimumWidth = 100;
		array[1] = new DataGridViewFilterTextBoxColumn();
		array[1].HeaderText = "Принадлежность";
		array[1].DataPropertyName = "CharValue";
		array[1].Name = "CharValue";
		array[1].ReadOnly = true;
		array[1].ValueType = typeof(string);
		array[2] = new DataGridViewFilterTextBoxColumn();
		array[2].HeaderText = "Трансформатор";
		array[2].DataPropertyName = "transname";
		array[2].Name = "transname";
		array[2].ReadOnly = true;
		array[2].ValueType = typeof(string);
		array[3] = new DataGridViewFilterTextBoxColumn();
		array[3].HeaderText = "Тип";
		array[3].DataPropertyName = "typeCaption";
		array[3].Name = "typeCaption";
		array[3].ReadOnly = true;
		array[3].ValueType = typeof(string);
		int num4 = 4;
		for (int i = num; i <= num2; i++)
		{
			array2[num4] = new DataColumn();
			array2[num4].ColumnName = i.ToString();
			array2[num4].DataType = typeof(int);
			array2[num4].DefaultValue = 0;
			array[num4] = new DataGridViewFilterTextBoxColumn();
			array[num4].HeaderText = i.ToString();
			array[num4].Name = i.ToString() + "v";
			array[num4].DataPropertyName = i.ToString();
			array[num4].ReadOnly = true;
			array[num4].ValueType = typeof(int);
			array[num4].Tag = i;
			num4++;
		}
		array2[array2.Length - 2] = new DataColumn();
		array2[array2.Length - 2].ColumnName = "type";
		array2[array2.Length - 2].DataType = typeof(int);
		array2[array2.Length - 1] = new DataColumn();
		array2[array2.Length - 1].ColumnName = "transid";
		array2[array2.Length - 1].DataType = typeof(int);
		this.dataTable_0.Columns.AddRange(array2);
		this.dataGridViewExcelFilter_0.Columns.AddRange(array);
		SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString());
		SqlCommand sqlCommand = new SqlCommand(string.Format("with Meas ([id], [year], [TypeDoc], [valueid], [transid])\r\n                                            as\r\n                                            (\r\n                                            select m.id, m.[Year],m.[TypeDoc], (case m.[TypeDoc] when 1191 then mc.id else case m.[TypeDoc] when 1192 then mt.id end end) valueid \r\n                                            ,(case m.[TypeDoc] when 1191 then mc.idObjList else case m.[TypeDoc] when 1192 then mt.idObjList end end) transid   -- mt.id,mt.idObjList,mc.id, mc.idObjList \r\n                                            from [tJ_Measurement] m\r\n                                            left join [tJ_MeasAmperageTransf] as mt on mt.idMeasurement = m.id and mt.deleted=0\r\n                                            left join tJ_MeasVoltageTransf as mc on mc.idMeasurement = m.id and mc.deleted=0\r\n                                            where m.deleted = 0\r\n                                            )\r\n\r\n                                            SELECT \r\n                                            c.Name+'-'+p.[Name]as tpname\r\n                                                  ,pa.[CharValue]\r\n                                                  ,t.[Id] as transid\r\n                                                  ,t.[Name] as transname\r\n                                                  ,Meas.[TypeDoc] as [type]\r\n                                                  ,Meas.[year]   \r\n                                              FROM [tSchm_ObjList] as t  \r\n                                              inner join [tSchm_ObjList] p on p.id = t.idParentAddl\r\n                                              inner join tr_Classifier as c on c.id = p.[TypeCodeId]\r\n                                              left join vP_PassportDataReports as pa on  pa.[IdObj] =p.id and pa.typecodeid in (538,535,537,536) and pa.[CharName] like 'Принадлежность'\r\n                                              left join Meas on Meas.[transid] = t.[Id]\r\n                                              where t.[TypeCodeId] = 556 and t.deleted = 0 and ((Meas.[year]>={0} and Meas.[year]<={1}) or Meas.[year] is null)\r\n                                              order by p.[TypeCodeId], p.[Name],Meas.[year]", num, num2), sqlConnection);
		SqlDataReader sqlDataReader = null;
		try
		{
			sqlConnection.Open();
			sqlDataReader = sqlCommand.ExecuteReader();
			goto IL_6D1;
		}
		catch
		{
			goto IL_6D1;
		}
		IL_452:
		bool flag;
		DataRow[] array3;
		if (flag = sqlDataReader.IsDBNull(4))
		{
			array3 = new DataRow[0];
		}
		else
		{
			array3 = this.dataTable_0.Select(string.Format("transid = {0} and type = {1}", sqlDataReader["transid"], sqlDataReader["type"]));
		}
		DataRow dataRow = null;
		if (array3.Length == 0)
		{
			DataRow dataRow2 = this.dataTable_0.NewRow();
			dataRow2["tpname"] = sqlDataReader["tpname"];
			dataRow2["CharValue"] = sqlDataReader["CharValue"];
			dataRow2["transname"] = sqlDataReader["transname"];
			dataRow2["transid"] = sqlDataReader["transid"];
			dataRow2["typeCaption"] = "0,4 кВ";
			dataRow2["type"] = 1191;
			this.dataTable_0.Rows.Add(dataRow2);
			if (!flag && (int)sqlDataReader["type"] == 1191)
			{
				dataRow = dataRow2;
			}
			dataRow2 = this.dataTable_0.NewRow();
			dataRow2["tpname"] = sqlDataReader["tpname"];
			dataRow2["CharValue"] = sqlDataReader["CharValue"];
			dataRow2["transname"] = sqlDataReader["transname"];
			dataRow2["transid"] = sqlDataReader["transid"];
			dataRow2["typeCaption"] = "6-10 кВ";
			dataRow2["type"] = 1192;
			this.dataTable_0.Rows.Add(dataRow2);
			if (!flag && (int)sqlDataReader["type"] == 1192)
			{
				dataRow = dataRow2;
			}
		}
		else
		{
			dataRow = array3[0];
		}
		int num5 = sqlDataReader.IsDBNull(5) ? -1 : ((int)sqlDataReader["year"]);
		foreach (object obj in this.dataTable_0.Columns)
		{
			DataColumn dataColumn = (DataColumn)obj;
			if (dataColumn.ColumnName == num5.ToString())
			{
				int num6 = (int)dataRow[dataColumn];
				dataRow[dataColumn] = num6 + 1;
			}
		}
		IL_6D1:
		if (!sqlDataReader.Read())
		{
			sqlDataReader.Close();
			sqlConnection.Close();
			this.Cursor = Cursors.Default;
			return;
		}
		goto IL_452;
	}

	private void dataGridViewExcelFilter_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (e.RowIndex != -1)
		{
			if (e.ColumnIndex != -1)
			{
				DataGridViewColumn dataGridViewColumn = this.dataGridViewExcelFilter_0.Columns[e.ColumnIndex];
				if (dataGridViewColumn.Tag == null && dataGridViewColumn.ValueType != typeof(int))
				{
					return;
				}
				if ((int)this.dataGridViewExcelFilter_0[e.ColumnIndex, e.RowIndex].Value == 0)
				{
					e.CellStyle.BackColor = Color.Red;
					e.CellStyle.ForeColor = Color.White;
					return;
				}
				e.CellStyle.BackColor = Color.Green;
				e.CellStyle.ForeColor = Color.White;
				return;
			}
		}
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		this.cRboiYehpbD();
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		this.dataGridViewExcelFilter_0.ExportToExcel();
	}

	private void method_0()
	{
		this.icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form45));
		this.dataSet_0 = new DataSet();
		this.dataTable_0 = new DataTable();
		this.dataColumn_0 = new DataColumn();
		this.dataColumn_1 = new DataColumn();
		this.dataColumn_2 = new DataColumn();
		this.dataTable_1 = new DataTable();
		this.dataColumn_3 = new DataColumn();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripSeparator_0 = new ToolStripSeparator();
		this.toolStripLabel_0 = new ToolStripLabel();
		this.toolStripComboBox_0 = new ToolStripComboBox();
		this.zVvoiUyAaj0 = new ToolStripLabel();
		this.toolStripComboBox_1 = new ToolStripComboBox();
		this.toolStripSeparator_1 = new ToolStripSeparator();
		this.toolStripButton_1 = new ToolStripButton();
		((ISupportInitialize)this.dataSet_0).BeginInit();
		((ISupportInitialize)this.dataTable_0).BeginInit();
		((ISupportInitialize)this.dataTable_1).BeginInit();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		this.toolStrip_0.SuspendLayout();
		base.SuspendLayout();
		this.dataSet_0.DataSetName = "NewDataSet";
		this.dataSet_0.Tables.AddRange(new DataTable[]
		{
			this.dataTable_0,
			this.dataTable_1
		});
		this.dataTable_0.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_0,
			this.dataColumn_1,
			this.dataColumn_2
		});
		this.dataTable_0.TableName = "MeasExistTable";
		this.dataColumn_0.ColumnName = "tpname";
		this.dataColumn_1.ColumnName = "transname";
		this.dataColumn_2.ColumnName = "type";
		this.dataTable_1.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_3
		});
		this.dataTable_1.TableName = "tJ_Measurement";
		this.dataColumn_3.ColumnName = "year";
		this.dataColumn_3.DataType = typeof(int);
		this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_0.BackgroundColor = Color.White;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewTextBoxColumn_2
		});
		this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
		this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_0.Location = new Point(0, 25);
		this.dataGridViewExcelFilter_0.MultiSelect = false;
		this.dataGridViewExcelFilter_0.Name = "dataGridViewExcelFilterMeasExist";
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_0.Size = new Size(610, 326);
		this.dataGridViewExcelFilter_0.TabIndex = 0;
		this.dataGridViewExcelFilter_0.CellFormatting += this.dataGridViewExcelFilter_0_CellFormatting;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "tpname";
		this.dataGridViewTextBoxColumn_0.HeaderText = "tpname";
		this.dataGridViewTextBoxColumn_0.Name = "tpnameDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "transname";
		this.dataGridViewTextBoxColumn_1.HeaderText = "transname";
		this.dataGridViewTextBoxColumn_1.Name = "transnameDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "type";
		this.dataGridViewTextBoxColumn_2.HeaderText = "type";
		this.dataGridViewTextBoxColumn_2.Name = "typeDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_2.ReadOnly = true;
		this.bindingSource_0.DataMember = "MeasExistTable";
		this.bindingSource_0.DataSource = this.dataSet_0;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripSeparator_0,
			this.toolStripLabel_0,
			this.toolStripComboBox_0,
			this.zVvoiUyAaj0,
			this.toolStripComboBox_1,
			this.toolStripSeparator_1,
			this.toolStripButton_1
		});
		this.toolStrip_0.Location = new Point(0, 0);
		this.toolStrip_0.Name = "toolStrip1";
		this.toolStrip_0.Size = new Size(610, 25);
		this.toolStrip_0.TabIndex = 1;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources.refresh_16;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolStripButtonRefresh";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Обновить";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.toolStripSeparator_0.Name = "toolStripSeparator1";
		this.toolStripSeparator_0.Size = new Size(6, 25);
		this.toolStripLabel_0.Name = "toolStripLabel1";
		this.toolStripLabel_0.Size = new Size(52, 22);
		this.toolStripLabel_0.Text = "Период:";
		this.toolStripComboBox_0.Name = "toolStripComboBoxFromYear";
		this.toolStripComboBox_0.Size = new Size(75, 25);
		this.toolStripComboBox_0.SelectedIndexChanged += this.toolStripComboBox_0_SelectedIndexChanged;
		this.zVvoiUyAaj0.Name = "toolStripLabel2";
		this.zVvoiUyAaj0.Size = new Size(18, 22);
		this.zVvoiUyAaj0.Text = " - ";
		this.toolStripComboBox_1.Name = "toolStripComboBoxToYear";
		this.toolStripComboBox_1.Size = new Size(75, 25);
		this.toolStripComboBox_1.SelectedIndexChanged += this.toolStripComboBox_1_SelectedIndexChanged;
		this.toolStripSeparator_1.Name = "toolStripSeparator2";
		this.toolStripSeparator_1.Size = new Size(6, 25);
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = Resources.microsoftoffice2007excel_7581;
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "toolStripButtonToExcel";
		this.toolStripButton_1.Size = new Size(23, 22);
		this.toolStripButton_1.Text = "Экспорт в Excel";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(610, 351);
		base.Controls.Add(this.dataGridViewExcelFilter_0);
		base.Controls.Add(this.toolStrip_0);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.MinimizeBox = false;
		base.Name = "MeasurementExistYearForm";
		this.Text = "Наличие замеров";
		base.Load += this.Form45_Load;
		((ISupportInitialize)this.dataSet_0).EndInit();
		((ISupportInitialize)this.dataTable_0).EndInit();
		((ISupportInitialize)this.dataTable_1).EndInit();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private DataSet dataSet_0;

	private DataTable dataTable_0;

	private DataColumn dataColumn_0;

	private DataColumn dataColumn_1;

	private DataColumn dataColumn_2;

	private DataTable dataTable_1;

	private DataColumn dataColumn_3;

	private DataGridViewExcelFilter dataGridViewExcelFilter_0;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripLabel toolStripLabel_0;

	private ToolStripComboBox toolStripComboBox_0;

	private ToolStripLabel zVvoiUyAaj0;

	private ToolStripComboBox toolStripComboBox_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private BindingSource bindingSource_0;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripButton toolStripButton_1;
}
