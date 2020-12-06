using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using ControlsLbr.DataGridViewExcelFilter;
using Documents.Properties;
using FormLbr;

namespace Documents.Forms.TechnologicalConnection.Rebinding
{
	public partial class FormJournalRebinding : FormBase
	{
		public FormJournalRebinding()
		{
			
			
			this.method_12();
			this.method_0();
		}

		private void method_0()
		{
			this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, 1, 1);
			this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year, 12, 31);
		}

		private void FormJournalRebinding_Load(object sender, EventArgs e)
		{
			this.tabControl_0.TabPages.Remove(this.pLaRrBunj8);
			this.tabControl_0.TabPages.Remove(this.tabPage_1);
			base.LoadFormConfig(null);
			this.method_3();
			this.method_1(null);
			this.method_2(null);
		}

		private void FormJournalRebinding_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.SaveFormConfig(null);
		}

		private void method_1(int? nullable_1)
		{
			using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString() + ";Connection Timeout=0"))
			{
				sqlConnection.Open();
				try
				{
					string selectCommandText = Class7.smethod_2("Documents.Forms.TechnologicalConnection.SqlScripts.vTC_ChangeOwnership.sql") + string.Format(" and dateDoc >= '{0}' and dateDoc <= '{1}' order by numdoc desc", this.dateTimePicker_1.Value.ToString("yyyyMMdd"), this.dateTimePicker_0.Value.ToString("yyyyMMdd"));
					this.class10_0.vTC_ChangeOwnership.Clear();
					new SqlDataAdapter(selectCommandText, sqlConnection).Fill(this.class10_0.vTC_ChangeOwnership);
					if (nullable_1 != null)
					{
						this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_1.Name, nullable_1.ToString(), false);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
				}
			}
		}

		private void method_2(int? nullable_1 = null)
		{
			using (SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString() + ";Connection Timeout=0"))
			{
				sqlConnection.Open();
				try
				{
					string selectCommandText = Class7.smethod_2("Documents.Forms.TechnologicalConnection.SqlScripts.vTC_ChangeSwitch.sql") + string.Format(" and dateDoc >= '{0}' and dateDoc <= '{1}' order by numdoc desc", this.dateTimePicker_1.Value.ToString("yyyyMMdd"), this.dateTimePicker_0.Value.ToString("yyyyMMdd"));
					this.class10_0.vTC_ChangeSwitch.Clear();
					new SqlDataAdapter(selectCommandText, sqlConnection).Fill(this.class10_0.vTC_ChangeSwitch);
					if (nullable_1 != null)
					{
						this.dataGridViewExcelFilter_1.SearchGrid(this.dataGridViewTextBoxColumn_18.Name, nullable_1.ToString(), false);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.Source);
				}
			}
		}

		private void method_3()
		{
			DataTable dataTable = new DataTable("tR_Classifier");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("name", typeof(string));
			base.SelectSqlData(dataTable, true, "where ParentKey = ';TechConnect;TypeDoc;Rebinding;' and isGroup = 0 and deleted = 0 order by id", null, false, 0);
			this.toolStripDropDownButton_0.DropDownItems.Clear();
			foreach (object obj in dataTable.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				if (Convert.ToInt32(dataRow["id"]) == 1346)
				{
					ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(dataRow["name"].ToString());
					toolStripMenuItem.Tag = dataRow["id"];
					toolStripMenuItem.Click += this.method_4;
					this.toolStripDropDownButton_0.DropDownItems.Add(toolStripMenuItem);
				}
			}
		}

		private void method_4(object sender, EventArgs e)
		{
			if (sender != null && sender is ToolStripMenuItem)
			{
				if (((ToolStripMenuItem)sender).Tag == null)
				{
					return;
				}
				switch (Convert.ToInt32(((ToolStripMenuItem)sender).Tag))
				{
				case 1345:
				{
					FormDocChangeOwnerShipAddEdit form = new FormDocChangeOwnerShipAddEdit(null);
					form.SqlSettings = this.SqlSettings;
					form.MdiParent = base.MdiParent;
					form.FormClosed += this.method_6;
					form.Show();
					return;
				}
				case 1346:
				{
					FormDocChangeSwitch formDocChangeSwitch = new FormDocChangeSwitch(null, false);
					formDocChangeSwitch.SqlSettings = this.SqlSettings;
					formDocChangeSwitch.MdiParent = base.MdiParent;
					formDocChangeSwitch.FormClosed += this.method_5;
					formDocChangeSwitch.Show();
					break;
				}
				case 1347:
					break;
				default:
					return;
				}
			}
		}

		private void method_5(object sender, FormClosedEventArgs e)
		{
			FormDocChangeSwitch formDocChangeSwitch = (FormDocChangeSwitch)sender;
			this.method_2(formDocChangeSwitch.method_0());
		}

		private void method_6(object sender, FormClosedEventArgs e)
		{
			FormDocChangeOwnerShipAddEdit form = (FormDocChangeOwnerShipAddEdit)sender;
			this.method_1(form.RcCjXgcuhc());
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			if (this.tabControl_0.SelectedTab == this.pLaRrBunj8 && this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				FormDocChangeOwnerShipAddEdit form = new FormDocChangeOwnerShipAddEdit(new int?(Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_1.Name].Value)));
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.FormClosed += this.method_6;
				form.Show();
			}
			if (this.tabControl_0.SelectedTab == this.tabPage_0 && this.dataGridViewExcelFilter_1.CurrentRow != null)
			{
				FormDocChangeSwitch formDocChangeSwitch = new FormDocChangeSwitch(new int?(Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_18.Name].Value)), false);
				formDocChangeSwitch.SqlSettings = this.SqlSettings;
				formDocChangeSwitch.MdiParent = base.MdiParent;
				formDocChangeSwitch.FormClosed += this.method_5;
				formDocChangeSwitch.Show();
			}
		}

		private void toolStripButton_9_Click(object sender, EventArgs e)
		{
			if (this.tabControl_0.SelectedTab == this.tabPage_0 && this.dataGridViewExcelFilter_1.CurrentRow != null)
			{
				new FormDocChangeSwitch(new int?(Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_18.Name].Value)), true)
				{
					SqlSettings = this.SqlSettings,
					MdiParent = base.MdiParent
				}.Show();
			}
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			if (this.tabControl_0.SelectedTab == this.tabPage_0 && this.dataGridViewExcelFilter_1.CurrentRow != null)
			{
				if (Convert.ToBoolean(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewCheckBoxColumn_1.Name].Value))
				{
					MessageBox.Show("Невозможно удалить проведенный документ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				if (MessageBox.Show("Вы действительно хотите удалить выбранный документ", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class10_0.tTC_Doc, Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_18.Name].Value)))
				{
					this.dataGridViewExcelFilter_1.Rows.Remove(this.dataGridViewExcelFilter_1.CurrentRow);
				}
			}
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			this.method_1(null);
			this.method_2(this.nullable_0);
		}

		private DataGridViewExcelFilter method_7()
		{
			if (this.tabControl_0.SelectedTab == this.pLaRrBunj8)
			{
				return this.dataGridViewExcelFilter_0;
			}
			if (this.tabControl_0.SelectedTab == this.tabPage_0)
			{
				return this.dataGridViewExcelFilter_1;
			}
			if (this.tabControl_0.SelectedTab == this.tabPage_1)
			{
				return this.dataGridViewExcelFilter_2;
			}
			return null;
		}

		private void method_8(object sender, EventArgs e)
		{
			DataGridViewExcelFilter dataGridViewExcelFilter = this.method_7();
			if (dataGridViewExcelFilter != null)
			{
				dataGridViewExcelFilter.SearchGrid(DataGridViewExcelFilter.TypeFind.Begin, this.toolStripTextBox_0.Text);
			}
		}

		private void method_9(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				DataGridViewExcelFilter dataGridViewExcelFilter = this.method_7();
				if (dataGridViewExcelFilter != null)
				{
					if (e.Modifiers == Keys.None)
					{
						dataGridViewExcelFilter.SearchGrid(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_0.Text);
					}
					if (e.Modifiers == Keys.Shift)
					{
						dataGridViewExcelFilter.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_0.Text);
					}
				}
			}
		}

		private void method_10(object sender, EventArgs e)
		{
			DataGridViewExcelFilter dataGridViewExcelFilter = this.method_7();
			if (dataGridViewExcelFilter != null)
			{
				dataGridViewExcelFilter.SearchGrid(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_0.Text);
			}
		}

		private void method_11(object sender, EventArgs e)
		{
			DataGridViewExcelFilter dataGridViewExcelFilter = this.method_7();
			if (dataGridViewExcelFilter != null)
			{
				dataGridViewExcelFilter.SearchGrid(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_0.Text);
			}
		}

		private void toolStripButton_8_Click(object sender, EventArgs e)
		{
			DataGridViewExcelFilter dataGridViewExcelFilter = this.method_7();
			if (dataGridViewExcelFilter != null)
			{
				dataGridViewExcelFilter.ExportToExcel();
			}
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			this.method_1(null);
			this.method_2(this.nullable_0);
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			this.method_0();
			this.method_1(null);
			this.method_2(this.nullable_0);
		}

		protected override XmlDocument CreateXmlConfig()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlNode newChild = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
			xmlDocument.AppendChild(newChild);
			XmlNode xmlNode = xmlDocument.CreateElement(base.Name);
			xmlDocument.AppendChild(xmlNode);
			XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("FilterDateBeg");
			xmlAttribute.Value = this.dateTimePicker_1.Value.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute("FilterDateEnd");
			xmlAttribute.Value = this.dateTimePicker_0.Value.ToString();
			xmlNode.Attributes.Append(xmlAttribute);
			return xmlDocument;
		}

		protected override void ApplyConfig(XmlDocument doc)
		{
			XmlNode xmlNode = doc.SelectSingleNode(base.Name);
			if (xmlNode != null)
			{
				XmlAttribute xmlAttribute = xmlNode.Attributes["FilterDateBeg"];
				if (xmlAttribute != null)
				{
					this.dateTimePicker_1.Value = Convert.ToDateTime(xmlAttribute.Value);
				}
				xmlAttribute = xmlNode.Attributes["FilterDateEnd"];
				if (xmlAttribute != null)
				{
					this.dateTimePicker_0.Value = Convert.ToDateTime(xmlAttribute.Value);
				}
			}
		}

		private void dataGridViewExcelFilter_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				if (this.toolStripButton_2.Enabled && this.toolStripButton_2.Visible)
				{
					this.toolStripButton_2_Click(sender, e);
					return;
				}
				this.toolStripButton_9_Click(sender, e);
			}
		}

		private void dataGridViewExcelFilter_1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && Convert.ToBoolean(this.dataGridViewExcelFilter_1[this.dataGridViewCheckBoxColumn_1.Name, e.RowIndex].Value))
			{
				e.CellStyle.BackColor = Color.LightGray;
			}
		}

		private void bindingSource_1_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bindingSource_1.Current != null)
			{
				this.nullable_0 = new int?(Convert.ToInt32(((DataRowView)this.bindingSource_1.Current).Row["id"]));
				return;
			}
			this.nullable_0 = null;
		}

		private void method_12()
		{
			this.icontainer_0 = new Container();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripDropDownButton_0 = new ToolStripDropDownButton();
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripMenuItem_1 = new ToolStripMenuItem();
			this.toolStripMenuItem_2 = new ToolStripMenuItem();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_4 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripTextBox_0 = new ToolStripTextBox();
			this.toolStripButton_6 = new ToolStripButton();
			this.toolStripButton_7 = new ToolStripButton();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripButton_8 = new ToolStripButton();
			this.splitContainer_0 = new SplitContainer();
			this.dateTimePicker_0 = new DateTimePicker();
			this.label_0 = new Label();
			this.dateTimePicker_1 = new DateTimePicker();
			this.label_1 = new Label();
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.tabControl_0 = new TabControl();
			this.pLaRrBunj8 = new TabPage();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_11 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_15 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_16 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.class10_0 = new Class10();
			this.tabPage_0 = new TabPage();
			this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_22 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_23 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_24 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_25 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_26 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_27 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_28 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_29 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_30 = new DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn_1 = new DataGridViewCheckBoxColumn();
			this.bindingSource_1 = new BindingSource(this.icontainer_0);
			this.tabPage_1 = new TabPage();
			this.dataGridViewExcelFilter_2 = new DataGridViewExcelFilter();
			this.toolStripButton_9 = new ToolStripButton();
			this.toolStrip_0.SuspendLayout();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			this.toolStrip_1.SuspendLayout();
			this.tabControl_0.SuspendLayout();
			this.pLaRrBunj8.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.class10_0).BeginInit();
			this.tabPage_0.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
			((ISupportInitialize)this.bindingSource_1).BeginInit();
			this.tabPage_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_2).BeginInit();
			base.SuspendLayout();
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripDropDownButton_0,
				this.toolStripButton_2,
				this.toolStripButton_9,
				this.toolStripButton_3,
				this.toolStripSeparator_0,
				this.toolStripButton_4,
				this.toolStripSeparator_1,
				this.toolStripButton_5,
				this.toolStripTextBox_0,
				this.toolStripButton_6,
				this.toolStripButton_7,
				this.toolStripSeparator_2,
				this.toolStripButton_8
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStripMain";
			this.toolStrip_0.Size = new Size(798, 25);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = "toolStrip";
			this.toolStripDropDownButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButton_0.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_0,
				this.toolStripMenuItem_1,
				this.toolStripMenuItem_2
			});
			this.toolStripDropDownButton_0.Image = Resources.ElementAdd;
			this.toolStripDropDownButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripDropDownButton_0.Name = "toolBtnAddDoc";
			this.toolStripDropDownButton_0.Size = new Size(29, 22);
			this.toolStripDropDownButton_0.Text = "Добавить документ";
			this.toolStripMenuItem_0.Name = "сменаСобственникаToolStripMenuItem";
			this.toolStripMenuItem_0.Size = new Size(218, 22);
			this.toolStripMenuItem_0.Tag = "1345";
			this.toolStripMenuItem_0.Text = "Смена собственника";
			this.toolStripMenuItem_1.Name = "сменаРубильникаToolStripMenuItem";
			this.toolStripMenuItem_1.Size = new Size(218, 22);
			this.toolStripMenuItem_1.Tag = "1346";
			this.toolStripMenuItem_1.Text = "Смена рубильника";
			this.toolStripMenuItem_2.Name = "сменаИмениРубильникаToolStripMenuItem";
			this.toolStripMenuItem_2.Size = new Size(218, 22);
			this.toolStripMenuItem_2.Tag = "1347";
			this.toolStripMenuItem_2.Text = "Смена имени рубильника";
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.ElementEdit;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnEditDoc";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Редактировать";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = Resources.ElementDel;
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnDelDoc";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Удалить";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator5";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = Resources.refresh_16;
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnRefresh";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Обновить";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator2";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = Resources.Find;
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBtnFindRequest";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "Поиск";
			this.toolStripTextBox_0.Name = "toolTxtFind";
			this.toolStripTextBox_0.Size = new Size(100, 25);
			this.toolStripTextBox_0.ToolTipText = "Текст для поиска";
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = Resources.FindPrev;
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "toolBtnFindPrev";
			this.toolStripButton_6.Size = new Size(23, 22);
			this.toolStripButton_6.Text = "поиск назад";
			this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_7.Image = Resources.FindNext;
			this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_7.Name = "toolBtnFindNext";
			this.toolStripButton_7.Size = new Size(23, 22);
			this.toolStripButton_7.Text = "поиск вперед";
			this.toolStripSeparator_2.Name = "toolStripSeparator3";
			this.toolStripSeparator_2.Size = new Size(6, 25);
			this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_8.Image = Resources.microsoftoffice2007excel_7581;
			this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_8.Name = "toolBtnExportExcel";
			this.toolStripButton_8.Size = new Size(23, 22);
			this.toolStripButton_8.Text = "Экспорт в Excel";
			this.toolStripButton_8.Click += this.toolStripButton_8_Click;
			this.splitContainer_0.Dock = DockStyle.Fill;
			this.splitContainer_0.Location = new Point(0, 25);
			this.splitContainer_0.Name = "splitContainer1";
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_0);
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_1);
			this.splitContainer_0.Panel1.Controls.Add(this.label_1);
			this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_1);
			this.splitContainer_0.Panel2.Controls.Add(this.tabControl_0);
			this.splitContainer_0.Size = new Size(798, 388);
			this.splitContainer_0.SplitterDistance = 167;
			this.splitContainer_0.TabIndex = 1;
			this.dateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_0.Location = new Point(12, 80);
			this.dateTimePicker_0.Name = "dateTimePickerFilterEnd";
			this.dateTimePicker_0.Size = new Size(142, 20);
			this.dateTimePicker_0.TabIndex = 8;
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(12, 64);
			this.label_0.Name = "label2";
			this.label_0.Size = new Size(89, 13);
			this.label_0.TabIndex = 7;
			this.label_0.Text = "Дата окончания";
			this.dateTimePicker_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_1.Location = new Point(12, 41);
			this.dateTimePicker_1.Name = "dateTimePickerFilterBeg";
			this.dateTimePicker_1.Size = new Size(142, 20);
			this.dateTimePicker_1.TabIndex = 6;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(12, 22);
			this.label_1.Name = "label1";
			this.label_1.Size = new Size(71, 13);
			this.label_1.TabIndex = 5;
			this.label_1.Text = "Дата начала";
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripButton_1
			});
			this.toolStrip_1.Location = new Point(0, 0);
			this.toolStrip_1.Name = "toolStripFilter";
			this.toolStrip_1.Size = new Size(167, 25);
			this.toolStrip_1.TabIndex = 1;
			this.toolStrip_1.Text = "toolStrip1";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.filter;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnApplyFilter";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Применить фильтр";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.filter_delete;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnClearFilter";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Очистить фильтр";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.tabControl_0.Controls.Add(this.pLaRrBunj8);
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Dock = DockStyle.Fill;
			this.tabControl_0.Location = new Point(0, 0);
			this.tabControl_0.Name = "tabControl";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new Size(627, 388);
			this.tabControl_0.TabIndex = 0;
			this.pLaRrBunj8.Controls.Add(this.dataGridViewExcelFilter_0);
			this.pLaRrBunj8.Location = new Point(4, 22);
			this.pLaRrBunj8.Name = "tabPageChangeOwnerShip";
			this.pLaRrBunj8.Padding = new Padding(3);
			this.pLaRrBunj8.Size = new Size(619, 362);
			this.pLaRrBunj8.TabIndex = 0;
			this.pLaRrBunj8.Text = "Смена собственника";
			this.pLaRrBunj8.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_3,
				this.dataGridViewTextBoxColumn_4,
				this.dataGridViewTextBoxColumn_5,
				this.dataGridViewTextBoxColumn_6,
				this.dataGridViewTextBoxColumn_7,
				this.dataGridViewTextBoxColumn_8,
				this.dataGridViewTextBoxColumn_9,
				this.dataGridViewTextBoxColumn_10,
				this.dataGridViewTextBoxColumn_11,
				this.dataGridViewTextBoxColumn_12,
				this.dataGridViewTextBoxColumn_13,
				this.dataGridViewTextBoxColumn_14,
				this.dataGridViewTextBoxColumn_15,
				this.dataGridViewTextBoxColumn_16,
				this.dataGridViewTextBoxColumn_17,
				this.dataGridViewCheckBoxColumn_0
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.Location = new Point(3, 3);
			this.dataGridViewExcelFilter_0.Name = "dgvChangeOwnership";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.Size = new Size(613, 356);
			this.dataGridViewExcelFilter_0.TabIndex = 0;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "numdoc";
			this.dataGridViewTextBoxColumn_0.HeaderText = "№ док";
			this.dataGridViewTextBoxColumn_0.Name = "numdocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_1.HeaderText = "id";
			this.dataGridViewTextBoxColumn_1.Name = "idChangeOwnershipDgvColumn";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_2.HeaderText = "Дата документа";
			this.dataGridViewTextBoxColumn_2.Name = "dateDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "codeAbonentOld";
			this.dataGridViewTextBoxColumn_3.HeaderText = "Код (стар)";
			this.dataGridViewTextBoxColumn_3.Name = "codeAbonentOldDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "typeDoc";
			this.dataGridViewTextBoxColumn_4.HeaderText = "typeDoc";
			this.dataGridViewTextBoxColumn_4.Name = "typeDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.Visible = false;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "comment";
			this.dataGridViewTextBoxColumn_5.HeaderText = "comment";
			this.dataGridViewTextBoxColumn_5.Name = "commentDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "numdocin";
			this.dataGridViewTextBoxColumn_6.HeaderText = "numdocin";
			this.dataGridViewTextBoxColumn_6.Name = "numdocinDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "typedocin";
			this.dataGridViewTextBoxColumn_7.HeaderText = "typedocin";
			this.dataGridViewTextBoxColumn_7.Name = "typedocinDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewTextBoxColumn_8.DataPropertyName = "dateDocIn";
			this.dataGridViewTextBoxColumn_8.HeaderText = "dateDocIn";
			this.dataGridViewTextBoxColumn_8.Name = "dateDocInDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewTextBoxColumn_9.DataPropertyName = "idAbnOld";
			this.dataGridViewTextBoxColumn_9.HeaderText = "idAbnOld";
			this.dataGridViewTextBoxColumn_9.Name = "idAbnOldDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewTextBoxColumn_10.DataPropertyName = "nameAbnOld";
			this.dataGridViewTextBoxColumn_10.HeaderText = "nameAbnOld";
			this.dataGridViewTextBoxColumn_10.Name = "nameAbnOldDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewTextBoxColumn_11.DataPropertyName = "idAbnObjOld";
			this.dataGridViewTextBoxColumn_11.HeaderText = "idAbnObjOld";
			this.dataGridViewTextBoxColumn_11.Name = "idAbnObjOldDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewTextBoxColumn_12.DataPropertyName = "nameObjOld";
			this.dataGridViewTextBoxColumn_12.HeaderText = "nameObjOld";
			this.dataGridViewTextBoxColumn_12.Name = "nameObjOldDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewTextBoxColumn_13.DataPropertyName = "idAbnNew";
			this.dataGridViewTextBoxColumn_13.HeaderText = "idAbnNew";
			this.dataGridViewTextBoxColumn_13.Name = "idAbnNewDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewTextBoxColumn_14.DataPropertyName = "codeAbonentNew";
			this.dataGridViewTextBoxColumn_14.HeaderText = "codeAbonentNew";
			this.dataGridViewTextBoxColumn_14.Name = "codeAbonentNewDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewTextBoxColumn_15.DataPropertyName = "nameAbnNew";
			this.dataGridViewTextBoxColumn_15.HeaderText = "nameAbnNew";
			this.dataGridViewTextBoxColumn_15.Name = "nameAbnNewDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewTextBoxColumn_16.DataPropertyName = "idAbnObjNew";
			this.dataGridViewTextBoxColumn_16.HeaderText = "idAbnObjNew";
			this.dataGridViewTextBoxColumn_16.Name = "idAbnObjNewDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewTextBoxColumn_17.DataPropertyName = "nameObjNew";
			this.dataGridViewTextBoxColumn_17.HeaderText = "nameObjNew";
			this.dataGridViewTextBoxColumn_17.Name = "nameObjNewDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_0.DataPropertyName = "isApply";
			this.dataGridViewCheckBoxColumn_0.HeaderText = "isApply";
			this.dataGridViewCheckBoxColumn_0.Name = "isApplyDataGridViewCheckBoxColumn";
			this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
			this.bindingSource_0.DataMember = "vTC_ChangeOwnership";
			this.bindingSource_0.DataSource = this.class10_0;
			this.class10_0.DataSetName = "DataSetTechConnection";
			this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.tabPage_0.Controls.Add(this.dataGridViewExcelFilter_1);
			this.tabPage_0.Location = new Point(4, 22);
			this.tabPage_0.Name = "tabPageChangeCell";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.Size = new Size(619, 362);
			this.tabPage_0.TabIndex = 1;
			this.tabPage_0.Text = "Смена рубильника";
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter_1.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_1.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewFilterTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_18,
				this.dataGridViewFilterTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_19,
				this.dataGridViewTextBoxColumn_20,
				this.dataGridViewTextBoxColumn_21,
				this.dataGridViewTextBoxColumn_22,
				this.dataGridViewTextBoxColumn_23,
				this.dataGridViewTextBoxColumn_24,
				this.dataGridViewTextBoxColumn_25,
				this.dataGridViewTextBoxColumn_26,
				this.dataGridViewTextBoxColumn_27,
				this.dataGridViewFilterTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_28,
				this.dataGridViewTextBoxColumn_29,
				this.dataGridViewTextBoxColumn_30,
				this.dataGridViewCheckBoxColumn_1
			});
			this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_1;
			this.dataGridViewExcelFilter_1.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_1.Location = new Point(3, 3);
			this.dataGridViewExcelFilter_1.Name = "dgvChangeSwitch";
			this.dataGridViewExcelFilter_1.ReadOnly = true;
			this.dataGridViewExcelFilter_1.Size = new Size(613, 356);
			this.dataGridViewExcelFilter_1.TabIndex = 0;
			this.dataGridViewExcelFilter_1.CellDoubleClick += this.dataGridViewExcelFilter_1_CellDoubleClick;
			this.dataGridViewExcelFilter_1.CellFormatting += this.dataGridViewExcelFilter_1_CellFormatting;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "numdoc";
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "№ док";
			this.dataGridViewFilterTextBoxColumn_0.Name = "numdocDataGridViewTextBoxColumn1";
			this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_18.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_18.HeaderText = "id";
			this.dataGridViewTextBoxColumn_18.Name = "idChangeSwitchDgvColumn";
			this.dataGridViewTextBoxColumn_18.ReadOnly = true;
			this.dataGridViewTextBoxColumn_18.Visible = false;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "dateDoc";
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Дата док";
			this.dataGridViewFilterTextBoxColumn_1.Name = "dateDocDataGridViewTextBoxColumn1";
			this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_19.DataPropertyName = "typeDoc";
			this.dataGridViewTextBoxColumn_19.HeaderText = "typeDoc";
			this.dataGridViewTextBoxColumn_19.Name = "typeDocDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_19.ReadOnly = true;
			this.dataGridViewTextBoxColumn_19.Visible = false;
			this.dataGridViewTextBoxColumn_20.DataPropertyName = "comment";
			this.dataGridViewTextBoxColumn_20.HeaderText = "comment";
			this.dataGridViewTextBoxColumn_20.Name = "commentDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_20.ReadOnly = true;
			this.dataGridViewTextBoxColumn_20.Visible = false;
			this.dataGridViewTextBoxColumn_21.DataPropertyName = "numdocin";
			this.dataGridViewTextBoxColumn_21.HeaderText = "numdocin";
			this.dataGridViewTextBoxColumn_21.Name = "numdocinDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_21.ReadOnly = true;
			this.dataGridViewTextBoxColumn_21.Visible = false;
			this.dataGridViewTextBoxColumn_22.DataPropertyName = "typedocin";
			this.dataGridViewTextBoxColumn_22.HeaderText = "typedocin";
			this.dataGridViewTextBoxColumn_22.Name = "typedocinDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_22.ReadOnly = true;
			this.dataGridViewTextBoxColumn_22.Visible = false;
			this.dataGridViewTextBoxColumn_23.DataPropertyName = "dateDocIn";
			this.dataGridViewTextBoxColumn_23.HeaderText = "dateDocIn";
			this.dataGridViewTextBoxColumn_23.Name = "dateDocInDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_23.ReadOnly = true;
			this.dataGridViewTextBoxColumn_23.Visible = false;
			this.dataGridViewTextBoxColumn_24.DataPropertyName = "idSchmObjOld";
			this.dataGridViewTextBoxColumn_24.HeaderText = "idSchmObjOld";
			this.dataGridViewTextBoxColumn_24.Name = "idSchmObjOldDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_24.ReadOnly = true;
			this.dataGridViewTextBoxColumn_24.Visible = false;
			this.dataGridViewTextBoxColumn_25.DataPropertyName = "idSchmObjNew";
			this.dataGridViewTextBoxColumn_25.HeaderText = "idSchmObjNew";
			this.dataGridViewTextBoxColumn_25.Name = "idSchmObjNewDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_25.ReadOnly = true;
			this.dataGridViewTextBoxColumn_25.Visible = false;
			this.dataGridViewTextBoxColumn_26.DataPropertyName = "subOldId";
			this.dataGridViewTextBoxColumn_26.HeaderText = "subOldId";
			this.dataGridViewTextBoxColumn_26.Name = "subOldIdDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_26.ReadOnly = true;
			this.dataGridViewTextBoxColumn_26.Visible = false;
			this.dataGridViewTextBoxColumn_27.DataPropertyName = "subOldName";
			this.dataGridViewTextBoxColumn_27.HeaderText = "subOldName";
			this.dataGridViewTextBoxColumn_27.Name = "subOldNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_27.ReadOnly = true;
			this.dataGridViewTextBoxColumn_27.Visible = false;
			this.dataGridViewFilterTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "schmObjNameOld";
			this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Объект стар";
			this.dataGridViewFilterTextBoxColumn_2.Name = "schmObjNameOldDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_28.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_28.DataPropertyName = "schmObjNameNew";
			this.dataGridViewTextBoxColumn_28.HeaderText = "Объект нов";
			this.dataGridViewTextBoxColumn_28.Name = "schmObjNameNewDgvColumn";
			this.dataGridViewTextBoxColumn_28.ReadOnly = true;
			this.dataGridViewTextBoxColumn_29.DataPropertyName = "subNewId";
			this.dataGridViewTextBoxColumn_29.HeaderText = "subNewId";
			this.dataGridViewTextBoxColumn_29.Name = "subNewIdDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_29.ReadOnly = true;
			this.dataGridViewTextBoxColumn_29.Visible = false;
			this.dataGridViewTextBoxColumn_30.DataPropertyName = "subNewName";
			this.dataGridViewTextBoxColumn_30.HeaderText = "subNewName";
			this.dataGridViewTextBoxColumn_30.Name = "subNewNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_30.ReadOnly = true;
			this.dataGridViewTextBoxColumn_30.Visible = false;
			this.dataGridViewCheckBoxColumn_1.DataPropertyName = "isApply";
			this.dataGridViewCheckBoxColumn_1.HeaderText = "isApply";
			this.dataGridViewCheckBoxColumn_1.Name = "isApplychangeCellDgvColumn";
			this.dataGridViewCheckBoxColumn_1.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_1.Visible = false;
			this.bindingSource_1.DataMember = "vTC_ChangeSwitch";
			this.bindingSource_1.DataSource = this.class10_0;
			this.bindingSource_1.CurrentChanged += this.bindingSource_1_CurrentChanged;
			this.tabPage_1.Controls.Add(this.dataGridViewExcelFilter_2);
			this.tabPage_1.Location = new Point(4, 22);
			this.tabPage_1.Name = "tabPageChangeNameCell";
			this.tabPage_1.Padding = new Padding(3);
			this.tabPage_1.Size = new Size(619, 362);
			this.tabPage_1.TabIndex = 2;
			this.tabPage_1.Text = "Смена имени рубильника";
			this.tabPage_1.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_2.Location = new Point(195, 116);
			this.dataGridViewExcelFilter_2.Name = "dgvChangeNameCell";
			this.dataGridViewExcelFilter_2.Size = new Size(240, 150);
			this.dataGridViewExcelFilter_2.TabIndex = 0;
			this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_9.Image = Resources.ElementInformation;
			this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_9.Name = "toolBtnInfo";
			this.toolStripButton_9.Size = new Size(23, 22);
			this.toolStripButton_9.Text = "Просмотр";
			this.toolStripButton_9.Click += this.toolStripButton_9_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(798, 413);
			base.Controls.Add(this.splitContainer_0);
			base.Controls.Add(this.toolStrip_0);
			base.Name = "FormJournalRebinding";
			this.Text = "Журнал перепривязок абонентов";
			base.FormClosed += this.FormJournalRebinding_FormClosed;
			base.Load += this.FormJournalRebinding_Load;
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.ResumeLayout(false);
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			this.tabControl_0.ResumeLayout(false);
			this.pLaRrBunj8.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.class10_0).EndInit();
			this.tabPage_0.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
			((ISupportInitialize)this.bindingSource_1).EndInit();
			this.tabPage_1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private int? nullable_0;

		private ToolStrip toolStrip_0;

		private SplitContainer splitContainer_0;

		private TabControl tabControl_0;

		private TabPage pLaRrBunj8;

		private TabPage tabPage_0;

		private TabPage tabPage_1;

		private ToolStrip toolStrip_1;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private DateTimePicker dateTimePicker_0;

		private Label label_0;

		private DateTimePicker dateTimePicker_1;

		private Label label_1;

		private ToolStripDropDownButton toolStripDropDownButton_0;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripButton toolStripButton_2;

		private ToolStripButton toolStripButton_3;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton toolStripButton_4;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripButton toolStripButton_5;

		private ToolStripTextBox toolStripTextBox_0;

		private ToolStripButton toolStripButton_6;

		private ToolStripButton toolStripButton_7;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripButton toolStripButton_8;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private BindingSource bindingSource_0;

		private Class10 class10_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

		private DataGridViewExcelFilter dataGridViewExcelFilter_1;

		private BindingSource bindingSource_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_22;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_23;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_24;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_25;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_26;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_27;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_28;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_29;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_30;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_1;

		private DataGridViewExcelFilter dataGridViewExcelFilter_2;

		private ToolStripButton toolStripButton_9;
	}
}
