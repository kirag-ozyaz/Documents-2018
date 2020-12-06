using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Constants;
using ControlsLbr.ReportViewerRus;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class Form68 : FormBase
{
	internal Form68()
	{
		
		
		this.method_5();
		this.dateTimePicker_0.Value = DateTime.Now.Date;
	}

	private void Form68_Load(object sender, EventArgs e)
	{
		this.toolStripComboBox_0.SelectedIndex = 0;
		base.SelectSqlData(this.class130_0, this.class130_0.tR_Classifier, true, "where ParentKey = ';CityRaion;UlyanovskRaion;' and isGRoup = 0 and deleted = 0 order by name ");
		foreach (DataRow dataRow in this.class130_0.tR_Classifier)
		{
			this.checkedListBox_0.Items.Add(dataRow["Name"], true);
		}
	}

	private void method_0()
	{
		this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalExcavation.Reports.ReportExcavation.rdlc";
		this.reportViewerRus_0.LocalReport.DataSources.Clear();
		ReportParameter reportParameter = new ReportParameter("dateReport", this.dateTimePicker_0.Value.ToString());
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter("Owner", this.method_2()));
		base.SelectSqlData(this.class130_0, this.class130_0.vAbnType, true, " where typeKontragent = " + 1115.ToString());
		string text = "";
		foreach (DataRow dataRow in this.class130_0.vAbnType)
		{
			if (!string.IsNullOrEmpty(text))
			{
				text += ",";
			}
			text += dataRow["idAbn"].ToString();
		}
		string text2 = string.Format("left join tj_excavationstatus sOrder on sOrder.id = (select top 1 id \r\n                                                from tj_excavationstatus \r\n                                                where idExcavation = vj_excavation.id and idType = 1 and dateChange <= '{0}'\r\n                                                order by datechange desc) \r\n                                            left join tr_classifier cOrder on cOrder.id = sOrder.idStatus \r\n                                            left join tj_excavationstatus sWork on sWork.id = (select top 1 id \r\n                                                from tj_excavationstatus \r\n                                                where idExcavation = vj_excavation.id and idType = 2 and dateChange <= '{0}'\r\n                                                order by datechange desc)\r\n                                            left join tr_classifier cStatusWork on cStatusWork.id = sWork.idStatus \r\n                                            where (cOrder.value not in (1,6) or cOrder.id is null) \r\n                                                and (cStatusWork.ParentKey <> ';Excavation;StatusWork;RealEnd;' or cStatusWork.id is null) \r\n                                                and (vj_excavation.dateBeg <= '{0}')\r\n                                                and (vj_excavation.dateEndPlanned is null or vj_excavation.dateEndPlanned >= '{0}') ", this.dateTimePicker_0.Value.ToString("yyyyMMdd"));
		if (this.checkBox_0.Checked)
		{
			text2 += " and (vj_excavation.agreed = 1) ";
		}
		if (this.checkedListBox_0.CheckedItems.Count > 0 && this.checkedListBox_0.CheckedItems.Count != this.checkedListBox_0.Items.Count)
		{
			string text3 = "";
			foreach (object obj in this.checkedListBox_0.CheckedItems)
			{
				if (!string.IsNullOrEmpty(text3))
				{
					text3 += ",";
				}
				text3 = text3 + "'" + obj.ToString() + "'";
			}
			text2 = text2 + " and (region in (" + text3 + ")) ";
		}
		string text4 = text2;
		if (!string.IsNullOrEmpty(text))
		{
			text2 = text2 + " and (vj_excavation.idContractor in (" + text + ")) ";
			text4 = text4 + " and (vj_excavation.idContractor not in (" + text + ")) ";
		}
		base.SelectSqlData(this.class130_0, this.class130_0.vJ_Excavation, true, text2);
		base.SelectSqlData(this.class130_1, this.class130_1.vJ_Excavation, true, text4);
		this.reportViewerRus_0.LocalReport.DataSources.Add(new ReportDataSource("DataSetExc", this.class130_0.vJ_Excavation));
		this.reportViewerRus_0.LocalReport.DataSources.Add(new ReportDataSource("DataSetExcContractor", this.class130_1.vJ_Excavation));
		ReportParameter reportParameter2 = new ReportParameter("hideContr", (this.class130_1.vJ_Excavation.Rows.Count == 0).ToString());
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter2
		});
		ReportParameter reportParameter3 = new ReportParameter("JobTitle", this.comboBox_1.Text);
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter3
		});
		ReportParameter reportParameter4 = new ReportParameter("Worker", this.comboBox_0.Text);
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter4
		});
		this.reportViewerRus_0.RefreshReport();
	}

	private void method_1()
	{
		this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalExcavation.Reports.ReportExcavation_ver2.rdlc";
		List<ReportParameter> list = new List<ReportParameter>();
		list.Add(new ReportParameter("Owner", this.method_2()));
		list.Add(new ReportParameter("dateReport", this.dateTimePicker_0.Value.ToString()));
		list.Add(new ReportParameter("JobTitle", this.comboBox_1.Text));
		list.Add(new ReportParameter("Worker", this.comboBox_0.Text));
		this.reportViewerRus_0.LocalReport.SetParameters(list);
		this.reportViewerRus_0.LocalReport.DataSources.Clear();
		this.method_3(this.checkState_0, this.checkState_1, this.checkState_2);
		this.reportViewerRus_0.RefreshReport();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (this.toolStripComboBox_0.SelectedIndex == 0)
		{
			this.method_0();
			return;
		}
		if (this.toolStripComboBox_0.SelectedIndex == 1)
		{
			this.method_1();
		}
	}

	private void toolStripComboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.toolStripComboBox_0.SelectedIndex == 0)
		{
			Control control = this.checkedListBox_1;
			this.checkedListBox_1.Enabled = false;
			control.Visible = false;
			this.method_0();
			return;
		}
		if (this.toolStripComboBox_0.SelectedIndex == 1)
		{
			Control control2 = this.checkedListBox_1;
			this.checkedListBox_1.Enabled = true;
			control2.Visible = true;
			this.method_1();
		}
	}

	private string method_2()
	{
		DataTable dataTable = new DataTable("vAbnType");
		base.SelectSqlData(dataTable, true, string.Format("where typeKontragent = '{0}' and deleted = '0'", Convert.ToInt32(KontragentType.Own)), null, false, 0);
		if (dataTable.Rows.Count > 0)
		{
			return dataTable.Rows[0]["Name"].ToString();
		}
		return string.Empty;
	}

	private void method_3(CheckState checkState_3, CheckState checkState_4, CheckState checkState_5)
	{
		DataTable dataSourceValue = new DataTable();
		DataTable dataTable = new DataTable();
		DataTable dataTable2 = new DataTable();
		string text = string.Empty;
		if (checkState_3 == CheckState.Checked)
		{
			text = Class602.smethod_2("Documents.Forms.JournalExcavation.Reports.SqlScript.ExcavationWithoutGroupingAddr.sql");
		}
		else if (checkState_3 == CheckState.Unchecked)
		{
			text = Class602.smethod_2("Documents.Forms.JournalExcavation.Reports.SqlScript.ExcavationWithGroupingAddr.sql");
		}
		base.SelectSqlData(this.class130_0, this.class130_0.vAbnType, true, " where typeKontragent = " + 1115.ToString());
		string text2 = "";
		foreach (DataRow dataRow in this.class130_0.vAbnType)
		{
			if (!string.IsNullOrEmpty(text2))
			{
				text2 += ",";
			}
			text2 += dataRow["idAbn"].ToString();
		}
		if (this.checkBox_0.Checked)
		{
			text += "\r\n and (exc.agreed = 1) ";
		}
		if (this.checkedListBox_0.CheckedItems.Count > 0 && this.checkedListBox_0.CheckedItems.Count != this.checkedListBox_0.Items.Count)
		{
			string text3 = "";
			foreach (object obj in this.checkedListBox_0.CheckedItems)
			{
				if (!string.IsNullOrEmpty(text3))
				{
					text3 += ",";
				}
				text3 = text3 + "'" + obj.ToString() + "'";
			}
			text = text + "\r\n and (region in (" + text3 + ")) ";
		}
		if (checkState_5 == CheckState.Checked)
		{
			string string_ = text + "\r\n and exc.typeWork = 1053";
			text += "\r\n and (exc.typeWork <> 1053 or exc.typeWork is null)";
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter("hideSTP", "false"));
			dataTable2 = this.method_4(string_);
		}
		else if (checkState_5 == CheckState.Unchecked)
		{
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter("hideSTP", "true"));
			dataTable2.Clear();
		}
		string text4 = text;
		if (!string.IsNullOrEmpty(text2))
		{
			text = text + "\r\n and (exc.idContractor in (" + text2 + ")) ";
			text4 = text4 + "\r\n and (exc.idContractor not in (" + text2 + ")) ";
		}
		if (checkState_4 == CheckState.Checked)
		{
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter("hideContr", "false"));
			dataTable = this.method_4(text4);
		}
		else if (checkState_4 == CheckState.Unchecked)
		{
			this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter("hideContr", "true"));
			dataTable.Clear();
		}
		dataSourceValue = this.method_4(text);
		this.reportViewerRus_0.LocalReport.DataSources.Add(new ReportDataSource("DataSetExc", dataSourceValue));
		this.reportViewerRus_0.LocalReport.DataSources.Add(new ReportDataSource("DataSetExcContractor", dataTable));
		this.reportViewerRus_0.LocalReport.DataSources.Add(new ReportDataSource("dsExcSTP", dataTable2));
	}

	private DataTable method_4(string string_0)
	{
		DataTable dataTable = new DataTable();
		DataTable result;
		using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
		{
			sqlConnection.Open();
			using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
			{
				try
				{
					using (SqlCommand sqlCommand = new SqlCommand(string_0, sqlConnection))
					{
						sqlCommand.CommandTimeout = 0;
						sqlCommand.Transaction = sqlTransaction;
						sqlCommand.Parameters.Add("dateBeg", SqlDbType.VarChar).Value = this.dateTimePicker_0.Value.ToString("yyyyMMdd");
						sqlCommand.Parameters.Add("dateEnd", SqlDbType.VarChar).Value = this.dateTimePicker_0.Value.ToString("yyyyMMdd");
						new SqlDataAdapter(sqlCommand).Fill(dataTable);
					}
					return dataTable;
				}
				catch (Exception ex)
				{
					sqlTransaction.Rollback();
					MessageBox.Show(ex.Message, ex.Source);
					result = null;
				}
			}
		}
		return result;
	}

	private void checkedListBox_1_ItemCheck(object sender, ItemCheckEventArgs e)
	{
		switch (e.Index)
		{
		case 0:
			this.checkState_0 = e.NewValue;
			return;
		case 1:
			this.checkState_1 = e.NewValue;
			return;
		case 2:
			this.checkState_2 = e.NewValue;
			return;
		default:
			return;
		}
	}

	private void method_5()
	{
		this.icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form68));
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class130_0 = new DataSetExcavation();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.class130_1 = new DataSetExcavation();
		this.panel_0 = new Panel();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripComboBox_0 = new ToolStripComboBox();
		this.checkedListBox_1 = new CheckedListBox();
		this.groupBox_0 = new GroupBox();
		this.comboBox_0 = new ComboBox();
		this.label_1 = new Label();
		this.comboBox_1 = new ComboBox();
		this.label_2 = new Label();
		this.checkBox_0 = new CheckBox();
		this.checkedListBox_0 = new CheckedListBox();
		this.button_0 = new Button();
		this.dateTimePicker_0 = new DateTimePicker();
		this.label_0 = new Label();
		this.reportViewerRus_0 = new ReportViewerRus();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class130_0).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		((ISupportInitialize)this.class130_1).BeginInit();
		this.panel_0.SuspendLayout();
		this.toolStrip_0.SuspendLayout();
		this.groupBox_0.SuspendLayout();
		base.SuspendLayout();
		this.bindingSource_0.DataMember = "vJ_Excavation";
		this.bindingSource_0.DataSource = this.class130_0;
		this.class130_0.DataSetName = "DataSetExcavation";
		this.class130_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.bindingSource_1.DataMember = "vJ_Excavation";
		this.bindingSource_1.DataSource = this.class130_1;
		this.class130_1.DataSetName = "DataSetExcavation";
		this.class130_1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.panel_0.Controls.Add(this.toolStrip_0);
		this.panel_0.Controls.Add(this.checkedListBox_1);
		this.panel_0.Controls.Add(this.groupBox_0);
		this.panel_0.Controls.Add(this.checkBox_0);
		this.panel_0.Controls.Add(this.checkedListBox_0);
		this.panel_0.Controls.Add(this.button_0);
		this.panel_0.Controls.Add(this.dateTimePicker_0);
		this.panel_0.Controls.Add(this.label_0);
		this.panel_0.Dock = DockStyle.Left;
		this.panel_0.Location = new Point(0, 0);
		this.panel_0.Name = "panel1";
		this.panel_0.Size = new Size(172, 442);
		this.panel_0.TabIndex = 0;
		this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripComboBox_0
		});
		this.toolStrip_0.Location = new Point(0, 0);
		this.toolStrip_0.Name = "toolStrip1";
		this.toolStrip_0.Size = new Size(172, 25);
		this.toolStrip_0.TabIndex = 7;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripComboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		this.toolStripComboBox_0.Items.AddRange(new object[]
		{
			"Версия 2013 г.",
			"Версия 2016 г."
		});
		this.toolStripComboBox_0.Margin = new Padding(5, 0, 1, 0);
		this.toolStripComboBox_0.Name = "tsCBVersion";
		this.toolStripComboBox_0.Size = new Size(121, 25);
		this.toolStripComboBox_0.SelectedIndexChanged += this.toolStripComboBox_0_SelectedIndexChanged;
		this.checkedListBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.checkedListBox_1.CheckOnClick = true;
		this.checkedListBox_1.FormattingEnabled = true;
		this.checkedListBox_1.Items.AddRange(new object[]
		{
			"Разгруппировать по адресам",
			"Показать подрядчиков",
			"СТП раскопки"
		});
		this.checkedListBox_1.Location = new Point(3, 304);
		this.checkedListBox_1.Name = "chListBoxVer2";
		this.checkedListBox_1.Size = new Size(163, 49);
		this.checkedListBox_1.TabIndex = 6;
		this.checkedListBox_1.ItemCheck += this.checkedListBox_1_ItemCheck;
		this.groupBox_0.Controls.Add(this.comboBox_0);
		this.groupBox_0.Controls.Add(this.label_1);
		this.groupBox_0.Controls.Add(this.comboBox_1);
		this.groupBox_0.Controls.Add(this.label_2);
		this.groupBox_0.Location = new Point(3, 197);
		this.groupBox_0.Name = "groupBoxSign";
		this.groupBox_0.Size = new Size(163, 101);
		this.groupBox_0.TabIndex = 5;
		this.groupBox_0.TabStop = false;
		this.groupBox_0.Text = "Подпись";
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(6, 72);
		this.comboBox_0.Name = "cmbWorker";
		this.comboBox_0.Size = new Size(151, 21);
		this.comboBox_0.TabIndex = 3;
		this.comboBox_0.Text = "Демченко Л.Н.";
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(9, 56);
		this.label_1.Name = "label3";
		this.label_1.Size = new Size(34, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "ФИО";
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(6, 32);
		this.comboBox_1.Name = "cmbJobTitle";
		this.comboBox_1.Size = new Size(151, 21);
		this.comboBox_1.TabIndex = 1;
		this.comboBox_1.Text = "Главный инженер";
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(6, 16);
		this.label_2.Name = "label2";
		this.label_2.Size = new Size(65, 13);
		this.label_2.TabIndex = 0;
		this.label_2.Text = "Должность";
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Location = new Point(3, 174);
		this.checkBox_0.Name = "checkBoxAgreed";
		this.checkBox_0.Size = new Size(106, 17);
		this.checkBox_0.TabIndex = 4;
		this.checkBox_0.Text = "Согласованные";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkedListBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.checkedListBox_0.CheckOnClick = true;
		this.checkedListBox_0.FormattingEnabled = true;
		this.checkedListBox_0.Location = new Point(3, 74);
		this.checkedListBox_0.Name = "checkedListBoxRegion";
		this.checkedListBox_0.Size = new Size(163, 94);
		this.checkedListBox_0.TabIndex = 3;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.button_0.Location = new Point(3, 407);
		this.button_0.Name = "buttonLoad";
		this.button_0.Size = new Size(163, 23);
		this.button_0.TabIndex = 2;
		this.button_0.Text = "Сформировать";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.dateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.dateTimePicker_0.Location = new Point(3, 48);
		this.dateTimePicker_0.Name = "dateTimePicker1";
		this.dateTimePicker_0.Size = new Size(163, 20);
		this.dateTimePicker_0.TabIndex = 1;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 32);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(92, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "по состоянию на";
		this.reportViewerRus_0.Dock = DockStyle.Fill;
		this.reportViewerRus_0.Location = new Point(172, 0);
		this.reportViewerRus_0.Name = "reportViewerRus1";
		this.reportViewerRus_0.Size = new Size(508, 442);
		this.reportViewerRus_0.TabIndex = 1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(680, 442);
		base.Controls.Add(this.reportViewerRus_0);
		base.Controls.Add(this.panel_0);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "FormReportExcavation";
		this.Text = "Сведения о раскопках";
		base.Load += this.Form68_Load;
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class130_0).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		((ISupportInitialize)this.class130_1).EndInit();
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		base.ResumeLayout(false);
	}

	internal static void Uo5DYj0x14rCVBA7jBAX(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private CheckState checkState_0;

	private CheckState checkState_1;

	private CheckState checkState_2;

	private Panel panel_0;

	private ReportViewerRus reportViewerRus_0;

	private Button button_0;

	private DateTimePicker dateTimePicker_0;

	private Label label_0;

	private BindingSource bindingSource_0;

	private DataSetExcavation class130_0;

	private CheckedListBox checkedListBox_0;

	private CheckBox checkBox_0;

	private BindingSource bindingSource_1;

	private DataSetExcavation class130_1;

	private GroupBox groupBox_0;

	private ComboBox comboBox_0;

	private Label label_1;

	private ComboBox comboBox_1;

	private Label label_2;

	private CheckedListBox checkedListBox_1;

	private ToolStrip toolStrip_0;

	private ToolStripComboBox toolStripComboBox_0;
}
