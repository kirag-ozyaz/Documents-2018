using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using FormLbr;
using RequestsClient.Properties;

namespace RequestsClient.Forms
{
	public partial class TemperatureSR : FormBase
	{
		public TemperatureSR()
		{
			//Class38.TqlX7ZmzmDDi2();
			//
			this.InitializeComponent();
			this.dateTimePicker_0 = new DateTimePicker();
			this.dateTimePicker_0.Format = DateTimePickerFormat.Short;
			this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year, 1, 1);
			this.dateTimePicker_0.Size = new Size(100, 20);
			this.toolStrip.Items.Insert(1, new ToolStripControlHost(this.dateTimePicker_0));
			this.dateTimePicker_1 = new DateTimePicker();
			this.dateTimePicker_1.Format = DateTimePickerFormat.Short;
			this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year + 1, 1, 1).AddDays(-1.0);
			this.dateTimePicker_1.Size = new Size(100, 20);
			this.toolStrip.Items.Insert(3, new ToolStripControlHost(this.dateTimePicker_1));
		}

		private void TemperatureSR_Load(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void method_0()
		{
			new SqlDataCommand(new SQLSettings("ulges-sql", "SR", "WINDOWS", "", "")).SelectSqlData(this.dataSet_0.Tables["СоставительНизкого"], false, string.Concat(new string[]
			{
				" where [Дата] >= '",
				this.dateTimePicker_0.Value.ToString("yyyyMMdd"),
				"' and [Дата] <= '",
				this.dateTimePicker_1.Value.ToString("yyyyMMdd"),
				"' order by [Дата] desc "
			}), null, false, 0);
			new SqlDataCommand(new SQLSettings("ulges-sql", "SR4", "WINDOWS", "", "")).SelectSqlData(this.dataSet_1.Tables["СоставительНизкого"], false, string.Concat(new string[]
			{
				" where [Дата] >= '",
				this.dateTimePicker_0.Value.ToString("yyyyMMdd"),
				"' and [Дата] <= '",
				this.dateTimePicker_1.Value.ToString("yyyyMMdd"),
				"' order by [Дата] desc "
			}), null, false, 0);
		}

		private void toolBtnRefresh_Click(object sender, EventArgs e)
		{
			this.method_0();
		}

		private DateTimePicker dateTimePicker_0;

		private DateTimePicker dateTimePicker_1;
	}
}
