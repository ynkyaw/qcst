namespace PTIC.ReportViewer
{
    partial class frmRV_AP_UsageCustomersViewer
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rpAPusageCustomersViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoYearly = new System.Windows.Forms.RadioButton();
            this.rdoDaily = new System.Windows.Forms.RadioButton();
            this.rdoMonthly = new System.Windows.Forms.RadioButton();
            this.rdoWeekly = new System.Windows.Forms.RadioButton();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoDateRange = new System.Windows.Forms.RadioButton();
            this.rdoPosmNotUsedCus = new System.Windows.Forms.RadioButton();
            this.rdoUnUsedPosmByCus = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoAPUsageCus = new System.Windows.Forms.RadioButton();
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.panel4);
            this.pnlFilter.Controls.Add(this.panel2);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.dtpEnd);
            this.pnlFilter.Controls.Add(this.dtpStart);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 23);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1067, 124);
            this.pnlFilter.TabIndex = 196;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(199, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 190;
            this.label2.Text = "ထိ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 189;
            this.label1.Text = "မှ";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "dd-MMM-yyyy";
            this.dtpEnd.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(63, 43);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(130, 28);
            this.dtpEnd.TabIndex = 188;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "dd-MMM-yyyy";
            this.dtpStart.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(63, 9);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(130, 28);
            this.dtpStart.TabIndex = 187;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(937, 5);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.pnlFilt.Size = new System.Drawing.Size(1067, 23);
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
            this.panel1.Controls.Add(this.rpAPusageCustomersViewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 351);
            this.panel1.TabIndex = 197;
            // 
            // rpAPusageCustomersViewer
            // 
            this.rpAPusageCustomersViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpAPusageCustomersViewer.Location = new System.Drawing.Point(0, 0);
            this.rpAPusageCustomersViewer.Name = "rpAPusageCustomersViewer";
            this.rpAPusageCustomersViewer.Size = new System.Drawing.Size(1067, 351);
            this.rpAPusageCustomersViewer.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdoDateRange);
            this.panel2.Controls.Add(this.dtpDate);
            this.panel2.Controls.Add(this.rdoYearly);
            this.panel2.Controls.Add(this.rdoDaily);
            this.panel2.Controls.Add(this.rdoMonthly);
            this.panel2.Controls.Add(this.rdoWeekly);
            this.panel2.Location = new System.Drawing.Point(236, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 70);
            this.panel2.TabIndex = 206;
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
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(8, 20);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(117, 28);
            this.dtpDate.TabIndex = 204;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 191;
            this.label3.Text = "နေ့စွဲ";
            // 
            // rdoDateRange
            // 
            this.rdoDateRange.AutoSize = true;
            this.rdoDateRange.Location = new System.Drawing.Point(289, 6);
            this.rdoDateRange.Name = "rdoDateRange";
            this.rdoDateRange.Size = new System.Drawing.Size(100, 24);
            this.rdoDateRange.TabIndex = 205;
            this.rdoDateRange.TabStop = true;
            this.rdoDateRange.Text = "Date Range";
            this.rdoDateRange.UseVisualStyleBackColor = true;
            // 
            // rdoPosmNotUsedCus
            // 
            this.rdoPosmNotUsedCus.AutoSize = true;
            this.rdoPosmNotUsedCus.Location = new System.Drawing.Point(12, 70);
            this.rdoPosmNotUsedCus.Name = "rdoPosmNotUsedCus";
            this.rdoPosmNotUsedCus.Size = new System.Drawing.Size(273, 24);
            this.rdoPosmNotUsedCus.TabIndex = 207;
            this.rdoPosmNotUsedCus.Text = "A && P လုံးဝအသုံးပြုမထားသော Customer";
            this.rdoPosmNotUsedCus.UseVisualStyleBackColor = true;
            // 
            // rdoUnUsedPosmByCus
            // 
            this.rdoUnUsedPosmByCus.AutoSize = true;
            this.rdoUnUsedPosmByCus.Location = new System.Drawing.Point(12, 38);
            this.rdoUnUsedPosmByCus.Name = "rdoUnUsedPosmByCus";
            this.rdoUnUsedPosmByCus.Size = new System.Drawing.Size(258, 24);
            this.rdoUnUsedPosmByCus.TabIndex = 208;
            this.rdoUnUsedPosmByCus.Text = "Customer အသုံးမပြုရသေးသော A && P ";
            this.rdoUnUsedPosmByCus.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdoAPUsageCus);
            this.panel4.Controls.Add(this.rdoUnUsedPosmByCus);
            this.panel4.Controls.Add(this.rdoPosmNotUsedCus);
            this.panel4.Location = new System.Drawing.Point(633, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(298, 103);
            this.panel4.TabIndex = 207;
            // 
            // rdoAPUsageCus
            // 
            this.rdoAPUsageCus.AutoSize = true;
            this.rdoAPUsageCus.Checked = true;
            this.rdoAPUsageCus.Location = new System.Drawing.Point(12, 6);
            this.rdoAPUsageCus.Name = "rdoAPUsageCus";
            this.rdoAPUsageCus.Size = new System.Drawing.Size(236, 24);
            this.rdoAPUsageCus.TabIndex = 209;
            this.rdoAPUsageCus.TabStop = true;
            this.rdoAPUsageCus.Text = "A && P အသုံးပြုထားသော Customer";
            this.rdoAPUsageCus.UseVisualStyleBackColor = true;
            // 
            // frmRV_AP_UsageCustomersViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 498);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRV_AP_UsageCustomersViewer";
            this.Text = "A & P အသုံးပြုထားသော Customer များ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AP_UsageCustomersViewer_FormClosing);
            this.Load += new System.EventHandler(this.AP_UsageCustomersViewer_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer rpAPusageCustomersViewer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoYearly;
        private System.Windows.Forms.RadioButton rdoDaily;
        private System.Windows.Forms.RadioButton rdoMonthly;
        private System.Windows.Forms.RadioButton rdoWeekly;
        private System.Windows.Forms.RadioButton rdoUnUsedPosmByCus;
        private System.Windows.Forms.RadioButton rdoPosmNotUsedCus;
        private System.Windows.Forms.RadioButton rdoDateRange;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdoAPUsageCus;
    }
}