namespace PTIC.Marketing.DailyMarketing
{
    partial class frmNonCustomerDailyMarketingDetail
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
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.dtpMarketedDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnAPUsage = new System.Windows.Forms.Button();
            this.btnCompetitorActivity = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvOwn = new System.Windows.Forms.DataGridView();
            this.colOwnBrand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colMarketingDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCompetitor = new System.Windows.Forms.DataGridView();
            this.colCompetitorBrand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gbxCustomer = new System.Windows.Forms.GroupBox();
            this.pnlCustomer = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCustType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.pnlTownTownship = new System.Windows.Forms.Panel();
            this.rdoTownship = new System.Windows.Forms.RadioButton();
            this.rdoTown = new System.Windows.Forms.RadioButton();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.cmbTownTownship = new System.Windows.Forms.ComboBox();
            this.rdoNonCustomer = new System.Windows.Forms.RadioButton();
            this.rdoExistingCustomer = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFooter = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetitor)).BeginInit();
            this.gbxCustomer.SuspendLayout();
            this.pnlCustomer.SuspendLayout();
            this.pnlTownTownship.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmployee
            // 
            this.txtEmployee.BackColor = System.Drawing.Color.White;
            this.txtEmployee.Location = new System.Drawing.Point(129, 62);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.ReadOnly = true;
            this.txtEmployee.Size = new System.Drawing.Size(158, 28);
            this.txtEmployee.TabIndex = 175;
            // 
            // dtpMarketedDate
            // 
            this.dtpMarketedDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpMarketedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMarketedDate.Location = new System.Drawing.Point(129, 22);
            this.dtpMarketedDate.Name = "dtpMarketedDate";
            this.dtpMarketedDate.Size = new System.Drawing.Size(158, 28);
            this.dtpMarketedDate.TabIndex = 166;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 165;
            this.label3.Text = "သွားသည့်‌နေ့";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 164;
            this.label2.Text = "ဝန်ထမ်းအမည်";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblSetup);
            this.panel2.Controls.Add(this.lblHeader);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(713, 41);
            this.panel2.TabIndex = 177;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(8, 9);
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
            this.lblHeader.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeader.Location = new System.Drawing.Point(97, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(269, 20);
            this.lblHeader.TabIndex = 45;
            this.lblHeader.Text = ">    Non Customer Marketing Detail";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSave.Location = new System.Drawing.Point(583, 507);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 38);
            this.btnSave.TabIndex = 179;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOrder);
            this.groupBox1.Controls.Add(this.btnAPUsage);
            this.groupBox1.Controls.Add(this.btnCompetitorActivity);
            this.groupBox1.Location = new System.Drawing.Point(18, 408);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 75);
            this.groupBox1.TabIndex = 178;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "‌ဆောင်ရွက်ခဲ့မှုများ";
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(95, 27);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(146, 34);
            this.btnOrder.TabIndex = 151;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnAPUsage
            // 
            this.btnAPUsage.Location = new System.Drawing.Point(265, 27);
            this.btnAPUsage.Name = "btnAPUsage";
            this.btnAPUsage.Size = new System.Drawing.Size(146, 34);
            this.btnAPUsage.TabIndex = 150;
            this.btnAPUsage.Text = "A && P အသုံးပြုခြင်း";
            this.btnAPUsage.UseVisualStyleBackColor = true;
            this.btnAPUsage.Click += new System.EventHandler(this.btnAPUsage_Click);
            // 
            // btnCompetitorActivity
            // 
            this.btnCompetitorActivity.Location = new System.Drawing.Point(435, 27);
            this.btnCompetitorActivity.Name = "btnCompetitorActivity";
            this.btnCompetitorActivity.Size = new System.Drawing.Size(146, 34);
            this.btnCompetitorActivity.TabIndex = 152;
            this.btnCompetitorActivity.Text = "Competitor Activity";
            this.btnCompetitorActivity.UseVisualStyleBackColor = true;
            this.btnCompetitorActivity.Click += new System.EventHandler(this.btnCompetitorActivity_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvOwn);
            this.groupBox2.Controls.Add(this.dgvCompetitor);
            this.groupBox2.Location = new System.Drawing.Point(19, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(675, 200);
            this.groupBox2.TabIndex = 181;
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
            this.dgvOwn.Location = new System.Drawing.Point(9, 27);
            this.dgvOwn.MaximumSize = new System.Drawing.Size(194, 167);
            this.dgvOwn.MinimumSize = new System.Drawing.Size(194, 135);
            this.dgvOwn.Name = "dgvOwn";
            this.dgvOwn.RowTemplate.Height = 28;
            this.dgvOwn.Size = new System.Drawing.Size(194, 167);
            this.dgvOwn.TabIndex = 168;
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
            this.dgvCompetitor.Location = new System.Drawing.Point(225, 27);
            this.dgvCompetitor.MaximumSize = new System.Drawing.Size(180, 167);
            this.dgvCompetitor.MinimumSize = new System.Drawing.Size(180, 135);
            this.dgvCompetitor.Name = "dgvCompetitor";
            this.dgvCompetitor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvCompetitor.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvCompetitor.RowTemplate.Height = 28;
            this.dgvCompetitor.Size = new System.Drawing.Size(180, 167);
            this.dgvCompetitor.TabIndex = 168;
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
            // gbxCustomer
            // 
            this.gbxCustomer.Controls.Add(this.pnlCustomer);
            this.gbxCustomer.Controls.Add(this.pnlTownTownship);
            this.gbxCustomer.Controls.Add(this.btnNewCustomer);
            this.gbxCustomer.Controls.Add(this.cmbTownTownship);
            this.gbxCustomer.Controls.Add(this.rdoNonCustomer);
            this.gbxCustomer.Controls.Add(this.rdoExistingCustomer);
            this.gbxCustomer.Location = new System.Drawing.Point(18, 54);
            this.gbxCustomer.Name = "gbxCustomer";
            this.gbxCustomer.Size = new System.Drawing.Size(369, 139);
            this.gbxCustomer.TabIndex = 184;
            this.gbxCustomer.TabStop = false;
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.Controls.Add(this.label8);
            this.pnlCustomer.Controls.Add(this.cmbCustType);
            this.pnlCustomer.Controls.Add(this.label4);
            this.pnlCustomer.Controls.Add(this.cmbCustomer);
            this.pnlCustomer.Location = new System.Drawing.Point(10, 65);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.Size = new System.Drawing.Size(309, 68);
            this.pnlCustomer.TabIndex = 191;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 20);
            this.label8.TabIndex = 189;
            this.label8.Text = "Customer အမျိုးအစား";
            // 
            // cmbCustType
            // 
            this.cmbCustType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustType.DisplayMember = "CusTypeName";
            this.cmbCustType.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustType.FormattingEnabled = true;
            this.cmbCustType.Location = new System.Drawing.Point(148, 3);
            this.cmbCustType.Name = "cmbCustType";
            this.cmbCustType.Size = new System.Drawing.Size(157, 27);
            this.cmbCustType.TabIndex = 185;
            this.cmbCustType.ValueMember = "CusType";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 187;
            this.label4.Text = "Customer အမည်";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.DisplayMember = "CusName";
            this.cmbCustomer.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(148, 38);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(157, 27);
            this.cmbCustomer.TabIndex = 186;
            this.cmbCustomer.ValueMember = "CustomerID";
            this.cmbCustomer.SelectedValueChanged += new System.EventHandler(this.cmbCustomer_SelectedValueChanged);
            // 
            // pnlTownTownship
            // 
            this.pnlTownTownship.Controls.Add(this.rdoTownship);
            this.pnlTownTownship.Controls.Add(this.rdoTown);
            this.pnlTownTownship.Location = new System.Drawing.Point(10, 22);
            this.pnlTownTownship.Name = "pnlTownTownship";
            this.pnlTownTownship.Size = new System.Drawing.Size(125, 39);
            this.pnlTownTownship.TabIndex = 186;
            // 
            // rdoTownship
            // 
            this.rdoTownship.AutoSize = true;
            this.rdoTownship.Location = new System.Drawing.Point(53, 7);
            this.rdoTownship.Name = "rdoTownship";
            this.rdoTownship.Size = new System.Drawing.Size(68, 24);
            this.rdoTownship.TabIndex = 192;
            this.rdoTownship.Text = "မြို့နယ်";
            this.rdoTownship.UseVisualStyleBackColor = true;
            this.rdoTownship.CheckedChanged += new System.EventHandler(this.rdoTownTownship_CheckedChanged);
            // 
            // rdoTown
            // 
            this.rdoTown.AutoSize = true;
            this.rdoTown.Checked = true;
            this.rdoTown.Location = new System.Drawing.Point(4, 7);
            this.rdoTown.Name = "rdoTown";
            this.rdoTown.Size = new System.Drawing.Size(44, 24);
            this.rdoTown.TabIndex = 191;
            this.rdoTown.TabStop = true;
            this.rdoTown.Text = "မြို့";
            this.rdoTown.UseVisualStyleBackColor = true;
            this.rdoTown.CheckedChanged += new System.EventHandler(this.rdoTownTownship_CheckedChanged);
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCustomer.Location = new System.Drawing.Point(321, 102);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(45, 27);
            this.btnNewCustomer.TabIndex = 190;
            this.btnNewCustomer.Text = "+";
            this.btnNewCustomer.UseVisualStyleBackColor = true;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // cmbTownTownship
            // 
            this.cmbTownTownship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTownTownship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTownTownship.DisplayMember = "Town";
            this.cmbTownTownship.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTownTownship.FormattingEnabled = true;
            this.cmbTownTownship.Location = new System.Drawing.Point(158, 26);
            this.cmbTownTownship.Name = "cmbTownTownship";
            this.cmbTownTownship.Size = new System.Drawing.Size(157, 27);
            this.cmbTownTownship.TabIndex = 184;
            this.cmbTownTownship.ValueMember = "TownID";
            // 
            // rdoNonCustomer
            // 
            this.rdoNonCustomer.AutoSize = true;
            this.rdoNonCustomer.Location = new System.Drawing.Point(100, 0);
            this.rdoNonCustomer.Name = "rdoNonCustomer";
            this.rdoNonCustomer.Size = new System.Drawing.Size(147, 17);
            this.rdoNonCustomer.TabIndex = 183;
            this.rdoNonCustomer.Text = "Non-customer ( Potential )";
            this.rdoNonCustomer.UseVisualStyleBackColor = true;
            this.rdoNonCustomer.CheckedChanged += new System.EventHandler(this.rdoCustomer_CheckedChanged);
            // 
            // rdoExistingCustomer
            // 
            this.rdoExistingCustomer.AutoSize = true;
            this.rdoExistingCustomer.Checked = true;
            this.rdoExistingCustomer.Location = new System.Drawing.Point(10, 0);
            this.rdoExistingCustomer.Name = "rdoExistingCustomer";
            this.rdoExistingCustomer.Size = new System.Drawing.Size(75, 17);
            this.rdoExistingCustomer.TabIndex = 182;
            this.rdoExistingCustomer.TabStop = true;
            this.rdoExistingCustomer.Text = "Customer  ";
            this.rdoExistingCustomer.UseVisualStyleBackColor = true;
            this.rdoExistingCustomer.CheckedChanged += new System.EventHandler(this.rdoCustomer_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtpMarketedDate);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtEmployee);
            this.groupBox4.Location = new System.Drawing.Point(393, 54);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(301, 139);
            this.groupBox4.TabIndex = 185;
            this.groupBox4.TabStop = false;
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
            // lblFooter
            // 
            this.lblFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFooter.Enabled = false;
            this.lblFooter.Location = new System.Drawing.Point(16, 500);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(680, 1);
            this.lblFooter.TabIndex = 186;
            // 
            // frmNonCustomerDailyMarketingDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(713, 557);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbxCustomer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNonCustomerDailyMarketingDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Non Customer Daily Marketing Detail";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetitor)).EndInit();
            this.gbxCustomer.ResumeLayout(false);
            this.gbxCustomer.PerformLayout();
            this.pnlCustomer.ResumeLayout(false);
            this.pnlCustomer.PerformLayout();
            this.pnlTownTownship.ResumeLayout(false);
            this.pnlTownTownship.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmployee;
        private System.Windows.Forms.DateTimePicker dtpMarketedDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnAPUsage;
        private System.Windows.Forms.Button btnCompetitorActivity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvOwn;
        private System.Windows.Forms.DataGridViewComboBoxColumn colOwnBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarketingDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridView dgvCompetitor;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCompetitorBrand;
        private System.Windows.Forms.GroupBox gbxCustomer;
        private System.Windows.Forms.RadioButton rdoNonCustomer;
        private System.Windows.Forms.RadioButton rdoExistingCustomer;
        private System.Windows.Forms.ComboBox cmbCustType;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.ComboBox cmbTownTownship;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.RadioButton rdoTownship;
        private System.Windows.Forms.RadioButton rdoTown;
        private System.Windows.Forms.Panel pnlTownTownship;
        private System.Windows.Forms.Panel pnlCustomer;
        private System.Windows.Forms.Label lblFooter;
    }
}