namespace PTIC.Sale.OfficeSales
{
    partial class frmDailySales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPageSize = new AGL.UI.Controls.EditTextBox();
            this.btnFillGrid = new System.Windows.Forms.Button();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.chkCustomerName = new System.Windows.Forms.CheckBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.chkEmployee = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpOrderEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpOrderStart = new System.Windows.Forms.DateTimePicker();
            this.dgvDailySales = new System.Windows.Forms.DataGridView();
            this.dgvSalesDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVanNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailySales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPageSize
            // 
            this.txtPageSize.ErrorColor = System.Drawing.Color.Empty;
            this.txtPageSize.ErrorMessage = "Page size must be integer and greater than zero!";
            this.txtPageSize.Location = new System.Drawing.Point(274, 0);
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(56, 25);
            this.txtPageSize.TabIndex = 18;
            this.txtPageSize.Text = "15";
            // 
            // btnFillGrid
            // 
            this.btnFillGrid.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFillGrid.Location = new System.Drawing.Point(336, 3);
            this.btnFillGrid.Name = "btnFillGrid";
            this.btnFillGrid.Size = new System.Drawing.Size(56, 23);
            this.btnFillGrid.TabIndex = 14;
            this.btnFillGrid.Text = "Fill Grid";
            this.btnFillGrid.Visible = false;
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(200, 4);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(85, 19);
            this.lblPageSize.TabIndex = 17;
            this.lblPageSize.Text = "Page Size:";
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Enabled = false;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatus.Location = new System.Drawing.Point(55, 4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(85, 20);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "0 / 0";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLast
            // 
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLast.Location = new System.Drawing.Point(166, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(24, 23);
            this.btnLast.TabIndex = 13;
            this.btnLast.Text = ">|";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtPageSize);
            this.panel2.Controls.Add(this.btnFillGrid);
            this.panel2.Controls.Add(this.lblPageSize);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.btnLast);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnPrevious);
            this.panel2.Controls.Add(this.btnFirst);
            this.panel2.Location = new System.Drawing.Point(16, 357);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1001, 30);
            this.panel2.TabIndex = 202;
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNext.Location = new System.Drawing.Point(142, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = ">";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Enabled = false;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrevious.Location = new System.Drawing.Point(30, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(24, 23);
            this.btnPrevious.TabIndex = 11;
            this.btnPrevious.Text = "<";
            // 
            // btnFirst
            // 
            this.btnFirst.Enabled = false;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFirst.Location = new System.Drawing.Point(6, 3);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(24, 23);
            this.btnFirst.TabIndex = 10;
            this.btnFirst.Text = "|<";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblDelivery);
            this.panel1.Controls.Add(this.lblBrand);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 41);
            this.panel1.TabIndex = 198;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.MediumBlue;
            this.label7.Location = new System.Drawing.Point(93, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = ">";
            // 
            // lblDelivery
            // 
            this.lblDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDelivery.AutoSize = true;
            this.lblDelivery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDelivery.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelivery.Location = new System.Drawing.Point(10, 9);
            this.lblDelivery.Name = "lblDelivery";
            this.lblDelivery.Size = new System.Drawing.Size(54, 19);
            this.lblDelivery.TabIndex = 4;
            this.lblDelivery.Text = "Sales";
            // 
            // lblBrand
            // 
            this.lblBrand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblBrand.Location = new System.Drawing.Point(131, 9);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(104, 19);
            this.lblBrand.TabIndex = 3;
            this.lblBrand.Text = "Daily Sales";
            // 
            // chkCustomerName
            // 
            this.chkCustomerName.AutoSize = true;
            this.chkCustomerName.Location = new System.Drawing.Point(220, 86);
            this.chkCustomerName.Name = "chkCustomerName";
            this.chkCustomerName.Size = new System.Drawing.Size(129, 23);
            this.chkCustomerName.TabIndex = 212;
            this.chkCustomerName.Text = "Customer အမည်";
            this.chkCustomerName.UseVisualStyleBackColor = true;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.DisplayMember = "CusName";
            this.cmbCustomer.Enabled = false;
            this.cmbCustomer.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(350, 85);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(150, 25);
            this.cmbCustomer.TabIndex = 211;
            this.cmbCustomer.ValueMember = "CustomerID";
            // 
            // chkEmployee
            // 
            this.chkEmployee.AutoSize = true;
            this.chkEmployee.Location = new System.Drawing.Point(220, 54);
            this.chkEmployee.Name = "chkEmployee";
            this.chkEmployee.Size = new System.Drawing.Size(114, 23);
            this.chkEmployee.TabIndex = 210;
            this.chkEmployee.Text = "အရောင်းဝန်ထမ်း";
            this.chkEmployee.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 19);
            this.label8.TabIndex = 208;
            this.label8.Text = "နေ့စွဲ";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSearch.Location = new System.Drawing.Point(525, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 30);
            this.btnSearch.TabIndex = 207;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label2.Location = new System.Drawing.Point(193, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 19);
            this.label2.TabIndex = 206;
            this.label2.Text = "ထိ";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.lblFrom.Location = new System.Drawing.Point(196, 54);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(17, 19);
            this.lblFrom.TabIndex = 205;
            this.lblFrom.Text = "မှ";
            // 
            // dtpOrderEnd
            // 
            this.dtpOrderEnd.CustomFormat = "dd-MMM-yyyy";
            this.dtpOrderEnd.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrderEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderEnd.Location = new System.Drawing.Point(59, 87);
            this.dtpOrderEnd.Name = "dtpOrderEnd";
            this.dtpOrderEnd.ShowCheckBox = true;
            this.dtpOrderEnd.Size = new System.Drawing.Size(128, 25);
            this.dtpOrderEnd.TabIndex = 204;
            // 
            // dtpOrderStart
            // 
            this.dtpOrderStart.CustomFormat = "dd-MMM-yyyy";
            this.dtpOrderStart.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrderStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderStart.Location = new System.Drawing.Point(59, 53);
            this.dtpOrderStart.Name = "dtpOrderStart";
            this.dtpOrderStart.ShowCheckBox = true;
            this.dtpOrderStart.Size = new System.Drawing.Size(128, 25);
            this.dtpOrderStart.TabIndex = 203;
            // 
            // dgvDailySales
            // 
            this.dgvDailySales.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDailySales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDailySales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDailySales.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDailySales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDailySales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDailySales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSalesDate,
            this.colID,
            this.colEmpName,
            this.colTown,
            this.colCustomerName,
            this.colSalesType,
            this.colInvoiceNo,
            this.colVanNo,
            this.colTotalAmt});
            this.dgvDailySales.Location = new System.Drawing.Point(16, 121);
            this.dgvDailySales.MultiSelect = false;
            this.dgvDailySales.Name = "dgvDailySales";
            this.dgvDailySales.ReadOnly = true;
            this.dgvDailySales.RowHeadersVisible = false;
            this.dgvDailySales.RowHeadersWidth = 50;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvDailySales.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDailySales.RowTemplate.Height = 28;
            this.dgvDailySales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDailySales.Size = new System.Drawing.Size(1001, 235);
            this.dgvDailySales.TabIndex = 199;
            this.dgvDailySales.SelectionChanged += new System.EventHandler(this.dgvDailySales_SelectionChanged);
            // 
            // dgvSalesDetails
            // 
            this.dgvSalesDetails.AllowUserToAddRows = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSalesDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSalesDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalesDetails.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSalesDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductID,
            this.colProductName,
            this.colPrice,
            this.colQty,
            this.colAmount});
            this.dgvSalesDetails.Location = new System.Drawing.Point(16, 427);
            this.dgvSalesDetails.Name = "dgvSalesDetails";
            this.dgvSalesDetails.ReadOnly = true;
            this.dgvSalesDetails.RowHeadersWidth = 50;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvSalesDetails.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSalesDetails.RowTemplate.Height = 28;
            this.dgvSalesDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesDetails.Size = new System.Drawing.Size(1001, 234);
            this.dgvSalesDetails.TabIndex = 201;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(17, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 200;
            this.label1.Text = "ပစ္စည်းစာရင်း";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmployee.DisplayMember = "EmpName";
            this.cmbEmployee.Enabled = false;
            this.cmbEmployee.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(350, 52);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(150, 25);
            this.cmbEmployee.TabIndex = 209;
            this.cmbEmployee.ValueMember = "EmployeeID";
            // 
            // colProductID
            // 
            this.colProductID.DataPropertyName = "ProductID";
            this.colProductID.HeaderText = "Product ID";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Visible = false;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "ထုတ်ကုန်အမည်";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 150;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "Price";
            this.colPrice.HeaderText = "ရောင်းဈေး";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQty.DefaultCellStyle = dataGridViewCellStyle7;
            this.colQty.HeaderText = "အ‌ရေအတွက်";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colSalesDate
            // 
            this.colSalesDate.DataPropertyName = "SalesDate";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colSalesDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSalesDate.HeaderText = "Date";
            this.colSalesDate.Name = "colSalesDate";
            this.colSalesDate.ReadOnly = true;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colEmpName
            // 
            this.colEmpName.DataPropertyName = "EmpName";
            this.colEmpName.HeaderText = "ဝန်ထမ်းအမည်";
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.ReadOnly = true;
            this.colEmpName.Width = 120;
            // 
            // colTown
            // 
            this.colTown.DataPropertyName = "TOWN";
            this.colTown.HeaderText = "မြို့/မြို့နယ်";
            this.colTown.Name = "colTown";
            this.colTown.ReadOnly = true;
            // 
            // colCustomerName
            // 
            this.colCustomerName.DataPropertyName = "CusName";
            this.colCustomerName.HeaderText = "Customer အမည်";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            // 
            // colSalesType
            // 
            this.colSalesType.DataPropertyName = "SalesType";
            this.colSalesType.HeaderText = "Sales Type";
            this.colSalesType.Name = "colSalesType";
            this.colSalesType.ReadOnly = true;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.DataPropertyName = "InvoiceNo";
            this.colInvoiceNo.HeaderText = "Invoice No";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.ReadOnly = true;
            this.colInvoiceNo.Width = 180;
            // 
            // colVanNo
            // 
            this.colVanNo.DataPropertyName = "VanNo";
            this.colVanNo.HeaderText = "Van No";
            this.colVanNo.Name = "colVanNo";
            this.colVanNo.ReadOnly = true;
            // 
            // colTotalAmt
            // 
            this.colTotalAmt.DataPropertyName = "TotalAmt";
            this.colTotalAmt.HeaderText = "Amount";
            this.colTotalAmt.Name = "colTotalAmt";
            this.colTotalAmt.ReadOnly = true;
            // 
            // frmDailySales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 663);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkCustomerName);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.chkEmployee);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtpOrderEnd);
            this.Controls.Add(this.dtpOrderStart);
            this.Controls.Add(this.dgvDailySales);
            this.Controls.Add(this.dgvSalesDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEmployee);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDailySales";
            this.Text = "frmDailySales";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailySales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AGL.UI.Controls.EditTextBox txtPageSize;
        private System.Windows.Forms.Button btnFillGrid;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDelivery;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.CheckBox chkCustomerName;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.CheckBox chkEmployee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpOrderEnd;
        private System.Windows.Forms.DateTimePicker dtpOrderStart;
        private System.Windows.Forms.DataGridView dgvDailySales;
        private System.Windows.Forms.DataGridView dgvSalesDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVanNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmt;
    }
}