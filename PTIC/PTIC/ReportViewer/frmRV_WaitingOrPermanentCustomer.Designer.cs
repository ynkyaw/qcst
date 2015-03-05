namespace PTIC.ReportViewer
{
    partial class frmRV_WaitingOrPermanentCustomer
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
            this.label1 = new System.Windows.Forms.Label();
            this.dptEndDate = new System.Windows.Forms.DateTimePicker();
            this.rdoPermanent = new System.Windows.Forms.RadioButton();
            this.rdoWaiting = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.rpViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.dptEndDate);
            this.pnlFilter.Controls.Add(this.rdoPermanent);
            this.pnlFilter.Controls.Add(this.rdoWaiting);
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 33);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1170, 47);
            this.pnlFilter.TabIndex = 196;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 178;
            this.label1.Text = "နေ့ရက်";
            // 
            // dptEndDate
            // 
            this.dptEndDate.CustomFormat = "MMM-yyyy";
            this.dptEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dptEndDate.Location = new System.Drawing.Point(83, 9);
            this.dptEndDate.Name = "dptEndDate";
            this.dptEndDate.ShowUpDown = true;
            this.dptEndDate.Size = new System.Drawing.Size(111, 28);
            this.dptEndDate.TabIndex = 177;
            // 
            // rdoPermanent
            // 
            this.rdoPermanent.AutoSize = true;
            this.rdoPermanent.Location = new System.Drawing.Point(351, 11);
            this.rdoPermanent.Name = "rdoPermanent";
            this.rdoPermanent.Size = new System.Drawing.Size(158, 24);
            this.rdoPermanent.TabIndex = 176;
            this.rdoPermanent.Text = "Permanent Customer";
            this.rdoPermanent.UseVisualStyleBackColor = true;
            // 
            // rdoWaiting
            // 
            this.rdoWaiting.AutoSize = true;
            this.rdoWaiting.Checked = true;
            this.rdoWaiting.Location = new System.Drawing.Point(202, 11);
            this.rdoWaiting.Name = "rdoWaiting";
            this.rdoWaiting.Size = new System.Drawing.Size(141, 24);
            this.rdoWaiting.TabIndex = 175;
            this.rdoWaiting.TabStop = true;
            this.rdoWaiting.Text = "Waiting Customer";
            this.rdoWaiting.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 126);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1343, 146);
            this.panel3.TabIndex = 174;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(562, 8);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
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
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(1170, 33);
            this.pnlFilt.TabIndex = 195;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lblFilter.Location = new System.Drawing.Point(3, 5);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(166, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Advance Search";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // rpViewer
            // 
            this.rpViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpViewer.Location = new System.Drawing.Point(0, 80);
            this.rpViewer.Name = "rpViewer";
            this.rpViewer.Size = new System.Drawing.Size(1170, 591);
            this.rpViewer.TabIndex = 197;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(545, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 22);
            this.label2.TabIndex = 179;
            // 
            // frmRV_WaitingOrPermanentCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 671);
            this.Controls.Add(this.rpViewer);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmRV_WaitingOrPermanentCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report: Waiting / Permanent Customer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRV_WaitingOrPermanentCustomer_FormClosing);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private Microsoft.Reporting.WinForms.ReportViewer rpViewer;
        private System.Windows.Forms.RadioButton rdoPermanent;
        private System.Windows.Forms.RadioButton rdoWaiting;
        private System.Windows.Forms.DateTimePicker dptEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}