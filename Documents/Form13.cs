using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataSql;
using FormLbr;

internal partial class Form13 : FormBase
{
	internal Form13(int int_2, string string_1, bool bool_1, int int_3, SQLSettings sqlsettings_0)
	{
		
		this.bool_0 = true;
		this.dictionary_0 = new Dictionary<int, Class548.Class568>();
		this.dictionary_1 = new Dictionary<string, Class548.Class568>();
		this.dictionary_2 = new Dictionary<int, Class548.Class572>();
		
		this.method_0();
		this.SqlSettings = sqlsettings_0;
		this.int_0 = int_2;
		this.string_0 = string_1;
		this.bool_0 = bool_1;
		this.int_1 = int_3;
		if (string_1 != "")
		{
			this.maskedTextBox_0.Enabled = false;
		}
		this.class596_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class590_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class587_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class595_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class588_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class589_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
	}

	internal Form13(int int_2, int int_3, bool bool_1, int int_4, SQLSettings sqlsettings_0)
	{
		
		this.bool_0 = true;
		this.dictionary_0 = new Dictionary<int, Class548.Class568>();
		this.dictionary_1 = new Dictionary<string, Class548.Class568>();
		this.dictionary_2 = new Dictionary<int, Class548.Class572>();
		
		this.method_0();
		this.SqlSettings = sqlsettings_0;
		this.int_0 = int_2;
		string text = int_3.ToString();
		int num = 10 - text.Length;
		this.int_1 = int_4;
		for (int i = 0; i < num; i++)
		{
			this.string_0 += "0";
		}
		this.string_0 += text;
		if (this.string_0 != "")
		{
			this.maskedTextBox_0.Enabled = false;
		}
		this.bool_0 = bool_1;
		this.class596_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class590_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class586_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class587_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class595_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class588_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		this.class589_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
	}

	private void maskedTextBox_0_TextChanged(object sender, EventArgs e)
	{
		if (this.maskedTextBox_0.Text.Length > 0)
		{
			if (this.bool_0)
			{
				this.class595_0.vmethod_0(this.class548_0.tblAbnObj2, new int?(this.int_1), Convert.ToInt32(this.maskedTextBox_0.Text));
				return;
			}
			this.class596_0.vmethod_0(this.class548_0.tblAbnAplForDisconIndividualUsersForCancel, new int?(this.int_1), Convert.ToInt32(this.maskedTextBox_0.Text));
			return;
		}
		else
		{
			if (this.bool_0)
			{
				this.class595_0.vmethod_0(this.class548_0.tblAbnObj2, new int?(this.int_1), -1);
				return;
			}
			this.class596_0.vmethod_0(this.class548_0.tblAbnAplForDisconIndividualUsersForCancel, new int?(this.int_1), -1);
			return;
		}
	}

	private void Form13_Load(object sender, EventArgs e)
	{
		this.class587_0.vmethod_0(this.class548_0.tblAbnAplForDisconReason, new int?(this.int_0));
		if (this.string_0 != "")
		{
			this.maskedTextBox_0.Text = this.string_0;
		}
		if (this.bool_0)
		{
			using (IEnumerator enumerator = this.bindingSource_2.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Class548.Class568 @class = (Class548.Class568)((DataRowView)obj).Row;
					foreach (object obj2 in this.bindingSource_3)
					{
						Class548.Class577 class2 = (Class548.Class577)((DataRowView)obj2).Row;
						if (class2.method_4() && @class.method_4())
						{
							if (class2.NoDogObj == @class.NoDogObj)
							{
								class2.Label = true;
								if (!@class.method_10())
								{
									class2.Reason = @class.Reason;
								}
								this.dictionary_1.Add(class2.NoDogObj, @class);
								break;
							}
						}
						else if (!class2.method_4() && !@class.method_4() && class2.ObjId == @class.AbnObjId)
						{
							class2.Label = true;
							if (!@class.method_10())
							{
								class2.Reason = @class.Reason;
							}
							if (!this.dictionary_0.ContainsKey(class2.ObjId))
							{
								this.dictionary_0.Add(class2.ObjId, @class);
								break;
							}
							break;
						}
					}
				}
				goto IL_28F;
			}
		}
		foreach (object obj3 in this.bindingSource_5)
		{
			Class548.Class572 class3 = (Class548.Class572)((DataRowView)obj3).Row;
			foreach (object obj4 in this.bindingSource_4)
			{
				Class548.Class578 class4 = (Class548.Class578)((DataRowView)obj4).Row;
				if (class4.FIO == class3.FIO && class4.Address == class3.Address)
				{
					class4.Label = true;
					if (!class3.method_8())
					{
						class4.Reason = class3.Reason;
					}
					this.dictionary_2.Add(class4.Id, class3);
					break;
				}
			}
		}
		IL_28F:
		if (!this.bool_0)
		{
			this.dataGridView_0.Enabled = false;
			this.dataGridView_0.Visible = false;
			this.dataGridView_1.Enabled = true;
			this.dataGridView_1.Visible = true;
		}
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		this.bindingSource_1.AddNew();
		Class548.Class569 @class = (Class548.Class569)((DataRowView)this.bindingSource_1.Current).Row;
		@class.Reason = this.toolStripTextBox_0.Text;
		@class.IdTypeApl = this.int_0;
		this.bindingSource_1.EndEdit();
		this.class587_0.vmethod_2(this.class548_0.tblAbnAplForDisconReason);
		this.toolStripTextBox_0.Text = string.Empty;
	}

	private void Form13_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.bool_0)
			{
				using (IEnumerator enumerator = this.bindingSource_3.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						Class548.Class577 @class = (Class548.Class577)((DataRowView)obj).Row;
						if (@class.Label)
						{
							Class548.Class568 class2;
							if (!@class.method_4() && this.dictionary_0.ContainsKey(@class.ObjId))
							{
								class2 = this.dictionary_0[@class.ObjId];
							}
							else if (!@class.method_22() && this.dictionary_1.ContainsKey(@class.NoDogObj))
							{
								class2 = this.dictionary_1[@class.NoDogObj];
							}
							else
							{
								this.bindingSource_2.AddNew();
								class2 = (Class548.Class568)((DataRowView)this.bindingSource_2.Current).Row;
							}
							if (!@class.method_0())
							{
								class2.AbnId = @class.AbnID;
							}
							if (!@class.method_4())
							{
								class2.AbnObjId = @class.ObjId;
							}
							if (!@class.method_18())
							{
								class2.PlaceId = @class.idPoint;
							}
							if (!@class.method_14())
							{
								class2.Reason = @class.Reason;
							}
							if (!@class.method_16())
							{
								class2.Comments = @class.Comments;
							}
							if (!@class.method_6())
							{
								class2.DateDog = @class.DateDog;
							}
							if (!@class.method_8())
							{
								class2.Code = @class.Code;
							}
							if (!@class.method_10())
							{
								class2.NameShort = @class.NameShort;
							}
							if (!@class.method_2())
							{
								class2.AbnObj = @class.Title;
							}
							if (@class.method_8())
							{
								if (!@class.method_22())
								{
									class2.AbnObj = @class.NoDogObj;
									class2.NoDogObj = @class.NoDogObj;
								}
								if (!@class.method_20())
								{
									class2.NameShort = @class.NoDogAbn;
									class2.NoDogAbn = @class.NoDogAbn;
								}
							}
							class2.IdCancelApl = @class.CanceledAplId;
							this.bindingSource_2.EndEdit();
						}
						else
						{
							foreach (object obj2 in this.bindingSource_2)
							{
								Class548.Class568 class3 = (Class548.Class568)((DataRowView)obj2).Row;
								if (@class.method_4() && class3.method_4())
								{
									if (@class.NoDogObj == class3.NoDogObj)
									{
										this.class586_0.vmethod_20(class3.NoDogObj, new int?(this.int_1));
										class3.Delete();
										this.bindingSource_2.EndEdit();
										break;
									}
								}
								else if (!@class.method_4() && !class3.method_4() && @class.ObjId == class3.AbnObjId)
								{
									this.class586_0.vmethod_19(new int?(class3.AbnObjId), new int?(this.int_1));
									class3.Delete();
									this.bindingSource_2.EndEdit();
									break;
								}
							}
						}
					}
					goto IL_4D9;
				}
			}
			foreach (object obj3 in this.bindingSource_4)
			{
				Class548.Class578 class4 = (Class548.Class578)((DataRowView)obj3).Row;
				if (class4.Label)
				{
					Class548.Class572 class5;
					if (this.dictionary_2.ContainsKey(class4.Id))
					{
						class5 = this.dictionary_2[class4.Id];
					}
					else
					{
						this.bindingSource_5.AddNew();
						class5 = (Class548.Class572)((DataRowView)this.bindingSource_5.Current).Row;
					}
					if (!class4.method_0())
					{
						class5.FIO = class4.FIO;
					}
					if (!class4.method_2())
					{
						class5.Address = class4.Address;
					}
					if (!class4.method_4())
					{
						class5.PlaceId = class4.PlaceId;
					}
					if (!class4.method_12())
					{
						class5.Reason = class4.Reason;
					}
					if (!class4.method_10())
					{
						class5.DateDog = class4.DateDog;
					}
					if (!class4.method_8())
					{
						class5.Code = class4.Code;
					}
					class5.IdCancelApl = class4.CanceledAplId;
					this.bindingSource_5.EndEdit();
				}
				else
				{
					foreach (object obj4 in this.bindingSource_2)
					{
						Class548.Class572 class6 = (Class548.Class572)((DataRowView)obj4).Row;
						if (class4.Id == class6.Id)
						{
							this.class590_0.vmethod_19(class6.FIO, new int?(this.int_1));
							class6.Delete();
							this.bindingSource_5.EndEdit();
							break;
						}
					}
				}
			}
		}
		IL_4D9:
		this.bindingSource_2.RemoveFilter();
	}

	private void dataGridView_0_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
		{
			Class548.Class577 @class = (Class548.Class577)((DataRowView)this.bindingSource_3[i]).Row;
			if (@class.method_8())
			{
				if (!@class.method_20())
				{
					@class.NameShort = @class.NoDogAbn;
				}
				if (!@class.method_22())
				{
					@class.Title = @class.NoDogObj;
				}
			}
		}
	}

	private void method_0()
	{
		this.icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form13));
		this.label_0 = new Label();
		this.class548_0 = new Class548();
		this.maskedTextBox_0 = new MaskedTextBox();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		this.contextMenuStrip_0 = new ContextMenuStrip(this.icontainer_0);
		this.toolStripTextBox_0 = new ToolStripTextBox();
		this.toolStripMenuItem_0 = new ToolStripMenuItem();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.bindingSource_3 = new BindingSource(this.icontainer_0);
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.class587_0 = new Class587();
		this.dataGridView_1 = new DataGridView();
		this.dataGridViewCheckBoxColumn_1 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_1 = new DataGridViewComboBoxColumn();
		this.bindingSource_4 = new BindingSource(this.icontainer_0);
		this.class590_0 = new Class590();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.tkyNhPsbaf = new BindingSource(this.icontainer_0);
		this.bindingSource_2 = new BindingSource(this.icontainer_0);
		this.bindingSource_5 = new BindingSource(this.icontainer_0);
		this.class589_0 = new Class589();
		this.class588_0 = new Class588();
		this.class595_0 = new Class595();
		this.class596_0 = new Class596();
		this.class586_0 = new Class586();
		((ISupportInitialize)this.class548_0).BeginInit();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		this.contextMenuStrip_0.SuspendLayout();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		((ISupportInitialize)this.bindingSource_3).BeginInit();
		((ISupportInitialize)this.dataGridView_1).BeginInit();
		((ISupportInitialize)this.bindingSource_4).BeginInit();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		((ISupportInitialize)this.tkyNhPsbaf).BeginInit();
		((ISupportInitialize)this.bindingSource_2).BeginInit();
		((ISupportInitialize)this.bindingSource_5).BeginInit();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 9);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(98, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Номер заявления";
		this.class548_0.DataSetName = "OrgDataSet";
		this.class548_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.maskedTextBox_0.BeepOnError = true;
		this.maskedTextBox_0.Location = new Point(155, 6);
		this.maskedTextBox_0.Mask = "0000000000";
		this.maskedTextBox_0.Name = "maskedTextBoxCode";
		this.maskedTextBox_0.Size = new Size(210, 20);
		this.maskedTextBox_0.TabIndex = 2;
		this.maskedTextBox_0.TextChanged += this.maskedTextBox_0_TextChanged;
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.AutoGenerateColumns = false;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewCheckBoxColumn_0,
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewComboBoxColumn_0
		});
		this.dataGridView_0.DataSource = this.bindingSource_3;
		this.dataGridView_0.Location = new Point(12, 32);
		this.dataGridView_0.Name = "dataGridView1Legal";
		this.dataGridView_0.RowHeadersWidth = 25;
		this.dataGridView_0.Size = new Size(511, 306);
		this.dataGridView_0.TabIndex = 3;
		this.dataGridView_0.RowsAdded += this.dataGridView_0_RowsAdded;
		this.dataGridViewCheckBoxColumn_0.DataPropertyName = "Label";
		this.dataGridViewCheckBoxColumn_0.HeaderText = "";
		this.dataGridViewCheckBoxColumn_0.Name = "labelDataGridViewCheckBoxColumn";
		this.dataGridViewCheckBoxColumn_0.Width = 25;
		this.dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "NameShort";
		this.dataGridViewTextBoxColumn_0.HeaderText = "Наименование абонента";
		this.dataGridViewTextBoxColumn_0.Name = "NameShort";
		this.dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "Title";
		this.dataGridViewTextBoxColumn_1.HeaderText = "Наименование объекта";
		this.dataGridViewTextBoxColumn_1.Name = "pointDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "idPoint";
		this.dataGridViewTextBoxColumn_2.FillWeight = 75f;
		this.dataGridViewTextBoxColumn_2.HeaderText = "Пункт ввода ограничения";
		this.dataGridViewTextBoxColumn_2.Name = "titleDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewComboBoxColumn_0.ContextMenuStrip = this.contextMenuStrip_0;
		this.dataGridViewComboBoxColumn_0.DataPropertyName = "Reason";
		this.dataGridViewComboBoxColumn_0.DataSource = this.bindingSource_1;
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
		this.bindingSource_1.DataMember = "tblAbnAplForDisconReason";
		this.bindingSource_1.DataSource = this.class548_0;
		this.bindingSource_3.DataMember = "tblAbnObj2";
		this.bindingSource_3.DataSource = this.class548_0;
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
		this.dataGridView_1.AllowUserToAddRows = false;
		this.dataGridView_1.AllowUserToDeleteRows = false;
		this.dataGridView_1.AutoGenerateColumns = false;
		this.dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_1.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewCheckBoxColumn_1,
			this.dataGridViewTextBoxColumn_3,
			this.dataGridViewTextBoxColumn_4,
			this.dataGridViewTextBoxColumn_5,
			this.dataGridViewComboBoxColumn_1
		});
		this.dataGridView_1.DataSource = this.bindingSource_4;
		this.dataGridView_1.Enabled = false;
		this.dataGridView_1.Location = new Point(12, 32);
		this.dataGridView_1.Name = "dataGridView2Individual";
		this.dataGridView_1.RowHeadersWidth = 25;
		this.dataGridView_1.Size = new Size(511, 306);
		this.dataGridView_1.TabIndex = 5;
		this.dataGridView_1.Visible = false;
		this.dataGridViewCheckBoxColumn_1.DataPropertyName = "Label";
		this.dataGridViewCheckBoxColumn_1.HeaderText = "";
		this.dataGridViewCheckBoxColumn_1.Name = "Label";
		this.dataGridViewCheckBoxColumn_1.Width = 25;
		this.dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_3.DataPropertyName = "FIO";
		this.dataGridViewTextBoxColumn_3.HeaderText = "ФИО";
		this.dataGridViewTextBoxColumn_3.Name = "fIODataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_4.DataPropertyName = "Address";
		this.dataGridViewTextBoxColumn_4.HeaderText = "Адрес";
		this.dataGridViewTextBoxColumn_4.Name = "addressDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_5.DataPropertyName = "Place";
		this.dataGridViewTextBoxColumn_5.HeaderText = "Пункт ввода ограничения";
		this.dataGridViewTextBoxColumn_5.Name = "placeIdDataGridViewTextBoxColumn";
		this.dataGridViewComboBoxColumn_1.ContextMenuStrip = this.contextMenuStrip_0;
		this.dataGridViewComboBoxColumn_1.DataPropertyName = "Reason";
		this.dataGridViewComboBoxColumn_1.DataSource = this.bindingSource_1;
		this.dataGridViewComboBoxColumn_1.DisplayMember = "Reason";
		this.dataGridViewComboBoxColumn_1.HeaderText = "Причина";
		this.dataGridViewComboBoxColumn_1.Name = "dataGridViewComboBoxColumn1";
		this.dataGridViewComboBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_1.SortMode = DataGridViewColumnSortMode.Automatic;
		this.dataGridViewComboBoxColumn_1.ValueMember = "Id";
		this.bindingSource_4.DataMember = "tblAbnAplForDisconIndividualUsersForCancel";
		this.bindingSource_4.DataSource = this.class548_0;
		this.class590_0.Boolean_0 = true;
		this.bindingSource_0.DataMember = "tblAbn";
		this.bindingSource_0.DataSource = this.class548_0;
		this.tkyNhPsbaf.DataMember = "tblAbnObj";
		this.tkyNhPsbaf.DataSource = this.class548_0;
		this.bindingSource_2.DataMember = "tblAbnAplForDisconObjects";
		this.bindingSource_2.DataSource = this.class548_0;
		this.bindingSource_5.DataMember = "tblAbnAplForDisconIndividualUsers";
		this.bindingSource_5.DataSource = this.class548_0;
		this.class589_0.Boolean_0 = true;
		this.class588_0.Boolean_0 = true;
		this.class595_0.Boolean_0 = true;
		this.class596_0.Boolean_0 = true;
		this.class586_0.Boolean_0 = true;
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(535, 387);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.maskedTextBox_0);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.dataGridView_0);
		base.Controls.Add(this.dataGridView_1);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "FormAddObjectsForCancel";
		this.Text = "Добавление объектов для отмены";
		base.FormClosing += this.Form13_FormClosing;
		base.Load += this.Form13_Load;
		((ISupportInitialize)this.class548_0).EndInit();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		this.contextMenuStrip_0.ResumeLayout(false);
		this.contextMenuStrip_0.PerformLayout();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		((ISupportInitialize)this.bindingSource_3).EndInit();
		((ISupportInitialize)this.dataGridView_1).EndInit();
		((ISupportInitialize)this.bindingSource_4).EndInit();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		((ISupportInitialize)this.tkyNhPsbaf).EndInit();
		((ISupportInitialize)this.bindingSource_2).EndInit();
		((ISupportInitialize)this.bindingSource_5).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	internal static void B3tE7Z3bZt3NcGnJ3N9(Form form_0, bool bool_1)
	{
		form_0.Dispose(bool_1);
	}

	private int int_0;

	private string string_0;

	private bool bool_0;

	private int int_1;

	private Dictionary<int, Class548.Class568> dictionary_0;

	private Dictionary<string, Class548.Class568> dictionary_1;

	private Dictionary<int, Class548.Class572> dictionary_2;

	private Label label_0;

	private BindingSource bindingSource_0;

	private Class548 class548_0;

	private Class589 class589_0;

	private MaskedTextBox maskedTextBox_0;

	private DataGridView dataGridView_0;

	private BindingSource tkyNhPsbaf;

	private Class588 class588_0;

	private Button button_0;

	private Button button_1;

	private BindingSource bindingSource_1;

	private Class587 class587_0;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripTextBox toolStripTextBox_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	public BindingSource bindingSource_2;

	private BindingSource bindingSource_3;

	private Class595 class595_0;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridView dataGridView_1;

	private BindingSource bindingSource_4;

	private Class596 class596_0;

	private Class590 class590_0;

	public BindingSource bindingSource_5;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;

	private Class586 class586_0;
}
