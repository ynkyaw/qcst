namespace PTIC.Marketing.DailyMarketing
{
    partial class frmTripRequestList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTripRequestList = new System.Windows.Forms.DataGridView();
            this.clnTripRequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTripPlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTripPlanName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnFromDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnToDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butSearch = new System.Windows.Forms.Button();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.butAddNew = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripRequestList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTripRequestList
            // 
            this.dgvTripRequestList.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTripRequestList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTripRequestList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTripRequestList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTripRequestList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTripRequestList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTripRequestList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnTripRequestID,
            this.clnTripPlanID,
            this.clnNo,
            this.clnTripPlanName,
            this.clnFromDate,
            this.clnToDate});
            this.dgvTripRequestList.Location = new System.Drawing.Point(12, 90);
            this.dgvTripRequestList.MultiSelect = false;
            this.dgvTripRequestList.Name = "dgvTripRequestList";
            this.dgvTripRequestList.RowHeadersWidth = 50;
            this.dgvTripRequestList.RowTemplate.Height = 28;
            this.dgvTripRequestList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTripRequestList.Size = new System.Drawing.Size(635, 429);
            this.dgvTripRequestList.TabIndex = 17;
            this.dgvTripRequestList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTripRequestList_CellClick);
            this.dgvTripRequestList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTripPlanList_CellContentClick);
            this.dgvTripRequestList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTripRequestList_DataBindingComplete);
            this.dgvTripRequestList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTripPlanList_RowPostPaint);
            // 
            // clnTripRequestID
            // 
            this.clnTripRequestID.DataPropertyName = "TripRequestID";
            this.clnTripRequestID.HeaderText = "Trip Request ID";
            this.clnTripRequestID.Name = "clnTripRequestID";
            this.clnTripRequestID.Visible = false;
            // 
            // clnTripPlanID
            // 
            this.clnTripPlanID.DataPropertyName = "TripPlanID";
            this.clnTripPlanID.HeaderText = "Trip Plan ID";
            this.clnTripPlanID.Name = "clnTripPlanID";
            this.clnTripPlanID.Visible = false;
            // 
            // clnNo
            // 
            this.clnNo.HeaderText = "စဉ်";
            this.clnNo.Name = "clnNo";
            this.clnNo.Width = 50;
            // 
            // clnTripPlanName
            // 
            this.clnTripPlanName.DataPropertyName = "TripPlanName";
            this.clnTripPlanName.HeaderText = "ခရီးစဉ်အမည်";
            this.clnTripPlanName.Name = "clnTripPlanName";
            this.clnTripPlanName.Width = 200;
            // 
            // clnFromDate
            // 
            this.clnFromDate.DataPropertyName = "FromDate";
            this.clnFromDate.HeaderText = "မှ";
            this.clnFromDate.Name = "clnFromDate";
            this.clnFromDate.Width = 150;
            // 
            // clnToDate
            // 
            this.clnToDate.DataPropertyName = "ToDate";
            this.clnToDate.HeaderText = "အထိ";
            this.clnToDate.Name = "clnToDate";
            this.clnToDate.Width = 150;
            // 
            // butSearch
            // 
            this.butSearch.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSearch.Location = new System.Drawing.Point(405, 56);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(100, 28);
            this.butSearch.TabIndex = 125;
            this.butSearch.Text = "ရှာမည်";
            this.butSearch.UseVisualStyleBackColor = true;
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(221, 56);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(150, 28);
            this.dtToDate.TabIndex = 123;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(15, 56);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(150, 28);
            this.dtFromDate.TabIndex = 122;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(185, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 121;
            this.label3.Text = "မှ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(377, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 20);
            this.label1.TabIndex = 120;
            this.label1.Text = "ထိ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblSetup);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 41);
            this.panel1.TabIndex = 57;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(11, 9);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(83, 20);
            this.lblSetup.TabIndex = 46;
            this.lblSetup.Text = "Marketing";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeader.Location = new System.Drawing.Point(101, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(165, 20);
            this.lblHeader.TabIndex = 47;
            this.lblHeader.Text = ">    Trip Request List";
            // 
            // butAddNew
            // 
            this.butAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butAddNew.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAddNew.Location = new System.Drawing.Point(152, 525);
            this.butAddNew.Name = "butAddNew";
            this.butAddNew.Size = new System.Drawing.Size(112, 34);
            this.butAddNew.TabIndex = 131;
            this.butAddNew.Text = "အသစ်ထည့်မည်";
            this.butAddNew.UseVisualStyleBackColor = true;
            this.butAddNew.Click += new System.EventHandler(this.butAddNew_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 525);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 34);
            this.button1.TabIndex = 130;
            this.button1.Text = "အ‌ရေး‌ပေါ်ခရီးစဉ်";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // butDelete
            // 
            this.butDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDelete.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDelete.Location = new System.Drawing.Point(280, 525);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(95, 34);
            this.butDelete.TabIndex = 132;
            this.butDelete.Text = "ဖျက်မည်";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button7.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(553, 525);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(95, 34);
            this.button7.TabIndex = 128;
            this.button7.Text = "တင်ပြမည်";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(452, 525);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 34);
            this.button3.TabIndex = 125;
            this.button3.Text = "သိမ်းမည်";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // frmTripRequestList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(659, 564);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.butAddNew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTripRequestList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button7);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmTripRequestList";
            this.Text = "Trip Request List";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripRequestList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTripRequestList;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butAddNew;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTripRequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTripPlanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTripPlanName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnToDate;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeader;
    }
}