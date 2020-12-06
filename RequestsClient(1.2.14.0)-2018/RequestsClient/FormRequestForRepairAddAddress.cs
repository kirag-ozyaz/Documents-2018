using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ControlsLbr;
using DataSql;
using FormLbr;
/// <summary>
/// Добавление адреса
/// </summary>
internal partial class FormRequestForRepairAddAddress : FormBase
{
	public override SQLSettings SqlSettings
	{
		get
		{
			return base.SqlSettings;
		}
		set
		{
			base.SqlSettings = value;
			if (value != null)
			{
				this.kladrStreetControl.SqlSettings = value;
			}
		}
	}

	internal FormRequestForRepairAddAddress()
	{

		this.dataTable_0 = new DataTable();
		this.InitializeComponent();
	}

	private void kladrStreetControl_ChangeTypeHouseSelect(object sender, EventArgs e)
	{
		if (((ComboBox)sender).SelectedIndex == ((ComboBox)sender).Items.Count - 1)
		{
			this.listBoxHouse.Enabled = true;
			return;
		}
		this.listBoxHouse.Enabled = false;
	}

	private void kladrStreetControl_ChangeStreetSelect(object sender, EventArgs e)
	{
		this.method_0();
	}

	private void kladrStreetControl_ChangeRaionOblSelect(object sender, EventArgs e)
	{
		this.method_0();
	}

	private void kladrStreetControl_ChangePunktsSelect(object sender, EventArgs e)
	{
		this.method_0();
	}

	private void kladrStreetControl_ChangeOblSelect(object sender, EventArgs e)
	{
		this.method_0();
	}

	private void method_0()
	{
		this.listBoxHouse.Items.Clear();
		if (this.kladrStreetControl.SelectedStreet.SelectedIndex >= 0)
		{
			DataTable dataTable = new DataTable("tMapObj");
			base.SelectSqlData(dataTable, true, " left join tAbnObj obj on tMapObj.idMap = obj.idMap  left join tAbn abn on abn.id = obj.idabn  where not abn.id is null and tMapObj.Street = " + this.kladrStreetControl.SelectedStreet.SelectedValue.ToString() + " order by house, houseprefix", null, true, 0);
			foreach (object obj in dataTable.Rows)
			{
				DataRow dataRow = (DataRow)obj;
				this.listBoxHouse.Items.Add(new Class2(dataRow["House"].ToString() + dataRow["HousePrefix"].ToString(), Convert.ToInt32(dataRow["IdMap"])));
			}
		}
	}

	private void buttonCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		base.Close();
	}

	private void buttonOK_Click(object sender, EventArgs e)
	{
		if (this.kladrStreetControl.SelectedStreet.SelectedIndex < 0)
		{
			MessageBox.Show("Не выбрана улица");
			return;
		}
		if (this.kladrStreetControl.SelectedHouseType.SelectedIndex >= 0 && (!(this.kladrStreetControl.SelectedHouseType.SelectedItem.ToString() == "Отдельные дома") || this.listBoxHouse.SelectedItems.Count != 0))
		{
			this.dataTable_0.Columns.Clear();
			this.dataTable_0.Columns.Add("idKladrObj", typeof(int));
			this.dataTable_0.Columns.Add("idstreet", typeof(int));
			this.dataTable_0.Columns.Add("house", typeof(string));
			this.dataTable_0.Rows.Clear();
			int num;
			if (this.kladrStreetControl.SelectedCity.SelectedIndex < 0)
			{
				num = Convert.ToInt32(this.kladrStreetControl.SelectedRaionObl.SelectedValue);
			}
			else
			{
				num = Convert.ToInt32(this.kladrStreetControl.SelectedCity.SelectedValue);
			}
			int num2 = Convert.ToInt32(this.kladrStreetControl.SelectedStreet.SelectedValue);
			if (Convert.ToInt32(this.kladrStreetControl.SelectedHouseType.SelectedValue) == 0)
			{
				using (IEnumerator enumerator = this.listBoxHouse.SelectedItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						Class2 @class = (Class2)obj;
						this.dataTable_0.Rows.Add(new object[]
						{
							num,
							num2,
							@class.Name
						});
					}
					goto IL_247;
				}
			}
			foreach (object obj2 in this.listBoxHouse.Items)
			{
				Class2 class2 = (Class2)obj2;
				this.dataTable_0.Rows.Add(new object[]
				{
					num,
					num2,
					class2.Name
				});
			}
			IL_247:
			base.DialogResult = DialogResult.OK;
			base.Close();
			return;
		}
		MessageBox.Show("Не выбраны дома");
	}

	public DataTable dataTable_0;
}
