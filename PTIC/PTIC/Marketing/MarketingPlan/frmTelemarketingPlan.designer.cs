namespace PTIC.VC.Marketing.DailyMarketing
{
    partial class frmTelemarketingPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dgvTeleMarketingPlan = new System.Windows.Forms.DataGridView();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColPlanDate = new AGL.UI.Controls.CalendarColumn();
            this.dgvColTownship = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColCusType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColCusName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeleMarketingPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(342, 559);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(95, 34);
            this.btnReport.TabIndex = 139;
            this.btnReport.Text = "တင္ျပမည္";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(453, 559);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(95, 34);
            this.btnConfirm.TabIndex = 138;
            this.btnConfirm.Text = "အတည္ျပဳမည္";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(120, 559);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 137;
            this.btnSave.Text = "သိမ္းမည္";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(231, 559);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 136;
            this.btnDelete.Text = "ဖ်က္မည္";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(411, 48);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 135;
            this.btnSearch.Text = "ရွာမည္";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(157, 48);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 27);
            this.dtpEndDate.TabIndex = 134;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(135, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 20);
            this.label3.TabIndex = 133;
            this.label3.Text = "မွ";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(9, 47);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 27);
            this.dtpStartDate.TabIndex = 132;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(283, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 131;
            this.label1.Text = "ထိ ေစ်းကြက္အစီအစဥ္";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(933, 41);
            this.panel2.TabIndex = 141;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(76, 9);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(155, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">   TeleMarketing Plan";
            // 
            // lblMarketing
            // 
            this.lblMarketing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarketing.AutoSize = true;
            this.lblMarketing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMarketing.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketing.Location = new System.Drawing.Point(8, 9);
            this.lblMarketing.Name = "lblMarketing";
            this.lblMarketing.Size = new System.Drawing.Size(62, 20);
            this.lblMarketing.TabIndex = 0;
            this.lblMarketing.Text = "Planning";
            this.lblMarketing.Click += new System.EventHandler(this.lblMarketing_Click);
            // 
            // dgvTeleMarketingPlan
            // 
            this.dgvTeleMarketingPlan.AllowUserToAddRows = false;
            this.dgvTeleMarketingPlan.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeleMarketingPlan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTeleMarketingPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTeleMarketingPlan.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeleMarketingPlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTeleMarketingPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeleMarketingPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.dgvColPlanDate,
            this.dgvColTownship,
            this.dgvColCusType,
            this.dgvColCusName,
            this.dgvColPhone});
            this.dgvTeleMarketingPlan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTeleMarketingPlan.Location = new System.Drawing.Point(9, 81);
            this.dgvTeleMarketingPlan.MultiSelect = false;
            this.dgvTeleMarketingPlan.Name = "dgvTeleMarketingPlan";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.dgvTeleMarketingPlan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTeleMarketingPlan.RowTemplate.Height = 30;
            this.dgvTeleMarketingPlan.Size = new System.Drawing.Size(912, 472);
            this.dgvTeleMarketingPlan.TabIndex = 142;
            this.dgvTeleMarketingPlan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeleMarketingPlan_CellClick);
            this.dgvTeleMarketingPlan.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeleMarketingPlan_CellLeave);
            this.dgvTeleMarketingPlan.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeleMarketingPlan_CellValueChanged);
            this.dgvTeleMarketingPlan.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvTeleMarketingPlan_EditingControlShowing);
            this.dgvTeleMarketingPlan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMarketingPlan_RowPostPaint);
            this.dgvTeleMarketingPlan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTeleMarketingPlan_KeyDown);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(527, 48);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(100, 30);
            this.btnAll.TabIndex = 143;
            this.btnAll.Text = "အကုန္ၾကည့္မည္";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(9, 559);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 34);
            this.btnNew.TabIndex = 145;
            this.btnNew.Text = "ထည့္မည္";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.No.HeaderText = "စဥ္";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 48;
            // 
            // dgvColPlanDate
            // 
            this.dgvColPlanDate.DataPropertyName = "PlanDate";
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.dgvColPlanDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvColPlanDate.HeaderText = "ဆက္သြယ္ရမည့္ေန႕";
            this.dgvColPlanDate.Name = "dgvColPlanDate";
            this.dgvColPlanDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColPlanDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColPlanDate.Width = 123;
            // 
            // dgvColTownship
            // 
            this.dgvColTownship.DataPropertyName = "TownshipID";
            this.dgvColTownship.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvColTownship.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvColTownship.HeaderText = "ျမိဳ႕နယ္";
            this.dgvColTownship.Name = "dgvColTownship";
            this.dgvColTownship.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColTownship.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColTownship.Width = 150;
            // 
            // dgvColCusType
            // 
            this.dgvColCusType.DataPropertyName = "CusTypeID";
            this.dgvColCusType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvColCusType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvColCusType.HeaderText = "Customer အမ်ိဳးအစား";
            this.dgvColCusType.Name = "dgvColCusType";
            this.dgvColCusType.Width = 150;
            // 
            // dgvColCusName
            // 
            this.dgvColCusName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvColCusName.HeaderText = "Customer အမည္";
            this.dgvColCusName.Name = "dgvColCusName";
            this.dgvColCusName.Width = 150;
            // 
            // dgvColPhone
            // 
            this.dgvColPhone.DataPropertyName = "Phone1";
            this.dgvColPhone.HeaderText = "ဆက္သြယ္ရမည့္ဖုန္း";
            this.dgvColPhone.Name = "dgvColPhone";
            this.dgvColPhone.ReadOnly = true;
            this.dgvColPhone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvColPhone.Width = 150;
            // 
            // frmTelemarketingPlan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(933, 600);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.dgvTeleMarketingPlan);
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
            this.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "frmTelemarketingPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Telemarketing Plan";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeleMarketingPlan)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvTeleMarketingPlan;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private AGL.UI.Controls.CalendarColumn dgvColPlanDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColTownship;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColCusType;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColPhone;

    }
}