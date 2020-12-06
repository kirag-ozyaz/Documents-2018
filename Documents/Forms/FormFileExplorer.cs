using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using FormLbr;

namespace Documents.Forms
{
	public partial class FormFileExplorer : FormBase
	{
		public FormFileExplorer()
		{
			
			this.dataTable_0 = new DataTable();
			this.dataTable_1 = new DataTable();
			
			this.method_3();
		}

		private void FormFileExplorer_Load(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void treeView_0_AfterSelect(object sender, TreeViewEventArgs e)
		{
		}

		private void method_0()
		{
			SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString());
			SqlCommand sqlCommand = new SqlCommand("SELECT [id]\r\n                                                        ,[idparent]\r\n                                                        ,[level]\r\n                                                        ,[name]\r\n                                                        ,[path]\r\n                                                    FROM [vDoc_GetDirectoryFromFileSystem]\r\n                                                    order by [path]", sqlConnection);
			try
			{
				sqlConnection.Open();
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				this.dataTable_0.Load(sqlDataReader);
				sqlDataReader.Close();
			}
			catch
			{
			}
			finally
			{
				sqlConnection.Close();
			}
			TreeNode treeNode = null;
			foreach (object obj in this.dataTable_0.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				Class8 @class = new Class8(Convert.ToInt32(dataRow["id"]), Convert.ToInt32((dataRow["idparent"] == DBNull.Value) ? 0 : dataRow["idparent"]), Convert.ToInt32(dataRow["level"]), dataRow["name"].ToString(), dataRow["path"].ToString());
				TreeNode treeNode2 = new TreeNode(@class.Name);
				treeNode2.Tag = @class;
				if (@class.method_2() == 0)
				{
					this.treeView_0.Nodes.Add(treeNode2);
				}
				else if (treeNode.Level < @class.method_2())
				{
					treeNode.Nodes.Add(treeNode2);
				}
				else
				{
					while (treeNode.Level >= @class.method_2())
					{
						treeNode = treeNode.Parent;
					}
					treeNode.Nodes.Add(treeNode2);
				}
				treeNode = treeNode2;
			}
		}

		private void method_1(Class8 class8_0)
		{
			int id = class8_0.Id;
			SqlConnection sqlConnection = new SqlConnection(this.SqlSettings.GetConnectionString());
			SqlCommand sqlCommand = new SqlCommand("SELECT [id]\r\n                                                        ,[idParent]\r\n                                                        ,[Name]\r\n                                                        ,[Comment]\r\n                                                        ,[idOwner]\r\n                                                        ,[DateIn]\r\n                                                    FROM tDoc_FileSystem\r\n                                                    where idParent = " + id + " and isdirectory = 0", sqlConnection);
			try
			{
				sqlConnection.Open();
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				this.dataTable_1.Load(sqlDataReader);
				sqlDataReader.Close();
			}
			catch
			{
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		private string method_2(Class9 class9_0)
		{
			SqlConnection connection = new SqlConnection(this.SqlSettings.GetConnectionString());
			new SqlCommand("SELECT [id]                                                        \r\n                                                        ,[Name]\r\n                                                        ,[Data]\r\n                                                    FROM tDoc_FileSystem\r\n                                                    where isdirectory = 0", connection);
			return string.Empty;
		}

		private void method_3()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormFileExplorer));
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			this.splitContainer_0 = new SplitContainer();
			this.treeView_0 = new TreeView();
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripButton_3 = new ToolStripButton();
			this.splitContainer_1 = new SplitContainer();
			this.textBox_0 = new TextBox();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.dataGridView_0 = new DataGridView();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
			this.dataGridViewLinkColumn_0 = new DataGridViewLinkColumn();
			this.touWgUyaMV = new DataSet();
			this.dataTable_2 = new DataTable();
			this.dataColumn_0 = new DataColumn();
			this.dataColumn_1 = new DataColumn();
			this.dataColumn_2 = new DataColumn();
			this.dataColumn_3 = new DataColumn();
			this.dataColumn_4 = new DataColumn();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			this.toolStrip_1.SuspendLayout();
			this.splitContainer_1.Panel1.SuspendLayout();
			this.splitContainer_1.Panel2.SuspendLayout();
			this.splitContainer_1.SuspendLayout();
			this.toolStrip_0.SuspendLayout();
			((ISupportInitialize)this.dataGridView_0).BeginInit();
			((ISupportInitialize)this.touWgUyaMV).BeginInit();
			((ISupportInitialize)this.dataTable_2).BeginInit();
			base.SuspendLayout();
			this.splitContainer_0.Dock = DockStyle.Fill;
			this.splitContainer_0.Location = new Point(0, 0);
			this.splitContainer_0.Name = "splitContainer1";
			this.splitContainer_0.Panel1.Controls.Add(this.treeView_0);
			this.splitContainer_0.Panel1.Controls.Add(this.toolStrip_1);
			this.splitContainer_0.Panel2.Controls.Add(this.splitContainer_1);
			this.splitContainer_0.Panel2.Controls.Add(this.toolStrip_0);
			this.splitContainer_0.Size = new Size(426, 377);
			this.splitContainer_0.SplitterDistance = 142;
			this.splitContainer_0.TabIndex = 0;
			this.treeView_0.Dock = DockStyle.Fill;
			this.treeView_0.Location = new Point(0, 25);
			this.treeView_0.Name = "treeView1";
			this.treeView_0.Size = new Size(142, 352);
			this.treeView_0.TabIndex = 0;
			this.treeView_0.AfterSelect += this.treeView_0_AfterSelect;
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_2,
				this.toolStripButton_3
			});
			this.toolStrip_1.Location = new Point(0, 0);
			this.toolStrip_1.Name = "toolStrip2";
			this.toolStrip_1.Size = new Size(142, 25);
			this.toolStrip_1.TabIndex = 1;
			this.toolStrip_1.Text = "toolStrip2";
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = (Image)componentResourceManager.GetObject("toolStripButton3.Image");
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolStripButton3";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "toolStripButton1";
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = (Image)componentResourceManager.GetObject("toolStripButton4.Image");
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolStripButton4";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "toolStripButton2";
			this.splitContainer_1.Dock = DockStyle.Fill;
			this.splitContainer_1.Location = new Point(0, 25);
			this.splitContainer_1.Name = "splitContainer2";
			this.splitContainer_1.Orientation = Orientation.Horizontal;
			this.splitContainer_1.Panel1.Controls.Add(this.dataGridView_0);
			this.splitContainer_1.Panel2.Controls.Add(this.textBox_0);
			this.splitContainer_1.Size = new Size(280, 352);
			this.splitContainer_1.SplitterDistance = 263;
			this.splitContainer_1.TabIndex = 1;
			this.textBox_0.Dock = DockStyle.Fill;
			this.textBox_0.Location = new Point(0, 0);
			this.textBox_0.Multiline = true;
			this.textBox_0.Name = "textBox1";
			this.textBox_0.Size = new Size(280, 85);
			this.textBox_0.TabIndex = 0;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripButton_1
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStrip1";
			this.toolStrip_0.Size = new Size(280, 25);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("toolStripButton1.Image");
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolStripButton1";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "toolStripButton1";
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("toolStripButton2.Image");
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolStripButton2";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "toolStripButton2";
			this.dataGridView_0.AllowUserToAddRows = false;
			this.dataGridView_0.AllowUserToDeleteRows = false;
			this.dataGridView_0.AllowUserToResizeColumns = false;
			this.dataGridView_0.AllowUserToResizeRows = false;
			this.dataGridView_0.BackgroundColor = Color.White;
			this.dataGridView_0.BorderStyle = BorderStyle.None;
			this.dataGridView_0.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = SystemColors.Control;
			dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dataGridView_0.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_0.ColumnHeadersVisible = false;
			this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewImageColumnNotNull_0,
				this.dataGridViewLinkColumn_0
			});
			this.dataGridView_0.DataMember = "tJ_RequestDoc";
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			this.dataGridView_0.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView_0.Dock = DockStyle.Fill;
			this.dataGridView_0.GridColor = SystemColors.Control;
			this.dataGridView_0.Location = new Point(0, 0);
			this.dataGridView_0.MultiSelect = false;
			this.dataGridView_0.Name = "dgvDocs";
			this.dataGridView_0.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Control;
			dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
			dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dataGridView_0.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView_0.RowHeadersVisible = false;
			this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_0.Size = new Size(280, 263);
			this.dataGridView_0.TabIndex = 16;
			this.dataGridView_0.VirtualMode = true;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "Id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "Id";
			this.dataGridViewTextBoxColumn_0.Name = "IdDocDgvTxtColumn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Visible = false;
			dataGridViewCellStyle4.NullValue = null;
			this.dataGridViewImageColumnNotNull_0.DefaultCellStyle = dataGridViewCellStyle4;
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
			this.touWgUyaMV.DataSetName = "NewDataSet";
			this.touWgUyaMV.Tables.AddRange(new DataTable[]
			{
				this.dataTable_2
			});
			this.dataTable_2.Columns.AddRange(new DataColumn[]
			{
				this.dataColumn_0,
				this.dataColumn_1,
				this.dataColumn_2,
				this.dataColumn_3,
				this.dataColumn_4
			});
			this.dataTable_2.TableName = "Table1";
			this.dataColumn_0.AllowDBNull = false;
			this.dataColumn_0.AutoIncrement = true;
			this.dataColumn_0.ColumnName = "id";
			this.dataColumn_0.DataType = typeof(int);
			this.dataColumn_1.AllowDBNull = false;
			this.dataColumn_1.ColumnName = "Name";
			this.dataColumn_2.ColumnName = "Data";
			this.dataColumn_2.DataType = typeof(byte[]);
			this.dataColumn_3.ColumnName = "Comment";
			this.dataColumn_4.ColumnName = "Column1";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(426, 377);
			base.Controls.Add(this.splitContainer_0);
			base.Name = "FormFileExplorer";
			this.Text = "FormFileExplorer";
			base.Load += this.FormFileExplorer_Load;
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.Panel2.PerformLayout();
			this.splitContainer_0.ResumeLayout(false);
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			this.splitContainer_1.Panel1.ResumeLayout(false);
			this.splitContainer_1.Panel2.ResumeLayout(false);
			this.splitContainer_1.Panel2.PerformLayout();
			this.splitContainer_1.ResumeLayout(false);
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			((ISupportInitialize)this.dataGridView_0).EndInit();
			((ISupportInitialize)this.touWgUyaMV).EndInit();
			((ISupportInitialize)this.dataTable_2).EndInit();
			base.ResumeLayout(false);
		}

		private DataTable dataTable_0;

		private DataTable dataTable_1;

		private SplitContainer splitContainer_0;

		private TreeView treeView_0;

		private SplitContainer splitContainer_1;

		private TextBox textBox_0;

		private ToolStrip toolStrip_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStrip toolStrip_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripButton toolStripButton_3;

		private DataGridView dataGridView_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

		private DataGridViewLinkColumn dataGridViewLinkColumn_0;

		private DataSet touWgUyaMV;

		private DataTable dataTable_2;

		private DataColumn dataColumn_0;

		private DataColumn dataColumn_1;

		private DataColumn dataColumn_2;

		private DataColumn dataColumn_3;

		private DataColumn dataColumn_4;
	}
}
