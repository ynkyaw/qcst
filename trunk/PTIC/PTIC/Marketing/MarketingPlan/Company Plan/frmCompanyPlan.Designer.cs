namespace PTIC.Marketing.MarketingPlan.Company_Plan
{
    partial class frmCompanyPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new AGL.UI.Controls.CalendarColumn();
            this.btnReport = new System.Windows.Forms.Button();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMarketing = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn2 = new AGL.UI.Controls.CalendarColumn();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvCompanyPlan = new System.Windows.Forms.DataGridView();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.colCompanyPlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCompanyPlanNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColTargetedDate = new AGL.UI.Controls.CalendarColumn();
            this.dgvColTownship = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCustomerType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColCusName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.HeaderText = "စဥ္";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MobilePhone";
            this.dataGridViewTextBoxColumn4.HeaderText = "ဖုန္းနံပါတ္";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ConPersonName";
            this.dataGridViewTextBoxColumn3.HeaderText = "ဆက္သြယ္ရမည့္သူအမည္";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SvcPlanNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Service Plan No";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.DataPropertyName = "SvcPlanDate";
            dataGridViewCellStyle1.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.calendarColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.calendarColumn1.HeaderText = "သြားရမည့္ေန႕";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(553, 588);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(109, 32);
            this.btnReport.TabIndex = 153;
            this.btnReport.Text = "တင်ပြမည်";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(102, 12);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(117, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">  Company Plan";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1038, 44);
            this.panel2.TabIndex = 155;
            // 
            // lblMarketing
            // 
            this.lblMarketing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarketing.AutoSize = true;
            this.lblMarketing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMarketing.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketing.Location = new System.Drawing.Point(10, 12);
            this.lblMarketing.Name = "lblMarketing";
            this.lblMarketing.Size = new System.Drawing.Size(62, 20);
            this.lblMarketing.TabIndex = 0;
            this.lblMarketing.Text = "Planning";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn5.HeaderText = "စဥ္";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(553, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 28);
            this.button1.TabIndex = 156;
            this.button1.Text = "အကုန်ကြည့်မည်";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MobilePhone";
            this.dataGridViewTextBoxColumn6.HeaderText = "ဖုန္းနံပါတ္";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 130;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ConPersonName";
            this.dataGridViewTextBoxColumn7.HeaderText = "ဆက္သြယ္ရမည့္သူအမည္";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "SvcPlanNo";
            this.dataGridViewTextBoxColumn8.HeaderText = "Service Plan No";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // calendarColumn2
            // 
            this.calendarColumn2.DataPropertyName = "SvcPlanDate";
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.calendarColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.calendarColumn2.HeaderText = "သြားရမည့္ေန႕";
            this.calendarColumn2.Name = "calendarColumn2";
            this.calendarColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(11, 588);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(109, 32);
            this.btnNew.TabIndex = 157;
            this.btnNew.Text = "ထည့်မည်";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvCompanyPlan
            // 
            this.dgvCompanyPlan.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvCompanyPlan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCompanyPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCompanyPlan.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompanyPlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCompanyPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompanyPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCompanyPlanID,
            this.dgvCompanyPlanNo,
            this.dgvColTargetedDate,
            this.dgvColTownship,
            this.colCustomerType,
            this.dgvColCusName,
            this.dgvColContactPerson,
            this.dgvColPhone});
            this.dgvCompanyPlan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCompanyPlan.Location = new System.Drawing.Point(10, 84);
            this.dgvCompanyPlan.MultiSelect = false;
            this.dgvCompanyPlan.Name = "dgvCompanyPlan";
            this.dgvCompanyPlan.RowHeadersWidth = 50;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvCompanyPlan.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCompanyPlan.RowTemplate.Height = 28;
            this.dgvCompanyPlan.Size = new System.Drawing.Size(1021, 501);
            this.dgvCompanyPlan.TabIndex = 154;
            this.dgvCompanyPlan.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompanyPlan_CellEndEdit);
            this.dgvCompanyPlan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvCompanyPlan_RowPostPaint);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(680, 588);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(109, 32);
            this.btnConfirm.TabIndex = 152;
            this.btnConfirm.Text = "အတည်ပြုမည်";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(126, 588);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 32);
            this.btnSave.TabIndex = 151;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(356, 588);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(109, 32);
            this.btnDelete.TabIndex = 150;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(433, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 28);
            this.btnSearch.TabIndex = 149;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(177, 50);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(111, 25);
            this.dtpEndDate.TabIndex = 148;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(155, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 20);
            this.label3.TabIndex = 147;
            this.label3.Text = "မွ";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(40, 50);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(109, 25);
            this.dtpStartDate.TabIndex = 146;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label1.Location = new System.Drawing.Point(306, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.TabIndex = 145;
            this.label1.Text = "ထိ ဈေးကွက်အစီအစဉ်";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(241, 588);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(109, 32);
            this.btnEdit.TabIndex = 158;
            this.btnEdit.Text = "ပြင်မည်";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // colCompanyPlanID
            // 
            this.colCompanyPlanID.DataPropertyName = "ID";
            this.colCompanyPlanID.HeaderText = "CompanyPlanID";
            this.colCompanyPlanID.Name = "colCompanyPlanID";
            this.colCompanyPlanID.Visible = false;
            // 
            // dgvCompanyPlanNo
            // 
            this.dgvCompanyPlanNo.DataPropertyName = "CompanyPlanNo";
            this.dgvCompanyPlanNo.HeaderText = "Company Plan No";
            this.dgvCompanyPlanNo.Name = "dgvCompanyPlanNo";
            // 
            // dgvColTargetedDate
            // 
            this.dgvColTargetedDate.DataPropertyName = "TargetedDate";
            dataGridViewCellStyle5.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle5.NullValue = null;
            this.dgvColTargetedDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvColTargetedDate.HeaderText = "သွားရမည့်နေ့";
            this.dgvColTargetedDate.Name = "dgvColTargetedDate";
            this.dgvColTargetedDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColTargetedDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColTargetedDate.Width = 120;
            // 
            // dgvColTownship
            // 
            this.dgvColTownship.DataPropertyName = "TownshipId";
            this.dgvColTownship.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvColTownship.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvColTownship.HeaderText = "မြို့နယ်";
            this.dgvColTownship.Name = "dgvColTownship";
            this.dgvColTownship.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColTownship.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColTownship.Width = 200;
            // 
            // colCustomerType
            // 
            dataGridViewCellStyle6.NullValue = "Company";
            this.colCustomerType.DefaultCellStyle = dataGridViewCellStyle6;
            this.colCustomerType.HeaderText = "Customer အမျိုးအစား";
            this.colCustomerType.Name = "colCustomerType";
            // 
            // dgvColCusName
            // 
            this.dgvColCusName.DataPropertyName = "CustomerId";
            this.dgvColCusName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvColCusName.HeaderText = "Customer အမည်";
            this.dgvColCusName.Name = "dgvColCusName";
            this.dgvColCusName.Width = 200;
            // 
            // dgvColContactPerson
            // 
            this.dgvColContactPerson.DataPropertyName = "ConPersonName";
            this.dgvColContactPerson.HeaderText = "ဆက်သွယ်ရမည့်သူအမည်";
            this.dgvColContactPerson.Name = "dgvColContactPerson";
            this.dgvColContactPerson.ReadOnly = true;
            this.dgvColContactPerson.Width = 200;
            // 
            // dgvColPhone
            // 
            this.dgvColPhone.DataPropertyName = "MobilePhone";
            this.dgvColPhone.HeaderText = "ဖုန်းနံပါတ်";
            this.dgvColPhone.Name = "dgvColPhone";
            this.dgvColPhone.ReadOnly = true;
            this.dgvColPhone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvColPhone.Width = 130;
            // 
            // frmCompanyPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 624);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvCompanyPlan);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCompanyPlan";
            this.Text = "frmCompanyPlan";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyPlan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private AGL.UI.Controls.CalendarColumn calendarColumn1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private AGL.UI.Controls.CalendarColumn calendarColumn2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvCompanyPlan;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyPlanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCompanyPlanNo;
        private AGL.UI.Controls.CalendarColumn dgvColTargetedDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColTownship;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerType;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColPhone;
    }
}