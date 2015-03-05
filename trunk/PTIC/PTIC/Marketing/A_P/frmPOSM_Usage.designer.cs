namespace PTIC.Marketing.A_P
{
    partial class frmPOSM_Usage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBakToAP = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.dgvAPUsageDetail = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.colBrand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colA_P_SubCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colA_P_Material = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsagePurpose = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPOSM_UsageDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAPUsageDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblBakToAP);
            this.panel1.Controls.Add(this.lblOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 41);
            this.panel1.TabIndex = 4;
            // 
            // lblBakToAP
            // 
            this.lblBakToAP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBakToAP.AutoSize = true;
            this.lblBakToAP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBakToAP.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBakToAP.Location = new System.Drawing.Point(10, 11);
            this.lblBakToAP.Name = "lblBakToAP";
            this.lblBakToAP.Size = new System.Drawing.Size(46, 17);
            this.lblBakToAP.TabIndex = 4;
            this.lblBakToAP.Text = "A && P";
            this.lblBakToAP.Click += new System.EventHandler(this.lblBakToAP_Click);
            // 
            // lblOrder
            // 
            this.lblOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrder.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblOrder.Location = new System.Drawing.Point(61, 10);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(144, 17);
            this.lblOrder.TabIndex = 3;
            this.lblOrder.Text = ">    A && P အသုံးပြုခြင်း";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 19);
            this.label1.TabIndex = 139;
            this.label1.Text = "‌နေ့စွဲ";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(53, 46);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(150, 28);
            this.dtpDate.TabIndex = 138;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(486, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 19);
            this.label10.TabIndex = 141;
            this.label10.Text = "တာဝန်ခံ";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmployee.DisplayMember = "EmpName";
            this.cmbEmployee.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(545, 47);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(150, 27);
            this.cmbEmployee.TabIndex = 140;
            this.cmbEmployee.ValueMember = "EmployeeID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(233, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 167;
            this.label5.Text = "ဌာနအမည်";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDepartment.DisplayMember = "DeptName";
            this.cmbDepartment.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(303, 47);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(150, 27);
            this.cmbDepartment.TabIndex = 166;
            this.cmbDepartment.ValueMember = "ID";
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
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
            this.colA_P_SubCategory,
            this.colA_P_Material,
            this.colQty,
            this.colUsagePurpose,
            this.colRemark,
            this.colPOSM_UsageDetailID});
            this.dgvAPUsageDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAPUsageDetail.Location = new System.Drawing.Point(13, 80);
            this.dgvAPUsageDetail.MultiSelect = false;
            this.dgvAPUsageDetail.Name = "dgvAPUsageDetail";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAPUsageDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAPUsageDetail.RowHeadersWidth = 50;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvAPUsageDetail.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAPUsageDetail.RowTemplate.Height = 28;
            this.dgvAPUsageDetail.Size = new System.Drawing.Size(861, 303);
            this.dgvAPUsageDetail.TabIndex = 168;
            this.dgvAPUsageDetail.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvAPUsageDetail_CellBeginEdit);
            this.dgvAPUsageDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAPUsageDetail_CellEndEdit);
            this.dgvAPUsageDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvAPUsageDetail_CellValidating);
            this.dgvAPUsageDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAPUsageDetail_CellValueChanged);
            this.dgvAPUsageDetail.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvAPUsageDetail_CurrentCellDirtyStateChanged);
            this.dgvAPUsageDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAPUsageDetail_DataError);
            this.dgvAPUsageDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvAPUsageDetail_EditingControlShowing);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnDelete.Location = new System.Drawing.Point(120, 393);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 170;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSave.Location = new System.Drawing.Point(9, 393);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 169;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // colBrand
            // 
            this.colBrand.DataPropertyName = "BrandID";
            this.colBrand.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colBrand.HeaderText = "အမှတ်တံဆိပ်";
            this.colBrand.Name = "colBrand";
            this.colBrand.Width = 120;
            // 
            // colA_P_SubCategory
            // 
            this.colA_P_SubCategory.DataPropertyName = "APSubCategoryID";
            this.colA_P_SubCategory.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colA_P_SubCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colA_P_SubCategory.HeaderText = "A & P အမျိုးအစားခွဲ";
            this.colA_P_SubCategory.Name = "colA_P_SubCategory";
            this.colA_P_SubCategory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colA_P_SubCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colA_P_SubCategory.Width = 130;
            // 
            // colA_P_Material
            // 
            this.colA_P_Material.DataPropertyName = "A_P_MaterialID";
            this.colA_P_Material.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colA_P_Material.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colA_P_Material.HeaderText = "POSM";
            this.colA_P_Material.Name = "colA_P_Material";
            this.colA_P_Material.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colA_P_Material.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colA_P_Material.Width = 140;
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
            this.colQty.Width = 90;
            // 
            // colUsagePurpose
            // 
            this.colUsagePurpose.DataPropertyName = "UsagePurpose";
            this.colUsagePurpose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colUsagePurpose.HeaderText = "အကြောင်းအရာ";
            this.colUsagePurpose.Name = "colUsagePurpose";
            this.colUsagePurpose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUsagePurpose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colUsagePurpose.Width = 130;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "မှတ်ချက်";
            this.colRemark.Name = "colRemark";
            this.colRemark.Width = 180;
            // 
            // colPOSM_UsageDetailID
            // 
            this.colPOSM_UsageDetailID.DataPropertyName = "POSM_UsageDetailID";
            this.colPOSM_UsageDetailID.HeaderText = "POSM_UsageDetailID";
            this.colPOSM_UsageDetailID.Name = "colPOSM_UsageDetailID";
            this.colPOSM_UsageDetailID.Visible = false;
            // 
            // frmPOSM_Usage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 439);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvAPUsageDetail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.panel1);
            this.Name = "frmPOSM_Usage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "A & P အသုံးပြုခြင်း";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAPUsageDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBakToAP;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.DataGridView dgvAPUsageDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewComboBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewComboBoxColumn colA_P_SubCategory;
        private System.Windows.Forms.DataGridViewComboBoxColumn colA_P_Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewComboBoxColumn colUsagePurpose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPOSM_UsageDetailID;
    }
}