namespace PTIC.Marketing.Complaint
{
    partial class frmCustomerComplaintReceiveList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvComplaintReceive = new System.Windows.Forms.DataGridView();
            this.colReceivedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRefNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComplaintReceivedID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaintReceive)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblHeader);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(967, 41);
            this.panel2.TabIndex = 150;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(170, 10);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(158, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">   Complaint Forms";
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRegister);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 504);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 46);
            this.panel1.TabIndex = 151;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(12, 6);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(95, 34);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.dtpReceivedDate);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(967, 46);
            this.panel3.TabIndex = 152;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(189, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 34);
            this.btnSearch.TabIndex = 278;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpReceivedDate
            // 
            this.dtpReceivedDate.CustomFormat = "MMM-yyyy";
            this.dtpReceivedDate.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceivedDate.Location = new System.Drawing.Point(86, 9);
            this.dtpReceivedDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpReceivedDate.Name = "dtpReceivedDate";
            this.dtpReceivedDate.ShowUpDown = true;
            this.dtpReceivedDate.Size = new System.Drawing.Size(97, 28);
            this.dtpReceivedDate.TabIndex = 276;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvComplaintReceive);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 87);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(967, 417);
            this.panel4.TabIndex = 153;
            // 
            // dgvComplaintReceive
            // 
            this.dgvComplaintReceive.AllowUserToAddRows = false;
            this.dgvComplaintReceive.AllowUserToDeleteRows = false;
            this.dgvComplaintReceive.AllowUserToOrderColumns = true;
            this.dgvComplaintReceive.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComplaintReceive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvComplaintReceive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComplaintReceive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReceivedDate,
            this.colCustomerName,
            this.colRefNo,
            this.colReceivedName,
            this.colComplaintReceivedID});
            this.dgvComplaintReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComplaintReceive.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvComplaintReceive.Location = new System.Drawing.Point(0, 0);
            this.dgvComplaintReceive.MultiSelect = false;
            this.dgvComplaintReceive.Name = "dgvComplaintReceive";
            this.dgvComplaintReceive.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComplaintReceive.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvComplaintReceive.RowHeadersWidth = 50;
            this.dgvComplaintReceive.RowTemplate.Height = 28;
            this.dgvComplaintReceive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComplaintReceive.ShowCellToolTips = false;
            this.dgvComplaintReceive.Size = new System.Drawing.Size(967, 417);
            this.dgvComplaintReceive.TabIndex = 1;
            this.dgvComplaintReceive.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvComplaintReceive_DataBindingComplete);
            // 
            // colReceivedDate
            // 
            this.colReceivedDate.DataPropertyName = "ReceivedDate";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.colReceivedDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colReceivedDate.HeaderText = "Date";
            this.colReceivedDate.Name = "colReceivedDate";
            this.colReceivedDate.ReadOnly = true;
            // 
            // colCustomerName
            // 
            this.colCustomerName.DataPropertyName = "Customer";
            this.colCustomerName.HeaderText = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            this.colCustomerName.Width = 200;
            // 
            // colRefNo
            // 
            this.colRefNo.DataPropertyName = "RefNo";
            this.colRefNo.HeaderText = "Ref: No";
            this.colRefNo.Name = "colRefNo";
            this.colRefNo.ReadOnly = true;
            this.colRefNo.Width = 130;
            // 
            // colReceivedName
            // 
            this.colReceivedName.DataPropertyName = "ReceiveName";
            this.colReceivedName.HeaderText = "Receive Name";
            this.colReceivedName.Name = "colReceivedName";
            this.colReceivedName.ReadOnly = true;
            this.colReceivedName.Width = 200;
            // 
            // colComplaintReceivedID
            // 
            this.colComplaintReceivedID.DataPropertyName = "ComplaintReceiveID";
            this.colComplaintReceivedID.HeaderText = "ComplaintReceivedID";
            this.colComplaintReceivedID.Name = "colComplaintReceivedID";
            this.colComplaintReceivedID.ReadOnly = true;
            this.colComplaintReceivedID.Visible = false;
            this.colComplaintReceivedID.Width = 110;
            // 
            // frmCustomerComplaintReceiveList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 550);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCustomerComplaintReceiveList";
            this.Text = "Complaint Forms";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaintReceive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvComplaintReceive;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpReceivedDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRefNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComplaintReceivedID;
    }
}