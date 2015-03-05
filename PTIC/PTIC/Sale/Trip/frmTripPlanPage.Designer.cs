namespace PTIC.VC.Sale.Trip
{
    partial class frmTripPlanPage
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
            this.btn3MonthPlan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.btnTripRequest = new System.Windows.Forms.Button();
            this.btnRoutePlan = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn3MonthPlan
            // 
            this.btn3MonthPlan.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3MonthPlan.Location = new System.Drawing.Point(243, 171);
            this.btn3MonthPlan.Name = "btn3MonthPlan";
            this.btn3MonthPlan.Size = new System.Drawing.Size(172, 54);
            this.btn3MonthPlan.TabIndex = 2;
            this.btn3MonthPlan.Text = "3 Month Trip Plan";
            this.btn3MonthPlan.UseVisualStyleBackColor = true;
            this.btn3MonthPlan.Visible = false;
            this.btn3MonthPlan.Click += new System.EventHandler(this.btn3MonthPlan_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblSetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 41);
            this.panel1.TabIndex = 26;
            // 
            // lblSetup
            // 
            this.lblSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSetup.AutoSize = true;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetup.Location = new System.Drawing.Point(8, 9);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(103, 19);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "အရောင်းခရီးစဉ်";
            // 
            // btnTripRequest
            // 
            this.btnTripRequest.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnTripRequest.Location = new System.Drawing.Point(41, 71);
            this.btnTripRequest.Name = "btnTripRequest";
            this.btnTripRequest.Size = new System.Drawing.Size(172, 54);
            this.btnTripRequest.TabIndex = 27;
            this.btnTripRequest.Text = "အရောင်းခရီးစဉ်";
            this.btnTripRequest.UseVisualStyleBackColor = true;
            this.btnTripRequest.Click += new System.EventHandler(this.btnTripRequest_Click);
            // 
            // btnRoutePlan
            // 
            this.btnRoutePlan.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoutePlan.Location = new System.Drawing.Point(243, 85);
            this.btnRoutePlan.Name = "btnRoutePlan";
            this.btnRoutePlan.Size = new System.Drawing.Size(172, 54);
            this.btnRoutePlan.TabIndex = 28;
            this.btnRoutePlan.Text = "Route Plan";
            this.btnRoutePlan.UseVisualStyleBackColor = true;
            this.btnRoutePlan.Visible = false;
            this.btnRoutePlan.Click += new System.EventHandler(this.btnRoutePlan_Click);
            // 
            // frmTripPlanPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(923, 589);
            this.Controls.Add(this.btnRoutePlan);
            this.Controls.Add(this.btnTripRequest);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn3MonthPlan);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Name = "frmTripPlanPage";
            this.Text = "အရောင်းခရီးစဉ်";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn3MonthPlan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Button btnTripRequest;
        private System.Windows.Forms.Button btnRoutePlan;
    }
}