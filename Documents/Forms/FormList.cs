using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DataSql;
using Documents.Properties;
using FormLbr;

namespace Documents.Forms
{
	public partial class FormList : FormBase
	{
		public FormList()
		{
			
			this.formFilter_0 = new FormFilter();
			this.list_0 = new List<string>();
			
			this.method_1();
		}

		public FormList(SQLSettings SqlSettings)
		{
			
			this.formFilter_0 = new FormFilter();
			this.list_0 = new List<string>();
			
			this.method_1();
			this.SqlSettings = SqlSettings;
		}

		private void FormList_Load(object sender, EventArgs e)
		{
			this.class585_0.vmethod_0(this.class548_0.tblAbnAplForDiscon);
			this.formFilter_0.ShowDoNotDisplayZone = false;
			this.formFilter_0.ShowPeriodExecutionApplication = false;
			this.formFilter_0.Deactivate += this.formFilter_0_Deactivate;
			this.formFilter_0.Legal = true;
			this.formFilter_0.Individual = true;
			this.formFilter_0.UsePeriod = true;
			this.formFilter_0.BeginningOfPeriod = DateTime.Today.AddDays((double)(-1 * (DateTime.Today.Day - 1)));
			this.formFilter_0.EndOfPeriod = DateTime.Today.AddDays((double)(DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) - DateTime.Today.Day));
			this.formFilter_0.Disconnection = true;
			this.formFilter_0.Resumption = true;
			this.formFilter_0.Cancel = true;
			this.formFilter_0.ShowNetArea = false;
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
					this.list_0.Add(xmlNode.Attributes["Name"].Value);
				}
			}
			this.method_0();
		}

		private void dataGridView_0_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
			{
				if (!((Class548.Class567)((DataRowView)this.bindingSource_0[i]).Row).method_2())
				{
					if (this.list_0.Count <= ((Class548.Class567)((DataRowView)this.bindingSource_0[i]).Row).NetArea)
					{
						this.dataGridView_0.Rows[i].Cells[3].Value = string.Empty;
					}
					else
					{
						this.dataGridView_0.Rows[i].Cells[3].Value = this.list_0[((Class548.Class567)((DataRowView)this.bindingSource_0[i]).Row).NetArea];
					}
				}
				if (!((Class548.Class567)((DataRowView)this.bindingSource_0[i]).Row).method_4())
				{
					switch (((Class548.Class567)((DataRowView)this.bindingSource_0[i]).Row).TypeAction)
					{
					case 0:
						this.dataGridView_0.Rows[i].Cells[4].Value = "ОТКЛЮЧЕНИЕ";
						break;
					case 1:
						this.dataGridView_0.Rows[i].Cells[4].Value = "ВОЗОБНОВЛЕНИЕ";
						break;
					case 2:
						this.dataGridView_0.Rows[i].Cells[4].Value = "ОТМЕНА";
						break;
					}
				}
				if (!((Class548.Class567)((DataRowView)this.bindingSource_0[i]).Row).method_16())
				{
					if (((Class548.Class567)((DataRowView)this.bindingSource_0[i]).Row).LegalAbns)
					{
						this.dataGridView_0.Rows[i].Cells[0].Value = Resources.legaluser;
					}
					else
					{
						this.dataGridView_0.Rows[i].Cells[0].Value = Resources.individualuser;
					}
				}
			}
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			if (this.list_0.Count == 0)
			{
				MessageBox.Show("В настройках не указан список адресатов заявок");
				return;
			}
			this.bindingSource_0.AddNew();
			Class548.Class567 @class = (Class548.Class567)((DataRowView)this.bindingSource_0.Current).Row;
			@class.TypeAction = 0;
			@class.NetArea = 0;
			@class.DateAppl = DateTime.Now;
			@class.DateAction = DateTime.Today.AddDays(2.0).AddHours(9.0);
			new Form9(this, true, this.SqlSettings)
			{
				bindingSource_0 = 
				{
					DataSource = this.bindingSource_0,
					Filter = this.bindingSource_0.Filter,
					Position = this.bindingSource_0.Position
				}
			}.ShowDialog();
			this.class585_0.vmethod_0(this.class548_0.tblAbnAplForDiscon);
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			if (this.list_0.Count == 0)
			{
				MessageBox.Show("В настройках не указан список адресатов заявок");
				return;
			}
			this.bindingSource_0.AddNew();
			Class548.Class567 @class = (Class548.Class567)((DataRowView)this.bindingSource_0.Current).Row;
			@class.TypeAction = 0;
			@class.NetArea = 0;
			@class.DateAppl = DateTime.Today;
			@class.DateAction = DateTime.Today.AddDays(2.0).AddHours(9.0);
			new Form9(this, false, this.SqlSettings)
			{
				bindingSource_0 = 
				{
					DataSource = this.bindingSource_0,
					Filter = this.bindingSource_0.Filter,
					Position = this.bindingSource_0.Position
				}
			}.ShowDialog();
			this.class585_0.vmethod_0(this.class548_0.tblAbnAplForDiscon);
		}

		public int UpdatetblAbnAplForDisconTableAdapter()
		{
			return this.class585_0.vmethod_16(this.class548_0.tblAbnAplForDiscon);
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			if (((Class548.Class567)((DataRowView)this.bindingSource_0.Current).Row).LegalAbns)
			{
				if (new Form9(this, true, this.SqlSettings)
				{
					bindingSource_0 = 
					{
						DataSource = this.bindingSource_0,
						Filter = this.bindingSource_0.Filter,
						Position = this.bindingSource_0.Position
					}
				}.ShowDialog() == DialogResult.OK)
				{
					this.class585_0.vmethod_0(this.class548_0.tblAbnAplForDiscon);
					return;
				}
			}
			else if (new Form9(this, false, this.SqlSettings)
			{
				bindingSource_0 = 
				{
					DataSource = this.bindingSource_0,
					Filter = this.bindingSource_0.Filter,
					Position = this.bindingSource_0.Position
				}
			}.ShowDialog() == DialogResult.OK)
			{
				this.class585_0.vmethod_0(this.class548_0.tblAbnAplForDiscon);
			}
		}

		private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (((Class548.Class567)((DataRowView)this.bindingSource_0.Current).Row).LegalAbns)
			{
				if (new Form9(this, true, this.SqlSettings)
				{
					bindingSource_0 = 
					{
						DataSource = this.bindingSource_0,
						Filter = this.bindingSource_0.Filter,
						Position = this.bindingSource_0.Position
					}
				}.ShowDialog() == DialogResult.OK)
				{
					this.class585_0.vmethod_0(this.class548_0.tblAbnAplForDiscon);
					return;
				}
			}
			else if (new Form9(this, false, this.SqlSettings)
			{
				bindingSource_0 = 
				{
					DataSource = this.bindingSource_0,
					Filter = this.bindingSource_0.Filter,
					Position = this.bindingSource_0.Position
				}
			}.ShowDialog() == DialogResult.OK)
			{
				this.class585_0.vmethod_0(this.class548_0.tblAbnAplForDiscon);
			}
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			this.formFilter_0.Location = new Point(base.Location.X + 25 + base.MdiParent.Location.X, base.Location.Y + 110 + base.MdiParent.Location.Y);
			this.formFilter_0.Show();
		}

		private void formFilter_0_Deactivate(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void method_0()
		{
			List<string> list = new List<string>();
			if (this.formFilter_0.UsePeriod)
			{
				string item = string.Concat(new string[]
				{
					"DateAppl>='",
					this.formFilter_0.BeginningOfPeriod.ToString(),
					"' and DateAppl<='",
					this.formFilter_0.EndOfPeriod.ToString(),
					"'"
				});
				list.Add(item);
			}
			if (!this.formFilter_0.Legal)
			{
				list.Add("LegalAbns <> True");
			}
			if (!this.formFilter_0.Individual)
			{
				list.Add("LegalAbns <> false");
			}
			if (!this.formFilter_0.Disconnection)
			{
				list.Add("TypeAction<>0");
			}
			if (!this.formFilter_0.Resumption)
			{
				list.Add("TypeAction<>1");
			}
			if (!this.formFilter_0.Cancel)
			{
				list.Add("TypeAction<>2");
			}
			if (list.Count == 0)
			{
				this.bindingSource_0.RemoveFilter();
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			foreach (string value in list)
			{
				if (flag)
				{
					stringBuilder.Append(" AND ");
				}
				else
				{
					flag = true;
				}
				stringBuilder.Append(value);
			}
			this.bindingSource_0.Filter = stringBuilder.ToString();
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
				this.class585_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
			}
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			SearchForm searchForm = new SearchForm();
			searchForm.radioButtonLegal.Checked = true;
			searchForm.comboBoxSearchType.SelectedIndex = 0;
			if (searchForm.ShowDialog() == DialogResult.OK)
			{
				if (searchForm.radioButtonLegal.Checked)
				{
					if (searchForm.comboBoxSearchType.SelectedIndex == 0)
					{
						this.class585_0.vmethod_12(this.class548_0.tblAbnAplForDiscon, "%" + searchForm.textBoxName.Text + "%");
						return;
					}
					if (searchForm.comboBoxSearchType.SelectedIndex == 1)
					{
						this.class585_0.vmethod_14(this.class548_0.tblAbnAplForDiscon, "%" + searchForm.textBoxName.Text + "%");
						return;
					}
					if (searchForm.comboBoxSearchType.SelectedIndex == 2)
					{
						int int_ = -1;
						try
						{
							int_ = Convert.ToInt32(searchForm.textBoxName.Text);
						}
						catch
						{
						}
						this.class585_0.vmethod_10(this.class548_0.tblAbnAplForDiscon, int_);
						return;
					}
				}
				else if (searchForm.radioButtonIndiviual.Checked)
				{
					if (searchForm.comboBoxSearchType.SelectedIndex == 0)
					{
						this.class585_0.vmethod_8(this.class548_0.tblAbnAplForDiscon, "%" + searchForm.textBoxName.Text + "%");
						return;
					}
					if (searchForm.comboBoxSearchType.SelectedIndex == 1)
					{
						this.class585_0.vmethod_4(this.class548_0.tblAbnAplForDiscon, "%" + searchForm.textBoxName.Text + "%");
						return;
					}
					if (searchForm.comboBoxSearchType.SelectedIndex == 2)
					{
						int value = -1;
						try
						{
							value = Convert.ToInt32(searchForm.textBoxName.Text);
						}
						catch
						{
						}
						this.class585_0.vmethod_6(this.class548_0.tblAbnAplForDiscon, new int?(value));
					}
				}
			}
		}

		private void toolStripButton_5_Click(object sender, EventArgs e)
		{
			this.class585_0.vmethod_0(this.class548_0.tblAbnAplForDiscon);
			this.formFilter_0.ShowDoNotDisplayZone = false;
			this.formFilter_0.ShowPeriodExecutionApplication = false;
			this.formFilter_0.Legal = true;
			this.formFilter_0.Individual = true;
			this.formFilter_0.UsePeriod = true;
			this.formFilter_0.BeginningOfPeriod = DateTime.Today.AddDays((double)(-1 * (DateTime.Today.Day - 1)));
			this.formFilter_0.EndOfPeriod = DateTime.Today.AddDays((double)(DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) - DateTime.Today.Day));
			this.formFilter_0.Disconnection = true;
			this.formFilter_0.Resumption = true;
			this.formFilter_0.Cancel = true;
			this.formFilter_0.ShowNetArea = false;
			this.method_0();
		}

		private void toolStripButton_6_Click(object sender, EventArgs e)
		{
			new Form73
			{
				SqlSettings = this.SqlSettings
			}.ShowDialog();
		}

		private void method_1()
		{
			this.icontainer_0 = new Container();
			this.dataGridView_0 = new DataGridView();
			this.dataGridViewImageColumn_0 = new DataGridViewImageColumn();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.class548_0 = new Class548();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripButton_4 = new ToolStripButton();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripButton_6 = new ToolStripButton();
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.class585_0 = new Class585();
			((ISupportInitialize)this.dataGridView_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.class548_0).BeginInit();
			this.toolStrip_0.SuspendLayout();
			this.toolStrip_1.SuspendLayout();
			base.SuspendLayout();
			this.dataGridView_0.AllowUserToAddRows = false;
			this.dataGridView_0.AllowUserToDeleteRows = false;
			this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.dataGridView_0.AutoGenerateColumns = false;
			this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewImageColumn_0,
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_3,
				this.dataGridViewTextBoxColumn_4
			});
			this.dataGridView_0.DataSource = this.bindingSource_0;
			this.dataGridView_0.Location = new Point(12, 53);
			this.dataGridView_0.MultiSelect = false;
			this.dataGridView_0.Name = "dataGridViewDocList";
			this.dataGridView_0.ReadOnly = true;
			this.dataGridView_0.RowHeadersWidth = 25;
			this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_0.Size = new Size(565, 409);
			this.dataGridView_0.TabIndex = 0;
			this.dataGridView_0.CellDoubleClick += this.dataGridView_0_CellDoubleClick;
			this.dataGridView_0.RowsAdded += this.dataGridView_0_RowsAdded;
			this.dataGridViewImageColumn_0.HeaderText = "";
			this.dataGridViewImageColumn_0.Name = "TypeAbn";
			this.dataGridViewImageColumn_0.ReadOnly = true;
			this.dataGridViewImageColumn_0.Width = 24;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "Id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "Номер распоряжения";
			this.dataGridViewTextBoxColumn_0.Name = "numDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Width = 85;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "DateAppl";
			this.dataGridViewTextBoxColumn_1.HeaderText = "Дата распоряжения";
			this.dataGridViewTextBoxColumn_1.Name = "dateApplDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Width = 110;
			this.dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "NetAreaCaption";
			this.dataGridViewTextBoxColumn_2.HeaderText = "Сетевой район/ОДС ";
			this.dataGridViewTextBoxColumn_2.Name = "netAreaCaptionDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "TypeActionCaption";
			this.dataGridViewTextBoxColumn_3.HeaderText = "Вид заявки";
			this.dataGridViewTextBoxColumn_3.Name = "typeActionCaptionDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "DateAction";
			this.dataGridViewTextBoxColumn_4.HeaderText = "Дата и время выполнения";
			this.dataGridViewTextBoxColumn_4.Name = "dateActionDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.Width = 110;
			this.bindingSource_0.DataMember = "tblAbnAplForDiscon";
			this.bindingSource_0.DataSource = this.class548_0;
			this.class548_0.DataSetName = "OrgDataSet";
			this.class548_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_3,
				this.toolStripButton_4,
				this.toolStripButton_5,
				this.toolStripButton_6
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStripEditTheList";
			this.toolStrip_0.Size = new Size(589, 25);
			this.toolStrip_0.TabIndex = 1;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = Resources.filter;
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolStripButton1";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Фильтр";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = Resources.Find;
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolStripButtonOpenSearchForm";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Открыть окно поиска";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = Resources.filter_delete;
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolStripButton2";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "Сброс фильтра и поиска";
			this.toolStripButton_5.Click += this.toolStripButton_5_Click;
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = Resources.Setting;
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "toolStripButton3";
			this.toolStripButton_6.Size = new Size(23, 22);
			this.toolStripButton_6.Text = "Настройки";
			this.toolStripButton_6.Click += this.toolStripButton_6_Click;
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripButton_2,
				this.toolStripButton_1
			});
			this.toolStrip_1.Location = new Point(0, 25);
			this.toolStrip_1.Name = "toolStripEditTheRecord";
			this.toolStrip_1.Size = new Size(589, 25);
			this.toolStrip_1.TabIndex = 2;
			this.toolStrip_1.Text = "toolStrip2";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.legal_add;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolStripButtonAddLegal";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Добавить заявление на юридические лица";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.individual_add;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolStripButtonAddindIvidual";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Добавить заявление на физические лица";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.ButtonEdit;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolStripButtonEdit";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Редактировать";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.class585_0.Boolean_0 = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(589, 474);
			base.Controls.Add(this.toolStrip_1);
			base.Controls.Add(this.toolStrip_0);
			base.Controls.Add(this.dataGridView_0);
			base.Name = "FormList";
			this.Text = "Список заявлений";
			base.Load += this.FormList_Load;
			((ISupportInitialize)this.dataGridView_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.class548_0).EndInit();
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private FormFilter formFilter_0;

		private List<string> list_0;

		private DataGridView dataGridView_0;

		private ToolStrip toolStrip_0;

		private ToolStrip toolStrip_1;

		private Class548 class548_0;

		private BindingSource bindingSource_0;

		private Class585 class585_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripButton toolStripButton_3;

		private DataGridViewImageColumn dataGridViewImageColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private ToolStripButton toolStripButton_4;

		private ToolStripButton toolStripButton_5;

		private ToolStripButton toolStripButton_6;
	}
}
