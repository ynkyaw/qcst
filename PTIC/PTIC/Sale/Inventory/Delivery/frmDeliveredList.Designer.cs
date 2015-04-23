namespace PTIC.Sale.Delivery
{
    partial class frmDeliveredList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.dgvDeliveredOrders = new System.Windows.Forms.DataGridView();
            this.colDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVenNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderDate = new AGL.UI.Controls.CalendarColumn();
            this.colOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRouteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTripName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsDelivered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDeliveryDetails = new System.Windows.Forms.DataGridView();
            this.colDeliveryDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailDeliveryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPageSize = new AGL.UI.Controls.EditTextBox();
            this.btnFillGrid = new System.Windows.Forms.Button();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpOrderEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpOrderStart = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.chkCustomerName = new System.Windows.Forms.CheckBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.chkEmployee = new System.Windows.Forms.CheckBox();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveredOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryDetails)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.TabIndex = 6;
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
            this.label7.Size = new System.Drawing.Size(19, 20);
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
            this.lblDelivery.Size = new System.Drawing.Size(71, 20);
            this.lblDelivery.TabIndex = 4;
            this.lblDelivery.Text = "Delivery";
            this.lblDelivery.Click += new System.EventHandler(this.lblDelivery_Click);
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
            this.lblBrand.Size = new System.Drawing.Size(88, 20);
            this.lblBrand.TabIndex = 3;
            this.lblBrand.Text = "ပို့ပြီး စာရင်း";
            // 
            // dgvDeliveredOrders
            // 
            this.dgvDeliveredOrders.AllowUserToAddRows = false;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDeliveredOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvDeliveredOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeliveredOrders.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeliveredOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvDeliveredOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeliveredOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeliveryDate,
            this.colDeliveryNo,
            this.colEmpName,
            this.colGateName,
            this.colDeliveryID,
            this.colVenNo,
            this.colOrderID,
            this.colOrderDate,
            this.colOrderNo,
            this.colCusName,
            this.colTown,
            this.colRouteName,
            this.colTripName,
            this.colIsDelivered,
            this.colStatus});
            this.dgvDeliveredOrders.Location = new System.Drawing.Point(16, 120);
            this.dgvDeliveredOrders.MultiSelect = false;
            this.dgvDeliveredOrders.Name = "dgvDeliveredOrders";
            this.dgvDeliveredOrders.ReadOnly = true;
            this.dgvDeliveredOrders.RowHeadersWidth = 50;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvDeliveredOrders.RowsDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvDeliveredOrders.RowTemplate.Height = 28;
            this.dgvDeliveredOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeliveredOrders.Size = new System.Drawing.Size(1001, 235);
            this.dgvDeliveredOrders.TabIndex = 99;
            this.dgvDeliveredOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdeliveredOrders_CellClick);
            this.dgvDeliveredOrders.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDeliveredOrders_DataBindingComplete);
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.DataPropertyName = "DeliveryDate";
            dataGridViewCellStyle21.Format = "d";
            dataGridViewCellStyle21.NullValue = null;
            this.colDeliveryDate.DefaultCellStyle = dataGridViewCellStyle21;
            this.colDeliveryDate.HeaderText = "Delivery Date";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.ReadOnly = true;
            // 
            // colDeliveryNo
            // 
            this.colDeliveryNo.DataPropertyName = "DeliveryNo";
            this.colDeliveryNo.HeaderText = "Delivery No";
            this.colDeliveryNo.Name = "colDeliveryNo";
            this.colDeliveryNo.ReadOnly = true;
            // 
            // colEmpName
            // 
            this.colEmpName.DataPropertyName = "EmpName";
            this.colEmpName.HeaderText = "အ‌ရောင်းဝန်ထမ်း";
            this.colEmpName.Name = "colEmpName";
            this.colEmpName.ReadOnly = true;
            this.colEmpName.Width = 120;
            // 
            // colGateName
            // 
            this.colGateName.DataPropertyName = "GateName";
            this.colGateName.HeaderText = "ဂိတ်အမည်";
            this.colGateName.Name = "colGateName";
            this.colGateName.ReadOnly = true;
            // 
            // colDeliveryID
            // 
            this.colDeliveryID.DataPropertyName = "DeliveryID";
            this.colDeliveryID.HeaderText = "DeliveryID";
            this.colDeliveryID.Name = "colDeliveryID";
            this.colDeliveryID.ReadOnly = true;
            this.colDeliveryID.Visible = false;
            // 
            // colVenNo
            // 
            this.colVenNo.DataPropertyName = "VenNo";
            this.colVenNo.HeaderText = "Van No";
            this.colVenNo.Name = "colVenNo";
            this.colVenNo.ReadOnly = true;
            // 
            // colOrderID
            // 
            this.colOrderID.DataPropertyName = "OrderID";
            this.colOrderID.HeaderText = "Order ID";
            this.colOrderID.Name = "colOrderID";
            this.colOrderID.ReadOnly = true;
            this.colOrderID.Visible = false;
            // 
            // colOrderDate
            // 
            this.colOrderDate.DataPropertyName = "OrderDate";
            this.colOrderDate.HeaderText = "Order ‌နေ့စွဲ";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.ReadOnly = true;
            this.colOrderDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOrderDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colOrderDate.Width = 150;
            // 
            // colOrderNo
            // 
            this.colOrderNo.DataPropertyName = "OrderNo";
            this.colOrderNo.HeaderText = "Order No.";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.ReadOnly = true;
            // 
            // colCusName
            // 
            this.colCusName.DataPropertyName = "CusName";
            this.colCusName.HeaderText = "Customer အမည်";
            this.colCusName.Name = "colCusName";
            this.colCusName.ReadOnly = true;
            // 
            // colTown
            // 
            this.colTown.DataPropertyName = "Town";
            this.colTown.HeaderText = "မြို့";
            this.colTown.Name = "colTown";
            this.colTown.ReadOnly = true;
            // 
            // colRouteName
            // 
            this.colRouteName.DataPropertyName = "RouteName";
            this.colRouteName.HeaderText = "လမ်း‌ကြောင်း";
            this.colRouteName.Name = "colRouteName";
            this.colRouteName.ReadOnly = true;
            // 
            // colTripName
            // 
            this.colTripName.DataPropertyName = "TripName";
            this.colTripName.HeaderText = "ခရီးစဉ်";
            this.colTripName.Name = "colTripName";
            this.colTripName.ReadOnly = true;
            this.colTripName.Width = 180;
            // 
            // colIsDelivered
            // 
            this.colIsDelivered.DataPropertyName = "IsDelivered";
            this.colIsDelivered.HeaderText = "Is Delivered";
            this.colIsDelivered.Name = "colIsDelivered";
            this.colIsDelivered.ReadOnly = true;
            this.colIsDelivered.Visible = false;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(17, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 100;
            this.label1.Text = "ပို့ပြီးပစ္စည်းစာရင်း";
            // 
            // dgvDeliveryDetails
            // 
            this.dgvDeliveryDetails.AllowUserToAddRows = false;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDeliveryDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle23;
            this.dgvDeliveryDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeliveryDetails.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeliveryDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvDeliveryDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeliveryDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeliveryDetailID,
            this.colDetailDeliveryID,
            this.colProductID,
            this.colProductName,
            this.colQty,
            this.colDeliveryQty,
            this.colRemark});
            this.dgvDeliveryDetails.Location = new System.Drawing.Point(16, 426);
            this.dgvDeliveryDetails.Name = "dgvDeliveryDetails";
            this.dgvDeliveryDetails.ReadOnly = true;
            this.dgvDeliveryDetails.RowHeadersWidth = 50;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvDeliveryDetails.RowsDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvDeliveryDetails.RowTemplate.Height = 28;
            this.dgvDeliveryDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeliveryDetails.Size = new System.Drawing.Size(1001, 234);
            this.dgvDeliveryDetails.TabIndex = 101;
            this.dgvDeliveryDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDeliveryDetails_DataBindingComplete);
            // 
            // colDeliveryDetailID
            // 
            this.colDeliveryDetailID.HeaderText = "DeliveryDetailID";
            this.colDeliveryDetailID.Name = "colDeliveryDetailID";
            this.colDeliveryDetailID.ReadOnly = true;
            this.colDeliveryDetailID.Visible = false;
            // 
            // colDetailDeliveryID
            // 
            this.colDetailDeliveryID.HeaderText = "DeliveryID";
            this.colDetailDeliveryID.Name = "colDetailDeliveryID";
            this.colDetailDeliveryID.ReadOnly = true;
            this.colDetailDeliveryID.Visible = false;
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
            // 
            // colQty
            // 
            this.colQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colQty.DataPropertyName = "OrderQty";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQty.DefaultCellStyle = dataGridViewCellStyle25;
            this.colQty.HeaderText = "Order မှာသည့် အ‌ရေအတွက်";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            this.colQty.Width = 177;
            // 
            // colDeliveryQty
            // 
            this.colDeliveryQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colDeliveryQty.DataPropertyName = "DeliverQty";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDeliveryQty.DefaultCellStyle = dataGridViewCellStyle26;
            this.colDeliveryQty.HeaderText = "ပို့သည့်အ‌ရေအတွက်";
            this.colDeliveryQty.Name = "colDeliveryQty";
            this.colDeliveryQty.ReadOnly = true;
            this.colDeliveryQty.Width = 143;
            // 
            // colRemark
            // 
            this.colRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "မှတ်ချက်";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
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
            this.panel2.Location = new System.Drawing.Point(16, 356);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1001, 30);
            this.panel2.TabIndex = 172;
            // 
            // txtPageSize
            // 
            this.txtPageSize.ErrorColor = System.Drawing.Color.Empty;
            this.txtPageSize.ErrorMessage = "Page size must be integer and greater than zero!";
            this.txtPageSize.Location = new System.Drawing.Point(274, 0);
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(56, 28);
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
            this.btnFillGrid.Click += new System.EventHandler(this.btnFillGrid_Click);
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(200, 4);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(75, 20);
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
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNext.Location = new System.Drawing.Point(142, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
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
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
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
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSearch.Location = new System.Drawing.Point(525, 49);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 30);
            this.btnSearch.TabIndex = 177;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label2.Location = new System.Drawing.Point(193, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 176;
            this.label2.Text = "ထိ";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.lblFrom.Location = new System.Drawing.Point(196, 53);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(18, 20);
            this.lblFrom.TabIndex = 175;
            this.lblFrom.Text = "မှ";
            // 
            // dtpOrderEnd
            // 
            this.dtpOrderEnd.CustomFormat = "dd-MMM-yyyy";
            this.dtpOrderEnd.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrderEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderEnd.Location = new System.Drawing.Point(59, 86);
            this.dtpOrderEnd.Name = "dtpOrderEnd";
            this.dtpOrderEnd.ShowCheckBox = true;
            this.dtpOrderEnd.Size = new System.Drawing.Size(128, 28);
            this.dtpOrderEnd.TabIndex = 174;
            this.dtpOrderEnd.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dtpOrderStart
            // 
            this.dtpOrderStart.CustomFormat = "dd-MMM-yyyy";
            this.dtpOrderStart.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrderStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderStart.Location = new System.Drawing.Point(59, 52);
            this.dtpOrderStart.Name = "dtpOrderStart";
            this.dtpOrderStart.ShowCheckBox = true;
            this.dtpOrderStart.Size = new System.Drawing.Size(128, 28);
            this.dtpOrderStart.TabIndex = 173;
            this.dtpOrderStart.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 20);
            this.label8.TabIndex = 186;
            this.label8.Text = "နေ့စွဲ";
            // 
            // chkCustomerName
            // 
            this.chkCustomerName.AutoSize = true;
            this.chkCustomerName.Location = new System.Drawing.Point(220, 85);
            this.chkCustomerName.Name = "chkCustomerName";
            this.chkCustomerName.Size = new System.Drawing.Size(128, 24);
            this.chkCustomerName.TabIndex = 197;
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
            this.cmbCustomer.Location = new System.Drawing.Point(350, 84);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(150, 27);
            this.cmbCustomer.TabIndex = 196;
            this.cmbCustomer.ValueMember = "CustomerID";
            // 
            // chkEmployee
            // 
            this.chkEmployee.AutoSize = true;
            this.chkEmployee.Location = new System.Drawing.Point(220, 53);
            this.chkEmployee.Name = "chkEmployee";
            this.chkEmployee.Size = new System.Drawing.Size(124, 24);
            this.chkEmployee.TabIndex = 195;
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
            this.cmbEmployee.Location = new System.Drawing.Point(350, 51);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(150, 27);
            this.cmbEmployee.TabIndex = 194;
            this.cmbEmployee.ValueMember = "EmployeeID";
            // 
            // frmDeliveredList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 663);
            this.Controls.Add(this.chkCustomerName);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.chkEmployee);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtpOrderEnd);
            this.Controls.Add(this.dtpOrderStart);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvDeliveryDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDeliveredOrders);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmDeliveredList";
            this.Text = "ပို့ပြီးစာရင်း";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveredOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryDetails)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDelivery;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.DataGridView dgvDeliveredOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDeliveryDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private AGL.UI.Controls.EditTextBox txtPageSize;
        private System.Windows.Forms.Button btnFillGrid;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpOrderEnd;
        private System.Windows.Forms.DateTimePicker dtpOrderStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailDeliveryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVenNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderID;
        private AGL.UI.Controls.CalendarColumn colOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRouteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTripName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsDelivered;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkCustomerName;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.CheckBox chkEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;
    }
}

