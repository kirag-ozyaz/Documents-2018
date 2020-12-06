using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Documents.Forms
{
	public partial class FormFilter : Form
	{
		public FormFilter()
		{
			
			this.bool_0 = true;
			
			this.InitializeComponent();
		}

		public bool UsePeriod
		{
			get
			{
				return this.checkBox8.Checked;
			}
			set
			{
				this.checkBox8.Checked = value;
			}
		}

		public bool UsePeriodExecution
		{
			get
			{
				return this.checkBox9.Checked;
			}
			set
			{
				this.checkBox9.Checked = value;
			}
		}

		public DateTime BeginningOfPeriod
		{
			get
			{
				return this.dateTimePicker1.Value;
			}
			set
			{
				this.dateTimePicker1.Value = value;
			}
		}

		public DateTime EndOfPeriod
		{
			get
			{
				return this.dateTimePicker2.Value;
			}
			set
			{
				this.dateTimePicker2.Value = value;
			}
		}

		public DateTime BeginningOfPeriodExecution
		{
			get
			{
				return this.dateTimePicker4.Value;
			}
			set
			{
				this.dateTimePicker4.Value = value;
			}
		}

		public DateTime EndOfPeriodExecution
		{
			get
			{
				return this.dateTimePicker3.Value;
			}
			set
			{
				this.dateTimePicker3.Value = value;
			}
		}

		public bool Legal
		{
			get
			{
				return this.checkBox1.Checked;
			}
			set
			{
				this.checkBox1.Checked = value;
			}
		}

		public bool Individual
		{
			get
			{
				return this.checkBox2.Checked;
			}
			set
			{
				this.checkBox2.Checked = value;
			}
		}

		public bool Disconnection
		{
			get
			{
				return this.checkBox4.Checked;
			}
			set
			{
				this.checkBox4.Checked = value;
			}
		}

		public bool Resumption
		{
			get
			{
				return this.checkBox3.Checked;
			}
			set
			{
				this.checkBox3.Checked = value;
			}
		}

		public bool Cancel
		{
			get
			{
				return this.checkBox5.Checked;
			}
			set
			{
				this.checkBox5.Checked = value;
			}
		}

		public bool DoNotDisplayCancelled
		{
			get
			{
				return this.checkBox6.Checked;
			}
			set
			{
				this.checkBox6.Checked = value;
			}
		}

		public bool DoNotDisplayPerformed
		{
			get
			{
				return this.checkBox7.Checked;
			}
			set
			{
				this.checkBox7.Checked = value;
			}
		}

		public bool DoNotDisplayUnperformed
		{
			get
			{
				return this.checkBox_7.Checked;
			}
			set
			{
				this.checkBox_7.Checked = value;
			}
		}

		public bool SkipUnperformed
		{
			get
			{
				return this.checkBox_6.Checked;
			}
			set
			{
				this.checkBox_6.Checked = value;
			}
		}

		public bool SkipUnsent
		{
			get
			{
				return this.checkBox_5.Checked;
			}
			set
			{
				this.checkBox_5.Checked = value;
			}
		}

		public bool ShowDoNotDisplayZone
		{
			get
			{
				return this.groupBox4.Visible;
			}
			set
			{
				this.groupBox4.Visible = value;
			}
		}

		public bool ShowPeriodExecutionApplication
		{
			get
			{
				return this.PeriodExecutionApplication.Visible;
			}
			set
			{
				this.PeriodExecutionApplication.Visible = value;
			}
		}

		public bool ShowPeriodApplication
		{
			get
			{
				return this.panelPeriodApplication.Visible;
			}
			set
			{
				this.panelPeriodApplication.Visible = value;
			}
		}

		public bool ForDisconected
		{
			get
			{
				return this.groupBox2.Enabled;
			}
			set
			{
				this.groupBox2.Enabled = value;
				this.groupBox4.Enabled = value;
			}
		}

		public bool NetArea1
		{
			get
			{
				return this.checkBox_3.Checked;
			}
			set
			{
				this.checkBox_3.Checked = value;
			}
		}

		public bool NetArea2
		{
			get
			{
				return this.checkBox_2.Checked;
			}
			set
			{
				this.checkBox_2.Checked = value;
			}
		}

		public bool NetArea3
		{
			get
			{
				return this.checkBox_1.Checked;
			}
			set
			{
				this.checkBox_1.Checked = value;
			}
		}

		public bool NetArea4
		{
			get
			{
				return this.checkBox_0.Checked;
			}
			set
			{
				this.checkBox_0.Checked = value;
			}
		}

		public bool ODS
		{
			get
			{
				return this.checkBox_4.Checked;
			}
			set
			{
				this.checkBox_4.Checked = value;
			}
		}

		public bool SESNO
		{
			get
			{
				return this.checkBox_8.Checked;
			}
			set
			{
				this.checkBox_8.Checked = value;
			}
		}

		public bool ShowNetArea
		{
			get
			{
				return this.groupBox6.Visible;
			}
			set
			{
				this.groupBox6.Visible = value;
			}
		}

		protected override void OnDeactivate(EventArgs e)
		{
			base.OnDeactivate(e);
			base.Hide();
		}

		private void ftZdursrjA(object sender, EventArgs e)
		{
			this.groupBox3.Enabled = this.checkBox8.Checked;
		}

		private void FormFilter_Load(object sender, EventArgs e)
		{
			int num = 2;
			foreach (object obj in base.Controls)
			{
				Control control = (Control)obj;
				if (control.Visible)
				{
					num += control.Size.Height;
				}
			}
			base.Height = num;
		}

		private void checkBox9_CheckedChanged(object sender, EventArgs e)
		{
			this.groupBox5.Enabled = this.checkBox9.Checked;
		}

		private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.bool_0 = false;
				this.dateTimePicker3.Value = (this.dateTimePicker3.Value - this.dateTimePicker3.Value.TimeOfDay).AddHours(24.0).AddSeconds(-1.0);
				this.bool_0 = true;
			}
			if (this.dateTimePicker3.Value < this.dateTimePicker4.Value)
			{
				this.dateTimePicker4.Value = this.dateTimePicker3.Value;
			}
		}

		private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.bool_0 = false;
				this.dateTimePicker4.Value = this.dateTimePicker4.Value - this.dateTimePicker4.Value.TimeOfDay;
				this.bool_0 = true;
			}
			if (this.dateTimePicker4.Value > this.dateTimePicker3.Value)
			{
				this.dateTimePicker3.Value = this.dateTimePicker4.Value;
			}
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.bool_0 = false;
				this.dateTimePicker1.Value = this.dateTimePicker1.Value - this.dateTimePicker1.Value.TimeOfDay;
				this.bool_0 = true;
			}
			if (this.dateTimePicker1.Value > this.dateTimePicker2.Value)
			{
				this.dateTimePicker2.Value = this.dateTimePicker1.Value;
			}
		}

		private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				this.bool_0 = false;
				this.dateTimePicker2.Value = (this.dateTimePicker2.Value - this.dateTimePicker2.Value.TimeOfDay).AddHours(24.0).AddSeconds(-1.0);
				this.bool_0 = true;
			}
			if (this.dateTimePicker2.Value < this.dateTimePicker1.Value)
			{
				this.dateTimePicker1.Value = this.dateTimePicker2.Value;
			}
		}

		private bool bool_0;
	}
}
