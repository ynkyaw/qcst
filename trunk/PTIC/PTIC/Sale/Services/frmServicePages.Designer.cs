namespace PTIC.VC.Sale.Services
{
    partial class frmServicePages
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
            this.btnServiceReceive = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSalePage = new System.Windows.Forms.Label();
            this.btnServiceBatterySatatus = new System.Windows.Forms.Button();
            this.btnServiceBatteryList = new System.Windows.Forms.Button();
            this.btnBatteriesInFactory = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnServiceReceive
            // 
            this.btnServiceReceive.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnServiceReceive.Location = new System.Drawing.Point(30, 90);
            this.btnServiceReceive.Name = "btnServiceReceive";
            this.btnServiceReceive.Size = new System.Drawing.Size(172, 54);
            this.btnServiceReceive.TabIndex = 39;
            this.btnServiceReceive.Text = "Service Receive";
            this.btnServiceReceive.UseVisualStyleBackColor = true;
            this.btnServiceReceive.Click += new System.EventHandler(this.btnServiceReceive_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblSalePage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 41);
            this.panel1.TabIndex = 38;
            // 
            // lblSalePage
            // 
            this.lblSalePage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSalePage.AutoSize = true;
            this.lblSalePage.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSalePage.Location = new System.Drawing.Point(8, 9);
            this.lblSalePage.Name = "lblSalePage";
            this.lblSalePage.Size = new System.Drawing.Size(63, 20);
            this.lblSalePage.TabIndex = 0;
            this.lblSalePage.Text = "Service";
            // 
            // btnServiceBatterySatatus
            // 
            this.btnServiceBatterySatatus.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnServiceBatterySatatus.Location = new System.Drawing.Point(234, 90);
            this.btnServiceBatterySatatus.Name = "btnServiceBatterySatatus";
            this.btnServiceBatterySatatus.Size = new System.Drawing.Size(172, 54);
            this.btnServiceBatterySatatus.TabIndex = 41;
            this.btnServiceBatterySatatus.Text = "Service Battery Status";
            this.btnServiceBatterySatatus.UseVisualStyleBackColor = true;
            this.btnServiceBatterySatatus.Click += new System.EventHandler(this.btnServiceBatterySatatus_Click);
            // 
            // btnServiceBatteryList
            // 
            this.btnServiceBatteryList.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnServiceBatteryList.Location = new System.Drawing.Point(234, 168);
            this.btnServiceBatteryList.Name = "btnServiceBatteryList";
            this.btnServiceBatteryList.Size = new System.Drawing.Size(172, 54);
            this.btnServiceBatteryList.TabIndex = 44;
            this.btnServiceBatteryList.Text = "Service Battery စာရင်း";
            this.btnServiceBatteryList.UseVisualStyleBackColor = true;
            this.btnServiceBatteryList.Click += new System.EventHandler(this.btnServiceBatteryList_Click);
            // 
            // btnBatteriesInFactory
            // 
            this.btnBatteriesInFactory.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnBatteriesInFactory.Location = new System.Drawing.Point(438, 90);
            this.btnBatteriesInFactory.Name = "btnBatteriesInFactory";
            this.btnBatteriesInFactory.Size = new System.Drawing.Size(172, 54);
            this.btnBatteriesInFactory.TabIndex = 45;
            this.btnBatteriesInFactory.Text = "Factory ရှိ Service Battery စာရင်း";
            this.btnBatteriesInFactory.UseVisualStyleBackColor = true;
            this.btnBatteriesInFactory.Click += new System.EventHandler(this.btnBatteriesInFactory_Click);
            // 
            // frmServicePages
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(916, 714);
            this.Controls.Add(this.btnBatteriesInFactory);
            this.Controls.Add(this.btnServiceBatteryList);
            this.Controls.Add(this.btnServiceBatterySatatus);
            this.Controls.Add(this.btnServiceReceive);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmServicePages";
            this.Text = "Service";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnServiceReceive;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSalePage;
        private System.Windows.Forms.Button btnServiceBatterySatatus;
        private System.Windows.Forms.Button btnServiceBatteryList;
        private System.Windows.Forms.Button btnBatteriesInFactory;
    }
}