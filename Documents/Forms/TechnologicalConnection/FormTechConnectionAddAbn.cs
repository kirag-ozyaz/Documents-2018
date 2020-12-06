using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Constants;
using Contractor.Forms;
using ControlsLbr.DataGridViewExcelFilter;
using FormLbr;
using FormLbr.Classes;

namespace Documents.Forms.TechnologicalConnection
{
	public partial class FormTechConnectionAddAbn : FormBase
    {
        private string string_0;

        private int idAbn = -1;
        //private int IdAbnObj;
        //private string NameAbnObj;
        private int TypeAbn = -1;
        private bool IsSelect;

        internal int IdAbn
        {
            get
            {
                return this.idAbn;
            }
            set
            {
                this.idAbn = value;
            }
        }

        internal int IdAbnObj
        {
            get; set;
        } = -1;

        internal int GetIdAbnObj()
		{
			return this.IdAbnObj;
		}

		internal void SetIdAbnObj(int value)
		{
			this.IdAbnObj = value;
		}

		internal string AbnName { get; private set; }

		internal string NameAbnObj { get; set; }
		internal string GetNameAbnObj()
		{
			return this.NameAbnObj;
		}
		private void SetNameAbnObj(string value)
		{
			this.NameAbnObj = value;
		}

		public FormTechConnectionAddAbn()
		{
			this.InitializeComponent();
			this.FullAddressConsumer();
		}

		internal FormTechConnectionAddAbn(int idAbn = -1, int idAbnObj = -1, bool isSelect = false)
		{
			this.InitializeComponent();
			this.IdAbn = idAbn;
            this.IdAbnObj = idAbnObj;
			this.IsSelect = isSelect;
			this.FullAddressConsumer();
		}

		private void FullAddressConsumer()
		{
            // vAbnObjAddress
            // DataSetTC
            // this.tableAbnObjAddress = new Class10.Class16();
            this.tableAbnObjAddress = new DataSetTC.vAbnObjAddressDataTable();
            
			DataColumn dataColumn = new DataColumn("AddressFL");
			dataColumn.Expression = "isnull(street + ', ', '') + 'д. ' + houseall + isnull(' - ' + name, '')";
			this.tableAbnObjAddress.Columns.Add(dataColumn);
			dataColumn = new DataColumn("AddressUL");
			dataColumn.Expression = "isnull(street + ', ', '') + 'д. ' + houseall";
			this.tableAbnObjAddress.Columns.Add(dataColumn);
			this.addressFLDgvColumn.DataPropertyName = "AddressFL";
			this.addressULDgvColumn.DataPropertyName = "AddressUL";
			this.bsAbnObjAddress.DataSource = this.tableAbnObjAddress;
			if (!this.IsSelect)
			{
				Control control = this.buttonОК;
				this.buttonCancel.Visible = false;
				control.Visible = false;
				this.Text = "Контрагенты";
				this.splitContainerDgv.Height += 33;
				this.tabControlContr.Top += 33;
			}
		}

		private void FormTechConnectionAddAbn_Load(object sender, EventArgs e)
		{
			if (this.IdAbn != -1)
			{
				//Class10 ds = new Class10();
                DataSetTC ds = new DataSetTC();

                base.SelectSqlData(ds, ds.vAbn, true, "where id = " + this.IdAbn.ToString());
				if (ds.vAbn.Rows.Count > 0)
				{
					int typeAbn = Convert.ToInt32(ds.vAbn.Rows[0]["typeAbn"]);
					if (typeAbn == 1037 || typeAbn == 206 || typeAbn == 253)
					{
						this.radioButtonFL.Checked = true;
					}
					this.txtCurrentAbn.Text = ds.vAbn.Rows[0]["Name"].ToString();
				}
			}
			this.FullAddressSubject();
			this.LoadAbn();
		}

		private void LoadAbn()
		{
			int idAbn = this.idAbn;
			int idAbnObj = this.IdAbnObj;
			string strIsDelAbn = this.toolBtnShowDelAbn.Checked ? " " : " and deleted = 0 ";
			string strIsActiveAbn = this.chkVisibleNoActiveAbn.Checked ? " " : " and (isActive = 1 or isActive is null) ";
			strIsDelAbn += strIsActiveAbn;
			string strWhere = string.Empty;
			foreach (AbnType abnType in Enum.GetValues(typeof(AbnType)))
			{

				if (abnType != AbnType.KontragentFL && abnType != AbnType.Private && abnType != AbnType.PrivateNoDog)
				{
					if (!string.IsNullOrEmpty(strWhere))
					{
						strWhere += ",";
					}
					string str2 = strWhere;
					int AbnType = (int)abnType;
					strWhere = str2 + AbnType.ToString();
				}
			}
			if (this.radioButtonUL.Checked)
			{
				if (this.radioButtonSelectName.Checked)
				{
					base.SelectSqlData(this.dsTU, this.dsTU.vAbn, true, string.Concat(new string[]
					{
						" where typeAbn in (",
						strWhere,
						") ",
						strIsDelAbn,
						" order by name"
					}));
					if (!string.IsNullOrEmpty(this.txtCurrentAbn.Text))
					{
						this.bsAbn.Filter = "Name like '%" + this.txtCurrentAbn.Text + "%'";
					}
					else
					{
						this.bsAbn.Filter = "";
					}
				}
				else
				{
					if (this.cmbStreet.SelectedIndex < 0)
					{
						if (this.cmbPunkt.SelectedIndex < 0)
						{
							if (this.cmbCity.SelectedIndex < 0)
							{
								base.SelectSqlData(this.dsTU, this.dsTU.vAbn, true, string.Concat(new string[]
								{
									" where typeAbn in (",
									strWhere,
									") ",
									strIsDelAbn,
									" order by name"
								}));
							}
							else
							{
								base.SelectSqlData(this.dsTU, this.dsTU.vAbn, true, string.Concat(new string[]
								{
									" where typeAbn in (",
									strWhere,
									") ",
									strIsDelAbn,
									" and id in (select idAbn from vAbnObjAddress where idCity = ",
									this.cmbCity.SelectedValue.ToString(),
									")  order by name"
								}));
							}
						}
						else
						{
							base.SelectSqlData(this.dsTU, this.dsTU.vAbn, true, string.Concat(new string[]
							{
								" where typeAbn in (",
								strWhere,
								") ",
								strIsDelAbn,
								" and id in (select idAbn from vAbnObjAddress where idCity = ",
								this.cmbPunkt.SelectedValue.ToString(),
								")  order by name"
							}));
						}
					}
					else if (string.IsNullOrEmpty(this.txtHouse.Text) && string.IsNullOrEmpty(this.txtHousePrefix.Text))
					{
						base.SelectSqlData(this.dsTU, this.dsTU.vAbn, true, string.Concat(new string[]
						{
							" where typeAbn in (",
							strWhere,
							") ",
							strIsDelAbn,
							" and id in (select idAbn from vAbnObjAddress where idStreet = ",
							this.cmbStreet.SelectedValue.ToString(),
							")  order by name"
						}));
					}
					else
					{
						base.SelectSqlData(this.dsTU, this.dsTU.vAbn, true, string.Concat(new string[]
						{
							" where typeAbn in (",
							strWhere,
							") ",
							strIsDelAbn,
							" and id in (select idAbn from vAbnObjAddress where idStreet = ",
							this.cmbStreet.SelectedValue.ToString(),
							" and HouseAll like '%",
							this.txtHouse.Text,
							this.txtHousePrefix.Text,
							"%')  order by name"
						}));
					}
					this.bsAbn.Filter = "";
				}
			}
			else if (this.radioButtonSelectName.Checked)
			{
				if (string.IsNullOrEmpty(this.txtCurrentAbn.Text))
				{
					this.dsTU.vAbn.Clear();
				}
				else
				{
					base.SelectSqlData(this.dsTU, this.dsTU.vAbn, true, string.Concat(new string[]
					{
						" where name like '%",
						this.txtCurrentAbn.Text,
						"%' and typeAbn not in (",
						strWhere,
						") ",
						strIsDelAbn,
						" order by name"
					}));
				}
			}
			else
			{
				if (this.cmbStreet.SelectedIndex < 0)
				{
					this.dsTU.vAbn.Clear();
				}
				else if (string.IsNullOrEmpty(this.txtHouse.Text) && string.IsNullOrEmpty(this.txtHousePrefix.Text))
				{
					base.SelectSqlData(this.dsTU, this.dsTU.vAbn, true, string.Concat(new string[]
					{
						" where typeAbn not in (",
						strWhere,
						") ",
						strIsDelAbn,
						" and id in (select idAbn from vAbnObjAddress where idStreet = ",
						this.cmbStreet.SelectedValue.ToString(),
						")  order by name"
					}));
				}
				else
				{
					base.SelectSqlData(this.dsTU, this.dsTU.vAbn, true, string.Concat(new string[]
					{
						" where typeAbn not in (",
						strWhere,
						") ",
						strIsDelAbn,
						" and id in (select idAbn from vAbnObjAddress where idStreet = ",
						this.cmbStreet.SelectedValue.ToString(),
						" and HouseAll like '%",
						this.txtHouse.Text,
						this.txtHousePrefix.Text,
						"%')  order by name"
					}));
				}
				this.bsAbn.Filter = "";
			}
			this.dgvAbn.SearchGrid(this.dataGridViewTextBoxColumn_37.Name, idAbn.ToString(), false);
			this.dgvObj.SearchGrid(this.dataGridViewTextBoxColumn_10.Name, idAbnObj.ToString(), false);
		}

		private void radioButtonUL_CheckedChanged(object sender, EventArgs e)
		{
			if (this.radioButtonUL.Checked)
			{
				this.addressFLDgvColumn.Visible = false;
				this.addressULDgvColumn.Visible = true;
				this.dataGridViewTextBoxColumn_14.Visible = true;
				if (!this.tabControlContr.TabPages.Contains(this.tabPageDirector))
				{
					this.tabControlContr.TabPages.Insert(1, this.tabPageDirector);
				}
				if (!string.IsNullOrEmpty(this.txtCurrentAbn.Text))
				{
					this.bsAbn.Filter = "Name like '%" + this.txtCurrentAbn.Text + "%'";
				}
				else
				{
					this.bsAbn.Filter = "";
				}
			}
			else
			{
				this.addressFLDgvColumn.Visible = true;
				this.addressULDgvColumn.Visible = false;
				this.dataGridViewTextBoxColumn_14.Visible = false;
				if (this.tabControlContr.TabPages.Contains(this.tabPageDirector))
				{
					this.tabControlContr.TabPages.Remove(this.tabPageDirector);
				}
				this.bsAbn.Filter = "";
			}
			this.LoadAbn();
		}

		private void txtCurrentAbn_TextChanged(object sender, EventArgs e)
		{
			if (!this.radioButtonUL.Checked)
			{
				this.timer1.Stop();
				this.timer1.Start();
				return;
			}
			if (!string.IsNullOrEmpty(this.txtCurrentAbn.Text))
			{
				this.bsAbn.Filter = "Name like '%" + this.txtCurrentAbn.Text + "%'";
				return;
			}
			this.bsAbn.Filter = "";
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.LoadAbn();
			this.timer1.Stop();
		}

		private void bsAbn_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bsAbn.Current != null)
			{
				this.idAbn = Convert.ToInt32(((DataRowView)this.bsAbn.Current)["id"]);
				this.TypeAbn = Convert.ToInt32(((DataRowView)this.bsAbn.Current)["typeAbn"]);
				this.AbnName = ((DataRowView)this.bsAbn.Current)["name"].ToString();
				base.SelectSqlData(this.tableAbnObjAddress, true, "where idAbn = " + this.idAbn.ToString(), null, false, 0);
				base.SelectSqlData(this.dsTU.vG_AbnInfo, true, " where idAbn = " + this.idAbn.ToString() + " order by DateChange desc", null, false, 1);
				base.SelectSqlData(this.dsTU.tG_AbnChief, true, " where idAbn = " + this.idAbn.ToString() + " order by DateChange desc", null, false, 1);
				base.SelectSqlData(this.dsTU.vG_AbnAddressL, true, " where idAbn = " + this.idAbn.ToString() + " order by DateChange desc", null, false, 1);
				base.SelectSqlData(this.dsTU.vG_AbnAddressP, true, " where idAbn = " + this.idAbn.ToString() + " order by DateChange desc", null, false, 1);
				base.SelectSqlData(this.dsTU.tAbnContact, true, " where idAbn = " + this.idAbn.ToString() + " order by DateChange desc", null, false, 0);
				base.SelectSqlData(this.dsTU.vAbnType, true, " where idAbn = " + this.idAbn.ToString(), null, false, 0);
				return;
			}
			this.idAbn = -1;
			this.TypeAbn = -1;
			this.AbnName = null;
			this.tableAbnObjAddress.Clear();
			this.dsTU.vG_AbnInfo.Clear();
			this.dsTU.tG_AbnChief.Clear();
			this.dsTU.vG_AbnAddressL.Clear();
			this.dsTU.vG_AbnAddressP.Clear();
			this.dsTU.tAbnContact.Clear();
			this.dsTU.vAbnType.Clear();
		}

		private void bsAbnObjAddress_CurrentChanged(object sender, EventArgs e)
		{
			if (this.bsAbnObjAddress.Current == null)
			{
				this.IdAbnObj = -1;
				this.SetNameAbnObj(null);
				return;
			}
			this.IdAbnObj = Convert.ToInt32(((DataRowView)this.bsAbnObjAddress.Current)["id"]);
			if (this.radioButtonFL.Checked)
			{
				this.SetNameAbnObj(((DataRowView)this.bsAbnObjAddress.Current)["AddressFl"].ToString());
				return;
			}
			this.SetNameAbnObj(((DataRowView)this.bsAbnObjAddress.Current)["Name"].ToString());
		}

		private bool method_6()
		{
			if (this.TypeAbn != 207 && this.TypeAbn != 231 && this.TypeAbn != 206 && this.TypeAbn != 253)
			{
				if (this.TypeAbn != 230)
				{
					return true;
				}
			}
			return false;
		}

		private void radioButtonSelectName_CheckedChanged(object sender, EventArgs e)
		{
			this.txtCurrentAbn.Enabled = this.radioButtonSelectName.Checked;
			this.cmbObl.Enabled = !this.radioButtonSelectName.Checked;
			this.cmbCity.Enabled = !this.radioButtonSelectName.Checked;
			this.cmbPunkt.Enabled = !this.radioButtonSelectName.Checked;
			this.cmbStreet.Enabled = !this.radioButtonSelectName.Checked;
			this.txtHouse.Enabled = !this.radioButtonSelectName.Checked;
			this.txtHousePrefix.Enabled = !this.radioButtonSelectName.Checked;
			this.txtFlat.Enabled = !this.radioButtonSelectName.Checked;
			this.LoadAbn();
		}
        /// <summary>
        /// найдем субъект страны и основные муниципальные образования
        /// </summary>
		private void FullAddressSubject()
		{
			if (this.SqlSettings != null)
			{
				base.SelectSqlData(this.tblKladrObjSubject, true, " where PrimaryKey = 'Subject' and deleted = 0 order by name, socr", null, false, 0);
				if (this.cmbObl.SelectedIndex >= 0)
				{
					base.SelectSqlData(this.tblKladrObjRaion, true, " where ParentId = " + this.cmbObl.SelectedValue.ToString() + " and deleted = 0 order by name, socr", null, false, 0);
					this.cmbCity.Text = "Ульяновск г";
				}
			}
		}

		private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbObl.SelectedIndex < 0)
			{
				this.dsKladrObj.Tables["tR_KladrObj"].Clear();
				return;
			}
			base.SelectSqlData(this.tblKladrObjRaion, true, " where ParentId = " + this.cmbObl.SelectedValue.ToString() + " and deleted = 0 order by name, socr", null, false, 0);
		}

		private void comboBox_3_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbCity.SelectedIndex < 0)
			{
				this.dsKladr.Tables["tR_KladrObj"].Clear();
				this.dsKladrStreet.Tables["tR_KladrStreet"].Clear();
			}
			else
			{
				base.SelectSqlData(this.tblKladrObj, true, " where ParentId = " + this.cmbCity.SelectedValue.ToString() + " and deleted = 0 order by name, socr", null, false, 0);
				this.cmbPunkt.SelectedIndex = -1;
				base.SelectSqlData(this.tableKladrStreet, true, " where KladrObjId = " + this.cmbCity.SelectedValue + " and deleted = 0 order by name, socr ", null, false, 0);
				this.cmbStreet.SelectedIndex = -1;
			}
			this.LoadAbn();
		}

		private void cmbPunkt_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbPunkt.SelectedIndex >= 0)
			{
				base.SelectSqlData(this.tableKladrStreet, true, " where KladrObjId = " + this.cmbPunkt.SelectedValue + " and deleted = 0 order by name, socr ", null, false, 0);
			}
			else if (this.cmbCity.SelectedIndex >= 0)
			{
				base.SelectSqlData(this.tableKladrStreet, true, " where KladrObjId = " + this.cmbCity.SelectedValue + " and deleted = 0 order by name, socr ", null, false, 0);
			}
			this.cmbStreet.SelectedIndex = -1;
			this.LoadAbn();
		}

		private void cmbStreet_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.LoadAbn();
		}

		private void txtHouse_TextChanged(object sender, EventArgs e)
		{
			this.LoadAbn();
		}

		private void txtHousePrefix_TextChanged(object sender, EventArgs e)
		{
			this.LoadAbn();
		}

		private void textBox_1_TextChanged(object sender, EventArgs e)
		{
			this.LoadAbn();
		}

		private void toolBtnAddCont_Click(object sender, EventArgs e)
		{
			FormAddEditContracor formAddEditContracor = new FormAddEditContracor(-1, this.radioButtonFL.Checked ? AbnType.KontragentFL : AbnType.KontragentLegal, string.IsNullOrEmpty(this.txtCurrentAbn.Text) ? "NoName" : this.txtCurrentAbn.Text);
			formAddEditContracor.SqlSettings = this.SqlSettings;
			if (formAddEditContracor.ShowDialog() == DialogResult.OK)
			{
				if (formAddEditContracor.TypeAbn == AbnType.KontragentLegal)
				{
					this.radioButtonUL.Checked = true;
				}
				else
				{
					this.radioButtonFL.Checked = true;
				}
				this.txtCurrentAbn.Text = formAddEditContracor.NameAbn;
				this.LoadAbn();
				this.dgvAbn.SearchGrid(this.dataGridViewTextBoxColumn_37.Name, formAddEditContracor.Id.ToString(), false);
			}
		}

		private void toolBtnEditCont_Click(object sender, EventArgs e)
		{
			if (this.bsAbn.Current != null)
			{
				if (!this.method_6())
				{
					MessageBox.Show("Редактирование данного контрагента невозможно");
					return;
				}
				FormAddEditContracor formAddEditContracor = new FormAddEditContracor(this.idAbn, this.radioButtonFL.Checked ? AbnType.KontragentFL : AbnType.KontragentLegal, string.IsNullOrEmpty(this.txtCurrentAbn.Text) ? "NoName" : this.txtCurrentAbn.Text);
				formAddEditContracor.SqlSettings = this.SqlSettings;
				if (formAddEditContracor.ShowDialog() == DialogResult.OK)
				{
					if (formAddEditContracor.TypeAbn == AbnType.KontragentLegal)
					{
						this.radioButtonUL.Checked = true;
					}
					else
					{
						this.radioButtonFL.Checked = true;
					}
					this.txtCurrentAbn.Text = formAddEditContracor.NameAbn;
					this.LoadAbn();
					this.dgvAbn.SearchGrid(this.dataGridViewTextBoxColumn_37.Name, this.idAbn.ToString(), false);
				}
			}
		}

		private void toolBtnDelCont_Click(object sender, EventArgs e)
		{
			if (this.dgvAbn.CurrentRow != null)
			{
				if (!this.method_6())
				{
					MessageBox.Show("Удаление данного контрагента невозможно");
					return;
				}
				if (MessageBox.Show(Convert.ToBoolean(this.dgvAbn.CurrentRow.Cells[this.deletedKontragentDgvColumn.Name].Value) ? "Вы действительно хотите восстановить текущего контрагента" : "Вы действительно хотите удалить текущего контрагента?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					int num = -1;
					if (this.dgvAbn.CurrentRow.Index > 0)
					{
						num = Convert.ToInt32(this.dgvAbn.Rows[this.dgvAbn.CurrentRow.Index - 1].Cells[this.dataGridViewTextBoxColumn_37.Name].Value);
					}
					Class10 @class = new Class10();
					base.SelectSqlData(@class, @class.tAbn, true, "where id = " + this.idAbn);
					@class.tAbn.Rows[0]["Deleted"] = !Convert.ToBoolean(@class.tAbn.Rows[0]["Deleted"]);
					@class.tAbn.Rows[0].EndEdit();
					if (base.UpdateSqlData(@class, @class.tAbn))
					{
						if (Convert.ToBoolean(@class.tAbn.Rows[0]["Deleted"]))
						{
							MessageBox.Show("Абонент успешно удален");
						}
						else
						{
							MessageBox.Show("Абонент успешно восстановлен");
						}
					}
					this.LoadAbn();
					if (Convert.ToBoolean(@class.tAbn.Rows[0]["Deleted"]) && !this.toolBtnShowDelAbn.Checked)
					{
						this.dgvAbn.SearchGrid(this.dataGridViewTextBoxColumn_37.Name, num.ToString(), false);
					}
				}
			}
		}

		private void toolBtnShowDelAbn_Click(object sender, EventArgs e)
		{
			this.LoadAbn();
		}

		private void dataGridViewExcelFilter_0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				if (Convert.ToInt32(this.dgvAbn[this.dataGridViewTextBoxColumn_40.Name, e.RowIndex].Value) == 206)
				{
					e.CellStyle.ForeColor = Color.Blue;
				}
				if (Convert.ToInt32(this.dgvAbn[this.dataGridViewTextBoxColumn_40.Name, e.RowIndex].Value) == 207)
				{
					e.CellStyle.ForeColor = Color.Green;
				}
				if (Convert.ToInt32(this.dgvAbn[this.dataGridViewTextBoxColumn_40.Name, e.RowIndex].Value) == 231)
				{
					e.CellStyle.ForeColor = Color.Red;
				}
				if (Convert.ToInt32(this.dgvAbn[this.dataGridViewTextBoxColumn_40.Name, e.RowIndex].Value) == 230)
				{
					e.CellStyle.ForeColor = Color.Purple;
				}
				if (Convert.ToBoolean(this.dgvAbn[this.deletedKontragentDgvColumn.Name, e.RowIndex].Value))
				{
					e.CellStyle.ForeColor = Color.Red;
				}
				if (this.dgvAbn[this.isActiveDgvColumn.Name, e.RowIndex].Value != DBNull.Value && !Convert.ToBoolean(this.dgvAbn[this.isActiveDgvColumn.Name, e.RowIndex].Value))
				{
					e.CellStyle.BackColor = Color.Yellow;
				}
			}
		}

		private void toolBtnAddObj_Click(object sender, EventArgs e)
		{
			KontragentObjType typeObj = (this.TypeAbn == 206 || this.TypeAbn == 253 || this.TypeAbn == 1037) ? KontragentObjType.KontragentObjFL : KontragentObjType.KontragentObjLegal;
			if (new FormAddEditObj(this.idAbn, -1, FormAddEditObj.ActionAbnObj.Add, -1, FormAddEditObj.ActionAbnObjReg.Add, this.TypeAbn, typeObj)
			{
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				base.SelectSqlData(this.tableAbnObjAddress, true, "where idAbn = " + this.idAbn.ToString(), null, false, 0);
			}
		}

		private void toolBtnEditObj_Click(object sender, EventArgs e)
		{
			if (this.dgvObj.CurrentRow != null)
			{
				int idObj = Convert.ToInt32(this.dgvObj.CurrentRow.Cells[this.dataGridViewTextBoxColumn_10.Name].Value);
				int idObjReg = (this.dgvObj.CurrentRow.Cells[this.idObjRegDgvColumn.Name].Value == DBNull.Value) ? 0 : Convert.ToInt32(this.dgvObj.CurrentRow.Cells[this.idObjRegDgvColumn.Name].Value);
				KontragentObjType typeObj = (this.TypeAbn == 206 || this.TypeAbn == 253 || this.TypeAbn == 1037) ? KontragentObjType.KontragentObjFL : KontragentObjType.KontragentObjLegal;
				base.SelectSqlData(this.dsTU, this.dsTU.tAbnObj, true, "where id = " + idObj.ToString());
				if (this.dsTU.tAbnObj.Rows.Count > 0 && (this.dsTU.tAbnObj.Rows[0]["typeObj"] == DBNull.Value || (Convert.ToInt32(this.dsTU.tAbnObj.Rows[0]["typeObj"]) != 1148 && Convert.ToInt32(this.dsTU.tAbnObj.Rows[0]["typeObj"]) != 1149)))
				{
					MessageBox.Show("Редактирование данного объекта невозможно");
					return;
				}
				if (new FormAddEditObj(this.idAbn, idObj, FormAddEditObj.ActionAbnObj.Edit, idObjReg, FormAddEditObj.ActionAbnObjReg.Edit, this.TypeAbn, typeObj)
				{
					SqlSettings = this.SqlSettings
				}.ShowDialog() == DialogResult.OK)
				{
					base.SelectSqlData(this.tableAbnObjAddress, true, "where idAbn = " + this.idAbn.ToString(), null, false, 0);
					return;
				}
			}
			else
			{
				MessageBox.Show("Нечего редактировать.");
			}
		}

		private void toolBtnDelObj_Click(object sender, EventArgs e)
		{
			if (this.dgvObj.CurrentRow != null && MessageBox.Show("Удалить текущий объект?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes && MessageBox.Show("Уверены? ВСЕ ТЕКУЩИЕ ДАННЫЕ БУДУТ ПОТЕРЯНЫ!!!", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				MessageBox.Show("Функция отключена. Обратитесь в ОА.");
			}
		}

		private void tsbAddAbnInfo_Click(object sender, EventArgs e)
		{
			if (!this.method_6())
			{
				MessageBox.Show("Редактирование данного контрагента невозможно");
				return;
			}
			ShowFormEventArgs showFormEventArgs = new ShowFormEventArgs();
			showFormEventArgs.TypeForm = "Legal.Forms.FormAbnDetails, Legal";
			showFormEventArgs.FormMode = eFormMode.Dialog;
			showFormEventArgs.Param = new object[2];
			showFormEventArgs.Param[0] = this.idAbn;
			showFormEventArgs.Param[1] = true;
			showFormEventArgs.SQLSettings = this.SqlSettings;
			this.OnShowForm(showFormEventArgs);
			if (showFormEventArgs.DialogResult == DialogResult.OK)
			{
				base.SelectSqlData(this.dsTU.vG_AbnInfo, true, " where idAbn = " + this.idAbn.ToString() + " order by DateChange desc", null, false, 1);
			}
		}

		private void tsbEditInfo_Click(object sender, EventArgs e)
		{
			if (!this.method_6())
			{
				MessageBox.Show("Редактирование данного контрагента невозможно");
				return;
			}
			ShowFormEventArgs showFormEventArgs = new ShowFormEventArgs();
			showFormEventArgs.TypeForm = "Legal.Forms.FormAbnDetails, Legal";
			showFormEventArgs.FormMode = eFormMode.Dialog;
			showFormEventArgs.Param = new object[2];
			showFormEventArgs.Param[0] = this.idAbn;
			showFormEventArgs.Param[1] = false;
			showFormEventArgs.SQLSettings = this.SqlSettings;
			this.OnShowForm(showFormEventArgs);
			if (showFormEventArgs.DialogResult == DialogResult.OK)
			{
				base.SelectSqlData(this.dsTU.vG_AbnInfo, true, " where idAbn = " + this.idAbn.ToString() + " order by DateChange desc", null, false, 1);
			}
		}

		private void tsbInfoHistory_Click(object sender, EventArgs e)
		{
			ShowFormEventArgs showFormEventArgs = new ShowFormEventArgs();
			showFormEventArgs.TypeForm = "Legal.Forms.FormAbnDetailsHistory, Legal";
			if (base.MdiParent == null)
			{
				showFormEventArgs.FormMode = eFormMode.Dialog;
			}
			else
			{
				showFormEventArgs.FormMode = eFormMode.Mdi;
			}
			showFormEventArgs.Param = new object[1];
			showFormEventArgs.Param[0] = this.idAbn;
			showFormEventArgs.SQLSettings = this.SqlSettings;
			this.OnShowForm(showFormEventArgs);
		}

		private void tsbDirectorAdd_Click(object sender, EventArgs e)
		{
			if (!this.method_6())
			{
				MessageBox.Show("Редактирование данного контрагента невозможно");
				return;
			}
			ShowFormEventArgs showFormEventArgs = new ShowFormEventArgs();
			showFormEventArgs.TypeForm = "Legal.Forms.FormAbnChief, Legal";
			showFormEventArgs.FormMode = eFormMode.Dialog;
			showFormEventArgs.Param = new object[2];
			showFormEventArgs.Param[0] = this.idAbn;
			showFormEventArgs.Param[1] = true;
			showFormEventArgs.SQLSettings = this.SqlSettings;
			this.OnShowForm(showFormEventArgs);
			if (showFormEventArgs.DialogResult == DialogResult.OK)
			{
				base.SelectSqlData(this.dsTU.tG_AbnChief, true, " where idAbn = " + this.idAbn.ToString() + " order by DateChange desc", null, false, 1);
			}
		}

		private void tsbDirectorEdit_Click(object sender, EventArgs e)
		{
			if (!this.method_6())
			{
				MessageBox.Show("Редактирование данного контрагента невозможно");
				return;
			}
			ShowFormEventArgs showFormEventArgs = new ShowFormEventArgs();
			showFormEventArgs.TypeForm = "Legal.Forms.FormAbnChief, Legal";
			showFormEventArgs.FormMode = eFormMode.Dialog;
			showFormEventArgs.Param = new object[2];
			showFormEventArgs.Param[0] = this.idAbn;
			showFormEventArgs.Param[1] = false;
			showFormEventArgs.SQLSettings = this.SqlSettings;
			this.OnShowForm(showFormEventArgs);
			if (showFormEventArgs.DialogResult == DialogResult.OK)
			{
				base.SelectSqlData(this.dsTU.tG_AbnChief, true, " where idAbn = " + this.idAbn.ToString() + " order by DateChange desc", null, false, 1);
			}
		}

		private void tsbDirectorHistory_Click(object sender, EventArgs e)
		{
			ShowFormEventArgs showFormEventArgs = new ShowFormEventArgs();
			showFormEventArgs.TypeForm = "Legal.Forms.FormAbnChiefHistory, Legal";
			showFormEventArgs.FormMode = ((base.MdiParent == null) ? eFormMode.Dialog : eFormMode.Mdi);
			showFormEventArgs.Param = new object[1];
			showFormEventArgs.Param[0] = this.idAbn;
			showFormEventArgs.SQLSettings = this.SqlSettings;
			this.OnShowForm(showFormEventArgs);
		}

		private void tsbAddressHistory_Click(object sender, EventArgs e)
		{
			if (!this.method_6())
			{
				MessageBox.Show("Редактирование данного контрагента невозможно");
				return;
			}
			ShowFormEventArgs showFormEventArgs = new ShowFormEventArgs();
			showFormEventArgs.TypeForm = "Legal.Forms.FormAbnAddressHistory, Legal";
			showFormEventArgs.FormMode = eFormMode.Dialog;
			showFormEventArgs.Param = new object[1];
			showFormEventArgs.Param[0] = this.idAbn;
			showFormEventArgs.SQLSettings = this.SqlSettings;
			this.OnShowForm(showFormEventArgs);
			if (showFormEventArgs.DialogResult == DialogResult.OK)
			{
				base.SelectSqlData(this.dsTU.vG_AbnAddressL, true, " where idAbn = " + this.idAbn.ToString() + " order by DateChange desc", null, false, 1);
				base.SelectSqlData(this.dsTU.vG_AbnAddressP, true, " where idAbn = " + this.idAbn.ToString() + " order by DateChange desc", null, false, 1);
			}
		}

		private void toolStripButton_7_Click(object sender, EventArgs e)
		{
			ShowFormEventArgs showFormEventArgs = new ShowFormEventArgs();
			showFormEventArgs.TypeForm = "Legal.Forms.FormAbnContactAdd, Legal";
			showFormEventArgs.FormMode = eFormMode.Dialog;
			showFormEventArgs.Param = new object[2];
			showFormEventArgs.Param[0] = this.idAbn;
			showFormEventArgs.Param[1] = true;
			showFormEventArgs.SQLSettings = this.SqlSettings;
			this.OnShowForm(showFormEventArgs);
			if (showFormEventArgs.DialogResult == DialogResult.OK)
			{
				base.SelectSqlData(this.dsTU, this.dsTU.tAbnContact, true, " where idAbn = " + this.idAbn.ToString() + " order by DateChange desc");
			}
		}

		private void toolStripButton_8_Click(object sender, EventArgs e)
		{
			ShowFormEventArgs showFormEventArgs = new ShowFormEventArgs();
			showFormEventArgs.TypeForm = "Legal.Forms.FormAbnContactAdd, Legal";
			showFormEventArgs.FormMode = eFormMode.Dialog;
			showFormEventArgs.Param = new object[2];
			showFormEventArgs.Param[0] = Convert.ToInt32(this.dGVAbnContact.CurrentRow.Cells["idDGVTBC"].Value);
			showFormEventArgs.Param[1] = false;
			showFormEventArgs.SQLSettings = this.SqlSettings;
			this.OnShowForm(showFormEventArgs);
			if (showFormEventArgs.DialogResult == DialogResult.OK)
			{
				base.SelectSqlData(this.dsTU, this.dsTU.tAbnContact, true, " where idAbn = " + this.idAbn.ToString() + " order by DateChange desc");
			}
		}

		private void toolStripButton_9_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Хотите удалить контакт?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				base.DeleteSqlDataById(this.dsTU.tAbnContact, Convert.ToInt32(this.dGVAbnContact.CurrentRow.Cells["idDGVTBC"].Value));
				base.SelectSqlData(this.dsTU, this.dsTU.tAbnContact, true, " where idAbn = " + this.idAbn.ToString() + " order by DateChange desc");
			}
		}

		private void buttonОК_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void toolStripButton_17_Click(object sender, EventArgs e)
		{
			if (this.idAbn != -1 && new FormaddEditAbnType(-1, this.idAbn)
			{
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				base.SelectSqlData(this.dsTU, this.dsTU.vAbnType, true, " where idAbn = " + this.idAbn.ToString());
			}
		}

		private void toolStripButton_18_Click(object sender, EventArgs e)
		{
			if (this.idAbn != -1 && this.dgvAbnType.CurrentRow != null && new FormaddEditAbnType(Convert.ToInt32(this.dgvAbnType.CurrentRow.Cells[this.dataGridViewTextBoxColumn_33.Name].Value), this.idAbn)
			{
				SqlSettings = this.SqlSettings
			}.ShowDialog() == DialogResult.OK)
			{
				base.SelectSqlData(this.dsTU, this.dsTU.vAbnType, true, " where idAbn = " + this.idAbn.ToString());
			}
		}

		private void toolStripButton_19_Click(object sender, EventArgs e)
		{
			if (this.dgvAbnType.CurrentRow != null && MessageBox.Show("Вы действительно хотите удалить текущую запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				base.DeleteSqlDataById(this.dsTU.tAbnType, Convert.ToInt32(this.dgvAbnType.CurrentRow.Cells[this.dataGridViewTextBoxColumn_33.Name].Value));
				base.SelectSqlData(this.dsTU, this.dsTU.vAbnType, true, " where idAbn = " + this.idAbn.ToString());
				MessageBox.Show("Запись успешно удалена");
			}
		}

		private void chkVisibleNoActiveAbn_CheckedChanged(object sender, EventArgs e)
		{
			this.LoadAbn();
		}

	}
}
