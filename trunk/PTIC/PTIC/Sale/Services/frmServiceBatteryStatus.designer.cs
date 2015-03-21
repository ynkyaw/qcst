namespace PTIC.VC.Sale.Services
{
    partial class frmServiceBatteryStatus
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
            this.dgvStatus = new System.Windows.Forms.DataGridView();
            this.colBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurServiceTeamID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurVehicleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurMainStoreID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurWarehouseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInBackShowroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInBackVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInBackServiceTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInBackCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInShowroom = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colInVehicle = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colInServiceTeam = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colInMainStore = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSvcFact = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colSalesServiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSvcFactID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrandID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWhereami = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReturnedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContactPersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhNo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJobCardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarrantyNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJobNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsBackward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesServiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServicedCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTackerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsReturned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnToFactory = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStatus
            // 
            this.dgvStatus.AllowUserToAddRows = false;
            this.dgvStatus.AllowUserToDeleteRows = false;
            this.dgvStatus.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBrand,
            this.colCurServiceTeamID,
            this.colCurVehicleID,
            this.colCurMainStoreID,
            this.colCurWarehouseID,
            this.colInBackShowroom,
            this.colInBackVehicle,
            this.colInBackServiceTeam,
            this.colInBackCustomer,
            this.colProductName,
            this.colReceivedDate,
            this.colUserName,
            this.colInShowroom,
            this.colInVehicle,
            this.colInServiceTeam,
            this.colInMainStore,
            this.colSvcFact,
            this.colSalesServiceID,
            this.colSvcFactID,
            this.colProductID,
            this.colBrandID,
            this.colWhereami,
            this.colReturnedDate,
            this.colProductionDate,
            this.colPurchaseDate,
            this.colContactPersion,
            this.colPhNo1,
            this.colPhNo2,
            this.colJobCardNo,
            this.colWarrantyNo,
            this.colJobNo,
            this.colIsBackward,
            this.colSalesServiceNo,
            this.colServicedCustomerID,
            this.colTackerID,
            this.colIsReturned});
            this.dgvStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatus.EnableHeadersVisualStyles = false;
            this.dgvStatus.Location = new System.Drawing.Point(0, 0);
            this.dgvStatus.Name = "dgvStatus";
            this.dgvStatus.ReadOnly = true;
            this.dgvStatus.RowHeadersWidth = 50;
            this.dgvStatus.RowTemplate.Height = 28;
            this.dgvStatus.Size = new System.Drawing.Size(898, 356);
            this.dgvStatus.TabIndex = 0;
            this.dgvStatus.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStatus_CellContentClick);
            this.dgvStatus.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvStatus_DataBindingComplete);
            // 
            // colBrand
            // 
            this.colBrand.DataPropertyName = "BrandName";
            this.colBrand.HeaderText = "အမှတ်တံဆိပ်";
            this.colBrand.Name = "colBrand";
            this.colBrand.ReadOnly = true;
            this.colBrand.Width = 110;
            // 
            // colCurServiceTeamID
            // 
            this.colCurServiceTeamID.DataPropertyName = "CurServiceTeamID";
            this.colCurServiceTeamID.HeaderText = "CurServiceTeamID";
            this.colCurServiceTeamID.Name = "colCurServiceTeamID";
            this.colCurServiceTeamID.ReadOnly = true;
            this.colCurServiceTeamID.Visible = false;
            // 
            // colCurVehicleID
            // 
            this.colCurVehicleID.DataPropertyName = "CurVehicleID";
            this.colCurVehicleID.HeaderText = "CurVehicleID";
            this.colCurVehicleID.Name = "colCurVehicleID";
            this.colCurVehicleID.ReadOnly = true;
            this.colCurVehicleID.Visible = false;
            // 
            // colCurMainStoreID
            // 
            this.colCurMainStoreID.DataPropertyName = "CurMainStoreID";
            this.colCurMainStoreID.HeaderText = "CurMainStoreID";
            this.colCurMainStoreID.Name = "colCurMainStoreID";
            this.colCurMainStoreID.ReadOnly = true;
            this.colCurMainStoreID.Visible = false;
            // 
            // colCurWarehouseID
            // 
            this.colCurWarehouseID.DataPropertyName = "CurWarehouseID";
            this.colCurWarehouseID.HeaderText = "CurWarehouseID";
            this.colCurWarehouseID.Name = "colCurWarehouseID";
            this.colCurWarehouseID.ReadOnly = true;
            this.colCurWarehouseID.Visible = false;
            // 
            // colInBackShowroom
            // 
            this.colInBackShowroom.DataPropertyName = "InBackShowroom";
            this.colInBackShowroom.HeaderText = "InBackShowroom";
            this.colInBackShowroom.Name = "colInBackShowroom";
            this.colInBackShowroom.ReadOnly = true;
            this.colInBackShowroom.Visible = false;
            // 
            // colInBackVehicle
            // 
            this.colInBackVehicle.DataPropertyName = "InBackVehicle";
            this.colInBackVehicle.HeaderText = "InBackVehicle";
            this.colInBackVehicle.Name = "colInBackVehicle";
            this.colInBackVehicle.ReadOnly = true;
            this.colInBackVehicle.Visible = false;
            // 
            // colInBackServiceTeam
            // 
            this.colInBackServiceTeam.DataPropertyName = "InBackServiceTeam";
            this.colInBackServiceTeam.HeaderText = "InBackServiceTeam";
            this.colInBackServiceTeam.Name = "colInBackServiceTeam";
            this.colInBackServiceTeam.ReadOnly = true;
            this.colInBackServiceTeam.Visible = false;
            // 
            // colInBackCustomer
            // 
            this.colInBackCustomer.DataPropertyName = "InBackCustomer";
            this.colInBackCustomer.HeaderText = "InBackMainStore";
            this.colInBackCustomer.Name = "colInBackCustomer";
            this.colInBackCustomer.ReadOnly = true;
            this.colInBackCustomer.Visible = false;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "ထုတ်ကုန်အမည်";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 120;
            // 
            // colReceivedDate
            // 
            this.colReceivedDate.DataPropertyName = "ReceivedDate";
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.colReceivedDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colReceivedDate.HeaderText = "ရရှိသည့်နေ့";
            this.colReceivedDate.Name = "colReceivedDate";
            this.colReceivedDate.ReadOnly = true;
            // 
            // colUserName
            // 
            this.colUserName.DataPropertyName = "Name";
            this.colUserName.HeaderText = "User အမည်";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            this.colUserName.Width = 120;
            // 
            // colInShowroom
            // 
            this.colInShowroom.DataPropertyName = "InShowroom";
            this.colInShowroom.HeaderText = "Showroom";
            this.colInShowroom.Name = "colInShowroom";
            this.colInShowroom.ReadOnly = true;
            this.colInShowroom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInShowroom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colInShowroom.Width = 80;
            // 
            // colInVehicle
            // 
            this.colInVehicle.DataPropertyName = "InVehicle";
            this.colInVehicle.HeaderText = "Van";
            this.colInVehicle.Name = "colInVehicle";
            this.colInVehicle.ReadOnly = true;
            this.colInVehicle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInVehicle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colInVehicle.Width = 60;
            // 
            // colInServiceTeam
            // 
            this.colInServiceTeam.DataPropertyName = "InServiceTeam";
            this.colInServiceTeam.HeaderText = "SSB Service";
            this.colInServiceTeam.Name = "colInServiceTeam";
            this.colInServiceTeam.ReadOnly = true;
            this.colInServiceTeam.Width = 60;
            // 
            // colInMainStore
            // 
            this.colInMainStore.DataPropertyName = "InMainStore";
            this.colInMainStore.HeaderText = "Factory Service";
            this.colInMainStore.Name = "colInMainStore";
            this.colInMainStore.ReadOnly = true;
            this.colInMainStore.Width = 60;
            // 
            // colSvcFact
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "Detail";
            this.colSvcFact.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSvcFact.HeaderText = "Detail";
            this.colSvcFact.Name = "colSvcFact";
            this.colSvcFact.ReadOnly = true;
            this.colSvcFact.Text = "Click";
            // 
            // colSalesServiceID
            // 
            this.colSalesServiceID.DataPropertyName = "SalesServiceID";
            this.colSalesServiceID.HeaderText = "SalesServiceID";
            this.colSalesServiceID.Name = "colSalesServiceID";
            this.colSalesServiceID.ReadOnly = true;
            this.colSalesServiceID.Visible = false;
            // 
            // colSvcFactID
            // 
            this.colSvcFactID.DataPropertyName = "SvcFactID";
            this.colSvcFactID.HeaderText = "SvcFactID";
            this.colSvcFactID.Name = "colSvcFactID";
            this.colSvcFactID.ReadOnly = true;
            this.colSvcFactID.Visible = false;
            // 
            // colProductID
            // 
            this.colProductID.DataPropertyName = "ProductID";
            this.colProductID.HeaderText = "ProductID";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Visible = false;
            // 
            // colBrandID
            // 
            this.colBrandID.DataPropertyName = "BrandID";
            this.colBrandID.HeaderText = "BrandID";
            this.colBrandID.Name = "colBrandID";
            this.colBrandID.ReadOnly = true;
            this.colBrandID.Visible = false;
            // 
            // colWhereami
            // 
            this.colWhereami.DataPropertyName = "Whereami";
            this.colWhereami.HeaderText = "Whereami";
            this.colWhereami.Name = "colWhereami";
            this.colWhereami.ReadOnly = true;
            this.colWhereami.Visible = false;
            // 
            // colReturnedDate
            // 
            this.colReturnedDate.DataPropertyName = "ReturnedDate";
            this.colReturnedDate.HeaderText = "ReturnedDate";
            this.colReturnedDate.Name = "colReturnedDate";
            this.colReturnedDate.ReadOnly = true;
            this.colReturnedDate.Visible = false;
            // 
            // colProductionDate
            // 
            this.colProductionDate.DataPropertyName = "ProductionDate";
            this.colProductionDate.HeaderText = "ProductionDate";
            this.colProductionDate.Name = "colProductionDate";
            this.colProductionDate.ReadOnly = true;
            this.colProductionDate.Visible = false;
            // 
            // colPurchaseDate
            // 
            this.colPurchaseDate.DataPropertyName = "PurchaseDate";
            this.colPurchaseDate.HeaderText = "PurchaseDate";
            this.colPurchaseDate.Name = "colPurchaseDate";
            this.colPurchaseDate.ReadOnly = true;
            this.colPurchaseDate.Visible = false;
            // 
            // colContactPersion
            // 
            this.colContactPersion.DataPropertyName = "ContactPerson";
            this.colContactPersion.HeaderText = "ContactPersion";
            this.colContactPersion.Name = "colContactPersion";
            this.colContactPersion.ReadOnly = true;
            this.colContactPersion.Visible = false;
            // 
            // colPhNo1
            // 
            this.colPhNo1.DataPropertyName = "Phone1";
            this.colPhNo1.HeaderText = "PhNo1";
            this.colPhNo1.Name = "colPhNo1";
            this.colPhNo1.ReadOnly = true;
            this.colPhNo1.Visible = false;
            // 
            // colPhNo2
            // 
            this.colPhNo2.DataPropertyName = "Phone2";
            this.colPhNo2.HeaderText = "PhNo2";
            this.colPhNo2.Name = "colPhNo2";
            this.colPhNo2.ReadOnly = true;
            this.colPhNo2.Visible = false;
            // 
            // colJobCardNo
            // 
            this.colJobCardNo.DataPropertyName = "JobCardNo";
            this.colJobCardNo.HeaderText = "JobCardNo";
            this.colJobCardNo.Name = "colJobCardNo";
            this.colJobCardNo.ReadOnly = true;
            this.colJobCardNo.Visible = false;
            // 
            // colWarrantyNo
            // 
            this.colWarrantyNo.DataPropertyName = "WarrantyNo";
            this.colWarrantyNo.HeaderText = "WarrantyNo";
            this.colWarrantyNo.Name = "colWarrantyNo";
            this.colWarrantyNo.ReadOnly = true;
            this.colWarrantyNo.Visible = false;
            // 
            // colJobNo
            // 
            this.colJobNo.DataPropertyName = "JobNo";
            this.colJobNo.HeaderText = "JobNo";
            this.colJobNo.Name = "colJobNo";
            this.colJobNo.ReadOnly = true;
            this.colJobNo.Visible = false;
            // 
            // colIsBackward
            // 
            this.colIsBackward.DataPropertyName = "IsBackward";
            this.colIsBackward.HeaderText = "IsBackward";
            this.colIsBackward.Name = "colIsBackward";
            this.colIsBackward.ReadOnly = true;
            this.colIsBackward.Visible = false;
            // 
            // colSalesServiceNo
            // 
            this.colSalesServiceNo.DataPropertyName = "SalesServiceNo";
            this.colSalesServiceNo.HeaderText = "SalesServiceNo";
            this.colSalesServiceNo.Name = "colSalesServiceNo";
            this.colSalesServiceNo.ReadOnly = true;
            this.colSalesServiceNo.Visible = false;
            // 
            // colServicedCustomerID
            // 
            this.colServicedCustomerID.DataPropertyName = "ServicedCustomerID";
            this.colServicedCustomerID.HeaderText = "ServicedCustomerID";
            this.colServicedCustomerID.Name = "colServicedCustomerID";
            this.colServicedCustomerID.ReadOnly = true;
            this.colServicedCustomerID.Visible = false;
            // 
            // colTackerID
            // 
            this.colTackerID.DataPropertyName = "TakerID";
            this.colTackerID.HeaderText = "TackerID";
            this.colTackerID.Name = "colTackerID";
            this.colTackerID.ReadOnly = true;
            this.colTackerID.Visible = false;
            // 
            // colIsReturned
            // 
            this.colIsReturned.DataPropertyName = "IsReturned";
            this.colIsReturned.HeaderText = "IsReturned";
            this.colIsReturned.Name = "colIsReturned";
            this.colIsReturned.ReadOnly = true;
            this.colIsReturned.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(898, 55);
            this.panel3.TabIndex = 83;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SkyBlue;
            this.panel4.Controls.Add(this.lblSetup);
            this.panel4.Controls.Add(this.lblHeaderPCat);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(896, 51);
            this.panel4.TabIndex = 116;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(14, 14);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(81, 19);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Services";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(92, 14);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(228, 19);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">    Service Battery Status";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "အမှတ်တံဆိပ်";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 110;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ထုတ်ကုန်အမည်";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ရရှိသည့်‌နေ ့";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "User အမည်";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnToFactory);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 480);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(898, 47);
            this.panel5.TabIndex = 88;
            // 
            // btnToFactory
            // 
            this.btnToFactory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToFactory.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnToFactory.Location = new System.Drawing.Point(12, 7);
            this.btnToFactory.Name = "btnToFactory";
            this.btnToFactory.Size = new System.Drawing.Size(125, 34);
            this.btnToFactory.TabIndex = 95;
            this.btnToFactory.Text = "Factory သို့ပို့မည်";
            this.btnToFactory.UseVisualStyleBackColor = true;
            this.btnToFactory.Click += new System.EventHandler(this.btnToFactory_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.panel1);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 78);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(898, 46);
            this.pnlFilter.TabIndex = 194;
            this.pnlFilter.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 100);
            this.panel1.TabIndex = 174;
            // 
            // pnlFilt
            // 
            this.pnlFilt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(131)))), ((int)(((byte)(170)))));
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 55);
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(898, 23);
            this.pnlFilt.TabIndex = 193;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lblFilter.Location = new System.Drawing.Point(3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(168, 19);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Advance Search";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(898, 356);
            this.panel2.TabIndex = 195;
            // 
            // frmServiceBatteryStatus
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 527);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmServiceBatteryStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Service Battery Status";
            this.Load += new System.EventHandler(this.frmServiceBatteryStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStatus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnToFactory;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurServiceTeamID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurVehicleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurMainStoreID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurWarehouseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInBackShowroom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInBackVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInBackServiceTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInBackCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colInShowroom;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colInVehicle;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colInServiceTeam;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colInMainStore;
        private System.Windows.Forms.DataGridViewButtonColumn colSvcFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesServiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSvcFactID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrandID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWhereami;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReturnedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContactPersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhNo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhNo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJobCardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarrantyNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJobNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsBackward;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesServiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServicedCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTackerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsReturned;
    }
}