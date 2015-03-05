namespace PTIC.Marketing.MobileService
{
    partial class MobileServiceMonthlyPlan
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
            this.dgvIntialMobileMarketingPlan = new System.Windows.Forms.DataGridView();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblMarketing = new System.Windows.Forms.Label();
            this.colIntialPlanDate = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRoute = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRouteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInitialMobileServicePlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntialMobileMarketingPlan)).BeginInit();
            this.panel4.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIntialMobileMarketingPlan
            // 
            this.dgvIntialMobileMarketingPlan.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvIntialMobileMarketingPlan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIntialMobileMarketingPlan.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIntialMobileMarketingPlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIntialMobileMarketingPlan.ColumnHeadersHeight = 32;
            this.dgvIntialMobileMarketingPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvIntialMobileMarketingPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIntialPlanDate,
            this.colRoute,
            this.colRemark,
            this.colRouteID,
            this.colInitialMobileServicePlanID});
            this.dgvIntialMobileMarketingPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIntialMobileMarketingPlan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvIntialMobileMarketingPlan.Location = new System.Drawing.Point(0, 82);
            this.dgvIntialMobileMarketingPlan.MultiSelect = false;
            this.dgvIntialMobileMarketingPlan.Name = "dgvIntialMobileMarketingPlan";
            this.dgvIntialMobileMarketingPlan.RowHeadersWidth = 50;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvIntialMobileMarketingPlan.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvIntialMobileMarketingPlan.RowTemplate.Height = 30;
            this.dgvIntialMobileMarketingPlan.Size = new System.Drawing.Size(972, 255);
            this.dgvIntialMobileMarketingPlan.TabIndex = 190;
            this.dgvIntialMobileMarketingPlan.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvIntialMobileMarketingPlan_CellValidating);
            this.dgvIntialMobileMarketingPlan.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvIntialMobileMarketingPlan_CurrentCellDirtyStateChanged);
            this.dgvIntialMobileMarketingPlan.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvIntialMobileMarketingPlan_DataBindingComplete);
            this.dgvIntialMobileMarketingPlan.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvIntialMobileMarketingPlan_DataError);
            this.dgvIntialMobileMarketingPlan.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvIntialMobileMarketingPlan_EditingControlShowing);
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
            this.panel4.Location = new System.Drawing.Point(0, 337);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(972, 46);
            this.panel4.TabIndex = 192;
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
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
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
            this.pnlGrid.Location = new System.Drawing.Point(0, 41);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(972, 41);
            this.pnlGrid.TabIndex = 191;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 41);
            this.panel2.TabIndex = 189;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(76, 10);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(247, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">   Mobile Service Monthly Plan";
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
            // colInitialMobileServicePlanID
            // 
            this.colInitialMobileServicePlanID.DataPropertyName = "InitialMobileServicePlanID";
            this.colInitialMobileServicePlanID.HeaderText = "InitialMobileServicePlanID";
            this.colInitialMobileServicePlanID.Name = "colInitialMobileServicePlanID";
            this.colInitialMobileServicePlanID.Visible = false;
            // 
            // MobileServiceMonthlyPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 383);
            this.Controls.Add(this.dgvIntialMobileMarketingPlan);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MobileServiceMonthlyPlan";
            this.Text = "Mobile Service Monthly Plan";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntialMobileMarketingPlan)).EndInit();
            this.panel4.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIntialMobileMarketingPlan;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.DataGridViewComboBoxColumn colIntialPlanDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn colRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRouteID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInitialMobileServicePlanID;
    }
}