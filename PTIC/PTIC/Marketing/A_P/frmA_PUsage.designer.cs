namespace PTIC.VC.Marketing.A_P
{
    partial class frmA_PUsage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbVehicle = new System.Windows.Forms.ComboBox();
            this.txtCustomerType = new System.Windows.Forms.TextBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPh2 = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContactPersonPhNo = new System.Windows.Forms.TextBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.txtPh1 = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.cmbEmployeeName = new System.Windows.Forms.ComboBox();
            this.dgvAPUsageDetail = new System.Windows.Forms.DataGridView();
            this.colBrand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colA_P_SubCatID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colA_PID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colA_P_Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colA_P_UsageDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colA_P_UsageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAP_CategoryID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAPUsageDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.cmbVehicle);
            this.panel1.Controls.Add(this.txtCustomerType);
            this.panel1.Controls.Add(this.cmbDepartment);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtPh2);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtContactPersonPhNo);
            this.panel1.Controls.Add(this.txtContactPerson);
            this.panel1.Controls.Add(this.txtPh1);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmbCustomerName);
            this.panel1.Controls.Add(this.cmbEmployeeName);
            this.panel1.Controls.Add(this.dgvAPUsageDetail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 557);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 165;
            this.label5.Text = "ဌာနအမည်";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(121, 516);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 164;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbVehicle
            // 
            this.cmbVehicle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVehicle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVehicle.DisplayMember = "VenNo";
            this.cmbVehicle.FormattingEnabled = true;
            this.cmbVehicle.Location = new System.Drawing.Point(597, 52);
            this.cmbVehicle.Name = "cmbVehicle";
            this.cmbVehicle.Size = new System.Drawing.Size(150, 27);
            this.cmbVehicle.TabIndex = 163;
            this.cmbVehicle.ValueMember = "VehicleID";
            // 
            // txtCustomerType
            // 
            this.txtCustomerType.Location = new System.Drawing.Point(223, 146);
            this.txtCustomerType.Name = "txtCustomerType";
            this.txtCustomerType.ReadOnly = true;
            this.txtCustomerType.Size = new System.Drawing.Size(150, 28);
            this.txtCustomerType.TabIndex = 162;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDepartment.DisplayMember = "DeptName";
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(223, 180);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(150, 27);
            this.cmbDepartment.TabIndex = 160;
            this.cmbDepartment.ValueMember = "ID";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(10, 516);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 152;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPh2
            // 
            this.txtPh2.Location = new System.Drawing.Point(597, 117);
            this.txtPh2.Name = "txtPh2";
            this.txtPh2.ReadOnly = true;
            this.txtPh2.Size = new System.Drawing.Size(150, 28);
            this.txtPh2.TabIndex = 148;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(597, 149);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(177, 60);
            this.txtAddress.TabIndex = 147;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 140;
            this.label4.Text = "လိပ်စာ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 139;
            this.label3.Text = "ဖုန်းနံပါတ် (၁)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 138;
            this.label2.Text = "အ‌ရောင်းကားနံပါတ်";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(473, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 137;
            this.label1.Text = "‌နေ့စွဲ";
            // 
            // txtContactPersonPhNo
            // 
            this.txtContactPersonPhNo.Location = new System.Drawing.Point(223, 114);
            this.txtContactPersonPhNo.Name = "txtContactPersonPhNo";
            this.txtContactPersonPhNo.ReadOnly = true;
            this.txtContactPersonPhNo.Size = new System.Drawing.Size(150, 28);
            this.txtContactPersonPhNo.TabIndex = 135;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(223, 82);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.ReadOnly = true;
            this.txtContactPerson.Size = new System.Drawing.Size(150, 28);
            this.txtContactPerson.TabIndex = 134;
            // 
            // txtPh1
            // 
            this.txtPh1.Location = new System.Drawing.Point(597, 85);
            this.txtPh1.Name = "txtPh1";
            this.txtPh1.ReadOnly = true;
            this.txtPh1.Size = new System.Drawing.Size(150, 28);
            this.txtPh1.TabIndex = 132;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(597, 19);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(150, 28);
            this.dtpDate.TabIndex = 131;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(473, 123);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(89, 20);
            this.label22.TabIndex = 129;
            this.label22.Text = "ဖုန်းနံပါတ် (၂)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 20);
            this.label11.TabIndex = 128;
            this.label11.Text = "Customer အမျိုးအစား";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 20);
            this.label7.TabIndex = 127;
            this.label7.Text = "ဆက်သွယ်ရမည့်သူအမည်";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 20);
            this.label8.TabIndex = 126;
            this.label8.Text = "ဆက်သွယ်ရမည့်သူဖုန်း";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 125;
            this.label9.Text = "Customer အမည်";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 20);
            this.label10.TabIndex = 124;
            this.label10.Text = "အ‌ရောင်းဝန်ထမ်းအမည်";
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomerName.DisplayMember = "CusName";
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(223, 49);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(150, 27);
            this.cmbCustomerName.TabIndex = 123;
            this.cmbCustomerName.ValueMember = "CustomerID";
            this.cmbCustomerName.SelectedValueChanged += new System.EventHandler(this.cmbCustomerName_SelectedValueChanged);
            // 
            // cmbEmployeeName
            // 
            this.cmbEmployeeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmployeeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmployeeName.DisplayMember = "EmpName";
            this.cmbEmployeeName.FormattingEnabled = true;
            this.cmbEmployeeName.Location = new System.Drawing.Point(223, 16);
            this.cmbEmployeeName.Name = "cmbEmployeeName";
            this.cmbEmployeeName.Size = new System.Drawing.Size(150, 27);
            this.cmbEmployeeName.TabIndex = 122;
            this.cmbEmployeeName.ValueMember = "EmployeeID";
            // 
            // dgvAPUsageDetail
            // 
            this.dgvAPUsageDetail.AllowUserToAddRows = false;
            this.dgvAPUsageDetail.AllowUserToDeleteRows = false;
            this.dgvAPUsageDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAPUsageDetail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAPUsageDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAPUsageDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAPUsageDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBrand,
            this.colA_P_SubCatID,
            this.colA_PID,
            this.colA_P_Size,
            this.colQty,
            this.colRemark,
            this.colA_P_UsageDetailID,
            this.colA_P_UsageID,
            this.colAP_CategoryID});
            this.dgvAPUsageDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAPUsageDetail.Location = new System.Drawing.Point(11, 230);
            this.dgvAPUsageDetail.Name = "dgvAPUsageDetail";
            this.dgvAPUsageDetail.RowHeadersWidth = 50;
            this.dgvAPUsageDetail.RowTemplate.Height = 28;
            this.dgvAPUsageDetail.Size = new System.Drawing.Size(862, 280);
            this.dgvAPUsageDetail.TabIndex = 60;
            this.dgvAPUsageDetail.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvAPUsageDetail_CellBeginEdit);
            this.dgvAPUsageDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAPUsageDetail_CellEndEdit);
            this.dgvAPUsageDetail.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAPUsageDetail_CellLeave);
            this.dgvAPUsageDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvAPUsageDetail_CellValidating);
            this.dgvAPUsageDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAPUsageDetail_CellValueChanged);
            this.dgvAPUsageDetail.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvAPUsageDetail_CurrentCellDirtyStateChanged);
            this.dgvAPUsageDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAPUsageDetail_DataBindingComplete);
            this.dgvAPUsageDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAPUsageDetail_DataError);
            this.dgvAPUsageDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvAPUsageDetail_EditingControlShowing);
            // 
            // colBrand
            // 
            this.colBrand.DataPropertyName = "BrandID";
            this.colBrand.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colBrand.HeaderText = "အမှတ်တံဆိပ်";
            this.colBrand.Name = "colBrand";
            // 
            // colA_P_SubCatID
            // 
            this.colA_P_SubCatID.DataPropertyName = "APSubCategoryID";
            this.colA_P_SubCatID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colA_P_SubCatID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colA_P_SubCatID.HeaderText = "A & P အမျိုးအစားခွဲ";
            this.colA_P_SubCatID.Name = "colA_P_SubCatID";
            this.colA_P_SubCatID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colA_P_SubCatID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colA_PID
            // 
            this.colA_PID.DataPropertyName = "A_P_MaterialID";
            this.colA_PID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colA_PID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colA_PID.HeaderText = "A&P အမည်";
            this.colA_PID.Name = "colA_PID";
            this.colA_PID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colA_PID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colA_PID.Width = 130;
            // 
            // colA_P_Size
            // 
            this.colA_P_Size.DataPropertyName = "Size";
            this.colA_P_Size.HeaderText = "A&P အရွယ်အစား";
            this.colA_P_Size.Name = "colA_P_Size";
            this.colA_P_Size.ReadOnly = true;
            this.colA_P_Size.Width = 110;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQty.HeaderText = "အ‌ရေအတွက်";
            this.colQty.MaxInputLength = 4;
            this.colQty.Name = "colQty";
            this.colQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQty.Width = 90;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "မှတ်ချက်";
            this.colRemark.Name = "colRemark";
            this.colRemark.Width = 180;
            // 
            // colA_P_UsageDetailID
            // 
            this.colA_P_UsageDetailID.DataPropertyName = "A_P_UsageDetailID";
            this.colA_P_UsageDetailID.HeaderText = "A_P_UsageDetailID";
            this.colA_P_UsageDetailID.Name = "colA_P_UsageDetailID";
            this.colA_P_UsageDetailID.Visible = false;
            // 
            // colA_P_UsageID
            // 
            this.colA_P_UsageID.DataPropertyName = "A_P_UsageID";
            this.colA_P_UsageID.HeaderText = "A_P_UsageID";
            this.colA_P_UsageID.Name = "colA_P_UsageID";
            this.colA_P_UsageID.Visible = false;
            // 
            // colAP_CategoryID
            // 
            this.colAP_CategoryID.DataPropertyName = "APCategoryID";
            this.colAP_CategoryID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colAP_CategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colAP_CategoryID.HeaderText = "A & P အမျိုးအစား";
            this.colAP_CategoryID.Name = "colAP_CategoryID";
            this.colAP_CategoryID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAP_CategoryID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAP_CategoryID.Visible = false;
            // 
            // frmA_PUsage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 557);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmA_PUsage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "A & P Usage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAPUsageDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvAPUsageDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContactPersonPhNo;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.TextBox txtPh1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbCustomerName;
        private System.Windows.Forms.ComboBox cmbEmployeeName;
        private System.Windows.Forms.TextBox txtPh2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.TextBox txtCustomerType;
        private System.Windows.Forms.ComboBox cmbVehicle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewComboBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewComboBoxColumn colA_P_SubCatID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colA_PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colA_P_Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colA_P_UsageDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colA_P_UsageID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAP_CategoryID;
    }
}