namespace PTIC.ReportViewer
{
    partial class frmRV_YearlyCustomerTransition
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dptStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.rpViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTrip = new System.Windows.Forms.ComboBox();
            this.cmbTown = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dptEndDate = new System.Windows.Forms.DateTimePicker();
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.label6);
            this.pnlFilter.Controls.Add(this.label5);
            this.pnlFilter.Controls.Add(this.cmbTown);
            this.pnlFilter.Controls.Add(this.cmbTrip);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Controls.Add(this.dptEndDate);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.cmbCustomerType);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.dptStartDate);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 33);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1342, 50);
            this.pnlFilter.TabIndex = 200;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(857, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 181;
            this.label3.Text = "Customer အမျိုးအစား";
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.DisplayMember = "CusTypeName";
            this.cmbCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Location = new System.Drawing.Point(1004, 12);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(112, 27);
            this.cmbCustomerType.TabIndex = 180;
            this.cmbCustomerType.ValueMember = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(1146, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 22);
            this.label2.TabIndex = 179;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 178;
            this.label1.Text = "စရက်";
            // 
            // dptStartDate
            // 
            this.dptStartDate.CustomFormat = "MMM-yyyy";
            this.dptStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dptStartDate.Location = new System.Drawing.Point(70, 11);
            this.dptStartDate.Name = "dptStartDate";
            this.dptStartDate.ShowUpDown = true;
            this.dptStartDate.Size = new System.Drawing.Size(111, 28);
            this.dptStartDate.TabIndex = 177;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1154, 10);
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
            this.pnlFilt.Size = new System.Drawing.Size(1342, 33);
            this.pnlFilt.TabIndex = 199;
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
            this.rpViewer.Location = new System.Drawing.Point(0, 83);
            this.rpViewer.Name = "rpViewer";
            this.rpViewer.Size = new System.Drawing.Size(1342, 469);
            this.rpViewer.TabIndex = 201;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 183;
            this.label4.Text = "ဆုံးရက်";
            // 
            // cmbTrip
            // 
            this.cmbTrip.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTrip.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTrip.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTrip.FormattingEnabled = true;
            this.cmbTrip.ItemHeight = 17;
            this.cmbTrip.Location = new System.Drawing.Point(426, 13);
            this.cmbTrip.Name = "cmbTrip";
            this.cmbTrip.Size = new System.Drawing.Size(186, 25);
            this.cmbTrip.TabIndex = 184;
            // 
            // cmbTown
            // 
            this.cmbTown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTown.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTown.FormattingEnabled = true;
            this.cmbTown.ItemHeight = 17;
            this.cmbTown.Location = new System.Drawing.Point(663, 13);
            this.cmbTown.Name = "cmbTown";
            this.cmbTown.Size = new System.Drawing.Size(186, 25);
            this.cmbTown.TabIndex = 185;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 186;
            this.label5.Text = "ခရီးစဉ်";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(629, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 20);
            this.label6.TabIndex = 187;
            this.label6.Text = "မြို့";
            // 
            // dptEndDate
            // 
            this.dptEndDate.CustomFormat = "MMM-yyyy";
            this.dptEndDate.Enabled = false;
            this.dptEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dptEndDate.Location = new System.Drawing.Point(249, 11);
            this.dptEndDate.Name = "dptEndDate";
            this.dptEndDate.Size = new System.Drawing.Size(111, 28);
            this.dptEndDate.TabIndex = 182;
            // 
            // frmRV_YearlyCustomerTransition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 552);
            this.Controls.Add(this.rpViewer);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmRV_YearlyCustomerTransition";
            this.Text = "Report: Yearly Customer Transition";
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dptStartDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private Microsoft.Reporting.WinForms.ReportViewer rpViewer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTrip;
        private System.Windows.Forms.ComboBox cmbTown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dptEndDate;
    }
}