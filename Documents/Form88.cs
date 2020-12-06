using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using FormLbr;

internal partial class Form88 : FormBase
{
	internal int? method_0()
	{
		if (this.bindingSource_0.Current != null)
		{
			return new int?(Convert.ToInt32(((DataRowView)this.bindingSource_0.Current).Row["id"]));
		}
		return null;
	}

	internal Form88()
	{
		
		
		this.method_3();
		this.method_1();
		this.toolStrip_0.Items.Insert(1, new ToolStripControlHost(this.dateTimePicker_0));
		this.toolStrip_0.Items.Insert(3, new ToolStripControlHost(this.dateTimePicker_1));
	}

	private void method_1()
	{
		this.dateTimePicker_0 = new DateTimePicker();
		this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year, 1, 1);
		this.dateTimePicker_1 = new DateTimePicker();
		this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year + 1, 1, 1).AddMilliseconds(-1.0);
	}

	private void Form88_Load(object sender, EventArgs e)
	{
		this.method_2();
	}

	private void method_2()
	{
		base.SelectSqlData(this.class171_0.vJ_Damage, true, string.Format(" where dateDoc >= '{0}' and dateDoc <= '{1}' \r\n                and typeDoc = {2} order by dateDoc desc", this.dateTimePicker_0.Value.ToString("yyyyMMdd"), this.dateTimePicker_1.Value.ToString("yyyyMMdd"), 1402), null, false, 0);
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		this.method_2();
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		this.method_1();
		this.method_2();
	}

	private void Form88_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK && this.bindingSource_0.Current == null)
		{
			MessageBox.Show("Не выбран ни один документ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			e.Cancel = true;
			return;
		}
	}

	private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
	}

	private void method_3()
	{
		this.icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form88));
		this.toolStrip_0 = new ToolStrip();
		this.toolStripLabel_0 = new ToolStripLabel();
		this.toolStripLabel_1 = new ToolStripLabel();
		this.toolStripSeparator_0 = new ToolStripSeparator();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripButton_1 = new ToolStripButton();
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
		this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class171_0 = new Class171();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.toolStrip_0.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class171_0).BeginInit();
		base.SuspendLayout();
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripLabel_0,
			this.toolStripLabel_1,
			this.toolStripSeparator_0,
			this.toolStripButton_0,
			this.toolStripButton_1
		});
		this.toolStrip_0.Location = new Point(0, 0);
		this.toolStrip_0.Name = "toolStrip";
		this.toolStrip_0.Size = new Size(738, 25);
		this.toolStrip_0.TabIndex = 0;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripLabel_0.Name = "toolStripLabel1";
		this.toolStripLabel_0.Size = new Size(47, 22);
		this.toolStripLabel_0.Text = "Дата от";
		this.toolStripLabel_1.Name = "toolStripLabel2";
		this.toolStripLabel_1.Size = new Size(20, 22);
		this.toolStripLabel_1.Text = "до";
		this.toolStripSeparator_0.Name = "toolStripSeparator1";
		this.toolStripSeparator_0.Size = new Size(6, 25);
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("btnApplyFilter.Image");
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "btnApplyFilter";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Применить фильтр";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("btnResetFilter.Image");
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "btnResetFilter";
		this.toolStripButton_1.Size = new Size(23, 22);
		this.toolStripButton_1.Text = "Сбросить фильтр";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewFilterTextBoxColumn_0,
			this.dataGridViewFilterTextBoxColumn_1,
			this.dataGridViewFilterTextBoxColumn_2
		});
		this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
		this.dataGridViewExcelFilter_0.Location = new Point(0, 28);
		this.dataGridViewExcelFilter_0.Name = "dgv";
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.RowHeadersWidth = 21;
		this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_0.Size = new Size(738, 270);
		this.dataGridViewExcelFilter_0.TabIndex = 1;
		this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
		this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "numrequest";
		this.dataGridViewFilterTextBoxColumn_0.FilteringEnabled = false;
		this.dataGridViewFilterTextBoxColumn_0.HeaderText = "№ документа";
		this.dataGridViewFilterTextBoxColumn_0.Name = "dataGridViewTextBoxColumn4";
		this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "dateDoc";
		this.dataGridViewFilterTextBoxColumn_1.FilteringEnabled = false;
		this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Дата документа";
		this.dataGridViewFilterTextBoxColumn_1.Name = "dataGridViewTextBoxColumn3";
		this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewFilterTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "schmObjName";
		this.dataGridViewFilterTextBoxColumn_2.FilteringEnabled = false;
		this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Электроустановка";
		this.dataGridViewFilterTextBoxColumn_2.Name = "schmObjName";
		this.dataGridViewFilterTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
		this.bindingSource_0.DataMember = "vJ_Damage";
		this.bindingSource_0.DataSource = this.class171_0;
		this.class171_0.DataSetName = "DataSetDamage";
		this.class171_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(12, 304);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 2;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(651, 304);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 3;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_1;
		base.ClientSize = new Size(738, 339);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.dataGridViewExcelFilter_0);
		base.Controls.Add(this.toolStrip_0);
		base.Name = "FormSelectDamage";
		this.Text = "Выбор дефекта";
		base.FormClosing += this.Form88_FormClosing;
		base.Load += this.Form88_Load;
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class171_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	internal static void xOPK13rJFG6VHk1V37I6(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private DateTimePicker dateTimePicker_0;

	private DateTimePicker dateTimePicker_1;

	private ToolStrip toolStrip_0;

	private DataGridViewExcelFilter dataGridViewExcelFilter_0;

	private Button button_0;

	private Button button_1;

	private ToolStripLabel toolStripLabel_0;

	private ToolStripLabel toolStripLabel_1;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private BindingSource bindingSource_0;

	private Class171 class171_0;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

	private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;
}
