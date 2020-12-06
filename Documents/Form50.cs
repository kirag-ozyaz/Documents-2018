using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ControlsLbr;
using ControlsLbr.DataGridViewExcelFilter;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

internal partial class Form50 : FormBase
{
	internal int IdRequest
	{
		get
		{
			return this.int_0;
		}
	}

	public Form50()
	{
		
		this.int_0 = -1;
		
		this.method_0();
	}

	public Form50(int int_1, Form50.Enum14 enum14_1)
	{
		
		this.int_0 = -1;
		
		this.method_0();
		this.enum14_0 = enum14_1;
		this.int_0 = int_1;
		switch (this.enum14_0)
		{
		case (Form50.Enum14)0:
			this.Text = "Новая задача";
			return;
		case (Form50.Enum14)1:
			this.Text = "Редактировать задачу";
			return;
		case (Form50.Enum14)2:
			this.Text = "Просмотр задачи";
			return;
		default:
			return;
		}
	}

	private void Form50_Load(object sender, EventArgs e)
	{
		base.SelectSqlData(this.dataSet_0, this.dataSet_0.Tables["tUser"], true, " where deleted = 0 order by [name]");
		base.SelectSqlData(this.dataSet_0, this.dataSet_0.Tables["tR_Classifier"], true, " where ParentKey = ';Other;ModulPC;' and isGroup = 0 and deleted = 0 order by [name]");
		base.SelectSqlData(this.class255_0.tUser, true, " where [Login] = SYSTEM_USER ", null, false, 1);
		int num = -1;
		if (this.class255_0.tUser.Rows.Count > 0)
		{
			num = Convert.ToInt32(this.class255_0.tUser.Rows[0]["idUser"]);
		}
		Form50.Enum14 @enum = this.enum14_0;
		if (@enum == (Form50.Enum14)0)
		{
			DataRow dataRow = this.class255_0.tJ_Request.NewRow();
			dataRow["idUserTask"] = num;
			dataRow["DateTask"] = DateTime.Now;
			this.class255_0.tJ_Request.Rows.Add(dataRow);
			return;
		}
		if (@enum != (Form50.Enum14)1)
		{
			return;
		}
		base.SelectSqlData(this.class255_0, this.class255_0.tJ_Request, true, " where id = " + this.int_0.ToString());
		base.SelectSqlData(this.class255_0, this.class255_0.tJ_RequestDoc, true, " where idRequest = " + this.int_0.ToString());
		if (this.class255_0.tJ_Request.Rows[0]["TextTaskBin"] != DBNull.Value)
		{
			this.richTextBoxWithContextMenu_0.Rtf = Form50.smethod_1((byte[])this.class255_0.tJ_Request.Rows[0]["TextTaskBin"]);
		}
		if (this.class255_0.tJ_Request.Rows.Count == 0)
		{
			MessageBox.Show("Не удалось открыть документ для редактирования");
			base.DialogResult = DialogResult.Cancel;
			base.Close();
			return;
		}
		if (num == -1 || num != Convert.ToInt32(this.class255_0.tJ_Request.Rows[0]["idUserTask"]))
		{
			this.comboBox_0.Enabled = false;
			this.richTextBoxWithContextMenu_0.ReadOnly = true;
			this.toolStrip_0.Enabled = false;
			this.toolStripMenuItem_2.Visible = false;
			this.comboBox_1.Enabled = false;
		}
		if (this.class255_0.tJ_Request.Rows[0]["idUserWhom"] != DBNull.Value && num == Convert.ToInt32(this.class255_0.tJ_Request.Rows[0]["idUserWhom"]))
		{
			this.comboBox_1.Enabled = true;
			this.toolStrip_0.Enabled = true;
		}
	}

	private void Form50_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.comboBox_0.SelectedIndex < 0)
			{
				MessageBox.Show("Не выбран модуль");
				e.Cancel = true;
				return;
			}
			if (string.IsNullOrEmpty(this.richTextBoxWithContextMenu_0.Text))
			{
				MessageBox.Show("Не заполнено поле текста задачи");
				e.Cancel = true;
				return;
			}
			if (!string.IsNullOrEmpty(this.richTextBoxWithContextMenu_0.Rtf))
			{
				this.class255_0.tJ_Request.Rows[0]["TextTaskBin"] = Form50.smethod_0(this.richTextBoxWithContextMenu_0.Rtf);
			}
			else
			{
				this.class255_0.tJ_Request.Rows[0]["TextTaskBin"] = DBNull.Value;
			}
			Form50.Enum14 @enum = this.enum14_0;
			if (@enum != (Form50.Enum14)0)
			{
				if (@enum != (Form50.Enum14)1)
				{
					return;
				}
				this.class255_0.tJ_Request.Rows[0].EndEdit();
				base.UpdateSqlData(this.class255_0, this.class255_0.tJ_Request);
				if (this.int_0 > 0)
				{
					foreach (object obj in this.class255_0.tJ_RequestDoc.Rows)
					{
						DataRow dataRow = (DataRow)obj;
						if (dataRow.RowState != DataRowState.Deleted)
						{
							dataRow["idRequest"] = this.int_0;
						}
						dataRow.EndEdit();
					}
					base.InsertSqlData(this.class255_0, this.class255_0.tJ_RequestDoc);
					base.DeleteSqlData(this.class255_0, this.class255_0.tJ_RequestDoc);
				}
			}
			else
			{
				this.class255_0.tJ_Request.Rows[0].EndEdit();
				this.int_0 = base.InsertSqlDataOneRow(this.class255_0, this.class255_0.tJ_Request);
				if (this.int_0 > 0)
				{
					foreach (object obj2 in this.class255_0.tJ_RequestDoc.Rows)
					{
						DataRow dataRow2 = (DataRow)obj2;
						dataRow2["idRequest"] = this.int_0;
						dataRow2.EndEdit();
					}
					base.InsertSqlData(this.class255_0, this.class255_0.tJ_RequestDoc);
					return;
				}
			}
		}
	}

	private void toolStripButton_0_Click(object sender, EventArgs e)
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				for (int i = 0; i < openFileDialog.FileNames.Length; i++)
				{
					DataRow dataRow = this.class255_0.tJ_RequestDoc.NewRow();
					dataRow["idRequest"] = -1;
					dataRow["Document"] = File.ReadAllBytes(openFileDialog.FileNames[i]);
					dataRow["FileName"] = openFileDialog.FileNames[i];
					this.class255_0.tJ_RequestDoc.Rows.Add(dataRow);
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.Source);
		}
	}

	private void toolStripButton_1_Click(object sender, EventArgs e)
	{
		if (this.dataGridView_0.CurrentRow != null)
		{
			Convert.ToInt32(this.dataGridView_0.CurrentRow.Cells["idDgvTxtColumn"].Value);
			this.dataGridView_0.Rows.Remove(this.dataGridView_0.CurrentRow);
			return;
		}
		MessageBox.Show("Не выбрано ни одного файла");
	}

	private void dataGridView_0_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
	{
		if (this.dataGridView_0.RowCount > 0 && this.dataGridView_0["filenameDgvTxtColumn", e.RowIndex].Value != null)
		{
			if (e.ColumnIndex == this.dataGridView_0.Columns["shortFileNameDgvTxtColumn"].Index)
			{
				e.Value = Path.GetFileName(this.dataGridView_0["filenameDgvTxtColumn", e.RowIndex].Value.ToString());
			}
			if (e.ColumnIndex == this.dataGridView_0.Columns["ColumnImage"].Index)
			{
				Icon icon = FormLbr.Classes.FileInfo.IconOfFile(this.dataGridView_0["filenameDgvTxtColumn", e.RowIndex].Value.ToString());
				e.Value = icon.ToBitmap();
			}
		}
	}

	private void dataGridView_0_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		if (this.dataGridView_0.CurrentRow == null)
		{
			return;
		}
		int num = Convert.ToInt32(this.dataGridView_0.CurrentRow.Cells["idDgvTxtColumn"].Value);
		if (e.ColumnIndex == this.dataGridView_0.Columns["shortFileNameDgvTxtColumn"].Index)
		{
			byte[] array = (byte[])this.class255_0.tJ_RequestDoc.method_2(num)["Document"];
			string text = Path.GetTempFileName();
			text = Path.ChangeExtension(text, Path.GetExtension(this.class255_0.tJ_RequestDoc.method_2(num)["FileName"].ToString()));
			FileStream fileStream = File.Create(text);
			fileStream.Write(array, 0, array.Length);
			fileStream.Close();
			new Process
			{
				StartInfo = 
				{
					FileName = text,
					UseShellExecute = true
				}
			}.Start();
		}
	}

	private void dataGridView_0_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
		{
			this.dataGridView_0.Rows[e.RowIndex].Selected = true;
			this.dataGridView_0.CurrentCell = this.dataGridView_0["columnimage", e.RowIndex];
			this.contextMenuStrip_0.Show(Cursor.Position);
		}
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		if (this.dataGridView_0.CurrentRow == null)
		{
			return;
		}
		int num = Convert.ToInt32(this.dataGridView_0.CurrentRow.Cells["idDgvTxtColumn"].Value);
		byte[] array = (byte[])this.class255_0.tJ_RequestDoc.method_2(num)["Document"];
		string text = Path.GetTempFileName();
		text = Path.ChangeExtension(text, Path.GetExtension(this.class255_0.tJ_RequestDoc.method_2(num)["FileName"].ToString()));
		FileStream fileStream = File.Create(text);
		fileStream.Write(array, 0, array.Length);
		fileStream.Close();
		new Process
		{
			StartInfo = 
			{
				FileName = text,
				UseShellExecute = true
			}
		}.Start();
	}

	private void wGqoqLwcvsx(object sender, EventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(this.dataGridView_0.CurrentRow.Cells["idDgvTxtColumn"].Value);
			string text = this.dataGridView_0.CurrentRow.Cells["shortFileNameDgvTxtColumn"].Value.ToString();
			string extension = Path.GetExtension(text);
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "(*" + extension + ")|*" + extension;
			saveFileDialog.FileName = text;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				byte[] array = (byte[])this.class255_0.tJ_RequestDoc.method_2(num)["Document"];
				FileStream fileStream = File.Create(saveFileDialog.FileName);
				fileStream.Write(array, 0, array.Length);
				fileStream.Close();
				MessageBox.Show("Файл успешно сохранен", "Сохранение");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.Source);
		}
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		this.toolStripButton_1_Click(sender, e);
	}

	private static byte[] smethod_0(string string_0)
	{
		byte[] array = new byte[string_0.Length * 2];
		Buffer.BlockCopy(string_0.ToCharArray(), 0, array, 0, array.Length);
		return array;
	}

	private static string smethod_1(byte[] byte_0)
	{
		char[] array = new char[byte_0.Length / 2];
		Buffer.BlockCopy(byte_0, 0, array, 0, byte_0.Length);
		return new string(array);
	}

	private void dataGridView_0_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = DragDropEffects.Move;
			return;
		}
		e.Effect = DragDropEffects.None;
	}

	private void dataGridView_0_DragDrop(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
		{
			string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
			for (int i = 0; i < array.Length; i++)
			{
				if (File.GetAttributes(array[i]) != FileAttributes.Directory)
				{
					DataRow dataRow = this.class255_0.tJ_RequestDoc.NewRow();
					dataRow["idRequest"] = -1;
					dataRow["Document"] = File.ReadAllBytes(array[i]);
					dataRow["FileName"] = array[i];
					this.class255_0.tJ_RequestDoc.Rows.Add(dataRow);
				}
			}
		}
	}

	private void enqozZipMd3_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.Close();
	}

	private void method_0()
	{
		this.icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		this.class255_0 = new Class255();
		this.label_0 = new Label();
		this.textBox_0 = new TextBox();
		this.label_1 = new Label();
		this.comboBox_0 = new ComboBox();
		this.dataSet_0 = new DataSet();
		this.dataTable_0 = new DataTable();
		this.dataColumn_0 = new DataColumn();
		this.dataColumn_1 = new DataColumn();
		this.dataTable_1 = new DataTable();
		this.dataColumn_2 = new DataColumn();
		this.dataColumn_3 = new DataColumn();
		this.dataColumn_4 = new DataColumn();
		this.label_2 = new Label();
		this.button_0 = new Button();
		this.enqozZipMd3 = new Button();
		this.label_3 = new Label();
		this.comboBox_1 = new ComboBox();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewImageColumn_0 = new DataGridViewImageColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
		this.dataGridViewLinkColumn_0 = new DataGridViewLinkColumn();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripButton_1 = new ToolStripButton();
		this.contextMenuStrip_0 = new ContextMenuStrip(this.icontainer_0);
		this.toolStripMenuItem_0 = new ToolStripMenuItem();
		this.toolStripMenuItem_1 = new ToolStripMenuItem();
		this.toolStripMenuItem_2 = new ToolStripMenuItem();
		this.contextMenuStrip_1 = new ContextMenuStrip(this.icontainer_0);
		this.toolStripMenuItem_3 = new ToolStripMenuItem();
		this.toolStripSeparator_0 = new ToolStripSeparator();
		this.toolStripMenuItem_4 = new ToolStripMenuItem();
		this.toolStripMenuItem_5 = new ToolStripMenuItem();
		this.toolStripMenuItem_6 = new ToolStripMenuItem();
		this.richTextBoxWithContextMenu_0 = new RichTextBoxWithContextMenu();
		((ISupportInitialize)this.class255_0).BeginInit();
		((ISupportInitialize)this.dataSet_0).BeginInit();
		((ISupportInitialize)this.dataTable_0).BeginInit();
		((ISupportInitialize)this.dataTable_1).BeginInit();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		this.toolStrip_0.SuspendLayout();
		this.contextMenuStrip_0.SuspendLayout();
		this.contextMenuStrip_1.SuspendLayout();
		base.SuspendLayout();
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 10);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(56, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "№ задачи";
		this.textBox_0.BackColor = SystemColors.Window;
		this.textBox_0.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_Request.id", true));
		this.textBox_0.Location = new Point(74, 7);
		this.textBox_0.Name = "textBoxId";
		this.textBox_0.ReadOnly = true;
		this.textBox_0.Size = new Size(113, 20);
		this.textBox_0.TabIndex = 1;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(189, 10);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(45, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Модуль";
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class255_0, "tJ_Request.Modul", true));
		this.comboBox_0.DataSource = this.dataSet_0;
		this.comboBox_0.DisplayMember = "tR_Classifier.Name";
		this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(240, 6);
		this.comboBox_0.Name = "comboBoxModul";
		this.comboBox_0.Size = new Size(156, 21);
		this.comboBox_0.TabIndex = 3;
		this.comboBox_0.ValueMember = "tR_Classifier.Id";
		this.dataSet_0.DataSetName = "NewDataSet";
		this.dataSet_0.Tables.AddRange(new DataTable[]
		{
			this.dataTable_0,
			this.dataTable_1
		});
		this.dataTable_0.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_0,
			this.dataColumn_1
		});
		this.dataTable_0.TableName = "tUser";
		this.dataColumn_0.ColumnName = "idUser";
		this.dataColumn_0.DataType = typeof(int);
		this.dataColumn_1.ColumnName = "Name";
		this.dataTable_1.Columns.AddRange(new DataColumn[]
		{
			this.dataColumn_2,
			this.dataColumn_3,
			this.dataColumn_4
		});
		this.dataTable_1.TableName = "tR_Classifier";
		this.dataColumn_2.ColumnName = "Id";
		this.dataColumn_2.DataType = typeof(int);
		this.dataColumn_3.ColumnName = "Name";
		this.dataColumn_4.ColumnName = "ParentKey";
		this.label_2.AutoSize = true;
		this.label_2.Location = new Point(12, 69);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(76, 13);
		this.label_2.TabIndex = 4;
		this.label_2.Text = "Текст Задачи";
		this.button_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.button_0.DialogResult = DialogResult.OK;
		this.button_0.Location = new Point(15, 309);
		this.button_0.Name = "buttonOK";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 6;
		this.button_0.Text = "ОК";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_0.Click += this.button_0_Click;
		this.enqozZipMd3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
		this.enqozZipMd3.DialogResult = DialogResult.Cancel;
		this.enqozZipMd3.Location = new Point(321, 309);
		this.enqozZipMd3.Name = "buttonCancel";
		this.enqozZipMd3.Size = new Size(75, 23);
		this.enqozZipMd3.TabIndex = 7;
		this.enqozZipMd3.Text = "Отмена";
		this.enqozZipMd3.UseVisualStyleBackColor = true;
		this.enqozZipMd3.Click += this.enqozZipMd3_Click;
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 43);
		this.label_3.Name = "label4";
		this.label_3.Size = new Size(33, 13);
		this.label_3.TabIndex = 12;
		this.label_3.Text = "Кому";
		this.comboBox_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		this.comboBox_1.AutoCompleteSource = AutoCompleteSource.ListItems;
		this.comboBox_1.DataBindings.Add(new Binding("SelectedValue", this.class255_0, "tJ_Request.idUserWhom", true));
		this.comboBox_1.DataSource = this.dataSet_0;
		this.comboBox_1.DisplayMember = "tUser.Name";
		this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Location = new Point(53, 40);
		this.comboBox_1.Name = "comboBoxWhom";
		this.comboBox_1.Size = new Size(343, 21);
		this.comboBox_1.TabIndex = 13;
		this.comboBox_1.ValueMember = "tUser.idUser";
		this.dataGridView_0.AllowDrop = true;
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.AllowUserToResizeColumns = false;
		this.dataGridView_0.AllowUserToResizeRows = false;
		this.dataGridView_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.dataGridView_0.AutoGenerateColumns = false;
		this.dataGridView_0.BackgroundColor = SystemColors.Control;
		this.dataGridView_0.BorderStyle = BorderStyle.None;
		this.dataGridView_0.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.ColumnHeadersVisible = false;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewImageColumn_0,
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewImageColumnNotNull_0,
			this.dataGridViewLinkColumn_0
		});
		this.dataGridView_0.DataMember = "tJ_RequestDoc";
		this.dataGridView_0.DataSource = this.class255_0;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		dataGridViewCellStyle.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		this.dataGridView_0.DefaultCellStyle = dataGridViewCellStyle;
		this.dataGridView_0.GridColor = SystemColors.Control;
		this.dataGridView_0.Location = new Point(42, 183);
		this.dataGridView_0.MultiSelect = false;
		this.dataGridView_0.Name = "dgvDocs";
		this.dataGridView_0.ReadOnly = true;
		this.dataGridView_0.RowHeadersVisible = false;
		this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_0.Size = new Size(354, 101);
		this.dataGridView_0.TabIndex = 14;
		this.dataGridView_0.VirtualMode = true;
		this.dataGridView_0.CellContentClick += this.dataGridView_0_CellContentClick;
		this.dataGridView_0.CellMouseClick += this.dataGridView_0_CellMouseClick;
		this.dataGridView_0.CellValueNeeded += this.dataGridView_0_CellValueNeeded;
		this.dataGridView_0.DragDrop += this.dataGridView_0_DragDrop;
		this.dataGridView_0.DragEnter += this.dataGridView_0_DragEnter;
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_0.HeaderText = "id";
		this.dataGridViewTextBoxColumn_0.Name = "idDgvTxtColumn";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "idRequest";
		this.dataGridViewTextBoxColumn_1.HeaderText = "idRequest";
		this.dataGridViewTextBoxColumn_1.Name = "idRequestDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.Visible = false;
		this.dataGridViewImageColumn_0.DataPropertyName = "Document";
		this.dataGridViewImageColumn_0.HeaderText = "Document";
		this.dataGridViewImageColumn_0.Name = "documentDataGridViewImageColumn";
		this.dataGridViewImageColumn_0.ReadOnly = true;
		this.dataGridViewImageColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_2.DataPropertyName = "FileName";
		this.dataGridViewTextBoxColumn_2.HeaderText = "FileName";
		this.dataGridViewTextBoxColumn_2.Name = "fileNameDgvTxtColumn";
		this.dataGridViewTextBoxColumn_2.ReadOnly = true;
		this.dataGridViewTextBoxColumn_2.Visible = false;
		dataGridViewCellStyle2.NullValue = null;
		this.dataGridViewImageColumnNotNull_0.DefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridViewImageColumnNotNull_0.HeaderText = "";
		this.dataGridViewImageColumnNotNull_0.ImageLayout = DataGridViewImageCellLayout.Zoom;
		this.dataGridViewImageColumnNotNull_0.Name = "ColumnImage";
		this.dataGridViewImageColumnNotNull_0.ReadOnly = true;
		this.dataGridViewImageColumnNotNull_0.Width = 30;
		this.dataGridViewLinkColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		this.dataGridViewLinkColumn_0.HeaderText = "Файл";
		this.dataGridViewLinkColumn_0.Name = "shortFileNameDgvTxtColumn";
		this.dataGridViewLinkColumn_0.ReadOnly = true;
		this.dataGridViewLinkColumn_0.Resizable = DataGridViewTriState.True;
		this.dataGridViewLinkColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
		this.toolStrip_0.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
		this.toolStrip_0.Dock = DockStyle.None;
		this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripButton_1
		});
		this.toolStrip_0.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
		this.toolStrip_0.Location = new Point(15, 183);
		this.toolStrip_0.Name = "toolStrip";
		this.toolStrip_0.Size = new Size(24, 48);
		this.toolStrip_0.TabIndex = 15;
		this.toolStrip_0.Text = "toolStrip1";
		this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_0.Image = Resources.ElementAdd;
		this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
		this.toolStripButton_0.Name = "toolBtnAdd";
		this.toolStripButton_0.Size = new Size(22, 20);
		this.toolStripButton_0.Text = "Добавить файл";
		this.toolStripButton_0.Click += this.toolStripButton_0_Click;
		this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
		this.toolStripButton_1.Image = Resources.ElementDel;
		this.toolStripButton_1.ImageTransparentColor = Color.Transparent;
		this.toolStripButton_1.Name = "toolBtnDel";
		this.toolStripButton_1.Size = new Size(22, 20);
		this.toolStripButton_1.Text = "Удалить";
		this.toolStripButton_1.Click += this.toolStripButton_1_Click;
		this.contextMenuStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripMenuItem_0,
			this.toolStripMenuItem_1,
			this.toolStripMenuItem_2
		});
		this.contextMenuStrip_0.Name = "contextMenuDgvDoc";
		this.contextMenuStrip_0.Size = new Size(133, 70);
		this.toolStripMenuItem_0.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		this.toolStripMenuItem_0.Name = "toolMenuOpen";
		this.toolStripMenuItem_0.Size = new Size(132, 22);
		this.toolStripMenuItem_0.Text = "Открыть";
		this.toolStripMenuItem_0.Click += this.toolStripMenuItem_0_Click;
		this.toolStripMenuItem_1.Image = Resources.save;
		this.toolStripMenuItem_1.Name = "toolMenuSave";
		this.toolStripMenuItem_1.Size = new Size(132, 22);
		this.toolStripMenuItem_1.Text = "Сохранить";
		this.toolStripMenuItem_1.Click += this.wGqoqLwcvsx;
		this.toolStripMenuItem_2.Image = Resources.ElementDel;
		this.toolStripMenuItem_2.Name = "toolMenuDel";
		this.toolStripMenuItem_2.Size = new Size(132, 22);
		this.toolStripMenuItem_2.Text = "Удалить";
		this.toolStripMenuItem_2.Click += this.toolStripMenuItem_2_Click;
		this.contextMenuStrip_1.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripMenuItem_3,
			this.toolStripSeparator_0,
			this.toolStripMenuItem_4,
			this.toolStripMenuItem_5,
			this.toolStripMenuItem_6
		});
		this.contextMenuStrip_1.Name = "contextMenuTxt";
		this.contextMenuStrip_1.Size = new Size(140, 98);
		this.toolStripMenuItem_3.Name = "отменитьToolStripMenuItem";
		this.toolStripMenuItem_3.Size = new Size(139, 22);
		this.toolStripMenuItem_3.Text = "Отменить";
		this.toolStripSeparator_0.Name = "toolStripSeparator1";
		this.toolStripSeparator_0.Size = new Size(136, 6);
		this.toolStripMenuItem_4.Name = "вырезатьToolStripMenuItem";
		this.toolStripMenuItem_4.Size = new Size(139, 22);
		this.toolStripMenuItem_4.Text = "Вырезать";
		this.toolStripMenuItem_5.Name = "копироватьToolStripMenuItem";
		this.toolStripMenuItem_5.Size = new Size(139, 22);
		this.toolStripMenuItem_5.Text = "Копировать";
		this.toolStripMenuItem_6.Name = "вставитьToolStripMenuItem";
		this.toolStripMenuItem_6.Size = new Size(139, 22);
		this.toolStripMenuItem_6.Text = "Вставить";
		this.richTextBoxWithContextMenu_0.AcceptsTab = true;
		this.richTextBoxWithContextMenu_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
		this.richTextBoxWithContextMenu_0.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_Request.TextTask", true));
		this.richTextBoxWithContextMenu_0.Location = new Point(15, 85);
		this.richTextBoxWithContextMenu_0.Name = "richTextBoxTextTask";
		this.richTextBoxWithContextMenu_0.Size = new Size(381, 92);
		this.richTextBoxWithContextMenu_0.TabIndex = 16;
		this.richTextBoxWithContextMenu_0.Text = "";
		base.AcceptButton = this.button_0;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.enqozZipMd3;
		base.ClientSize = new Size(405, 344);
		base.Controls.Add(this.richTextBoxWithContextMenu_0);
		base.Controls.Add(this.toolStrip_0);
		base.Controls.Add(this.dataGridView_0);
		base.Controls.Add(this.comboBox_1);
		base.Controls.Add(this.label_3);
		base.Controls.Add(this.enqozZipMd3);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.textBox_0);
		base.Controls.Add(this.label_0);
		base.Name = "FormAddEditRequest";
		this.Text = "j";
		base.FormClosing += this.Form50_FormClosing;
		base.Load += this.Form50_Load;
		((ISupportInitialize)this.class255_0).EndInit();
		((ISupportInitialize)this.dataSet_0).EndInit();
		((ISupportInitialize)this.dataTable_0).EndInit();
		((ISupportInitialize)this.dataTable_1).EndInit();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		this.contextMenuStrip_0.ResumeLayout(false);
		this.contextMenuStrip_1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private Form50.Enum14 enum14_0;

	private int int_0;

	private Class255 class255_0;

	private Label label_0;

	private TextBox textBox_0;

	private Label label_1;

	private ComboBox comboBox_0;

	private Label label_2;

	private Button button_0;

	private Button enqozZipMd3;

	private Label label_3;

	private ComboBox comboBox_1;

	private DataSet dataSet_0;

	private DataTable dataTable_0;

	private DataColumn dataColumn_0;

	private DataColumn dataColumn_1;

	private DataTable dataTable_1;

	private DataColumn dataColumn_2;

	private DataColumn dataColumn_3;

	private DataColumn dataColumn_4;

	private DataGridView dataGridView_0;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewImageColumn dataGridViewImageColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

	private DataGridViewLinkColumn dataGridViewLinkColumn_0;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ContextMenuStrip contextMenuStrip_1;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStripMenuItem toolStripMenuItem_5;

	private ToolStripMenuItem toolStripMenuItem_6;

	private RichTextBoxWithContextMenu richTextBoxWithContextMenu_0;

	internal enum Enum14
	{

	}
}
