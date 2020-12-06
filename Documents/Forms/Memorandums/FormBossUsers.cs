using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Constants;
using Documents.Properties;
using FormLbr;

namespace Documents.Forms.Memorandums
{
	public partial class FormBossUsers : FormBase
	{
		public FormBossUsers()
		{
			
			
			this.method_12();
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			Form34 form = new Form34();
			form.SqlSettings = this.SqlSettings;
			form.MdiParent = base.MdiParent;
			form.method_1(StateFormCreate.Add);
			form.IdParent = ((this.treeView_0.SelectedNode != null) ? ((int)this.treeView_0.SelectedNode.Tag) : -1);
			form.FormClosed += this.method_0;
			form.Show();
		}

		private void method_0(object sender, FormClosedEventArgs e)
		{
			Form34 form = (Form34)sender;
			this.cepokIvstOR(form.Id);
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			if (this.treeView_0.SelectedNode != null)
			{
				Form34 form = new Form34();
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.method_1(StateFormCreate.Edit);
				form.Id = (int)this.treeView_0.SelectedNode.Tag;
				form.FormClosed += this.method_0;
				form.Show();
			}
		}

		private void toolStripButton_5_Click(object sender, EventArgs e)
		{
			if (this.treeView_0.SelectedNode != null && MessageBox.Show("Вы действительно хотите удалить группу пользавателей?", "Удаление.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (this.dataGridView_0.Rows.Count > 0)
				{
					MessageBox.Show("Удаление невозможно! Группа не пуста!", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				Class255.Class459 @class = this.class255_0.tJ_BossUserGroup.Where(new Func<Class255.Class459, bool>(this.method_13)).First<Class255.Class459>();
				@class.Deleted = true;
				@class.EndEdit();
				if (base.UpdateSqlData(this.class255_0, this.class255_0.tJ_BossUserGroup))
				{
					MessageBox.Show("Группа успешно удалена.");
				}
				this.method_2();
			}
		}

		private void toolStripButton_7_Click(object sender, EventArgs e)
		{
			this.method_1();
		}

		private void method_1()
		{
			base.SelectSqlData(this.class255_0, this.class255_0.tJ_BossUserGroup, true, "WHERE Deleted = 0");
			this.method_2();
		}

		private void cepokIvstOR(int int_0)
		{
			base.SelectSqlData(this.class255_0, this.class255_0.tJ_BossUserGroup, true, "WHERE Deleted = 0");
			this.method_3(int_0);
		}

		private void method_2()
		{
			this.method_3((this.treeView_0.SelectedNode != null) ? ((int)this.treeView_0.SelectedNode.Tag) : -1);
		}

		private void method_3(int int_0)
		{
			this.list_0 = this.method_7(this.treeView_0.Nodes, this.list_0);
			this.treeView_0.Nodes.Clear();
			this.treeView_0.BeginUpdate();
			foreach (Class255.Class459 @class in from row in this.class255_0.tJ_BossUserGroup
			where row["idParent"] == DBNull.Value
			select row)
			{
				TreeNode treeNode = new TreeNode(@class.Name);
				treeNode.Tag = @class.id;
				this.method_6(treeNode);
				this.treeView_0.Nodes.Add(treeNode);
			}
			this.method_8(this.treeView_0.Nodes, this.list_0);
			if (int_0 != -1)
			{
				List<TreeNode> list_ = new List<TreeNode>();
				list_ = this.method_4(this.treeView_0.Nodes, list_);
				this.treeView_0.SelectedNode = this.method_5(list_, int_0);
			}
			this.treeView_0.EndUpdate();
		}

		private List<TreeNode> method_4(TreeNodeCollection treeNodeCollection_0, List<TreeNode> list_1)
		{
			if (list_1 == null)
			{
				list_1 = new List<TreeNode>();
			}
			foreach (object obj in treeNodeCollection_0)
			{
				TreeNode treeNode = (TreeNode)obj;
				list_1.Add(treeNode);
				list_1 = this.method_4(treeNode.Nodes, list_1);
			}
			return list_1;
		}

		private TreeNode method_5(List<TreeNode> list_1, int int_0)
		{
			foreach (TreeNode treeNode in list_1)
			{
				if ((int)treeNode.Tag == int_0)
				{
					return treeNode;
				}
			}
			return null;
		}

		private void method_6(TreeNode treeNode_0)
		{
			foreach (Class255.Class459 @class in from row in this.class255_0.tJ_BossUserGroup
			where row["idParent"] != DBNull.Value && row.idParent == (int)treeNode_0.Tag
			select row)
			{
				TreeNode treeNode = new TreeNode(@class.Name);
				treeNode.Tag = @class.id;
				this.method_6(treeNode);
				treeNode_0.Nodes.Add(treeNode);
			}
		}

		private List<int> method_7(TreeNodeCollection treeNodeCollection_0, List<int> list_1)
		{
			if (list_1 == null)
			{
				list_1 = new List<int>();
			}
			foreach (object obj in treeNodeCollection_0)
			{
				TreeNode treeNode = (TreeNode)obj;
				if (treeNode.IsExpanded)
				{
					list_1.Add((int)treeNode.Tag);
				}
				list_1 = this.method_7(treeNode.Nodes, list_1);
			}
			return list_1;
		}

		private void method_8(TreeNodeCollection treeNodeCollection_0, List<int> list_1)
		{
			foreach (object obj in treeNodeCollection_0)
			{
				TreeNode treeNode = (TreeNode)obj;
				if (list_1.Contains((int)treeNode.Tag))
				{
					treeNode.Expand();
				}
				this.method_8(treeNode.Nodes, list_1);
			}
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			if (this.treeView_0.SelectedNode != null)
			{
				Form33 form = new Form33();
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.method_3(StateFormCreate.Add);
				form.method_1((int)this.treeView_0.SelectedNode.Tag);
				form.FormClosed += this.method_9;
				form.Show();
			}
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_0.SelectedRows != null && this.dataGridView_0.SelectedRows.Count != 0)
			{
				Form33 form = new Form33();
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.method_3(StateFormCreate.Edit);
				form.Id = (int)this.dataGridView_0.SelectedRows[0].Cells["idDataGridViewTextBoxColumn"].Value;
				form.FormClosed += this.method_9;
				form.Show();
			}
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_0.SelectedRows != null && this.dataGridView_0.SelectedRows.Count != 0 && MessageBox.Show("Вы действительно хотите удалить пользавателя?", "Удаление.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Class255.Class466 @class = this.class255_0.tJ_BossUser.Where(new Func<Class255.Class466, bool>(this.method_14)).First<Class255.Class466>();
				@class.Deleted = true;
				@class.EndEdit();
				if (base.UpdateSqlData(this.class255_0, this.class255_0.tJ_BossUser))
				{
					MessageBox.Show("Пользователь успешно удален.");
					this.method_10((int)this.treeView_0.SelectedNode.Tag);
				}
			}
		}

		private void toolStripButton_6_Click(object sender, EventArgs e)
		{
			this.method_10((int)this.treeView_0.SelectedNode.Tag);
		}

		private void method_9(object sender, FormClosedEventArgs e)
		{
			Form33 form = (Form33)sender;
			this.method_11((int)this.treeView_0.SelectedNode.Tag, form.Id);
		}

		private void method_10(int int_0)
		{
			base.SelectSqlData(this.class255_0, this.class255_0.tJ_BossUser, true, "WHERE idGroup = " + int_0.ToString() + " AND Deleted = 0");
		}

		private void method_11(int int_0, int int_1)
		{
			base.SelectSqlData(this.class255_0, this.class255_0.tJ_BossUser, true, "WHERE idGroup = " + int_0.ToString() + " AND Deleted = 0");
			this.eQnoFyxkwo2.Position = this.eQnoFyxkwo2.Find("id", int_1);
		}

		private void treeView_0_AfterSelect(object sender, TreeViewEventArgs e)
		{
			this.method_10((int)this.treeView_0.SelectedNode.Tag);
		}

		private void FormBossUsers_Load(object sender, EventArgs e)
		{
			this.method_1();
		}

		private void dataGridView_0_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
			{
				this.toolStripButton_1_Click(this.toolStripButton_4, e);
			}
		}

		private void toolStripButton_8_Click(object sender, EventArgs e)
		{
			if (this.dataGridView_0.SelectedRows != null && this.dataGridView_0.SelectedRows.Count != 0)
			{
				Form33 form = new Form33();
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.method_3(StateFormCreate.View);
				form.Id = (int)this.dataGridView_0.SelectedRows[0].Cells["idDataGridViewTextBoxColumn"].Value;
				form.Show();
			}
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void method_12()
		{
			this.icontainer_0 = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormBossUsers));
			this.tableLayoutPanel_0 = new TableLayoutPanel();
			this.dataGridView_0 = new DataGridView();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
			this.contextMenuStrip_1 = new ContextMenuStrip(this.icontainer_0);
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripMenuItem_1 = new ToolStripMenuItem();
			this.toolStripMenuItem_2 = new ToolStripMenuItem();
			this.toolStripSeparator_4 = new ToolStripSeparator();
			this.toolStripMenuItem_3 = new ToolStripMenuItem();
			this.toolStripSeparator_5 = new ToolStripSeparator();
			this.toolStripMenuItem_4 = new ToolStripMenuItem();
			this.eQnoFyxkwo2 = new BindingSource(this.icontainer_0);
			this.class255_0 = new Class255();
			this.treeView_0 = new TreeView();
			this.contextMenuStrip_0 = new ContextMenuStrip(this.icontainer_0);
			this.yAmoFtYiBm0 = new ToolStripMenuItem();
			this.toolStripMenuItem_5 = new ToolStripMenuItem();
			this.toolStripSeparator_6 = new ToolStripSeparator();
			this.toolStripMenuItem_6 = new ToolStripMenuItem();
			this.toolStripSeparator_7 = new ToolStripSeparator();
			this.toolStripMenuItem_7 = new ToolStripMenuItem();
			this.button_0 = new Button();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripButton_8 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_6 = new ToolStripButton();
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripButton_4 = new ToolStripButton();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripSeparator_3 = new ToolStripSeparator();
			this.toolStripButton_7 = new ToolStripButton();
			this.tableLayoutPanel_0.SuspendLayout();
			((ISupportInitialize)this.dataGridView_0).BeginInit();
			this.contextMenuStrip_1.SuspendLayout();
			((ISupportInitialize)this.eQnoFyxkwo2).BeginInit();
			((ISupportInitialize)this.class255_0).BeginInit();
			this.contextMenuStrip_0.SuspendLayout();
			this.toolStrip_0.SuspendLayout();
			this.toolStrip_1.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel_0.ColumnCount = 3;
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.71533f));
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.28467f));
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 102f));
			this.tableLayoutPanel_0.Controls.Add(this.dataGridView_0, 1, 1);
			this.tableLayoutPanel_0.Controls.Add(this.treeView_0, 0, 1);
			this.tableLayoutPanel_0.Controls.Add(this.button_0, 2, 2);
			this.tableLayoutPanel_0.Controls.Add(this.toolStrip_0, 1, 0);
			this.tableLayoutPanel_0.Controls.Add(this.toolStrip_1, 0, 0);
			this.tableLayoutPanel_0.Dock = DockStyle.Fill;
			this.tableLayoutPanel_0.Location = new Point(0, 0);
			this.tableLayoutPanel_0.Name = "tlpGeneral";
			this.tableLayoutPanel_0.RowCount = 3;
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 39f));
			this.tableLayoutPanel_0.Size = new Size(522, 400);
			this.tableLayoutPanel_0.TabIndex = 0;
			this.dataGridView_0.AllowUserToAddRows = false;
			this.dataGridView_0.AllowUserToDeleteRows = false;
			this.dataGridView_0.AllowUserToOrderColumns = true;
			this.dataGridView_0.AutoGenerateColumns = false;
			this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_3,
				this.dataGridViewTextBoxColumn_4,
				this.dataGridViewTextBoxColumn_5,
				this.dataGridViewCheckBoxColumn_0,
				this.dataGridViewTextBoxColumn_6
			});
			this.tableLayoutPanel_0.SetColumnSpan(this.dataGridView_0, 2);
			this.dataGridView_0.ContextMenuStrip = this.contextMenuStrip_1;
			this.dataGridView_0.DataSource = this.eQnoFyxkwo2;
			this.dataGridView_0.Dock = DockStyle.Fill;
			this.dataGridView_0.Location = new Point(199, 25);
			this.dataGridView_0.Name = "dgvUser";
			this.dataGridView_0.ReadOnly = true;
			this.dataGridView_0.RowHeadersVisible = false;
			this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_0.Size = new Size(320, 333);
			this.dataGridView_0.TabIndex = 1;
			this.dataGridView_0.CellMouseDoubleClick += this.dataGridView_0_CellMouseDoubleClick;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "idDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "idGroup";
			this.dataGridViewTextBoxColumn_1.HeaderText = "idGroup";
			this.dataGridViewTextBoxColumn_1.Name = "idGroupDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "FirstName";
			this.dataGridViewTextBoxColumn_2.HeaderText = "Фамилия";
			this.dataGridViewTextBoxColumn_2.Name = "firstNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "LastName";
			this.dataGridViewTextBoxColumn_3.HeaderText = "Имя";
			this.dataGridViewTextBoxColumn_3.Name = "lastNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "MiddleInitial";
			this.dataGridViewTextBoxColumn_4.HeaderText = "Отчество";
			this.dataGridViewTextBoxColumn_4.Name = "middleInitialDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "Password";
			this.dataGridViewTextBoxColumn_5.HeaderText = "Password";
			this.dataGridViewTextBoxColumn_5.Name = "passwordDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewTextBoxColumn_5.Visible = false;
			this.dataGridViewCheckBoxColumn_0.DataPropertyName = "Deleted";
			this.dataGridViewCheckBoxColumn_0.HeaderText = "Deleted";
			this.dataGridViewCheckBoxColumn_0.Name = "deletedDataGridViewCheckBoxColumn";
			this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "BossUNID";
			this.dataGridViewTextBoxColumn_6.HeaderText = "BossUNID";
			this.dataGridViewTextBoxColumn_6.Name = "bossUNIDDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewTextBoxColumn_6.Visible = false;
			this.contextMenuStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_0,
				this.toolStripMenuItem_1,
				this.toolStripMenuItem_2,
				this.toolStripSeparator_4,
				this.toolStripMenuItem_3,
				this.toolStripSeparator_5,
				this.toolStripMenuItem_4
			});
			this.contextMenuStrip_1.Name = "cmsUser";
			this.contextMenuStrip_1.Size = new Size(155, 126);
			this.toolStripMenuItem_0.Image = Resources.ElementAdd;
			this.toolStripMenuItem_0.Name = "tsmiAddUser";
			this.toolStripMenuItem_0.Size = new Size(154, 22);
			this.toolStripMenuItem_0.Text = "Добавить";
			this.toolStripMenuItem_0.Click += this.toolStripButton_0_Click;
			this.toolStripMenuItem_1.Image = Resources.ElementEdit;
			this.toolStripMenuItem_1.Name = "tsmiEditUser";
			this.toolStripMenuItem_1.Size = new Size(154, 22);
			this.toolStripMenuItem_1.Text = "Редактировать";
			this.toolStripMenuItem_1.Click += this.toolStripButton_1_Click;
			this.toolStripMenuItem_2.Image = Resources.ElementInformation;
			this.toolStripMenuItem_2.Name = "tsmiViewUser";
			this.toolStripMenuItem_2.Size = new Size(154, 22);
			this.toolStripMenuItem_2.Text = "Просмотр";
			this.toolStripMenuItem_2.Click += this.toolStripButton_8_Click;
			this.toolStripSeparator_4.Name = "toolStripSeparator7";
			this.toolStripSeparator_4.Size = new Size(151, 6);
			this.toolStripMenuItem_3.Image = Resources.ElementDel;
			this.toolStripMenuItem_3.Name = "tsmiDeleteUser";
			this.toolStripMenuItem_3.Size = new Size(154, 22);
			this.toolStripMenuItem_3.Text = "Удалить";
			this.toolStripMenuItem_3.Click += this.toolStripButton_2_Click;
			this.toolStripSeparator_5.Name = "toolStripSeparator8";
			this.toolStripSeparator_5.Size = new Size(151, 6);
			this.toolStripMenuItem_4.Image = Resources.refresh_16;
			this.toolStripMenuItem_4.Name = "tsmiRefreshUser";
			this.toolStripMenuItem_4.Size = new Size(154, 22);
			this.toolStripMenuItem_4.Text = "Обновить";
			this.toolStripMenuItem_4.Click += this.toolStripButton_6_Click;
			this.eQnoFyxkwo2.DataMember = "tJ_BossUser";
			this.eQnoFyxkwo2.DataSource = this.class255_0;
			this.class255_0.DataSetName = "DataSetGES";
			this.class255_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.treeView_0.ContextMenuStrip = this.contextMenuStrip_0;
			this.treeView_0.Dock = DockStyle.Fill;
			this.treeView_0.Location = new Point(3, 25);
			this.treeView_0.Name = "trvGroup";
			this.treeView_0.Size = new Size(190, 333);
			this.treeView_0.TabIndex = 0;
			this.treeView_0.AfterSelect += this.treeView_0_AfterSelect;
			this.contextMenuStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.yAmoFtYiBm0,
				this.toolStripMenuItem_5,
				this.toolStripSeparator_6,
				this.toolStripMenuItem_6,
				this.toolStripSeparator_7,
				this.toolStripMenuItem_7
			});
			this.contextMenuStrip_0.Name = "cmsGroup";
			this.contextMenuStrip_0.Size = new Size(155, 104);
			this.yAmoFtYiBm0.Image = Resources._1353328228_folder_add;
			this.yAmoFtYiBm0.Name = "tsmiAddGroup";
			this.yAmoFtYiBm0.Size = new Size(154, 22);
			this.yAmoFtYiBm0.Text = "Добавить";
			this.yAmoFtYiBm0.Click += this.toolStripButton_3_Click;
			this.toolStripMenuItem_5.Image = Resources.FolderEditYellow;
			this.toolStripMenuItem_5.Name = "tsmiEditGroup";
			this.toolStripMenuItem_5.Size = new Size(154, 22);
			this.toolStripMenuItem_5.Text = "Редактировать";
			this.toolStripMenuItem_5.Click += this.toolStripButton_4_Click;
			this.toolStripSeparator_6.Name = "toolStripSeparator5";
			this.toolStripSeparator_6.Size = new Size(151, 6);
			this.toolStripMenuItem_6.Image = Resources._1353328250_folder_open_delete;
			this.toolStripMenuItem_6.Name = "tsmiDeleteGroup";
			this.toolStripMenuItem_6.Size = new Size(154, 22);
			this.toolStripMenuItem_6.Text = "Удалить";
			this.toolStripMenuItem_6.Click += this.toolStripButton_5_Click;
			this.toolStripSeparator_7.Name = "toolStripSeparator6";
			this.toolStripSeparator_7.Size = new Size(151, 6);
			this.toolStripMenuItem_7.Image = Resources.refresh_16;
			this.toolStripMenuItem_7.Name = "tsmiRefreshGroup";
			this.toolStripMenuItem_7.Size = new Size(154, 22);
			this.toolStripMenuItem_7.Text = "Обновить";
			this.toolStripMenuItem_7.Click += this.toolStripButton_7_Click;
			this.button_0.Location = new Point(422, 369);
			this.button_0.Margin = new Padding(3, 8, 3, 3);
			this.button_0.Name = "btnClose";
			this.button_0.Size = new Size(75, 23);
			this.button_0.TabIndex = 2;
			this.button_0.Text = "Закрыть";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += this.button_0_Click;
			this.tableLayoutPanel_0.SetColumnSpan(this.toolStrip_0, 2);
			this.toolStrip_0.Dock = DockStyle.Fill;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripButton_1,
				this.toolStripButton_8,
				this.toolStripSeparator_0,
				this.toolStripButton_2,
				this.toolStripSeparator_1,
				this.toolStripButton_6
			});
			this.toolStrip_0.Location = new Point(196, 0);
			this.toolStrip_0.Name = "tsUser";
			this.toolStrip_0.Size = new Size(326, 22);
			this.toolStrip_0.TabIndex = 3;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("tsbAddUser.Image");
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "tsbAddUser";
			this.toolStripButton_0.Size = new Size(23, 19);
			this.toolStripButton_0.Text = "Добавить пользователя";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("tsbEditUser.Image");
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "tsbEditUser";
			this.toolStripButton_1.Size = new Size(23, 19);
			this.toolStripButton_1.Text = "Редактировать пользователя";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_8.Image = Resources.ElementInformation;
			this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_8.Name = "tsbViewUser";
			this.toolStripButton_8.Size = new Size(23, 19);
			this.toolStripButton_8.Text = "toolStripButton1";
			this.toolStripButton_8.Click += this.toolStripButton_8_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator1";
			this.toolStripSeparator_0.Size = new Size(6, 22);
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = (Image)componentResourceManager.GetObject("tsbDeleteUser.Image");
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "tsbDeleteUser";
			this.toolStripButton_2.Size = new Size(23, 19);
			this.toolStripButton_2.Text = "Удалить пользователя";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator2";
			this.toolStripSeparator_1.Size = new Size(6, 22);
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = (Image)componentResourceManager.GetObject("tsbRefreshUser.Image");
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "tsbRefreshUser";
			this.toolStripButton_6.Size = new Size(23, 19);
			this.toolStripButton_6.Text = "Обновить";
			this.toolStripButton_6.Click += this.toolStripButton_6_Click;
			this.toolStrip_1.Dock = DockStyle.Fill;
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_3,
				this.toolStripButton_4,
				this.toolStripSeparator_2,
				this.toolStripButton_5,
				this.toolStripSeparator_3,
				this.toolStripButton_7
			});
			this.toolStrip_1.Location = new Point(0, 0);
			this.toolStrip_1.Name = "tsGroup";
			this.toolStrip_1.Size = new Size(196, 22);
			this.toolStrip_1.TabIndex = 4;
			this.toolStrip_1.Text = "toolStrip2";
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = (Image)componentResourceManager.GetObject("tsbAddGroup.Image");
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "tsbAddGroup";
			this.toolStripButton_3.Size = new Size(23, 19);
			this.toolStripButton_3.Text = "Добавить группу";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = (Image)componentResourceManager.GetObject("tsbEditGroup.Image");
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "tsbEditGroup";
			this.toolStripButton_4.Size = new Size(23, 19);
			this.toolStripButton_4.Text = "Редактировать группу";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.toolStripSeparator_2.Name = "toolStripSeparator3";
			this.toolStripSeparator_2.Size = new Size(6, 22);
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = (Image)componentResourceManager.GetObject("tsbDeleteGroup.Image");
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "tsbDeleteGroup";
			this.toolStripButton_5.Size = new Size(23, 19);
			this.toolStripButton_5.Text = "Удалить группу";
			this.toolStripButton_5.Click += this.toolStripButton_5_Click;
			this.toolStripSeparator_3.Name = "toolStripSeparator4";
			this.toolStripSeparator_3.Size = new Size(6, 22);
			this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_7.Image = (Image)componentResourceManager.GetObject("tsbRefreshGroup.Image");
			this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_7.Name = "tsbRefreshGroup";
			this.toolStripButton_7.Size = new Size(23, 19);
			this.toolStripButton_7.Text = "Обновить";
			this.toolStripButton_7.Click += this.toolStripButton_7_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(522, 400);
			base.Controls.Add(this.tableLayoutPanel_0);
			base.Name = "FormBossUsers";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Пользователи \"Босс Референт\"";
			base.Load += this.FormBossUsers_Load;
			this.tableLayoutPanel_0.ResumeLayout(false);
			this.tableLayoutPanel_0.PerformLayout();
			((ISupportInitialize)this.dataGridView_0).EndInit();
			this.contextMenuStrip_1.ResumeLayout(false);
			((ISupportInitialize)this.eQnoFyxkwo2).EndInit();
			((ISupportInitialize)this.class255_0).EndInit();
			this.contextMenuStrip_0.ResumeLayout(false);
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			base.ResumeLayout(false);
		}

		[CompilerGenerated]
		private bool method_13(Class255.Class459 class459_0)
		{
			return class459_0.id == (int)this.treeView_0.SelectedNode.Tag;
		}

		[CompilerGenerated]
		private bool method_14(Class255.Class466 class466_0)
		{
			return class466_0.id == (int)this.dataGridView_0.SelectedRows[0].Cells["idDataGridViewTextBoxColumn"].Value;
		}

		internal static void ROjHxvOlfmbtgPc8sTJn(Form form_0, bool bool_0)
		{
			form_0.Dispose(bool_0);
		}

		private List<int> list_0;

		private TableLayoutPanel tableLayoutPanel_0;

		private DataGridView dataGridView_0;

		private TreeView treeView_0;

		private Button button_0;

		private ToolStrip toolStrip_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private ToolStrip toolStrip_1;

		private ToolStripButton toolStripButton_3;

		private ToolStripButton toolStripButton_4;

		private ToolStripButton toolStripButton_5;

		private ToolStripButton toolStripButton_6;

		private ToolStripButton toolStripButton_7;

		private Class255 class255_0;

		private BindingSource eQnoFyxkwo2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		private ToolStripButton toolStripButton_8;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripSeparator toolStripSeparator_3;

		private ContextMenuStrip contextMenuStrip_0;

		private ContextMenuStrip contextMenuStrip_1;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripSeparator toolStripSeparator_4;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripSeparator toolStripSeparator_5;

		private ToolStripMenuItem toolStripMenuItem_4;

		private ToolStripMenuItem yAmoFtYiBm0;

		private ToolStripMenuItem toolStripMenuItem_5;

		private ToolStripSeparator toolStripSeparator_6;

		private ToolStripMenuItem toolStripMenuItem_6;

		private ToolStripSeparator toolStripSeparator_7;

		private ToolStripMenuItem toolStripMenuItem_7;
	}
}
