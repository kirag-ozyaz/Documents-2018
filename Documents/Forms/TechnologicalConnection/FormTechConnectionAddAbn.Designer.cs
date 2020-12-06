

using ControlsLbr.DataGridViewExcelFilter;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Documents.Forms.TechnologicalConnection
{
	public partial class FormTechConnectionAddAbn : FormLbr.FormBase
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private System.ComponentModel.IContainer components = null;


        private void InitializeComponent()
        {
            this.components = new Container();
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormTechConnectionAddAbn));
            this.groupBox1 = new GroupBox();
            this.radioButtonFL = new RadioButton();
            this.radioButtonUL = new RadioButton();
            this.txtCurrentAbn = new TextBox();
            this.dgvAbn = new DataGridViewExcelFilter();
            this.typeNameSocrDgvColumn = new DataGridViewTextBoxColumn();
            this.deletedKontragentDgvColumn = new DataGridViewCheckBoxColumn();
            this.isActiveDgvColumn = new DataGridViewCheckBoxColumn();
            this.timer1 = new Timer(this.components);
            this.dgvObj = new DataGridViewExcelFilter();
            this.idObjRegDgvColumn = new DataGridViewTextBoxColumn();
            this.addressULDgvColumn = new DataGridViewTextBoxColumn();
            this.addressFLDgvColumn = new DataGridViewTextBoxColumn();
            this.splitContainerDgv = new SplitContainer();
            this.toolStripCont = new ToolStrip();
            this.toolBtnAddCont = new ToolStripButton();
            this.toolBtnEditCont = new ToolStripButton();
            this.toolBtnDelCont = new ToolStripButton();
            this.toolStripSeparator_0 = new ToolStripSeparator();
            this.toolBtnShowDelAbn = new ToolStripButton();
            this.toolStripObj = new ToolStrip();
            this.toolBtnAddObj = new ToolStripButton();
            this.toolBtnEditObj = new ToolStripButton();
            this.toolBtnDelObj = new ToolStripButton();
            this.groupBoxSelect = new GroupBox();
            this.txtFlat = new TextBox();
            this.label82 = new Label();
            this.txtHousePrefix = new TextBox();
            this.label71 = new Label();
            this.txtHouse = new TextBox();
            this.label83 = new Label();
            this.cmbStreet = new ComboBox();
            this.dsKladrStreet = new DataSet();
            this.tableKladrStreet = new DataTable();
            this.dataColumnId4 = new DataColumn();
            this.dataColumnName4 = new DataColumn();
            this.dataColumnSocr4 = new DataColumn();
            this.dataColumnNameSocr4 = new DataColumn();
            this.dataColumnIndex4 = new DataColumn();
            this.label80 = new Label();
            this.cmbPunkt = new ComboBox();
            this.dsKladr = new DataSet();
            this.tblKladrObj = new DataTable();
            this.dataColumnId = new DataColumn();
            this.dataColumnName = new DataColumn();
            this.dataColumnSocr = new DataColumn();
            this.dataColumnNameSocr = new DataColumn();
            this.labelSettlement = new Label();
            this.cmbCity = new ComboBox();
            this.dsKladrObj = new DataSet();
            this.tblKladrObjRaion = new DataTable();
            this.dataColumnid2 = new DataColumn();
            this.dataColumnname2 = new DataColumn();
            this.dataColumnsocr2 = new DataColumn();
            this.dataColumnnamesocr2 = new DataColumn();
            this.labelSity = new Label();
            this.labelRegion = new Label();
            this.cmbObl = new ComboBox();
            this.dataSet_3 = new DataSet();
            this.tblKladrObjSubject = new DataTable();
            this.dataColumnId3 = new DataColumn();
            this.dataColumnName3 = new DataColumn();
            this.dataColumnSocr3 = new DataColumn();
            this.dataColumnNameSocr3 = new DataColumn();
            this.radioButtonSelAddress = new RadioButton();
            this.radioButtonSelectName = new RadioButton();
            this.tabControlContr = new TabControl();
            this.tabPageAbnInfo = new TabPage();
            this.nameFullTextBox = new TextBox();
            this.iNNTextBox = new TextBox();
            this.bankAcntTextBox = new TextBox();
            this.kPPTextBox = new TextBox();
            this.bankDestTextBox = new TextBox();
            this.oKVEDTextBox = new TextBox();
            this.bankIDTextBox = new TextBox();
            this.oKPOTextBox = new TextBox();
            this.tsAbnInfo = new ToolStrip();
            this.tsbAddAbnInfo = new ToolStripButton();
            this.tsbEditInfo = new ToolStripButton();
            this.tsbInfoHistory = new ToolStripButton();
            this.tabPageDirector = new TabPage();
            this.tabControlDirectorFIO = new TabControl();
            this.tabPageI = new TabPage();
            this.I_postTextBox = new TextBox();
            this.i_OTextBox = new TextBox();
            this.i_ITextBox = new TextBox();
            this.i_FTextBox = new TextBox();
            this.tabPageR = new TabPage();
            this.R_postTextBox = new TextBox();
            this.r_OTextBox = new TextBox();
            this.r_ITextBox = new TextBox();
            this.r_FTextBox = new TextBox();
            this.tabPageD = new TabPage();
            this.D_postTextBox = new TextBox();
            this.d_OTextBox = new TextBox();
            this.d_ITextBox = new TextBox();
            this.d_FTextBox = new TextBox();
            this.tabPageT = new TabPage();
            this.T_postTextBox = new TextBox();
            this.t_OTextBox = new TextBox();
            this.t_ITextBox = new TextBox();
            this.t_FTextBox = new TextBox();
            this.tsDirector = new ToolStrip();
            this.tsbDirectorAdd = new ToolStripButton();
            this.tsbDirectorEdit = new ToolStripButton();
            this.tsbDirectorHistory = new ToolStripButton();
            this.tabPageAddress = new TabPage();
            this.groupBoxAddressP = new GroupBox();
            this.richTextBoxAddressP = new RichTextBox();
            this.groupBoxAddressL = new GroupBox();
            this.richTextBoxAddressL = new RichTextBox();
            this.tsAddress = new ToolStrip();
            this.tsbAddressHistory = new ToolStripButton();
            this.tabPageContacts = new TabPage();
            this.dGVAbnContact = new DataGridView();
            this.toolStripContact = new ToolStrip();
            this.toolStripButton_7 = new ToolStripButton();
            this.toolStripButton_8 = new ToolStripButton();
            this.toolStripButton_9 = new ToolStripButton();
            this.tabPageTypeAbn = new TabPage();
            this.dgvAbnType = new DataGridViewExcelFilter();
            this.toolStripAbnType = new ToolStrip();
            this.toolStripButton_17 = new ToolStripButton();
            this.toolStripButton_18 = new ToolStripButton();
            this.toolStripButton_19 = new ToolStripButton();
            this.buttonОК = new Button();
            this.buttonCancel = new Button();
            this.chkVisibleNoActiveAbn = new CheckBox();
            this.dsTU = new DataSetTC();
            this.dataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_2 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_3 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_4 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_5 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_6 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_7 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_8 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_9 = new DataGridViewTextBoxColumn();
            this.bsAbnContact = new BindingSource(this.components);
            this.dataGridViewTextBoxColumn_32 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_33 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_34 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_35 = new DataGridViewTextBoxColumn();
            this.bsAbnType = new BindingSource(this.components);
            this.dataGridViewTextBoxColumn_36 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_37 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_38 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_40 = new DataGridViewTextBoxColumn();
            this.bsAbn = new BindingSource(this.components);
            this.dataGridViewTextBoxColumn_10 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_12 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_13 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_14 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_17 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_18 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_19 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_20 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_21 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_22 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_23 = new DataGridViewTextBoxColumn();
            this.zauYlEgnqI = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_24 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_25 = new DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn_0 = new DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn_26 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_27 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_28 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_29 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_30 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn_31 = new DataGridViewTextBoxColumn();
            this.bsAbnObjAddress = new BindingSource(this.components);
            Label nameFullLabel = new Label();
            Label bankAcntLabel = new Label();
            Label iNNLabel = new Label();
            Label bankDestLabel = new Label();
            Label kPPLabel = new Label();
            Label bankIDLabel = new Label();
            Label oKVEDLabel = new Label();
            Label oKPOLabel = new Label();
            Label postLabel = new Label();
            Label i_OLabel = new Label();
            Label i_ILabel = new Label();
            Label i_FLabel = new Label();
            Label label6 = new Label();
            Label r_OLabel = new Label();
            Label r_ILabel = new Label();
            Label r_FLabel = new Label();
            Label d_OLabel = new Label();
            Label label9 = new Label();
            Label d_ILabel = new Label();
            Label d_FLabel = new Label();
            Label label10 = new Label();
            Label t_OLabel = new Label();
            Label t_ILabel = new Label();
            Label t_FLabel = new Label();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize)this.dgvAbn).BeginInit();
            ((ISupportInitialize)this.dgvObj).BeginInit();
            this.splitContainerDgv.Panel1.SuspendLayout();
            this.splitContainerDgv.Panel2.SuspendLayout();
            this.splitContainerDgv.SuspendLayout();
            this.toolStripCont.SuspendLayout();
            this.toolStripObj.SuspendLayout();
            this.groupBoxSelect.SuspendLayout();
            ((ISupportInitialize)this.dsKladrStreet).BeginInit();
            ((ISupportInitialize)this.tableKladrStreet).BeginInit();
            ((ISupportInitialize)this.dsKladr).BeginInit();
            ((ISupportInitialize)this.tblKladrObj).BeginInit();
            ((ISupportInitialize)this.dsKladrObj).BeginInit();
            ((ISupportInitialize)this.tblKladrObjRaion).BeginInit();
            ((ISupportInitialize)this.dataSet_3).BeginInit();
            ((ISupportInitialize)this.tblKladrObjSubject).BeginInit();
            this.tabControlContr.SuspendLayout();
            this.tabPageAbnInfo.SuspendLayout();
            this.tsAbnInfo.SuspendLayout();
            this.tabPageDirector.SuspendLayout();
            this.tabControlDirectorFIO.SuspendLayout();
            this.tabPageI.SuspendLayout();
            this.tabPageR.SuspendLayout();
            this.tabPageD.SuspendLayout();
            this.tabPageT.SuspendLayout();
            this.tsDirector.SuspendLayout();
            this.tabPageAddress.SuspendLayout();
            this.groupBoxAddressP.SuspendLayout();
            this.groupBoxAddressL.SuspendLayout();
            this.tsAddress.SuspendLayout();
            this.tabPageContacts.SuspendLayout();
            ((ISupportInitialize)this.dGVAbnContact).BeginInit();
            this.toolStripContact.SuspendLayout();
            this.tabPageTypeAbn.SuspendLayout();
            ((ISupportInitialize)this.dgvAbnType).BeginInit();
            this.toolStripAbnType.SuspendLayout();
            ((ISupportInitialize)this.dsTU).BeginInit();
            ((ISupportInitialize)this.bsAbnContact).BeginInit();
            ((ISupportInitialize)this.bsAbnType).BeginInit();
            ((ISupportInitialize)this.bsAbn).BeginInit();
            ((ISupportInitialize)this.bsAbnObjAddress).BeginInit();
            base.SuspendLayout();
            nameFullLabel.AutoSize = true;
            nameFullLabel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
            nameFullLabel.Location = new Point(31, 7);
            nameFullLabel.Name = "nameFullLabel";
            nameFullLabel.Size = new Size(82, 13);
            nameFullLabel.TabIndex = 37;
            nameFullLabel.Text = "Полное имя:";
            bankAcntLabel.AutoSize = true;
            bankAcntLabel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
            bankAcntLabel.Location = new Point(60, 171);
            bankAcntLabel.Name = "bankAcntLabel";
            bankAcntLabel.Size = new Size(105, 13);
            bankAcntLabel.TabIndex = 51;
            bankAcntLabel.Text = "Расчетный счет:";
            iNNLabel.AutoSize = true;
            iNNLabel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
            iNNLabel.Location = new Point(75, 68);
            iNNLabel.Name = "iNNLabel";
            iNNLabel.Size = new Size(38, 13);
            iNNLabel.TabIndex = 39;
            iNNLabel.Text = "ИНН:";
            bankDestLabel.AutoSize = true;
            bankDestLabel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
            bankDestLabel.Location = new Point(55, 145);
            bankDestLabel.Name = "bankDestLabel";
            bankDestLabel.Size = new Size(111, 13);
            bankDestLabel.TabIndex = 49;
            bankDestLabel.Text = "Банк получателя:";
            kPPLabel.AutoSize = true;
            kPPLabel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
            kPPLabel.Location = new Point(357, 68);
            kPPLabel.Name = "kPPLabel";
            kPPLabel.Size = new Size(37, 13);
            kPPLabel.TabIndex = 41;
            kPPLabel.Text = "КПП:";
            bankIDLabel.AutoSize = true;
            bankIDLabel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
            bankIDLabel.Location = new Point(41, 119);
            bankIDLabel.Name = "bankIDLabel";
            bankIDLabel.Size = new Size(127, 13);
            bankIDLabel.TabIndex = 47;
            bankIDLabel.Text = "Банк плательщика :";
            oKVEDLabel.AutoSize = true;
            oKVEDLabel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
            oKVEDLabel.Location = new Point(61, 90);
            oKVEDLabel.Name = "oKVEDLabel";
            oKVEDLabel.Size = new Size(54, 13);
            oKVEDLabel.TabIndex = 43;
            oKVEDLabel.Text = "ОКВЕД:";
            oKPOLabel.AutoSize = true;
            oKPOLabel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
            oKPOLabel.Location = new Point(349, 90);
            oKPOLabel.Name = "oKPOLabel";
            oKPOLabel.Size = new Size(46, 13);
            oKPOLabel.TabIndex = 45;
            oKPOLabel.Text = "ОКПО:";
            postLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            postLabel.AutoSize = true;
            postLabel.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            postLabel.Location = new Point(12, 15);
            postLabel.Name = "postLabel";
            postLabel.Size = new Size(95, 17);
            postLabel.TabIndex = 32;
            postLabel.Text = "Должность:";
            i_OLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            i_OLabel.AutoSize = true;
            i_OLabel.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            i_OLabel.Location = new Point(23, 130);
            i_OLabel.Name = "i_OLabel";
            i_OLabel.Size = new Size(84, 17);
            i_OLabel.TabIndex = 42;
            i_OLabel.Text = "Отчество:";
            i_ILabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            i_ILabel.AutoSize = true;
            i_ILabel.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            i_ILabel.Location = new Point(64, 95);
            i_ILabel.Name = "i_ILabel";
            i_ILabel.Size = new Size(43, 17);
            i_ILabel.TabIndex = 40;
            i_ILabel.Text = "Имя:";
            i_FLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            i_FLabel.AutoSize = true;
            i_FLabel.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            i_FLabel.Location = new Point(25, 58);
            i_FLabel.Name = "i_FLabel";
            i_FLabel.Size = new Size(82, 17);
            i_FLabel.TabIndex = 38;
            i_FLabel.Text = "Фамилия:";
            label6.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.Location = new Point(12, 15);
            label6.Name = "label6";
            label6.Size = new Size(95, 17);
            label6.TabIndex = 34;
            label6.Text = "Должность:";
            r_OLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            r_OLabel.AutoSize = true;
            r_OLabel.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            r_OLabel.Location = new Point(23, 130);
            r_OLabel.Name = "r_OLabel";
            r_OLabel.Size = new Size(84, 17);
            r_OLabel.TabIndex = 52;
            r_OLabel.Text = "Отчество:";
            r_ILabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            r_ILabel.AutoSize = true;
            r_ILabel.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            r_ILabel.Location = new Point(64, 95);
            r_ILabel.Name = "r_ILabel";
            r_ILabel.Size = new Size(43, 17);
            r_ILabel.TabIndex = 50;
            r_ILabel.Text = "Имя:";
            r_FLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            r_FLabel.AutoSize = true;
            r_FLabel.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            r_FLabel.Location = new Point(25, 58);
            r_FLabel.Name = "r_FLabel";
            r_FLabel.Size = new Size(82, 17);
            r_FLabel.TabIndex = 48;
            r_FLabel.Text = "Фамилия:";
            r_FLabel.TextAlign = ContentAlignment.TopCenter;
            d_OLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            d_OLabel.AutoSize = true;
            d_OLabel.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            d_OLabel.Location = new Point(23, 130);
            d_OLabel.Name = "d_OLabel";
            d_OLabel.Size = new Size(84, 17);
            d_OLabel.TabIndex = 58;
            d_OLabel.Text = "Отчество:";
            label9.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            label9.Location = new Point(12, 15);
            label9.Name = "label9";
            label9.Size = new Size(95, 17);
            label9.TabIndex = 36;
            label9.Text = "Должность:";
            d_ILabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            d_ILabel.AutoSize = true;
            d_ILabel.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            d_ILabel.Location = new Point(64, 95);
            d_ILabel.Name = "d_ILabel";
            d_ILabel.Size = new Size(43, 17);
            d_ILabel.TabIndex = 56;
            d_ILabel.Text = "Имя:";
            d_FLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            d_FLabel.AutoSize = true;
            d_FLabel.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            d_FLabel.Location = new Point(25, 58);
            d_FLabel.Name = "d_FLabel";
            d_FLabel.Size = new Size(82, 17);
            d_FLabel.TabIndex = 54;
            d_FLabel.Text = "Фамилия:";
            label10.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            label10.Location = new Point(12, 15);
            label10.Name = "label10";
            label10.Size = new Size(95, 17);
            label10.TabIndex = 36;
            label10.Text = "Должность:";
            t_OLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            t_OLabel.AutoSize = true;
            t_OLabel.CausesValidation = false;
            t_OLabel.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            t_OLabel.Location = new Point(23, 130);
            t_OLabel.Name = "t_OLabel";
            t_OLabel.Size = new Size(84, 17);
            t_OLabel.TabIndex = 64;
            t_OLabel.Text = "Отчество:";
            t_ILabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            t_ILabel.AutoSize = true;
            t_ILabel.CausesValidation = false;
            t_ILabel.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            t_ILabel.Location = new Point(64, 95);
            t_ILabel.Name = "t_ILabel";
            t_ILabel.Size = new Size(43, 17);
            t_ILabel.TabIndex = 62;
            t_ILabel.Text = "Имя:";
            t_FLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            t_FLabel.AutoSize = true;
            t_FLabel.CausesValidation = false;
            t_FLabel.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            t_FLabel.Location = new Point(25, 58);
            t_FLabel.Name = "t_FLabel";
            t_FLabel.Size = new Size(82, 17);
            t_FLabel.TabIndex = 60;
            t_FLabel.Text = "Фамилия:";
            this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.groupBox1.Controls.Add(this.radioButtonFL);
            this.groupBox1.Controls.Add(this.radioButtonUL);
            this.groupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.groupBox1.Location = new Point(2, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(720, 37);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.radioButtonFL.AutoSize = true;
            this.radioButtonFL.Location = new Point(156, 12);
            this.radioButtonFL.Name = "radioButtonFL";
            this.radioButtonFL.Size = new Size(131, 17);
            this.radioButtonFL.TabIndex = 1;
            this.radioButtonFL.Text = "Физическое лицо";
            this.radioButtonFL.UseVisualStyleBackColor = true;
            this.radioButtonUL.AutoSize = true;
            this.radioButtonUL.Checked = true;
            this.radioButtonUL.Location = new Point(10, 12);
            this.radioButtonUL.Name = "radioButtonUL";
            this.radioButtonUL.Size = new Size(136, 17);
            this.radioButtonUL.TabIndex = 0;
            this.radioButtonUL.TabStop = true;
            this.radioButtonUL.Text = "Юридическое лицо";
            this.radioButtonUL.UseVisualStyleBackColor = true;
            this.radioButtonUL.CheckedChanged += this.radioButtonUL_CheckedChanged;
            this.txtCurrentAbn.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.txtCurrentAbn.Location = new Point(109, 10);
            this.txtCurrentAbn.Name = "txtCurrentAbn";
            this.txtCurrentAbn.Size = new Size(605, 20);
            this.txtCurrentAbn.TabIndex = 2;
            this.txtCurrentAbn.TextChanged += this.txtCurrentAbn_TextChanged;
            this.dgvAbn.AllowUserToAddRows = false;
            this.dgvAbn.AllowUserToDeleteRows = false;
            this.dgvAbn.AllowUserToResizeRows = false;
            this.dgvAbn.AutoGenerateColumns = false;
            dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle.BackColor = SystemColors.Control;
            dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvAbn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
            this.dgvAbn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbn.Columns.AddRange(new DataGridViewColumn[]
            {
                this.dataGridViewTextBoxColumn_36,
                this.dataGridViewTextBoxColumn_37,
                this.dataGridViewTextBoxColumn_38,
                this.typeNameSocrDgvColumn,
                this.dataGridViewTextBoxColumn_40,
                this.deletedKontragentDgvColumn,
                this.isActiveDgvColumn
            });
            this.dgvAbn.DataSource = this.bsAbn;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            this.dgvAbn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAbn.Dock = DockStyle.Fill;
            this.dgvAbn.Location = new Point(24, 0);
            this.dgvAbn.Name = "dgvAbn";
            this.dgvAbn.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            this.dgvAbn.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAbn.RowHeadersVisible = false;
            this.dgvAbn.Size = new Size(322, 162);
            this.dgvAbn.TabIndex = 3;
            this.dgvAbn.VirtualMode = true;
            this.dgvAbn.CellFormatting += this.dataGridViewExcelFilter_0_CellFormatting;
            this.typeNameSocrDgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.typeNameSocrDgvColumn.DataPropertyName = "TypeNameSocr";
            this.typeNameSocrDgvColumn.FillWeight = 20f;
            this.typeNameSocrDgvColumn.HeaderText = "Тип";
            this.typeNameSocrDgvColumn.Name = "typeNameSocrDgvColumn";
            this.typeNameSocrDgvColumn.ReadOnly = true;
            this.deletedKontragentDgvColumn.DataPropertyName = "Deleted";
            this.deletedKontragentDgvColumn.HeaderText = "Deleted";
            this.deletedKontragentDgvColumn.Name = "deletedKontragentDgvColumn";
            this.deletedKontragentDgvColumn.ReadOnly = true;
            this.deletedKontragentDgvColumn.Visible = false;
            this.isActiveDgvColumn.DataPropertyName = "isActive";
            this.isActiveDgvColumn.HeaderText = "isActive";
            this.isActiveDgvColumn.Name = "isActiveDgvColumn";
            this.isActiveDgvColumn.ReadOnly = true;
            this.isActiveDgvColumn.Visible = false;
            this.timer1.Interval = 300;
            this.timer1.Tick += this.timer1_Tick;
            this.dgvObj.AllowUserToAddRows = false;
            this.dgvObj.AllowUserToDeleteRows = false;
            this.dgvObj.AllowUserToResizeRows = false;
            this.dgvObj.AutoGenerateColumns = false;
            this.dgvObj.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObj.Columns.AddRange(new DataGridViewColumn[]
            {
                this.dataGridViewTextBoxColumn_10,
                this.idObjRegDgvColumn,
                this.dataGridViewTextBoxColumn_12,
                this.dataGridViewTextBoxColumn_13,
                this.dataGridViewTextBoxColumn_14,
                this.addressULDgvColumn,
                this.addressFLDgvColumn,
                this.dataGridViewTextBoxColumn_17,
                this.dataGridViewTextBoxColumn_18,
                this.dataGridViewTextBoxColumn_19,
                this.dataGridViewTextBoxColumn_20,
                this.dataGridViewTextBoxColumn_21,
                this.dataGridViewTextBoxColumn_22,
                this.dataGridViewTextBoxColumn_23,
                this.zauYlEgnqI,
                this.dataGridViewTextBoxColumn_24,
                this.dataGridViewTextBoxColumn_25,
                this.dataGridViewCheckBoxColumn_0,
                this.dataGridViewTextBoxColumn_26,
                this.dataGridViewTextBoxColumn_27,
                this.dataGridViewTextBoxColumn_28,
                this.dataGridViewTextBoxColumn_29,
                this.dataGridViewTextBoxColumn_30,
                this.dataGridViewTextBoxColumn_31
            });
            this.dgvObj.DataSource = this.bsAbnObjAddress;
            this.dgvObj.Dock = DockStyle.Fill;
            this.dgvObj.Location = new Point(24, 0);
            this.dgvObj.Name = "dgvObj";
            this.dgvObj.ReadOnly = true;
            this.dgvObj.RowHeadersVisible = false;
            this.dgvObj.Size = new Size(346, 162);
            this.dgvObj.TabIndex = 6;
            this.idObjRegDgvColumn.DataPropertyName = "idObjReg";
            this.idObjRegDgvColumn.HeaderText = "idObjReg";
            this.idObjRegDgvColumn.Name = "idObjRegDgvColumn";
            this.idObjRegDgvColumn.ReadOnly = true;
            this.idObjRegDgvColumn.Visible = false;
            this.addressULDgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.addressULDgvColumn.HeaderText = "Адрес";
            this.addressULDgvColumn.Name = "addressULDgvColumn";
            this.addressULDgvColumn.ReadOnly = true;
            this.addressFLDgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.addressFLDgvColumn.HeaderText = "Адрес";
            this.addressFLDgvColumn.Name = "addressFLDgvColumn";
            this.addressFLDgvColumn.ReadOnly = true;
            this.addressFLDgvColumn.Visible = false;
            this.splitContainerDgv.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.splitContainerDgv.Location = new Point(2, 168);
            this.splitContainerDgv.Name = "splitContainerDgv";
            this.splitContainerDgv.Panel1.Controls.Add(this.dgvAbn);
            this.splitContainerDgv.Panel1.Controls.Add(this.toolStripCont);
            this.splitContainerDgv.Panel2.Controls.Add(this.dgvObj);
            this.splitContainerDgv.Panel2.Controls.Add(this.toolStripObj);
            this.splitContainerDgv.Size = new Size(720, 162);
            this.splitContainerDgv.SplitterDistance = 346;
            this.splitContainerDgv.TabIndex = 7;
            this.toolStripCont.Dock = DockStyle.Left;
            this.toolStripCont.GripStyle = ToolStripGripStyle.Hidden;
            this.toolStripCont.Items.AddRange(new ToolStripItem[]
            {
                this.toolBtnAddCont,
                this.toolBtnEditCont,
                this.toolBtnDelCont,
                this.toolStripSeparator_0,
                this.toolBtnShowDelAbn
            });
            this.toolStripCont.Location = new Point(0, 0);
            this.toolStripCont.Name = "toolStripCont";
            this.toolStripCont.Size = new Size(24, 162);
            this.toolStripCont.TabIndex = 4;
            this.toolStripCont.Text = "toolStrip1";
            this.toolBtnAddCont.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolBtnAddCont.Image = (Image)resources.GetObject("toolBtnAddCont.Image");
            this.toolBtnAddCont.ImageTransparentColor = Color.Magenta;
            this.toolBtnAddCont.Name = "toolBtnAddCont";
            this.toolBtnAddCont.Size = new Size(21, 20);
            this.toolBtnAddCont.Text = "Создание контрагента";
            this.toolBtnAddCont.Click += this.toolBtnAddCont_Click;
            this.toolBtnEditCont.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolBtnEditCont.Image = (Image)resources.GetObject("toolBtnEditCont.Image");
            this.toolBtnEditCont.ImageTransparentColor = Color.Magenta;
            this.toolBtnEditCont.Name = "toolBtnEditCont";
            this.toolBtnEditCont.Size = new Size(21, 20);
            this.toolBtnEditCont.Text = "Редактирование Контрагента";
            this.toolBtnEditCont.Click += this.toolBtnEditCont_Click;
            this.toolBtnDelCont.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolBtnDelCont.Image = (Image)resources.GetObject("toolBtnDelCont.Image");
            this.toolBtnDelCont.ImageTransparentColor = Color.Magenta;
            this.toolBtnDelCont.Name = "toolBtnDelCont";
            this.toolBtnDelCont.Size = new Size(21, 20);
            this.toolBtnDelCont.Text = "Удаление контрагента";
            this.toolBtnDelCont.Click += this.toolBtnDelCont_Click;
            this.toolStripSeparator_0.Name = "toolStripSeparator1";
            this.toolStripSeparator_0.Size = new Size(21, 6);
            this.toolBtnShowDelAbn.CheckOnClick = true;
            this.toolBtnShowDelAbn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolBtnShowDelAbn.Image = (Image)resources.GetObject("toolBtnShowDelAbn.Image");
            this.toolBtnShowDelAbn.ImageTransparentColor = Color.Magenta;
            this.toolBtnShowDelAbn.Name = "toolBtnShowDelAbn";
            this.toolBtnShowDelAbn.Size = new Size(21, 20);
            this.toolBtnShowDelAbn.Text = "Показать удаленных";
            this.toolBtnShowDelAbn.Click += this.toolBtnShowDelAbn_Click;
            this.toolStripObj.Dock = DockStyle.Left;
            this.toolStripObj.GripStyle = ToolStripGripStyle.Hidden;
            this.toolStripObj.Items.AddRange(new ToolStripItem[]
            {
                this.toolBtnAddObj,
                this.toolBtnEditObj,
                this.toolBtnDelObj
            });
            this.toolStripObj.Location = new Point(0, 0);
            this.toolStripObj.Name = "toolStripObj";
            this.toolStripObj.Size = new Size(24, 162);
            this.toolStripObj.TabIndex = 7;
            this.toolStripObj.Text = "toolStrip2";
            this.toolBtnAddObj.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolBtnAddObj.Image = (Image)resources.GetObject("toolBtnAddObj.Image");
            this.toolBtnAddObj.ImageTransparentColor = Color.Magenta;
            this.toolBtnAddObj.Name = "toolBtnAddObj";
            this.toolBtnAddObj.Size = new Size(21, 20);
            this.toolBtnAddObj.Text = "Добавление объекта";
            this.toolBtnAddObj.Click += this.toolBtnAddObj_Click;
            this.toolBtnEditObj.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolBtnEditObj.Image = (Image)resources.GetObject("toolBtnEditObj.Image");
            this.toolBtnEditObj.ImageTransparentColor = Color.Magenta;
            this.toolBtnEditObj.Name = "toolBtnEditObj";
            this.toolBtnEditObj.Size = new Size(21, 20);
            this.toolBtnEditObj.Text = "Редактирование объекта";
            this.toolBtnEditObj.Click += this.toolBtnEditObj_Click;
            this.toolBtnDelObj.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolBtnDelObj.Image = (Image)resources.GetObject("toolBtnDelObj.Image");
            this.toolBtnDelObj.ImageTransparentColor = Color.Magenta;
            this.toolBtnDelObj.Name = "toolBtnDelObj";
            this.toolBtnDelObj.Size = new Size(21, 20);
            this.toolBtnDelObj.Text = "Удаление объекта";
            this.toolBtnDelObj.Click += this.toolBtnDelObj_Click;
            this.groupBoxSelect.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.groupBoxSelect.Controls.Add(this.txtFlat);
            this.groupBoxSelect.Controls.Add(this.label82);
            this.groupBoxSelect.Controls.Add(this.txtHousePrefix);
            this.groupBoxSelect.Controls.Add(this.label71);
            this.groupBoxSelect.Controls.Add(this.txtHouse);
            this.groupBoxSelect.Controls.Add(this.label83);
            this.groupBoxSelect.Controls.Add(this.cmbStreet);
            this.groupBoxSelect.Controls.Add(this.label80);
            this.groupBoxSelect.Controls.Add(this.cmbPunkt);
            this.groupBoxSelect.Controls.Add(this.labelSettlement);
            this.groupBoxSelect.Controls.Add(this.cmbCity);
            this.groupBoxSelect.Controls.Add(this.labelSity);
            this.groupBoxSelect.Controls.Add(this.labelRegion);
            this.groupBoxSelect.Controls.Add(this.cmbObl);
            this.groupBoxSelect.Controls.Add(this.radioButtonSelAddress);
            this.groupBoxSelect.Controls.Add(this.radioButtonSelectName);
            this.groupBoxSelect.Controls.Add(this.txtCurrentAbn);
            this.groupBoxSelect.Location = new Point(2, 35);
            this.groupBoxSelect.Name = "groupBoxSelect";
            this.groupBoxSelect.Size = new Size(720, 109);
            this.groupBoxSelect.TabIndex = 8;
            this.groupBoxSelect.TabStop = false;
            this.groupBoxSelect.Text = "Фильтр";
            this.txtFlat.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.txtFlat.Enabled = false;
            this.txtFlat.Location = new Point(649, 82);
            this.txtFlat.Name = "txtFlat";
            this.txtFlat.Size = new Size(61, 20);
            this.txtFlat.TabIndex = 19;
            this.txtFlat.TextChanged += this.textBox_1_TextChanged;
            this.label82.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.label82.AutoSize = true;
            this.label82.Location = new Point(649, 70);
            this.label82.Name = "label82";
            this.label82.Size = new Size(55, 13);
            this.label82.TabIndex = 18;
            this.label82.Text = "Квартира";
            this.txtHousePrefix.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.txtHousePrefix.Enabled = false;
            this.txtHousePrefix.Location = new Point(603, 82);
            this.txtHousePrefix.Name = "txtHousePrefix";
            this.txtHousePrefix.Size = new Size(40, 20);
            this.txtHousePrefix.TabIndex = 17;
            this.txtHousePrefix.TextChanged += this.txtHousePrefix_TextChanged;
            this.label71.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.label71.AutoSize = true;
            this.label71.Location = new Point(600, 70);
            this.label71.Name = "label71";
            this.label71.Size = new Size(43, 13);
            this.label71.TabIndex = 16;
            this.label71.Text = "Корпус";
            this.txtHouse.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.txtHouse.Enabled = false;
            this.txtHouse.Location = new Point(564, 82);
            this.txtHouse.Name = "txtHouse";
            this.txtHouse.Size = new Size(33, 20);
            this.txtHouse.TabIndex = 14;
            this.txtHouse.TextChanged += this.txtHouse_TextChanged;
            this.label83.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.label83.AutoSize = true;
            this.label83.Location = new Point(564, 70);
            this.label83.Name = "label83";
            this.label83.Size = new Size(30, 13);
            this.label83.TabIndex = 13;
            this.label83.Text = "Дом";
            this.cmbStreet.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.cmbStreet.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbStreet.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbStreet.DataSource = this.dsKladrStreet;
            this.cmbStreet.DisplayMember = "tR_KladrStreet.NameSocr";
            this.cmbStreet.Enabled = false;
            this.cmbStreet.FormattingEnabled = true;
            this.cmbStreet.Location = new Point(177, 82);
            this.cmbStreet.Name = "cmbStreet";
            this.cmbStreet.Size = new Size(381, 21);
            this.cmbStreet.TabIndex = 12;
            this.cmbStreet.ValueMember = "tR_KladrStreet.Id";
            this.cmbStreet.SelectedIndexChanged += this.cmbStreet_SelectedIndexChanged;
            this.dsKladrStreet.DataSetName = "NewDataSet";
            this.dsKladrStreet.Tables.AddRange(new DataTable[]
            {
                this.tableKladrStreet
            });
            this.tableKladrStreet.Columns.AddRange(new DataColumn[]
            {
                this.dataColumnId4,
                this.dataColumnName4,
                this.dataColumnSocr4,
                this.dataColumnNameSocr4,
                this.dataColumnIndex4
            });
            this.tableKladrStreet.TableName = "tR_KladrStreet";
            this.dataColumnId4.ColumnName = "Id";
            this.dataColumnId4.DataType = typeof(int);
            this.dataColumnName4.ColumnName = "Name";
            this.dataColumnSocr4.ColumnName = "Socr";
            this.dataColumnNameSocr4.ColumnName = "NameSocr";
            this.dataColumnNameSocr4.Expression = "Name + ' ' + isnull(socr, '')";
            this.dataColumnNameSocr4.ReadOnly = true;
            this.dataColumnIndex4.ColumnName = "Index";
            this.label80.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.label80.AutoSize = true;
            this.label80.Location = new Point(174, 67);
            this.label80.Name = "label80";
            this.label80.Size = new Size(39, 13);
            this.label80.TabIndex = 11;
            this.label80.Text = "Улица";
            this.cmbPunkt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbPunkt.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbPunkt.DataSource = this.dsKladr;
            this.cmbPunkt.DisplayMember = "tR_KladrObj.NameSocr";
            this.cmbPunkt.Enabled = false;
            this.cmbPunkt.FormattingEnabled = true;
            this.cmbPunkt.Location = new Point(6, 82);
            this.cmbPunkt.Name = "cmbPunkt";
            this.cmbPunkt.Size = new Size(156, 21);
            this.cmbPunkt.TabIndex = 10;
            this.cmbPunkt.ValueMember = "tR_KladrObj.Id";
            this.cmbPunkt.SelectedIndexChanged += this.cmbPunkt_SelectedIndexChanged;
            this.dsKladr.DataSetName = "NewDataSet";
            this.dsKladr.Tables.AddRange(new DataTable[]
            {
                this.tblKladrObj
            });
            this.tblKladrObj.Columns.AddRange(new DataColumn[]
            {
                this.dataColumnId,
                this.dataColumnName,
                this.dataColumnSocr,
                this.dataColumnNameSocr
            });
            this.tblKladrObj.TableName = "tR_KladrObj";
            this.dataColumnId.ColumnName = "Id";
            this.dataColumnId.DataType = typeof(int);
            this.dataColumnName.ColumnName = "Name";
            this.dataColumnSocr.ColumnName = "Socr";
            this.dataColumnNameSocr.ColumnName = "NameSocr";
            this.dataColumnNameSocr.Expression = "Name + ' ' + isnull(socr, '')";
            this.dataColumnNameSocr.ReadOnly = true;
            this.labelSettlement.AutoSize = true;
            this.labelSettlement.Location = new Point(7, 67);
            this.labelSettlement.Name = "labelSettlement";
            this.labelSettlement.Size = new Size(61, 13);
            this.labelSettlement.TabIndex = 9;
            this.labelSettlement.Text = "Нас. пункт";
            this.cmbCity.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.cmbCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbCity.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbCity.DataSource = this.dsKladrObj;
            this.cmbCity.DisplayMember = "tR_KladrObj.NameSocr";
            this.cmbCity.Enabled = false;
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new Point(266, 46);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new Size(447, 21);
            this.cmbCity.TabIndex = 8;
            this.cmbCity.ValueMember = "tR_KladrObj.Id";
            this.cmbCity.SelectedIndexChanged += this.comboBox_3_SelectedIndexChanged;
            this.dsKladrObj.DataSetName = "NewDataSet";
            this.dsKladrObj.Tables.AddRange(new DataTable[]
            {
                this.tblKladrObjRaion
            });
            this.tblKladrObjRaion.Columns.AddRange(new DataColumn[]
            {
                this.dataColumnid2,
                this.dataColumnname2,
                this.dataColumnsocr2,
                this.dataColumnnamesocr2
            });
            this.tblKladrObjRaion.TableName = "tR_KladrObj";
            this.dataColumnid2.ColumnName = "Id";
            this.dataColumnid2.DataType = typeof(int);
            this.dataColumnname2.ColumnName = "Name";
            this.dataColumnsocr2.ColumnName = "Socr";
            this.dataColumnnamesocr2.ColumnName = "NameSocr";
            this.dataColumnnamesocr2.Expression = "Name + ' ' + isnull(socr, '')";
            this.dataColumnnamesocr2.ReadOnly = true;
            this.labelSity.AutoSize = true;
            this.labelSity.Location = new Point(263, 31);
            this.labelSity.Name = "label2";
            this.labelSity.Size = new Size(37, 13);
            this.labelSity.TabIndex = 7;
            this.labelSity.Text = "Город";
            this.labelRegion.AutoSize = true;
            this.labelRegion.Location = new Point(106, 31);
            this.labelRegion.Name = "label1";
            this.labelRegion.Size = new Size(43, 13);
            this.labelRegion.TabIndex = 6;
            this.labelRegion.Text = "Регион";
            this.cmbObl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbObl.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbObl.DataSource = this.dataSet_3;
            this.cmbObl.DisplayMember = "tR_KladrObj.NameSocr";
            this.cmbObl.Enabled = false;
            this.cmbObl.FormattingEnabled = true;
            this.cmbObl.Location = new Point(109, 46);
            this.cmbObl.Name = "cmbObl";
            this.cmbObl.Size = new Size(141, 21);
            this.cmbObl.TabIndex = 5;
            this.cmbObl.ValueMember = "tR_KladrObj.Id";
            this.cmbObl.SelectedIndexChanged += this.comboBox_0_SelectedIndexChanged;
            this.dataSet_3.DataSetName = "NewDataSet";
            this.dataSet_3.Tables.AddRange(new DataTable[]
            {
                this.tblKladrObjSubject
            });
            this.tblKladrObjSubject.Columns.AddRange(new DataColumn[]
            {
                this.dataColumnId3,
                this.dataColumnName3,
                this.dataColumnSocr3,
                this.dataColumnNameSocr3
            });
            this.tblKladrObjSubject.TableName = "tR_KladrObj";
            this.dataColumnId3.ColumnName = "Id";
            this.dataColumnId3.DataType = typeof(int);
            this.dataColumnName3.ColumnName = "Name";
            this.dataColumnSocr3.ColumnName = "Socr";
            this.dataColumnNameSocr3.ColumnName = "NameSocr";
            this.dataColumnNameSocr3.Expression = "Name + ' ' + isnull(socr, '')";
            this.dataColumnNameSocr3.ReadOnly = true;

            this.radioButtonSelAddress.AutoSize = true;
            this.radioButtonSelAddress.Location = new Point(6, 43);
            this.radioButtonSelAddress.Name = "radioButtonSelAddress";
            this.radioButtonSelAddress.Size = new Size(75, 17);
            this.radioButtonSelAddress.TabIndex = 4;
            this.radioButtonSelAddress.Text = "по адресу";
            this.radioButtonSelAddress.UseVisualStyleBackColor = true;

            this.radioButtonSelectName.AutoSize = true;
            this.radioButtonSelectName.Checked = true;
            this.radioButtonSelectName.Location = new Point(6, 11);
            this.radioButtonSelectName.Name = "radioButtonSelectName";
            this.radioButtonSelectName.Size = new Size(72, 17);
            this.radioButtonSelectName.TabIndex = 3;
            this.radioButtonSelectName.TabStop = true;
            this.radioButtonSelectName.Text = "по имени";
            this.radioButtonSelectName.UseVisualStyleBackColor = true;
            this.radioButtonSelectName.CheckedChanged += this.radioButtonSelectName_CheckedChanged;

            this.tabControlContr.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.tabControlContr.Controls.Add(this.tabPageAbnInfo);
            this.tabControlContr.Controls.Add(this.tabPageDirector);
            this.tabControlContr.Controls.Add(this.tabPageAddress);
            this.tabControlContr.Controls.Add(this.tabPageContacts);
            this.tabControlContr.Controls.Add(this.tabPageTypeAbn);
            this.tabControlContr.Location = new Point(1, 331);
            this.tabControlContr.Name = "tabControlContr";
            this.tabControlContr.SelectedIndex = 0;
            this.tabControlContr.Size = new Size(727, 217);
            this.tabControlContr.TabIndex = 9;
            this.tabPageAbnInfo.Controls.Add(this.nameFullTextBox);
            this.tabPageAbnInfo.Controls.Add(this.iNNTextBox);
            this.tabPageAbnInfo.Controls.Add(this.bankAcntTextBox);
            this.tabPageAbnInfo.Controls.Add(this.kPPTextBox);
            this.tabPageAbnInfo.Controls.Add(this.bankDestTextBox);
            this.tabPageAbnInfo.Controls.Add(this.oKVEDTextBox);
            this.tabPageAbnInfo.Controls.Add(this.bankIDTextBox);
            this.tabPageAbnInfo.Controls.Add(this.oKPOTextBox);
            this.tabPageAbnInfo.Controls.Add(nameFullLabel);
            this.tabPageAbnInfo.Controls.Add(bankAcntLabel);
            this.tabPageAbnInfo.Controls.Add(iNNLabel);
            this.tabPageAbnInfo.Controls.Add(bankDestLabel);
            this.tabPageAbnInfo.Controls.Add(kPPLabel);
            this.tabPageAbnInfo.Controls.Add(bankIDLabel);
            this.tabPageAbnInfo.Controls.Add(oKVEDLabel);
            this.tabPageAbnInfo.Controls.Add(oKPOLabel);
            this.tabPageAbnInfo.Controls.Add(this.tsAbnInfo);
            this.tabPageAbnInfo.Location = new Point(4, 22);
            this.tabPageAbnInfo.Name = "tabPageAbnInfo";
            this.tabPageAbnInfo.Padding = new Padding(3);
            this.tabPageAbnInfo.Size = new Size(719, 191);
            this.tabPageAbnInfo.TabIndex = 0;
            this.tabPageAbnInfo.Text = "Реквизиты";
            this.tabPageAbnInfo.UseVisualStyleBackColor = true;
            this.nameFullTextBox.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.nameFullTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "vG_AbnInfo.NameFull", true));
            this.nameFullTextBox.Location = new Point(119, 3);
            this.nameFullTextBox.Multiline = true;
            this.nameFullTextBox.Name = "nameFullTextBox";
            this.nameFullTextBox.ReadOnly = true;
            this.nameFullTextBox.Size = new Size(591, 52);
            this.nameFullTextBox.TabIndex = 38;
            this.iNNTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "vG_AbnInfo.INN", true));
            this.iNNTextBox.Location = new Point(119, 65);
            this.iNNTextBox.Name = "iNNTextBox";
            this.iNNTextBox.ReadOnly = true;
            this.iNNTextBox.Size = new Size(230, 20);
            this.iNNTextBox.TabIndex = 40;
            this.bankAcntTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "vG_AbnInfo.BankAcnt", true));
            this.bankAcntTextBox.Location = new Point(167, 168);
            this.bankAcntTextBox.Name = "bankAcntTextBox";
            this.bankAcntTextBox.ReadOnly = true;
            this.bankAcntTextBox.Size = new Size(223, 20);
            this.bankAcntTextBox.TabIndex = 52;
            this.kPPTextBox.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.kPPTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "vG_AbnInfo.KPP", true));
            this.kPPTextBox.Location = new Point(396, 61);
            this.kPPTextBox.Name = "kPPTextBox";
            this.kPPTextBox.ReadOnly = true;
            this.kPPTextBox.Size = new Size(314, 20);
            this.kPPTextBox.TabIndex = 42;
            this.bankDestTextBox.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.bankDestTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "vG_AbnInfo.BankDestName", true));
            this.bankDestTextBox.Location = new Point(167, 142);
            this.bankDestTextBox.Name = "bankDestTextBox";
            this.bankDestTextBox.ReadOnly = true;
            this.bankDestTextBox.Size = new Size(543, 20);
            this.bankDestTextBox.TabIndex = 50;
            this.oKVEDTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "vG_AbnInfo.OKVED", true));
            this.oKVEDTextBox.Location = new Point(119, 87);
            this.oKVEDTextBox.Name = "oKVEDTextBox";
            this.oKVEDTextBox.ReadOnly = true;
            this.oKVEDTextBox.Size = new Size(230, 20);
            this.oKVEDTextBox.TabIndex = 44;
            this.bankIDTextBox.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.bankIDTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "vG_AbnInfo.BankName", true));
            this.bankIDTextBox.Location = new Point(167, 116);
            this.bankIDTextBox.Name = "bankIDTextBox";
            this.bankIDTextBox.ReadOnly = true;
            this.bankIDTextBox.Size = new Size(543, 20);
            this.bankIDTextBox.TabIndex = 48;
            this.oKPOTextBox.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.oKPOTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "vG_AbnInfo.OKPO", true));
            this.oKPOTextBox.Location = new Point(396, 87);
            this.oKPOTextBox.Name = "oKPOTextBox";
            this.oKPOTextBox.ReadOnly = true;
            this.oKPOTextBox.Size = new Size(314, 20);
            this.oKPOTextBox.TabIndex = 46;
            this.tsAbnInfo.Dock = DockStyle.Left;
            this.tsAbnInfo.GripStyle = ToolStripGripStyle.Hidden;
            this.tsAbnInfo.Items.AddRange(new ToolStripItem[]
            {
                this.tsbAddAbnInfo,
                this.tsbEditInfo,
                this.tsbInfoHistory
            });
            this.tsAbnInfo.Location = new Point(3, 3);
            this.tsAbnInfo.Name = "tsAbnInfo";
            this.tsAbnInfo.Size = new Size(24, 185);
            this.tsAbnInfo.TabIndex = 36;
            this.tsAbnInfo.Text = "toolStrip1";
            this.tsbAddAbnInfo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.tsbAddAbnInfo.Image = (Image)resources.GetObject("tsbAddAbnInfo.Image");
            this.tsbAddAbnInfo.ImageTransparentColor = Color.Magenta;
            this.tsbAddAbnInfo.Name = "tsbAddAbnInfo";
            this.tsbAddAbnInfo.Size = new Size(21, 20);
            this.tsbAddAbnInfo.Text = "Новые реквизиты";
            this.tsbAddAbnInfo.Click += this.tsbAddAbnInfo_Click;
            this.tsbEditInfo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.tsbEditInfo.Image = (Image)resources.GetObject("tsbEditInfo.Image");
            this.tsbEditInfo.ImageTransparentColor = Color.Magenta;
            this.tsbEditInfo.Name = "tsbEditInfo";
            this.tsbEditInfo.Size = new Size(21, 20);
            this.tsbEditInfo.Text = "Редактировать реквизиты";
            this.tsbEditInfo.Click += this.tsbEditInfo_Click;
            this.tsbInfoHistory.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.tsbInfoHistory.Image = (Image)resources.GetObject("tsbInfoHistory.Image");
            this.tsbInfoHistory.ImageTransparentColor = Color.Magenta;
            this.tsbInfoHistory.Name = "tsbInfoHistory";
            this.tsbInfoHistory.Size = new Size(21, 20);
            this.tsbInfoHistory.Text = "Истрия реквизитов";
            this.tsbInfoHistory.Click += this.tsbInfoHistory_Click;
            this.tabPageDirector.Controls.Add(this.tabControlDirectorFIO);
            this.tabPageDirector.Controls.Add(this.tsDirector);
            this.tabPageDirector.Location = new Point(4, 22);
            this.tabPageDirector.Name = "tabPageDirector";
            this.tabPageDirector.Padding = new Padding(3);
            this.tabPageDirector.Size = new Size(719, 191);
            this.tabPageDirector.TabIndex = 1;
            this.tabPageDirector.Text = "Руководитель";
            this.tabPageDirector.UseVisualStyleBackColor = true;
            this.tabControlDirectorFIO.Controls.Add(this.tabPageI);
            this.tabControlDirectorFIO.Controls.Add(this.tabPageR);
            this.tabControlDirectorFIO.Controls.Add(this.tabPageD);
            this.tabControlDirectorFIO.Controls.Add(this.tabPageT);
            this.tabControlDirectorFIO.Dock = DockStyle.Fill;
            this.tabControlDirectorFIO.Location = new Point(27, 3);
            this.tabControlDirectorFIO.Name = "tabControlDirectorFIO";
            this.tabControlDirectorFIO.SelectedIndex = 0;
            this.tabControlDirectorFIO.Size = new Size(689, 185);
            this.tabControlDirectorFIO.TabIndex = 40;
            this.tabPageI.Controls.Add(this.I_postTextBox);
            this.tabPageI.Controls.Add(postLabel);
            this.tabPageI.Controls.Add(i_OLabel);
            this.tabPageI.Controls.Add(this.i_OTextBox);
            this.tabPageI.Controls.Add(i_ILabel);
            this.tabPageI.Controls.Add(this.i_ITextBox);
            this.tabPageI.Controls.Add(i_FLabel);
            this.tabPageI.Controls.Add(this.i_FTextBox);
            this.tabPageI.Location = new Point(4, 22);
            this.tabPageI.Name = "tabPageI";
            this.tabPageI.Padding = new Padding(3);
            this.tabPageI.Size = new Size(681, 159);
            this.tabPageI.TabIndex = 0;
            this.tabPageI.Text = "Именительный (кто)";
            this.tabPageI.UseVisualStyleBackColor = true;
            this.I_postTextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.I_postTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.I_Post", true));
            this.I_postTextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.I_postTextBox.Location = new Point(113, 15);
            this.I_postTextBox.Multiline = true;
            this.I_postTextBox.Name = "I_postTextBox";
            this.I_postTextBox.ReadOnly = true;
            this.I_postTextBox.Size = new Size(552, 25);
            this.I_postTextBox.TabIndex = 33;
            this.i_OTextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.i_OTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.I_O", true));
            this.i_OTextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.i_OTextBox.Location = new Point(113, 127);
            this.i_OTextBox.Name = "i_OTextBox";
            this.i_OTextBox.ReadOnly = true;
            this.i_OTextBox.Size = new Size(552, 23);
            this.i_OTextBox.TabIndex = 43;
            this.i_ITextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.i_ITextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.I_I", true));
            this.i_ITextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.i_ITextBox.Location = new Point(113, 92);
            this.i_ITextBox.Name = "i_ITextBox";
            this.i_ITextBox.ReadOnly = true;
            this.i_ITextBox.Size = new Size(552, 23);
            this.i_ITextBox.TabIndex = 41;
            this.i_FTextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.i_FTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.I_F", true));
            this.i_FTextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.i_FTextBox.Location = new Point(113, 55);
            this.i_FTextBox.Name = "i_FTextBox";
            this.i_FTextBox.ReadOnly = true;
            this.i_FTextBox.Size = new Size(552, 23);
            this.i_FTextBox.TabIndex = 39;
            this.tabPageR.Controls.Add(this.R_postTextBox);
            this.tabPageR.Controls.Add(label6);
            this.tabPageR.Controls.Add(r_OLabel);
            this.tabPageR.Controls.Add(this.r_OTextBox);
            this.tabPageR.Controls.Add(r_ILabel);
            this.tabPageR.Controls.Add(this.r_ITextBox);
            this.tabPageR.Controls.Add(r_FLabel);
            this.tabPageR.Controls.Add(this.r_FTextBox);
            this.tabPageR.Location = new Point(4, 22);
            this.tabPageR.Name = "tabPageR";
            this.tabPageR.Padding = new Padding(3);
            this.tabPageR.Size = new Size(681, 159);
            this.tabPageR.TabIndex = 1;
            this.tabPageR.Text = "Родительный (кого)";
            this.tabPageR.UseVisualStyleBackColor = true;
            this.R_postTextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.R_postTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.R_Post", true));
            this.R_postTextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.R_postTextBox.Location = new Point(113, 15);
            this.R_postTextBox.Multiline = true;
            this.R_postTextBox.Name = "R_postTextBox";
            this.R_postTextBox.ReadOnly = true;
            this.R_postTextBox.Size = new Size(552, 25);
            this.R_postTextBox.TabIndex = 35;
            this.r_OTextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.r_OTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.R_O", true));
            this.r_OTextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.r_OTextBox.Location = new Point(113, 127);
            this.r_OTextBox.Name = "r_OTextBox";
            this.r_OTextBox.ReadOnly = true;
            this.r_OTextBox.Size = new Size(552, 23);
            this.r_OTextBox.TabIndex = 53;
            this.r_ITextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.r_ITextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.R_I", true));
            this.r_ITextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.r_ITextBox.Location = new Point(113, 92);
            this.r_ITextBox.Name = "r_ITextBox";
            this.r_ITextBox.ReadOnly = true;
            this.r_ITextBox.Size = new Size(552, 23);
            this.r_ITextBox.TabIndex = 51;
            this.r_FTextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.r_FTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.R_F", true));
            this.r_FTextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.r_FTextBox.Location = new Point(113, 55);
            this.r_FTextBox.Name = "r_FTextBox";
            this.r_FTextBox.ReadOnly = true;
            this.r_FTextBox.Size = new Size(552, 23);
            this.r_FTextBox.TabIndex = 49;
            this.tabPageD.Controls.Add(this.D_postTextBox);
            this.tabPageD.Controls.Add(d_OLabel);
            this.tabPageD.Controls.Add(label9);
            this.tabPageD.Controls.Add(this.d_OTextBox);
            this.tabPageD.Controls.Add(d_ILabel);
            this.tabPageD.Controls.Add(this.d_ITextBox);
            this.tabPageD.Controls.Add(d_FLabel);
            this.tabPageD.Controls.Add(this.d_FTextBox);
            this.tabPageD.Location = new Point(4, 22);
            this.tabPageD.Name = "tabPageD";
            this.tabPageD.Padding = new Padding(3);
            this.tabPageD.Size = new Size(681, 159);
            this.tabPageD.TabIndex = 2;
            this.tabPageD.Text = "Дательный (кому)";
            this.tabPageD.UseVisualStyleBackColor = true;
            this.D_postTextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.D_postTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.D_Post", true));
            this.D_postTextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.D_postTextBox.Location = new Point(113, 15);
            this.D_postTextBox.Multiline = true;
            this.D_postTextBox.Name = "D_postTextBox";
            this.D_postTextBox.ReadOnly = true;
            this.D_postTextBox.Size = new Size(552, 25);
            this.D_postTextBox.TabIndex = 37;
            this.d_OTextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.d_OTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.D_O", true));
            this.d_OTextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.d_OTextBox.Location = new Point(113, 127);
            this.d_OTextBox.Name = "d_OTextBox";
            this.d_OTextBox.ReadOnly = true;
            this.d_OTextBox.Size = new Size(552, 23);
            this.d_OTextBox.TabIndex = 59;
            this.d_ITextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.d_ITextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.D_I", true));
            this.d_ITextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.d_ITextBox.Location = new Point(113, 92);
            this.d_ITextBox.Name = "d_ITextBox";
            this.d_ITextBox.ReadOnly = true;
            this.d_ITextBox.Size = new Size(552, 23);
            this.d_ITextBox.TabIndex = 57;
            this.d_FTextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.d_FTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.D_F", true));
            this.d_FTextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.d_FTextBox.Location = new Point(113, 55);
            this.d_FTextBox.Name = "d_FTextBox";
            this.d_FTextBox.ReadOnly = true;
            this.d_FTextBox.Size = new Size(552, 23);
            this.d_FTextBox.TabIndex = 55;
            this.tabPageT.CausesValidation = false;
            this.tabPageT.Controls.Add(this.T_postTextBox);
            this.tabPageT.Controls.Add(label10);
            this.tabPageT.Controls.Add(t_OLabel);
            this.tabPageT.Controls.Add(this.t_OTextBox);
            this.tabPageT.Controls.Add(t_ILabel);
            this.tabPageT.Controls.Add(this.t_ITextBox);
            this.tabPageT.Controls.Add(t_FLabel);
            this.tabPageT.Controls.Add(this.t_FTextBox);
            this.tabPageT.Location = new Point(4, 22);
            this.tabPageT.Name = "tabPageT";
            this.tabPageT.Padding = new Padding(3);
            this.tabPageT.Size = new Size(681, 159);
            this.tabPageT.TabIndex = 3;
            this.tabPageT.Text = "Творительный (кем)";
            this.tabPageT.UseVisualStyleBackColor = true;
            this.T_postTextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.T_postTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.T_Post", true));
            this.T_postTextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.T_postTextBox.Location = new Point(113, 15);
            this.T_postTextBox.Multiline = true;
            this.T_postTextBox.Name = "T_postTextBox";
            this.T_postTextBox.ReadOnly = true;
            this.T_postTextBox.Size = new Size(552, 25);
            this.T_postTextBox.TabIndex = 37;
            this.t_OTextBox.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.t_OTextBox.CausesValidation = false;
            this.t_OTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.T_O", true));
            this.t_OTextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.t_OTextBox.Location = new Point(113, 127);
            this.t_OTextBox.Name = "t_OTextBox";
            this.t_OTextBox.ReadOnly = true;
            this.t_OTextBox.Size = new Size(552, 23);
            this.t_OTextBox.TabIndex = 65;
            this.t_ITextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.t_ITextBox.CausesValidation = false;
            this.t_ITextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.T_I", true));
            this.t_ITextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.t_ITextBox.Location = new Point(113, 92);
            this.t_ITextBox.Name = "t_ITextBox";
            this.t_ITextBox.ReadOnly = true;
            this.t_ITextBox.Size = new Size(552, 23);
            this.t_ITextBox.TabIndex = 63;
            this.t_FTextBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.t_FTextBox.CausesValidation = false;
            this.t_FTextBox.DataBindings.Add(new Binding("Text", this.dsTU, "tG_AbnChief.T_F", true));
            this.t_FTextBox.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.t_FTextBox.Location = new Point(113, 55);
            this.t_FTextBox.Name = "t_FTextBox";
            this.t_FTextBox.ReadOnly = true;
            this.t_FTextBox.Size = new Size(552, 23);
            this.t_FTextBox.TabIndex = 61;
            this.tsDirector.Dock = DockStyle.Left;
            this.tsDirector.GripStyle = ToolStripGripStyle.Hidden;
            this.tsDirector.Items.AddRange(new ToolStripItem[]
            {
                this.tsbDirectorAdd,
                this.tsbDirectorEdit,
                this.tsbDirectorHistory
            });
            this.tsDirector.Location = new Point(3, 3);
            this.tsDirector.Name = "tsDirector";
            this.tsDirector.Size = new Size(24, 185);
            this.tsDirector.TabIndex = 39;
            this.tsDirector.Text = "toolStrip1";
            this.tsbDirectorAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.tsbDirectorAdd.Image = (Image)resources.GetObject("tsbDirectorAdd.Image");
            this.tsbDirectorAdd.ImageTransparentColor = Color.Magenta;
            this.tsbDirectorAdd.Name = "tsbDirectorAdd";
            this.tsbDirectorAdd.Size = new Size(21, 20);
            this.tsbDirectorAdd.Text = "Новый руководитель";
            this.tsbDirectorAdd.Click += this.tsbDirectorAdd_Click;
            this.tsbDirectorEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.tsbDirectorEdit.Image = (Image)resources.GetObject("tsbDirectorEdit.Image");
            this.tsbDirectorEdit.ImageTransparentColor = Color.Magenta;
            this.tsbDirectorEdit.Name = "tsbDirectorEdit";
            this.tsbDirectorEdit.Size = new Size(21, 20);
            this.tsbDirectorEdit.Text = "Редактировать руководителя";
            this.tsbDirectorEdit.Click += this.tsbDirectorEdit_Click;
            this.tsbDirectorHistory.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.tsbDirectorHistory.Image = (Image)resources.GetObject("tsbDirectorHistory.Image");
            this.tsbDirectorHistory.ImageTransparentColor = Color.Magenta;
            this.tsbDirectorHistory.Name = "tsbDirectorHistory";
            this.tsbDirectorHistory.Size = new Size(21, 20);
            this.tsbDirectorHistory.Text = "История руководителей";
            this.tsbDirectorHistory.Click += this.tsbDirectorHistory_Click;
            this.tabPageAddress.Controls.Add(this.groupBoxAddressP);
            this.tabPageAddress.Controls.Add(this.groupBoxAddressL);
            this.tabPageAddress.Controls.Add(this.tsAddress);
            this.tabPageAddress.Location = new Point(4, 22);
            this.tabPageAddress.Name = "tabPageAddress";
            this.tabPageAddress.Padding = new Padding(3);
            this.tabPageAddress.Size = new Size(719, 191);
            this.tabPageAddress.TabIndex = 2;
            this.tabPageAddress.Text = "Адреса";
            this.tabPageAddress.UseVisualStyleBackColor = true;
            this.groupBoxAddressP.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.groupBoxAddressP.Controls.Add(this.richTextBoxAddressP);
            this.groupBoxAddressP.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.groupBoxAddressP.Location = new Point(30, 93);
            this.groupBoxAddressP.Name = "groupBoxAddressP";
            this.groupBoxAddressP.Size = new Size(686, 101);
            this.groupBoxAddressP.TabIndex = 7;
            this.groupBoxAddressP.TabStop = false;
            this.groupBoxAddressP.Text = "Почтовый адрес";
            this.richTextBoxAddressP.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.richTextBoxAddressP.DataBindings.Add(new Binding("Text", this.dsTU, "vG_AbnAddressP.Representation", true));
            this.richTextBoxAddressP.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
            this.richTextBoxAddressP.Location = new Point(12, 19);
            this.richTextBoxAddressP.Name = "richTextBoxAddressP";
            this.richTextBoxAddressP.ReadOnly = true;
            this.richTextBoxAddressP.Size = new Size(656, 65);
            this.richTextBoxAddressP.TabIndex = 0;
            this.richTextBoxAddressP.Text = "";
            this.groupBoxAddressL.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.groupBoxAddressL.Controls.Add(this.richTextBoxAddressL);
            this.groupBoxAddressL.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 204);
            this.groupBoxAddressL.Location = new Point(30, 1);
            this.groupBoxAddressL.Name = "groupBoxAddressL";
            this.groupBoxAddressL.Size = new Size(687, 97);
            this.groupBoxAddressL.TabIndex = 6;
            this.groupBoxAddressL.TabStop = false;
            this.groupBoxAddressL.Text = "Юридический адрес";
            this.richTextBoxAddressL.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            this.richTextBoxAddressL.DataBindings.Add(new Binding("Text", this.dsTU, "vG_AbnAddressL.Representation", true));
            this.richTextBoxAddressL.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
            this.richTextBoxAddressL.Location = new Point(13, 19);
            this.richTextBoxAddressL.Name = "richTextBoxAddressL";
            this.richTextBoxAddressL.ReadOnly = true;
            this.richTextBoxAddressL.Size = new Size(656, 67);
            this.richTextBoxAddressL.TabIndex = 1;
            this.richTextBoxAddressL.Text = "";
            this.tsAddress.Dock = DockStyle.Left;
            this.tsAddress.GripStyle = ToolStripGripStyle.Hidden;
            this.tsAddress.Items.AddRange(new ToolStripItem[]
            {
                this.tsbAddressHistory
            });
            this.tsAddress.Location = new Point(3, 3);
            this.tsAddress.Name = "tsAddress";
            this.tsAddress.Size = new Size(24, 185);
            this.tsAddress.TabIndex = 5;
            this.tsAddress.Text = "toolStrip1";
            this.tsbAddressHistory.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.tsbAddressHistory.Image = (Image)resources.GetObject("tsbAddressHistory.Image");
            this.tsbAddressHistory.ImageTransparentColor = Color.Magenta;
            this.tsbAddressHistory.Name = "tsbAddressHistory";
            this.tsbAddressHistory.Size = new Size(21, 20);
            this.tsbAddressHistory.Text = "История адресов";
            this.tsbAddressHistory.Click += this.tsbAddressHistory_Click;
            this.tabPageContacts.Controls.Add(this.dGVAbnContact);
            this.tabPageContacts.Controls.Add(this.toolStripContact);
            this.tabPageContacts.Location = new Point(4, 22);
            this.tabPageContacts.Name = "tabPageContacts";
            this.tabPageContacts.Padding = new Padding(3);
            this.tabPageContacts.Size = new Size(719, 191);
            this.tabPageContacts.TabIndex = 3;
            this.tabPageContacts.Text = "Контакты";
            this.tabPageContacts.UseVisualStyleBackColor = true;
            this.dGVAbnContact.AllowUserToAddRows = false;
            this.dGVAbnContact.AllowUserToDeleteRows = false;
            this.dGVAbnContact.AutoGenerateColumns = false;
            this.dGVAbnContact.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVAbnContact.Columns.AddRange(new DataGridViewColumn[]
            {
                this.dataGridViewTextBoxColumn_0,
                this.dataGridViewTextBoxColumn_1,
                this.dataGridViewTextBoxColumn_2,
                this.dataGridViewTextBoxColumn_3,
                this.dataGridViewTextBoxColumn_4,
                this.dataGridViewTextBoxColumn_5,
                this.dataGridViewTextBoxColumn_6,
                this.dataGridViewTextBoxColumn_7,
                this.dataGridViewTextBoxColumn_8,
                this.dataGridViewTextBoxColumn_9
            });
            this.dGVAbnContact.DataSource = this.bsAbnContact;
            this.dGVAbnContact.Dock = DockStyle.Fill;
            this.dGVAbnContact.Location = new Point(27, 3);
            this.dGVAbnContact.MultiSelect = false;
            this.dGVAbnContact.Name = "dGVAbnContact";
            this.dGVAbnContact.ReadOnly = true;
            this.dGVAbnContact.RowHeadersWidth = 5;
            this.dGVAbnContact.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dGVAbnContact.RowTemplate.Height = 24;
            this.dGVAbnContact.Size = new Size(689, 185);
            this.dGVAbnContact.TabIndex = 6;
            this.toolStripContact.Dock = DockStyle.Left;
            this.toolStripContact.GripStyle = ToolStripGripStyle.Hidden;
            this.toolStripContact.Items.AddRange(new ToolStripItem[]
            {
                this.toolStripButton_7,
                this.toolStripButton_8,
                this.toolStripButton_9
            });
            this.toolStripContact.Location = new Point(3, 3);
            this.toolStripContact.Name = "toolStripContact";
            this.toolStripContact.Size = new Size(24, 185);
            this.toolStripContact.TabIndex = 3;
            this.toolStripContact.Text = "toolStrip1";
            this.toolStripButton_7.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton_7.Image = (Image)resources.GetObject("toolStripButtonNewContact.Image");
            this.toolStripButton_7.ImageTransparentColor = Color.Magenta;
            this.toolStripButton_7.Name = "toolStripButtonNewContact";
            this.toolStripButton_7.Size = new Size(21, 20);
            this.toolStripButton_7.Text = "Новый контакт";
            this.toolStripButton_7.Click += this.toolStripButton_7_Click;
            this.toolStripButton_8.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton_8.Image = (Image)resources.GetObject("toolStripButtonEditContac.Image");
            this.toolStripButton_8.ImageTransparentColor = Color.Magenta;
            this.toolStripButton_8.Name = "toolStripButtonEditContac";
            this.toolStripButton_8.Size = new Size(21, 20);
            this.toolStripButton_8.Text = "Редактировать контакт";
            this.toolStripButton_8.Click += this.toolStripButton_8_Click;
            this.toolStripButton_9.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton_9.Image = (Image)resources.GetObject("toolStripButtonDelContact.Image");
            this.toolStripButton_9.ImageTransparentColor = Color.Magenta;
            this.toolStripButton_9.Name = "toolStripButtonDelContact";
            this.toolStripButton_9.Size = new Size(21, 20);
            this.toolStripButton_9.Text = "Удалить контакт";
            this.toolStripButton_9.Click += this.toolStripButton_9_Click;
            this.tabPageTypeAbn.Controls.Add(this.dgvAbnType);
            this.tabPageTypeAbn.Controls.Add(this.toolStripAbnType);
            this.tabPageTypeAbn.Location = new Point(4, 22);
            this.tabPageTypeAbn.Name = "tabPageTypeAbn";
            this.tabPageTypeAbn.Padding = new Padding(3);
            this.tabPageTypeAbn.Size = new Size(719, 191);
            this.tabPageTypeAbn.TabIndex = 4;
            this.tabPageTypeAbn.Text = "Принадлежность к типу";
            this.tabPageTypeAbn.UseVisualStyleBackColor = true;
            this.dgvAbnType.AllowUserToAddRows = false;
            this.dgvAbnType.AllowUserToDeleteRows = false;
            this.dgvAbnType.AutoGenerateColumns = false;
            this.dgvAbnType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbnType.Columns.AddRange(new DataGridViewColumn[]
            {
                this.dataGridViewTextBoxColumn_32,
                this.dataGridViewTextBoxColumn_33,
                this.dataGridViewTextBoxColumn_34,
                this.dataGridViewTextBoxColumn_35
            });
            this.dgvAbnType.DataSource = this.bsAbnType;
            this.dgvAbnType.Dock = DockStyle.Fill;
            this.dgvAbnType.Location = new Point(27, 3);
            this.dgvAbnType.Name = "dgvAbnType";
            this.dgvAbnType.ReadOnly = true;
            this.dgvAbnType.RowHeadersWidth = 21;
            this.dgvAbnType.Size = new Size(689, 185);
            this.dgvAbnType.TabIndex = 38;
            this.toolStripAbnType.Dock = DockStyle.Left;
            this.toolStripAbnType.GripStyle = ToolStripGripStyle.Hidden;
            this.toolStripAbnType.Items.AddRange(new ToolStripItem[]
            {
                this.toolStripButton_17,
                this.toolStripButton_18,
                this.toolStripButton_19
            });
            this.toolStripAbnType.Location = new Point(3, 3);
            this.toolStripAbnType.Name = "toolStripAbnType";
            this.toolStripAbnType.Size = new Size(24, 185);
            this.toolStripAbnType.TabIndex = 37;
            this.toolStripAbnType.Text = "toolStrip1";
            this.toolStripButton_17.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton_17.Image = (Image)resources.GetObject("toolStripButton1.Image");
            this.toolStripButton_17.ImageTransparentColor = Color.Magenta;
            this.toolStripButton_17.Name = "toolStripButton1";
            this.toolStripButton_17.Size = new Size(21, 20);
            this.toolStripButton_17.Text = "Добавить";
            this.toolStripButton_17.Click += this.toolStripButton_17_Click;
            this.toolStripButton_18.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton_18.Image = (Image)resources.GetObject("toolStripButton2.Image");
            this.toolStripButton_18.ImageTransparentColor = Color.Magenta;
            this.toolStripButton_18.Name = "toolStripButton2";
            this.toolStripButton_18.Size = new Size(21, 20);
            this.toolStripButton_18.Text = "Редактировать";
            this.toolStripButton_18.Click += this.toolStripButton_18_Click;
            this.toolStripButton_19.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.toolStripButton_19.Image = (Image)resources.GetObject("toolStripButton3.Image");
            this.toolStripButton_19.ImageTransparentColor = Color.Magenta;
            this.toolStripButton_19.Name = "toolStripButton3";
            this.toolStripButton_19.Size = new Size(21, 20);
            this.toolStripButton_19.Text = "Удалить";
            this.toolStripButton_19.Click += this.toolStripButton_19_Click;

            this.buttonОК.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.buttonОК.DialogResult = DialogResult.OK;
            this.buttonОК.Location = new Point(12, 554);
            this.buttonОК.Name = "buttonОК";
            this.buttonОК.Size = new Size(75, 23);
            this.buttonОК.TabIndex = 10;
            this.buttonОК.Text = "ОК";
            this.buttonОК.UseVisualStyleBackColor = true;
            this.buttonОК.Click += this.buttonОК_Click;
            this.buttonCancel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(641, 554);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += this.buttonCancel_Click;

            this.chkVisibleNoActiveAbn.AutoSize = true;
            this.chkVisibleNoActiveAbn.Location = new Point(12, 145);
            this.chkVisibleNoActiveAbn.Name = "chkVisibleNoActiveAbn";
            this.chkVisibleNoActiveAbn.Size = new Size(194, 17);
            this.chkVisibleNoActiveAbn.TabIndex = 12;
            this.chkVisibleNoActiveAbn.Text = "Показать неактивных абонентов";
            this.chkVisibleNoActiveAbn.UseVisualStyleBackColor = true;
            this.chkVisibleNoActiveAbn.CheckedChanged += this.chkVisibleNoActiveAbn_CheckedChanged;
            this.dsTU.DataSetName = "DataSetTechConnection";
            this.dsTU.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.dataGridViewTextBoxColumn_0.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn_0.HeaderText = "id";
            this.dataGridViewTextBoxColumn_0.Name = "idDGVTBC";
            this.dataGridViewTextBoxColumn_0.ReadOnly = true;
            this.dataGridViewTextBoxColumn_0.Visible = false;
            this.dataGridViewTextBoxColumn_1.DataPropertyName = "idAbn";
            this.dataGridViewTextBoxColumn_1.HeaderText = "idAbn";
            this.dataGridViewTextBoxColumn_1.Name = "idAbnDataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn_1.ReadOnly = true;
            this.dataGridViewTextBoxColumn_1.Visible = false;
            this.dataGridViewTextBoxColumn_2.DataPropertyName = "Post";
            this.dataGridViewTextBoxColumn_2.HeaderText = "Должность";
            this.dataGridViewTextBoxColumn_2.Name = "postDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_2.ReadOnly = true;
            this.dataGridViewTextBoxColumn_3.DataPropertyName = "F";
            this.dataGridViewTextBoxColumn_3.HeaderText = "Фамилия";
            this.dataGridViewTextBoxColumn_3.Name = "fDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_3.ReadOnly = true;
            this.dataGridViewTextBoxColumn_4.DataPropertyName = "I";
            this.dataGridViewTextBoxColumn_4.HeaderText = "Имя";
            this.dataGridViewTextBoxColumn_4.Name = "iDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_4.ReadOnly = true;
            this.dataGridViewTextBoxColumn_5.DataPropertyName = "O";
            this.dataGridViewTextBoxColumn_5.HeaderText = "Отчество";
            this.dataGridViewTextBoxColumn_5.Name = "oDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_5.ReadOnly = true;
            this.dataGridViewTextBoxColumn_6.DataPropertyName = "Phone";
            this.dataGridViewTextBoxColumn_6.HeaderText = "Телефон";
            this.dataGridViewTextBoxColumn_6.Name = "phoneDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_6.ReadOnly = true;
            this.dataGridViewTextBoxColumn_7.DataPropertyName = "email";
            this.dataGridViewTextBoxColumn_7.HeaderText = "E-mail";
            this.dataGridViewTextBoxColumn_7.Name = "emailDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_7.ReadOnly = true;
            this.dataGridViewTextBoxColumn_8.DataPropertyName = "DateChange";
            this.dataGridViewTextBoxColumn_8.HeaderText = "Дата";
            this.dataGridViewTextBoxColumn_8.Name = "dateChangeDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_8.ReadOnly = true;
            this.dataGridViewTextBoxColumn_8.Visible = false;
            this.dataGridViewTextBoxColumn_9.DataPropertyName = "Comment";
            this.dataGridViewTextBoxColumn_9.HeaderText = "Коментарий";
            this.dataGridViewTextBoxColumn_9.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn_9.ReadOnly = true;
            this.bsAbnContact.DataMember = "tAbnContact";
            this.bsAbnContact.DataSource = this.dsTU;
            this.dataGridViewTextBoxColumn_32.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn_32.DataPropertyName = "typeKontragentName";
            this.dataGridViewTextBoxColumn_32.HeaderText = "Тип";
            this.dataGridViewTextBoxColumn_32.Name = "typeKontragentNameDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_32.ReadOnly = true;
            this.dataGridViewTextBoxColumn_33.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn_33.HeaderText = "id";
            this.dataGridViewTextBoxColumn_33.Name = "idAbnTypeDgvColumn";
            this.dataGridViewTextBoxColumn_33.ReadOnly = true;
            this.dataGridViewTextBoxColumn_33.Visible = false;
            this.dataGridViewTextBoxColumn_34.DataPropertyName = "CodeAbonent";
            this.dataGridViewTextBoxColumn_34.HeaderText = "CodeAbonent";
            this.dataGridViewTextBoxColumn_34.Name = "codeAbonentDataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn_34.ReadOnly = true;
            this.dataGridViewTextBoxColumn_34.Visible = false;
            this.dataGridViewTextBoxColumn_35.DataPropertyName = "typeKontragent";
            this.dataGridViewTextBoxColumn_35.HeaderText = "typeKontragent";
            this.dataGridViewTextBoxColumn_35.Name = "typeKontragentDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_35.ReadOnly = true;
            this.dataGridViewTextBoxColumn_35.Visible = false;
            this.bsAbnType.DataMember = "vAbnType";
            this.bsAbnType.DataSource = this.dsTU;
            this.bsAbnType.Sort = "typeKontragentName";
            this.dataGridViewTextBoxColumn_36.DataPropertyName = "CodeAbonent";
            this.dataGridViewTextBoxColumn_36.HeaderText = "Код";
            this.dataGridViewTextBoxColumn_36.Name = "codeAbonentDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_36.ReadOnly = true;
            this.dataGridViewTextBoxColumn_36.Width = 80;
            this.dataGridViewTextBoxColumn_37.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn_37.HeaderText = "id";
            this.dataGridViewTextBoxColumn_37.Name = "idKontragentDgvColumn";
            this.dataGridViewTextBoxColumn_37.ReadOnly = true;
            this.dataGridViewTextBoxColumn_37.Visible = false;
            this.dataGridViewTextBoxColumn_38.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn_38.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn_38.HeaderText = "Контрагент";
            this.dataGridViewTextBoxColumn_38.Name = "nameDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_38.ReadOnly = true;
            this.dataGridViewTextBoxColumn_40.DataPropertyName = "TypeAbn";
            this.dataGridViewTextBoxColumn_40.HeaderText = "TypeAbn";
            this.dataGridViewTextBoxColumn_40.Name = "typeAbnDgvColumn";
            this.dataGridViewTextBoxColumn_40.ReadOnly = true;
            this.dataGridViewTextBoxColumn_40.Visible = false;
            this.bsAbn.DataMember = "vAbn";
            this.bsAbn.DataSource = this.dsTU;
            this.bsAbn.CurrentChanged += this.bsAbn_CurrentChanged;
            this.dataGridViewTextBoxColumn_10.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn_10.HeaderText = "id";
            this.dataGridViewTextBoxColumn_10.Name = "idObjDgvColumn";
            this.dataGridViewTextBoxColumn_10.ReadOnly = true;
            this.dataGridViewTextBoxColumn_10.Visible = false;
            this.dataGridViewTextBoxColumn_12.DataPropertyName = "idAbn";
            this.dataGridViewTextBoxColumn_12.HeaderText = "idAbn";
            this.dataGridViewTextBoxColumn_12.Name = "idAbnDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_12.ReadOnly = true;
            this.dataGridViewTextBoxColumn_12.Visible = false;
            this.dataGridViewTextBoxColumn_13.DataPropertyName = "idMap";
            this.dataGridViewTextBoxColumn_13.HeaderText = "idMap";
            this.dataGridViewTextBoxColumn_13.Name = "idMapDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_13.ReadOnly = true;
            this.dataGridViewTextBoxColumn_13.Visible = false;
            this.dataGridViewTextBoxColumn_14.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn_14.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn_14.HeaderText = "Объект";
            this.dataGridViewTextBoxColumn_14.Name = "nameObjDgvColumn";
            this.dataGridViewTextBoxColumn_14.ReadOnly = true;
            this.dataGridViewTextBoxColumn_17.DataPropertyName = "Comment";
            this.dataGridViewTextBoxColumn_17.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn_17.Name = "commentDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_17.ReadOnly = true;
            this.dataGridViewTextBoxColumn_17.Visible = false;
            this.dataGridViewTextBoxColumn_18.DataPropertyName = "idCity";
            this.dataGridViewTextBoxColumn_18.HeaderText = "idCity";
            this.dataGridViewTextBoxColumn_18.Name = "idCityDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_18.ReadOnly = true;
            this.dataGridViewTextBoxColumn_18.Visible = false;
            this.dataGridViewTextBoxColumn_19.DataPropertyName = "City";
            this.dataGridViewTextBoxColumn_19.HeaderText = "City";
            this.dataGridViewTextBoxColumn_19.Name = "cityDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_19.ReadOnly = true;
            this.dataGridViewTextBoxColumn_19.Visible = false;
            this.dataGridViewTextBoxColumn_20.DataPropertyName = "idRaion";
            this.dataGridViewTextBoxColumn_20.HeaderText = "idRaion";
            this.dataGridViewTextBoxColumn_20.Name = "idRaionDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_20.ReadOnly = true;
            this.dataGridViewTextBoxColumn_20.Visible = false;
            this.dataGridViewTextBoxColumn_21.DataPropertyName = "Raion";
            this.dataGridViewTextBoxColumn_21.HeaderText = "Raion";
            this.dataGridViewTextBoxColumn_21.Name = "raionDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_21.ReadOnly = true;
            this.dataGridViewTextBoxColumn_21.Visible = false;
            this.dataGridViewTextBoxColumn_22.DataPropertyName = "idStreet";
            this.dataGridViewTextBoxColumn_22.HeaderText = "idStreet";
            this.dataGridViewTextBoxColumn_22.Name = "idStreetDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_22.ReadOnly = true;
            this.dataGridViewTextBoxColumn_22.Visible = false;
            this.dataGridViewTextBoxColumn_23.DataPropertyName = "Street";
            this.dataGridViewTextBoxColumn_23.HeaderText = "Street";
            this.dataGridViewTextBoxColumn_23.Name = "streetDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_23.ReadOnly = true;
            this.dataGridViewTextBoxColumn_23.Visible = false;
            this.zauYlEgnqI.DataPropertyName = "House";
            this.zauYlEgnqI.HeaderText = "House";
            this.zauYlEgnqI.Name = "houseDataGridViewTextBoxColumn";
            this.zauYlEgnqI.ReadOnly = true;
            this.zauYlEgnqI.Visible = false;
            this.dataGridViewTextBoxColumn_24.DataPropertyName = "HousePrefix";
            this.dataGridViewTextBoxColumn_24.HeaderText = "HousePrefix";
            this.dataGridViewTextBoxColumn_24.Name = "housePrefixDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_24.ReadOnly = true;
            this.dataGridViewTextBoxColumn_24.Visible = false;
            this.dataGridViewTextBoxColumn_25.DataPropertyName = "HouseAll";
            this.dataGridViewTextBoxColumn_25.HeaderText = "HouseAll";
            this.dataGridViewTextBoxColumn_25.Name = "houseAllDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_25.ReadOnly = true;
            this.dataGridViewTextBoxColumn_25.Visible = false;
            this.dataGridViewCheckBoxColumn_0.DataPropertyName = "IsHouse";
            this.dataGridViewCheckBoxColumn_0.HeaderText = "IsHouse";
            this.dataGridViewCheckBoxColumn_0.Name = "isHouseDataGridViewCheckBoxColumn";
            this.dataGridViewCheckBoxColumn_0.ReadOnly = true;
            this.dataGridViewCheckBoxColumn_0.Visible = false;
            this.dataGridViewTextBoxColumn_26.DataPropertyName = "Index";
            this.dataGridViewTextBoxColumn_26.HeaderText = "Index";
            this.dataGridViewTextBoxColumn_26.Name = "indexDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_26.ReadOnly = true;
            this.dataGridViewTextBoxColumn_26.Visible = false;
            this.dataGridViewTextBoxColumn_27.DataPropertyName = "Latitude";
            this.dataGridViewTextBoxColumn_27.HeaderText = "Latitude";
            this.dataGridViewTextBoxColumn_27.Name = "latitudeDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_27.ReadOnly = true;
            this.dataGridViewTextBoxColumn_27.Visible = false;
            this.dataGridViewTextBoxColumn_28.DataPropertyName = "Longitude";
            this.dataGridViewTextBoxColumn_28.HeaderText = "Longitude";
            this.dataGridViewTextBoxColumn_28.Name = "longitudeDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_28.ReadOnly = true;
            this.dataGridViewTextBoxColumn_28.Visible = false;
            this.dataGridViewTextBoxColumn_29.DataPropertyName = "idObjParent";
            this.dataGridViewTextBoxColumn_29.HeaderText = "idObjParent";
            this.dataGridViewTextBoxColumn_29.Name = "idObjParentDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_29.ReadOnly = true;
            this.dataGridViewTextBoxColumn_29.Visible = false;
            this.dataGridViewTextBoxColumn_30.DataPropertyName = "TypeObj";
            this.dataGridViewTextBoxColumn_30.HeaderText = "TypeObj";
            this.dataGridViewTextBoxColumn_30.Name = "typeObjDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_30.ReadOnly = true;
            this.dataGridViewTextBoxColumn_30.Visible = false;
            this.dataGridViewTextBoxColumn_31.DataPropertyName = "TypeObjName";
            this.dataGridViewTextBoxColumn_31.HeaderText = "TypeObjName";
            this.dataGridViewTextBoxColumn_31.Name = "typeObjNameDataGridViewTextBoxColumn";
            this.dataGridViewTextBoxColumn_31.ReadOnly = true;
            this.dataGridViewTextBoxColumn_31.Visible = false;
            this.bsAbnObjAddress.DataMember = "vAbnObjAddress";
            this.bsAbnObjAddress.DataSource = this.dsTU;
            this.bsAbnObjAddress.CurrentChanged += this.bsAbnObjAddress_CurrentChanged;
            base.AcceptButton = this.buttonОК;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(727, 578);
            base.Controls.Add(this.chkVisibleNoActiveAbn);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonОК);
            base.Controls.Add(this.tabControlContr);
            base.Controls.Add(this.groupBoxSelect);
            base.Controls.Add(this.splitContainerDgv);
            base.Controls.Add(this.groupBox1);
            base.Name = "FormTechConnectionAddAbn";
            this.Text = "Выбор/создание контрагента";
            base.Load += this.FormTechConnectionAddAbn_Load;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((ISupportInitialize)this.dgvAbn).EndInit();
            ((ISupportInitialize)this.dgvObj).EndInit();
            this.splitContainerDgv.Panel1.ResumeLayout(false);
            this.splitContainerDgv.Panel1.PerformLayout();
            this.splitContainerDgv.Panel2.ResumeLayout(false);
            this.splitContainerDgv.Panel2.PerformLayout();
            this.splitContainerDgv.ResumeLayout(false);
            this.toolStripCont.ResumeLayout(false);
            this.toolStripCont.PerformLayout();
            this.toolStripObj.ResumeLayout(false);
            this.toolStripObj.PerformLayout();
            this.groupBoxSelect.ResumeLayout(false);
            this.groupBoxSelect.PerformLayout();
            ((ISupportInitialize)this.dsKladrStreet).EndInit();
            ((ISupportInitialize)this.tableKladrStreet).EndInit();
            ((ISupportInitialize)this.dsKladr).EndInit();
            ((ISupportInitialize)this.tblKladrObj).EndInit();
            ((ISupportInitialize)this.dsKladrObj).EndInit();
            ((ISupportInitialize)this.tblKladrObjRaion).EndInit();
            ((ISupportInitialize)this.dataSet_3).EndInit();
            ((ISupportInitialize)this.tblKladrObjSubject).EndInit();
            this.tabControlContr.ResumeLayout(false);
            this.tabPageAbnInfo.ResumeLayout(false);
            this.tabPageAbnInfo.PerformLayout();
            this.tsAbnInfo.ResumeLayout(false);
            this.tsAbnInfo.PerformLayout();
            this.tabPageDirector.ResumeLayout(false);
            this.tabPageDirector.PerformLayout();
            this.tabControlDirectorFIO.ResumeLayout(false);
            this.tabPageI.ResumeLayout(false);
            this.tabPageI.PerformLayout();
            this.tabPageR.ResumeLayout(false);
            this.tabPageR.PerformLayout();
            this.tabPageD.ResumeLayout(false);
            this.tabPageD.PerformLayout();
            this.tabPageT.ResumeLayout(false);
            this.tabPageT.PerformLayout();
            this.tsDirector.ResumeLayout(false);
            this.tsDirector.PerformLayout();
            this.tabPageAddress.ResumeLayout(false);
            this.tabPageAddress.PerformLayout();
            this.groupBoxAddressP.ResumeLayout(false);
            this.groupBoxAddressL.ResumeLayout(false);
            this.tsAddress.ResumeLayout(false);
            this.tsAddress.PerformLayout();
            this.tabPageContacts.ResumeLayout(false);
            this.tabPageContacts.PerformLayout();
            ((ISupportInitialize)this.dGVAbnContact).EndInit();
            this.toolStripContact.ResumeLayout(false);
            this.toolStripContact.PerformLayout();
            this.tabPageTypeAbn.ResumeLayout(false);
            this.tabPageTypeAbn.PerformLayout();
            ((ISupportInitialize)this.dgvAbnType).EndInit();
            this.toolStripAbnType.ResumeLayout(false);
            this.toolStripAbnType.PerformLayout();
            ((ISupportInitialize)this.dsTU).EndInit();
            ((ISupportInitialize)this.bsAbnContact).EndInit();
            ((ISupportInitialize)this.bsAbnType).EndInit();
            ((ISupportInitialize)this.bsAbn).EndInit();
            ((ISupportInitialize)this.bsAbnObjAddress).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        //private Class10.Class16 tableAbnObjAddress;
        private DataSetTC.vAbnObjAddressDataTable tableAbnObjAddress;

        private GroupBox groupBox1;

        private RadioButton radioButtonUL;

        private RadioButton radioButtonFL;

        private TextBox txtCurrentAbn;

        private DataSetTC dsTU;

        private BindingSource bsAbn;

        private DataGridViewExcelFilter dgvAbn;

        private Timer timer1;

        private BindingSource bsAbnObjAddress;

        private DataGridViewExcelFilter dgvObj;

        private SplitContainer splitContainerDgv;

        private GroupBox groupBoxSelect;

        private RadioButton radioButtonSelectName;

        private ComboBox cmbObl;

        private RadioButton radioButtonSelAddress;

        private ComboBox cmbStreet;

        private Label label80;

        private ComboBox cmbPunkt;

        private Label labelSettlement;

        private ComboBox cmbCity;

        private Label labelSity;

        private Label labelRegion;

        private TextBox txtFlat;

        private Label label82;

        private TextBox txtHousePrefix;

        private Label label71;

        private TextBox txtHouse;

        private Label label83;

        private DataSet dsKladrStreet;

        private DataTable tableKladrStreet;

        private DataColumn dataColumnId4;

        private DataColumn dataColumnName4;

        private DataColumn dataColumnSocr4;

        private DataColumn dataColumnNameSocr4;

        private DataColumn dataColumnIndex4;

        private DataSet dsKladr;

        private DataTable tblKladrObj;

        private DataColumn dataColumnId;

        private DataColumn dataColumnName;

        private DataColumn dataColumnSocr;

        private DataColumn dataColumnNameSocr;

        private DataSet dsKladrObj;

        private DataTable tblKladrObjRaion;

        private DataColumn dataColumnid2;

        private DataColumn dataColumnname2;

        private DataColumn dataColumnsocr2;

        private DataColumn dataColumnnamesocr2;

        private DataSet dataSet_3;

        private DataTable tblKladrObjSubject;

        private DataColumn dataColumnId3;

        private DataColumn dataColumnName3;

        private DataColumn dataColumnSocr3;

        private DataColumn dataColumnNameSocr3;

        private TabControl tabControlContr;

        private TabPage tabPageAbnInfo;

        private TabPage tabPageDirector;

        private ToolStrip tsAbnInfo;

        private ToolStripButton tsbAddAbnInfo;

        private ToolStripButton tsbEditInfo;

        private ToolStripButton tsbInfoHistory;

        private TextBox nameFullTextBox;

        private TextBox iNNTextBox;

        private TextBox bankAcntTextBox;

        private TextBox kPPTextBox;

        private TextBox bankDestTextBox;

        private TextBox oKVEDTextBox;

        private TextBox bankIDTextBox;

        private TextBox oKPOTextBox;

        private ToolStrip tsDirector;

        private ToolStripButton tsbDirectorAdd;

        private ToolStripButton tsbDirectorEdit;

        private ToolStripButton tsbDirectorHistory;

        private TabControl tabControlDirectorFIO;

        private TabPage tabPageI;

        private TextBox I_postTextBox;

        private TextBox i_OTextBox;

        private TextBox i_ITextBox;

        private TextBox i_FTextBox;

        private TabPage tabPageR;

        private TextBox R_postTextBox;

        private TextBox r_OTextBox;

        private TextBox r_ITextBox;

        private TextBox r_FTextBox;

        private TabPage tabPageD;

        private TextBox D_postTextBox;

        private TextBox d_OTextBox;

        private TextBox d_ITextBox;

        private TextBox d_FTextBox;

        private TabPage tabPageT;

        private TextBox T_postTextBox;

        private TextBox t_OTextBox;

        private TextBox t_ITextBox;

        private TextBox t_FTextBox;

        private TabPage tabPageAddress;

        private TabPage tabPageContacts;

        private ToolStrip tsAddress;

        private ToolStripButton tsbAddressHistory;

        private GroupBox groupBoxAddressP;

        private RichTextBox richTextBoxAddressP;

        private GroupBox groupBoxAddressL;

        private RichTextBox richTextBoxAddressL;

        private ToolStrip toolStripContact;

        private ToolStripButton toolStripButton_7;

        private ToolStripButton toolStripButton_8;

        private ToolStripButton toolStripButton_9;

        private BindingSource bsAbnContact;

        private DataGridView dGVAbnContact;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

        private ToolStrip toolStripCont;

        private ToolStripButton toolBtnAddCont;

        private ToolStripButton toolBtnEditCont;

        private ToolStripButton toolBtnDelCont;

        private ToolStrip toolStripObj;

        private ToolStripButton toolBtnAddObj;

        private ToolStripButton toolBtnEditObj;

        private ToolStripButton toolBtnDelObj;

        private ToolStripSeparator toolStripSeparator_0;

        private ToolStripButton toolBtnShowDelAbn;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

        private DataGridViewTextBoxColumn idObjRegDgvColumn;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

        private DataGridViewTextBoxColumn addressULDgvColumn;

        private DataGridViewTextBoxColumn addressFLDgvColumn;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_22;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_23;

        private DataGridViewTextBoxColumn zauYlEgnqI;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_24;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_25;

        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn_0;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_26;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_27;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_28;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_29;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_30;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_31;

        private Button buttonОК;

        private Button buttonCancel;

        private TabPage tabPageTypeAbn;

        private ToolStrip toolStripAbnType;

        private ToolStripButton toolStripButton_17;

        private ToolStripButton toolStripButton_18;

        private ToolStripButton toolStripButton_19;

        private DataGridViewExcelFilter dgvAbnType;

        private BindingSource bsAbnType;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_32;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_33;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_34;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_35;

        private CheckBox chkVisibleNoActiveAbn;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_36;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_37;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_38;

        private DataGridViewTextBoxColumn typeNameSocrDgvColumn;

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_40;

        private DataGridViewCheckBoxColumn deletedKontragentDgvColumn;

        private DataGridViewCheckBoxColumn isActiveDgvColumn;
    }

    



}
