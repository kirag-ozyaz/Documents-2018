using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using DataSql;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class Form80 : FormBase
{
	internal Form80()
	{
		
		this.bool_0 = true;
		this.double_0 = 37.79527559055;
		this.double_1 = 6.82708;
		
		this.method_8();
	}

	private void Form80_Load(object sender, EventArgs e)
	{
		this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
		this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddSeconds(-1.0);
		this.method_5();
		this.method_1();
		if (!this.checkBox_0.Checked)
		{
			this.method_6();
		}
	}

	private void method_0()
	{
		this.dataTable_1 = new DataTable("tSettings");
		this.dataTable_1.Columns.Add("id", typeof(int));
		this.dataTable_1.PrimaryKey = new DataColumn[]
		{
			this.dataTable_1.Columns["id"]
		};
		this.dataTable_1.Columns["id"].AutoIncrement = true;
		this.dataTable_1.Columns.Add("hostIP", typeof(string));
		this.dataTable_1.Columns.Add("settings", typeof(object));
		this.dataTable_1.Columns.Add("module", typeof(string));
		base.SelectSqlData(this.dataTable_1, true, " where module = 'ReportInterruptLV' ", null, false, 0);
	}

	private void method_1()
	{
		this.method_0();
		if (this.dataTable_1.Rows.Count > 0)
		{
			foreach (XElement xelement in XDocument.Parse(this.dataTable_1.Rows[0]["settings"].ToString()).Elements("confirm"))
			{
				if (xelement.Attribute("post") != null)
				{
					this.textBox_1.Text = xelement.Attribute("post").Value.ToString();
				}
				if (xelement.Attribute("FIO") != null)
				{
					this.textBox_0.Text = xelement.Attribute("FIO").Value.ToString();
				}
				if (xelement.Attribute("visible") != null)
				{
					this.checkBox_0.Checked = Convert.ToBoolean(xelement.Attribute("visible").Value);
				}
			}
		}
	}

	private void method_2()
	{
		this.class171_0.tReportIterruptLV.Clear();
		foreach (object obj in this.method_3().Rows)
		{
			DataRow dataRow = (DataRow)obj;
			DataRow dataRow2 = this.class171_0.tReportIterruptLV.NewRow();
			dataRow2["numNetRegion"] = dataRow["value"];
			dataRow2["netRegionValue"] = dataRow["name"];
			for (int i = 2; i < this.class171_0.tReportIterruptLV.Columns.Count; i++)
			{
				dataRow2[i] = 0;
			}
			this.class171_0.tReportIterruptLV.Rows.Add(dataRow2);
		}
	}

	private DataTable method_3()
	{
		DataTable dataTable = new DataTable("tR_Classifier");
		dataTable.Columns.Add("value", typeof(decimal));
		dataTable.Columns.Add("name", typeof(string));
		base.SelectSqlData(dataTable, true, " where ParentKey = ';NetworkAreas;' and deleted = 0 and isGroup = 0 order by value asc ", null, false, 0);
		DataRow dataRow = dataTable.NewRow();
		dataRow["value"] = 0;
		dataRow["name"] = "Нет данных";
		dataTable.Rows.Add(dataRow);
		return dataTable;
	}

	private DataTable method_4()
	{
		DataTable dataTable = new DataTable("tR_Classifier");
		dataTable.Columns.Add("value", typeof(decimal));
		base.SelectSqlData(dataTable, true, " where ParentKey like ';ReportDaily;PTS;ReasonDamage;LV;%' and deleted = '0' and isGroup = 0 order by value", null, false, 0);
		foreach (object obj in dataTable.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			dataRow["value"] = Convert.ToInt32(dataRow["value"]);
		}
		return dataTable;
	}

	private void method_5()
	{
		string text = string.Empty;
		string text2 = string.Empty;
		foreach (object obj in this.method_4().Rows)
		{
			DataRow dataRow = (DataRow)obj;
			if (string.IsNullOrEmpty(text2))
			{
				text = " [" + dataRow["value"].ToString() + "] as c" + dataRow["value"].ToString();
				text2 = " [" + dataRow["value"].ToString() + "]";
			}
			else
			{
				text = string.Concat(new string[]
				{
					text,
					", [",
					dataRow["value"].ToString(),
					"] as c",
					dataRow["Value"].ToString()
				});
				text2 = text2 + ", [" + dataRow["value"].ToString() + "]";
			}
		}
		string select = string.Format(" select netRegionValue as numNetRegion, {0}  from  (select t.netRegionValue, t.codeDamage from  (select dam.id, dam.numDoc, dam.dateDoc, dam.idSchmObj, dam.idReasonPTS,  sub.idNetRegion, convert(int, sub.netRegionValue) as netRegionValue, c.value as codeDamage, c.name  from tJ_Damage as dam left join  tR_Classifier as c on dam.idReasonPTS = c.Id left join  vj_damage dv on dv.id = dam.id left join  vP_SubstationByNetRegion as sub on dv.idSub = sub.id  where dam.dateDoc >= '{2}' and dam.dateDoc < '{3}' and dam.deleted = 0 ) as t  ) as res  pivot  (  count(codeDamage)  for codeDamage in ({1})  ) as pvt ", new object[]
		{
			text,
			text2,
			this.dateTimePicker_0.Value.Date.ToString("yyyyMMdd"),
			Convert.ToDateTime(this.dateTimePicker_1.Value.AddDays(1.0)).Date.ToString("yyyyMMdd")
		});
		SqlDataCommand sqlDataCommand = new SqlDataCommand(this.SqlSettings);
		this.dataTable_0 = sqlDataCommand.SelectSqlData(select);
		this.method_2();
		int count = this.class171_0.tReportIterruptLV.Columns.Count;
		int count2 = this.class171_0.tReportIterruptLV.Rows.Count;
		for (int i = 0; i < count2; i++)
		{
			for (int j = 2; j < count; j++)
			{
				this.class171_0.tReportIterruptLV.Rows[i][j] = 0;
			}
		}
		foreach (object obj2 in this.dataTable_0.Rows)
		{
			DataRow dataRow2 = (DataRow)obj2;
			for (int k = 0; k < count2; k++)
			{
				if (dataRow2["numNetRegion"] != DBNull.Value)
				{
					if ((int)dataRow2["numNetRegion"] == (int)this.class171_0.tReportIterruptLV.Rows[k]["numNetRegion"])
					{
						for (int l = 2; l < count; l++)
						{
							if ((int)dataRow2[l - 1] > 0)
							{
								this.class171_0.tReportIterruptLV.Rows[k][l] = dataRow2[l - 1];
							}
						}
					}
				}
				else
				{
					for (int m = 2; m < count; m++)
					{
						if ((int)dataRow2[m - 1] > 0)
						{
							this.class171_0.tReportIterruptLV.Rows[count2 - 1][m] = dataRow2[m - 1];
						}
					}
				}
			}
		}
		bool flag = true;
		for (int n = 0; n < count2; n++)
		{
			if ((int)this.class171_0.tReportIterruptLV.Rows[n]["numNetRegion"] == 0)
			{
				int num = 2;
				while (num < count)
				{
					if ((int)this.class171_0.tReportIterruptLV[n][num] == 0)
					{
						num++;
					}
					else
					{
						flag = false;
						IL_3D8:
						if (flag)
						{
							this.class171_0.tReportIterruptLV.Rows.RemoveAt(n);
							goto IL_3F2;
						}
						goto IL_3F2;
					}
				}
				goto IL_3D8;
			}
			IL_3F2:;
		}
		this.bindingSource_0.DataSource = this.class171_0.tReportIterruptLV;
	}

	private void method_6()
	{
		this.reportViewer_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.DailyReport.Reports.reportInterruptLV.rdlc";
		List<ReportParameter> list = new List<ReportParameter>();
		list.Add(new ReportParameter("dateBegin", this.dateTimePicker_0.Value.ToString("dd.MM.yyyy")));
		list.Add(new ReportParameter("dateEnd", this.dateTimePicker_1.Value.ToString("dd.MM.yyyy")));
		list.Add(new ReportParameter("post", this.textBox_1.Text));
		list.Add(new ReportParameter("FIO", this.method_7()));
		list.Add(new ReportParameter("hiddenConfirm", this.bool_0.ToString()));
		if (string.IsNullOrEmpty(this.textBox_1.Text))
		{
			list.Add(new ReportParameter("line", "true"));
		}
		else
		{
			list.Add(new ReportParameter("line", "false"));
		}
		this.reportViewer_0.LocalReport.SetParameters(list);
		this.reportViewer_0.RefreshReport();
	}

	private string method_7()
	{
		string text = "_______";
		Font font = new Font("Arial", 10f);
		double num = this.double_1 * this.double_0 + 39.0;
		text += this.textBox_0.Text;
		Size size = TextRenderer.MeasureText(text, font);
		if ((double)size.Width <= num)
		{
			if (num - (double)size.Width >= 2.0)
			{
				while ((double)size.Width < num - 13.0)
				{
					text = text.Insert(1, "_");
					size = TextRenderer.MeasureText(text, font);
				}
				return text;
			}
		}
		while ((double)size.Width > num || num - (double)size.Width < 2.0)
		{
			text = text.Remove(text.Length - 1);
			size = TextRenderer.MeasureText(text, font);
		}
		return text;
	}

	private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		if (this.dateTimePicker_1.Value < this.dateTimePicker_0.Value)
		{
			this.dateTimePicker_1.Value = this.dateTimePicker_0.Value;
		}
	}

	private void dateTimePicker_1_ValueChanged(object sender, EventArgs e)
	{
		if (this.dateTimePicker_1.Value < this.dateTimePicker_0.Value)
		{
			this.dateTimePicker_0.Value = this.dateTimePicker_1.Value;
		}
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		if (this.checkBox_0.Checked)
		{
			this.bool_0 = false;
		}
		else
		{
			this.bool_0 = true;
		}
		this.method_6();
	}

	private void textBox_1_Leave(object sender, EventArgs e)
	{
		if (!this.bool_0)
		{
			this.method_6();
		}
	}

	private void textBox_0_Leave(object sender, EventArgs e)
	{
		if (!this.bool_0)
		{
			this.method_6();
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		this.method_5();
		this.method_6();
	}

	private void Form80_FormClosed(object sender, FormClosedEventArgs e)
	{
		XDocument xdocument = new XDocument(new XDeclaration("1.0", "utf-16", null), new object[]
		{
			new XElement("confirm", new object[]
			{
				new XAttribute("post", this.textBox_1.Text),
				new XAttribute("FIO", this.textBox_0.Text),
				new XAttribute("visible", this.checkBox_0.Checked.ToString())
			})
		});
		if (this.dataTable_1.Rows.Count > 0)
		{
			this.dataTable_1.Rows[0]["settings"] = xdocument.ToString();
			base.UpdateSqlData(this.dataTable_1);
			return;
		}
		DataRow dataRow = this.dataTable_1.NewRow();
		dataRow["settings"] = xdocument.ToString();
		dataRow["module"] = "ReportInterruptLV";
		this.dataTable_1.Rows.Add(dataRow);
		this.dataTable_1.Rows[0].EndEdit();
		base.InsertSqlData(this.dataTable_1);
	}

	private void method_8()
	{
		this.icontainer_0 = new Container();
		ReportDataSource reportDataSource = new ReportDataSource();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class171_0 = new Class171();
		this.dateTimePicker_0 = new DateTimePicker();
		this.dateTimePicker_1 = new DateTimePicker();
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.panel_0 = new Panel();
		this.button_0 = new Button();
		this.checkBox_0 = new CheckBox();
		this.reportViewer_0 = new ReportViewer();
		this.textBox_0 = new TextBox();
		this.textBox_1 = new TextBox();
		this.label_2 = new Label();
		this.label_3 = new Label();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class171_0).BeginInit();
		this.panel_0.SuspendLayout();
		base.SuspendLayout();
		this.bindingSource_0.DataMember = "tReportIterruptLV";
		this.bindingSource_0.DataSource = this.class171_0;
		this.class171_0.DataSetName = "DataSetDamage";
		this.class171_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.dateTimePicker_0.Anchor = AnchorStyles.Top;
		this.dateTimePicker_0.Location = new Point(342, 8);
		this.dateTimePicker_0.Name = "dtpBegin";
		this.dateTimePicker_0.Size = new Size(131, 20);
		this.dateTimePicker_0.TabIndex = 0;
		this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
		this.dateTimePicker_1.Anchor = AnchorStyles.Top;
		this.dateTimePicker_1.Location = new Point(523, 8);
		this.dateTimePicker_1.Name = "dtpEnd";
		this.dateTimePicker_1.Size = new Size(131, 20);
		this.dateTimePicker_1.TabIndex = 1;
		this.dateTimePicker_1.ValueChanged += this.dateTimePicker_1_ValueChanged;
		this.label_0.Anchor = AnchorStyles.Top;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(282, 14);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(54, 13);
		this.label_0.TabIndex = 2;
		this.label_0.Text = "Период с";
		this.label_1.Anchor = AnchorStyles.Top;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(498, 14);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(19, 13);
		this.label_1.TabIndex = 3;
		this.label_1.Text = "по";
		this.panel_0.Controls.Add(this.textBox_0);
		this.panel_0.Controls.Add(this.button_0);
		this.panel_0.Controls.Add(this.textBox_1);
		this.panel_0.Controls.Add(this.checkBox_0);
		this.panel_0.Controls.Add(this.label_2);
		this.panel_0.Controls.Add(this.label_0);
		this.panel_0.Controls.Add(this.label_3);
		this.panel_0.Controls.Add(this.dateTimePicker_0);
		this.panel_0.Controls.Add(this.label_1);
		this.panel_0.Controls.Add(this.dateTimePicker_1);
		this.panel_0.Dock = DockStyle.Top;
		this.panel_0.Location = new Point(0, 0);
		this.panel_0.Name = "panel1";
		this.panel_0.Size = new Size(890, 90);
		this.panel_0.TabIndex = 5;
		this.button_0.Anchor = AnchorStyles.Top;
		this.button_0.Location = new Point(669, 5);
		this.button_0.Name = "btnApply";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 5;
		this.button_0.Text = "Применить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Location = new Point(12, 13);
		this.checkBox_0.Name = "checkBox1";
		this.checkBox_0.Size = new Size(160, 17);
		this.checkBox_0.TabIndex = 4;
		this.checkBox_0.Text = "Показать \"УТВЕРЖДАЮ\"";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
		this.reportViewer_0.Dock = DockStyle.Fill;
		reportDataSource.Name = "dsReport";
		reportDataSource.Value = this.bindingSource_0;
		this.reportViewer_0.LocalReport.DataSources.Add(reportDataSource);
		this.reportViewer_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.DailyReport.Reports.reportInterruptLV.rdlc";
		this.reportViewer_0.Location = new Point(0, 90);
		this.reportViewer_0.Name = "rViewerDoc";
		this.reportViewer_0.Size = new Size(890, 454);
		this.reportViewer_0.TabIndex = 6;
		this.textBox_0.Location = new Point(86, 62);
		this.textBox_0.Name = "txtFIO";
		this.textBox_0.Size = new Size(302, 20);
		this.textBox_0.TabIndex = 3;
		this.textBox_0.Leave += this.textBox_0_Leave;
		this.textBox_1.Location = new Point(86, 36);
		this.textBox_1.Name = "txtPost";
		this.textBox_1.Size = new Size(302, 20);
		this.textBox_1.TabIndex = 2;
		this.textBox_1.Leave += this.textBox_1_Leave;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(12, 63);
		this.label_2.Name = "label4";
		this.label_2.Size = new Size(37, 13);
		this.label_2.TabIndex = 1;
		this.label_2.Text = "ФИО:";
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 39);
		this.label_3.Name = "label3";
		this.label_3.Size = new Size(68, 13);
		this.label_3.TabIndex = 0;
		this.label_3.Text = "Должность:";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(890, 544);
		base.Controls.Add(this.reportViewer_0);
		base.Controls.Add(this.panel_0);
		base.Name = "FormReportInterruptLV";
		this.Text = "Бюллетень перерывов электроснабжения в сетях 0,4 кВ";
		base.FormClosed += this.Form80_FormClosed;
		base.Load += this.Form80_Load;
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class171_0).EndInit();
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		base.ResumeLayout(false);
	}

	private DataTable dataTable_0;

	private bool bool_0;

	private double double_0;

	private double double_1;

	private DataTable dataTable_1;

	private DateTimePicker dateTimePicker_0;

	private DateTimePicker dateTimePicker_1;

	private Label label_0;

	private Label label_1;

	private Panel panel_0;

	private ReportViewer reportViewer_0;

	private BindingSource bindingSource_0;

	private Class171 class171_0;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private Label label_2;

	private Label label_3;

	private CheckBox checkBox_0;

	private Button button_0;
}
