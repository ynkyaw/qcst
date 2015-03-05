namespace PTIC.ReportViewer
{
    partial class frmRV_CompanyContactViewer
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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.chkCustomerType = new System.Windows.Forms.CheckBox();
            this.chkTownTownship = new System.Windows.Forms.CheckBox();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.cmbTripOrRoute = new System.Windows.Forms.ComboBox();
            this.rdoTrip = new System.Windows.Forms.RadioButton();
            this.rdoRoute = new System.Windows.Forms.RadioButton();
            this.cmbTownTownship = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdoYearly = new System.Windows.Forms.RadioButton();
            this.rdoDaily = new System.Windows.Forms.RadioButton();
            this.rdoMonthly = new System.Windows.Forms.RadioButton();
            this.rdoWeekly = new System.Windows.Forms.RadioButton();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rpViewerCompanyContact = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlFilter.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.dtpDate);
            this.pnlFilter.Controls.Add(this.chkCustomerType);
            this.pnlFilter.Controls.Add(this.chkTownTownship);
            this.pnlFilter.Controls.Add(this.cmbCustomerType);
            this.pnlFilter.Controls.Add(this.cmbTripOrRoute);
            this.pnlFilter.Controls.Add(this.rdoTrip);
            this.pnlFilter.Controls.Add(this.rdoRoute);
            this.pnlFilter.Controls.Add(this.cmbTownTownship);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Controls.Add(this.panel2);
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 23);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1057, 80);
            this.pnlFilter.TabIndex = 196;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(611, 23);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(117, 28);
            this.dtpDate.TabIndex = 203;
            // 
            // chkCustomerType
            // 
            this.chkCustomerType.AutoSize = true;
            this.chkCustomerType.Location = new System.Drawing.Point(293, 41);
            this.chkCustomerType.Name = "chkCustomerType";
            this.chkCustomerType.Size = new System.Drawing.Size(125, 24);
            this.chkCustomerType.TabIndex = 198;
            this.chkCustomerType.Text = "Customer Type";
            this.chkCustomerType.UseVisualStyleBackColor = true;
            // 
            // chkTownTownship
            // 
            this.chkTownTownship.AutoSize = true;
            this.chkTownTownship.Location = new System.Drawing.Point(293, 10);
            this.chkTownTownship.Name = "chkTownTownship";
            this.chkTownTownship.Size = new System.Drawing.Size(98, 24);
            this.chkTownTownship.TabIndex = 179;
            this.chkTownTownship.Text = "မြို့ / မြို့နယ်";
            this.chkTownTownship.UseVisualStyleBackColor = true;
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomerType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomerType.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.ItemHeight = 17;
            this.cmbCustomerType.Location = new System.Drawing.Point(424, 41);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(167, 25);
            this.cmbCustomerType.TabIndex = 197;
            // 
            // cmbTripOrRoute
            // 
            this.cmbTripOrRoute.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTripOrRoute.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTripOrRoute.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTripOrRoute.FormattingEnabled = true;
            this.cmbTripOrRoute.ItemHeight = 17;
            this.cmbTripOrRoute.Location = new System.Drawing.Point(105, 23);
            this.cmbTripOrRoute.Name = "cmbTripOrRoute";
            this.cmbTripOrRoute.Size = new System.Drawing.Size(167, 25);
            this.cmbTripOrRoute.TabIndex = 178;
            // 
            // rdoTrip
            // 
            this.rdoTrip.AutoSize = true;
            this.rdoTrip.Location = new System.Drawing.Point(14, 10);
            this.rdoTrip.Name = "rdoTrip";
            this.rdoTrip.Size = new System.Drawing.Size(68, 24);
            this.rdoTrip.TabIndex = 177;
            this.rdoTrip.Text = "ခရီးစဉ်";
            this.rdoTrip.UseVisualStyleBackColor = true;
            this.rdoTrip.CheckedChanged += new System.EventHandler(this.rdoTrip_CheckedChanged);
            // 
            // rdoRoute
            // 
            this.rdoRoute.AutoSize = true;
            this.rdoRoute.Location = new System.Drawing.Point(13, 40);
            this.rdoRoute.Name = "rdoRoute";
            this.rdoRoute.Size = new System.Drawing.Size(101, 24);
            this.rdoRoute.TabIndex = 176;
            this.rdoRoute.Text = "လမ်း‌ကြောင်း";
            this.rdoRoute.UseVisualStyleBackColor = true;
            this.rdoRoute.CheckedChanged += new System.EventHandler(this.rdoRoute_CheckedChanged);
            // 
            // cmbTownTownship
            // 
            this.cmbTownTownship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTownTownship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTownTownship.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTownTownship.FormattingEnabled = true;
            this.cmbTownTownship.ItemHeight = 17;
            this.cmbTownTownship.Location = new System.Drawing.Point(424, 10);
            this.cmbTownTownship.Name = "cmbTownTownship";
            this.cmbTownTownship.Size = new System.Drawing.Size(167, 25);
            this.cmbTownTownship.TabIndex = 175;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(919, 23);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 70);
            this.panel2.TabIndex = 204;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdoYearly);
            this.panel3.Controls.Add(this.rdoDaily);
            this.panel3.Controls.Add(this.rdoMonthly);
            this.panel3.Controls.Add(this.rdoWeekly);
            this.panel3.Location = new System.Drawing.Point(603, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(310, 70);
            this.panel3.TabIndex = 205;
            // 
            // rdoYearly
            // 
            this.rdoYearly.AutoSize = true;
            this.rdoYearly.Location = new System.Drawing.Point(206, 36);
            this.rdoYearly.Name = "rdoYearly";
            this.rdoYearly.Size = new System.Drawing.Size(69, 24);
            this.rdoYearly.TabIndex = 202;
            this.rdoYearly.TabStop = true;
            this.rdoYearly.Text = "Yearly";
            this.rdoYearly.UseVisualStyleBackColor = true;
            // 
            // rdoDaily
            // 
            this.rdoDaily.AutoSize = true;
            this.rdoDaily.Checked = true;
            this.rdoDaily.Location = new System.Drawing.Point(131, 7);
            this.rdoDaily.Name = "rdoDaily";
            this.rdoDaily.Size = new System.Drawing.Size(61, 24);
            this.rdoDaily.TabIndex = 199;
            this.rdoDaily.TabStop = true;
            this.rdoDaily.Text = "Daily";
            this.rdoDaily.UseVisualStyleBackColor = true;
            // 
            // rdoMonthly
            // 
            this.rdoMonthly.AutoSize = true;
            this.rdoMonthly.Location = new System.Drawing.Point(206, 7);
            this.rdoMonthly.Name = "rdoMonthly";
            this.rdoMonthly.Size = new System.Drawing.Size(81, 24);
            this.rdoMonthly.TabIndex = 201;
            this.rdoMonthly.TabStop = true;
            this.rdoMonthly.Text = "Monthly";
            this.rdoMonthly.UseVisualStyleBackColor = true;
            // 
            // rdoWeekly
            // 
            this.rdoWeekly.AutoSize = true;
            this.rdoWeekly.Location = new System.Drawing.Point(131, 38);
            this.rdoWeekly.Name = "rdoWeekly";
            this.rdoWeekly.Size = new System.Drawing.Size(76, 24);
            this.rdoWeekly.TabIndex = 200;
            this.rdoWeekly.TabStop = true;
            this.rdoWeekly.Text = "Weekly";
            this.rdoWeekly.UseVisualStyleBackColor = true;
            // 
            // pnlFilt
            // 
            this.pnlFilt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(131)))), ((int)(((byte)(170)))));
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 0);
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(1057, 23);
            this.pnlFilt.TabIndex = 195;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lblFilter.Location = new System.Drawing.Point(3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(166, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Advance Search";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rpViewerCompanyContact);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 366);
            this.panel1.TabIndex = 197;
            // 
            // rpViewerCompanyContact
            // 
            this.rpViewerCompanyContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpViewerCompanyContact.LocalReport.ReportEmbeddedResource = "PTIC.Report.CompanyContactReport.rdlc";
            this.rpViewerCompanyContact.Location = new System.Drawing.Point(0, 0);
            this.rpViewerCompanyContact.Name = "rpViewerCompanyContact";
            this.rpViewerCompanyContact.Size = new System.Drawing.Size(1057, 366);
            this.rpViewerCompanyContact.TabIndex = 0;
            // 
            // frmRV_CompanyContactViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 469);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRV_CompanyContactViewer";
            this.Text = "Company Contact Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRV_CompanyContactViewer_FormClosing);
            this.Load += new System.EventHandler(this.frmRV_CompanyContactViewer_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.CheckBox chkCustomerType;
        private System.Windows.Forms.CheckBox chkTownTownship;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.ComboBox cmbTripOrRoute;
        private System.Windows.Forms.RadioButton rdoTrip;
        private System.Windows.Forms.RadioButton rdoRoute;
        private System.Windows.Forms.ComboBox cmbTownTownship;
        private System.Windows.Forms.RadioButton rdoWeekly;
        private System.Windows.Forms.RadioButton rdoDaily;
        private System.Windows.Forms.RadioButton rdoYearly;
        private System.Windows.Forms.RadioButton rdoMonthly;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer rpViewerCompanyContact;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}