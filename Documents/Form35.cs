using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ControlsLbr.Forms;
using FormLbr;
using FormLbr.Classes;

internal partial class Form35 : FormBase
{
	internal Form35()
	{
		
		
		this.method_0();
	}

	private void Form35_Load(object sender, EventArgs e)
	{
		this.formProgressBar_0 = new FormProgressBar();
		this.backgroundWorker_0.RunWorkerAsync(this.string_0);
	}

	private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
	{
		if (string.IsNullOrEmpty(e.Argument.ToString()))
		{
			MessageBox.Show("Пароль не может быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		try
		{
			Dispatcher.Invoke(this, new AsyncAction(this.method_1));
			Class603 @class = new Class603(this.string_0);
			e.Result = @class.method_11();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Ошибка загрузки списка с\\з", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			Dispatcher.Invoke(this, new AsyncAction(this.method_2));
		}
	}

	private void Form35_Shown(object sender, EventArgs e)
	{
	}

	private void method_0()
	{
		this.dataGridView_0 = new DataGridView();
		this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
		this.tableLayoutPanel_0 = new TableLayoutPanel();
		this.button_0 = new Button();
		this.backgroundWorker_0 = new BackgroundWorker();
		((ISupportInitialize)this.dataGridView_0).BeginInit();
		this.tableLayoutPanel_0.SuspendLayout();
		base.SuspendLayout();
		this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(new DataGridViewColumn[]
		{
			this.dataGridViewTextBoxColumn_0,
			this.dataGridViewTextBoxColumn_1,
			this.dataGridViewTextBoxColumn_2,
			this.dataGridViewTextBoxColumn_3,
			this.dataGridViewTextBoxColumn_4,
			this.dataGridViewTextBoxColumn_5
		});
		this.tableLayoutPanel_0.SetColumnSpan(this.dataGridView_0, 2);
		this.dataGridView_0.Dock = DockStyle.Fill;
		this.dataGridView_0.Location = new Point(3, 3);
		this.dataGridView_0.Name = "dgvMemorandum";
		this.dataGridView_0.Size = new Size(799, 413);
		this.dataGridView_0.TabIndex = 0;
		this.dataGridViewTextBoxColumn_0.HeaderText = "Рег. №";
		this.dataGridViewTextBoxColumn_0.Name = "RegNum";
		this.dataGridViewTextBoxColumn_1.HeaderText = "Дата подп.";
		this.dataGridViewTextBoxColumn_1.Name = "DateSign";
		this.dataGridViewTextBoxColumn_2.HeaderText = "Подписал";
		this.dataGridViewTextBoxColumn_2.Name = "Sign";
		this.dataGridViewTextBoxColumn_3.HeaderText = "Адресат";
		this.dataGridViewTextBoxColumn_3.Name = "Addressee";
		this.dataGridViewTextBoxColumn_4.HeaderText = "Испольнитель";
		this.dataGridViewTextBoxColumn_4.Name = "Preformer";
		this.dataGridViewTextBoxColumn_5.HeaderText = "По вопросу";
		this.dataGridViewTextBoxColumn_5.Name = "Subject";
		this.tableLayoutPanel_0.ColumnCount = 2;
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.08696f));
		this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.91304f));
		this.tableLayoutPanel_0.Controls.Add(this.dataGridView_0, 0, 0);
		this.tableLayoutPanel_0.Controls.Add(this.button_0, 1, 1);
		this.tableLayoutPanel_0.Dock = DockStyle.Fill;
		this.tableLayoutPanel_0.Location = new Point(0, 0);
		this.tableLayoutPanel_0.Name = "tlpGeneral";
		this.tableLayoutPanel_0.RowCount = 2;
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 92.10526f));
		this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 7.894737f));
		this.tableLayoutPanel_0.Size = new Size(805, 456);
		this.tableLayoutPanel_0.TabIndex = 1;
		this.button_0.Location = new Point(696, 426);
		this.button_0.Margin = new Padding(3, 7, 3, 7);
		this.button_0.Name = "button1";
		this.button_0.Size = new Size(90, 23);
		this.button_0.TabIndex = 1;
		this.button_0.Text = "Закрыть";
		this.button_0.UseVisualStyleBackColor = true;
		this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(805, 456);
		base.Controls.Add(this.tableLayoutPanel_0);
		base.Name = "FormMemorandum";
		base.StartPosition = FormStartPosition.CenterScreen;
		this.Text = "Служебные записки";
		base.Load += this.Form35_Load;
		base.Shown += this.Form35_Shown;
		((ISupportInitialize)this.dataGridView_0).EndInit();
		this.tableLayoutPanel_0.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	[CompilerGenerated]
	private void method_1()
	{
		this.formProgressBar_0.Show();
	}

	[CompilerGenerated]
	private void method_2()
	{
		this.formProgressBar_0.Hide();
	}

	internal static void TqRhG6ODv9Pc72ttMSOs(Form form_0, bool bool_0)
	{
		form_0.Dispose(bool_0);
	}

	internal string string_0;

	private FormProgressBar formProgressBar_0;

	private DataGridView dataGridView_0;

	private TableLayoutPanel tableLayoutPanel_0;

	private BackgroundWorker backgroundWorker_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private Button button_0;
}
