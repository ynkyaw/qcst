namespace PTIC.Marketing.TripPlan_Request
{
    partial class frmProductRequestIssue
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGiver = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbGiverDept = new System.Windows.Forms.ComboBox();
            this.txtTrip = new System.Windows.Forms.TextBox();
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
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.dgvProductReqIssue = new System.Windows.Forms.DataGridView();
            this.colBrand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurpose = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductReqIssue)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SkyBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblHeaderPCat);
            this.panel3.Controls.Add(this.lblHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1053, 44);
            this.panel3.TabIndex = 70;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(85, 11);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(355, 19);
            this.lblHeaderPCat.TabIndex = 48;
            this.lblHeaderPCat.Text = ">  ခရီးစဉ်အတွက် Battery တောင်းခံခြင်းနှင့်ထုတ်ပေးခြင်း";
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.AutoSize = true;
            this.lblHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHeader.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(17, 11);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(72, 17);
            this.lblHeader.TabIndex = 47;
            this.lblHeader.Text = "Planning";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.groupBox2);
            this.pnlFilter.Controls.Add(this.txtTrip);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.dtpRequestDate);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.groupBox1);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 44);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1053, 143);
            this.pnlFilter.TabIndex = 180;
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
            this.groupBox2.Size = new System.Drawing.Size(313, 131);
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
            this.label5.Size = new System.Drawing.Size(67, 19);
            this.label5.TabIndex = 208;
            this.label5.Text = "ထုတ်ပေးသူ";
            // 
            // cmbGiver
            // 
            this.cmbGiver.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGiver.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGiver.DisplayMember = "APSubCategoryName";
            this.cmbGiver.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.cmbGiver.FormattingEnabled = true;
            this.cmbGiver.Location = new System.Drawing.Point(143, 72);
            this.cmbGiver.Name = "cmbGiver";
            this.cmbGiver.Size = new System.Drawing.Size(150, 24);
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
            this.label3.Size = new System.Drawing.Size(106, 19);
            this.label3.TabIndex = 206;
            this.label3.Text = "ထုတ်ပေးသည့် ဌာန";
            // 
            // cmbGiverDept
            // 
            this.cmbGiverDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGiverDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGiverDept.DisplayMember = "APSubCategoryName";
            this.cmbGiverDept.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.cmbGiverDept.FormattingEnabled = true;
            this.cmbGiverDept.Location = new System.Drawing.Point(143, 38);
            this.cmbGiverDept.Name = "cmbGiverDept";
            this.cmbGiverDept.Size = new System.Drawing.Size(150, 24);
            this.cmbGiverDept.TabIndex = 205;
            this.cmbGiverDept.SelectedIndexChanged += new System.EventHandler(this.cmbGiverDept_SelectedIndexChanged);
            // 
            // txtTrip
            // 
            this.txtTrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTrip.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtTrip.Location = new System.Drawing.Point(84, 42);
            this.txtTrip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTrip.Name = "txtTrip";
            this.txtTrip.Size = new System.Drawing.Size(150, 25);
            this.txtTrip.TabIndex = 199;
            this.txtTrip.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label1.Location = new System.Drawing.Point(16, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 198;
            this.label1.Text = "ခရီးစဉ်";
            this.label1.Visible = false;
            // 
            // dtpRequestDate
            // 
            this.dtpRequestDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpRequestDate.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRequestDate.Location = new System.Drawing.Point(84, 8);
            this.dtpRequestDate.Name = "dtpRequestDate";
            this.dtpRequestDate.Size = new System.Drawing.Size(150, 27);
            this.dtpRequestDate.TabIndex = 197;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 19);
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
            this.groupBox1.Size = new System.Drawing.Size(313, 131);
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
            this.label4.Size = new System.Drawing.Size(68, 19);
            this.label4.TabIndex = 202;
            this.label4.Text = "တောင်းခံသူ";
            // 
            // rdoVen
            // 
            this.rdoVen.AutoSize = true;
            this.rdoVen.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.rdoVen.Location = new System.Drawing.Point(18, 57);
            this.rdoVen.Name = "rdoVen";
            this.rdoVen.Size = new System.Drawing.Size(87, 23);
            this.rdoVen.TabIndex = 197;
            this.rdoVen.Text = "ယာဉ်အမှတ်";
            this.rdoVen.UseVisualStyleBackColor = true;
            this.rdoVen.CheckedChanged += new System.EventHandler(this.rdoVen_CheckedChanged);
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmployee.DisplayMember = "APSubCategoryName";
            this.cmbEmployee.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(128, 93);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(150, 24);
            this.cmbEmployee.TabIndex = 200;
            this.cmbEmployee.ValueMember = "ID";
            // 
            // rdoDept
            // 
            this.rdoDept.AutoSize = true;
            this.rdoDept.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.rdoDept.Location = new System.Drawing.Point(18, 27);
            this.rdoDept.Name = "rdoDept";
            this.rdoDept.Size = new System.Drawing.Size(49, 23);
            this.rdoDept.TabIndex = 196;
            this.rdoDept.Text = "ဌာန";
            this.rdoDept.UseVisualStyleBackColor = true;
            this.rdoDept.CheckedChanged += new System.EventHandler(this.rdoDept_CheckedChanged);
            // 
            // cmbDeptVen
            // 
            this.cmbDeptVen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDeptVen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDeptVen.DisplayMember = "APSubCategoryName";
            this.cmbDeptVen.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.cmbDeptVen.FormattingEnabled = true;
            this.cmbDeptVen.Location = new System.Drawing.Point(128, 40);
            this.cmbDeptVen.Name = "cmbDeptVen";
            this.cmbDeptVen.Size = new System.Drawing.Size(150, 24);
            this.cmbDeptVen.TabIndex = 195;
            this.cmbDeptVen.ValueMember = "ID";
            this.cmbDeptVen.SelectedIndexChanged += new System.EventHandler(this.cmbDeptVen_SelectedIndexChanged);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnRequest);
            this.pnlFooter.Controls.Add(this.btnNew);
            this.pnlFooter.Controls.Add(this.btnDelete);
            this.pnlFooter.Controls.Add(this.btnIssue);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 450);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1053, 50);
            this.pnlFooter.TabIndex = 181;
            // 
            // btnRequest
            // 
            this.btnRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRequest.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnRequest.Location = new System.Drawing.Point(117, 8);
            this.btnRequest.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(95, 34);
            this.btnRequest.TabIndex = 173;
            this.btnRequest.Text = "တောင်းခံမည်";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
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
            this.btnDelete.Location = new System.Drawing.Point(323, 8);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 171;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnIssue
            // 
            this.btnIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIssue.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnIssue.Location = new System.Drawing.Point(220, 8);
            this.btnIssue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(95, 34);
            this.btnIssue.TabIndex = 170;
            this.btnIssue.Text = "ထုတ်ပေးမည်";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // dgvProductReqIssue
            // 
            this.dgvProductReqIssue.AllowUserToAddRows = false;
            this.dgvProductReqIssue.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvProductReqIssue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(131)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductReqIssue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductReqIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductReqIssue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBrand,
            this.colProduct,
            this.colWeight,
            this.colRequestQty,
            this.colIssueQty,
            this.colPurpose,
            this.colRemark});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductReqIssue.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProductReqIssue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductReqIssue.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvProductReqIssue.EnableHeadersVisualStyles = false;
            this.dgvProductReqIssue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(255)))));
            this.dgvProductReqIssue.Location = new System.Drawing.Point(0, 187);
            this.dgvProductReqIssue.Name = "dgvProductReqIssue";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(131)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductReqIssue.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProductReqIssue.RowHeadersWidth = 50;
            this.dgvProductReqIssue.RowTemplate.Height = 28;
            this.dgvProductReqIssue.Size = new System.Drawing.Size(1053, 263);
            this.dgvProductReqIssue.TabIndex = 188;
            this.dgvProductReqIssue.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvProductReqIssue_CellBeginEdit);
            this.dgvProductReqIssue.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductReqIssue_CellEndEdit);
            this.dgvProductReqIssue.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvProductReqIssue_EditingControlShowing);
            // 
            // colBrand
            // 
            this.colBrand.DataPropertyName = "BrandID";
            this.colBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colBrand.HeaderText = "အမှတ်တံဆိပ်";
            this.colBrand.Name = "colBrand";
            this.colBrand.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colBrand.Width = 160;
            // 
            // colProduct
            // 
            this.colProduct.DataPropertyName = "ProductID";
            this.colProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colProduct.HeaderText = "ထုတ်ကုန်";
            this.colProduct.Name = "colProduct";
            this.colProduct.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colProduct.Width = 200;
            // 
            // colWeight
            // 
            this.colWeight.DataPropertyName = "Weight";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colWeight.DefaultCellStyle = dataGridViewCellStyle2;
            this.colWeight.HeaderText = "Weight";
            this.colWeight.MaxInputLength = 4;
            this.colWeight.Name = "colWeight";
            // 
            // colRequestQty
            // 
            this.colRequestQty.DataPropertyName = "RequestQty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = "0";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colRequestQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colRequestQty.HeaderText = "Request Qty";
            this.colRequestQty.MaxInputLength = 5;
            this.colRequestQty.Name = "colRequestQty";
            this.colRequestQty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colRequestQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRequestQty.Width = 90;
            // 
            // colIssueQty
            // 
            this.colIssueQty.DataPropertyName = "IssueQty";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.NullValue = "0";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colIssueQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.colIssueQty.HeaderText = "Issue Qty";
            this.colIssueQty.MaxInputLength = 5;
            this.colIssueQty.Name = "colIssueQty";
            this.colIssueQty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colIssueQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colIssueQty.Width = 90;
            // 
            // colPurpose
            // 
            this.colPurpose.DataPropertyName = "Purpose";
            this.colPurpose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colPurpose.HeaderText = "Purpose";
            this.colPurpose.Name = "colPurpose";
            this.colPurpose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPurpose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPurpose.Width = 150;
            // 
            // colRemark
            // 
            this.colRemark.HeaderText = "မှတ်ချက်";
            this.colRemark.Name = "colRemark";
            this.colRemark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRemark.Width = 200;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "အမှတ်တံဆိပ်";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 160;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ထုတ်ကုန်";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.NullValue = "0";
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "Request Qty";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "IssueQty";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.NullValue = "0";
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn4.HeaderText = "Issue Qty";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "မှတ်ချက်";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // frmProductRequestIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 500);
            this.Controls.Add(this.dgvProductReqIssue);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProductRequestIssue";
            this.Text = "ခရီးစဉ်အတွက် Battery တောင်းခံခြင်းနှင့်ထုတ်ပေးခြင်း";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProductRequestIssue_FormClosed);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductReqIssue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGiver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbGiverDept;
        private System.Windows.Forms.TextBox txtTrip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpRequestDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdoVen;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.RadioButton rdoDept;
        private System.Windows.Forms.ComboBox cmbDeptVen;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.DataGridView dgvProductReqIssue;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewComboBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueQty;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPurpose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
    }
}