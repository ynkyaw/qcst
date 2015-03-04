namespace PTIC.Sale.Setup
{
    partial class frmPriceChange
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblSetup = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblProductBrand = new System.Windows.Forms.Label();
            this.txtWSNo = new System.Windows.Forms.TextBox();
            this.lblWholeSale = new System.Windows.Forms.Label();
            this.txtRSNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWholeSalePrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRetailSalePrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpTranDate = new System.Windows.Forms.DateTimePicker();
            this.txtAcidPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Controls.Add(this.lblSetup);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 41);
            this.panel1.TabIndex = 3;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHeader.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeader.Location = new System.Drawing.Point(61, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(196, 17);
            this.lblHeader.TabIndex = 44;
            this.lblHeader.Text = ">   ‌ဈေးနှုန်း‌ပြောင်းလဲသတ်မှတ်ခြင်း";
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(8, 9);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(44, 17);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Setup";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(331, 4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(19, 26);
            this.dtpEndDate.TabIndex = 77;
            this.dtpEndDate.Visible = false;
            // 
            // cmbProduct
            // 
            this.cmbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProduct.DisplayMember = "BrandID";
            this.cmbProduct.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(131, 156);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(208, 25);
            this.cmbProduct.TabIndex = 63;
            this.cmbProduct.ValueMember = "BrandID";
            // 
            // lblProductBrand
            // 
            this.lblProductBrand.AutoSize = true;
            this.lblProductBrand.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductBrand.Location = new System.Drawing.Point(10, 157);
            this.lblProductBrand.Name = "lblProductBrand";
            this.lblProductBrand.Size = new System.Drawing.Size(82, 17);
            this.lblProductBrand.TabIndex = 64;
            this.lblProductBrand.Text = "ထုတ်ကုန်အမည်";
            // 
            // txtWSNo
            // 
            this.txtWSNo.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWSNo.Location = new System.Drawing.Point(131, 192);
            this.txtWSNo.MaxLength = 15;
            this.txtWSNo.Name = "txtWSNo";
            this.txtWSNo.Size = new System.Drawing.Size(208, 26);
            this.txtWSNo.TabIndex = 66;
            // 
            // lblWholeSale
            // 
            this.lblWholeSale.AutoSize = true;
            this.lblWholeSale.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWholeSale.Location = new System.Drawing.Point(10, 193);
            this.lblWholeSale.Name = "lblWholeSale";
            this.lblWholeSale.Size = new System.Drawing.Size(91, 17);
            this.lblWholeSale.TabIndex = 65;
            this.lblWholeSale.Text = "WholeSale No.";
            // 
            // txtRSNo
            // 
            this.txtRSNo.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRSNo.Location = new System.Drawing.Point(131, 227);
            this.txtRSNo.MaxLength = 15;
            this.txtRSNo.Name = "txtRSNo";
            this.txtRSNo.Size = new System.Drawing.Size(208, 26);
            this.txtRSNo.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 67;
            this.label1.Text = "RetailSale No.";
            // 
            // txtWholeSalePrice
            // 
            this.txtWholeSalePrice.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWholeSalePrice.Location = new System.Drawing.Point(131, 262);
            this.txtWholeSalePrice.MaxLength = 10;
            this.txtWholeSalePrice.Name = "txtWholeSalePrice";
            this.txtWholeSalePrice.Size = new System.Drawing.Size(208, 26);
            this.txtWholeSalePrice.TabIndex = 70;
            this.txtWholeSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWholeSalePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWholeSalePrice_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 69;
            this.label2.Text = "လက်ကား‌ဈေး";
            // 
            // txtRetailSalePrice
            // 
            this.txtRetailSalePrice.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetailSalePrice.Location = new System.Drawing.Point(131, 297);
            this.txtRetailSalePrice.MaxLength = 10;
            this.txtRetailSalePrice.Name = "txtRetailSalePrice";
            this.txtRetailSalePrice.Size = new System.Drawing.Size(208, 26);
            this.txtRetailSalePrice.TabIndex = 72;
            this.txtRetailSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRetailSalePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetailSalePrice_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 71;
            this.label3.Text = "လက်လီ‌ဈေး";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 73;
            this.label4.Text = "‌ဈေးနှုန်း‌ပြောင်းမည့်‌နေ့";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(131, 121);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(208, 26);
            this.dtpStartDate.TabIndex = 74;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(244, 376);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 34);
            this.btnClose.TabIndex = 79;
            this.btnClose.Text = "ပိတ်မည်";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(131, 376);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 78;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 17);
            this.label7.TabIndex = 81;
            this.label7.Text = "‌နေ့စွဲ";
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.Enabled = false;
            this.dtpTranDate.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTranDate.Location = new System.Drawing.Point(131, 86);
            this.dtpTranDate.Name = "dtpTranDate";
            this.dtpTranDate.Size = new System.Drawing.Size(208, 26);
            this.dtpTranDate.TabIndex = 80;
            // 
            // txtAcidPrice
            // 
            this.txtAcidPrice.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcidPrice.Location = new System.Drawing.Point(131, 332);
            this.txtAcidPrice.MaxLength = 10;
            this.txtAcidPrice.Name = "txtAcidPrice";
            this.txtAcidPrice.Size = new System.Drawing.Size(208, 26);
            this.txtAcidPrice.TabIndex = 73;
            this.txtAcidPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 82;
            this.label5.Text = "Acid ‌ဈေး";
            // 
            // frmPriceChange
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(362, 426);
            this.Controls.Add(this.txtAcidPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpTranDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRetailSalePrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWholeSalePrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRSNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWSNo);
            this.Controls.Add(this.lblWholeSale);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.lblProductBrand);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPriceChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "‌ဈေးနှုန်း‌ပြောင်းလဲသတ်မှတ်ခြင်း";
            this.Load += new System.EventHandler(this.frmPriceChange_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label lblProductBrand;
        private System.Windows.Forms.TextBox txtWSNo;
        private System.Windows.Forms.Label lblWholeSale;
        private System.Windows.Forms.TextBox txtRSNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWholeSalePrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRetailSalePrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpTranDate;
        private System.Windows.Forms.TextBox txtAcidPrice;
        private System.Windows.Forms.Label label5;
    }
}