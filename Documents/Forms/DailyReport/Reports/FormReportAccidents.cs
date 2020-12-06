using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using ControlsLbr.ReportViewerRus;
using DataSql;
using FormLbr;
using Microsoft.Reporting.WinForms;

namespace Documents.Forms.DailyReport.Reports
{
	public partial class FormReportAccidents : FormBase
	{
		public FormReportAccidents()
		{
			
			
			this.method_2();
			this.reportViewerRus_0 = new ReportViewerRus();
			this.reportViewerRus_0.Dock = DockStyle.Fill;
			this.reportViewerRus_0.Size = new Size(625, 571);
			this.splitContainer_0.Panel2.Controls.Add(this.reportViewerRus_0);
		}

		private void FormReportAccidents_Load(object sender, EventArgs e)
		{
			this.method_0();
			this.method_1();
		}

		private void method_0()
		{
			this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, 1, 1);
			this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year, 12, 31);
			DataTable dataTable = new SqlDataCommand(this.SqlSettings).SelectSqlData("select year(dateDoc) as year\r\n                                                from tj_damage\r\n                                                where (typedoc = 1874 or (typeDoc = 1844 and idParent is null))\r\n                                                group by year(dateDoc)\r\n                                                order by year(dateDoc) desc");
			if (dataTable.Rows.Count > 0)
			{
				using (IEnumerator enumerator = dataTable.Rows.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DataRow dataRow = (DataRow)obj;
						this.comboBox_0.Items.Add(dataRow["year"]);
					}
					goto IL_DC;
				}
			}
			this.comboBox_0.Items.Add(DateTime.Now.Year);
			IL_DC:
			this.comboBox_0.SelectedIndex = 0;
			foreach (object obj2 in this.comboBox_0.Items)
			{
				if (Convert.ToInt32(obj2) == DateTime.Now.Year)
				{
					this.comboBox_0.SelectedItem = obj2;
					break;
				}
			}
		}

		private void radioButton_0_CheckedChanged(object sender, EventArgs e)
		{
			this.comboBox_0.Enabled = this.radioButton_1.Checked;
			this.dateTimePicker_1.Enabled = (this.dateTimePicker_0.Enabled = this.radioButton_0.Checked);
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			this.method_1();
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			this.method_0();
			this.method_1();
		}

		private void method_1()
		{
			this.toolStrip_0.Enabled = false;
			this.groupBox_0.Enabled = false;
			this.groupBox_1.Enabled = false;
			this.groupBox_2.Enabled = false;
			this.reportViewerRus_0.Enabled = false;
			this.reportViewerRus_0.LocalReport.DataSources.Clear();
			this.progressBar_0.Visible = true;
			FormReportAccidents.Class169 @class = new FormReportAccidents.Class169();
			if (this.radioButton_1.Checked)
			{
				if (this.comboBox_0.SelectedIndex >= 0)
				{
					@class.dateTime_0 = new DateTime(Convert.ToInt32(this.comboBox_0.SelectedItem), 1, 1);
					@class.dateTime_1 = new DateTime(Convert.ToInt32(this.comboBox_0.SelectedItem), 12, 31);
				}
			}
			else
			{
				@class.dateTime_0 = this.dateTimePicker_1.Value;
				@class.dateTime_1 = this.dateTimePicker_0.Value;
			}
			@class.bool_0 = this.checkBox_1.Checked;
			@class.bool_1 = this.checkBox_0.Checked;
			this.backgroundWorker_0.RunWorkerAsync(@class);
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			Class171.Class196 @class = new Class171.Class196();
			if (e.Argument == null || !(e.Argument is FormReportAccidents.Class169))
			{
				return;
			}
			FormReportAccidents.Class169 class2 = (FormReportAccidents.Class169)e.Argument;
			if (!class2.bool_0 && !class2.bool_1)
			{
				return;
			}
			using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString()))
			{
				try
				{
					sqlConnection.Open();
					string text = Class602.smethod_2("Documents.Forms.DailyReport.SqlScripts.ReportAccidents.sql");
					text += string.Format(" where (isnull(dHV.dateDoc, d.dateDoc) >= '{0}' and \r\n                                        isnull(dOn.dateOn, d.dateApply) < '{1}') ", class2.dateTime_0.Date.ToString("yyyyMMdd"), class2.dateTime_1.Date.AddDays(1.0).ToString("yyyyMMdd"));
					if (class2.bool_0)
					{
						if (class2.bool_1)
						{
							text += " and (d.typedoc = 1874 or (d.typeDoc = 1844 and d.idParent is null)) ";
						}
						else
						{
							text += " and (d.typedoc = 1874) ";
						}
					}
					else if (class2.bool_1)
					{
						text += " and (d.typeDoc = 1844 and d.idParent is null) ";
					}
					text += "\r\n order by isnull(dHV.dateDoc, d.dateDoc), ad.numCrash";
					using (SqlCommand sqlCommand = new SqlCommand(text, sqlConnection))
					{
						sqlCommand.CommandTimeout = 0;
						sqlCommand.CommandType = CommandType.Text;
						new SqlDataAdapter(sqlCommand).Fill(@class);
						string b = "190000";
						int num = 1;
						foreach (object obj in @class.Rows)
						{
							DataRow dataRow = (DataRow)obj;
							if (Convert.ToDateTime(dataRow["datedoc"]).ToString("yyyyMM") != b)
							{
								b = Convert.ToDateTime(dataRow["datedoc"]).ToString("yyyyMM");
								num = 1;
							}
							if (Convert.ToBoolean(dataRow["isCrash"]))
							{
								dataRow["numCrashMonth"] = num;
								num++;
							}
							if (dataRow["dateEnd"] != DBNull.Value && dataRow["dateDoc"] != DBNull.Value)
							{
								TimeSpan t = Convert.ToDateTime(dataRow["dateEnd"]).AddSeconds((double)(-(double)Convert.ToDateTime(dataRow["dateEnd"]).Second)) - Convert.ToDateTime(dataRow["dateDoc"]).AddSeconds((double)(-(double)Convert.ToDateTime(dataRow["dateDoc"]).Second));
								int num2 = (int)(t - TimeSpan.FromHours((double)((int)t.TotalHours))).TotalMinutes;
								string str;
								if (num2 < 10)
								{
									str = "0" + num2.ToString();
								}
								else
								{
									str = num2.ToString();
								}
								dataRow["timeCrash"] = ((int)t.TotalHours).ToString() + ":" + str;
							}
						}
						@class.AcceptChanges();
						e.Result = @class;
						return;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
					sqlConnection.Close();
					@class = new Class171.Class196();
				}
			}
			e.Result = @class;
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			PrinterSettings printerSettings = new PrinterSettings();
			IQueryable<PaperSize> source = printerSettings.PaperSizes.Cast<PaperSize>().AsQueryable<PaperSize>();
			if (this.radioButton_2.Checked)
			{
				this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.DailyReport.Reports.ReportAccidentsA3.rdlc";
				PaperSize paperSize = (from paperSize in source
				where (int)paperSize.Kind == 8
				select paperSize).FirstOrDefault<PaperSize>();
				printerSettings.DefaultPageSettings.PaperSize = paperSize;
			}
			else
			{
				this.reportViewerRus_0.LocalReport.ReportEmbeddedResource = "Documents.Forms.DailyReport.Reports.ReportAccidents.rdlc";
				PaperSize paperSize;
				PaperSize paperSize2 = (from paperSize in source
				where (int)paperSize.Kind == 9
				select paperSize).FirstOrDefault<PaperSize>();
				printerSettings.DefaultPageSettings.PaperSize = paperSize2;
			}
			this.reportViewerRus_0.PrinterSettings = printerSettings;
			this.reportViewerRus_0.LocalReport.DataSources.Clear();
			Class171.Class196 dataSourceValue = new Class171.Class196();
			if (e.Result != null)
			{
				dataSourceValue = (Class171.Class196)e.Result;
			}
			List<ReportParameter> list = new List<ReportParameter>();
			string text = "";
			if (this.radioButton_1.Checked)
			{
				text = this.comboBox_0.SelectedItem.ToString() + " год";
			}
			else
			{
				text = text + this.dateTimePicker_1.Value.Date.ToString("dd.MM.yyyy") + " - " + this.dateTimePicker_0.Value.Date.ToString("dd.MM.yyyy");
			}
			list.Add(new ReportParameter("Period", text));
			this.reportViewerRus_0.LocalReport.SetParameters(list);
			Class602.smethod_2("Documents.Forms.DailyReport.SqlScripts.ReportAccidents.sql");
			this.reportViewerRus_0.LocalReport.DataSources.Add(new ReportDataSource("DataSet", dataSourceValue));
			this.toolStrip_0.Enabled = true;
			this.groupBox_0.Enabled = true;
			this.groupBox_1.Enabled = true;
			this.groupBox_2.Enabled = true;
			this.reportViewerRus_0.Enabled = true;
			this.progressBar_0.Visible = false;
			this.reportViewerRus_0.RefreshReport();
		}

		private void method_2()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormReportAccidents));
			this.splitContainer_0 = new SplitContainer();
			this.progressBar_0 = new ProgressBar();
			this.groupBox_1 = new GroupBox();
			this.checkBox_0 = new CheckBox();
			this.checkBox_1 = new CheckBox();
			this.groupBox_0 = new GroupBox();
			this.dateTimePicker_0 = new DateTimePicker();
			this.label_0 = new Label();
			this.dateTimePicker_1 = new DateTimePicker();
			this.label_1 = new Label();
			this.radioButton_0 = new RadioButton();
			this.comboBox_0 = new ComboBox();
			this.radioButton_1 = new RadioButton();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.backgroundWorker_0 = new BackgroundWorker();
			this.groupBox_2 = new GroupBox();
			this.radioButton_3 = new RadioButton();
			this.radioButton_2 = new RadioButton();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			this.groupBox_1.SuspendLayout();
			this.groupBox_0.SuspendLayout();
			this.toolStrip_0.SuspendLayout();
			this.groupBox_2.SuspendLayout();
			base.SuspendLayout();
			this.splitContainer_0.Dock = DockStyle.Fill;
			this.splitContainer_0.FixedPanel = FixedPanel.Panel1;
			this.splitContainer_0.Location = new Point(0, 0);
			this.splitContainer_0.Name = "splitContainerMain";
			this.splitContainer_0.Panel1.Controls.Add(this.groupBox_2);
			this.splitContainer_0.Panel1.Controls.Add(this.progressBar_0);
			this.splitContainer_0.Panel1.Controls.Add(this.groupBox_1);
			this.splitContainer_0.Panel1.Controls.Add(this.groupBox_0);
			this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_0);
			this.splitContainer_0.Size = new Size(829, 582);
			this.splitContainer_0.SplitterDistance = 257;
			this.splitContainer_0.TabIndex = 2;
			this.progressBar_0.Dock = DockStyle.Bottom;
			this.progressBar_0.Location = new Point(0, 559);
			this.progressBar_0.Name = "progressBar";
			this.progressBar_0.Size = new Size(257, 23);
			this.progressBar_0.Style = ProgressBarStyle.Marquee;
			this.progressBar_0.TabIndex = 3;
			this.progressBar_0.Visible = false;
			this.groupBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_1.Controls.Add(this.checkBox_0);
			this.groupBox_1.Controls.Add(this.checkBox_1);
			this.groupBox_1.Location = new Point(12, 211);
			this.groupBox_1.Name = "groupBoxTypeDoc";
			this.groupBox_1.Size = new Size(232, 67);
			this.groupBox_1.TabIndex = 2;
			this.groupBox_1.TabStop = false;
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.Checked = true;
			this.checkBox_0.CheckState = CheckState.Checked;
			this.checkBox_0.Location = new Point(6, 42);
			this.checkBox_0.Name = "chkFilterDefectHV";
			this.checkBox_0.Size = new Size(84, 17);
			this.checkBox_0.TabIndex = 1;
			this.checkBox_0.Text = "Дефект ВН";
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.checkBox_1.AutoSize = true;
			this.checkBox_1.Checked = true;
			this.checkBox_1.CheckState = CheckState.Checked;
			this.checkBox_1.Location = new Point(6, 19);
			this.checkBox_1.Name = "chkFilterActDetection";
			this.checkBox_1.Size = new Size(125, 17);
			this.checkBox_1.TabIndex = 0;
			this.checkBox_1.Text = "Акт расследования";
			this.checkBox_1.UseVisualStyleBackColor = true;
			this.groupBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_0.Controls.Add(this.dateTimePicker_0);
			this.groupBox_0.Controls.Add(this.label_0);
			this.groupBox_0.Controls.Add(this.dateTimePicker_1);
			this.groupBox_0.Controls.Add(this.label_1);
			this.groupBox_0.Controls.Add(this.radioButton_0);
			this.groupBox_0.Controls.Add(this.comboBox_0);
			this.groupBox_0.Controls.Add(this.radioButton_1);
			this.groupBox_0.Location = new Point(12, 28);
			this.groupBox_0.Name = "groupBoxDate";
			this.groupBox_0.Size = new Size(232, 177);
			this.groupBox_0.TabIndex = 1;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.Text = "Дата";
			this.dateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_0.Enabled = false;
			this.dateTimePicker_0.Location = new Point(6, 147);
			this.dateTimePicker_0.Name = "dtpFilterEnd";
			this.dateTimePicker_0.Size = new Size(220, 20);
			this.dateTimePicker_0.TabIndex = 6;
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(6, 131);
			this.label_0.Name = "label2";
			this.label_0.Size = new Size(38, 13);
			this.label_0.TabIndex = 5;
			this.label_0.Text = "Конец";
			this.dateTimePicker_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_1.Enabled = false;
			this.dateTimePicker_1.Location = new Point(6, 105);
			this.dateTimePicker_1.Name = "dtpFilterBeg";
			this.dateTimePicker_1.Size = new Size(220, 20);
			this.dateTimePicker_1.TabIndex = 4;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(6, 89);
			this.label_1.Name = "label1";
			this.label_1.Size = new Size(44, 13);
			this.label_1.TabIndex = 3;
			this.label_1.Text = "Начало";
			this.radioButton_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.radioButton_0.AutoSize = true;
			this.radioButton_0.Location = new Point(6, 69);
			this.radioButton_0.Name = "rbFilterPeriod";
			this.radioButton_0.Size = new Size(63, 17);
			this.radioButton_0.TabIndex = 2;
			this.radioButton_0.Text = "Период";
			this.radioButton_0.UseVisualStyleBackColor = true;
			this.radioButton_0.CheckedChanged += this.radioButton_0_CheckedChanged;
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(6, 42);
			this.comboBox_0.Name = "cmbFilterYear";
			this.comboBox_0.Size = new Size(220, 21);
			this.comboBox_0.TabIndex = 1;
			this.radioButton_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.radioButton_1.AutoSize = true;
			this.radioButton_1.Checked = true;
			this.radioButton_1.Location = new Point(6, 19);
			this.radioButton_1.Name = "rbFilterYear";
			this.radioButton_1.Size = new Size(43, 17);
			this.radioButton_1.TabIndex = 0;
			this.radioButton_1.TabStop = true;
			this.radioButton_1.Text = "Год";
			this.radioButton_1.UseVisualStyleBackColor = true;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripButton_1
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStripFilter";
			this.toolStrip_0.Size = new Size(257, 25);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = "Фильтр";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("toolBtnFilterApply.Image");
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnFilterApply";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Применить фильтр";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("toolBtnFilterDelete.Image");
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnFilterDelete";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Убрать фильтр";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
			this.backgroundWorker_0.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
			this.groupBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_2.Controls.Add(this.radioButton_2);
			this.groupBox_2.Controls.Add(this.radioButton_3);
			this.groupBox_2.Location = new Point(12, 284);
			this.groupBox_2.Name = "groupBoxFormatPaper";
			this.groupBox_2.Size = new Size(232, 67);
			this.groupBox_2.TabIndex = 4;
			this.groupBox_2.TabStop = false;
			this.radioButton_3.AutoSize = true;
			this.radioButton_3.Checked = true;
			this.radioButton_3.Location = new Point(6, 19);
			this.radioButton_3.Name = "rbA4";
			this.radioButton_3.Size = new Size(38, 17);
			this.radioButton_3.TabIndex = 0;
			this.radioButton_3.TabStop = true;
			this.radioButton_3.Text = "A4";
			this.radioButton_3.UseVisualStyleBackColor = true;
			this.radioButton_2.AutoSize = true;
			this.radioButton_2.Location = new Point(5, 42);
			this.radioButton_2.Name = "rbA3";
			this.radioButton_2.Size = new Size(38, 17);
			this.radioButton_2.TabIndex = 1;
			this.radioButton_2.Text = "A3";
			this.radioButton_2.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(829, 582);
			base.Controls.Add(this.splitContainer_0);
			base.Name = "FormReportAccidents";
			this.Text = "Перечень аварий";
			base.Load += this.FormReportAccidents_Load;
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.ResumeLayout(false);
			this.groupBox_1.ResumeLayout(false);
			this.groupBox_1.PerformLayout();
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.groupBox_2.ResumeLayout(false);
			this.groupBox_2.PerformLayout();
			base.ResumeLayout(false);
		}

		internal static void JU7yhgrpL2iVXpb41WFA(Form form_0, bool bool_0)
		{
			form_0.Dispose(bool_0);
		}

		private ReportViewerRus reportViewerRus_0;

		private SplitContainer splitContainer_0;

		private GroupBox groupBox_0;

		private DateTimePicker dateTimePicker_0;

		private Label label_0;

		private DateTimePicker dateTimePicker_1;

		private Label label_1;

		private RadioButton radioButton_0;

		private ComboBox comboBox_0;

		private RadioButton radioButton_1;

		private ToolStrip toolStrip_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private GroupBox groupBox_1;

		private CheckBox checkBox_0;

		private CheckBox checkBox_1;

		private BackgroundWorker backgroundWorker_0;

		private ProgressBar progressBar_0;

		private GroupBox groupBox_2;

		private RadioButton radioButton_2;

		private RadioButton radioButton_3;

		private class Class169
		{
			public Class169()
			{
				
				this.dateTime_0 = DateTime.Now;
				this.dateTime_1 = DateTime.Now;
				this.bool_0 = true;
				this.bool_1 = true;
				
			}

			internal DateTime dateTime_0;

			internal DateTime dateTime_1;

			internal bool bool_0;

			internal bool bool_1;
		}
	}
}
