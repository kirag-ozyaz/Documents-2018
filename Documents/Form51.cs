using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr;
using FormLbr;

internal partial class Form51 : FormBase
{
	internal Form51()
	{
		
		this.int_0 = -1;
		
		this.method_0();
	}

	internal Form51(int int_1)
	{
		
		this.int_0 = -1;
		
		this.method_0();
		this.int_0 = int_1;
	}

	private void Form51_Load(object sender, EventArgs e)
	{
		base.SelectSqlData(this.dataSet_0, this.dataSet_0.Tables["tR_Classifier"], true, "where deleted = 0 and isgroup = 0 and ParentKey in (';Other;StatusTask;', ';Other;TypeTask;')");
		base.SelectSqlData(this.class255_0, this.class255_0.tJ_Request, true, "where id = " + this.int_0.ToString());
	}

	private void Form51_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			this.class255_0.tJ_Request.Rows[0].EndEdit();
			base.UpdateSqlData(this.class255_0, this.class255_0.tJ_Request);
		}
	}

	private void method_0()
	{
		this.icontainer_0 = new Container();
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.class255_0 = new Class255();
		this.zdLozUtUnxW = new Label();
		this.label_1 = new Label();
		this.comboBox_0 = new ComboBox();
		this.wfqozBoxRky = new BindingSource(this.icontainer_0);
		this.dataSet_0 = new DataSet();
		this.dataTable_0 = new DataTable();
		this.dataColumn_0 = new DataColumn();
		this.dataColumn_1 = new DataColumn();
		this.dataColumn_2 = new DataColumn();
		this.comboBox_1 = new ComboBox();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.label_2 = new Label();
		this.Rghozrjmnoo = new RichTextBoxWithContextMenu();
		this.QnJozgvjYn5 = new Button();
		this.button_0 = new Button();
		((ISupportInitialize)this.class255_0).BeginInit();
		((ISupportInitialize)this.wfqozBoxRky).BeginInit();
		((ISupportInitialize)this.dataSet_0).BeginInit();
		((ISupportInitialize)this.dataTable_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 9);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(56, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "№ задачи";
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_Request.id", true));
		this.textBox_0.Location = new Point(74, 6);
		this.textBox_0.Name = "textBoxID";
		this.textBox_0.ReadOnly = true;
		this.textBox_0.Size = new Size(156, 20);
		this.textBox_0.TabIndex = 1;
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.zdLozUtUnxW.AutoSize = true;
		this.zdLozUtUnxW.Location = new Point(12, 46);
		this.zdLozUtUnxW.Name = "label2";
		this.zdLozUtUnxW.Size = new Size(41, 13);
		this.zdLozUtUnxW.TabIndex = 2;
		this.zdLozUtUnxW.Text = "Статус";
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(12, 83);
		this.label_1.Name = "label3";
		this.label_1.Size = new Size(64, 13);
		this.label_1.TabIndex = 3;
		this.label_1.Text = "Тип задачи";
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class255_0, "tJ_Request.StatusTask", true));
		this.comboBox_0.DataSource = this.wfqozBoxRky;
		this.comboBox_0.DisplayMember = "Name";
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(74, 43);
		this.comboBox_0.Name = "comboBoxStatus";
		this.comboBox_0.Size = new Size(156, 21);
		this.comboBox_0.TabIndex = 4;
		this.comboBox_0.ValueMember = "Id";
		this.wfqozBoxRky.DataMember = "tR_Classifier";
		this.wfqozBoxRky.DataSource = this.dataSet_0;
		this.wfqozBoxRky.Filter = "ParentKey = ';Other;StatusTask;'";
		this.dataSet_0.DataSetName = "NewDataSet";
		this.dataSet_0.Tables.AddRange(new DataTable[]
		{
			this.dataTable_0
		});
		this.dataTable_0.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_0,
			this.dataColumn_1,
			this.dataColumn_2
		});
		this.dataTable_0.TableName = "tR_Classifier";
		this.dataColumn_0.ColumnName = "Id";
		this.dataColumn_0.DataType = typeof(int);
		this.dataColumn_1.ColumnName = "Name";
		this.dataColumn_2.ColumnName = "ParentKey";
		this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.class255_0, "tJ_Request.TypeTask", true));
		this.comboBox_1.DataSource = this.bindingSource_0;
		this.comboBox_1.DisplayMember = "Name";
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(74, 80);
		this.comboBox_1.Name = "comboBoxType";
		this.comboBox_1.Size = new Size(156, 21);
		this.comboBox_1.TabIndex = 5;
		this.comboBox_1.ValueMember = "Id";
		this.bindingSource_0.DataMember = "tR_Classifier";
		this.bindingSource_0.DataSource = this.dataSet_0;
		this.bindingSource_0.Filter = "ParentKey = ';Other;TypeTask;'";
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(245, 6);
		this.label_2.Name = "label4";
		this.label_2.Size = new Size(48, 13);
		this.label_2.TabIndex = 6;
		this.label_2.Text = "Резюме";
		this.Rghozrjmnoo.AcceptsTab = true;
		this.Rghozrjmnoo.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_Request.Comment", true));
		this.Rghozrjmnoo.Location = new Point(248, 22);
		this.Rghozrjmnoo.Name = "richTextBoxComment";
		this.Rghozrjmnoo.Size = new Size(218, 79);
		this.Rghozrjmnoo.TabIndex = 7;
		this.Rghozrjmnoo.Text = "";
		this.QnJozgvjYn5.DialogResult = DialogResult.OK;
		this.QnJozgvjYn5.Location = new Point(15, 119);
		this.QnJozgvjYn5.Name = "buttonOK";
		this.QnJozgvjYn5.Size = new Size(75, 23);
		this.QnJozgvjYn5.TabIndex = 8;
		this.QnJozgvjYn5.Text = "ОК";
		this.QnJozgvjYn5.UseVisualStyleBackColor = true;
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Location = new Point(391, 119);
		this.button_0.Name = "buttonCancel";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 9;
		this.button_0.Text = "Отмена";
		this.button_0.UseVisualStyleBackColor = true;
		base.AcceptButton = this.QnJozgvjYn5;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_0;
		base.ClientSize = new Size(478, 154);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.QnJozgvjYn5);
		base.Controls.Add(this.Rghozrjmnoo);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.comboBox_1);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.zdLozUtUnxW);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormEditRequeststatus";
		this.Text = "Изменение статуса";
		base.FormClosing += this.Form51_FormClosing;
		base.Load += this.Form51_Load;
		((ISupportInitialize)this.class255_0).EndInit();
		((ISupportInitialize)this.wfqozBoxRky).EndInit();
		((ISupportInitialize)this.dataSet_0).EndInit();
		((ISupportInitialize)this.dataTable_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private int int_0;

	private Label label_0;

	private TextBox textBox_0;

	private Label zdLozUtUnxW;

	private Label label_1;

	private ComboBox comboBox_0;

	private ComboBox comboBox_1;

	private Label label_2;

	private RichTextBoxWithContextMenu Rghozrjmnoo;

	private Button QnJozgvjYn5;

	private Button button_0;

	private BindingSource wfqozBoxRky;

	private DataSet dataSet_0;

	private DataTable dataTable_0;

	private DataColumn dataColumn_0;

	private DataColumn dataColumn_1;

	private DataColumn dataColumn_2;

	private Class255 class255_0;

	private BindingSource bindingSource_0;
}
