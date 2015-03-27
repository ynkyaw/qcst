namespace PTIC.Sale.OfficeSales
{
    partial class frmVenReturn
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblSalePage = new System.Windows.Forms.Label();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSalesPersonName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbVehicle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvVenReturn = new System.Windows.Forms.DataGridView();
            this.colProduct = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbShowroom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSalesPerson = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenReturn)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(661, 41);
            this.panel1.TabIndex = 29;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(175, 9);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(114, 19);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">  Van Return";
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
            this.lblSalePage.Size = new System.Drawing.Size(155, 19);
            this.lblSalePage.TabIndex = 0;
            this.lblSalePage.Text = "ကုန်ပစ္စည်း အဝင်/အထွက်";
            this.lblSalePage.Click += new System.EventHandler(this.lblSalePage_Click);
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpReturnDate.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReturnDate.Location = new System.Drawing.Point(496, 56);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(150, 25);
            this.dtpReturnDate.TabIndex = 152;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(349, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 19);
            this.label3.TabIndex = 151;
            this.label3.Text = "‌နေ့စွဲ";
            // 
            // txtSalesPersonName
            // 
            this.txtSalesPersonName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesPersonName.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesPersonName.Location = new System.Drawing.Point(496, 94);
            this.txtSalesPersonName.Name = "txtSalesPersonName";
            this.txtSalesPersonName.ReadOnly = true;
            this.txtSalesPersonName.Size = new System.Drawing.Size(149, 25);
            this.txtSalesPersonName.TabIndex = 155;
            this.txtSalesPersonName.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(349, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 19);
            this.label5.TabIndex = 154;
            this.label5.Text = "အ‌ရောင်းဝန်ထမ်းအမည်";
            // 
            // cmbVehicle
            // 
            this.cmbVehicle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVehicle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVehicle.DisplayMember = "VenNo";
            this.cmbVehicle.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVehicle.FormattingEnabled = true;
            this.cmbVehicle.Location = new System.Drawing.Point(140, 58);
            this.cmbVehicle.Name = "cmbVehicle";
            this.cmbVehicle.Size = new System.Drawing.Size(150, 25);
            this.cmbVehicle.TabIndex = 150;
            this.cmbVehicle.ValueMember = "VehicleID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 19);
            this.label1.TabIndex = 153;
            this.label1.Text = "အ‌ရောင်းကားနံပါတ်";
            // 
            // dgvVenReturn
            // 
            this.dgvVenReturn.AllowUserToAddRows = false;
            this.dgvVenReturn.AllowUserToDeleteRows = false;
            this.dgvVenReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVenReturn.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVenReturn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVenReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVenReturn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProduct,
            this.colQty,
            this.colRemark});
            this.dgvVenReturn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvVenReturn.Location = new System.Drawing.Point(12, 142);
            this.dgvVenReturn.MultiSelect = false;
            this.dgvVenReturn.Name = "dgvVenReturn";
            this.dgvVenReturn.RowHeadersWidth = 50;
            this.dgvVenReturn.RowTemplate.Height = 28;
            this.dgvVenReturn.Size = new System.Drawing.Size(638, 401);
            this.dgvVenReturn.TabIndex = 156;
            this.dgvVenReturn.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVenReturn_CellEndEdit);
            this.dgvVenReturn.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvVenReturn_CellValidating);
            this.dgvVenReturn.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvVenReturn_DataBindingComplete);
            this.dgvVenReturn.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvVenReturn_DataError);
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
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQty.HeaderText = "အ‌ရေအတွက်";
            this.colQty.Name = "colQty";
            this.colQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colRemark
            // 
            this.colRemark.HeaderText = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRemark.Width = 180;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(131, 554);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 158;
            this.btnDelete.Text = "ပယ်ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 554);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 157;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbShowroom
            // 
            this.cmbShowroom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbShowroom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbShowroom.DisplayMember = "Warehouse";
            this.cmbShowroom.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShowroom.FormattingEnabled = true;
            this.cmbShowroom.Location = new System.Drawing.Point(140, 94);
            this.cmbShowroom.Name = "cmbShowroom";
            this.cmbShowroom.Size = new System.Drawing.Size(150, 25);
            this.cmbShowroom.TabIndex = 159;
            this.cmbShowroom.ValueMember = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 19);
            this.label2.TabIndex = 160;
            this.label2.Text = "ShowRoom အမည်";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(295, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 19);
            this.label4.TabIndex = 161;
            this.label4.Text = "မှ";
            // 
            // cboSalesPerson
            // 
            this.cboSalesPerson.FormattingEnabled = true;
            this.cboSalesPerson.Location = new System.Drawing.Point(496, 94);
            this.cboSalesPerson.Name = "cboSalesPerson";
            this.cboSalesPerson.Size = new System.Drawing.Size(149, 25);
            this.cboSalesPerson.TabIndex = 162;
            // 
            // frmVenReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 595);
            this.Controls.Add(this.cboSalesPerson);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbShowroom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvVenReturn);
            this.Controls.Add(this.dtpReturnDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSalesPersonName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbVehicle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmVenReturn";
            this.Text = "Van Return";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenReturn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblSalePage;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSalesPersonName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbVehicle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvVenReturn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbShowroom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewComboBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.ComboBox cboSalesPerson;
    }
}