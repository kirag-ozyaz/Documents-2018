using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using Documents.Properties;
using FormLbr;

namespace Documents.Forms.TechnologicalConnection.RBP
{
	public partial class FormObjFind : FormBase
	{
		public FormObjFind()
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.string_0 = "";
			
			this.method_2();
		}

		public FormObjFind(int idAbn)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.string_0 = "";
			
			this.method_2();
			this.int_0 = idAbn;
		}

		public FormObjFind(int idAbn, int idAbnObj)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.string_0 = "";
			
			this.method_2();
			this.int_0 = idAbn;
			this.int_1 = idAbnObj;
		}

		private void FormObjFind_Load(object sender, EventArgs e)
		{
			this.toolStripComboBox_0.SelectedIndex = 0;
			base.SelectSqlData(this.class537_0, this.class537_0.vG_Find, true, " order by CodeAbonent");
			if (this.int_0 > 0)
			{
				for (int i = 0; i < this.dataGridView_0.RowCount; i++)
				{
					if (this.dataGridView_0[0, i].FormattedValue.ToString().Contains(this.int_0.ToString()))
					{
						this.dataGridView_0.CurrentCell = this.dataGridView_0[1, i];
						return;
					}
				}
				return;
			}
			if (this.int_1 > 0)
			{
				for (int j = 0; j < this.dataGridView_0.RowCount; j++)
				{
					if (this.dataGridView_0[8, j].FormattedValue.ToString().Contains(this.int_1.ToString()))
					{
						this.dataGridView_0.CurrentCell = this.dataGridView_0[1, j];
						return;
					}
				}
			}
		}

		private void dataGridView_0_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.string_0.Length > 3)
			{
				this.string_0 = "";
			}
			if (e.Modifiers == Keys.None)
			{
				Keys keyCode = e.KeyCode;
				if (keyCode != Keys.Return)
				{
					switch (keyCode)
					{
					case Keys.D0:
						this.string_0 += "0";
						break;
					case Keys.D1:
						this.string_0 += "1";
						break;
					case Keys.D2:
						this.string_0 += "2";
						break;
					case Keys.D3:
						this.string_0 += "3";
						break;
					case Keys.D4:
						this.string_0 += "4";
						break;
					case Keys.D5:
						this.string_0 += "5";
						break;
					case Keys.D6:
						this.string_0 += "6";
						break;
					case Keys.D7:
						this.string_0 += "7";
						break;
					case Keys.D8:
						this.string_0 += "8";
						break;
					case Keys.D9:
						this.string_0 += "9";
						break;
					default:
						switch (keyCode)
						{
						case Keys.NumPad0:
							this.string_0 += "0";
							break;
						case Keys.NumPad1:
							this.string_0 += "1";
							break;
						case Keys.NumPad2:
							this.string_0 += "2";
							break;
						case Keys.NumPad3:
							this.string_0 += "3";
							break;
						case Keys.NumPad4:
							this.string_0 += "4";
							break;
						case Keys.NumPad5:
							this.string_0 += "5";
							break;
						case Keys.NumPad6:
							this.string_0 += "6";
							break;
						case Keys.NumPad7:
							this.string_0 += "7";
							break;
						case Keys.NumPad8:
							this.string_0 += "8";
							break;
						case Keys.NumPad9:
							this.string_0 += "9";
							break;
						default:
							this.string_0 = "";
							break;
						}
						break;
					}
				}
				else
				{
					this.method_1();
				}
				if (this.string_0 != "")
				{
					this.method_0();
				}
			}
		}

		private void method_0()
		{
			for (int i = 0; i < this.dataGridView_0.RowCount; i++)
			{
				if (this.dataGridView_0[1, i].FormattedValue.ToString().Contains(this.string_0))
				{
					this.dataGridView_0.CurrentCell = this.dataGridView_0[1, i];
					return;
				}
			}
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.toolStripComboBox_0.SelectedIndex;
			if (selectedIndex != 0)
			{
				if (selectedIndex != 1)
				{
					this.class537_0.vG_Find.Clear();
				}
				else
				{
					base.SelectSqlData(this.class537_0.vG_Find, true, " where [objname] like '%" + this.toolStripTextBox_0.Text + "%' order by codeAbonent ", null, false, 0);
				}
			}
			else
			{
				base.SelectSqlData(this.class537_0.vG_Find, true, " where [name] like '%" + this.toolStripTextBox_0.Text + "%' order by codeAbonent ", null, false, 0);
			}
			this.dataGridView_0.Refresh();
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			this.class537_0.vG_Find.Clear();
			base.SelectSqlData(this.class537_0, this.class537_0.vG_Find, true, " order by CodeAbonent");
			this.dataGridView_0.Refresh();
		}

		private void dataGridView_0_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			this.method_1();
		}

		private void method_1()
		{
			FormJournalActRBP formJournalActRBP = (FormJournalActRBP)base.Owner;
			formJournalActRBP.ABNSELECT = Convert.ToInt32(this.dataGridView_0.CurrentRow.Cells["dgvIDAbn"].Value);
			if (this.dataGridView_0.CurrentRow.Cells["dgvIDAbnObj"].Value != DBNull.Value)
			{
				formJournalActRBP.OBJSELECT = Convert.ToInt32(this.dataGridView_0.CurrentRow.Cells["dgvIDAbnObj"].Value);
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void method_2()
		{
			this.icontainer_0 = new Container();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripComboBox_0 = new ToolStripComboBox();
			this.toolStripTextBox_0 = new ToolStripTextBox();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.dataGridView_0 = new DataGridView();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.lFeiWkxIkC = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.class537_0 = new Class537();
			this.toolStrip_0.SuspendLayout();
			((ISupportInitialize)this.dataGridView_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.class537_0).BeginInit();
			base.SuspendLayout();
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripComboBox_0,
				this.toolStripTextBox_0,
				this.toolStripButton_0,
				this.toolStripButton_1
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStrip1";
			this.toolStrip_0.Size = new Size(670, 25);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripComboBox_0.Items.AddRange(new object[]
			{
				"Наименование",
				"Объект"
			});
			this.toolStripComboBox_0.Name = "cbxFilter";
			this.toolStripComboBox_0.Size = new Size(200, 25);
			this.toolStripTextBox_0.Name = "txtFilter";
			this.toolStripTextBox_0.Size = new Size(250, 25);
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.Filtr_my;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "btnFilter";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "toolStripButton1";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.dialog_close;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "btnDelFilter";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "toolStripButton2";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.dataGridView_0.AllowUserToAddRows = false;
			this.dataGridView_0.AllowUserToDeleteRows = false;
			this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.dataGridView_0.AutoGenerateColumns = false;
			this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_0,
				this.lFeiWkxIkC,
				this.dataGridViewFilterTextBoxColumn_0,
				this.dataGridViewFilterTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_1
			});
			this.dataGridView_0.DataSource = this.bindingSource_0;
			this.dataGridView_0.Location = new Point(0, 28);
			this.dataGridView_0.MultiSelect = false;
			this.dataGridView_0.Name = "dgvAbn";
			this.dataGridView_0.ReadOnly = true;
			this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_0.Size = new Size(670, 383);
			this.dataGridView_0.TabIndex = 1;
			this.dataGridView_0.CellMouseDoubleClick += this.dataGridView_0_CellMouseDoubleClick;
			this.dataGridView_0.KeyDown += this.dataGridView_0_KeyDown;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "idAbn";
			this.dataGridViewTextBoxColumn_0.HeaderText = "idAbn";
			this.dataGridViewTextBoxColumn_0.Name = "dgvidAbn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_0.SortMode = DataGridViewColumnSortMode.Programmatic;
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.lFeiWkxIkC.DataPropertyName = "CodeAbonent";
			this.lFeiWkxIkC.HeaderText = "Код";
			this.lFeiWkxIkC.Name = "codeAbonentDataGridViewTextBoxColumn";
			this.lFeiWkxIkC.ReadOnly = true;
			this.lFeiWkxIkC.Resizable = DataGridViewTriState.True;
			this.lFeiWkxIkC.Width = 70;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "Name";
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Потребитель";
			this.dataGridViewFilterTextBoxColumn_0.Name = "nameDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_0.Width = 250;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "ObjName";
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Объект";
			this.dataGridViewFilterTextBoxColumn_1.Name = "objNameDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.Width = 300;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "idAbnObj";
			this.dataGridViewTextBoxColumn_1.HeaderText = "idAbnObj";
			this.dataGridViewTextBoxColumn_1.Name = "dgvidAbnObj";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.bindingSource_0.DataMember = "vG_Find";
			this.bindingSource_0.DataSource = this.class537_0;
			this.class537_0.DataSetName = "dsFind";
			this.class537_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(670, 407);
			base.Controls.Add(this.dataGridView_0);
			base.Controls.Add(this.toolStrip_0);
			base.Name = "FormObjFind";
			this.Text = "Выбор";
			base.Load += this.FormObjFind_Load;
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			((ISupportInitialize)this.dataGridView_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.class537_0).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		internal static void yKASDPOOVDxiEVoi89TN(Form form_0, bool bool_0)
		{
			form_0.Dispose(bool_0);
		}

		private int int_0;

		private int int_1;

		private string string_0;

		private ToolStrip toolStrip_0;

		private DataGridView dataGridView_0;

		private Class537 class537_0;

		private BindingSource bindingSource_0;

		private ToolStripComboBox toolStripComboBox_0;

		private ToolStripTextBox toolStripTextBox_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn lFeiWkxIkC;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;
	}
}
