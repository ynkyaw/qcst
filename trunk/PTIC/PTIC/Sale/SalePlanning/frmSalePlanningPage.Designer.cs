namespace PTIC.Sale.SalePlanning
{
    partial class frmSalePlanningPage
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
            this.btnSalesPlanforProduction = new System.Windows.Forms.Button();
            this.btnN100Convert = new System.Windows.Forms.Button();
            this.btnTripPlan = new System.Windows.Forms.Button();
            this.btnRoutePlan = new System.Windows.Forms.Button();
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
            this.panel1.Size = new System.Drawing.Size(923, 41);
            this.panel1.TabIndex = 27;
            // 
            // lblSetup
            // 
            this.lblSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSetup.AutoSize = true;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetup.Location = new System.Drawing.Point(8, 9);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(73, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Planning";
            // 
            // btnSalesPlanforProduction
            // 
            this.btnSalesPlanforProduction.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesPlanforProduction.Location = new System.Drawing.Point(30, 90);
            this.btnSalesPlanforProduction.Name = "btnSalesPlanforProduction";
            this.btnSalesPlanforProduction.Size = new System.Drawing.Size(172, 54);
            this.btnSalesPlanforProduction.TabIndex = 26;
            this.btnSalesPlanforProduction.Text = "Sales Plan for Production";
            this.btnSalesPlanforProduction.UseVisualStyleBackColor = true;
            this.btnSalesPlanforProduction.Click += new System.EventHandler(this.btnSalesPlanforProduction_Click);
            // 
            // btnN100Convert
            // 
            this.btnN100Convert.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnN100Convert.Location = new System.Drawing.Point(30, 168);
            this.btnN100Convert.Name = "btnN100Convert";
            this.btnN100Convert.Size = new System.Drawing.Size(172, 54);
            this.btnN100Convert.TabIndex = 28;
            this.btnN100Convert.Text = "N100 Convert";
            this.btnN100Convert.UseVisualStyleBackColor = true;
            this.btnN100Convert.Visible = false;
            // 
            // btnTripPlan
            // 
            this.btnTripPlan.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTripPlan.Location = new System.Drawing.Point(234, 90);
            this.btnTripPlan.Name = "btnTripPlan";
            this.btnTripPlan.Size = new System.Drawing.Size(172, 54);
            this.btnTripPlan.TabIndex = 29;
            this.btnTripPlan.Text = "ခရီးစဉ် Plan";
            this.btnTripPlan.UseVisualStyleBackColor = true;
            this.btnTripPlan.Click += new System.EventHandler(this.btnTripPlan_Click);
            // 
            // btnRoutePlan
            // 
            this.btnRoutePlan.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoutePlan.Location = new System.Drawing.Point(234, 168);
            this.btnRoutePlan.Name = "btnRoutePlan";
            this.btnRoutePlan.Size = new System.Drawing.Size(172, 54);
            this.btnRoutePlan.TabIndex = 30;
            this.btnRoutePlan.Text = "လမ်း‌ကြောင်း Plan";
            this.btnRoutePlan.UseVisualStyleBackColor = true;
            this.btnRoutePlan.Visible = false;
            this.btnRoutePlan.Click += new System.EventHandler(this.btnRoutePlan_Click);
            // 
            // frmSalePlanningPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 588);
            this.Controls.Add(this.btnRoutePlan);
            this.Controls.Add(this.btnTripPlan);
            this.Controls.Add(this.btnN100Convert);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalesPlanforProduction);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmSalePlanningPage";
            this.Text = "Sale Planning Page";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Button btnSalesPlanforProduction;
        private System.Windows.Forms.Button btnN100Convert;
        private System.Windows.Forms.Button btnTripPlan;
        private System.Windows.Forms.Button btnRoutePlan;
    }
}