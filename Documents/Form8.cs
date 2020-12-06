using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataSql;
using FormLbr;

internal partial class Form8 : FormBase
{
	internal Form8()
	{
		
		this.dictionary_0 = new Dictionary<int, Class548.Class568>();
		
		this.method_0();
	}

	internal Form8(int int_2, SQLSettings sqlsettings_0)
	{
		
		this.dictionary_0 = new Dictionary<int, Class548.Class568>();
		
		this.method_0();
		base.PermissionsSql = false;
		this.SqlSettings = sqlsettings_0;
		this.int_0 = int_2;
		this.checkBox_0.Checked = true;
		if (this.int_1 != 0)
		{
			this.maskedTextBox_0.Enabled = false;
		}
		this.checkBox_1.Visible = (this.label_8.Visible = (this.dataGridViewCheckBoxColumn_1.Visible = (int_2 == 0)));
	}

	internal Form8(int int_2, int int_3, SQLSettings sqlsettings_0)
	{
		
		this.dictionary_0 = new Dictionary<int, Class548.Class568>();
		
		this.method_0();
		base.PermissionsSql = false;
		this.SqlSettings = sqlsettings_0;
		this.int_0 = int_2;
		this.int_1 = int_3;
		if (int_3 != 0)
		{
			this.maskedTextBox_0.Enabled = false;
		}
		this.checkBox_1.Visible = (this.label_8.Visible = (this.dataGridViewCheckBoxColumn_1.Visible = (int_2 == 0)));
	}

	public override SQLSettings SqlSettings
	{
		get
		{
			return base.SqlSettings;
		}
		set
		{
			base.SqlSettings = value;
			this.class587_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
			this.class588_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
			this.class589_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		}
	}

	private void maskedTextBox_0_TextChanged(object sender, EventArgs e)
	{
		if (this.maskedTextBox_0.Text.Length > 0)
		{
			this.class589_0.vmethod_0(this.class548_0.tblAbn, new int?(Convert.ToInt32(this.maskedTextBox_0.Text)));
		}
		else
		{
			this.class589_0.vmethod_0(this.class548_0.tblAbn, new int?(0));
		}
		this.int_1 = -5;
		if (this.bindingSource_0.Count > 0)
		{
			this.int_1 = ((Class548.Class571)((DataRowView)this.bindingSource_0[0]).Row).AbnID;
		}
		this.class588_0.vmethod_0(this.class548_0.tblAbnObj, new int?(this.int_1));
		this.bindingSource_3.Filter = "AbnId=" + this.int_1.ToString();
	}

	private void Form8_Load(object sender, EventArgs e)
	{
		this.class587_0.vmethod_0(this.class548_0.tblAbnAplForDisconReason, new int?(this.int_0));
		if (this.int_1 != 0)
		{
			this.maskedTextBox_0.Text = this.int_1.ToString();
		}
		foreach (object obj in this.bindingSource_3)
		{
			Class548.Class568 @class = (Class548.Class568)((DataRowView)obj).Row;
			foreach (object obj2 in this.bindingSource_1)
			{
				Class548.Class570 class2 = (Class548.Class570)((DataRowView)obj2).Row;
				if (class2.ObjId == @class.AbnObjId)
				{
					class2.Label = true;
					if (!@class.method_10())
					{
						class2.Reason = @class.Reason;
					}
					if (!@class.method_8())
					{
						class2.Point = @class.PlaceId;
					}
					if (!@class.method_12())
					{
						class2.Comments = @class.Comments;
					}
					this.dictionary_0.Add(class2.ObjId, @class);
					break;
				}
			}
		}
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		this.bindingSource_2.AddNew();
		Class548.Class569 @class = (Class548.Class569)((DataRowView)this.bindingSource_2.Current).Row;
		@class.Reason = this.toolStripTextBox_0.Text;
		@class.IdTypeApl = this.int_0;
		this.bindingSource_2.EndEdit();
		this.class587_0.vmethod_2(this.class548_0.tblAbnAplForDisconReason);
		this.toolStripTextBox_0.Text = string.Empty;
	}

	private void Form8_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			foreach (object obj in this.bindingSource_1)
			{
				Class548.Class570 @class = (Class548.Class570)((DataRowView)obj).Row;
				if (@class.Label)
				{
					Class548.Class568 class2;
					if (this.dictionary_0.ContainsKey(@class.ObjId))
					{
						class2 = this.dictionary_0[@class.ObjId];
					}
					else
					{
						this.bindingSource_3.AddNew();
						class2 = (Class548.Class568)((DataRowView)this.bindingSource_3.Current).Row;
					}
					class2.AbnId = this.int_1;
					class2.AbnObjId = @class.ObjId;
					if (!@class.method_4())
					{
						class2.PlaceId = @class.Point;
					}
					if (!@class.method_10())
					{
						class2.Reason = @class.Reason;
					}
					if (!@class.method_12())
					{
						class2.Comments = @class.Comments;
					}
					if (!((Class548.Class571)((DataRowView)this.bindingSource_0[0]).Row).method_4())
					{
						class2.DateDog = ((Class548.Class571)((DataRowView)this.bindingSource_0[0]).Row).DateDog;
					}
					if (!((Class548.Class571)((DataRowView)this.bindingSource_0[0]).Row).method_6())
					{
						class2.Code = ((Class548.Class571)((DataRowView)this.bindingSource_0[0]).Row).Code;
					}
					if (!((Class548.Class571)((DataRowView)this.bindingSource_0[0]).Row).method_2())
					{
						class2.NameShort = ((Class548.Class571)((DataRowView)this.bindingSource_0[0]).Row).NameShort;
					}
					if (!@class.method_0())
					{
						class2.AbnObj = @class.Title;
					}
					if (this.int_0 == 0 && !@class.method_14())
					{
						class2.IsFullRestriction = @class.IsFullRestriction;
					}
					this.bindingSource_3.EndEdit();
				}
				else if (!this.checkBox_0.Checked)
				{
					foreach (object obj2 in this.bindingSource_3)
					{
						Class548.Class568 class3 = (Class548.Class568)((DataRowView)obj2).Row;
						if (!class3.method_6() && @class.ObjId == class3.AbnObjId)
						{
							class3.Delete();
							this.bindingSource_3.EndEdit();
							break;
						}
					}
				}
			}
			if (this.checkBox_0.Checked)
			{
				((Class548.Class568)((DataRowView)this.bindingSource_3.Current).Row).NameShort = ((Class548.Class568)((DataRowView)this.bindingSource_3.Current).Row).NoDogAbn;
				((Class548.Class568)((DataRowView)this.bindingSource_3.Current).Row).AbnObj = ((Class548.Class568)((DataRowView)this.bindingSource_3.Current).Row).NoDogObj;
				if (this.comboBox_0.SelectedIndex == -1)
				{
					string text = this.comboBox_0.Text;
					this.bindingSource_2.AddNew();
					((Class548.Class569)((DataRowView)this.bindingSource_2.Current).Row).Reason = text;
					((Class548.Class569)((DataRowView)this.bindingSource_2.Current).Row).IdTypeApl = this.int_0;
					this.bindingSource_2.EndEdit();
					this.class587_0.vmethod_2(this.class548_0.tblAbnAplForDisconReason);
					((Class548.Class568)((DataRowView)this.bindingSource_3.Current).Row).Reason = ((Class548.Class569)((DataRowView)this.bindingSource_2.Current).Row).Id;
				}
				this.bindingSource_3.EndEdit();
			}
		}
		else
		{
			this.bindingSource_3.CancelEdit();
		}
		this.bindingSource_3.RemoveFilter();
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		if (this.checkBox_0.Checked)
		{
			this.maskedTextBox_0.Enabled = false;
			this.panel_0.Visible = true;
			this.bindingSource_3.AddNew();
			return;
		}
		this.maskedTextBox_0.Enabled = true;
		this.panel_0.Visible = false;
		this.bindingSource_3.RemoveCurrent();
	}

	private void method_0()
	{
		this.icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form8));
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.class548_0 = new Class548();
		this.class589_0 = new Class589();
		this.maskedTextBox_0 = new MaskedTextBox();
		this.label_2 = new Label();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		this.contextMenuStrip_0 = new ContextMenuStrip(this.icontainer_0);
		this.toolStripTextBox_0 = new ToolStripTextBox();
		this.toolStripMenuItem_0 = new ToolStripMenuItem();
		this.bindingSource_2 = new BindingSource(this.icontainer_0);
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewCheckBoxColumn_1 = new DataGridViewCheckBoxColumn();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.class588_0 = new Class588();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.class587_0 = new Class587();
		this.bindingSource_3 = new BindingSource(this.icontainer_0);
		this.checkBox_0 = new CheckBox();
		this.panel_0 = new Panel();
		this.checkBox_1 = new CheckBox();
		this.comboBox_0 = new ComboBox();
		this.textBox_3 = new TextBox();
		this.textBox_0 = new TextBox();
		this.textBox_1 = new TextBox();
		this.textBox_2 = new TextBox();
		this.label_8 = new Label();
		this.label_7 = new Label();
		this.label_3 = new Label();
		this.label_4 = new Label();
		this.label_5 = new Label();
		this.label_6 = new Label();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.class548_0).BeginInit();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		this.contextMenuStrip_0.SuspendLayout();
		((ISupportInitialize)this.bindingSource_2).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		((ISupportInitialize)this.bindingSource_3).BeginInit();
		this.panel_0.SuspendLayout();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 9);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(76, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Код абонента";
		this.label_1.AutoSize = true;
		this.label_1.DataBindings.Add(new Binding("Text", this.bindingSource_0, "NameShort", true));
		this.label_1.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, 204);
		this.label_1.Location = new Point(12, 62);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(0, 24);
		this.label_1.TabIndex = 0;
		this.bindingSource_0.DataMember = "tblAbn";
		this.bindingSource_0.DataSource = this.class548_0;
		this.class548_0.DataSetName = "OrgDataSet";
		this.class548_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.class589_0.Boolean_0 = true;
		this.maskedTextBox_0.Location = new Point(155, 6);
		this.maskedTextBox_0.Mask = "9999999999";
		this.maskedTextBox_0.Name = "maskedTextBoxCode";
		this.maskedTextBox_0.Size = new Size(210, 20);
		this.maskedTextBox_0.TabIndex = 2;
		this.maskedTextBox_0.TextChanged += this.maskedTextBox_0_TextChanged;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(12, 34);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(52, 13);
		this.label_2.TabIndex = 0;
		this.label_2.Text = "Абонент:";
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.AutoGenerateColumns = false;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewCheckBoxColumn_0,
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewComboBoxColumn_0,
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewCheckBoxColumn_1
		});
		this.dataGridView_0.DataSource = this.bindingSource_1;
		this.dataGridView_0.Location = new Point(12, 113);
		this.dataGridView_0.Name = "dataGridView1";
		this.dataGridView_0.RowHeadersWidth = 20;
		this.dataGridView_0.Size = new Size(511, 225);
		this.dataGridView_0.TabIndex = 3;
		this.dataGridViewCheckBoxColumn_0.DataPropertyName = "Label";
		this.dataGridViewCheckBoxColumn_0.HeaderText = "";
		this.dataGridViewCheckBoxColumn_0.Name = "labelDataGridViewCheckBoxColumn";
		this.dataGridViewCheckBoxColumn_0.Width = 20;
		this.dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "Title";
		this.dataGridViewTextBoxColumn_0.HeaderText = "Наименование объекта";
		this.dataGridViewTextBoxColumn_0.Name = "pointDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "Point";
		this.dataGridViewTextBoxColumn_1.FillWeight = 75f;
		this.dataGridViewTextBoxColumn_1.HeaderText = "Пункт ввода ограничения";
		this.dataGridViewTextBoxColumn_1.Name = "titleDataGridViewTextBoxColumn";
		this.dataGridViewComboBoxColumn_0.ContextMenuStrip = this.contextMenuStrip_0;
		this.dataGridViewComboBoxColumn_0.DataPropertyName = "Reason";
		this.dataGridViewComboBoxColumn_0.DataSource = this.bindingSource_2;
		this.dataGridViewComboBoxColumn_0.DisplayMember = "Reason";
		this.dataGridViewComboBoxColumn_0.HeaderText = "Причина";
		this.dataGridViewComboBoxColumn_0.Name = "Reason";
		this.dataGridViewComboBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_0.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_0.ValueMember = "Id";
		this.contextMenuStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripTextBox_0,
			this.toolStripMenuItem_0
		});
		this.contextMenuStrip_0.Name = "contextMenuStripAddReason";
		this.contextMenuStrip_0.Size = new Size(161, 51);
		this.toolStripTextBox_0.BackColor = Color.White;
		this.toolStripTextBox_0.Name = "toolStripTextBoxInputReason";
		this.toolStripTextBox_0.Size = new Size(100, 23);
		this.toolStripMenuItem_0.Name = "toolStripMenuItemAddReason";
		this.toolStripMenuItem_0.Size = new Size(160, 22);
		this.toolStripMenuItem_0.Text = "Добавить";
		this.toolStripMenuItem_0.Click += this.toolStripMenuItem_0_Click;
		this.bindingSource_2.DataMember = "tblAbnAplForDisconReason";
		this.bindingSource_2.DataSource = this.class548_0;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "Comments";
		this.dataGridViewTextBoxColumn_2.HeaderText = "Примечание";
		this.dataGridViewTextBoxColumn_2.Name = "Comments";
		this.dataGridViewCheckBoxColumn_1.DataPropertyName = "IsFullRestriction";
		this.dataGridViewCheckBoxColumn_1.HeaderText = "Полное отключение";
		this.dataGridViewCheckBoxColumn_1.Name = "IsFullRestriction";
		this.dataGridViewCheckBoxColumn_1.Width = 70;
		this.bindingSource_1.DataMember = "tblAbnObj";
		this.bindingSource_1.DataSource = this.class548_0;
		this.class588_0.Boolean_0 = true;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(367, 352);
		this.button_0.Name = "buttonAdd";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 4;
		this.button_0.Text = "Добавить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(448, 352);
		this.button_1.Name = "buttonCancel";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 4;
		this.button_1.Text = "Отмена";
		this.button_1.UseVisualStyleBackColor = true;
		this.class587_0.Boolean_0 = true;
		this.bindingSource_3.DataMember = "tblAbnAplForDisconObjects";
		this.bindingSource_3.DataSource = this.class548_0;
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Location = new Point(389, 8);
		this.checkBox_0.Name = "checkBox1";
		this.checkBox_0.Size = new Size(94, 17);
		this.checkBox_0.TabIndex = 5;
		this.checkBox_0.Text = "без договора";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
		this.panel_0.Controls.Add(this.checkBox_1);
		this.panel_0.Controls.Add(this.comboBox_0);
		this.panel_0.Controls.Add(this.textBox_3);
		this.panel_0.Controls.Add(this.textBox_0);
		this.panel_0.Controls.Add(this.textBox_1);
		this.panel_0.Controls.Add(this.textBox_2);
		this.panel_0.Controls.Add(this.label_8);
		this.panel_0.Controls.Add(this.label_7);
		this.panel_0.Controls.Add(this.label_3);
		this.panel_0.Controls.Add(this.label_4);
		this.panel_0.Controls.Add(this.label_5);
		this.panel_0.Controls.Add(this.label_6);
		this.panel_0.Location = new Point(0, 33);
		this.panel_0.Name = "panelNoDog";
		this.panel_0.Size = new Size(533, 306);
		this.panel_0.TabIndex = 6;
		this.panel_0.Visible = false;
		this.checkBox_1.AutoSize = true;
		this.checkBox_1.DataBindings.Add(new Binding("Checked", this.bindingSource_3, "IsFullRestriction", true));
		this.checkBox_1.Location = new Point(154, 158);
		this.checkBox_1.Name = "checkBox2";
		this.checkBox_1.Size = new Size(15, 14);
		this.checkBox_1.TabIndex = 7;
		this.checkBox_1.UseVisualStyleBackColor = true;
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.bindingSource_3, "Reason", true));
		this.comboBox_0.DataSource = this.bindingSource_2;
		this.comboBox_0.DisplayMember = "Reason";
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(153, 131);
		this.comboBox_0.Name = "comboBox1";
		this.comboBox_0.Size = new Size(368, 21);
		this.comboBox_0.TabIndex = 2;
		this.comboBox_0.ValueMember = "Id";
		this.textBox_3.DataBindings.Add(new Binding("Text", this.bindingSource_3, "Comments", true));
		this.textBox_3.Location = new Point(154, 178);
		this.textBox_3.Multiline = true;
		this.textBox_3.Name = "textBox4";
		this.textBox_3.Size = new Size(367, 113);
		this.textBox_3.TabIndex = 1;
		this.textBox_0.DataBindings.Add(new Binding("Text", this.bindingSource_3, "PlaceId", true));
		this.textBox_0.Location = new Point(154, 88);
		this.textBox_0.Name = "textBox3";
		this.textBox_0.Size = new Size(367, 20);
		this.textBox_0.TabIndex = 1;
		this.textBox_1.DataBindings.Add(new Binding("Text", this.bindingSource_3, "NoDogObj", true));
		this.textBox_1.Location = new Point(154, 48);
		this.textBox_1.Name = "textBox2";
		this.textBox_1.Size = new Size(367, 20);
		this.textBox_1.TabIndex = 1;
		this.textBox_2.DataBindings.Add(new Binding("Text", this.bindingSource_3, "NoDogAbn", true));
		this.textBox_2.Location = new Point(154, 8);
		this.textBox_2.Name = "textBox1";
		this.textBox_2.Size = new Size(367, 20);
		this.textBox_2.TabIndex = 1;
		this.label_8.AutoSize = true;
		this.label_8.Location = new Point(12, 158);
		this.label_8.Name = "label9";
		this.label_8.Size = new Size(115, 13);
		this.label_8.TabIndex = 0;
		this.label_8.Text = "Полное ограничение:";
		this.label_7.AutoSize = true;
		this.label_7.Location = new Point(12, 181);
		this.label_7.Name = "label8";
		this.label_7.Size = new Size(73, 13);
		this.label_7.TabIndex = 0;
		this.label_7.Text = "Примечание:";
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 134);
		this.label_3.Name = "label7";
		this.label_3.Size = new Size(53, 13);
		this.label_3.TabIndex = 0;
		this.label_3.Text = "Причина:";
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(11, 91);
		this.label_4.Name = "label6";
		this.label_4.Size = new Size(140, 13);
		this.label_4.TabIndex = 0;
		this.label_4.Text = "Пункт ввода ограничения:";
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(11, 51);
		this.label_5.Name = "label5";
		this.label_5.Size = new Size(48, 13);
		this.label_5.TabIndex = 0;
		this.label_5.Text = "Объект:";
		this.label_6.AutoSize = true;
		this.label_6.Location = new Point(11, 15);
		this.label_6.Name = "label4";
		this.label_6.Size = new Size(52, 13);
		this.label_6.TabIndex = 0;
		this.label_6.Text = "Абонент:";
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(535, 387);
		base.Controls.Add(this.panel_0);
		base.Controls.Add(this.checkBox_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.dataGridView_0);
		base.Controls.Add(this.maskedTextBox_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.label_0);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "FormAddObjects";
		this.Text = "Форма добавления объекта";
		base.FormClosing += this.Form8_FormClosing;
		base.Load += this.Form8_Load;
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.class548_0).EndInit();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		this.contextMenuStrip_0.ResumeLayout(false);
		this.contextMenuStrip_0.PerformLayout();
		((ISupportInitialize)this.bindingSource_2).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		((ISupportInitialize)this.bindingSource_3).EndInit();
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private int int_0;

	private int int_1;

	private Dictionary<int, Class548.Class568> dictionary_0;

	private Label label_0;

	private Label label_1;

	private BindingSource bindingSource_0;

	private Class548 class548_0;

	private Class589 class589_0;

	private MaskedTextBox maskedTextBox_0;

	private Label label_2;

	private DataGridView dataGridView_0;

	private BindingSource bindingSource_1;

	private Class588 class588_0;

	private Button button_0;

	private Button button_1;

	private BindingSource bindingSource_2;

	private Class587 class587_0;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripTextBox toolStripTextBox_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	public BindingSource bindingSource_3;

	private CheckBox checkBox_0;

	private Panel panel_0;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private Label label_3;

	private Label label_4;

	private Label label_5;

	private Label label_6;

	private ComboBox comboBox_0;

	private TextBox textBox_3;

	private Label label_7;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_1;

	private CheckBox checkBox_1;

	private Label label_8;
}
