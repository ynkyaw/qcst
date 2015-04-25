namespace PTIC.Sale.Delivery
{
    partial class frmNewDeliveryNote
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.btnLoadOrder = new System.Windows.Forms.Button();
            this.cmbEmp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRealVen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDeliveryDisplay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtTotalAmt = new System.Windows.Forms.TextBox();
            this.dgvDeliveryNote = new System.Windows.Forms.DataGridView();
            this.clnBrandName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clnProductName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clnOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnExtra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryNoteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShowQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTrip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboDeliver = new System.Windows.Forms.ComboBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryNote)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(979, 46);
            this.panel1.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.MediumBlue;
            this.label7.Location = new System.Drawing.Point(77, 14);
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
            this.lblDelivery.Location = new System.Drawing.Point(12, 14);
            this.lblDelivery.Name = "lblDelivery";
            this.lblDelivery.Size = new System.Drawing.Size(81, 19);
            this.lblDelivery.TabIndex = 4;
            this.lblDelivery.Text = "Delivery";
            // 
            // lblBrand
            // 
            this.lblBrand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblBrand.Location = new System.Drawing.Point(97, 14);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(122, 19);
            this.lblBrand.TabIndex = 3;
            this.lblBrand.Text = "Delivery Note";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dtpToDate);
            this.pnlGrid.Controls.Add(this.label9);
            this.pnlGrid.Controls.Add(this.dtpFrom);
            this.pnlGrid.Controls.Add(this.label8);
            this.pnlGrid.Controls.Add(this.comboDeliver);
            this.pnlGrid.Controls.Add(this.txtTrip);
            this.pnlGrid.Controls.Add(this.label3);
            this.pnlGrid.Controls.Add(this.txtEmpName);
            this.pnlGrid.Controls.Add(this.label6);
            this.pnlGrid.Controls.Add(this.button1);
            this.pnlGrid.Controls.Add(this.label2);
            this.pnlGrid.Controls.Add(this.groupBox1);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrid.Location = new System.Drawing.Point(0, 46);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(979, 141);
            this.pnlGrid.TabIndex = 182;
            // 
            // btnLoadOrder
            // 
            this.btnLoadOrder.Location = new System.Drawing.Point(763, 20);
            this.btnLoadOrder.Name = "btnLoadOrder";
            this.btnLoadOrder.Size = new System.Drawing.Size(95, 34);
            this.btnLoadOrder.TabIndex = 185;
            this.btnLoadOrder.Text = "Load Order";
            this.btnLoadOrder.UseVisualStyleBackColor = true;
            this.btnLoadOrder.Click += new System.EventHandler(this.btnLoadOrder_Click);
            // 
            // cmbEmp
            // 
            this.cmbEmp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmp.DisplayMember = "EmpName";
            this.cmbEmp.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmp.FormattingEnabled = true;
            this.cmbEmp.Location = new System.Drawing.Point(262, 26);
            this.cmbEmp.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbEmp.Name = "cmbEmp";
            this.cmbEmp.Size = new System.Drawing.Size(174, 25);
            this.cmbEmp.TabIndex = 158;
            this.cmbEmp.ValueMember = "EmployeeID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(189, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 157;
            this.label4.Text = "ထုတ်ယူသူ";
            // 
            // cmbRealVen
            // 
            this.cmbRealVen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRealVen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRealVen.DisplayMember = "VenNo";
            this.cmbRealVen.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRealVen.FormattingEnabled = true;
            this.cmbRealVen.Location = new System.Drawing.Point(570, 26);
            this.cmbRealVen.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbRealVen.Name = "cmbRealVen";
            this.cmbRealVen.Size = new System.Drawing.Size(174, 25);
            this.cmbRealVen.TabIndex = 156;
            this.cmbRealVen.ValueMember = "VehicleID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(456, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 19);
            this.label5.TabIndex = 155;
            this.label5.Text = "ထုတ်ယူသည့်ကား";
            // 
            // dtpDeliveryDisplay
            // 
            this.dtpDeliveryDisplay.CustomFormat = "dd-MMM-yyyy";
            this.dtpDeliveryDisplay.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDeliveryDisplay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeliveryDisplay.Location = new System.Drawing.Point(48, 27);
            this.dtpDeliveryDisplay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtpDeliveryDisplay.Name = "dtpDeliveryDisplay";
            this.dtpDeliveryDisplay.Size = new System.Drawing.Size(117, 25);
            this.dtpDeliveryDisplay.TabIndex = 152;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 19);
            this.label1.TabIndex = 151;
            this.label1.Text = "‌နေ့စွဲ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnRequest);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.txtTotalAmt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 486);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(979, 83);
            this.panel2.TabIndex = 183;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(349, 43);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 34);
            this.btnPrint.TabIndex = 170;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            // 
            // btnRequest
            // 
            this.btnRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRequest.Location = new System.Drawing.Point(127, 43);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(95, 34);
            this.btnRequest.TabIndex = 147;
            this.btnRequest.Text = "‌တောင်းခံမည်";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(238, 43);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 149;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label13.Location = new System.Drawing.Point(450, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 19);
            this.label13.TabIndex = 168;
            this.label13.Text = "စုစု‌ပေါင်း";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(16, 43);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 34);
            this.btnAdd.TabIndex = 171;
            this.btnAdd.Text = "ထည့်မည်";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtTotalAmt
            // 
            this.txtTotalAmt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotalAmt.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtTotalAmt.Location = new System.Drawing.Point(515, 6);
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.ReadOnly = true;
            this.txtTotalAmt.Size = new System.Drawing.Size(91, 25);
            this.txtTotalAmt.TabIndex = 167;
            this.txtTotalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvDeliveryNote
            // 
            this.dgvDeliveryNote.AllowUserToAddRows = false;
            this.dgvDeliveryNote.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeliveryNote.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDeliveryNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeliveryNote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnBrandName,
            this.clnProductName,
            this.clnOrder,
            this.clnExtra,
            this.clnAmount,
            this.colDeliveryNoteID,
            this.colShowQty});
            this.dgvDeliveryNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeliveryNote.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDeliveryNote.Location = new System.Drawing.Point(0, 187);
            this.dgvDeliveryNote.Name = "dgvDeliveryNote";
            this.dgvDeliveryNote.RowHeadersWidth = 50;
            this.dgvDeliveryNote.RowTemplate.Height = 28;
            this.dgvDeliveryNote.Size = new System.Drawing.Size(979, 299);
            this.dgvDeliveryNote.TabIndex = 184;
            this.dgvDeliveryNote.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDeliveryNote_CellBeginEdit);
            this.dgvDeliveryNote.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryNote_CellEndEdit);
            this.dgvDeliveryNote.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryNote_CellLeave);
            this.dgvDeliveryNote.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDeliveryNote_CellValidating);
            this.dgvDeliveryNote.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryNote_CellValueChanged);
            this.dgvDeliveryNote.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDeliveryNote_DataError);
            this.dgvDeliveryNote.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDeliveryNote_EditingControlShowing);
            // 
            // clnBrandName
            // 
            this.clnBrandName.DataPropertyName = "BrandID";
            this.clnBrandName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.clnBrandName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clnBrandName.HeaderText = "အမှတ်တံဆိပ်အမည်";
            this.clnBrandName.Name = "clnBrandName";
            this.clnBrandName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnBrandName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clnBrandName.Width = 120;
            // 
            // clnProductName
            // 
            this.clnProductName.DataPropertyName = "ProductID";
            this.clnProductName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.clnProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clnProductName.HeaderText = "ထုတ်ကုန်အမည်";
            this.clnProductName.Name = "clnProductName";
            this.clnProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clnProductName.Width = 150;
            // 
            // clnOrder
            // 
            this.clnOrder.DataPropertyName = "DeliveryQty";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.NullValue = "0";
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clnOrder.DefaultCellStyle = dataGridViewCellStyle7;
            this.clnOrder.HeaderText = "Order ပို့ရန်";
            this.clnOrder.MaxInputLength = 5;
            this.clnOrder.Name = "clnOrder";
            this.clnOrder.Width = 80;
            // 
            // clnExtra
            // 
            this.clnExtra.DataPropertyName = "ExtraQty";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.NullValue = "0";
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clnExtra.DefaultCellStyle = dataGridViewCellStyle8;
            this.clnExtra.HeaderText = "အပိုယူသွားရန်";
            this.clnExtra.MaxInputLength = 5;
            this.clnExtra.Name = "clnExtra";
            // 
            // clnAmount
            // 
            this.clnAmount.DataPropertyName = "TotalQty";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.NullValue = "0";
            this.clnAmount.DefaultCellStyle = dataGridViewCellStyle9;
            this.clnAmount.HeaderText = "စုစု‌ပေါင်း";
            this.clnAmount.Name = "clnAmount";
            this.clnAmount.ReadOnly = true;
            // 
            // colDeliveryNoteID
            // 
            this.colDeliveryNoteID.DataPropertyName = "DeliveryNoteDetailID";
            this.colDeliveryNoteID.HeaderText = "DeliveryNoteDetailID";
            this.colDeliveryNoteID.Name = "colDeliveryNoteID";
            this.colDeliveryNoteID.Visible = false;
            // 
            // colShowQty
            // 
            this.colShowQty.DataPropertyName = "ShowroomQty";
            dataGridViewCellStyle10.NullValue = "0";
            this.colShowQty.DefaultCellStyle = dataGridViewCellStyle10;
            this.colShowQty.HeaderText = "ShowRooms သို့ပို့ရန်";
            this.colShowQty.Name = "colShowQty";
            this.colShowQty.ReadOnly = true;
            this.colShowQty.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpDeliveryDisplay);
            this.groupBox1.Controls.Add(this.btnLoadOrder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbEmp);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbRealVen);
            this.groupBox1.Location = new System.Drawing.Point(16, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(870, 60);
            this.groupBox1.TabIndex = 186;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 19);
            this.label2.TabIndex = 187;
            this.label2.Text = "Trip Plan No";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(779, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 28);
            this.button1.TabIndex = 186;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEmpName
            // 
            this.txtEmpName.Enabled = false;
            this.txtEmpName.Location = new System.Drawing.Point(278, 36);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(100, 25);
            this.txtEmpName.TabIndex = 192;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 19);
            this.label6.TabIndex = 191;
            this.label6.Text = "ခရီးစဉ်တာဝန်ခံအမည်";
            // 
            // txtTrip
            // 
            this.txtTrip.Enabled = false;
            this.txtTrip.Location = new System.Drawing.Point(166, 36);
            this.txtTrip.Name = "txtTrip";
            this.txtTrip.Size = new System.Drawing.Size(100, 25);
            this.txtTrip.TabIndex = 194;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 193;
            this.label3.Text = "ခရီးစဉ်";
            // 
            // comboDeliver
            // 
            this.comboDeliver.FormattingEnabled = true;
            this.comboDeliver.Location = new System.Drawing.Point(24, 36);
            this.comboDeliver.Name = "comboDeliver";
            this.comboDeliver.Size = new System.Drawing.Size(115, 25);
            this.comboDeliver.TabIndex = 195;
            this.comboDeliver.SelectedIndexChanged += new System.EventHandler(this.comboDeliver_SelectedIndexChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpFrom.Enabled = false;
            this.dtpFrom.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(414, 36);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(117, 25);
            this.dtpFrom.TabIndex = 187;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(410, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 19);
            this.label8.TabIndex = 186;
            this.label8.Text = "သွားမည့်ရက်";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpToDate.Enabled = false;
            this.dtpToDate.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(553, 36);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(117, 25);
            this.dtpToDate.TabIndex = 197;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(549, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 19);
            this.label9.TabIndex = 196;
            this.label9.Text = "ပြန်ရောက်မည့်ရက်မည့်ရက်";
            // 
            // frmNewDeliveryNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 569);
            this.Controls.Add(this.dgvDeliveryNote);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNewDeliveryNote";
            this.Text = "Delivery Note";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryNote)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDelivery;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ComboBox cmbEmp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRealVen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtTotalAmt;
        private System.Windows.Forms.DataGridView dgvDeliveryNote;
        private System.Windows.Forms.Button btnLoadOrder;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnBrandName;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExtra;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryNoteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShowQty;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTrip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboDeliver;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label9;
    }
}