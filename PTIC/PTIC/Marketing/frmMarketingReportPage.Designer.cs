namespace PTIC.Marketing
{
    partial class frmMarketingReportPage
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
            this.lblSetup = new System.Windows.Forms.Label();
            this.btnAPBalance = new System.Windows.Forms.Button();
            this.btnAPUsageCustomer = new System.Windows.Forms.Button();
            this.btnCustomerTransition = new System.Windows.Forms.Button();
            this.btnWaitingOrPermanentCustomer = new System.Windows.Forms.Button();
            this.btnCompanyContact = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnYearlyCustomerTransition = new System.Windows.Forms.Button();
            this.btnMarketingNewOutletQOB = new System.Windows.Forms.Button();
            this.btnQOB5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnComplainMonthly = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblSetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 41);
            this.panel1.TabIndex = 33;
            // 
            // lblSetup
            // 
            this.lblSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSetup.AutoSize = true;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetup.Location = new System.Drawing.Point(8, 9);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(63, 19);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Report";
            // 
            // btnAPBalance
            // 
            this.btnAPBalance.Location = new System.Drawing.Point(43, 90);
            this.btnAPBalance.Name = "btnAPBalance";
            this.btnAPBalance.Size = new System.Drawing.Size(172, 57);
            this.btnAPBalance.TabIndex = 34;
            this.btnAPBalance.Text = "A && P လက်ကျန်";
            this.btnAPBalance.UseVisualStyleBackColor = true;
            this.btnAPBalance.Click += new System.EventHandler(this.btnAPBalance_Click);
            // 
            // btnAPUsageCustomer
            // 
            this.btnAPUsageCustomer.Location = new System.Drawing.Point(43, 171);
            this.btnAPUsageCustomer.Name = "btnAPUsageCustomer";
            this.btnAPUsageCustomer.Size = new System.Drawing.Size(172, 57);
            this.btnAPUsageCustomer.TabIndex = 35;
            this.btnAPUsageCustomer.Text = "A && P အသုံးပြုထားသော Customer များ";
            this.btnAPUsageCustomer.UseVisualStyleBackColor = true;
            this.btnAPUsageCustomer.Click += new System.EventHandler(this.btnAPUsageCustomer_Click);
            // 
            // btnCustomerTransition
            // 
            this.btnCustomerTransition.Location = new System.Drawing.Point(247, 90);
            this.btnCustomerTransition.Name = "btnCustomerTransition";
            this.btnCustomerTransition.Size = new System.Drawing.Size(172, 57);
            this.btnCustomerTransition.TabIndex = 36;
            this.btnCustomerTransition.Text = "Customer Transition Result";
            this.btnCustomerTransition.UseVisualStyleBackColor = true;
            this.btnCustomerTransition.Click += new System.EventHandler(this.btnCustomerTransition_Click);
            // 
            // btnWaitingOrPermanentCustomer
            // 
            this.btnWaitingOrPermanentCustomer.Location = new System.Drawing.Point(247, 252);
            this.btnWaitingOrPermanentCustomer.Name = "btnWaitingOrPermanentCustomer";
            this.btnWaitingOrPermanentCustomer.Size = new System.Drawing.Size(172, 57);
            this.btnWaitingOrPermanentCustomer.TabIndex = 37;
            this.btnWaitingOrPermanentCustomer.Text = "Waiting / Permanent Customer";
            this.btnWaitingOrPermanentCustomer.UseVisualStyleBackColor = true;
            this.btnWaitingOrPermanentCustomer.Visible = false;
            this.btnWaitingOrPermanentCustomer.Click += new System.EventHandler(this.btnWaitingOrPermanentCustomer_Click);
            // 
            // btnCompanyContact
            // 
            this.btnCompanyContact.Location = new System.Drawing.Point(451, 90);
            this.btnCompanyContact.Name = "btnCompanyContact";
            this.btnCompanyContact.Size = new System.Drawing.Size(172, 57);
            this.btnCompanyContact.TabIndex = 38;
            this.btnCompanyContact.Text = "Company Contact Report";
            this.btnCompanyContact.UseVisualStyleBackColor = true;
            this.btnCompanyContact.Click += new System.EventHandler(this.btnCompanyContact_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 57);
            this.button1.TabIndex = 39;
            this.button1.Text = "Daily Marketing Outlet Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnYearlyCustomerTransition
            // 
            this.btnYearlyCustomerTransition.Location = new System.Drawing.Point(247, 171);
            this.btnYearlyCustomerTransition.Name = "btnYearlyCustomerTransition";
            this.btnYearlyCustomerTransition.Size = new System.Drawing.Size(172, 57);
            this.btnYearlyCustomerTransition.TabIndex = 40;
            this.btnYearlyCustomerTransition.Text = "Yearly Customer Transition Result";
            this.btnYearlyCustomerTransition.UseVisualStyleBackColor = true;
            this.btnYearlyCustomerTransition.Click += new System.EventHandler(this.btnYearlyCustomerTransition_Click);
            // 
            // btnMarketingNewOutletQOB
            // 
            this.btnMarketingNewOutletQOB.Location = new System.Drawing.Point(655, 90);
            this.btnMarketingNewOutletQOB.Name = "btnMarketingNewOutletQOB";
            this.btnMarketingNewOutletQOB.Size = new System.Drawing.Size(172, 57);
            this.btnMarketingNewOutletQOB.TabIndex = 41;
            this.btnMarketingNewOutletQOB.Text = "Marketing QOB 2";
            this.btnMarketingNewOutletQOB.UseVisualStyleBackColor = true;
            this.btnMarketingNewOutletQOB.Click += new System.EventHandler(this.btnMarketingNewOutletQOB_Click);
            // 
            // btnQOB5
            // 
            this.btnQOB5.Location = new System.Drawing.Point(655, 171);
            this.btnQOB5.Name = "btnQOB5";
            this.btnQOB5.Size = new System.Drawing.Size(172, 57);
            this.btnQOB5.TabIndex = 42;
            this.btnQOB5.Text = "Marketing QOB 5";
            this.btnQOB5.UseVisualStyleBackColor = true;
            this.btnQOB5.Click += new System.EventHandler(this.btnQOB5_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(43, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 57);
            this.button2.TabIndex = 43;
            this.button2.Text = "Waiting / Permanent Customers Status";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnComplainMonthly
            // 
            this.btnComplainMonthly.Location = new System.Drawing.Point(247, 252);
            this.btnComplainMonthly.Name = "btnComplainMonthly";
            this.btnComplainMonthly.Size = new System.Drawing.Size(172, 57);
            this.btnComplainMonthly.TabIndex = 44;
            this.btnComplainMonthly.Text = "Monthly Customer Complain";
            this.btnComplainMonthly.UseVisualStyleBackColor = true;
            this.btnComplainMonthly.Click += new System.EventHandler(this.btnComplainMonthly_Click);
            // 
            // frmMarketingReportPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 386);
            this.Controls.Add(this.btnComplainMonthly);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnQOB5);
            this.Controls.Add(this.btnMarketingNewOutletQOB);
            this.Controls.Add(this.btnYearlyCustomerTransition);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCompanyContact);
            this.Controls.Add(this.btnCustomerTransition);
            this.Controls.Add(this.btnAPUsageCustomer);
            this.Controls.Add(this.btnAPBalance);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnWaitingOrPermanentCustomer);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMarketingReportPage";
            this.Text = "Report";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Button btnAPBalance;
        private System.Windows.Forms.Button btnAPUsageCustomer;
        private System.Windows.Forms.Button btnCustomerTransition;
        private System.Windows.Forms.Button btnWaitingOrPermanentCustomer;
        private System.Windows.Forms.Button btnCompanyContact;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnYearlyCustomerTransition;
        private System.Windows.Forms.Button btnMarketingNewOutletQOB;
        private System.Windows.Forms.Button btnQOB5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnComplainMonthly;
    }
}