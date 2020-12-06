using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using ControlsLbr;
using FormLbr;

internal partial class Form82 : FormBase
{
	internal Form82()
	{
		
		
		this.method_3();
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		this.groupBox_0.Enabled = (this.groupBox_1.Enabled = (this.treeDataGridView_0.Enabled = this.checkBox_0.Checked));
	}

	private void Form82_Load(object sender, EventArgs e)
	{
		base.SelectSqlData(this.dataTable_0, true, string.Format("where module = '{0}'", "DamageMail"), null, false, 0);
		if (this.dataTable_0.Rows.Count > 0)
		{
			this.method_0();
		}
	}

	private void method_0()
	{
		if (this.dataTable_0.Rows.Count > 0 && this.dataTable_0.Rows[0]["Settings"] != DBNull.Value)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(this.dataTable_0.Rows[0]["Settings"].ToString());
			XmlNode xmlNode = xmlDocument.SelectSingleNode("DamageMail");
			if (xmlNode != null)
			{
				XmlAttribute xmlAttribute = xmlNode.Attributes["useMail"];
				if (xmlAttribute != null)
				{
					this.checkBox_0.Checked = Convert.ToBoolean(xmlAttribute.Value);
				}
				XmlNode xmlNode2 = xmlNode.SelectSingleNode("SMTP");
				if (xmlNode2 != null)
				{
					xmlAttribute = xmlNode2.Attributes["Name"];
					if (xmlAttribute != null)
					{
						this.textBox_4.Text = xmlAttribute.Value;
					}
					xmlAttribute = xmlNode2.Attributes["Port"];
					if (xmlAttribute != null && !string.IsNullOrEmpty(xmlAttribute.Value))
					{
						this.numericUpDown_0.Value = Convert.ToInt32(xmlAttribute.Value);
					}
					xmlAttribute = xmlNode2.Attributes["Login"];
					if (xmlAttribute != null)
					{
						this.textBox_3.Text = xmlAttribute.Value;
					}
					xmlAttribute = xmlNode2.Attributes["Pwd"];
					if (xmlAttribute != null)
					{
						this.textBox_2.Text = xmlAttribute.Value;
					}
				}
				XmlNode xmlNode3 = xmlNode.SelectSingleNode("Sender");
				if (xmlNode3 != null)
				{
					xmlAttribute = xmlNode3.Attributes["Address"];
					if (xmlAttribute != null)
					{
						this.textBox_1.Text = xmlAttribute.Value;
					}
					xmlAttribute = xmlNode3.Attributes["Name"];
					if (xmlAttribute != null)
					{
						this.textBox_0.Text = xmlAttribute.Value;
					}
				}
			}
			DataTable dataTable_ = Class227.smethod_1(xmlDocument, this.SqlSettings);
			this.method_2(dataTable_);
		}
	}

	private XmlDocument method_1()
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlNode xmlNode = xmlDocument.CreateElement("DamageMail");
		xmlDocument.AppendChild(xmlNode);
		XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("useMail");
		xmlAttribute.Value = this.checkBox_0.Checked.ToString();
		xmlNode.Attributes.Append(xmlAttribute);
		XmlNode xmlNode2 = xmlDocument.CreateElement("SMTP");
		xmlNode.AppendChild(xmlNode2);
		xmlAttribute = xmlDocument.CreateAttribute("Name");
		xmlAttribute.Value = this.textBox_4.Text;
		xmlNode2.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("Port");
		xmlAttribute.Value = this.numericUpDown_0.Value.ToString();
		xmlNode2.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("Login");
		xmlAttribute.Value = this.textBox_3.Text;
		xmlNode2.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("Pwd");
		xmlAttribute.Value = this.textBox_2.Text;
		xmlNode2.Attributes.Append(xmlAttribute);
		XmlNode xmlNode3 = xmlDocument.CreateElement("Sender");
		xmlNode.AppendChild(xmlNode3);
		xmlAttribute = xmlDocument.CreateAttribute("Address");
		xmlAttribute.Value = this.textBox_1.Text;
		xmlNode3.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("Name");
		xmlAttribute.Value = this.textBox_0.Text;
		xmlNode3.Attributes.Append(xmlAttribute);
		XmlNode xmlNode4 = xmlDocument.CreateElement("Recipients");
		xmlNode.AppendChild(xmlNode4);
		foreach (TreeDataGridViewNode treeDataGridViewNode in this.treeDataGridView_0.Nodes)
		{
			XmlNode xmlNode5 = xmlDocument.CreateElement("TagName");
			xmlNode4.AppendChild(xmlNode5);
			xmlAttribute = xmlDocument.CreateAttribute("TagName");
			xmlAttribute.Value = treeDataGridViewNode.Cells[0].Value.ToString();
			xmlNode5.Attributes.Append(xmlAttribute);
			foreach (TreeDataGridViewNode treeDataGridViewNode2 in treeDataGridViewNode.Nodes)
			{
				XmlNode xmlNode6 = xmlDocument.CreateElement("Division");
				xmlNode5.AppendChild(xmlNode6);
				xmlAttribute = xmlDocument.CreateAttribute("DivName");
				xmlAttribute.Value = treeDataGridViewNode2.Cells[0].Value.ToString();
				xmlNode6.Attributes.Append(xmlAttribute);
				xmlAttribute = xmlDocument.CreateAttribute("DivId");
				xmlAttribute.Value = treeDataGridViewNode2.Cells[1].Value.ToString();
				xmlNode6.Attributes.Append(xmlAttribute);
				foreach (TreeDataGridViewNode treeDataGridViewNode3 in treeDataGridViewNode2.Nodes)
				{
					XmlNode xmlNode7 = xmlDocument.CreateElement("Contact");
					xmlNode6.AppendChild(xmlNode7);
					xmlAttribute = xmlDocument.CreateAttribute("FIO");
					xmlAttribute.Value = treeDataGridViewNode3.Cells[2].Value.ToString();
					xmlNode7.Attributes.Append(xmlAttribute);
					xmlAttribute = xmlDocument.CreateAttribute("IdWorker");
					xmlAttribute.Value = treeDataGridViewNode3.Cells[3].Value.ToString();
					xmlNode7.Attributes.Append(xmlAttribute);
					xmlAttribute = xmlDocument.CreateAttribute("Contact");
					xmlAttribute.Value = treeDataGridViewNode3.Cells[4].Value.ToString();
					xmlNode7.Attributes.Append(xmlAttribute);
				}
			}
		}
		return xmlDocument;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (this.dataTable_0.Rows.Count == 0)
		{
			DataRow row = this.dataTable_0.NewRow();
			this.dataTable_0.Rows.Add(row);
		}
		this.dataTable_0.Rows[0]["Settings"] = this.method_1().InnerXml;
		this.dataTable_0.Rows[0]["Module"] = "DamageMail";
		this.dataTable_0.Rows[0].EndEdit();
		if (!base.InsertSqlData(this.dataTable_0))
		{
			return;
		}
		if (!base.UpdateSqlData(this.dataTable_0))
		{
			return;
		}
		base.Close();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		Form85 form = new Form85((Form85.Enum21)0, (Form85.Enum22)0, null);
		form.SqlSettings = this.SqlSettings;
		if (form.ShowDialog() == DialogResult.OK)
		{
			this.treeDataGridView_0.Nodes.Add(form.TagName);
		}
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		if (this.treeDataGridView_0.CurrentRow == null)
		{
			MessageBox.Show("Невозможно добавить подразделение. Сначала добавьте тэг.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		TreeDataGridViewNode nodeForRow = this.treeDataGridView_0.GetNodeForRow(this.treeDataGridView_0.CurrentRow);
		Form85 form = new Form85((Form85.Enum21)0, (Form85.Enum22)1, nodeForRow);
		form.SqlSettings = this.SqlSettings;
		if (form.ShowDialog() == DialogResult.OK)
		{
			switch (nodeForRow.Level)
			{
			case 1:
				nodeForRow.Nodes.Add(new object[]
				{
					form.method_0(),
					form.method_1()
				});
				return;
			case 2:
				nodeForRow.Parent.Nodes.Add(new object[]
				{
					form.method_0(),
					form.method_1()
				});
				return;
			case 3:
				nodeForRow.Parent.Parent.Nodes.Add(new object[]
				{
					form.method_0(),
					form.method_1()
				});
				break;
			default:
				return;
			}
		}
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		if (this.treeDataGridView_0.CurrentRow == null)
		{
			MessageBox.Show("Невозможно добавить контакт. Сначала добавьте тэг и подразделение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		TreeDataGridViewNode nodeForRow = this.treeDataGridView_0.GetNodeForRow(this.treeDataGridView_0.CurrentRow);
		if (nodeForRow.Level == 1)
		{
			MessageBox.Show("Невозможно добавить контакт. Выберите подразделение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		Form85 form = new Form85((Form85.Enum21)0, (Form85.Enum22)2, nodeForRow);
		form.SqlSettings = this.SqlSettings;
		if (form.ShowDialog() == DialogResult.OK)
		{
			int level = nodeForRow.Level;
			if (level == 2)
			{
				nodeForRow.Nodes.Add(new object[]
				{
					"",
					"",
					form.method_2(),
					form.method_3(),
					form.Contact
				});
				return;
			}
			if (level != 3)
			{
				return;
			}
			nodeForRow.Parent.Nodes.Add(new object[]
			{
				"",
				"",
				form.method_2(),
				form.method_3(),
				form.Contact
			});
		}
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		if (this.treeDataGridView_0.CurrentRow == null)
		{
			MessageBox.Show("Выберите строку для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		TreeDataGridViewNode nodeForRow = this.treeDataGridView_0.GetNodeForRow(this.treeDataGridView_0.CurrentRow);
		Form85.Enum22 enum22_ = (Form85.Enum22)0;
		switch (nodeForRow.Level)
		{
		case 1:
			enum22_ = (Form85.Enum22)0;
			break;
		case 2:
			enum22_ = (Form85.Enum22)1;
			break;
		case 3:
			enum22_ = (Form85.Enum22)2;
			break;
		}
		Form85 form = new Form85((Form85.Enum21)1, enum22_, nodeForRow);
		form.SqlSettings = this.SqlSettings;
		if (form.ShowDialog() == DialogResult.OK)
		{
			switch (nodeForRow.Level)
			{
			case 1:
				nodeForRow.Cells[0].Value = form.TagName;
				return;
			case 2:
				nodeForRow.Cells[0].Value = form.method_0();
				nodeForRow.Cells[1].Value = form.method_1();
				return;
			case 3:
				nodeForRow.Cells[2].Value = form.method_2();
				nodeForRow.Cells[3].Value = form.method_3();
				nodeForRow.Cells[4].Value = form.Contact;
				break;
			default:
				return;
			}
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		if (this.treeDataGridView_0.CurrentRow != null)
		{
			TreeDataGridViewNode nodeForRow = this.treeDataGridView_0.GetNodeForRow(this.treeDataGridView_0.CurrentRow);
			if (nodeForRow.Parent == null)
			{
				this.treeDataGridView_0.Nodes.Remove(nodeForRow);
				return;
			}
			nodeForRow.Parent.Nodes.Remove(nodeForRow);
		}
	}

	private void method_2(DataTable dataTable_1)
	{
		this.treeDataGridView_0.Nodes.Clear();
		string text = "";
		int? num = null;
		TreeDataGridViewNode treeDataGridViewNode = null;
		TreeDataGridViewNode treeDataGridViewNode2 = null;
		foreach (object obj in dataTable_1.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			if (dataRow["Tag"].ToString() != text)
			{
				text = dataRow["Tag"].ToString();
				treeDataGridViewNode = this.treeDataGridView_0.Nodes.Add(text);
				num = null;
				treeDataGridViewNode2 = null;
			}
			if (dataRow["DivId"] != DBNull.Value && Convert.ToInt32(dataRow["divId"]) != num && treeDataGridViewNode != null)
			{
				num = new int?(Convert.ToInt32(Convert.ToInt32(dataRow["divId"])));
				treeDataGridViewNode2 = treeDataGridViewNode.Nodes.Add(new object[]
				{
					dataRow["DivName"].ToString(),
					num
				});
			}
			if (dataRow["idWorker"] != DBNull.Value && treeDataGridViewNode2 != null)
			{
				treeDataGridViewNode2.Nodes.Add(new object[]
				{
					"",
					"",
					dataRow["FIO"].ToString(),
					Convert.ToInt32(dataRow["idWorker"]),
					dataRow["Contact"].ToString()
				});
			}
		}
	}

	private void method_3()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form82));
		this.checkBox_0 = new CheckBox();
		this.label_0 = new Label();
		this.groupBox_0 = new GroupBox();
		this.label_1 = new Label();
		this.textBox_0 = new TextBox();
		this.label_2 = new Label();
		this.textBox_1 = new TextBox();
		this.groupBox_1 = new GroupBox();
		this.label_3 = new Label();
		this.textBox_2 = new TextBox();
		this.label_4 = new Label();
		this.textBox_3 = new TextBox();
		this.label_5 = new Label();
		this.numericUpDown_0 = new NumericUpDown();
		this.label_6 = new Label();
		this.textBox_4 = new TextBox();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.dataSet_0 = new DataSet();
		this.dataTable_0 = new DataTable();
		this.dataColumn_0 = new DataColumn();
		this.dataColumn_1 = new DataColumn();
		this.dataColumn_2 = new DataColumn();
		this.treeDataGridView_0 = new TreeDataGridView();
		this.treeGridColumn_0 = new TreeGridColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripDropDownButton_0 = new ToolStripDropDownButton();
		this.toolStripMenuItem_0 = new ToolStripMenuItem();
		this.toolStripMenuItem_1 = new ToolStripMenuItem();
		this.toolStripMenuItem_2 = new ToolStripMenuItem();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripButton_1 = new ToolStripButton();
		this.groupBox_0.SuspendLayout();
		this.groupBox_1.SuspendLayout();
		((ISupportInitialize)this.numericUpDown_0).BeginInit();
		((ISupportInitialize)this.dataSet_0).BeginInit();
		((ISupportInitialize)this.dataTable_0).BeginInit();
		((ISupportInitialize)this.treeDataGridView_0).BeginInit();
		this.toolStrip_0.SuspendLayout();
		base.SuspendLayout();
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Location = new Point(12, 12);
		this.checkBox_0.Name = "chkSendMail";
		this.checkBox_0.Size = new Size(116, 17);
		this.checkBox_0.TabIndex = 0;
		this.checkBox_0.Text = "Отправлять почту";
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.CheckedChanged += this.checkBox_0_CheckedChanged;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(9, 191);
		this.label_0.Name = "label27";
		this.label_0.Size = new Size(97, 13);
		this.label_0.TabIndex = 32;
		this.label_0.Text = "Тэги получателей";
		this.groupBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_0.Controls.Add(this.label_1);
		this.groupBox_0.Controls.Add(this.textBox_0);
		this.groupBox_0.Controls.Add(this.label_2);
		this.groupBox_0.Controls.Add(this.textBox_1);
		this.groupBox_0.Location = new Point(3, 114);
		this.groupBox_0.Name = "groupBoxSender";
		this.groupBox_0.Size = new Size(802, 74);
		this.groupBox_0.TabIndex = 31;
		this.groupBox_0.TabStop = false;
		this.groupBox_0.Text = "Отправитель";
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(6, 48);
		this.label_1.Name = "label26";
		this.label_1.Size = new Size(29, 13);
		this.label_1.TabIndex = 4;
		this.label_1.Text = "Имя";
		this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_0.Location = new Point(80, 45);
		this.textBox_0.Name = "txtSenderNamePlanned";
		this.textBox_0.Size = new Size(716, 20);
		this.textBox_0.TabIndex = 3;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(6, 22);
		this.label_2.Name = "label25";
		this.label_2.Size = new Size(38, 13);
		this.label_2.TabIndex = 2;
		this.label_2.Text = "Адрес";
		this.textBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_1.Location = new Point(80, 19);
		this.textBox_1.Name = "txtSenderAddressPlanned";
		this.textBox_1.Size = new Size(716, 20);
		this.textBox_1.TabIndex = 1;
		this.groupBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.groupBox_1.Controls.Add(this.label_3);
		this.groupBox_1.Controls.Add(this.textBox_2);
		this.groupBox_1.Controls.Add(this.label_4);
		this.groupBox_1.Controls.Add(this.textBox_3);
		this.groupBox_1.Controls.Add(this.label_5);
		this.groupBox_1.Controls.Add(this.numericUpDown_0);
		this.groupBox_1.Controls.Add(this.label_6);
		this.groupBox_1.Controls.Add(this.textBox_4);
		this.groupBox_1.Location = new Point(3, 35);
		this.groupBox_1.Name = "groupBoxSMTP";
		this.groupBox_1.Size = new Size(802, 73);
		this.groupBox_1.TabIndex = 30;
		this.groupBox_1.TabStop = false;
		this.groupBox_1.Text = "SMTP-сервер (сервер отправки)";
		this.label_3.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(608, 48);
		this.label_3.Name = "label24";
		this.label_3.Size = new Size(45, 13);
		this.label_3.TabIndex = 7;
		this.label_3.Text = "Пароль";
		this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.textBox_2.Location = new Point(659, 45);
		this.textBox_2.Name = "txtPwdSMTPPlanned";
		this.textBox_2.PasswordChar = '*';
		this.textBox_2.Size = new Size(137, 20);
		this.textBox_2.TabIndex = 6;
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(6, 48);
		this.label_4.Name = "label23";
		this.label_4.Size = new Size(38, 13);
		this.label_4.TabIndex = 5;
		this.label_4.Text = "Логин";
		this.textBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_3.Location = new Point(80, 45);
		this.textBox_3.Name = "txtLoginSMTPPlanned";
		this.textBox_3.Size = new Size(522, 20);
		this.textBox_3.TabIndex = 4;
		this.label_5.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(679, 22);
		this.label_5.Name = "label22";
		this.label_5.Size = new Size(32, 13);
		this.label_5.TabIndex = 3;
		this.label_5.Text = "Порт";
		this.numericUpDown_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.numericUpDown_0.Location = new Point(717, 19);
		NumericUpDown numericUpDown = this.numericUpDown_0;
		int[] array = new int[4];
		array[0] = 999999;
		numericUpDown.Maximum = new decimal(array);
		this.numericUpDown_0.Name = "txtSMTPServerPortPlanned";
		this.numericUpDown_0.Size = new Size(79, 20);
		this.numericUpDown_0.TabIndex = 2;
		this.label_6.AutoSize = true;
		this.label_6.Location = new Point(6, 22);
		this.label_6.Name = "label21";
		this.label_6.Size = new Size(74, 13);
		this.label_6.TabIndex = 1;
		this.label_6.Text = "Имя сервера";
		this.textBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_4.Location = new Point(80, 19);
		this.textBox_4.Name = "txtSMTPServerPlanned";
		this.textBox_4.Size = new Size(593, 20);
		this.textBox_4.TabIndex = 0;
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.Location = new Point(12, 352);
		this.button_0.Name = "buttonSave";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 34;
		this.button_0.Text = "Сохранить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.Location = new Point(720, 352);
		this.button_1.Name = "buttonClose";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 36;
		this.button_1.Text = "Закрыть";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
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
		this.dataTable_0.Constraints.AddRange(new Constraint[]
		{
			new UniqueConstraint("Constraint1", new string[]
			{
				"id"
			}, true)
		});
		this.dataTable_0.PrimaryKey = new DataColumn[]
		{
			this.dataColumn_0
		};
		this.dataTable_0.TableName = "tSettings";
		this.dataColumn_0.AllowDBNull = false;
		this.dataColumn_0.AutoIncrement = true;
		this.dataColumn_0.ColumnName = "id";
		this.dataColumn_0.DataType = typeof(int);
		this.dataColumn_1.ColumnName = "settings";
		this.dataColumn_2.ColumnName = "module";
		this.treeDataGridView_0.AllowUserToAddRows = false;
		this.treeDataGridView_0.AllowUserToDeleteRows = false;
		this.treeDataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.treeDataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.treeGridColumn_0,
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewTextBoxColumn_3
		});
		this.treeDataGridView_0.EditMode = DataGridViewEditMode.EditProgrammatically;
		this.treeDataGridView_0.ImageList = null;
		this.treeDataGridView_0.Location = new Point(3, 232);
		this.treeDataGridView_0.MultiSelect = false;
		this.treeDataGridView_0.Name = "dgvTree";
		this.treeDataGridView_0.Size = new Size(802, 114);
		this.treeDataGridView_0.TabIndex = 37;
		this.treeGridColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.treeGridColumn_0.DefaultNodeImage = null;
		this.treeGridColumn_0.HeaderText = "Тэг\\Подразделение";
		this.treeGridColumn_0.Name = "tagColumn";
		this.treeGridColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_0.HeaderText = "idDivision";
		this.dataGridViewTextBoxColumn_0.Name = "idDivisionColumn";
		this.dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_1.HeaderText = "ФИО";
		this.dataGridViewTextBoxColumn_1.Name = "workerColumn";
		this.dataGridViewTextBoxColumn_1.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_2.HeaderText = "idWorker";
		this.dataGridViewTextBoxColumn_2.Name = "idWorkerColumn";
		this.dataGridViewTextBoxColumn_2.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_2.Visible = false;
		this.dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_3.HeaderText = "Контакт";
		this.dataGridViewTextBoxColumn_3.Name = "contactColumn";
		this.dataGridViewTextBoxColumn_3.SortMode = DataGridViewColumnSortMode.NotSortable;
		this.toolStrip_0.Dock = DockStyle.None;
		this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripDropDownButton_0,
			this.toolStripButton_0,
			this.toolStripButton_1
		});
		this.toolStrip_0.Location = new Point(13, 204);
		this.toolStrip_0.Name = "toolStrip1";
		this.toolStrip_0.Size = new Size(78, 25);
		this.toolStrip_0.TabIndex = 38;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripDropDownButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripDropDownButton_0.DropDownItems.AddRange(new ToolStripItem[]
		{
			this.toolStripMenuItem_0,
			this.toolStripMenuItem_1,
			this.toolStripMenuItem_2
		});
		this.toolStripDropDownButton_0.Image = (Image)componentResourceManager.GetObject("toolBtnAdd.Image");
		this.toolStripDropDownButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripDropDownButton_0.Name = "toolBtnAdd";
		this.toolStripDropDownButton_0.Size = new Size(29, 22);
		this.toolStripDropDownButton_0.Text = "Добавить";
		this.toolStripMenuItem_0.Name = "toolMenuItemTagAdd";
		this.toolStripMenuItem_0.Size = new Size(159, 22);
		this.toolStripMenuItem_0.Text = "Тэг";
		this.toolStripMenuItem_0.Click += this.toolStripMenuItem_0_Click;
		this.toolStripMenuItem_1.Name = "toolMenuItemDivisionAdd";
		this.toolStripMenuItem_1.Size = new Size(159, 22);
		this.toolStripMenuItem_1.Text = "Подразделение";
		this.toolStripMenuItem_1.Click += this.toolStripMenuItem_1_Click;
		this.toolStripMenuItem_2.Name = "toolMenuItemContactAdd";
		this.toolStripMenuItem_2.Size = new Size(159, 22);
		this.toolStripMenuItem_2.Text = "Контакт";
		this.toolStripMenuItem_2.Click += this.toolStripMenuItem_2_Click;
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("toolBtnEdit.Image");
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtnEdit";
		this.toolStripButton_0.Size = new Size(23, 22);
		this.toolStripButton_0.Text = "Редактировать";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("toolBtnDel.Image");
		this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_1.Name = "toolBtnDel";
		this.toolStripButton_1.Size = new Size(23, 22);
		this.toolStripButton_1.Text = "Удалить";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(810, 387);
		base.Controls.Add(this.toolStrip_0);
		base.Controls.Add(this.treeDataGridView_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.groupBox_0);
		base.Controls.Add(this.groupBox_1);
		base.Controls.Add(this.checkBox_0);
		base.Name = "FormDamageSettingMail";
		this.Text = "Настройки отправки почты (смс)";
		base.Load += this.Form82_Load;
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		this.groupBox_1.ResumeLayout(false);
		this.groupBox_1.PerformLayout();
		((ISupportInitialize)this.numericUpDown_0).EndInit();
		((ISupportInitialize)this.dataSet_0).EndInit();
		((ISupportInitialize)this.dataTable_0).EndInit();
		((ISupportInitialize)this.treeDataGridView_0).EndInit();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private CheckBox checkBox_0;

	private Label label_0;

	private GroupBox groupBox_0;

	private Label label_1;

	private TextBox textBox_0;

	private Label label_2;

	private TextBox textBox_1;

	private GroupBox groupBox_1;

	private Label label_3;

	private TextBox textBox_2;

	private Label label_4;

	private TextBox textBox_3;

	private Label label_5;

	private NumericUpDown numericUpDown_0;

	private Label label_6;

	private TextBox textBox_4;

	private Button button_0;

	private Button button_1;

	private DataSet dataSet_0;

	private DataTable dataTable_0;

	private DataColumn dataColumn_0;

	private DataColumn dataColumn_1;

	private DataColumn dataColumn_2;

	private TreeDataGridView treeDataGridView_0;

	private ToolStrip toolStrip_0;

	private ToolStripDropDownButton toolStripDropDownButton_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private TreeGridColumn treeGridColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;
}
