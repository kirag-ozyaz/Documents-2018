using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DataSql;
using Documents.Forms;
using Documents.Properties;
using FormLbr;

internal partial class Form9 : FormBase
{
	internal Form9(FormList formList_1, bool bool_1)
	{
		
		this.dateTime_0 = DateTime.MinValue;
		this.int_1 = -1;
		this.list_0 = new List<int>();
		this.bool_0 = true;
		this.list_1 = new List<string>();
		this.list_2 = new List<string>();
		
		this.method_2();
		this.formList_0 = formList_1;
		this.bool_0 = bool_1;
		if (!bool_1)
		{
			this.panel_0.Enabled = false;
			this.panel_0.Visible = false;
			this.panel_2.Enabled = true;
			this.panel_2.Visible = true;
			base.Icon = Resources.individualIcon;
		}
	}

	internal Form9(FormList formList_1, bool bool_1, SQLSettings sqlsettings_0)
	{
		
		this.dateTime_0 = DateTime.MinValue;
		this.int_1 = -1;
		this.list_0 = new List<int>();
		this.bool_0 = true;
		this.list_1 = new List<string>();
		this.list_2 = new List<string>();
		
		this.method_2();
		this.SqlSettings = sqlsettings_0;
		this.formList_0 = formList_1;
		this.bool_0 = bool_1;
		if (!bool_1)
		{
			this.panel_0.Enabled = false;
			this.panel_0.Visible = false;
			this.panel_2.Enabled = true;
			this.panel_2.Visible = true;
			base.Icon = Resources.individualIcon;
		}
		this.form7_0 = new Form7(this.SqlSettings);
	}

	private void Form9_Load(object sender, EventArgs e)
	{
		SqlConnection sqlConnection = new SqlConnection(SqlDataConnect.GetConnectionString(this.SqlSettings));
		string cmdText = "select top 1 * from tSettings where Module = 'RequestODS'";
		sqlConnection.Open();
		SqlDataReader sqlDataReader = new SqlCommand(cmdText, sqlConnection).ExecuteReader();
		if (sqlDataReader.Read())
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(sqlDataReader["Settings"].ToString());
			foreach (object obj in xmlDocument.SelectSingleNode("ApplSet").SelectNodes("NetArea"))
			{
				XmlNode xmlNode = (XmlNode)obj;
				this.list_1.Add(xmlNode.Attributes["Name"].Value);
				this.list_2.Add(xmlNode.Attributes["ManagerName"].Value);
			}
		}
		if (this.list_1.Count > 0)
		{
			this.comboBox_1.Items.Clear();
			this.comboBox_2.Items.Clear();
			foreach (string item in this.list_1)
			{
				this.comboBox_1.Items.Add(item);
			}
			foreach (string item2 in this.list_2)
			{
				this.comboBox_2.Items.Add(item2);
			}
		}
		this.class567_0 = (Class548.Class567)((DataRowView)this.bindingSource_0.Current).Row;
		this.comboBox_0.SelectedIndex = this.class567_0.TypeAction;
		if (this.class567_0.NetArea >= this.comboBox_1.Items.Count)
		{
			this.comboBox_1.SelectedIndex = 0;
		}
		else
		{
			this.comboBox_1.SelectedIndex = this.class567_0.NetArea;
		}
		if (!this.class567_0.method_14())
		{
			this.int_0 = this.class567_0.Id;
			this.form7_0.IdRequest = this.int_0;
			this.form7_0.method_0();
			this.Text = "Заявка №" + this.class567_0.Id;
			this.int_1 = this.class567_0.TypeAction;
			if (!this.class567_0.method_18())
			{
				this.dateTimePicker_2.Value = this.class567_0.Sent;
				this.method_0(true);
			}
			else
			{
				this.method_0(false);
			}
		}
		else
		{
			this.Text = "Заявка";
		}
		if (this.bool_0)
		{
			this.class586_0.vmethod_0(this.class548_0.tblAbnAplForDisconObjects, new int?(this.int_0));
			return;
		}
		this.class594_0.vmethod_0(this.class548_0.tblAbnAplConnectPointForIndividualUsers);
		this.class590_0.vmethod_0(this.class548_0.tblAbnAplForDisconIndividualUsers, new int?(this.int_0));
	}

	private void method_0(bool bool_1)
	{
		this.button_2.Enabled = true;
		if (bool_1)
		{
			this.panel_0.Enabled = false;
			this.panel_2.Enabled = false;
			this.comboBox_1.Enabled = false;
			this.dateTimePicker_1.Enabled = false;
			this.comboBox_2.Enabled = false;
			this.button_1.Enabled = false;
			this.checkBox_0.Checked = true;
			this.panel_1.Enabled = false;
			this.comboBox_0.Enabled = false;
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.int_1 == this.comboBox_0.SelectedIndex)
		{
			return;
		}
		bool flag;
		if (this.bool_0)
		{
			flag = (this.bindingSource_1.Count > 0);
		}
		else
		{
			flag = (this.bindingSource_3.Count > 0);
		}
		if (flag)
		{
			if (MessageBox.Show("В случае изменения типа распоряжения все объекты будут удалены из распоряжения, всё равно изменить? ", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
			{
				this.comboBox_0.SelectedIndex = this.int_1;
				return;
			}
			if (this.bool_0)
			{
				while (this.bindingSource_1.Count > 0)
				{
					this.bindingSource_1.RemoveAt(0);
				}
			}
			else
			{
				while (this.bindingSource_3.Count > 0)
				{
					this.bindingSource_3.RemoveAt(0);
				}
			}
		}
		this.int_1 = this.comboBox_0.SelectedIndex;
		switch (this.comboBox_0.SelectedIndex)
		{
		case 0:
			this.label_2.Text = "Дата отключения";
			this.label_2.Visible = true;
			this.dateTimePicker_1.Visible = true;
			if (this.dateTime_0 != DateTime.MinValue)
			{
				this.dateTimePicker_1.Value = this.dateTime_0;
				this.dateTime_0 = DateTime.MinValue;
			}
			break;
		case 1:
			this.label_2.Text = "Дата возобновления";
			this.label_2.Visible = true;
			this.dateTimePicker_1.Visible = true;
			if (this.dateTime_0 != DateTime.MinValue)
			{
				this.dateTimePicker_1.Value = this.dateTime_0;
				this.dateTime_0 = DateTime.MinValue;
			}
			break;
		case 2:
			this.label_2.Visible = false;
			this.dateTimePicker_1.Visible = false;
			this.dateTime_0 = this.dateTimePicker_1.Value;
			this.dateTimePicker_1.Value = this.dateTimePicker_0.Value;
			break;
		}
		this.class587_0.vmethod_0(this.class548_0.tblAbnAplForDisconReason, new int?(this.comboBox_0.SelectedIndex));
	}

	private void Form9_FormClosing(object sender, FormClosingEventArgs e)
	{
		this.bindingSource_0.CancelEdit();
		this.bindingSource_3.CancelEdit();
		this.bindingSource_1.CancelEdit();
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		if (this.comboBox_0.SelectedIndex != 2)
		{
			if (new Form8(this.comboBox_0.SelectedIndex, 0, this.SqlSettings)
			{
				bindingSource_3 = 
				{
					DataSource = this.bindingSource_1
				}
			}.ShowDialog() == DialogResult.OK)
			{
				this.comboBox_0.Enabled = false;
				this.dataGridView_0.Refresh();
			}
		}
		else if (new Form13(this.comboBox_0.SelectedIndex, string.Empty, true, this.int_0, this.SqlSettings)
		{
			bindingSource_2 = 
			{
				DataSource = this.bindingSource_1
			}
		}.ShowDialog() == DialogResult.OK)
		{
			this.comboBox_0.Enabled = false;
		}
		this.class587_0.vmethod_0(this.class548_0.tblAbnAplForDisconReason, new int?(this.comboBox_0.SelectedIndex));
	}

	private void toolStripButton_3_Click(object sender, EventArgs e)
	{
		if (this.comboBox_0.SelectedIndex != 2)
		{
			this.bindingSource_3.AddNew();
			if (new Form10(this.comboBox_0.SelectedIndex, this.SqlSettings)
			{
				bindingSource_0 = 
				{
					DataSource = this.bindingSource_3,
					Position = this.bindingSource_3.Position
				}
			}.ShowDialog() == DialogResult.OK)
			{
				this.comboBox_0.Enabled = false;
				this.class594_0.vmethod_0(this.class548_0.tblAbnAplConnectPointForIndividualUsers);
				this.class587_0.vmethod_0(this.class548_0.tblAbnAplForDisconReason, new int?(this.comboBox_0.SelectedIndex));
				return;
			}
			if (this.bindingSource_3.Current != null)
			{
				((DataRowView)this.bindingSource_3.Current).Row.Delete();
				return;
			}
		}
		else if (new Form13(this.comboBox_0.SelectedIndex, string.Empty, false, this.int_0, this.SqlSettings)
		{
			bindingSource_5 = 
			{
				DataSource = this.bindingSource_3
			}
		}.ShowDialog() == DialogResult.OK)
		{
			this.comboBox_0.Enabled = false;
			this.class594_0.vmethod_0(this.class548_0.tblAbnAplConnectPointForIndividualUsers);
			this.class587_0.vmethod_0(this.class548_0.tblAbnAplForDisconReason, new int?(this.comboBox_0.SelectedIndex));
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		if (this.bindingSource_1.Current != null)
		{
			if (this.comboBox_0.SelectedIndex != 2)
			{
				Form8 form;
				if (((Class548.Class568)((DataRowView)this.bindingSource_1.Current).Row).method_16())
				{
					form = new Form8(this.comboBox_0.SelectedIndex, this.SqlSettings);
				}
				else
				{
					form = new Form8(this.comboBox_0.SelectedIndex, ((Class548.Class568)((DataRowView)this.bindingSource_1.Current).Row).Code, this.SqlSettings);
				}
				form.bindingSource_3.DataSource = this.bindingSource_1;
				form.bindingSource_3.Position = this.bindingSource_1.Position;
				form.ShowDialog();
				this.dataGridView_0.Refresh();
				return;
			}
			new Form13(this.comboBox_0.SelectedIndex, ((Class548.Class568)((DataRowView)this.bindingSource_1.Current).Row).IdCancelApl, true, this.int_0, this.SqlSettings)
			{
				bindingSource_2 = 
				{
					DataSource = this.bindingSource_1,
					Position = this.bindingSource_1.Position
				}
			}.ShowDialog();
		}
	}

	private void toolStripButton_4_Click(object sender, EventArgs e)
	{
		if (this.bindingSource_3.Position != -1)
		{
			if (this.comboBox_0.SelectedIndex != 2)
			{
				if (new Form10(this.comboBox_0.SelectedIndex, this.SqlSettings)
				{
					bindingSource_0 = 
					{
						DataSource = this.bindingSource_3,
						Position = this.bindingSource_3.Position
					}
				}.ShowDialog() == DialogResult.OK)
				{
					this.comboBox_0.Enabled = false;
					this.class594_0.vmethod_0(this.class548_0.tblAbnAplConnectPointForIndividualUsers);
					this.class587_0.vmethod_0(this.class548_0.tblAbnAplForDisconReason, new int?(this.comboBox_0.SelectedIndex));
					return;
				}
			}
			else if (new Form13(this.comboBox_0.SelectedIndex, ((Class548.Class572)((DataRowView)this.bindingSource_3.Current).Row).IdCancelApl, false, this.int_0, this.SqlSettings)
			{
				bindingSource_5 = 
				{
					DataSource = this.bindingSource_3
				}
			}.ShowDialog() == DialogResult.OK)
			{
				this.comboBox_0.Enabled = false;
				this.class594_0.vmethod_0(this.class548_0.tblAbnAplConnectPointForIndividualUsers);
				this.class587_0.vmethod_0(this.class548_0.tblAbnAplForDisconReason, new int?(this.comboBox_0.SelectedIndex));
			}
		}
	}

	private void toolStripButton_2_Click(object sender, EventArgs e)
	{
		if (this.bindingSource_1.Current != null)
		{
			Class548.Class568 @class = (Class548.Class568)((DataRowView)this.bindingSource_1.Current).Row;
			if (this.comboBox_0.SelectedIndex == 2)
			{
				if (!@class.method_6())
				{
					this.class586_0.vmethod_19(new int?(@class.AbnObjId), new int?(this.int_0));
				}
				else if (@class.method_44())
				{
					this.class586_0.vmethod_20(@class.NoDogObj, new int?(this.int_0));
				}
			}
			@class.Delete();
		}
	}

	private void toolStripButton_5_Click(object sender, EventArgs e)
	{
		if (this.bindingSource_3.Current != null)
		{
			Class548.Class572 @class = (Class548.Class572)((DataRowView)this.bindingSource_3.Current).Row;
			if (this.comboBox_0.SelectedIndex == 2 && !@class.method_2())
			{
				this.class590_0.vmethod_19(@class.FIO, new int?(this.int_0));
			}
			@class.Delete();
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		this.bindingSource_2.AddNew();
		Class548.Class569 @class = (Class548.Class569)((DataRowView)this.bindingSource_2.Current).Row;
		@class.Reason = this.toolStripTextBox_0.Text;
		@class.IdTypeApl = this.comboBox_0.SelectedIndex;
		this.bindingSource_2.EndEdit();
		this.class587_0.vmethod_2(this.class548_0.tblAbnAplForDisconReason);
		this.toolStripTextBox_0.Text = string.Empty;
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		Form11 form = new Form11((Class548.Class567)((DataRowView)this.bindingSource_0.Current).Row, this.SqlSettings);
		if (this.bool_0)
		{
			form.bindingSource_1.DataSource = this.bindingSource_1;
			form.bindingSource_2.DataSource = this.bindingSource_2;
		}
		else
		{
			form.bindingSource_0.DataSource = this.bindingSource_3;
			form.bindingSource_2.DataSource = this.bindingSource_2;
		}
		form.Show();
	}

	private void dateTimePicker_0_ValueChanged(object sender, EventArgs e)
	{
		if ((this.dateTimePicker_2.Value - this.dateTimePicker_0.Value).Days < 2)
		{
			this.dateTimePicker_2.Value = this.dateTimePicker_0.Value.AddDays(2.0);
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		this.class567_0.NetArea = this.comboBox_1.SelectedIndex;
		this.class567_0.TypeAction = this.comboBox_0.SelectedIndex;
		this.class567_0.NetAreaCaption = this.comboBox_1.Text;
		this.class567_0.TypeActionCaption = this.comboBox_0.Text;
		this.class567_0.LegalAbns = this.bool_0;
		if (this.checkBox_0.Checked)
		{
			this.class567_0.Sent = this.dateTimePicker_2.Value;
		}
		else
		{
			this.class567_0.method_19();
		}
		this.bindingSource_0.EndEdit();
		this.formList_0.UpdatetblAbnAplForDisconTableAdapter();
		if (this.class567_0.method_14())
		{
			this.class567_0.Id = Convert.ToInt32(this.class585_0.vmethod_26());
		}
		if (this.bool_0)
		{
			foreach (object obj in this.bindingSource_1)
			{
				Class548.Class568 @class = (Class548.Class568)((DataRowView)obj).Row;
				if (@class.method_2() || @class.IdAplForDiscon != this.class567_0.Id)
				{
					if (@class.method_2())
					{
						@class.IdAplForDiscon = this.class567_0.Id;
					}
					@class.Officer = this.comboBox_2.Text;
					this.bindingSource_1.EndEdit();
				}
				if (this.class567_0.TypeAction == 2)
				{
					if (@class.method_16())
					{
						this.class586_0.vmethod_21(new int?(this.class567_0.Id), new int?(@class.IdCancelApl), @class.NoDogObj);
					}
					else
					{
						this.class586_0.vmethod_22(new int?(this.class567_0.Id), new int?(@class.AbnObjId), new int?(@class.IdCancelApl));
					}
				}
			}
			this.class586_0.vmethod_12(this.class548_0.tblAbnAplForDisconObjects);
		}
		else
		{
			foreach (object obj2 in this.bindingSource_3)
			{
				Class548.Class572 class2 = (Class548.Class572)((DataRowView)obj2).Row;
				if (class2.method_10() || class2.IdAplForDiscon != this.class567_0.Id)
				{
					if (class2.method_10())
					{
						class2.IdAplForDiscon = this.class567_0.Id;
					}
					class2.Officer = this.comboBox_2.Text;
					this.bindingSource_3.EndEdit();
				}
				if (this.class567_0.TypeAction == 2)
				{
					this.class590_0.vmethod_20(new int?(this.class567_0.Id), new int?(class2.IdCancelApl), class2.FIO);
				}
			}
			this.class590_0.vmethod_12(this.class548_0.tblAbnAplForDisconIndividualUsers);
		}
		this.method_0(!this.class567_0.method_18());
		this.Text = "Заявка №" + this.class567_0.Id;
		this.form7_0.IdRequest = this.class567_0.Id;
		this.form7_0.method_1();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void dataGridView_0_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
	{
		for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
		{
			Class548.Class568 @class = (Class548.Class568)((DataRowView)this.bindingSource_1[i]).Row;
			@class.method_58();
			if (@class.method_16())
			{
				if (!@class.method_42())
				{
					@class.NameShort = @class.NoDogAbn;
				}
				if (!@class.method_44())
				{
					@class.AbnObj = @class.NoDogObj;
				}
			}
		}
	}

	private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.comboBox_2.SelectedIndex = this.comboBox_1.SelectedIndex;
	}

	private void dataGridView_0_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
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
			this.class594_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
			this.class590_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
			this.class586_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
			this.class587_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
			this.class585_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		this.form7_0.Location = new Point(base.Location.X + this.button_3.Location.X, base.Location.Y + this.button_3.Location.Y + this.button_3.Size.Height - this.form7_0.Size.Height);
		this.form7_0.Show();
	}

	private void method_2()
	{
		this.icontainer_0 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form9));
		this.label_0 = new Label();
		this.label_1 = new Label();
		this.panel_0 = new Panel();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_1 = new DataGridViewComboBoxColumn();
		this.bindingSource_2 = new BindingSource(this.icontainer_0);
		this.class548_0 = new Class548();
		this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
		this.bindingSource_1 = new BindingSource(this.icontainer_0);
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripButton_1 = new ToolStripButton();
		this.toolStripButton_2 = new ToolStripButton();
		this.comboBox_0 = new ComboBox();
		this.label_2 = new Label();
		this.dateTimePicker_0 = new DateTimePicker();
		this.bindingSource_0 = new BindingSource(this.icontainer_0);
		this.dateTimePicker_1 = new DateTimePicker();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.label_3 = new Label();
		this.comboBox_1 = new ComboBox();
		this.contextMenuStrip_0 = new ContextMenuStrip(this.icontainer_0);
		this.toolStripTextBox_0 = new ToolStripTextBox();
		this.toolStripMenuItem_0 = new ToolStripMenuItem();
		this.button_2 = new Button();
		this.label_4 = new Label();
		this.dateTimePicker_2 = new DateTimePicker();
		this.comboBox_2 = new ComboBox();
		this.checkBox_0 = new CheckBox();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		this.panel_1 = new Panel();
		this.class585_0 = new Class585();
		this.class586_0 = new Class586();
		this.class587_0 = new Class587();
		this.bindingSource_3 = new BindingSource(this.icontainer_0);
		this.class590_0 = new Class590();
		this.bindingSource_4 = new BindingSource(this.icontainer_0);
		this.class594_0 = new Class594();
		this.panel_2 = new Panel();
		this.dataGridView_1 = new DataGridView();
		this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
		this.dataGridViewComboBoxColumn_2 = new DataGridViewComboBoxColumn();
		this.dataGridViewComboBoxColumn_3 = new DataGridViewComboBoxColumn();
		this.dataGridViewCheckBoxColumn_1 = new DataGridViewCheckBoxColumn();
		this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
		this.toolStrip_1 = new ToolStrip();
		this.toolStripButton_3 = new ToolStripButton();
		this.toolStripButton_4 = new ToolStripButton();
		this.toolStripButton_5 = new ToolStripButton();
		this.button_3 = new Button();
		this.panel_0.SuspendLayout();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		((ISupportInitialize)this.bindingSource_2).BeginInit();
		((ISupportInitialize)this.class548_0).BeginInit();
		((ISupportInitialize)this.bindingSource_1).BeginInit();
		this.toolStrip_0.SuspendLayout();
		((ISupportInitialize)this.bindingSource_0).BeginInit();
		this.contextMenuStrip_0.SuspendLayout();
		this.panel_1.SuspendLayout();
		((ISupportInitialize)this.bindingSource_3).BeginInit();
		((ISupportInitialize)this.bindingSource_4).BeginInit();
		this.panel_2.SuspendLayout();
		((ISupportInitialize)this.dataGridView_1).BeginInit();
		this.toolStrip_1.SuspendLayout();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(13, 13);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(59, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Заявка на";
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(13, 44);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(72, 13);
		this.label_1.TabIndex = 0;
		this.label_1.Text = "Дата заявки";
		this.panel_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_0.Controls.Add(this.dataGridView_0);
		this.panel_0.Controls.Add(this.toolStrip_0);
		this.panel_0.Location = new Point(16, 102);
		this.panel_0.Name = "panelLegal";
		this.panel_0.Size = new Size(864, 297);
		this.panel_0.TabIndex = 1;
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.AutoGenerateColumns = false;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_6,
			this.dataGridViewTextBoxColumn_7,
			this.dataGridViewTextBoxColumn_8,
			this.dataGridViewTextBoxColumn_9,
			this.dataGridViewTextBoxColumn_10,
			this.dataGridViewComboBoxColumn_1,
			this.dataGridViewCheckBoxColumn_0,
			this.dataGridViewTextBoxColumn_11
		});
		this.dataGridView_0.DataSource = this.bindingSource_1;
		this.dataGridView_0.Dock = DockStyle.Fill;
		this.dataGridView_0.Location = new Point(0, 25);
		this.dataGridView_0.Name = "dataGridView1";
		this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_0.Size = new Size(864, 272);
		this.dataGridView_0.TabIndex = 1;
		this.dataGridView_0.DataError += this.dataGridView_0_DataError;
		this.dataGridView_0.RowsAdded += this.dataGridView_0_RowsAdded;
		this.dataGridViewTextBoxColumn_6.DataPropertyName = "Code";
		this.dataGridViewTextBoxColumn_6.HeaderText = "Номер договора";
		this.dataGridViewTextBoxColumn_6.Name = "codeDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_6.ReadOnly = true;
		this.dataGridViewTextBoxColumn_6.Width = 70;
		this.dataGridViewTextBoxColumn_7.DataPropertyName = "DateDog";
		this.dataGridViewTextBoxColumn_7.HeaderText = "Дата договора";
		this.dataGridViewTextBoxColumn_7.Name = "dateDogDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_7.ReadOnly = true;
		this.dataGridViewTextBoxColumn_7.Width = 85;
		this.dataGridViewTextBoxColumn_8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_8.DataPropertyName = "NameShort";
		this.dataGridViewTextBoxColumn_8.HeaderText = "Наименование потребителя";
		this.dataGridViewTextBoxColumn_8.Name = "nameShortDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_8.ReadOnly = true;
		this.dataGridViewTextBoxColumn_9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_9.DataPropertyName = "AbnObj";
		this.dataGridViewTextBoxColumn_9.HeaderText = "Наименование объекта";
		this.dataGridViewTextBoxColumn_9.Name = "abnObjDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_9.ReadOnly = true;
		this.dataGridViewTextBoxColumn_10.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_10.DataPropertyName = "PlaceId";
		this.dataGridViewTextBoxColumn_10.HeaderText = "Пункт ввода ограничения";
		this.dataGridViewTextBoxColumn_10.Name = "PlaceId";
		this.dataGridViewComboBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_1.DataPropertyName = "Reason";
		this.dataGridViewComboBoxColumn_1.DataSource = this.bindingSource_2;
		this.dataGridViewComboBoxColumn_1.DisplayMember = "Reason";
		this.dataGridViewComboBoxColumn_1.HeaderText = "Причина";
		this.dataGridViewComboBoxColumn_1.Name = "reasonDataGridViewTextBoxColumn";
		this.dataGridViewComboBoxColumn_1.ReadOnly = true;
		this.dataGridViewComboBoxColumn_1.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_1.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_1.ValueMember = "Id";
		this.bindingSource_2.DataMember = "tblAbnAplForDisconReason";
		this.bindingSource_2.DataSource = this.class548_0;
		this.class548_0.DataSetName = "OrgDataSet";
		this.class548_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.dataGridViewCheckBoxColumn_0.DataPropertyName = "IsFullRestriction";
		this.dataGridViewCheckBoxColumn_0.HeaderText = "Полное ограничение";
		this.dataGridViewCheckBoxColumn_0.Name = "IsFullRestriction";
		this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
		this.dataGridViewCheckBoxColumn_0.Width = 75;
		this.dataGridViewTextBoxColumn_11.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_11.DataPropertyName = "Comments";
		this.dataGridViewTextBoxColumn_11.HeaderText = "Комментарий";
		this.dataGridViewTextBoxColumn_11.Name = "commentsDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_11.ReadOnly = true;
		this.bindingSource_1.DataMember = "tblAbnAplForDisconObjects";
		this.bindingSource_1.DataSource = this.class548_0;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripButton_1,
			this.toolStripButton_2
		});
		this.toolStrip_0.Location = new Point(0, 0);
		this.toolStrip_0.Name = "toolStrip1";
		this.toolStrip_0.Size = new Size(864, 25);
		this.toolStrip_0.TabIndex = 0;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources.legal_add;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolStripButtonAddRecord";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Добавить";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = Resources.legaluserEdit;
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "toolStripButtonEditRecords";
		this.toolStripButton_1.Size = new Size(23, 22);
		this.toolStripButton_1.Text = "Редактировать";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_2.Image = Resources.legal_add_delete;
		this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_2.Name = "toolStripButtonRemoveRecord";
		this.toolStripButton_2.Size = new Size(23, 22);
		this.toolStripButton_2.Text = "Удалить";
		this.toolStripButton_2.Click += this.toolStripButton_2_Click;
		this.comboBox_0.DisplayMember = "TypeAction";
		this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Items.AddRange(new object[]
		{
			"ОТКЛЮЧЕНИЕ",
			"ВОЗОБНОВЛЕНИЕ",
			"ОТМЕНУ"
		});
		this.comboBox_0.Location = new Point(135, 10);
		this.comboBox_0.Name = "comboBoxTypeAction";
		this.comboBox_0.Size = new Size(200, 21);
		this.comboBox_0.TabIndex = 2;
		this.comboBox_0.ValueMember = "TypeAction";
		this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(13, 75);
		this.label_2.Name = "labelDateAction";
		this.label_2.Size = new Size(33, 13);
		this.label_2.TabIndex = 0;
		this.label_2.Text = "Дата";
		this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.bindingSource_0, "DateAppl", true));
		this.dateTimePicker_0.Enabled = false;
		this.dateTimePicker_0.Location = new Point(135, 40);
		this.dateTimePicker_0.Name = "dateTimePicker1";
		this.dateTimePicker_0.Size = new Size(200, 20);
		this.dateTimePicker_0.TabIndex = 3;
		this.dateTimePicker_0.ValueChanged += this.dateTimePicker_0_ValueChanged;
		this.bindingSource_0.DataMember = "tblAbnAplForDiscon";
		this.bindingSource_0.DataSource = this.class548_0;
		this.dateTimePicker_1.CustomFormat = "dd.MM.yyyy HH:mm";
		this.dateTimePicker_1.DataBindings.Add(new Binding("Value", this.bindingSource_0, "DateAction", true));
		this.dateTimePicker_1.Format = DateTimePickerFormat.Custom;
		this.dateTimePicker_1.Location = new Point(135, 69);
		this.dateTimePicker_1.Name = "dateTimePickerAction";
		this.dateTimePicker_1.ShowUpDown = true;
		this.dateTimePicker_1.Size = new Size(200, 20);
		this.dateTimePicker_1.TabIndex = 3;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_0.Location = new Point(805, 411);
		this.button_0.Name = "buttonCancel";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 4;
		this.button_0.Text = "Закрыть";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.Location = new Point(724, 411);
		this.button_1.Name = "buttonOK";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 5;
		this.button_1.Text = "Сохранить";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(416, 13);
		this.label_3.Name = "label3";
		this.label_3.Size = new Size(85, 13);
		this.label_3.TabIndex = 0;
		this.label_3.Text = "Сетевой район:";
		this.comboBox_1.DisplayMember = "NetArea";
		this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Items.AddRange(new object[]
		{
			"Сетевой район 1",
			"Сетевой район 2",
			"Сетевой район 3",
			"Сетевой район 4",
			"ОДС",
			"СЭСНО"
		});
		this.comboBox_1.Location = new Point(538, 10);
		this.comboBox_1.Name = "comboBoxNetArea";
		this.comboBox_1.Size = new Size(200, 21);
		this.comboBox_1.TabIndex = 2;
		this.comboBox_1.ValueMember = "NetArea";
		this.comboBox_1.SelectedIndexChanged += this.comboBox_1_SelectedIndexChanged;
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
		this.button_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_2.Enabled = false;
		this.button_2.Location = new Point(643, 411);
		this.button_2.Name = "buttonPrint";
		this.button_2.Size = new Size(75, 23);
		this.button_2.TabIndex = 6;
		this.button_2.Text = "Печать";
		this.button_2.UseVisualStyleBackColor = true;
		this.button_2.Click += this.button_2_Click;
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(416, 44);
		this.label_4.Name = "label4";
		this.label_4.Size = new Size(89, 13);
		this.label_4.TabIndex = 0;
		this.label_4.Text = "Ответственный:";
		this.dateTimePicker_2.CustomFormat = "dd.MM.yyyy HH:mm";
		this.dateTimePicker_2.Format = DateTimePickerFormat.Custom;
		this.dateTimePicker_2.Location = new Point(122, 1);
		this.dateTimePicker_2.Name = "dateTimePickerSent";
		this.dateTimePicker_2.ShowUpDown = true;
		this.dateTimePicker_2.Size = new Size(200, 20);
		this.dateTimePicker_2.TabIndex = 3;
		this.comboBox_2.DisplayMember = "NetArea";
		this.comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Items.AddRange(new object[]
		{
			"Куфтырев Д.А.",
			"Рябов Д.А.",
			"Савинов Ю.М.",
			"Исаев В.М.",
			"Белавина Л.Г."
		});
		this.comboBox_2.Location = new Point(538, 41);
		this.comboBox_2.Name = "comboBox1";
		this.comboBox_2.Size = new Size(200, 21);
		this.comboBox_2.TabIndex = 2;
		this.comboBox_2.ValueMember = "NetArea";
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Location = new Point(3, 3);
		this.checkBox_0.Name = "checkBoxSent";
		this.checkBox_0.Size = new Size(90, 17);
		this.checkBox_0.TabIndex = 7;
		this.checkBox_0.Text = " Отправлено";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "Code";
		this.dataGridViewTextBoxColumn_0.HeaderText = "Номер договора";
		this.dataGridViewTextBoxColumn_0.Name = "dataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Width = 70;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "DateDog";
		this.dataGridViewTextBoxColumn_1.HeaderText = "Дата договора";
		this.dataGridViewTextBoxColumn_1.Name = "dataGridViewTextBoxColumn2";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.Width = 85;
		this.dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "NameShort";
		this.dataGridViewTextBoxColumn_2.HeaderText = "Наименование потребителя";
		this.dataGridViewTextBoxColumn_2.Name = "dataGridViewTextBoxColumn3";
		this.dataGridViewTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_3.DataPropertyName = "AbnObj";
		this.dataGridViewTextBoxColumn_3.HeaderText = "Наименование объекта";
		this.dataGridViewTextBoxColumn_3.Name = "dataGridViewTextBoxColumn4";
		this.dataGridViewTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewTextBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_4.DataPropertyName = "Point";
		this.dataGridViewTextBoxColumn_4.HeaderText = "Пункт";
		this.dataGridViewTextBoxColumn_4.Name = "dataGridViewTextBoxColumn5";
		this.dataGridViewTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewComboBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_0.DataPropertyName = "Reason";
		this.dataGridViewComboBoxColumn_0.DataSource = this.bindingSource_2;
		this.dataGridViewComboBoxColumn_0.DisplayMember = "Reason";
		this.dataGridViewComboBoxColumn_0.HeaderText = "Причина";
		this.dataGridViewComboBoxColumn_0.Name = "dataGridViewComboBoxColumn1";
		this.dataGridViewComboBoxColumn_0.ReadOnly = true;
		this.dataGridViewComboBoxColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_0.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_0.ValueMember = "Id";
		this.dataGridViewTextBoxColumn_5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_5.DataPropertyName = "Comments";
		this.dataGridViewTextBoxColumn_5.HeaderText = "Коментарий";
		this.dataGridViewTextBoxColumn_5.Name = "dataGridViewTextBoxColumn6";
		this.dataGridViewTextBoxColumn_5.ReadOnly = true;
		this.panel_1.Controls.Add(this.checkBox_0);
		this.panel_1.Controls.Add(this.dateTimePicker_2);
		this.panel_1.Location = new Point(416, 70);
		this.panel_1.Name = "panelSent";
		this.panel_1.Size = new Size(329, 25);
		this.panel_1.TabIndex = 8;
		this.class585_0.Boolean_0 = true;
		this.class586_0.Boolean_0 = true;
		this.class587_0.Boolean_0 = true;
		this.bindingSource_3.DataMember = "tblAbnAplForDisconIndividualUsers";
		this.bindingSource_3.DataSource = this.class548_0;
		this.class590_0.Boolean_0 = true;
		this.bindingSource_4.DataMember = "tblAbnAplConnectPointForIndividualUsers";
		this.bindingSource_4.DataSource = this.class548_0;
		this.class594_0.Boolean_0 = true;
		this.panel_2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_2.Controls.Add(this.dataGridView_1);
		this.panel_2.Controls.Add(this.toolStrip_1);
		this.panel_2.Enabled = false;
		this.panel_2.Location = new Point(16, 102);
		this.panel_2.Name = "panelIndividual";
		this.panel_2.Size = new Size(864, 297);
		this.panel_2.TabIndex = 13;
		this.panel_2.Visible = false;
		this.dataGridView_1.AllowUserToAddRows = false;
		this.dataGridView_1.AllowUserToDeleteRows = false;
		this.dataGridView_1.AutoGenerateColumns = false;
		this.dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_1.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_12,
			this.dataGridViewTextBoxColumn_13,
			this.dataGridViewTextBoxColumn_14,
			this.dataGridViewTextBoxColumn_15,
			this.dataGridViewComboBoxColumn_2,
			this.dataGridViewComboBoxColumn_3,
			this.dataGridViewCheckBoxColumn_1,
			this.dataGridViewTextBoxColumn_16
		});
		this.dataGridView_1.DataSource = this.bindingSource_3;
		this.dataGridView_1.Dock = DockStyle.Fill;
		this.dataGridView_1.Location = new Point(0, 25);
		this.dataGridView_1.MultiSelect = false;
		this.dataGridView_1.Name = "dataGridView2";
		this.dataGridView_1.ReadOnly = true;
		this.dataGridView_1.RowHeadersWidth = 25;
		this.dataGridView_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_1.Size = new Size(864, 272);
		this.dataGridView_1.TabIndex = 1;
		this.dataGridViewTextBoxColumn_12.DataPropertyName = "Code";
		this.dataGridViewTextBoxColumn_12.HeaderText = "Номер договора";
		this.dataGridViewTextBoxColumn_12.Name = "dataGridViewTextBoxColumn7";
		this.dataGridViewTextBoxColumn_12.ReadOnly = true;
		this.dataGridViewTextBoxColumn_12.Width = 70;
		this.dataGridViewTextBoxColumn_13.DataPropertyName = "DateDog";
		this.dataGridViewTextBoxColumn_13.HeaderText = "Дата договора";
		this.dataGridViewTextBoxColumn_13.Name = "dataGridViewTextBoxColumn8";
		this.dataGridViewTextBoxColumn_13.ReadOnly = true;
		this.dataGridViewTextBoxColumn_13.Width = 70;
		this.dataGridViewTextBoxColumn_14.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_14.DataPropertyName = "FIO";
		this.dataGridViewTextBoxColumn_14.HeaderText = "ФИО";
		this.dataGridViewTextBoxColumn_14.Name = "fIODataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_14.ReadOnly = true;
		this.dataGridViewTextBoxColumn_15.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_15.DataPropertyName = "Address";
		this.dataGridViewTextBoxColumn_15.HeaderText = "Наименование объекта";
		this.dataGridViewTextBoxColumn_15.Name = "addressDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_15.ReadOnly = true;
		this.dataGridViewComboBoxColumn_2.DataPropertyName = "PlaceId";
		this.dataGridViewComboBoxColumn_2.DataSource = this.bindingSource_4;
		this.dataGridViewComboBoxColumn_2.DisplayMember = "Point";
		this.dataGridViewComboBoxColumn_2.HeaderText = "Пункт";
		this.dataGridViewComboBoxColumn_2.Name = "placeIdDataGridViewTextBoxColumn";
		this.dataGridViewComboBoxColumn_2.ReadOnly = true;
		this.dataGridViewComboBoxColumn_2.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_2.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_2.ValueMember = "Id";
		this.dataGridViewComboBoxColumn_2.Width = 70;
		this.dataGridViewComboBoxColumn_3.DataPropertyName = "Reason";
		this.dataGridViewComboBoxColumn_3.DataSource = this.bindingSource_2;
		this.dataGridViewComboBoxColumn_3.DisplayMember = "Reason";
		this.dataGridViewComboBoxColumn_3.HeaderText = "Причина";
		this.dataGridViewComboBoxColumn_3.Name = "dataGridViewComboBoxColumn2";
		this.dataGridViewComboBoxColumn_3.ReadOnly = true;
		this.dataGridViewComboBoxColumn_3.Resizable = DataGridViewTriState.True;
		this.dataGridViewComboBoxColumn_3.SortMode = DataGridViewColumnSortMode.Programmatic;
		this.dataGridViewComboBoxColumn_3.ValueMember = "Id";
		this.dataGridViewComboBoxColumn_3.Width = 70;
		this.dataGridViewCheckBoxColumn_1.DataPropertyName = "IsFullRestriction";
		this.dataGridViewCheckBoxColumn_1.HeaderText = "Вид ограничения";
		this.dataGridViewCheckBoxColumn_1.Name = "dataGridViewCheckBoxColumn1";
		this.dataGridViewCheckBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_16.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_16.DataPropertyName = "Comments";
		this.dataGridViewTextBoxColumn_16.HeaderText = "Примечание";
		this.dataGridViewTextBoxColumn_16.Name = "dataGridViewTextBoxColumn9";
		this.dataGridViewTextBoxColumn_16.ReadOnly = true;
		this.toolStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_3,
			this.toolStripButton_4,
			this.toolStripButton_5
		});
		this.toolStrip_1.Location = new Point(0, 0);
		this.toolStrip_1.Name = "toolStrip2";
		this.toolStrip_1.Size = new Size(864, 25);
		this.toolStrip_1.TabIndex = 0;
		this.toolStrip_1.Text = "toolStrip2";
		this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_3.Image = Resources.individual_add;
		this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_3.Name = "toolStripButtonAdd";
		this.toolStripButton_3.Size = new Size(23, 22);
		this.toolStripButton_3.Text = "toolStripButton1";
		this.toolStripButton_3.Click += this.toolStripButton_3_Click;
		this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_4.Image = Resources.individualuserEdit;
		this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_4.Name = "toolStripButtonEdit";
		this.toolStripButton_4.Size = new Size(23, 22);
		this.toolStripButton_4.Text = "toolStripButton1";
		this.toolStripButton_4.Click += this.toolStripButton_4_Click;
		this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_5.Image = Resources.individualuserDelete;
		this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_5.Name = "toolStripButtonRemove";
		this.toolStripButton_5.Size = new Size(23, 22);
		this.toolStripButton_5.Text = "toolStripButton1";
		this.toolStripButton_5.Click += this.toolStripButton_5_Click;
		this.button_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_3.Location = new Point(16, 411);
		this.button_3.Name = "button1";
		this.button_3.Size = new Size(75, 23);
		this.button_3.TabIndex = 14;
		this.button_3.Text = "Файлы";
		this.button_3.UseVisualStyleBackColor = true;
		this.button_3.Click += this.button_3_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(892, 446);
		base.Controls.Add(this.button_3);
		base.Controls.Add(this.panel_0);
		base.Controls.Add(this.panel_1);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_2);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.dateTimePicker_1);
		base.Controls.Add(this.comboBox_1);
		base.Controls.Add(this.dateTimePicker_0);
		base.Controls.Add(this.comboBox_2);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.label_3);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.label_4);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.panel_2);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "FormAddApplication";
		this.Text = "Распоряжение для юридических лиц";
		base.FormClosing += this.Form9_FormClosing;
		base.Load += this.Form9_Load;
		this.panel_0.ResumeLayout(false);
		this.panel_0.PerformLayout();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		((ISupportInitialize)this.bindingSource_2).EndInit();
		((ISupportInitialize)this.class548_0).EndInit();
		((ISupportInitialize)this.bindingSource_1).EndInit();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		((ISupportInitialize)this.bindingSource_0).EndInit();
		this.contextMenuStrip_0.ResumeLayout(false);
		this.contextMenuStrip_0.PerformLayout();
		this.panel_1.ResumeLayout(false);
		this.panel_1.PerformLayout();
		((ISupportInitialize)this.bindingSource_3).EndInit();
		((ISupportInitialize)this.bindingSource_4).EndInit();
		this.panel_2.ResumeLayout(false);
		this.panel_2.PerformLayout();
		((ISupportInitialize)this.dataGridView_1).EndInit();
		this.toolStrip_1.ResumeLayout(false);
		this.toolStrip_1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private Form7 form7_0;

	private Class548.Class567 class567_0;

	private int int_0;

	private FormList formList_0;

	private DateTime dateTime_0;

	private int int_1;

	private List<int> list_0;

	private bool bool_0;

	private List<string> list_1;

	private List<string> list_2;

	private Class548 class548_0;

	private Class585 class585_0;

	public BindingSource bindingSource_0;

	private Label label_0;

	private Label label_1;

	private Panel panel_0;

	private DataGridView dataGridView_0;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ComboBox comboBox_0;

	private Label label_2;

	private DateTimePicker dateTimePicker_0;

	private DateTimePicker dateTimePicker_1;

	private Button button_0;

	private Button button_1;

	private BindingSource bindingSource_1;

	private Class586 class586_0;

	private Label label_3;

	private ComboBox comboBox_1;

	private BindingSource bindingSource_2;

	private Class587 class587_0;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripTextBox toolStripTextBox_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private Button button_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private Label label_4;

	private DateTimePicker dateTimePicker_2;

	private ComboBox comboBox_2;

	private CheckBox checkBox_0;

	private Panel panel_1;

	private ToolStripButton toolStripButton_2;

	private BindingSource bindingSource_3;

	private Class590 class590_0;

	private BindingSource bindingSource_4;

	private Class594 class594_0;

	private Panel panel_2;

	private DataGridView dataGridView_1;

	private ToolStrip toolStrip_1;

	private ToolStripButton toolStripButton_3;

	private ToolStripButton toolStripButton_4;

	private ToolStripButton toolStripButton_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_1;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

	private Button button_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_2;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_3;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;
}
