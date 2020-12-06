using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using DataSql;
using FormLbr;

internal partial class Form73 : FormBase
{
	internal Form73()
	{
		
		this.dictionary_0 = new Dictionary<string, Class167>();
		
		this.method_0();
		base.PermissionsSql = false;
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		int selectedIndex = this.listBox_0.SelectedIndex;
		if (selectedIndex == 0)
		{
			this.panel_0.Visible = true;
			this.panel_1.Visible = false;
			return;
		}
		if (selectedIndex != 1)
		{
			return;
		}
		this.panel_1.Visible = true;
		this.panel_0.Visible = false;
	}

	private void Form73_Load(object sender, EventArgs e)
	{
		SqlConnection sqlConnection = new SqlConnection(SqlDataConnect.GetConnectionString(this.SqlSettings));
		string cmdText = "select top 1 * from tSettings where Module = 'RequestODS'";
		sqlConnection.Open();
		SqlDataReader sqlDataReader = new SqlCommand(cmdText, sqlConnection).ExecuteReader();
		if (sqlDataReader.Read())
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(sqlDataReader["Settings"].ToString());
			XmlNode xmlNode = xmlDocument.SelectSingleNode("ApplSet");
			foreach (object obj in xmlNode.SelectNodes("NetArea"))
			{
				XmlNode xmlNode2 = (XmlNode)obj;
				Class167 @class = new Class167();
				@class.Name = xmlNode2.Attributes["Name"].Value;
				@class.Abbreviation = xmlNode2.Attributes["Abbreviation"].Value;
				@class.Genitive = xmlNode2.Attributes["Genitive"].Value;
				@class.ManagerName = xmlNode2.Attributes["ManagerName"].Value;
				this.dictionary_0.Add(@class.Name, @class);
				this.comboBox_0.Items.Add(@class.Name);
			}
			XmlNode xmlNode3 = xmlNode.SelectSingleNode("Ratifying");
			if (xmlNode3 != null)
			{
				this.textBox_8.Text = xmlNode3.Attributes["Post"].Value;
				this.textBox_7.Text = xmlNode3.Attributes["Name"].Value;
			}
			xmlNode3 = xmlNode.SelectSingleNode("Signer");
			if (xmlNode3 != null)
			{
				this.textBox_6.Text = xmlNode3.Attributes["Post"].Value;
				this.textBox_5.Text = xmlNode3.Attributes["Name"].Value;
			}
			xmlNode3 = xmlNode.SelectSingleNode("Performer");
			if (xmlNode3 != null)
			{
				this.textBox_4.Text = xmlNode3.Attributes["Name"].Value;
			}
		}
		sqlDataReader.Close();
		sqlConnection.Close();
		this.listBox_0.SelectedIndex = 0;
		if (this.comboBox_0.Items.Count == 0)
		{
			this.button_3.Enabled = true;
			this.button_2.Enabled = false;
			this.panel_2.Enabled = false;
			this.comboBox_0.Select();
			this.comboBox_0.Focus();
			return;
		}
		this.comboBox_0.SelectedIndex = 0;
	}

	private void comboBox_0_TextUpdate(object sender, EventArgs e)
	{
		this.button_3.Enabled = true;
		this.button_2.Enabled = false;
		this.panel_2.Enabled = false;
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.button_2.Enabled = true;
		this.button_3.Enabled = false;
		this.panel_2.Enabled = true;
		Class167 dataSource = this.dictionary_0[this.comboBox_0.Text];
		this.textBox_3.DataBindings.Clear();
		this.textBox_2.DataBindings.Clear();
		this.textBox_1.DataBindings.Clear();
		this.textBox_0.DataBindings.Clear();
		this.textBox_3.DataBindings.Add("Text", dataSource, "Name", true);
		this.textBox_2.DataBindings.Add("Text", dataSource, "Abbreviation", true);
		this.textBox_1.DataBindings.Add("Text", dataSource, "Genitive", true);
		this.textBox_0.DataBindings.Add("Text", dataSource, "ManagerName", true);
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (this.comboBox_0.Text == string.Empty)
		{
			return;
		}
		Class167 @class = new Class167();
		@class.Name = this.comboBox_0.Text;
		this.dictionary_0.Add(this.comboBox_0.Text, @class);
		this.comboBox_0.SelectedIndex = this.comboBox_0.Items.Add(this.comboBox_0.Text);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		int selectedIndex = this.comboBox_0.SelectedIndex;
		this.dictionary_0.Remove(this.comboBox_0.Text);
		this.comboBox_0.Items.Remove(this.comboBox_0.SelectedItem);
		if (this.comboBox_0.Items.Count == 0)
		{
			this.button_3.Enabled = true;
			this.button_2.Enabled = false;
			this.panel_2.Enabled = false;
			this.comboBox_0.Select();
			this.comboBox_0.Focus();
			return;
		}
		if (this.comboBox_0.Items.Count > selectedIndex)
		{
			this.comboBox_0.SelectedIndex = selectedIndex;
			return;
		}
		this.comboBox_0.SelectedIndex = this.comboBox_0.Items.Count - 1;
	}

	private void Form73_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml("<ApplSet></ApplSet>");
			XmlNode xmlNode = xmlDocument.SelectSingleNode("ApplSet");
			foreach (Class167 @class in this.dictionary_0.Values)
			{
				XmlElement xmlElement = xmlDocument.CreateElement("NetArea");
				xmlElement.SetAttribute("Name", @class.Name);
				xmlElement.SetAttribute("Genitive", @class.Genitive);
				xmlElement.SetAttribute("Abbreviation", @class.Abbreviation);
				if (@class.ManagerName == string.Empty)
				{
					e.Cancel = true;
					MessageBox.Show("Не введён ответственный от " + @class.Name);
					return;
				}
				xmlElement.SetAttribute("ManagerName", @class.ManagerName);
				xmlNode.AppendChild(xmlElement);
			}
			XmlElement xmlElement2 = xmlDocument.CreateElement("Ratifying");
			xmlElement2.SetAttribute("Post", this.textBox_8.Text);
			xmlElement2.SetAttribute("Name", this.textBox_7.Text);
			xmlNode.AppendChild(xmlElement2);
			xmlElement2 = xmlDocument.CreateElement("Signer");
			xmlElement2.SetAttribute("Post", this.textBox_6.Text);
			xmlElement2.SetAttribute("Name", this.textBox_5.Text);
			xmlNode.AppendChild(xmlElement2);
			xmlElement2 = xmlDocument.CreateElement("Performer");
			xmlElement2.SetAttribute("Name", this.textBox_4.Text);
			xmlNode.AppendChild(xmlElement2);
			SqlConnection sqlConnection = new SqlConnection(SqlDataConnect.GetConnectionString(this.SqlSettings));
			string cmdText = "select top 1 * from tSettings where Module = 'RequestODS'";
			sqlConnection.Open();
			SqlDataReader sqlDataReader = new SqlCommand(cmdText, sqlConnection).ExecuteReader();
			if (sqlDataReader.Read())
			{
				if (sqlDataReader["Settings"].ToString() != xmlDocument.InnerXml.ToString())
				{
					DbCommand dbCommand = new SqlCommand("update tSettings set Settings = '" + xmlDocument.InnerXml.ToString() + "'" + " where id = " + sqlDataReader["id"].ToString(), sqlConnection);
					sqlDataReader.Close();
					dbCommand.ExecuteNonQuery();
					return;
				}
				sqlDataReader.Close();
				return;
			}
			else
			{
				sqlDataReader.Close();
				new SqlCommand("insert into tSettings (Settings, Module) values ('" + xmlDocument.InnerXml.ToString() + "','RequestODS')", sqlConnection).ExecuteNonQuery();
			}
		}
	}

	private void comboBox_0_Leave(object sender, EventArgs e)
	{
	}

	private void textBox_3_Leave(object sender, EventArgs e)
	{
	}

	private void method_0()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form73));
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.splitContainer_0 = new SplitContainer();
		this.listBox_0 = new ListBox();
		this.panel_1 = new Panel();
		this.label_4 = new Label();
		this.label_5 = new Label();
		this.label_6 = new Label();
		this.label_7 = new Label();
		this.label_8 = new Label();
		this.textBox_4 = new TextBox();
		this.textBox_5 = new TextBox();
		this.textBox_6 = new TextBox();
		this.textBox_7 = new TextBox();
		this.textBox_8 = new TextBox();
		this.panel_0 = new Panel();
		this.panel_2 = new Panel();
		this.label_1 = new Label();
		this.label_2 = new Label();
		this.label_3 = new Label();
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.textBox_1 = new TextBox();
		this.textBox_2 = new TextBox();
		this.textBox_3 = new TextBox();
		this.comboBox_0 = new ComboBox();
		this.button_2 = new Button();
		this.button_3 = new Button();
		this.splitContainer_0.Panel1.SuspendLayout();
		this.splitContainer_0.Panel2.SuspendLayout();
		this.splitContainer_0.SuspendLayout();
		this.panel_1.SuspendLayout();
		this.panel_0.SuspendLayout();
		this.panel_2.SuspendLayout();
		base.SuspendLayout();
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Location = new Point(314, 170);
		this.button_0.Name = "buttonCancel";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 0;
		this.button_0.Text = "Отмена";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.OK;
		this.button_1.Location = new Point(233, 170);
		this.button_1.Name = "buttonOK";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 0;
		this.button_1.Text = "OK";
		this.button_1.UseVisualStyleBackColor = true;
		this.splitContainer_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.splitContainer_0.Location = new Point(12, 12);
		this.splitContainer_0.Name = "splitContainer1";
		this.splitContainer_0.Panel1.Controls.Add(this.listBox_0);
		this.splitContainer_0.Panel2.Controls.Add(this.panel_1);
		this.splitContainer_0.Panel2.Controls.Add(this.panel_0);
		this.splitContainer_0.Size = new Size(377, 152);
		this.splitContainer_0.SplitterDistance = 94;
		this.splitContainer_0.TabIndex = 1;
		this.listBox_0.Dock = DockStyle.Fill;
		this.listBox_0.FormattingEnabled = true;
		this.listBox_0.Items.AddRange(new object[]
		{
			"Адресат заявки",
			"Печатная форма"
		});
		this.listBox_0.Location = new Point(0, 0);
		this.listBox_0.Name = "listBox1";
		this.listBox_0.Size = new Size(94, 152);
		this.listBox_0.TabIndex = 0;
		this.listBox_0.SelectedIndexChanged += this.listBox_0_SelectedIndexChanged;
		this.panel_1.Controls.Add(this.label_4);
		this.panel_1.Controls.Add(this.label_5);
		this.panel_1.Controls.Add(this.label_6);
		this.panel_1.Controls.Add(this.label_7);
		this.panel_1.Controls.Add(this.label_8);
		this.panel_1.Controls.Add(this.textBox_4);
		this.panel_1.Controls.Add(this.textBox_5);
		this.panel_1.Controls.Add(this.textBox_6);
		this.panel_1.Controls.Add(this.textBox_7);
		this.panel_1.Controls.Add(this.textBox_8);
		this.panel_1.Dock = DockStyle.Fill;
		this.panel_1.Location = new Point(0, 0);
		this.panel_1.Name = "panelPrintFormSetting";
		this.panel_1.Size = new Size(279, 152);
		this.panel_1.TabIndex = 1;
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(6, 110);
		this.label_4.Name = "label9";
		this.label_4.Size = new Size(74, 13);
		this.label_4.TabIndex = 1;
		this.label_4.Text = "Исполнитель";
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(6, 84);
		this.label_5.Name = "label8";
		this.label_5.Size = new Size(122, 13);
		this.label_5.TabIndex = 1;
		this.label_5.Text = "Имя подписывающего";
		this.label_6.AutoSize = true;
		this.label_6.Location = new Point(6, 58);
		this.label_6.Name = "label7";
		this.label_6.Size = new Size(158, 13);
		this.label_6.TabIndex = 1;
		this.label_6.Text = "Должность подписывающего";
		this.label_7.AutoSize = true;
		this.label_7.Location = new Point(6, 32);
		this.label_7.Name = "label6";
		this.label_7.Size = new Size(114, 13);
		this.label_7.TabIndex = 1;
		this.label_7.Text = "Имя утверждающего";
		this.label_8.AutoSize = true;
		this.label_8.Location = new Point(6, 8);
		this.label_8.Name = "label5";
		this.label_8.Size = new Size(150, 13);
		this.label_8.TabIndex = 1;
		this.label_8.Text = "Должность утверждающего";
		this.textBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_4.Location = new Point(170, 107);
		this.textBox_4.Multiline = true;
		this.textBox_4.Name = "textBoxPerformer";
		this.textBox_4.Size = new Size(106, 42);
		this.textBox_4.TabIndex = 4;
		this.textBox_5.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_5.Location = new Point(170, 81);
		this.textBox_5.Name = "textBoxSignerName";
		this.textBox_5.Size = new Size(106, 20);
		this.textBox_5.TabIndex = 3;
		this.textBox_6.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_6.Location = new Point(170, 55);
		this.textBox_6.Name = "textBoxSignerPost";
		this.textBox_6.Size = new Size(106, 20);
		this.textBox_6.TabIndex = 2;
		this.textBox_7.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_7.Location = new Point(170, 29);
		this.textBox_7.Name = "textBoxRatifyingName";
		this.textBox_7.Size = new Size(106, 20);
		this.textBox_7.TabIndex = 1;
		this.textBox_8.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_8.Location = new Point(170, 3);
		this.textBox_8.Name = "textBoxRatifyingPost";
		this.textBox_8.Size = new Size(106, 20);
		this.textBox_8.TabIndex = 0;
		this.panel_0.Controls.Add(this.panel_2);
		this.panel_0.Controls.Add(this.comboBox_0);
		this.panel_0.Controls.Add(this.button_2);
		this.panel_0.Controls.Add(this.button_3);
		this.panel_0.Dock = DockStyle.Fill;
		this.panel_0.Location = new Point(0, 0);
		this.panel_0.Name = "panelAreas";
		this.panel_0.Size = new Size(279, 152);
		this.panel_0.TabIndex = 0;
		this.panel_2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.panel_2.Controls.Add(this.label_1);
		this.panel_2.Controls.Add(this.label_2);
		this.panel_2.Controls.Add(this.label_3);
		this.panel_2.Controls.Add(this.label_0);
		this.panel_2.Controls.Add(this.textBox_0);
		this.panel_2.Controls.Add(this.textBox_1);
		this.panel_2.Controls.Add(this.textBox_2);
		this.panel_2.Controls.Add(this.textBox_3);
		this.panel_2.Location = new Point(3, 32);
		this.panel_2.Name = "panelSet";
		this.panel_2.Size = new Size(273, 117);
		this.panel_2.TabIndex = 2;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(3, 93);
		this.label_1.Name = "label4";
		this.label_1.Size = new Size(86, 13);
		this.label_1.TabIndex = 1;
		this.label_1.Text = "Ответственный";
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(3, 67);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(100, 13);
		this.label_2.TabIndex = 1;
		this.label_2.Text = "Дательный падеж";
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(3, 41);
		this.label_3.Name = "label2";
		this.label_3.Size = new Size(77, 13);
		this.label_3.TabIndex = 1;
		this.label_3.Text = "Сокращённое";
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(3, 15);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(83, 13);
		this.label_0.TabIndex = 1;
		this.label_0.Text = "Наименование";
		this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.Location = new Point(119, 90);
		this.textBox_0.Name = "textBoxManagerName";
		this.textBox_0.Size = new Size(151, 20);
		this.textBox_0.TabIndex = 2;
		this.textBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_1.Location = new Point(119, 64);
		this.textBox_1.Name = "textBoxGenitive";
		this.textBox_1.Size = new Size(151, 20);
		this.textBox_1.TabIndex = 1;
		this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_2.Location = new Point(119, 38);
		this.textBox_2.Name = "textBoxAbbreviation";
		this.textBox_2.Size = new Size(151, 20);
		this.textBox_2.TabIndex = 0;
		this.textBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_3.Enabled = false;
		this.textBox_3.Location = new Point(119, 12);
		this.textBox_3.Name = "textBoxName";
		this.textBox_3.Size = new Size(151, 20);
		this.textBox_3.TabIndex = 3;
		this.textBox_3.Leave += this.textBox_3_Leave;
		this.comboBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(36, 5);
		this.comboBox_0.Name = "comboBox1";
		this.comboBox_0.Size = new Size(237, 21);
		this.comboBox_0.TabIndex = 0;
		this.comboBox_0.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
		this.comboBox_0.TextUpdate += this.comboBox_0_TextUpdate;
		this.comboBox_0.Leave += this.comboBox_0_Leave;
		this.button_2.Location = new Point(36, 3);
		this.button_2.Name = "buttonDelArea";
		this.button_2.Size = new Size(27, 23);
		this.button_2.TabIndex = 0;
		this.button_2.Text = "-";
		this.button_2.UseVisualStyleBackColor = true;
		this.button_2.Visible = false;
		this.button_2.Click += this.button_2_Click;
		this.button_3.Location = new Point(3, 3);
		this.button_3.Name = "buttonAddArea";
		this.button_3.Size = new Size(27, 23);
		this.button_3.TabIndex = 0;
		this.button_3.Text = "+";
		this.button_3.UseVisualStyleBackColor = true;
		this.button_3.Click += this.button_3_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(401, 205);
		base.Controls.Add(this.splitContainer_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		this.MinimumSize = new Size(417, 243);
		base.Name = "FormApplicationsSetting";
		this.Text = "Настройки";
		base.FormClosing += this.Form73_FormClosing;
		base.Load += this.Form73_Load;
		this.splitContainer_0.Panel1.ResumeLayout(false);
		this.splitContainer_0.Panel2.ResumeLayout(false);
		this.splitContainer_0.ResumeLayout(false);
		this.panel_1.ResumeLayout(false);
		this.panel_1.PerformLayout();
		this.panel_0.ResumeLayout(false);
		this.panel_2.ResumeLayout(false);
		this.panel_2.PerformLayout();
		base.ResumeLayout(false);
	}

	private Dictionary<string, Class167> dictionary_0;

	private Button button_0;

	private Button button_1;

	private SplitContainer splitContainer_0;

	private ListBox listBox_0;

	private Panel panel_0;

	private Panel panel_1;

	private ComboBox comboBox_0;

	private Button button_2;

	private Button button_3;

	private Panel panel_2;

	private Label label_0;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private TextBox textBox_3;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private Label label_4;

	private Label label_5;

	private Label label_6;

	private Label label_7;

	private Label label_8;

	private TextBox textBox_4;

	private TextBox textBox_5;

	private TextBox textBox_6;

	private TextBox textBox_7;

	private TextBox textBox_8;
}
