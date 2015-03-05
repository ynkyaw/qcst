namespace PTIC.Marketing.Complaint
{
    partial class frmCustomerComplainSummary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvComplaintSummary = new System.Windows.Forms.DataGridView();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWhen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExplanComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComplaintReceivedID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComplaintRegisterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaintSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 277;
            this.label5.Text = "‌နေ့စွဲ :";
            // 
            // dtpReceivedDate
            // 
            this.dtpReceivedDate.CustomFormat = "MMM-yyyy";
            this.dtpReceivedDate.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceivedDate.Location = new System.Drawing.Point(68, 9);
            this.dtpReceivedDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpReceivedDate.Name = "dtpReceivedDate";
            this.dtpReceivedDate.ShowUpDown = true;
            this.dtpReceivedDate.Size = new System.Drawing.Size(97, 28);
            this.dtpReceivedDate.TabIndex = 276;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(173, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 34);
            this.btnSearch.TabIndex = 278;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.dtpReceivedDate);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1043, 46);
            this.panel3.TabIndex = 158;
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.AutoSize = true;
            this.lblHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHeader.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(8, 10);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(156, 20);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Customer Complaint";
            this.lblHeader.Click += new System.EventHandler(this.lblHeader_Click);
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(170, 10);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(181, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">   Complaint Summary";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblHeader);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1043, 41);
            this.panel2.TabIndex = 157;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvComplaintSummary);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1043, 294);
            this.panel1.TabIndex = 159;
            // 
            // dgvComplaintSummary
            // 
            this.dgvComplaintSummary.AllowUserToAddRows = false;
            this.dgvComplaintSummary.AllowUserToDeleteRows = false;
            this.dgvComplaintSummary.AllowUserToOrderColumns = true;
            this.dgvComplaintSummary.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvComplaintSummary.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComplaintSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvComplaintSummary.ColumnHeadersHeight = 60;
            this.dgvComplaintSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomerName,
            this.colSubject,
            this.colReceivedDate,
            this.colReceivedBy,
            this.colWhen,
            this.colExplanComment,
            this.colComplaintReceivedID,
            this.colComplaintRegisterID});
            this.dgvComplaintSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComplaintSummary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvComplaintSummary.EnableHeadersVisualStyles = false;
            this.dgvComplaintSummary.Location = new System.Drawing.Point(0, 0);
            this.dgvComplaintSummary.MultiSelect = false;
            this.dgvComplaintSummary.Name = "dgvComplaintSummary";
            this.dgvComplaintSummary.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComplaintSummary.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvComplaintSummary.RowHeadersWidth = 50;
            this.dgvComplaintSummary.RowTemplate.Height = 110;
            this.dgvComplaintSummary.ShowCellToolTips = false;
            this.dgvComplaintSummary.Size = new System.Drawing.Size(1043, 294);
            this.dgvComplaintSummary.TabIndex = 3;
            this.dgvComplaintSummary.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvComplaintSummary_ColumnWidthChanged);
            this.dgvComplaintSummary.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvComplaintSummary_DataBindingComplete);
            this.dgvComplaintSummary.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvComplaintSummary_Scroll);
            this.dgvComplaintSummary.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvComplaintSummary_Paint);
            // 
            // colCustomerName
            // 
            this.colCustomerName.DataPropertyName = "Customer";
            this.colCustomerName.HeaderText = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            this.colCustomerName.Width = 170;
            // 
            // colSubject
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colSubject.DefaultCellStyle = dataGridViewCellStyle2;
            this.colSubject.HeaderText = "Subject";
            this.colSubject.Name = "colSubject";
            this.colSubject.ReadOnly = true;
            this.colSubject.Width = 500;
            // 
            // colReceivedDate
            // 
            this.colReceivedDate.DataPropertyName = "ReceivedDate";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colReceivedDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colReceivedDate.HeaderText = "Date of Complain";
            this.colReceivedDate.Name = "colReceivedDate";
            this.colReceivedDate.ReadOnly = true;
            this.colReceivedDate.Width = 150;
            // 
            // colReceivedBy
            // 
            this.colReceivedBy.DataPropertyName = "Who";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colReceivedBy.DefaultCellStyle = dataGridViewCellStyle4;
            this.colReceivedBy.HeaderText = "Who";
            this.colReceivedBy.Name = "colReceivedBy";
            this.colReceivedBy.ReadOnly = true;
            // 
            // colWhen
            // 
            this.colWhen.DataPropertyName = "ClosedDate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.colWhen.DefaultCellStyle = dataGridViewCellStyle5;
            this.colWhen.HeaderText = "When";
            this.colWhen.Name = "colWhen";
            this.colWhen.ReadOnly = true;
            // 
            // colExplanComment
            // 
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colExplanComment.DefaultCellStyle = dataGridViewCellStyle6;
            this.colExplanComment.HeaderText = "Close Out By Dept : Manager";
            this.colExplanComment.Name = "colExplanComment";
            this.colExplanComment.ReadOnly = true;
            this.colExplanComment.Width = 500;
            // 
            // colComplaintReceivedID
            // 
            this.colComplaintReceivedID.DataPropertyName = "ComplaintReceiveID";
            this.colComplaintReceivedID.HeaderText = "ComplaintReceivedID";
            this.colComplaintReceivedID.Name = "colComplaintReceivedID";
            this.colComplaintReceivedID.ReadOnly = true;
            this.colComplaintReceivedID.Visible = false;
            this.colComplaintReceivedID.Width = 173;
            // 
            // colComplaintRegisterID
            // 
            this.colComplaintRegisterID.DataPropertyName = "ComplaintRegisterID";
            this.colComplaintRegisterID.HeaderText = "ComplaintRegisterID";
            this.colComplaintRegisterID.Name = "colComplaintRegisterID";
            this.colComplaintRegisterID.ReadOnly = true;
            this.colComplaintRegisterID.Visible = false;
            this.colComplaintRegisterID.Width = 166;
            // 
            // frmCustomerComplainSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 381);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCustomerComplainSummary";
            this.Text = "Complaint Summary";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaintSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpReceivedDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvComplaintSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWhen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExplanComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComplaintReceivedID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComplaintRegisterID;
    }
}