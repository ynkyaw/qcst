namespace PTIC.ReportViewer
{
    partial class frmRV_YearlySalesQty
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTownTownship = new System.Windows.Forms.ComboBox();
            this.cmbSalesType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbTripOrRoute = new System.Windows.Forms.ComboBox();
            this.rdoRoute = new System.Windows.Forms.RadioButton();
            this.rdoTrip = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.YearlySalesViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbTownTownship);
            this.panel1.Controls.Add(this.cmbSalesType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1193, 83);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 196;
            this.label2.Text = "မြို့ ၊ မြို့နယ်";
            // 
            // cmbTownTownship
            // 
            this.cmbTownTownship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTownTownship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTownTownship.Font = new System.Drawing.Font("Myanmar3", 11F);
            this.cmbTownTownship.FormattingEnabled = true;
            this.cmbTownTownship.ItemHeight = 22;
            this.cmbTownTownship.Location = new System.Drawing.Point(551, 24);
            this.cmbTownTownship.Margin = new System.Windows.Forms.Padding(0);
            this.cmbTownTownship.Name = "cmbTownTownship";
            this.cmbTownTownship.Size = new System.Drawing.Size(193, 30);
            this.cmbTownTownship.TabIndex = 192;
            // 
            // cmbSalesType
            // 
            this.cmbSalesType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSalesType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSalesType.Font = new System.Drawing.Font("Myanmar3", 11F);
            this.cmbSalesType.FormattingEnabled = true;
            this.cmbSalesType.ItemHeight = 22;
            this.cmbSalesType.Location = new System.Drawing.Point(983, 23);
            this.cmbSalesType.Margin = new System.Windows.Forms.Padding(0);
            this.cmbSalesType.Name = "cmbSalesType";
            this.cmbSalesType.Size = new System.Drawing.Size(191, 30);
            this.cmbSalesType.TabIndex = 194;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(901, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 193;
            this.label1.Text = "Sales Type";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(760, 24);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 30);
            this.btnSearch.TabIndex = 186;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 185;
            this.label4.Text = "ခုနှစ်";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(55, 28);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShowUpDown = true;
            this.dtpDate.Size = new System.Drawing.Size(72, 28);
            this.dtpDate.TabIndex = 184;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbTripOrRoute);
            this.panel3.Controls.Add(this.rdoRoute);
            this.panel3.Controls.Add(this.rdoTrip);
            this.panel3.Location = new System.Drawing.Point(133, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(324, 65);
            this.panel3.TabIndex = 195;
            // 
            // cmbTripOrRoute
            // 
            this.cmbTripOrRoute.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTripOrRoute.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTripOrRoute.Font = new System.Drawing.Font("Myanmar3", 11F);
            this.cmbTripOrRoute.FormattingEnabled = true;
            this.cmbTripOrRoute.ItemHeight = 22;
            this.cmbTripOrRoute.Location = new System.Drawing.Point(120, 14);
            this.cmbTripOrRoute.Margin = new System.Windows.Forms.Padding(0);
            this.cmbTripOrRoute.Name = "cmbTripOrRoute";
            this.cmbTripOrRoute.Size = new System.Drawing.Size(191, 30);
            this.cmbTripOrRoute.TabIndex = 189;
            this.cmbTripOrRoute.SelectedIndexChanged += new System.EventHandler(this.cmbTripOrRoute_SelectedIndexChanged);
            // 
            // rdoRoute
            // 
            this.rdoRoute.AutoSize = true;
            this.rdoRoute.Checked = true;
            this.rdoRoute.Font = new System.Drawing.Font("Myanmar3", 11F);
            this.rdoRoute.Location = new System.Drawing.Point(14, 31);
            this.rdoRoute.Margin = new System.Windows.Forms.Padding(0);
            this.rdoRoute.Name = "rdoRoute";
            this.rdoRoute.Size = new System.Drawing.Size(106, 26);
            this.rdoRoute.TabIndex = 187;
            this.rdoRoute.TabStop = true;
            this.rdoRoute.Text = "လမ်း‌ကြောင်း";
            this.rdoRoute.UseVisualStyleBackColor = true;
            this.rdoRoute.CheckedChanged += new System.EventHandler(this.rdoRoute_CheckedChanged);
            // 
            // rdoTrip
            // 
            this.rdoTrip.AutoSize = true;
            this.rdoTrip.Font = new System.Drawing.Font("Myanmar3", 11F);
            this.rdoTrip.Location = new System.Drawing.Point(14, 5);
            this.rdoTrip.Margin = new System.Windows.Forms.Padding(0);
            this.rdoTrip.Name = "rdoTrip";
            this.rdoTrip.Size = new System.Drawing.Size(69, 26);
            this.rdoTrip.TabIndex = 188;
            this.rdoTrip.Text = "ခရီးစဉ်";
            this.rdoTrip.UseVisualStyleBackColor = true;
            this.rdoTrip.CheckedChanged += new System.EventHandler(this.rdoTrip_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.YearlySalesViewer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 83);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1193, 635);
            this.panel2.TabIndex = 1;
            // 
            // YearlySalesViewer
            // 
            this.YearlySalesViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YearlySalesViewer.Location = new System.Drawing.Point(0, 0);
            this.YearlySalesViewer.Margin = new System.Windows.Forms.Padding(4);
            this.YearlySalesViewer.Name = "YearlySalesViewer";
            this.YearlySalesViewer.Size = new System.Drawing.Size(1193, 635);
            this.YearlySalesViewer.TabIndex = 0;
            // 
            // frmRV_YearlySalesQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 718);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmRV_YearlySalesQty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yearly Sales Quantity";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRV_YearlySalesQty_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRV_YearlySalesQty_FormClosed);
            this.Load += new System.EventHandler(this.frmRV_YearlySalesQty_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Microsoft.Reporting.WinForms.ReportViewer YearlySalesViewer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbSalesType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTripOrRoute;
        private System.Windows.Forms.RadioButton rdoTrip;
        private System.Windows.Forms.RadioButton rdoRoute;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTownTownship;
    }
}