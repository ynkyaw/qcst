namespace PTIC.VC.Marketing.DailyMarketing
{
    partial class frmDailyMarketingLog
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
            this.dgvMarketingLog = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpMarketedEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpMarketedStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchByMarketedDate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpPlannedEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpPlannedStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearchByPlannedDate = new System.Windows.Forms.Button();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPotential = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarketedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarketingDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colMarketingDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsMarketed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarketingPlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownshipID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarketingLog)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMarketingLog
            // 
            this.dgvMarketingLog.AllowUserToAddRows = false;
            this.dgvMarketingLog.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMarketingLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMarketingLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarketingLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colIsPotential,
            this.colPlanDate,
            this.colMarketedDate,
            this.colTown,
            this.colTownship,
            this.colCusType,
            this.colCustomerType,
            this.colCusName,
            this.colContactPerson,
            this.colEmpName,
            this.colMarketingDetail,
            this.colMarketingDetailID,
            this.colIsMarketed,
            this.colRemark,
            this.colMarketingPlanID,
            this.colTownshipID,
            this.colTownID,
            this.colEmpID,
            this.colCusID});
            this.dgvMarketingLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarketingLog.EnableHeadersVisualStyles = false;
            this.dgvMarketingLog.Location = new System.Drawing.Point(0, 0);
            this.dgvMarketingLog.Name = "dgvMarketingLog";
            this.dgvMarketingLog.ReadOnly = true;
            this.dgvMarketingLog.RowTemplate.Height = 28;
            this.dgvMarketingLog.Size = new System.Drawing.Size(1020, 286);
            this.dgvMarketingLog.TabIndex = 0;
            this.dgvMarketingLog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarketingLog_CellClick);
            this.dgvMarketingLog.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMarketingLog_DataBindingComplete);
            this.dgvMarketingLog.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMarketingLog_RowPostPaint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.pnlFilter);
            this.panel1.Controls.Add(this.pnlFilt);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 442);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvMarketingLog);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 156);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1020, 286);
            this.panel4.TabIndex = 201;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.groupBox2);
            this.pnlFilter.Controls.Add(this.groupBox1);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 69);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1020, 87);
            this.pnlFilter.TabIndex = 200;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpMarketedEndDate);
            this.groupBox2.Controls.Add(this.dtpMarketedStartDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSearchByMarketedDate);
            this.groupBox2.Location = new System.Drawing.Point(464, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(445, 75);
            this.groupBox2.TabIndex = 88;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "By Marketed Date";
            // 
            // dtpMarketedEndDate
            // 
            this.dtpMarketedEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpMarketedEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMarketedEndDate.Location = new System.Drawing.Point(158, 27);
            this.dtpMarketedEndDate.Name = "dtpMarketedEndDate";
            this.dtpMarketedEndDate.Size = new System.Drawing.Size(120, 28);
            this.dtpMarketedEndDate.TabIndex = 86;
            // 
            // dtpMarketedStartDate
            // 
            this.dtpMarketedStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpMarketedStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMarketedStartDate.Location = new System.Drawing.Point(10, 26);
            this.dtpMarketedStartDate.Name = "dtpMarketedStartDate";
            this.dtpMarketedStartDate.Size = new System.Drawing.Size(120, 28);
            this.dtpMarketedStartDate.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 20);
            this.label1.TabIndex = 85;
            this.label1.Text = "မွ";
            // 
            // btnSearchByMarketedDate
            // 
            this.btnSearchByMarketedDate.Location = new System.Drawing.Point(306, 26);
            this.btnSearchByMarketedDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearchByMarketedDate.Name = "btnSearchByMarketedDate";
            this.btnSearchByMarketedDate.Size = new System.Drawing.Size(111, 30);
            this.btnSearchByMarketedDate.TabIndex = 2;
            this.btnSearchByMarketedDate.Text = "ရှာမည်";
            this.btnSearchByMarketedDate.UseVisualStyleBackColor = true;
            this.btnSearchByMarketedDate.Click += new System.EventHandler(this.btnSearchByMarketedDate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpPlannedEndDate);
            this.groupBox1.Controls.Add(this.dtpPlannedStartDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSearchByPlannedDate);
            this.groupBox1.Location = new System.Drawing.Point(13, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 75);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "By Planned Date";
            // 
            // dtpPlannedEndDate
            // 
            this.dtpPlannedEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpPlannedEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPlannedEndDate.Location = new System.Drawing.Point(158, 27);
            this.dtpPlannedEndDate.Name = "dtpPlannedEndDate";
            this.dtpPlannedEndDate.Size = new System.Drawing.Size(120, 28);
            this.dtpPlannedEndDate.TabIndex = 86;
            // 
            // dtpPlannedStartDate
            // 
            this.dtpPlannedStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpPlannedStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPlannedStartDate.Location = new System.Drawing.Point(10, 26);
            this.dtpPlannedStartDate.Name = "dtpPlannedStartDate";
            this.dtpPlannedStartDate.Size = new System.Drawing.Size(120, 28);
            this.dtpPlannedStartDate.TabIndex = 84;
            this.dtpPlannedStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(136, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 20);
            this.label3.TabIndex = 85;
            this.label3.Text = "မွ";
            // 
            // btnSearchByPlannedDate
            // 
            this.btnSearchByPlannedDate.Location = new System.Drawing.Point(306, 26);
            this.btnSearchByPlannedDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearchByPlannedDate.Name = "btnSearchByPlannedDate";
            this.btnSearchByPlannedDate.Size = new System.Drawing.Size(111, 30);
            this.btnSearchByPlannedDate.TabIndex = 2;
            this.btnSearchByPlannedDate.Text = "ရှာမည်";
            this.btnSearchByPlannedDate.UseVisualStyleBackColor = true;
            this.btnSearchByPlannedDate.Click += new System.EventHandler(this.btnSearchByPlannedDate_Click);
            // 
            // pnlFilt
            // 
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 46);
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(1020, 23);
            this.pnlFilt.TabIndex = 199;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.Blue;
            this.lblFilter.Location = new System.Drawing.Point(3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(145, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Advance Search";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.lblSetup);
            this.panel2.Controls.Add(this.lblHeader);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 46);
            this.panel2.TabIndex = 11;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(9, 13);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(83, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Marketing";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.MintCream;
            this.lblHeader.Location = new System.Drawing.Point(99, 13);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(191, 20);
            this.lblHeader.TabIndex = 45;
            this.lblHeader.Text = ">    Daily Marketing Log";
            // 
            // colNo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNo.HeaderText = "စဉ်";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Width = 30;
            // 
            // colIsPotential
            // 
            this.colIsPotential.DataPropertyName = "IsPotential";
            this.colIsPotential.HeaderText = "IsPotential";
            this.colIsPotential.Name = "colIsPotential";
            this.colIsPotential.ReadOnly = true;
            this.colIsPotential.Visible = false;
            // 
            // colPlanDate
            // 
            this.colPlanDate.DataPropertyName = "PlanDate";
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            this.colPlanDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPlanDate.HeaderText = "သွားရမည့့််နေ့";
            this.colPlanDate.Name = "colPlanDate";
            this.colPlanDate.ReadOnly = true;
            this.colPlanDate.Width = 90;
            // 
            // colMarketedDate
            // 
            this.colMarketedDate.DataPropertyName = "MarketedDate";
            dataGridViewCellStyle4.Format = "dd-MMM-yyyy";
            this.colMarketedDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.colMarketedDate.HeaderText = "သွားသည့်နေ့";
            this.colMarketedDate.Name = "colMarketedDate";
            this.colMarketedDate.ReadOnly = true;
            // 
            // colTown
            // 
            this.colTown.DataPropertyName = "Town";
            this.colTown.HeaderText = "မြို့";
            this.colTown.Name = "colTown";
            this.colTown.ReadOnly = true;
            this.colTown.Visible = false;
            // 
            // colTownship
            // 
            this.colTownship.DataPropertyName = "Township";
            this.colTownship.HeaderText = "မြို့နယ်";
            this.colTownship.Name = "colTownship";
            this.colTownship.ReadOnly = true;
            this.colTownship.Width = 120;
            // 
            // colCusType
            // 
            this.colCusType.DataPropertyName = "CusType";
            this.colCusType.HeaderText = "Customer Type";
            this.colCusType.Name = "colCusType";
            this.colCusType.ReadOnly = true;
            this.colCusType.Visible = false;
            this.colCusType.Width = 130;
            // 
            // colCustomerType
            // 
            this.colCustomerType.HeaderText = "Customer အမျိုးအစား";
            this.colCustomerType.Name = "colCustomerType";
            this.colCustomerType.ReadOnly = true;
            this.colCustomerType.Width = 150;
            // 
            // colCusName
            // 
            this.colCusName.DataPropertyName = "CusName";
            this.colCusName.HeaderText = "Customer အမည်";
            this.colCusName.Name = "colCusName";
            this.colCusName.ReadOnly = true;
            this.colCusName.Width = 120;
            // 
            // colContactPerson
            // 
            this.colContactPerson.HeaderText = "Contact Person";
            this.colContactPerson.Name = "colContactPerson";
            this.colContactPerson.ReadOnly = true;
            // 
            // colEmpName
            // 
            this.colEmpName.DataPropertyName = "EmpName";
            this.colEmpName.HeaderText = "သွားသည့်ဝန်ထမ်း";
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.ReadOnly = true;
            this.colEmpName.Width = 110;
            // 
            // colMarketingDetail
            // 
            this.colMarketingDetail.HeaderText = "Marketing Detail";
            this.colMarketingDetail.Name = "colMarketingDetail";
            this.colMarketingDetail.ReadOnly = true;
            this.colMarketingDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMarketingDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMarketingDetail.Text = "";
            this.colMarketingDetail.Width = 130;
            // 
            // colMarketingDetailID
            // 
            this.colMarketingDetailID.DataPropertyName = "MarketingDetailID";
            this.colMarketingDetailID.HeaderText = "MarketingDetailID";
            this.colMarketingDetailID.Name = "colMarketingDetailID";
            this.colMarketingDetailID.ReadOnly = true;
            this.colMarketingDetailID.Visible = false;
            // 
            // colIsMarketed
            // 
            this.colIsMarketed.DataPropertyName = "IsMarketed";
            this.colIsMarketed.HeaderText = "Marketing သွား/မသွား";
            this.colIsMarketed.Name = "colIsMarketed";
            this.colIsMarketed.ReadOnly = true;
            this.colIsMarketed.Width = 120;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            // 
            // colMarketingPlanID
            // 
            this.colMarketingPlanID.DataPropertyName = "MarketingPlanID";
            this.colMarketingPlanID.HeaderText = "MarketingPlanID";
            this.colMarketingPlanID.Name = "colMarketingPlanID";
            this.colMarketingPlanID.ReadOnly = true;
            this.colMarketingPlanID.Visible = false;
            // 
            // colTownshipID
            // 
            this.colTownshipID.DataPropertyName = "TownshipID";
            this.colTownshipID.HeaderText = "TownshipID";
            this.colTownshipID.Name = "colTownshipID";
            this.colTownshipID.ReadOnly = true;
            this.colTownshipID.Visible = false;
            // 
            // colTownID
            // 
            this.colTownID.DataPropertyName = "TownID";
            this.colTownID.HeaderText = "TownID";
            this.colTownID.Name = "colTownID";
            this.colTownID.ReadOnly = true;
            this.colTownID.Visible = false;
            // 
            // colEmpID
            // 
            this.colEmpID.DataPropertyName = "EmpID";
            this.colEmpID.HeaderText = "EmpID";
            this.colEmpID.Name = "colEmpID";
            this.colEmpID.ReadOnly = true;
            this.colEmpID.Visible = false;
            // 
            // colCusID
            // 
            this.colCusID.DataPropertyName = "CusID";
            this.colCusID.HeaderText = "CusID";
            this.colCusID.Name = "colCusID";
            this.colCusID.ReadOnly = true;
            this.colCusID.Visible = false;
            // 
            // frmDailyMarketingLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 442);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDailyMarketingLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Daily Marketing Log";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarketingLog)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMarketingLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnSearchByPlannedDate;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpPlannedEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpPlannedStartDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpMarketedEndDate;
        private System.Windows.Forms.DateTimePicker dtpMarketedStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchByMarketedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsPotential;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarketedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownship;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpName;
        private System.Windows.Forms.DataGridViewButtonColumn colMarketingDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarketingDetailID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsMarketed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarketingPlanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownshipID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusID;

    }
}