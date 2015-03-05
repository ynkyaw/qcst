namespace PTIC.VC.Sale.Delivery
{
    partial class frmDeliveryNote
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.dtpDeliveryNoteDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbVenNo = new System.Windows.Forms.ComboBox();
            this.dgvDeliveryNote = new System.Windows.Forms.DataGridView();
            this.clnBrandName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clnProductName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbSalePerson = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTotalAmt = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dtpDeliveryDisplay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEmpDisplay = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEmp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbRealVen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShowQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnExtra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryNoteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryNote)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlGrid.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(768, 46);
            this.panel1.TabIndex = 7;
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
            this.lblDelivery.Location = new System.Drawing.Point(12, 14);
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
            this.lblBrand.Location = new System.Drawing.Point(97, 14);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(110, 20);
            this.lblBrand.TabIndex = 3;
            this.lblBrand.Text = "Delivery Note";
            // 
            // dtpDeliveryNoteDate
            // 
            this.dtpDeliveryNoteDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDeliveryNoteDate.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDeliveryNoteDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeliveryNoteDate.Location = new System.Drawing.Point(51, 7);
            this.dtpDeliveryNoteDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtpDeliveryNoteDate.Name = "dtpDeliveryNoteDate";
            this.dtpDeliveryNoteDate.Size = new System.Drawing.Size(119, 28);
            this.dtpDeliveryNoteDate.TabIndex = 128;
            this.dtpDeliveryNoteDate.ValueChanged += new System.EventHandler(this.dtpDeliveryNoteDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 127;
            this.label3.Text = "‌နေ့စွဲ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(173, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 20);
            this.label6.TabIndex = 131;
            this.label6.Text = "ထုတ်ယူမည့်ကား";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(187, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 20);
            this.label12.TabIndex = 143;
            this.label12.Text = "ထုတ်ယူမည့်သူ";
            // 
            // cmbVenNo
            // 
            this.cmbVenNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVenNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVenNo.DisplayMember = "VenNo";
            this.cmbVenNo.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVenNo.FormattingEnabled = true;
            this.cmbVenNo.Location = new System.Drawing.Point(283, 41);
            this.cmbVenNo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbVenNo.Name = "cmbVenNo";
            this.cmbVenNo.Size = new System.Drawing.Size(174, 27);
            this.cmbVenNo.TabIndex = 145;
            this.cmbVenNo.ValueMember = "VenID";
            this.cmbVenNo.SelectedIndexChanged += new System.EventHandler(this.cmbVenNo_SelectedIndexChanged);
            // 
            // dgvDeliveryNote
            // 
            this.dgvDeliveryNote.AllowUserToAddRows = false;
            this.dgvDeliveryNote.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeliveryNote.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDeliveryNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeliveryNote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnBrandName,
            this.clnProductName,
            this.clnOrder,
            this.colShowQty,
            this.clnExtra,
            this.clnAmount,
            this.colDeliveryNoteID});
            this.dgvDeliveryNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeliveryNote.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDeliveryNote.Location = new System.Drawing.Point(0, 0);
            this.dgvDeliveryNote.Name = "dgvDeliveryNote";
            this.dgvDeliveryNote.RowHeadersWidth = 50;
            this.dgvDeliveryNote.RowTemplate.Height = 28;
            this.dgvDeliveryNote.Size = new System.Drawing.Size(768, 363);
            this.dgvDeliveryNote.TabIndex = 146;
            this.dgvDeliveryNote.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryNote_CellContentClick);
            this.dgvDeliveryNote.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryNote_CellEndEdit);
            this.dgvDeliveryNote.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryNote_CellLeave);
            this.dgvDeliveryNote.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDeliveryNote_CellValidating);
            this.dgvDeliveryNote.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryNote_CellValueChanged);
            this.dgvDeliveryNote.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDeliveryNote_CurrentCellDirtyStateChanged);
            this.dgvDeliveryNote.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDeliveryNote_DataBindingComplete);
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
            // btnRequest
            // 
            this.btnRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRequest.Enabled = false;
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
            // cmbSalePerson
            // 
            this.cmbSalePerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSalePerson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSalePerson.DisplayMember = "EmpName";
            this.cmbSalePerson.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalePerson.FormattingEnabled = true;
            this.cmbSalePerson.Location = new System.Drawing.Point(283, 10);
            this.cmbSalePerson.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbSalePerson.Name = "cmbSalePerson";
            this.cmbSalePerson.Size = new System.Drawing.Size(174, 27);
            this.cmbSalePerson.TabIndex = 150;
            this.cmbSalePerson.ValueMember = "EmployeeID";
            this.cmbSalePerson.SelectedIndexChanged += new System.EventHandler(this.cmbSalePerson_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label13.Location = new System.Drawing.Point(450, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 20);
            this.label13.TabIndex = 168;
            this.label13.Text = "စုစု‌ပေါင်း";
            // 
            // txtTotalAmt
            // 
            this.txtTotalAmt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotalAmt.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtTotalAmt.Location = new System.Drawing.Point(515, 6);
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.ReadOnly = true;
            this.txtTotalAmt.Size = new System.Drawing.Size(91, 28);
            this.txtTotalAmt.TabIndex = 167;
            this.txtTotalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(472, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 34);
            this.btnSearch.TabIndex = 169;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            // pnlFilter
            // 
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Controls.Add(this.dtpDeliveryNoteDate);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.cmbSalePerson);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Controls.Add(this.label12);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 69);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(768, 49);
            this.pnlFilter.TabIndex = 178;
            this.pnlFilter.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1007, 100);
            this.panel3.TabIndex = 174;
            // 
            // pnlFilt
            // 
            this.pnlFilt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(149)))), ((int)(((byte)(206)))));
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 46);
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(768, 23);
            this.pnlFilt.TabIndex = 177;
            // 
            // lblFilter
            // 
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lblFilter.Location = new System.Drawing.Point(3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(280, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Advance Search";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
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
            this.panel2.Location = new System.Drawing.Point(0, 558);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 83);
            this.panel2.TabIndex = 179;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvDeliveryNote);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 195);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(768, 363);
            this.panel4.TabIndex = 180;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.cmbEmp);
            this.pnlGrid.Controls.Add(this.label4);
            this.pnlGrid.Controls.Add(this.cmbRealVen);
            this.pnlGrid.Controls.Add(this.label5);
            this.pnlGrid.Controls.Add(this.dtpDeliveryDisplay);
            this.pnlGrid.Controls.Add(this.label1);
            this.pnlGrid.Controls.Add(this.cmbEmpDisplay);
            this.pnlGrid.Controls.Add(this.label2);
            this.pnlGrid.Controls.Add(this.cmbVenNo);
            this.pnlGrid.Controls.Add(this.label6);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrid.Location = new System.Drawing.Point(0, 118);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(768, 77);
            this.pnlGrid.TabIndex = 181;
            // 
            // dtpDeliveryDisplay
            // 
            this.dtpDeliveryDisplay.CustomFormat = "dd-MMM-yyyy";
            this.dtpDeliveryDisplay.Enabled = false;
            this.dtpDeliveryDisplay.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDeliveryDisplay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeliveryDisplay.Location = new System.Drawing.Point(52, 9);
            this.dtpDeliveryDisplay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtpDeliveryDisplay.Name = "dtpDeliveryDisplay";
            this.dtpDeliveryDisplay.Size = new System.Drawing.Size(117, 28);
            this.dtpDeliveryDisplay.TabIndex = 152;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 151;
            this.label1.Text = "‌နေ့စွဲ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbEmpDisplay
            // 
            this.cmbEmpDisplay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmpDisplay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmpDisplay.DisplayMember = "EmpName";
            this.cmbEmpDisplay.Enabled = false;
            this.cmbEmpDisplay.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpDisplay.FormattingEnabled = true;
            this.cmbEmpDisplay.Location = new System.Drawing.Point(283, 9);
            this.cmbEmpDisplay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbEmpDisplay.Name = "cmbEmpDisplay";
            this.cmbEmpDisplay.Size = new System.Drawing.Size(174, 27);
            this.cmbEmpDisplay.TabIndex = 154;
            this.cmbEmpDisplay.ValueMember = "EmployeeID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(186, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 153;
            this.label2.Text = "ထုတ်ယူမည့်သူ";
            // 
            // cmbEmp
            // 
            this.cmbEmp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmp.DisplayMember = "EmpName";
            this.cmbEmp.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmp.FormattingEnabled = true;
            this.cmbEmp.Location = new System.Drawing.Point(576, 9);
            this.cmbEmp.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbEmp.Name = "cmbEmp";
            this.cmbEmp.Size = new System.Drawing.Size(174, 27);
            this.cmbEmp.TabIndex = 158;
            this.cmbEmp.ValueMember = "EmployeeID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(501, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
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
            this.cmbRealVen.Location = new System.Drawing.Point(576, 41);
            this.cmbRealVen.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbRealVen.Name = "cmbRealVen";
            this.cmbRealVen.Size = new System.Drawing.Size(174, 27);
            this.cmbRealVen.TabIndex = 156;
            this.cmbRealVen.ValueMember = "VehicleID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(462, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 155;
            this.label5.Text = "ထုတ်ယူသည့်ကား";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DeliverQty";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn1.HeaderText = "စဉ်";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ExtraQty";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn2.HeaderText = "SaleDetailID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SalePrice";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn3.HeaderText = "Order ပို့ရန်";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Qty";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.NullValue = "0";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn4.HeaderText = "ShowRoom သို့ပို့ရန်";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DeliveryNoteDetailID";
            this.dataGridViewTextBoxColumn5.HeaderText = "အပိုယူသွားရန်";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // clnOrder
            // 
            this.clnOrder.DataPropertyName = "DeliveryQty";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.NullValue = "0";
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clnOrder.DefaultCellStyle = dataGridViewCellStyle11;
            this.clnOrder.HeaderText = "Order ပို့ရန်";
            this.clnOrder.MaxInputLength = 5;
            this.clnOrder.Name = "clnOrder";
            this.clnOrder.ReadOnly = true;
            this.clnOrder.Width = 80;
            // 
            // colShowQty
            // 
            this.colShowQty.DataPropertyName = "ShowroomQty";
            dataGridViewCellStyle12.NullValue = "0";
            this.colShowQty.DefaultCellStyle = dataGridViewCellStyle12;
            this.colShowQty.HeaderText = "ShowRooms သို့ပို့ရန်";
            this.colShowQty.Name = "colShowQty";
            this.colShowQty.ReadOnly = true;
            this.colShowQty.Visible = false;
            // 
            // clnExtra
            // 
            this.clnExtra.DataPropertyName = "ExtraQty";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.NullValue = "0";
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clnExtra.DefaultCellStyle = dataGridViewCellStyle13;
            this.clnExtra.HeaderText = "အပိုယူသွားရန်";
            this.clnExtra.MaxInputLength = 5;
            this.clnExtra.Name = "clnExtra";
            // 
            // clnAmount
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.NullValue = "0";
            this.clnAmount.DefaultCellStyle = dataGridViewCellStyle14;
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
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn6.HeaderText = "စုစု‌ပေါင်း";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // frmDeliveryNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 641);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmDeliveryNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeliveryNote";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryNote)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDelivery;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.DateTimePicker dtpDeliveryNoteDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbVenNo;
        private System.Windows.Forms.DataGridView dgvDeliveryNote;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ComboBox cmbSalePerson;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTotalAmt;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnBrandName;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShowQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExtra;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryNoteID;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEmpDisplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEmp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbRealVen;
        private System.Windows.Forms.Label label5;
    }
}