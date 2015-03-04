namespace PTIC.Sale.CashCollection
{
    partial class frmReceiptVoucherList_MultipleInvoices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvReceipt = new System.Windows.Forms.DataGridView();
            this.dgvColSaleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommDisAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOtherAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaidAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalanceAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTripRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownTownship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCashReceiptType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayTypeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCashReceiptTypeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstBxSalesInvoices = new System.Windows.Forms.ListBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.colDetailTotalAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailCommDisAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailOtherAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailPaidAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailBalanceAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkCustomerName = new System.Windows.Forms.CheckBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.chkDepartment = new System.Windows.Forms.CheckBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipt)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblSetup);
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 46);
            this.panel2.TabIndex = 180;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(9, 13);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(123, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Cash Collection";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(138, 13);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(270, 20);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">    Receipt List (Multiple Invoices)";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 46);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            this.splitContainer.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer.Size = new System.Drawing.Size(972, 485);
            this.splitContainer.SplitterDistance = 325;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 181;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvReceipt);
            this.groupBox1.Location = new System.Drawing.Point(0, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(972, 209);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Receipts";
            // 
            // dgvReceipt
            // 
            this.dgvReceipt.AllowUserToAddRows = false;
            this.dgvReceipt.AllowUserToDeleteRows = false;
            this.dgvReceipt.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceipt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.dgvReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColSaleDate,
            this.colTotalAmt,
            this.colCommDisAmt,
            this.colOtherAmt,
            this.colPaidAmt,
            this.colBalanceAmt,
            this.colInvoiceNo,
            this.dgvColCustomer,
            this.colTripRoute,
            this.colTownTownship,
            this.clnEmployee,
            this.colPayType,
            this.colCashReceiptType,
            this.colPayTypeText,
            this.colCashReceiptTypeText});
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceipt.DefaultCellStyle = dataGridViewCellStyle33;
            this.dgvReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceipt.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvReceipt.Location = new System.Drawing.Point(3, 16);
            this.dgvReceipt.MultiSelect = false;
            this.dgvReceipt.Name = "dgvReceipt";
            this.dgvReceipt.ReadOnly = true;
            this.dgvReceipt.RowHeadersWidth = 50;
            this.dgvReceipt.RowTemplate.Height = 28;
            this.dgvReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceipt.Size = new System.Drawing.Size(966, 190);
            this.dgvReceipt.TabIndex = 182;
            this.dgvReceipt.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvReceipt_DataBindingComplete);
            this.dgvReceipt.SelectionChanged += new System.EventHandler(this.dgvReceipt_SelectionChanged);
            // 
            // dgvColSaleDate
            // 
            this.dgvColSaleDate.DataPropertyName = "PayDate";
            dataGridViewCellStyle32.Format = "d";
            dataGridViewCellStyle32.NullValue = null;
            this.dgvColSaleDate.DefaultCellStyle = dataGridViewCellStyle32;
            this.dgvColSaleDate.HeaderText = "Receipt Date";
            this.dgvColSaleDate.Name = "dgvColSaleDate";
            this.dgvColSaleDate.ReadOnly = true;
            this.dgvColSaleDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColSaleDate.Width = 110;
            // 
            // colTotalAmt
            // 
            this.colTotalAmt.DataPropertyName = "TotalAmt";
            this.colTotalAmt.HeaderText = "TotalAmt";
            this.colTotalAmt.Name = "colTotalAmt";
            this.colTotalAmt.ReadOnly = true;
            this.colTotalAmt.Visible = false;
            // 
            // colCommDisAmt
            // 
            this.colCommDisAmt.DataPropertyName = "CommDisAmt";
            this.colCommDisAmt.HeaderText = "CommDisAmt";
            this.colCommDisAmt.Name = "colCommDisAmt";
            this.colCommDisAmt.ReadOnly = true;
            this.colCommDisAmt.Visible = false;
            // 
            // colOtherAmt
            // 
            this.colOtherAmt.DataPropertyName = "OtherAmt";
            this.colOtherAmt.HeaderText = "OtherAmt";
            this.colOtherAmt.Name = "colOtherAmt";
            this.colOtherAmt.ReadOnly = true;
            this.colOtherAmt.Visible = false;
            // 
            // colPaidAmt
            // 
            this.colPaidAmt.DataPropertyName = "PaidAmt";
            this.colPaidAmt.HeaderText = "PaidAmt";
            this.colPaidAmt.Name = "colPaidAmt";
            this.colPaidAmt.ReadOnly = true;
            this.colPaidAmt.Visible = false;
            // 
            // colBalanceAmt
            // 
            this.colBalanceAmt.DataPropertyName = "BalanceAmt";
            this.colBalanceAmt.HeaderText = "BalanceAmt";
            this.colBalanceAmt.Name = "colBalanceAmt";
            this.colBalanceAmt.ReadOnly = true;
            this.colBalanceAmt.Visible = false;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.DataPropertyName = "ReceiptNo";
            this.colInvoiceNo.HeaderText = "Recepit No";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.ReadOnly = true;
            // 
            // dgvColCustomer
            // 
            this.dgvColCustomer.DataPropertyName = "CusName";
            this.dgvColCustomer.HeaderText = "Customer အမည်";
            this.dgvColCustomer.Name = "dgvColCustomer";
            this.dgvColCustomer.ReadOnly = true;
            // 
            // colTripRoute
            // 
            this.colTripRoute.DataPropertyName = "TripRoute";
            this.colTripRoute.HeaderText = "ခရီးစဉ် / လမ်း‌ကြောင်း";
            this.colTripRoute.Name = "colTripRoute";
            this.colTripRoute.ReadOnly = true;
            // 
            // colTownTownship
            // 
            this.colTownTownship.DataPropertyName = "TownTownship";
            this.colTownTownship.HeaderText = "မြို့ / မြို့နယ်";
            this.colTownTownship.Name = "colTownTownship";
            this.colTownTownship.ReadOnly = true;
            // 
            // clnEmployee
            // 
            this.clnEmployee.DataPropertyName = "EmpName";
            this.clnEmployee.HeaderText = "‌ငွေလက်ခံဝန်ထမ်း";
            this.clnEmployee.Name = "clnEmployee";
            this.clnEmployee.ReadOnly = true;
            this.clnEmployee.Width = 140;
            // 
            // colPayType
            // 
            this.colPayType.DataPropertyName = "PayType";
            this.colPayType.HeaderText = "PayType";
            this.colPayType.Name = "colPayType";
            this.colPayType.ReadOnly = true;
            this.colPayType.Visible = false;
            // 
            // colCashReceiptType
            // 
            this.colCashReceiptType.DataPropertyName = "CashReceiptType";
            this.colCashReceiptType.HeaderText = "CashReceiptType";
            this.colCashReceiptType.Name = "colCashReceiptType";
            this.colCashReceiptType.ReadOnly = true;
            this.colCashReceiptType.Visible = false;
            // 
            // colPayTypeText
            // 
            this.colPayTypeText.HeaderText = "Installment";
            this.colPayTypeText.Name = "colPayTypeText";
            this.colPayTypeText.ReadOnly = true;
            // 
            // colCashReceiptTypeText
            // 
            this.colCashReceiptTypeText.HeaderText = "Payment Type";
            this.colCashReceiptTypeText.Name = "colCashReceiptTypeText";
            this.colCashReceiptTypeText.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.dgvDetail);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(972, 155);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lstBxSalesInvoices);
            this.groupBox3.Location = new System.Drawing.Point(726, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 126);
            this.groupBox3.TabIndex = 180;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sales Invoices";
            // 
            // lstBxSalesInvoices
            // 
            this.lstBxSalesInvoices.DisplayMember = "InvoiceNo";
            this.lstBxSalesInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBxSalesInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBxSalesInvoices.FormattingEnabled = true;
            this.lstBxSalesInvoices.ItemHeight = 16;
            this.lstBxSalesInvoices.Location = new System.Drawing.Point(3, 16);
            this.lstBxSalesInvoices.Name = "lstBxSalesInvoices";
            this.lstBxSalesInvoices.Size = new System.Drawing.Size(234, 107);
            this.lstBxSalesInvoices.TabIndex = 0;
            this.lstBxSalesInvoices.ValueMember = "InvoiceID";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetailTotalAmt,
            this.colDetailCommDisAmt,
            this.colDetailOtherAmt,
            this.colDetailPaidAmt,
            this.colDetailBalanceAmt});
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle40;
            this.dgvDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDetail.Location = new System.Drawing.Point(6, 21);
            this.dgvDetail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersWidth = 50;
            this.dgvDetail.RowTemplate.Height = 28;
            this.dgvDetail.Size = new System.Drawing.Size(713, 126);
            this.dgvDetail.TabIndex = 179;
            // 
            // colDetailTotalAmt
            // 
            this.colDetailTotalAmt.DataPropertyName = "TotalAmt";
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle35.Format = "N0";
            this.colDetailTotalAmt.DefaultCellStyle = dataGridViewCellStyle35;
            this.colDetailTotalAmt.HeaderText = "အရောင်းကျသင့်ငွေ";
            this.colDetailTotalAmt.Name = "colDetailTotalAmt";
            this.colDetailTotalAmt.ReadOnly = true;
            this.colDetailTotalAmt.Width = 150;
            // 
            // colDetailCommDisAmt
            // 
            this.colDetailCommDisAmt.DataPropertyName = "CommDisAmt";
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle36.Format = "N0";
            this.colDetailCommDisAmt.DefaultCellStyle = dataGridViewCellStyle36;
            this.colDetailCommDisAmt.HeaderText = "ခံစားခွင့်/လျော့စျေး";
            this.colDetailCommDisAmt.Name = "colDetailCommDisAmt";
            this.colDetailCommDisAmt.ReadOnly = true;
            this.colDetailCommDisAmt.Width = 150;
            // 
            // colDetailOtherAmt
            // 
            this.colDetailOtherAmt.DataPropertyName = "OtherAmt";
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle37.Format = "N0";
            this.colDetailOtherAmt.DefaultCellStyle = dataGridViewCellStyle37;
            this.colDetailOtherAmt.HeaderText = "အခြားကုန်ကျငွေ";
            this.colDetailOtherAmt.Name = "colDetailOtherAmt";
            this.colDetailOtherAmt.ReadOnly = true;
            this.colDetailOtherAmt.Width = 150;
            // 
            // colDetailPaidAmt
            // 
            this.colDetailPaidAmt.DataPropertyName = "PaidAmt";
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle38.Format = "N0";
            this.colDetailPaidAmt.DefaultCellStyle = dataGridViewCellStyle38;
            this.colDetailPaidAmt.HeaderText = "ပေးချေငွေ";
            this.colDetailPaidAmt.Name = "colDetailPaidAmt";
            this.colDetailPaidAmt.ReadOnly = true;
            // 
            // colDetailBalanceAmt
            // 
            this.colDetailBalanceAmt.DataPropertyName = "BalanceAmt";
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle39.Format = "N0";
            this.colDetailBalanceAmt.DefaultCellStyle = dataGridViewCellStyle39;
            this.colDetailBalanceAmt.HeaderText = "ကျန်ငွေ";
            this.colDetailBalanceAmt.Name = "colDetailBalanceAmt";
            this.colDetailBalanceAmt.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chkCustomerName);
            this.panel1.Controls.Add(this.cmbCustomer);
            this.panel1.Controls.Add(this.chkDepartment);
            this.panel1.Controls.Add(this.cmbDepartment);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblFrom);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 100);
            this.panel1.TabIndex = 1;
            // 
            // chkCustomerName
            // 
            this.chkCustomerName.AutoSize = true;
            this.chkCustomerName.Location = new System.Drawing.Point(210, 13);
            this.chkCustomerName.Name = "chkCustomerName";
            this.chkCustomerName.Size = new System.Drawing.Size(128, 24);
            this.chkCustomerName.TabIndex = 227;
            this.chkCustomerName.Text = "Customer အမည်";
            this.chkCustomerName.UseVisualStyleBackColor = true;
            this.chkCustomerName.CheckedChanged += new System.EventHandler(this.chkCustomerName_CheckedChanged);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.DisplayMember = "CusName";
            this.cmbCustomer.Enabled = false;
            this.cmbCustomer.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(340, 12);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(150, 27);
            this.cmbCustomer.TabIndex = 226;
            this.cmbCustomer.ValueMember = "CustomerID";
            // 
            // chkDepartment
            // 
            this.chkDepartment.AutoSize = true;
            this.chkDepartment.Location = new System.Drawing.Point(210, 51);
            this.chkDepartment.Name = "chkDepartment";
            this.chkDepartment.Size = new System.Drawing.Size(89, 24);
            this.chkDepartment.TabIndex = 225;
            this.chkDepartment.Text = "ဌာနအမည်";
            this.chkDepartment.UseVisualStyleBackColor = true;
            this.chkDepartment.CheckedChanged += new System.EventHandler(this.chkDepartment_CheckedChanged);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDepartment.DisplayMember = "DeptName";
            this.cmbDepartment.Enabled = false;
            this.cmbDepartment.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(340, 49);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(150, 27);
            this.cmbDepartment.TabIndex = 224;
            this.cmbDepartment.ValueMember = "ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 20);
            this.label8.TabIndex = 223;
            this.label8.Text = "နေ့စွဲ";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSearch.Location = new System.Drawing.Point(515, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 30);
            this.btnSearch.TabIndex = 222;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label3.Location = new System.Drawing.Point(183, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.TabIndex = 221;
            this.label3.Text = "ထိ";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.lblFrom.Location = new System.Drawing.Point(186, 13);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(18, 20);
            this.lblFrom.TabIndex = 220;
            this.lblFrom.Text = "မှ";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(49, 46);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowCheckBox = true;
            this.dtpEndDate.Size = new System.Drawing.Size(128, 28);
            this.dtpEndDate.TabIndex = 219;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(49, 12);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.ShowCheckBox = true;
            this.dtpStartDate.Size = new System.Drawing.Size(128, 28);
            this.dtpStartDate.TabIndex = 218;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // frmReceiptVoucherList_MultipleInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 531);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panel2);
            this.Name = "frmReceiptVoucherList_MultipleInvoices";
            this.Text = "Receipt List (Multiple Invoices)";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipt)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvReceipt;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstBxSalesInvoices;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColSaleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommDisAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOtherAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaidAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalanceAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTripRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownTownship;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCashReceiptType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayTypeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCashReceiptTypeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailTotalAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailCommDisAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailOtherAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailPaidAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailBalanceAmt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkCustomerName;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.CheckBox chkDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
    }
}