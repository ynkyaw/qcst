namespace PTIC.Sale.Order
{
    partial class frmOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBakToOrder = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.dgvOrderDetail = new System.Windows.Forms.DataGridView();
            this.colProductID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colWSPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRSPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbTown = new System.Windows.Forms.ComboBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.txtCreditLimitAmt = new System.Windows.Forms.TextBox();
            this.txtCreditAmount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.btnAddNewCustomer = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTrip = new System.Windows.Forms.TextBox();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.cmbReceiver = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblBakToOrder);
            this.panel1.Controls.Add(this.lblOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(929, 41);
            this.panel1.TabIndex = 3;
            // 
            // lblBakToOrder
            // 
            this.lblBakToOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBakToOrder.AutoSize = true;
            this.lblBakToOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBakToOrder.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBakToOrder.Location = new System.Drawing.Point(10, 12);
            this.lblBakToOrder.Name = "lblBakToOrder";
            this.lblBakToOrder.Size = new System.Drawing.Size(48, 16);
            this.lblBakToOrder.TabIndex = 4;
            this.lblBakToOrder.Text = "Order";
            this.lblBakToOrder.Click += new System.EventHandler(this.lblBakToOrder_Click);
            // 
            // lblOrder
            // 
            this.lblOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrder.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblOrder.Location = new System.Drawing.Point(61, 12);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(132, 16);
            this.lblOrder.TabIndex = 3;
            this.lblOrder.Text = ">    Order လက်ခံခြင်း";
            // 
            // dgvOrderDetail
            // 
            this.dgvOrderDetail.AllowUserToAddRows = false;
            this.dgvOrderDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderDetail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductID,
            this.colWSPrice,
            this.colRSPrice,
            this.colQty,
            this.colAmount,
            this.colRemark,
            this.colOrderDetailID,
            this.colDetailOrderID});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrderDetail.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvOrderDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvOrderDetail.Location = new System.Drawing.Point(12, 233);
            this.dgvOrderDetail.MultiSelect = false;
            this.dgvOrderDetail.Name = "dgvOrderDetail";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Myanmar3", 9F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvOrderDetail.RowHeadersWidth = 50;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvOrderDetail.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvOrderDetail.RowTemplate.Height = 28;
            this.dgvOrderDetail.Size = new System.Drawing.Size(904, 274);
            this.dgvOrderDetail.TabIndex = 5;
            this.dgvOrderDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderDetail_CellEndEdit);
            this.dgvOrderDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvOrderDetail_CellValidating);
            this.dgvOrderDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderDetail_CellValueChanged);
            this.dgvOrderDetail.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvOrderDetail_CurrentCellDirtyStateChanged);
            this.dgvOrderDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvOrderDetail_DataBindingComplete);
            this.dgvOrderDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvOrderDetail_DataError);
            this.dgvOrderDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvOrderDetail_EditingControlShowing);
            this.dgvOrderDetail.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvOrderDetail_RowsAdded);
            this.dgvOrderDetail.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvOrderDetail_RowsRemoved);
            this.dgvOrderDetail.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvOrderDetail_UserDeletedRow);
            // 
            // colProductID
            // 
            this.colProductID.DataPropertyName = "ProductID";
            this.colProductID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colProductID.HeaderText = "ထုတ်ကုန်";
            this.colProductID.Name = "colProductID";
            this.colProductID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProductID.Width = 150;
            // 
            // colWSPrice
            // 
            this.colWSPrice.DataPropertyName = "WSPrice";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N0";
            dataGridViewCellStyle14.NullValue = "0";
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colWSPrice.DefaultCellStyle = dataGridViewCellStyle14;
            this.colWSPrice.HeaderText = "‌လက်ကား ရောင်း‌ဈေး";
            this.colWSPrice.MaxInputLength = 8;
            this.colWSPrice.Name = "colWSPrice";
            this.colWSPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colWSPrice.Width = 150;
            // 
            // colRSPrice
            // 
            this.colRSPrice.DataPropertyName = "RSPrice";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N0";
            this.colRSPrice.DefaultCellStyle = dataGridViewCellStyle15;
            this.colRSPrice.HeaderText = "လက်လီ ‌ရောင်း‌ဈေး";
            this.colRSPrice.Name = "colRSPrice";
            this.colRSPrice.ReadOnly = true;
            this.colRSPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRSPrice.Visible = false;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.NullValue = "0";
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colQty.DefaultCellStyle = dataGridViewCellStyle16;
            this.colQty.HeaderText = "အ‌ရေအတွက်";
            this.colQty.MaxInputLength = 5;
            this.colQty.Name = "colQty";
            this.colQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAmount
            // 
            this.colAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N0";
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle17;
            this.colAmount.HeaderText = "ကျသင့်‌ငွေ";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "မှတ်ချက်";
            this.colRemark.Name = "colRemark";
            this.colRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRemark.Width = 180;
            // 
            // colOrderDetailID
            // 
            this.colOrderDetailID.DataPropertyName = "OrderDetailID";
            this.colOrderDetailID.HeaderText = "OrderDetailID";
            this.colOrderDetailID.Name = "colOrderDetailID";
            this.colOrderDetailID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colOrderDetailID.Visible = false;
            // 
            // colDetailOrderID
            // 
            this.colDetailOrderID.DataPropertyName = "OrderID";
            this.colDetailOrderID.HeaderText = "OrderID";
            this.colDetailOrderID.Name = "colDetailOrderID";
            this.colDetailOrderID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDetailOrderID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label1.Location = new System.Drawing.Point(448, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 114;
            this.label1.Text = "Order No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label2.Location = new System.Drawing.Point(448, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 19);
            this.label2.TabIndex = 115;
            this.label2.Text = "Order မှာသည့်နေ့စွဲ";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.CalendarFont = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrderDate.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(598, 60);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(150, 25);
            this.dtpOrderDate.TabIndex = 3;
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderNo.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNo.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtOrderNo.Location = new System.Drawing.Point(598, 24);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.ReadOnly = true;
            this.txtOrderNo.Size = new System.Drawing.Size(150, 23);
            this.txtOrderNo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label3.Location = new System.Drawing.Point(51, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 19);
            this.label3.TabIndex = 118;
            this.label3.Text = "Customer မြို့";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label4.Location = new System.Drawing.Point(51, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 19);
            this.label4.TabIndex = 119;
            this.label4.Text = "Customer အမည်";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label5.Location = new System.Drawing.Point(448, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 19);
            this.label5.TabIndex = 120;
            this.label5.Text = "အကြွေးကန့်သတ်ပမာဏ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label7.Location = new System.Drawing.Point(448, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 19);
            this.label7.TabIndex = 121;
            this.label7.Text = "Order လက်ခံသူ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label8.Location = new System.Drawing.Point(51, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 19);
            this.label8.TabIndex = 122;
            this.label8.Text = "Customer လမ်း‌ကြောင်း";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label9.Location = new System.Drawing.Point(51, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 19);
            this.label9.TabIndex = 123;
            this.label9.Text = "Customer ခရီးစဉ်";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label10.Location = new System.Drawing.Point(448, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 19);
            this.label10.TabIndex = 124;
            this.label10.Text = "အ‌ကြွေးလက်ကျန်";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label11.Location = new System.Drawing.Point(729, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 19);
            this.label11.TabIndex = 125;
            this.label11.Text = "ကျပ်";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 211);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 16);
            this.label12.TabIndex = 126;
            this.label12.Text = "Order မှာယူမှုစာရင်း";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label13.Location = new System.Drawing.Point(729, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 19);
            this.label13.TabIndex = 127;
            this.label13.Text = "ကျပ်";
            // 
            // cmbTown
            // 
            this.cmbTown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTown.DisplayMember = "Town";
            this.cmbTown.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbTown.FormattingEnabled = true;
            this.cmbTown.Location = new System.Drawing.Point(227, 23);
            this.cmbTown.Name = "cmbTown";
            this.cmbTown.Size = new System.Drawing.Size(150, 25);
            this.cmbTown.TabIndex = 1;
            this.cmbTown.ValueMember = "TownID";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.DisplayMember = "CusName";
            this.cmbCustomer.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(227, 60);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(150, 25);
            this.cmbCustomer.TabIndex = 2;
            this.cmbCustomer.ValueMember = "CustomerID";
            this.cmbCustomer.SelectedValueChanged += new System.EventHandler(this.cmbCustomer_SelectedValueChanged);
            // 
            // txtCreditLimitAmt
            // 
            this.txtCreditLimitAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreditLimitAmt.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditLimitAmt.Location = new System.Drawing.Point(598, 127);
            this.txtCreditLimitAmt.Name = "txtCreditLimitAmt";
            this.txtCreditLimitAmt.ReadOnly = true;
            this.txtCreditLimitAmt.Size = new System.Drawing.Size(125, 23);
            this.txtCreditLimitAmt.TabIndex = 130;
            this.txtCreditLimitAmt.TabStop = false;
            this.txtCreditLimitAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCreditAmount
            // 
            this.txtCreditAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreditAmount.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditAmount.Location = new System.Drawing.Point(598, 162);
            this.txtCreditAmount.Name = "txtCreditAmount";
            this.txtCreditAmount.ReadOnly = true;
            this.txtCreditAmount.Size = new System.Drawing.Size(125, 23);
            this.txtCreditAmount.TabIndex = 132;
            this.txtCreditAmount.TabStop = false;
            this.txtCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label14.Location = new System.Drawing.Point(51, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 19);
            this.label14.TabIndex = 135;
            this.label14.Text = "ဆက်သွယ်ရမည့်သူအမည်";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactPerson.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactPerson.Location = new System.Drawing.Point(227, 92);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.ReadOnly = true;
            this.txtContactPerson.Size = new System.Drawing.Size(150, 23);
            this.txtContactPerson.TabIndex = 136;
            this.txtContactPerson.TabStop = false;
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.Font = new System.Drawing.Font("Zawgyi-One", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewCustomer.Location = new System.Drawing.Point(383, 59);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(45, 27);
            this.btnAddNewCustomer.TabIndex = 161;
            this.btnAddNewCustomer.Text = "+";
            this.btnAddNewCustomer.UseVisualStyleBackColor = true;
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnNew);
            this.panel3.Controls.Add(this.txtTotalAmount);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txtTrip);
            this.panel3.Controls.Add(this.txtRoute);
            this.panel3.Controls.Add(this.cmbReceiver);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btnAddNewCustomer);
            this.panel3.Controls.Add(this.txtContactPerson);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.txtCreditAmount);
            this.panel3.Controls.Add(this.txtCreditLimitAmt);
            this.panel3.Controls.Add(this.cmbCustomer);
            this.panel3.Controls.Add(this.cmbTown);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtOrderNo);
            this.panel3.Controls.Add(this.dtpOrderDate);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dgvOrderDetail);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(929, 555);
            this.panel3.TabIndex = 140;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Zawgyi-One", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(383, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 27);
            this.button1.TabIndex = 170;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnNew.Location = new System.Drawing.Point(12, 513);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 34);
            this.btnNew.TabIndex = 169;
            this.btnNew.Text = "ထည့်မည်";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotalAmount.BackColor = System.Drawing.Color.White;
            this.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmount.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(515, 513);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(150, 23);
            this.txtTotalAmount.TabIndex = 168;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.TextChanged += new System.EventHandler(this.txtTotalAmount_TextChanged);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label15.Location = new System.Drawing.Point(393, 514);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 19);
            this.label15.TabIndex = 167;
            this.label15.Text = "စုစု‌ပေါင်းကျသင့်‌ငွေ";
            // 
            // txtTrip
            // 
            this.txtTrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTrip.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrip.Location = new System.Drawing.Point(227, 159);
            this.txtTrip.Name = "txtTrip";
            this.txtTrip.ReadOnly = true;
            this.txtTrip.Size = new System.Drawing.Size(150, 23);
            this.txtTrip.TabIndex = 166;
            this.txtTrip.TabStop = false;
            // 
            // txtRoute
            // 
            this.txtRoute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoute.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoute.Location = new System.Drawing.Point(227, 126);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.ReadOnly = true;
            this.txtRoute.Size = new System.Drawing.Size(150, 23);
            this.txtRoute.TabIndex = 165;
            this.txtRoute.TabStop = false;
            // 
            // cmbReceiver
            // 
            this.cmbReceiver.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbReceiver.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReceiver.DisplayMember = "EmpName";
            this.cmbReceiver.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbReceiver.FormattingEnabled = true;
            this.cmbReceiver.Location = new System.Drawing.Point(598, 93);
            this.cmbReceiver.Name = "cmbReceiver";
            this.cmbReceiver.Size = new System.Drawing.Size(150, 25);
            this.cmbReceiver.TabIndex = 4;
            this.cmbReceiver.ValueMember = "EmployeeID";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnDelete.Location = new System.Drawing.Point(234, 513);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSave.Location = new System.Drawing.Point(123, 513);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "WSPrice";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N0";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn1.HeaderText = "လက်ကား ‌ရောင်း‌ဈေး";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "RSPrice";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "N0";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn2.HeaderText = "လက်လီ ‌ရောင်း‌ဈေး";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Qty";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewTextBoxColumn3.HeaderText = "အ‌ရေအတွက်";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Amount";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle24.Format = "N0";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewTextBoxColumn4.HeaderText = "ကျသင့်‌ငွေ";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Remark";
            this.dataGridViewTextBoxColumn5.HeaderText = "မှတ်ချက်";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 180;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "OrderDetailID";
            this.dataGridViewTextBoxColumn6.HeaderText = "OrderDetailID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "OrderID";
            this.dataGridViewTextBoxColumn7.HeaderText = "OrderID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 596);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order လက်ခံခြင်း";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.DataGridView dgvOrderDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbTown;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.TextBox txtCreditLimitAmt;
        private System.Windows.Forms.TextBox txtCreditAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.Button btnAddNewCustomer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblBakToOrder;
        private System.Windows.Forms.ComboBox cmbReceiver;
        private System.Windows.Forms.TextBox txtTrip;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewComboBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWSPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRSPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailOrderID;
    }
}