namespace PTIC.VC.Marketing.Telemarketing
{
    partial class frmTeleMarketingPage
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
            this.btnMarketingLog = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnOrderList = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblSetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 48);
            this.panel1.TabIndex = 44;
            // 
            // lblSetup
            // 
            this.lblSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSetup.AutoSize = true;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetup.Location = new System.Drawing.Point(8, 12);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(113, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Telemarketing";
            // 
            // btnMarketingLog
            // 
            this.btnMarketingLog.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnMarketingLog.Location = new System.Drawing.Point(61, 129);
            this.btnMarketingLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMarketingLog.Name = "btnMarketingLog";
            this.btnMarketingLog.Size = new System.Drawing.Size(172, 54);
            this.btnMarketingLog.TabIndex = 39;
            this.btnMarketingLog.Text = "Telemarketing Log";
            this.btnMarketingLog.UseVisualStyleBackColor = true;
            this.btnMarketingLog.Click += new System.EventHandler(this.btnMarketingLog_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Location = new System.Drawing.Point(257, 129);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(172, 54);
            this.btnOrder.TabIndex = 45;
            this.btnOrder.Text = "Order လက်ခံခြင်း";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnOrderList
            // 
            this.btnOrderList.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderList.Location = new System.Drawing.Point(453, 129);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(172, 54);
            this.btnOrderList.TabIndex = 46;
            this.btnOrderList.Text = "Order စာရင်း";
            this.btnOrderList.UseVisualStyleBackColor = true;
            this.btnOrderList.Click += new System.EventHandler(this.btnOrderList_Click);
            // 
            // frmTeleMarketingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 669);
            this.Controls.Add(this.btnOrderList);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMarketingLog);
            this.Font = new System.Drawing.Font("Zawgyi-One", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTeleMarketingPage";
            this.Text = "Telemarketing";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Button btnMarketingLog;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnOrderList;
    }
}