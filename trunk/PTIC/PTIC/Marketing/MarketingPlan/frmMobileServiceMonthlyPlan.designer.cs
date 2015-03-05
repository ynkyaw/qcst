namespace PTIC.VC.Marketing.DailyMarketing
{
    partial class frmMobileServiceMonthlyPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblMarketing = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new AGL.UI.Controls.CalendarColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvMobileServicePlan = new System.Windows.Forms.DataGridView();
            this.colMobileServicePlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSvcNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColPlanDate = new AGL.UI.Controls.CalendarColumn();
            this.dgvColTownship = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColCusType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColCusName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobileServicePlan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(392, 596);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(109, 32);
            this.btnReport.TabIndex = 139;
            this.btnReport.Text = "တင်ပြမည်";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(519, 596);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(109, 32);
            this.btnConfirm.TabIndex = 138;
            this.btnConfirm.Text = "အတည်ပြုမည်";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Visible = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(138, 596);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 32);
            this.btnSave.TabIndex = 137;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(265, 596);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(109, 32);
            this.btnDelete.TabIndex = 136;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(539, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 28);
            this.btnSearch.TabIndex = 135;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(209, 51);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(158, 25);
            this.dtpEndDate.TabIndex = 134;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(179, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 20);
            this.label3.TabIndex = 133;
            this.label3.Text = "မွ";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(11, 50);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(158, 25);
            this.dtpStartDate.TabIndex = 132;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label1.Location = new System.Drawing.Point(377, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.TabIndex = 131;
            this.label1.Text = "ထိ ဈေးကွက်အစီအစဉ်";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1107, 44);
            this.panel2.TabIndex = 142;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(102, 12);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(156, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">   Mobile Service Plan";
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
            this.lblMarketing.Click += new System.EventHandler(this.lblMarketing_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.HeaderText = "စဥ္";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
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
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SvcPlanNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Service Plan No";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ConPersonName";
            this.dataGridViewTextBoxColumn3.HeaderText = "ဆက္သြယ္ရမည့္သူအမည္";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(672, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 28);
            this.button1.TabIndex = 143;
            this.button1.Text = "အကုန်ကြည့်မည်";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(11, 596);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(109, 32);
            this.btnNew.TabIndex = 144;
            this.btnNew.Text = "ထည့်မည်";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvMobileServicePlan
            // 
            this.dgvMobileServicePlan.AllowUserToAddRows = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvMobileServicePlan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMobileServicePlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMobileServicePlan.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMobileServicePlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMobileServicePlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMobileServicePlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMobileServicePlanID,
            this.dgvSvcNo,
            this.dgvColPlanDate,
            this.dgvColTownship,
            this.dgvColCusType,
            this.dgvColCusName,
            this.dgvColContactPerson,
            this.dgvColPhone});
            this.dgvMobileServicePlan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvMobileServicePlan.Location = new System.Drawing.Point(11, 89);
            this.dgvMobileServicePlan.MultiSelect = false;
            this.dgvMobileServicePlan.Name = "dgvMobileServicePlan";
            this.dgvMobileServicePlan.RowHeadersWidth = 50;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvMobileServicePlan.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMobileServicePlan.RowTemplate.Height = 28;
            this.dgvMobileServicePlan.Size = new System.Drawing.Size(1084, 501);
            this.dgvMobileServicePlan.TabIndex = 155;
            this.dgvMobileServicePlan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMobileServicePlan_CellClick);
            this.dgvMobileServicePlan.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMobileServicePlan_CellLeave);
            // 
            // colMobileServicePlanID
            // 
            this.colMobileServicePlanID.DataPropertyName = "MobileServicePlanID";
            this.colMobileServicePlanID.HeaderText = "MobileServicePlanID";
            this.colMobileServicePlanID.Name = "colMobileServicePlanID";
            this.colMobileServicePlanID.Visible = false;
            // 
            // dgvSvcNo
            // 
            this.dgvSvcNo.DataPropertyName = "SvcPlanNo";
            this.dgvSvcNo.HeaderText = "Service Plan No";
            this.dgvSvcNo.Name = "dgvSvcNo";
            this.dgvSvcNo.ReadOnly = true;
            this.dgvSvcNo.Visible = false;
            // 
            // dgvColPlanDate
            // 
            this.dgvColPlanDate.DataPropertyName = "SvcPlanDate";
            dataGridViewCellStyle4.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle4.NullValue = null;
            this.dgvColPlanDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvColPlanDate.HeaderText = "သွားရမည့်နေ့";
            this.dgvColPlanDate.Name = "dgvColPlanDate";
            this.dgvColPlanDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColPlanDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColPlanDate.Width = 120;
            // 
            // dgvColTownship
            // 
            this.dgvColTownship.DataPropertyName = "ID";
            this.dgvColTownship.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvColTownship.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvColTownship.HeaderText = "မြို့နယ်";
            this.dgvColTownship.Name = "dgvColTownship";
            this.dgvColTownship.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColTownship.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColTownship.Width = 200;
            // 
            // dgvColCusType
            // 
            this.dgvColCusType.DataPropertyName = "CusType";
            this.dgvColCusType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvColCusType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvColCusType.HeaderText = "Customer အမျိုးအစား";
            this.dgvColCusType.Name = "dgvColCusType";
            this.dgvColCusType.Width = 200;
            // 
            // dgvColCusName
            // 
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
            // frmMobileServiceMonthlyPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 634);
            this.Controls.Add(this.dgvMobileServicePlan);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmMobileServiceMonthlyPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mobile Service Plan";
            this.Load += new System.EventHandler(this.frmMobileServiceMonthlyPlan_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobileServicePlan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private AGL.UI.Controls.CalendarColumn calendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvMobileServicePlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobileServicePlanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSvcNo;
        private AGL.UI.Controls.CalendarColumn dgvColPlanDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColTownship;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColCusType;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColPhone;

    }
}