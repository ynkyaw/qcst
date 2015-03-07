﻿namespace PTIC.ReportViewer
{
    partial class frmRV_QOB_Marketing_2Viewer
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
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rpViewerMarketingQOB2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.cmbBrand);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Controls.Add(this.dtpStartDate);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 23);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(975, 79);
            this.pnlFilter.TabIndex = 196;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 188;
            this.label2.Text = "အမှတ်တံဆိပ်";
            // 
            // cmbBrand
            // 
            this.cmbBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBrand.DisplayMember = "BrandName";
            this.cmbBrand.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(108, 42);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(140, 27);
            this.cmbBrand.TabIndex = 187;
            this.cmbBrand.ValueMember = "BrandID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 186;
            this.label1.Text = "မှ နောက် နှစ်နှစ်အထိ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 20);
            this.label4.TabIndex = 185;
            this.label4.Text = "နှစ်";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1007, 100);
            this.panel3.TabIndex = 174;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(108, 8);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.ShowUpDown = true;
            this.dtpStartDate.Size = new System.Drawing.Size(70, 28);
            this.dtpStartDate.TabIndex = 184;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(320, 6);
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
            this.pnlFilt.Size = new System.Drawing.Size(975, 23);
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
            this.lblFilter.Size = new System.Drawing.Size(162, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Advance Search";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rpViewerMarketingQOB2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(975, 402);
            this.panel1.TabIndex = 197;
            // 
            // rpViewerMarketingQOB2
            // 
            this.rpViewerMarketingQOB2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpViewerMarketingQOB2.LocalReport.ReportEmbeddedResource = "PTIC.Report.Marketing_QOB2.rdlc";
            this.rpViewerMarketingQOB2.Location = new System.Drawing.Point(0, 0);
            this.rpViewerMarketingQOB2.Name = "rpViewerMarketingQOB2";
            this.rpViewerMarketingQOB2.Size = new System.Drawing.Size(975, 402);
            this.rpViewerMarketingQOB2.TabIndex = 0;
            // 
            // frmRV_QOB_Marketing_2Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 504);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRV_QOB_Marketing_2Viewer";
            this.Text = "Monthly Quality Objective( QOB-2 )";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRV_QOB_Marketing_2Viewer_FormClosing);
            this.Load += new System.EventHandler(this.frmRV_QOB_Marketing_2Viewer_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBrand;
        private Microsoft.Reporting.WinForms.ReportViewer rpViewerMarketingQOB2;
    }
}