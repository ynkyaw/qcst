namespace PTIC.VC.Marketing.Setup
{
    partial class frmSupplier
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvsetupSupplier = new System.Windows.Forms.DataGridView();
            this.clnSupplierTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clnSupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnContactPh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPh1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPh2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.chkSupplier = new System.Windows.Forms.CheckBox();
            this.chkSupplierCat = new System.Windows.Forms.CheckBox();
            this.cmbSupplierCat = new System.Windows.Forms.ComboBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblSetup = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetupSupplier)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pnlFilter);
            this.panel1.Controls.Add(this.pnlFilt);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 602);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvsetupSupplier);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 137);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(939, 416);
            this.panel4.TabIndex = 84;
            // 
            // dgvsetupSupplier
            // 
            this.dgvsetupSupplier.AllowUserToAddRows = false;
            this.dgvsetupSupplier.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvsetupSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvsetupSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsetupSupplier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnSupplierTypeID,
            this.clnSupplierName,
            this.clnContactPerson,
            this.clnContactPh,
            this.clnPh1,
            this.clnPh2,
            this.clnAddress,
            this.clnID,
            this.clnNo});
            this.dgvsetupSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvsetupSupplier.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvsetupSupplier.Location = new System.Drawing.Point(0, 0);
            this.dgvsetupSupplier.Name = "dgvsetupSupplier";
            this.dgvsetupSupplier.RowHeadersWidth = 80;
            this.dgvsetupSupplier.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvsetupSupplier.RowTemplate.Height = 28;
            this.dgvsetupSupplier.Size = new System.Drawing.Size(939, 416);
            this.dgvsetupSupplier.TabIndex = 80;
            this.dgvsetupSupplier.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvsetupSupplier_CellValidating);
            this.dgvsetupSupplier.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvsetupSupplier_DataBindingComplete);
            this.dgvsetupSupplier.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvsetupSupplier_DataError);
            this.dgvsetupSupplier.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvsetupSupplier_RowHeaderMouseDoubleClick);
            this.dgvsetupSupplier.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvsetupSupplier_RowPostPaint);
            // 
            // clnSupplierTypeID
            // 
            this.clnSupplierTypeID.DataPropertyName = "SupTypeID";
            this.clnSupplierTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clnSupplierTypeID.HeaderText = "Supplier အမျိုးအစား";
            this.clnSupplierTypeID.Name = "clnSupplierTypeID";
            this.clnSupplierTypeID.Width = 140;
            // 
            // clnSupplierName
            // 
            this.clnSupplierName.DataPropertyName = "SupplierName";
            this.clnSupplierName.HeaderText = "Supplier အမည်";
            this.clnSupplierName.Name = "clnSupplierName";
            // 
            // clnContactPerson
            // 
            this.clnContactPerson.DataPropertyName = "ContactPerson";
            this.clnContactPerson.HeaderText = "ဆက်သွယ်ရမည်သူအမည်";
            this.clnContactPerson.Name = "clnContactPerson";
            this.clnContactPerson.Width = 150;
            // 
            // clnContactPh
            // 
            this.clnContactPh.DataPropertyName = "ContactPhone";
            this.clnContactPh.HeaderText = "ဆက်သွယ်ရမည့်ဖုန်း";
            this.clnContactPh.Name = "clnContactPh";
            this.clnContactPh.Width = 120;
            // 
            // clnPh1
            // 
            this.clnPh1.DataPropertyName = "Phone1";
            this.clnPh1.HeaderText = "ဖုန်းနံပါတ် (၁)";
            this.clnPh1.Name = "clnPh1";
            this.clnPh1.Width = 115;
            // 
            // clnPh2
            // 
            this.clnPh2.DataPropertyName = "Phone2";
            this.clnPh2.HeaderText = "ဖုန်းနံပါတ် (၂)";
            this.clnPh2.Name = "clnPh2";
            this.clnPh2.Width = 120;
            // 
            // clnAddress
            // 
            this.clnAddress.DataPropertyName = "Address";
            this.clnAddress.HeaderText = "လိပ်စာ";
            this.clnAddress.Name = "clnAddress";
            this.clnAddress.Width = 110;
            // 
            // clnID
            // 
            this.clnID.DataPropertyName = "SupplierID";
            this.clnID.HeaderText = "clnID";
            this.clnID.Name = "clnID";
            this.clnID.Visible = false;
            // 
            // clnNo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clnNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.clnNo.HeaderText = "စဉ်";
            this.clnNo.Name = "clnNo";
            this.clnNo.ReadOnly = true;
            this.clnNo.Visible = false;
            this.clnNo.Width = 50;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 553);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(939, 49);
            this.panel3.TabIndex = 83;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(12, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 34);
            this.btnAdd.TabIndex = 79;
            this.btnAdd.Text = "ထည့်မည်";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(234, 7);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 78;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(123, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 75;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.chkSupplier);
            this.pnlFilter.Controls.Add(this.chkSupplierCat);
            this.pnlFilter.Controls.Add(this.cmbSupplierCat);
            this.pnlFilter.Controls.Add(this.cmbSupplier);
            this.pnlFilter.Controls.Add(this.btnAll);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 76);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(939, 61);
            this.pnlFilter.TabIndex = 82;
            // 
            // chkSupplier
            // 
            this.chkSupplier.AutoSize = true;
            this.chkSupplier.Location = new System.Drawing.Point(349, 18);
            this.chkSupplier.Name = "chkSupplier";
            this.chkSupplier.Size = new System.Drawing.Size(121, 24);
            this.chkSupplier.TabIndex = 7;
            this.chkSupplier.Text = "Supplier အမည်";
            this.chkSupplier.UseVisualStyleBackColor = true;
            // 
            // chkSupplierCat
            // 
            this.chkSupplierCat.AutoSize = true;
            this.chkSupplierCat.Location = new System.Drawing.Point(33, 18);
            this.chkSupplierCat.Name = "chkSupplierCat";
            this.chkSupplierCat.Size = new System.Drawing.Size(151, 24);
            this.chkSupplierCat.TabIndex = 2;
            this.chkSupplierCat.Text = "Supplier အမျိုးအစား";
            this.chkSupplierCat.UseVisualStyleBackColor = true;
            // 
            // cmbSupplierCat
            // 
            this.cmbSupplierCat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSupplierCat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSupplierCat.DisplayMember = "SupplierType";
            this.cmbSupplierCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplierCat.FormattingEnabled = true;
            this.cmbSupplierCat.Location = new System.Drawing.Point(184, 16);
            this.cmbSupplierCat.Name = "cmbSupplierCat";
            this.cmbSupplierCat.Size = new System.Drawing.Size(150, 27);
            this.cmbSupplierCat.TabIndex = 6;
            this.cmbSupplierCat.ValueMember = "SupplierTypeID";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSupplier.DisplayMember = "SupplierName";
            this.cmbSupplier.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(475, 16);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(150, 27);
            this.cmbSupplier.TabIndex = 8;
            this.cmbSupplier.ValueMember = "SupplierID";
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(746, 16);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(111, 29);
            this.btnAll.TabIndex = 10;
            this.btnAll.Text = "အကုန်ကြည့်မည်";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(635, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 29);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlFilt
            // 
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 41);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(939, 35);
            this.pnlFilt.TabIndex = 81;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.Blue;
            this.lblFilter.Location = new System.Drawing.Point(7, 6);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(176, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▼ Show Filter Information";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblSetup);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(939, 41);
            this.panel2.TabIndex = 79;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(61, 9);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(85, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = "> Supplier";
            // 
            // lblSetup
            // 
            this.lblSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetup.Location = new System.Drawing.Point(8, 9);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(50, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Setup";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // frmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 602);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetupSupplier)).EndInit();
            this.panel3.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.DataGridView dgvsetupSupplier;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.CheckBox chkSupplier;
        private System.Windows.Forms.CheckBox chkSupplierCat;
        private System.Windows.Forms.ComboBox cmbSupplierCat;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnSupplierTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnContactPh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPh1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPh2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNo;
        private System.Windows.Forms.Button btnAdd;
    }
}