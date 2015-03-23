namespace PTIC.VC.Sale.OfficeSales
{
    partial class frmCashSalesInvoices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInvoice = new System.Windows.Forms.DataGridView();
            this.dgvSaleDetail = new System.Windows.Forms.DataGridView();
            this.clnBrandName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPackage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColRetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColWholeSale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColCusType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColNoPerPack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.chkCustomerName = new System.Windows.Forms.CheckBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.chkEmployee = new System.Windows.Forms.CheckBox();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpOrderEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpOrderStart = new System.Windows.Forms.DateTimePicker();
            this.colInvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalCommAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalTaxAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNetAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleDetail)).BeginInit();
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
            this.panel2.Size = new System.Drawing.Size(983, 48);
            this.panel2.TabIndex = 169;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(13, 14);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(54, 19);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Sales";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(69, 14);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(165, 19);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">    Cash Sales List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(12, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 19);
            this.label1.TabIndex = 172;
            this.label1.Text = "Cash Sales List";
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.AllowUserToDeleteRows = false;
            this.dgvInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoice.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInvoiceID,
            this.colSalesDate,
            this.colInvoiceNo,
            this.colCusName,
            this.colEmpName,
            this.colTotalAmt,
            this.colTotalCommAmt,
            this.colTotalTaxAmt,
            this.colNetAmt,
            this.colRemark});
            this.dgvInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvInvoice.Location = new System.Drawing.Point(12, 159);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoice.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvInvoice.RowHeadersWidth = 50;
            this.dgvInvoice.RowTemplate.Height = 28;
            this.dgvInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoice.Size = new System.Drawing.Size(959, 253);
            this.dgvInvoice.TabIndex = 173;
            this.dgvInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoice_CellClick);
            this.dgvInvoice.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvInvoice_DataBindingComplete);
            // 
            // dgvSaleDetail
            // 
            this.dgvSaleDetail.AllowUserToAddRows = false;
            this.dgvSaleDetail.AllowUserToDeleteRows = false;
            this.dgvSaleDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSaleDetail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaleDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSaleDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnBrandName,
            this.clnProductName,
            this.clnPrice,
            this.clnQty,
            this.clnPackage,
            this.clnAmount,
            this.dgvColRetailPrice,
            this.dgvColWholeSale,
            this.dgvColCusType,
            this.dgvColNoPerPack});
            this.dgvSaleDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSaleDetail.Location = new System.Drawing.Point(12, 453);
            this.dgvSaleDetail.Name = "dgvSaleDetail";
            this.dgvSaleDetail.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSaleDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvSaleDetail.RowHeadersWidth = 50;
            this.dgvSaleDetail.RowTemplate.Height = 28;
            this.dgvSaleDetail.Size = new System.Drawing.Size(959, 275);
            this.dgvSaleDetail.TabIndex = 174;
            this.dgvSaleDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSaleDetail_DataBindingComplete);
            // 
            // clnBrandName
            // 
            this.clnBrandName.DataPropertyName = "BrandName";
            this.clnBrandName.HeaderText = "အမှတ်တံဆိပ်အမည်";
            this.clnBrandName.Name = "clnBrandName";
            this.clnBrandName.ReadOnly = true;
            this.clnBrandName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnBrandName.Width = 120;
            // 
            // clnProductName
            // 
            this.clnProductName.DataPropertyName = "ProductName";
            this.clnProductName.HeaderText = "ထုတ်ကုန်အမည်";
            this.clnProductName.Name = "clnProductName";
            this.clnProductName.ReadOnly = true;
            this.clnProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnProductName.Width = 150;
            // 
            // clnPrice
            // 
            this.clnPrice.DataPropertyName = "SalePrice";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.clnPrice.DefaultCellStyle = dataGridViewCellStyle9;
            this.clnPrice.HeaderText = "‌ရောင်း‌ဈေး";
            this.clnPrice.Name = "clnPrice";
            this.clnPrice.ReadOnly = true;
            this.clnPrice.Width = 150;
            // 
            // clnQty
            // 
            this.clnQty.DataPropertyName = "Qty";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clnQty.DefaultCellStyle = dataGridViewCellStyle10;
            this.clnQty.HeaderText = "အ‌ရေအတွက်";
            this.clnQty.Name = "clnQty";
            this.clnQty.ReadOnly = true;
            // 
            // clnPackage
            // 
            this.clnPackage.DataPropertyName = "Package";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clnPackage.DefaultCellStyle = dataGridViewCellStyle11;
            this.clnPackage.HeaderText = "Package";
            this.clnPackage.Name = "clnPackage";
            this.clnPackage.ReadOnly = true;
            // 
            // clnAmount
            // 
            this.clnAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N0";
            dataGridViewCellStyle12.NullValue = null;
            this.clnAmount.DefaultCellStyle = dataGridViewCellStyle12;
            this.clnAmount.HeaderText = "ကျသင့်‌ငွေ";
            this.clnAmount.Name = "clnAmount";
            this.clnAmount.ReadOnly = true;
            this.clnAmount.Width = 150;
            // 
            // dgvColRetailPrice
            // 
            this.dgvColRetailPrice.DataPropertyName = "RSPrice";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N0";
            this.dgvColRetailPrice.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvColRetailPrice.HeaderText = "RetailPrice";
            this.dgvColRetailPrice.Name = "dgvColRetailPrice";
            this.dgvColRetailPrice.ReadOnly = true;
            this.dgvColRetailPrice.Visible = false;
            // 
            // dgvColWholeSale
            // 
            this.dgvColWholeSale.DataPropertyName = "WSPrice";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvColWholeSale.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvColWholeSale.HeaderText = "WholeSale";
            this.dgvColWholeSale.Name = "dgvColWholeSale";
            this.dgvColWholeSale.ReadOnly = true;
            this.dgvColWholeSale.Visible = false;
            // 
            // dgvColCusType
            // 
            this.dgvColCusType.DataPropertyName = "CusTypeID";
            this.dgvColCusType.HeaderText = "CusType";
            this.dgvColCusType.Name = "dgvColCusType";
            this.dgvColCusType.ReadOnly = true;
            this.dgvColCusType.Visible = false;
            // 
            // dgvColNoPerPack
            // 
            this.dgvColNoPerPack.DataPropertyName = "NoPerPack";
            this.dgvColNoPerPack.HeaderText = "NoPerPack";
            this.dgvColNoPerPack.Name = "dgvColNoPerPack";
            this.dgvColNoPerPack.ReadOnly = true;
            this.dgvColNoPerPack.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(12, 430);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 175;
            this.label2.Text = "ပစ္စည်းစာရင်း";
            // 
            // chkCustomerName
            // 
            this.chkCustomerName.AutoSize = true;
            this.chkCustomerName.Location = new System.Drawing.Point(216, 87);
            this.chkCustomerName.Name = "chkCustomerName";
            this.chkCustomerName.Size = new System.Drawing.Size(129, 23);
            this.chkCustomerName.TabIndex = 207;
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
            this.cmbCustomer.Location = new System.Drawing.Point(346, 86);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(150, 25);
            this.cmbCustomer.TabIndex = 206;
            this.cmbCustomer.ValueMember = "CustomerID";
            // 
            // chkEmployee
            // 
            this.chkEmployee.AutoSize = true;
            this.chkEmployee.Location = new System.Drawing.Point(216, 55);
            this.chkEmployee.Name = "chkEmployee";
            this.chkEmployee.Size = new System.Drawing.Size(114, 23);
            this.chkEmployee.TabIndex = 205;
            this.chkEmployee.Text = "အရောင်းဝန်ထမ်း";
            this.chkEmployee.UseVisualStyleBackColor = true;
            this.chkEmployee.CheckedChanged += new System.EventHandler(this.chkEmployee_CheckedChanged);
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmployee.DisplayMember = "EmpName";
            this.cmbEmployee.Enabled = false;
            this.cmbEmployee.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(346, 53);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(150, 25);
            this.cmbEmployee.TabIndex = 204;
            this.cmbEmployee.ValueMember = "EmployeeID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 19);
            this.label8.TabIndex = 203;
            this.label8.Text = "နေ့စွဲ";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSearch.Location = new System.Drawing.Point(521, 51);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 30);
            this.btnSearch.TabIndex = 202;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label3.Location = new System.Drawing.Point(189, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 19);
            this.label3.TabIndex = 201;
            this.label3.Text = "ထိ";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.lblFrom.Location = new System.Drawing.Point(192, 55);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(17, 19);
            this.lblFrom.TabIndex = 200;
            this.lblFrom.Text = "မှ";
            // 
            // dtpOrderEnd
            // 
            this.dtpOrderEnd.CustomFormat = "dd-MMM-yyyy";
            this.dtpOrderEnd.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrderEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderEnd.Location = new System.Drawing.Point(55, 88);
            this.dtpOrderEnd.Name = "dtpOrderEnd";
            this.dtpOrderEnd.ShowCheckBox = true;
            this.dtpOrderEnd.Size = new System.Drawing.Size(128, 25);
            this.dtpOrderEnd.TabIndex = 199;
            this.dtpOrderEnd.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dtpOrderStart
            // 
            this.dtpOrderStart.CustomFormat = "dd-MMM-yyyy";
            this.dtpOrderStart.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrderStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderStart.Location = new System.Drawing.Point(55, 54);
            this.dtpOrderStart.Name = "dtpOrderStart";
            this.dtpOrderStart.ShowCheckBox = true;
            this.dtpOrderStart.Size = new System.Drawing.Size(128, 25);
            this.dtpOrderStart.TabIndex = 198;
            this.dtpOrderStart.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // colInvoiceID
            // 
            this.colInvoiceID.DataPropertyName = "InvoiceID";
            this.colInvoiceID.HeaderText = "InvoiceID";
            this.colInvoiceID.Name = "colInvoiceID";
            this.colInvoiceID.ReadOnly = true;
            this.colInvoiceID.Visible = false;
            // 
            // colSalesDate
            // 
            this.colSalesDate.DataPropertyName = "SalesDate";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.colSalesDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSalesDate.HeaderText = "‌ရောင်းချခဲ့သည့်‌နေ့";
            this.colSalesDate.Name = "colSalesDate";
            this.colSalesDate.ReadOnly = true;
            this.colSalesDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSalesDate.Width = 110;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.DataPropertyName = "InvoiceNo";
            this.colInvoiceNo.HeaderText = "Invoice No";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.ReadOnly = true;
            // 
            // colCusName
            // 
            this.colCusName.DataPropertyName = "CusName";
            this.colCusName.HeaderText = "Customer အမည်";
            this.colCusName.Name = "colCusName";
            this.colCusName.ReadOnly = true;
            // 
            // colEmpName
            // 
            this.colEmpName.DataPropertyName = "EmpName";
            this.colEmpName.HeaderText = "‌ငွေလက်ခံဝန်ထမ်းအမည်";
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.ReadOnly = true;
            this.colEmpName.Width = 150;
            // 
            // colTotalAmt
            // 
            this.colTotalAmt.DataPropertyName = "TotalAmt";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.colTotalAmt.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTotalAmt.HeaderText = "ကျသင့်‌ငွေ";
            this.colTotalAmt.Name = "colTotalAmt";
            this.colTotalAmt.ReadOnly = true;
            // 
            // colTotalCommAmt
            // 
            this.colTotalCommAmt.DataPropertyName = "TotalCommAmt";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.colTotalCommAmt.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTotalCommAmt.HeaderText = "ခံစားခွင့်/‌လျှော့‌ဈေး";
            this.colTotalCommAmt.Name = "colTotalCommAmt";
            this.colTotalCommAmt.ReadOnly = true;
            this.colTotalCommAmt.Width = 120;
            // 
            // colTotalTaxAmt
            // 
            this.colTotalTaxAmt.DataPropertyName = "TotalTaxAmt";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.colTotalTaxAmt.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTotalTaxAmt.HeaderText = "အခြားကျသင့်‌ငွေ";
            this.colTotalTaxAmt.Name = "colTotalTaxAmt";
            this.colTotalTaxAmt.ReadOnly = true;
            // 
            // colNetAmt
            // 
            this.colNetAmt.DataPropertyName = "NetAmt";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.colNetAmt.DefaultCellStyle = dataGridViewCellStyle6;
            this.colNetAmt.HeaderText = "အသားတင်ကျသင့်‌ငွေ";
            this.colNetAmt.Name = "colNetAmt";
            this.colNetAmt.ReadOnly = true;
            this.colNetAmt.Width = 125;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            // 
            // frmCashSalesInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 743);
            this.Controls.Add(this.chkCustomerName);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.chkEmployee);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtpOrderEnd);
            this.Controls.Add(this.dtpOrderStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvSaleDetail);
            this.Controls.Add(this.dgvInvoice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmCashSalesInvoices";
            this.Text = "Cash Sales List";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInvoice;
        private System.Windows.Forms.DataGridView dgvSaleDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBrandName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPackage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColRetailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColWholeSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColCusType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColNoPerPack;
        private System.Windows.Forms.CheckBox chkCustomerName;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.CheckBox chkEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpOrderEnd;
        private System.Windows.Forms.DateTimePicker dtpOrderStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCommAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalTaxAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNetAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;

    }
}