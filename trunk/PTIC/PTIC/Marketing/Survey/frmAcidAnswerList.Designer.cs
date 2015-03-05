namespace PTIC.Marketing.Survey
{
    partial class frmAcidAnswerList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnByFormType = new System.Windows.Forms.Button();
            this.chkTownTownship = new System.Windows.Forms.CheckBox();
            this.cmbTripOrRoute = new System.Windows.Forms.ComboBox();
            this.rdoTrip = new System.Windows.Forms.RadioButton();
            this.rdoRoute = new System.Windows.Forms.RadioButton();
            this.cmbTownTownship = new System.Windows.Forms.ComboBox();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.chkCustomerType = new System.Windows.Forms.CheckBox();
            this.cmbSurveyType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSurveyEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpSurveyStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvAnswer = new System.Windows.Forms.DataGridView();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSurveyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colListedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuestionFormID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnswer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblSetup);
            this.panel1.Controls.Add(this.lblHeaderPCat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 41);
            this.panel1.TabIndex = 0;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(8, 10);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(129, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Survey Question";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(143, 10);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(192, 20);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">    Survey Question List";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnByFormType);
            this.pnlFilter.Controls.Add(this.chkTownTownship);
            this.pnlFilter.Controls.Add(this.cmbTripOrRoute);
            this.pnlFilter.Controls.Add(this.rdoTrip);
            this.pnlFilter.Controls.Add(this.rdoRoute);
            this.pnlFilter.Controls.Add(this.cmbTownTownship);
            this.pnlFilter.Controls.Add(this.cmbCustomerType);
            this.pnlFilter.Controls.Add(this.chkCustomerType);
            this.pnlFilter.Controls.Add(this.cmbSurveyType);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.dtpSurveyEndDate);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.dtpSurveyStartDate);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 63);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1020, 106);
            this.pnlFilter.TabIndex = 179;
            // 
            // btnByFormType
            // 
            this.btnByFormType.Location = new System.Drawing.Point(456, 44);
            this.btnByFormType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnByFormType.Name = "btnByFormType";
            this.btnByFormType.Size = new System.Drawing.Size(170, 28);
            this.btnByFormType.TabIndex = 7;
            this.btnByFormType.Text = "Survey Type ဖြင့်ရှာမည်";
            this.btnByFormType.UseVisualStyleBackColor = true;
            this.btnByFormType.Click += new System.EventHandler(this.btnByFormType_Click);
            // 
            // chkTownTownship
            // 
            this.chkTownTownship.AutoSize = true;
            this.chkTownTownship.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.chkTownTownship.Location = new System.Drawing.Point(669, 70);
            this.chkTownTownship.Name = "chkTownTownship";
            this.chkTownTownship.Size = new System.Drawing.Size(98, 24);
            this.chkTownTownship.TabIndex = 201;
            this.chkTownTownship.Text = "မြို့ / မြို့နယ်";
            this.chkTownTownship.UseVisualStyleBackColor = true;
            // 
            // cmbTripOrRoute
            // 
            this.cmbTripOrRoute.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTripOrRoute.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTripOrRoute.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbTripOrRoute.FormattingEnabled = true;
            this.cmbTripOrRoute.ItemHeight = 19;
            this.cmbTripOrRoute.Location = new System.Drawing.Point(776, 17);
            this.cmbTripOrRoute.Name = "cmbTripOrRoute";
            this.cmbTripOrRoute.Size = new System.Drawing.Size(196, 27);
            this.cmbTripOrRoute.TabIndex = 4;
            // 
            // rdoTrip
            // 
            this.rdoTrip.AutoSize = true;
            this.rdoTrip.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.rdoTrip.Location = new System.Drawing.Point(670, 4);
            this.rdoTrip.Name = "rdoTrip";
            this.rdoTrip.Size = new System.Drawing.Size(68, 24);
            this.rdoTrip.TabIndex = 199;
            this.rdoTrip.Text = "ခရီးစဉ်";
            this.rdoTrip.UseVisualStyleBackColor = true;
            this.rdoTrip.CheckedChanged += new System.EventHandler(this.rdoTrip_CheckedChanged);
            // 
            // rdoRoute
            // 
            this.rdoRoute.AutoSize = true;
            this.rdoRoute.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.rdoRoute.Location = new System.Drawing.Point(669, 34);
            this.rdoRoute.Name = "rdoRoute";
            this.rdoRoute.Size = new System.Drawing.Size(101, 24);
            this.rdoRoute.TabIndex = 198;
            this.rdoRoute.Text = "လမ်း‌ကြောင်း";
            this.rdoRoute.UseVisualStyleBackColor = true;
            this.rdoRoute.CheckedChanged += new System.EventHandler(this.rdoRoute_CheckedChanged);
            // 
            // cmbTownTownship
            // 
            this.cmbTownTownship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTownTownship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTownTownship.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbTownTownship.FormattingEnabled = true;
            this.cmbTownTownship.ItemHeight = 19;
            this.cmbTownTownship.Location = new System.Drawing.Point(776, 69);
            this.cmbTownTownship.Name = "cmbTownTownship";
            this.cmbTownTownship.Size = new System.Drawing.Size(196, 27);
            this.cmbTownTownship.TabIndex = 5;
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomerType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomerType.DisplayMember = "APSubCategoryName";
            this.cmbCustomerType.Enabled = false;
            this.cmbCustomerType.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Location = new System.Drawing.Point(456, 43);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(170, 27);
            this.cmbCustomerType.TabIndex = 3;
            this.cmbCustomerType.ValueMember = "ID";
            this.cmbCustomerType.Visible = false;
            // 
            // chkCustomerType
            // 
            this.chkCustomerType.AutoSize = true;
            this.chkCustomerType.Enabled = false;
            this.chkCustomerType.Location = new System.Drawing.Point(325, 45);
            this.chkCustomerType.Name = "chkCustomerType";
            this.chkCustomerType.Size = new System.Drawing.Size(125, 24);
            this.chkCustomerType.TabIndex = 195;
            this.chkCustomerType.Text = "Customer Type";
            this.chkCustomerType.UseVisualStyleBackColor = true;
            this.chkCustomerType.Visible = false;
            // 
            // cmbSurveyType
            // 
            this.cmbSurveyType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSurveyType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSurveyType.DisplayMember = "APSubCategoryName";
            this.cmbSurveyType.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbSurveyType.FormattingEnabled = true;
            this.cmbSurveyType.Items.AddRange(new object[] {
            "Toyo Battery",
            "Lion Cycle Battery",
            "Acid"});
            this.cmbSurveyType.Location = new System.Drawing.Point(456, 11);
            this.cmbSurveyType.Name = "cmbSurveyType";
            this.cmbSurveyType.Size = new System.Drawing.Size(170, 27);
            this.cmbSurveyType.TabIndex = 2;
            this.cmbSurveyType.ValueMember = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 188;
            this.label4.Text = "Survey Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.TabIndex = 187;
            this.label3.Text = "ထိ";
            // 
            // dtpSurveyEndDate
            // 
            this.dtpSurveyEndDate.CustomFormat = "MMM-yyyy";
            this.dtpSurveyEndDate.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dtpSurveyEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSurveyEndDate.Location = new System.Drawing.Point(143, 44);
            this.dtpSurveyEndDate.Name = "dtpSurveyEndDate";
            this.dtpSurveyEndDate.Size = new System.Drawing.Size(127, 28);
            this.dtpSurveyEndDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 185;
            this.label2.Text = "မှ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 184;
            this.label1.Text = "ကောက်ယူသည့် နေ့စွဲ";
            // 
            // dtpSurveyStartDate
            // 
            this.dtpSurveyStartDate.CustomFormat = "MMM-yyyy";
            this.dtpSurveyStartDate.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dtpSurveyStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSurveyStartDate.Location = new System.Drawing.Point(143, 11);
            this.dtpSurveyStartDate.Name = "dtpSurveyStartDate";
            this.dtpSurveyStartDate.Size = new System.Drawing.Size(127, 28);
            this.dtpSurveyStartDate.TabIndex = 0;
            this.dtpSurveyStartDate.ValueChanged += new System.EventHandler(this.dtpSurveyStartDate_ValueChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(999, 16);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 28);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlFilt
            // 
            this.pnlFilt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(149)))), ((int)(((byte)(206)))));
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 41);
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(1020, 22);
            this.pnlFilt.TabIndex = 178;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lblFilter.Location = new System.Drawing.Point(3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(166, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Advance Search";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.dgvAnswer);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 169);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1020, 454);
            this.panel4.TabIndex = 180;
            // 
            // dgvAnswer
            // 
            this.dgvAnswer.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvAnswer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAnswer.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAnswer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAnswer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnswer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomer,
            this.colSurveyDate,
            this.colListedDate,
            this.colDetail,
            this.colCustomerID,
            this.colQuestionFormID});
            this.dgvAnswer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnswer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAnswer.Location = new System.Drawing.Point(0, 0);
            this.dgvAnswer.MultiSelect = false;
            this.dgvAnswer.Name = "dgvAnswer";
            this.dgvAnswer.RowHeadersWidth = 50;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvAnswer.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAnswer.RowTemplate.Height = 30;
            this.dgvAnswer.Size = new System.Drawing.Size(1016, 450);
            this.dgvAnswer.TabIndex = 134;
            this.dgvAnswer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnswer_CellContentClick);
            this.dgvAnswer.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAnswer_DataBindingComplete);
            // 
            // colCustomer
            // 
            this.colCustomer.DataPropertyName = "CusName";
            this.colCustomer.HeaderText = "Customer အမည်";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Width = 300;
            // 
            // colSurveyDate
            // 
            this.colSurveyDate.DataPropertyName = "SurveyDate";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colSurveyDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSurveyDate.HeaderText = "ကောက်ခံသည့်နေ့";
            this.colSurveyDate.Name = "colSurveyDate";
            this.colSurveyDate.ReadOnly = true;
            this.colSurveyDate.Width = 150;
            // 
            // colListedDate
            // 
            this.colListedDate.DataPropertyName = "DateAdded";
            dataGridViewCellStyle4.Format = "d";
            this.colListedDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.colListedDate.HeaderText = "စာရင်းသွင်းသည့်နေ့";
            this.colListedDate.Name = "colListedDate";
            this.colListedDate.ReadOnly = true;
            this.colListedDate.Width = 150;
            // 
            // colDetail
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = "ကြည့်မည်";
            this.colDetail.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDetail.HeaderText = "Detail";
            this.colDetail.Name = "colDetail";
            this.colDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colCustomerID
            // 
            this.colCustomerID.DataPropertyName = "CustomerID";
            this.colCustomerID.HeaderText = "CusID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.ReadOnly = true;
            this.colCustomerID.Visible = false;
            // 
            // colQuestionFormID
            // 
            this.colQuestionFormID.DataPropertyName = "QuestionFormID";
            this.colQuestionFormID.HeaderText = "colQuestionFormID";
            this.colQuestionFormID.Name = "colQuestionFormID";
            this.colQuestionFormID.Visible = false;
            // 
            // frmAcidAnswerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1020, 623);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAcidAnswerList";
            this.Text = "Acid Answer Chart";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnswer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSurveyType;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.CheckBox chkCustomerType;
        private System.Windows.Forms.DataGridView dgvAnswer;
        private System.Windows.Forms.CheckBox chkTownTownship;
        private System.Windows.Forms.ComboBox cmbTripOrRoute;
        private System.Windows.Forms.RadioButton rdoTrip;
        private System.Windows.Forms.RadioButton rdoRoute;
        private System.Windows.Forms.ComboBox cmbTownTownship;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSurveyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListedDate;
        private System.Windows.Forms.DataGridViewButtonColumn colDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuestionFormID;
        private System.Windows.Forms.DateTimePicker dtpSurveyEndDate;
        private System.Windows.Forms.DateTimePicker dtpSurveyStartDate;
        private System.Windows.Forms.Button btnByFormType;

    }
}