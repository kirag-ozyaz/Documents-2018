using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using ControlsLbr.DataGridViewExcelFilter;
using DataSql;
using Documents.Forms.TechnologicalConnection.TU;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;
using Microsoft.Office.Interop.Excel;

namespace Documents.Forms.TechnologicalConnection
{
	public partial class FormTechConnectionRequest : FormBase
	{
		public FormTechConnectionRequest()
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			
			this.method_8();
			this.method_6();
		}

		public FormTechConnectionRequest(int id)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			
			this.method_8();
			this.method_6();
			this.int_0 = id;
		}

		private void FormTechConnectionRequest_Load(object sender, EventArgs e)
		{
			base.LoadFormConfig(null);
			int num = -1;
			if (this.int_0 > 0)
			{
				Class10.Class12 @class = new Class10.Class12();
				base.SelectSqlData(@class, true, " where id = " + this.int_0.ToString(), null, false, 0);
				if (@class.Rows.Count > 0 && @class.Rows[0]["idParent"] != DBNull.Value)
				{
					base.SelectSqlData(@class, true, " where id = " + @class.Rows[0]["idParent"].ToString(), null, false, 0);
				}
				if (@class.Rows.Count > 0)
				{
					this.int_0 = Convert.ToInt32(@class.Rows[0]["id"]);
					if (@class.Rows[0]["DateDoc"] != DBNull.Value)
					{
						DateTime dateTime = Convert.ToDateTime(@class.Rows[0]["DateDoc"]);
						this.dateTimePicker_1.Value = new DateTime(dateTime.Year, 1, 1);
						this.dateTimePicker_0.Value = new DateTime(dateTime.Year, 12, 31);
					}
					num = this.int_0;
				}
			}
			this.method_0();
			if (num != -1)
			{
				this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_38.Name, num.ToString(), false);
				if (this.dataGridViewExcelFilter_0.CurrentRow != null)
				{
					this.dataGridViewExcelFilter_0.FirstDisplayedScrollingRowIndex = this.dataGridViewExcelFilter_0.CurrentRow.Index;
				}
			}
		}

		private void FormTechConnectionRequest_Shown(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				this.dataGridViewExcelFilter_0.FirstDisplayedScrollingRowIndex = this.dataGridViewExcelFilter_0.CurrentRow.Index;
			}
		}

		private void FormTechConnectionRequest_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.SaveFormConfig(null);
		}

		private void method_0()
		{
			int num = this.int_0;
			if (this.checkBox_0.Checked)
			{
				base.SelectSqlData(this.class10_0, this.class10_0.vTC_Request, true, string.Concat(new string[]
				{
					" where (dateDoc >= '",
					this.dateTimePicker_1.Value.ToString("yyyyMMdd"),
					"' and dateDoc < '",
					this.dateTimePicker_0.Value.AddDays(1.0).ToString("yyyyMMdd"),
					"') order by dateDoc desc"
				}));
			}
			else
			{
				base.SelectSqlData(this.class10_0, this.class10_0.vTC_Request, true, string.Concat(new string[]
				{
					" where (dateDoc >= '",
					this.dateTimePicker_1.Value.ToString("yyyyMMdd"),
					"' and dateDoc < '",
					this.dateTimePicker_0.Value.AddDays(1.0).ToString("yyyyMMdd"),
					"') or dateDoc is null order by dateDoc desc"
				}));
			}
			this.dataGridViewExcelFilter_0.SearchGrid(this.dataGridViewTextBoxColumn_38.Name, num.ToString(), false);
		}

		private void dcetsmBvMy_Click(object sender, EventArgs e)
		{
			FormTechConnectionRequestAddEdit formTechConnectionRequestAddEdit = new FormTechConnectionRequestAddEdit(-1, 1113, null);
			formTechConnectionRequestAddEdit.SqlSettings = this.SqlSettings;
			formTechConnectionRequestAddEdit.MdiParent = base.MdiParent;
			formTechConnectionRequestAddEdit.FormClosed += this.method_2;
			formTechConnectionRequestAddEdit.ShowForm += this.method_1;
			formTechConnectionRequestAddEdit.Show();
		}

		private FormBase method_1(object object_0, ShowFormEventArgs showFormEventArgs_0)
		{
			return this.OnShowForm(showFormEventArgs_0);
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				FormTechConnectionRequestAddEdit formTechConnectionRequestAddEdit = new FormTechConnectionRequestAddEdit(this.int_0, 1113, null);
				formTechConnectionRequestAddEdit.ShowForm += this.method_1;
				formTechConnectionRequestAddEdit.SqlSettings = this.SqlSettings;
				formTechConnectionRequestAddEdit.MdiParent = base.MdiParent;
				formTechConnectionRequestAddEdit.FormClosed += this.method_2;
				formTechConnectionRequestAddEdit.Show();
			}
		}

		private void method_2(object sender, FormClosedEventArgs e)
		{
			if (((Form)sender).DialogResult == DialogResult.OK)
			{
				if (sender is FormTechConnectionRequestAddEdit)
				{
					this.int_0 = ((FormTechConnectionRequestAddEdit)sender).Id;
				}
				this.method_0();
			}
		}

		private void WxitAfAdMe_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущую заявку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (this.class10_0.vTC_DocOut.Rows.Count > 0 && MessageBox.Show("Удалить все выданные документы по данной заявке?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					foreach (DataRow dataRow in this.class10_0.vTC_DocOut)
					{
						base.DeleteSqlDataById(this.class10_0.tTC_Doc, Convert.ToInt32(dataRow["idDocOut"]));
					}
					this.class10_0.vTC_DocOut.Clear();
				}
				if (base.DeleteSqlDataById(this.class10_0.tTC_Doc, this.int_0))
				{
					this.dataGridViewExcelFilter_0.Rows.Remove(this.dataGridViewExcelFilter_0.CurrentRow);
					MessageBox.Show("Заявка успешно удалена");
				}
			}
		}

		private void toolStripButton_20_Click(object sender, EventArgs e)
		{
			if (this.int_0 != -1)
			{
				if (this.class10_0.vTC_RequestHistory.Rows.Count > 1 && MessageBox.Show("Все дочерние заявки тоже привяжутся к выбранной", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
				{
					return;
				}
				FormTechConnectionRequestMerge formTechConnectionRequestMerge = new FormTechConnectionRequestMerge(this.int_0);
				formTechConnectionRequestMerge.SqlSettings = this.SqlSettings;
				if (formTechConnectionRequestMerge.ShowDialog() == DialogResult.OK)
				{
					this.int_0 = formTechConnectionRequestMerge.Id;
					this.method_0();
				}
			}
		}

		private void RjsIfkeEfy(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void toolStripButton_7_Click(object sender, EventArgs e)
		{
			this.SearchInDgvRequest(DataGridViewExcelFilter.TypeFind.Begin, this.toolStripTextBox_0.Text);
		}

		private void toolStripButton_8_Click(object sender, EventArgs e)
		{
			this.SearchInDgvRequest(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_0.Text);
		}

		private void toolStripButton_9_Click(object sender, EventArgs e)
		{
			this.SearchInDgvRequest(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_0.Text);
		}

		private void toolStripTextBox_0_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && e.Modifiers == Keys.None)
			{
				this.SearchInDgvRequest(DataGridViewExcelFilter.TypeFind.Next, this.toolStripTextBox_0.Text);
			}
			if (e.KeyCode == Keys.Return && e.Modifiers == Keys.Shift)
			{
				this.SearchInDgvRequest(DataGridViewExcelFilter.TypeFind.Prev, this.toolStripTextBox_0.Text);
			}
		}

		private void toolStripButton_16_Click(object sender, EventArgs e)
		{
			this.dataGridViewExcelFilter_0.ExportToExcel();
		}

		private void method_3(DataGridView dataGridView_0)
		{
			_Application application = new ApplicationClass();
			_Workbook workbook = application.Workbooks.Add(Type.Missing);
			application.Visible = false;
			_Worksheet worksheet = (Worksheet)workbook.ActiveSheet;
			worksheet.Name = "Exported from gridview";
			int num = 1;
			for (int i = 1; i < dataGridView_0.Columns.Count; i++)
			{
				if (dataGridView_0.Columns[i].Visible)
				{
					worksheet.Cells[1, num] = dataGridView_0.Columns[i].HeaderText;
					((Range)worksheet.Cells[1, num]).Font.Bold = true;
					num++;
				}
			}
			for (int j = 0; j < dataGridView_0.Rows.Count - 1; j++)
			{
				num = 1;
				Color c = Color.White;
				if (dataGridView_0[this.dataGridViewFilterTextBoxColumn_7.Name, j].Value != null && dataGridView_0[this.dataGridViewFilterTextBoxColumn_7.Name, j].Value != DBNull.Value)
				{
					c = Color.LightGreen;
				}
				for (int k = 1; k < dataGridView_0.Columns.Count; k++)
				{
					if (dataGridView_0.Columns[k].Visible)
					{
						worksheet.Cells[j + 2, num] = dataGridView_0.Rows[j].Cells[k].Value.ToString();
						((Range)worksheet.Cells[j + 2, num]).WrapText = true;
						((Range)worksheet.Cells[j + 2, num]).Interior.Color = ColorTranslator.ToOle(c);
						num++;
					}
				}
			}
			application.Visible = true;
		}

		public void SearchInDgvRequest(DataGridViewExcelFilter.TypeFind typeFind, string textFind)
		{
			Class10.Class30 @class = new Class10.Class30();
			base.SelectSqlData(@class, true, " where idParent is not null and numIn like '%" + textFind + "%'", null, false, 0);
			int num = (typeFind == DataGridViewExcelFilter.TypeFind.Begin) ? -1 : this.dataGridViewExcelFilter_0.CurrentCell.ColumnIndex;
			int num2 = (typeFind == DataGridViewExcelFilter.TypeFind.Begin) ? 0 : this.dataGridViewExcelFilter_0.CurrentCell.RowIndex;
			int num3 = num2;
			if (textFind.Length > 0)
			{
				for (;;)
				{
					switch (typeFind)
					{
					case DataGridViewExcelFilter.TypeFind.Begin:
					case DataGridViewExcelFilter.TypeFind.Next:
						if (num >= this.dataGridViewExcelFilter_0.Columns.Count - 1)
						{
							if (num2 != num3 && @class.Select("idParent = " + this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_38.Name, num2].Value.ToString()).Length != 0)
							{
								goto IL_1C0;
							}
							num = 0;
							num2++;
							if (num2 >= this.dataGridViewExcelFilter_0.Rows.Count)
							{
								goto Block_12;
							}
						}
						else
						{
							num++;
						}
						break;
					case DataGridViewExcelFilter.TypeFind.Prev:
						if (num <= 0)
						{
							if (num2 != num3 && @class.Select("idParent = " + this.dataGridViewExcelFilter_0[this.dataGridViewTextBoxColumn_38.Name, num2].Value.ToString()).Length != 0)
							{
								goto IL_21D;
							}
							num = this.dataGridViewExcelFilter_0.Columns.Count - 1;
							num2--;
							if (num2 < 0)
							{
								goto Block_6;
							}
						}
						else
						{
							num--;
						}
						break;
					}
					if (this.dataGridViewExcelFilter_0.Columns[num].Visible && this.dataGridViewExcelFilter_0[num, num2].Value != null && this.dataGridViewExcelFilter_0[num, num2].Value.ToString().ToUpper().Contains(textFind.ToUpper()))
					{
						goto Block_9;
					}
				}
				Block_6:
				MessageBox.Show("Фраза не найдена!");
				return;
				Block_9:
				this.dataGridViewExcelFilter_0.FirstDisplayedScrollingRowIndex = num2;
				this.dataGridViewExcelFilter_0[num, num2].Selected = true;
				this.dataGridViewExcelFilter_0.CurrentCell = this.dataGridViewExcelFilter_0.Rows[num2].Cells[num];
				return;
				Block_12:
				MessageBox.Show("Фраза не найдена!");
				return;
				IL_1C0:
				this.dataGridViewExcelFilter_0.FirstDisplayedScrollingRowIndex = num2;
				this.dataGridViewExcelFilter_0[num, num2].Selected = true;
				this.dataGridViewExcelFilter_0.CurrentCell = this.dataGridViewExcelFilter_0.Rows[num2].Cells[this.dataGridViewTextBoxColumn_39.Name];
				return;
				IL_21D:
				this.dataGridViewExcelFilter_0.FirstDisplayedScrollingRowIndex = num2;
				this.dataGridViewExcelFilter_0[num, num2].Selected = true;
				this.dataGridViewExcelFilter_0.CurrentCell = this.dataGridViewExcelFilter_0.Rows[num2].Cells[this.dataGridViewTextBoxColumn_39.Name];
				return;
			}
		}

		private void toolStripButton_22_Click(object sender, EventArgs e)
		{
			new Form16
			{
				SqlSettings = this.SqlSettings,
				MdiParent = base.MdiParent
			}.Show();
		}

		private void toolStripButton_17_Click(object sender, EventArgs e)
		{
			if (this.int_0 != -1)
			{
				FormTechConnectionRequestAddEdit formTechConnectionRequestAddEdit = new FormTechConnectionRequestAddEdit(-1, 1203, new int?(this.int_0));
				formTechConnectionRequestAddEdit.SqlSettings = this.SqlSettings;
				formTechConnectionRequestAddEdit.MdiParent = base.MdiParent;
				formTechConnectionRequestAddEdit.FormClosed += this.method_2;
				formTechConnectionRequestAddEdit.ShowForm += this.method_1;
				formTechConnectionRequestAddEdit.Show();
				return;
			}
			MessageBox.Show("Не выбрана основная заявка");
		}

		private void toolStripButton_18_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_4.CurrentRow != null)
			{
				FormTechConnectionRequestAddEdit formTechConnectionRequestAddEdit = new FormTechConnectionRequestAddEdit(Convert.ToInt32(this.dataGridViewExcelFilter_4.CurrentRow.Cells[this.dataGridViewTextBoxColumn_9.Name].Value), 1113, null);
				formTechConnectionRequestAddEdit.ShowForm += this.method_1;
				formTechConnectionRequestAddEdit.SqlSettings = this.SqlSettings;
				formTechConnectionRequestAddEdit.MdiParent = base.MdiParent;
				formTechConnectionRequestAddEdit.FormClosed += this.method_2;
				formTechConnectionRequestAddEdit.Show();
			}
		}

		private void toolStripButton_19_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_4.CurrentRow != null)
			{
				if (Convert.ToInt32(this.dataGridViewExcelFilter_4.CurrentRow.Cells[this.dataGridViewTextBoxColumn_11.Name].Value) == 1113)
				{
					MessageBox.Show("Вы не можете удалить основную заявку из истории");
					return;
				}
				if (MessageBox.Show("Вы действительно хотите удалить текущую заявку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && base.DeleteSqlDataById(this.class10_0.tTC_Doc, Convert.ToInt32(this.dataGridViewExcelFilter_4.CurrentRow.Cells[this.dataGridViewTextBoxColumn_9.Name].Value)))
				{
					this.dataGridViewExcelFilter_4.Rows.Remove(this.dataGridViewExcelFilter_4.CurrentRow);
					MessageBox.Show("Заявка успешно удалена");
				}
			}
		}

		private void toolStripButton_21_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_4.CurrentRow != null)
			{
				if (Convert.ToInt32(this.dataGridViewExcelFilter_4.CurrentRow.Cells[this.dataGridViewTextBoxColumn_11.Name].Value) == 1113)
				{
					MessageBox.Show("Данная заявка уже находится в списке основных заявок");
					return;
				}
				if (MessageBox.Show("Вы действительно хотите переместить текущую заявку в основной список?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Class10 @class = new Class10();
					base.SelectSqlData(@class, @class.tTC_Doc, true, " where id = " + this.dataGridViewExcelFilter_4.CurrentRow.Cells[this.dataGridViewTextBoxColumn_9.Name].Value.ToString());
					if (@class.tTC_Doc.Rows.Count > 0)
					{
						@class.tTC_Doc.Rows[0]["TypeDoc"] = 1113;
						@class.tTC_Doc.Rows[0]["IdParent"] = DBNull.Value;
						@class.tTC_Doc.Rows[0].EndEdit();
					}
					if (base.UpdateSqlData(@class, @class.tTC_Doc))
					{
						this.int_0 = Convert.ToInt32(this.dataGridViewExcelFilter_4.CurrentRow.Cells[this.dataGridViewTextBoxColumn_9.Name].Value);
						this.method_0();
						MessageBox.Show("Заявка успешно перемещена");
					}
				}
			}
		}

		private void bindingSource_0_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bindingSource_0.Current != null)
			{
				if (this.int_0 != Convert.ToInt32(((DataRowView)this.bindingSource_0.Current)["id"]))
				{
					this.int_0 = Convert.ToInt32(((DataRowView)this.bindingSource_0.Current)["id"]);
					base.SelectSqlData(this.class10_0, this.class10_0.vTC_DocStatus, true, " where idDoc = " + this.int_0.ToString() + " order by datechange desc");
					base.SelectSqlData(this.class10_0, this.class10_0.vTC_RequestHistory, true, string.Concat(new string[]
					{
						"where id = ",
						this.int_0.ToString(),
						" or IdParent = ",
						this.int_0.ToString(),
						" order by dateDoc"
					}));
					string text = "";
					foreach (DataRow dataRow in this.class10_0.vTC_RequestHistory)
					{
						if (string.IsNullOrEmpty(text))
						{
							text = dataRow["id"].ToString();
						}
						else
						{
							text = text + "," + dataRow["id"].ToString();
						}
					}
					if (string.IsNullOrEmpty(text))
					{
						base.SelectSqlData(this.class10_0, this.class10_0.vTC_DocOut, true, " where idDoc = " + this.int_0.ToString() + " order by dateDocOut desc");
					}
					else
					{
						base.SelectSqlData(this.class10_0, this.class10_0.vTC_DocOut, true, " where idDoc in (" + text + ") order by dateDocOut desc");
					}
					string text2 = "";
					foreach (DataRow dataRow2 in this.class10_0.vTC_DocOut)
					{
						if (Convert.ToInt32(dataRow2["TypeDocOut"]) == 1123)
						{
							if (string.IsNullOrEmpty(text2))
							{
								text2 = dataRow2["idDocOut"].ToString();
							}
							else
							{
								text2 = text2 + "," + dataRow2["idDocOut"].ToString();
							}
						}
					}
					if (!string.IsNullOrEmpty(text2))
					{
						Class10.Class26 @class = new Class10.Class26();
						base.SelectSqlData(@class, true, string.Concat(new string[]
						{
							" where idDoc in (",
							text2,
							") and typeDocout = ",
							1218.ToString(),
							" order by dateDocOut desc"
						}), null, false, 0);
						foreach (object obj in @class.Rows)
						{
							DataRow row = (DataRow)obj;
							this.class10_0.vTC_DocOut.ImportRow(row);
						}
					}
					if (this.class10_0.vTC_DocOut.Select("typeDocOut = " + 1123.ToString()).Length == 0)
					{
						this.toolStripMenuItem_4.Enabled = true;
						this.toolStripMenuItem_6.Enabled = false;
						return;
					}
					this.toolStripMenuItem_4.Enabled = false;
					if (this.class10_0.vTC_DocOut.Select("typeDocOut = " + 1220.ToString()).Length != 0)
					{
						this.toolStripMenuItem_6.Enabled = false;
						return;
					}
					this.toolStripMenuItem_6.Enabled = true;
					return;
				}
			}
			else
			{
				this.int_0 = -1;
				this.class10_0.vTC_DocStatus.Clear();
				this.class10_0.vTC_DocOut.Clear();
				this.class10_0.vTC_RequestHistory.Clear();
			}
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			if (new Form14(-1, this.int_0, false)
			{
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				this.method_0();
			}
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_1.CurrentRow != null)
			{
				int int_ = Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_48.Name].Value);
				if (new Form14(int_, this.int_0, false)
				{
					SqlSettings = this.SqlSettings
				}.ShowDialog() == DialogResult.OK)
				{
					this.method_0();
					this.dataGridViewExcelFilter_1.SearchGrid(this.dataGridViewTextBoxColumn_48.Name, int_.ToString(), false);
				}
			}
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_1.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущий статус", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				int id = Convert.ToInt32(this.dataGridViewExcelFilter_1.CurrentRow.Cells[this.dataGridViewTextBoxColumn_48.Name].Value);
				if (base.DeleteSqlDataById(this.class10_0.tTC_DocStatus, id))
				{
					this.dataGridViewExcelFilter_1.Rows.Remove(this.dataGridViewExcelFilter_1.CurrentRow);
					MessageBox.Show("Статус успешно удален");
				}
			}
		}

		private void dataGridViewExcelFilter_0_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			this.dataGridViewExcelFilter_0.AutoResizeRow(e.RowIndex);
		}

		private void dataGridViewExcelFilter_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.toolStripButton_0.Enabled && this.toolStripButton_0.Visible && e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				this.toolStripButton_0_Click(sender, e);
			}
		}

		private void dataGridViewExcelFilter_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_7.Name, e.RowIndex].Value != null && this.dataGridViewExcelFilter_0[this.dataGridViewFilterTextBoxColumn_7.Name, e.RowIndex].Value != DBNull.Value)
			{
				e.CellStyle.BackColor = Color.LightGreen;
			}
		}

		private void dataGridViewExcelFilter_0_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				this.dataGridViewExcelFilter_0.CurrentCell = this.dataGridViewExcelFilter_0[e.ColumnIndex, e.RowIndex];
				this.contextMenuStrip_0.Show(Cursor.Position);
			}
		}

		private void contextMenuStrip_0_Opening(object sender, CancelEventArgs e)
		{
			this.toolStripMenuItem_0.Visible = this.dcetsmBvMy.Visible;
			this.toolStripMenuItem_0.Enabled = this.dcetsmBvMy.Enabled;
			this.toolStripMenuItem_1.Visible = this.toolStripButton_0.Visible;
			this.toolStripMenuItem_1.Enabled = this.toolStripButton_0.Enabled;
			this.toolStripMenuItem_2.Visible = this.WxitAfAdMe.Visible;
			this.toolStripMenuItem_2.Enabled = this.WxitAfAdMe.Enabled;
			this.toolStripMenuItem_3.Visible = this.toolStripButton_20.Visible;
			this.toolStripMenuItem_3.Enabled = this.toolStripButton_20.Enabled;
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			this.dcetsmBvMy_Click(sender, e);
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			this.toolStripButton_0_Click(sender, e);
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			this.WxitAfAdMe_Click(sender, e);
		}

		private void toolStripMenuItem_3_Click(object sender, EventArgs e)
		{
			this.toolStripButton_20_Click(sender, e);
		}

		private void dataGridViewExcelFilter_4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && Convert.ToInt32(this.dataGridViewExcelFilter_4[this.dataGridViewTextBoxColumn_11.Name, e.RowIndex].Value) == 1113)
			{
				e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
				e.CellStyle.BackColor = Color.LightGray;
			}
		}

		private void dataGridViewExcelFilter_4_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			this.dataGridViewExcelFilter_4.AutoResizeRow(e.RowIndex);
		}

		private void dataGridViewExcelFilter_4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.toolStripButton_0.Enabled && this.toolStripButton_0.Visible && e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				this.toolStripButton_18_Click(sender, e);
			}
		}

		private void toolStripMenuItem_4_Click(object sender, EventArgs e)
		{
			if (this.int_0 != -1)
			{
				FormTUAddEdit formTUAddEdit = new FormTUAddEdit(-1, this.int_0);
				formTUAddEdit.SqlSettings = this.SqlSettings;
				formTUAddEdit.MdiParent = base.MdiParent;
				formTUAddEdit.FormClosed += this.method_5;
				formTUAddEdit.Show();
			}
		}

		private void toolStripMenuItem_6_Click(object sender, EventArgs e)
		{
			if (this.int_0 != -1)
			{
				DataRow[] array = this.class10_0.vTC_DocOut.Select("typeDocOut = " + 1123.ToString());
				if (array.Length != 0)
				{
					int int_ = Convert.ToInt32(array[0]["idDocOut"]);
					Form20 form = new Form20(-1, this.int_0, int_);
					form.SqlSettings = this.SqlSettings;
					if (form.ShowDialog() == DialogResult.OK)
					{
						this.method_0();
						this.dataGridViewExcelFilter_2.SearchGrid(this.dataGridViewTextBoxColumn_26.Name, form.method_0().ToString(), false);
					}
				}
			}
		}

		private void toolStripMenuItem_7_Click(object sender, EventArgs e)
		{
			if (this.int_0 != -1)
			{
				Form19 form = new Form19(-1, this.int_0);
				form.SqlSettings = this.SqlSettings;
				form.MdiParent = base.MdiParent;
				form.FormClosed += this.method_4;
				form.Show();
			}
		}

		private void method_4(object sender, FormClosedEventArgs e)
		{
			int num = ((Form19)sender).method_0();
			this.method_0();
			this.dataGridViewExcelFilter_2.SearchGrid(this.dataGridViewTextBoxColumn_26.Name, num.ToString(), false);
		}

		private void method_5(object sender, FormClosedEventArgs e)
		{
			int idTU = ((FormTUAddEdit)sender).IdTU;
			this.method_0();
			this.dataGridViewExcelFilter_2.SearchGrid(this.dataGridViewTextBoxColumn_26.Name, idTU.ToString(), false);
		}

		private void toolStripMenuItem_5_Click(object sender, EventArgs e)
		{
			if (this.int_0 != -1)
			{
				FormTechConnectionDocOutAddEdit formTechConnectionDocOutAddEdit = new FormTechConnectionDocOutAddEdit(-1, this.int_0);
				formTechConnectionDocOutAddEdit.SqlSettings = this.SqlSettings;
				if (formTechConnectionDocOutAddEdit.ShowDialog() == DialogResult.OK)
				{
					this.method_0();
					this.dataGridViewExcelFilter_2.SearchGrid(this.dataGridViewTextBoxColumn_26.Name, formTechConnectionDocOutAddEdit.IdDocOut.ToString(), false);
				}
			}
		}

		private void toolStripButton_5_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_2.CurrentRow != null)
			{
				int id = Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_26.Name].Value);
				int num = Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_30.Name].Value);
				int num2 = Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_31.Name].Value);
				if (num <= 1125)
				{
					if (num == 1123)
					{
						FormTUAddEdit formTUAddEdit = new FormTUAddEdit(num2, -1);
						formTUAddEdit.SqlSettings = this.SqlSettings;
						formTUAddEdit.FormClosed += this.method_5;
						formTUAddEdit.Show();
						return;
					}
					if (num == 1125)
					{
						goto IL_18E;
					}
				}
				else
				{
					if (num == 1218)
					{
						goto IL_18E;
					}
					if (num == 1220)
					{
						Form24 form = new Form24(num2, -1, -1);
						form.SqlSettings = this.SqlSettings;
						if (form.ShowDialog() == DialogResult.OK)
						{
							this.method_0();
							this.dataGridViewExcelFilter_2.SearchGrid(this.dataGridViewTextBoxColumn_31.Name, form.method_0().ToString(), false);
							return;
						}
						return;
					}
				}
				FormTechConnectionDocOutAddEdit formTechConnectionDocOutAddEdit = new FormTechConnectionDocOutAddEdit(id, this.int_0);
				formTechConnectionDocOutAddEdit.SqlSettings = this.SqlSettings;
				if (formTechConnectionDocOutAddEdit.ShowDialog() == DialogResult.OK)
				{
					this.method_0();
					this.dataGridViewExcelFilter_2.SearchGrid(this.dataGridViewTextBoxColumn_26.Name, formTechConnectionDocOutAddEdit.IdDocOut.ToString(), false);
					return;
				}
				return;
				IL_18E:
				Form19 form2 = new Form19(num2, -1);
				form2.SqlSettings = this.SqlSettings;
				form2.FormClosed += this.method_4;
				form2.Show();
				return;
			}
		}

		private void toolStripButton_6_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_2.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущий документ", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_26.Name].Value);
				int id = Convert.ToInt32(this.dataGridViewExcelFilter_2.CurrentRow.Cells[this.dataGridViewTextBoxColumn_31.Name].Value);
				if (base.DeleteSqlDataById(this.class10_0.tTC_Doc, id))
				{
					this.dataGridViewExcelFilter_2.Rows.Remove(this.dataGridViewExcelFilter_2.CurrentRow);
					this.method_0();
					MessageBox.Show("Документ успешно удален");
				}
			}
		}

		private void dataGridViewExcelFilter_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.toolStripButton_3.Enabled && this.toolStripButton_3.Visible)
			{
				this.toolStripButton_3_Click(sender, e);
			}
		}

		private void dataGridViewExcelFilter_2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (this.toolStripButton_5.Enabled && this.toolStripButton_5.Visible)
			{
				this.toolStripButton_5_Click(sender, e);
			}
		}

		private void dataGridViewExcelFilter_2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0 && this.dataGridViewExcelFilter_2[this.dataGridViewTextBoxColumn_28.Name, e.RowIndex].Value != null && Convert.ToInt32(this.dataGridViewExcelFilter_2[this.dataGridViewTextBoxColumn_28.Name, e.RowIndex].Value) != this.int_0)
			{
				e.CellStyle.BackColor = Color.LightGray;
			}
		}

		private void method_6()
		{
			this.dateTimePicker_1.Value = new DateTime(DateTime.Now.Year, 1, 1);
			this.dateTimePicker_0.Value = new DateTime(DateTime.Now.Year, 12, 31);
		}

		private void toolStripButton_10_Click(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void toolStripButton_11_Click(object sender, EventArgs e)
		{
			this.method_6();
			this.method_0();
		}

		private void bindingSource_2_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bindingSource_2.Current != null)
			{
				this.int_1 = Convert.ToInt32(((DataRowView)this.bindingSource_2.Current)["idDocOut"]);
				this.method_7();
				return;
			}
			this.int_1 = -1;
			this.bindingSource_3.DataSource = null;
		}

		private void method_7()
		{
			Class10.Class25 @class = new Class10.Class25();
			base.SelectSqlData(@class, true, " where idDoc = " + this.int_1.ToString() + " order by dateChange desc", null, false, 0);
			this.bindingSource_3.DataSource = @class;
			this.dataGridViewTextBoxColumn_0.Visible = false;
		}

		private void toolStripButton_12_Click(object sender, EventArgs e)
		{
			if (this.int_1 != -1 && new Form14(-1, this.int_1, true)
			{
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				this.method_7();
			}
		}

		private void toolStripButton_13_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_3.CurrentRow != null && this.int_1 != -1)
			{
				int int_ = Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
				if (new Form14(int_, this.int_1, true)
				{
					SqlSettings = this.SqlSettings
				}.ShowDialog() == DialogResult.OK)
				{
					this.method_7();
					this.dataGridViewExcelFilter_3.SearchGrid(this.dataGridViewTextBoxColumn_0.Name, int_.ToString(), false);
				}
			}
		}

		private void toolStripButton_14_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_3.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущий статус", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				int id = Convert.ToInt32(this.dataGridViewExcelFilter_3.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
				if (base.DeleteSqlDataById(this.class10_0.tTC_DocStatus, id))
				{
					this.dataGridViewExcelFilter_3.Rows.Remove(this.dataGridViewExcelFilter_3.CurrentRow);
					MessageBox.Show("Статус успешно удален");
				}
			}
		}

		private void toolStripButton_15_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Class10 @class = new Class10();
				Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
				Worksheet worksheet = (Worksheet)application.Workbooks.Open(openFileDialog.FileName, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false).Sheets[1];
				for (int i = 2; i < 3317; i++)
				{
					Range range = worksheet.get_Range("A" + i.ToString(), "A" + i.ToString());
					string text = range.Text.ToString();
					string text2 = null;
					DateTime minValue = DateTime.MinValue;
					if (!string.IsNullOrEmpty(text))
					{
						int num = text.IndexOf("от");
						if (num >= 0)
						{
							text2 = text.Substring(0, num).Trim();
							if (text2.IndexOf("№") >= 0)
							{
								text2 = text2.Substring(text2.IndexOf("№") + 1).Trim();
							}
							string text3 = text.Substring(num + 2).Trim();
							if (text3.Length > 0 && text3[text3.Length - 1] == '.')
							{
								text3 = text3.Remove(text3.Length - 1);
							}
							DateTime.TryParse(text3, out minValue);
						}
						else
						{
							text2 = text;
							if (text2.IndexOf("№") >= 0)
							{
								text2 = text2.Substring(text2.IndexOf("№") + 1).Trim();
							}
						}
					}
					range = worksheet.get_Range("B" + i.ToString(), "B" + i.ToString());
					string text4 = range.Text.ToString();
					if (text4.Length > 0 && text4[text4.Length - 1] == '.')
					{
						text4 = text4.Remove(text4.Length - 1);
					}
					DateTime minValue2 = DateTime.MinValue;
					DateTime.TryParse(text4, out minValue2);
					if (!(minValue2 >= new DateTime(2013, 5, 1)))
					{
						range = worksheet.get_Range("C" + i.ToString(), "C" + i.ToString());
						string str = range.Text.ToString();
						string text5 = null;
						int? num2 = null;
						new SqlDataCommand(new SQLSettings("ulges-sql2", "ges", "WINDOWS", "", "")).SelectSqlData(@class.tAbn, true, " where Name = '" + str + "'", null, false, 0);
						if (@class.tAbn.Rows.Count > 0)
						{
							num2 = new int?(Convert.ToInt32(@class.tAbn.Rows[0]["id"]));
						}
						else
						{
							text5 = "Абонент: " + str + "\n";
						}
						range = worksheet.get_Range("D" + i.ToString(), "D" + i.ToString());
						string value = range.Text.ToString();
						range = worksheet.get_Range("E" + i.ToString(), "E" + i.ToString());
						float? num3 = null;
						float num4;
						if (float.TryParse(range.Text.ToString(), out num4))
						{
							num3 = new float?(num4);
						}
						range = worksheet.get_Range("F" + i.ToString(), "F" + i.ToString());
						int? num5 = null;
						if (float.TryParse(range.Text.ToString(), out num4))
						{
							if ((double)num4 == 0.23)
							{
								num5 = new int?(1139);
							}
							if ((double)num4 == 0.4)
							{
								num5 = new int?(1140);
							}
							if (num4 == 6f)
							{
								num5 = new int?(1144);
							}
							if (num4 == 10f)
							{
								num5 = new int?(1143);
							}
							if (num4 == 35f)
							{
								num5 = new int?(1142);
							}
							if (num4 == 110f)
							{
								num5 = new int?(1141);
							}
						}
						range = worksheet.get_Range("K" + i.ToString(), "K" + i.ToString());
						if (!string.IsNullOrEmpty(range.Text.ToString()))
						{
							if (string.IsNullOrEmpty(text5))
							{
								text5 = "Выданные документы: " + range.Text.ToString();
							}
							else
							{
								text5 = text5 + "Выданные документы: " + range.Text.ToString();
							}
						}
						DataRow dataRow = @class.tTC_Doc.NewRow();
						dataRow["TypeDoc"] = 1113;
						if (minValue2 != DateTime.MinValue)
						{
							dataRow["dateDoc"] = minValue2;
						}
						if (!string.IsNullOrEmpty(text5))
						{
							dataRow["comment"] = text5;
						}
						@class.tTC_Doc.Rows.Add(dataRow);
						int num6 = base.InsertSqlDataOneRow(@class, @class.tTC_Doc);
						@class.tTC_Doc.Clear();
						DataRow dataRow2 = @class.tTC_Request.NewRow();
						dataRow2["id"] = num6;
						if (!string.IsNullOrEmpty(text2))
						{
							dataRow2["numIn"] = text2;
						}
						if (minValue != DateTime.MinValue)
						{
							dataRow2["dateIn"] = minValue;
						}
						if (num2 != null)
						{
							dataRow2["idAbn"] = num2;
						}
						if (!string.IsNullOrEmpty(value))
						{
							dataRow2["body"] = value;
						}
						if (num3 != null)
						{
							dataRow2["Power"] = num3;
						}
						if (num5 != null)
						{
							dataRow2["VoltageLevel"] = num5;
						}
						@class.tTC_Request.Rows.Add(dataRow2);
						base.InsertSqlData(@class, @class.tTC_Request);
						@class.tTC_Request.Clear();
						System.Windows.Forms.Application.DoEvents();
					}
				}
				application.Quit();
				MessageBox.Show("Всё");
			}
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
			xmlAttribute = xmlDocument.CreateAttribute("HideNoDate");
			xmlAttribute.Value = this.checkBox_0.Checked.ToString();
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
				xmlAttribute = xmlNode.Attributes["HideNoDate"];
				if (xmlAttribute != null)
				{
					this.checkBox_0.Checked = Convert.ToBoolean(xmlAttribute.Value);
				}
			}
		}

		private void method_8()
		{
			this.icontainer_0 = new Container();
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormTechConnectionRequest));
			this.class10_0 = new Class10();
			this.toolStrip_0 = new ToolStrip();
			this.dcetsmBvMy = new ToolStripButton();
			this.toolStripButton_0 = new ToolStripButton();
			this.WxitAfAdMe = new ToolStripButton();
			this.toolStripSeparator_4 = new ToolStripSeparator();
			this.toolStripButton_20 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_7 = new ToolStripButton();
			this.toolStripTextBox_0 = new ToolStripTextBox();
			this.toolStripButton_8 = new ToolStripButton();
			this.toolStripButton_9 = new ToolStripButton();
			this.toolStripButton_15 = new ToolStripButton();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripButton_16 = new ToolStripButton();
			this.toolStripButton_22 = new ToolStripButton();
			this.splitContainer_0 = new SplitContainer();
			this.checkBox_0 = new System.Windows.Forms.CheckBox();
			this.dateTimePicker_0 = new DateTimePicker();
			this.label_0 = new System.Windows.Forms.Label();
			this.dateTimePicker_1 = new DateTimePicker();
			this.label_1 = new System.Windows.Forms.Label();
			this.vuatRjiaYu = new ToolStrip();
			this.toolStripButton_10 = new ToolStripButton();
			this.toolStripButton_11 = new ToolStripButton();
			this.splitContainer_1 = new SplitContainer();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_38 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_39 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_40 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_41 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_1 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_2 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_42 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_43 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_44 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_45 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_3 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_4 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_5 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_6 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewTextBoxColumn_46 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_7 = new DataGridViewFilterTextBoxColumn();
			this.CuHvdgLiOk = new DataGridViewFilterTextBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.tabControl_0 = new TabControl();
			this.tabPage_1 = new TabPage();
			this.splitContainer_2 = new SplitContainer();
			this.dataGridViewExcelFilter_2 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_25 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_26 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_27 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_28 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_29 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_30 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_31 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_32 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_33 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_34 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_35 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_36 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_37 = new DataGridViewTextBoxColumn();
			this.bindingSource_2 = new BindingSource(this.icontainer_0);
			this.dataGridViewExcelFilter_3 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
			this.bindingSource_3 = new BindingSource(this.icontainer_0);
			this.toolStrip_3 = new ToolStrip();
			this.toolStripButton_12 = new ToolStripButton();
			this.toolStripButton_13 = new ToolStripButton();
			this.toolStripButton_14 = new ToolStripButton();
			this.toolStrip_2 = new ToolStrip();
			this.toolStripDropDownButton_0 = new ToolStripDropDownButton();
			this.toolStripMenuItem_4 = new ToolStripMenuItem();
			this.toolStripMenuItem_6 = new ToolStripMenuItem();
			this.toolStripSeparator_6 = new ToolStripSeparator();
			this.toolStripMenuItem_5 = new ToolStripMenuItem();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripButton_6 = new ToolStripButton();
			this.tabPage_2 = new TabPage();
			this.dataGridViewExcelFilter_4 = new DataGridViewExcelFilter();
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
			this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_22 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_23 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_24 = new DataGridViewTextBoxColumn();
			this.bindingSource_4 = new BindingSource(this.icontainer_0);
			this.toolStrip_4 = new ToolStrip();
			this.toolStripButton_17 = new ToolStripButton();
			this.toolStripButton_18 = new ToolStripButton();
			this.toolStripButton_19 = new ToolStripButton();
			this.toolStripSeparator_5 = new ToolStripSeparator();
			this.toolStripButton_21 = new ToolStripButton();
			this.tabPage_0 = new TabPage();
			this.dataGridViewExcelFilter_1 = new DataGridViewExcelFilter();
			this.dataGridViewTextBoxColumn_47 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_48 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_49 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_50 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_51 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_52 = new DataGridViewTextBoxColumn();
			this.bindingSource_1 = new BindingSource(this.icontainer_0);
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripButton_4 = new ToolStripButton();
			this.contextMenuStrip_0 = new ContextMenuStrip(this.icontainer_0);
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripMenuItem_1 = new ToolStripMenuItem();
			this.toolStripMenuItem_2 = new ToolStripMenuItem();
			this.toolStripSeparator_3 = new ToolStripSeparator();
			this.toolStripMenuItem_3 = new ToolStripMenuItem();
			this.toolStripMenuItem_7 = new ToolStripMenuItem();
			((ISupportInitialize)this.class10_0).BeginInit();
			this.toolStrip_0.SuspendLayout();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			this.vuatRjiaYu.SuspendLayout();
			this.splitContainer_1.Panel1.SuspendLayout();
			this.splitContainer_1.Panel2.SuspendLayout();
			this.splitContainer_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			this.tabControl_0.SuspendLayout();
			this.tabPage_1.SuspendLayout();
			this.splitContainer_2.Panel1.SuspendLayout();
			this.splitContainer_2.Panel2.SuspendLayout();
			this.splitContainer_2.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_2).BeginInit();
			((ISupportInitialize)this.bindingSource_2).BeginInit();
			((ISupportInitialize)this.dataGridViewExcelFilter_3).BeginInit();
			((ISupportInitialize)this.bindingSource_3).BeginInit();
			this.toolStrip_3.SuspendLayout();
			this.toolStrip_2.SuspendLayout();
			this.tabPage_2.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_4).BeginInit();
			((ISupportInitialize)this.bindingSource_4).BeginInit();
			this.toolStrip_4.SuspendLayout();
			this.tabPage_0.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_1).BeginInit();
			((ISupportInitialize)this.bindingSource_1).BeginInit();
			this.toolStrip_1.SuspendLayout();
			this.contextMenuStrip_0.SuspendLayout();
			base.SuspendLayout();
			this.class10_0.DataSetName = "DataSetTechConnection";
			this.class10_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.dcetsmBvMy,
				this.toolStripButton_0,
				this.WxitAfAdMe,
				this.toolStripSeparator_4,
				this.toolStripButton_20,
				this.toolStripSeparator_0,
				this.toolStripButton_1,
				this.toolStripSeparator_1,
				this.toolStripButton_7,
				this.toolStripTextBox_0,
				this.toolStripButton_8,
				this.toolStripButton_9,
				this.toolStripButton_15,
				this.toolStripSeparator_2,
				this.toolStripButton_16,
				this.toolStripButton_22
			});
			this.toolStrip_0.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_0.Name = "toolStripMain";
			this.toolStrip_0.Size = new Size(905, 25);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = "toolStrip1";
			this.dcetsmBvMy.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.dcetsmBvMy.Image = Resources.ElementAdd;
			this.dcetsmBvMy.ImageTransparentColor = Color.Magenta;
			this.dcetsmBvMy.Name = "toolBtnAddRequest";
			this.dcetsmBvMy.Size = new Size(23, 22);
			this.dcetsmBvMy.Text = "Добавить";
			this.dcetsmBvMy.Click += this.dcetsmBvMy_Click;
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.ElementEdit;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnEditRequest";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Редактировать";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.WxitAfAdMe.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.WxitAfAdMe.Image = Resources.ElementDel;
			this.WxitAfAdMe.ImageTransparentColor = Color.Magenta;
			this.WxitAfAdMe.Name = "toolBtnDelRequest";
			this.WxitAfAdMe.Size = new Size(23, 22);
			this.WxitAfAdMe.Text = "Удалить";
			this.WxitAfAdMe.Click += this.WxitAfAdMe_Click;
			this.toolStripSeparator_4.Name = "toolStripSeparator5";
			this.toolStripSeparator_4.Size = new Size(6, 25);
			this.toolStripButton_20.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_20.Image = Resources.mergedialog;
			this.toolStripButton_20.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_20.Name = "toolBtnMergeRequest";
			this.toolStripButton_20.Size = new Size(23, 22);
			this.toolStripButton_20.Text = "Привязать к основной заявке";
			this.toolStripButton_20.Click += this.toolStripButton_20_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator1";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.refresh_16;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnRefresh";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Обновить";
			this.toolStripButton_1.Click += this.RjsIfkeEfy;
			this.toolStripSeparator_1.Name = "toolStripSeparator2";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_7.Image = Resources.Find;
			this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_7.Name = "toolBtnFindRequest";
			this.toolStripButton_7.Size = new Size(23, 22);
			this.toolStripButton_7.Text = "Поиск";
			this.toolStripButton_7.Click += this.toolStripButton_7_Click;
			this.toolStripTextBox_0.Name = "toolTxtFind";
			this.toolStripTextBox_0.Size = new Size(100, 25);
			this.toolStripTextBox_0.ToolTipText = "Текст для поиска";
			this.toolStripTextBox_0.KeyDown += this.toolStripTextBox_0_KeyDown;
			this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_8.Image = Resources.FindPrev;
			this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_8.Name = "toolBtnFindPrev";
			this.toolStripButton_8.Size = new Size(23, 22);
			this.toolStripButton_8.Text = "поиск назад";
			this.toolStripButton_8.Click += this.toolStripButton_8_Click;
			this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_9.Image = Resources.FindNext;
			this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_9.Name = "toolBtnFindNext";
			this.toolStripButton_9.Size = new Size(23, 22);
			this.toolStripButton_9.Text = "поиск вперед";
			this.toolStripButton_9.Click += this.toolStripButton_9_Click;
			this.toolStripButton_15.Alignment = ToolStripItemAlignment.Right;
			this.toolStripButton_15.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_15.Image = Resources.ElementGo;
			this.toolStripButton_15.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_15.Name = "toolBtnImportOldData";
			this.toolStripButton_15.Size = new Size(23, 22);
			this.toolStripButton_15.Text = "Импорт старых данных";
			this.toolStripButton_15.Visible = false;
			this.toolStripButton_15.Click += this.toolStripButton_15_Click;
			this.toolStripSeparator_2.Name = "toolStripSeparator3";
			this.toolStripSeparator_2.Size = new Size(6, 25);
			this.toolStripButton_16.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_16.Image = Resources.microsoftoffice2007excel_7581;
			this.toolStripButton_16.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_16.Name = "toolBtnExportExcel";
			this.toolStripButton_16.Size = new Size(23, 22);
			this.toolStripButton_16.Text = "Экспорт в Excel";
			this.toolStripButton_16.Click += this.toolStripButton_16_Click;
			this.toolStripButton_22.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_22.Image = Resources.report;
			this.toolStripButton_22.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_22.Name = "toolBtnReport";
			this.toolStripButton_22.Size = new Size(23, 22);
			this.toolStripButton_22.Text = "Отчет";
			this.toolStripButton_22.Click += this.toolStripButton_22_Click;
			this.splitContainer_0.Dock = DockStyle.Fill;
			this.splitContainer_0.Location = new System.Drawing.Point(0, 25);
			this.splitContainer_0.Name = "splitContainer";
			this.splitContainer_0.Panel1.Controls.Add(this.checkBox_0);
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_0);
			this.splitContainer_0.Panel1.Controls.Add(this.label_0);
			this.splitContainer_0.Panel1.Controls.Add(this.dateTimePicker_1);
			this.splitContainer_0.Panel1.Controls.Add(this.label_1);
			this.splitContainer_0.Panel1.Controls.Add(this.vuatRjiaYu);
			this.splitContainer_0.Panel2.Controls.Add(this.splitContainer_1);
			this.splitContainer_0.Size = new Size(905, 431);
			this.splitContainer_0.SplitterDistance = 154;
			this.splitContainer_0.TabIndex = 1;
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.Checked = true;
			this.checkBox_0.CheckState = CheckState.Checked;
			this.checkBox_0.Location = new System.Drawing.Point(15, 106);
			this.checkBox_0.Name = "checkBoxNoDate";
			this.checkBox_0.Size = new Size(113, 17);
			this.checkBox_0.TabIndex = 5;
			this.checkBox_0.Text = "Скрыть без даты";
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.dateTimePicker_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_0.Location = new System.Drawing.Point(12, 80);
			this.dateTimePicker_0.Name = "dateTimePickerFilterEnd";
			this.dateTimePicker_0.Size = new Size(136, 20);
			this.dateTimePicker_0.TabIndex = 4;
			this.label_0.AutoSize = true;
			this.label_0.Location = new System.Drawing.Point(12, 64);
			this.label_0.Name = "label2";
			this.label_0.Size = new Size(89, 13);
			this.label_0.TabIndex = 3;
			this.label_0.Text = "Дата окончания";
			this.dateTimePicker_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dateTimePicker_1.Location = new System.Drawing.Point(12, 41);
			this.dateTimePicker_1.Name = "dateTimePickerFilterBeg";
			this.dateTimePicker_1.Size = new Size(139, 20);
			this.dateTimePicker_1.TabIndex = 2;
			this.label_1.AutoSize = true;
			this.label_1.Location = new System.Drawing.Point(12, 25);
			this.label_1.Name = "label1";
			this.label_1.Size = new Size(71, 13);
			this.label_1.TabIndex = 1;
			this.label_1.Text = "Дата начала";
			this.vuatRjiaYu.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_10,
				this.toolStripButton_11
			});
			this.vuatRjiaYu.Location = new System.Drawing.Point(0, 0);
			this.vuatRjiaYu.Name = "toolStripFilter";
			this.vuatRjiaYu.Size = new Size(154, 25);
			this.vuatRjiaYu.TabIndex = 0;
			this.vuatRjiaYu.Text = "toolStrip1";
			this.toolStripButton_10.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_10.Image = Resources.filter;
			this.toolStripButton_10.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_10.Name = "toolBtnApplyFilter";
			this.toolStripButton_10.Size = new Size(23, 22);
			this.toolStripButton_10.Text = "Применить фильтр";
			this.toolStripButton_10.Click += this.toolStripButton_10_Click;
			this.toolStripButton_11.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_11.Image = Resources.filter_delete;
			this.toolStripButton_11.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_11.Name = "toolBtnClearFilter";
			this.toolStripButton_11.Size = new Size(23, 22);
			this.toolStripButton_11.Text = "Очистить фильтр";
			this.toolStripButton_11.Click += this.toolStripButton_11_Click;
			this.splitContainer_1.Dock = DockStyle.Fill;
			this.splitContainer_1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer_1.Name = "splitContainerDgv";
			this.splitContainer_1.Orientation = Orientation.Horizontal;
			this.splitContainer_1.Panel1.Controls.Add(this.dataGridViewExcelFilter_0);
			this.splitContainer_1.Panel2.Controls.Add(this.tabControl_0);
			this.splitContainer_1.Size = new Size(747, 431);
			this.splitContainer_1.SplitterDistance = 253;
			this.splitContainer_1.TabIndex = 0;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_0.AllowUserToVisibleColumns = false;
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_38,
				this.dataGridViewTextBoxColumn_39,
				this.dataGridViewTextBoxColumn_40,
				this.dataGridViewTextBoxColumn_41,
				this.dataGridViewFilterTextBoxColumn_0,
				this.dataGridViewFilterTextBoxColumn_1,
				this.dataGridViewFilterTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_42,
				this.dataGridViewTextBoxColumn_43,
				this.dataGridViewTextBoxColumn_44,
				this.dataGridViewTextBoxColumn_45,
				this.dataGridViewFilterTextBoxColumn_3,
				this.dataGridViewFilterTextBoxColumn_4,
				this.dataGridViewFilterTextBoxColumn_5,
				this.dataGridViewFilterTextBoxColumn_6,
				this.dataGridViewTextBoxColumn_46,
				this.dataGridViewFilterTextBoxColumn_7,
				this.CuHvdgLiOk
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewExcelFilter_0.Name = "dgvRequest";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_0.Size = new Size(747, 253);
			this.dataGridViewExcelFilter_0.TabIndex = 0;
			this.dataGridViewExcelFilter_0.VirtualMode = true;
			this.dataGridViewExcelFilter_0.CellDoubleClick += this.dataGridViewExcelFilter_0_CellDoubleClick;
			this.dataGridViewExcelFilter_0.CellFormatting += this.dataGridViewExcelFilter_0_CellFormatting;
			this.dataGridViewExcelFilter_0.CellMouseClick += this.dataGridViewExcelFilter_0_CellMouseClick;
			this.dataGridViewExcelFilter_0.RowPostPaint += this.dataGridViewExcelFilter_0_RowPostPaint;
			this.dataGridViewTextBoxColumn_38.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_38.HeaderText = "id";
			this.dataGridViewTextBoxColumn_38.Name = "idDgvColumn";
			this.dataGridViewTextBoxColumn_38.ReadOnly = true;
			this.dataGridViewTextBoxColumn_38.Visible = false;
			this.dataGridViewTextBoxColumn_39.DataPropertyName = "numDateIn";
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_39.DefaultCellStyle = dataGridViewCellStyle;
			this.dataGridViewTextBoxColumn_39.HeaderText = "№, дата вход.";
			this.dataGridViewTextBoxColumn_39.Name = "numDateInDgvColumn";
			this.dataGridViewTextBoxColumn_39.ReadOnly = true;
			this.dataGridViewTextBoxColumn_40.DataPropertyName = "numDoc";
			this.dataGridViewTextBoxColumn_40.HeaderText = "numDoc";
			this.dataGridViewTextBoxColumn_40.Name = "numDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_40.ReadOnly = true;
			this.dataGridViewTextBoxColumn_40.Visible = false;
			this.dataGridViewTextBoxColumn_41.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_41.HeaderText = "Дата получения";
			this.dataGridViewTextBoxColumn_41.Name = "dateDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_41.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "nameAbn";
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_0.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "Абонент";
			this.dataGridViewFilterTextBoxColumn_0.Name = "nameAbnDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.DataPropertyName = "nameObj";
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_1.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewFilterTextBoxColumn_1.HeaderText = "Объект";
			this.dataGridViewFilterTextBoxColumn_1.Name = "nameObjDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_1.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_2.DataPropertyName = "address";
			this.dataGridViewFilterTextBoxColumn_2.HeaderText = "Адрес";
			this.dataGridViewFilterTextBoxColumn_2.Name = "addressDgvColumn";
			this.dataGridViewFilterTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_2.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_42.DataPropertyName = "numIn";
			this.dataGridViewTextBoxColumn_42.HeaderText = "numIn";
			this.dataGridViewTextBoxColumn_42.Name = "numInDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_42.ReadOnly = true;
			this.dataGridViewTextBoxColumn_42.Visible = false;
			this.dataGridViewTextBoxColumn_43.DataPropertyName = "dateIn";
			this.dataGridViewTextBoxColumn_43.HeaderText = "dateIn";
			this.dataGridViewTextBoxColumn_43.Name = "dateInDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_43.ReadOnly = true;
			this.dataGridViewTextBoxColumn_43.Visible = false;
			this.dataGridViewTextBoxColumn_44.DataPropertyName = "idAbn";
			this.dataGridViewTextBoxColumn_44.HeaderText = "idAbn";
			this.dataGridViewTextBoxColumn_44.Name = "idAbnDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_44.ReadOnly = true;
			this.dataGridViewTextBoxColumn_44.Visible = false;
			this.dataGridViewTextBoxColumn_45.DataPropertyName = "idAbnObj";
			this.dataGridViewTextBoxColumn_45.HeaderText = "idAbnObj";
			this.dataGridViewTextBoxColumn_45.Name = "idAbnObjDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_45.ReadOnly = true;
			this.dataGridViewTextBoxColumn_45.Visible = false;
			this.dataGridViewFilterTextBoxColumn_3.DataPropertyName = "body";
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_3.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewFilterTextBoxColumn_3.HeaderText = "Тело письма";
			this.dataGridViewFilterTextBoxColumn_3.Name = "bodyDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_3.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_4.DataPropertyName = "Power";
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridViewFilterTextBoxColumn_4.HeaderText = "Максимальная мощность";
			this.dataGridViewFilterTextBoxColumn_4.Name = "powerDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_4.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_5.DataPropertyName = "VoltageName";
			this.dataGridViewFilterTextBoxColumn_5.HeaderText = "Напр-ие";
			this.dataGridViewFilterTextBoxColumn_5.Name = "VoltageNameDgvColumn";
			this.dataGridViewFilterTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_6.DataPropertyName = "docStatus";
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_6.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewFilterTextBoxColumn_6.HeaderText = "Статус";
			this.dataGridViewFilterTextBoxColumn_6.Name = "docStatusDgvColumn";
			this.dataGridViewFilterTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_6.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_46.DataPropertyName = "addressFull";
			this.dataGridViewTextBoxColumn_46.HeaderText = "addressFull";
			this.dataGridViewTextBoxColumn_46.Name = "addressFullDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_46.ReadOnly = true;
			this.dataGridViewTextBoxColumn_46.Visible = false;
			this.dataGridViewFilterTextBoxColumn_7.DataPropertyName = "NameDocOut";
			dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_7.DefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewFilterTextBoxColumn_7.FillWeight = 120f;
			this.dataGridViewFilterTextBoxColumn_7.HeaderText = "Выданные документы";
			this.dataGridViewFilterTextBoxColumn_7.Name = "nameDocOutDgvColumn";
			this.dataGridViewFilterTextBoxColumn_7.ReadOnly = true;
			this.CuHvdgLiOk.DataPropertyName = "Comment";
			dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
			this.CuHvdgLiOk.DefaultCellStyle = dataGridViewCellStyle8;
			this.CuHvdgLiOk.HeaderText = "Комментарий";
			this.CuHvdgLiOk.Name = "commentdgvColumn";
			this.CuHvdgLiOk.ReadOnly = true;
			this.CuHvdgLiOk.Resizable = DataGridViewTriState.True;
			this.bindingSource_0.DataMember = "vTC_Request";
			this.bindingSource_0.DataSource = this.class10_0;
			this.bindingSource_0.CurrentChanged += this.bindingSource_0_CurrentChanged;
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Controls.Add(this.tabPage_2);
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Dock = DockStyle.Fill;
			this.tabControl_0.Location = new System.Drawing.Point(0, 0);
			this.tabControl_0.Name = "tabControlRequest";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new Size(747, 174);
			this.tabControl_0.TabIndex = 0;
			this.tabPage_1.Controls.Add(this.splitContainer_2);
			this.tabPage_1.Controls.Add(this.toolStrip_2);
			this.tabPage_1.Location = new System.Drawing.Point(4, 22);
			this.tabPage_1.Name = "tabPageDocOut";
			this.tabPage_1.Padding = new Padding(3);
			this.tabPage_1.Size = new Size(739, 148);
			this.tabPage_1.TabIndex = 1;
			this.tabPage_1.Text = "Выданные документы";
			this.tabPage_1.UseVisualStyleBackColor = true;
			this.splitContainer_2.Dock = DockStyle.Fill;
			this.splitContainer_2.Location = new System.Drawing.Point(35, 3);
			this.splitContainer_2.Name = "splitContainer1";
			this.splitContainer_2.Panel1.Controls.Add(this.dataGridViewExcelFilter_2);
			this.splitContainer_2.Panel2.Controls.Add(this.dataGridViewExcelFilter_3);
			this.splitContainer_2.Panel2.Controls.Add(this.toolStrip_3);
			this.splitContainer_2.Size = new Size(701, 142);
			this.splitContainer_2.SplitterDistance = 323;
			this.splitContainer_2.TabIndex = 3;
			this.dataGridViewExcelFilter_2.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_2.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_2.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_2.AllowUserToVisibleColumns = false;
			this.dataGridViewExcelFilter_2.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_2.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_25,
				this.dataGridViewTextBoxColumn_26,
				this.dataGridViewTextBoxColumn_27,
				this.dataGridViewTextBoxColumn_28,
				this.dataGridViewTextBoxColumn_29,
				this.dataGridViewTextBoxColumn_30,
				this.dataGridViewTextBoxColumn_31,
				this.dataGridViewTextBoxColumn_32,
				this.dataGridViewTextBoxColumn_33,
				this.dataGridViewTextBoxColumn_34,
				this.dataGridViewTextBoxColumn_35,
				this.dataGridViewTextBoxColumn_36,
				this.dataGridViewTextBoxColumn_37
			});
			this.dataGridViewExcelFilter_2.DataSource = this.bindingSource_2;
			this.dataGridViewExcelFilter_2.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_2.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewExcelFilter_2.Name = "dgvDocOut";
			this.dataGridViewExcelFilter_2.ReadOnly = true;
			this.dataGridViewExcelFilter_2.RowHeadersWidth = 21;
			this.dataGridViewExcelFilter_2.Size = new Size(323, 142);
			this.dataGridViewExcelFilter_2.TabIndex = 2;
			this.dataGridViewExcelFilter_2.VirtualMode = true;
			this.dataGridViewExcelFilter_2.CellDoubleClick += this.dataGridViewExcelFilter_2_CellDoubleClick;
			this.dataGridViewExcelFilter_2.CellFormatting += this.dataGridViewExcelFilter_2_CellFormatting;
			this.dataGridViewTextBoxColumn_25.DataPropertyName = "TypeDocNameOut";
			this.dataGridViewTextBoxColumn_25.HeaderText = "Документ";
			this.dataGridViewTextBoxColumn_25.Name = "typeDocNameOutDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_25.ReadOnly = true;
			this.dataGridViewTextBoxColumn_26.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_26.HeaderText = "id";
			this.dataGridViewTextBoxColumn_26.Name = "idLinkDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_26.ReadOnly = true;
			this.dataGridViewTextBoxColumn_26.Visible = false;
			this.dataGridViewTextBoxColumn_27.DataPropertyName = "numDateDocOut";
			this.dataGridViewTextBoxColumn_27.HeaderText = "numDateDocOut";
			this.dataGridViewTextBoxColumn_27.Name = "numDateDocOutDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_27.ReadOnly = true;
			this.dataGridViewTextBoxColumn_27.Visible = false;
			this.dataGridViewTextBoxColumn_28.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_28.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_28.Name = "idDocDgvColumnIndgvDocOut";
			this.dataGridViewTextBoxColumn_28.ReadOnly = true;
			this.dataGridViewTextBoxColumn_28.Visible = false;
			this.dataGridViewTextBoxColumn_29.DataPropertyName = "numDocOut";
			this.dataGridViewTextBoxColumn_29.HeaderText = "№";
			this.dataGridViewTextBoxColumn_29.Name = "numDocOutDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_29.ReadOnly = true;
			this.dataGridViewTextBoxColumn_30.DataPropertyName = "TypeDocOut";
			this.dataGridViewTextBoxColumn_30.HeaderText = "TypeDocOut";
			this.dataGridViewTextBoxColumn_30.Name = "typeDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_30.ReadOnly = true;
			this.dataGridViewTextBoxColumn_30.Visible = false;
			this.dataGridViewTextBoxColumn_31.DataPropertyName = "idDocOut";
			this.dataGridViewTextBoxColumn_31.HeaderText = "idDocOut";
			this.dataGridViewTextBoxColumn_31.Name = "idDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_31.ReadOnly = true;
			this.dataGridViewTextBoxColumn_31.Visible = false;
			this.dataGridViewTextBoxColumn_32.DataPropertyName = "dateDocOut";
			dataGridViewCellStyle9.Format = "d";
			dataGridViewCellStyle9.NullValue = null;
			this.dataGridViewTextBoxColumn_32.DefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridViewTextBoxColumn_32.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_32.Name = "dateDocOutDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_32.ReadOnly = true;
			this.dataGridViewTextBoxColumn_33.DataPropertyName = "Status";
			this.dataGridViewTextBoxColumn_33.HeaderText = "Статус";
			this.dataGridViewTextBoxColumn_33.Name = "statusDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_33.ReadOnly = true;
			this.dataGridViewTextBoxColumn_33.Visible = false;
			this.dataGridViewTextBoxColumn_34.DataPropertyName = "BodyDocOut";
			this.dataGridViewTextBoxColumn_34.HeaderText = "Содержание";
			this.dataGridViewTextBoxColumn_34.Name = "bodyDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_34.ReadOnly = true;
			this.dataGridViewTextBoxColumn_35.DataPropertyName = "SendModeName";
			this.dataGridViewTextBoxColumn_35.HeaderText = "Способ отправки";
			this.dataGridViewTextBoxColumn_35.Name = "sendModeNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_35.ReadOnly = true;
			this.dataGridViewTextBoxColumn_35.Visible = false;
			this.dataGridViewTextBoxColumn_36.DataPropertyName = "number";
			this.dataGridViewTextBoxColumn_36.HeaderText = "Кол-во";
			this.dataGridViewTextBoxColumn_36.Name = "numberDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_36.ReadOnly = true;
			this.dataGridViewTextBoxColumn_37.DataPropertyName = "comment";
			this.dataGridViewTextBoxColumn_37.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_37.Name = "commentDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_37.ReadOnly = true;
			this.dataGridViewTextBoxColumn_37.Visible = false;
			this.bindingSource_2.DataMember = "vTC_DocOut";
			this.bindingSource_2.DataSource = this.class10_0;
			this.bindingSource_2.CurrentChanged += this.bindingSource_2_CurrentChanged;
			this.dataGridViewExcelFilter_3.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_3.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_3.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_3.AllowUserToVisibleColumns = false;
			this.dataGridViewExcelFilter_3.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_3.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_3,
				this.dataGridViewTextBoxColumn_4,
				this.dataGridViewTextBoxColumn_5,
				this.dataGridViewTextBoxColumn_6
			});
			this.dataGridViewExcelFilter_3.DataSource = this.bindingSource_3;
			this.dataGridViewExcelFilter_3.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_3.Location = new System.Drawing.Point(0, 25);
			this.dataGridViewExcelFilter_3.Name = "dgvDocOutStatus";
			this.dataGridViewExcelFilter_3.ReadOnly = true;
			this.dataGridViewExcelFilter_3.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_3.Size = new Size(374, 117);
			this.dataGridViewExcelFilter_3.TabIndex = 2;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "idStatusDocOutDgvColumn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_1.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_1.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Visible = false;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "idStatus";
			this.dataGridViewTextBoxColumn_2.HeaderText = "idStatus";
			this.dataGridViewTextBoxColumn_2.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewTextBoxColumn_2.Visible = false;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "statusName";
			this.dataGridViewTextBoxColumn_3.HeaderText = "Статус";
			this.dataGridViewTextBoxColumn_3.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "DateChange";
			dataGridViewCellStyle10.Format = "d";
			dataGridViewCellStyle10.NullValue = null;
			this.dataGridViewTextBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewTextBoxColumn_4.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_4.Width = 70;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "SendName";
			this.dataGridViewTextBoxColumn_5.HeaderText = "Способ отправки";
			this.dataGridViewTextBoxColumn_5.Name = "sendNameDgvColumn";
			this.dataGridViewTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_6.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_6.Name = "сommentDocOutStatusDgvColumn";
			this.dataGridViewTextBoxColumn_6.ReadOnly = true;
			this.bindingSource_3.DataMember = "vTC_DocStatus";
			this.bindingSource_3.DataSource = this.class10_0;
			this.toolStrip_3.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_3.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_12,
				this.toolStripButton_13,
				this.toolStripButton_14
			});
			this.toolStrip_3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_3.Name = "toolStripDocOutStatus";
			this.toolStrip_3.Size = new Size(374, 25);
			this.toolStrip_3.TabIndex = 1;
			this.toolStrip_3.Text = "toolStrip1";
			this.toolStripButton_12.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_12.Image = Resources.ElementAdd;
			this.toolStripButton_12.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_12.Name = "toolBtnAddDocOutStatus";
			this.toolStripButton_12.Size = new Size(23, 22);
			this.toolStripButton_12.Text = "Новый статус";
			this.toolStripButton_12.Click += this.toolStripButton_12_Click;
			this.toolStripButton_13.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_13.Image = Resources.ElementEdit;
			this.toolStripButton_13.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_13.Name = "toolBtnEditDocOutStatus";
			this.toolStripButton_13.Size = new Size(23, 22);
			this.toolStripButton_13.Text = "Редактировать статус";
			this.toolStripButton_13.Click += this.toolStripButton_13_Click;
			this.toolStripButton_14.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_14.Image = Resources.ElementDel;
			this.toolStripButton_14.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_14.Name = "toolBtnDelDocOutStatus";
			this.toolStripButton_14.Size = new Size(23, 22);
			this.toolStripButton_14.Text = "Удалить статус";
			this.toolStripButton_14.Click += this.toolStripButton_14_Click;
			this.toolStrip_2.Dock = DockStyle.Left;
			this.toolStrip_2.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_2.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripDropDownButton_0,
				this.toolStripButton_5,
				this.toolStripButton_6
			});
			this.toolStrip_2.Location = new System.Drawing.Point(3, 3);
			this.toolStrip_2.Name = "toolStripDocOut";
			this.toolStrip_2.Size = new Size(32, 142);
			this.toolStrip_2.TabIndex = 1;
			this.toolStrip_2.Text = "toolStrip1";
			this.toolStripDropDownButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripDropDownButton_0.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_4,
				this.toolStripMenuItem_6,
				this.toolStripMenuItem_7,
				this.toolStripSeparator_6,
				this.toolStripMenuItem_5
			});
			this.toolStripDropDownButton_0.Image = Resources.ElementAdd;
			this.toolStripDropDownButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripDropDownButton_0.Name = "toolBtnAddDocOut";
			this.toolStripDropDownButton_0.Size = new Size(29, 20);
			this.toolStripDropDownButton_0.Text = "Новый документ";
			this.toolStripMenuItem_4.Name = "toolBtnAddTU";
			this.toolStripMenuItem_4.Size = new Size(177, 22);
			this.toolStripMenuItem_4.Text = "Тех. условие";
			this.toolStripMenuItem_4.Click += this.toolStripMenuItem_4_Click;
			this.toolStripMenuItem_6.Name = "toolBtnAddContract";
			this.toolStripMenuItem_6.Size = new Size(177, 22);
			this.toolStripMenuItem_6.Text = "Договор на ТП";
			this.toolStripMenuItem_6.Click += this.toolStripMenuItem_6_Click;
			this.toolStripSeparator_6.Name = "toolStripSeparator7";
			this.toolStripSeparator_6.Size = new Size(174, 6);
			this.toolStripMenuItem_5.Name = "toolBtnAddDocOutOther";
			this.toolStripMenuItem_5.Size = new Size(177, 22);
			this.toolStripMenuItem_5.Text = "Другие документы";
			this.toolStripMenuItem_5.Click += this.toolStripMenuItem_5_Click;
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = Resources.ElementEdit;
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBtnEditDocOut";
			this.toolStripButton_5.Size = new Size(29, 20);
			this.toolStripButton_5.Text = "Редактировать документ";
			this.toolStripButton_5.Click += this.toolStripButton_5_Click;
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = Resources.ElementDel;
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "toolBtnDelDocOut";
			this.toolStripButton_6.Size = new Size(29, 20);
			this.toolStripButton_6.Text = "Удалить документ";
			this.toolStripButton_6.Click += this.toolStripButton_6_Click;
			this.tabPage_2.Controls.Add(this.dataGridViewExcelFilter_4);
			this.tabPage_2.Controls.Add(this.toolStrip_4);
			this.tabPage_2.Location = new System.Drawing.Point(4, 22);
			this.tabPage_2.Name = "tabPageRequestHistory";
			this.tabPage_2.Padding = new Padding(3);
			this.tabPage_2.Size = new Size(739, 148);
			this.tabPage_2.TabIndex = 2;
			this.tabPage_2.Text = "История заявок";
			this.tabPage_2.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter_4.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_4.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_4.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_4.Columns.AddRange(new DataGridViewColumn[]
			{
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
				this.dataGridViewTextBoxColumn_18,
				this.dataGridViewTextBoxColumn_19,
				this.dataGridViewTextBoxColumn_20,
				this.dataGridViewTextBoxColumn_21,
				this.dataGridViewTextBoxColumn_22,
				this.dataGridViewTextBoxColumn_23,
				this.dataGridViewTextBoxColumn_24
			});
			this.dataGridViewExcelFilter_4.DataSource = this.bindingSource_4;
			this.dataGridViewExcelFilter_4.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_4.Location = new System.Drawing.Point(27, 3);
			this.dataGridViewExcelFilter_4.MultiSelect = false;
			this.dataGridViewExcelFilter_4.Name = "dgvRequestHistory";
			this.dataGridViewExcelFilter_4.ReadOnly = true;
			this.dataGridViewExcelFilter_4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_4.Size = new Size(709, 142);
			this.dataGridViewExcelFilter_4.TabIndex = 3;
			this.dataGridViewExcelFilter_4.VirtualMode = true;
			this.dataGridViewExcelFilter_4.CellDoubleClick += this.dataGridViewExcelFilter_4_CellDoubleClick;
			this.dataGridViewExcelFilter_4.CellFormatting += this.dataGridViewExcelFilter_4_CellFormatting;
			this.dataGridViewExcelFilter_4.RowPostPaint += this.dataGridViewExcelFilter_4_RowPostPaint;
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "numDateIn";
			dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_7.DefaultCellStyle = dataGridViewCellStyle11;
			this.dataGridViewTextBoxColumn_7.HeaderText = "№, дата вход.";
			this.dataGridViewTextBoxColumn_7.Name = "numDateInDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewTextBoxColumn_7.Width = 80;
			this.dataGridViewTextBoxColumn_8.DataPropertyName = "numDoc";
			this.dataGridViewTextBoxColumn_8.HeaderText = "numDoc";
			this.dataGridViewTextBoxColumn_8.Name = "numDocDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewTextBoxColumn_8.Visible = false;
			this.dataGridViewTextBoxColumn_9.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_9.HeaderText = "id";
			this.dataGridViewTextBoxColumn_9.Name = "idRequestHistoryDgvColumn";
			this.dataGridViewTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewTextBoxColumn_9.Visible = false;
			this.dataGridViewTextBoxColumn_10.DataPropertyName = "dateDoc";
			this.dataGridViewTextBoxColumn_10.HeaderText = "Дата получения";
			this.dataGridViewTextBoxColumn_10.Name = "dateDocDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewTextBoxColumn_10.Width = 80;
			this.dataGridViewTextBoxColumn_11.DataPropertyName = "TypeDoc";
			this.dataGridViewTextBoxColumn_11.HeaderText = "TypeDoc";
			this.dataGridViewTextBoxColumn_11.Name = "typeDocRequestHistoryDgvColumn";
			this.dataGridViewTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewTextBoxColumn_11.Visible = false;
			this.dataGridViewTextBoxColumn_12.DataPropertyName = "numIn";
			this.dataGridViewTextBoxColumn_12.HeaderText = "numIn";
			this.dataGridViewTextBoxColumn_12.Name = "numInDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewTextBoxColumn_12.Visible = false;
			this.dataGridViewTextBoxColumn_13.DataPropertyName = "dateIn";
			this.dataGridViewTextBoxColumn_13.HeaderText = "dateIn";
			this.dataGridViewTextBoxColumn_13.Name = "dateInDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewTextBoxColumn_13.Visible = false;
			this.dataGridViewTextBoxColumn_14.DataPropertyName = "idAbn";
			this.dataGridViewTextBoxColumn_14.HeaderText = "idAbn";
			this.dataGridViewTextBoxColumn_14.Name = "idAbnDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewTextBoxColumn_14.Visible = false;
			this.dataGridViewTextBoxColumn_15.DataPropertyName = "idAbnObj";
			this.dataGridViewTextBoxColumn_15.HeaderText = "idAbnObj";
			this.dataGridViewTextBoxColumn_15.Name = "idAbnObjDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewTextBoxColumn_15.Visible = false;
			this.dataGridViewTextBoxColumn_16.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_16.DataPropertyName = "body";
			dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn_16.DefaultCellStyle = dataGridViewCellStyle12;
			this.dataGridViewTextBoxColumn_16.HeaderText = "Тело письма";
			this.dataGridViewTextBoxColumn_16.Name = "bodyDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewTextBoxColumn_17.DataPropertyName = "PowerCurrent";
			this.dataGridViewTextBoxColumn_17.HeaderText = "Текущая мощность";
			this.dataGridViewTextBoxColumn_17.Name = "powerCurrentDgvColumn";
			this.dataGridViewTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewTextBoxColumn_17.Width = 70;
			this.dataGridViewTextBoxColumn_18.DataPropertyName = "PowerAdd";
			this.dataGridViewTextBoxColumn_18.HeaderText = "Доп мощность";
			this.dataGridViewTextBoxColumn_18.Name = "PowerAddDgvColumn";
			this.dataGridViewTextBoxColumn_18.ReadOnly = true;
			this.dataGridViewTextBoxColumn_18.Width = 70;
			this.dataGridViewTextBoxColumn_19.DataPropertyName = "Power";
			this.dataGridViewTextBoxColumn_19.HeaderText = "Суммарная мощность";
			this.dataGridViewTextBoxColumn_19.Name = "powerDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_19.ReadOnly = true;
			this.dataGridViewTextBoxColumn_19.Width = 70;
			this.dataGridViewTextBoxColumn_20.DataPropertyName = "VoltageName";
			this.dataGridViewTextBoxColumn_20.HeaderText = "Напряжение";
			this.dataGridViewTextBoxColumn_20.Name = "voltageNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_20.ReadOnly = true;
			this.dataGridViewTextBoxColumn_20.Width = 70;
			this.dataGridViewTextBoxColumn_21.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_21.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_21.Name = "commentDataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_21.ReadOnly = true;
			this.dataGridViewTextBoxColumn_21.Width = 70;
			this.dataGridViewTextBoxColumn_22.DataPropertyName = "VoltageLevel";
			this.dataGridViewTextBoxColumn_22.HeaderText = "VoltageLevel";
			this.dataGridViewTextBoxColumn_22.Name = "voltageLevelDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_22.ReadOnly = true;
			this.dataGridViewTextBoxColumn_22.Visible = false;
			this.dataGridViewTextBoxColumn_23.DataPropertyName = "VoltageValue";
			this.dataGridViewTextBoxColumn_23.HeaderText = "VoltageValue";
			this.dataGridViewTextBoxColumn_23.Name = "voltageValueDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_23.ReadOnly = true;
			this.dataGridViewTextBoxColumn_23.Visible = false;
			this.dataGridViewTextBoxColumn_24.DataPropertyName = "IdParent";
			this.dataGridViewTextBoxColumn_24.HeaderText = "IdParent";
			this.dataGridViewTextBoxColumn_24.Name = "idParentDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_24.ReadOnly = true;
			this.dataGridViewTextBoxColumn_24.Visible = false;
			this.bindingSource_4.DataMember = "vTC_RequestHistory";
			this.bindingSource_4.DataSource = this.class10_0;
			this.toolStrip_4.Dock = DockStyle.Left;
			this.toolStrip_4.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_4.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_17,
				this.toolStripButton_18,
				this.toolStripButton_19,
				this.toolStripSeparator_5,
				this.toolStripButton_21
			});
			this.toolStrip_4.Location = new System.Drawing.Point(3, 3);
			this.toolStrip_4.Name = "toolStripRequestHistory";
			this.toolStrip_4.Size = new Size(24, 142);
			this.toolStrip_4.TabIndex = 2;
			this.toolStrip_4.Text = "toolStrip1";
			this.toolStripButton_17.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_17.Image = Resources.ElementAdd;
			this.toolStripButton_17.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_17.Name = "toolBtnAddReuestAdditional";
			this.toolStripButton_17.Size = new Size(21, 20);
			this.toolStripButton_17.Text = "Добавить";
			this.toolStripButton_17.Click += this.toolStripButton_17_Click;
			this.toolStripButton_18.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_18.Image = Resources.ElementEdit;
			this.toolStripButton_18.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_18.Name = "toolBtnEditReuestAdditional";
			this.toolStripButton_18.Size = new Size(21, 20);
			this.toolStripButton_18.Text = "Редактировать";
			this.toolStripButton_18.Click += this.toolStripButton_18_Click;
			this.toolStripButton_19.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_19.Image = Resources.ElementDel;
			this.toolStripButton_19.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_19.Name = "toolBtnDelReuestAdditional";
			this.toolStripButton_19.Size = new Size(21, 20);
			this.toolStripButton_19.Text = "Удалить";
			this.toolStripButton_19.Click += this.toolStripButton_19_Click;
			this.toolStripSeparator_5.Name = "toolStripSeparator6";
			this.toolStripSeparator_5.Size = new Size(21, 6);
			this.toolStripButton_21.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_21.Image = Resources.ElementGo;
			this.toolStripButton_21.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_21.Name = "toolBtnRequestSplit";
			this.toolStripButton_21.Size = new Size(21, 20);
			this.toolStripButton_21.Text = "Переместить в основные заявки";
			this.toolStripButton_21.Click += this.toolStripButton_21_Click;
			this.tabPage_0.Controls.Add(this.dataGridViewExcelFilter_1);
			this.tabPage_0.Controls.Add(this.toolStrip_1);
			this.tabPage_0.Location = new System.Drawing.Point(4, 22);
			this.tabPage_0.Name = "tabPageDocStatus";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.Size = new Size(739, 148);
			this.tabPage_0.TabIndex = 0;
			this.tabPage_0.Text = "Статус заявки";
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter_1.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_1.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_1.AllowUserToOrderColumns = true;
			this.dataGridViewExcelFilter_1.AllowUserToVisibleColumns = false;
			this.dataGridViewExcelFilter_1.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_1.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_47,
				this.dataGridViewTextBoxColumn_48,
				this.dataGridViewTextBoxColumn_49,
				this.dataGridViewTextBoxColumn_50,
				this.dataGridViewTextBoxColumn_51,
				this.dataGridViewTextBoxColumn_52
			});
			this.dataGridViewExcelFilter_1.DataSource = this.bindingSource_1;
			this.dataGridViewExcelFilter_1.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_1.Location = new System.Drawing.Point(27, 3);
			this.dataGridViewExcelFilter_1.Name = "dgvDocStatus";
			this.dataGridViewExcelFilter_1.ReadOnly = true;
			this.dataGridViewExcelFilter_1.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_1.Size = new Size(709, 142);
			this.dataGridViewExcelFilter_1.TabIndex = 1;
			this.dataGridViewExcelFilter_1.CellDoubleClick += this.dataGridViewExcelFilter_1_CellDoubleClick;
			this.dataGridViewTextBoxColumn_47.DataPropertyName = "DateChange";
			dataGridViewCellStyle13.Format = "d";
			dataGridViewCellStyle13.NullValue = null;
			this.dataGridViewTextBoxColumn_47.DefaultCellStyle = dataGridViewCellStyle13;
			this.dataGridViewTextBoxColumn_47.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_47.Name = "dateChangeDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_47.ReadOnly = true;
			this.dataGridViewTextBoxColumn_47.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_48.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_48.HeaderText = "id";
			this.dataGridViewTextBoxColumn_48.Name = "idRequestStatusDgvColumn";
			this.dataGridViewTextBoxColumn_48.ReadOnly = true;
			this.dataGridViewTextBoxColumn_48.Visible = false;
			this.dataGridViewTextBoxColumn_49.DataPropertyName = "idDoc";
			this.dataGridViewTextBoxColumn_49.HeaderText = "idDoc";
			this.dataGridViewTextBoxColumn_49.Name = "idDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_49.ReadOnly = true;
			this.dataGridViewTextBoxColumn_49.Visible = false;
			this.dataGridViewTextBoxColumn_50.DataPropertyName = "idStatus";
			this.dataGridViewTextBoxColumn_50.HeaderText = "idStatus";
			this.dataGridViewTextBoxColumn_50.Name = "idStatusDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_50.ReadOnly = true;
			this.dataGridViewTextBoxColumn_50.Visible = false;
			this.dataGridViewTextBoxColumn_51.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_51.DataPropertyName = "statusName";
			this.dataGridViewTextBoxColumn_51.FillWeight = 30.03301f;
			this.dataGridViewTextBoxColumn_51.HeaderText = "Статус";
			this.dataGridViewTextBoxColumn_51.Name = "statusNameDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_51.ReadOnly = true;
			this.dataGridViewTextBoxColumn_51.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn_52.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_52.DataPropertyName = "Comment";
			this.dataGridViewTextBoxColumn_52.FillWeight = 69.967f;
			this.dataGridViewTextBoxColumn_52.HeaderText = "Комментарий";
			this.dataGridViewTextBoxColumn_52.Name = "commentStatusDgvColumn";
			this.dataGridViewTextBoxColumn_52.ReadOnly = true;
			this.bindingSource_1.DataMember = "vTC_DocStatus";
			this.bindingSource_1.DataSource = this.class10_0;
			this.toolStrip_1.Dock = DockStyle.Left;
			this.toolStrip_1.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_2,
				this.toolStripButton_3,
				this.toolStripButton_4
			});
			this.toolStrip_1.Location = new System.Drawing.Point(3, 3);
			this.toolStrip_1.Name = "toolStripDocStatus";
			this.toolStrip_1.Size = new Size(24, 142);
			this.toolStrip_1.TabIndex = 0;
			this.toolStrip_1.Text = "toolStrip1";
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.ElementAdd;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnAddDocStatus";
			this.toolStripButton_2.Size = new Size(21, 20);
			this.toolStripButton_2.Text = "Новый статус";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = Resources.ElementEdit;
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnEditDocStatus";
			this.toolStripButton_3.Size = new Size(21, 20);
			this.toolStripButton_3.Text = "Редактировать статус";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = Resources.ElementDel;
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnDelDocStatus";
			this.toolStripButton_4.Size = new Size(21, 20);
			this.toolStripButton_4.Text = "Удалить статус";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.contextMenuStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem_0,
				this.toolStripMenuItem_1,
				this.toolStripMenuItem_2,
				this.toolStripSeparator_3,
				this.toolStripMenuItem_3
			});
			this.contextMenuStrip_0.Name = "contextMenuRequest";
			this.contextMenuStrip_0.Size = new Size(236, 98);
			this.contextMenuStrip_0.Opening += this.contextMenuStrip_0_Opening;
			this.toolStripMenuItem_0.Image = Resources.ElementAdd;
			this.toolStripMenuItem_0.Name = "toolMenuAddRequest";
			this.toolStripMenuItem_0.Size = new Size(235, 22);
			this.toolStripMenuItem_0.Text = "Добавить";
			this.toolStripMenuItem_0.Click += this.toolStripMenuItem_0_Click;
			this.toolStripMenuItem_1.Image = Resources.ElementEdit;
			this.toolStripMenuItem_1.Name = "toolMenuEditRequest";
			this.toolStripMenuItem_1.Size = new Size(235, 22);
			this.toolStripMenuItem_1.Text = "Редактировать";
			this.toolStripMenuItem_1.Click += this.toolStripMenuItem_1_Click;
			this.toolStripMenuItem_2.Image = Resources.ElementDel;
			this.toolStripMenuItem_2.Name = "toolMenuDelRequest";
			this.toolStripMenuItem_2.Size = new Size(235, 22);
			this.toolStripMenuItem_2.Text = "Удалить";
			this.toolStripMenuItem_2.Click += this.toolStripMenuItem_2_Click;
			this.toolStripSeparator_3.Name = "toolStripSeparator4";
			this.toolStripSeparator_3.Size = new Size(232, 6);
			this.toolStripMenuItem_3.Image = Resources.mergedialog;
			this.toolStripMenuItem_3.Name = "toolMenuMergeRequest";
			this.toolStripMenuItem_3.Size = new Size(235, 22);
			this.toolStripMenuItem_3.Text = "Привязать к основной заявке";
			this.toolStripMenuItem_3.Click += this.toolStripMenuItem_3_Click;
			this.toolStripMenuItem_7.Name = "toolBtnAddMail";
			this.toolStripMenuItem_7.Size = new Size(177, 22);
			this.toolStripMenuItem_7.Text = "Письмо";
			this.toolStripMenuItem_7.Click += this.toolStripMenuItem_7_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(905, 456);
			base.Controls.Add(this.splitContainer_0);
			base.Controls.Add(this.toolStrip_0);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FormTechConnectionRequest";
			this.Text = "Заявки на тех присоединение";
			base.FormClosed += this.FormTechConnectionRequest_FormClosed;
			base.Load += this.FormTechConnectionRequest_Load;
			base.Shown += this.FormTechConnectionRequest_Shown;
			((ISupportInitialize)this.class10_0).EndInit();
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel1.PerformLayout();
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.ResumeLayout(false);
			this.vuatRjiaYu.ResumeLayout(false);
			this.vuatRjiaYu.PerformLayout();
			this.splitContainer_1.Panel1.ResumeLayout(false);
			this.splitContainer_1.Panel2.ResumeLayout(false);
			this.splitContainer_1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			this.tabControl_0.ResumeLayout(false);
			this.tabPage_1.ResumeLayout(false);
			this.tabPage_1.PerformLayout();
			this.splitContainer_2.Panel1.ResumeLayout(false);
			this.splitContainer_2.Panel2.ResumeLayout(false);
			this.splitContainer_2.Panel2.PerformLayout();
			this.splitContainer_2.ResumeLayout(false);
			((ISupportInitialize)this.dataGridViewExcelFilter_2).EndInit();
			((ISupportInitialize)this.bindingSource_2).EndInit();
			((ISupportInitialize)this.dataGridViewExcelFilter_3).EndInit();
			((ISupportInitialize)this.bindingSource_3).EndInit();
			this.toolStrip_3.ResumeLayout(false);
			this.toolStrip_3.PerformLayout();
			this.toolStrip_2.ResumeLayout(false);
			this.toolStrip_2.PerformLayout();
			this.tabPage_2.ResumeLayout(false);
			this.tabPage_2.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_4).EndInit();
			((ISupportInitialize)this.bindingSource_4).EndInit();
			this.toolStrip_4.ResumeLayout(false);
			this.toolStrip_4.PerformLayout();
			this.tabPage_0.ResumeLayout(false);
			this.tabPage_0.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_1).EndInit();
			((ISupportInitialize)this.bindingSource_1).EndInit();
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			this.contextMenuStrip_0.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		internal static void xiynaJjICm98btSA64e(Form form_0, bool bool_0)
		{
			form_0.Dispose(bool_0);
		}

		private int int_0;

		private int int_1;

		private Class10 class10_0;

		private ToolStrip toolStrip_0;

		private SplitContainer splitContainer_0;

		private ToolStripButton dcetsmBvMy;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton WxitAfAdMe;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripButton toolStripButton_1;

		private SplitContainer splitContainer_1;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private BindingSource bindingSource_0;

		private TabControl tabControl_0;

		private TabPage tabPage_0;

		private ToolStrip toolStrip_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripButton toolStripButton_3;

		private ToolStripButton toolStripButton_4;

		private BindingSource bindingSource_1;

		private DataGridViewExcelFilter dataGridViewExcelFilter_1;

		private TabPage tabPage_1;

		private ToolStrip toolStrip_2;

		private ToolStripButton toolStripButton_5;

		private ToolStripButton toolStripButton_6;

		private BindingSource bindingSource_2;

		private DataGridViewExcelFilter dataGridViewExcelFilter_2;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripButton toolStripButton_7;

		private ToolStripTextBox toolStripTextBox_0;

		private ToolStripButton toolStripButton_8;

		private ToolStripButton toolStripButton_9;

		private DateTimePicker dateTimePicker_0;

		private System.Windows.Forms.Label label_0;

		private DateTimePicker dateTimePicker_1;

		private System.Windows.Forms.Label label_1;

		private ToolStrip vuatRjiaYu;

		private ToolStripButton toolStripButton_10;

		private ToolStripButton toolStripButton_11;

		private SplitContainer splitContainer_2;

		private DataGridViewExcelFilter dataGridViewExcelFilter_3;

		private BindingSource bindingSource_3;

		private ToolStrip toolStrip_3;

		private ToolStripButton toolStripButton_12;

		private ToolStripButton toolStripButton_13;

		private ToolStripButton toolStripButton_14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

		private ToolStripButton toolStripButton_15;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripButton toolStripButton_16;

		private TabPage tabPage_2;

		private ToolStrip toolStrip_4;

		private ToolStripButton toolStripButton_17;

		private ToolStripButton toolStripButton_18;

		private ToolStripButton toolStripButton_19;

		private DataGridViewExcelFilter dataGridViewExcelFilter_4;

		private BindingSource bindingSource_4;

		private ContextMenuStrip contextMenuStrip_0;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripSeparator toolStripSeparator_3;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripSeparator toolStripSeparator_4;

		private ToolStripButton toolStripButton_20;

		private ToolStripSeparator toolStripSeparator_5;

		private ToolStripButton toolStripButton_21;

		private ToolStripDropDownButton toolStripDropDownButton_0;

		private ToolStripMenuItem toolStripMenuItem_4;

		private ToolStripSeparator toolStripSeparator_6;

		private ToolStripMenuItem toolStripMenuItem_5;

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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_22;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_23;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_24;

		private System.Windows.Forms.CheckBox checkBox_0;

		private ToolStripMenuItem toolStripMenuItem_6;

		private ToolStripButton toolStripButton_22;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_25;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_26;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_27;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_28;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_29;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_30;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_31;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_32;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_33;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_34;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_35;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_36;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_37;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_38;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_39;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_40;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_41;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_1;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_42;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_43;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_44;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_45;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_3;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_4;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_5;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_46;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_7;

		private DataGridViewFilterTextBoxColumn CuHvdgLiOk;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_47;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_48;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_49;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_50;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_51;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_52;

		private ToolStripMenuItem toolStripMenuItem_7;
	}
}
