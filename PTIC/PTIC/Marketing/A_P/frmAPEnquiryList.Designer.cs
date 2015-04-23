namespace PTIC.VC.Marketing.A_P
{
    partial class frmAPEnquiryList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAPEnquiry = new System.Windows.Forms.DataGridView();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEnquiryEnd = new System.Windows.Forms.DateTimePicker();
            this.chkAPSubCat = new System.Windows.Forms.CheckBox();
            this.chkPosm = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpEnquiryStart = new System.Windows.Forms.DateTimePicker();
            this.cmbAPSubCat = new System.Windows.Forms.ComboBox();
            this.cmbPOSM = new System.Windows.Forms.ComboBox();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnEnquiry = new System.Windows.Forms.Button();
            this.btnNewEnquiry = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.calendarColumn1 = new AGL.UI.Controls.CalendarColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlanMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnquiryDate = new AGL.UI.Controls.CalendarColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCOORemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAPEnquiryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAPEnquiry)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAPEnquiry
            // 
            this.dgvAPEnquiry.AllowUserToAddRows = false;
            this.dgvAPEnquiry.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAPEnquiry.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(175)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAPEnquiry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAPEnquiry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAPEnquiry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlanMonth,
            this.colEnquiryDate,
            this.colEndDate,
            this.colCOORemark,
            this.colAPEnquiryID});
            this.dgvAPEnquiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAPEnquiry.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAPEnquiry.EnableHeadersVisualStyles = false;
            this.dgvAPEnquiry.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(36)))), ((int)(((byte)(60)))));
            this.dgvAPEnquiry.Location = new System.Drawing.Point(0, 156);
            this.dgvAPEnquiry.Name = "dgvAPEnquiry";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(175)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAPEnquiry.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAPEnquiry.RowHeadersWidth = 50;
            this.dgvAPEnquiry.RowTemplate.Height = 28;
            this.dgvAPEnquiry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAPEnquiry.Size = new System.Drawing.Size(1180, 266);
            this.dgvAPEnquiry.TabIndex = 188;
            this.dgvAPEnquiry.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAPEnquiry_DataBindingComplete);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.chkDate);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.dtpEnquiryEnd);
            this.pnlFilter.Controls.Add(this.chkAPSubCat);
            this.pnlFilter.Controls.Add(this.chkPosm);
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Controls.Add(this.dtpEnquiryStart);
            this.pnlFilter.Controls.Add(this.cmbAPSubCat);
            this.pnlFilter.Controls.Add(this.cmbPOSM);
            this.pnlFilter.Controls.Add(this.btnViewAll);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 69);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1180, 87);
            this.pnlFilter.TabIndex = 192;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(25, 13);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(51, 23);
            this.chkDate.TabIndex = 187;
            this.chkDate.Text = "နေ့စွဲ";
            this.chkDate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 19);
            this.label2.TabIndex = 186;
            this.label2.Text = "ထိ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 19);
            this.label1.TabIndex = 185;
            this.label1.Text = "မှ";
            // 
            // dtpEnquiryEnd
            // 
            this.dtpEnquiryEnd.CustomFormat = "dd-MMM-yyyy";
            this.dtpEnquiryEnd.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnquiryEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnquiryEnd.Location = new System.Drawing.Point(94, 48);
            this.dtpEnquiryEnd.Name = "dtpEnquiryEnd";
            this.dtpEnquiryEnd.Size = new System.Drawing.Size(130, 25);
            this.dtpEnquiryEnd.TabIndex = 184;
            // 
            // chkAPSubCat
            // 
            this.chkAPSubCat.AutoSize = true;
            this.chkAPSubCat.Location = new System.Drawing.Point(571, 53);
            this.chkAPSubCat.Name = "chkAPSubCat";
            this.chkAPSubCat.Size = new System.Drawing.Size(131, 23);
            this.chkAPSubCat.TabIndex = 183;
            this.chkAPSubCat.Text = "A && P အမျိုးအစားခွဲ";
            this.chkAPSubCat.UseVisualStyleBackColor = true;
            this.chkAPSubCat.Visible = false;
            // 
            // chkPosm
            // 
            this.chkPosm.AutoSize = true;
            this.chkPosm.Location = new System.Drawing.Point(274, 53);
            this.chkPosm.Name = "chkPosm";
            this.chkPosm.Size = new System.Drawing.Size(97, 23);
            this.chkPosm.TabIndex = 182;
            this.chkPosm.Text = "POSM အမည်\r\n";
            this.chkPosm.UseVisualStyleBackColor = true;
            this.chkPosm.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1007, 100);
            this.panel3.TabIndex = 174;
            // 
            // dtpEnquiryStart
            // 
            this.dtpEnquiryStart.CustomFormat = "dd-MMM-yyyy";
            this.dtpEnquiryStart.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnquiryStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnquiryStart.Location = new System.Drawing.Point(94, 10);
            this.dtpEnquiryStart.Name = "dtpEnquiryStart";
            this.dtpEnquiryStart.Size = new System.Drawing.Size(130, 25);
            this.dtpEnquiryStart.TabIndex = 180;
            // 
            // cmbAPSubCat
            // 
            this.cmbAPSubCat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAPSubCat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAPSubCat.DisplayMember = "APSubCategoryName";
            this.cmbAPSubCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAPSubCat.FormattingEnabled = true;
            this.cmbAPSubCat.Location = new System.Drawing.Point(725, 52);
            this.cmbAPSubCat.Name = "cmbAPSubCat";
            this.cmbAPSubCat.Size = new System.Drawing.Size(150, 25);
            this.cmbAPSubCat.TabIndex = 13;
            this.cmbAPSubCat.ValueMember = "ID";
            this.cmbAPSubCat.Visible = false;
            // 
            // cmbPOSM
            // 
            this.cmbPOSM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPOSM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPOSM.DisplayMember = "APMaterialName";
            this.cmbPOSM.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPOSM.FormattingEnabled = true;
            this.cmbPOSM.Location = new System.Drawing.Point(393, 52);
            this.cmbPOSM.Name = "cmbPOSM";
            this.cmbPOSM.Size = new System.Drawing.Size(150, 25);
            this.cmbPOSM.TabIndex = 8;
            this.cmbPOSM.ValueMember = "ID";
            this.cmbPOSM.Visible = false;
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(403, 11);
            this.btnViewAll.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(113, 30);
            this.btnViewAll.TabIndex = 3;
            this.btnViewAll.Text = "အကုန်ကြည့်မည်";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(274, 11);
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
            this.pnlFilt.Location = new System.Drawing.Point(0, 46);
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(1180, 23);
            this.pnlFilt.TabIndex = 191;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lblFilter.Location = new System.Drawing.Point(3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(168, 19);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Advance Search";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnEnquiry);
            this.pnlFooter.Controls.Add(this.btnNewEnquiry);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 422);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1180, 51);
            this.pnlFooter.TabIndex = 190;
            // 
            // btnEnquiry
            // 
            this.btnEnquiry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnquiry.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnquiry.Location = new System.Drawing.Point(157, 8);
            this.btnEnquiry.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnEnquiry.Name = "btnEnquiry";
            this.btnEnquiry.Size = new System.Drawing.Size(133, 34);
            this.btnEnquiry.TabIndex = 171;
            this.btnEnquiry.Text = "ဆက်လက်စုံစမ်းမည်";
            this.btnEnquiry.UseVisualStyleBackColor = true;
            this.btnEnquiry.Click += new System.EventHandler(this.btnEnquiry_Click);
            // 
            // btnNewEnquiry
            // 
            this.btnNewEnquiry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewEnquiry.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewEnquiry.Location = new System.Drawing.Point(25, 8);
            this.btnNewEnquiry.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnNewEnquiry.Name = "btnNewEnquiry";
            this.btnNewEnquiry.Size = new System.Drawing.Size(116, 34);
            this.btnNewEnquiry.TabIndex = 170;
            this.btnNewEnquiry.Text = "အသစ်စုံစမ်းမည်";
            this.btnNewEnquiry.UseVisualStyleBackColor = true;
            this.btnNewEnquiry.Click += new System.EventHandler(this.btnNewEnquiry_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel2.Controls.Add(this.lblSetup);
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 12, 3, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1180, 46);
            this.panel2.TabIndex = 189;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(9, 13);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(46, 19);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "A && P";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(149)))), ((int)(((byte)(206)))));
            this.lblHeaderPCat.Location = new System.Drawing.Point(61, 13);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(122, 19);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = "> POSM စုံစမ်းခြင်း";
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.DataPropertyName = "OpenDate";
            this.calendarColumn1.HeaderText = "စုံစမ်းခြင်း စတင်သည့်နေ့စွဲ";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.ReadOnly = true;
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.calendarColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CloseDate";
            this.dataGridViewTextBoxColumn1.HeaderText = "စုံစမ်းခြင်း ပြီးဆုံးသည့်နေ့စွဲ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "COORemark";
            this.dataGridViewTextBoxColumn2.HeaderText = "COO Remark";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "APEnquiryID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // colPlanMonth
            // 
            this.colPlanMonth.DataPropertyName = "AP_PLanMonth";
            dataGridViewCellStyle2.Format = "MMM-yyyy";
            this.colPlanMonth.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPlanMonth.HeaderText = "Plan Month";
            this.colPlanMonth.Name = "colPlanMonth";
            this.colPlanMonth.ReadOnly = true;
            this.colPlanMonth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colEnquiryDate
            // 
            this.colEnquiryDate.DataPropertyName = "OpenDate";
            this.colEnquiryDate.HeaderText = "စုံစမ်းခြင်း စတင်သည့်နေ့စွဲ";
            this.colEnquiryDate.Name = "colEnquiryDate";
            this.colEnquiryDate.ReadOnly = true;
            this.colEnquiryDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEnquiryDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEnquiryDate.Width = 150;
            // 
            // colEndDate
            // 
            this.colEndDate.DataPropertyName = "CloseDate";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colEndDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEndDate.HeaderText = "စုံစမ်းခြင်း ပြီးဆုံးသည့်နေ့စွဲ";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.ReadOnly = true;
            this.colEndDate.Width = 150;
            // 
            // colCOORemark
            // 
            this.colCOORemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCOORemark.DataPropertyName = "COORemark";
            this.colCOORemark.HeaderText = "COO Remark";
            this.colCOORemark.Name = "colCOORemark";
            this.colCOORemark.ReadOnly = true;
            // 
            // colAPEnquiryID
            // 
            this.colAPEnquiryID.DataPropertyName = "ID";
            this.colAPEnquiryID.HeaderText = "APEnquiryID";
            this.colAPEnquiryID.Name = "colAPEnquiryID";
            this.colAPEnquiryID.Visible = false;
            // 
            // frmAPEnquiryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1180, 473);
            this.Controls.Add(this.dgvAPEnquiry);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAPEnquiryList";
            this.Text = "A && P စုံစမ်းခြင်းစာရင်း";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAPEnquiry)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAPEnquiry;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEnquiryEnd;
        private System.Windows.Forms.CheckBox chkAPSubCat;
        private System.Windows.Forms.CheckBox chkPosm;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpEnquiryStart;
        private System.Windows.Forms.ComboBox cmbAPSubCat;
        private System.Windows.Forms.ComboBox cmbPOSM;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnEnquiry;
        private System.Windows.Forms.Button btnNewEnquiry;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private AGL.UI.Controls.CalendarColumn calendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlanMonth;
        private AGL.UI.Controls.CalendarColumn colEnquiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCOORemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAPEnquiryID;

    }
}