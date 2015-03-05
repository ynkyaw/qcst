namespace PTIC.VC.Marketing.DailyMarketing
{
    partial class frmDailyMarketingDetail
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
            this.cmbEmp = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnCustomerComplaint = new System.Windows.Forms.Button();
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.txtTownship = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerType = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnAPUsage = new System.Windows.Forms.Button();
            this.btnCompetitorActivity = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.dtpMarketedDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvOwn = new System.Windows.Forms.DataGridView();
            this.colOwnBrand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colMarketingDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCompetitor = new System.Windows.Forms.DataGridView();
            this.colCompetitorBrand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetitor)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbEmp);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnCustomerComplaint);
            this.panel1.Controls.Add(this.txtEmployee);
            this.panel1.Controls.Add(this.txtTownship);
            this.panel1.Controls.Add(this.txtCustomerName);
            this.panel1.Controls.Add(this.txtCustomerType);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbBrand);
            this.panel1.Controls.Add(this.dtpMarketedDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 499);
            this.panel1.TabIndex = 0;
            // 
            // cmbEmp
            // 
            this.cmbEmp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmp.FormattingEnabled = true;
            this.cmbEmp.Location = new System.Drawing.Point(503, 93);
            this.cmbEmp.Name = "cmbEmp";
            this.cmbEmp.Size = new System.Drawing.Size(163, 27);
            this.cmbEmp.TabIndex = 167;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.lblSetup);
            this.panel2.Controls.Add(this.lblHeader);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(692, 46);
            this.panel2.TabIndex = 161;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(9, 13);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(83, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Marketing";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.MintCream;
            this.lblHeader.Location = new System.Drawing.Point(99, 13);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(205, 20);
            this.lblHeader.TabIndex = 45;
            this.lblHeader.Text = ">    Daily Marketing Detail";
            // 
            // btnCustomerComplaint
            // 
            this.btnCustomerComplaint.Location = new System.Drawing.Point(299, 17);
            this.btnCustomerComplaint.Name = "btnCustomerComplaint";
            this.btnCustomerComplaint.Size = new System.Drawing.Size(134, 34);
            this.btnCustomerComplaint.TabIndex = 153;
            this.btnCustomerComplaint.Text = "Customer Complaint";
            this.btnCustomerComplaint.UseVisualStyleBackColor = true;
            this.btnCustomerComplaint.Visible = false;
            this.btnCustomerComplaint.Click += new System.EventHandler(this.btnCustomerComplaint_Click);
            // 
            // txtEmployee
            // 
            this.txtEmployee.Location = new System.Drawing.Point(503, 453);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.ReadOnly = true;
            this.txtEmployee.Size = new System.Drawing.Size(163, 28);
            this.txtEmployee.TabIndex = 160;
            this.txtEmployee.Visible = false;
            // 
            // txtTownship
            // 
            this.txtTownship.Location = new System.Drawing.Point(171, 93);
            this.txtTownship.Name = "txtTownship";
            this.txtTownship.ReadOnly = true;
            this.txtTownship.Size = new System.Drawing.Size(163, 28);
            this.txtTownship.TabIndex = 159;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(171, 129);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(163, 28);
            this.txtCustomerName.TabIndex = 158;
            // 
            // txtCustomerType
            // 
            this.txtCustomerType.Location = new System.Drawing.Point(171, 57);
            this.txtCustomerType.Name = "txtCustomerType";
            this.txtCustomerType.ReadOnly = true;
            this.txtCustomerType.Size = new System.Drawing.Size(163, 28);
            this.txtCustomerType.TabIndex = 157;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnDelete.Location = new System.Drawing.Point(355, 449);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 38);
            this.btnDelete.TabIndex = 156;
            this.btnDelete.Text = "ပယ်ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSave.Location = new System.Drawing.Point(238, 449);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 38);
            this.btnSave.TabIndex = 155;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOrder);
            this.groupBox1.Controls.Add(this.btnAPUsage);
            this.groupBox1.Controls.Add(this.btnCompetitorActivity);
            this.groupBox1.Location = new System.Drawing.Point(18, 368);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 75);
            this.groupBox1.TabIndex = 154;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "‌ဆောင်ရွက်ခဲ့မှုများ";
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(100, 27);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(146, 34);
            this.btnOrder.TabIndex = 151;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnAPUsage
            // 
            this.btnAPUsage.Location = new System.Drawing.Point(259, 27);
            this.btnAPUsage.Name = "btnAPUsage";
            this.btnAPUsage.Size = new System.Drawing.Size(146, 34);
            this.btnAPUsage.TabIndex = 150;
            this.btnAPUsage.Text = "A && P အသုံးပြုခြင်း";
            this.btnAPUsage.UseVisualStyleBackColor = true;
            this.btnAPUsage.Click += new System.EventHandler(this.btnAPUsage_Click);
            // 
            // btnCompetitorActivity
            // 
            this.btnCompetitorActivity.Location = new System.Drawing.Point(422, 27);
            this.btnCompetitorActivity.Name = "btnCompetitorActivity";
            this.btnCompetitorActivity.Size = new System.Drawing.Size(146, 34);
            this.btnCompetitorActivity.TabIndex = 152;
            this.btnCompetitorActivity.Text = "Competitor Activity";
            this.btnCompetitorActivity.UseVisualStyleBackColor = true;
            this.btnCompetitorActivity.Click += new System.EventHandler(this.btnCompetitorActivity_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 148;
            this.label5.Text = "‌ရောင်းချ‌နေ‌သော Brand";
            this.label5.Visible = false;
            // 
            // cmbBrand
            // 
            this.cmbBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBrand.DisplayMember = "BrandName";
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(503, 129);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(163, 27);
            this.cmbBrand.TabIndex = 147;
            this.cmbBrand.ValueMember = "BrandID";
            this.cmbBrand.Visible = false;
            // 
            // dtpMarketedDate
            // 
            this.dtpMarketedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMarketedDate.Location = new System.Drawing.Point(503, 57);
            this.dtpMarketedDate.Name = "dtpMarketedDate";
            this.dtpMarketedDate.Size = new System.Drawing.Size(163, 28);
            this.dtpMarketedDate.TabIndex = 143;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 142;
            this.label3.Text = "သွားသည့်‌နေ့";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 141;
            this.label2.Text = "ဝန်ထမ်းအမည်";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 139;
            this.label1.Text = "Customer မြို့နယ်";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 20);
            this.label11.TabIndex = 136;
            this.label11.Text = "Customer အမျိုးအစား";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 135;
            this.label9.Text = "Customer အမည်";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvOwn);
            this.groupBox2.Controls.Add(this.dgvCompetitor);
            this.groupBox2.Location = new System.Drawing.Point(123, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(447, 200);
            this.groupBox2.TabIndex = 166;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ရောင်းချနေသော အမှတ်တံဆိပ်";
            // 
            // dgvOwn
            // 
            this.dgvOwn.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvOwn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOwn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOwnBrand,
            this.colMarketingDetailID,
            this.colID});
            this.dgvOwn.Location = new System.Drawing.Point(28, 21);
            this.dgvOwn.MaximumSize = new System.Drawing.Size(194, 167);
            this.dgvOwn.MinimumSize = new System.Drawing.Size(194, 135);
            this.dgvOwn.Name = "dgvOwn";
            this.dgvOwn.RowTemplate.Height = 28;
            this.dgvOwn.Size = new System.Drawing.Size(194, 167);
            this.dgvOwn.TabIndex = 168;
            this.dgvOwn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOwn_CellContentClick);
            this.dgvOwn.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOwn_CellEndEdit);
            this.dgvOwn.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvOwn_CellValidating);
            this.dgvOwn.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvOwn_DataError);
            // 
            // colOwnBrand
            // 
            this.colOwnBrand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOwnBrand.DataPropertyName = "BrandID";
            this.colOwnBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colOwnBrand.HeaderText = "Own အမှတ်တံဆိပ်";
            this.colOwnBrand.Name = "colOwnBrand";
            this.colOwnBrand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colOwnBrand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colMarketingDetailID
            // 
            this.colMarketingDetailID.DataPropertyName = "MarketingDetailID";
            this.colMarketingDetailID.HeaderText = "MarketingDetailID";
            this.colMarketingDetailID.Name = "colMarketingDetailID";
            this.colMarketingDetailID.Visible = false;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // dgvCompetitor
            // 
            this.dgvCompetitor.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCompetitor.ColumnHeadersHeight = 28;
            this.dgvCompetitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCompetitor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCompetitorBrand});
            this.dgvCompetitor.Location = new System.Drawing.Point(244, 21);
            this.dgvCompetitor.MaximumSize = new System.Drawing.Size(180, 167);
            this.dgvCompetitor.MinimumSize = new System.Drawing.Size(180, 135);
            this.dgvCompetitor.Name = "dgvCompetitor";
            this.dgvCompetitor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvCompetitor.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvCompetitor.RowTemplate.Height = 28;
            this.dgvCompetitor.Size = new System.Drawing.Size(180, 167);
            this.dgvCompetitor.TabIndex = 168;
            this.dgvCompetitor.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompetitor_CellEndEdit);
            this.dgvCompetitor.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCompetitor_CellValidating);
            this.dgvCompetitor.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCompetitor_DataError);
            // 
            // colCompetitorBrand
            // 
            this.colCompetitorBrand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCompetitorBrand.DataPropertyName = "BrandID";
            this.colCompetitorBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colCompetitorBrand.HeaderText = "ပြိုင်ဖက်အမှတ်တံဆိပ်";
            this.colCompetitorBrand.Name = "colCompetitorBrand";
            this.colCompetitorBrand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCompetitorBrand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MarketingDetailID";
            this.dataGridViewTextBoxColumn1.HeaderText = "MarketingDetailID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // frmDailyMarketingDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(222)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(692, 499);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDailyMarketingDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Daily Marketing Detail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetitor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpMarketedDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Button btnCustomerComplaint;
        private System.Windows.Forms.Button btnCompetitorActivity;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnAPUsage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtEmployee;
        private System.Windows.Forms.TextBox txtTownship;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCompetitor;
        private System.Windows.Forms.DataGridView dgvOwn;
        private System.Windows.Forms.DataGridViewComboBoxColumn colOwnBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarketingDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCompetitorBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ComboBox cmbEmp;
    }
}