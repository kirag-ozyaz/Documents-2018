using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using FormLbr;
using FormLbr.Classes;
using MarkupConverter;

internal partial class Form49 : FormBase
{
	internal int? IdRequest
	{
		get
		{
			return this.nullable_0;
		}
	}

	internal Form49(int? nullable_1 = null)
	{
		
		
		this.method_5();
		this.nullable_0 = nullable_1;
	}

	private void Form49_Load(object sender, EventArgs e)
	{
		this.method_0();
		base.LoadFormConfig(null);
		if (this.nullable_0 != null)
		{
			TextBox textBox = this.textBox_0;
			textBox.Text += this.nullable_0.ToString();
		}
	}

	private void method_0()
	{
		DataTable dataTable = new DataTable("vR_worker");
		dataTable.Columns.Add(new DataColumn("id", typeof(int)));
		dataTable.Columns.Add(new DataColumn("fio", typeof(string)));
		new BindingSource().DataSource = dataTable;
		base.SelectSqlData(dataTable, true, "where dateEnd is null order by fio", null, false, 0);
		foreach (object obj in dataTable.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			this.dataGridViewComboBoxColumn_0.Items.Add(dataRow["fio"].ToString());
		}
	}

	private void Form49_FormClosing(object sender, FormClosingEventArgs e)
	{
		base.SaveFormConfig(null);
	}

	protected override XmlDocument CreateXmlConfig()
	{
		XmlDocument xmlDocument = new XmlDocument();
		XmlNode xmlNode = xmlDocument.CreateElement(base.Name);
		xmlDocument.AppendChild(xmlNode);
		XmlNode xmlNode2 = xmlDocument.CreateElement("Mail");
		xmlNode.AppendChild(xmlNode2);
		XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("Subject");
		xmlAttribute.Value = this.textBox_0.Text;
		xmlNode2.Attributes.Append(xmlAttribute);
		XmlNode xmlNode3 = xmlDocument.CreateElement("SMTP");
		xmlNode2.AppendChild(xmlNode3);
		xmlAttribute = xmlDocument.CreateAttribute("Name");
		xmlAttribute.Value = this.textBox_5.Text;
		xmlNode3.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("Port");
		xmlAttribute.Value = this.zQsoqvmPysY.Text;
		xmlNode3.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("Login");
		xmlAttribute.Value = this.textBox_2.Text;
		xmlNode3.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("Password");
		xmlAttribute.Value = Form49.smethod_0(this.textBox_3.Text);
		xmlNode3.Attributes.Append(xmlAttribute);
		XmlNode xmlNode4 = xmlDocument.CreateElement("Sender");
		xmlNode2.AppendChild(xmlNode4);
		xmlAttribute = xmlDocument.CreateAttribute("Address");
		xmlAttribute.Value = this.textBox_1.Text;
		xmlNode4.Attributes.Append(xmlAttribute);
		xmlAttribute = xmlDocument.CreateAttribute("Name");
		xmlAttribute.Value = this.textBox_4.Text;
		xmlNode4.Attributes.Append(xmlAttribute);
		XmlNode xmlNode5 = xmlDocument.CreateElement("Recipients");
		xmlNode2.AppendChild(xmlNode5);
		for (int i = 0; i < this.dataGridView_0.Rows.Count - 1; i++)
		{
			XmlNode xmlNode6 = xmlDocument.CreateElement("Recipient");
			xmlNode5.AppendChild(xmlNode6);
			xmlAttribute = xmlDocument.CreateAttribute("Address");
			if (this.dataGridView_0[this.dataGridViewTextBoxColumn_0.Name, i].Value == null)
			{
				xmlAttribute.Value = "";
			}
			else
			{
				xmlAttribute.Value = this.dataGridView_0[this.dataGridViewTextBoxColumn_0.Name, i].Value.ToString();
			}
			xmlNode6.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("Name");
			xmlAttribute.Value = this.dataGridView_0[this.dataGridViewComboBoxColumn_0.Name, i].Value.ToString();
			xmlNode6.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("IsSend");
			if (this.dataGridView_0[this.dataGridViewCheckBoxColumn_0.Name, i].Value != null && Convert.ToBoolean(this.dataGridView_0[this.dataGridViewCheckBoxColumn_0.Name, i].Value))
			{
				xmlAttribute.Value = true.ToString();
			}
			else
			{
				xmlAttribute.Value = false.ToString();
			}
			xmlNode6.Attributes.Append(xmlAttribute);
		}
		return xmlDocument;
	}

	protected override void ApplyConfig(XmlDocument xmlDocument_0)
	{
		this.dataGridView_0.Rows.Clear();
		XmlNode xmlNode = xmlDocument_0.SelectSingleNode(base.Name);
		if (xmlNode != null)
		{
			XmlNode xmlNode2 = xmlNode.SelectSingleNode("Mail");
			if (xmlNode2 == null)
			{
				return;
			}
			XmlNode xmlNode3 = xmlNode2.SelectSingleNode("SMTP");
			if (xmlNode3 == null)
			{
				return;
			}
			XmlAttribute xmlAttribute = xmlNode3.Attributes["Name"];
			if (xmlAttribute != null)
			{
				this.textBox_5.Text = xmlAttribute.Value;
			}
			xmlAttribute = xmlNode3.Attributes["Port"];
			if (xmlAttribute != null)
			{
				this.zQsoqvmPysY.Text = xmlAttribute.Value;
			}
			xmlAttribute = xmlNode3.Attributes["Login"];
			if (xmlAttribute != null)
			{
				this.textBox_2.Text = xmlAttribute.Value;
			}
			xmlAttribute = xmlNode3.Attributes["Password"];
			if (xmlAttribute != null)
			{
				this.textBox_3.Text = Form49.smethod_1(xmlAttribute.Value);
			}
			XmlNode xmlNode4 = xmlNode2.SelectSingleNode("Sender");
			if (xmlNode4 == null)
			{
				return;
			}
			xmlAttribute = xmlNode4.Attributes["Address"];
			if (xmlAttribute != null)
			{
				this.textBox_1.Text = xmlAttribute.Value;
			}
			xmlAttribute = xmlNode4.Attributes["Name"];
			if (xmlAttribute != null)
			{
				this.textBox_4.Text = xmlAttribute.Value;
			}
			XmlNode xmlNode5 = xmlNode2.SelectSingleNode("Recipients");
			if (xmlNode5 == null)
			{
				return;
			}
			XmlNodeList xmlNodeList = xmlNode5.SelectNodes("Recipient");
			if (xmlNodeList != null)
			{
				foreach (object obj in xmlNodeList)
				{
					XmlNode xmlNode6 = (XmlNode)obj;
					object obj2 = -1;
					object value = "";
					xmlAttribute = xmlNode6.Attributes["Address"];
					if (xmlAttribute != null)
					{
						value = xmlAttribute.Value;
					}
					xmlAttribute = xmlNode6.Attributes["Name"];
					if (xmlAttribute != null)
					{
						obj2 = xmlAttribute.Value;
					}
					bool flag = false;
					xmlAttribute = xmlNode6.Attributes["IsSend"];
					if (xmlAttribute != null)
					{
						flag = Convert.ToBoolean(xmlAttribute.Value);
					}
					this.dataGridView_0.Rows.Add(1);
					if (!((DataGridViewComboBoxCell)this.dataGridView_0.Rows[this.dataGridView_0.Rows.Count - 2].Cells[this.dataGridViewComboBoxColumn_0.Name]).Items.Contains(obj2))
					{
						((DataGridViewComboBoxCell)this.dataGridView_0.Rows[this.dataGridView_0.Rows.Count - 2].Cells[this.dataGridViewComboBoxColumn_0.Name]).Items.Add(obj2);
					}
					this.dataGridView_0.Rows[this.dataGridView_0.Rows.Count - 2].Cells[this.dataGridViewComboBoxColumn_0.Name].Value = obj2;
					this.dataGridView_0.Rows[this.dataGridView_0.Rows.Count - 2].Cells[this.dataGridViewTextBoxColumn_0.Name].Value = value;
					this.dataGridView_0.Rows[this.dataGridView_0.Rows.Count - 2].Cells[this.dataGridViewCheckBoxColumn_0.Name].Value = flag;
				}
			}
		}
	}

	private static string smethod_0(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return "";
		}
		DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
		MemoryStream memoryStream = new MemoryStream();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider.CreateEncryptor(Form49.byte_0, Form49.byte_0), CryptoStreamMode.Write);
		StreamWriter streamWriter = new StreamWriter(cryptoStream);
		streamWriter.Write(string_0);
		streamWriter.Flush();
		cryptoStream.FlushFinalBlock();
		streamWriter.Flush();
		return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
	}

	private static string smethod_1(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
		}
		DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
		return new StreamReader(new CryptoStream(new MemoryStream(Convert.FromBase64String(string_0)), descryptoServiceProvider.CreateDecryptor(Form49.byte_0, Form49.byte_0), CryptoStreamMode.Read)).ReadToEnd();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void dataGridView_0_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		if (e.Control is ComboBox)
		{
			(e.Control as ComboBox).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			(e.Control as ComboBox).AutoCompleteSource = AutoCompleteSource.ListItems;
			if ((e.Control as ComboBox).DropDownStyle != ComboBoxStyle.DropDown)
			{
				(e.Control as ComboBox).DropDownStyle = ComboBoxStyle.DropDown;
			}
			(e.Control as ComboBox).SelectedValueChanged -= this.method_1;
			(e.Control as ComboBox).SelectedValueChanged += this.method_1;
			(e.Control as ComboBox).SelectedIndexChanged -= this.method_1;
			(e.Control as ComboBox).SelectedIndexChanged += this.method_1;
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		if (this.dataGridView_0.CurrentCell != null && ((ComboBox)sender).SelectedItem != null)
		{
			string str = ((ComboBox)sender).SelectedItem.ToString();
			DataTable dataTable = base.SelectSqlData("tR_WorkerContact", true, " left join  vr_worker v on tr_workercontact.worker = v.id where v.fio = '" + str + "' and tr_workercontact.Type = 44");
			if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["Description"] != DBNull.Value)
			{
				this.dataGridView_0[this.dataGridViewTextBoxColumn_0.Name, this.dataGridView_0.CurrentCell.RowIndex].Value = dataTable.Rows[0]["Description"].ToString();
			}
			else
			{
				this.dataGridView_0[this.dataGridViewTextBoxColumn_0.Name, this.dataGridView_0.CurrentCell.RowIndex].Value = "адрес не задан";
			}
			this.dataGridView_0[this.dataGridViewCheckBoxColumn_0.Name, this.dataGridView_0.CurrentCell.RowIndex].Value = false;
		}
	}

	private void dataGridView_0_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
	{
		if (e.ColumnIndex == this.dataGridView_0.Columns[this.dataGridViewComboBoxColumn_0.Name].Index)
		{
			DataGridViewComboBoxCell dataGridViewComboBoxCell = this.dataGridView_0.CurrentCell as DataGridViewComboBoxCell;
			if (dataGridViewComboBoxCell != null)
			{
				if (!dataGridViewComboBoxCell.Items.Contains(e.FormattedValue))
				{
					dataGridViewComboBoxCell.Items.Insert(0, e.FormattedValue);
					if (this.dataGridView_0.IsCurrentCellDirty)
					{
						this.dataGridView_0.CommitEdit(DataGridViewDataErrorContexts.Commit);
					}
					dataGridViewComboBoxCell.Value = e.FormattedValue;
					this.object_0 = e.FormattedValue;
					return;
				}
				this.object_0 = e.FormattedValue;
			}
		}
	}

	private void dataGridView_0_CellValidated(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == this.dataGridView_0.Columns[this.dataGridViewComboBoxColumn_0.Name].Index)
		{
			(this.dataGridView_0.CurrentCell as DataGridViewComboBoxCell).Value = this.object_0;
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (this.method_2(false))
		{
			if (this.nullable_0 != null)
			{
				Class255.Class258 @class = new Class255.Class258();
				base.SelectSqlData(@class, true, " where id = " + this.nullable_0.ToString(), null, false, 0);
				if (@class.Rows.Count > 0)
				{
					DataTable dataTable = new DataTable("tUser");
					dataTable.Columns.Add("Login", typeof(string));
					dataTable.Columns.Add("name", typeof(string));
					base.SelectSqlData(dataTable, true, " where [Login] = SYSTEM_USER ", null, false, 0);
					string value = "неопределено";
					if (dataTable.Rows.Count > 0)
					{
						if (dataTable.Rows[0]["name"] != DBNull.Value)
						{
							value = dataTable.Rows[0]["name"].ToString();
						}
						else
						{
							value = dataTable.Rows[0]["login"].ToString();
						}
					}
					@class.Rows[0]["dateSendMail"] = DateTime.Now;
					@class.Rows[0]["fioSendMail"] = value;
					@class.Rows[0].EndEdit();
					base.UpdateSqlData(@class);
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}
	}

	private static string smethod_2(byte[] byte_1)
	{
		char[] array = new char[byte_1.Length / 2];
		Buffer.BlockCopy(byte_1, 0, array, 0, byte_1.Length);
		return new string(array);
	}

	private bool method_2(bool bool_0 = false)
	{
		bool result;
		try
		{
			if (this.dataGridView_0.Rows.Count > 0 && this.nullable_0 != null)
			{
				base.SelectSqlData(this.class255_0, this.class255_0.vJ_Request, true, " where id = " + this.nullable_0.ToString());
				base.SelectSqlData(this.class255_0, this.class255_0.tJ_Request, true, " where id = " + this.nullable_0.ToString());
				base.SelectSqlData(this.class255_0, this.class255_0.tJ_RequestDoc, true, "where idRequest = " + this.nullable_0.ToString());
				if (this.class255_0.vJ_Request.Rows.Count > 0)
				{
					string text = "<b>Постановщик:</b> " + this.class255_0.vJ_Request.Rows[0]["nameUserTask"].ToString() + "<br>";
					text = text + "<b>Дата:</b> " + Convert.ToDateTime(this.class255_0.vJ_Request.Rows[0]["dateTask"]).ToString() + "<br>";
					text = text + "<b>Модуль:</b> " + this.class255_0.vJ_Request.Rows[0]["nameModul"].ToString() + "<br>";
					text = text + "<b>Кому:</b> " + this.class255_0.vJ_Request.Rows[0]["nameuserWhom"].ToString() + "<br>";
					if (this.class255_0.tJ_Request.Rows[0]["TextTaskBin"] != DBNull.Value)
					{
						text = text + "<b>Текст задачи:</b><br> " + RtfToHtmlConverter.ConvertRtfToHtml(Form49.smethod_2((byte[])this.class255_0.tJ_Request.Rows[0]["TextTaskBin"]));
					}
					else
					{
						text = text + "<b>Текст задачи:</b><br> " + this.class255_0.vJ_Request.Rows[0]["TextTask"].ToString() + "<br><br><br>";
					}
					if (this.class255_0.vJ_Request.Rows[0]["nameUserPerfom"] != DBNull.Value)
					{
						text = text + "<b>Исполнитель:</b> " + this.class255_0.vJ_Request.Rows[0]["nameUserPerfom"].ToString() + "<br>";
						if (this.class255_0.vJ_Request.Rows[0]["datePerfom"] != DBNull.Value)
						{
							text = text + "<b>Дата:</b> " + Convert.ToDateTime(this.class255_0.vJ_Request.Rows[0]["datePerfom"]).ToString() + "<br>";
						}
						if (this.class255_0.vJ_Request.Rows[0]["Comment"] != DBNull.Value)
						{
							text = text + "<b>Резюме:</b><br> " + this.class255_0.vJ_Request.Rows[0]["Comment"].ToString();
						}
					}
					List<string> list_ = this.method_4(this.class255_0.tJ_RequestDoc);
					bool flag = true;
					for (int i = 0; i < this.dataGridView_0.Rows.Count - 1; i++)
					{
						if (!bool_0 || !Convert.ToBoolean(this.dataGridView_0[this.dataGridViewCheckBoxColumn_0.Name, i].Value))
						{
							List<Struct6> list = new List<Struct6>();
							list.Add(new Struct6(this.dataGridView_0[this.dataGridViewTextBoxColumn_0.Name, i].Value.ToString(), this.dataGridView_0[this.dataGridViewComboBoxColumn_0.Name, i].FormattedValue.ToString()));
							if (Class129.smethod_13(this.textBox_5.Text, Convert.ToInt32(this.zQsoqvmPysY.Text), this.textBox_2.Text, this.textBox_3.Text, this.textBox_1.Text, this.textBox_4.Text, list, this.textBox_0.Text, text, list_, this.checkBox_0.Checked))
							{
								this.dataGridView_0[this.dataGridViewCheckBoxColumn_0.Name, i].Value = true;
							}
							else
							{
								this.dataGridView_0[this.dataGridViewCheckBoxColumn_0.Name, i].Value = false;
								flag = false;
							}
						}
					}
					result = flag;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.Source);
			result = false;
		}
		return result;
	}

	private string method_3()
	{
		string text = base.Name;
		if (string.IsNullOrEmpty(text))
		{
			text = "tmp";
		}
		string text2 = Path.GetTempPath() + "\\" + text + "\\";
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
		}
		return text2;
	}

	private List<string> method_4(DataTable dataTable_0)
	{
		List<string> list = new List<string>();
		foreach (object obj in dataTable_0.Rows)
		{
			DataRow dataRow = (DataRow)obj;
			string text = dataRow["FileName"].ToString();
			text = Path.GetFileName(text);
			string text2 = this.method_3();
			string newFileNameIsExists = FileBinary.GetNewFileNameIsExists(text2, text, false);
			byte[] inputByteArray;
			try
			{
				inputByteArray = (byte[])dataRow["document"];
			}
			catch
			{
				MessageBox.Show("Нет содержимого файла");
				continue;
			}
			FileBinary fileBinary = new FileBinary(inputByteArray, newFileNameIsExists, DateTime.Now);
			fileBinary.SaveToDisk(text2);
			list.Add(text2 + "\\" + fileBinary.Name);
		}
		return list;
	}

	private void method_5()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form49));
		this.button_0 = new Button();
		this.textBox_0 = new TextBox();
		this.label_0 = new Label();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewComboBoxColumn_0 = new DataGridViewComboBoxColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
		this.splitContainer_0 = new SplitContainer();
		this.textBox_1 = new TextBox();
		this.label_1 = new Label();
		this.textBox_2 = new TextBox();
		this.label_2 = new Label();
		this.textBox_3 = new TextBox();
		this.textBox_4 = new TextBox();
		this.label_3 = new Label();
		this.label_4 = new Label();
		this.zQsoqvmPysY = new TextBox();
		this.label_5 = new Label();
		this.textBox_5 = new TextBox();
		this.label_6 = new Label();
		this.button_1 = new Button();
		this.class255_0 = new Class255();
		this.checkBox_0 = new CheckBox();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		this.splitContainer_0.Panel1.SuspendLayout();
		this.splitContainer_0.Panel2.SuspendLayout();
		this.splitContainer_0.SuspendLayout();
		((ISupportInitialize)this.class255_0).BeginInit();
		base.SuspendLayout();
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.Location = new Point(15, 362);
		this.button_0.Name = "buttonSend";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 24;
		this.button_0.Text = "Отправить";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.textBox_0.Location = new Point(97, 144);
		this.textBox_0.Name = "txtSubject";
		this.textBox_0.Size = new Size(338, 20);
		this.textBox_0.TabIndex = 23;
		this.textBox_0.Text = "Энергосхема: Задача №";
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 147);
		this.label_0.Name = "label12";
		this.label_0.Size = new Size(75, 13);
		this.label_0.TabIndex = 22;
		this.label_0.Text = "Тема письма";
		this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewComboBoxColumn_0,
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewCheckBoxColumn_0
		});
		this.dataGridView_0.Location = new Point(12, 170);
		this.dataGridView_0.Name = "dgvRecipient";
		this.dataGridView_0.Size = new Size(760, 180);
		this.dataGridView_0.TabIndex = 21;
		this.dataGridView_0.CellValidated += this.dataGridView_0_CellValidated;
		this.dataGridView_0.CellValidating += this.dataGridView_0_CellValidating;
		this.dataGridView_0.EditingControlShowing += this.dataGridView_0_EditingControlShowing;
		this.dataGridViewComboBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewComboBoxColumn_0.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
		this.dataGridViewComboBoxColumn_0.HeaderText = "Имя получателя";
		this.dataGridViewComboBoxColumn_0.Name = "fioRecipientDgvColumn";
		this.dataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewTextBoxColumn_0.HeaderText = "Адрес получателя";
		this.dataGridViewTextBoxColumn_0.Name = "mailDgvColumn";
		this.dataGridViewCheckBoxColumn_0.HeaderText = "Отправлено";
		this.dataGridViewCheckBoxColumn_0.Name = "isSendDgvColumn";
		this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
		this.dataGridViewCheckBoxColumn_0.Visible = false;
		this.dataGridViewCheckBoxColumn_0.Width = 70;
		this.splitContainer_0.IsSplitterFixed = true;
		this.splitContainer_0.Location = new Point(12, 51);
		this.splitContainer_0.Name = "splitContainer1";
		this.splitContainer_0.Panel1.Controls.Add(this.textBox_1);
		this.splitContainer_0.Panel1.Controls.Add(this.label_1);
		this.splitContainer_0.Panel1.Controls.Add(this.textBox_2);
		this.splitContainer_0.Panel1.Controls.Add(this.label_2);
		this.splitContainer_0.Panel2.Controls.Add(this.textBox_3);
		this.splitContainer_0.Panel2.Controls.Add(this.textBox_4);
		this.splitContainer_0.Panel2.Controls.Add(this.label_3);
		this.splitContainer_0.Panel2.Controls.Add(this.label_4);
		this.splitContainer_0.Size = new Size(427, 87);
		this.splitContainer_0.SplitterDistance = 211;
		this.splitContainer_0.SplitterWidth = 1;
		this.splitContainer_0.TabIndex = 20;
		this.textBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_1.Location = new Point(14, 55);
		this.textBox_1.Name = "textBoxSenderAddress";
		this.textBox_1.Size = new Size(194, 20);
		this.textBox_1.TabIndex = 3;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(11, 39);
		this.label_1.Name = "label10";
		this.label_1.Size = new Size(105, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Адрес отправителя";
		this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_2.Location = new Point(14, 16);
		this.textBox_2.Name = "textBoxLogin";
		this.textBox_2.Size = new Size(194, 20);
		this.textBox_2.TabIndex = 1;
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(11, 0);
		this.label_2.Name = "label8";
		this.label_2.Size = new Size(38, 13);
		this.label_2.TabIndex = 0;
		this.label_2.Text = "Логин";
		this.textBox_3.Location = new Point(6, 16);
		this.textBox_3.Name = "textBoxPassword";
		this.textBox_3.PasswordChar = '☻';
		this.textBox_3.Size = new Size(206, 20);
		this.textBox_3.TabIndex = 8;
		this.textBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_4.Location = new Point(6, 55);
		this.textBox_4.Name = "textBoxSenderName";
		this.textBox_4.Size = new Size(205, 20);
		this.textBox_4.TabIndex = 5;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(3, 39);
		this.label_3.Name = "label11";
		this.label_3.Size = new Size(96, 13);
		this.label_3.TabIndex = 4;
		this.label_3.Text = "Имя отправителя";
		this.label_4.AutoSize = true;
		this.label_4.Location = new Point(3, 0);
		this.label_4.Name = "label4";
		this.label_4.Size = new Size(45, 13);
		this.label_4.TabIndex = 2;
		this.label_4.Text = "Пароль";
		this.zQsoqvmPysY.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		this.zQsoqvmPysY.Location = new Point(244, 25);
		this.zQsoqvmPysY.Name = "textBoxSmtpPort";
		this.zQsoqvmPysY.Size = new Size(123, 20);
		this.zQsoqvmPysY.TabIndex = 19;
		this.zQsoqvmPysY.Text = "25";
		this.label_5.AutoSize = true;
		this.label_5.Location = new Point(244, 9);
		this.label_5.Name = "label6";
		this.label_5.Size = new Size(32, 13);
		this.label_5.TabIndex = 18;
		this.label_5.Text = "Порт";
		this.textBox_5.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
		this.textBox_5.Location = new Point(12, 25);
		this.textBox_5.Name = "txtSmtpServer";
		this.textBox_5.Size = new Size(226, 20);
		this.textBox_5.TabIndex = 17;
		this.textBox_5.Text = "domino";
		this.label_6.AutoSize = true;
		this.label_6.Location = new Point(12, 9);
		this.label_6.Name = "label14";
		this.label_6.Size = new Size(94, 13);
		this.label_6.TabIndex = 16;
		this.label_6.Text = "Сервер отправки";
		this.button_1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.button_1.DialogResult = DialogResult.Cancel;
		this.button_1.Location = new Point(687, 362);
		this.button_1.Name = "buttonClose";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 25;
		this.button_1.Text = "Закрыть";
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += this.button_1_Click;
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Checked = true;
		this.checkBox_0.CheckState = CheckState.Checked;
		this.checkBox_0.Location = new Point(373, 27);
		this.checkBox_0.Name = "checkBoxSSL";
		this.checkBox_0.Size = new Size(46, 17);
		this.checkBox_0.TabIndex = 26;
		this.checkBox_0.Text = "SSL";
		this.checkBox_0.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(774, 391);
		base.Controls.Add(this.checkBox_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_0);
		base.Controls.Add(this.dataGridView_0);
		base.Controls.Add(this.splitContainer_0);
		base.Controls.Add(this.zQsoqvmPysY);
		base.Controls.Add(this.label_5);
		base.Controls.Add(this.textBox_5);
		base.Controls.Add(this.label_6);
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "FormSendMailRequest";
		this.Text = "Отправка задачи почтой";
		base.FormClosing += this.Form49_FormClosing;
		base.Load += this.Form49_Load;
		((ISupportInitialize)this.dataGridView_0).EndInit();
		this.splitContainer_0.Panel1.ResumeLayout(false);
		this.splitContainer_0.Panel1.PerformLayout();
		this.splitContainer_0.Panel2.ResumeLayout(false);
		this.splitContainer_0.Panel2.PerformLayout();
		this.splitContainer_0.ResumeLayout(false);
		((ISupportInitialize)this.class255_0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	static Form49()
	{
		// Note: this type is marked as 'beforefieldinit'.
		
		Form49.byte_0 = Encoding.ASCII.GetBytes("jf8hSDJH");
	}

	internal static void L2Mdss0UAaF6cpAnAnQq(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private int? nullable_0;

	private static byte[] byte_0;

	private object object_0;

	private Button button_0;

	private TextBox textBox_0;

	private Label label_0;

	private DataGridView dataGridView_0;

	private SplitContainer splitContainer_0;

	private TextBox textBox_1;

	private Label label_1;

	private TextBox textBox_2;

	private Label label_2;

	private TextBox textBox_3;

	private TextBox textBox_4;

	private Label label_3;

	private Label label_4;

	private TextBox zQsoqvmPysY;

	private Label label_5;

	private TextBox textBox_5;

	private Label label_6;

	private Button button_1;

	private DataGridViewComboBoxColumn dataGridViewComboBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

	private Class255 class255_0;

	private CheckBox checkBox_0;
}
