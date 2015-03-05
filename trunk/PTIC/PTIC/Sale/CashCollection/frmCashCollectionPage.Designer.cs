namespace PTIC.Sale.CashCollection
{
    partial class frmCashCollectionPage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSalePage = new System.Windows.Forms.Label();
            this.DebtorsList = new System.Windows.Forms.Button();
            this.btnRecipt_MultiInvoices = new System.Windows.Forms.Button();
            this.btnReceiptVoucherList = new System.Windows.Forms.Button();
            this.btnReceiptVoucher = new System.Windows.Forms.Button();
            this.btnReciptList_MultiInvoices = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblSalePage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 41);
            this.panel1.TabIndex = 28;
            // 
            // lblSalePage
            // 
            this.lblSalePage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSalePage.AutoSize = true;
            this.lblSalePage.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalePage.Location = new System.Drawing.Point(8, 10);
            this.lblSalePage.Name = "lblSalePage";
            this.lblSalePage.Size = new System.Drawing.Size(123, 20);
            this.lblSalePage.TabIndex = 0;
            this.lblSalePage.Text = "Cash Collection";
            // 
            // DebtorsList
            // 
            this.DebtorsList.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebtorsList.Location = new System.Drawing.Point(30, 90);
            this.DebtorsList.Name = "DebtorsList";
            this.DebtorsList.Size = new System.Drawing.Size(172, 54);
            this.DebtorsList.TabIndex = 65;
            this.DebtorsList.Text = "အ‌ကြွေးလက်ကျန်စာရင်း";
            this.DebtorsList.UseVisualStyleBackColor = true;
            this.DebtorsList.Click += new System.EventHandler(this.DebtorsList_Click);
            // 
            // btnRecipt_MultiInvoices
            // 
            this.btnRecipt_MultiInvoices.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecipt_MultiInvoices.Location = new System.Drawing.Point(438, 90);
            this.btnRecipt_MultiInvoices.Name = "btnRecipt_MultiInvoices";
            this.btnRecipt_MultiInvoices.Size = new System.Drawing.Size(172, 54);
            this.btnRecipt_MultiInvoices.TabIndex = 64;
            this.btnRecipt_MultiInvoices.Text = "          Receipt              (Multiple Invoices)";
            this.btnRecipt_MultiInvoices.UseVisualStyleBackColor = true;
            this.btnRecipt_MultiInvoices.Click += new System.EventHandler(this.btnRecipt_MultiInvoices_Click);
            // 
            // btnReceiptVoucherList
            // 
            this.btnReceiptVoucherList.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiptVoucherList.Location = new System.Drawing.Point(234, 168);
            this.btnReceiptVoucherList.Name = "btnReceiptVoucherList";
            this.btnReceiptVoucherList.Size = new System.Drawing.Size(172, 54);
            this.btnReceiptVoucherList.TabIndex = 63;
            this.btnReceiptVoucherList.Text = "Receipt List";
            this.btnReceiptVoucherList.UseVisualStyleBackColor = true;
            this.btnReceiptVoucherList.Click += new System.EventHandler(this.btnReceiptVoucherList_Click);
            // 
            // btnReceiptVoucher
            // 
            this.btnReceiptVoucher.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceiptVoucher.Location = new System.Drawing.Point(234, 90);
            this.btnReceiptVoucher.Name = "btnReceiptVoucher";
            this.btnReceiptVoucher.Size = new System.Drawing.Size(172, 54);
            this.btnReceiptVoucher.TabIndex = 62;
            this.btnReceiptVoucher.Text = "Receipt ";
            this.btnReceiptVoucher.UseVisualStyleBackColor = true;
            this.btnReceiptVoucher.Click += new System.EventHandler(this.btnReceiptVoucher_Click);
            // 
            // btnReciptList_MultiInvoices
            // 
            this.btnReciptList_MultiInvoices.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReciptList_MultiInvoices.Location = new System.Drawing.Point(438, 168);
            this.btnReciptList_MultiInvoices.Name = "btnReciptList_MultiInvoices";
            this.btnReciptList_MultiInvoices.Size = new System.Drawing.Size(172, 54);
            this.btnReciptList_MultiInvoices.TabIndex = 66;
            this.btnReciptList_MultiInvoices.Text = "         Receipt List            (Multiple Invoices)";
            this.btnReciptList_MultiInvoices.UseVisualStyleBackColor = true;
            this.btnReciptList_MultiInvoices.Click += new System.EventHandler(this.btnReciptList_MultiInvoices_Click);
            // 
            // frmCashCollectionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 705);
            this.Controls.Add(this.btnReciptList_MultiInvoices);
            this.Controls.Add(this.DebtorsList);
            this.Controls.Add(this.btnRecipt_MultiInvoices);
            this.Controls.Add(this.btnReceiptVoucherList);
            this.Controls.Add(this.btnReceiptVoucher);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmCashCollectionPage";
            this.Text = "Cash Collection";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSalePage;
        private System.Windows.Forms.Button DebtorsList;
        private System.Windows.Forms.Button btnRecipt_MultiInvoices;
        private System.Windows.Forms.Button btnReceiptVoucherList;
        private System.Windows.Forms.Button btnReceiptVoucher;
        private System.Windows.Forms.Button btnReciptList_MultiInvoices;
    }
}