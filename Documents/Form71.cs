using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using FormLbr;

internal partial class Form71 : FormBase
{
	internal int Id { get; set; }

	internal string MakeupTrans { get; set; }

	internal float? RatedPower { get; set; }

	internal float? NoLoadLoss { get; set; }

	internal float? ShortCircuitLoss { get; set; }

	[CompilerGenerated]
	internal float? method_0()
	{
		return this.nullable_3;
	}

	[CompilerGenerated]
	internal void method_1(float? nullable_4)
	{
		this.nullable_3 = nullable_4;
	}

	internal Form71()
	{
		
		
		this.method_3();
	}

	private void Form71_Load(object sender, EventArgs e)
	{
		base.SelectSqlData(this.class498_0.vR_Transformer, true, "where deleted = 0 order by fullname", null, false, 0);
		this.toolStripTextBox_0.Select();
		this.toolStripTextBox_0.Focus();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
		{
			this.method_2(this.dataGridViewExcelFilter_0.Rows[e.RowIndex]);
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
	}

	private void method_2(DataGridViewRow dataGridViewRow_0)
	{
		this.Id = Convert.ToInt32(dataGridViewRow_0.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
		this.MakeupTrans = dataGridViewRow_0.Cells[this.dataGridViewFilterTextBoxColumn_0.Name].Value.ToString();
		if (dataGridViewRow_0.Cells[this.dataGridViewTextBoxColumn_1.Name].Value == DBNull.Value)
		{
			this.RatedPower = null;
		}
		else
		{
			this.RatedPower = new float?(Convert.ToSingle(dataGridViewRow_0.Cells[this.dataGridViewTextBoxColumn_1.Name].Value) / 1000f);
		}
		if (dataGridViewRow_0.Cells[this.dataGridViewTextBoxColumn_2.Name].Value == DBNull.Value)
		{
			this.NoLoadLoss = null;
		}
		else
		{
			this.NoLoadLoss = new float?(Convert.ToSingle(dataGridViewRow_0.Cells[this.dataGridViewTextBoxColumn_2.Name].Value));
		}
		if (dataGridViewRow_0.Cells[this.dataGridViewTextBoxColumn_3.Name].Value == DBNull.Value)
		{
			this.ShortCircuitLoss = null;
		}
		else
		{
			this.ShortCircuitLoss = new float?(Convert.ToSingle(dataGridViewRow_0.Cells[this.dataGridViewTextBoxColumn_3.Name].Value));
		}
		if (dataGridViewRow_0.Cells[this.dataGridViewTextBoxColumn_4.Name].Value == DBNull.Value)
		{
			this.method_1(null);
			return;
		}
		this.method_1(new float?(Convert.ToSingle(dataGridViewRow_0.Cells[this.dataGridViewTextBoxColumn_4.Name].Value)));
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (this.dataGridViewExcelFilter_0.SelectedRows.Count > 0)
		{
			this.method_2(this.dataGridViewExcelFilter_0.SelectedRows[0]);
			base.DialogResult = DialogResult.OK;
			base.Close();
			return;
		}
		MessageBox.Show("Не выбрана ни одна марка трансформатора");
	}

	private void toolStripTextBox_0_TextChanged(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(this.toolStripTextBox_0.Text))
		{
			this.bindingSource_0.Filter = "";
			return;
		}
		this.bindingSource_0.Filter = "fullName like '%" + this.toolStripTextBox_0.Text + "%'";
	}

	private void method_3()
	{
		this.icontainer_0 = new Container();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripLabel_0 = new ToolStripLabel();
		this.toolStripTextBox_0 = new ToolStripTextBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class498_0 = new Class498();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.toolStrip_0.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class498_0).BeginInit();
		base.SuspendLayout();
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripLabel_0,
			this.toolStripTextBox_0
		});
		this.toolStrip_0.Location = new Point(0, 0);
		this.toolStrip_0.Name = "toolStrip";
		this.toolStrip_0.Size = new Size(507, 25);
		this.toolStrip_0.TabIndex = 0;
		this.toolStrip_0.TabStop = true;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripLabel_0.Name = "toolStripLabel1";
		this.toolStripLabel_0.Size = new Size(48, 22);
		this.toolStripLabel_0.Text = "Фильтр";
		this.toolStripTextBox_0.Name = "txtFilter";
		this.toolStripTextBox_0.Size = new Size(300, 25);
		this.toolStripTextBox_0.TextChanged += this.toolStripTextBox_0_TextChanged;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.Location = new Point(12, 274);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 2;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.Location = new Point(420, 274);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 3;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToResizeRows = false;
		this.dataGridViewExcelFilter_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_0.BackgroundColor = SystemColors.Control;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewFilterTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewTextBoxColumn_3,
			this.dataGridViewTextBoxColumn_4
		});
		this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
		this.dataGridViewExcelFilter_0.Location = new Point(0, 28);
		this.dataGridViewExcelFilter_0.Name = "dgvTrans";
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.RowHeadersVisible = false;
		this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_0.Size = new Size(507, 240);
		this.dataGridViewExcelFilter_0.TabIndex = 1;
		this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
		this.bindingSource_0.DataMember = "vR_Transformer";
		this.bindingSource_0.DataSource = this.class498_0;
		this.class498_0.DataSetName = "dsCalc";
		this.class498_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_0.HeaderText = "id";
		this.dataGridViewTextBoxColumn_0.Name = "idDgvColumn";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewFilterTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "FullName";
		this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Марка трансформатора";
		this.dataGridViewFilterTextBoxColumn_0.Name = "fullNameDgvColumn";
		this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "Power";
		this.dataGridViewTextBoxColumn_1.HeaderText = "Power";
		this.dataGridViewTextBoxColumn_1.Name = "powerDgvColumn";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.Visible = false;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "NoLoadLoss";
		this.dataGridViewTextBoxColumn_2.HeaderText = "NoLoadLoss";
		this.dataGridViewTextBoxColumn_2.Name = "noLoadLossDgvColumn";
		this.dataGridViewTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewTextBoxColumn_2.Visible = false;
		this.dataGridViewTextBoxColumn_3.DataPropertyName = "ShortCircuitLoss";
		this.dataGridViewTextBoxColumn_3.HeaderText = "ShortCircuitLoss";
		this.dataGridViewTextBoxColumn_3.Name = "shortCircuitLossDgvColumn";
		this.dataGridViewTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewTextBoxColumn_3.Visible = false;
		this.dataGridViewTextBoxColumn_4.DataPropertyName = "HighVoltage";
		this.dataGridViewTextBoxColumn_4.HeaderText = "HighVoltage";
		this.dataGridViewTextBoxColumn_4.Name = "highVoltageDgvVoltage";
		this.dataGridViewTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewTextBoxColumn_4.Visible = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(507, 309);
		base.Controls.Add(this.dataGridViewExcelFilter_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.toolStrip_0);
		base.Name = "FormSelectTrans";
		this.Text = "Выбор марки трансформатора";
		base.Load += this.Form71_Load;
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class498_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private float? nullable_0;

	[CompilerGenerated]
	private float? nullable_1;

	[CompilerGenerated]
	private float? nullable_2;

	[CompilerGenerated]
	private float? nullable_3;

	private ToolStrip toolStrip_0;

	private Button button_0;

	private Button button_1;

	private DataGridViewExcelFilter dataGridViewExcelFilter_0;

	private Class498 class498_0;

	private BindingSource bindingSource_0;

	private ToolStripLabel toolStripLabel_0;

	private ToolStripTextBox toolStripTextBox_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;
}
