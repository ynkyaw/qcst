namespace PTIC.VC.Marketing
{
    partial class frmDailyMarketingPage
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
            this.btnGovMarketingLog = new System.Windows.Forms.Button();
            this.btnMarketingDetail = new System.Windows.Forms.Button();
            this.btnTripRequest = new System.Windows.Forms.Button();
            this.btnGovMarketingDetail = new System.Windows.Forms.Button();
            this.btnMarketingLog = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGovMarketingLog
            // 
            this.btnGovMarketingLog.Location = new System.Drawing.Point(33, 175);
            this.btnGovMarketingLog.Name = "btnGovMarketingLog";
            this.btnGovMarketingLog.Size = new System.Drawing.Size(176, 54);
            this.btnGovMarketingLog.TabIndex = 37;
            this.btnGovMarketingLog.Text = "Government Marketing Log";
            this.btnGovMarketingLog.UseVisualStyleBackColor = true;
            this.btnGovMarketingLog.Click += new System.EventHandler(this.btnGovMarketingLog_Click);
            // 
            // btnMarketingDetail
            // 
            this.btnMarketingDetail.Location = new System.Drawing.Point(233, 97);
            this.btnMarketingDetail.Name = "btnMarketingDetail";
            this.btnMarketingDetail.Size = new System.Drawing.Size(176, 54);
            this.btnMarketingDetail.TabIndex = 36;
            this.btnMarketingDetail.Text = "Daily Marketing Detail (Non-customer)";
            this.btnMarketingDetail.UseVisualStyleBackColor = true;
            this.btnMarketingDetail.Click += new System.EventHandler(this.btnMarketingDetail_Click);
            // 
            // btnTripRequest
            // 
            this.btnTripRequest.Location = new System.Drawing.Point(33, 253);
            this.btnTripRequest.Name = "btnTripRequest";
            this.btnTripRequest.Size = new System.Drawing.Size(176, 54);
            this.btnTripRequest.TabIndex = 35;
            this.btnTripRequest.Text = "Trip Request";
            this.btnTripRequest.UseVisualStyleBackColor = true;
            this.btnTripRequest.Visible = false;
            this.btnTripRequest.Click += new System.EventHandler(this.btnTripRequest_Click);
            // 
            // btnGovMarketingDetail
            // 
            this.btnGovMarketingDetail.Location = new System.Drawing.Point(233, 175);
            this.btnGovMarketingDetail.Name = "btnGovMarketingDetail";
            this.btnGovMarketingDetail.Size = new System.Drawing.Size(176, 54);
            this.btnGovMarketingDetail.TabIndex = 34;
            this.btnGovMarketingDetail.Text = "Government Marketing Detail";
            this.btnGovMarketingDetail.UseVisualStyleBackColor = true;
            this.btnGovMarketingDetail.Click += new System.EventHandler(this.btnGovMarketingDetail_Click);
            // 
            // btnMarketingLog
            // 
            this.btnMarketingLog.Location = new System.Drawing.Point(33, 97);
            this.btnMarketingLog.Name = "btnMarketingLog";
            this.btnMarketingLog.Size = new System.Drawing.Size(176, 54);
            this.btnMarketingLog.TabIndex = 33;
            this.btnMarketingLog.Text = "Daily Marketing Log";
            this.btnMarketingLog.UseVisualStyleBackColor = true;
            this.btnMarketingLog.Click += new System.EventHandler(this.btnMarketingLog_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblSetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 41);
            this.panel1.TabIndex = 38;
            // 
            // lblSetup
            // 
            this.lblSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSetup.AutoSize = true;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetup.Location = new System.Drawing.Point(8, 9);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(127, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Daily Marketing";
            // 
            // frmDailyMarketingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGovMarketingLog);
            this.Controls.Add(this.btnMarketingDetail);
            this.Controls.Add(this.btnTripRequest);
            this.Controls.Add(this.btnGovMarketingDetail);
            this.Controls.Add(this.btnMarketingLog);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmDailyMarketingPage";
            this.Text = "Daily Marketing";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGovMarketingLog;
        private System.Windows.Forms.Button btnMarketingDetail;
        private System.Windows.Forms.Button btnTripRequest;
        private System.Windows.Forms.Button btnGovMarketingDetail;
        private System.Windows.Forms.Button btnMarketingLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;

    }
}