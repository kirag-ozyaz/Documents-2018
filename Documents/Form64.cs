using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Constants;
using ControlsLbr.DataGridViewExcelFilter;
using Documents.Properties;
using FormLbr;

internal partial class Form64 : FormBase
{
	internal Form64()
	{
		
		
		this.method_1();
	}

	private void method_0()
	{
		string text = string.Empty;
		foreach (object obj in Enum.GetValues(typeof(AbnType)))
		{
			AbnType abnType = (AbnType)obj;
			if (abnType != AbnType.KontragentFL && abnType != AbnType.Private && abnType != AbnType.PrivateNoDog)
			{
				if (!string.IsNullOrEmpty(text))
				{
					text += ",";
				}
				string str = text;
				int num = (int)abnType;
				text = str + num.ToString();
			}
		}
		this.dataTable_1 = base.SelectSqlData("tAbn", true, string.Concat(new string[]
		{
			" where typeAbn in (",
			text,
			") and deleted = 0  and id not in (select idAbn from tAbnType where typekontragent = ",
			1046.ToString(),
			") order by name"
		}));
		this.bindingSource_0.DataSource = this.dataTable_1;
		this.dataTable_0 = base.SelectSqlData("vAbnType", true, " where typeKontragent = " + 1046.ToString() + " order by name");
		base.SelectSqlData(this.class130_0, this.class130_0.tAbnType, true, "where typeKontragent = " + 1046.ToString());
		this.bindingSource_1.DataSource = this.dataTable_0;
	}

	private void Form64_Load(object sender, EventArgs e)
	{
		this.method_0();
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		this.bindingSource_0.Filter = " name like '%" + this.textBox_0.Text + "%'";
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		this.bindingSource_1.Filter = " name like '%" + this.textBox_1.Text + "%'";
	}

	private void Form64_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			base.DeleteSqlData(this.class130_0, this.class130_0.tAbnType);
			foreach (DataRow dataRow in this.class130_0.tAbn)
			{
				DataRow[] array = this.class130_0.tAbnType.Select("idAbn = " + dataRow["id"].ToString());
				if (array.Length != 0)
				{
					int num = base.InsertSqlDataOneRow(dataRow);
					array[0]["idAbn"] = num;
					array[0].EndEdit();
					base.InsertSqlDataOneRow(array[0]);
					array[0].AcceptChanges();
				}
				else
				{
					dataRow.AcceptChanges();
					dataRow.Delete();
				}
			}
			base.InsertSqlData(this.class130_0, this.class130_0.tAbnType);
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		if (this.dataGridViewExcelFilter_0.CurrentRow != null)
		{
			int num = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
			DataRow dataRow = this.dataTable_0.NewRow();
			dataRow["Name"] = this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_1.Name].Value.ToString();
			dataRow["idAbn"] = num;
			this.dataTable_0.Rows.Add(dataRow);
			dataRow = this.class130_0.tAbnType.NewRow();
			dataRow["idAbn"] = num;
			dataRow["typeKontragent"] = 1046;
			this.class130_0.tAbnType.Rows.Add(dataRow);
			this.dataGridViewExcelFilter_0.Rows.Remove(this.dataGridViewExcelFilter_0.CurrentRow);
			this.textBox_1.Text = "";
		}
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		if (this.dataGridViewExcelFilter_1.CurrentRow != null)
		{
			int num = Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_3.Name].Value);
			DataRow[] array = this.class130_0.tAbnType.Select("idAbn = " + num.ToString());
			if (array.Length != 0)
			{
				array[0].Delete();
			}
			DataRow dataRow = this.dataTable_1.NewRow();
			dataRow["Name"] = this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_2.Name].Value.ToString();
			dataRow["idAbn"] = num;
			this.dataTable_1.Rows.Add(dataRow);
			this.dataGridViewExcelFilter_1.Rows.Remove(this.dataGridViewExcelFilter_1.CurrentRow);
			this.textBox_0.Text = "";
		}
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(this.textBox_0.Text))
		{
			DataRow dataRow = this.class130_0.tAbn.NewRow();
			dataRow["CodeAbonent"] = -1;
			dataRow["Name"] = this.textBox_0.Text;
			dataRow["TypeAbn"] = 1038;
			dataRow["idWorker"] = -1;
			dataRow["deleted"] = 0;
			this.class130_0.tAbn.Rows.Add(dataRow);
			dataRow = this.dataTable_0.NewRow();
			dataRow["idAbn"] = this.class130_0.tAbn.Rows[this.class130_0.tAbn.Rows.Count - 1]["id"];
			dataRow["Name"] = this.textBox_0.Text;
			this.dataTable_0.Rows.Add(dataRow);
			dataRow = this.class130_0.tAbnType.NewRow();
			dataRow["idAbn"] = this.class130_0.tAbn.Rows[this.class130_0.tAbn.Rows.Count - 1]["id"];
			dataRow["typeKontragent"] = 1046;
			this.class130_0.tAbnType.Rows.Add(dataRow);
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void method_1()
	{
		this.icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form64));
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.class130_0 = new DataSetExcavation();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.splitContainer_0 = new SplitContainer();
		this.toolStrip_1 = new ToolStrip();
		this.toolStripButton_1 = new ToolStripButton();
		this.toolStripButton_2 = new ToolStripButton();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.label_1 = new Label();
		this.textBox_1 = new TextBox();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		((ISupportInitialize)this.class130_0).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
		this.splitContainer_0.Panel1.SuspendLayout();
		this.splitContainer_0.Panel2.SuspendLayout();
		this.splitContainer_0.SuspendLayout();
		this.toolStrip_1.SuspendLayout();
		this.toolStrip_0.SuspendLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(14, 7);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(65, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Контрагент";
		this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.Location = new Point(85, 3);
		this.textBox_0.Name = "textBoxKontragent";
		this.textBox_0.Size = new Size(159, 20);
		this.textBox_0.TabIndex = 1;
		this.textBox_0.TextChanged += this.textBox_0_TextChanged;
		this.class130_0.DataSetName = "DataSetExcavation";
		this.class130_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.bindingSource_0.DataMember = "tAbn";
		this.bindingSource_0.DataSource = this.class130_0;
		this.bindingSource_0.Sort = "name";
		this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToResizeColumns = false;
		this.dataGridViewExcelFilter_0.AllowUserToResizeRows = false;
		this.dataGridViewExcelFilter_0.AllowUserToVisibleColumns = false;
		dataGridViewCellStyle.BackColor = Color.FromArgb(224, 224, 224);
		this.dataGridViewExcelFilter_0.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
		this.dataGridViewExcelFilter_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1
		});
		this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
		this.dataGridViewExcelFilter_0.Location = new Point(0, 29);
		this.dataGridViewExcelFilter_0.MultiSelect = false;
		this.dataGridViewExcelFilter_0.Name = "dgvKontragent";
		this.dataGridViewExcelFilter_0.ReadOnly = true;
		this.dataGridViewExcelFilter_0.RowHeadersVisible = false;
		this.dataGridViewExcelFilter_0.RowHeadersWidth = 21;
		this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_0.Size = new Size(268, 203);
		this.dataGridViewExcelFilter_0.TabIndex = 2;
		this.dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_0.HeaderText = "id";
		this.dataGridViewTextBoxColumn_0.Name = "idKontragentDgvColumn";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "Name";
		this.dataGridViewTextBoxColumn_1.HeaderText = "Контрагент";
		this.dataGridViewTextBoxColumn_1.Name = "nameKontragentDgvColumn";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(15, 240);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 3;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(516, 240);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 4;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.splitContainer_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.splitContainer_0.Location = new Point(-2, -1);
		this.splitContainer_0.Name = "splitContainer";
		this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_1);
		this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_0);
		this.splitContainer_0.Panel1.Controls.Add(this.label_0);
		this.splitContainer_0.Panel1.Controls.Add(this.textBox_0);
		this.splitContainer_0.Panel1.Controls.Add(this.dataGridViewExcelFilter_0);
		this.splitContainer_0.Panel2.Controls.Add(this.dataGridViewExcelFilter_1);
		this.splitContainer_0.Panel2.Controls.Add(this.label_1);
		this.splitContainer_0.Panel2.Controls.Add(this.textBox_1);
		this.splitContainer_0.Size = new Size(606, 235);
		this.splitContainer_0.SplitterDistance = 303;
		this.splitContainer_0.TabIndex = 5;
		this.toolStrip_1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.toolStrip_1.Dock = DockStyle.None;
		this.toolStrip_1.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_1,
			this.toolStripButton_2
		});
		this.toolStrip_1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
		this.toolStrip_1.Location = new Point(279, 81);
		this.toolStrip_1.Name = "toolStripMove";
		this.toolStrip_1.Size = new Size(24, 48);
		this.toolStrip_1.TabIndex = 4;
		this.toolStrip_1.Text = "toolStrip1";
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = Resources.Bitmap_1;
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "toolBtnAddExcavation";
		this.toolStripButton_1.Size = new Size(22, 20);
		this.toolStripButton_1.Text = "Добавить в список";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Image = Resources.Bitmap_2;
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "toolBtnRemoveEcxcavation";
		this.toolStripButton_2.Size = new Size(22, 20);
		this.toolStripButton_2.Text = "Убрать из списка";
		this.toolStripButton_2.Click += this.toolStripButton_2_Click;
		this.toolStrip_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.toolStrip_0.Dock = DockStyle.None;
		this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0
		});
		this.toolStrip_0.Location = new Point(246, 4);
		this.toolStrip_0.Name = "toolStripAdd";
		this.toolStrip_0.Size = new Size(26, 25);
		this.toolStrip_0.TabIndex = 3;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources._1364474610_agt_update_misc;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtnAddNewKontragent";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Добавить контрагента";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.dataGridViewExcelFilter_1.AllowUserToAddRows = false;
		this.dataGridViewExcelFilter_1.AllowUserToDeleteRows = false;
		this.dataGridViewExcelFilter_1.AllowUserToResizeColumns = false;
		this.dataGridViewExcelFilter_1.AllowUserToResizeRows = false;
		this.dataGridViewExcelFilter_1.AllowUserToVisibleColumns = false;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(224, 224, 224);
		this.dataGridViewExcelFilter_1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridViewExcelFilter_1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
		this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewTextBoxColumn_3
		});
		this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_1;
		this.dataGridViewExcelFilter_1.Location = new Point(-1, 32);
		this.dataGridViewExcelFilter_1.MultiSelect = false;
		this.dataGridViewExcelFilter_1.Name = "dgvContractor";
		this.dataGridViewExcelFilter_1.ReadOnly = true;
		this.dataGridViewExcelFilter_1.RowHeadersVisible = false;
		this.dataGridViewExcelFilter_1.RowHeadersWidth = 21;
		this.dataGridViewExcelFilter_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewExcelFilter_1.Size = new Size(300, 203);
		this.dataGridViewExcelFilter_1.TabIndex = 4;
		this.bindingSource_1.Sort = "name";
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(15, 11);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(62, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Подрядчик";
		this.textBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_1.Location = new Point(86, 4);
		this.textBox_1.Name = "textBoxContractor";
		this.textBox_1.Size = new Size(171, 20);
		this.textBox_1.TabIndex = 3;
		this.textBox_1.TextChanged += this.textBox_1_TextChanged;
		this.dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "name";
		this.dataGridViewTextBoxColumn_2.HeaderText = "Подрядчик";
		this.dataGridViewTextBoxColumn_2.Name = "nameContractordgvColumn";
		this.dataGridViewTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewTextBoxColumn_3.DataPropertyName = "idAbn";
		this.dataGridViewTextBoxColumn_3.HeaderText = "id";
		this.dataGridViewTextBoxColumn_3.Name = "idContractorDgvColumn";
		this.dataGridViewTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewTextBoxColumn_3.Visible = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(603, 275);
		base.Controls.Add(this.splitContainer_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "FormFindAddKontragentExcavation";
		this.Text = "Подрядчики";
		base.FormClosing += this.Form64_FormClosing;
		base.Load += this.Form64_Load;
		((ISupportInitialize)this.class130_0).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
		this.splitContainer_0.Panel1.ResumeLayout(false);
		this.splitContainer_0.Panel1.PerformLayout();
		this.splitContainer_0.Panel2.ResumeLayout(false);
		this.splitContainer_0.Panel2.PerformLayout();
		this.splitContainer_0.ResumeLayout(false);
		this.toolStrip_1.ResumeLayout(false);
		this.toolStrip_1.PerformLayout();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		base.ResumeLayout(false);
	}

	internal static void ILyioG08HJxbiOQdlrOR(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private DataTable dataTable_0;

	private DataTable dataTable_1;

	private Label label_0;

	private TextBox textBox_0;

	private DataSetExcavation class130_0;

	private BindingSource bindingSource_0;

	private DataGridViewExcelFilter dataGridViewExcelFilter_0;

	private Button button_0;

	private Button button_1;

	private SplitContainer splitContainer_0;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private DataGridViewExcelFilter dataGridViewExcelFilter_1;

	private Label label_1;

	private TextBox textBox_1;

	private ToolStrip toolStrip_1;

	private ToolStripButton toolStripButton_1;

	private ToolStripButton toolStripButton_2;

	private BindingSource bindingSource_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;
}
