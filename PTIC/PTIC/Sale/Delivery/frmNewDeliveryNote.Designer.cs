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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
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
            this.btnLoadOrder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.clnBrandName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clnProductName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clnOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnExtra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryNoteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShowQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryNote)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1010, 46);
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
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.button1);
            this.pnlGrid.Controls.Add(this.btnLoadOrder);
            this.pnlGrid.Controls.Add(this.cmbEmp);
            this.pnlGrid.Controls.Add(this.label4);
            this.pnlGrid.Controls.Add(this.cmbRealVen);
            this.pnlGrid.Controls.Add(this.label5);
            this.pnlGrid.Controls.Add(this.dtpDeliveryDisplay);
            this.pnlGrid.Controls.Add(this.label1);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrid.Location = new System.Drawing.Point(0, 46);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1010, 58);
            this.pnlGrid.TabIndex = 182;
            // 
            // cmbEmp
            // 
            this.cmbEmp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmp.DisplayMember = "EmpName";
            this.cmbEmp.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmp.FormattingEnabled = true;
            this.cmbEmp.Location = new System.Drawing.Point(397, 13);
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
            this.label4.Location = new System.Drawing.Point(324, 16);
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
            this.cmbRealVen.Location = new System.Drawing.Point(705, 13);
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
            this.label5.Location = new System.Drawing.Point(591, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 155;
            this.label5.Text = "ထုတ်ယူသည့်ကား";
            // 
            // dtpDeliveryDisplay
            // 
            this.dtpDeliveryDisplay.CustomFormat = "dd-MMM-yyyy";
            this.dtpDeliveryDisplay.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDeliveryDisplay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeliveryDisplay.Location = new System.Drawing.Point(183, 14);
            this.dtpDeliveryDisplay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtpDeliveryDisplay.Name = "dtpDeliveryDisplay";
            this.dtpDeliveryDisplay.Size = new System.Drawing.Size(117, 28);
            this.dtpDeliveryDisplay.TabIndex = 152;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(143, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
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
            this.panel2.Size = new System.Drawing.Size(1010, 83);
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
            this.label13.Size = new System.Drawing.Size(60, 20);
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
            this.txtTotalAmt.Size = new System.Drawing.Size(91, 28);
            this.txtTotalAmt.TabIndex = 167;
            this.txtTotalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvDeliveryNote
            // 
            this.dgvDeliveryNote.AllowUserToAddRows = false;
            this.dgvDeliveryNote.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeliveryNote.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.dgvDeliveryNote.Location = new System.Drawing.Point(0, 104);
            this.dgvDeliveryNote.Name = "dgvDeliveryNote";
            this.dgvDeliveryNote.RowHeadersWidth = 50;
            this.dgvDeliveryNote.RowTemplate.Height = 28;
            this.dgvDeliveryNote.Size = new System.Drawing.Size(1010, 382);
            this.dgvDeliveryNote.TabIndex = 184;
            this.dgvDeliveryNote.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDeliveryNote_CellBeginEdit);
            this.dgvDeliveryNote.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryNote_CellEndEdit);
            this.dgvDeliveryNote.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryNote_CellLeave);
            this.dgvDeliveryNote.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDeliveryNote_CellValidating);
            this.dgvDeliveryNote.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryNote_CellValueChanged);
            this.dgvDeliveryNote.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDeliveryNote_DataError);
            this.dgvDeliveryNote.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDeliveryNote_EditingControlShowing);
            // 
            // btnLoadOrder
            // 
            this.btnLoadOrder.Location = new System.Drawing.Point(885, 13);
            this.btnLoadOrder.Name = "btnLoadOrder";
            this.btnLoadOrder.Size = new System.Drawing.Size(95, 34);
            this.btnLoadOrder.TabIndex = 185;
            this.btnLoadOrder.Text = "Load Order";
            this.btnLoadOrder.UseVisualStyleBackColor = true;
            this.btnLoadOrder.Click += new System.EventHandler(this.btnLoadOrder_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 34);
            this.button1.TabIndex = 186;
            this.button1.Text = "For Trip Plan";
            this.button1.UseVisualStyleBackColor = true;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clnOrder.DefaultCellStyle = dataGridViewCellStyle2;
            this.clnOrder.HeaderText = "Order ပို့ရန်";
            this.clnOrder.MaxInputLength = 5;
            this.clnOrder.Name = "clnOrder";
            this.clnOrder.Width = 80;
            // 
            // clnExtra
            // 
            this.clnExtra.DataPropertyName = "ExtraQty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = "0";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clnExtra.DefaultCellStyle = dataGridViewCellStyle3;
            this.clnExtra.HeaderText = "အပိုယူသွားရန်";
            this.clnExtra.MaxInputLength = 5;
            this.clnExtra.Name = "clnExtra";
            // 
            // clnAmount
            // 
            this.clnAmount.DataPropertyName = "TotalQty";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.NullValue = "0";
            this.clnAmount.DefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.NullValue = "0";
            this.colShowQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.colShowQty.HeaderText = "ShowRooms သို့ပို့ရန်";
            this.colShowQty.Name = "colShowQty";
            this.colShowQty.ReadOnly = true;
            this.colShowQty.Visible = false;
            // 
            // frmNewDeliveryNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 569);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLoadOrder;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnBrandName;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExtra;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryNoteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShowQty;
    }
}