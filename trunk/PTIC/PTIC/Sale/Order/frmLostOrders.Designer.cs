namespace PTIC.Sale.Order
{
    partial class frmLostOrders
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBakToOrder = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpLostOrderStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.mbProduct = new System.Windows.Forms.ComboBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTown = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpLostOrderEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvLostOrders = new System.Windows.Forms.DataGridView();
            this.colCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliverQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLostQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPageSize = new AGL.UI.Controls.EditTextBox();
            this.btnFillGrid = new System.Windows.Forms.Button();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLostOrders)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblBakToOrder);
            this.panel1.Controls.Add(this.lblOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 41);
            this.panel1.TabIndex = 86;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.MediumBlue;
            this.label6.Location = new System.Drawing.Point(68, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = ">";
            // 
            // lblBakToOrder
            // 
            this.lblBakToOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBakToOrder.AutoSize = true;
            this.lblBakToOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBakToOrder.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBakToOrder.Location = new System.Drawing.Point(10, 10);
            this.lblBakToOrder.Name = "lblBakToOrder";
            this.lblBakToOrder.Size = new System.Drawing.Size(50, 20);
            this.lblBakToOrder.TabIndex = 4;
            this.lblBakToOrder.Text = "Order";
            this.lblBakToOrder.Click += new System.EventHandler(this.lblBakToOrder_Click);
            // 
            // lblOrder
            // 
            this.lblOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblOrder.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblOrder.Location = new System.Drawing.Point(96, 10);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(175, 20);
            this.lblOrder.TabIndex = 3;
            this.lblOrder.Text = "မပို့နိုင်‌သော Order စာရင်း";
            // 
            // pnlFilt
            // 
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 41);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(965, 35);
            this.pnlFilt.TabIndex = 87;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.Blue;
            this.lblFilter.Location = new System.Drawing.Point(7, 6);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(174, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Filter Information";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Controls.Add(this.dtpLostOrderStart);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.mbProduct);
            this.pnlFilter.Controls.Add(this.cmbCustomer);
            this.pnlFilter.Controls.Add(this.label8);
            this.pnlFilter.Controls.Add(this.cmbTown);
            this.pnlFilter.Controls.Add(this.label5);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Controls.Add(this.dtpLostOrderEnd);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 76);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(965, 90);
            this.pnlFilter.TabIndex = 88;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(863, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 34);
            this.btnSearch.TabIndex = 96;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpLostOrderStart
            // 
            this.dtpLostOrderStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLostOrderStart.Location = new System.Drawing.Point(50, 9);
            this.dtpLostOrderStart.Name = "dtpLostOrderStart";
            this.dtpLostOrderStart.ShowCheckBox = true;
            this.dtpLostOrderStart.Size = new System.Drawing.Size(170, 28);
            this.dtpLostOrderStart.TabIndex = 95;
            this.dtpLostOrderStart.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            this.dtpLostOrderStart.EnabledChanged += new System.EventHandler(this.dtpLostOrderStart_EnabledChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 94;
            this.label2.Text = "မှ";
            // 
            // mbProduct
            // 
            this.mbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.mbProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.mbProduct.DisplayMember = "ProductName";
            this.mbProduct.FormattingEnabled = true;
            this.mbProduct.Location = new System.Drawing.Point(687, 17);
            this.mbProduct.Name = "mbProduct";
            this.mbProduct.Size = new System.Drawing.Size(170, 27);
            this.mbProduct.TabIndex = 93;
            this.mbProduct.ValueMember = "ProductID";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.DisplayMember = "CusName";
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(391, 48);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(170, 27);
            this.cmbCustomer.TabIndex = 91;
            this.cmbCustomer.ValueMember = "CustomerID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(583, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 20);
            this.label8.TabIndex = 90;
            this.label8.Text = "ထုတ်ကုန်အမည်";
            // 
            // cmbTown
            // 
            this.cmbTown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTown.DisplayMember = "Town";
            this.cmbTown.FormattingEnabled = true;
            this.cmbTown.Location = new System.Drawing.Point(391, 14);
            this.cmbTown.Name = "cmbTown";
            this.cmbTown.Size = new System.Drawing.Size(170, 27);
            this.cmbTown.TabIndex = 92;
            this.cmbTown.ValueMember = "TownID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 89;
            this.label5.Text = "Customer မြို့";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 88;
            this.label4.Text = "Customer အမည်";
            // 
            // dtpLostOrderEnd
            // 
            this.dtpLostOrderEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLostOrderEnd.Location = new System.Drawing.Point(50, 43);
            this.dtpLostOrderEnd.Name = "dtpLostOrderEnd";
            this.dtpLostOrderEnd.ShowCheckBox = true;
            this.dtpLostOrderEnd.Size = new System.Drawing.Size(170, 28);
            this.dtpLostOrderEnd.TabIndex = 87;
            this.dtpLostOrderEnd.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 20);
            this.label1.TabIndex = 86;
            this.label1.Text = "ထိ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvLostOrders);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 166);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(965, 364);
            this.panel2.TabIndex = 89;
            // 
            // dgvLostOrders
            // 
            this.dgvLostOrders.AllowUserToAddRows = false;
            this.dgvLostOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvLostOrders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLostOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLostOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLostOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCusName,
            this.colTown,
            this.colOrderDate,
            this.colProductName,
            this.colOrderQty,
            this.colDeliveryDate,
            this.colDeliverQty,
            this.colLostQty});
            this.dgvLostOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLostOrders.Location = new System.Drawing.Point(0, 0);
            this.dgvLostOrders.Name = "dgvLostOrders";
            this.dgvLostOrders.ReadOnly = true;
            this.dgvLostOrders.RowHeadersWidth = 50;
            this.dgvLostOrders.RowTemplate.Height = 28;
            this.dgvLostOrders.Size = new System.Drawing.Size(965, 364);
            this.dgvLostOrders.TabIndex = 74;
            // 
            // colCusName
            // 
            this.colCusName.DataPropertyName = "CusName";
            this.colCusName.HeaderText = "Customer အမည်";
            this.colCusName.Name = "colCusName";
            this.colCusName.ReadOnly = true;
            this.colCusName.Width = 135;
            // 
            // colTown
            // 
            this.colTown.DataPropertyName = "Town";
            this.colTown.HeaderText = "Customer မြို့";
            this.colTown.Name = "colTown";
            this.colTown.ReadOnly = true;
            this.colTown.Width = 120;
            // 
            // colOrderDate
            // 
            this.colOrderDate.DataPropertyName = "OrderDate";
            dataGridViewCellStyle2.Format = "dd/MMM/yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.colOrderDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colOrderDate.HeaderText = "Order မှာသည့်‌နေ့";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.ReadOnly = true;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "ထုတ်ကုန်အမည်";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 110;
            // 
            // colOrderQty
            // 
            this.colOrderQty.DataPropertyName = "OrderQty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colOrderQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colOrderQty.HeaderText = "Order အ‌ရေအတွက်";
            this.colOrderQty.Name = "colOrderQty";
            this.colOrderQty.ReadOnly = true;
            this.colOrderQty.Width = 90;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.DataPropertyName = "DeliveryDate";
            dataGridViewCellStyle4.Format = "dd/MMM/yyyy";
            this.colDeliveryDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDeliveryDate.HeaderText = "ပို့သည့်‌နေ့";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.ReadOnly = true;
            // 
            // colDeliverQty
            // 
            this.colDeliverQty.DataPropertyName = "DeliverQty";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDeliverQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDeliverQty.HeaderText = "ပို့သည့် အ‌ရေအတွက်";
            this.colDeliverQty.Name = "colDeliverQty";
            this.colDeliverQty.ReadOnly = true;
            this.colDeliverQty.Width = 90;
            // 
            // colLostQty
            // 
            this.colLostQty.DataPropertyName = "LostQty";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colLostQty.DefaultCellStyle = dataGridViewCellStyle6;
            this.colLostQty.HeaderText = "ပို့ရန်လိုသည့် အ‌ရေအတွက်";
            this.colLostQty.Name = "colLostQty";
            this.colLostQty.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtPageSize);
            this.panel3.Controls.Add(this.btnFillGrid);
            this.panel3.Controls.Add(this.lblPageSize);
            this.panel3.Controls.Add(this.lblStatus);
            this.panel3.Controls.Add(this.btnLast);
            this.panel3.Controls.Add(this.btnNext);
            this.panel3.Controls.Add(this.btnPrevious);
            this.panel3.Controls.Add(this.btnFirst);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 501);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(965, 29);
            this.panel3.TabIndex = 174;
            // 
            // txtPageSize
            // 
            this.txtPageSize.ErrorColor = System.Drawing.Color.Empty;
            this.txtPageSize.ErrorMessage = "Page size must be integer and greater than zero!";
            this.txtPageSize.Location = new System.Drawing.Point(264, 3);
            this.txtPageSize.Multiline = true;
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(56, 20);
            this.txtPageSize.TabIndex = 19;
            this.txtPageSize.Text = "15";
            // 
            // btnFillGrid
            // 
            this.btnFillGrid.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFillGrid.Location = new System.Drawing.Point(326, 2);
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
            this.lblPageSize.Location = new System.Drawing.Point(193, 3);
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
            this.lblStatus.Location = new System.Drawing.Point(55, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(85, 20);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "0 / 0";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLast
            // 
            this.btnLast.Enabled = false;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLast.Location = new System.Drawing.Point(166, 2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(24, 23);
            this.btnLast.TabIndex = 13;
            this.btnLast.Text = ">|";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNext.Location = new System.Drawing.Point(142, 2);
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
            this.btnPrevious.Location = new System.Drawing.Point(30, 2);
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
            this.btnFirst.Location = new System.Drawing.Point(6, 2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(24, 23);
            this.btnFirst.TabIndex = 10;
            this.btnFirst.Text = "|<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // frmLostOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 530);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmLostOrders";
            this.Text = "Lost Orders";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLostOrders)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblBakToOrder;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpLostOrderStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox mbProduct;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpLostOrderEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvLostOrders;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnFillGrid;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private AGL.UI.Controls.EditTextBox txtPageSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliverQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLostQty;

    }
}