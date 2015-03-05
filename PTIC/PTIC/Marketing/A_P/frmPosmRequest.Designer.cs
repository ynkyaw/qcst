namespace PTIC.VC.Marketing.A_P
{
    partial class frmPosmRequest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGiver = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbGiverDept = new System.Windows.Forms.ComboBox();
            this.txtTitleNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpRequestDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdoVen = new System.Windows.Forms.RadioButton();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.rdoDept = new System.Windows.Forms.RadioButton();
            this.cmbDeptVen = new System.Windows.Forms.ComboBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvPosmRequest = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAPSubCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPosm = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAP_RequestDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAP_RequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestPurposeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestVenID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequesterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosmRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel2.Controls.Add(this.lblSetup);
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(924, 44);
            this.panel2.TabIndex = 172;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(10, 12);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(54, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "A && P";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(149)))), ((int)(((byte)(206)))));
            this.lblHeaderPCat.Location = new System.Drawing.Point(70, 12);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(169, 20);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">  POSM တောင်းခံခြင်း";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.groupBox2);
            this.pnlFilter.Controls.Add(this.txtTitleNo);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.dtpRequestDate);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.groupBox1);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 44);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(924, 149);
            this.pnlFilter.TabIndex = 179;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbGiver);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbGiverDept);
            this.groupBox2.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Location = new System.Drawing.Point(590, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 140);
            this.groupBox2.TabIndex = 204;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ထုတ်ပေးသည့် နေရာ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label5.Location = new System.Drawing.Point(19, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 208;
            this.label5.Text = "ထုတ်ပေးသူ";
            // 
            // cmbGiver
            // 
            this.cmbGiver.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGiver.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGiver.DisplayMember = "APSubCategoryName";
            this.cmbGiver.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbGiver.FormattingEnabled = true;
            this.cmbGiver.Location = new System.Drawing.Point(143, 72);
            this.cmbGiver.Name = "cmbGiver";
            this.cmbGiver.Size = new System.Drawing.Size(150, 27);
            this.cmbGiver.TabIndex = 207;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label3.Location = new System.Drawing.Point(19, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 206;
            this.label3.Text = "ထုတ်ပေးသည့် ဌာန";
            // 
            // cmbGiverDept
            // 
            this.cmbGiverDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGiverDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGiverDept.DisplayMember = "APSubCategoryName";
            this.cmbGiverDept.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbGiverDept.FormattingEnabled = true;
            this.cmbGiverDept.Location = new System.Drawing.Point(143, 38);
            this.cmbGiverDept.Name = "cmbGiverDept";
            this.cmbGiverDept.Size = new System.Drawing.Size(150, 27);
            this.cmbGiverDept.TabIndex = 205;
            this.cmbGiverDept.SelectedIndexChanged += new System.EventHandler(this.cmbGiverDept_SelectedIndexChanged);
            // 
            // txtTitleNo
            // 
            this.txtTitleNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitleNo.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtTitleNo.Location = new System.Drawing.Point(84, 42);
            this.txtTitleNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTitleNo.Name = "txtTitleNo";
            this.txtTitleNo.Size = new System.Drawing.Size(150, 28);
            this.txtTitleNo.TabIndex = 199;
            this.txtTitleNo.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label1.Location = new System.Drawing.Point(16, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 198;
            this.label1.Text = "စာအမှတ်";
            this.label1.Visible = false;
            // 
            // dtpRequestDate
            // 
            this.dtpRequestDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpRequestDate.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dtpRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequestDate.Location = new System.Drawing.Point(84, 8);
            this.dtpRequestDate.Name = "dtpRequestDate";
            this.dtpRequestDate.Size = new System.Drawing.Size(150, 28);
            this.dtpRequestDate.TabIndex = 197;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 196;
            this.label2.Text = "နေ့စွဲ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rdoVen);
            this.groupBox1.Controls.Add(this.cmbEmployee);
            this.groupBox1.Controls.Add(this.rdoDept);
            this.groupBox1.Controls.Add(this.cmbDeptVen);
            this.groupBox1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(255, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 140);
            this.groupBox1.TabIndex = 203;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "တောင်းခံသည့် နေရာ";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label4.Location = new System.Drawing.Point(14, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 202;
            this.label4.Text = "တောင်းခံသူ";
            // 
            // rdoVen
            // 
            this.rdoVen.AutoSize = true;
            this.rdoVen.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.rdoVen.Location = new System.Drawing.Point(18, 57);
            this.rdoVen.Name = "rdoVen";
            this.rdoVen.Size = new System.Drawing.Size(104, 24);
            this.rdoVen.TabIndex = 197;
            this.rdoVen.TabStop = true;
            this.rdoVen.Text = "အရောင်းကား";
            this.rdoVen.UseVisualStyleBackColor = true;
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmployee.DisplayMember = "APSubCategoryName";
            this.cmbEmployee.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(128, 93);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(150, 27);
            this.cmbEmployee.TabIndex = 200;
            this.cmbEmployee.ValueMember = "ID";
            // 
            // rdoDept
            // 
            this.rdoDept.AutoSize = true;
            this.rdoDept.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.rdoDept.Location = new System.Drawing.Point(18, 27);
            this.rdoDept.Name = "rdoDept";
            this.rdoDept.Size = new System.Drawing.Size(52, 24);
            this.rdoDept.TabIndex = 196;
            this.rdoDept.TabStop = true;
            this.rdoDept.Text = "ဌာန";
            this.rdoDept.UseVisualStyleBackColor = true;
            this.rdoDept.CheckedChanged += new System.EventHandler(this.rdoDept_CheckedChanged);
            // 
            // cmbDeptVen
            // 
            this.cmbDeptVen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDeptVen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDeptVen.DisplayMember = "APSubCategoryName";
            this.cmbDeptVen.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbDeptVen.FormattingEnabled = true;
            this.cmbDeptVen.Location = new System.Drawing.Point(128, 40);
            this.cmbDeptVen.Name = "cmbDeptVen";
            this.cmbDeptVen.Size = new System.Drawing.Size(150, 27);
            this.cmbDeptVen.TabIndex = 195;
            this.cmbDeptVen.ValueMember = "ID";
            this.cmbDeptVen.SelectedIndexChanged += new System.EventHandler(this.cmbDeptVen_SelectedIndexChanged);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnIssue);
            this.pnlFooter.Controls.Add(this.btnNew);
            this.pnlFooter.Controls.Add(this.btnDelete);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 409);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(924, 50);
            this.pnlFooter.TabIndex = 180;
            // 
            // btnIssue
            // 
            this.btnIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIssue.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnIssue.Location = new System.Drawing.Point(348, 8);
            this.btnIssue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(95, 34);
            this.btnIssue.TabIndex = 173;
            this.btnIssue.Text = "ထုတ်ပေးမည်";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Visible = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnNew.Location = new System.Drawing.Point(14, 8);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 34);
            this.btnNew.TabIndex = 172;
            this.btnNew.Text = "ထည့်မည်";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnDelete.Location = new System.Drawing.Point(236, 8);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 171;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSave.Location = new System.Drawing.Point(125, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 170;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvPosmRequest
            // 
            this.dgvPosmRequest.AllowUserToAddRows = false;
            this.dgvPosmRequest.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPosmRequest.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(175)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPosmRequest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPosmRequest.ColumnHeadersHeight = 50;
            this.dgvPosmRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPosmRequest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAPSubCategory,
            this.colPosm,
            this.colQuantity,
            this.colDescription,
            this.colRemark,
            this.colAP_RequestDetailID,
            this.colRequestDate,
            this.colAP_RequestID,
            this.colRequestPurposeID,
            this.colRequestDept,
            this.colRequestVenID,
            this.colRequesterID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPosmRequest.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPosmRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPosmRequest.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPosmRequest.EnableHeadersVisualStyles = false;
            this.dgvPosmRequest.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(36)))), ((int)(((byte)(60)))));
            this.dgvPosmRequest.Location = new System.Drawing.Point(0, 193);
            this.dgvPosmRequest.MultiSelect = false;
            this.dgvPosmRequest.Name = "dgvPosmRequest";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(175)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPosmRequest.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPosmRequest.RowHeadersWidth = 50;
            this.dgvPosmRequest.RowTemplate.Height = 28;
            this.dgvPosmRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPosmRequest.Size = new System.Drawing.Size(924, 216);
            this.dgvPosmRequest.TabIndex = 181;
            this.dgvPosmRequest.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPosmRequest_CellBeginEdit);
            this.dgvPosmRequest.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPosmRequest_CellEndEdit);
            this.dgvPosmRequest.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvPosmRequest_CellValidating);
            this.dgvPosmRequest.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvPosmRequest_CurrentCellDirtyStateChanged);
            this.dgvPosmRequest.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPosmRequest_DataBindingComplete);
            this.dgvPosmRequest.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPosmRequest_DataError);
            this.dgvPosmRequest.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPosmRequest_EditingControlShowing);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Qty";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.NullValue = "1";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Remark";
            this.dataGridViewTextBoxColumn2.HeaderText = "မှတ်ချက်";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "AP_RequestDetailID";
            this.dataGridViewTextBoxColumn3.HeaderText = "AP_RequestDetailID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "AP_RequestID";
            this.dataGridViewTextBoxColumn4.HeaderText = "AP_RequestID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // colAPSubCategory
            // 
            this.colAPSubCategory.DataPropertyName = "AP_SubCategoryID";
            this.colAPSubCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colAPSubCategory.HeaderText = "A & P အမျိုးအစားခွဲ";
            this.colAPSubCategory.Name = "colAPSubCategory";
            this.colAPSubCategory.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAPSubCategory.Width = 200;
            // 
            // colPosm
            // 
            this.colPosm.DataPropertyName = "AP_MaterialID";
            this.colPosm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colPosm.HeaderText = "POSM";
            this.colPosm.Name = "colPosm";
            this.colPosm.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPosm.Width = 250;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "RequestQty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQuantity.HeaderText = "Qty";
            this.colQuantity.MaxInputLength = 6;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQuantity.Width = 60;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "RequestPurpose";
            this.colDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDescription.HeaderText = "အကြောင်းအရာ";
            this.colDescription.Items.AddRange(new object[] {
            "Outlet များပေး",
            "Retailer များပေး",
            "ခရီးစဉ်",
            "လက်ဆောင်ပေး",
            "ရုံးသုံး",
            "အခြား"});
            this.colDescription.Name = "colDescription";
            this.colDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDescription.Width = 200;
            // 
            // colRemark
            // 
            this.colRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "မှတ်ချက်";
            this.colRemark.Name = "colRemark";
            this.colRemark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAP_RequestDetailID
            // 
            this.colAP_RequestDetailID.DataPropertyName = "AP_RequestDetailID";
            this.colAP_RequestDetailID.HeaderText = "AP_RequestDetailID";
            this.colAP_RequestDetailID.Name = "colAP_RequestDetailID";
            this.colAP_RequestDetailID.Visible = false;
            // 
            // colRequestDate
            // 
            this.colRequestDate.DataPropertyName = "RequestDate";
            this.colRequestDate.HeaderText = "RequestDate";
            this.colRequestDate.Name = "colRequestDate";
            this.colRequestDate.Visible = false;
            // 
            // colAP_RequestID
            // 
            this.colAP_RequestID.DataPropertyName = "AP_RequestID";
            this.colAP_RequestID.HeaderText = "AP_RequestID";
            this.colAP_RequestID.Name = "colAP_RequestID";
            this.colAP_RequestID.Visible = false;
            // 
            // colRequestPurposeID
            // 
            this.colRequestPurposeID.DataPropertyName = "RequestPurpose";
            this.colRequestPurposeID.HeaderText = "RequestPurposeID";
            this.colRequestPurposeID.Name = "colRequestPurposeID";
            this.colRequestPurposeID.Visible = false;
            // 
            // colRequestDept
            // 
            this.colRequestDept.DataPropertyName = "RequestDeptID";
            this.colRequestDept.HeaderText = "RequestDeptID";
            this.colRequestDept.Name = "colRequestDept";
            this.colRequestDept.Visible = false;
            // 
            // colRequestVenID
            // 
            this.colRequestVenID.DataPropertyName = "RequestVenID";
            this.colRequestVenID.HeaderText = "RequestVenID";
            this.colRequestVenID.Name = "colRequestVenID";
            this.colRequestVenID.Visible = false;
            // 
            // colRequesterID
            // 
            this.colRequesterID.DataPropertyName = "RequesterID";
            this.colRequesterID.HeaderText = "RequesterID";
            this.colRequesterID.Name = "colRequesterID";
            this.colRequesterID.Visible = false;
            // 
            // frmPosmRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(924, 459);
            this.Controls.Add(this.dgvPosmRequest);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmPosmRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POSM တောင်းခံခြင်း";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPosmRequest_FormClosed);
            this.Load += new System.EventHandler(this.frmPosmRequest_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosmRequest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.ComboBox cmbDeptVen;
        private System.Windows.Forms.TextBox txtTitleNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpRequestDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvPosmRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoVen;
        private System.Windows.Forms.RadioButton rdoDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGiver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbGiverDept;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAPSubCategory;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPosm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAP_RequestDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAP_RequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestPurposeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestVenID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequesterID;
    }
}