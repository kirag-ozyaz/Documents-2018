using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using ControlsLbr.ReportViewerRus;
using Documents.Properties;
using FormLbr;
using Microsoft.Reporting.WinForms;

internal partial class Form56 : FormBase
{
	internal Form56()
	{
		
		this.string_0 = "Главный инженер";
		this.string_1 = "МУП \"УльГЭС\"";
		this.string_2 = "Л.Н.Демченко";
		this.string_3 = "Начальник ОДС";
		this.string_4 = "Л.Г. Белавина";
		this.string_5 = "Зам.начальника ОДС";
		this.string_6 = "А.Б. Манузин";
		
		this.method_1();
		this.dateTimePicker_1.Value = (this.dateTimePicker_0.Value = DateTime.Now);
	}

	internal Form56(bool bool_1 = false)
	{
		
		this.string_0 = "Главный инженер";
		this.string_1 = "МУП \"УльГЭС\"";
		this.string_2 = "Л.Н.Демченко";
		this.string_3 = "Начальник ОДС";
		this.string_4 = "Л.Г. Белавина";
		this.string_5 = "Зам.начальника ОДС";
		this.string_6 = "А.Б. Манузин";
		
		this.method_1();
		this.dateTimePicker_1.Value = (this.dateTimePicker_0.Value = DateTime.Now);
		this.bool_0 = bool_1;
		if (bool_1)
		{
			this.Text = "Отчет аварийных заявок на ремонт оборудования";
		}
	}

	private void Form56_Load(object sender, EventArgs e)
	{
		base.SelectSqlData(this.class255_0, this.class255_0.tR_Classifier, true, " where ParentKey = ';NetworkAreas;' and deleted = 0 and isGroup = 0 order by name ");
		foreach (DataRow dataRow in this.class255_0.tR_Classifier)
		{
			Form56.Struct9 @struct = new Form56.Struct9(Convert.ToInt32(dataRow["id"]), dataRow["name"].ToString());
			this.checkedListBox_0.Items.Add(@struct, true);
		}
		base.SelectSqlData(this.class255_0, this.class255_0.tR_Classifier, true, " where ParentKey = ';Other;DivisionRequestRepair;' and isgroup = 0 and deleted = 0 order by name");
		this.comboBox_0.DataSource = this.class255_0.tR_Classifier;
		this.comboBox_0.DisplayMember = "name";
		this.comboBox_0.ValueMember = "ID";
		this.comboBox_0.SelectedValue = 920;
		base.LoadFormConfig(null);
	}

	private void Form56_FormClosed(object sender, FormClosedEventArgs e)
	{
		base.SaveFormConfig(null);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		if (this.checkBox_0.Checked)
		{
			if (this.dateTimePicker_1.Value.Date == this.dateTimePicker_0.Value.Date)
			{
				this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalRequestForRepair.Reports.ReportrequestForRepairFull.rdlc";
			}
			else
			{
				this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalRequestForRepair.Reports.ReportrequestForRepairFullPeriod.rdlc";
			}
		}
		else if (this.dateTimePicker_1.Value.Date == this.dateTimePicker_0.Value.Date)
		{
			this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalRequestForRepair.Reports.ReportrequestForRepairNoAddress.rdlc";
		}
		else
		{
			this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalRequestForRepair.Reports.ReportrequestForRepairNoAddressPeriod.rdlc";
		}
		ReportParameter reportParameter = new ReportParameter("DateBegin", this.dateTimePicker_1.Value.Date.ToString());
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		reportParameter = new ReportParameter("DateEnd", this.dateTimePicker_0.Value.Date.ToString());
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		reportParameter = new ReportParameter("ShowAgreed", (!this.checkBox_1.Checked).ToString());
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		reportParameter = new ReportParameter("AppoveTitle", this.string_0);
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		reportParameter = new ReportParameter("AppoveOrg", this.string_1);
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		reportParameter = new ReportParameter("AppoveFIO", this.string_2);
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		reportParameter = new ReportParameter("SignatureTitle1", string.IsNullOrEmpty(this.string_3) ? null : this.string_3);
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		reportParameter = new ReportParameter("SignatureFIO1", string.IsNullOrEmpty(this.string_4) ? null : this.string_4);
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		reportParameter = new ReportParameter("SignatureTitle2", string.IsNullOrEmpty(this.string_5) ? null : this.string_5);
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		reportParameter = new ReportParameter("SignatureFIO2", string.IsNullOrEmpty(this.string_6) ? null : this.string_6);
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		reportParameter = new ReportParameter("isCrash", this.bool_0.ToString());
		this.reportViewerRus_0.LocalReport.SetParameters(new ReportParameter[]
		{
			reportParameter
		});
		string text = "'" + this.dateTimePicker_1.Value.Date.ToString("yyyyMMdd") + "'";
		string text2 = "'" + this.dateTimePicker_0.Value.Date.ToString("yyyyMMdd") + " 23:59:59'";
		string text3 = string.Concat(new string[]
		{
			" ((dateTripBeg >= ",
			text,
			" and datetripBEg <= ",
			text2,
			") or (datetripend >= ",
			text,
			" and datetripEnd <= ",
			text2,
			") or (datetripBeg <= ",
			text,
			" and dateTRipEnd >= ",
			text2,
			")) "
		});
		if (this.checkedListBox_0.CheckedItems.Count <= 0)
		{
			this.class255_0.vJ_RequestForRepairDaily.Clear();
		}
		else
		{
			string text4 = "";
			foreach (object obj in this.checkedListBox_0.CheckedItems)
			{
				text4 = text4 + ((Form56.Struct9)obj).int_0.ToString() + ",";
			}
			text4 = " (idSR in (" + text4.Remove(text4.Length - 1) + ")) ";
			if (this.comboBox_0.SelectedValue == null)
			{
				this.class255_0.vJ_RequestForRepairDaily.Clear();
			}
			else
			{
				string text5 = " (idDivision = " + this.comboBox_0.SelectedValue.ToString() + ") ";
				string text6 = "";
				if (!string.IsNullOrEmpty(this.textBox_0.Text))
				{
					text6 = " and (schmObj like '%" + this.textBox_0.Text + "%') ";
				}
				string text7 = "";
				if (this.checkBox_1.Checked)
				{
					text7 = " and (Agreed = 1) ";
				}
				string text8;
				if (this.bool_0)
				{
					text8 = " and (Crash = 1) ";
				}
				else
				{
					text8 = " and (Crash = 0 or Crash is null) ";
				}
				base.SelectSqlData(this.class255_0, this.class255_0.vJ_RequestForRepairDaily, true, string.Concat(new string[]
				{
					" where ",
					text3,
					" and ",
					text4,
					" and ",
					text5,
					text6,
					text7,
					text8,
					" and deleted = 0 order by sr, id, datetripBeg"
				}));
				this.method_0(this.dateTimePicker_1.Value.Date, this.dateTimePicker_0.Value.Date);
			}
		}
		this.reportViewerRus_0.RefreshReport();
	}

	private void method_0(DateTime dateTime_0, DateTime dateTime_1)
	{
		bool flag = dateTime_0 == dateTime_1;
		for (int i = 0; i < this.class255_0.vJ_RequestForRepairDaily.Rows.Count; i++)
		{
			DataRow dataRow = this.class255_0.vJ_RequestForRepairDaily.Rows[i];
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4;
			if (!flag)
			{
				text = Convert.ToDateTime(dataRow["DateTripBeg"]).ToShortDateString();
				text4 = Convert.ToDateTime(dataRow["DateTripBeg"]).ToShortTimeString();
				text2 = Convert.ToDateTime(dataRow["DateTripEnd"]).ToShortDateString();
				text3 = Convert.ToDateTime(dataRow["DateTripEnd"]).ToShortTimeString();
			}
			else
			{
				if (dateTime_0 > Convert.ToDateTime(dataRow["DateTripBeg"]))
				{
					text4 = "0:00";
				}
				else
				{
					text4 = Convert.ToDateTime(dataRow["DateTripBeg"]).ToShortTimeString();
				}
				if (dateTime_1.AddDays(1.0).AddMinutes(-1.0) < Convert.ToDateTime(dataRow["DateTripEnd"]))
				{
					text4 += " - 23:59";
				}
				else
				{
					text4 = text4 + " - " + Convert.ToDateTime(dataRow["DateTripEnd"]).ToShortTimeString();
				}
			}
			int num = 1;
			while (i + num < this.class255_0.vJ_RequestForRepairDaily.Rows.Count)
			{
				DataRow dataRow2 = this.class255_0.vJ_RequestForRepairDaily.Rows[i + num];
				if (Convert.ToInt32(dataRow["id"]) != Convert.ToInt32(dataRow2["id"]))
				{
					break;
				}
				if (!flag)
				{
					text = text + "\n" + Convert.ToDateTime(dataRow2["DateTripBeg"]).ToShortDateString();
					text4 = text4 + "\n" + Convert.ToDateTime(dataRow2["DateTripBeg"]).ToShortTimeString();
					text2 = text2 + "\n" + Convert.ToDateTime(dataRow2["DateTripEnd"]).ToShortDateString();
					text3 = text3 + "\n" + Convert.ToDateTime(dataRow2["DateTripEnd"]).ToShortTimeString();
				}
				else
				{
					if (dateTime_0 > Convert.ToDateTime(dataRow2["DateTripBeg"]))
					{
						text4 += "\n0:00";
					}
					else
					{
						text4 = text4 + "\n" + Convert.ToDateTime(dataRow2["DateTripBeg"]).ToShortTimeString();
					}
					if (dateTime_1.AddDays(1.0).AddMinutes(-1.0) < Convert.ToDateTime(dataRow2["DateTripEnd"]))
					{
						text4 += " - 23:59";
					}
					else
					{
						text4 = text4 + " - " + Convert.ToDateTime(dataRow2["DateTripEnd"]).ToShortTimeString();
					}
				}
				this.class255_0.vJ_RequestForRepairDaily.Rows.Remove(dataRow2);
			}
			dataRow["dateBeg"] = text;
			dataRow["dateEnd"] = text2;
			dataRow["timeBeg"] = text4;
			dataRow["timeEnd"] = text3;
		}
	}

	private void dateTimePicker_1_ValueChanged(object sender, EventArgs e)
	{
		this.dateTimePicker_0.MinDate = this.dateTimePicker_1.Value;
	}

	private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		this.dateTimePicker_1.MaxDate = this.dateTimePicker_0.Value;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		FormReportReguestForRepairSettings formReportReguestForRepairSettings = new FormReportReguestForRepairSettings();
		formReportReguestForRepairSettings.AppoveTitle = this.string_0;
		formReportReguestForRepairSettings.AppoveOrg = this.string_1;
		formReportReguestForRepairSettings.String_0 = this.string_2;
		formReportReguestForRepairSettings.SignatureTitle1 = this.string_3;
		formReportReguestForRepairSettings.SignatureFIO1 = this.string_4;
		formReportReguestForRepairSettings.SignatureTitle2 = this.string_5;
		formReportReguestForRepairSettings.SignatureFIO2 = this.string_6;
		if (formReportReguestForRepairSettings.ShowDialog() == DialogResult.OK)
		{
			this.string_0 = formReportReguestForRepairSettings.AppoveTitle;
			this.string_1 = formReportReguestForRepairSettings.AppoveOrg;
			this.string_2 = formReportReguestForRepairSettings.String_0;
			this.string_3 = formReportReguestForRepairSettings.SignatureTitle1;
			this.string_4 = formReportReguestForRepairSettings.SignatureFIO1;
			this.string_5 = formReportReguestForRepairSettings.SignatureTitle2;
			this.string_6 = formReportReguestForRepairSettings.SignatureFIO2;
		}
	}

	protected override XmlDocument CreateXmlConfig()
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlNode newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
		xmlDocument.AppendChild(newChild);
		XmlNode xmlNode = xmlDocument.CreateElement(base.Name);
		xmlDocument.AppendChild(xmlNode);
		XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("appoveTitle");
		xmlAttribute.Value = this.string_0;
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("appoveOrg");
		xmlAttribute.Value = this.string_1;
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("appoveFIO");
		xmlAttribute.Value = this.string_2;
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("signatureTitle1");
		xmlAttribute.Value = this.string_3;
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("signatureFIO1");
		xmlAttribute.Value = this.string_4;
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("signatureTitle2");
		xmlAttribute.Value = this.string_5;
		xmlNode.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("signatureFIO2");
		xmlAttribute.Value = this.string_6;
		xmlNode.Attributes.Append(xmlAttribute);
		return xmlDocument;
	}

	protected override void ApplyConfig(XmlDocument xmlDocument_0)
	{
		XmlNode xmlNode = xmlDocument_0.SelectSingleNode(base.Name);
		if (xmlNode != null)
		{
			XmlAttribute xmlAttribute = xmlNode.Attributes["appoveTitle"];
			if (xmlAttribute != null)
			{
				this.string_0 = xmlAttribute.Value;
			}
			xmlAttribute = xmlNode.Attributes["appoveOrg"];
			if (xmlAttribute != null)
			{
				this.string_1 = xmlAttribute.Value;
			}
			xmlAttribute = xmlNode.Attributes["appoveFIO"];
			if (xmlAttribute != null)
			{
				this.string_2 = xmlAttribute.Value;
			}
			xmlAttribute = xmlNode.Attributes["signatureTitle1"];
			if (xmlAttribute != null)
			{
				this.string_3 = xmlAttribute.Value;
			}
			xmlAttribute = xmlNode.Attributes["signatureFIO1"];
			if (xmlAttribute != null)
			{
				this.string_4 = xmlAttribute.Value;
			}
			xmlAttribute = xmlNode.Attributes["signatureTitle2"];
			if (xmlAttribute != null)
			{
				this.string_5 = xmlAttribute.Value;
			}
			xmlAttribute = xmlNode.Attributes["signatureFIO2"];
			if (xmlAttribute != null)
			{
				this.string_6 = xmlAttribute.Value;
			}
		}
	}

	private void method_1()
	{
		this.icontainer_0 = new Container();
		ReportDataSource reportDataSource = new ReportDataSource();
		ReportDataSource reportDataSource2 = new ReportDataSource();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form56));
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class255_0 = new Class255();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.reportViewerRus_0 = new ReportViewerRus();
		this.panel_0 = new Panel();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.comboBox_0 = new ComboBox();
		this.label_5 = new Label();
		this.checkedListBox_0 = new CheckedListBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.textBox_0 = new TextBox();
		this.label_0 = new Label();
		this.checkBox_0 = new CheckBox();
		this.checkBox_1 = new CheckBox();
		this.label_1 = new Label();
		this.dateTimePicker_0 = new DateTimePicker();
		this.label_2 = new Label();
		this.dateTimePicker_1 = new DateTimePicker();
		this.label_3 = new Label();
		this.label_4 = new Label();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class255_0).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		this.panel_0.SuspendLayout();
		this.toolStrip_0.SuspendLayout();
		base.SuspendLayout();
		this.bindingSource_0.DataMember = "vJ_RequestForRepair";
		this.bindingSource_0.DataSource = this.class255_0;
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.bindingSource_1.DataMember = "vJ_RequestForRepairDaily";
		this.bindingSource_1.DataSource = this.class255_0;
		this.reportViewerRus_0.Dock = DockStyle.Fill;
		reportDataSource.Name = "DataSetGES";
		reportDataSource.Value = this.bindingSource_0;
		reportDataSource2.Name = "DataSetDaily";
		reportDataSource2.Value = this.bindingSource_1;
		this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource);
		this.reportViewerRus_0.LocalReport.DataSources.Add(reportDataSource2);
		this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.JournalRequestForRepair.Reports.ReportrequestForRepairFull.rdlc";
		this.reportViewerRus_0.Location = new Point(211, 0);
		this.reportViewerRus_0.Name = "reportViewerRus1";
		this.reportViewerRus_0.Size = new Size(485, 494);
		this.reportViewerRus_0.TabIndex = 0;
		this.panel_0.Controls.Add(this.toolStrip_0);
		this.panel_0.Controls.Add(this.comboBox_0);
		this.panel_0.Controls.Add(this.label_5);
		this.panel_0.Controls.Add(this.checkedListBox_0);
		this.panel_0.Controls.Add(this.button_0);
		this.panel_0.Controls.Add(this.button_1);
		this.panel_0.Controls.Add(this.textBox_0);
		this.panel_0.Controls.Add(this.label_0);
		this.panel_0.Controls.Add(this.checkBox_0);
		this.panel_0.Controls.Add(this.checkBox_1);
		this.panel_0.Controls.Add(this.label_1);
		this.panel_0.Controls.Add(this.dateTimePicker_0);
		this.panel_0.Controls.Add(this.label_2);
		this.panel_0.Controls.Add(this.dateTimePicker_1);
		this.panel_0.Controls.Add(this.label_3);
		this.panel_0.Controls.Add(this.label_4);
		this.panel_0.Dock = DockStyle.Left;
		this.panel_0.Location = new Point(0, 0);
		this.panel_0.Name = "panel1";
		this.panel_0.Size = new Size(211, 494);
		this.panel_0.TabIndex = 1;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0
		});
		this.toolStrip_0.Location = new Point(0, 0);
		this.toolStrip_0.Name = "toolStrip";
		this.toolStrip_0.Size = new Size(211, 25);
		this.toolStrip_0.TabIndex = 16;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources.Setting;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtnSettings";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Настройки";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(9, 237);
		this.comboBox_0.Name = "cmdDivision";
		this.comboBox_0.Size = new Size(199, 21);
		this.comboBox_0.TabIndex = 15;
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(6, 221);
		this.label_5.Name = "label6";
		this.label_5.Size = new Size(87, 13);
		this.label_5.TabIndex = 14;
		this.label_5.Text = "Подразделения";
		this.checkedListBox_0.CheckOnClick = true;
		this.checkedListBox_0.FormattingEnabled = true;
		this.checkedListBox_0.Location = new Point(9, 124);
		this.checkedListBox_0.Name = "checkedListBoxSR";
		this.checkedListBox_0.Size = new Size(199, 94);
		this.checkedListBox_0.TabIndex = 13;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.Location = new Point(114, 466);
		this.button_0.Name = "buttonClose";
		this.button_0.Size = new Size(94, 25);
		this.button_0.TabIndex = 12;
		this.button_0.Text = "Закрыть";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_1.Location = new Point(9, 466);
		this.button_1.Name = "buttonAplly";
		this.button_1.Size = new Size(96, 25);
		this.button_1.TabIndex = 11;
		this.button_1.Text = "Сформировать";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.textBox_0.Location = new Point(9, 323);
		this.textBox_0.Name = "txtObject";
		this.textBox_0.Size = new Size(199, 20);
		this.textBox_0.TabIndex = 10;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(6, 307);
		this.label_0.Name = "label5";
		this.label_0.Size = new Size(112, 13);
		this.label_0.TabIndex = 9;
		this.label_0.Text = "Отключаемы объект";
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Location = new Point(9, 287);
		this.checkBox_0.Name = "checkBoxShowAdresses";
		this.checkBox_0.Size = new Size(115, 17);
		this.checkBox_0.TabIndex = 8;
		this.checkBox_0.Text = "Выводить адреса";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_1.AutoSize = true;
		this.checkBox_1.Location = new Point(9, 264);
		this.checkBox_1.Name = "checkBoxIsAgreed";
		this.checkBox_1.Size = new Size(155, 17);
		this.checkBox_1.TabIndex = 7;
		this.checkBox_1.Text = "Учитывать согласование";
		this.checkBox_1.UseVisualStyleBackColor = true;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(6, 108);
		this.label_1.Name = "label4";
		this.label_1.Size = new Size(92, 13);
		this.label_1.TabIndex = 5;
		this.label_1.Text = "Сетевые районы";
		this.dateTimePicker_0.Location = new Point(31, 76);
		this.dateTimePicker_0.Name = "dateTimePickerEnd";
		this.dateTimePicker_0.Size = new Size(177, 20);
		this.dateTimePicker_0.TabIndex = 4;
		this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(6, 82);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(19, 13);
		this.label_2.TabIndex = 3;
		this.label_2.Text = "по";
		this.dateTimePicker_1.Location = new Point(31, 50);
		this.dateTimePicker_1.Name = "dateTimePickerBeg";
		this.dateTimePicker_1.Size = new Size(177, 20);
		this.dateTimePicker_1.TabIndex = 2;
		this.dateTimePicker_1.ValueChanged += this.dateTimePicker_1_ValueChanged;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 56);
		this.label_3.Name = "label2";
		this.label_3.Size = new Size(13, 13);
		this.label_3.TabIndex = 1;
		this.label_3.Text = "с";
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(12, 32);
		this.label_4.Name = "label1";
		this.label_4.Size = new Size(45, 13);
		this.label_4.TabIndex = 0;
		this.label_4.Text = "Период";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(696, 494);
		base.Controls.Add(this.reportViewerRus_0);
		base.Controls.Add(this.panel_0);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		this.MinimumSize = new Size(500, 400);
		base.Name = "FormReportRequestForRepair";
		this.Text = "Отчет заявок на ремонт оборудования";
		base.FormClosed += this.Form56_FormClosed;
		base.Load += this.Form56_Load;
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class255_0).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		base.ResumeLayout(false);
	}

	private bool bool_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private Class255 class255_0;

	private BindingSource bindingSource_0;

	private ReportViewerRus reportViewerRus_0;

	private Panel panel_0;

	private Button button_0;

	private Button button_1;

	private TextBox textBox_0;

	private Label label_0;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private Label label_1;

	private DateTimePicker dateTimePicker_0;

	private Label label_2;

	private DateTimePicker dateTimePicker_1;

	private Label label_3;

	private Label label_4;

	private BindingSource bindingSource_1;

	private CheckedListBox checkedListBox_0;

	private ComboBox comboBox_0;

	private Label label_5;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private struct Struct9
	{
		public Struct9(int int_1, string string_1)
		{
			
			this.int_0 = int_1;
			this.string_0 = string_1;
		}

		public override string ToString()
		{
			return this.string_0;
		}

		public int int_0;

		public string string_0;
	}
}
