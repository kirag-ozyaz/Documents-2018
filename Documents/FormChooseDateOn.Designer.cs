internal partial class FormChooseDateOn : global::System.Windows.Forms.Form
{
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.label1 = new global::System.Windows.Forms.Label();
		this.dtpDate = new global::System.Windows.Forms.DateTimePicker();
		this.checkBoxIncludeChain = new global::System.Windows.Forms.CheckBox();
		this.buttonOK = new global::System.Windows.Forms.Button();
		this.buttonCancel = new global::System.Windows.Forms.Button();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new global::System.Drawing.Point(12, 15);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(77, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Дата и время";
		this.dtpDate.CustomFormat = "dd.MM.yyyy HH:mm";
		this.dtpDate.Format = global::System.Windows.Forms.DateTimePickerFormat.Custom;
		this.dtpDate.Location = new global::System.Drawing.Point(95, 9);
		this.dtpDate.Name = "dtpDate";
		this.dtpDate.Size = new global::System.Drawing.Size(200, 20);
		this.dtpDate.TabIndex = 1;
		this.checkBoxIncludeChain.AutoSize = true;
		this.checkBoxIncludeChain.Checked = true;
		this.checkBoxIncludeChain.CheckState = global::System.Windows.Forms.CheckState.Checked;
		this.checkBoxIncludeChain.Location = new global::System.Drawing.Point(76, 44);
		this.checkBoxIncludeChain.Name = "checkBoxIncludeChain";
		this.checkBoxIncludeChain.Size = new global::System.Drawing.Size(134, 17);
		this.checkBoxIncludeChain.TabIndex = 2;
		this.checkBoxIncludeChain.Text = "Включить по цепочке";
		this.checkBoxIncludeChain.UseVisualStyleBackColor = true;
		this.buttonOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
		this.buttonOK.Location = new global::System.Drawing.Point(15, 77);
		this.buttonOK.Name = "buttonOK";
		this.buttonOK.Size = new global::System.Drawing.Size(75, 23);
		this.buttonOK.TabIndex = 3;
		this.buttonOK.Text = "ОК";
		this.buttonOK.UseVisualStyleBackColor = true;
		this.buttonCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.buttonCancel.Location = new global::System.Drawing.Point(220, 77);
		this.buttonCancel.Name = "buttonCancel";
		this.buttonCancel.Size = new global::System.Drawing.Size(75, 23);
		this.buttonCancel.TabIndex = 4;
		this.buttonCancel.Text = "Отмена";
		this.buttonCancel.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(305, 112);
		base.Controls.Add(this.buttonCancel);
		base.Controls.Add(this.buttonOK);
		base.Controls.Add(this.checkBoxIncludeChain);
		base.Controls.Add(this.dtpDate);
		base.Controls.Add(this.label1);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormChooseDateOn";
		this.Text = "Выбор даты";
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private global::System.ComponentModel.IContainer icontainer_0;

	private global::System.Windows.Forms.Label label1;

	private global::System.Windows.Forms.DateTimePicker dtpDate;

	private global::System.Windows.Forms.CheckBox checkBoxIncludeChain;

	private global::System.Windows.Forms.Button buttonOK;

	private global::System.Windows.Forms.Button buttonCancel;
}
