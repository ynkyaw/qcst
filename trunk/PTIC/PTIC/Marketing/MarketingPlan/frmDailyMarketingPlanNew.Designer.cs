namespace PTIC.VC.Marketing.MarketingPlan
{
    partial class frmDailyMarketingPlanNew
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvIntialMarketingPlan = new System.Windows.Forms.DataGridView();
            this.colIntialPlanDate = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRoute = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRouteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInitialMarketingPlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblMarketing = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntialMarketingPlan)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIntialMarketingPlan
            // 
            this.dgvIntialMarketingPlan.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvIntialMarketingPlan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIntialMarketingPlan.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIntialMarketingPlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIntialMarketingPlan.ColumnHeadersHeight = 32;
            this.dgvIntialMarketingPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvIntialMarketingPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIntialPlanDate,
            this.colRoute,
            this.colRemark,
            this.colRouteID,
            this.colInitialMarketingPlanID});
            this.dgvIntialMarketingPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIntialMarketingPlan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvIntialMarketingPlan.Location = new System.Drawing.Point(0, 0);
            this.dgvIntialMarketingPlan.MultiSelect = false;
            this.dgvIntialMarketingPlan.Name = "dgvIntialMarketingPlan";
            this.dgvIntialMarketingPlan.RowHeadersWidth = 50;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvIntialMarketingPlan.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvIntialMarketingPlan.RowTemplate.Height = 30;
            this.dgvIntialMarketingPlan.Size = new System.Drawing.Size(980, 263);
            this.dgvIntialMarketingPlan.TabIndex = 130;
            this.dgvIntialMarketingPlan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIntialMarketingPlan_CellContentClick);
            this.dgvIntialMarketingPlan.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIntialMarketingPlan_CellEndEdit);
            this.dgvIntialMarketingPlan.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvIntialMarketingPlan_CellValidating);
            this.dgvIntialMarketingPlan.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvIntialMarketingPlan_CurrentCellDirtyStateChanged);
            this.dgvIntialMarketingPlan.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvIntialMarketingPlan_DataBindingComplete);
            this.dgvIntialMarketingPlan.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvIntialMarketingPlan_DataError);
            this.dgvIntialMarketingPlan.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvIntialMarketingPlan_EditingControlShowing);
            this.dgvIntialMarketingPlan.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvIntialMarketingPlan_RowHeaderMouseDoubleClick);
            // 
            // colIntialPlanDate
            // 
            this.colIntialPlanDate.DataPropertyName = "Day";
            dataGridViewCellStyle3.Format = "ddd";
            this.colIntialPlanDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colIntialPlanDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colIntialPlanDate.HeaderText = "နေ့";
            this.colIntialPlanDate.Name = "colIntialPlanDate";
            this.colIntialPlanDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIntialPlanDate.Width = 123;
            // 
            // colRoute
            // 
            this.colRoute.DataPropertyName = "RouteID";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.colRoute.DefaultCellStyle = dataGridViewCellStyle4;
            this.colRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colRoute.HeaderText = "လမ်းကြောင်း";
            this.colRoute.Name = "colRoute";
            this.colRoute.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRoute.Width = 200;
            // 
            // colRemark
            // 
            this.colRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "မှတ်ချက်";
            this.colRemark.Name = "colRemark";
            this.colRemark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colRouteID
            // 
            this.colRouteID.DataPropertyName = "RouteID";
            this.colRouteID.HeaderText = "RouteID";
            this.colRouteID.Name = "colRouteID";
            this.colRouteID.Visible = false;
            // 
            // colInitialMarketingPlanID
            // 
            this.colInitialMarketingPlanID.DataPropertyName = "IntialMarketingPlanID";
            this.colInitialMarketingPlanID.HeaderText = "InitialMarketingPlanID";
            this.colInitialMarketingPlanID.Name = "colInitialMarketingPlanID";
            this.colInitialMarketingPlanID.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(980, 41);
            this.panel2.TabIndex = 129;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(76, 10);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(189, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">   Daily Marketing Plan";
            this.lblHeaderPCat.Click += new System.EventHandler(this.lblHeaderPCat_Click);
            // 
            // lblMarketing
            // 
            this.lblMarketing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarketing.AutoSize = true;
            this.lblMarketing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMarketing.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblMarketing.Location = new System.Drawing.Point(8, 10);
            this.lblMarketing.Name = "lblMarketing";
            this.lblMarketing.Size = new System.Drawing.Size(73, 20);
            this.lblMarketing.TabIndex = 0;
            this.lblMarketing.Text = "Planning";
            this.lblMarketing.Click += new System.EventHandler(this.lblMarketing_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.pnlGrid);
            this.panel1.Controls.Add(this.pnlFilter);
            this.panel1.Controls.Add(this.pnlFilt);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 457);
            this.panel1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvIntialMarketingPlan);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 148);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(980, 263);
            this.panel5.TabIndex = 189;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnReport);
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Controls.Add(this.btnConfirm);
            this.panel4.Controls.Add(this.btnView);
            this.panel4.Controls.Add(this.btnNew);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 411);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(980, 46);
            this.panel4.TabIndex = 188;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(609, 6);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(95, 34);
            this.btnReport.TabIndex = 128;
            this.btnReport.Text = "တင်ပြမည်";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(233, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 124;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(122, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 125;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(489, 6);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(105, 34);
            this.btnConfirm.TabIndex = 127;
            this.btnConfirm.Text = "အတည်ပြုမည်";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Visible = false;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnView.Location = new System.Drawing.Point(344, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(95, 34);
            this.btnView.TabIndex = 133;
            this.btnView.Text = "ကြည့်မည်";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(11, 6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 34);
            this.btnNew.TabIndex = 132;
            this.btnNew.Text = "ထည့်မည်";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.label2);
            this.pnlGrid.Controls.Add(this.dtpFromDate);
            this.pnlGrid.Controls.Add(this.dtpToDate);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrid.Location = new System.Drawing.Point(0, 107);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(980, 41);
            this.pnlGrid.TabIndex = 187;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label2.Location = new System.Drawing.Point(134, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 86;
            this.label2.Text = "မှ";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(8, 5);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(120, 28);
            this.dtpFromDate.TabIndex = 84;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(158, 5);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(120, 28);
            this.dtpToDate.TabIndex = 85;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Controls.Add(this.btnViewAll);
            this.pnlFilter.Controls.Add(this.button2);
            this.pnlFilter.Controls.Add(this.dtpStartDate);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.dtpEndDate);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 64);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(980, 43);
            this.pnlFilter.TabIndex = 186;
            this.pnlFilter.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1007, 100);
            this.panel3.TabIndex = 174;
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(561, 7);
            this.btnViewAll.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(111, 30);
            this.btnViewAll.TabIndex = 3;
            this.btnViewAll.Text = "အကုန်ကြည့်မည်";
            this.btnViewAll.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(434, 7);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "ရှာမည်";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(8, 6);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 28);
            this.dtpStartDate.TabIndex = 81;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label3.Location = new System.Drawing.Point(134, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 82;
            this.label3.Text = "မှ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label1.Location = new System.Drawing.Point(287, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 80;
            this.label1.Text = "ထိ ဈေးကွက်အစီအစဉ်";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(158, 6);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 28);
            this.dtpEndDate.TabIndex = 83;
            // 
            // pnlFilt
            // 
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 41);
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(980, 23);
            this.pnlFilt.TabIndex = 185;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.Blue;
            this.lblFilter.Location = new System.Drawing.Point(3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(142, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Advance Search";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "မှတ်ချက်";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // frmDailyMarketingPlanNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 457);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDailyMarketingPlanNew";
            this.Text = "DailyMarketing Plan";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntialMarketingPlan)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIntialMarketingPlan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn colIntialPlanDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn colRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRouteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInitialMarketingPlanID;

    }
}