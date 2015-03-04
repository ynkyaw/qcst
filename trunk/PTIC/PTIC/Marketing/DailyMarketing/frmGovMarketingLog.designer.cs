namespace PTIC.VC.Marketing.DailyMarketing
{
    partial class frmGovMarketingLog
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblMarketing = new System.Windows.Forms.Label();
            this.dgvGovMarketingLog = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinistryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIsMarketed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colServiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenderInfoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContactPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGovernmentMarketingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarketingPlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVenID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownshipID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGovMarketingLog)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvGovMarketingLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 600);
            this.panel1.TabIndex = 0;
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
            this.panel2.TabIndex = 130;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(85, 9);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(235, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">   Government Marketing Log";
            // 
            // lblMarketing
            // 
            this.lblMarketing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarketing.AutoSize = true;
            this.lblMarketing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMarketing.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketing.Location = new System.Drawing.Point(8, 9);
            this.lblMarketing.Name = "lblMarketing";
            this.lblMarketing.Size = new System.Drawing.Size(83, 20);
            this.lblMarketing.TabIndex = 0;
            this.lblMarketing.Text = "Marketing";
            this.lblMarketing.Click += new System.EventHandler(this.lblMarketing_Click);
            // 
            // dgvGovMarketingLog
            // 
            this.dgvGovMarketingLog.AllowUserToAddRows = false;
            this.dgvGovMarketingLog.AllowUserToOrderColumns = true;
            this.dgvGovMarketingLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGovMarketingLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvGovMarketingLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGovMarketingLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colDate,
            this.colMinistryName,
            this.colDepartment,
            this.colMatter,
            this.colEmpName,
            this.colUpdateDetail,
            this.colIsMarketed,
            this.colServiceID,
            this.colOrderID,
            this.colTenderInfoID,
            this.colContactPerson,
            this.colPosition,
            this.colContactPhone,
            this.colAddress,
            this.colPhone1,
            this.colPhone2,
            this.colRemark,
            this.colGovernmentMarketingID,
            this.colMarketingPlanID,
            this.colEmpID,
            this.colVenID,
            this.colCusID,
            this.colTownID,
            this.colTownshipID});
            this.dgvGovMarketingLog.Location = new System.Drawing.Point(0, 47);
            this.dgvGovMarketingLog.Name = "dgvGovMarketingLog";
            this.dgvGovMarketingLog.ReadOnly = true;
            this.dgvGovMarketingLog.RowHeadersWidth = 50;
            this.dgvGovMarketingLog.RowTemplate.Height = 28;
            this.dgvGovMarketingLog.Size = new System.Drawing.Size(930, 550);
            this.dgvGovMarketingLog.TabIndex = 1;
            this.dgvGovMarketingLog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGovMarketingLog_CellContentClick);
            this.dgvGovMarketingLog.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvGovMarketingLog_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "စဉ်";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "သွားရမည့်ရက်";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ဝန်ကြီးဌာနအမည်";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ဌာနခွဲအမည်";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "သွားရမည့်ကိစ္စ";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "သွားရမည့်ဝန်ထမ်း";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 110;
            // 
            // colNo
            // 
            this.colNo.HeaderText = "စဉ်";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Visible = false;
            this.colNo.Width = 30;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "PlanDate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.colDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDate.HeaderText = "သွားရမည့်ရက်";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 110;
            // 
            // colMinistryName
            // 
            this.colMinistryName.DataPropertyName = "MinistryName";
            this.colMinistryName.HeaderText = "ဝန်ကြီးဌာနအမည်";
            this.colMinistryName.Name = "colMinistryName";
            this.colMinistryName.ReadOnly = true;
            this.colMinistryName.Width = 120;
            // 
            // colDepartment
            // 
            this.colDepartment.DataPropertyName = "Department";
            this.colDepartment.HeaderText = "ဌာနခွဲအမည်";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            this.colDepartment.Width = 120;
            // 
            // colMatter
            // 
            this.colMatter.DataPropertyName = "Matter";
            this.colMatter.HeaderText = "သွားရမည့်ကိစ္စ";
            this.colMatter.Name = "colMatter";
            this.colMatter.ReadOnly = true;
            this.colMatter.Width = 150;
            // 
            // colEmpName
            // 
            this.colEmpName.DataPropertyName = "EmpName";
            this.colEmpName.HeaderText = "သွားရမည့်ဝန်ထမ်း";
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.ReadOnly = true;
            this.colEmpName.Width = 120;
            // 
            // colUpdateDetail
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "ထည့်မည်";
            this.colUpdateDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.colUpdateDetail.HeaderText = "Marketing Detail";
            this.colUpdateDetail.Name = "colUpdateDetail";
            this.colUpdateDetail.ReadOnly = true;
            this.colUpdateDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUpdateDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colIsMarketed
            // 
            this.colIsMarketed.DataPropertyName = "IsMarketed";
            this.colIsMarketed.HeaderText = "Marketing သွား/မသွား";
            this.colIsMarketed.Name = "colIsMarketed";
            this.colIsMarketed.ReadOnly = true;
            this.colIsMarketed.Width = 90;
            // 
            // colServiceID
            // 
            this.colServiceID.DataPropertyName = "ServiceID";
            this.colServiceID.HeaderText = "ServiceID";
            this.colServiceID.Name = "colServiceID";
            this.colServiceID.ReadOnly = true;
            this.colServiceID.Visible = false;
            // 
            // colOrderID
            // 
            this.colOrderID.DataPropertyName = "OrderID";
            this.colOrderID.HeaderText = "OrderID";
            this.colOrderID.Name = "colOrderID";
            this.colOrderID.ReadOnly = true;
            this.colOrderID.Visible = false;
            // 
            // colTenderInfoID
            // 
            this.colTenderInfoID.DataPropertyName = "TenderInfoID";
            this.colTenderInfoID.HeaderText = "TenderInfoID";
            this.colTenderInfoID.Name = "colTenderInfoID";
            this.colTenderInfoID.ReadOnly = true;
            this.colTenderInfoID.Visible = false;
            // 
            // colContactPerson
            // 
            this.colContactPerson.DataPropertyName = "ContactPerson";
            this.colContactPerson.HeaderText = "ContactPerson";
            this.colContactPerson.Name = "colContactPerson";
            this.colContactPerson.ReadOnly = true;
            this.colContactPerson.Visible = false;
            // 
            // colPosition
            // 
            this.colPosition.DataPropertyName = "Position";
            this.colPosition.HeaderText = "Position";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            this.colPosition.Visible = false;
            // 
            // colContactPhone
            // 
            this.colContactPhone.DataPropertyName = "ContactPhone";
            this.colContactPhone.HeaderText = "ContactPhone";
            this.colContactPhone.Name = "colContactPhone";
            this.colContactPhone.ReadOnly = true;
            this.colContactPhone.Visible = false;
            // 
            // colAddress
            // 
            this.colAddress.DataPropertyName = "Address";
            this.colAddress.HeaderText = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            this.colAddress.Visible = false;
            // 
            // colPhone1
            // 
            this.colPhone1.DataPropertyName = "Phone1";
            this.colPhone1.HeaderText = "Phone1";
            this.colPhone1.Name = "colPhone1";
            this.colPhone1.ReadOnly = true;
            this.colPhone1.Visible = false;
            // 
            // colPhone2
            // 
            this.colPhone2.DataPropertyName = "Phone2";
            this.colPhone2.HeaderText = "Phone2";
            this.colPhone2.Name = "colPhone2";
            this.colPhone2.ReadOnly = true;
            this.colPhone2.Visible = false;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            this.colRemark.Visible = false;
            // 
            // colGovernmentMarketingID
            // 
            this.colGovernmentMarketingID.DataPropertyName = "GovernmentMarketingID";
            this.colGovernmentMarketingID.HeaderText = "GovernmentMarketingID";
            this.colGovernmentMarketingID.Name = "colGovernmentMarketingID";
            this.colGovernmentMarketingID.ReadOnly = true;
            this.colGovernmentMarketingID.Visible = false;
            // 
            // colMarketingPlanID
            // 
            this.colMarketingPlanID.DataPropertyName = "MarketingPlanID";
            this.colMarketingPlanID.HeaderText = "MarketingPlanID";
            this.colMarketingPlanID.Name = "colMarketingPlanID";
            this.colMarketingPlanID.ReadOnly = true;
            this.colMarketingPlanID.Visible = false;
            // 
            // colEmpID
            // 
            this.colEmpID.DataPropertyName = "EmpID";
            this.colEmpID.HeaderText = "EmpID";
            this.colEmpID.Name = "colEmpID";
            this.colEmpID.ReadOnly = true;
            this.colEmpID.Visible = false;
            // 
            // colVenID
            // 
            this.colVenID.DataPropertyName = "VenID";
            this.colVenID.HeaderText = "VenID";
            this.colVenID.Name = "colVenID";
            this.colVenID.ReadOnly = true;
            this.colVenID.Visible = false;
            // 
            // colCusID
            // 
            this.colCusID.DataPropertyName = "CusID";
            this.colCusID.HeaderText = "CusID";
            this.colCusID.Name = "colCusID";
            this.colCusID.ReadOnly = true;
            this.colCusID.Visible = false;
            // 
            // colTownID
            // 
            this.colTownID.DataPropertyName = "TownID";
            this.colTownID.HeaderText = "TownID";
            this.colTownID.Name = "colTownID";
            this.colTownID.ReadOnly = true;
            this.colTownID.Visible = false;
            // 
            // colTownshipID
            // 
            this.colTownshipID.DataPropertyName = "TownshipID";
            this.colTownshipID.HeaderText = "TownshipID";
            this.colTownshipID.Name = "colTownshipID";
            this.colTownshipID.ReadOnly = true;
            this.colTownshipID.Visible = false;
            // 
            // frmGovMarketingLog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(933, 600);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmGovMarketingLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Government Marketing Log";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGovMarketingLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvGovMarketingLog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinistryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpName;
        private System.Windows.Forms.DataGridViewButtonColumn colUpdateDetail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsMarketed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenderInfoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContactPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGovernmentMarketingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarketingPlanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVenID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownshipID;
    }
}