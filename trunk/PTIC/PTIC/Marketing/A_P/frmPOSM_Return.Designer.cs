namespace PTIC.VC.Marketing.A_P
{
    partial class frmPOSM_Return
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvReturnDetail = new System.Windows.Forms.DataGridView();
            this.colA_P_SubCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colA_P_Material = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colReturnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReturnPurpose = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAP_ReturnDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromDeptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromVenID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToDeptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReturnNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToVenID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAP_ReturnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlEntry = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoToVen = new System.Windows.Forms.RadioButton();
            this.rdoToDept = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbToDeptOrVen = new System.Windows.Forms.ComboBox();
            this.cmbToEmployee = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoFromDept = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFromDeptOrVen = new System.Windows.Forms.ComboBox();
            this.cmbFromEmployee = new System.Windows.Forms.ComboBox();
            this.txtReturnNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpKW_Date = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbKW_FromDepartment = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.rdoFromVen = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnDetail)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlEntry.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReturnDetail
            // 
            this.dgvReturnDetail.AllowUserToAddRows = false;
            this.dgvReturnDetail.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvReturnDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(131)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReturnDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.dgvReturnDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturnDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colA_P_SubCategory,
            this.colA_P_Material,
            this.colReturnQty,
            this.colRemark,
            this.colReturnPurpose,
            this.colAP_ReturnDetailID,
            this.colFromDeptID,
            this.colFromVenID,
            this.colFromEmpID,
            this.colToDeptID,
            this.colReturnDate,
            this.colReturnNo,
            this.colToVenID,
            this.colToEmpID,
            this.colAP_ReturnID});
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReturnDetail.DefaultCellStyle = dataGridViewCellStyle31;
            this.dgvReturnDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReturnDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvReturnDetail.EnableHeadersVisualStyles = false;
            this.dgvReturnDetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(255)))));
            this.dgvReturnDetail.Location = new System.Drawing.Point(0, 267);
            this.dgvReturnDetail.Name = "dgvReturnDetail";
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(131)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReturnDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.dgvReturnDetail.RowHeadersWidth = 50;
            this.dgvReturnDetail.RowTemplate.Height = 28;
            this.dgvReturnDetail.Size = new System.Drawing.Size(1020, 132);
            this.dgvReturnDetail.TabIndex = 193;
            this.dgvReturnDetail.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvReturnDetail_CellBeginEdit);
            this.dgvReturnDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReturnDetail_CellEndEdit);
            this.dgvReturnDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvReturnDetail_CellValidating);
            this.dgvReturnDetail.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvReturnDetail_CurrentCellDirtyStateChanged);
            this.dgvReturnDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvReturnDetail_DataError);
            this.dgvReturnDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvReturnDetail_EditingControlShowing);
            // 
            // colA_P_SubCategory
            // 
            this.colA_P_SubCategory.DataPropertyName = "APSubCategoryID";
            this.colA_P_SubCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colA_P_SubCategory.HeaderText = "A & P အမျိုးအစားခွဲ";
            this.colA_P_SubCategory.Name = "colA_P_SubCategory";
            this.colA_P_SubCategory.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colA_P_SubCategory.Width = 130;
            // 
            // colA_P_Material
            // 
            this.colA_P_Material.DataPropertyName = "A_P_MaterialID";
            this.colA_P_Material.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colA_P_Material.HeaderText = "POSM";
            this.colA_P_Material.Name = "colA_P_Material";
            this.colA_P_Material.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colA_P_Material.Width = 130;
            // 
            // colReturnQty
            // 
            this.colReturnQty.DataPropertyName = "ReturnQty";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle30.NullValue = "0";
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colReturnQty.DefaultCellStyle = dataGridViewCellStyle30;
            this.colReturnQty.HeaderText = "Qty";
            this.colReturnQty.MaxInputLength = 4;
            this.colReturnQty.Name = "colReturnQty";
            this.colReturnQty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colReturnQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colReturnQty.Width = 90;
            // 
            // colRemark
            // 
            this.colRemark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "မှတ်ချက်";
            this.colRemark.Name = "colRemark";
            this.colRemark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRemark.Width = 58;
            // 
            // colReturnPurpose
            // 
            this.colReturnPurpose.DataPropertyName = "ReturnPurpose";
            this.colReturnPurpose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colReturnPurpose.HeaderText = "အကြောင်းအရာ";
            this.colReturnPurpose.Items.AddRange(new object[] {
            "Outlet များပေး",
            "Retailer များပေး",
            "ခရီးစဉ်",
            "လက်ဆောင်ပေး",
            "ရုံးသုံး",
            "အခြား"});
            this.colReturnPurpose.Name = "colReturnPurpose";
            this.colReturnPurpose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colReturnPurpose.Visible = false;
            this.colReturnPurpose.Width = 200;
            // 
            // colAP_ReturnDetailID
            // 
            this.colAP_ReturnDetailID.DataPropertyName = "AP_ReturnDetailID";
            this.colAP_ReturnDetailID.HeaderText = "AP_ReturnDetailID";
            this.colAP_ReturnDetailID.Name = "colAP_ReturnDetailID";
            this.colAP_ReturnDetailID.Visible = false;
            // 
            // colFromDeptID
            // 
            this.colFromDeptID.DataPropertyName = "FromDeptID";
            this.colFromDeptID.HeaderText = "FromDeptID";
            this.colFromDeptID.Name = "colFromDeptID";
            this.colFromDeptID.Visible = false;
            // 
            // colFromVenID
            // 
            this.colFromVenID.DataPropertyName = "FromVenID";
            this.colFromVenID.HeaderText = "FromVenID";
            this.colFromVenID.Name = "colFromVenID";
            this.colFromVenID.Visible = false;
            // 
            // colFromEmpID
            // 
            this.colFromEmpID.DataPropertyName = "FromEmpID";
            this.colFromEmpID.HeaderText = "FromEmpID";
            this.colFromEmpID.Name = "colFromEmpID";
            this.colFromEmpID.Visible = false;
            // 
            // colToDeptID
            // 
            this.colToDeptID.DataPropertyName = "ToDeptID";
            this.colToDeptID.HeaderText = "ToDeptID";
            this.colToDeptID.Name = "colToDeptID";
            this.colToDeptID.Visible = false;
            // 
            // colReturnDate
            // 
            this.colReturnDate.DataPropertyName = "ReturnDate";
            this.colReturnDate.HeaderText = "ReturnDate";
            this.colReturnDate.Name = "colReturnDate";
            this.colReturnDate.Visible = false;
            // 
            // colReturnNo
            // 
            this.colReturnNo.DataPropertyName = "ReturnNo";
            this.colReturnNo.HeaderText = "ReturnNo";
            this.colReturnNo.Name = "colReturnNo";
            this.colReturnNo.Visible = false;
            // 
            // colToVenID
            // 
            this.colToVenID.DataPropertyName = "ToVenID";
            this.colToVenID.HeaderText = "ToVenID";
            this.colToVenID.Name = "colToVenID";
            this.colToVenID.Visible = false;
            // 
            // colToEmpID
            // 
            this.colToEmpID.DataPropertyName = "ToEmpID";
            this.colToEmpID.HeaderText = "ToEmpID";
            this.colToEmpID.Name = "colToEmpID";
            this.colToEmpID.Visible = false;
            // 
            // colAP_ReturnID
            // 
            this.colAP_ReturnID.DataPropertyName = "AP_ReturnID";
            this.colAP_ReturnID.HeaderText = "AP_ReturnID";
            this.colAP_ReturnID.Name = "colAP_ReturnID";
            this.colAP_ReturnID.Visible = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnNew);
            this.pnlFooter.Controls.Add(this.btnDelete);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 399);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1020, 50);
            this.pnlFooter.TabIndex = 192;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnNew.Location = new System.Drawing.Point(14, 8);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 34);
            this.btnNew.TabIndex = 172;
            this.btnNew.Text = "ထည့်မည်";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnDelete.Location = new System.Drawing.Point(236, 8);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 171;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSave.Location = new System.Drawing.Point(125, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 170;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlEntry
            // 
            this.pnlEntry.Controls.Add(this.groupBox2);
            this.pnlEntry.Controls.Add(this.groupBox1);
            this.pnlEntry.Controls.Add(this.txtReturnNo);
            this.pnlEntry.Controls.Add(this.label1);
            this.pnlEntry.Controls.Add(this.dtpReturnDate);
            this.pnlEntry.Controls.Add(this.label2);
            this.pnlEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEntry.Location = new System.Drawing.Point(0, 118);
            this.pnlEntry.Name = "pnlEntry";
            this.pnlEntry.Size = new System.Drawing.Size(1020, 149);
            this.pnlEntry.TabIndex = 191;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoToDept);
            this.groupBox2.Controls.Add(this.rdoToVen);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbToDeptOrVen);
            this.groupBox2.Controls.Add(this.cmbToEmployee);
            this.groupBox2.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Location = new System.Drawing.Point(552, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 127);
            this.groupBox2.TabIndex = 208;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "လက်ခံသည့်";
            // 
            // rdoToVen
            // 
            this.rdoToVen.AutoSize = true;
            this.rdoToVen.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.rdoToVen.Location = new System.Drawing.Point(22, 57);
            this.rdoToVen.Name = "rdoToVen";
            this.rdoToVen.Size = new System.Drawing.Size(95, 23);
            this.rdoToVen.TabIndex = 200;
            this.rdoToVen.Text = "အရောင်းကား";
            this.rdoToVen.UseVisualStyleBackColor = true;
            this.rdoToVen.Visible = false;
            this.rdoToVen.CheckedChanged += new System.EventHandler(this.rdoToVen_CheckedChanged);
            // 
            // rdoToDept
            // 
            this.rdoToDept.AutoSize = true;
            this.rdoToDept.Checked = true;
            this.rdoToDept.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.rdoToDept.Location = new System.Drawing.Point(22, 42);
            this.rdoToDept.Name = "rdoToDept";
            this.rdoToDept.Size = new System.Drawing.Size(49, 23);
            this.rdoToDept.TabIndex = 199;
            this.rdoToDept.TabStop = true;
            this.rdoToDept.Text = "ဌာန";
            this.rdoToDept.UseVisualStyleBackColor = true;
            this.rdoToDept.CheckedChanged += new System.EventHandler(this.rdoToDept_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label5.Location = new System.Drawing.Point(18, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 19);
            this.label5.TabIndex = 204;
            this.label5.Text = "ဝန်ထမ်း";
            // 
            // cmbToDeptOrVen
            // 
            this.cmbToDeptOrVen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbToDeptOrVen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbToDeptOrVen.DisplayMember = "Despt";
            this.cmbToDeptOrVen.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbToDeptOrVen.FormattingEnabled = true;
            this.cmbToDeptOrVen.Location = new System.Drawing.Point(132, 42);
            this.cmbToDeptOrVen.Name = "cmbToDeptOrVen";
            this.cmbToDeptOrVen.Size = new System.Drawing.Size(150, 25);
            this.cmbToDeptOrVen.TabIndex = 198;
            this.cmbToDeptOrVen.ValueMember = "ID";
            this.cmbToDeptOrVen.SelectedIndexChanged += new System.EventHandler(this.cmbToDeptOrVen_SelectedIndexChanged);
            this.cmbToDeptOrVen.SelectedValueChanged += new System.EventHandler(this.cmbFromTo_DepartmentVehicle_SelectedValueChanged);
            // 
            // cmbToEmployee
            // 
            this.cmbToEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbToEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbToEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbToEmployee.DisplayMember = "EmpName";
            this.cmbToEmployee.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbToEmployee.FormattingEnabled = true;
            this.cmbToEmployee.Location = new System.Drawing.Point(131, 89);
            this.cmbToEmployee.Name = "cmbToEmployee";
            this.cmbToEmployee.Size = new System.Drawing.Size(150, 25);
            this.cmbToEmployee.TabIndex = 203;
            this.cmbToEmployee.ValueMember = "EmployeeID";
            this.cmbToEmployee.SelectedValueChanged += new System.EventHandler(this.cmbEmployee_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoFromVen);
            this.groupBox1.Controls.Add(this.rdoFromDept);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbFromDeptOrVen);
            this.groupBox1.Controls.Add(this.cmbFromEmployee);
            this.groupBox1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(254, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 127);
            this.groupBox1.TabIndex = 207;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "​ပြန်လည်အပ်နှံသည့်";
            // 
            // rdoFromDept
            // 
            this.rdoFromDept.AutoSize = true;
            this.rdoFromDept.Checked = true;
            this.rdoFromDept.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.rdoFromDept.Location = new System.Drawing.Point(18, 27);
            this.rdoFromDept.Name = "rdoFromDept";
            this.rdoFromDept.Size = new System.Drawing.Size(49, 23);
            this.rdoFromDept.TabIndex = 196;
            this.rdoFromDept.TabStop = true;
            this.rdoFromDept.Text = "ဌာန";
            this.rdoFromDept.UseVisualStyleBackColor = true;
            this.rdoFromDept.CheckedChanged += new System.EventHandler(this.rdoFromDept_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label6.Location = new System.Drawing.Point(14, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 19);
            this.label6.TabIndex = 206;
            this.label6.Text = "ဝန်ထမ်း";
            // 
            // cmbFromDeptOrVen
            // 
            this.cmbFromDeptOrVen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFromDeptOrVen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFromDeptOrVen.DisplayMember = "Despt";
            this.cmbFromDeptOrVen.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbFromDeptOrVen.FormattingEnabled = true;
            this.cmbFromDeptOrVen.Location = new System.Drawing.Point(128, 40);
            this.cmbFromDeptOrVen.Name = "cmbFromDeptOrVen";
            this.cmbFromDeptOrVen.Size = new System.Drawing.Size(150, 25);
            this.cmbFromDeptOrVen.TabIndex = 195;
            this.cmbFromDeptOrVen.ValueMember = "ID";
            this.cmbFromDeptOrVen.SelectedIndexChanged += new System.EventHandler(this.cmbFromDeptOrVen_SelectedIndexChanged);
            this.cmbFromDeptOrVen.SelectedValueChanged += new System.EventHandler(this.cmbFromTo_DepartmentVehicle_SelectedValueChanged);
            // 
            // cmbFromEmployee
            // 
            this.cmbFromEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFromEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFromEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFromEmployee.DisplayMember = "EmpName";
            this.cmbFromEmployee.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbFromEmployee.FormattingEnabled = true;
            this.cmbFromEmployee.Location = new System.Drawing.Point(127, 89);
            this.cmbFromEmployee.Name = "cmbFromEmployee";
            this.cmbFromEmployee.Size = new System.Drawing.Size(150, 25);
            this.cmbFromEmployee.TabIndex = 205;
            this.cmbFromEmployee.ValueMember = "EmployeeID";
            this.cmbFromEmployee.SelectedValueChanged += new System.EventHandler(this.cmbEmployee_SelectedValueChanged);
            // 
            // txtReturnNo
            // 
            this.txtReturnNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReturnNo.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtReturnNo.Location = new System.Drawing.Point(98, 52);
            this.txtReturnNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtReturnNo.Name = "txtReturnNo";
            this.txtReturnNo.Size = new System.Drawing.Size(150, 25);
            this.txtReturnNo.TabIndex = 199;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label1.Location = new System.Drawing.Point(16, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 198;
            this.label1.Text = "စာအမှတ်";
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpReturnDate.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReturnDate.Location = new System.Drawing.Point(98, 18);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(150, 25);
            this.dtpReturnDate.TabIndex = 197;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label2.Location = new System.Drawing.Point(16, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 19);
            this.label2.TabIndex = 196;
            this.label2.Text = "နေ့စွဲ";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Controls.Add(this.dtpKW_Date);
            this.pnlFilter.Controls.Add(this.label7);
            this.pnlFilter.Controls.Add(this.cmbKW_FromDepartment);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 67);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1020, 51);
            this.pnlFilter.TabIndex = 190;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label3.Location = new System.Drawing.Point(234, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 19);
            this.label3.TabIndex = 199;
            this.label3.Text = "​ပြန်လည်အပ်နှံသည့်ဌာန";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1007, 100);
            this.panel3.TabIndex = 174;
            // 
            // dtpKW_Date
            // 
            this.dtpKW_Date.CustomFormat = "dd-MMM-yyyy";
            this.dtpKW_Date.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dtpKW_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKW_Date.Location = new System.Drawing.Point(56, 13);
            this.dtpKW_Date.Name = "dtpKW_Date";
            this.dtpKW_Date.Size = new System.Drawing.Size(150, 25);
            this.dtpKW_Date.TabIndex = 180;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label7.Location = new System.Drawing.Point(16, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 19);
            this.label7.TabIndex = 179;
            this.label7.Text = "နေ့စွဲ";
            // 
            // cmbKW_FromDepartment
            // 
            this.cmbKW_FromDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbKW_FromDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbKW_FromDepartment.DisplayMember = "Despt";
            this.cmbKW_FromDepartment.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbKW_FromDepartment.FormattingEnabled = true;
            this.cmbKW_FromDepartment.Location = new System.Drawing.Point(382, 9);
            this.cmbKW_FromDepartment.Name = "cmbKW_FromDepartment";
            this.cmbKW_FromDepartment.Size = new System.Drawing.Size(150, 25);
            this.cmbKW_FromDepartment.TabIndex = 13;
            this.cmbKW_FromDepartment.ValueMember = "ID";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(549, 7);
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
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 44);
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(1020, 23);
            this.pnlFilt.TabIndex = 189;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(198)))), ((int)(((byte)(232)))));
            this.panel2.Controls.Add(this.lblSetup);
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 44);
            this.panel2.TabIndex = 188;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(10, 12);
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
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(70, 12);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(123, 19);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">  POSM Return";
            // 
            // rdoFromVen
            // 
            this.rdoFromVen.AutoSize = true;
            this.rdoFromVen.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.rdoFromVen.Location = new System.Drawing.Point(18, 57);
            this.rdoFromVen.Name = "rdoFromVen";
            this.rdoFromVen.Size = new System.Drawing.Size(95, 23);
            this.rdoFromVen.TabIndex = 197;
            this.rdoFromVen.Text = "အရောင်းကား";
            this.rdoFromVen.UseVisualStyleBackColor = true;
            this.rdoFromVen.CheckedChanged += new System.EventHandler(this.rdoFromVen_CheckedChanged);
            // 
            // frmPOSM_Return
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 449);
            this.Controls.Add(this.dgvReturnDetail);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlEntry);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPOSM_Return";
            this.Text = "POSM Return";
            this.Load += new System.EventHandler(this.frmPOSM_Return_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnDetail)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlEntry.ResumeLayout(false);
            this.pnlEntry.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReturnDetail;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlEntry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbToEmployee;
        private System.Windows.Forms.TextBox txtReturnNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpKW_Date;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbKW_FromDepartment;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFromEmployee;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoFromDept;
        private System.Windows.Forms.ComboBox cmbFromDeptOrVen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoToVen;
        private System.Windows.Forms.RadioButton rdoToDept;
        private System.Windows.Forms.ComboBox cmbToDeptOrVen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewComboBoxColumn colA_P_SubCategory;
        private System.Windows.Forms.DataGridViewComboBoxColumn colA_P_Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReturnQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewComboBoxColumn colReturnPurpose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAP_ReturnDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromDeptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromVenID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToDeptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReturnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReturnNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToVenID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAP_ReturnID;
        private System.Windows.Forms.RadioButton rdoFromVen;
    }
}