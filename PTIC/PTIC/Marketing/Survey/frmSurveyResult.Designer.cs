namespace PTIC.Marketing.Survey
{
    partial class frmSurveyResult
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkTownTownship = new System.Windows.Forms.CheckBox();
            this.dgvSurveyResult = new System.Windows.Forms.DataGridView();
            this.colQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuestionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPayMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAnsMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvgMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSatisfaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbTripOrRoute = new System.Windows.Forms.ComboBox();
            this.rdoTrip = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoRoute = new System.Windows.Forms.RadioButton();
            this.cmbTownTownship = new System.Windows.Forms.ComboBox();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.chkCustomerType = new System.Windows.Forms.CheckBox();
            this.cmbSurveyType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnSearchBySurvery = new System.Windows.Forms.Button();
            this.dtpSurveyEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpSurveyStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveyResult)).BeginInit();
            this.panel4.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // dgvSurveyResult
            // 
            this.dgvSurveyResult.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvSurveyResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSurveyResult.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSurveyResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSurveyResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSurveyResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colQuestion,
            this.colQuestionNo,
            this.colTotalPayMark,
            this.colTotalAnsMark,
            this.colAvgMark,
            this.colSatisfaction});
            this.dgvSurveyResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSurveyResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSurveyResult.Location = new System.Drawing.Point(0, 0);
            this.dgvSurveyResult.MultiSelect = false;
            this.dgvSurveyResult.Name = "dgvSurveyResult";
            this.dgvSurveyResult.RowHeadersWidth = 50;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvSurveyResult.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSurveyResult.RowTemplate.Height = 30;
            this.dgvSurveyResult.Size = new System.Drawing.Size(1284, 574);
            this.dgvSurveyResult.TabIndex = 134;
            // 
            // colQuestion
            // 
            this.colQuestion.DataPropertyName = "Question";
            this.colQuestion.HeaderText = "မေးခွန်း";
            this.colQuestion.Name = "colQuestion";
            this.colQuestion.ReadOnly = true;
            this.colQuestion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQuestion.Width = 500;
            // 
            // colQuestionNo
            // 
            this.colQuestionNo.DataPropertyName = "QuestionNo";
            this.colQuestionNo.HeaderText = "QuestionNo";
            this.colQuestionNo.Name = "colQuestionNo";
            this.colQuestionNo.ReadOnly = true;
            this.colQuestionNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQuestionNo.Visible = false;
            // 
            // colTotalPayMark
            // 
            this.colTotalPayMark.DataPropertyName = "TotalPayMark";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotalPayMark.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTotalPayMark.HeaderText = "စုစုပေါင်းအမှတ်";
            this.colTotalPayMark.Name = "colTotalPayMark";
            this.colTotalPayMark.ReadOnly = true;
            this.colTotalPayMark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTotalAnsMark
            // 
            this.colTotalAnsMark.DataPropertyName = "TotalAnsMark";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotalAnsMark.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTotalAnsMark.HeaderText = "ရမှတ်";
            this.colTotalAnsMark.Name = "colTotalAnsMark";
            this.colTotalAnsMark.ReadOnly = true;
            this.colTotalAnsMark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAvgMark
            // 
            this.colAvgMark.DataPropertyName = "AvgMark";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            this.colAvgMark.DefaultCellStyle = dataGridViewCellStyle5;
            this.colAvgMark.HeaderText = "ပျမ်းမျှရမှတ်";
            this.colAvgMark.MaxInputLength = 5;
            this.colAvgMark.Name = "colAvgMark";
            this.colAvgMark.ReadOnly = true;
            this.colAvgMark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSatisfaction
            // 
            this.colSatisfaction.DataPropertyName = "Satisfaction";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N3";
            this.colSatisfaction.DefaultCellStyle = dataGridViewCellStyle6;
            this.colSatisfaction.HeaderText = "ကျေနပ်မှု %";
            this.colSatisfaction.MaxInputLength = 5;
            this.colSatisfaction.Name = "colSatisfaction";
            this.colSatisfaction.ReadOnly = true;
            this.colSatisfaction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.cmbTripOrRoute.TabIndex = 200;
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
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.dgvSurveyResult);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 166);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1288, 578);
            this.panel4.TabIndex = 184;
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
            this.cmbTownTownship.TabIndex = 197;
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomerType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomerType.DisplayMember = "APSubCategoryName";
            this.cmbCustomerType.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Location = new System.Drawing.Point(456, 43);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(170, 27);
            this.cmbCustomerType.TabIndex = 196;
            this.cmbCustomerType.ValueMember = "ID";
            this.cmbCustomerType.Visible = false;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lblFilter.Location = new System.Drawing.Point(3, 1);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(166, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Advance Search";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // chkCustomerType
            // 
            this.chkCustomerType.AutoSize = true;
            this.chkCustomerType.Location = new System.Drawing.Point(325, 45);
            this.chkCustomerType.Name = "chkCustomerType";
            this.chkCustomerType.Size = new System.Drawing.Size(117, 23);
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
            this.cmbSurveyType.TabIndex = 190;
            this.cmbSurveyType.ValueMember = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(321, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 19);
            this.label4.TabIndex = 188;
            this.label4.Text = "Survey Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 19);
            this.label3.TabIndex = 187;
            this.label3.Text = "ထိ";
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
            this.pnlFilt.Size = new System.Drawing.Size(1288, 27);
            this.pnlFilt.TabIndex = 182;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnSearchBySurvery);
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
            this.pnlFilter.Location = new System.Drawing.Point(0, 68);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1288, 98);
            this.pnlFilter.TabIndex = 183;
            // 
            // btnSearchBySurvery
            // 
            this.btnSearchBySurvery.Location = new System.Drawing.Point(456, 69);
            this.btnSearchBySurvery.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearchBySurvery.Name = "btnSearchBySurvery";
            this.btnSearchBySurvery.Size = new System.Drawing.Size(170, 28);
            this.btnSearchBySurvery.TabIndex = 202;
            this.btnSearchBySurvery.Text = "Survey Type ဖြင့်ရှာမည်";
            this.btnSearchBySurvery.UseVisualStyleBackColor = true;
            this.btnSearchBySurvery.Click += new System.EventHandler(this.btnSearchBySurvery_Click);
            // 
            // dtpSurveyEndDate
            // 
            this.dtpSurveyEndDate.CustomFormat = "MMM-yyyy";
            this.dtpSurveyEndDate.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dtpSurveyEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSurveyEndDate.Location = new System.Drawing.Point(143, 44);
            this.dtpSurveyEndDate.Name = "dtpSurveyEndDate";
            this.dtpSurveyEndDate.Size = new System.Drawing.Size(127, 28);
            this.dtpSurveyEndDate.TabIndex = 186;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 19);
            this.label2.TabIndex = 185;
            this.label2.Text = "မှ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 19);
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
            this.dtpSurveyStartDate.TabIndex = 180;
            this.dtpSurveyStartDate.ValueChanged += new System.EventHandler(this.dtpSurveyStartDate_ValueChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1007, 40);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.panel1.Size = new System.Drawing.Size(1288, 41);
            this.panel1.TabIndex = 185;
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
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click_1);
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(143, 10);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(140, 20);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">    Survey Result";
            // 
            // frmSurveyResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 744);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSurveyResult";
            this.Text = "Survey Result";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveyResult)).EndInit();
            this.panel4.ResumeLayout(false);
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkTownTownship;
        private System.Windows.Forms.DataGridView dgvSurveyResult;
        private System.Windows.Forms.ComboBox cmbTripOrRoute;
        private System.Windows.Forms.RadioButton rdoTrip;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdoRoute;
        private System.Windows.Forms.ComboBox cmbTownTownship;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.CheckBox chkCustomerType;
        private System.Windows.Forms.ComboBox cmbSurveyType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.DateTimePicker dtpSurveyEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpSurveyStartDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Button btnSearchBySurvery;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuestionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPayMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAnsMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvgMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSatisfaction;
    }
}