using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FormLbr;

namespace Documents.Forms.TechnologicalConnection
{
	public partial class FormTechConnectionRequestMerge : FormBase
	{
		public int Id { get; private set; }

		public FormTechConnectionRequestMerge()
		{
			
			this.int_0 = -1;
			
			this.method_0();
		}

		public FormTechConnectionRequestMerge(int idChild)
		{
			
			this.int_0 = -1;
			
			this.method_0();
			this.int_0 = idChild;
		}

		private void FormTechConnectionRequestMerge_Load(object sender, EventArgs e)
		{
			DataTable dataTable = new DataTable("vTC_Request");
			dataTable.Columns.Add("id", typeof(int));
			dataTable.Columns.Add("numDateIn", typeof(string));
			base.SelectSqlData(dataTable, true, " where id <> " + this.int_0.ToString() + " order by numdateIn ", null, false, 0);
			this.comboBox_0.DataSource = dataTable;
			this.comboBox_0.DisplayMember = "numDateIn";
			this.comboBox_0.ValueMember = "id";
			this.comboBox_0.SelectedIndex = -1;
		}

		private void FormTechConnectionRequestMerge_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.DialogResult == DialogResult.OK)
			{
				if (this.comboBox_0.SelectedIndex == -1)
				{
					MessageBox.Show("Не выбрана основная заявка");
					e.Cancel = true;
				}
				this.Id = Convert.ToInt32(this.comboBox_0.SelectedValue);
				Class10 @class = new Class10();
				base.SelectSqlData(@class.tTC_Doc, true, " where id = " + this.int_0.ToString() + " or idParent = " + this.int_0.ToString(), null, false, 0);
				foreach (DataRow dataRow in @class.tTC_Doc)
				{
					dataRow["TypeDoc"] = 1203;
					dataRow["IdParent"] = this.Id;
					dataRow.EndEdit();
					base.SelectSqlData(@class.tTC_DocOut, true, " where idDoc = " + dataRow["id"].ToString(), null, false, 0);
					foreach (Class10.Class80 class2 in @class.tTC_DocOut)
					{
						class2["idDoc"] = this.Id;
						class2.EndEdit();
					}
					base.UpdateSqlData(@class, @class.tTC_DocOut);
				}
				base.UpdateSqlData(@class, @class.tTC_Doc);
			}
		}

		private void method_0()
		{
			this.label_0 = new Label();
			this.comboBox_0 = new ComboBox();
			this.button_0 = new Button();
			this.button_1 = new Button();
			base.SuspendLayout();
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(12, 9);
			this.label_0.Name = "label1";
			this.label_0.Size = new Size(96, 13);
			this.label_0.TabIndex = 0;
			this.label_0.Text = "Основная заявка";
			this.comboBox_0.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			this.comboBox_0.AutoCompleteSource = AutoCompleteSource.ListItems;
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(15, 25);
			this.comboBox_0.Name = "cmbRequest";
			this.comboBox_0.Size = new Size(270, 21);
			this.comboBox_0.TabIndex = 1;
			this.button_0.DialogResult = DialogResult.OK;
			this.button_0.Location = new Point(15, 52);
			this.button_0.Name = "buttonOK";
			this.button_0.Size = new Size(75, 23);
			this.button_0.TabIndex = 2;
			this.button_0.Text = "ОК";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_1.Location = new Point(210, 52);
			this.button_1.Name = "buttonCancel";
			this.button_1.Size = new Size(75, 23);
			this.button_1.TabIndex = 3;
			this.button_1.Text = "Отмена";
			this.button_1.UseVisualStyleBackColor = true;
			base.AcceptButton = this.button_0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.button_1;
			base.ClientSize = new Size(294, 84);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.button_0);
			base.Controls.Add(this.comboBox_0);
			base.Controls.Add(this.label_0);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormTechConnectionRequestMerge";
			this.Text = "Привязка заявки";
			base.FormClosing += this.FormTechConnectionRequestMerge_FormClosing;
			base.Load += this.FormTechConnectionRequestMerge_Load;
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private int int_0;

		[CompilerGenerated]
		private int int_1;

		private Label label_0;

		private ComboBox comboBox_0;

		private Button button_0;

		private Button button_1;
	}
}
