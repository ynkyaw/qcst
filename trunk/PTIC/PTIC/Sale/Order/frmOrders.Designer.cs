namespace PTIC.Sale.Order
{
    partial class frmOrders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOrder = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderDate = new AGL.UI.Controls.CalendarColumn();
            this.colCusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderReceieverID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRouteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTripName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsDelivered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpOrderStart = new System.Windows.Forms.DateTimePicker();
            this.dtpOrderEnd = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnToDeliver = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWSPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRSPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPageSize = new AGL.UI.Controls.EditTextBox();
            this.btnFillGrid = new System.Windows.Forms.Button();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblOrder);
            this.panel1.Controls.Add(this.lblBrand);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 41);
            this.panel1.TabIndex = 4;
            // 
            // lblOrder
            // 
            this.lblOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrder.AutoSize = true;
            this.lblOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOrder.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.Location = new System.Drawing.Point(10, 9);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(44, 17);
            this.lblOrder.TabIndex = 4;
            this.lblOrder.Text = "Order";
            this.lblOrder.Click += new System.EventHandler(this.lblOrder_Click);
            // 
            // lblBrand
            // 
            this.lblBrand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblBrand.Location = new System.Drawing.Point(61, 9);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(109, 17);
            this.lblBrand.TabIndex = 3;
            this.lblBrand.Text = ">    Order စာရင်း";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.colOrderDate,
            this.colCusID,
            this.colTownID,
            this.colOrderNo,
            this.colCusName,
            this.colOrderReceieverID,
            this.colTown,
            this.colRouteName,
            this.colTripName,
            this.colIsDelivered,
            this.colStatus,
            this.colOrderID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Myanmar3", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrders.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrders.Location = new System.Drawing.Point(12, 136);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrders.RowHeadersWidth = 50;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvOrders.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOrders.RowTemplate.Height = 28;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(899, 219);
            this.dgvOrders.TabIndex = 80;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            this.dgvOrders.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvOrders_DataBindingComplete);
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // no
            // 
            this.no.HeaderText = "စဉ်";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.Visible = false;
            this.no.Width = 30;
            // 
            // colOrderDate
            // 
            this.colOrderDate.DataPropertyName = "OrderDate";
            this.colOrderDate.HeaderText = "‌နေ့စွဲ";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.ReadOnly = true;
            this.colOrderDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOrderDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colOrderDate.Width = 150;
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
            // colOrderReceieverID
            // 
            this.colOrderReceieverID.DataPropertyName = "OrderReceieverID";
            this.colOrderReceieverID.HeaderText = "OrderReceieverID";
            this.colOrderReceieverID.Name = "colOrderReceieverID";
            this.colOrderReceieverID.ReadOnly = true;
            this.colOrderReceieverID.Visible = false;
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
            // 
            // colOrderID
            // 
            this.colOrderID.DataPropertyName = "OrderID";
            this.colOrderID.HeaderText = "Order ID";
            this.colOrderID.Name = "colOrderID";
            this.colOrderID.ReadOnly = true;
            this.colOrderID.Visible = false;
            // 
            // dtpOrderStart
            // 
            this.dtpOrderStart.CustomFormat = "dd-MMM-yyyy";
            this.dtpOrderStart.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrderStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderStart.Location = new System.Drawing.Point(18, 50);
            this.dtpOrderStart.Name = "dtpOrderStart";
            this.dtpOrderStart.Size = new System.Drawing.Size(128, 26);
            this.dtpOrderStart.TabIndex = 81;
            // 
            // dtpOrderEnd
            // 
            this.dtpOrderEnd.CustomFormat = "dd-MMM-yyyy";
            this.dtpOrderEnd.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrderEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderEnd.Location = new System.Drawing.Point(19, 82);
            this.dtpOrderEnd.Name = "dtpOrderEnd";
            this.dtpOrderEnd.Size = new System.Drawing.Size(128, 26);
            this.dtpOrderEnd.TabIndex = 82;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(152, 55);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(16, 17);
            this.lblFrom.TabIndex = 83;
            this.lblFrom.Text = "မှ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 84;
            this.label1.Text = "ထိ";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(510, 64);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 34);
            this.btnSearch.TabIndex = 163;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnToDeliver
            // 
            this.btnToDeliver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToDeliver.Enabled = false;
            this.btnToDeliver.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToDeliver.Location = new System.Drawing.Point(816, 452);
            this.btnToDeliver.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnToDeliver.Name = "btnToDeliver";
            this.btnToDeliver.Size = new System.Drawing.Size(95, 32);
            this.btnToDeliver.TabIndex = 165;
            this.btnToDeliver.Text = "ပို့ရန်စီစဉ်မည်";
            this.btnToDeliver.UseVisualStyleBackColor = true;
            this.btnToDeliver.Visible = false;
            this.btnToDeliver.Click += new System.EventHandler(this.btnToDeliver_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(693, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 166;
            this.label2.Text = "Order No. ";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderNo.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNo.Location = new System.Drawing.Point(776, 417);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.ReadOnly = true;
            this.txtOrderNo.Size = new System.Drawing.Size(135, 25);
            this.txtOrderNo.TabIndex = 167;
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.AllowUserToAddRows = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrderDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderDetails.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Myanmar3", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.colProductName,
            this.colWSPrice,
            this.colRSPrice,
            this.colQty,
            this.colAmount,
            this.colRemark,
            this.colOrderDetailID,
            this.colDetailOrderID,
            this.colProductID});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Myanmar3", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrderDetails.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvOrderDetails.Location = new System.Drawing.Point(12, 417);
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Myanmar3", 9F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvOrderDetails.RowHeadersWidth = 50;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvOrderDetails.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvOrderDetails.RowTemplate.Height = 28;
            this.dgvOrderDetails.Size = new System.Drawing.Size(675, 234);
            this.dgvOrderDetails.TabIndex = 168;
            this.dgvOrderDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvOrderDetails_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "စဉ်";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "ထုတ်ကုန်အမည်";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProductName.Width = 150;
            // 
            // colWSPrice
            // 
            this.colWSPrice.DataPropertyName = "WSPrice";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.colWSPrice.DefaultCellStyle = dataGridViewCellStyle8;
            this.colWSPrice.HeaderText = "Whole Price";
            this.colWSPrice.Name = "colWSPrice";
            this.colWSPrice.ReadOnly = true;
            // 
            // colRSPrice
            // 
            this.colRSPrice.DataPropertyName = "RSPrice";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.colRSPrice.DefaultCellStyle = dataGridViewCellStyle9;
            this.colRSPrice.HeaderText = "Retail Price";
            this.colRSPrice.Name = "colRSPrice";
            this.colRSPrice.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQty.DefaultCellStyle = dataGridViewCellStyle10;
            this.colQty.HeaderText = "အ‌ရေအတွက်";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle11;
            this.colAmount.HeaderText = "ကျသင့်‌ငွေ";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "မှတ်ချက်";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            this.colRemark.Width = 180;
            // 
            // colOrderDetailID
            // 
            this.colOrderDetailID.DataPropertyName = "OrderDetailID";
            this.colOrderDetailID.HeaderText = "OrderDetailID";
            this.colOrderDetailID.Name = "colOrderDetailID";
            this.colOrderDetailID.ReadOnly = true;
            this.colOrderDetailID.Visible = false;
            // 
            // colDetailOrderID
            // 
            this.colDetailOrderID.DataPropertyName = "OrderID";
            this.colDetailOrderID.HeaderText = "OrderID";
            this.colDetailOrderID.Name = "colDetailOrderID";
            this.colDetailOrderID.ReadOnly = true;
            this.colDetailOrderID.Visible = false;
            // 
            // colProductID
            // 
            this.colProductID.DataPropertyName = "ProductID";
            this.colProductID.HeaderText = "Product ID";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(704, 48);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 34);
            this.btnEdit.TabIndex = 170;
            this.btnEdit.Text = "ပြင်မည်";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(816, 48);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 169;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.panel2.Location = new System.Drawing.Point(12, 355);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(899, 30);
            this.panel2.TabIndex = 171;
            // 
            // txtPageSize
            // 
            this.txtPageSize.ErrorColor = System.Drawing.Color.Empty;
            this.txtPageSize.ErrorMessage = "Page size must be integer and greater than zero!";
            this.txtPageSize.Location = new System.Drawing.Point(264, 5);
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(56, 20);
            this.txtPageSize.TabIndex = 18;
            this.txtPageSize.Text = "15";
            // 
            // btnFillGrid
            // 
            this.btnFillGrid.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFillGrid.Location = new System.Drawing.Point(326, 3);
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
            this.lblPageSize.Location = new System.Drawing.Point(200, 8);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(58, 13);
            this.lblPageSize.TabIndex = 17;
            this.lblPageSize.Text = "Page Size:";
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Enabled = false;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatus.Location = new System.Drawing.Point(55, 5);
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
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(12, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 17);
            this.label3.TabIndex = 172;
            this.label3.Text = "မှာယူသည့်ပစ္စည်းစာရင်း";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label7.Location = new System.Drawing.Point(189, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 174;
            this.label7.Text = "Customer အမည်";
            // 
            // cmbDept
            // 
            this.cmbDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDept.DisplayMember = "DeptName";
            this.cmbDept.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(349, 84);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(150, 27);
            this.cmbDept.TabIndex = 175;
            this.cmbDept.ValueMember = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label4.Location = new System.Drawing.Point(189, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 20);
            this.label4.TabIndex = 176;
            this.label4.Text = "လက်ခံသည့် Department";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.DisplayMember = "CusName";
            this.cmbCustomer.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(349, 53);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(150, 27);
            this.cmbCustomer.TabIndex = 177;
            this.cmbCustomer.ValueMember = "CustomerID";
            // 
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 663);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.cmbDept);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvOrderDetails);
            this.Controls.Add(this.txtOrderNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnToDeliver);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtpOrderEnd);
            this.Controls.Add(this.dtpOrderStart);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.panel1);
            this.Name = "frmOrders";
            this.Text = "Order စာရင်း";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.DateTimePicker dtpOrderStart;
        private System.Windows.Forms.DateTimePicker dtpOrderEnd;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnToDeliver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private AGL.UI.Controls.CalendarColumn colOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderReceieverID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRouteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTripName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsDelivered;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFillGrid;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private AGL.UI.Controls.EditTextBox txtPageSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWSPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRSPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCustomer;
    }
}