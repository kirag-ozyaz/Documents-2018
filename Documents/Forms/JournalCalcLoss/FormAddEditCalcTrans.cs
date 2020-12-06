using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using Documents.Forms.JournalCalcLoss.Report;
using Documents.Forms.TechnologicalConnection;
using Documents.Properties;
using FormLbr;
using FormLbr.Classes;

namespace Documents.Forms.JournalCalcLoss
{
	public partial class FormAddEditCalcTrans : FormBase
	{
		public int Id
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		public FormAddEditCalcTrans()
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			
			this.method_32();
			this.method_0();
		}

		public FormAddEditCalcTrans(int id, int typeCalc, int idAbn = -1, int idAbnObj = -1)
		{
			
			this.int_0 = -1;
			this.int_1 = -1;
			this.int_2 = -1;
			this.int_3 = -1;
			this.int_4 = -1;
			
			this.method_32();
			this.int_0 = id;
			this.int_1 = typeCalc;
			this.int_4 = idAbn;
			this.int_2 = idAbn;
			this.int_3 = idAbnObj;
			this.method_0();
		}

		private void method_0()
		{
			this.textBox_7.TextChanged += this.textBox_44_TextChanged;
			this.textBox_7.KeyPress += this.textBox_44_KeyPress;
			this.textBox_8.TextChanged += this.textBox_44_TextChanged;
			this.textBox_8.KeyPress += this.textBox_44_KeyPress;
			this.textBox_11.TextChanged += this.textBox_44_TextChanged;
			this.textBox_11.KeyPress += this.textBox_44_KeyPress;
			this.textBox_23.TextChanged += this.textBox_44_TextChanged;
			this.textBox_23.KeyPress += this.textBox_44_KeyPress;
			this.textBox_51.TextChanged += this.textBox_44_TextChanged;
			this.textBox_51.KeyPress += this.textBox_44_KeyPress;
			this.textBox_20.TextChanged += this.textBox_44_TextChanged;
			this.textBox_20.KeyPress += this.textBox_44_KeyPress;
			this.textBox_17.TextChanged += this.textBox_44_TextChanged;
			this.textBox_17.KeyPress += this.textBox_44_KeyPress;
			this.textBox_35.TextChanged += this.textBox_44_TextChanged;
			this.textBox_35.KeyPress += this.textBox_44_KeyPress;
			this.textBox_14.TextChanged += this.textBox_44_TextChanged;
			this.textBox_14.KeyPress += this.textBox_44_KeyPress;
			this.textBox_32.TextChanged += this.textBox_44_TextChanged;
			this.textBox_32.KeyPress += this.textBox_44_KeyPress;
			this.textBox_29.TextChanged += this.textBox_44_TextChanged;
			this.textBox_29.KeyPress += this.textBox_44_KeyPress;
			this.textBox_26.TextChanged += this.textBox_44_TextChanged;
			this.textBox_26.KeyPress += this.textBox_44_KeyPress;
			this.textBox_44.TextChanged += this.textBox_44_TextChanged;
			this.textBox_44.KeyPress += this.textBox_44_KeyPress;
		}

		private void textBox_44_KeyPress(object sender, KeyPressEventArgs e)
		{
			NumberFormatInfo numberFormat = CultureInfo.CurrentCulture.NumberFormat;
			string numberDecimalSeparator = numberFormat.NumberDecimalSeparator;
			string text = numberFormat.NumberGroupSeparator;
			string negativeSign = numberFormat.NegativeSign;
			if (text == '\u00a0'.ToString())
			{
				text = " ";
			}
			string text2 = e.KeyChar.ToString();
			if (!char.IsDigit(e.KeyChar) && !text2.Equals(numberDecimalSeparator) && !text2.Equals(text) && !text2.Equals(negativeSign) && e.KeyChar != '\b' && (!this.bool_0 || e.KeyChar != ' '))
			{
				e.Handled = true;
			}
		}

		private void textBox_44_TextChanged(object sender, EventArgs e)
		{
			TabPage tabPage_ = null;
			if (((TextBox)sender).Tag != null && ((TextBox)sender).Parent is TabPage)
			{
				tabPage_ = (TabPage)((TextBox)sender).Parent;
			}
			try
			{
				this.method_13(tabPage_);
				this.method_14();
				this.method_15();
				this.method_16();
				this.method_17();
				this.method_18();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}

		private void method_1(object sender, EventArgs e)
		{
			TabPage tabPage_ = null;
			if (((TextBox)sender).Tag != null && ((TextBox)sender).Parent is TabPage)
			{
				tabPage_ = (TabPage)((TextBox)sender).Parent;
			}
			try
			{
				this.method_13(tabPage_);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}

		private void FormAddEditCalcTrans_Load(object sender, EventArgs e)
		{
			this.dataGridView_0.Rows.Add();
			this.dataGridView_1.Rows.Add();
			if (this.Id == -1)
			{
				this.method_2();
				return;
			}
			base.SelectSqlData(this.class498_0.tUser, true, "", null, false, 0);
			base.SelectSqlData(this.class498_0.tJ_CalcLoss, true, "where id = " + this.int_0.ToString(), null, false, 0);
			if (this.class498_0.tJ_CalcLoss.Rows.Count > 0)
			{
				if (this.class498_0.tJ_CalcLoss.Rows[0]["idAbn"] != DBNull.Value)
				{
					this.textBox_1.Tag = (this.int_2 = Convert.ToInt32(this.class498_0.tJ_CalcLoss.Rows[0]["idAbn"]));
					base.SelectSqlData(this.class498_0.tAbn, true, "where id = " + this.int_2.ToString(), null, false, 0);
					if (this.class498_0.tAbn.Rows.Count > 0)
					{
						this.textBox_1.Text = this.class498_0.tAbn.Rows[0]["Name"].ToString();
					}
					if (this.class498_0.tJ_CalcLoss.Rows[0]["idAbnObj"] != DBNull.Value)
					{
						this.comboBox_1.Tag = (this.int_3 = Convert.ToInt32(this.class498_0.tJ_CalcLoss.Rows[0]["idAbnObj"]));
					}
					this.method_10();
				}
				if (this.class498_0.tJ_CalcLoss.Rows[0]["idAbnBalance"] != DBNull.Value)
				{
					this.textBox_2.Tag = (this.int_4 = Convert.ToInt32(this.class498_0.tJ_CalcLoss.Rows[0]["idAbnBalance"]));
					base.SelectSqlData(this.class498_0.tAbn, true, "where id = " + this.int_4.ToString(), null, false, 0);
					if (this.class498_0.tAbn.Rows.Count > 0)
					{
						this.textBox_2.Text = this.class498_0.tAbn.Rows[0]["Name"].ToString();
					}
				}
				base.SelectSqlData(this.class498_0, this.class498_0.tJ_CalcLossTrans, true, " where idCalc = " + this.int_0.ToString() + " order by numTrans");
				if (this.class498_0.tJ_CalcLossTrans.Rows.Count == 0)
				{
					this.method_3();
				}
				else
				{
					this.method_6();
				}
				base.SelectSqlData(this.class498_0, this.class498_0.tJ_CalcLossTransHH, true, " where idCalc = " + this.int_0.ToString() + " order by id");
				this.method_25();
				this.method_26();
				return;
			}
			this.method_2();
		}

		private void method_2()
		{
			base.SelectSqlData(this.class498_0.tUser, true, "where Login = SYSTEM_USER", null, false, 0);
			this.comboBox_0.SelectedIndex = -1;
			base.SelectSqlData(this.class498_0.tR_Classifier, true, "where id = " + this.int_1.ToString(), null, false, 0);
			DataRow dataRow = this.class498_0.tJ_CalcLoss.NewRow();
			dataRow["typeCalc"] = this.int_1;
			if (this.class498_0.tR_Classifier.Rows.Count > 0)
			{
				dataRow["nameCalc"] = this.class498_0.tR_Classifier.Rows[0]["name"];
			}
			dataRow["idAbnObj"] = -1;
			dataRow["idAbnBalance"] = -1;
			dataRow["DateCalc"] = DateTime.Now.Date;
			if (this.class498_0.tUser.Rows.Count > 0)
			{
				dataRow["idowner"] = this.class498_0.tUser.Rows[0]["idUser"];
			}
			dataRow["isActive"] = true;
			dataRow["deleted"] = false;
			dataRow["tpName"] = "Источник питания: ";
			this.class498_0.tJ_CalcLoss.Rows.Add(dataRow);
			this.method_4();
			this.method_3();
		}

		private void method_3()
		{
			this.textBox_14.Text = 0.6.ToString();
			this.textBox_29.Text = 1.33.ToString();
			this.textBox_26.Text = 0.99.ToString();
		}

		private void method_4()
		{
			if (this.int_2 != -1)
			{
				this.class498_0.tJ_CalcLoss.Rows[0]["idAbn"] = this.int_2;
				base.SelectSqlData(this.class498_0.tAbn, true, "where id = " + this.int_2.ToString(), null, false, 0);
				if (this.class498_0.tAbn.Rows.Count > 0)
				{
					this.textBox_1.Text = this.class498_0.tAbn.Rows[0]["Name"].ToString();
				}
			}
			if (this.int_4 != -1)
			{
				this.class498_0.tJ_CalcLoss.Rows[0]["idAbnBalance"] = this.int_4;
				base.SelectSqlData(this.class498_0.tAbn, true, "where id = " + this.int_4.ToString(), null, false, 0);
				if (this.class498_0.tAbn.Rows.Count > 0)
				{
					this.textBox_2.Text = this.class498_0.tAbn.Rows[0]["Name"].ToString();
				}
			}
			if (this.int_3 != -1)
			{
				this.class498_0.tJ_CalcLoss.Rows[0]["idAbnObj"] = this.int_3;
			}
			this.method_10();
			this.method_5();
		}

		private void method_5()
		{
			if (string.IsNullOrEmpty(this.textBox_3.Text))
			{
				base.SelectSqlData(this.class498_0.vL_SchmAbn, true, "where idAbn = " + this.int_2.ToString() + " or idAbnObj = " + this.int_3.ToString(), null, false, 0);
				foreach (DataRow dataRow in this.class498_0.vL_SchmAbn)
				{
					if (!string.IsNullOrEmpty(this.textBox_3.Text))
					{
						TextBox textBox = this.textBox_3;
						textBox.Text += ", ";
					}
					TextBox textBox2 = this.textBox_3;
					textBox2.Text += dataRow["SchmObjName"].ToString();
				}
			}
		}

		private void method_6()
		{
			int num = 0;
			foreach (DataRow dataRow in this.class498_0.tJ_CalcLossTrans)
			{
				TabPage tabPage;
				if (num == 0)
				{
					tabPage = this.tabPage_2;
				}
				else
				{
					tabPage = this.method_27();
				}
				tabPage.Tag = dataRow["makeupTrans"];
				base.SelectSqlData(this.class498_0.vR_Transformer, true, "where id= " + dataRow["makeupTrans"].ToString(), null, false, 0);
				if (this.class498_0.vR_Transformer.Rows.Count > 0)
				{
					TextBox textBox = this.method_28(tabPage, "MakeupTrans");
					if (textBox != null)
					{
						textBox.Text = this.class498_0.vR_Transformer.Rows[0]["FullName"].ToString();
					}
				}
				this.method_7(tabPage, dataRow, "RatedPower");
				this.method_7(tabPage, dataRow, "NoLoadLoss");
				this.method_7(tabPage, dataRow, "ShortCircuitLoss");
				this.method_7(tabPage, dataRow, "Consumption");
				this.method_7(tabPage, dataRow, "RatedVoltage");
				this.method_7(tabPage, dataRow, "MiddleVoltage");
				this.method_7(tabPage, dataRow, "Period");
				this.method_7(tabPage, dataRow, "CoeffPowerReactive");
				this.method_7(tabPage, dataRow, "SquareCoeffFromGraph");
				this.method_7(tabPage, dataRow, "CoeffDifference");
				this.method_7(tabPage, dataRow, "LossElectrHH");
				if (Convert.ToInt32(dataRow["numTrans"]) == 1)
				{
					this.textBox_35.Text = dataRow["ActiveResistance"].ToString();
					this.textBox_44.Text = dataRow["LoadAverage"].ToString();
					this.textBox_38.Text = this.method_29(Convert.ToDecimal(dataRow["LoadPowerLoss"]), 5).ToString();
					this.textBox_41.Text = this.method_29(Convert.ToDecimal(dataRow["LoadLosses"]), 5).ToString();
					this.textBox_49.Text = this.method_29(Convert.ToDecimal(dataRow["CoeffLosses"]), 3).ToString();
				}
				num++;
			}
		}

		private void method_7(TabPage tabPage_3, DataRow dataRow_0, string string_0)
		{
			TextBox textBox = this.method_28(tabPage_3, string_0);
			if (textBox != null)
			{
				textBox.Text = dataRow_0[string_0].ToString();
			}
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			FormTechConnectionAddAbn formTechConnectionAddAbn = new FormTechConnectionAddAbn(this.int_2, this.int_3, true);
			formTechConnectionAddAbn.ShowForm += this.method_9;
			formTechConnectionAddAbn.SqlSettings = this.SqlSettings;
			formTechConnectionAddAbn.MdiParent = base.MdiParent;
			formTechConnectionAddAbn.FormClosed += this.method_8;
			formTechConnectionAddAbn.Show();
		}

		private void method_8(object sender, FormClosedEventArgs e)
		{
			FormTechConnectionAddAbn formTechConnectionAddAbn = (FormTechConnectionAddAbn)sender;
			if (formTechConnectionAddAbn.DialogResult == DialogResult.OK)
			{
				this.textBox_1.Text = formTechConnectionAddAbn.AbnName;
				if (string.IsNullOrEmpty(this.textBox_2.Text))
				{
					this.textBox_2.Text = formTechConnectionAddAbn.AbnName;
					this.textBox_2.Tag = (this.int_4 = formTechConnectionAddAbn.IdAbn);
					this.class498_0.tJ_CalcLoss.Rows[0]["idAbnBalance"] = this.int_4;
				}
				this.textBox_1.Tag = (this.int_2 = formTechConnectionAddAbn.IdAbn);
				this.class498_0.tJ_CalcLoss.Rows[0]["idAbn"] = this.int_2;
				this.comboBox_1.Tag = (this.int_3 = formTechConnectionAddAbn.GetIdAbnObj());
				this.class498_0.tJ_CalcLoss.Rows[0]["idAbnObj"] = this.int_3;
				this.method_10();
				this.method_5();
				this.method_26();
			}
		}

		private FormBase method_9(object object_0, ShowFormEventArgs showFormEventArgs_0)
		{
			return this.OnShowForm(showFormEventArgs_0);
		}

		private void method_10()
		{
			Class498.Class502 @class = new Class498.Class502();
			base.SelectSqlData(@class, true, " where id = " + this.int_2.ToString(), null, false, 0);
			if (@class.Rows.Count > 0)
			{
				this.comboBox_1.SelectedValueChanged -= this.comboBox_1_SelectedValueChanged;
				int num = Convert.ToInt32(@class.Rows[0]["typeAbn"]);
				Class498.Class507 class2 = new Class498.Class507();
				DataColumn dataColumn = new DataColumn("AddressFL");
				dataColumn.Expression = "street + ', д. ' + houseall + ', кв. ' + name";
				class2.Columns.Add(dataColumn);
				dataColumn = new DataColumn("AddressUL");
				dataColumn.Expression = "street + ', д. ' + houseall";
				class2.Columns.Add(dataColumn);
				base.SelectSqlData(class2, true, "where idAbn = " + this.int_2.ToString() + " order by name", null, false, 0);
				this.comboBox_1.ValueMember = "id";
				this.comboBox_1.DataSource = class2;
				if (num != 206 && num != 253)
				{
					if (num != 1037)
					{
						this.comboBox_1.DisplayMember = "name";
						goto IL_149;
					}
				}
				this.comboBox_1.DisplayMember = "AddressFL";
				IL_149:
				this.comboBox_1.SelectedValue = this.int_3;
				this.comboBox_1.SelectedValueChanged += this.comboBox_1_SelectedValueChanged;
				return;
			}
			this.comboBox_1.Items.Clear();
		}

		private void comboBox_1_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.comboBox_1.SelectedValue != null || this.comboBox_1.SelectedValue != DBNull.Value)
			{
				this.comboBox_1.Tag = (this.int_3 = Convert.ToInt32(this.comboBox_1.SelectedValue));
			}
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			FormTechConnectionAddAbn formTechConnectionAddAbn = new FormTechConnectionAddAbn(this.int_4, -1, true);
			formTechConnectionAddAbn.ShowForm += this.method_9;
			formTechConnectionAddAbn.SqlSettings = this.SqlSettings;
			formTechConnectionAddAbn.MdiParent = base.MdiParent;
			formTechConnectionAddAbn.FormClosed += this.method_11;
			formTechConnectionAddAbn.Show();
		}

		private void method_11(object sender, FormClosedEventArgs e)
		{
			FormTechConnectionAddAbn formTechConnectionAddAbn = (FormTechConnectionAddAbn)sender;
			if (formTechConnectionAddAbn.DialogResult == DialogResult.OK)
			{
				this.textBox_2.Text = formTechConnectionAddAbn.AbnName;
				this.textBox_2.Tag = (this.int_4 = formTechConnectionAddAbn.IdAbn);
				this.class498_0.tJ_CalcLoss.Rows[0]["idAbnBalance"] = this.int_4;
				this.method_26();
			}
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			Form71 form = new Form71();
			form.Tag = ((Button)sender).Parent;
			form.ShowForm += this.method_9;
			form.SqlSettings = this.SqlSettings;
			form.MdiParent = base.MdiParent;
			form.FormClosed += this.method_12;
			form.Show();
		}

		private void method_12(object sender, FormClosedEventArgs e)
		{
			TabPage tabPage = (TabPage)((Form)sender).Tag;
			if (((Form)sender).DialogResult == DialogResult.OK)
			{
				tabPage.Tag = ((Form71)sender).Id;
				TextBox textBox = this.method_28(tabPage, "MakeupTrans");
				if (textBox != null)
				{
					textBox.Text = ((Form71)sender).MakeupTrans;
				}
				textBox = this.method_28(tabPage, "RatedPower");
				if (textBox != null)
				{
					if (((Form71)sender).RatedPower == null)
					{
						textBox.Text = null;
					}
					else
					{
						textBox.Text = ((Form71)sender).RatedPower.ToString();
					}
				}
				textBox = this.method_28(tabPage, "NoLoadLoss");
				if (textBox != null)
				{
					if (((Form71)sender).NoLoadLoss == null)
					{
						textBox.Text = null;
					}
					else
					{
						textBox.Text = this.method_29(Convert.ToDecimal(((Form71)sender).NoLoadLoss), 2).ToString();
					}
				}
				textBox = this.method_28(tabPage, "ShortCircuitLoss");
				if (textBox != null)
				{
					if (((Form71)sender).ShortCircuitLoss == null)
					{
						textBox.Text = null;
					}
					else
					{
						textBox.Text = this.method_29(Convert.ToDecimal(((Form71)sender).ShortCircuitLoss), 2).ToString();
					}
				}
				textBox = this.method_28(tabPage, "RatedVoltage");
				if (textBox != null)
				{
					if (((Form71)sender).method_0() == null)
					{
						textBox.Text = null;
					}
					else
					{
						textBox.Text = this.method_29(Convert.ToDecimal(((Form71)sender).method_0()), 2).ToString();
					}
				}
				textBox = this.method_28(tabPage, "MiddleVoltage");
				if (textBox != null)
				{
					if (((Form71)sender).method_0() == null)
					{
						textBox.Text = null;
						return;
					}
					textBox.Text = this.method_29(Convert.ToDecimal(((Form71)sender).method_0()), 2).ToString();
				}
			}
		}

		private void method_13(TabPage tabPage_3)
		{
			if (tabPage_3 != null)
			{
				TextBox textBox = this.method_28(tabPage_3, "NoLoadLoss");
				TextBox textBox2 = this.method_28(tabPage_3, "Period");
				TextBox textBox3 = this.method_28(tabPage_3, "MiddleVoltage");
				TextBox textBox4 = this.method_28(tabPage_3, "RatedVoltage");
				TextBox textBox5 = this.method_28(tabPage_3, "LossElectrHH");
				if (textBox != null && textBox2 != null && textBox3 != null && textBox4 != null && textBox5 != null)
				{
					if (!string.IsNullOrEmpty(textBox.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
					{
						textBox5.Text = this.method_29(Convert.ToDecimal(Convert.ToDouble(textBox.Text) * Convert.ToDouble(textBox2.Text) * Math.Pow(Convert.ToDouble(textBox3.Text) / Convert.ToDouble(textBox4.Text), 2.0)), 0).ToString();
						return;
					}
					textBox5.Text = "";
				}
			}
		}

		private void method_14()
		{
			if (!string.IsNullOrEmpty(this.textBox_11.Text) && !string.IsNullOrEmpty(this.textBox_51.Text) && !string.IsNullOrEmpty(this.textBox_7.Text))
			{
				this.textBox_35.Text = this.method_29(0.001m * Convert.ToDecimal(this.textBox_11.Text) * Convert.ToDecimal(Math.Pow(Convert.ToDouble(this.textBox_51.Text), 2.0) / Math.Pow(Convert.ToDouble(this.textBox_7.Text), 2.0)), 5).ToString();
				return;
			}
			this.textBox_35.Text = null;
		}

		private void method_15()
		{
			if (!string.IsNullOrEmpty(this.textBox_20.Text) && !string.IsNullOrEmpty(this.textBox_17.Text))
			{
				this.textBox_44.Text = this.method_29(0.001m * Convert.ToDecimal(this.textBox_20.Text) / Convert.ToDecimal(this.textBox_17.Text), 5).ToString();
				return;
			}
			this.textBox_44.Text = null;
		}

		private void method_16()
		{
			if (!string.IsNullOrEmpty(this.textBox_44.Text) && !string.IsNullOrEmpty(this.textBox_14.Text) && !string.IsNullOrEmpty(this.textBox_11.Text) && !string.IsNullOrEmpty(this.textBox_32.Text) && !string.IsNullOrEmpty(this.textBox_35.Text))
			{
				this.textBox_38.Text = this.method_29(1000m * Convert.ToDecimal(Math.Pow(Convert.ToDouble(this.textBox_44.Text), 2.0)) * Convert.ToDecimal(this.textBox_35.Text) * (1m + Convert.ToDecimal(this.textBox_14.Text) * Convert.ToDecimal(this.textBox_14.Text)) / Convert.ToDecimal(Math.Pow(Convert.ToDouble(this.textBox_23.Text), 2.0)), 5).ToString();
				return;
			}
			this.textBox_38.Text = null;
		}

		private void method_17()
		{
			if (!string.IsNullOrEmpty(this.textBox_29.Text) && !string.IsNullOrEmpty(this.textBox_26.Text) && !string.IsNullOrEmpty(this.textBox_38.Text) && !string.IsNullOrEmpty(this.textBox_17.Text))
			{
				this.textBox_41.Text = this.method_29(Convert.ToDecimal(this.textBox_26.Text) * Convert.ToDecimal(this.textBox_38.Text) * Convert.ToDecimal(this.textBox_17.Text) * Convert.ToDecimal(this.textBox_29.Text), 5).ToString();
				return;
			}
			this.textBox_41.Text = null;
		}

		private void method_18()
		{
			if (!string.IsNullOrEmpty(this.textBox_41.Text) && !string.IsNullOrEmpty(this.textBox_20.Text))
			{
				this.textBox_49.Text = this.method_29(100m * Convert.ToDecimal(this.textBox_41.Text) / Convert.ToDecimal(this.textBox_20.Text), 3).ToString();
				return;
			}
			this.textBox_49.Text = null;
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			if (this.method_19())
			{
				base.DialogResult = DialogResult.OK;
				base.Close();
			}
		}

		private bool method_19()
		{
			if (this.method_23())
			{
				if (this.Id == -1)
				{
					this.class498_0.tJ_CalcLoss.Rows[0].EndEdit();
					this.Id = base.InsertSqlDataOneRow(this.class498_0, this.class498_0.tJ_CalcLoss);
					if (this.Id >= 0 && this.method_24() && this.method_20())
					{
						return true;
					}
				}
				else
				{
					this.class498_0.tJ_CalcLoss.Rows[0].EndEdit();
					if (base.UpdateSqlData(this.class498_0, this.class498_0.tJ_CalcLoss) && this.method_24() && this.method_20())
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool method_20()
		{
			int num = 0;
			foreach (object obj in this.tabControl_1.TabPages)
			{
				TabPage tabPage = (TabPage)obj;
				while (this.class498_0.tJ_CalcLossTrans.Rows.Count <= num)
				{
					DataRow dataRow = this.class498_0.tJ_CalcLossTrans.NewRow();
					dataRow["idCalc"] = this.int_0;
					dataRow["makeupTrans"] = -1;
					this.class498_0.tJ_CalcLossTrans.Rows.Add(dataRow);
				}
				if (this.class498_0.tJ_CalcLossTrans.Rows.Count > num)
				{
					this.class498_0.tJ_CalcLossTrans.Rows[num]["idCalc"] = this.int_0;
					this.class498_0.tJ_CalcLossTrans.Rows[num]["numTrans"] = num + 1;
					if (tabPage.Tag == null)
					{
						this.class498_0.tJ_CalcLossTrans.Rows[num]["MakeupTrans"] = -1;
					}
					else
					{
						this.class498_0.tJ_CalcLossTrans.Rows[num]["MakeupTrans"] = tabPage.Tag;
					}
					this.method_22(tabPage, this.class498_0.tJ_CalcLossTrans.Rows[num], "RatedPower");
					this.method_22(tabPage, this.class498_0.tJ_CalcLossTrans.Rows[num], "NoLoadLoss");
					this.method_22(tabPage, this.class498_0.tJ_CalcLossTrans.Rows[num], "ShortCircuitLoss");
					this.method_22(tabPage, this.class498_0.tJ_CalcLossTrans.Rows[num], "Consumption");
					this.method_22(tabPage, this.class498_0.tJ_CalcLossTrans.Rows[num], "RatedVoltage");
					this.method_22(tabPage, this.class498_0.tJ_CalcLossTrans.Rows[num], "MiddleVoltage");
					this.method_22(tabPage, this.class498_0.tJ_CalcLossTrans.Rows[num], "Period");
					this.method_22(tabPage, this.class498_0.tJ_CalcLossTrans.Rows[num], "CoeffPowerReactive");
					this.method_22(tabPage, this.class498_0.tJ_CalcLossTrans.Rows[num], "SquareCoeffFromGraph");
					this.method_22(tabPage, this.class498_0.tJ_CalcLossTrans.Rows[num], "CoeffDifference");
					this.method_22(tabPage, this.class498_0.tJ_CalcLossTrans.Rows[num], "LossElectrHH");
					if (num == 0)
					{
						if (string.IsNullOrEmpty(this.textBox_35.Text))
						{
							this.class498_0.tJ_CalcLossTrans.Rows[num]["ActiveResistance"] = DBNull.Value;
						}
						else
						{
							this.class498_0.tJ_CalcLossTrans.Rows[num]["ActiveResistance"] = Convert.ToDecimal(this.textBox_35.Text);
						}
						if (string.IsNullOrEmpty(this.textBox_44.Text))
						{
							this.class498_0.tJ_CalcLossTrans.Rows[num]["LoadAverage"] = DBNull.Value;
						}
						else
						{
							this.class498_0.tJ_CalcLossTrans.Rows[num]["LoadAverage"] = Convert.ToDecimal(this.textBox_44.Text);
						}
						if (string.IsNullOrEmpty(this.textBox_38.Text))
						{
							this.class498_0.tJ_CalcLossTrans.Rows[num]["LoadPowerLoss"] = DBNull.Value;
						}
						else
						{
							this.class498_0.tJ_CalcLossTrans.Rows[num]["LoadPowerLoss"] = Convert.ToDecimal(this.textBox_38.Text);
						}
						if (string.IsNullOrEmpty(this.textBox_41.Text))
						{
							this.class498_0.tJ_CalcLossTrans.Rows[num]["LoadLosses"] = DBNull.Value;
						}
						else
						{
							this.class498_0.tJ_CalcLossTrans.Rows[num]["LoadLosses"] = Convert.ToDecimal(this.textBox_41.Text);
						}
						if (string.IsNullOrEmpty(this.textBox_49.Text))
						{
							this.class498_0.tJ_CalcLossTrans.Rows[num]["CoeffLosses"] = DBNull.Value;
						}
						else
						{
							this.class498_0.tJ_CalcLossTrans.Rows[num]["CoeffLosses"] = Convert.ToDecimal(this.textBox_49.Text);
						}
					}
					this.class498_0.tJ_CalcLossTrans.Rows[num].EndEdit();
				}
				num++;
			}
			for (int i = this.tabControl_1.TabPages.Count; i < this.class498_0.tJ_CalcLossTrans.Rows.Count; i++)
			{
				this.class498_0.tJ_CalcLossTrans.Rows[i].Delete();
			}
			if (base.InsertSqlData(this.class498_0, this.class498_0.tJ_CalcLossTrans) && base.UpdateSqlData(this.class498_0, this.class498_0.tJ_CalcLossTrans) && base.DeleteSqlData(this.class498_0, this.class498_0.tJ_CalcLossTrans))
			{
				base.SelectSqlData(this.class498_0, this.class498_0.tJ_CalcLossTrans, true, " where idCalc = " + this.int_0.ToString() + " order by numTrans");
				return this.method_21();
			}
			return false;
		}

		private bool method_21()
		{
			Class498.Class515 @class = new Class498.Class515();
			base.SelectSqlData(@class, true, "where idCalc = " + this.int_0.ToString() + " order by numTrans", null, false, 0);
			if (@class.Rows.Count != this.tabControl_1.TabPages.Count)
			{
				MessageBox.Show("Ошибка сохранения расчета потерь холостого хода");
				return false;
			}
			if (this.bool_1)
			{
				int num = 0;
				using (IEnumerator enumerator = @class.Rows.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DataRow dataRow = (DataRow)obj;
						while (this.class498_0.tJ_CalcLossTransHH.Rows.Count <= num)
						{
							DataRow dataRow2 = this.class498_0.tJ_CalcLossTransHH.NewRow();
							dataRow2["idCalc"] = this.int_0;
							this.class498_0.tJ_CalcLossTransHH.Rows.Add(dataRow2);
						}
						if (this.class498_0.tJ_CalcLossTransHH.Rows.Count > num)
						{
							this.class498_0.tJ_CalcLossTransHH.Rows[num]["idTrans"] = dataRow["id"];
							DataGridView dataGridView = this.method_31(this.tabControl_1.TabPages[num]);
							if (dataGridView != null)
							{
								short num2 = 1;
								foreach (object obj2 in dataGridView.Columns)
								{
									DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj2;
									if (dataGridView[dataGridViewColumn.Index, 0].Value != null)
									{
										this.class498_0.tJ_CalcLossTransHH.Rows[num]["month" + num2.ToString("00")] = Convert.ToInt32(dataGridView[dataGridViewColumn.Index, 0].Value);
									}
									else
									{
										this.class498_0.tJ_CalcLossTransHH.Rows[num]["month" + num2.ToString("00")] = DBNull.Value;
									}
									num2 += 1;
								}
							}
						}
						num++;
					}
					goto IL_2A3;
				}
				IL_263:
				DataRow dataRow3 = this.class498_0.tJ_CalcLossTransHH.NewRow();
				dataRow3["idCalc"] = this.int_0;
				this.class498_0.tJ_CalcLossTransHH.Rows.Add(dataRow3);
				IL_2A3:
				if (this.class498_0.tJ_CalcLossTransHH.Rows.Count <= num)
				{
					goto IL_263;
				}
				if (this.class498_0.tJ_CalcLossTransHH.Rows.Count > num)
				{
					short num3 = 1;
					foreach (object obj3 in this.dataGridView_1.Columns)
					{
						DataGridViewColumn dataGridViewColumn2 = (DataGridViewColumn)obj3;
						if (this.dataGridView_1[dataGridViewColumn2.Index, 0].Value != null)
						{
							this.class498_0.tJ_CalcLossTransHH.Rows[num]["month" + num3.ToString("00")] = Convert.ToInt32(this.dataGridView_1[dataGridViewColumn2.Index, 0].Value);
						}
						else
						{
							this.class498_0.tJ_CalcLossTransHH.Rows[num]["month" + num3.ToString("00")] = DBNull.Value;
						}
						num3 += 1;
					}
				}
				for (int i = @class.Rows.Count + 1; i < this.class498_0.tJ_CalcLossTransHH.Rows.Count; i++)
				{
					this.class498_0.tJ_CalcLossTransHH.Rows[i].Delete();
				}
			}
			else
			{
				for (int j = 0; j < this.class498_0.tJ_CalcLossTransHH.Rows.Count; j++)
				{
					this.class498_0.tJ_CalcLossTransHH.Rows[j].Delete();
				}
			}
			if (base.InsertSqlData(this.class498_0, this.class498_0.tJ_CalcLossTransHH) && base.UpdateSqlData(this.class498_0, this.class498_0.tJ_CalcLossTransHH) && base.DeleteSqlData(this.class498_0, this.class498_0.tJ_CalcLossTransHH))
			{
				base.SelectSqlData(this.class498_0, this.class498_0.tJ_CalcLossTransHH, true, " where idCalc = " + this.int_0.ToString() + " order by id");
				return true;
			}
			return false;
		}

		private void method_22(TabPage tabPage_3, DataRow dataRow_0, string string_0)
		{
			TextBox textBox = this.method_28(tabPage_3, string_0);
			if (textBox != null)
			{
				if (string.IsNullOrEmpty(textBox.Text))
				{
					dataRow_0[string_0] = DBNull.Value;
					return;
				}
				dataRow_0[string_0] = Convert.ToDecimal(textBox.Text);
			}
		}

		private bool method_23()
		{
			if (this.comboBox_1.SelectedIndex < 0)
			{
				MessageBox.Show("Не указан объект абонента");
				return false;
			}
			if (string.IsNullOrEmpty(this.textBox_2.Text))
			{
				MessageBox.Show("Не указана балансовая принадлежность");
				return false;
			}
			return true;
		}

		private void button_3_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		private void button_4_Click(object sender, EventArgs e)
		{
			if (this.method_19())
			{
				new FormReportCalcLossTrans(this.int_0)
				{
					MdiParent = base.MdiParent,
					SqlSettings = this.SqlSettings
				}.Show();
			}
		}

		private bool method_24()
		{
			bool result;
			try
			{
				foreach (DataRow dataRow in this.class498_0.tJ_CalcLossFile)
				{
					if (dataRow.RowState != DataRowState.Deleted && dataRow.RowState != DataRowState.Detached)
					{
						dataRow["idCalc"] = this.int_0;
						dataRow.EndEdit();
					}
				}
				base.InsertSqlData(this.class498_0, this.class498_0.tJ_CalcLossFile);
				base.UpdateSqlData(this.class498_0, this.class498_0.tJ_CalcLossFile);
				base.DeleteSqlData(this.class498_0, this.class498_0.tJ_CalcLossFile);
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
				result = false;
			}
			return result;
		}

		private void method_25()
		{
			base.SelectSqlData(this.class498_0.tJ_CalcLossFile, true, " where idCalc = " + this.int_0.ToString(), null, false, 0);
		}

		private void dataGridViewExcelFilter_0_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.RowCount > 0 && this.dataGridViewExcelFilter_0[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value != null && e.ColumnIndex == this.dataGridViewExcelFilter_0.Columns[this.dataGridViewImageColumnNotNull_0.Name].Index)
			{
				Icon icon = FormLbr.Classes.FileInfo.IconOfFile(this.dataGridViewExcelFilter_0[this.dataGridViewLinkColumn_0.Name, e.RowIndex].Value.ToString());
				e.Value = icon.ToBitmap();
			}
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Multiselect = true;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					for (int i = 0; i < openFileDialog.FileNames.Length; i++)
					{
						DataRow dataRow = this.class498_0.tJ_CalcLossFile.NewRow();
						dataRow["idCalc"] = this.int_0;
						dataRow["File"] = File.ReadAllBytes(openFileDialog.FileNames[i]);
						dataRow["FileName"] = Path.GetFileName(openFileDialog.FileNames[i]);
						dataRow["DateIn"] = DateTime.Now;
						this.class498_0.tJ_CalcLossFile.Rows.Add(dataRow);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow != null)
			{
				this.dataGridViewExcelFilter_0.Rows.Remove(this.dataGridViewExcelFilter_0.CurrentRow);
				return;
			}
			MessageBox.Show("Не выбрано ни одного файла");
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			if (this.dataGridViewExcelFilter_0.CurrentRow == null)
			{
				return;
			}
			int num = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
			DataRow[] array = this.class498_0.tJ_CalcLossFile.Select("id = " + num.ToString());
			if (array.Length != 0)
			{
				byte[] array2 = (byte[])array[0]["File"];
				string text = Path.GetTempFileName();
				text = Path.ChangeExtension(text, Path.GetExtension(array[0]["FileName"].ToString()));
				FileStream fileStream = File.Create(text);
				fileStream.Write(array2, 0, array2.Length);
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

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			try
			{
				int num = Convert.ToInt32(this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewTextBoxColumn_0.Name].Value);
				DataRow[] array = this.class498_0.tJ_CalcLossFile.Select("id = " + num.ToString());
				if (array.Length != 0)
				{
					string text = this.dataGridViewExcelFilter_0.CurrentRow.Cells[this.dataGridViewLinkColumn_0.Name].Value.ToString();
					string extension = Path.GetExtension(text);
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.Filter = "(*" + extension + ")|*" + extension;
					saveFileDialog.FileName = text;
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						byte[] array2 = (byte[])array[0]["file"];
						FileStream fileStream = File.Create(saveFileDialog.FileName);
						fileStream.Write(array2, 0, array2.Length);
						fileStream.Close();
						MessageBox.Show("Файл успешно сохранен", "Сохранение");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.Source);
			}
		}

		private void dataGridViewExcelFilter_0_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == this.dataGridViewExcelFilter_0.Columns[this.dataGridViewLinkColumn_0.Name].Index)
			{
				this.toolStripButton_3_Click(sender, e);
			}
		}

		private void method_26()
		{
			if (this.int_2 != this.int_4)
			{
				Control control = this.textBox_34;
				Control control2 = this.textBox_33;
				this.textBox_32.Visible = false;
				control2.Visible = false;
				control.Visible = false;
				Control control3 = this.label_10;
				this.dataGridView_0.Visible = false;
				control3.Visible = false;
				this.bool_1 = false;
				this.tabControl_1.Height = 244;
				Control control4 = this.label_11;
				this.dataGridView_1.Visible = false;
				control4.Visible = false;
				this.panel_0.Top = 387;
				this.panel_0.Height = this.tabControl_0.Bottom - this.panel_0.Top - 20;
				this.toolStripButton_5.Enabled = false;
				while (this.tabControl_1.TabPages.Count > 1)
				{
					this.tabControl_1.TabPages.RemoveAt(1);
				}
				return;
			}
			Control control5 = this.textBox_34;
			Control control6 = this.textBox_33;
			this.textBox_32.Visible = true;
			control6.Visible = true;
			control5.Visible = true;
			Control control7 = this.label_10;
			this.dataGridView_0.Visible = true;
			control7.Visible = true;
			this.bool_1 = true;
			this.tabControl_1.Height = 339;
			this.toolStripButton_5.Enabled = true;
			if (this.tabControl_1.TabPages.Count > 1)
			{
				Control control8 = this.label_11;
				this.dataGridView_1.Visible = true;
				control8.Visible = true;
				this.panel_0.Top = 557;
				this.panel_0.Height = this.tabControl_0.Bottom - this.panel_0.Top - 20;
				return;
			}
			this.panel_0.Top = 477;
			this.panel_0.Height = this.tabControl_0.Bottom - this.panel_0.Top - 20;
			Control control9 = this.label_11;
			this.dataGridView_1.Visible = false;
			control9.Visible = false;
		}

		private void textBox_32_TextChanged(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			DataGridView dataGridView = this.dataGridView_0;
			if (textBox.Parent != null && textBox.Parent is TabPage)
			{
				dataGridView = this.method_31((TabPage)textBox.Parent);
			}
			if (string.IsNullOrEmpty(textBox.Text))
			{
				using (IEnumerator enumerator = dataGridView.Columns.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj;
						dataGridView[dataGridViewColumn.Index, 0].Value = null;
					}
					return;
				}
			}
			float num = Convert.ToSingle(textBox.Text);
			int num2 = DateTime.IsLeapYear(this.dateTimePicker_0.Value.Year) ? 366 : 365;
			int num3 = 0;
			foreach (object obj2 in dataGridView.Columns)
			{
				DataGridViewColumn dataGridViewColumn2 = (DataGridViewColumn)obj2;
				if (dataGridViewColumn2.Index != 1)
				{
					dataGridView[dataGridViewColumn2.Index, 0].Value = Math.Round((double)((float)DateTime.DaysInMonth(this.dateTimePicker_0.Value.Year, dataGridViewColumn2.Index + 1) * num / (float)num2), 0);
					num3 += Convert.ToInt32(Math.Round((double)((float)DateTime.DaysInMonth(this.dateTimePicker_0.Value.Year, dataGridViewColumn2.Index + 1) * num / (float)num2), 0));
				}
			}
			dataGridView[1, 0].Value = Convert.ToInt32(Math.Round((double)(num - (float)num3), 0));
		}

		private TabPage method_27()
		{
			TabPage tabPage = new TabPage("Т" + (this.tabControl_1.TabCount + 1).ToString());
			tabPage.Name = "tabPageTrans" + (this.tabControl_1.TabCount + 1).ToString();
			tabPage.Size = this.tabPage_2.Size;
			foreach (object obj in this.tabPage_2.Controls)
			{
				Control control = (Control)obj;
				Type type = control.GetType();
				Control control2 = (Control)Activator.CreateInstance(type);
				control2.Dock = control.Dock;
				control2.Location = control.Location;
				control2.Size = control.Size;
				control2.Anchor = control.Anchor;
				control2.BackColor = control.BackColor;
				control2.TabStop = control.TabStop;
				if (type == typeof(TextBox))
				{
					((TextBox)control2).ReadOnly = ((TextBox)control).ReadOnly;
					((TextBox)control2).TextAlign = ((TextBox)control).TextAlign;
					if (!((TextBox)control2).ReadOnly)
					{
						((TextBox)control2).KeyPress += this.textBox_44_KeyPress;
						((TextBox)control2).TextChanged += this.method_1;
					}
					if (((TextBox)control).Tag != null && ((TextBox)control).Tag.ToString() == "LossElectrHH")
					{
						((TextBox)control2).TextChanged += this.textBox_32_TextChanged;
					}
					control2.Tag = control.Tag;
				}
				if (type == typeof(ToolStrip))
				{
					((ToolStrip)control2).LayoutStyle = ((ToolStrip)control).LayoutStyle;
					((ToolStrip)control2).GripStyle = ((ToolStrip)control).GripStyle;
					foreach (object obj2 in ((ToolStrip)control).Items)
					{
						ToolStripItem toolStripItem = (ToolStripItem)obj2;
						ToolStripItem toolStripItem2 = (ToolStripItem)Activator.CreateInstance(toolStripItem.GetType());
						toolStripItem2.Text = toolStripItem.Text;
						toolStripItem2.Image = toolStripItem.Image;
						toolStripItem2.DisplayStyle = toolStripItem.DisplayStyle;
						toolStripItem2.Visible = true;
						toolStripItem2.Tag = tabPage;
						FieldInfo field = typeof(Component).GetField("events", BindingFlags.Instance | BindingFlags.NonPublic);
						object value = field.GetValue(toolStripItem);
						field.SetValue(toolStripItem2, value);
						((ToolStrip)control2).Items.Add(toolStripItem2);
					}
				}
				if (type == typeof(Button))
				{
					FieldInfo field2 = typeof(Component).GetField("events", BindingFlags.Instance | BindingFlags.NonPublic);
					object value2 = field2.GetValue(control);
					field2.SetValue(control2, value2);
				}
				if (type == typeof(DataGridView))
				{
					((DataGridView)control2).AllowUserToAddRows = ((DataGridView)control).AllowUserToAddRows;
					((DataGridView)control2).AllowUserToDeleteRows = ((DataGridView)control).AllowUserToDeleteRows;
					((DataGridView)control2).AllowUserToOrderColumns = ((DataGridView)control).AllowUserToOrderColumns;
					((DataGridView)control2).AllowUserToResizeColumns = ((DataGridView)control).AllowUserToResizeColumns;
					((DataGridView)control2).AllowUserToResizeRows = ((DataGridView)control).AllowUserToResizeRows;
					((DataGridView)control2).RowHeadersVisible = ((DataGridView)control).RowHeadersVisible;
					FieldInfo field3 = typeof(Component).GetField("events", BindingFlags.Instance | BindingFlags.NonPublic);
					object value3 = field3.GetValue(control);
					field3.SetValue(control2, value3);
					foreach (object obj3 in ((DataGridView)control).Columns)
					{
						DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj3;
						DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
						dataGridViewColumn2.CellTemplate = dataGridViewColumn.CellTemplate;
						dataGridViewColumn2.HeaderText = dataGridViewColumn.HeaderText;
						dataGridViewColumn2.AutoSizeMode = dataGridViewColumn.AutoSizeMode;
						((DataGridView)control2).Columns.Add(dataGridViewColumn2);
					}
					((DataGridView)control2).Rows.Add();
				}
				tabPage.Controls.Add(control2);
				control2.Text = control.Text;
			}
			this.tabControl_1.TabPages.Add(tabPage);
			this.method_30();
			this.method_26();
			return tabPage;
		}

		private void toolStripButton_5_Click(object sender, EventArgs e)
		{
			this.method_27();
		}

		private void toolStripButton_6_Click(object sender, EventArgs e)
		{
			TabPage value = (TabPage)((ToolStripItem)sender).Tag;
			this.tabControl_1.TabPages.Remove(value);
			int num = 0;
			foreach (object obj in this.tabControl_1.TabPages)
			{
				Control control = (TabPage)obj;
				string str = "Т";
				int num2 = num + 1;
				num = num2;
				control.Text = str + num2.ToString();
			}
			this.method_30();
			this.method_26();
		}

		private TextBox method_28(TabPage tabPage_3, object object_0)
		{
			if (object_0 == null)
			{
				return null;
			}
			foreach (object obj in tabPage_3.Controls)
			{
				Control control = (Control)obj;
				if (control is TextBox && ((TextBox)control).Tag != null && ((TextBox)control).Tag.ToString() == object_0.ToString())
				{
					return (TextBox)control;
				}
			}
			return null;
		}

		private decimal method_29(decimal decimal_0, int int_5)
		{
			if (decimal_0 == 0m)
			{
				return decimal_0;
			}
			decimal num = Math.Round(decimal_0, int_5);
			if (int_5 < 15 && !(num != 0m))
			{
				return this.method_29(decimal_0, int_5 + 1);
			}
			return num;
		}

		private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				int? num = null;
				foreach (object obj in this.tabControl_1.TabPages)
				{
					TabPage tabPage_ = (TabPage)obj;
					DataGridView dataGridView = this.method_31(tabPage_);
					if (dataGridView[e.ColumnIndex, e.RowIndex].Value != null)
					{
						if (num != null)
						{
							num += Convert.ToInt32(dataGridView[e.ColumnIndex, e.RowIndex].Value);
						}
						else
						{
							num = new int?(Convert.ToInt32(dataGridView[e.ColumnIndex, e.RowIndex].Value));
						}
					}
				}
				this.dataGridView_1[e.ColumnIndex, e.RowIndex].Value = num;
			}
		}

		private void method_30()
		{
			int?[] array = new int?[12];
			foreach (object obj in this.tabControl_1.TabPages)
			{
				TabPage tabPage_ = (TabPage)obj;
				DataGridView dataGridView = this.method_31(tabPage_);
				foreach (object obj2 in dataGridView.Columns)
				{
					DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)obj2;
					if (dataGridView[dataGridViewColumn.Index, 0].Value != null)
					{
						if (array[dataGridViewColumn.Index] != null)
						{
							array[dataGridViewColumn.Index] += Convert.ToInt32(dataGridView[dataGridViewColumn.Index, 0].Value);
						}
						else
						{
							array[dataGridViewColumn.Index] = new int?(Convert.ToInt32(dataGridView[dataGridViewColumn.Index, 0].Value));
						}
					}
				}
			}
			for (int i = 0; i < array.Length; i++)
			{
				this.dataGridView_1[i, 0].Value = array[i];
			}
		}

		private DataGridView method_31(TabPage tabPage_3)
		{
			DataGridView result = this.dataGridView_0;
			foreach (object obj in tabPage_3.Controls)
			{
				Control control = (Control)obj;
				if (control is DataGridView)
				{
					result = (DataGridView)control;
					break;
				}
			}
			return result;
		}

		private void method_32()
		{
			this.icontainer_0 = new Container();
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormAddEditCalcTrans));
			this.label_0 = new Label();
			this.dateTimePicker_0 = new DateTimePicker();
			this.class498_0 = new Class498();
			this.label_1 = new Label();
			this.comboBox_0 = new ComboBox();
			this.label_2 = new Label();
			this.textBox_0 = new TextBox();
			this.comboBox_1 = new ComboBox();
			this.label_3 = new Label();
			this.textBox_1 = new TextBox();
			this.label_4 = new Label();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.textBox_2 = new TextBox();
			this.label_5 = new Label();
			this.button_0 = new Button();
			this.label_6 = new Label();
			this.textBox_3 = new TextBox();
			this.label_7 = new Label();
			this.textBox_4 = new TextBox();
			this.button_1 = new Button();
			this.textBox_5 = new TextBox();
			this.textBox_6 = new TextBox();
			this.textBox_7 = new TextBox();
			this.textBox_8 = new TextBox();
			this.textBox_9 = new TextBox();
			this.textBox_10 = new TextBox();
			this.textBox_11 = new TextBox();
			this.textBox_12 = new TextBox();
			this.textBox_13 = new TextBox();
			this.textBox_14 = new TextBox();
			this.textBox_15 = new TextBox();
			this.textBox_16 = new TextBox();
			this.textBox_17 = new TextBox();
			this.textBox_18 = new TextBox();
			this.textBox_19 = new TextBox();
			this.textBox_20 = new TextBox();
			this.textBox_21 = new TextBox();
			this.textBox_22 = new TextBox();
			this.textBox_23 = new TextBox();
			this.textBox_24 = new TextBox();
			this.textBox_25 = new TextBox();
			this.textBox_26 = new TextBox();
			this.textBox_27 = new TextBox();
			this.textBox_28 = new TextBox();
			this.textBox_29 = new TextBox();
			this.textBox_30 = new TextBox();
			this.textBox_31 = new TextBox();
			this.button_2 = new Button();
			this.textBox_32 = new TextBox();
			this.textBox_33 = new TextBox();
			this.textBox_34 = new TextBox();
			this.textBox_35 = new TextBox();
			this.textBox_36 = new TextBox();
			this.textBox_37 = new TextBox();
			this.textBox_38 = new TextBox();
			this.textBox_39 = new TextBox();
			this.textBox_40 = new TextBox();
			this.textBox_41 = new TextBox();
			this.textBox_42 = new TextBox();
			this.textBox_43 = new TextBox();
			this.textBox_44 = new TextBox();
			this.textBox_45 = new TextBox();
			this.textBox_46 = new TextBox();
			this.textBox_47 = new TextBox();
			this.textBox_48 = new TextBox();
			this.textBox_49 = new TextBox();
			this.button_3 = new Button();
			this.richTextBox_0 = new RichTextBox();
			this.label_8 = new Label();
			this.button_4 = new Button();
			this.tabControl_0 = new TabControl();
			this.tabPage_0 = new TabPage();
			this.panel_0 = new Panel();
			this.dataGridView_1 = new DataGridView();
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
			this.dataGridViewTextBoxColumn_25 = new DataGridViewTextBoxColumn();
			this.label_11 = new Label();
			this.tabControl_1 = new TabControl();
			this.tabPage_2 = new TabPage();
			this.toolStrip_2 = new ToolStrip();
			this.toolStripButton_5 = new ToolStripButton();
			this.toolStripButton_6 = new ToolStripButton();
			this.label_10 = new Label();
			this.dataGridView_0 = new DataGridView();
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
			this.textBox_51 = new TextBox();
			this.textBox_52 = new TextBox();
			this.textBox_53 = new TextBox();
			this.textBox_50 = new TextBox();
			this.label_9 = new Label();
			this.tabPage_1 = new TabPage();
			this.dataGridViewExcelFilter_0 = new DataGridViewExcelFilter();
			this.dataGridViewImageColumnNotNull_0 = new DataGridViewImageColumnNotNull();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewFilterTextBoxColumn_0 = new DataGridViewFilterTextBoxColumn();
			this.dataGridViewLinkColumn_0 = new DataGridViewLinkColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.toolStrip_1 = new ToolStrip();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripButton_4 = new ToolStripButton();
			((ISupportInitialize)this.class498_0).BeginInit();
			this.toolStrip_0.SuspendLayout();
			this.tabControl_0.SuspendLayout();
			this.tabPage_0.SuspendLayout();
			this.panel_0.SuspendLayout();
			((ISupportInitialize)this.dataGridView_1).BeginInit();
			this.tabControl_1.SuspendLayout();
			this.tabPage_2.SuspendLayout();
			this.toolStrip_2.SuspendLayout();
			((ISupportInitialize)this.dataGridView_0).BeginInit();
			this.tabPage_1.SuspendLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			this.toolStrip_1.SuspendLayout();
			base.SuspendLayout();
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(12, 14);
			this.label_0.Name = "label1";
			this.label_0.Size = new Size(90, 13);
			this.label_0.TabIndex = 0;
			this.label_0.Text = "Дата документа";
			this.dateTimePicker_0.DataBindings.Add(new Binding("Value", this.class498_0, "tJ_CalcLoss.DateCalc", true));
			this.dateTimePicker_0.Location = new Point(108, 12);
			this.dateTimePicker_0.Name = "dateTimePickerDateCalc";
			this.dateTimePicker_0.Size = new Size(165, 20);
			this.dateTimePicker_0.TabIndex = 1;
			this.class498_0.DataSetName = "dsCalc";
			this.class498_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(417, 14);
			this.label_1.Name = "label2";
			this.label_1.Size = new Size(80, 13);
			this.label_1.TabIndex = 4;
			this.label_1.Text = "Пользователь";
			this.comboBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_0.DataBindings.Add(new Binding("SelectedValue", this.class498_0, "tJ_CalcLoss.idOwner", true));
			this.comboBox_0.DataSource = this.class498_0;
			this.comboBox_0.DisplayMember = "tUser.Name";
			this.comboBox_0.Enabled = false;
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(503, 11);
			this.comboBox_0.Name = "cmbOwner";
			this.comboBox_0.Size = new Size(547, 21);
			this.comboBox_0.TabIndex = 5;
			this.comboBox_0.ValueMember = "tUser.IDUser";
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(12, 41);
			this.label_2.Name = "label3";
			this.label_2.Size = new Size(72, 13);
			this.label_2.TabIndex = 6;
			this.label_2.Text = "Имя расчета";
			this.textBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_0.DataBindings.Add(new Binding("Text", this.class498_0, "tJ_CalcLoss.nameCalc", true));
			this.textBox_0.Location = new Point(147, 38);
			this.textBox_0.Name = "txtNameCalc";
			this.textBox_0.Size = new Size(903, 20);
			this.textBox_0.TabIndex = 7;
			this.comboBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.comboBox_1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_1.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_1.DataBindings.Add(new Binding("Tag", this.class498_0, "tJ_CalcLoss.idAbnObj", true));
			this.comboBox_1.FormattingEnabled = true;
			this.comboBox_1.Location = new Point(147, 76);
			this.comboBox_1.Name = "cmbAbnObj";
			this.comboBox_1.Size = new Size(876, 21);
			this.comboBox_1.TabIndex = 12;
			this.comboBox_1.SelectedValueChanged += this.comboBox_1_SelectedValueChanged;
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(12, 79);
			this.label_3.Name = "label5";
			this.label_3.Size = new Size(45, 13);
			this.label_3.TabIndex = 11;
			this.label_3.Text = "Объект";
			this.textBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_1.BackColor = SystemColors.Window;
			this.textBox_1.DataBindings.Add(new Binding("Tag", this.class498_0, "tJ_CalcLoss.idAbn", true));
			this.textBox_1.Location = new Point(147, 57);
			this.textBox_1.Name = "txtAbn";
			this.textBox_1.ReadOnly = true;
			this.textBox_1.Size = new Size(876, 20);
			this.textBox_1.TabIndex = 9;
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(12, 60);
			this.label_4.Name = "label4";
			this.label_4.Size = new Size(49, 13);
			this.label_4.TabIndex = 8;
			this.label_4.Text = "Абонент";
			this.toolStrip_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.toolStrip_0.Dock = DockStyle.None;
			this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0
			});
			this.toolStrip_0.Location = new Point(1025, 65);
			this.toolStrip_0.Name = "toolStripAbnObj";
			this.toolStrip_0.Size = new Size(26, 25);
			this.toolStrip_0.TabIndex = 10;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.partners;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolBtnContractor";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Выбрать контрагента";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.textBox_2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_2.BackColor = SystemColors.Window;
			this.textBox_2.DataBindings.Add(new Binding("Tag", this.class498_0, "tJ_CalcLoss.idAbnBalance", true));
			this.textBox_2.Location = new Point(147, 95);
			this.textBox_2.Name = "txtAbnBalance";
			this.textBox_2.ReadOnly = true;
			this.textBox_2.Size = new Size(876, 20);
			this.textBox_2.TabIndex = 14;
			this.label_5.AutoSize = true;
			this.label_5.Location = new Point(12, 98);
			this.label_5.Name = "label6";
			this.label_5.Size = new Size(44, 13);
			this.label_5.TabIndex = 13;
			this.label_5.Text = "Баланс";
			this.button_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.button_0.Location = new Point(1024, 95);
			this.button_0.Name = "buttonAbnBalance";
			this.button_0.Size = new Size(26, 20);
			this.button_0.TabIndex = 15;
			this.button_0.Text = "...";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += this.button_0_Click;
			this.label_6.AutoSize = true;
			this.label_6.Location = new Point(12, 117);
			this.label_6.Name = "label7";
			this.label_6.Size = new Size(68, 13);
			this.label_6.TabIndex = 16;
			this.label_6.Text = "Подстанции";
			this.textBox_3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_3.BackColor = SystemColors.Window;
			this.textBox_3.DataBindings.Add(new Binding("Text", this.class498_0, "tJ_CalcLoss.tpName", true));
			this.textBox_3.Location = new Point(147, 114);
			this.textBox_3.Name = "txtTPName";
			this.textBox_3.Size = new Size(903, 20);
			this.textBox_3.TabIndex = 17;
			this.label_7.AutoSize = true;
			this.label_7.Location = new Point(27, 6);
			this.label_7.Name = "labelMakeupTrans";
			this.label_7.Size = new Size(129, 13);
			this.label_7.TabIndex = 1;
			this.label_7.Text = "Марка трансформатора";
			this.textBox_4.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_4.BackColor = SystemColors.Window;
			this.textBox_4.Location = new Point(162, 1);
			this.textBox_4.Name = "txtMakeupTrans";
			this.textBox_4.ReadOnly = true;
			this.textBox_4.Size = new Size(856, 20);
			this.textBox_4.TabIndex = 2;
			this.textBox_4.Tag = "MakeupTrans";
			this.button_1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.button_1.Location = new Point(1020, 2);
			this.button_1.Name = "buttonMakeupTrans";
			this.button_1.Size = new Size(26, 20);
			this.button_1.TabIndex = 3;
			this.button_1.Text = "...";
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += this.button_1_Click;
			this.textBox_5.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_5.BackColor = SystemColors.ControlLight;
			this.textBox_5.Location = new Point(27, 25);
			this.textBox_5.Name = "textBox1";
			this.textBox_5.ReadOnly = true;
			this.textBox_5.Size = new Size(830, 20);
			this.textBox_5.TabIndex = 4;
			this.textBox_5.TabStop = false;
			this.textBox_5.Text = "Номинальная мощность трансформатора";
			this.textBox_6.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_6.BackColor = SystemColors.ControlLight;
			this.textBox_6.Location = new Point(854, 25);
			this.textBox_6.Name = "textBox2";
			this.textBox_6.ReadOnly = true;
			this.textBox_6.Size = new Size(100, 20);
			this.textBox_6.TabIndex = 5;
			this.textBox_6.TabStop = false;
			this.textBox_6.Text = "Sном, МВА";
			this.textBox_7.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_7.Location = new Point(953, 25);
			this.textBox_7.Name = "txtRatedPowerTrans1";
			this.textBox_7.Size = new Size(93, 20);
			this.textBox_7.TabIndex = 6;
			this.textBox_7.Tag = "RatedPower";
			this.textBox_7.TextAlign = HorizontalAlignment.Right;
			this.textBox_8.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_8.BackColor = SystemColors.Window;
			this.textBox_8.Location = new Point(953, 44);
			this.textBox_8.Name = "txtNoLoadLoss";
			this.textBox_8.Size = new Size(93, 20);
			this.textBox_8.TabIndex = 9;
			this.textBox_8.Tag = "NoLoadLoss";
			this.textBox_8.TextAlign = HorizontalAlignment.Right;
			this.textBox_9.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_9.BackColor = SystemColors.ControlLight;
			this.textBox_9.Location = new Point(854, 44);
			this.textBox_9.Name = "textBox4";
			this.textBox_9.ReadOnly = true;
			this.textBox_9.Size = new Size(100, 20);
			this.textBox_9.TabIndex = 8;
			this.textBox_9.TabStop = false;
			this.textBox_9.Text = "∆Pхх, кВт";
			this.textBox_10.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_10.BackColor = SystemColors.ControlLight;
			this.textBox_10.Location = new Point(27, 44);
			this.textBox_10.Name = "textBox5";
			this.textBox_10.ReadOnly = true;
			this.textBox_10.Size = new Size(830, 20);
			this.textBox_10.TabIndex = 7;
			this.textBox_10.TabStop = false;
			this.textBox_10.Text = "Потери мощности холостого хода";
			this.textBox_11.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_11.Location = new Point(953, 62);
			this.textBox_11.Name = "txtShortCicuitLoss";
			this.textBox_11.Size = new Size(93, 20);
			this.textBox_11.TabIndex = 12;
			this.textBox_11.Tag = "ShortCircuitLoss";
			this.textBox_11.TextAlign = HorizontalAlignment.Right;
			this.textBox_12.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_12.BackColor = SystemColors.ControlLight;
			this.textBox_12.Location = new Point(854, 62);
			this.textBox_12.Name = "textBox7";
			this.textBox_12.ReadOnly = true;
			this.textBox_12.Size = new Size(100, 20);
			this.textBox_12.TabIndex = 11;
			this.textBox_12.TabStop = false;
			this.textBox_12.Text = "∆Pкз, кВт";
			this.textBox_13.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_13.BackColor = SystemColors.ControlLight;
			this.textBox_13.Location = new Point(9, 62);
			this.textBox_13.Name = "textBox8";
			this.textBox_13.ReadOnly = true;
			this.textBox_13.Size = new Size(848, 20);
			this.textBox_13.TabIndex = 10;
			this.textBox_13.TabStop = false;
			this.textBox_13.Text = "Потери мощности короткого замыкания";
			this.textBox_14.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_14.Location = new Point(953, 157);
			this.textBox_14.Name = "txtCoeffPowerReactive";
			this.textBox_14.Size = new Size(93, 20);
			this.textBox_14.TabIndex = 29;
			this.textBox_14.Tag = "CoeffPowerReactive";
			this.textBox_14.TextAlign = HorizontalAlignment.Right;
			this.textBox_15.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_15.BackColor = SystemColors.ControlLight;
			this.textBox_15.Location = new Point(854, 157);
			this.textBox_15.Name = "textBox10";
			this.textBox_15.ReadOnly = true;
			this.textBox_15.Size = new Size(100, 20);
			this.textBox_15.TabIndex = 28;
			this.textBox_15.TabStop = false;
			this.textBox_15.Text = "tg φ";
			this.textBox_16.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_16.BackColor = SystemColors.ControlLight;
			this.textBox_16.Location = new Point(9, 157);
			this.textBox_16.Name = "textBox11";
			this.textBox_16.ReadOnly = true;
			this.textBox_16.Size = new Size(848, 20);
			this.textBox_16.TabIndex = 27;
			this.textBox_16.TabStop = false;
			this.textBox_16.Text = "Коэффициент реактивной мощности";
			this.textBox_17.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_17.Location = new Point(953, 137);
			this.textBox_17.Name = "txtPeriod";
			this.textBox_17.Size = new Size(93, 20);
			this.textBox_17.TabIndex = 26;
			this.textBox_17.Tag = "Period";
			this.textBox_17.TextAlign = HorizontalAlignment.Right;
			this.textBox_18.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_18.BackColor = SystemColors.ControlLight;
			this.textBox_18.Location = new Point(854, 137);
			this.textBox_18.Name = "textBox13";
			this.textBox_18.ReadOnly = true;
			this.textBox_18.Size = new Size(100, 20);
			this.textBox_18.TabIndex = 25;
			this.textBox_18.TabStop = false;
			this.textBox_18.Text = "Т, час";
			this.textBox_19.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_19.BackColor = SystemColors.ControlLight;
			this.textBox_19.Location = new Point(9, 137);
			this.textBox_19.Name = "textBox14";
			this.textBox_19.ReadOnly = true;
			this.textBox_19.Size = new Size(848, 20);
			this.textBox_19.TabIndex = 24;
			this.textBox_19.TabStop = false;
			this.textBox_19.Text = "Базовый (расчетный) период";
			this.textBox_20.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_20.Location = new Point(953, 80);
			this.textBox_20.Name = "txtConsumtion";
			this.textBox_20.Size = new Size(93, 20);
			this.textBox_20.TabIndex = 18;
			this.textBox_20.Tag = "Consumption";
			this.textBox_20.TextAlign = HorizontalAlignment.Right;
			this.textBox_21.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_21.BackColor = SystemColors.ControlLight;
			this.textBox_21.Location = new Point(854, 80);
			this.textBox_21.Name = "textBox16";
			this.textBox_21.ReadOnly = true;
			this.textBox_21.Size = new Size(100, 20);
			this.textBox_21.TabIndex = 17;
			this.textBox_21.TabStop = false;
			this.textBox_21.Text = "Wт, кВт*ч";
			this.textBox_22.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_22.BackColor = SystemColors.ControlLight;
			this.textBox_22.Location = new Point(9, 80);
			this.textBox_22.Name = "textBox17";
			this.textBox_22.ReadOnly = true;
			this.textBox_22.Size = new Size(848, 20);
			this.textBox_22.TabIndex = 16;
			this.textBox_22.TabStop = false;
			this.textBox_22.Text = "Потребление активной электроэнергии за базовый период по счетчику";
			this.textBox_23.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_23.Location = new Point(953, 117);
			this.textBox_23.Name = "txtMiddleVoltage";
			this.textBox_23.Size = new Size(93, 20);
			this.textBox_23.TabIndex = 23;
			this.textBox_23.Tag = "MiddleVoltage";
			this.textBox_23.TextAlign = HorizontalAlignment.Right;
			this.textBox_24.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_24.BackColor = SystemColors.ControlLight;
			this.textBox_24.Location = new Point(854, 117);
			this.textBox_24.Name = "textBox19";
			this.textBox_24.ReadOnly = true;
			this.textBox_24.Size = new Size(100, 20);
			this.textBox_24.TabIndex = 22;
			this.textBox_24.TabStop = false;
			this.textBox_24.Text = "Uср, кВ";
			this.textBox_25.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_25.BackColor = SystemColors.ControlLight;
			this.textBox_25.Location = new Point(9, 117);
			this.textBox_25.Name = "textBox20";
			this.textBox_25.ReadOnly = true;
			this.textBox_25.Size = new Size(848, 20);
			this.textBox_25.TabIndex = 21;
			this.textBox_25.TabStop = false;
			this.textBox_25.Text = "Среднее напряжение на высшей стороне трансформатора за базовый период";
			this.textBox_26.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_26.Location = new Point(953, 195);
			this.textBox_26.Name = "txtCoeffDifference";
			this.textBox_26.Size = new Size(93, 20);
			this.textBox_26.TabIndex = 35;
			this.textBox_26.Tag = "CoeffDifference";
			this.textBox_26.TextAlign = HorizontalAlignment.Right;
			this.textBox_27.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_27.BackColor = SystemColors.ControlLight;
			this.textBox_27.Location = new Point(854, 195);
			this.textBox_27.Name = "textBox22";
			this.textBox_27.ReadOnly = true;
			this.textBox_27.Size = new Size(100, 20);
			this.textBox_27.TabIndex = 34;
			this.textBox_27.TabStop = false;
			this.textBox_27.Text = "kк, о.е.";
			this.textBox_28.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_28.BackColor = SystemColors.ControlLight;
			this.textBox_28.Location = new Point(9, 195);
			this.textBox_28.Name = "textBox23";
			this.textBox_28.ReadOnly = true;
			this.textBox_28.Size = new Size(848, 20);
			this.textBox_28.TabIndex = 33;
			this.textBox_28.TabStop = false;
			this.textBox_28.Text = "Коэффициент учитывающий различие конфигураций графиков активной и реактивной нагрузки";
			this.textBox_29.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_29.Location = new Point(953, 176);
			this.textBox_29.Name = "txtSquareCoeff";
			this.textBox_29.Size = new Size(93, 20);
			this.textBox_29.TabIndex = 32;
			this.textBox_29.Tag = "SquareCoeffFromGraph";
			this.textBox_29.TextAlign = HorizontalAlignment.Right;
			this.textBox_30.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_30.BackColor = SystemColors.ControlLight;
			this.textBox_30.Location = new Point(854, 176);
			this.textBox_30.Name = "textBox25";
			this.textBox_30.ReadOnly = true;
			this.textBox_30.Size = new Size(100, 20);
			this.textBox_30.TabIndex = 31;
			this.textBox_30.TabStop = false;
			this.textBox_30.Text = "kφ², о.е.";
			this.textBox_31.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_31.BackColor = SystemColors.ControlLight;
			this.textBox_31.Location = new Point(9, 176);
			this.textBox_31.Name = "textBox26";
			this.textBox_31.ReadOnly = true;
			this.textBox_31.Size = new Size(848, 20);
			this.textBox_31.TabIndex = 30;
			this.textBox_31.TabStop = false;
			this.textBox_31.Text = "Квадрат коэффициента формы графика за базовый период";
			this.button_2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.button_2.Location = new Point(19, 734);
			this.button_2.Name = "buttonOK";
			this.button_2.Size = new Size(75, 23);
			this.button_2.TabIndex = 1;
			this.button_2.Text = "ОК";
			this.button_2.UseVisualStyleBackColor = true;
			this.button_2.Click += this.button_2_Click;
			this.textBox_32.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_32.Location = new Point(953, 214);
			this.textBox_32.Name = "txtLossElectrHH";
			this.textBox_32.ReadOnly = true;
			this.textBox_32.Size = new Size(93, 20);
			this.textBox_32.TabIndex = 38;
			this.textBox_32.Tag = "LossElectrHH";
			this.textBox_32.TextAlign = HorizontalAlignment.Right;
			this.textBox_32.TextChanged += this.textBox_32_TextChanged;
			this.textBox_33.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_33.BackColor = SystemColors.Info;
			this.textBox_33.Location = new Point(854, 214);
			this.textBox_33.Name = "txtParamLossElectrHH";
			this.textBox_33.ReadOnly = true;
			this.textBox_33.Size = new Size(100, 20);
			this.textBox_33.TabIndex = 37;
			this.textBox_33.TabStop = false;
			this.textBox_33.Text = "∆Wхх, кВт*ч";
			this.textBox_34.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_34.BackColor = SystemColors.Info;
			this.textBox_34.Location = new Point(9, 214);
			this.textBox_34.Name = "lalbelLossElectrHH";
			this.textBox_34.ReadOnly = true;
			this.textBox_34.Size = new Size(848, 20);
			this.textBox_34.TabIndex = 36;
			this.textBox_34.TabStop = false;
			this.textBox_34.Text = "Потери электроэнергии холостого хода в силовом трансформаторе";
			this.textBox_35.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_35.Location = new Point(954, 10);
			this.textBox_35.Name = "txtActiveResistance";
			this.textBox_35.ReadOnly = true;
			this.textBox_35.Size = new Size(93, 20);
			this.textBox_35.TabIndex = 2;
			this.textBox_35.Tag = "ActiveResistance";
			this.textBox_35.TextAlign = HorizontalAlignment.Right;
			this.textBox_36.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_36.BackColor = SystemColors.Info;
			this.textBox_36.Location = new Point(855, 10);
			this.textBox_36.Name = "textBox18";
			this.textBox_36.ReadOnly = true;
			this.textBox_36.Size = new Size(100, 20);
			this.textBox_36.TabIndex = 1;
			this.textBox_36.TabStop = false;
			this.textBox_36.Text = "Rт, Ом/фазу";
			this.textBox_37.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_37.BackColor = SystemColors.Info;
			this.textBox_37.Location = new Point(11, 10);
			this.textBox_37.Name = "textBox28";
			this.textBox_37.ReadOnly = true;
			this.textBox_37.Size = new Size(845, 20);
			this.textBox_37.TabIndex = 0;
			this.textBox_37.TabStop = false;
			this.textBox_37.Text = "Активное сопротивление трансформатора";
			this.textBox_38.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_38.Location = new Point(954, 49);
			this.textBox_38.Name = "txtLoadPowerLoss";
			this.textBox_38.ReadOnly = true;
			this.textBox_38.Size = new Size(93, 20);
			this.textBox_38.TabIndex = 8;
			this.textBox_38.TextAlign = HorizontalAlignment.Right;
			this.textBox_39.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_39.BackColor = SystemColors.Info;
			this.textBox_39.Location = new Point(855, 49);
			this.textBox_39.Name = "textBox12";
			this.textBox_39.ReadOnly = true;
			this.textBox_39.Size = new Size(100, 20);
			this.textBox_39.TabIndex = 7;
			this.textBox_39.TabStop = false;
			this.textBox_39.Text = "∆Pср, кВт";
			this.textBox_40.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_40.BackColor = SystemColors.Info;
			this.textBox_40.Location = new Point(11, 49);
			this.textBox_40.Name = "textBox15";
			this.textBox_40.ReadOnly = true;
			this.textBox_40.Size = new Size(845, 20);
			this.textBox_40.TabIndex = 6;
			this.textBox_40.TabStop = false;
			this.textBox_40.Text = "Нагрузочные потери мощности в трансформаторе";
			this.textBox_41.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_41.Location = new Point(954, 67);
			this.textBox_41.Name = "txtLoadLosses";
			this.textBox_41.ReadOnly = true;
			this.textBox_41.Size = new Size(93, 20);
			this.textBox_41.TabIndex = 11;
			this.textBox_41.TextAlign = HorizontalAlignment.Right;
			this.textBox_42.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_42.BackColor = SystemColors.Info;
			this.textBox_42.Location = new Point(855, 67);
			this.textBox_42.Name = "textBox9";
			this.textBox_42.ReadOnly = true;
			this.textBox_42.Size = new Size(100, 20);
			this.textBox_42.TabIndex = 10;
			this.textBox_42.TabStop = false;
			this.textBox_42.Text = "∆Wн, кВт*ч";
			this.textBox_43.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_43.BackColor = SystemColors.Info;
			this.textBox_43.Location = new Point(11, 67);
			this.textBox_43.Name = "textBox29";
			this.textBox_43.ReadOnly = true;
			this.textBox_43.Size = new Size(845, 20);
			this.textBox_43.TabIndex = 9;
			this.textBox_43.TabStop = false;
			this.textBox_43.Text = "Нагрузочные потери электроэнергии в трансформаторе";
			this.textBox_44.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_44.Location = new Point(954, 29);
			this.textBox_44.Name = "txtLoadAverage";
			this.textBox_44.ReadOnly = true;
			this.textBox_44.Size = new Size(93, 20);
			this.textBox_44.TabIndex = 5;
			this.textBox_44.TextAlign = HorizontalAlignment.Right;
			this.textBox_45.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_45.BackColor = SystemColors.Info;
			this.textBox_45.Location = new Point(855, 29);
			this.textBox_45.Name = "labelParamUnitYearLoss";
			this.textBox_45.ReadOnly = true;
			this.textBox_45.Size = new Size(100, 20);
			this.textBox_45.TabIndex = 4;
			this.textBox_45.TabStop = false;
			this.textBox_45.Text = "Рср, МВт";
			this.textBox_46.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_46.BackColor = SystemColors.Info;
			this.textBox_46.Location = new Point(11, 29);
			this.textBox_46.Name = "labelUnitYearLoss";
			this.textBox_46.ReadOnly = true;
			this.textBox_46.Size = new Size(845, 20);
			this.textBox_46.TabIndex = 3;
			this.textBox_46.TabStop = false;
			this.textBox_46.Text = "Cреднее значение активной мощности за базовый период";
			this.textBox_47.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_47.BackColor = SystemColors.Info;
			this.textBox_47.Location = new Point(11, 86);
			this.textBox_47.Name = "labelCoefLoss";
			this.textBox_47.ReadOnly = true;
			this.textBox_47.Size = new Size(845, 20);
			this.textBox_47.TabIndex = 12;
			this.textBox_47.TabStop = false;
			this.textBox_47.Text = "Доля нагрузочных потерь в потребление активной электроэнергии";
			this.textBox_48.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_48.BackColor = SystemColors.Info;
			this.textBox_48.Location = new Point(855, 86);
			this.textBox_48.Name = "labelParamCoefLoss";
			this.textBox_48.ReadOnly = true;
			this.textBox_48.Size = new Size(100, 20);
			this.textBox_48.TabIndex = 13;
			this.textBox_48.TabStop = false;
			this.textBox_48.Text = "%";
			this.textBox_49.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_49.Location = new Point(954, 86);
			this.textBox_49.Name = "txtCoefLoss";
			this.textBox_49.ReadOnly = true;
			this.textBox_49.Size = new Size(93, 20);
			this.textBox_49.TabIndex = 14;
			this.textBox_49.TextAlign = HorizontalAlignment.Right;
			this.button_3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.button_3.Location = new Point(980, 734);
			this.button_3.Name = "buttonCancel";
			this.button_3.Size = new Size(75, 23);
			this.button_3.TabIndex = 3;
			this.button_3.Text = "Отмена";
			this.button_3.UseVisualStyleBackColor = true;
			this.button_3.Click += this.button_3_Click;
			this.richTextBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.richTextBox_0.DataBindings.Add(new Binding("Text", this.class498_0, "tJ_CalcLoss.Comment", true));
			this.richTextBox_0.Location = new Point(91, 112);
			this.richTextBox_0.Name = "txtComment";
			this.richTextBox_0.Size = new Size(955, 26);
			this.richTextBox_0.TabIndex = 16;
			this.richTextBox_0.Text = "";
			this.label_8.AutoSize = true;
			this.label_8.Location = new Point(8, 109);
			this.label_8.Name = "labelComment";
			this.label_8.Size = new Size(77, 13);
			this.label_8.TabIndex = 15;
			this.label_8.Text = "Комментарий";
			this.button_4.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.button_4.Location = new Point(100, 734);
			this.button_4.Name = "buttonPrint";
			this.button_4.Size = new Size(75, 23);
			this.button_4.TabIndex = 2;
			this.button_4.Text = "Печать";
			this.button_4.UseVisualStyleBackColor = true;
			this.button_4.Click += this.button_4_Click;
			this.tabControl_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Location = new Point(0, 0);
			this.tabControl_0.Name = "tabControl";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new Size(1062, 728);
			this.tabControl_0.TabIndex = 0;
			this.tabPage_0.Controls.Add(this.panel_0);
			this.tabPage_0.Controls.Add(this.dataGridView_1);
			this.tabPage_0.Controls.Add(this.label_11);
			this.tabPage_0.Controls.Add(this.tabControl_1);
			this.tabPage_0.Controls.Add(this.textBox_50);
			this.tabPage_0.Controls.Add(this.label_9);
			this.tabPage_0.Controls.Add(this.textBox_3);
			this.tabPage_0.Controls.Add(this.label_6);
			this.tabPage_0.Controls.Add(this.button_0);
			this.tabPage_0.Controls.Add(this.label_5);
			this.tabPage_0.Controls.Add(this.textBox_2);
			this.tabPage_0.Controls.Add(this.toolStrip_0);
			this.tabPage_0.Controls.Add(this.comboBox_1);
			this.tabPage_0.Controls.Add(this.label_3);
			this.tabPage_0.Controls.Add(this.textBox_1);
			this.tabPage_0.Controls.Add(this.label_4);
			this.tabPage_0.Controls.Add(this.textBox_0);
			this.tabPage_0.Controls.Add(this.label_2);
			this.tabPage_0.Controls.Add(this.comboBox_0);
			this.tabPage_0.Controls.Add(this.label_1);
			this.tabPage_0.Controls.Add(this.dateTimePicker_0);
			this.tabPage_0.Controls.Add(this.label_0);
			this.tabPage_0.Location = new Point(4, 22);
			this.tabPage_0.Name = "tabPageCalc";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.Size = new Size(1054, 702);
			this.tabPage_0.TabIndex = 0;
			this.tabPage_0.Text = "Расчет";
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.panel_0.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.panel_0.Controls.Add(this.richTextBox_0);
			this.panel_0.Controls.Add(this.textBox_37);
			this.panel_0.Controls.Add(this.textBox_36);
			this.panel_0.Controls.Add(this.textBox_35);
			this.panel_0.Controls.Add(this.textBox_40);
			this.panel_0.Controls.Add(this.textBox_39);
			this.panel_0.Controls.Add(this.label_8);
			this.panel_0.Controls.Add(this.textBox_38);
			this.panel_0.Controls.Add(this.textBox_43);
			this.panel_0.Controls.Add(this.textBox_49);
			this.panel_0.Controls.Add(this.textBox_42);
			this.panel_0.Controls.Add(this.textBox_48);
			this.panel_0.Controls.Add(this.textBox_41);
			this.panel_0.Controls.Add(this.textBox_47);
			this.panel_0.Controls.Add(this.textBox_46);
			this.panel_0.Controls.Add(this.textBox_44);
			this.panel_0.Controls.Add(this.textBox_45);
			this.panel_0.Location = new Point(0, 557);
			this.panel_0.Name = "panelBottom";
			this.panel_0.Size = new Size(1054, 145);
			this.panel_0.TabIndex = 21;
			this.dataGridView_1.AllowUserToAddRows = false;
			this.dataGridView_1.AllowUserToDeleteRows = false;
			this.dataGridView_1.AllowUserToResizeColumns = false;
			this.dataGridView_1.AllowUserToResizeRows = false;
			this.dataGridView_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dataGridView_1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_1.Columns.AddRange(new DataGridViewColumn[]
			{
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
				this.dataGridViewTextBoxColumn_24,
				this.dataGridViewTextBoxColumn_25
			});
			this.dataGridView_1.Location = new Point(13, 498);
			this.dataGridView_1.Name = "dgvMonthSum";
			this.dataGridView_1.ReadOnly = true;
			this.dataGridView_1.RowHeadersVisible = false;
			this.dataGridView_1.Size = new Size(1037, 57);
			this.dataGridView_1.TabIndex = 20;
			this.dataGridViewTextBoxColumn_14.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_14.HeaderText = "Январь";
			this.dataGridViewTextBoxColumn_14.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn_14.ReadOnly = true;
			this.dataGridViewTextBoxColumn_15.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_15.HeaderText = "Февраль";
			this.dataGridViewTextBoxColumn_15.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn_15.ReadOnly = true;
			this.dataGridViewTextBoxColumn_16.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_16.HeaderText = "Март";
			this.dataGridViewTextBoxColumn_16.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn_16.ReadOnly = true;
			this.dataGridViewTextBoxColumn_17.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_17.HeaderText = "Апрель";
			this.dataGridViewTextBoxColumn_17.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn_17.ReadOnly = true;
			this.dataGridViewTextBoxColumn_18.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_18.HeaderText = "Май";
			this.dataGridViewTextBoxColumn_18.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn_18.ReadOnly = true;
			this.dataGridViewTextBoxColumn_19.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_19.HeaderText = "Июнь";
			this.dataGridViewTextBoxColumn_19.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn_19.ReadOnly = true;
			this.dataGridViewTextBoxColumn_20.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_20.HeaderText = "Июль";
			this.dataGridViewTextBoxColumn_20.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn_20.ReadOnly = true;
			this.dataGridViewTextBoxColumn_21.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_21.HeaderText = "Август";
			this.dataGridViewTextBoxColumn_21.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn_21.ReadOnly = true;
			this.dataGridViewTextBoxColumn_22.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_22.HeaderText = "Сентябрь";
			this.dataGridViewTextBoxColumn_22.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn_22.ReadOnly = true;
			this.dataGridViewTextBoxColumn_23.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_23.HeaderText = "Октябрь";
			this.dataGridViewTextBoxColumn_23.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn_23.ReadOnly = true;
			this.dataGridViewTextBoxColumn_24.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_24.HeaderText = "Ноябрь";
			this.dataGridViewTextBoxColumn_24.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn_24.ReadOnly = true;
			this.dataGridViewTextBoxColumn_25.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_25.HeaderText = "Декабрь";
			this.dataGridViewTextBoxColumn_25.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn_25.ReadOnly = true;
			this.label_11.AutoSize = true;
			this.label_11.Location = new Point(12, 482);
			this.label_11.Name = "labeldgvMonthSum";
			this.label_11.Size = new Size(403, 13);
			this.label_11.TabIndex = 19;
			this.label_11.Text = "Суммарные потери электроэнергии холостого хода с разбивкой по месяцам:";
			this.tabControl_1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.tabControl_1.Controls.Add(this.tabPage_2);
			this.tabControl_1.Location = new Point(0, 140);
			this.tabControl_1.Name = "tabControlTrans";
			this.tabControl_1.SelectedIndex = 0;
			this.tabControl_1.Size = new Size(1058, 339);
			this.tabControl_1.TabIndex = 18;
			this.tabPage_2.Controls.Add(this.toolStrip_2);
			this.tabPage_2.Controls.Add(this.label_7);
			this.tabPage_2.Controls.Add(this.label_10);
			this.tabPage_2.Controls.Add(this.textBox_4);
			this.tabPage_2.Controls.Add(this.dataGridView_0);
			this.tabPage_2.Controls.Add(this.button_1);
			this.tabPage_2.Controls.Add(this.textBox_51);
			this.tabPage_2.Controls.Add(this.textBox_5);
			this.tabPage_2.Controls.Add(this.textBox_52);
			this.tabPage_2.Controls.Add(this.textBox_6);
			this.tabPage_2.Controls.Add(this.textBox_53);
			this.tabPage_2.Controls.Add(this.textBox_7);
			this.tabPage_2.Controls.Add(this.textBox_10);
			this.tabPage_2.Controls.Add(this.textBox_9);
			this.tabPage_2.Controls.Add(this.textBox_8);
			this.tabPage_2.Controls.Add(this.textBox_13);
			this.tabPage_2.Controls.Add(this.textBox_12);
			this.tabPage_2.Controls.Add(this.textBox_11);
			this.tabPage_2.Controls.Add(this.textBox_22);
			this.tabPage_2.Controls.Add(this.textBox_21);
			this.tabPage_2.Controls.Add(this.textBox_20);
			this.tabPage_2.Controls.Add(this.textBox_19);
			this.tabPage_2.Controls.Add(this.textBox_18);
			this.tabPage_2.Controls.Add(this.textBox_17);
			this.tabPage_2.Controls.Add(this.textBox_16);
			this.tabPage_2.Controls.Add(this.textBox_15);
			this.tabPage_2.Controls.Add(this.textBox_14);
			this.tabPage_2.Controls.Add(this.textBox_31);
			this.tabPage_2.Controls.Add(this.textBox_30);
			this.tabPage_2.Controls.Add(this.textBox_29);
			this.tabPage_2.Controls.Add(this.textBox_28);
			this.tabPage_2.Controls.Add(this.textBox_27);
			this.tabPage_2.Controls.Add(this.textBox_26);
			this.tabPage_2.Controls.Add(this.textBox_25);
			this.tabPage_2.Controls.Add(this.textBox_32);
			this.tabPage_2.Controls.Add(this.textBox_24);
			this.tabPage_2.Controls.Add(this.textBox_33);
			this.tabPage_2.Controls.Add(this.textBox_23);
			this.tabPage_2.Controls.Add(this.textBox_34);
			this.tabPage_2.Location = new Point(4, 22);
			this.tabPage_2.Name = "tabPageTrans1";
			this.tabPage_2.Padding = new Padding(3);
			this.tabPage_2.Size = new Size(1050, 313);
			this.tabPage_2.TabIndex = 0;
			this.tabPage_2.Text = "Т1";
			this.tabPage_2.UseVisualStyleBackColor = true;
			this.toolStrip_2.Dock = DockStyle.None;
			this.toolStrip_2.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_2.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_5,
				this.toolStripButton_6
			});
			this.toolStrip_2.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
			this.toolStrip_2.Location = new Point(0, 2);
			this.toolStrip_2.Name = "toolStripTrans1";
			this.toolStrip_2.Size = new Size(24, 25);
			this.toolStrip_2.TabIndex = 0;
			this.toolStrip_2.Text = "toolStrip1";
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = Resources.ElementAdd;
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolBtnAddTrans1";
			this.toolStripButton_5.Size = new Size(22, 20);
			this.toolStripButton_5.Text = "Добавить трансформатор";
			this.toolStripButton_5.Click += this.toolStripButton_5_Click;
			this.toolStripButton_6.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_6.Image = Resources.ElementDel;
			this.toolStripButton_6.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_6.Name = "toolBtnDelTrans1";
			this.toolStripButton_6.Size = new Size(22, 20);
			this.toolStripButton_6.Text = "Удалить трансформатор";
			this.toolStripButton_6.Visible = false;
			this.toolStripButton_6.Click += this.toolStripButton_6_Click;
			this.label_10.AutoSize = true;
			this.label_10.Location = new Point(6, 237);
			this.label_10.Name = "labelDgvMonth";
			this.label_10.Size = new Size(342, 13);
			this.label_10.TabIndex = 0;
			this.label_10.Text = "Потери электроэнергии холостого хода с разбивкой по месяцам:";
			this.dataGridView_0.AllowUserToAddRows = false;
			this.dataGridView_0.AllowUserToDeleteRows = false;
			this.dataGridView_0.AllowUserToResizeColumns = false;
			this.dataGridView_0.AllowUserToResizeRows = false;
			this.dataGridView_0.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
			{
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
				this.dataGridViewTextBoxColumn_13
			});
			this.dataGridView_0.Location = new Point(9, 253);
			this.dataGridView_0.Name = "dgvMonth";
			this.dataGridView_0.ReadOnly = true;
			this.dataGridView_0.RowHeadersVisible = false;
			this.dataGridView_0.Size = new Size(1037, 57);
			this.dataGridView_0.TabIndex = 1;
			this.dataGridView_0.CellValueChanged += this.dataGridView_0_CellValueChanged;
			this.dataGridViewTextBoxColumn_2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_2.HeaderText = "Январь";
			this.dataGridViewTextBoxColumn_2.Name = "colJanuary";
			this.dataGridViewTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_3.HeaderText = "Февраль";
			this.dataGridViewTextBoxColumn_3.Name = "colFebruary";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_4.HeaderText = "Март";
			this.dataGridViewTextBoxColumn_4.Name = "colMarch";
			this.dataGridViewTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewTextBoxColumn_5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_5.HeaderText = "Апрель";
			this.dataGridViewTextBoxColumn_5.Name = "colApril";
			this.dataGridViewTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewTextBoxColumn_6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_6.HeaderText = "Май";
			this.dataGridViewTextBoxColumn_6.Name = "colMay";
			this.dataGridViewTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewTextBoxColumn_7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_7.HeaderText = "Июнь";
			this.dataGridViewTextBoxColumn_7.Name = "colJune";
			this.dataGridViewTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewTextBoxColumn_8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_8.HeaderText = "Июль";
			this.dataGridViewTextBoxColumn_8.Name = "colJule";
			this.dataGridViewTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewTextBoxColumn_9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_9.HeaderText = "Август";
			this.dataGridViewTextBoxColumn_9.Name = "colAugust";
			this.dataGridViewTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewTextBoxColumn_10.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_10.HeaderText = "Сентябрь";
			this.dataGridViewTextBoxColumn_10.Name = "colSeptember";
			this.dataGridViewTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewTextBoxColumn_11.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_11.HeaderText = "Октябрь";
			this.dataGridViewTextBoxColumn_11.Name = "colOctober";
			this.dataGridViewTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewTextBoxColumn_12.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_12.HeaderText = "Ноябрь";
			this.dataGridViewTextBoxColumn_12.Name = "colNovember";
			this.dataGridViewTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewTextBoxColumn_13.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn_13.HeaderText = "Декабрь";
			this.dataGridViewTextBoxColumn_13.Name = "colDecember";
			this.dataGridViewTextBoxColumn_13.ReadOnly = true;
			this.textBox_51.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_51.Location = new Point(953, 99);
			this.textBox_51.Name = "txtRatedVoltage";
			this.textBox_51.Size = new Size(93, 20);
			this.textBox_51.TabIndex = 20;
			this.textBox_51.Tag = "RatedVoltage";
			this.textBox_51.TextAlign = HorizontalAlignment.Right;
			this.textBox_52.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.textBox_52.BackColor = SystemColors.ControlLight;
			this.textBox_52.Location = new Point(854, 99);
			this.textBox_52.Name = "textBox21";
			this.textBox_52.ReadOnly = true;
			this.textBox_52.Size = new Size(100, 20);
			this.textBox_52.TabIndex = 19;
			this.textBox_52.TabStop = false;
			this.textBox_52.Text = "Uном, кВ";
			this.textBox_53.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_53.BackColor = SystemColors.ControlLight;
			this.textBox_53.Location = new Point(9, 99);
			this.textBox_53.Name = "textBox24";
			this.textBox_53.ReadOnly = true;
			this.textBox_53.Size = new Size(848, 20);
			this.textBox_53.TabIndex = 15;
			this.textBox_53.TabStop = false;
			this.textBox_53.Text = "Номинальное напряжение высшей обмотки трансформатора";
			this.textBox_50.DataBindings.Add(new Binding("Text", this.class498_0, "tJ_CalcLoss.num", true));
			this.textBox_50.Location = new Point(326, 12);
			this.textBox_50.Name = "txtNum";
			this.textBox_50.ReadOnly = true;
			this.textBox_50.Size = new Size(85, 20);
			this.textBox_50.TabIndex = 3;
			this.label_9.AutoSize = true;
			this.label_9.Location = new Point(279, 14);
			this.label_9.Name = "label9";
			this.label_9.Size = new Size(41, 13);
			this.label_9.TabIndex = 2;
			this.label_9.Text = "Номер";
			this.tabPage_1.Controls.Add(this.dataGridViewExcelFilter_0);
			this.tabPage_1.Controls.Add(this.toolStrip_1);
			this.tabPage_1.Location = new Point(4, 22);
			this.tabPage_1.Name = "tabPageFile";
			this.tabPage_1.Padding = new Padding(3);
			this.tabPage_1.Size = new Size(1054, 702);
			this.tabPage_1.TabIndex = 1;
			this.tabPage_1.Text = "Файлы";
			this.tabPage_1.UseVisualStyleBackColor = true;
			this.dataGridViewExcelFilter_0.AllowUserToAddRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToDeleteRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToResizeColumns = false;
			this.dataGridViewExcelFilter_0.AllowUserToResizeRows = false;
			this.dataGridViewExcelFilter_0.AllowUserToVisibleColumns = false;
			this.dataGridViewExcelFilter_0.AutoGenerateColumns = false;
			this.dataGridViewExcelFilter_0.BackgroundColor = SystemColors.Window;
			this.dataGridViewExcelFilter_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewExcelFilter_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewImageColumnNotNull_0,
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewFilterTextBoxColumn_0,
				this.dataGridViewLinkColumn_0,
				this.dataGridViewTextBoxColumn_1
			});
			this.dataGridViewExcelFilter_0.DataSource = this.bindingSource_0;
			this.dataGridViewExcelFilter_0.Dock = DockStyle.Fill;
			this.dataGridViewExcelFilter_0.GridColor = SystemColors.Window;
			this.dataGridViewExcelFilter_0.Location = new Point(3, 28);
			this.dataGridViewExcelFilter_0.Name = "dgvFiles";
			this.dataGridViewExcelFilter_0.ReadOnly = true;
			this.dataGridViewExcelFilter_0.RowHeadersVisible = false;
			this.dataGridViewExcelFilter_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewExcelFilter_0.Size = new Size(1048, 671);
			this.dataGridViewExcelFilter_0.TabIndex = 2;
			this.dataGridViewExcelFilter_0.VirtualMode = true;
			this.dataGridViewExcelFilter_0.CellContentClick += this.dataGridViewExcelFilter_0_CellContentClick;
			this.dataGridViewExcelFilter_0.CellValueNeeded += this.dataGridViewExcelFilter_0_CellValueNeeded;
			dataGridViewCellStyle.NullValue = null;
			this.dataGridViewImageColumnNotNull_0.DefaultCellStyle = dataGridViewCellStyle;
			this.dataGridViewImageColumnNotNull_0.HeaderText = "";
			this.dataGridViewImageColumnNotNull_0.Name = "ColumnImage";
			this.dataGridViewImageColumnNotNull_0.ReadOnly = true;
			this.dataGridViewImageColumnNotNull_0.Resizable = DataGridViewTriState.False;
			this.dataGridViewImageColumnNotNull_0.Width = 20;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
			this.dataGridViewTextBoxColumn_0.HeaderText = "id";
			this.dataGridViewTextBoxColumn_0.Name = "idDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Visible = false;
			this.dataGridViewFilterTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewFilterTextBoxColumn_0.DataPropertyName = "idCalc";
			this.dataGridViewFilterTextBoxColumn_0.HeaderText = "idCalc";
			this.dataGridViewFilterTextBoxColumn_0.Name = "idCalcDataGridViewTextBoxColumn";
			this.dataGridViewFilterTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewFilterTextBoxColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewFilterTextBoxColumn_0.Visible = false;
			this.dataGridViewLinkColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewLinkColumn_0.DataPropertyName = "FileName";
			this.dataGridViewLinkColumn_0.HeaderText = "Файл";
			this.dataGridViewLinkColumn_0.Name = "fileNameDataGridViewTextBoxColumn";
			this.dataGridViewLinkColumn_0.ReadOnly = true;
			this.dataGridViewLinkColumn_0.Resizable = DataGridViewTriState.True;
			this.dataGridViewLinkColumn_0.SortMode = DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "DateIn";
			this.dataGridViewTextBoxColumn_1.HeaderText = "Дата";
			this.dataGridViewTextBoxColumn_1.Name = "dateInDgvColumn";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_1.Width = 120;
			this.bindingSource_0.DataMember = "tJ_CalcLossFile";
			this.bindingSource_0.DataSource = this.class498_0;
			this.toolStrip_1.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_1,
				this.toolStripButton_2,
				this.toolStripButton_3,
				this.toolStripButton_4
			});
			this.toolStrip_1.Location = new Point(3, 3);
			this.toolStrip_1.Name = "toolStripFile";
			this.toolStrip_1.Size = new Size(1048, 25);
			this.toolStrip_1.TabIndex = 1;
			this.toolStrip_1.Text = "toolStrip1";
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("toolBtnFileAdd.Image");
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolBtnFileAdd";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Добавить файлы";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = (Image)componentResourceManager.GetObject("toolBtnFileDelete.Image");
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolBtnFileDelete";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Удалить файлы";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = (Image)componentResourceManager.GetObject("toolBtnFileView.Image");
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolBtnFileView";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Просмотр файла";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = (Image)componentResourceManager.GetObject("toolBtnFileSave.Image");
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolBtnFileSave";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Сохранить файл";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1062, 760);
			base.Controls.Add(this.tabControl_0);
			base.Controls.Add(this.button_2);
			base.Controls.Add(this.button_4);
			base.Controls.Add(this.button_3);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			this.MinimumSize = new Size(550, 623);
			base.Name = "FormAddEditCalcTrans";
			this.Text = "Расчет потерь в трансформаторе";
			base.Load += this.FormAddEditCalcTrans_Load;
			((ISupportInitialize)this.class498_0).EndInit();
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.tabControl_0.ResumeLayout(false);
			this.tabPage_0.ResumeLayout(false);
			this.tabPage_0.PerformLayout();
			this.panel_0.ResumeLayout(false);
			this.panel_0.PerformLayout();
			((ISupportInitialize)this.dataGridView_1).EndInit();
			this.tabControl_1.ResumeLayout(false);
			this.tabPage_2.ResumeLayout(false);
			this.tabPage_2.PerformLayout();
			this.toolStrip_2.ResumeLayout(false);
			this.toolStrip_2.PerformLayout();
			((ISupportInitialize)this.dataGridView_0).EndInit();
			this.tabPage_1.ResumeLayout(false);
			this.tabPage_1.PerformLayout();
			((ISupportInitialize)this.dataGridViewExcelFilter_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			this.toolStrip_1.ResumeLayout(false);
			this.toolStrip_1.PerformLayout();
			base.ResumeLayout(false);
		}

		internal static void d4rGjq0RehnvqpWvPwLv(Form form_0, bool bool_2)
		{
			form_0.Dispose(bool_2);
		}

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private bool bool_0;

		private bool bool_1;

		private Label label_0;

		private DateTimePicker dateTimePicker_0;

		private Class498 class498_0;

		private Label label_1;

		private ComboBox comboBox_0;

		private Label label_2;

		private TextBox textBox_0;

		private ComboBox comboBox_1;

		private Label label_3;

		private TextBox textBox_1;

		private Label label_4;

		private ToolStrip toolStrip_0;

		private ToolStripButton toolStripButton_0;

		private TextBox textBox_2;

		private Label label_5;

		private Button button_0;

		private Label label_6;

		private TextBox textBox_3;

		private Label label_7;

		private TextBox textBox_4;

		private Button button_1;

		private TextBox textBox_5;

		private TextBox textBox_6;

		private TextBox textBox_7;

		private TextBox textBox_8;

		private TextBox textBox_9;

		private TextBox textBox_10;

		private TextBox textBox_11;

		private TextBox textBox_12;

		private TextBox textBox_13;

		private TextBox textBox_14;

		private TextBox textBox_15;

		private TextBox textBox_16;

		private TextBox textBox_17;

		private TextBox textBox_18;

		private TextBox textBox_19;

		private TextBox textBox_20;

		private TextBox textBox_21;

		private TextBox textBox_22;

		private TextBox textBox_23;

		private TextBox textBox_24;

		private TextBox textBox_25;

		private TextBox textBox_26;

		private TextBox textBox_27;

		private TextBox textBox_28;

		private TextBox textBox_29;

		private TextBox textBox_30;

		private TextBox textBox_31;

		private Button button_2;

		private TextBox textBox_32;

		private TextBox textBox_33;

		private TextBox textBox_34;

		private TextBox textBox_35;

		private TextBox textBox_36;

		private TextBox textBox_37;

		private TextBox textBox_38;

		private TextBox textBox_39;

		private TextBox textBox_40;

		private TextBox textBox_41;

		private TextBox textBox_42;

		private TextBox textBox_43;

		private TextBox textBox_44;

		private TextBox textBox_45;

		private TextBox textBox_46;

		private TextBox textBox_47;

		private TextBox textBox_48;

		private TextBox textBox_49;

		private Button button_3;

		private RichTextBox richTextBox_0;

		private Label label_8;

		private Button button_4;

		private TabControl tabControl_0;

		private TabPage tabPage_0;

		private TabPage tabPage_1;

		private TextBox textBox_50;

		private Label label_9;

		private ToolStrip toolStrip_1;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripButton toolStripButton_3;

		private ToolStripButton toolStripButton_4;

		private DataGridViewExcelFilter dataGridViewExcelFilter_0;

		private BindingSource bindingSource_0;

		private DataGridViewImageColumnNotNull dataGridViewImageColumnNotNull_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewFilterTextBoxColumn dataGridViewFilterTextBoxColumn_0;

		private DataGridViewLinkColumn dataGridViewLinkColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private TextBox textBox_51;

		private TextBox textBox_52;

		private TextBox textBox_53;

		private Label label_10;

		private DataGridView dataGridView_0;

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

		private TabControl tabControl_1;

		private TabPage tabPage_2;

		private ToolStrip toolStrip_2;

		private ToolStripButton toolStripButton_5;

		private ToolStripButton toolStripButton_6;

		private DataGridView dataGridView_1;

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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_25;

		private Label label_11;

		private Panel panel_0;
	}
}
