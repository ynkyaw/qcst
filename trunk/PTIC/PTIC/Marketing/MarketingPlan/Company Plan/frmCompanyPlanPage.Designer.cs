namespace PTIC.Marketing.MarketingPlan.Company_Plan
{
    partial class frmCompanyPlanPage
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
            this.btnMobileServiceDetail = new System.Windows.Forms.Button();
            this.btnMobileServiceLog = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblSetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 47);
            this.panel1.TabIndex = 48;
            // 
            // lblSetup
            // 
            this.lblSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSetup.AutoSize = true;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetup.Location = new System.Drawing.Point(9, 13);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(131, 19);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Mobile Service";
            // 
            // btnMobileServiceDetail
            // 
            this.btnMobileServiceDetail.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnMobileServiceDetail.Location = new System.Drawing.Point(32, 162);
            this.btnMobileServiceDetail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnMobileServiceDetail.Name = "btnMobileServiceDetail";
            this.btnMobileServiceDetail.Size = new System.Drawing.Size(198, 60);
            this.btnMobileServiceDetail.TabIndex = 47;
            this.btnMobileServiceDetail.Text = "Company Plan Detail";
            this.btnMobileServiceDetail.UseVisualStyleBackColor = true;
            this.btnMobileServiceDetail.Click += new System.EventHandler(this.btnMobileServiceDetail_Click);
            // 
            // btnMobileServiceLog
            // 
            this.btnMobileServiceLog.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnMobileServiceLog.Location = new System.Drawing.Point(32, 83);
            this.btnMobileServiceLog.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnMobileServiceLog.Name = "btnMobileServiceLog";
            this.btnMobileServiceLog.Size = new System.Drawing.Size(198, 60);
            this.btnMobileServiceLog.TabIndex = 45;
            this.btnMobileServiceLog.Text = "ComplanPlan Log";
            this.btnMobileServiceLog.UseVisualStyleBackColor = true;
            this.btnMobileServiceLog.Click += new System.EventHandler(this.btnMobileServiceLog_Click);
            // 
            // frmCompanyPlanPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 629);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMobileServiceDetail);
            this.Controls.Add(this.btnMobileServiceLog);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCompanyPlanPage";
            this.Text = "frmCompanyPlanPage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Button btnMobileServiceDetail;
        private System.Windows.Forms.Button btnMobileServiceLog;
    }
}