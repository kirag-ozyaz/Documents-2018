using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

internal partial class Form46 : FormBase
{
	internal Form46()
	{
		
		this.int_0 = -1;
		
		this.method_0();
	}

	internal Form46(int int_1)
	{
		
		this.int_0 = -1;
		
		this.method_0();
		this.int_0 = int_1;
		if (int_1 == -1)
		{
			this.Text = "Добавить обновление";
			return;
		}
		this.Text = "Изменить обновление";
	}

	private void Form46_Load(object sender, EventArgs e)
	{
		base.SelectSqlData(this.class255_0, this.class255_0.tR_Classifier, true, " where ParentKey = ';Other;ModulPC;' and isGroup = 0 and deleted = 0 order by [name]");
		if (this.int_0 == -1)
		{
			DataRow dataRow = this.class255_0.tJ_UpdateProgram.NewRow();
			dataRow["Dateupdate"] = DateTime.Now;
			this.class255_0.tJ_UpdateProgram.Rows.Add(dataRow);
			this.comboBox_0.SelectedIndex = -1;
			return;
		}
		base.SelectSqlData(this.class255_0, this.class255_0.tJ_UpdateProgram, true, " where id = " + this.int_0.ToString());
		base.SelectSqlData(this.class255_0, this.class255_0.tJ_UpdateProgramDoc, true, " where idUpdate = " + this.int_0.ToString());
	}

	private void Form46_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (base.DialogResult == DialogResult.OK)
		{
			if (this.comboBox_0.SelectedIndex < 0)
			{
				MessageBox.Show("Не выбран модуль");
				e.Cancel = true;
				return;
			}
			if (string.IsNullOrEmpty(this.richTextBox_0.Text) || string.IsNullOrEmpty(this.richTextBox_1.Text))
			{
				MessageBox.Show("Не заполнено поле текста");
				e.Cancel = true;
				return;
			}
			if (this.int_0 == -1)
			{
				this.class255_0.tJ_UpdateProgram.Rows[0].EndEdit();
				this.int_0 = base.InsertSqlDataOneRow(this.class255_0, this.class255_0.tJ_UpdateProgram);
				if (this.int_0 > 0)
				{
					foreach (object obj in this.class255_0.tJ_UpdateProgramDoc.Rows)
					{
						DataRow dataRow = (DataRow)obj;
						dataRow["idUpdate"] = this.int_0;
						dataRow.EndEdit();
					}
					base.InsertSqlData(this.class255_0, this.class255_0.tJ_UpdateProgramDoc);
					return;
				}
			}
			else
			{
				this.class255_0.tJ_UpdateProgram.Rows[0].EndEdit();
				base.UpdateSqlData(this.class255_0, this.class255_0.tJ_UpdateProgram);
				if (this.int_0 > 0)
				{
					foreach (object obj2 in this.class255_0.tJ_UpdateProgramDoc.Rows)
					{
						DataRow dataRow2 = (DataRow)obj2;
						if (dataRow2.RowState != DataRowState.Deleted)
						{
							dataRow2["idUpdate"] = this.int_0;
						}
						dataRow2.EndEdit();
					}
					base.InsertSqlData(this.class255_0, this.class255_0.tJ_UpdateProgramDoc);
					base.DeleteSqlData(this.class255_0, this.class255_0.tJ_UpdateProgramDoc);
				}
			}
		}
	}

	private void dataGridView_0_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
	{
		if (this.dataGridView_0.RowCount > 0 && this.dataGridView_0[this.dataGridViewTextBoxColumn_1.Name, e.RowIndex].Value != null)
		{
			if (e.ColumnIndex == this.dataGridView_0.Columns[this.dataGridViewLinkColumn_0.Name].Index)
			{
				e.Value = Path.GetFileName(this.dataGridView_0[this.dataGridViewTextBoxColumn_1.Name, e.RowIndex].Value.ToString());
			}
			if (e.ColumnIndex == this.dataGridView_0.Columns[this.dataGridViewImageColumnNotNull_0.Name].Index)
			{
				Icon icon = FormLbr.Classes.FileInfo.IconOfFile(this.dataGridView_0[this.dataGridViewTextBoxColumn_1.Name, e.RowIndex].Value.ToString());
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
		int num = Convert.ToInt32(this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
		if (e.ColumnIndex == this.dataGridView_0.Columns[this.dataGridViewLinkColumn_0.Name].Index)
		{
			byte[] array = (byte[])this.class255_0.tJ_UpdateProgramDoc.method_2(num)["Document"];
			string text = Path.GetTempFileName();
			text = Path.ChangeExtension(text, Path.GetExtension(this.class255_0.tJ_UpdateProgramDoc.method_2(num)["FileName"].ToString()));
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
			this.dataGridView_0.CurrentCell = this.dataGridView_0[this.dataGridViewImageColumnNotNull_0.Name, e.RowIndex];
			this.contextMenuStrip_0.Show(Cursor.Position);
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
					DataRow dataRow = this.class255_0.tJ_UpdateProgramDoc.NewRow();
					dataRow["idUpdate"] = this.int_0;
					dataRow["Document"] = File.ReadAllBytes(openFileDialog.FileNames[i]);
					dataRow["FileName"] = openFileDialog.FileNames[i];
					this.class255_0.tJ_UpdateProgramDoc.Rows.Add(dataRow);
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
			Convert.ToInt32(this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
			this.dataGridView_0.Rows.Remove(this.dataGridView_0.CurrentRow);
			return;
		}
		MessageBox.Show("Не выбрано ни одного файла");
	}

	private void toolStripMenuItem_0_Click(object sender, EventArgs e)
	{
		if (this.dataGridView_0.CurrentRow == null)
		{
			return;
		}
		int num = Convert.ToInt32(this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
		byte[] array = (byte[])this.class255_0.tJ_UpdateProgramDoc.method_2(num)["Document"];
		string text = Path.GetTempFileName();
		text = Path.ChangeExtension(text, Path.GetExtension(this.class255_0.tJ_UpdateProgramDoc.method_2(num)["FileName"].ToString()));
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

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(this.dataGridView_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
			string text = this.dataGridView_0.CurrentRow.Cells[this.dataGridViewLinkColumn_0.Name].Value.ToString();
			string extension = Path.GetExtension(text);
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "(*" + extension + ")|*" + extension;
			saveFileDialog.FileName = text;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				byte[] array = (byte[])this.class255_0.tJ_UpdateProgramDoc.method_2(num)["Document"];
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

	private void method_0()
	{
		this.icontainer_0 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		this.label_0 = new Label();
		this.class255_0 = new Class255();
		this.dateTimePicker_0 = new DateTimePicker();
		this.label_1 = new Label();
		this.comboBox_0 = new ComboBox();
		this.label_2 = new Label();
		this.richTextBox_0 = new RichTextBox();
		this.label_3 = new Label();
		this.richTextBox_1 = new RichTextBox();
		this.toolStrip_0 = new ToolStrip();
		this.toolStripButton_0 = new ToolStripButton();
		this.toolStripButton_1 = new ToolStripButton();
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
		this.dataGridViewLinkColumn_0 = new DataGridViewLinkColumn();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewImageColumn_0 = new DataGridViewImageColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.button_0 = new Button();
		this.button_1 = new Button();
		this.contextMenuStrip_0 = new ContextMenuStrip(this.icontainer_0);
		this.toolStripMenuItem_0 = new ToolStripMenuItem();
		this.toolStripMenuItem_1 = new ToolStripMenuItem();
		this.toolStripMenuItem_2 = new ToolStripMenuItem();
		((ISupportInitialize)this.class255_0).BeginInit();
		this.toolStrip_0.SuspendLayout();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		this.contextMenuStrip_0.SuspendLayout();
		base.SuspendLayout();
		this.label_0.AutoSize = true;
		this.label_0.Location = new Point(12, 9);
		this.label_0.Name = "label1";
		this.label_0.Size = new Size(33, 13);
		this.label_0.TabIndex = 0;
		this.label_0.Text = "Дата";
		this.class255_0.DataSetName = "DataSetGES";
		this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		this.dateTimePicker_0.CustomFormat = "dd MMMM yyyy HH:mm";
		this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class255_0, "tJ_UpdateProgram.DateUpdate", true));
		this.dateTimePicker_0.Format = DateTimePickerFormat.Custom;
		this.dateTimePicker_0.Location = new Point(15, 25);
		this.dateTimePicker_0.Name = "dateTimePicker1";
		this.dateTimePicker_0.Size = new Size(200, 20);
		this.dateTimePicker_0.TabIndex = 1;
		this.label_1.AutoSize = true;
		this.label_1.Location = new Point(240, 9);
		this.label_1.Name = "label2";
		this.label_1.Size = new Size(45, 13);
		this.label_1.TabIndex = 2;
		this.label_1.Text = "Модуль";
		this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class255_0, "tJ_UpdateProgram.Modul", true));
		this.comboBox_0.DataSource = this.class255_0;
		this.comboBox_0.DisplayMember = "tR_Classifier.Name";
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new Point(243, 24);
		this.comboBox_0.Name = "comboBoxModul";
		this.comboBox_0.Size = new Size(284, 21);
		this.comboBox_0.TabIndex = 3;
		this.comboBox_0.ValueMember = "tR_Classifier.Id";
		this.label_2.AutoSize = true;
		this.label_2.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_UpdateProgram.Description", true));
		this.label_2.Location = new Point(12, 48);
		this.label_2.Name = "label3";
		this.label_2.Size = new Size(69, 13);
		this.label_2.TabIndex = 4;
		this.label_2.Text = "Обновление";
		this.richTextBox_0.AcceptsTab = true;
		this.richTextBox_0.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_UpdateProgram.Description", true));
		this.richTextBox_0.Location = new Point(15, 64);
		this.richTextBox_0.Name = "richTextBox1";
		this.richTextBox_0.Size = new Size(512, 77);
		this.richTextBox_0.TabIndex = 5;
		this.richTextBox_0.Text = "";
		this.label_3.AutoSize = true;
		this.label_3.Location = new Point(12, 144);
		this.label_3.Name = "label4";
		this.label_3.Size = new Size(37, 13);
		this.label_3.TabIndex = 6;
		this.label_3.Text = "Текст";
		this.richTextBox_1.AcceptsTab = true;
		this.richTextBox_1.DataBindings.Add(new Binding("Text", this.class255_0, "tJ_UpdateProgram.TextUpdate", true));
		this.richTextBox_1.Location = new Point(15, 160);
		this.richTextBox_1.Name = "richTextBox2";
		this.richTextBox_1.Size = new Size(512, 96);
		this.richTextBox_1.TabIndex = 7;
		this.richTextBox_1.Text = "";
		this.toolStrip_0.Dock = DockStyle.None;
		this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
		this.toolStrip_0.Items.AddRange(new ToolStripItem[]
		{
			this.toolStripButton_0,
			this.toolStripButton_1
		});
		this.toolStrip_0.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
		this.toolStrip_0.Location = new Point(17, 259);
		this.toolStrip_0.Name = "toolStrip";
		this.toolStrip_0.Size = new Size(24, 48);
		this.toolStrip_0.TabIndex = 16;
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
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.AllowUserToResizeColumns = false;
		this.dataGridView_0.AllowUserToResizeRows = false;
		this.dataGridView_0.AutoGenerateColumns = false;
		this.dataGridView_0.BackgroundColor = SystemColors.Control;
		this.dataGridView_0.BorderStyle = BorderStyle.None;
		this.dataGridView_0.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.ColumnHeadersVisible = false;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewImageColumnNotNull_0,
			this.dataGridViewLinkColumn_0,
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewImageColumn_0,
			this.dataGridViewTextBoxColumn_1
		});
		this.dataGridView_0.DataMember = "tJ_UpdateProgramDoc";
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
		this.dataGridView_0.Location = new Point(44, 259);
		this.dataGridView_0.MultiSelect = false;
		this.dataGridView_0.Name = "dgvDocs";
		this.dataGridView_0.ReadOnly = true;
		this.dataGridView_0.RowHeadersVisible = false;
		this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_0.Size = new Size(483, 115);
		this.dataGridView_0.TabIndex = 17;
		this.dataGridView_0.VirtualMode = true;
		this.dataGridView_0.CellContentClick += this.dataGridView_0_CellContentClick;
		this.dataGridView_0.CellMouseClick += this.dataGridView_0_CellMouseClick;
		this.dataGridView_0.CellValueNeeded += this.dataGridView_0_CellValueNeeded;
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
		this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
		this.dataGridViewTextBoxColumn_0.HeaderText = "id";
		this.dataGridViewTextBoxColumn_0.Name = "idDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.Visible = false;
		this.dataGridViewImageColumn_0.DataPropertyName = "Document";
		this.dataGridViewImageColumn_0.HeaderText = "Document";
		this.dataGridViewImageColumn_0.Name = "documentDataGridViewImageColumn";
		this.dataGridViewImageColumn_0.ReadOnly = true;
		this.dataGridViewImageColumn_0.Visible = false;
		this.dataGridViewTextBoxColumn_1.DataPropertyName = "FileName";
		this.dataGridViewTextBoxColumn_1.HeaderText = "FileName";
		this.dataGridViewTextBoxColumn_1.Name = "fileNameDataGridViewTextBoxColumn";
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.Visible = false;
		this.button_0.DialogResult = DialogResult.Cancel;
		this.button_0.Location = new Point(452, 380);
		this.button_0.Name = "buttonCancel";
		this.button_0.Size = new Size(75, 23);
		this.button_0.TabIndex = 19;
		this.button_0.Text = "Отмена";
		this.button_0.UseVisualStyleBackColor = true;
		this.button_1.DialogResult = DialogResult.OK;
		this.button_1.Location = new Point(15, 380);
		this.button_1.Name = "buttonOK";
		this.button_1.Size = new Size(75, 23);
		this.button_1.TabIndex = 18;
		this.button_1.Text = "ОК";
		this.button_1.UseVisualStyleBackColor = true;
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
		this.toolStripMenuItem_1.Click += this.toolStripMenuItem_1_Click;
		this.toolStripMenuItem_2.Image = Resources.ElementDel;
		this.toolStripMenuItem_2.Name = "toolMenuDel";
		this.toolStripMenuItem_2.Size = new Size(132, 22);
		this.toolStripMenuItem_2.Text = "Удалить";
		this.toolStripMenuItem_2.Click += this.toolStripMenuItem_2_Click;
		base.AcceptButton = this.button_1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = this.button_0;
		base.ClientSize = new Size(540, 415);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.button_1);
		base.Controls.Add(this.dataGridView_0);
		base.Controls.Add(this.toolStrip_0);
		base.Controls.Add(this.richTextBox_1);
		base.Controls.Add(this.label_3);
		base.Controls.Add(this.richTextBox_0);
		base.Controls.Add(this.label_2);
		base.Controls.Add(this.comboBox_0);
		base.Controls.Add(this.label_1);
		base.Controls.Add(this.dateTimePicker_0);
		base.Controls.Add(this.label_0);
		base.Name = "FormAddEditUpdateProgram";
		this.Text = "FormAddEditUpdateProgram";
		base.FormClosing += this.Form46_FormClosing;
		base.Load += this.Form46_Load;
		((ISupportInitialize)this.class255_0).EndInit();
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		((ISupportInitialize)this.dataGridView_0).EndInit();
		this.contextMenuStrip_0.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	internal static void kP73hb0pgiA6MjW5oxXH(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	private int int_0;

	private Label label_0;

	private Class255 class255_0;

	private DateTimePicker dateTimePicker_0;

	private Label label_1;

	private ComboBox comboBox_0;

	private Label label_2;

	private RichTextBox richTextBox_0;

	private Label label_3;

	private RichTextBox richTextBox_1;

	private ToolStrip toolStrip_0;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private DataGridView dataGridView_0;

	private Button button_0;

	private Button button_1;

	private ContextMenuStrip contextMenuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

	private DataGridViewLinkColumn dataGridViewLinkColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewImageColumn dataGridViewImageColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;
}
