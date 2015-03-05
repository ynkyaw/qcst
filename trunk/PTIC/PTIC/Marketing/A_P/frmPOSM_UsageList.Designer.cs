namespace PTIC.Marketing.A_P
{
    partial class frmPOSM_UsageList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBakToAP = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.dgvPOSM_Usage = new System.Windows.Forms.DataGridView();
            this.colPOSM_UsageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new AGL.UI.Controls.CalendarColumn();
            this.colDeptID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colInchargeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbKW_Department = new System.Windows.Forms.ComboBox();
            this.txtDate = new System.Windows.Forms.Label();
            this.dtpKW_Date = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkDepartment = new System.Windows.Forms.CheckBox();
            this.txtDepartment = new System.Windows.Forms.Label();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOSM_Usage)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lblBakToAP);
            this.panel1.Controls.Add(this.lblOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 41);
            this.panel1.TabIndex = 5;
            // 
            // lblBakToAP
            // 
            this.lblBakToAP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBakToAP.AutoSize = true;
            this.lblBakToAP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBakToAP.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBakToAP.Location = new System.Drawing.Point(10, 11);
            this.lblBakToAP.Name = "lblBakToAP";
            this.lblBakToAP.Size = new System.Drawing.Size(46, 17);
            this.lblBakToAP.TabIndex = 4;
            this.lblBakToAP.Text = "A && P";
            this.lblBakToAP.Click += new System.EventHandler(this.lblBakToAP_Click);
            // 
            // lblOrder
            // 
            this.lblOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrder.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblOrder.Location = new System.Drawing.Point(61, 10);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(184, 17);
            this.lblOrder.TabIndex = 3;
            this.lblOrder.Text = ">    A && P အသုံးပြုခြင်း စာရင်း";
            // 
            // pnlFilt
            // 
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 41);
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(770, 23);
            this.pnlFilt.TabIndex = 191;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.Blue;
            this.lblFilter.Location = new System.Drawing.Point(3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(145, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Advance Search";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // dgvPOSM_Usage
            // 
            this.dgvPOSM_Usage.AllowUserToAddRows = false;
            this.dgvPOSM_Usage.AllowUserToDeleteRows = false;
            this.dgvPOSM_Usage.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPOSM_Usage.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(131)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSM_Usage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPOSM_Usage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPOSM_Usage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPOSM_UsageID,
            this.colDate,
            this.colDeptID,
            this.colInchargeID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPOSM_Usage.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPOSM_Usage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPOSM_Usage.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPOSM_Usage.EnableHeadersVisualStyles = false;
            this.dgvPOSM_Usage.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(255)))));
            this.dgvPOSM_Usage.Location = new System.Drawing.Point(0, 0);
            this.dgvPOSM_Usage.MultiSelect = false;
            this.dgvPOSM_Usage.Name = "dgvPOSM_Usage";
            this.dgvPOSM_Usage.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(131)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOSM_Usage.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPOSM_Usage.RowHeadersWidth = 50;
            this.dgvPOSM_Usage.RowTemplate.Height = 28;
            this.dgvPOSM_Usage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPOSM_Usage.Size = new System.Drawing.Size(770, 283);
            this.dgvPOSM_Usage.TabIndex = 194;
            this.dgvPOSM_Usage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPOSM_Usage_CellClick);
            this.dgvPOSM_Usage.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPOSM_Usage_DataBindingComplete);
            // 
            // colPOSM_UsageID
            // 
            this.colPOSM_UsageID.DataPropertyName = "POSM_UsageID";
            this.colPOSM_UsageID.HeaderText = "POSM_UsageID";
            this.colPOSM_UsageID.Name = "colPOSM_UsageID";
            this.colPOSM_UsageID.ReadOnly = true;
            this.colPOSM_UsageID.Visible = false;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "Date";
            dataGridViewCellStyle2.Format = "yyyy-MMM-dd";
            dataGridViewCellStyle2.NullValue = null;
            this.colDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDate.HeaderText = "နေ့စွဲ";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colDeptID
            // 
            this.colDeptID.DataPropertyName = "DeptID";
            this.colDeptID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colDeptID.HeaderText = "ဌာနအမည်";
            this.colDeptID.Name = "colDeptID";
            this.colDeptID.ReadOnly = true;
            this.colDeptID.Width = 200;
            // 
            // colInchargeID
            // 
            this.colInchargeID.DataPropertyName = "InchargeID";
            this.colInchargeID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colInchargeID.HeaderText = "တာဝန်ခံ";
            this.colInchargeID.Name = "colInchargeID";
            this.colInchargeID.ReadOnly = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(584, 10);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbKW_Department
            // 
            this.cmbKW_Department.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbKW_Department.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKW_Department.DisplayMember = "DeptName";
            this.cmbKW_Department.Enabled = false;
            this.cmbKW_Department.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKW_Department.FormattingEnabled = true;
            this.cmbKW_Department.Location = new System.Drawing.Point(417, 11);
            this.cmbKW_Department.Name = "cmbKW_Department";
            this.cmbKW_Department.Size = new System.Drawing.Size(150, 28);
            this.cmbKW_Department.TabIndex = 13;
            this.cmbKW_Department.ValueMember = "ID";
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.Enabled = false;
            this.txtDate.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtDate.Location = new System.Drawing.Point(16, 15);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(34, 20);
            this.txtDate.TabIndex = 179;
            this.txtDate.Text = "နေ့စွဲ";
            // 
            // dtpKW_Date
            // 
            this.dtpKW_Date.Checked = false;
            this.dtpKW_Date.CustomFormat = "dd-MMM-yyyy";
            this.dtpKW_Date.Enabled = false;
            this.dtpKW_Date.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpKW_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKW_Date.Location = new System.Drawing.Point(77, 12);
            this.dtpKW_Date.Name = "dtpKW_Date";
            this.dtpKW_Date.Size = new System.Drawing.Size(150, 27);
            this.dtpKW_Date.TabIndex = 180;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1007, 100);
            this.panel3.TabIndex = 174;
            // 
            // chkDepartment
            // 
            this.chkDepartment.AutoSize = true;
            this.chkDepartment.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.chkDepartment.Location = new System.Drawing.Point(320, 18);
            this.chkDepartment.Name = "chkDepartment";
            this.chkDepartment.Size = new System.Drawing.Size(15, 14);
            this.chkDepartment.TabIndex = 200;
            this.chkDepartment.UseVisualStyleBackColor = true;
            this.chkDepartment.CheckedChanged += new System.EventHandler(this.chkDepartment_CheckedChanged);
            // 
            // txtDepartment
            // 
            this.txtDepartment.AutoSize = true;
            this.txtDepartment.Enabled = false;
            this.txtDepartment.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtDepartment.Location = new System.Drawing.Point(341, 15);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(70, 20);
            this.txtDepartment.TabIndex = 201;
            this.txtDepartment.Text = "ဌာနအမည်";
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.chkDate.Location = new System.Drawing.Point(56, 18);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(15, 14);
            this.chkDate.TabIndex = 202;
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.chkDate);
            this.pnlFilter.Controls.Add(this.txtDepartment);
            this.pnlFilter.Controls.Add(this.chkDepartment);
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Controls.Add(this.dtpKW_Date);
            this.pnlFilter.Controls.Add(this.txtDate);
            this.pnlFilter.Controls.Add(this.cmbKW_Department);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 64);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(770, 51);
            this.pnlFilter.TabIndex = 192;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvPOSM_Usage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 283);
            this.panel2.TabIndex = 193;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label1.Location = new System.Drawing.Point(233, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 204;
            this.label1.Text = "မှ";
            // 
            // frmPOSM_UsageList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 398);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Controls.Add(this.panel1);
            this.Name = "frmPOSM_UsageList";
            this.Text = "A & P အသုံးပြုခြင်း စာရင်း";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOSM_Usage)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBakToAP;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.DataGridView dgvPOSM_Usage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPOSM_UsageID;
        private AGL.UI.Controls.CalendarColumn colDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDeptID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colInchargeID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbKW_Department;
        private System.Windows.Forms.Label txtDate;
        private System.Windows.Forms.DateTimePicker dtpKW_Date;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkDepartment;
        private System.Windows.Forms.Label txtDepartment;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}