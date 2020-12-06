using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using ControlsLbr.ReportViewerRus;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class Form76 : FormBase
{
	internal Form76()
	{
		
		this.list_0 = new List<int>();
		
		this.method_6();
		this.dateTimePicker_1.Value = (this.dateTimePicker_0.Value = DateTime.Now);
	}

	private void Form76_Load(object sender, EventArgs e)
	{
		base.LoadFormConfig(null);
		this.method_0();
		this.method_4();
		this.method_1();
		this.method_2();
	}

	private void Form76_FormClosing(object sender, FormClosingEventArgs e)
	{
		this.method_5();
		base.SaveFormConfig(null);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		this.method_1();
		this.method_2();
	}

	private void method_0()
	{
		DataTable dataTable = new DataTable("tR_Classifier");
		dataTable.Columns.Add("id", typeof(int));
		dataTable.Columns.Add("name", typeof(string));
		base.SelectSqlData(dataTable, true, "where ParentKey = ';ReportDaily;DivisionApply;' and isGroup = 0 and deleted = 0 order by value", null, false, 0);
		dataTable.Rows.Add(new object[]
		{
			-1,
			"Производственная лаборатория"
		});
		foreach (object obj in dataTable.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			if (this.list_0.Count != 0 && !this.list_0.Contains(Convert.ToInt32(dataRow["id"])))
			{
				this.checkedListBox_0.Items.Add(new Form76.Class170(Convert.ToInt32(dataRow["id"]), dataRow["name"].ToString()), false);
			}
			else
			{
				this.checkedListBox_0.Items.Add(new Form76.Class170(Convert.ToInt32(dataRow["id"]), dataRow["name"].ToString()), true);
			}
		}
	}

	private void method_1()
	{
		this.class171_0.ReportDailyDefect.Clear();
		using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString() + ";Connection Timeout=1000"))
		{
			sqlConnection.Open();
			using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
			{
				try
				{
					string cmdText;
					if (this.checkBox_2.Checked)
					{
						cmdText = Class7.smethod_2("Documents.Forms.DailyReport.SqlScripts.ReportDailyDefectWithLocation.sql");
					}
					else
					{
						cmdText = Class7.smethod_2("Documents.Forms.DailyReport.SqlScripts.ReportDailyDefect.sql");
					}
					using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
					{
						sqlCommand.CommandTimeout = 0;
						sqlCommand.Transaction = sqlTransaction;
						sqlCommand.Parameters.Add("dBeg", SqlDbType.DateTime).Value = this.dateTimePicker_1.Value.Date;
						sqlCommand.Parameters.Add("dEnd", SqlDbType.DateTime).Value = this.dateTimePicker_0.Value.Date.AddDays(1.0);
						new SqlDataAdapter(sqlCommand).Fill(this.class171_0.ReportDailyDefect);
					}
					sqlTransaction.Commit();
				}
				catch (Exception ex)
				{
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, ex.Source);
				}
			}
		}
	}

	private void method_2()
	{
		this.reportViewerRus_0.Reset();
		ReportDataSource reportDataSource = new ReportDataSource();
		reportDataSource.Name = "DataSetReportDailyDefect";
		reportDataSource.Value = this.bindingSource_0;
		this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
		if (this.checkBox_0.Checked)
		{
			this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.DailyReport.Reports.ReportDailyDefectFull.rdlc";
		}
		else
		{
			this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.DailyReport.Reports.ReportDailyDefect.rdlc";
		}
		List<ReportParameter> list = new List<ReportParameter>();
		if (!string.IsNullOrEmpty(this.textBox_2.Text))
		{
			list.Add(new ReportParameter("textName1", this.textBox_2.Text));
		}
		else
		{
			list.Add(new ReportParameter("textName1"));
		}
		if (!string.IsNullOrEmpty(this.textBox_1.Text))
		{
			list.Add(new ReportParameter("textName2", this.textBox_1.Text));
		}
		if (!string.IsNullOrEmpty(this.textBox_0.Text))
		{
			list.Add(new ReportParameter("textForWhom", this.textBox_0.Text));
		}
		if (this.dateTimePicker_1.Value.Date == this.dateTimePicker_0.Value.Date)
		{
			list.Add(new ReportParameter("dateReport", this.dateTimePicker_1.Value.Date.ToString("dd.MM.yyyy")));
		}
		else
		{
			list.Add(new ReportParameter("dateReport", this.dateTimePicker_1.Value.Date.ToString("dd.MM.yyyy") + " - " + this.dateTimePicker_0.Value.Date.ToString("dd.MM.yyyy")));
		}
		if (this.checkBox_0.Checked)
		{
			if (this.dateTimePicker_1.Value.Date != this.dateTimePicker_0.Value.Date)
			{
				list.Add(new ReportParameter("VisibleDateDefect", true.ToString()));
			}
			else
			{
				list.Add(new ReportParameter("VisibleDateDefect", false.ToString()));
			}
		}
		if (this.checkedListBox_0.CheckedItems.Count > 0 && this.checkedListBox_0.CheckedItems.Count < this.checkedListBox_0.Items.Count)
		{
			string text = "";
			foreach (object obj in this.checkedListBox_0.CheckedItems)
			{
				if (string.IsNullOrEmpty(text))
				{
					text = ((Form76.Class170)obj).int_0.ToString();
				}
				else
				{
					text = text + "," + ((Form76.Class170)obj).int_0.ToString();
				}
			}
			this.bindingSource_0.Filter = " idDivisionApply in (" + text + ") ";
		}
		else
		{
			this.bindingSource_0.Filter = "";
		}
		if (this.checkBox_1.Checked)
		{
			list.Add(new ReportParameter("isNoApply", true.ToString()));
			if (string.IsNullOrEmpty(this.bindingSource_0.Filter))
			{
				this.bindingSource_0.Filter = " (isApply = 0 or isApply is null)";
			}
			else
			{
				BindingSource bindingSource = this.bindingSource_0;
				bindingSource.Filter += " and (isApply = 0 or isApply is null) ";
			}
		}
		list.Add(new ReportParameter("ReportUser", this.method_3()));
		this.reportViewerRus_0.LocalReport.SetParameters(list);
		this.reportViewerRus_0.RefreshReport();
	}

	private void textBox_2_Leave(object sender, EventArgs e)
	{
		this.method_2();
	}

	private string method_3()
	{
		using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString() + ";Connection Timeout=1000"))
		{
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand("select isnull(w.fio, u.name) as name from tuser u\r\n\t                                left join vr_worker w on u.idWorker = w.id\r\n                                    where login = SYSTEM_USER", sqlConnection))
			{
				sqlCommand.CommandTimeout = 0;
				DbDataAdapter dbDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				dbDataAdapter.Fill(dataTable);
				if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["name"] != DBNull.Value)
				{
					return dataTable.Rows[0]["name"].ToString();
				}
			}
		}
		return string.Empty;
	}

	private void method_4()
	{
		this.dataTable_0 = new DataTable("tSettings");
		this.dataTable_0.Columns.Add("id", typeof(int));
		this.dataTable_0.PrimaryKey = new DataColumn[]
		{
			this.dataTable_0.Columns["id"]
		};
		this.dataTable_0.Columns["id"].AutoIncrement = true;
		this.dataTable_0.Columns.Add("hostIP", typeof(string));
		this.dataTable_0.Columns.Add("settings", typeof(object));
		this.dataTable_0.Columns.Add("module", typeof(string));
		base.SelectSqlData(this.dataTable_0, true, " where module = 'ReportDailyDefect' ", null, false, 0);
		if (this.dataTable_0.Rows.Count > 0)
		{
			string xml = this.dataTable_0.Rows[0]["settings"].ToString();
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("Sett");
			if (xmlNode != null)
			{
				if (xmlNode.Attributes["text1"] != null)
				{
					this.textBox_2.Text = xmlNode.Attributes["text1"].Value.ToString();
				}
				if (xmlNode.Attributes["text2"] != null)
				{
					this.textBox_1.Text = xmlNode.Attributes["text2"].Value.ToString();
				}
				if (xmlNode.Attributes["ForWhom"] != null)
				{
					this.textBox_0.Text = xmlNode.Attributes["ForWhom"].Value.ToString();
				}
			}
		}
	}

	private void method_5()
	{
		XDocument xdocument = new XDocument(new XDeclaration("1.0", "utf-16", null), new object[]
		{
			new XElement("Sett", new object[]
			{
				new XAttribute("text1", this.textBox_2.Text),
				new XAttribute("text2", this.textBox_1.Text),
				new XAttribute("ForWhom", this.textBox_0.Text)
			})
		});
		if (this.dataTable_0.Rows.Count > 0)
		{
			this.dataTable_0.Rows[0]["settings"] = xdocument.ToString();
			base.UpdateSqlData(this.dataTable_0);
			return;
		}
		DataRow dataRow = this.dataTable_0.NewRow();
		dataRow["settings"] = xdocument.ToString();
		dataRow["module"] = "ReportDailyDefect";
		this.dataTable_0.Rows.Add(dataRow);
		this.dataTable_0.Rows[0].EndEdit();
		base.InsertSqlData(this.dataTable_0);
	}

	protected override void ApplyConfig(XmlDocument xmlDocument_0)
	{
		XmlNode xmlNode = xmlDocument_0.SelectSingleNode(base.Name);
		if (xmlNode != null)
		{
			foreach (object obj in xmlNode.SelectNodes("Item"))
			{
				XmlNode xmlNode2 = (XmlNode)obj;
				if (!string.IsNullOrEmpty(xmlNode2.InnerText))
				{
					this.list_0.Add(Convert.ToInt32(xmlNode2.InnerText));
				}
			}
		}
	}

	protected override XmlDocument CreateXmlConfig()
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlNode newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
		xmlDocument.AppendChild(newChild);
		XmlNode xmlNode = xmlDocument.CreateElement(base.Name);
		xmlDocument.AppendChild(xmlNode);
		foreach (object obj in this.checkedListBox_0.CheckedItems)
		{
			XmlNode xmlNode2 = xmlDocument.CreateElement("Item");
			xmlNode2.InnerText = ((Form76.Class170)obj).int_0.ToString();
			xmlNode.AppendChild(xmlNode2);
		}
		return xmlDocument;
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		this.method_2();
	}

	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		this.method_2();
	}

	private void method_6()
	{
		this.icontainer_0 = new Container();
		ReportDataSource reportDataSource = new ReportDataSource();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class171_0 = new Class171();
		this.panel_0 = new Panel();
		this.checkedListBox_0 = new CheckedListBox();
		this.button_0 = new Button();
		this.dateTimePicker_0 = new DateTimePicker();
		this.label_0 = new Label();
		this.dateTimePicker_1 = new DateTimePicker();
		this.label_1 = new Label();
		this.label_2 = new Label();
		this.label_3 = new Label();
		this.label_4 = new Label();
		this.textBox_0 = new TextBox();
		this.textBox_1 = new TextBox();
		this.textBox_2 = new TextBox();
		this.reportViewerRus_0 = new ReportViewerRus();
		this.checkBox_0 = new CheckBox();
		this.checkBox_1 = new CheckBox();
		this.checkBox_2 = new CheckBox();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class171_0).BeginInit();
		this.panel_0.SuspendLayout();
		base.SuspendLayout();
		this.bindingSource_0.DataMember = "ReportDailyDefect";
		this.bindingSource_0.DataSource = this.class171_0;
		this.class171_0.DataSetName = "DataSetDamage";
		this.class171_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.panel_0.Controls.Add(this.checkedListBox_0);
		this.panel_0.Controls.Add(this.button_0);
		this.panel_0.Controls.Add(this.dateTimePicker_0);
		this.panel_0.Controls.Add(this.label_0);
		this.panel_0.Controls.Add(this.dateTimePicker_1);
		this.panel_0.Controls.Add(this.label_1);
		this.panel_0.Controls.Add(this.label_2);
		this.panel_0.Controls.Add(this.label_3);
		this.panel_0.Controls.Add(this.label_4);
		this.panel_0.Controls.Add(this.textBox_0);
		this.panel_0.Controls.Add(this.textBox_1);
		this.panel_0.Controls.Add(this.textBox_2);
		this.panel_0.Dock = DockStyle.Top;
		this.panel_0.Location = new Point(0, 0);
		this.panel_0.Name = "panel1";
		this.panel_0.Size = new Size(798, 100);
		this.panel_0.TabIndex = 0;
		this.checkedListBox_0.CheckOnClick = true;
		this.checkedListBox_0.FormattingEnabled = true;
		this.checkedListBox_0.Location = new Point(369, 12);
		this.checkedListBox_0.Name = "chkListBoxDivision";
		this.checkedListBox_0.Size = new Size(165, 79);
		this.checkedListBox_0.TabIndex = 11;
		this.button_0.Location = new Point(540, 64);
		this.button_0.Name = "buttonLoad";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 10;
		this.button_0.Text = "Применить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.dateTimePicker_0.Location = new Point(632, 38);
		this.dateTimePicker_0.Name = "dtpEnd";
		this.dateTimePicker_0.Size = new Size(152, 20);
		this.dateTimePicker_0.TabIndex = 9;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(537, 41);
		this.label_0.Name = "label5";
		this.label_0.Size = new Size(89, 13);
		this.label_0.TabIndex = 8;
		this.label_0.Text = "Дата окончания";
		this.dateTimePicker_1.Location = new Point(631, 12);
		this.dateTimePicker_1.Name = "dtpBeg";
		this.dateTimePicker_1.Size = new Size(152, 20);
		this.dateTimePicker_1.TabIndex = 7;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(537, 15);
		this.label_1.Name = "label4";
		this.label_1.Size = new Size(71, 13);
		this.label_1.TabIndex = 6;
		this.label_1.Text = "Дата начала";
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(12, 67);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(54, 13);
		this.label_2.TabIndex = 5;
		this.label_2.Text = "Для кого";
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 41);
		this.label_3.Name = "label2";
		this.label_3.Size = new Size(49, 13);
		this.label_3.TabIndex = 4;
		this.label_3.Text = "Шапка 2";
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(12, 15);
		this.label_4.Name = "label1";
		this.label_4.Size = new Size(49, 13);
		this.label_4.TabIndex = 3;
		this.label_4.Text = "Шапка 1";
		this.textBox_0.Location = new Point(72, 64);
		this.textBox_0.Name = "txtForWhom";
		this.textBox_0.Size = new Size(279, 20);
		this.textBox_0.TabIndex = 2;
		this.textBox_0.Leave += this.textBox_2_Leave;
		this.textBox_1.Location = new Point(72, 38);
		this.textBox_1.Name = "txt2";
		this.textBox_1.Size = new Size(279, 20);
		this.textBox_1.TabIndex = 1;
		this.textBox_1.Leave += this.textBox_2_Leave;
		this.textBox_2.Location = new Point(72, 12);
		this.textBox_2.Name = "txt1";
		this.textBox_2.Size = new Size(279, 20);
		this.textBox_2.TabIndex = 0;
		this.textBox_2.Leave += this.textBox_2_Leave;
		this.reportViewerRus_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		reportDataSource.Name = "DataSetReportDailyDefect";
		reportDataSource.Value = this.bindingSource_0;
		this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
		this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.DailyReport.Reports.ReportDailyDefect.rdlc";
		this.reportViewerRus_0.Location = new Point(0, 100);
		this.reportViewerRus_0.Name = "reportViewerRus1";
		this.reportViewerRus_0.Size = new Size(798, 419);
		this.reportViewerRus_0.TabIndex = 1;
		this.checkBox_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Location = new Point(12, 525);
		this.checkBox_0.Name = "chkFullReport";
		this.checkBox_0.Size = new Size(123, 17);
		this.checkBox_0.TabIndex = 2;
		this.checkBox_0.Text = "Развернутый отчет";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
		this.checkBox_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.checkBox_1.AutoSize = true;
		this.checkBox_1.Location = new Point(141, 525);
		this.checkBox_1.Name = "chkNotApply";
		this.checkBox_1.Size = new Size(110, 17);
		this.checkBox_1.TabIndex = 3;
		this.checkBox_1.Text = "Невыполненные";
		this.checkBox_1.UseVisualStyleBackColor = true;
		this.checkBox_1.CheckedChanged += this.checkBox_1_CheckedChanged;
		this.checkBox_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.checkBox_2.AutoSize = true;
		this.checkBox_2.Checked = true;
		this.checkBox_2.CheckState = CheckState.Checked;
		this.checkBox_2.Location = new Point(257, 525);
		this.checkBox_2.Name = "chkDefectLocation";
		this.checkBox_2.Size = new Size(180, 17);
		this.checkBox_2.TabIndex = 4;
		this.checkBox_2.Text = "Показать место повреждения";
		this.checkBox_2.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(798, 550);
		base.Controls.Add(this.checkBox_2);
		base.Controls.Add(this.checkBox_1);
		base.Controls.Add(this.checkBox_0);
		base.Controls.Add(this.reportViewerRus_0);
		base.Controls.Add(this.panel_0);
		base.Name = "FormReportDailyDefect";
		this.Text = "Суточный рапорт по дефектам";
		base.FormClosing += this.Form76_FormClosing;
		base.Load += this.Form76_Load;
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class171_0).EndInit();
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private DataTable dataTable_0;

	private List<int> list_0;

	private Panel panel_0;

	private Button button_0;

	private DateTimePicker dateTimePicker_0;

	private Label label_0;

	private DateTimePicker dateTimePicker_1;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private Label label_4;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private ReportViewerRus reportViewerRus_0;

	private BindingSource bindingSource_0;

	private Class171 class171_0;

	private CheckedListBox checkedListBox_0;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private class Class170
	{
		internal Class170(int int_1, string string_1)
		{
			
			
			this.int_0 = int_1;
			this.string_0 = string_1;
		}

		public override string ToString()
		{
			return this.string_0;
		}

		internal int int_0;

		internal string string_0;
	}
}
