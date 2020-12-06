internal partial class SearchForm : global::System.Windows.Forms.Form
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
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::SearchForm));
		this.buttonCancel = new global::System.Windows.Forms.Button();
		this.buttonOK = new global::System.Windows.Forms.Button();
		this.radioButtonLegal = new global::System.Windows.Forms.RadioButton();
		this.radioButtonIndiviual = new global::System.Windows.Forms.RadioButton();
		this.textBoxName = new global::System.Windows.Forms.TextBox();
		this.comboBoxSearchType = new global::System.Windows.Forms.ComboBox();
		this.label1 = new global::System.Windows.Forms.Label();
		base.SuspendLayout();
		this.buttonCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.buttonCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
		this.buttonCancel.Location = new global::System.Drawing.Point(177, 102);
		this.buttonCancel.Name = "buttonCancel";
		this.buttonCancel.Size = new global::System.Drawing.Size(75, 23);
		this.buttonCancel.TabIndex = 0;
		this.buttonCancel.Text = "Отмена";
		this.buttonCancel.UseVisualStyleBackColor = true;
		this.buttonOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
		this.buttonOK.DialogResult = global::System.Windows.Forms.DialogResult.OK;
		this.buttonOK.Location = new global::System.Drawing.Point(96, 102);
		this.buttonOK.Name = "buttonOK";
		this.buttonOK.Size = new global::System.Drawing.Size(75, 23);
		this.buttonOK.TabIndex = 0;
		this.buttonOK.Text = "OK";
		this.buttonOK.UseVisualStyleBackColor = true;
		this.radioButtonLegal.AutoSize = true;
		this.radioButtonLegal.Location = new global::System.Drawing.Point(12, 12);
		this.radioButtonLegal.Name = "radioButtonLegal";
		this.radioButtonLegal.Size = new global::System.Drawing.Size(120, 17);
		this.radioButtonLegal.TabIndex = 1;
		this.radioButtonLegal.Text = "Юридическое лицо";
		this.radioButtonLegal.UseVisualStyleBackColor = true;
		this.radioButtonLegal.CheckedChanged += new global::System.EventHandler(this.radioButtonLegal_CheckedChanged);
		this.radioButtonIndiviual.AutoSize = true;
		this.radioButtonIndiviual.Location = new global::System.Drawing.Point(138, 12);
		this.radioButtonIndiviual.Name = "radioButtonIndiviual";
		this.radioButtonIndiviual.Size = new global::System.Drawing.Size(116, 17);
		this.radioButtonIndiviual.TabIndex = 1;
		this.radioButtonIndiviual.Text = "Физическое лицо";
		this.radioButtonIndiviual.UseVisualStyleBackColor = true;
		this.radioButtonIndiviual.CheckedChanged += new global::System.EventHandler(this.radioButtonIndiviual_CheckedChanged);
		this.textBoxName.Location = new global::System.Drawing.Point(12, 76);
		this.textBoxName.Name = "textBoxName";
		this.textBoxName.Size = new global::System.Drawing.Size(240, 20);
		this.textBoxName.TabIndex = 2;
		this.comboBoxSearchType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxSearchType.FormattingEnabled = true;
		this.comboBoxSearchType.Items.AddRange(new object[]
		{
			"Абоненту",
			"Объекту"
		});
		this.comboBoxSearchType.Location = new global::System.Drawing.Point(96, 49);
		this.comboBoxSearchType.Name = "comboBoxSearchType";
		this.comboBoxSearchType.Size = new global::System.Drawing.Size(156, 21);
		this.comboBoxSearchType.TabIndex = 3;
		this.label1.AutoSize = true;
		this.label1.Location = new global::System.Drawing.Point(12, 52);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(57, 13);
		this.label1.TabIndex = 4;
		this.label1.Text = "Поиск по:";
		base.AcceptButton = this.buttonOK;
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.buttonCancel;
		base.ClientSize = new global::System.Drawing.Size(264, 137);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.comboBoxSearchType);
		base.Controls.Add(this.textBoxName);
		base.Controls.Add(this.radioButtonIndiviual);
		base.Controls.Add(this.radioButtonLegal);
		base.Controls.Add(this.buttonOK);
		base.Controls.Add(this.buttonCancel);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SearchForm";
		base.ShowInTaskbar = false;
		base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Поиск";
		base.Load += new global::System.EventHandler(this.SearchForm_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private global::System.ComponentModel.IContainer icontainer_0;

	private global::System.Windows.Forms.Button buttonCancel;

	private global::System.Windows.Forms.Button buttonOK;

	public global::System.Windows.Forms.RadioButton radioButtonLegal;

	public global::System.Windows.Forms.RadioButton radioButtonIndiviual;

	public global::System.Windows.Forms.TextBox textBoxName;

	private global::System.Windows.Forms.Label label1;

	public global::System.Windows.Forms.ComboBox comboBoxSearchType;
}
