namespace PTIC.Sale.Setup
{
    partial class frmBrand
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
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblBrandName = new System.Windows.Forms.Label();
            this.lblConfirmBrand = new System.Windows.Forms.Label();
            this.lblStartBrand = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.dtpConfirmDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkIsOwnBrand = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblBrand);
            this.panel1.Controls.Add(this.lblSetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 41);
            this.panel1.TabIndex = 2;
            // 
            // lblBrand
            // 
            this.lblBrand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblBrand.Location = new System.Drawing.Point(61, 10);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(123, 17);
            this.lblBrand.TabIndex = 3;
            this.lblBrand.Text = ">    ကုန်အမှတ်တံဆိပ်";
            // 
            // lblSetup
            // 
            this.lblSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSetup.AutoSize = true;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetup.Location = new System.Drawing.Point(8, 10);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(44, 17);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Setup";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblBrandName
            // 
            this.lblBrandName.AutoSize = true;
            this.lblBrandName.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandName.Location = new System.Drawing.Point(20, 112);
            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Size = new System.Drawing.Size(101, 17);
            this.lblBrandName.TabIndex = 3;
            this.lblBrandName.Text = "အမှတ်တံဆိပ်အမည်";
            // 
            // lblConfirmBrand
            // 
            this.lblConfirmBrand.AutoSize = true;
            this.lblConfirmBrand.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmBrand.Location = new System.Drawing.Point(430, 69);
            this.lblConfirmBrand.Name = "lblConfirmBrand";
            this.lblConfirmBrand.Size = new System.Drawing.Size(129, 17);
            this.lblConfirmBrand.TabIndex = 4;
            this.lblConfirmBrand.Text = "Brand အတည်ပြုသည့်‌နေ့";
            // 
            // lblStartBrand
            // 
            this.lblStartBrand.AutoSize = true;
            this.lblStartBrand.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartBrand.Location = new System.Drawing.Point(429, 117);
            this.lblStartBrand.Name = "lblStartBrand";
            this.lblStartBrand.Size = new System.Drawing.Size(131, 17);
            this.lblStartBrand.TabIndex = 5;
            this.lblStartBrand.Text = "Brand စတင်သုံးစွဲသည့်‌နေ့";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(20, 151);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(49, 17);
            this.lblRemark.TabIndex = 6;
            this.lblRemark.Text = "မှတ်ချက်";
            // 
            // txtBrandName
            // 
            this.txtBrandName.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrandName.Location = new System.Drawing.Point(132, 112);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(139, 26);
            this.txtBrandName.TabIndex = 1;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(132, 151);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(574, 45);
            this.txtRemark.TabIndex = 4;
            // 
            // dtpConfirmDate
            // 
            this.dtpConfirmDate.CalendarFont = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpConfirmDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpConfirmDate.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpConfirmDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpConfirmDate.Location = new System.Drawing.Point(572, 64);
            this.dtpConfirmDate.Name = "dtpConfirmDate";
            this.dtpConfirmDate.Size = new System.Drawing.Size(134, 26);
            this.dtpConfirmDate.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CalendarFont = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(572, 112);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(134, 26);
            this.dtpStartDate.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(132, 238);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(244, 238);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 34);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "ပိတ်မည်";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkIsOwnBrand
            // 
            this.chkIsOwnBrand.AutoSize = true;
            this.chkIsOwnBrand.Checked = true;
            this.chkIsOwnBrand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsOwnBrand.Location = new System.Drawing.Point(132, 211);
            this.chkIsOwnBrand.Name = "chkIsOwnBrand";
            this.chkIsOwnBrand.Size = new System.Drawing.Size(108, 21);
            this.chkIsOwnBrand.TabIndex = 5;
            this.chkIsOwnBrand.Text = "Is Own Brand?";
            this.chkIsOwnBrand.UseVisualStyleBackColor = true;
            this.chkIsOwnBrand.Visible = false;
            // 
            // frmBrand
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(736, 285);
            this.Controls.Add(this.chkIsOwnBrand);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dtpConfirmDate);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtBrandName);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblStartBrand);
            this.Controls.Add(this.lblConfirmBrand);
            this.Controls.Add(this.lblBrandName);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(746, 317);
            this.MinimumSize = new System.Drawing.Size(746, 317);
            this.Name = "frmBrand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ကုန်အမှတ်တံဆိပ်";
            this.Load += new System.EventHandler(this.frmBrand_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.Label lblConfirmBrand;
        private System.Windows.Forms.Label lblStartBrand;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtBrandName;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.DateTimePicker dtpConfirmDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkIsOwnBrand;
    }
}