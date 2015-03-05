namespace PTIC.VC.Marketing.DailyMarketing
{
    partial class frmTripPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.butDelete = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSalePage = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new AGL.UI.Controls.CalendarColumn();
            this.calendarColumn2 = new AGL.UI.Controls.CalendarColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTripPlanNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTripPlanName = new System.Windows.Forms.TextBox();
            this.dgvTripPlanDetail = new System.Windows.Forms.DataGridView();
            this.clnTripPlanNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTripPlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clntranportTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clnVenID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clnTripID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clnFromDate = new AGL.UI.Controls.CalendarColumn();
            this.clnToDate = new AGL.UI.Controls.CalendarColumn();
            this.clnManagerID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colTripPlanTargetOpen = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colTripPlanTargetID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clnRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTripPlanDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTripName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTripPlanName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNew = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripPlanDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // butDelete
            // 
            this.butDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDelete.Location = new System.Drawing.Point(252, 580);
            this.butDelete.Margin = new System.Windows.Forms.Padding(0);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(98, 33);
            this.butDelete.TabIndex = 6;
            this.butDelete.Text = "ဖျက်မည်";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(371, 580);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 33);
            this.button4.TabIndex = 4;
            this.button4.Text = "ခေတ္တသိမ်းမည်";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSave.Location = new System.Drawing.Point(133, 580);
            this.butSave.Margin = new System.Windows.Forms.Padding(0);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(98, 33);
            this.butSave.TabIndex = 5;
            this.butSave.Text = "သိမ်းမည်";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblSalePage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1277, 47);
            this.panel1.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(148, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = " > ခရီးစဉ် Plan";
            // 
            // lblSalePage
            // 
            this.lblSalePage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSalePage.AutoSize = true;
            this.lblSalePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalePage.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSalePage.Location = new System.Drawing.Point(7, 13);
            this.lblSalePage.Margin = new System.Windows.Forms.Padding(0);
            this.lblSalePage.Name = "lblSalePage";
            this.lblSalePage.Size = new System.Drawing.Size(135, 19);
            this.lblSalePage.TabIndex = 0;
            this.lblSalePage.Text = "ခရီးစဉ် Plan စာရင်း";
            this.lblSalePage.Click += new System.EventHandler(this.lblSalePage_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TripPlanDetailID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Trip Plan Detail ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "စဥ္";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 30;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TripPlanNo";
            this.dataGridViewTextBoxColumn3.HeaderText = "ခရီးစဥ္အမွတ္";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TripName";
            this.dataGridViewTextBoxColumn4.HeaderText = "Trip Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.DataPropertyName = "FromDate";
            this.calendarColumn1.HeaderText = "သြားမည့္ရက္";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // calendarColumn2
            // 
            this.calendarColumn2.DataPropertyName = "ToDate";
            this.calendarColumn2.HeaderText = "ျပန္ေရာက္မည့္ရက္";
            this.calendarColumn2.Name = "calendarColumn2";
            this.calendarColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Remark";
            this.dataGridViewTextBoxColumn5.HeaderText = "မွတ္ခ်က္";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // txtTripPlanNo
            // 
            this.txtTripPlanNo.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtTripPlanNo.Location = new System.Drawing.Point(881, 70);
            this.txtTripPlanNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtTripPlanNo.Name = "txtTripPlanNo";
            this.txtTripPlanNo.ReadOnly = true;
            this.txtTripPlanNo.Size = new System.Drawing.Size(172, 25);
            this.txtTripPlanNo.TabIndex = 120;
            this.txtTripPlanNo.Text = "TP1";
            this.txtTripPlanNo.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label1.Location = new System.Drawing.Point(304, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "မှ";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "MMMM/yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(158, 103);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(0);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(137, 25);
            this.dtFromDate.TabIndex = 1;
            this.dtFromDate.Value = new System.DateTime(2013, 11, 20, 0, 0, 0, 0);
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label4.Location = new System.Drawing.Point(776, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 19);
            this.label4.TabIndex = 22;
            this.label4.Text = "Trip Plan No.";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label5.Location = new System.Drawing.Point(14, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 19);
            this.label5.TabIndex = 121;
            this.label5.Text = "PTIC နယ်ခရီးစဉ် Plan";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "MMMM/yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(325, 103);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(0);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(144, 25);
            this.dtToDate.TabIndex = 2;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label2.Location = new System.Drawing.Point(478, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "ထိ";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label7.Location = new System.Drawing.Point(14, 73);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 19);
            this.label7.TabIndex = 122;
            this.label7.Text = "Trip Plan အမည်";
            // 
            // txtTripPlanName
            // 
            this.txtTripPlanName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTripPlanName.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtTripPlanName.Location = new System.Drawing.Point(158, 71);
            this.txtTripPlanName.Margin = new System.Windows.Forms.Padding(0);
            this.txtTripPlanName.Name = "txtTripPlanName";
            this.txtTripPlanName.Size = new System.Drawing.Size(212, 25);
            this.txtTripPlanName.TabIndex = 0;
            // 
            // dgvTripPlanDetail
            // 
            this.dgvTripPlanDetail.AllowUserToAddRows = false;
            this.dgvTripPlanDetail.AllowUserToDeleteRows = false;
            this.dgvTripPlanDetail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTripPlanDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTripPlanDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTripPlanDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnTripPlanNo,
            this.colTripPlanID,
            this.clntranportTypeID,
            this.clnVenID,
            this.clnTripID,
            this.clnFromDate,
            this.clnToDate,
            this.clnManagerID,
            this.colTripPlanTargetOpen,
            this.colTripPlanTargetID,
            this.dgvColBtn,
            this.clnRemark,
            this.clnTripPlanDetailID,
            this.clnTripName,
            this.colTripPlanName});
            this.dgvTripPlanDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTripPlanDetail.Location = new System.Drawing.Point(14, 153);
            this.dgvTripPlanDetail.Margin = new System.Windows.Forms.Padding(0);
            this.dgvTripPlanDetail.Name = "dgvTripPlanDetail";
            this.dgvTripPlanDetail.RowHeadersWidth = 50;
            this.dgvTripPlanDetail.RowTemplate.Height = 28;
            this.dgvTripPlanDetail.Size = new System.Drawing.Size(1256, 420);
            this.dgvTripPlanDetail.TabIndex = 3;
            this.dgvTripPlanDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dgvTripPlanDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTripPlanDetail_CellEndEdit);
            this.dgvTripPlanDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvTripPlanDetail_CellValidating);
            this.dgvTripPlanDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTripPlanDetail_CellValueChanged);
            this.dgvTripPlanDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTripPlanDetail_DataBindingComplete);
            this.dgvTripPlanDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTripPlanDetail_DataError);
            this.dgvTripPlanDetail.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTripPlanDetail_RowHeaderMouseDoubleClick);
            //this.dgvTripPlanDetail.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTripPlanDetail_RowPostPaint);
            // 
            // clnTripPlanNo
            // 
            this.clnTripPlanNo.DataPropertyName = "TripPlanNo";
            this.clnTripPlanNo.HeaderText = "ခရီးစဉ်အမှတ်";
            this.clnTripPlanNo.Name = "clnTripPlanNo";
            this.clnTripPlanNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTripPlanID
            // 
            this.colTripPlanID.DataPropertyName = "TripPlanID";
            this.colTripPlanID.HeaderText = "TripPlanID";
            this.colTripPlanID.Name = "colTripPlanID";
            this.colTripPlanID.Visible = false;
            // 
            // clntranportTypeID
            // 
            this.clntranportTypeID.DataPropertyName = "TransportTypeID";
            this.clntranportTypeID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.clntranportTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clntranportTypeID.HeaderText = "ပို့ဆောင်ရေးစနစ်";
            this.clntranportTypeID.Name = "clntranportTypeID";
            this.clntranportTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clntranportTypeID.Width = 130;
            // 
            // clnVenID
            // 
            this.clnVenID.DataPropertyName = "VenID";
            this.clnVenID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.clnVenID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clnVenID.HeaderText = "အရောင်းကားနံပါတ်";
            this.clnVenID.Name = "clnVenID";
            this.clnVenID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnVenID.Width = 130;
            // 
            // clnTripID
            // 
            this.clnTripID.DataPropertyName = "TripID";
            this.clnTripID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.clnTripID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clnTripID.HeaderText = "ခရီးစဉ်";
            this.clnTripID.Name = "clnTripID";
            this.clnTripID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnTripID.Width = 150;
            // 
            // clnFromDate
            // 
            this.clnFromDate.DataPropertyName = "FromDate";
            this.clnFromDate.HeaderText = "သွားမည့်ရက်";
            this.clnFromDate.Name = "clnFromDate";
            this.clnFromDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clnToDate
            // 
            this.clnToDate.DataPropertyName = "ToDate";
            this.clnToDate.HeaderText = "ပြန်ရောက်မည့်ရက်";
            this.clnToDate.Name = "clnToDate";
            this.clnToDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnToDate.Width = 130;
            // 
            // clnManagerID
            // 
            this.clnManagerID.DataPropertyName = "ManagerID";
            this.clnManagerID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.clnManagerID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clnManagerID.HeaderText = "ခရီးစဉ်တာဝန်ခံအမည်";
            this.clnManagerID.Name = "clnManagerID";
            this.clnManagerID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnManagerID.Width = 140;
            // 
            // colTripPlanTargetOpen
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "Trip Target";
            this.colTripPlanTargetOpen.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTripPlanTargetOpen.HeaderText = "Trip Target";
            this.colTripPlanTargetOpen.Name = "colTripPlanTargetOpen";
            this.colTripPlanTargetOpen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTripPlanTargetOpen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colTripPlanTargetID
            // 
            this.colTripPlanTargetID.DataPropertyName = "TripPlanTargetID";
            this.colTripPlanTargetID.HeaderText = "TripPlanTarget";
            this.colTripPlanTargetID.Name = "colTripPlanTargetID";
            this.colTripPlanTargetID.Visible = false;
            // 
            // dgvColBtn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "Trip Detail";
            this.dgvColBtn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvColBtn.HeaderText = "အသေးစိတ်အစီအစဉ်";
            this.dgvColBtn.Name = "dgvColBtn";
            this.dgvColBtn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColBtn.Width = 130;
            // 
            // clnRemark
            // 
            this.clnRemark.DataPropertyName = "Remark";
            this.clnRemark.HeaderText = "မှတ်ချက်";
            this.clnRemark.Name = "clnRemark";
            this.clnRemark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clnRemark.Width = 94;
            // 
            // clnTripPlanDetailID
            // 
            this.clnTripPlanDetailID.DataPropertyName = "TripPlanDetailID";
            this.clnTripPlanDetailID.HeaderText = "Trip Plan Detail ID";
            this.clnTripPlanDetailID.Name = "clnTripPlanDetailID";
            this.clnTripPlanDetailID.ReadOnly = true;
            this.clnTripPlanDetailID.Visible = false;
            // 
            // clnTripName
            // 
            this.clnTripName.DataPropertyName = "TripName";
            this.clnTripName.HeaderText = "Trip Name";
            this.clnTripName.Name = "clnTripName";
            this.clnTripName.Visible = false;
            // 
            // colTripPlanName
            // 
            this.colTripPlanName.DataPropertyName = "TripPlanName";
            this.colTripPlanName.HeaderText = "TripPlanName";
            this.colTripPlanName.Name = "colTripPlanName";
            this.colTripPlanName.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(14, 580);
            this.btnNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(98, 33);
            this.btnNew.TabIndex = 123;
            this.btnNew.Text = "ထည့်မည်";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1109, 71);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 33);
            this.button1.TabIndex = 124;
            this.button1.Text = "Edit View Setting";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmTripPlan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1277, 620);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.dgvTripPlanDetail);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTripPlanName);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTripPlanNo);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtFromDate);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(0, 7, 0, 7);
            this.MaximizeBox = false;
            this.Name = "frmTripPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trip Plan";
            this.Load += new System.EventHandler(this.frmTripPlan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTripPlanDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSalePage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private AGL.UI.Controls.CalendarColumn calendarColumn1;
        private AGL.UI.Controls.CalendarColumn calendarColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.TextBox txtTripPlanNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTripPlanName;
        private System.Windows.Forms.DataGridView dgvTripPlanDetail;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTripPlanNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTripPlanID;
        private System.Windows.Forms.DataGridViewComboBoxColumn clntranportTypeID;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnVenID;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnTripID;
        private AGL.UI.Controls.CalendarColumn clnFromDate;
        private AGL.UI.Controls.CalendarColumn clnToDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnManagerID;
        private System.Windows.Forms.DataGridViewButtonColumn colTripPlanTargetOpen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTripPlanTargetID;
        private System.Windows.Forms.DataGridViewButtonColumn dgvColBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTripPlanDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTripName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTripPlanName;
    }
}