namespace PTIC.Marketing.Complaint
{
    partial class frmComplaintPage
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
            this.btnCustomerComplaint = new System.Windows.Forms.Button();
            this.btnCusComplaintRegistered = new System.Windows.Forms.Button();
            this.btnCustomerComplaintRecList = new System.Windows.Forms.Button();
            this.btnCusComplaintRegList = new System.Windows.Forms.Button();
            this.btnComplaintSummaryReport = new System.Windows.Forms.Button();
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
            this.panel1.Size = new System.Drawing.Size(926, 41);
            this.panel1.TabIndex = 39;
            // 
            // lblSetup
            // 
            this.lblSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSetup.AutoSize = true;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetup.Location = new System.Drawing.Point(8, 9);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(221, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Customer Relationship(CRM)";
            // 
            // btnCustomerComplaint
            // 
            this.btnCustomerComplaint.Location = new System.Drawing.Point(34, 90);
            this.btnCustomerComplaint.Name = "btnCustomerComplaint";
            this.btnCustomerComplaint.Size = new System.Drawing.Size(176, 54);
            this.btnCustomerComplaint.TabIndex = 40;
            this.btnCustomerComplaint.Text = "Complaint Receive Form";
            this.btnCustomerComplaint.UseVisualStyleBackColor = true;
            this.btnCustomerComplaint.Click += new System.EventHandler(this.btnCustomerComplaint_Click);
            // 
            // btnCusComplaintRegistered
            // 
            this.btnCusComplaintRegistered.Location = new System.Drawing.Point(436, 90);
            this.btnCusComplaintRegistered.Name = "btnCusComplaintRegistered";
            this.btnCusComplaintRegistered.Size = new System.Drawing.Size(176, 54);
            this.btnCusComplaintRegistered.TabIndex = 41;
            this.btnCusComplaintRegistered.Text = "Customer Complaint Registered";
            this.btnCusComplaintRegistered.UseVisualStyleBackColor = true;
            this.btnCusComplaintRegistered.Visible = false;
            this.btnCusComplaintRegistered.Click += new System.EventHandler(this.btnCusComplaintRegistered_Click);
            // 
            // btnCustomerComplaintRecList
            // 
            this.btnCustomerComplaintRecList.Location = new System.Drawing.Point(34, 168);
            this.btnCustomerComplaintRecList.Name = "btnCustomerComplaintRecList";
            this.btnCustomerComplaintRecList.Size = new System.Drawing.Size(176, 54);
            this.btnCustomerComplaintRecList.TabIndex = 42;
            this.btnCustomerComplaintRecList.Text = "Complaint Forms";
            this.btnCustomerComplaintRecList.UseVisualStyleBackColor = true;
            this.btnCustomerComplaintRecList.Click += new System.EventHandler(this.btnCustomerComplaintRecList_Click);
            // 
            // btnCusComplaintRegList
            // 
            this.btnCusComplaintRegList.Location = new System.Drawing.Point(234, 90);
            this.btnCusComplaintRegList.Name = "btnCusComplaintRegList";
            this.btnCusComplaintRegList.Size = new System.Drawing.Size(176, 54);
            this.btnCusComplaintRegList.TabIndex = 43;
            this.btnCusComplaintRegList.Text = "Complaint Register";
            this.btnCusComplaintRegList.UseVisualStyleBackColor = true;
            this.btnCusComplaintRegList.Click += new System.EventHandler(this.btnCusComplaintRegList_Click);
            // 
            // btnComplaintSummaryReport
            // 
            this.btnComplaintSummaryReport.Location = new System.Drawing.Point(234, 168);
            this.btnComplaintSummaryReport.Name = "btnComplaintSummaryReport";
            this.btnComplaintSummaryReport.Size = new System.Drawing.Size(176, 54);
            this.btnComplaintSummaryReport.TabIndex = 44;
            this.btnComplaintSummaryReport.Text = "Complaint Summary";
            this.btnComplaintSummaryReport.UseVisualStyleBackColor = true;
            this.btnComplaintSummaryReport.Click += new System.EventHandler(this.btnComplaintSummaryReport_Click);
            // 
            // frmComplaintPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 563);
            this.Controls.Add(this.btnComplaintSummaryReport);
            this.Controls.Add(this.btnCusComplaintRegList);
            this.Controls.Add(this.btnCustomerComplaintRecList);
            this.Controls.Add(this.btnCusComplaintRegistered);
            this.Controls.Add(this.btnCustomerComplaint);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Name = "frmComplaintPage";
            this.Text = "Customer Relationship(CRM)";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Button btnCustomerComplaint;
        private System.Windows.Forms.Button btnCusComplaintRegistered;
        private System.Windows.Forms.Button btnCustomerComplaintRecList;
        private System.Windows.Forms.Button btnCusComplaintRegList;
        private System.Windows.Forms.Button btnComplaintSummaryReport;
    }
}