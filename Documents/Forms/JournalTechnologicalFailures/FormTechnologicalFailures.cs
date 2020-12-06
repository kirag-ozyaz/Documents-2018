using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using Documents.Properties;
using FormLbr;

namespace Documents.Forms.JournalTechnologicalFailures
{
	public partial class FormTechnologicalFailures : FormBase
	{
		public FormTechnologicalFailures()
		{
			
			
			this.method_1();
			this.dateTimePicker_1.Value = (this.dateTimePicker_0.Value = DateTime.Now.Date);
			for (int i = 1990; i < DateTime.Now.Year + 20; i++)
			{
				this.comboBox_1.Items.Add(i);
				this.comboBox_0.Items.Add(i);
			}
			this.comboBox_2.SelectedIndex = DateTime.Now.Month - 1;
			this.comboBox_1.SelectedItem = DateTime.Now.Year;
			this.comboBox_0.SelectedItem = DateTime.Now.Year;
		}

		private void FormTechnologicalFailures_Load(object sender, EventArgs e)
		{
			this.comboBox_2.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
			this.comboBox_1.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
			this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
			this.dateTimePicker_1.ValueChanged += this.dateTimePicker_0_ValueChanged;
			this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
			this.method_0();
		}

		private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void method_0()
		{
			string where = "";
			if (this.radioButton_2.Checked)
			{
				DateTime dateTime = new DateTime(Convert.ToInt32(this.comboBox_1.SelectedItem), this.comboBox_2.SelectedIndex + 1, 1);
				where = string.Concat(new string[]
				{
					" where dateOff >= '",
					dateTime.ToString("yyyyMMdd"),
					"' and dateOff < '",
					dateTime.AddMonths(1).ToString("yyyyMMdd"),
					"'"
				});
			}
			else if (this.radioButton_1.Checked)
			{
				DateTime dateTime2 = new DateTime(Convert.ToInt32(this.comboBox_0.SelectedItem), 1, 1);
				where = string.Concat(new string[]
				{
					" where dateOff >= '",
					dateTime2.ToString("yyyyMMdd"),
					"' and dateOff < '",
					dateTime2.AddYears(1).ToString("yyyyMMdd"),
					"'"
				});
			}
			else if (this.radioButton_0.Checked)
			{
				where = string.Concat(new string[]
				{
					" where dateOff >= '",
					this.dateTimePicker_1.Value.ToString("yyyyMMdd"),
					"' and dateOff < '",
					this.dateTimePicker_0.Value.AddDays(1.0).ToString("yyyyMMdd"),
					"'"
				});
			}
			int? num = null;
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				num = new int?(Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value));
			}
			base.SelectSqlData(this.class126_0.tJ_TechnologicalFailures, true, where, null, false, 0);
			if (num != null)
			{
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_0.Name, num.ToString(), false);
			}
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			Form48 form = new Form48(-1);
			form.SqlSettings = this.SqlSettings;
			if (form.ShowDialog() == DialogResult.OK)
			{
				this.method_0();
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_0.Name, form.Id.ToString(), false);
			}
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				Form48 form = new Form48(Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value));
				form.SqlSettings = this.SqlSettings;
				if (form.ShowDialog() == DialogResult.OK)
				{
					this.method_0();
					this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_0.Name, form.Id.ToString(), false);
				}
			}
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null && MessageBox.Show("Вы действиетльно хотите удалить текущую запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class126_0.tJ_TechnologicalFailures, Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value)))
			{
				this.dataGridViewExcelFilter_0.Rows.Remove(this.dataGridViewExcelFilter_0.CurrentRow);
			}
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			new Form47
			{
				MdiParent = base.MdiParent,
				SqlSettings = this.SqlSettings
			}.Show();
		}

		private void dataGridViewExcelFilter_0_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			if (e.RowIndex >= 0 && this.dataGridViewExcelFilter_0.Columns[e.ColumnIndex] == this.dataGridViewFilterTextBoxColumn_3 && this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_2.Name, e.RowIndex].Value != DBNull.Value && this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_0.Name, e.RowIndex].Value != DBNull.Value)
			{
				e.Value = Convert.ToDateTime(this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_2.Name, e.RowIndex].Value) - Convert.ToDateTime(this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_0.Name, e.RowIndex].Value);
			}
		}

		private void dataGridViewExcelFilter_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && this.dataGridViewExcelFilter_0.Columns[e.ColumnIndex] == this.dataGridViewFilterTextBoxColumn_3 && e.Value != null && e.Value != DBNull.Value)
			{
				string text = "";
				if (((TimeSpan)e.Value).Days != 0)
				{
					text = ((TimeSpan)e.Value).Days.ToString() + "  ";
				}
				text = text + ((TimeSpan)e.Value).Hours.ToString("00") + ":" + ((TimeSpan)e.Value).Minutes.ToString("00");
				e.Value = text;
			}
		}

		private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				this.toolStripButton_1_Click(sender, e);
			}
		}

		private void dataGridViewExcelFilter_0_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			this.dataGridViewExcelFilter_0.AutoResizeRow(e.RowIndex);
		}

		private void radioButton_2_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButton_2.Checked)
			{
				Control control = this.comboBox_1;
				this.comboBox_2.Enabled = true;
				control.Enabled = true;
				this.comboBox_0.Enabled = false;
				Control control2 = this.dateTimePicker_0;
				this.dateTimePicker_1.Enabled = false;
				control2.Enabled = false;
				this.method_0();
			}
		}

		private void radioButton_1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButton_1.Checked)
			{
				Control control = this.comboBox_1;
				this.comboBox_2.Enabled = false;
				control.Enabled = false;
				this.comboBox_0.Enabled = true;
				Control control2 = this.dateTimePicker_0;
				this.dateTimePicker_1.Enabled = false;
				control2.Enabled = false;
				this.method_0();
			}
		}

		private void radioButton_0_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButton_0.Checked)
			{
				Control control = this.comboBox_1;
				this.comboBox_2.Enabled = false;
				control.Enabled = false;
				this.comboBox_0.Enabled = false;
				Control control2 = this.dateTimePicker_0;
				this.dateTimePicker_1.Enabled = true;
				control2.Enabled = true;
				this.method_0();
			}
		}

		private void method_1()
		{
			this.icontainer_0 = new Container();
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripButton_4 = new ToolStripButton();
			this.class126_0 = new Class126();
			this.splitContainer_0 = new SplitContainer();
			this.label_0 = new Label();
			this.dateTimePicker_0 = new DateTimePicker();
			this.label_1 = new Label();
			this.dateTimePicker_1 = new DateTimePicker();
			this.radioButton_0 = new RadioButton();
			this.comboBox_0 = new ComboBox();
			this.radioButton_1 = new RadioButton();
			this.comboBox_1 = new ComboBox();
			this.comboBox_2 = new ComboBox();
			this.radioButton_2 = new RadioButton();
			this.label_2 = new Label();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.zVqoQuudlp1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
			this.IcwoQxsckoQ = new DataGridViewFilterTextBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.toolStrip_0.SuspendLayout();
			((ISupportInitialize)this.class126_0).BeginInit();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			base.SuspendLayout();
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripButton_1,
				this.toolStripButton_2,
				this.toolStripButton_3,
				this.toolStripButton_4
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStripMain";
			this.toolStrip_0.Size = new Size(885, 25);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.ElementAdd;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnAdd";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Добавить";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.ElementEdit;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnEdit";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Редактировать";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.ElementDel;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnRemove";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Удалить";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = Resources.refresh_16;
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnRefresh";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Обновить";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = Resources.report;
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnReport";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Отчет";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.class126_0.DataSetName = "DataSetFailure";
			this.class126_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.splitContainer_0.Dock = DockStyle.Fill;
			this.splitContainer_0.Location = new Point(0, 25);
			this.splitContainer_0.Name = "splitContainer1";
			this.splitContainer_0.Panel1.Controls.Add(this.label_0);
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_1);
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_1);
			this.splitContainer_0.Panel1.Controls.Add(this.radioButton_0);
			this.splitContainer_0.Panel1.Controls.Add(this.comboBox_0);
			this.splitContainer_0.Panel1.Controls.Add(this.radioButton_1);
			this.splitContainer_0.Panel1.Controls.Add(this.comboBox_1);
			this.splitContainer_0.Panel1.Controls.Add(this.comboBox_2);
			this.splitContainer_0.Panel1.Controls.Add(this.radioButton_2);
			this.splitContainer_0.Panel1.Controls.Add(this.label_2);
			this.splitContainer_0.Panel2.Controls.Add(this.dataGridViewExcelFilter_0);
			this.splitContainer_0.Size = new Size(885, 368);
			this.splitContainer_0.SplitterDistance = 199;
			this.splitContainer_0.TabIndex = 1;
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(12, 176);
			this.label_0.Name = "label3";
			this.label_0.Size = new Size(19, 13);
			this.label_0.TabIndex = 10;
			this.label_0.Text = "до";
			this.dateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_0.Enabled = false;
			this.dateTimePicker_0.Location = new Point(35, 174);
			this.dateTimePicker_0.Name = "dateTimePickerEnd";
			this.dateTimePicker_0.Size = new Size(156, 20);
			this.dateTimePicker_0.TabIndex = 9;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(12, 152);
			this.label_1.Name = "label2";
			this.label_1.Size = new Size(18, 13);
			this.label_1.TabIndex = 8;
			this.label_1.Text = "от";
			this.dateTimePicker_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_1.Enabled = false;
			this.dateTimePicker_1.Location = new Point(35, 148);
			this.dateTimePicker_1.Name = "dateTimePickerBeg";
			this.dateTimePicker_1.Size = new Size(156, 20);
			this.dateTimePicker_1.TabIndex = 7;
			this.radioButton_0.AutoSize = true;
			this.radioButton_0.Location = new Point(12, 125);
			this.radioButton_0.Name = "radioButtonPeriod";
			this.radioButton_0.Size = new Size(63, 17);
			this.radioButton_0.TabIndex = 6;
			this.radioButton_0.Text = "Период";
			this.radioButton_0.UseVisualStyleBackColor = true;
			this.radioButton_0.CheckedChanged += this.radioButton_0_CheckedChanged;
			this.comboBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_0.Enabled = false;
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(12, 98);
			this.comboBox_0.Name = "cmbYear";
			this.comboBox_0.Size = new Size(179, 21);
			this.comboBox_0.TabIndex = 5;
			this.radioButton_1.AutoSize = true;
			this.radioButton_1.Location = new Point(12, 75);
			this.radioButton_1.Name = "radioButtonYear";
			this.radioButton_1.Size = new Size(43, 17);
			this.radioButton_1.TabIndex = 4;
			this.radioButton_1.Text = "Год";
			this.radioButton_1.UseVisualStyleBackColor = true;
			this.radioButton_1.CheckedChanged += this.radioButton_1_CheckedChanged;
			this.comboBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.comboBox_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_1.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_1.FormattingEnabled = true;
			this.comboBox_1.Location = new Point(125, 48);
			this.comboBox_1.Name = "cmbMonthYear";
			this.comboBox_1.Size = new Size(66, 21);
			this.comboBox_1.TabIndex = 3;
			this.comboBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_2.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_2.FormattingEnabled = true;
			this.comboBox_2.Items.AddRange(new object[]
			{
				"январь",
				"февраль",
				"март",
				"апрель",
				"май",
				"июнь",
				"июль",
				"август",
				"сентябрь",
				"октябрь",
				"ноябрь",
				"декабрь"
			});
			this.comboBox_2.Location = new Point(12, 48);
			this.comboBox_2.Name = "cmbMonth";
			this.comboBox_2.Size = new Size(112, 21);
			this.comboBox_2.TabIndex = 2;
			this.radioButton_2.AutoSize = true;
			this.radioButton_2.Checked = true;
			this.radioButton_2.Location = new Point(12, 25);
			this.radioButton_2.Name = "radioButtonMonth";
			this.radioButton_2.Size = new Size(58, 17);
			this.radioButton_2.TabIndex = 1;
			this.radioButton_2.TabStop = true;
			this.radioButton_2.Text = "Месяц";
			this.radioButton_2.UseVisualStyleBackColor = true;
			this.radioButton_2.CheckedChanged += this.radioButton_2_CheckedChanged;
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(12, 9);
			this.label_2.Name = "label1";
			this.label_2.Size = new Size(47, 13);
			this.label_2.TabIndex = 0;
			this.label_2.Text = "Фильтр";
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_0.AllowUserToVisibleColumns = false;
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewFilterTextBoxColumn_0,
				this.zVqoQuudlp1,
				this.dataGridViewFilterTextBoxColumn_1,
				this.dataGridViewFilterTextBoxColumn_2,
				this.dataGridViewFilterTextBoxColumn_3,
				this.IcwoQxsckoQ
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.Location = new Point(0, 0);
			this.dataGridViewExcelFilter_0.Name = "dgv";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.Size = new Size(682, 368);
			this.dataGridViewExcelFilter_0.TabIndex = 0;
			this.dataGridViewExcelFilter_0.VirtualMode = true;
			this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
			this.dataGridViewExcelFilter_0.CellFormatting += this.dataGridViewExcelFilter_0_CellFormatting;
			this.dataGridViewExcelFilter_0.CellValueNeeded += this.dataGridViewExcelFilter_0_CellValueNeeded;
			this.dataGridViewExcelFilter_0.RowPostPaint += this.dataGridViewExcelFilter_0_RowPostPaint;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "idDgvColumn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "num";
			this.dataGridViewTextBoxColumn_1.HeaderText = "num";
			this.dataGridViewTextBoxColumn_1.Name = "numDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "dateOff";
			dataGridViewCellStyle.Format = "g";
			dataGridViewCellStyle.NullValue = null;
			this.dataGridViewFilterTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle;
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Дата и время отключения";
			this.dataGridViewFilterTextBoxColumn_0.Name = "dateOffDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.zVqoQuudlp1.DataPropertyName = "schmObj";
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			this.zVqoQuudlp1.DefaultCellStyle = dataGridViewCellStyle2;
			this.zVqoQuudlp1.HeaderText = "Наименование электроустановки";
			this.zVqoQuudlp1.Name = "schmObjDgvColumn";
			this.zVqoQuudlp1.ReadOnly = true;
			this.zVqoQuudlp1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "text";
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Причина, характер повреждения";
			this.dataGridViewFilterTextBoxColumn_1.Name = "textDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "dateOn";
			dataGridViewCellStyle4.Format = "g";
			dataGridViewCellStyle4.NullValue = null;
			this.dataGridViewFilterTextBoxColumn_2.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Дата и время включения";
			this.dataGridViewFilterTextBoxColumn_2.Name = "dateOnDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
			dataGridViewCellStyle5.Format = "HH:mm";
			dataGridViewCellStyle5.NullValue = null;
			this.dataGridViewFilterTextBoxColumn_3.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewFilterTextBoxColumn_3.HeaderText = "Время простоя";
			this.dataGridViewFilterTextBoxColumn_3.Name = "DownTimeCompute";
			this.dataGridViewFilterTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_3.Resizable = DataGridViewTriState.True;
			this.IcwoQxsckoQ.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.IcwoQxsckoQ.DataPropertyName = "abonents";
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
			this.IcwoQxsckoQ.DefaultCellStyle = dataGridViewCellStyle6;
			this.IcwoQxsckoQ.HeaderText = "Потребители";
			this.IcwoQxsckoQ.Name = "abonentsDataGridViewTextBoxColumn";
			this.IcwoQxsckoQ.ReadOnly = true;
			this.IcwoQxsckoQ.Resizable = DataGridViewTriState.True;
			this.bindingSource_0.DataMember = "tJ_TechnologicalFailures";
			this.bindingSource_0.DataSource = this.class126_0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(885, 393);
			base.Controls.Add(this.splitContainer_0);
			base.Controls.Add(this.toolStrip_0);
			base.Name = "FormTechnologicalFailures";
			this.Text = "Журнал технологических нарушений";
			base.Load += this.FormTechnologicalFailures_Load;
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			((ISupportInitialize)this.class126_0).EndInit();
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private ToolStrip toolStrip_0;

		private Class126 class126_0;

		private SplitContainer splitContainer_0;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private BindingSource bindingSource_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripButton toolStripButton_3;

		private ToolStripButton toolStripButton_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn zVqoQuudlp1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_3;

		private DataGridViewFilterTextBoxColumn IcwoQxsckoQ;

		private Label label_0;

		private DateTimePicker dateTimePicker_0;

		private Label label_1;

		private DateTimePicker dateTimePicker_1;

		private RadioButton radioButton_0;

		private ComboBox comboBox_0;

		private RadioButton radioButton_1;

		private ComboBox comboBox_1;

		private ComboBox comboBox_2;

		private RadioButton radioButton_2;

		private Label label_2;
	}
}
