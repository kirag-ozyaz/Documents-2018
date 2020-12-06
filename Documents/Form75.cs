using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using Documents.Properties;
using FormLbr;
using Microsoft.Office.Interop.Excel;

internal partial class Form75 : FormBase
{
	internal Form75()
	{
		
		this.string_0 = "";
		
		this.method_2();
	}

	private void Form75_Load(object sender, EventArgs e)
	{
		this.method_0();
		this.method_1(null);
	}

	private void method_0()
	{
		this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, 1, 1);
		this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year, 12, 31);
		System.Data.DataTable dataTable = new SqlDataCommand(this.SqlSettings).SelectSqlData("select year(dateDoc) as year\r\n                                                from tj_damage\r\n                                                group by year(dateDoc)\r\n                                                order by year(dateDoc) desc");
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
				goto IL_DE;
			}
		}
		this.comboBox_0.Items.Add(DateTime.Now.Year);
		IL_DE:
		this.comboBox_0.SelectedIndex = 0;
		foreach (object obj2 in this.comboBox_0.Items)
		{
			if (Convert.ToInt32(obj2) == DateTime.Now.Year)
			{
				this.comboBox_0.SelectedItem = obj2;
				break;
			}
		}
		this.radioButton_2.Checked = true;
	}

	private void radioButton_0_CheckedChanged(object sender, EventArgs e)
	{
		this.comboBox_0.Enabled = this.radioButton_1.Checked;
		this.dateTimePicker_1.Enabled = (this.dateTimePicker_0.Enabled = this.radioButton_0.Checked);
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		this.method_1(null);
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		this.method_0();
		this.method_1(null);
	}

	private void method_1(int? nullable_0 = null)
	{
		if (nullable_0 == null && this.dataGridViewExcelFilter_0.CurrentRow != null)
		{
			nullable_0 = new int?(Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value));
		}
		this.toolStrip_0.Enabled = false;
		this.toolStripProgressBar_0.Visible = true;
		this.splitContainer_0.Enabled = false;
		this.string_0 = this.bindingSource_0.Sort;
		this.bindingSource_0.Sort = string.Empty;
		this.bindingSource_0.DataMember = null;
		Form75.Class168 @class = new Form75.Class168();
		@class.nullable_0 = nullable_0;
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
		@class.bool_0 = this.radioButton_2.Checked;
		this.backgroundWorker_0.RunWorkerAsync(@class);
	}

	private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
	{
		try
		{
			this.class171_0.Report81.Clear();
			if (e.Argument != null && e.Argument is Form75.Class168)
			{
				Form75.Class168 @class = (Form75.Class168)e.Argument;
				using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString() + ";Connection Timeout=1000"))
				{
					sqlConnection.Open();
					using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
					{
						try
						{
							string text = Class602.smethod_2("Documents.Forms.DailyReport.SqlScripts.Report81Total.sql");
							if (@class.bool_0)
							{
								text += " and (d.is81 = 1 or d.is81 is null) ";
							}
							text += " order by d.datedoc desc";
							using (SqlCommand sqlCommand = new SqlCommand(text, sqlConnection))
							{
								sqlCommand.CommandTimeout = 0;
								sqlCommand.Transaction = sqlTransaction;
								sqlCommand.Parameters.Add("dateBeg", SqlDbType.DateTime).Value = @class.dateTime_0.Date;
								sqlCommand.Parameters.Add("dateEnd", SqlDbType.DateTime).Value = @class.dateTime_1.Date.AddDays(1.0);
								new SqlDataAdapter(sqlCommand).Fill(this.class171_0.Report81);
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
				e.Result = @class.nullable_0;
			}
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message, ex2.Source);
		}
	}

	private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		this.toolStrip_0.Enabled = true;
		this.toolStripProgressBar_0.Visible = false;
		this.splitContainer_0.Enabled = true;
		this.bindingSource_0.DataMember = this.class171_0.Report81.TableName;
		this.bindingSource_0.Sort = this.string_0;
		if (e.Result != null && Convert.ToInt32(e.Result) > 0)
		{
			this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_0.Name, e.Result.ToString(), true);
		}
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		this.dataGridViewExcelFilter_0.ExportToExcel();
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		try
		{
			Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
			try
			{
				application.SheetsInNewWorkbook = 1;
				CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
				Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
				Workbook workbook = application.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
				workbook.Title = "Title";
				Worksheet worksheet = (Worksheet)workbook.Worksheets[1];
				worksheet.Name = "SheetName";
				Thread.CurrentThread.CurrentCulture = currentCulture;
				worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[999999, 35]).Font.Size = 8;
				worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 35]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 35]).Font.Size = 12;
				worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 35]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				string text = "Журнал учета данных первичной информации по всем прекращениям передачи электрической энергии произошедших на объектах электросетевых организаций за ";
				if (this.radioButton_1.Checked)
				{
					text = text + this.comboBox_0.SelectedItem.ToString() + " год";
				}
				else
				{
					text = text + this.dateTimePicker_1.Value.Date.ToString("dd.MM.yyyy") + " - " + this.dateTimePicker_0.Value.Date.ToString("dd.MM.yyyy");
				}
				worksheet.Cells[1, 1] = text;
				worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, 35]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, 35]).Font.Size = 12;
				worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, 35]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				text = "ООО \"Компания\"";
				System.Data.DataTable dataTable = new System.Data.DataTable("vAbnType");
				dataTable.Columns.Add("Name", typeof(string));
				base.SelectSqlData(dataTable, true, "where typeKontragent = " + 1115.ToString(), null, false, 0);
				if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["Name"] != DBNull.Value)
				{
					text = dataTable.Rows[0]["Name"].ToString();
				}
				worksheet.Cells[2, 1] = text;
				worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, 1]).Rows.RowHeight = 67.5;
				worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, 1]).Rows.RowHeight = 38;
				worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[6, 1]).Rows.RowHeight = 36;
				worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[7, 1]).Rows.RowHeight = 193;
				worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 1]).Columns.ColumnWidth = 2.86;
				worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[7, 1]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[7, 1]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[7, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 1] = "№ п/п";
				worksheet.get_Range(worksheet.Cells[1, 2], worksheet.Cells[1, 2]).Columns.ColumnWidth = 4.43;
				worksheet.get_Range(worksheet.Cells[4, 2], worksheet.Cells[7, 2]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 2], worksheet.Cells[7, 2]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 2], worksheet.Cells[7, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 2] = "Наименование структурной единицы электросетевой сетевой организации";
				worksheet.get_Range(worksheet.Cells[1, 3], worksheet.Cells[1, 3]).Columns.ColumnWidth = 7;
				worksheet.get_Range(worksheet.Cells[4, 3], worksheet.Cells[7, 3]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 3], worksheet.Cells[7, 3]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 3], worksheet.Cells[7, 3]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 3], worksheet.Cells[7, 3]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 3] = "Диспетчерское наименование ПС или ЛЭП, в результате отключения которой произошло прекращение передачи электроэнергии потребителям услуг";
				worksheet.get_Range(worksheet.Cells[1, 4], worksheet.Cells[1, 4]).Columns.ColumnWidth = 3.29;
				worksheet.get_Range(worksheet.Cells[4, 4], worksheet.Cells[7, 4]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 4], worksheet.Cells[7, 4]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 4], worksheet.Cells[7, 4]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 4], worksheet.Cells[7, 4]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 4] = "Вид объекта (ПС, ЛЭП)";
				worksheet.get_Range(worksheet.Cells[1, 5], worksheet.Cells[1, 5]).Columns.ColumnWidth = 3.29;
				worksheet.get_Range(worksheet.Cells[4, 5], worksheet.Cells[7, 5]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 5], worksheet.Cells[7, 5]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 5], worksheet.Cells[7, 5]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 5], worksheet.Cells[7, 5]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 5] = "Высший класс напряжения обесточенного оборудования, кВ";
				worksheet.get_Range(worksheet.Cells[1, 6], worksheet.Cells[1, 6]).Columns.ColumnWidth = 7;
				worksheet.get_Range(worksheet.Cells[4, 6], worksheet.Cells[7, 6]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 6], worksheet.Cells[7, 6]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 6], worksheet.Cells[7, 6]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 6], worksheet.Cells[7, 6]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 6] = "Причина прекращения передачи электрической энергии (1/0)";
				worksheet.get_Range(worksheet.Cells[1, 7], worksheet.Cells[1, 7]).Columns.ColumnWidth = 3.29;
				worksheet.get_Range(worksheet.Cells[4, 7], worksheet.Cells[7, 7]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 7], worksheet.Cells[7, 7]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 7], worksheet.Cells[7, 7]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 7], worksheet.Cells[7, 7]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 7] = "Признак АПВ (1/0)";
				worksheet.get_Range(worksheet.Cells[1, 8], worksheet.Cells[1, 8]).Columns.ColumnWidth = 3.29;
				worksheet.get_Range(worksheet.Cells[4, 8], worksheet.Cells[7, 8]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 8], worksheet.Cells[7, 8]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 8], worksheet.Cells[7, 8]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 8], worksheet.Cells[7, 8]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 8] = "Признак АВР (1/0)";
				worksheet.get_Range(worksheet.Cells[4, 9], worksheet.Cells[4, 16]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 9], worksheet.Cells[4, 16]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 9], worksheet.Cells[4, 16]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.get_Range(worksheet.Cells[4, 9], worksheet.Cells[4, 16]).VerticalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 9] = "Количество точек поставки, по которым произошло прекращение передачи электрической энергии. шт";
				worksheet.get_Range(worksheet.Cells[5, 9], worksheet.Cells[5, 13]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[5, 9], worksheet.Cells[5, 13]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[5, 9], worksheet.Cells[5, 13]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.get_Range(worksheet.Cells[5, 9], worksheet.Cells[5, 13]).VerticalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[5, 9] = "Потребители электрической энергии";
				worksheet.get_Range(worksheet.Cells[6, 9], worksheet.Cells[6, 10]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[6, 9], worksheet.Cells[6, 10]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[6, 9], worksheet.Cells[6, 10]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.get_Range(worksheet.Cells[6, 9], worksheet.Cells[6, 10]).VerticalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[6, 9] = "1 категории надежности";
				worksheet.get_Range(worksheet.Cells[6, 11], worksheet.Cells[6, 12]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[6, 11], worksheet.Cells[6, 12]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[6, 11], worksheet.Cells[6, 12]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.get_Range(worksheet.Cells[6, 11], worksheet.Cells[6, 12]).VerticalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[6, 11] = "2 категории надежности";
				worksheet.get_Range(worksheet.Cells[1, 9], worksheet.Cells[1, 9]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[7, 9], worksheet.Cells[7, 9]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[7, 9], worksheet.Cells[7, 9]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[7, 9], worksheet.Cells[7, 9]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[7, 9] = "Полное";
				worksheet.get_Range(worksheet.Cells[1, 10], worksheet.Cells[1, 10]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[7, 10], worksheet.Cells[7, 10]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[7, 10], worksheet.Cells[7, 10]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[7, 10], worksheet.Cells[7, 10]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[7, 10] = "Частичное";
				worksheet.get_Range(worksheet.Cells[1, 11], worksheet.Cells[1, 11]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[7, 11], worksheet.Cells[7, 11]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[7, 11], worksheet.Cells[7, 11]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[7, 11], worksheet.Cells[7, 11]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[7, 11] = "Полное";
				worksheet.get_Range(worksheet.Cells[1, 12], worksheet.Cells[1, 12]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[7, 12], worksheet.Cells[7, 12]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[7, 12], worksheet.Cells[7, 12]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[7, 12], worksheet.Cells[7, 12]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[7, 12] = "Частичное";
				worksheet.get_Range(worksheet.Cells[1, 13], worksheet.Cells[1, 13]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[6, 13], worksheet.Cells[7, 13]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[6, 13], worksheet.Cells[7, 13]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[6, 13], worksheet.Cells[7, 13]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[6, 13], worksheet.Cells[7, 13]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[6, 13] = "3 категории надежности";
				worksheet.get_Range(worksheet.Cells[1, 14], worksheet.Cells[1, 14]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[5, 14], worksheet.Cells[7, 14]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[5, 14], worksheet.Cells[7, 14]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[5, 14], worksheet.Cells[7, 14]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[5, 14], worksheet.Cells[7, 14]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[5, 14] = "Электросетевые организации";
				worksheet.get_Range(worksheet.Cells[1, 15], worksheet.Cells[1, 15]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[5, 15], worksheet.Cells[7, 15]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[5, 15], worksheet.Cells[7, 15]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[5, 15], worksheet.Cells[7, 15]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[5, 15], worksheet.Cells[7, 15]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[5, 15] = "Производители электрической энергии";
				worksheet.get_Range(worksheet.Cells[1, 16], worksheet.Cells[1, 16]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[5, 16], worksheet.Cells[7, 16]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[5, 16], worksheet.Cells[7, 16]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[5, 16], worksheet.Cells[7, 16]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[5, 16], worksheet.Cells[7, 16]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[5, 16] = "Всего (сумма граф 9-15)";
				worksheet.get_Range(worksheet.Cells[4, 17], worksheet.Cells[4, 28]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 17], worksheet.Cells[4, 28]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 17], worksheet.Cells[4, 28]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.get_Range(worksheet.Cells[4, 17], worksheet.Cells[4, 28]).VerticalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 17] = "Количество потребителей услуг (производители электрической энергии) в отношении которых произошло прекращение передачи электрической энергии, шт.";
				worksheet.get_Range(worksheet.Cells[5, 17], worksheet.Cells[5, 25]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[5, 17], worksheet.Cells[5, 25]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[5, 17], worksheet.Cells[5, 25]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.get_Range(worksheet.Cells[5, 17], worksheet.Cells[5, 25]).VerticalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[5, 17] = "Потребители электрической энергии";
				worksheet.get_Range(worksheet.Cells[6, 17], worksheet.Cells[6, 18]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[6, 17], worksheet.Cells[6, 18]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[6, 17], worksheet.Cells[6, 18]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.get_Range(worksheet.Cells[6, 17], worksheet.Cells[6, 18]).VerticalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[6, 17] = "1 категории надежности";
				worksheet.get_Range(worksheet.Cells[6, 19], worksheet.Cells[6, 20]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[6, 19], worksheet.Cells[6, 20]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[6, 19], worksheet.Cells[6, 20]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.get_Range(worksheet.Cells[6, 19], worksheet.Cells[6, 20]).VerticalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[6, 19] = "2 категории надежности";
				worksheet.get_Range(worksheet.Cells[1, 17], worksheet.Cells[1, 17]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[7, 17], worksheet.Cells[7, 17]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[7, 17], worksheet.Cells[7, 17]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[7, 17], worksheet.Cells[7, 17]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[7, 17] = "Полное";
				worksheet.get_Range(worksheet.Cells[1, 18], worksheet.Cells[1, 18]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[7, 18], worksheet.Cells[7, 18]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[7, 18], worksheet.Cells[7, 18]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[7, 18], worksheet.Cells[7, 18]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[7, 18] = "Частичное";
				worksheet.get_Range(worksheet.Cells[1, 19], worksheet.Cells[1, 19]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[7, 19], worksheet.Cells[7, 19]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[7, 19], worksheet.Cells[7, 19]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[7, 19], worksheet.Cells[7, 19]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[7, 19] = "Полное";
				worksheet.get_Range(worksheet.Cells[1, 20], worksheet.Cells[1, 20]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[7, 20], worksheet.Cells[7, 20]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[7, 20], worksheet.Cells[7, 20]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[7, 20], worksheet.Cells[7, 20]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[7, 20] = "Частичное";
				worksheet.get_Range(worksheet.Cells[1, 21], worksheet.Cells[1, 21]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[6, 21], worksheet.Cells[7, 21]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[6, 21], worksheet.Cells[7, 21]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[6, 21], worksheet.Cells[7, 21]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[6, 21], worksheet.Cells[7, 21]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[6, 21] = "3 категории надежности";
				worksheet.get_Range(worksheet.Cells[1, 22], worksheet.Cells[1, 22]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[6, 22], worksheet.Cells[7, 22]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[6, 22], worksheet.Cells[7, 22]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[6, 22], worksheet.Cells[7, 22]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[6, 22], worksheet.Cells[7, 22]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[6, 22] = "С максимальной мощностью до 150 кВт";
				worksheet.get_Range(worksheet.Cells[1, 23], worksheet.Cells[1, 23]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[6, 23], worksheet.Cells[7, 23]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[6, 23], worksheet.Cells[7, 23]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[6, 23], worksheet.Cells[7, 23]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[6, 23], worksheet.Cells[7, 23]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[6, 23] = "С максимальной мощностью от 150 до 670 кВт";
				worksheet.get_Range(worksheet.Cells[1, 24], worksheet.Cells[1, 24]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[6, 24], worksheet.Cells[7, 24]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[6, 24], worksheet.Cells[7, 24]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[6, 24], worksheet.Cells[7, 24]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[6, 24], worksheet.Cells[7, 24]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[6, 24] = "С максимальной мощностью свыше 670 кВт";
				worksheet.get_Range(worksheet.Cells[1, 25], worksheet.Cells[1, 25]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[6, 25], worksheet.Cells[7, 25]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[6, 25], worksheet.Cells[7, 25]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[6, 25], worksheet.Cells[7, 25]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[6, 25], worksheet.Cells[7, 25]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[6, 25] = "Всего (сумма граф 17-21)";
				worksheet.get_Range(worksheet.Cells[1, 26], worksheet.Cells[1, 26]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[5, 26], worksheet.Cells[7, 26]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[5, 26], worksheet.Cells[7, 26]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[5, 26], worksheet.Cells[7, 26]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[5, 26], worksheet.Cells[7, 26]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[5, 26] = "Электросетевые организации";
				worksheet.get_Range(worksheet.Cells[1, 27], worksheet.Cells[1, 27]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[5, 27], worksheet.Cells[7, 27]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[5, 27], worksheet.Cells[7, 27]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[5, 27], worksheet.Cells[7, 27]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[5, 27], worksheet.Cells[7, 27]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[5, 27] = "Производители электрической энергии";
				worksheet.get_Range(worksheet.Cells[1, 28], worksheet.Cells[1, 28]).Columns.ColumnWidth = 5.57;
				worksheet.get_Range(worksheet.Cells[5, 28], worksheet.Cells[7, 28]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[5, 28], worksheet.Cells[7, 28]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[5, 28], worksheet.Cells[7, 28]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[5, 28], worksheet.Cells[7, 28]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[5, 28] = "Всего (сумма граф 25-27)";
				worksheet.get_Range(worksheet.Cells[1, 29], worksheet.Cells[1, 29]).Columns.ColumnWidth = 6.43;
				worksheet.get_Range(worksheet.Cells[4, 29], worksheet.Cells[7, 29]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 29], worksheet.Cells[7, 29]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 29], worksheet.Cells[7, 29]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 29], worksheet.Cells[7, 29]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 29] = "Время и дата прекращения передачи электрической энергии (часы, минуты, ГГГГ.ММ.ДД)";
				worksheet.get_Range(worksheet.Cells[1, 30], worksheet.Cells[1, 30]).Columns.ColumnWidth = 6.43;
				worksheet.get_Range(worksheet.Cells[4, 30], worksheet.Cells[7, 30]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 30], worksheet.Cells[7, 30]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 30], worksheet.Cells[7, 30]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 30], worksheet.Cells[7, 30]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 30] = "Время и дата устранения технологического нарушения на объектах данной сетевой организации (часы, минуты, ГГГГ.ММ.ДД)";
				worksheet.get_Range(worksheet.Cells[1, 31], worksheet.Cells[1, 31]).Columns.ColumnWidth = 6.43;
				worksheet.get_Range(worksheet.Cells[4, 31], worksheet.Cells[7, 31]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 31], worksheet.Cells[7, 31]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 31], worksheet.Cells[7, 31]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 31], worksheet.Cells[7, 31]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 31] = "Время и дата восстановления режима потребления электрической энергии потребителей услуг (часы, минуты, ГГГГ.ММ.ДД)";
				worksheet.get_Range(worksheet.Cells[1, 32], worksheet.Cells[1, 32]).Columns.ColumnWidth = 4.71;
				worksheet.get_Range(worksheet.Cells[4, 32], worksheet.Cells[7, 32]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 32], worksheet.Cells[7, 32]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 32], worksheet.Cells[7, 32]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 32], worksheet.Cells[7, 32]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 32] = "Продолжительность прекращения передачи электрической энергии, час";
				worksheet.get_Range(worksheet.Cells[1, 33], worksheet.Cells[1, 33]).Columns.ColumnWidth = 6.71;
				worksheet.get_Range(worksheet.Cells[4, 33], worksheet.Cells[7, 33]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 33], worksheet.Cells[7, 33]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 33], worksheet.Cells[7, 33]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 33], worksheet.Cells[7, 33]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 33] = "Суммарный объем фактической нагрузки (мощности) на присоединениях потребителей услуг по которым в результате технологического нарушения произошло прекращение передачи электрической энергии на момент возникновения такого события, МВТ";
				worksheet.get_Range(worksheet.Cells[1, 34], worksheet.Cells[1, 34]).Columns.ColumnWidth = 6.29;
				worksheet.get_Range(worksheet.Cells[4, 34], worksheet.Cells[7, 34]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 34], worksheet.Cells[7, 34]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 34], worksheet.Cells[7, 34]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 34], worksheet.Cells[7, 34]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 34] = "Наименование документа первичной информации (акт расследования, журнал отключений и т.п.)";
				worksheet.get_Range(worksheet.Cells[1, 35], worksheet.Cells[1, 35]).Columns.ColumnWidth = 6.29;
				worksheet.get_Range(worksheet.Cells[4, 35], worksheet.Cells[7, 35]).Merge(Type.Missing);
				worksheet.get_Range(worksheet.Cells[4, 35], worksheet.Cells[7, 35]).Orientation = 90;
				worksheet.get_Range(worksheet.Cells[4, 35], worksheet.Cells[7, 35]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 35], worksheet.Cells[7, 35]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
				worksheet.Cells[4, 35] = "Реквизиты документа первичной информации (акты расследования технологического нарушения (аварии) или иног документа (номер и дата записи в журнале отключений)";
				for (int i = 1; i <= 35; i++)
				{
					worksheet.get_Range(worksheet.Cells[8, i], worksheet.Cells[8, i]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
					worksheet.Cells[8, i] = i.ToString();
				}
				this.class171_0.Report81.DefaultView.RowFilter = this.bindingSource_0.Filter;
				System.Data.DataTable dataTable2 = this.class171_0.Report81.DefaultView.ToTable();
				int num = 9;
				foreach (object obj in dataTable2.Rows)
				{
					DataRow dataRow = (DataRow)obj;
					worksheet.Cells[num, 1] = (num - 8).ToString();
					worksheet.Cells[num, 2] = dataRow["netRegionValue"].ToString();
					worksheet.Cells[num, 3] = dataRow["subName"].ToString();
					worksheet.Cells[num, 4] = dataRow["TypeSchmObj"].ToString();
					worksheet.Cells[num, 5] = dataRow["PowerV"].ToString();
					worksheet.Cells[num, 6] = 1;
					int num2 = 7;
					if (dataRow["APV"] != DBNull.Value && Convert.ToBoolean(dataRow["APV"]))
					{
						worksheet.Cells[num, num2] = 1;
					}
					else
					{
						worksheet.Cells[num, num2] = 0;
					}
					num2++;
					if (dataRow["AVR"] != DBNull.Value && Convert.ToBoolean(dataRow["AVR"]))
					{
						worksheet.Cells[num, num2] = 1;
					}
					else
					{
						worksheet.Cells[num, num2] = 0;
					}
					num2++;
					worksheet.Cells[num, num2] = dataRow["countPointCat1Full"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["countPointCat1"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["countPointCat2Full"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["countPointCat2"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["countPointCat3"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["countPointEE"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["countPointSource"].ToString();
					int num3 = 0;
					if (dataRow["countPointCat1Full"] != DBNull.Value)
					{
						num3 += (int)dataRow["countPointCat1Full"];
					}
					if (dataRow["countPointCat1"] != DBNull.Value)
					{
						num3 += (int)dataRow["countPointCat1"];
					}
					if (dataRow["countPointCat2Full"] != DBNull.Value)
					{
						num3 += (int)dataRow["countPointCat2Full"];
					}
					if (dataRow["countPointCat2"] != DBNull.Value)
					{
						num3 += (int)dataRow["countPointCat2"];
					}
					if (dataRow["countPointCat3"] != DBNull.Value)
					{
						num3 += (int)dataRow["countPointCat3"];
					}
					if (dataRow["countPointee"] != DBNull.Value)
					{
						num3 += (int)dataRow["countPointee"];
					}
					if (dataRow["countPointsource"] != DBNull.Value)
					{
						num3 += (int)dataRow["countPointsource"];
					}
					num2++;
					worksheet.Cells[num, num2] = num3;
					num2++;
					worksheet.Cells[num, num2] = dataRow["countAbnObjCat1Full"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["countAbnObjCat1"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["countAbnObjCat2Full"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["countAbnObjCat2"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["countAbnObjCat3"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["countAbnObj150"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["countAbnObj150670"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["countAbnObj670"].ToString();
					num3 = 0;
					if (dataRow["countAbnObjCat1Full"] != DBNull.Value)
					{
						num3 += (int)dataRow["countAbnObjCat1Full"];
					}
					if (dataRow["countAbnObjCat1"] != DBNull.Value)
					{
						num3 += (int)dataRow["countAbnObjCat1"];
					}
					if (dataRow["countAbnObjCat2Full"] != DBNull.Value)
					{
						num3 += (int)dataRow["countAbnObjCat2Full"];
					}
					if (dataRow["countAbnObjCat2"] != DBNull.Value)
					{
						num3 += (int)dataRow["countAbnObjCat2"];
					}
					if (dataRow["countAbnObjCat3"] != DBNull.Value)
					{
						num3 += (int)dataRow["countAbnObjCat3"];
					}
					num2++;
					worksheet.Cells[num, num2] = num3;
					num2++;
					worksheet.Cells[num, num2] = dataRow["countAbnObjEE"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["countAbnObjSource"].ToString();
					if (dataRow["countAbnObjee"] != DBNull.Value)
					{
						num3 += (int)dataRow["countAbnObjee"];
					}
					if (dataRow["countAbnObjsource"] != DBNull.Value)
					{
						num3 += (int)dataRow["countAbnObjsource"];
					}
					num2++;
					worksheet.Cells[num, num2] = num3;
					num2++;
					worksheet.get_Range(worksheet.Cells[num, num2], worksheet.Cells[num, num2]).NumberFormat = "@";
					if (dataRow["dateBegin"] != DBNull.Value)
					{
						worksheet.Cells[num, num2] = Convert.ToDateTime(dataRow["dateBegin"]).ToString("HH:mm dd.MM.yy");
					}
					num2++;
					worksheet.get_Range(worksheet.Cells[num, num2], worksheet.Cells[num, num2]).NumberFormat = "@";
					if (dataRow["dateApply"] != DBNull.Value)
					{
						worksheet.Cells[num, num2] = Convert.ToDateTime(dataRow["dateApply"]).ToString("HH:mm dd.MM.yy");
					}
					num2++;
					worksheet.get_Range(worksheet.Cells[num, num2], worksheet.Cells[num, num2]).NumberFormat = "@";
					if (dataRow["dateApplyMax"] != DBNull.Value)
					{
						worksheet.Cells[num, num2] = Convert.ToDateTime(dataRow["dateApplyMax"]).ToString("HH:mm dd.MM.yy");
					}
					num2++;
					worksheet.get_Range(worksheet.Cells[num, num2], worksheet.Cells[num, num2]).NumberFormat = "@";
					if (dataRow["dateApplyMax"] != DBNull.Value && dataRow["dateBegin"] != DBNull.Value)
					{
						TimeSpan t = Convert.ToDateTime(dataRow["dateApplyMax"]).AddSeconds((double)(-(double)Convert.ToDateTime(dataRow["dateApplyMax"]).Second)) - Convert.ToDateTime(dataRow["datebegin"]).AddSeconds((double)(-(double)Convert.ToDateTime(dataRow["datebegin"]).Second));
						text = ((int)t.TotalHours).ToString() + ":" + ((int)(t - TimeSpan.FromHours((double)((int)t.TotalHours))).TotalMinutes).ToString();
						worksheet.Cells[num, num2] = text;
					}
					num2++;
					num2++;
					worksheet.Cells[num, num2] = dataRow["TypeDoc"].ToString();
					num2++;
					worksheet.Cells[num, num2] = dataRow["numDateDoc"].ToString();
					num++;
				}
				worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num - 1, 35]).Font.Size = 10;
				worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num - 1, 35]).WrapText = true;
				worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num - 1, 35]).Borders.LineStyle = XlLineStyle.xlContinuous;
				application.Visible = true;
			}
			catch (Exception ex)
			{
				application.Quit();
				throw ex;
			}
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message, ex2.Source);
		}
	}

	private void method_2()
	{
		this.icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form75));
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripProgressBar_0 = new ToolStripProgressBar();
		this.toolStripButton_2 = new ToolStripButton();
		this.splitContainer_0 = new SplitContainer();
		this.groupBox_1 = new System.Windows.Forms.GroupBox();
		this.radioButton_2 = new RadioButton();
		this.radioButton_3 = new RadioButton();
		this.groupBox_0 = new System.Windows.Forms.GroupBox();
		this.dateTimePicker_0 = new DateTimePicker();
		this.label_0 = new System.Windows.Forms.Label();
		this.dateTimePicker_1 = new DateTimePicker();
		this.label_1 = new System.Windows.Forms.Label();
		this.radioButton_0 = new RadioButton();
		this.comboBox_0 = new ComboBox();
		this.radioButton_1 = new RadioButton();
		this.toolStrip_1 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripButton_1 = new ToolStripButton();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_4 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_5 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_6 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_7 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_8 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterCheckBoxColumn_1 = new DataGridViewFilterCheckBoxColumn();
		this.dataGridViewFilterTextBoxColumn_9 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_10 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_11 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_12 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_13 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_14 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_15 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_16 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_17 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_18 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_19 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_20 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_21 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_22 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_23 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_24 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_25 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_26 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_27 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_28 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class171_0 = new Class171();
		this.backgroundWorker_0 = new BackgroundWorker();
		this.toolStripButton_3 = new ToolStripButton();
		this.toolStrip_0.SuspendLayout();
		this.splitContainer_0.Panel1.SuspendLayout();
		this.splitContainer_0.Panel2.SuspendLayout();
		this.splitContainer_0.SuspendLayout();
		this.groupBox_1.SuspendLayout();
		this.groupBox_0.SuspendLayout();
		this.toolStrip_1.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class171_0).BeginInit();
		base.SuspendLayout();
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripProgressBar_0,
			this.toolStripButton_2,
			this.toolStripButton_3
		});
		this.toolStrip_0.Location = new System.Drawing.Point(0, 0);
		this.toolStrip_0.Name = "toolStripMain";
		this.toolStrip_0.Size = new Size(1135, 25);
		this.toolStrip_0.TabIndex = 0;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripProgressBar_0.Alignment = ToolStripItemAlignment.Right;
		this.toolStripProgressBar_0.Name = "progressBar";
		this.toolStripProgressBar_0.Size = new Size(100, 22);
		this.toolStripProgressBar_0.Style = ProgressBarStyle.Marquee;
		this.toolStripProgressBar_0.ToolTipText = "Загрузка данных";
		this.toolStripProgressBar_0.Visible = false;
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Image = (Image)componentResourceManager.GetObject("toolBtnExcel.Image");
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "toolBtnExcel";
		this.toolStripButton_2.Size = new Size(23, 22);
		this.toolStripButton_2.Text = "Экспорт в Excel";
		this.toolStripButton_2.Click += this.toolStripButton_2_Click;
		this.splitContainer_0.Dock = DockStyle.Fill;
		this.splitContainer_0.FixedPanel = FixedPanel.Panel1;
		this.splitContainer_0.Location = new System.Drawing.Point(0, 25);
		this.splitContainer_0.Name = "splitContainerMain";
		this.splitContainer_0.Panel1.Controls.Add(this.groupBox_1);
		this.splitContainer_0.Panel1.Controls.Add(this.groupBox_0);
		this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_1);
		this.splitContainer_0.Panel2.Controls.Add(this.dataGridViewExcelFilter_0);
		this.splitContainer_0.Size = new Size(1135, 690);
		this.splitContainer_0.SplitterDistance = 257;
		this.splitContainer_0.TabIndex = 1;
		this.groupBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_1.Controls.Add(this.radioButton_2);
		this.groupBox_1.Controls.Add(this.radioButton_3);
		this.groupBox_1.Location = new System.Drawing.Point(12, 211);
		this.groupBox_1.Name = "groupBoxIs81";
		this.groupBox_1.Size = new Size(232, 72);
		this.groupBox_1.TabIndex = 2;
		this.groupBox_1.TabStop = false;
		this.radioButton_2.AutoSize = true;
		this.radioButton_2.Checked = true;
		this.radioButton_2.Location = new System.Drawing.Point(9, 42);
		this.radioButton_2.Name = "rbFilterIs81";
		this.radioButton_2.Size = new Size(80, 17);
		this.radioButton_2.TabIndex = 1;
		this.radioButton_2.TabStop = true;
		this.radioButton_2.Text = "Только 8.1";
		this.radioButton_2.UseVisualStyleBackColor = true;
		this.radioButton_3.AutoSize = true;
		this.radioButton_3.Location = new System.Drawing.Point(9, 19);
		this.radioButton_3.Name = "rbFilterAll81";
		this.radioButton_3.Size = new Size(115, 17);
		this.radioButton_3.TabIndex = 0;
		this.radioButton_3.Text = "Все повреждения";
		this.radioButton_3.UseVisualStyleBackColor = true;
		this.groupBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_0.Controls.Add(this.dateTimePicker_0);
		this.groupBox_0.Controls.Add(this.label_0);
		this.groupBox_0.Controls.Add(this.dateTimePicker_1);
		this.groupBox_0.Controls.Add(this.label_1);
		this.groupBox_0.Controls.Add(this.radioButton_0);
		this.groupBox_0.Controls.Add(this.comboBox_0);
		this.groupBox_0.Controls.Add(this.radioButton_1);
		this.groupBox_0.Location = new System.Drawing.Point(12, 28);
		this.groupBox_0.Name = "groupBoxDate";
		this.groupBox_0.Size = new Size(232, 177);
		this.groupBox_0.TabIndex = 1;
		this.groupBox_0.TabStop = false;
		this.groupBox_0.Text = "Дата";
		this.dateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.dateTimePicker_0.Enabled = false;
		this.dateTimePicker_0.Location = new System.Drawing.Point(6, 147);
		this.dateTimePicker_0.Name = "dtpFilterEnd";
		this.dateTimePicker_0.Size = new Size(220, 20);
		this.dateTimePicker_0.TabIndex = 6;
		this.label_0.AutoSize = true;
		this.label_0.Location = new System.Drawing.Point(6, 131);
		this.label_0.Name = "label2";
		this.label_0.Size = new Size(38, 13);
		this.label_0.TabIndex = 5;
		this.label_0.Text = "Конец";
		this.dateTimePicker_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.dateTimePicker_1.Enabled = false;
		this.dateTimePicker_1.Location = new System.Drawing.Point(6, 105);
		this.dateTimePicker_1.Name = "dtpFilterBeg";
		this.dateTimePicker_1.Size = new Size(220, 20);
		this.dateTimePicker_1.TabIndex = 4;
		this.label_1.AutoSize = true;
		this.label_1.Location = new System.Drawing.Point(6, 89);
		this.label_1.Name = "label1";
		this.label_1.Size = new Size(44, 13);
		this.label_1.TabIndex = 3;
		this.label_1.Text = "Начало";
		this.radioButton_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.radioButton_0.AutoSize = true;
		this.radioButton_0.Location = new System.Drawing.Point(6, 69);
		this.radioButton_0.Name = "rbFilterPeriod";
		this.radioButton_0.Size = new Size(63, 17);
		this.radioButton_0.TabIndex = 2;
		this.radioButton_0.Text = "Период";
		this.radioButton_0.UseVisualStyleBackColor = true;
		this.radioButton_0.CheckedChanged += this.radioButton_0_CheckedChanged;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new System.Drawing.Point(6, 42);
		this.comboBox_0.Name = "cmbFilterYear";
		this.comboBox_0.Size = new Size(220, 21);
		this.comboBox_0.TabIndex = 1;
		this.radioButton_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.radioButton_1.AutoSize = true;
		this.radioButton_1.Checked = true;
		this.radioButton_1.Location = new System.Drawing.Point(6, 19);
		this.radioButton_1.Name = "rbFilterYear";
		this.radioButton_1.Size = new Size(43, 17);
		this.radioButton_1.TabIndex = 0;
		this.radioButton_1.TabStop = true;
		this.radioButton_1.Text = "Год";
		this.radioButton_1.UseVisualStyleBackColor = true;
		this.toolStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripButton_1
		});
		this.toolStrip_1.Location = new System.Drawing.Point(0, 0);
		this.toolStrip_1.Name = "toolStripFilter";
		this.toolStrip_1.Size = new Size(257, 25);
		this.toolStrip_1.TabIndex = 0;
		this.toolStrip_1.Text = "Фильтр";
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
		this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewFilterTextBoxColumn_0,
			this.dataGridViewFilterTextBoxColumn_1,
			this.dataGridViewFilterTextBoxColumn_2,
			this.dataGridViewFilterTextBoxColumn_3,
			this.dataGridViewFilterTextBoxColumn_4,
			this.dataGridViewFilterTextBoxColumn_5,
			this.dataGridViewFilterTextBoxColumn_6,
			this.dataGridViewFilterTextBoxColumn_7,
			this.dataGridViewFilterTextBoxColumn_8,
			this.dataGridViewFilterCheckBoxColumn_1,
			this.dataGridViewFilterTextBoxColumn_9,
			this.dataGridViewFilterTextBoxColumn_10,
			this.dataGridViewFilterTextBoxColumn_11,
			this.dataGridViewFilterTextBoxColumn_12,
			this.dataGridViewFilterTextBoxColumn_13,
			this.dataGridViewFilterTextBoxColumn_14,
			this.dataGridViewFilterTextBoxColumn_15,
			this.dataGridViewFilterTextBoxColumn_16,
			this.dataGridViewFilterTextBoxColumn_17,
			this.dataGridViewFilterTextBoxColumn_18,
			this.dataGridViewFilterTextBoxColumn_19,
			this.dataGridViewFilterTextBoxColumn_20,
			this.dataGridViewFilterTextBoxColumn_21,
			this.dataGridViewFilterTextBoxColumn_22,
			this.dataGridViewFilterTextBoxColumn_23,
			this.dataGridViewFilterTextBoxColumn_24,
			this.dataGridViewFilterTextBoxColumn_25,
			this.dataGridViewFilterTextBoxColumn_26,
			this.dataGridViewFilterTextBoxColumn_27,
			this.dataGridViewFilterTextBoxColumn_28,
			this.dataGridViewTextBoxColumn_0
		});
		this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
		this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_0.Location = new System.Drawing.Point(0, 0);
		this.dataGridViewExcelFilter_0.Name = "dgvReport";
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.RowHeadersWidth = 21;
		this.dataGridViewExcelFilter_0.Size = new Size(874, 690);
		this.dataGridViewExcelFilter_0.TabIndex = 0;
		this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "numDateDoc";
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		this.dataGridViewFilterTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle;
		this.dataGridViewFilterTextBoxColumn_0.HeaderText = "№ и дата";
		this.dataGridViewFilterTextBoxColumn_0.Name = "numDateDocDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "TypeDoc";
		this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Тип документа";
		this.dataGridViewFilterTextBoxColumn_1.Name = "typeDocDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_1.Width = 80;
		this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "SRName";
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		this.dataGridViewFilterTextBoxColumn_2.DefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Сетевой район";
		this.dataGridViewFilterTextBoxColumn_2.Name = "sRNameDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_2.Visible = false;
		this.dataGridViewFilterTextBoxColumn_3.DataPropertyName = "netRegionValue";
		this.dataGridViewFilterTextBoxColumn_3.HeaderText = "Сет. р-н";
		this.dataGridViewFilterTextBoxColumn_3.Name = "netRegionValueDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_3.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_3.Width = 60;
		this.dataGridViewFilterTextBoxColumn_4.DataPropertyName = "schmObjName";
		this.dataGridViewFilterTextBoxColumn_4.HeaderText = "Объект схемы";
		this.dataGridViewFilterTextBoxColumn_4.Name = "schmObjNameDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_4.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_4.Visible = false;
		this.dataGridViewFilterTextBoxColumn_5.DataPropertyName = "subName";
		this.dataGridViewFilterTextBoxColumn_5.HeaderText = "ТП";
		this.dataGridViewFilterTextBoxColumn_5.Name = "subNameDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_5.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_5.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_5.Width = 80;
		this.dataGridViewFilterTextBoxColumn_6.DataPropertyName = "TypeSchmObj";
		this.dataGridViewFilterTextBoxColumn_6.HeaderText = "Вид объекта";
		this.dataGridViewFilterTextBoxColumn_6.Name = "typeSchmObjDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_6.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_6.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_6.Width = 60;
		this.dataGridViewFilterTextBoxColumn_7.DataPropertyName = "PowerV";
		this.dataGridViewFilterTextBoxColumn_7.HeaderText = "Напр-е";
		this.dataGridViewFilterTextBoxColumn_7.Name = "powerVDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_7.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_7.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_7.Width = 60;
		this.dataGridViewFilterTextBoxColumn_8.DataPropertyName = "Reason";
		this.dataGridViewFilterTextBoxColumn_8.HeaderText = "Причина";
		this.dataGridViewFilterTextBoxColumn_8.Name = "reasonDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_8.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_8.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_8.Width = 70;
		this.dataGridViewFilterCheckBoxColumn_1.DataPropertyName = "APV";
		this.dataGridViewFilterCheckBoxColumn_1.HeaderText = "АПВ";
		this.dataGridViewFilterCheckBoxColumn_1.Name = "aPVDataGridViewCheckBoxColumn";
		this.dataGridViewFilterCheckBoxColumn_1.ReadOnly = true;
		this.dataGridViewFilterCheckBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterCheckBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewFilterCheckBoxColumn_1.Width = 40;
		this.dataGridViewFilterTextBoxColumn_9.DataPropertyName = "countPointCat1Full";
		this.dataGridViewFilterTextBoxColumn_9.HeaderText = "т.у. Кат1 Полное";
		this.dataGridViewFilterTextBoxColumn_9.Name = "countPointCat1FullDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_9.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_9.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_9.Width = 50;
		this.dataGridViewFilterTextBoxColumn_10.DataPropertyName = "countPointCat1";
		this.dataGridViewFilterTextBoxColumn_10.HeaderText = "т.у. Кат1";
		this.dataGridViewFilterTextBoxColumn_10.Name = "countPointCat1DataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_10.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_10.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_10.Width = 50;
		this.dataGridViewFilterTextBoxColumn_11.DataPropertyName = "countPointCat2Full";
		this.dataGridViewFilterTextBoxColumn_11.HeaderText = "т.у. Кат2 Полное";
		this.dataGridViewFilterTextBoxColumn_11.Name = "countPointCat2FullDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_11.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_11.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_11.Width = 50;
		this.dataGridViewFilterTextBoxColumn_12.DataPropertyName = "countPointCat2";
		this.dataGridViewFilterTextBoxColumn_12.HeaderText = "т.у. Кат2";
		this.dataGridViewFilterTextBoxColumn_12.Name = "countPointCat2DataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_12.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_12.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_12.Width = 50;
		this.dataGridViewFilterTextBoxColumn_13.DataPropertyName = "countPointCat3";
		this.dataGridViewFilterTextBoxColumn_13.HeaderText = "т.у. Кат3";
		this.dataGridViewFilterTextBoxColumn_13.Name = "countPointCat3DataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_13.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_13.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_13.Width = 50;
		this.dataGridViewFilterTextBoxColumn_14.DataPropertyName = "countPointEE";
		this.dataGridViewFilterTextBoxColumn_14.HeaderText = "т.у. Сеть";
		this.dataGridViewFilterTextBoxColumn_14.Name = "countPointCatEEDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_14.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_14.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_14.Width = 50;
		this.dataGridViewFilterTextBoxColumn_15.DataPropertyName = "countPointSource";
		this.dataGridViewFilterTextBoxColumn_15.HeaderText = "т.у. Произв";
		this.dataGridViewFilterTextBoxColumn_15.Name = "countPointCatSourceDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_15.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_15.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_15.Width = 50;
		this.dataGridViewFilterTextBoxColumn_16.DataPropertyName = "countAbnObjCat1Full";
		this.dataGridViewFilterTextBoxColumn_16.HeaderText = "Абн Кат1 Полное";
		this.dataGridViewFilterTextBoxColumn_16.Name = "countAbnObjCat1FullDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_16.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_16.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_16.Width = 50;
		this.dataGridViewFilterTextBoxColumn_17.DataPropertyName = "countAbnObjCat1";
		this.dataGridViewFilterTextBoxColumn_17.HeaderText = "Абн Кат1";
		this.dataGridViewFilterTextBoxColumn_17.Name = "countAbnObjCat1DataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_17.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_17.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_17.Width = 50;
		this.dataGridViewFilterTextBoxColumn_18.DataPropertyName = "countAbnObjCat2Full";
		this.dataGridViewFilterTextBoxColumn_18.HeaderText = "Абн Кат2 Полное";
		this.dataGridViewFilterTextBoxColumn_18.Name = "countAbnObjCat2FullDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_18.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_18.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_18.Width = 50;
		this.dataGridViewFilterTextBoxColumn_19.DataPropertyName = "countAbnObjCat2";
		this.dataGridViewFilterTextBoxColumn_19.HeaderText = "Абн Кат2";
		this.dataGridViewFilterTextBoxColumn_19.Name = "countAbnObjCat2DataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_19.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_19.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_19.Width = 50;
		this.dataGridViewFilterTextBoxColumn_20.DataPropertyName = "countAbnObjCat3";
		this.dataGridViewFilterTextBoxColumn_20.HeaderText = "Абн Кат3";
		this.dataGridViewFilterTextBoxColumn_20.Name = "countAbnObjCat3DataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_20.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_20.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_20.Width = 50;
		this.dataGridViewFilterTextBoxColumn_21.DataPropertyName = "countAbnObjEE";
		this.dataGridViewFilterTextBoxColumn_21.HeaderText = "Абн Сеть";
		this.dataGridViewFilterTextBoxColumn_21.Name = "countAbnObjCatEEDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_21.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_21.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_21.Width = 50;
		this.dataGridViewFilterTextBoxColumn_22.DataPropertyName = "countAbnObjSource";
		this.dataGridViewFilterTextBoxColumn_22.HeaderText = "Абн Произв";
		this.dataGridViewFilterTextBoxColumn_22.Name = "countAbnObjCatSourceDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_22.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_22.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_22.Width = 50;
		this.dataGridViewFilterTextBoxColumn_23.DataPropertyName = "countAbnObj150";
		this.dataGridViewFilterTextBoxColumn_23.HeaderText = "Абн до 150";
		this.dataGridViewFilterTextBoxColumn_23.Name = "countAbnObj150DataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_23.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_23.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_24.DataPropertyName = "countAbnObj150670";
		this.dataGridViewFilterTextBoxColumn_24.HeaderText = "Абн до 670";
		this.dataGridViewFilterTextBoxColumn_24.Name = "countAbnObj150670DataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_24.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_24.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_24.Width = 50;
		this.dataGridViewFilterTextBoxColumn_25.DataPropertyName = "countAbnObj670";
		this.dataGridViewFilterTextBoxColumn_25.HeaderText = "Абн свыше 670";
		this.dataGridViewFilterTextBoxColumn_25.Name = "countAbnObj670DataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_25.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_25.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_26.DataPropertyName = "dateBegin";
		this.dataGridViewFilterTextBoxColumn_26.HeaderText = "Дата прекращения";
		this.dataGridViewFilterTextBoxColumn_26.Name = "dateBeginDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_26.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_26.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_26.Width = 80;
		this.dataGridViewFilterTextBoxColumn_27.DataPropertyName = "dateApply";
		this.dataGridViewFilterTextBoxColumn_27.HeaderText = "Дата устранения";
		this.dataGridViewFilterTextBoxColumn_27.Name = "dateApplyDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_27.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_27.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_27.Width = 80;
		this.dataGridViewFilterTextBoxColumn_28.DataPropertyName = "dateApplyMax";
		this.dataGridViewFilterTextBoxColumn_28.HeaderText = "Дата восстановления";
		this.dataGridViewFilterTextBoxColumn_28.Name = "dateApplyMaxDataGridViewTextBoxColumn";
		this.dataGridViewFilterTextBoxColumn_28.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_28.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_28.Width = 80;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "IdDamage";
		this.dataGridViewTextBoxColumn_0.HeaderText = "IdDamage";
		this.dataGridViewTextBoxColumn_0.Name = "idDamageDgvColumn";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.bindingSource_0.DataMember = "Report81";
		this.bindingSource_0.DataSource = this.class171_0;
		this.class171_0.DataSetName = "DataSetDamage";
		this.class171_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
		this.backgroundWorker_0.RunWorkerCompleted += this.backgroundWorker_0_RunWorkerCompleted;
		this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_3.Image = Resources.report;
		this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_3.Name = "toolBtnReport";
		this.toolStripButton_3.Size = new Size(23, 22);
		this.toolStripButton_3.Text = "Отчет";
		this.toolStripButton_3.Click += this.toolStripButton_3_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1135, 715);
		base.Controls.Add(this.splitContainer_0);
		base.Controls.Add(this.toolStrip_0);
		base.Name = "FormReport81";
		this.Text = "Бюллетень 8.1";
		base.Load += this.Form75_Load;
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		this.splitContainer_0.Panel1.ResumeLayout(false);
		this.splitContainer_0.Panel1.PerformLayout();
		this.splitContainer_0.Panel2.ResumeLayout(false);
		this.splitContainer_0.ResumeLayout(false);
		this.groupBox_1.ResumeLayout(false);
		this.groupBox_1.PerformLayout();
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		this.toolStrip_1.ResumeLayout(false);
		this.toolStrip_1.PerformLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class171_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private string string_0;

	private ToolStrip toolStrip_0;

	private SplitContainer splitContainer_0;

	private ToolStrip toolStrip_1;

	private Class171 class171_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private DataGridViewExcelFilter dataGridViewExcelFilter_0;

	private BindingSource bindingSource_0;

	private BackgroundWorker backgroundWorker_0;

	private System.Windows.Forms.GroupBox groupBox_0;

	private DateTimePicker dateTimePicker_0;

	private System.Windows.Forms.Label label_0;

	private DateTimePicker dateTimePicker_1;

	private System.Windows.Forms.Label label_1;

	private RadioButton radioButton_0;

	private ComboBox comboBox_0;

	private RadioButton radioButton_1;

	private ToolStripProgressBar toolStripProgressBar_0;

	private DataGridViewFilterCheckBoxColumn dataGridViewFilterCheckBoxColumn_0;

	private System.Windows.Forms.GroupBox groupBox_1;

	private RadioButton radioButton_2;

	private RadioButton radioButton_3;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_3;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_4;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_5;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_6;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_7;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_8;

	private DataGridViewFilterCheckBoxColumn dataGridViewFilterCheckBoxColumn_1;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_9;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_10;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_11;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_12;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_13;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_14;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_15;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_16;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_17;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_18;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_19;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_20;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_21;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_22;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_23;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_24;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_25;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_26;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_27;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_28;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private class Class168
	{
		public Class168()
		{
			
			this.dateTime_0 = DateTime.Now;
			this.dateTime_1 = DateTime.Now;
			this.bool_0 = true;
			
		}

		internal int? nullable_0;

		internal DateTime dateTime_0;

		internal DateTime dateTime_1;

		internal bool bool_0;
	}
}
