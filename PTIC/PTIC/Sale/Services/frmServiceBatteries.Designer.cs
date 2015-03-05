namespace PTIC.Sale.Services
{
    partial class frmServiceBatteries
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.dgvServiceBatteries = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDetail = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.colReceivedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsReturned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJobNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestRecPlus1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestRecPlus2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestRecPlus3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestRecPlus4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestRecPlus5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestRecPlus6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestRecMinus1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestRecMinus2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestRecMinus3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestRecMinus4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestRecMinus5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestRecMinus6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestVolt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colService = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colFaultRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateToFactory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFaultBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFactoryMgrRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAGM_Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateFromFactory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContactDateToCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateToCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaleServicedID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colServicedCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceBatteries)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(198)))), ((int)(((byte)(232)))));
            this.panel2.Controls.Add(this.lblSetup);
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 44);
            this.panel2.TabIndex = 195;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(10, 12);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(63, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Service";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(70, 12);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(189, 20);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">  Service Battery စာရင်း";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.dateTimePicker1);
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 67);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(982, 49);
            this.pnlFilter.TabIndex = 198;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(36, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(133, 28);
            this.dateTimePicker1.TabIndex = 175;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 102);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1007, 176);
            this.panel3.TabIndex = 174;
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(193, 9);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // pnlFilt
            // 
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 44);
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(982, 23);
            this.pnlFilt.TabIndex = 197;
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
            // dgvServiceBatteries
            // 
            this.dgvServiceBatteries.AllowUserToAddRows = false;
            this.dgvServiceBatteries.AllowUserToDeleteRows = false;
            this.dgvServiceBatteries.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServiceBatteries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServiceBatteries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceBatteries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReceivedDate,
            this.colIsReturned,
            this.colJobNo,
            this.colProductName,
            this.colProductionDate,
            this.colPurchaseDate,
            this.colName,
            this.colTestRecPlus1,
            this.colTestRecPlus2,
            this.colTestRecPlus3,
            this.colTestRecPlus4,
            this.colTestRecPlus5,
            this.colTestRecPlus6,
            this.colTestRecMinus1,
            this.colTestRecMinus2,
            this.colTestRecMinus3,
            this.colTestRecMinus4,
            this.colTestRecMinus5,
            this.colTestRecMinus6,
            this.colTestVolt,
            this.colService,
            this.colFaultRemark,
            this.colDateToFactory,
            this.colFaultBy,
            this.colFactoryMgrRemark,
            this.colAGM_Remark,
            this.colDateFromFactory,
            this.colContactDateToCustomer,
            this.colDateToCustomer,
            this.colSaleServicedID,
            this.colServicedCustomerID});
            this.dgvServiceBatteries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServiceBatteries.EnableHeadersVisualStyles = false;
            this.dgvServiceBatteries.Location = new System.Drawing.Point(0, 0);
            this.dgvServiceBatteries.Name = "dgvServiceBatteries";
            this.dgvServiceBatteries.ReadOnly = true;
            this.dgvServiceBatteries.RowHeadersWidth = 50;
            this.dgvServiceBatteries.RowTemplate.Height = 28;
            this.dgvServiceBatteries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServiceBatteries.Size = new System.Drawing.Size(982, 300);
            this.dgvServiceBatteries.TabIndex = 199;
            this.dgvServiceBatteries.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvServiceBatteries_DataBindingComplete);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDetail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 416);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 41);
            this.panel1.TabIndex = 200;
            // 
            // btnDetail
            // 
            this.btnDetail.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnDetail.Location = new System.Drawing.Point(14, 6);
            this.btnDetail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(111, 30);
            this.btnDetail.TabIndex = 3;
            this.btnDetail.Text = "Detail";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvServiceBatteries);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 116);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(982, 300);
            this.panel4.TabIndex = 201;
            // 
            // colReceivedDate
            // 
            this.colReceivedDate.DataPropertyName = "ReceivedDate";
            dataGridViewCellStyle2.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.colReceivedDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colReceivedDate.HeaderText = "Date";
            this.colReceivedDate.Name = "colReceivedDate";
            this.colReceivedDate.ReadOnly = true;
            // 
            // colIsReturned
            // 
            this.colIsReturned.DataPropertyName = "IsReturned";
            this.colIsReturned.HeaderText = "IsReturned";
            this.colIsReturned.Name = "colIsReturned";
            this.colIsReturned.ReadOnly = true;
            this.colIsReturned.Visible = false;
            // 
            // colJobNo
            // 
            this.colJobNo.DataPropertyName = "JobNo";
            this.colJobNo.HeaderText = "J.No";
            this.colJobNo.Name = "colJobNo";
            this.colJobNo.ReadOnly = true;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "Type";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // colProductionDate
            // 
            this.colProductionDate.DataPropertyName = "ProductionDate";
            this.colProductionDate.HeaderText = "PD";
            this.colProductionDate.Name = "colProductionDate";
            this.colProductionDate.ReadOnly = true;
            // 
            // colPurchaseDate
            // 
            this.colPurchaseDate.DataPropertyName = "PurchaseDate";
            this.colPurchaseDate.HeaderText = "Sales Date";
            this.colPurchaseDate.Name = "colPurchaseDate";
            this.colPurchaseDate.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colTestRecPlus1
            // 
            this.colTestRecPlus1.DataPropertyName = "TestRecPlus1";
            this.colTestRecPlus1.HeaderText = "(+) 1";
            this.colTestRecPlus1.Name = "colTestRecPlus1";
            this.colTestRecPlus1.ReadOnly = true;
            this.colTestRecPlus1.Visible = false;
            // 
            // colTestRecPlus2
            // 
            this.colTestRecPlus2.DataPropertyName = "TestRecPlus2";
            this.colTestRecPlus2.HeaderText = "(+) 2";
            this.colTestRecPlus2.Name = "colTestRecPlus2";
            this.colTestRecPlus2.ReadOnly = true;
            this.colTestRecPlus2.Visible = false;
            // 
            // colTestRecPlus3
            // 
            this.colTestRecPlus3.DataPropertyName = "TestRecPlus3";
            this.colTestRecPlus3.HeaderText = "(+) 3";
            this.colTestRecPlus3.Name = "colTestRecPlus3";
            this.colTestRecPlus3.ReadOnly = true;
            this.colTestRecPlus3.Visible = false;
            // 
            // colTestRecPlus4
            // 
            this.colTestRecPlus4.DataPropertyName = "TestRecPlus4";
            this.colTestRecPlus4.HeaderText = "(+) 4";
            this.colTestRecPlus4.Name = "colTestRecPlus4";
            this.colTestRecPlus4.ReadOnly = true;
            this.colTestRecPlus4.Visible = false;
            // 
            // colTestRecPlus5
            // 
            this.colTestRecPlus5.DataPropertyName = "TestRecPlus5";
            this.colTestRecPlus5.HeaderText = "(+) 5";
            this.colTestRecPlus5.Name = "colTestRecPlus5";
            this.colTestRecPlus5.ReadOnly = true;
            this.colTestRecPlus5.Visible = false;
            // 
            // colTestRecPlus6
            // 
            this.colTestRecPlus6.DataPropertyName = "TestRecPlus6";
            this.colTestRecPlus6.HeaderText = "(+) 6";
            this.colTestRecPlus6.Name = "colTestRecPlus6";
            this.colTestRecPlus6.ReadOnly = true;
            this.colTestRecPlus6.Visible = false;
            // 
            // colTestRecMinus1
            // 
            this.colTestRecMinus1.DataPropertyName = "TestRecMinus1";
            this.colTestRecMinus1.HeaderText = "(-) 1";
            this.colTestRecMinus1.Name = "colTestRecMinus1";
            this.colTestRecMinus1.ReadOnly = true;
            this.colTestRecMinus1.Visible = false;
            // 
            // colTestRecMinus2
            // 
            this.colTestRecMinus2.DataPropertyName = "TestRecMinus2";
            this.colTestRecMinus2.HeaderText = "(-) 2";
            this.colTestRecMinus2.Name = "colTestRecMinus2";
            this.colTestRecMinus2.ReadOnly = true;
            this.colTestRecMinus2.Visible = false;
            // 
            // colTestRecMinus3
            // 
            this.colTestRecMinus3.DataPropertyName = "TestRecMinus3";
            this.colTestRecMinus3.HeaderText = "(-) 3";
            this.colTestRecMinus3.Name = "colTestRecMinus3";
            this.colTestRecMinus3.ReadOnly = true;
            this.colTestRecMinus3.Visible = false;
            // 
            // colTestRecMinus4
            // 
            this.colTestRecMinus4.DataPropertyName = "TestRecMinus4";
            this.colTestRecMinus4.HeaderText = "(-) 4";
            this.colTestRecMinus4.Name = "colTestRecMinus4";
            this.colTestRecMinus4.ReadOnly = true;
            this.colTestRecMinus4.Visible = false;
            // 
            // colTestRecMinus5
            // 
            this.colTestRecMinus5.DataPropertyName = "TestRecMinus5";
            this.colTestRecMinus5.HeaderText = "(-) 5";
            this.colTestRecMinus5.Name = "colTestRecMinus5";
            this.colTestRecMinus5.ReadOnly = true;
            this.colTestRecMinus5.Visible = false;
            // 
            // colTestRecMinus6
            // 
            this.colTestRecMinus6.DataPropertyName = "TestRecMinus6";
            this.colTestRecMinus6.HeaderText = "(-) 6";
            this.colTestRecMinus6.Name = "colTestRecMinus6";
            this.colTestRecMinus6.ReadOnly = true;
            this.colTestRecMinus6.Visible = false;
            // 
            // colTestVolt
            // 
            this.colTestVolt.DataPropertyName = "TestVolt";
            this.colTestVolt.HeaderText = "Volt";
            this.colTestVolt.Name = "colTestVolt";
            this.colTestVolt.ReadOnly = true;
            this.colTestVolt.Visible = false;
            // 
            // colService
            // 
            this.colService.DataPropertyName = "Service";
            this.colService.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colService.HeaderText = "Customer အားဆောင်ရွက်ပေးမှု";
            this.colService.Name = "colService";
            this.colService.ReadOnly = true;
            this.colService.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colService.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colFaultRemark
            // 
            this.colFaultRemark.DataPropertyName = "FaultRemark";
            this.colFaultRemark.HeaderText = "ပြစ်ချက်";
            this.colFaultRemark.Name = "colFaultRemark";
            this.colFaultRemark.ReadOnly = true;
            // 
            // colDateToFactory
            // 
            this.colDateToFactory.DataPropertyName = "DateToFactory";
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.colDateToFactory.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDateToFactory.HeaderText = "Factory ပို့ရက်";
            this.colDateToFactory.Name = "colDateToFactory";
            this.colDateToFactory.ReadOnly = true;
            // 
            // colFaultBy
            // 
            this.colFaultBy.DataPropertyName = "FaultBy";
            this.colFaultBy.HeaderText = "F";
            this.colFaultBy.Name = "colFaultBy";
            this.colFaultBy.ReadOnly = true;
            // 
            // colFactoryMgrRemark
            // 
            this.colFactoryMgrRemark.DataPropertyName = "FactoryMgrRemark";
            this.colFactoryMgrRemark.HeaderText = "Factory Mgr Remark";
            this.colFactoryMgrRemark.Name = "colFactoryMgrRemark";
            this.colFactoryMgrRemark.ReadOnly = true;
            // 
            // colAGM_Remark
            // 
            this.colAGM_Remark.DataPropertyName = "AGM_Remark";
            this.colAGM_Remark.HeaderText = "A.S.M Remark";
            this.colAGM_Remark.Name = "colAGM_Remark";
            this.colAGM_Remark.ReadOnly = true;
            // 
            // colDateFromFactory
            // 
            this.colDateFromFactory.DataPropertyName = "DateFromFactory";
            dataGridViewCellStyle4.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle4.NullValue = null;
            this.colDateFromFactory.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDateFromFactory.HeaderText = "Factory မှပြန်ရရက်";
            this.colDateFromFactory.Name = "colDateFromFactory";
            this.colDateFromFactory.ReadOnly = true;
            // 
            // colContactDateToCustomer
            // 
            this.colContactDateToCustomer.DataPropertyName = "ContactDateToCustomer";
            dataGridViewCellStyle5.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle5.NullValue = null;
            this.colContactDateToCustomer.DefaultCellStyle = dataGridViewCellStyle5;
            this.colContactDateToCustomer.HeaderText = "Customer ထံအကြောင်းကြားရက်";
            this.colContactDateToCustomer.Name = "colContactDateToCustomer";
            this.colContactDateToCustomer.ReadOnly = true;
            // 
            // colDateToCustomer
            // 
            this.colDateToCustomer.DataPropertyName = "DateToCustomer";
            dataGridViewCellStyle6.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle6.NullValue = null;
            this.colDateToCustomer.DefaultCellStyle = dataGridViewCellStyle6;
            this.colDateToCustomer.HeaderText = "Customer ထံပြန်ပေးရက်";
            this.colDateToCustomer.Name = "colDateToCustomer";
            this.colDateToCustomer.ReadOnly = true;
            // 
            // colSaleServicedID
            // 
            this.colSaleServicedID.DataPropertyName = "SalesServicedID";
            this.colSaleServicedID.HeaderText = "SalesServiceID";
            this.colSaleServicedID.Name = "colSaleServicedID";
            this.colSaleServicedID.ReadOnly = true;
            this.colSaleServicedID.Visible = false;
            // 
            // colServicedCustomerID
            // 
            this.colServicedCustomerID.DataPropertyName = "ServicedCustomerID";
            this.colServicedCustomerID.HeaderText = "ServicedCustomerID";
            this.colServicedCustomerID.Name = "colServicedCustomerID";
            this.colServicedCustomerID.ReadOnly = true;
            this.colServicedCustomerID.Visible = false;
            // 
            // frmServiceBatteries
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(982, 457);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmServiceBatteries";
            this.Text = "Service Batteries";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceBatteries)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.DataGridView dgvServiceBatteries;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsReturned;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJobNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestRecPlus1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestRecPlus2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestRecPlus3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestRecPlus4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestRecPlus5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestRecPlus6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestRecMinus1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestRecMinus2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestRecMinus3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestRecMinus4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestRecMinus5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestRecMinus6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestVolt;
        private System.Windows.Forms.DataGridViewComboBoxColumn colService;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFaultRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateToFactory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFaultBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactoryMgrRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAGM_Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateFromFactory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContactDateToCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateToCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaleServicedID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colServicedCustomerID;
    }
}