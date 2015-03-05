namespace PTIC.VC.Sale.OfficeSales
{
    partial class frmSalesReturn
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblSalePage = new System.Windows.Forms.Label();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRouteTrip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSalesPersonName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvSalesReturn = new System.Windows.Forms.DataGridView();
            this.colInvoiceNo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesDetailsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesReturnInID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoShowRoom = new System.Windows.Forms.RadioButton();
            this.cmbWarehouseORVen = new System.Windows.Forms.ComboBox();
            this.rdoVenNo = new System.Windows.Forms.RadioButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbTown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesReturn)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblHeaderPCat);
            this.panel1.Controls.Add(this.lblSalePage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 41);
            this.panel1.TabIndex = 28;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(173, 10);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(120, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">  Sales Return";
            // 
            // lblSalePage
            // 
            this.lblSalePage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSalePage.AutoSize = true;
            this.lblSalePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalePage.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalePage.Location = new System.Drawing.Point(8, 10);
            this.lblSalePage.Name = "lblSalePage";
            this.lblSalePage.Size = new System.Drawing.Size(165, 20);
            this.lblSalePage.TabIndex = 0;
            this.lblSalePage.Text = "ကုန်ပစ္စည်း အဝင်/အထွက်";
            this.lblSalePage.Click += new System.EventHandler(this.lblSalePage_Click);
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReturnDate.Location = new System.Drawing.Point(189, 63);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(150, 28);
            this.dtpReturnDate.TabIndex = 136;
            this.dtpReturnDate.ValueChanged += new System.EventHandler(this.dtpReturnDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 135;
            this.label3.Text = "‌နေ့စွဲ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(34, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 20);
            this.label12.TabIndex = 143;
            this.label12.Text = "Customer အမည်";
            // 
            // txtRouteTrip
            // 
            this.txtRouteTrip.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRouteTrip.Location = new System.Drawing.Point(515, 63);
            this.txtRouteTrip.Name = "txtRouteTrip";
            this.txtRouteTrip.ReadOnly = true;
            this.txtRouteTrip.Size = new System.Drawing.Size(150, 28);
            this.txtRouteTrip.TabIndex = 146;
            this.txtRouteTrip.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(370, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 145;
            this.label4.Text = "ခရီးစဉ် / လမ်း‌ကြောင်း";
            // 
            // txtSalesPersonName
            // 
            this.txtSalesPersonName.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesPersonName.Location = new System.Drawing.Point(516, 98);
            this.txtSalesPersonName.Name = "txtSalesPersonName";
            this.txtSalesPersonName.ReadOnly = true;
            this.txtSalesPersonName.Size = new System.Drawing.Size(150, 28);
            this.txtSalesPersonName.TabIndex = 148;
            this.txtSalesPersonName.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(370, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 20);
            this.label5.TabIndex = 147;
            this.label5.Text = "အ‌ရောင်းဝန်ထမ်းအမည်";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(131, 608);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 34);
            this.btnCancel.TabIndex = 151;
            this.btnCancel.Text = "ပယ်ဖျက်မည်";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 608);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 150;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvSalesReturn
            // 
            this.dgvSalesReturn.AllowUserToAddRows = false;
            this.dgvSalesReturn.AllowUserToDeleteRows = false;
            this.dgvSalesReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalesReturn.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesReturn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesReturn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInvoiceNo,
            this.colProduct,
            this.colPrice,
            this.colQty,
            this.colRemark,
            this.colSalesDetailsID,
            this.colSalesReturnInID,
            this.colInvoiceID});
            this.dgvSalesReturn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSalesReturn.Location = new System.Drawing.Point(12, 254);
            this.dgvSalesReturn.Name = "dgvSalesReturn";
            this.dgvSalesReturn.RowHeadersWidth = 50;
            this.dgvSalesReturn.RowTemplate.Height = 28;
            this.dgvSalesReturn.Size = new System.Drawing.Size(854, 348);
            this.dgvSalesReturn.TabIndex = 152;
            this.dgvSalesReturn.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesReturn_CellEndEdit);
            this.dgvSalesReturn.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesReturn_CellLeave);
            this.dgvSalesReturn.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSalesReturn_CellValidating);
            this.dgvSalesReturn.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesReturn_CellValueChanged);
            this.dgvSalesReturn.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvSalesReturn_CurrentCellDirtyStateChanged);
            this.dgvSalesReturn.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSalesReturn_DataBindingComplete);
            this.dgvSalesReturn.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSalesReturn_DataError);
            this.dgvSalesReturn.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSalesReturn_EditingControlShowing);
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.DataPropertyName = "InvoiceID";
            this.colInvoiceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colInvoiceNo.HeaderText = "Sales Invoice No";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.Width = 130;
            // 
            // colProduct
            // 
            this.colProduct.DataPropertyName = "ProductID";
            this.colProduct.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colProduct.HeaderText = "ထုတ်ကုန်အမည်";
            this.colProduct.Name = "colProduct";
            this.colProduct.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProduct.Width = 150;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "SalePrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPrice.HeaderText = "‌ဈေးနှုန်း";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPrice.Width = 150;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colQty.HeaderText = "အ‌ရေအတွက်";
            this.colQty.Name = "colQty";
            this.colQty.Width = 110;
            // 
            // colRemark
            // 
            this.colRemark.HeaderText = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRemark.Width = 180;
            // 
            // colSalesDetailsID
            // 
            this.colSalesDetailsID.DataPropertyName = "SalesDetailID";
            this.colSalesDetailsID.HeaderText = "SalesDetailID";
            this.colSalesDetailsID.Name = "colSalesDetailsID";
            this.colSalesDetailsID.Visible = false;
            // 
            // colSalesReturnInID
            // 
            this.colSalesReturnInID.DataPropertyName = "SalesReturnInID";
            this.colSalesReturnInID.HeaderText = "SalesReturnInID";
            this.colSalesReturnInID.Name = "colSalesReturnInID";
            this.colSalesReturnInID.Visible = false;
            // 
            // colInvoiceID
            // 
            this.colInvoiceID.DataPropertyName = "InvoiceID";
            this.colInvoiceID.HeaderText = "InvoiceID";
            this.colInvoiceID.Name = "colInvoiceID";
            this.colInvoiceID.Visible = false;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.DisplayMember = "CusName";
            this.cmbCustomer.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(189, 134);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(150, 27);
            this.cmbCustomer.TabIndex = 153;
            this.cmbCustomer.ValueMember = "CustomerID";
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoShowRoom);
            this.groupBox1.Controls.Add(this.cmbWarehouseORVen);
            this.groupBox1.Controls.Add(this.rdoVenNo);
            this.groupBox1.Location = new System.Drawing.Point(374, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 103);
            this.groupBox1.TabIndex = 173;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "အ‌ရောင်းကားနံပါတ် / ShowRoom အမည်";
            // 
            // rdoShowRoom
            // 
            this.rdoShowRoom.AutoSize = true;
            this.rdoShowRoom.Location = new System.Drawing.Point(7, 67);
            this.rdoShowRoom.Name = "rdoShowRoom";
            this.rdoShowRoom.Size = new System.Drawing.Size(141, 24);
            this.rdoShowRoom.TabIndex = 1;
            this.rdoShowRoom.Text = "ShowRoom အမည်";
            this.rdoShowRoom.UseVisualStyleBackColor = true;
            this.rdoShowRoom.CheckedChanged += new System.EventHandler(this.rdoShowRoom_CheckedChanged);
            // 
            // cmbWarehouseORVen
            // 
            this.cmbWarehouseORVen.DisplayMember = "Warehouse";
            this.cmbWarehouseORVen.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarehouseORVen.FormattingEnabled = true;
            this.cmbWarehouseORVen.Location = new System.Drawing.Point(153, 43);
            this.cmbWarehouseORVen.Name = "cmbWarehouseORVen";
            this.cmbWarehouseORVen.Size = new System.Drawing.Size(150, 27);
            this.cmbWarehouseORVen.TabIndex = 170;
            this.cmbWarehouseORVen.ValueMember = "ID";
            // 
            // rdoVenNo
            // 
            this.rdoVenNo.AutoSize = true;
            this.rdoVenNo.Location = new System.Drawing.Point(7, 26);
            this.rdoVenNo.Name = "rdoVenNo";
            this.rdoVenNo.Size = new System.Drawing.Size(140, 24);
            this.rdoVenNo.TabIndex = 0;
            this.rdoVenNo.Text = "အ‌ရောင်းကားနံပါတ်";
            this.rdoVenNo.UseVisualStyleBackColor = true;
            this.rdoVenNo.CheckedChanged += new System.EventHandler(this.rdoVenNo_CheckedChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SalePrice";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.HeaderText = "‌ဈေးနှုန်း";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DeliverQty";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "အ‌ရေအတွက်";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Remark";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 180;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SalesDetailID";
            this.dataGridViewTextBoxColumn4.HeaderText = "SalesDetailID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // cmbTown
            // 
            this.cmbTown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTown.DisplayMember = "Town";
            this.cmbTown.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTown.FormattingEnabled = true;
            this.cmbTown.Location = new System.Drawing.Point(189, 99);
            this.cmbTown.Name = "cmbTown";
            this.cmbTown.Size = new System.Drawing.Size(150, 27);
            this.cmbTown.TabIndex = 175;
            this.cmbTown.ValueMember = "TownID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 174;
            this.label1.Text = " မြို့အမည်";
            // 
            // frmSalesReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 650);
            this.Controls.Add(this.cmbTown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.dgvSalesReturn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtpReturnDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSalesPersonName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRouteTrip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmSalesReturn";
            this.Text = "Sales Return";
            this.Load += new System.EventHandler(this.frmSalesReturn_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesReturn)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSalePage;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRouteTrip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSalesPersonName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvSalesReturn;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoShowRoom;
        private System.Windows.Forms.ComboBox cmbWarehouseORVen;
        private System.Windows.Forms.RadioButton rdoVenNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ComboBox cmbTown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewComboBoxColumn colInvoiceNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesDetailsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesReturnInID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceID;
    }
}