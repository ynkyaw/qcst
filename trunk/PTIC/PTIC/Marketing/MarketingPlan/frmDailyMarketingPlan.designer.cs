namespace PTIC.VC.Marketing.DailyMarketing
{
    partial class frmDailyMarketingPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new AGL.UI.Controls.CalendarColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblMarketing = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAll = new System.Windows.Forms.Button();
            this.dgvMarketingPlan = new System.Windows.Forms.DataGridView();
            this.dgvColPlanDate = new AGL.UI.Controls.CalendarColumn();
            this.dgvColTownship = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColCusType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColCusName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColEmployee = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarketingPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.HeaderText = "စဥ္";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 35;
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.HeaderText = "သြားမည့္ရက္";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Status";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 80;
            this.label1.Text = "ထိ ေစ်းကြက္အစီအစဥ္";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(12, 47);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 27);
            this.dtpStartDate.TabIndex = 81;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(138, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 20);
            this.label3.TabIndex = 82;
            this.label3.Text = "မွ";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(160, 48);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 27);
            this.dtpEndDate.TabIndex = 83;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(408, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 120;
            this.btnSearch.Text = "ရွာမည္";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(234, 561);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 124;
            this.btnDelete.Text = "ဖ်က္မည္";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(123, 561);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 125;
            this.btnSave.Text = "သိမ္းမည္";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(345, 561);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(95, 34);
            this.btnConfirm.TabIndex = 127;
            this.btnConfirm.Text = "အတည္ျပဳမည္";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Visible = false;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(456, 561);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(95, 34);
            this.btnReport.TabIndex = 128;
            this.btnReport.Text = "တင္ျပမည္";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
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
            this.panel2.TabIndex = 129;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(76, 9);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(161, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">   Daily Marketing Plan";
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnAll);
            this.panel1.Controls.Add(this.dgvMarketingPlan);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 600);
            this.panel1.TabIndex = 0;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(524, 47);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(100, 30);
            this.btnAll.TabIndex = 131;
            this.btnAll.Text = "အကုန္ၾကည့္မည္";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // dgvMarketingPlan
            // 
            this.dgvMarketingPlan.AllowUserToAddRows = false;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMarketingPlan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvMarketingPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMarketingPlan.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMarketingPlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvMarketingPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarketingPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColPlanDate,
            this.dgvColTownship,
            this.dgvColCusType,
            this.dgvColCusName,
            this.dgvColEmployee});
            this.dgvMarketingPlan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvMarketingPlan.Location = new System.Drawing.Point(12, 83);
            this.dgvMarketingPlan.MultiSelect = false;
            this.dgvMarketingPlan.Name = "dgvMarketingPlan";
            this.dgvMarketingPlan.RowHeadersWidth = 50;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.dgvMarketingPlan.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvMarketingPlan.RowTemplate.Height = 30;
            this.dgvMarketingPlan.Size = new System.Drawing.Size(909, 472);
            this.dgvMarketingPlan.TabIndex = 130;
            this.dgvMarketingPlan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarketingPlan_CellClick);
            this.dgvMarketingPlan.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarketingPlan_CellEnter);
            this.dgvMarketingPlan.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarketingPlan_CellLeave);
            this.dgvMarketingPlan.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarketingPlan_CellValueChanged);
            this.dgvMarketingPlan.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMarketingPlan_DataBindingComplete);
            this.dgvMarketingPlan.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvMarketingPlan_DataError);
            this.dgvMarketingPlan.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvMarketingPlan_EditingControlShowing);
            this.dgvMarketingPlan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMarketingPlan_RowPostPaint);
            this.dgvMarketingPlan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvMarketingPlan_KeyDown);
            // 
            // dgvColPlanDate
            // 
            this.dgvColPlanDate.DataPropertyName = "PlanDate";
            dataGridViewCellStyle15.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle15.NullValue = null;
            this.dgvColPlanDate.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvColPlanDate.HeaderText = "သြားရမည့္ရက္";
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
            this.dgvColCusType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColCusType.Width = 150;
            // 
            // dgvColCusName
            // 
            this.dgvColCusName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvColCusName.HeaderText = "Customer အမည္";
            this.dgvColCusName.Name = "dgvColCusName";
            this.dgvColCusName.Width = 150;
            // 
            // dgvColEmployee
            // 
            this.dgvColEmployee.DataPropertyName = "EmpID";
            this.dgvColEmployee.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvColEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvColEmployee.HeaderText = "သြားရမည့္၀န္ထမ္း";
            this.dgvColEmployee.Name = "dgvColEmployee";
            this.dgvColEmployee.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColEmployee.Width = 150;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(12, 561);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 34);
            this.btnNew.TabIndex = 132;
            this.btnNew.Text = "ထည့္မည္";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmDailyMarketingPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 600);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "frmDailyMarketingPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Marketing Plan";
            this.Load += new System.EventHandler(this.frmDailyMarketingPlan_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarketingPlan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private AGL.UI.Controls.CalendarColumn calendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMarketingPlan;
        private System.Windows.Forms.Button btnAll;
        private AGL.UI.Controls.CalendarColumn dgvColPlanDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColTownship;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColCusType;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColCusName;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColEmployee;
        private System.Windows.Forms.Button btnNew;
    }
}