using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr;
using FormLbr;

internal partial class Form62 : FormBase
{
	internal int method_0()
	{
		return this.int_1;
	}

	internal void method_1(int int_2)
	{
		this.int_1 = int_2;
	}

	public Form62()
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		
		this.method_3();
		this.method_2();
	}

	internal Form62(int int_2, int int_3, Enum18 enum18_1)
	{
		
		this.int_0 = -1;
		this.int_1 = -1;
		
		this.method_3();
		this.int_0 = int_3;
		this.int_1 = int_2;
		this.enum18_0 = enum18_1;
		this.method_2();
	}

	private void method_2()
	{
		if (this.enum18_0 == (Enum18)2)
		{
			this.Text = ((this.int_1 == -1) ? "Новое состояние" : "Редактирование состояния");
			this.dateTimePicker_0.Value = DateTime.Now;
			this.dateTimePicker_0.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker_0.CustomFormat = "dd.MM.yyyy HH.mm";
		}
		else if (this.enum18_0 == (Enum18)1)
		{
			this.Text = ((this.int_1 == -1) ? "Новый статус" : "Редактирование статуса");
		}
		this.nullableDateTimePicker_0.Value = (this.dateTimePicker_0.Value = DateTime.Now.Date);
	}

	private void Form62_Load(object sender, EventArgs e)
	{
		if (this.enum18_0 == (Enum18)1)
		{
			base.SelectSqlData(this.class130_0, this.class130_0.tR_Classifier, true, " where ParentKey like ';Excavation;StatusOrder;%' and isGRoup = 0 and deleted = 0 order by name");
		}
		if (this.enum18_0 == (Enum18)2)
		{
			base.SelectSqlData(this.class130_0, this.class130_0.tR_Classifier, true, " where ParentKey like ';Excavation;StatusWork;%' and isGRoup = 0 and deleted = 0 order by name");
		}
		this.comboBox_0.SelectedIndex = -1;
		if (this.int_1 == -1)
		{
			DataRow dataRow = this.class130_0.tJ_ExcavationStatus.NewRow();
			dataRow["idExcavation"] = this.int_0;
			dataRow["idType"] = (int)this.enum18_0;
			dataRow["idStatus"] = -1;
			if (this.enum18_0 == (Enum18)1)
			{
				dataRow["dateChange"] = DateTime.Now.Date;
			}
			else
			{
				dataRow["dateChange"] = DateTime.Now;
			}
			this.class130_0.tJ_ExcavationStatus.Rows.Add(dataRow);
		}
		else
		{
			base.SelectSqlData(this.class130_0, this.class130_0.tJ_ExcavationStatus, true, "where id = " + this.int_1.ToString());
		}
		if (this.class130_0.tJ_ExcavationStatus.Rows.Count > 0)
		{
			this.class130_0.tJ_ExcavationStatus.Rows[0].BeginEdit();
		}
	}

	private void Form62_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.comboBox_0.SelectedIndex < 0)
			{
				MessageBox.Show("Не выбран статус");
				e.Cancel = true;
				return;
			}
			if (this.enum18_0 == (Enum18)1 && this.nullable_0 == 4f && (this.nullableDateTimePicker_0.Value == null || this.nullableDateTimePicker_0.Value == DBNull.Value))
			{
				MessageBox.Show("Не указана дата продления");
				e.Cancel = true;
				return;
			}
			this.class130_0.tJ_ExcavationStatus.Rows[0].EndEdit();
			if (this.int_1 == -1)
			{
				this.int_1 = base.InsertSqlDataOneRow(this.class130_0, this.class130_0.tJ_ExcavationStatus);
				return;
			}
			base.UpdateSqlData(this.class130_0, this.class130_0.tJ_ExcavationStatus);
		}
	}

	private void comboBox_0_SelectedValueChanged(object sender, EventArgs e)
	{
		if (this.comboBox_0.SelectedValue != null && this.comboBox_0.SelectedValue != DBNull.Value)
		{
			DataRow[] array = this.class130_0.tR_Classifier.Select("id = " + this.comboBox_0.SelectedValue.ToString());
			if (array.Length != 0)
			{
				if (array[0]["Value"] != DBNull.Value)
				{
					this.nullable_0 = new float?(Convert.ToSingle(array[0]["Value"]));
				}
				else
				{
					this.nullable_0 = new float?(0f);
				}
			}
			else
			{
				this.nullable_0 = null;
			}
		}
		else
		{
			this.nullable_0 = null;
		}
		if (this.nullable_0 == 4f && this.enum18_0 == (Enum18)1)
		{
			this.label_1.Visible = true;
			this.nullableDateTimePicker_0.Visible = true;
			this.nullableDateTimePicker_0.Value = this.nullable_1;
			return;
		}
		this.label_1.Visible = false;
		this.nullableDateTimePicker_0.Visible = false;
		if (this.nullableDateTimePicker_0.Value == null)
		{
			this.nullable_1 = null;
		}
		else
		{
			this.nullable_1 = new DateTime?(Convert.ToDateTime(this.nullableDateTimePicker_0.Value));
		}
		if (this.class130_0.tJ_ExcavationStatus.Rows.Count > 0)
		{
			this.class130_0.tJ_ExcavationStatus.Rows[0]["dateElongation"] = DBNull.Value;
		}
		this.nullableDateTimePicker_0.Value = null;
	}

	private void nullableDateTimePicker_0_VisibleChanged(object sender, EventArgs e)
	{
		if (this.nullableDateTimePicker_0.Visible)
		{
			base.Height += this.nullableDateTimePicker_0.Height;
			return;
		}
		base.Height -= this.nullableDateTimePicker_0.Height;
	}

	private void method_3()
	{
		this.label_0 = new Label();
		this.comboBox_0 = new ComboBox();
		this.class130_0 = new DataSetExcavation();
		this.label_1 = new Label();
		this.nullableDateTimePicker_0 = new NullableDateTimePicker();
		this.label_2 = new Label();
		this.dateTimePicker_0 = new DateTimePicker();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.label_3 = new Label();
		this.richTextBox_0 = new RichTextBox();
		this.tableLayoutPanel_0 = new TableLayoutPanel();
		((ISupportInitialize)this.class130_0).BeginInit();
		this.tableLayoutPanel_0.SuspendLayout();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Dock = DockStyle.Fill;
		this.label_0.Location = new Point(3, 0);
		this.label_0.Name = "labelStatus";
		this.label_0.Size = new Size(92, 27);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Статус";
		this.label_0.TextAlign = ContentAlignment.MiddleLeft;
		this.tableLayoutPanel_0.SetColumnSpan(this.comboBox_0, 2);
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class130_0, "tJ_ExcavationStatus.idStatus", true));
		this.comboBox_0.DataSource = this.class130_0;
		this.comboBox_0.DisplayMember = "tR_Classifier.Name";
		this.comboBox_0.Dock = DockStyle.Fill;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(101, 3);
		this.comboBox_0.Name = "cmStatus";
		this.comboBox_0.Size = new Size(213, 21);
		this.comboBox_0.TabIndex = 1;
		this.comboBox_0.ValueMember = "tR_Classifier.Id";
		this.comboBox_0.SelectedValueChanged += this.comboBox_0_SelectedValueChanged;
		this.class130_0.DataSetName = "DataSetExcavation";
		this.class130_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_1.AutoSize = true;
		this.label_1.Dock = DockStyle.Fill;
		this.label_1.Location = new Point(3, 27);
		this.label_1.Name = "labelElongation";
		this.label_1.Size = new Size(92, 26);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Продлен до";
		this.label_1.TextAlign = ContentAlignment.MiddleLeft;
		this.tableLayoutPanel_0.SetColumnSpan(this.nullableDateTimePicker_0, 2);
		this.nullableDateTimePicker_0.DataBindings.Add(new Binding("Value", this.class130_0, "tJ_ExcavationStatus.dateElongation", true));
		this.nullableDateTimePicker_0.Dock = DockStyle.Fill;
		this.nullableDateTimePicker_0.Location = new Point(101, 30);
		this.nullableDateTimePicker_0.Name = "dateTimePickerElonagation";
		this.nullableDateTimePicker_0.Size = new Size(213, 20);
		this.nullableDateTimePicker_0.TabIndex = 3;
		this.nullableDateTimePicker_0.Value = new DateTime(2016, 6, 21, 15, 7, 38, 861);
		this.nullableDateTimePicker_0.VisibleChanged += this.nullableDateTimePicker_0_VisibleChanged;
		this.label_2.AutoSize = true;
		this.label_2.Dock = DockStyle.Fill;
		this.label_2.Location = new Point(3, 53);
		this.label_2.Name = "labelChange";
		this.label_2.Size = new Size(92, 26);
		this.label_2.TabIndex = 4;
		this.label_2.Text = "Дата изменения";
		this.label_2.TextAlign = ContentAlignment.MiddleLeft;
		this.tableLayoutPanel_0.SetColumnSpan(this.dateTimePicker_0, 2);
		this.dateTimePicker_0.CustomFormat = "dd.MM.yyyy HH:mm";
		this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class130_0, "tJ_ExcavationStatus.dateChange", true));
		this.dateTimePicker_0.Dock = DockStyle.Fill;
		this.dateTimePicker_0.Location = new Point(101, 56);
		this.dateTimePicker_0.Name = "dateTimePickerChange";
		this.dateTimePicker_0.Size = new Size(213, 20);
		this.dateTimePicker_0.TabIndex = 5;
		this.button_0.Anchor = AnchorStyles.Bottom;
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(11, 140);
		this.button_0.Margin = new Padding(3, 3, 3, 7);
		this.button_0.Name = "buttonОК";
		this.button_0.Size = new Size(75, 25);
		this.button_0.TabIndex = 6;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.Anchor = AnchorStyles.Bottom;
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(239, 140);
		this.button_1.Margin = new Padding(3, 3, 3, 7);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 25);
		this.button_1.TabIndex = 7;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.label_3.AutoSize = true;
		this.label_3.Dock = DockStyle.Fill;
		this.label_3.Location = new Point(3, 79);
		this.label_3.Name = "lblComment";
		this.label_3.Size = new Size(92, 26);
		this.label_3.TabIndex = 8;
		this.label_3.Text = "Описание";
		this.label_3.TextAlign = ContentAlignment.MiddleLeft;
		this.tableLayoutPanel_0.SetColumnSpan(this.richTextBox_0, 2);
		this.richTextBox_0.DataBindings.Add(new Binding("Text", this.class130_0, "tJ_ExcavationStatus.Comment", true));
		this.richTextBox_0.Dock = DockStyle.Fill;
		this.richTextBox_0.Location = new Point(101, 82);
		this.richTextBox_0.Name = "rtxtComment";
		this.tableLayoutPanel_0.SetRowSpan(this.richTextBox_0, 2);
		this.richTextBox_0.Size = new Size(213, 38);
		this.richTextBox_0.TabIndex = 9;
		this.richTextBox_0.Text = "";
		this.tableLayoutPanel_0.ColumnCount = 3;
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
		this.tableLayoutPanel_0.Controls.Add(this.label_0, 0, 0);
		this.tableLayoutPanel_0.Controls.Add(this.comboBox_0, 1, 0);
		this.tableLayoutPanel_0.Controls.Add(this.nullableDateTimePicker_0, 1, 1);
		this.tableLayoutPanel_0.Controls.Add(this.button_1, 2, 6);
		this.tableLayoutPanel_0.Controls.Add(this.label_1, 0, 1);
		this.tableLayoutPanel_0.Controls.Add(this.label_2, 0, 2);
		this.tableLayoutPanel_0.Controls.Add(this.dateTimePicker_0, 1, 2);
		this.tableLayoutPanel_0.Controls.Add(this.label_3, 0, 3);
		this.tableLayoutPanel_0.Controls.Add(this.richTextBox_0, 1, 3);
		this.tableLayoutPanel_0.Controls.Add(this.button_0, 0, 6);
		this.tableLayoutPanel_0.Dock = DockStyle.Fill;
		this.tableLayoutPanel_0.Location = new Point(0, 0);
		this.tableLayoutPanel_0.Name = "tableLayoutPanel1";
		this.tableLayoutPanel_0.RowCount = 7;
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 10f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle());
		this.tableLayoutPanel_0.Size = new Size(317, 172);
		this.tableLayoutPanel_0.TabIndex = 10;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(317, 172);
		base.Controls.Add(this.tableLayoutPanel_0);
		base.Name = "FormExcavationStatusAddEdit";
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "Новый статус";
		base.FormClosing += this.Form62_FormClosing;
		base.Load += this.Form62_Load;
		((ISupportInitialize)this.class130_0).EndInit();
		this.tableLayoutPanel_0.ResumeLayout(false);
		this.tableLayoutPanel_0.PerformLayout();
		base.ResumeLayout(false);
	}

	internal static void qefQyg0MkA357wOFOYK2(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private int int_0;

	private int int_1;

	private Enum18 enum18_0;

	private float? nullable_0;

	private DateTime? nullable_1;

	private Label label_0;

	private ComboBox comboBox_0;

	private Label label_1;

	private NullableDateTimePicker nullableDateTimePicker_0;

	private Label label_2;

	private DateTimePicker dateTimePicker_0;

	private Button button_0;

	private Button button_1;

	private DataSetExcavation class130_0;

	private Label label_3;

	private RichTextBox richTextBox_0;

	private TableLayoutPanel tableLayoutPanel_0;
}
