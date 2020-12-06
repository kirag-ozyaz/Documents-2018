using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using FormLbr;

internal partial class Form2 : FormBase
{
	[Browsable(false)]
	internal FormBase FormBase_0
	{
		get
		{
			return this.formBase_0;
		}
		set
		{
			this.formBase_0 = value;
		}
	}

	internal Form2()
	{
		
		
		this.method_0();
		this.dataGridViewExcelFilter_0.DataSource = this.class498_0;
	}

	private void dataGridViewExcelFilter_0_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
	{
	}

	private void dataGridViewExcelFilter_0_KeyDown(object sender, KeyEventArgs e)
	{
	}

	private void method_0()
	{
		this.panel_0 = new Panel();
		this.BvoZyvQnDo = new Button();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.class498_0 = new Class498();
		this.panel_0.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		((ISupportInitialize)this.class498_0).BeginInit();
		base.SuspendLayout();
		this.panel_0.Controls.Add(this.BvoZyvQnDo);
		this.panel_0.Dock = DockStyle.Bottom;
		this.panel_0.Location = new Point(0, 321);
		this.panel_0.Name = "panel1";
		this.panel_0.Size = new Size(632, 34);
		this.panel_0.TabIndex = 2;
		this.BvoZyvQnDo.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.BvoZyvQnDo.Location = new Point(561, 6);
		this.BvoZyvQnDo.Name = "btnClose";
		this.BvoZyvQnDo.Size = new Size(68, 23);
		this.BvoZyvQnDo.TabIndex = 13;
		this.BvoZyvQnDo.Text = "Закрыть";
		this.BvoZyvQnDo.UseVisualStyleBackColor = true;
		this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_0.BackgroundColor = SystemColors.Control;
		this.dataGridViewExcelFilter_0.BorderStyle = BorderStyle.None;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
		this.dataGridViewExcelFilter_0.Location = new Point(0, 0);
		this.dataGridViewExcelFilter_0.Name = "GridView";
		this.dataGridViewExcelFilter_0.NumbLineVisible = false;
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.Size = new Size(632, 321);
		this.dataGridViewExcelFilter_0.TabIndex = 5;
		this.dataGridViewExcelFilter_0.CellMouseDoubleClick += this.dataGridViewExcelFilter_0_CellMouseDoubleClick;
		this.dataGridViewExcelFilter_0.KeyDown += this.dataGridViewExcelFilter_0_KeyDown;
		this.class498_0.DataSetName = "dsCalc";
		this.class498_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(632, 355);
		base.Controls.Add(this.dataGridViewExcelFilter_0);
		base.Controls.Add(this.panel_0);
		base.Name = "SelectElementForm";
		this.Text = "SelectElemnetForm";
		this.panel_0.ResumeLayout(false);
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		((ISupportInitialize)this.class498_0).EndInit();
		base.ResumeLayout(false);
	}

	private FormBase formBase_0;

	private Panel panel_0;

	private Button BvoZyvQnDo;

	private Class498 class498_0;

	public DataGridViewExcelFilter dataGridViewExcelFilter_0;
}
