namespace PTIC.Sale.Setup
{
    partial class frmPriceChanges
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHProduct = new System.Windows.Forms.Label();
            this.lblSetup = new System.Windows.Forms.Label();
            this.dgvPriceChange = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new AGL.UI.Controls.CalendarColumn();
            this.calendarColumn2 = new AGL.UI.Controls.CalendarColumn();
            this.calendarColumn3 = new AGL.UI.Controls.CalendarColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.Button();
            this.PriceChangeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TranDate = new AGL.UI.Controls.CalendarColumn();
            this.colFromDate = new AGL.UI.Controls.CalendarColumn();
            this.colToDate = new AGL.UI.Controls.CalendarColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WSaleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetailNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWSPriceWithAcid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRSPriceWithAcid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceChange)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblHProduct);
            this.panel1.Controls.Add(this.lblSetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 41);
            this.panel1.TabIndex = 4;
            // 
            // lblHProduct
            // 
            this.lblHProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHProduct.AutoSize = true;
            this.lblHProduct.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold);
            this.lblHProduct.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHProduct.Location = new System.Drawing.Point(66, 10);
            this.lblHProduct.Name = "lblHProduct";
            this.lblHProduct.Size = new System.Drawing.Size(151, 17);
            this.lblHProduct.TabIndex = 4;
            this.lblHProduct.Text = ">    ‌ဈေးနှုန်း‌ပြောင်းလဲခြင်း";
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetup.Location = new System.Drawing.Point(13, 10);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(44, 17);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Setup";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // dgvPriceChange
            // 
            this.dgvPriceChange.AllowUserToAddRows = false;
            this.dgvPriceChange.AllowUserToDeleteRows = false;
            this.dgvPriceChange.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPriceChange.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPriceChange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPriceChange.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPriceChange.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPriceChange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceChange.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PriceChangeID,
            this.No,
            this.colProductID,
            this.TranDate,
            this.colFromDate,
            this.colToDate,
            this.ProductName,
            this.WSaleNo,
            this.WSalePrice,
            this.RetailNo,
            this.RetailPrice,
            this.colAcid,
            this.colWSPriceWithAcid,
            this.colRSPriceWithAcid});
            this.dgvPriceChange.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPriceChange.Location = new System.Drawing.Point(12, 59);
            this.dgvPriceChange.MinimumSize = new System.Drawing.Size(939, 472);
            this.dgvPriceChange.MultiSelect = false;
            this.dgvPriceChange.Name = "dgvPriceChange";
            this.dgvPriceChange.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPriceChange.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvPriceChange.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPriceChange.RowTemplate.Height = 30;
            this.dgvPriceChange.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPriceChange.Size = new System.Drawing.Size(1138, 472);
            this.dgvPriceChange.TabIndex = 54;
            this.dgvPriceChange.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvPriceChange_CellValidating);
            this.dgvPriceChange.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPriceChange_DataError);
            this.dgvPriceChange.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPriceChange_RowPostPaint);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(244, 544);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 57;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(12, 544);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 34);
            this.btnAdd.TabIndex = 56;
            this.btnAdd.Text = "ထည့်မည်";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.HeaderText = "စဉ်";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProductID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Product ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.DataPropertyName = "TranDate";
            this.calendarColumn1.HeaderText = "Transaction Date";
            this.calendarColumn1.Name = "calendarColumn1";
            // 
            // calendarColumn2
            // 
            this.calendarColumn2.DataPropertyName = "ChangeFromDate";
            this.calendarColumn2.HeaderText = "From Date";
            this.calendarColumn2.Name = "calendarColumn2";
            // 
            // calendarColumn3
            // 
            this.calendarColumn3.DataPropertyName = "ChangeToDate";
            this.calendarColumn3.HeaderText = "To Date";
            this.calendarColumn3.Name = "calendarColumn3";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "WholeSaleNo";
            this.dataGridViewTextBoxColumn3.HeaderText = "Whole Sale No.";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "WSPrice";
            this.dataGridViewTextBoxColumn4.HeaderText = "Whole Sale Price";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "RetailNo";
            this.dataGridViewTextBoxColumn5.HeaderText = "Retail No.";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "RSPrice";
            this.dataGridViewTextBoxColumn6.HeaderText = "Retail Price";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(128, 544);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 34);
            this.btnEdit.TabIndex = 58;
            this.btnEdit.Text = "ပြင်မည်";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // PriceChangeID
            // 
            this.PriceChangeID.DataPropertyName = "PriceChangeID";
            this.PriceChangeID.HeaderText = global::PTIC.Resource.errSelectRowToEdit;
            this.PriceChangeID.Name = "PriceChangeID";
            this.PriceChangeID.ReadOnly = true;
            this.PriceChangeID.Visible = false;
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.No.DefaultCellStyle = dataGridViewCellStyle3;
            this.No.HeaderText = "စဉ်";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 47;
            // 
            // colProductID
            // 
            this.colProductID.DataPropertyName = "ProductID";
            this.colProductID.HeaderText = "Product ID";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Visible = false;
            // 
            // TranDate
            // 
            this.TranDate.DataPropertyName = "TranDate";
            this.TranDate.HeaderText = "Transaction Date";
            this.TranDate.Name = "TranDate";
            this.TranDate.ReadOnly = true;
            // 
            // colFromDate
            // 
            this.colFromDate.DataPropertyName = "ChangeFromDate";
            this.colFromDate.HeaderText = "From Date";
            this.colFromDate.Name = "colFromDate";
            this.colFromDate.ReadOnly = true;
            // 
            // colToDate
            // 
            this.colToDate.DataPropertyName = "ChangeToDate";
            this.colToDate.HeaderText = "To Date";
            this.colToDate.Name = "colToDate";
            this.colToDate.ReadOnly = true;
            this.colToDate.Visible = false;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductName.Width = 145;
            // 
            // WSaleNo
            // 
            this.WSaleNo.DataPropertyName = "WholeSaleNo";
            this.WSaleNo.HeaderText = "Whole Sale No.";
            this.WSaleNo.Name = "WSaleNo";
            this.WSaleNo.ReadOnly = true;
            this.WSaleNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WSaleNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WSalePrice
            // 
            this.WSalePrice.DataPropertyName = "WSPrice";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.WSalePrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.WSalePrice.HeaderText = "Acid မပါ WS Price";
            this.WSalePrice.Name = "WSalePrice";
            this.WSalePrice.ReadOnly = true;
            this.WSalePrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WSalePrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RetailNo
            // 
            this.RetailNo.DataPropertyName = "RetailNo";
            this.RetailNo.HeaderText = "Retail No.";
            this.RetailNo.Name = "RetailNo";
            this.RetailNo.ReadOnly = true;
            this.RetailNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RetailNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RetailPrice
            // 
            this.RetailPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RetailPrice.DataPropertyName = "RSPrice";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.RetailPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.RetailPrice.HeaderText = "Acid မပါ RS Price";
            this.RetailPrice.Name = "RetailPrice";
            this.RetailPrice.ReadOnly = true;
            // 
            // colAcid
            // 
            this.colAcid.DataPropertyName = "AcidPrice";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.colAcid.DefaultCellStyle = dataGridViewCellStyle6;
            this.colAcid.HeaderText = "Acid တန်ဖိုး";
            this.colAcid.Name = "colAcid";
            this.colAcid.ReadOnly = true;
            // 
            // colWSPriceWithAcid
            // 
            this.colWSPriceWithAcid.DataPropertyName = "WSPriceWithAcid";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.colWSPriceWithAcid.DefaultCellStyle = dataGridViewCellStyle7;
            this.colWSPriceWithAcid.HeaderText = "Acid ပါ WS Price";
            this.colWSPriceWithAcid.Name = "colWSPriceWithAcid";
            this.colWSPriceWithAcid.ReadOnly = true;
            // 
            // colRSPriceWithAcid
            // 
            this.colRSPriceWithAcid.DataPropertyName = "RSPriceWithAcid";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.colRSPriceWithAcid.DefaultCellStyle = dataGridViewCellStyle8;
            this.colRSPriceWithAcid.HeaderText = "Acid ပါ RS Price";
            this.colRSPriceWithAcid.Name = "colRSPriceWithAcid";
            this.colRSPriceWithAcid.ReadOnly = true;
            // 
            // frmPriceChanges
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1162, 591);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvPriceChange);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(979, 627);
            this.Name = "frmPriceChanges";
            this.Text = "‌ဈေးနှုန်း‌ပြောင်းလဲခြင်း";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceChange)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHProduct;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.DataGridView dgvPriceChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private AGL.UI.Controls.CalendarColumn calendarColumn1;
        private AGL.UI.Controls.CalendarColumn calendarColumn2;
        private AGL.UI.Controls.CalendarColumn calendarColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceChangeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private AGL.UI.Controls.CalendarColumn TranDate;
        private AGL.UI.Controls.CalendarColumn colFromDate;
        private AGL.UI.Controls.CalendarColumn colToDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WSaleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn WSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetailNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWSPriceWithAcid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRSPriceWithAcid;

    }
}