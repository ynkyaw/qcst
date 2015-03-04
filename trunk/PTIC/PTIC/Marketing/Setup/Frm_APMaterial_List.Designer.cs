namespace PITC.VC.Marketing
{
    partial class Frm_APMaterial_List
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvAPMaterial = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAPCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APMaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubCatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAPCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblSetup = new System.Windows.Forms.LinkLabel();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.chkMaterial = new System.Windows.Forms.CheckBox();
            this.chkSubCat = new System.Windows.Forms.CheckBox();
            this.cmbAPSubCat = new System.Windows.Forms.ComboBox();
            this.cboMaterialName = new System.Windows.Forms.ComboBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAPMaterial)).BeginInit();
            this.panel4.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 414);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 49);
            this.panel1.TabIndex = 47;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(227, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 36);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(125, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 36);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "ပြင်မည်";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 36);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "အသစ်ထည့်မည်";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvAPMaterial
            // 
            this.dgvAPMaterial.AllowUserToAddRows = false;
            this.dgvAPMaterial.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAPMaterial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAPMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAPMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.colNo,
            this.colAPCategory,
            this.APCategory,
            this.APMaterialName,
            this.Size,
            this.Description,
            this.colSubCatID,
            this.colAPCategoryID});
            this.dgvAPMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAPMaterial.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAPMaterial.Location = new System.Drawing.Point(0, 0);
            this.dgvAPMaterial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvAPMaterial.Name = "dgvAPMaterial";
            this.dgvAPMaterial.ReadOnly = true;
            this.dgvAPMaterial.RowTemplate.Height = 28;
            this.dgvAPMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAPMaterial.Size = new System.Drawing.Size(1017, 276);
            this.dgvAPMaterial.TabIndex = 48;
            this.dgvAPMaterial.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvAPMaterial_CurrentCellDirtyStateChanged);
            this.dgvAPMaterial.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAPMaterial_DataBindingComplete);
            this.dgvAPMaterial.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvAPMaterial_RowPostPaint);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // colNo
            // 
            this.colNo.HeaderText = "စဉ်";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Width = 50;
            // 
            // colAPCategory
            // 
            this.colAPCategory.DataPropertyName = "APCategoryName";
            this.colAPCategory.HeaderText = "A & P အမျိုးအစား";
            this.colAPCategory.Name = "colAPCategory";
            this.colAPCategory.ReadOnly = true;
            // 
            // APCategory
            // 
            this.APCategory.DataPropertyName = "APSubCategoryName";
            this.APCategory.HeaderText = "A & P အမျိုးအစားခွဲ";
            this.APCategory.Name = "APCategory";
            this.APCategory.ReadOnly = true;
            this.APCategory.Width = 200;
            // 
            // APMaterialName
            // 
            this.APMaterialName.DataPropertyName = "APMaterialName";
            this.APMaterialName.HeaderText = "A & P အမည်";
            this.APMaterialName.Name = "APMaterialName";
            this.APMaterialName.ReadOnly = true;
            this.APMaterialName.Width = 200;
            // 
            // Size
            // 
            this.Size.DataPropertyName = "Size";
            this.Size.HeaderText = "အရွယ်အစား";
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            this.Size.Width = 200;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "မှတ်ချက်";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // colSubCatID
            // 
            this.colSubCatID.DataPropertyName = "APSubCategoryID";
            this.colSubCatID.HeaderText = "SubCategoryID";
            this.colSubCatID.Name = "colSubCatID";
            this.colSubCatID.ReadOnly = true;
            this.colSubCatID.Visible = false;
            // 
            // colAPCategoryID
            // 
            this.colAPCategoryID.DataPropertyName = "APCategoryID";
            this.colAPCategoryID.HeaderText = "APCategoryID";
            this.colAPCategoryID.Name = "colAPCategoryID";
            this.colAPCategoryID.ReadOnly = true;
            this.colAPCategoryID.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SkyBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblHeaderPCat);
            this.panel4.Controls.Add(this.lblSetup);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1017, 42);
            this.panel4.TabIndex = 49;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Zawgyi-One", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.Black;
            this.lblHeaderPCat.Location = new System.Drawing.Point(67, 10);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(67, 21);
            this.lblHeaderPCat.TabIndex = 48;
            this.lblHeaderPCat.Text = ">  A && P";
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Zawgyi-One", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetup.Location = new System.Drawing.Point(13, 10);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(48, 21);
            this.lblSetup.TabIndex = 47;
            this.lblSetup.TabStop = true;
            this.lblSetup.Text = "Setup";
            this.lblSetup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSetup_LinkClicked);
            // 
            // pnlFilt
            // 
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 42);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(1017, 35);
            this.pnlFilt.TabIndex = 51;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.Blue;
            this.lblFilter.Location = new System.Drawing.Point(7, 6);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(180, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▼ Show Filter Information";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.chkMaterial);
            this.pnlFilter.Controls.Add(this.chkSubCat);
            this.pnlFilter.Controls.Add(this.cmbAPSubCat);
            this.pnlFilter.Controls.Add(this.cboMaterialName);
            this.pnlFilter.Controls.Add(this.btnAll);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 77);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1017, 61);
            this.pnlFilter.TabIndex = 52;
            // 
            // chkMaterial
            // 
            this.chkMaterial.AutoSize = true;
            this.chkMaterial.Location = new System.Drawing.Point(388, 19);
            this.chkMaterial.Name = "chkMaterial";
            this.chkMaterial.Size = new System.Drawing.Size(108, 24);
            this.chkMaterial.TabIndex = 7;
            this.chkMaterial.Text = "A && P အမည်";
            this.chkMaterial.UseVisualStyleBackColor = true;
            // 
            // chkSubCat
            // 
            this.chkSubCat.AutoSize = true;
            this.chkSubCat.Location = new System.Drawing.Point(14, 17);
            this.chkSubCat.Name = "chkSubCat";
            this.chkSubCat.Size = new System.Drawing.Size(147, 24);
            this.chkSubCat.TabIndex = 2;
            this.chkSubCat.Text = "A && P အမျိုးအစားခွဲ";
            this.chkSubCat.UseVisualStyleBackColor = true;
            // 
            // cmbAPSubCat
            // 
            this.cmbAPSubCat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAPSubCat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAPSubCat.DisplayMember = "ID";
            this.cmbAPSubCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAPSubCat.FormattingEnabled = true;
            this.cmbAPSubCat.Location = new System.Drawing.Point(167, 16);
            this.cmbAPSubCat.Name = "cmbAPSubCat";
            this.cmbAPSubCat.Size = new System.Drawing.Size(150, 27);
            this.cmbAPSubCat.TabIndex = 6;
            this.cmbAPSubCat.ValueMember = "ID";
            // 
            // cboMaterialName
            // 
            this.cboMaterialName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMaterialName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMaterialName.DisplayMember = "APMaterialName";
            this.cboMaterialName.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaterialName.FormattingEnabled = true;
            this.cboMaterialName.Location = new System.Drawing.Point(502, 17);
            this.cboMaterialName.Name = "cboMaterialName";
            this.cboMaterialName.Size = new System.Drawing.Size(150, 27);
            this.cboMaterialName.TabIndex = 4;
            this.cboMaterialName.ValueMember = "ID";
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(773, 16);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(111, 29);
            this.btnAll.TabIndex = 3;
            this.btnAll.Text = "အကုန်ကြည့်မည်";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(662, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 29);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvAPMaterial);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1017, 276);
            this.panel2.TabIndex = 53;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "A&P အမျိုးအစား";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "A&P Material အမည်";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "အရွယ်အစား";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "မှတ်ချက်";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "SubCategoryID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // Frm_APMaterial_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1017, 463);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "Frm_APMaterial_List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "A & P";
            this.Load += new System.EventHandler(this.Frm_APMaterial_List_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAPMaterial)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvAPMaterial;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.LinkLabel lblSetup;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ComboBox cboMaterialName;
        private System.Windows.Forms.ComboBox cmbAPSubCat;
        private System.Windows.Forms.CheckBox chkMaterial;
        private System.Windows.Forms.CheckBox chkSubCat;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAPCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn APCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn APMaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubCatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAPCategoryID;
    }
}