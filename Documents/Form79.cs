using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using Documents.Forms.DailyReport.Reports;
using Documents.Properties;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class Form79 : FormBase
{
	internal Form79()
	{
		
		
		this.method_12();
	}

	private void Form79_Load(object sender, EventArgs e)
	{
		this.method_0();
		this.method_1();
		this.method_4();
	}

	private void method_0()
	{
		this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year + 1, 1, 1).AddSeconds(-1.0);
		this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, 1, 1);
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("year", typeof(int));
		for (int i = 1879; i <= DateTime.Now.Year; i++)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["year"] = i;
			dataRow.EndEdit();
			dataTable.Rows.Add(dataRow);
		}
		this.comboBox_0.DisplayMember = "year";
		this.comboBox_0.ValueMember = "year";
		this.comboBox_0.DataSource = dataTable;
		this.comboBox_0.SelectedValue = DateTime.Now.Year;
	}

	private void dateTimePicker_1_ValueChanged(object sender, EventArgs e)
	{
		if (this.dateTimePicker_1.Value > this.dateTimePicker_0.Value)
		{
			this.dateTimePicker_0.Value = this.dateTimePicker_1.Value;
		}
	}

	private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		if (this.dateTimePicker_0.Value < this.dateTimePicker_1.Value)
		{
			this.dateTimePicker_1.Value = this.dateTimePicker_0.Value;
		}
	}

	private void radioButton_3_CheckedChanged(object sender, EventArgs e)
	{
		this.comboBox_0.Enabled = this.radioButton_3.Checked;
		this.dateTimePicker_1.Enabled = (this.dateTimePicker_0.Enabled = !this.radioButton_3.Checked);
	}

	private void method_1()
	{
		DataTable dataTable = new DataTable("tSettings");
		base.SelectSqlData(dataTable, true, "where module = 'ReportDetectApprover'", null, false, 0);
		if (dataTable.Rows.Count > 0)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Approver));
			StringReader textReader = new StringReader(dataTable.Rows[0]["Settings"].ToString());
			this.approver_0 = (Approver)xmlSerializer.Deserialize(textReader);
		}
		else
		{
			this.approver_0 = new Approver();
		}
		this.method_2();
	}

	private void method_2()
	{
		this.textBox_0.Text = this.approver_0.Name;
		this.textBox_1.Text = this.approver_0.Post;
	}

	private void method_3()
	{
		this.approver_0.Name = this.textBox_0.Text.Trim();
		this.approver_0.Post = this.textBox_1.Text.Trim();
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(Approver));
		new XDocument();
		StringWriter stringWriter = new StringWriter();
		xmlSerializer.Serialize(stringWriter, this.approver_0);
		DataTable dataTable = new Class171.Class194();
		base.SelectSqlData(dataTable, true, "where module = 'ReportDetectApprover'", null, false, 0);
		if (dataTable.Rows.Count == 0)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["Settings"] = stringWriter.ToString();
			dataRow["Module"] = "ReportDetectApprover";
			dataRow.EndEdit();
			dataTable.Rows.Add(dataRow);
			base.InsertSqlData(dataTable);
			return;
		}
		dataTable.Rows[0]["Settings"] = stringWriter.ToString();
		dataTable.Rows[0].EndEdit();
		base.UpdateSqlDataOnlyChange(dataTable);
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		this.method_4();
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		this.radioButton_3.Checked = true;
		this.radioButton_1.Checked = true;
		this.method_0();
	}

	private void method_4()
	{
		this.reportViewer_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.DailyReport.Reports.ReportEmergencyShutdown.rdlc";
		this.reportViewer_0.LocalReport.DataSources.Clear();
		List<ReportParameter> list = new List<ReportParameter>();
		list.Add(new ReportParameter("post", this.textBox_1.Text.Trim()));
		list.Add(new ReportParameter("worker", this.textBox_0.Text.Trim()));
		this.bool_0 = this.radioButton_0.Checked;
		if (this.radioButton_3.Checked)
		{
			if (this.comboBox_0.SelectedValue == null)
			{
				new ToolTip().Show("!", this.comboBox_0, 10, 5, 3000);
				return;
			}
			this.dateTime_0 = new DateTime(Convert.ToInt32(this.comboBox_0.SelectedValue), 1, 1);
			this.dateTime_1 = new DateTime(Convert.ToInt32(this.comboBox_0.SelectedValue) + 1, 1, 1).AddSeconds(-1.0);
			list.Add(new ReportParameter("year", this.comboBox_0.SelectedValue.ToString()));
		}
		else
		{
			this.dateTime_0 = this.dateTimePicker_1.Value.Date;
			this.dateTime_1 = this.dateTimePicker_0.Value.Date;
			list.Add(new ReportParameter("year", ""));
			list.Add(new ReportParameter("dateBegin", this.dateTime_0.ToString("dd.MM.yyyy")));
			list.Add(new ReportParameter("dateEnd", this.dateTime_1.ToString("dd.MM.yyyy")));
		}
		this.reportViewer_0.LocalReport.SetParameters(list);
		string string_ = Class7.smethod_2("Documents.Forms.DailyReport.SqlScripts.ReportDetectionCrashByMonth.sql");
		string string_2 = Class7.smethod_2("Documents.Forms.DailyReport.SqlScripts.ReportDetectionCrashByNetRegion.sql");
		string string_3 = Class7.smethod_2("Documents.Forms.DailyReport.SqlScripts.ReportDetectionReasonCrashEquip.sql");
		string string_4 = Class7.smethod_2("Documents.Forms.DailyReport.SqlScripts.ReportDetectionReasonCrash.sql");
		string string_5 = Class7.smethod_2("Documents.Forms.DailyReport.SqlScripts.ReportDetectionNoAdmissKWTByNetReg.sql");
		this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsCrash", this.method_10(this.method_5(string_))));
		this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsNetRegion", this.method_11(this.method_5(string_2))));
		this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsReasonCrashEquip", this.method_5(string_3)));
		this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsReasonCrash", this.method_5(string_4)));
		this.reportViewer_0.LocalReport.DataSources.Add(new ReportDataSource("dsNoAdmissKWT", this.method_5(string_5)));
		this.reportViewer_0.RefreshReport();
	}

	private DataTable method_5(string string_0)
	{
		DataTable result;
		using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
		{
			try
			{
				sqlConnection.Open();
				if (this.bool_0)
				{
					string_0 += "\r\n where isCrash = '1'";
				}
				using (SqlCommand sqlCommand = new SqlCommand(string_0, sqlConnection))
				{
					sqlCommand.CommandType = CommandType.Text;
					sqlCommand.Parameters.Add("dateBegin", SqlDbType.DateTime).Value = this.dateTime_0;
					sqlCommand.Parameters.Add("dateEnd", SqlDbType.DateTime).Value = this.dateTime_1;
					DataTable dataTable = new DataTable();
					new SqlDataAdapter(sqlCommand).Fill(dataTable);
					this.method_9(dataTable);
					result = dataTable;
				}
			}
			catch
			{
				sqlConnection.Close();
				result = new DataTable();
			}
		}
		return result;
	}

	private DataTable method_6()
	{
		DataTable result;
		using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
		{
			try
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand(Class7.smethod_2("Documents.Forms.DailyReport.SqlScripts.ReportDetectionCrashByMonth.sql"), sqlConnection))
				{
					sqlCommand.CommandType = CommandType.Text;
					sqlCommand.Parameters.Add("dateBegin", SqlDbType.DateTime).Value = this.dateTime_0;
					sqlCommand.Parameters.Add("dateEnd", SqlDbType.DateTime).Value = this.dateTime_1;
					DataTable dataTable = new DataTable();
					new SqlDataAdapter(sqlCommand).Fill(dataTable);
					this.method_9(dataTable);
					result = dataTable;
				}
			}
			catch
			{
				sqlConnection.Close();
				result = new Class171.Class191();
			}
		}
		return result;
	}

	private DataTable method_7()
	{
		DataTable result;
		using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
		{
			try
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand(Class7.smethod_2("Documents.Forms.DailyReport.SqlScripts.ReportDetectionReasonCrashEquip.sql"), sqlConnection))
				{
					sqlCommand.CommandType = CommandType.Text;
					sqlCommand.Parameters.Add("dateBegin", SqlDbType.DateTime).Value = this.dateTime_0;
					sqlCommand.Parameters.Add("dateEnd", SqlDbType.DateTime).Value = this.dateTime_1;
					DataTable dataTable = new DataTable();
					new SqlDataAdapter(sqlCommand).Fill(dataTable);
					this.method_9(dataTable);
					result = dataTable;
				}
			}
			catch
			{
				sqlConnection.Close();
				result = new Class171.Class191();
			}
		}
		return result;
	}

	private DataTable method_8()
	{
		DataTable result;
		using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
		{
			try
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand(Class7.smethod_2("Documents.Forms.DailyReport.SqlScripts.ReportDetectionReasonCrash.sql"), sqlConnection))
				{
					sqlCommand.CommandType = CommandType.Text;
					sqlCommand.Parameters.Add("dateBegin", SqlDbType.DateTime).Value = this.dateTime_0;
					sqlCommand.Parameters.Add("dateEnd", SqlDbType.DateTime).Value = this.dateTime_1;
					DataTable dataTable = new DataTable();
					new SqlDataAdapter(sqlCommand).Fill(dataTable);
					this.method_9(dataTable);
					result = dataTable;
				}
			}
			catch
			{
				sqlConnection.Close();
				result = new Class171.Class191();
			}
		}
		return result;
	}

	private void method_9(DataTable dataTable_0)
	{
		foreach (object obj in dataTable_0.Columns)
		{
			DataColumn dataColumn = (DataColumn)obj;
			int num;
			if (int.TryParse(dataColumn.ColumnName, out num))
			{
				dataColumn.ColumnName = "id" + dataColumn.ColumnName;
			}
		}
	}

	private DataTable method_10(DataTable dataTable_0)
	{
		for (int i = 1; i <= 12; i++)
		{
			if (new DataView(dataTable_0)
			{
				RowFilter = string.Format("[month] = '{0}'", i)
			}.Count == 0)
			{
				DataRow dataRow = dataTable_0.NewRow();
				dataRow["month"] = i;
				dataRow.EndEdit();
				dataTable_0.Rows.Add(dataRow);
			}
		}
		return dataTable_0;
	}

	private DataTable method_11(DataTable dataTable_0)
	{
		DataTable dataTable = new DataTable("tR_Classifier");
		base.SelectSqlData(dataTable, true, "Where ParentKey = ';NetworkAreas;' and deleted = '0' and isGroup = '0'", null, false, 0);
		foreach (object obj in dataTable.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			if (new DataView(dataTable_0)
			{
				RowFilter = string.Format("typeNetReg = '{0}'", dataRow["id"])
			}.Count == 0)
			{
				DataRow dataRow2 = dataTable_0.NewRow();
				dataRow2["typeNetReg"] = dataRow["id"];
				dataRow2.EndEdit();
				dataTable_0.Rows.Add(dataRow2);
			}
		}
		return dataTable_0;
	}

	private void Form79_FormClosing(object sender, FormClosingEventArgs e)
	{
		this.method_3();
	}

	private void method_12()
	{
		this.panel_0 = new Panel();
		this.groupBox_0 = new GroupBox();
		this.radioButton_0 = new RadioButton();
		this.radioButton_1 = new RadioButton();
		this.panel_1 = new Panel();
		this.textBox_0 = new TextBox();
		this.label_0 = new Label();
		this.textBox_1 = new TextBox();
		this.label_3 = new Label();
		this.groupBox_1 = new GroupBox();
		this.comboBox_0 = new ComboBox();
		this.dateTimePicker_0 = new DateTimePicker();
		this.dateTimePicker_1 = new DateTimePicker();
		this.label_1 = new Label();
		this.label_2 = new Label();
		this.radioButton_2 = new RadioButton();
		this.radioButton_3 = new RadioButton();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripButton_1 = new ToolStripButton();
		this.reportViewer_0 = new ReportViewer();
		this.panel_0.SuspendLayout();
		this.groupBox_0.SuspendLayout();
		this.panel_1.SuspendLayout();
		this.groupBox_1.SuspendLayout();
		this.toolStrip_0.SuspendLayout();
		base.SuspendLayout();
		this.panel_0.Controls.Add(this.groupBox_0);
		this.panel_0.Controls.Add(this.panel_1);
		this.panel_0.Controls.Add(this.groupBox_1);
		this.panel_0.Controls.Add(this.toolStrip_0);
		this.panel_0.Dock = DockStyle.Left;
		this.panel_0.Location = new Point(0, 0);
		this.panel_0.Name = "panel1";
		this.panel_0.Padding = new Padding(3);
		this.panel_0.Size = new Size(200, 571);
		this.panel_0.TabIndex = 0;
		this.groupBox_0.Controls.Add(this.radioButton_0);
		this.groupBox_0.Controls.Add(this.radioButton_1);
		this.groupBox_0.Dock = DockStyle.Top;
		this.groupBox_0.Location = new Point(3, 266);
		this.groupBox_0.Name = "grpAct";
		this.groupBox_0.Size = new Size(194, 68);
		this.groupBox_0.TabIndex = 1;
		this.groupBox_0.TabStop = false;
		this.groupBox_0.Text = "Акты";
		this.radioButton_0.AutoSize = true;
		this.radioButton_0.Location = new Point(9, 42);
		this.radioButton_0.Name = "rBtnCrashAct";
		this.radioButton_0.Size = new Size(110, 17);
		this.radioButton_0.TabIndex = 8;
		this.radioButton_0.TabStop = true;
		this.radioButton_0.Text = "Аварийные акты";
		this.radioButton_0.UseVisualStyleBackColor = true;
		this.radioButton_1.AutoSize = true;
		this.radioButton_1.Checked = true;
		this.radioButton_1.Location = new Point(9, 19);
		this.radioButton_1.Name = "rBtnAllAct";
		this.radioButton_1.Size = new Size(72, 17);
		this.radioButton_1.TabIndex = 7;
		this.radioButton_1.TabStop = true;
		this.radioButton_1.Text = "Все акты";
		this.radioButton_1.UseVisualStyleBackColor = true;
		this.panel_1.Controls.Add(this.textBox_0);
		this.panel_1.Controls.Add(this.label_0);
		this.panel_1.Controls.Add(this.textBox_1);
		this.panel_1.Controls.Add(this.label_3);
		this.panel_1.Dock = DockStyle.Top;
		this.panel_1.Location = new Point(3, 176);
		this.panel_1.Name = "panel2";
		this.panel_1.Padding = new Padding(0, 10, 0, 0);
		this.panel_1.Size = new Size(194, 90);
		this.panel_1.TabIndex = 4;
		this.textBox_0.BackColor = SystemColors.Window;
		this.textBox_0.Dock = DockStyle.Top;
		this.textBox_0.Location = new Point(0, 61);
		this.textBox_0.Name = "txtName";
		this.textBox_0.Size = new Size(194, 20);
		this.textBox_0.TabIndex = 6;
		this.label_0.AutoSize = true;
		this.label_0.Dock = DockStyle.Top;
		this.label_0.Location = new Point(0, 43);
		this.label_0.Name = "label1";
		this.label_0.Padding = new Padding(0, 5, 0, 0);
		this.label_0.Size = new Size(34, 18);
		this.label_0.TabIndex = 2;
		this.label_0.Text = "ФИО";
		this.textBox_1.Dock = DockStyle.Top;
		this.textBox_1.Location = new Point(0, 23);
		this.textBox_1.Name = "txtPost";
		this.textBox_1.Size = new Size(194, 20);
		this.textBox_1.TabIndex = 5;
		this.label_3.AutoSize = true;
		this.label_3.Dock = DockStyle.Top;
		this.label_3.Location = new Point(0, 10);
		this.label_3.Name = "label4";
		this.label_3.Size = new Size(65, 13);
		this.label_3.TabIndex = 4;
		this.label_3.Text = "Должность";
		this.groupBox_1.Controls.Add(this.comboBox_0);
		this.groupBox_1.Controls.Add(this.dateTimePicker_0);
		this.groupBox_1.Controls.Add(this.dateTimePicker_1);
		this.groupBox_1.Controls.Add(this.label_1);
		this.groupBox_1.Controls.Add(this.label_2);
		this.groupBox_1.Controls.Add(this.radioButton_2);
		this.groupBox_1.Controls.Add(this.radioButton_3);
		this.groupBox_1.Dock = DockStyle.Top;
		this.groupBox_1.Location = new Point(3, 28);
		this.groupBox_1.Name = "grpDate";
		this.groupBox_1.Size = new Size(194, 148);
		this.groupBox_1.TabIndex = 0;
		this.groupBox_1.TabStop = false;
		this.groupBox_1.Text = "Дата";
		this.comboBox_0.AutoCompleteMode = AutoCompleteMode.Append;
		this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(9, 41);
		this.comboBox_0.Name = "cmbYear";
		this.comboBox_0.Size = new Size(179, 21);
		this.comboBox_0.TabIndex = 1;
		this.dateTimePicker_0.Enabled = false;
		this.dateTimePicker_0.Location = new Point(34, 117);
		this.dateTimePicker_0.Name = "dtpDateEnd";
		this.dateTimePicker_0.Size = new Size(154, 20);
		this.dateTimePicker_0.TabIndex = 4;
		this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
		this.dateTimePicker_1.Enabled = false;
		this.dateTimePicker_1.Location = new Point(34, 91);
		this.dateTimePicker_1.Name = "dtpDateBegin";
		this.dateTimePicker_1.Size = new Size(154, 20);
		this.dateTimePicker_1.TabIndex = 3;
		this.dateTimePicker_1.ValueChanged += this.dateTimePicker_1_ValueChanged;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(6, 119);
		this.label_1.Name = "label3";
		this.label_1.Size = new Size(22, 13);
		this.label_1.TabIndex = 4;
		this.label_1.Text = "по:";
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(6, 91);
		this.label_2.Name = "label2";
		this.label_2.Size = new Size(16, 13);
		this.label_2.TabIndex = 3;
		this.label_2.Text = "с:";
		this.radioButton_2.AutoSize = true;
		this.radioButton_2.Location = new Point(9, 68);
		this.radioButton_2.Name = "rBtnPeriod";
		this.radioButton_2.Size = new Size(63, 17);
		this.radioButton_2.TabIndex = 2;
		this.radioButton_2.TabStop = true;
		this.radioButton_2.Text = "Период";
		this.radioButton_2.UseVisualStyleBackColor = true;
		this.radioButton_3.AutoSize = true;
		this.radioButton_3.Checked = true;
		this.radioButton_3.Location = new Point(9, 19);
		this.radioButton_3.Name = "rBtnYear";
		this.radioButton_3.Size = new Size(43, 17);
		this.radioButton_3.TabIndex = 0;
		this.radioButton_3.TabStop = true;
		this.radioButton_3.Text = "Год";
		this.radioButton_3.UseVisualStyleBackColor = true;
		this.radioButton_3.CheckedChanged += this.radioButton_3_CheckedChanged;
		this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripButton_1
		});
		this.toolStrip_0.Location = new Point(3, 3);
		this.toolStrip_0.Name = "tsMain";
		this.toolStrip_0.Size = new Size(194, 25);
		this.toolStrip_0.TabIndex = 9;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources.filter;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "tsBtnAddFilter";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Применить фильтр";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = Resources.filter_delete;
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "tsBtnDelFilter";
		this.toolStripButton_1.Size = new Size(23, 22);
		this.toolStripButton_1.Text = "Сбросить фильтр";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.reportViewer_0.Dock = DockStyle.Fill;
		this.reportViewer_0.Location = new Point(200, 0);
		this.reportViewer_0.Name = "rView";
		this.reportViewer_0.Size = new Size(625, 571);
		this.reportViewer_0.TabIndex = 1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(825, 571);
		base.Controls.Add(this.reportViewer_0);
		base.Controls.Add(this.panel_0);
		base.Name = "FormReportDetectionCrash";
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "Бюллетень аварийных отключений";
		base.FormClosing += this.Form79_FormClosing;
		base.Load += this.Form79_Load;
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		this.panel_1.ResumeLayout(false);
		this.panel_1.PerformLayout();
		this.groupBox_1.ResumeLayout(false);
		this.groupBox_1.PerformLayout();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		base.ResumeLayout(false);
	}

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private bool bool_0;

	private Approver approver_0;

	private Panel panel_0;

	private ReportViewer reportViewer_0;

	private GroupBox groupBox_0;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private Panel panel_1;

	private TextBox textBox_0;

	private Label label_0;

	private GroupBox groupBox_1;

	private DateTimePicker dateTimePicker_0;

	private DateTimePicker dateTimePicker_1;

	private Label label_1;

	private Label label_2;

	private RadioButton radioButton_2;

	private RadioButton radioButton_3;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ComboBox comboBox_0;

	private TextBox textBox_1;

	private Label label_3;
}
