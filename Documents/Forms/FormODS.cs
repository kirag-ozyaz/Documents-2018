using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataSql;
using Documents.Properties;
using FormLbr;

namespace Documents.Forms
{
	public partial class FormODS : FormBase
	{
		public FormODS()
		{
			
			this.string_0 = string.Empty;
			this.string_1 = string.Empty;
			this.string_2 = string.Empty;
			this.formFilter_0 = new FormFilter();
			
			this.method_4();
			this.dataGridView_0.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
		}

		internal FormODS(SQLSettings SqlSettings)
		{
			
			this.string_0 = string.Empty;
			this.string_1 = string.Empty;
			this.string_2 = string.Empty;
			this.formFilter_0 = new FormFilter();
			
			this.method_4();
			this.SqlSettings = SqlSettings;
			this.dataGridView_0.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
		}

		private void FormODS_Load(object sender, EventArgs e)
		{
			this.formFilter_0.Deactivate += this.formFilter_0_Deactivate;
			this.formFilter_0.ShowPeriodApplication = false;
			this.formFilter_0.Legal = true;
			this.formFilter_0.Individual = true;
			this.formFilter_0.UsePeriodExecution = true;
			this.formFilter_0.BeginningOfPeriodExecution = DateTime.Today;
			this.formFilter_0.EndOfPeriodExecution = DateTime.Today;
			this.formFilter_0.Disconnection = true;
			this.formFilter_0.Resumption = true;
			this.formFilter_0.Cancel = true;
			this.formFilter_0.NetArea1 = true;
			this.formFilter_0.NetArea2 = true;
			this.formFilter_0.NetArea3 = true;
			this.formFilter_0.NetArea4 = true;
			this.formFilter_0.ODS = true;
			this.formFilter_0.SESNO = true;
			this.method_2();
		}

		private void formFilter_0_Deactivate(object sender, EventArgs e)
		{
			this.method_2();
		}

		private void method_0()
		{
			if (this.bindingSource_0.Count > 0)
			{
				this.class548_0.Class565_0.Clear();
			}
			if (!this.formFilter_0.SkipUnperformed && !this.bool_0)
			{
				this.class586_0.vmethod_10(this.class548_0.tblAbnAplForDisconObjects, new DateTime?(this.formFilter_0.BeginningOfPeriodExecution));
				foreach (object obj in this.bindingSource_1)
				{
					Class548.Class568 @class = (Class548.Class568)((DataRowView)obj).Row;
					this.bindingSource_0.AddNew();
					Class548.Class583 class2 = (Class548.Class583)((DataRowView)this.bindingSource_0.Current).Row;
					class2.legal = true;
					class2.AbnObjId = @class.Id;
					switch (@class.NetArea)
					{
					case 0:
						class2.NetArea = "1";
						break;
					case 1:
						class2.NetArea = "2";
						break;
					case 2:
						class2.NetArea = "3";
						break;
					case 3:
						class2.NetArea = "4";
						break;
					case 4:
						class2.NetArea = "ОДС";
						break;
					case 5:
						class2.NetArea = "СЭСНО";
						break;
					}
					class2.NumDoc = @class.IdAplForDiscon.ToString();
					if (!@class.method_34())
					{
						Class548.Class583 class3 = class2;
						class3.NumDoc = class3.NumDoc + ", " + @class.ReasonCaption;
					}
					if (!@class.method_56())
					{
						class2.Sent = @class.Sent.ToString("dd.MM.yyyy HH:mm");
					}
					if (!@class.method_16())
					{
						class2.Code = @class.Code.ToString();
						if (!@class.method_20())
						{
							class2.Title = @class.AbnObj;
						}
					}
					else
					{
						class2.Code = "б/д";
						class2.Title = @class.NoDogObj;
					}
					if (!@class.method_8())
					{
						class2.Point = @class.PlaceId;
					}
					class2.TypeAction = @class.TypeAction;
					switch (@class.TypeAction)
					{
					case 0:
						class2.TypeActionCaption = "Отключение";
						break;
					case 1:
						class2.TypeActionCaption = "Возобновление";
						break;
					case 2:
						class2.TypeActionCaption = "Отмена";
						break;
					}
					class2.DateAction = @class.DateAction;
					if (!@class.method_24())
					{
						class2.DateExec = @class.DateExec;
					}
					if (!@class.method_28())
					{
						class2.ReasonFailure = @class.ReasonFailure;
					}
					if (!@class.method_26())
					{
						class2.FIOExec = @class.String_0;
						if (!@class.method_38())
						{
							Class548.Class583 class4 = class2;
							class4.FIOExec = class4.FIOExec + " (" + @class.NetAreaExecDescription + ")";
						}
					}
					if (!@class.method_12())
					{
						class2.Comments = @class.Comments;
					}
					if (!@class.method_22() && @class.TypeAction != 2)
					{
						class2.IdCancelApl = @class.IdCancelApl;
						class2.NumCancelApl = @class.IdCancelApl.ToString();
					}
				}
				this.class590_0.vmethod_10(this.class548_0.tblAbnAplForDisconIndividualUsers, new DateTime?(this.formFilter_0.BeginningOfPeriodExecution));
				foreach (object obj2 in this.bindingSource_2)
				{
					Class548.Class572 class5 = (Class548.Class572)((DataRowView)obj2).Row;
					this.bindingSource_0.AddNew();
					Class548.Class583 class6 = (Class548.Class583)((DataRowView)this.bindingSource_0.Current).Row;
					class6.legal = false;
					class6.AbnObjId = class5.Id;
					switch (class5.NetArea)
					{
					case 0:
						class6.NetArea = "1";
						break;
					case 1:
						class6.NetArea = "2";
						break;
					case 2:
						class6.NetArea = "3";
						break;
					case 3:
						class6.NetArea = "4";
						break;
					case 4:
						class6.NetArea = "ОДС";
						break;
					case 5:
						class6.NetArea = "СЭСНО";
						break;
					}
					class6.NumDoc = class5.IdAplForDiscon + ", " + class5.ReasonCaption;
					if (!class5.method_44())
					{
						class6.Sent = class5.Sent.ToString("dd.MM.yyyy HH:mm");
					}
					if (!class5.method_18())
					{
						class6.Code = class5.Code.ToString();
					}
					if (!class5.method_2())
					{
						class6.Title = class5.FIO;
						if (!class5.method_4())
						{
							Class548.Class583 class7 = class6;
							class7.Title = class7.Title + ",\r\n" + class5.Address;
						}
					}
					else if (!class5.method_4())
					{
						class6.Title = class5.Address;
					}
					if (!class5.method_24())
					{
						class6.Point = class5.Point;
					}
					switch (class5.TypeAction)
					{
					case 0:
						class6.TypeActionCaption = "Отключение";
						break;
					case 1:
						class6.TypeActionCaption = "Возобновление";
						break;
					case 2:
						class6.TypeActionCaption = "Отмена";
						break;
					}
					class6.DateAction = class5.DateAction;
					if (!class5.method_28())
					{
						class6.DateExec = class5.DateExec;
					}
					if (!class5.method_33())
					{
						class6.ReasonFailure = class5.ReasonFailure;
					}
					if (!class5.method_30())
					{
						class6.FIOExec = class5.String_0 + " (" + class5.NetAreaExecDescription + ")";
					}
					if (!class5.method_12())
					{
						class6.Comments = class5.Comments;
					}
					if (!class5.method_22() && class5.TypeAction != 2)
					{
						class6.IdCancelApl = class5.IdCancelApl;
						class6.NumCancelApl = class5.IdCancelApl.ToString();
					}
					if (!class5.method_43())
					{
						class6.Matrix = class5.Matrix;
					}
				}
			}
			this.class585_0.vmethod_0(this.class548_0.tblAbnAplForDiscon);
			this.bindingSource_3.Filter = this.string_0;
			this.method_1();
			this.bindingSource_0.Filter = this.string_2;
			this.bindingSource_0.Sort = "DateAction";
		}

		private void method_1()
		{
			using (IEnumerator enumerator = this.bindingSource_3.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Class548.Class567 @class = (Class548.Class567)((DataRowView)enumerator.Current).Row;
					if (@class.LegalAbns)
					{
						if (this.bool_0)
						{
							this.class586_0.vmethod_8(this.class548_0.tblAbnAplForDisconObjects, new int?(@class.Id));
						}
						else
						{
							this.class586_0.vmethod_0(this.class548_0.tblAbnAplForDisconObjects, new int?(@class.Id));
						}
						this.bindingSource_1.Filter = this.string_1;
						using (IEnumerator enumerator2 = this.bindingSource_1.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								object obj = enumerator2.Current;
								Class548.Class568 class2 = (Class548.Class568)((DataRowView)obj).Row;
								this.bindingSource_0.AddNew();
								Class548.Class583 class3 = (Class548.Class583)((DataRowView)this.bindingSource_0.Current).Row;
								class3.legal = true;
								class3.AbnObjId = class2.Id;
								switch (@class.NetArea)
								{
								case 0:
									class3.NetArea = "1";
									break;
								case 1:
									class3.NetArea = "2";
									break;
								case 2:
									class3.NetArea = "3";
									break;
								case 3:
									class3.NetArea = "4";
									break;
								case 4:
									class3.NetArea = "ОДС";
									break;
								case 5:
									class3.NetArea = "СЭСНО";
									break;
								}
								class3.NumDoc = @class.Id.ToString();
								if (!class2.method_34())
								{
									Class548.Class583 class4 = class3;
									class4.NumDoc = class4.NumDoc + ", " + class2.ReasonCaption;
								}
								if (!@class.method_18())
								{
									class3.Sent = @class.Sent.ToString("dd.MM.yyyy HH:mm");
								}
								if (!class2.method_16())
								{
									class3.Code = class2.Code.ToString();
									if (!class2.method_20())
									{
										class3.Title = class2.AbnObj;
									}
								}
								else
								{
									class3.Code = "б/д";
									class3.Title = class2.NoDogObj;
								}
								if (!class2.method_8())
								{
									class3.Point = class2.PlaceId;
								}
								class3.TypeAction = @class.TypeAction;
								switch (@class.TypeAction)
								{
								case 0:
									class3.TypeActionCaption = "Отключение";
									break;
								case 1:
									class3.TypeActionCaption = "Возобновление";
									break;
								case 2:
									class3.TypeActionCaption = "Отмена";
									break;
								}
								class3.DateAction = @class.DateAction;
								if (@class.TypeAction == 0 && !class2.method_58())
								{
									if (class2.IsFullRestriction)
									{
										class3.IsFullRestriction = "Полное";
									}
									else
									{
										class3.IsFullRestriction = "Частичное";
									}
								}
								if (!class2.method_24())
								{
									class3.DateExec = class2.DateExec;
								}
								if (!class2.method_28())
								{
									class3.ReasonFailure = class2.ReasonFailure;
								}
								if (!class2.method_26())
								{
									class3.FIOExec = class2.String_0 + " (" + class2.NetAreaExecDescription + ")";
								}
								if (!class2.method_12())
								{
									class3.Comments = class2.Comments;
								}
								if (!class2.method_22() && @class.TypeAction != 2)
								{
									class3.IdCancelApl = class2.IdCancelApl;
									class3.NumCancelApl = class2.IdCancelApl.ToString();
								}
								if (!class2.method_46())
								{
									class3.Matrix = class2.Matrix;
								}
							}
							goto IL_732;
						}
						goto IL_3A0;
					}
					goto IL_3A0;
					IL_732:
					this.bindingSource_0.EndEdit();
					continue;
					IL_3A0:
					if (this.bool_0)
					{
						this.class590_0.vmethod_4(this.class548_0.tblAbnAplForDisconIndividualUsers, new int?(@class.Id));
					}
					else
					{
						this.class590_0.vmethod_0(this.class548_0.tblAbnAplForDisconIndividualUsers, new int?(@class.Id));
					}
					this.bindingSource_2.Filter = this.string_1;
					foreach (object obj2 in this.bindingSource_2)
					{
						Class548.Class572 class5 = (Class548.Class572)((DataRowView)obj2).Row;
						this.bindingSource_0.AddNew();
						Class548.Class583 class6 = (Class548.Class583)((DataRowView)this.bindingSource_0.Current).Row;
						class6.legal = false;
						class6.AbnObjId = class5.Id;
						switch (@class.NetArea)
						{
						case 0:
							class6.NetArea = "1";
							break;
						case 1:
							class6.NetArea = "2";
							break;
						case 2:
							class6.NetArea = "3";
							break;
						case 3:
							class6.NetArea = "4";
							break;
						case 4:
							class6.NetArea = "ОДС";
							break;
						case 5:
							class6.NetArea = "СЭСНО";
							break;
						}
						class6.NumDoc = @class.Id + ", " + class5.ReasonCaption;
						if (!@class.method_18())
						{
							class6.Sent = @class.Sent.ToString("dd.MM.yyyy HH:mm");
						}
						if (!class5.method_18())
						{
							class6.Code = class5.Code.ToString();
						}
						if (!class5.method_2())
						{
							class6.Title = class5.FIO;
							if (!class5.method_4())
							{
								Class548.Class583 class7 = class6;
								class7.Title = class7.Title + ",\r\n" + class5.Address;
							}
						}
						else if (!class5.method_4())
						{
							class6.Title = class5.Address;
						}
						if (!class5.method_24())
						{
							class6.Point = class5.Point;
						}
						switch (@class.TypeAction)
						{
						case 0:
							class6.TypeActionCaption = "Отключение";
							break;
						case 1:
							class6.TypeActionCaption = "Возобновление";
							break;
						case 2:
							class6.TypeActionCaption = "Отмена";
							break;
						}
						class6.DateAction = @class.DateAction;
						if (@class.TypeAction == 0 && !class5.method_54())
						{
							if (class5.IsFullRestriction)
							{
								class6.IsFullRestriction = "Полное";
							}
							else
							{
								class6.IsFullRestriction = "Частичное";
							}
						}
						if (!class5.method_28())
						{
							class6.DateExec = class5.DateExec;
						}
						if (!class5.method_33())
						{
							class6.ReasonFailure = class5.ReasonFailure;
						}
						if (!class5.method_30())
						{
							class6.FIOExec = class5.String_0;
							if (!class5.method_39())
							{
								Class548.Class583 class8 = class6;
								class8.FIOExec = class8.FIOExec + " (" + class5.NetAreaExecDescription + ")";
							}
						}
						if (!class5.method_12())
						{
							class6.Comments = class5.Comments;
						}
						if (!class5.method_22() && @class.TypeAction != 2)
						{
							class6.IdCancelApl = class5.IdCancelApl;
							class6.NumCancelApl = class5.IdCancelApl.ToString();
						}
						if (!class5.method_43())
						{
							class6.Matrix = class5.Matrix;
						}
					}
					goto IL_732;
				}
			}
		}

		private void method_2()
		{
			this.Cursor = Cursors.WaitCursor;
			this.string_0 = string.Empty;
			this.string_1 = string.Empty;
			this.string_2 = string.Empty;
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			if (this.formFilter_0.UsePeriodExecution)
			{
				string item = string.Concat(new string[]
				{
					"DateAction>='",
					this.formFilter_0.BeginningOfPeriodExecution.ToString(),
					"' and DateAction<='",
					this.formFilter_0.EndOfPeriodExecution.ToString(),
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
			if (!this.formFilter_0.Disconnection && !this.bool_0)
			{
				list.Add("TypeAction<>0");
			}
			if (!this.formFilter_0.Resumption && !this.bool_0)
			{
				list.Add("TypeAction<>1");
			}
			if (!this.formFilter_0.Cancel && !this.bool_0)
			{
				list.Add("TypeAction<>2");
			}
			if (this.formFilter_0.DoNotDisplayCancelled && !this.bool_0)
			{
				list3.Add("IdCancelApl is null");
			}
			if (this.formFilter_0.DoNotDisplayPerformed && !this.bool_0)
			{
				list2.Add("DateExec is null");
			}
			if (this.formFilter_0.DoNotDisplayUnperformed || this.bool_0)
			{
				list2.Add("DateExec not is null");
			}
			if (this.formFilter_0.SkipUnsent && !this.bool_0)
			{
				list.Add("Sent NOT IS NULL");
			}
			if (!this.formFilter_0.NetArea1)
			{
				list.Add("NetArea<>0");
			}
			if (!this.formFilter_0.NetArea2)
			{
				list.Add("NetArea<>1");
			}
			if (!this.formFilter_0.NetArea3)
			{
				list.Add("NetArea<>2");
			}
			if (!this.formFilter_0.NetArea4)
			{
				list.Add("NetArea<>3");
			}
			if (!this.formFilter_0.ODS)
			{
				list.Add("NetArea<>4");
			}
			if (!this.formFilter_0.SESNO)
			{
				list.Add("NetArea<>5");
			}
			if (list.Count == 0 && list2.Count == 0 && list3.Count == 0)
			{
				this.method_0();
			}
			else
			{
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
				this.string_0 = stringBuilder.ToString();
				stringBuilder = new StringBuilder();
				flag = false;
				foreach (string value2 in list2)
				{
					if (flag)
					{
						stringBuilder.Append(" AND ");
					}
					else
					{
						flag = true;
					}
					stringBuilder.Append(value2);
				}
				this.string_1 = stringBuilder.ToString();
				stringBuilder = new StringBuilder();
				flag = false;
				foreach (string value3 in list3)
				{
					if (flag)
					{
						stringBuilder.Append(" AND ");
					}
					else
					{
						flag = true;
					}
					stringBuilder.Append(value3);
				}
				this.string_2 = stringBuilder.ToString();
				this.method_0();
			}
			this.Cursor = Cursors.Default;
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			this.formFilter_0.Location = new Point(base.Location.X + 25 + base.MdiParent.Location.X, base.Location.Y + 110 + base.MdiParent.Location.Y);
			this.formFilter_0.Show();
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			DateTime dateTime_ = DateTime.MinValue;
			DateTime dateTime_2 = DateTime.MinValue;
			if (this.formFilter_0.UsePeriodExecution)
			{
				dateTime_ = this.formFilter_0.BeginningOfPeriodExecution;
				dateTime_2 = this.formFilter_0.EndOfPeriodExecution;
			}
			new Form11(dateTime_, dateTime_2, this.SqlSettings)
			{
				bindingSource_7 = 
				{
					DataSource = this.bindingSource_0
				},
				MdiParent = base.MdiParent
			}.Show();
		}

		private void toolStripButton_2_Click(object sender, EventArgs e)
		{
			this.method_3();
		}

		private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			this.method_3();
		}

		private void method_3()
		{
			Class548.Class583 @class = (Class548.Class583)((DataRowView)this.bindingSource_0.Current).Row;
			Form12 form;
			if (@class.legal)
			{
				this.class586_0.vmethod_4(this.class548_0.tblAbnAplForDisconObjects, new int?(@class.AbnObjId));
				form = new Form12(true, this.bindingSource_1[0], this.SqlSettings);
			}
			else
			{
				this.class590_0.vmethod_6(this.class548_0.tblAbnAplForDisconIndividualUsers, @class.AbnObjId);
				form = new Form12(false, this.bindingSource_2[0], this.SqlSettings);
			}
			if (form.ShowDialog() == DialogResult.OK)
			{
				if (@class.legal)
				{
					this.class586_0.vmethod_12(this.class548_0.tblAbnAplForDisconObjects);
				}
				else
				{
					this.class590_0.vmethod_12(this.class548_0.tblAbnAplForDisconIndividualUsers);
				}
				int position = this.bindingSource_0.Position;
				this.class585_0.vmethod_0(this.class548_0.tblAbnAplForDiscon);
				this.method_0();
				this.bindingSource_0.Position = position;
			}
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			SearchForm searchForm = new SearchForm();
			searchForm.radioButtonLegal.Checked = true;
			searchForm.comboBoxSearchType.SelectedIndex = 0;
			if (searchForm.ShowDialog() == DialogResult.OK)
			{
				this.bindingSource_3.Filter = string.Empty;
				if (searchForm.radioButtonLegal.Checked)
				{
					if (searchForm.comboBoxSearchType.SelectedIndex == 0)
					{
						this.class586_0.vmethod_2(this.class548_0.tblAbnAplForDisconObjects, "%" + searchForm.textBoxName.Text + "%");
					}
					else if (searchForm.comboBoxSearchType.SelectedIndex == 1)
					{
						this.class586_0.vmethod_6(this.class548_0.tblAbnAplForDisconObjects, "%" + searchForm.textBoxName.Text + "%");
					}
					this.bindingSource_1.RemoveFilter();
					if (this.bindingSource_0.Count > 0)
					{
						this.class548_0.Class565_0.Clear();
					}
					using (IEnumerator enumerator = this.bindingSource_1.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							Class548.Class568 @class = (Class548.Class568)((DataRowView)obj).Row;
							if (!@class.method_2())
							{
								this.class585_0.vmethod_2(this.class548_0.tblAbnAplForDiscon, new int?(@class.IdAplForDiscon));
								this.bindingSource_3.RemoveFilter();
								Class548.Class567 class2 = (Class548.Class567)((DataRowView)this.bindingSource_3[0]).Row;
								this.bindingSource_0.AddNew();
								Class548.Class583 class3 = (Class548.Class583)((DataRowView)this.bindingSource_0.Current).Row;
								class3.legal = true;
								class3.AbnObjId = @class.Id;
								switch (class2.NetArea)
								{
								case 0:
									class3.NetArea = "1";
									break;
								case 1:
									class3.NetArea = "2";
									break;
								case 2:
									class3.NetArea = "3";
									break;
								case 3:
									class3.NetArea = "4";
									break;
								case 4:
									class3.NetArea = "ОДС";
									break;
								case 5:
									class3.NetArea = "СЭСНО";
									break;
								}
								class3.NumDoc = class2.Id.ToString();
								if (!@class.method_34())
								{
									Class548.Class583 class4 = class3;
									class4.NumDoc = class4.NumDoc + ", " + @class.ReasonCaption;
								}
								if (!class2.method_18())
								{
									class3.Sent = class2.Sent.ToString("dd.MM.yyyy HH:mm");
								}
								if (!@class.method_16())
								{
									class3.Code = @class.Code.ToString();
									if (!@class.method_20())
									{
										class3.Title = @class.AbnObj;
									}
								}
								else
								{
									class3.Code = "б/д";
									class3.Title = @class.NoDogObj;
								}
								if (!@class.method_8())
								{
									class3.Point = @class.PlaceId;
								}
								class3.TypeAction = class2.TypeAction;
								switch (class2.TypeAction)
								{
								case 0:
									class3.TypeActionCaption = "Отключение";
									break;
								case 1:
									class3.TypeActionCaption = "Возобновление";
									break;
								case 2:
									class3.TypeActionCaption = "Отмена";
									break;
								}
								class3.DateAction = class2.DateAction;
								if (!@class.method_24())
								{
									class3.DateExec = @class.DateExec;
								}
								if (!@class.method_28())
								{
									class3.ReasonFailure = @class.ReasonFailure;
								}
								if (!@class.method_26())
								{
									class3.FIOExec = @class.String_0 + " (" + @class.NetAreaExecDescription + ")";
								}
								if (!@class.method_12())
								{
									class3.Comments = @class.Comments;
								}
								if (!@class.method_22() && class2.TypeAction != 2)
								{
									class3.IdCancelApl = @class.IdCancelApl;
									class3.NumCancelApl = @class.IdCancelApl.ToString();
								}
								if (!@class.method_46())
								{
									class3.Matrix = @class.Matrix;
								}
							}
						}
						return;
					}
				}
				if (searchForm.radioButtonIndiviual.Checked)
				{
					if (searchForm.textBoxName.Text == string.Empty)
					{
						return;
					}
					if (searchForm.comboBoxSearchType.SelectedIndex == 0)
					{
						this.class590_0.vmethod_8(this.class548_0.tblAbnAplForDisconIndividualUsers, "%" + searchForm.textBoxName.Text + "%");
					}
					else if (searchForm.comboBoxSearchType.SelectedIndex == 1)
					{
						this.class590_0.vmethod_2(this.class548_0.tblAbnAplForDisconIndividualUsers, "%" + searchForm.textBoxName.Text + "%");
					}
					this.bindingSource_2.RemoveFilter();
					if (this.bindingSource_0.Count > 0)
					{
						this.class548_0.Class565_0.Clear();
					}
					foreach (object obj2 in this.bindingSource_2)
					{
						Class548.Class572 class5 = (Class548.Class572)((DataRowView)obj2).Row;
						if (!class5.method_10())
						{
							this.class585_0.vmethod_2(this.class548_0.tblAbnAplForDiscon, new int?(class5.IdAplForDiscon));
							this.bindingSource_3.RemoveFilter();
							Class548.Class567 class6 = (Class548.Class567)((DataRowView)this.bindingSource_3[0]).Row;
							this.bindingSource_0.AddNew();
							Class548.Class583 class7 = (Class548.Class583)((DataRowView)this.bindingSource_0.Current).Row;
							class7.legal = false;
							class7.AbnObjId = class5.Id;
							switch (class6.NetArea)
							{
							case 0:
								class7.NetArea = "Сетевой район 1";
								break;
							case 1:
								class7.NetArea = "Сетевой район 2";
								break;
							case 2:
								class7.NetArea = "Сетевой район 3";
								break;
							case 3:
								class7.NetArea = "Сетевой район 4";
								break;
							case 4:
								class7.NetArea = "ОДС";
								break;
							case 5:
								class7.NetArea = "СЭСНО";
								break;
							}
							class7.NumDoc = class6.Id + ", " + class5.ReasonCaption;
							if (!class5.method_18())
							{
								class7.Code = class5.Code.ToString();
							}
							if (!class5.method_2())
							{
								class7.Title = class5.FIO;
							}
							if (!class5.method_4())
							{
								if (!class7.method_24())
								{
									Class548.Class583 class8 = class7;
									class8.Title = class8.Title + ",\r\n" + class5.Address;
								}
								else
								{
									class7.Title = class5.Address;
								}
							}
							class7.Point = class5.Point;
							switch (class6.TypeAction)
							{
							case 0:
								class7.TypeActionCaption = "Отключение";
								break;
							case 1:
								class7.TypeActionCaption = "Возобнавление";
								break;
							case 2:
								class7.TypeActionCaption = "Отмена";
								break;
							}
							class7.DateAction = class6.DateAction;
							if (!class5.method_28())
							{
								class7.DateExec = class5.DateExec;
							}
							if (!class5.method_33())
							{
								class7.ReasonFailure = class5.ReasonFailure;
							}
							if (!class5.method_30())
							{
								class7.FIOExec = class5.String_0 + " (" + class5.NetAreaExecDescription + ")";
							}
							if (!class5.method_12())
							{
								class7.Comments = class5.Comments;
							}
							if (!class5.method_37() && class6.TypeAction != 2)
							{
								class7.IdCancelApl = class5.IdCancelApl;
								class7.NumCancelApl = class5.CancelAplNum;
							}
							this.bindingSource_0.EndEdit();
						}
					}
				}
			}
		}

		private void toolStripButton_4_Click(object sender, EventArgs e)
		{
			this.formFilter_0.ShowPeriodApplication = false;
			this.formFilter_0.Legal = true;
			this.formFilter_0.Individual = true;
			this.formFilter_0.UsePeriodExecution = true;
			this.formFilter_0.BeginningOfPeriodExecution = DateTime.Today;
			this.formFilter_0.EndOfPeriodExecution = DateTime.Today;
			this.formFilter_0.Disconnection = true;
			this.formFilter_0.Resumption = true;
			this.formFilter_0.Cancel = true;
			this.formFilter_0.NetArea1 = true;
			this.formFilter_0.NetArea2 = true;
			this.formFilter_0.NetArea3 = true;
			this.formFilter_0.NetArea4 = true;
			this.formFilter_0.ODS = true;
			this.formFilter_0.SESNO = true;
			this.formFilter_0.DoNotDisplayCancelled = true;
			this.method_2();
			this.class585_0.vmethod_0(this.class548_0.tblAbnAplForDiscon);
			this.method_0();
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
				this.class590_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
				this.class586_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
				this.class585_0.SqlConnection_0.ConnectionString = this.SqlSettings.GetConnectionString();
			}
		}

		private void toolStripButton_5_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = this.toolStripButton_5.Checked;
			this.bool_0 = @checked;
			this.formFilter_0.ForDisconected = !@checked;
			this.method_2();
		}

		private void method_4()
		{
			this.icontainer_0 = new Container();
			this.dataGridView_0 = new DataGridView();
			this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
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
			this.bindingSource_0 = new BindingSource(this.icontainer_0);
			this.class548_0 = new Class548();
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_3 = new ToolStripButton();
			this.toolStripButton_4 = new ToolStripButton();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.toolStripButton_2 = new ToolStripButton();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripButton_5 = new ToolStripButton();
			this.bindingSource_2 = new BindingSource(this.icontainer_0);
			this.class590_0 = new Class590();
			this.bindingSource_1 = new BindingSource(this.icontainer_0);
			this.class586_0 = new Class586();
			this.bindingSource_3 = new BindingSource(this.icontainer_0);
			this.class585_0 = new Class585();
			((ISupportInitialize)this.dataGridView_0).BeginInit();
			((ISupportInitialize)this.bindingSource_0).BeginInit();
			((ISupportInitialize)this.class548_0).BeginInit();
			this.toolStrip_0.SuspendLayout();
			((ISupportInitialize)this.bindingSource_2).BeginInit();
			((ISupportInitialize)this.bindingSource_1).BeginInit();
			((ISupportInitialize)this.bindingSource_3).BeginInit();
			base.SuspendLayout();
			this.dataGridView_0.AllowUserToAddRows = false;
			this.dataGridView_0.AllowUserToDeleteRows = false;
			this.dataGridView_0.AutoGenerateColumns = false;
			this.dataGridView_0.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView_0.BackgroundColor = Color.White;
			this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn_0,
				this.dataGridViewTextBoxColumn_1,
				this.dataGridViewTextBoxColumn_2,
				this.dataGridViewTextBoxColumn_3,
				this.dataGridViewTextBoxColumn_4,
				this.dataGridViewCheckBoxColumn_0,
				this.dataGridViewTextBoxColumn_5,
				this.dataGridViewTextBoxColumn_6,
				this.dataGridViewTextBoxColumn_7,
				this.dataGridViewTextBoxColumn_8,
				this.dataGridViewTextBoxColumn_9,
				this.dataGridViewTextBoxColumn_10,
				this.dataGridViewTextBoxColumn_11,
				this.dataGridViewTextBoxColumn_12,
				this.dataGridViewTextBoxColumn_13,
				this.dataGridViewTextBoxColumn_14
			});
			this.dataGridView_0.DataSource = this.bindingSource_0;
			this.dataGridView_0.Dock = DockStyle.Fill;
			this.dataGridView_0.Location = new Point(0, 25);
			this.dataGridView_0.Name = "dataGridView1";
			this.dataGridView_0.ReadOnly = true;
			this.dataGridView_0.RowHeadersVisible = false;
			this.dataGridView_0.RowHeadersWidth = 25;
			this.dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_0.Size = new Size(1022, 652);
			this.dataGridView_0.TabIndex = 0;
			this.dataGridView_0.CellDoubleClick += this.dataGridView_0_CellDoubleClick;
			this.dataGridViewTextBoxColumn_0.DataPropertyName = "NetArea";
			this.dataGridViewTextBoxColumn_0.HeaderText = "№ сетевого района";
			this.dataGridViewTextBoxColumn_0.Name = "netAreaDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_0.ReadOnly = true;
			this.dataGridViewTextBoxColumn_0.Width = 55;
			this.dataGridViewTextBoxColumn_1.DataPropertyName = "NumDoc";
			this.dataGridViewTextBoxColumn_1.HeaderText = "№ заявки, причина";
			this.dataGridViewTextBoxColumn_1.Name = "numDocDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_1.ReadOnly = true;
			this.dataGridViewTextBoxColumn_2.DataPropertyName = "Sent";
			this.dataGridViewTextBoxColumn_2.HeaderText = "Дата и время отправки распоряжения";
			this.dataGridViewTextBoxColumn_2.Name = "Sent";
			this.dataGridViewTextBoxColumn_2.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.DataPropertyName = "Code";
			this.dataGridViewTextBoxColumn_3.HeaderText = "№ договора";
			this.dataGridViewTextBoxColumn_3.Name = "codeDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_3.ReadOnly = true;
			this.dataGridViewTextBoxColumn_3.Width = 60;
			this.dataGridViewTextBoxColumn_4.DataPropertyName = "Title";
			this.dataGridViewTextBoxColumn_4.HeaderText = "Наименование и адрес объекта(ФИО физ. лица)";
			this.dataGridViewTextBoxColumn_4.MinimumWidth = 60;
			this.dataGridViewTextBoxColumn_4.Name = "titleDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_4.ReadOnly = true;
			this.dataGridViewTextBoxColumn_4.Width = 120;
			this.dataGridViewCheckBoxColumn_0.DataPropertyName = "Matrix";
			this.dataGridViewCheckBoxColumn_0.FillWeight = 70f;
			this.dataGridViewCheckBoxColumn_0.HeaderText = "Подключён к матрице";
			this.dataGridViewCheckBoxColumn_0.Name = "Matrix";
			this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
			this.dataGridViewCheckBoxColumn_0.Width = 70;
			this.dataGridViewTextBoxColumn_5.DataPropertyName = "Point";
			this.dataGridViewTextBoxColumn_5.HeaderText = "Место выполнения";
			this.dataGridViewTextBoxColumn_5.Name = "pointDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_5.ReadOnly = true;
			this.dataGridViewTextBoxColumn_6.DataPropertyName = "TypeActionCaption";
			this.dataGridViewTextBoxColumn_6.HeaderText = "Вид заявки";
			this.dataGridViewTextBoxColumn_6.Name = "typeActionDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_6.ReadOnly = true;
			this.dataGridViewTextBoxColumn_7.DataPropertyName = "IsFullRestriction";
			this.dataGridViewTextBoxColumn_7.HeaderText = "Вид ограничения";
			this.dataGridViewTextBoxColumn_7.Name = "IsFullRestriction";
			this.dataGridViewTextBoxColumn_7.ReadOnly = true;
			this.dataGridViewTextBoxColumn_7.Width = 85;
			this.dataGridViewTextBoxColumn_8.DataPropertyName = "Officer";
			this.dataGridViewTextBoxColumn_8.HeaderText = "Ответственный за выполнение";
			this.dataGridViewTextBoxColumn_8.Name = "officerDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_8.ReadOnly = true;
			this.dataGridViewTextBoxColumn_9.DataPropertyName = "DateAction";
			this.dataGridViewTextBoxColumn_9.HeaderText = "Планируемая дата и время исполнения";
			this.dataGridViewTextBoxColumn_9.Name = "dateActionDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_9.ReadOnly = true;
			this.dataGridViewTextBoxColumn_10.DataPropertyName = "DateExec";
			this.dataGridViewTextBoxColumn_10.HeaderText = "Фактическая дата и время исполнения";
			this.dataGridViewTextBoxColumn_10.Name = "dateExecDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_10.ReadOnly = true;
			this.dataGridViewTextBoxColumn_11.DataPropertyName = "ReasonFailure";
			this.dataGridViewTextBoxColumn_11.HeaderText = "Причина не выпонения";
			this.dataGridViewTextBoxColumn_11.Name = "reasonFailureDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_11.ReadOnly = true;
			this.dataGridViewTextBoxColumn_12.DataPropertyName = "FIOExec";
			this.dataGridViewTextBoxColumn_12.HeaderText = "ФИО исполнителя (№ сет. района, ОДС)";
			this.dataGridViewTextBoxColumn_12.Name = "fIOExecDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_12.ReadOnly = true;
			this.dataGridViewTextBoxColumn_13.DataPropertyName = "NumCancelApl";
			this.dataGridViewTextBoxColumn_13.HeaderText = "Отмена (№ заявки)";
			this.dataGridViewTextBoxColumn_13.Name = "numCancelAplDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_13.ReadOnly = true;
			this.dataGridViewTextBoxColumn_14.DataPropertyName = "Comments";
			this.dataGridViewTextBoxColumn_14.HeaderText = "Примечание";
			this.dataGridViewTextBoxColumn_14.Name = "commentsDataGridViewTextBoxColumn";
			this.dataGridViewTextBoxColumn_14.ReadOnly = true;
			this.bindingSource_0.DataMember = "ReportODS";
			this.bindingSource_0.DataSource = this.class548_0;
			this.class548_0.DataSetName = "OrgDataSet";
			this.class548_0.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
			this.toolStrip_0.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButton_0,
				this.toolStripButton_3,
				this.toolStripButton_4,
				this.toolStripSeparator_0,
				this.toolStripButton_1,
				this.toolStripSeparator_1,
				this.toolStripButton_2,
				this.toolStripSeparator_2,
				this.toolStripButton_5
			});
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStrip1";
			this.toolStrip_0.Size = new Size(1022, 25);
			this.toolStrip_0.TabIndex = 1;
			this.toolStrip_0.Text = "toolStrip1";
			this.toolStripButton_0.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_0.Image = Resources.Filtr;
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolStripButtonFilter";
			this.toolStripButton_0.Size = new Size(23, 22);
			this.toolStripButton_0.Text = "Фильтр";
			this.toolStripButton_0.Click += this.toolStripButton_0_Click;
			this.toolStripButton_3.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_3.Image = Resources.search2;
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolStripButton2";
			this.toolStripButton_3.Size = new Size(23, 22);
			this.toolStripButton_3.Text = "Начать поиск по адресу";
			this.toolStripButton_3.Click += this.toolStripButton_3_Click;
			this.toolStripButton_4.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_4.Image = Resources.filter_delete;
			this.toolStripButton_4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_4.Name = "toolStripButton3";
			this.toolStripButton_4.Size = new Size(23, 22);
			this.toolStripButton_4.Text = "Обновить";
			this.toolStripButton_4.Click += this.toolStripButton_4_Click;
			this.toolStripSeparator_0.Name = "toolStripSeparator1";
			this.toolStripSeparator_0.Size = new Size(6, 25);
			this.toolStripButton_1.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_1.Image = Resources.printer;
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolStripButtonPrint";
			this.toolStripButton_1.Size = new Size(23, 22);
			this.toolStripButton_1.Text = "Печать";
			this.toolStripButton_1.Click += this.toolStripButton_1_Click;
			this.toolStripSeparator_1.Name = "toolStripSeparator2";
			this.toolStripSeparator_1.Size = new Size(6, 25);
			this.toolStripButton_2.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_2.Image = Resources.ButtonEdit;
			this.toolStripButton_2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_2.Name = "toolStripButton1";
			this.toolStripButton_2.Size = new Size(23, 22);
			this.toolStripButton_2.Text = "Редактировать";
			this.toolStripButton_2.Click += this.toolStripButton_2_Click;
			this.toolStripSeparator_2.Name = "toolStripSeparator3";
			this.toolStripSeparator_2.Size = new Size(6, 25);
			this.toolStripButton_5.CheckOnClick = true;
			this.toolStripButton_5.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButton_5.Image = Resources.AbonentsDel;
			this.toolStripButton_5.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_5.Name = "toolStripButtonDisconnected";
			this.toolStripButton_5.Size = new Size(23, 22);
			this.toolStripButton_5.Text = "Отключенные";
			this.toolStripButton_5.CheckedChanged += this.toolStripButton_5_CheckedChanged;
			this.bindingSource_2.DataMember = "tblAbnAplForDisconIndividualUsers";
			this.bindingSource_2.DataSource = this.class548_0;
			this.class590_0.Boolean_0 = true;
			this.bindingSource_1.DataMember = "tblAbnAplForDisconObjects";
			this.bindingSource_1.DataSource = this.class548_0;
			this.class586_0.Boolean_0 = true;
			this.bindingSource_3.DataMember = "tblAbnAplForDiscon";
			this.bindingSource_3.DataSource = this.class548_0;
			this.class585_0.Boolean_0 = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1022, 677);
			base.Controls.Add(this.dataGridView_0);
			base.Controls.Add(this.toolStrip_0);
			base.Name = "FormODS";
			this.Text = "Заявки на введение или отмену введения ограничения режима потребления электрической энергии";
			base.WindowState = FormWindowState.Maximized;
			base.Load += this.FormODS_Load;
			((ISupportInitialize)this.dataGridView_0).EndInit();
			((ISupportInitialize)this.bindingSource_0).EndInit();
			((ISupportInitialize)this.class548_0).EndInit();
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			((ISupportInitialize)this.bindingSource_2).EndInit();
			((ISupportInitialize)this.bindingSource_1).EndInit();
			((ISupportInitialize)this.bindingSource_3).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private string string_0;

		private string string_1;

		private string string_2;

		private FormFilter formFilter_0;

		private bool bool_0;

		private DataGridView dataGridView_0;

		private ToolStrip toolStrip_0;

		private ToolStripButton toolStripButton_0;

		private BindingSource bindingSource_0;

		private Class548 class548_0;

		private BindingSource bindingSource_1;

		private BindingSource bindingSource_2;

		private Class590 class590_0;

		private Class586 class586_0;

		private BindingSource bindingSource_3;

		private Class585 class585_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripButton toolStripButton_2;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripButton toolStripButton_3;

		private ToolStripButton toolStripButton_4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

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

		private ToolStripButton toolStripButton_5;
	}
}
