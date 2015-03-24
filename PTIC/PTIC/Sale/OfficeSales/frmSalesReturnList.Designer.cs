namespace PTIC.Sale.OfficeSales
{
    partial class frmSalesReturnList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkCustomerName = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpOrderStart = new System.Windows.Forms.DateTimePicker();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.dgvSalesReturnList = new System.Windows.Forms.DataGridView();
            this.clnReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTownship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesReturnList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCustomer);
            this.panel1.Controls.Add(this.chkCustomerName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtpOrderStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 50);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvSalesReturnList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1028, 331);
            this.panel3.TabIndex = 2;
            // 
            // chkCustomerName
            // 
            this.chkCustomerName.AutoSize = true;
            this.chkCustomerName.Location = new System.Drawing.Point(238, 15);
            this.chkCustomerName.Name = "chkCustomerName";
            this.chkCustomerName.Size = new System.Drawing.Size(128, 24);
            this.chkCustomerName.TabIndex = 221;
            this.chkCustomerName.Text = "Customer အမည်";
            this.chkCustomerName.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 20);
            this.label8.TabIndex = 220;
            this.label8.Text = "နေ့စွဲ";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSearch.Location = new System.Drawing.Point(598, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 30);
            this.btnSearch.TabIndex = 219;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // dtpOrderStart
            // 
            this.dtpOrderStart.CustomFormat = "dd-MMM-yyyy";
            this.dtpOrderStart.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpOrderStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderStart.Location = new System.Drawing.Point(64, 12);
            this.dtpOrderStart.Name = "dtpOrderStart";
            this.dtpOrderStart.Size = new System.Drawing.Size(128, 28);
            this.dtpOrderStart.TabIndex = 218;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(372, 12);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(208, 28);
            this.txtCustomer.TabIndex = 222;
            // 
            // dgvSalesReturnList
            // 
            this.dgvSalesReturnList.AllowUserToAddRows = false;
            this.dgvSalesReturnList.AllowUserToDeleteRows = false;
            this.dgvSalesReturnList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesReturnList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesReturnList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesReturnList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnReturnDate,
            this.clnCustomerName,
            this.clnTown,
            this.clnTownship,
            this.clnInvoiceNo,
            this.clnProductName,
            this.clnQty,
            this.clnAmount});
            this.dgvSalesReturnList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesReturnList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSalesReturnList.Location = new System.Drawing.Point(0, 0);
            this.dgvSalesReturnList.Name = "dgvSalesReturnList";
            this.dgvSalesReturnList.ReadOnly = true;
            this.dgvSalesReturnList.RowHeadersWidth = 50;
            this.dgvSalesReturnList.RowTemplate.Height = 28;
            this.dgvSalesReturnList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesReturnList.Size = new System.Drawing.Size(1028, 331);
            this.dgvSalesReturnList.TabIndex = 171;
            // 
            // clnReturnDate
            // 
            this.clnReturnDate.HeaderText = "ReturnDate";
            this.clnReturnDate.Name = "clnReturnDate";
            this.clnReturnDate.ReadOnly = true;
            // 
            // clnCustomerName
            // 
            this.clnCustomerName.HeaderText = "CustomerName";
            this.clnCustomerName.Name = "clnCustomerName";
            this.clnCustomerName.ReadOnly = true;
            // 
            // clnTown
            // 
            this.clnTown.HeaderText = "Town";
            this.clnTown.Name = "clnTown";
            this.clnTown.ReadOnly = true;
            // 
            // clnTownship
            // 
            this.clnTownship.HeaderText = "Township";
            this.clnTownship.Name = "clnTownship";
            this.clnTownship.ReadOnly = true;
            // 
            // clnInvoiceNo
            // 
            this.clnInvoiceNo.HeaderText = "Invoice No.";
            this.clnInvoiceNo.Name = "clnInvoiceNo";
            this.clnInvoiceNo.ReadOnly = true;
            // 
            // clnProductName
            // 
            this.clnProductName.HeaderText = "ProductName";
            this.clnProductName.Name = "clnProductName";
            this.clnProductName.ReadOnly = true;
            // 
            // clnQty
            // 
            this.clnQty.HeaderText = "Qty";
            this.clnQty.Name = "clnQty";
            this.clnQty.ReadOnly = true;
            // 
            // clnAmount
            // 
            this.clnAmount.HeaderText = "Amount";
            this.clnAmount.Name = "clnAmount";
            this.clnAmount.ReadOnly = true;
            // 
            // frmSalesReturnList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 381);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSalesReturnList";
            this.Text = "frmSalesReturnList";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesReturnList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.CheckBox chkCustomerName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpOrderStart;
        private System.Windows.Forms.DataGridView dgvSalesReturnList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnReturnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTown;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTownship;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAmount;
    }
}