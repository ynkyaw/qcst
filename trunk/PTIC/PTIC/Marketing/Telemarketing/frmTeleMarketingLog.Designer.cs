namespace PTIC.VC.Marketing.Telemarketing
{
    partial class frmTeleMarketingLog
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
            this.dgvTelemarketingLog = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailCusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarketedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelemarketingDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIsMarketed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarketingType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarketingPlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmarketingDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownshipID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSetup = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelemarketingLog)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTelemarketingLog
            // 
            this.dgvTelemarketingLog.AllowUserToAddRows = false;
            this.dgvTelemarketingLog.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTelemarketingLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTelemarketingLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelemarketingLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colDetailCusID,
            this.colDetailEmpID,
            this.colPlanDate,
            this.colMarketedDate,
            this.colTown,
            this.colTownship,
            this.colCusType,
            this.colCustomerType,
            this.colCusName,
            this.colCusPhone,
            this.colEmpName,
            this.colTelemarketingDetail,
            this.colIsMarketed,
            this.colRemark,
            this.colStatus,
            this.colMarketingType,
            this.colMarketingPlanID,
            this.colmarketingDetailID,
            this.colTownshipID,
            this.colEmpID,
            this.colCusID});
            this.dgvTelemarketingLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTelemarketingLog.Location = new System.Drawing.Point(0, 0);
            this.dgvTelemarketingLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTelemarketingLog.Name = "dgvTelemarketingLog";
            this.dgvTelemarketingLog.ReadOnly = true;
            this.dgvTelemarketingLog.RowTemplate.Height = 28;
            this.dgvTelemarketingLog.Size = new System.Drawing.Size(1020, 573);
            this.dgvTelemarketingLog.TabIndex = 0;
            this.dgvTelemarketingLog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTelemarketingLog_CellClick);
            this.dgvTelemarketingLog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTelemarketingLog_CellContentClick);
            this.dgvTelemarketingLog.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTelemarketingLog_DataBindingComplete);
            this.dgvTelemarketingLog.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTelemarketingLog_RowPostPaint);
            // 
            // colNo
            // 
            this.colNo.HeaderText = "စဉ်";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Width = 30;
            // 
            // colDetailCusID
            // 
            this.colDetailCusID.DataPropertyName = "DetailCusID";
            this.colDetailCusID.HeaderText = "DetailCusID";
            this.colDetailCusID.Name = "colDetailCusID";
            this.colDetailCusID.ReadOnly = true;
            this.colDetailCusID.Visible = false;
            // 
            // colDetailEmpID
            // 
            this.colDetailEmpID.DataPropertyName = "DetailEmpID";
            this.colDetailEmpID.HeaderText = "DetailEmpID";
            this.colDetailEmpID.Name = "colDetailEmpID";
            this.colDetailEmpID.ReadOnly = true;
            this.colDetailEmpID.Visible = false;
            // 
            // colPlanDate
            // 
            this.colPlanDate.DataPropertyName = "PlanDate";
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            this.colPlanDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPlanDate.HeaderText = "ဆက်သွယ်ရမည့်နေ့";
            this.colPlanDate.Name = "colPlanDate";
            this.colPlanDate.ReadOnly = true;
            this.colPlanDate.Width = 110;
            // 
            // colMarketedDate
            // 
            this.colMarketedDate.DataPropertyName = "MarketedDate";
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            this.colMarketedDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colMarketedDate.HeaderText = "ဆက်သွယ်သည့်နေ့";
            this.colMarketedDate.Name = "colMarketedDate";
            this.colMarketedDate.ReadOnly = true;
            this.colMarketedDate.Width = 110;
            // 
            // colTown
            // 
            this.colTown.DataPropertyName = "Town";
            this.colTown.HeaderText = "မြို့";
            this.colTown.Name = "colTown";
            this.colTown.ReadOnly = true;
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
            this.colCustomerType.DataPropertyName = "CusTypeName";
            this.colCustomerType.HeaderText = "Customer အမျိုးအစား";
            this.colCustomerType.Name = "colCustomerType";
            this.colCustomerType.ReadOnly = true;
            this.colCustomerType.Width = 130;
            // 
            // colCusName
            // 
            this.colCusName.DataPropertyName = "CusName";
            this.colCusName.HeaderText = "Customer အမည်";
            this.colCusName.Name = "colCusName";
            this.colCusName.ReadOnly = true;
            this.colCusName.Width = 200;
            // 
            // colCusPhone
            // 
            this.colCusPhone.DataPropertyName = "Phone1";
            this.colCusPhone.HeaderText = "ဖုန်းနံပါတ်";
            this.colCusPhone.Name = "colCusPhone";
            this.colCusPhone.ReadOnly = true;
            this.colCusPhone.Width = 200;
            // 
            // colEmpName
            // 
            this.colEmpName.DataPropertyName = "EmpName";
            this.colEmpName.HeaderText = "ဆက်သွယ်သည့် ဝန်ထမ်းအမည်";
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.ReadOnly = true;
            this.colEmpName.Width = 180;
            // 
            // colTelemarketingDetail
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = "ထည့်မည်";
            this.colTelemarketingDetail.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTelemarketingDetail.HeaderText = "ဆက်သွယ်မှု မှတ်တမ်း";
            this.colTelemarketingDetail.Name = "colTelemarketingDetail";
            this.colTelemarketingDetail.ReadOnly = true;
            this.colTelemarketingDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTelemarketingDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colTelemarketingDetail.Width = 90;
            // 
            // colIsMarketed
            // 
            this.colIsMarketed.DataPropertyName = "IsMarketed";
            this.colIsMarketed.HeaderText = "ဆက်သွယ်ပြီး/မပြီး";
            this.colIsMarketed.Name = "colIsMarketed";
            this.colIsMarketed.ReadOnly = true;
            this.colIsMarketed.Width = 60;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "မှတ်ချက်";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Visible = false;
            // 
            // colMarketingType
            // 
            this.colMarketingType.DataPropertyName = "MarketingType";
            this.colMarketingType.HeaderText = "Marketing Type";
            this.colMarketingType.Name = "colMarketingType";
            this.colMarketingType.ReadOnly = true;
            this.colMarketingType.Visible = false;
            // 
            // colMarketingPlanID
            // 
            this.colMarketingPlanID.DataPropertyName = "MarketingPlanID";
            this.colMarketingPlanID.HeaderText = "TelemarketingPlanID";
            this.colMarketingPlanID.Name = "colMarketingPlanID";
            this.colMarketingPlanID.ReadOnly = true;
            this.colMarketingPlanID.Visible = false;
            // 
            // colmarketingDetailID
            // 
            this.colmarketingDetailID.DataPropertyName = "MarketingDetailID";
            this.colmarketingDetailID.HeaderText = "MarketingDetailID";
            this.colmarketingDetailID.Name = "colmarketingDetailID";
            this.colmarketingDetailID.ReadOnly = true;
            this.colmarketingDetailID.Visible = false;
            // 
            // colTownshipID
            // 
            this.colTownshipID.DataPropertyName = "TownshipID";
            this.colTownshipID.HeaderText = "TownshipID";
            this.colTownshipID.Name = "colTownshipID";
            this.colTownshipID.ReadOnly = true;
            this.colTownshipID.Visible = false;
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
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(7, 14);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(113, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Telemarketing";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblSetup);
            this.panel2.Controls.Add(this.lblHeader);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 48);
            this.panel2.TabIndex = 11;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeader.Location = new System.Drawing.Point(120, 14);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(177, 20);
            this.lblHeader.TabIndex = 45;
            this.lblHeader.Text = ">    Telemarketing Log";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.pnlFilter);
            this.panel1.Controls.Add(this.pnlFilt);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 693);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvTelemarketingLog);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 120);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1020, 573);
            this.panel4.TabIndex = 203;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.dtpEndDate);
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Controls.Add(this.dtpStartDate);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 71);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1020, 49);
            this.pnlFilter.TabIndex = 202;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(190, 11);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 28);
            this.dtpEndDate.TabIndex = 86;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 102);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1007, 176);
            this.panel3.TabIndex = 174;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(168, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 20);
            this.label3.TabIndex = 85;
            this.label3.Text = "မွ";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(330, 9);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(42, 10);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 28);
            this.dtpStartDate.TabIndex = 84;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // pnlFilt
            // 
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 48);
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(1020, 23);
            this.pnlFilt.TabIndex = 201;
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
            // frmTeleMarketingLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 693);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTeleMarketingLog";
            this.Text = "TeleMarketing Log";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelemarketingLog)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTelemarketingLog;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailCusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarketedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownship;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpName;
        private System.Windows.Forms.DataGridViewButtonColumn colTelemarketingDetail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsMarketed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarketingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarketingPlanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmarketingDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownshipID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusID;
    }
}