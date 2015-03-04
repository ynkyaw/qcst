namespace PTIC.Marketing.Complaint
{
    partial class frmProductsPicker
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvProductSelection = new System.Windows.Forms.DataGridView();
            this.colBrand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colProductAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCause = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colComplaintReceivedFormID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductInComplaintReceiveID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SkyBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblHeaderPCat);
            this.panel3.Controls.Add(this.lblHeader);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1325, 44);
            this.panel3.TabIndex = 70;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(235, 12);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(150, 19);
            this.lblHeaderPCat.TabIndex = 48;
            this.lblHeaderPCat.Text = ">   Product Selection";
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.AutoSize = true;
            this.lblHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHeader.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(17, 12);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(212, 19);
            this.lblHeader.TabIndex = 47;
            this.lblHeader.Text = "Customer Complaint Received";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 252);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1325, 47);
            this.panel1.TabIndex = 71;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(224, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 34);
            this.btnDelete.TabIndex = 129;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 34);
            this.btnAdd.TabIndex = 128;
            this.btnAdd.Text = "ထည့်မည်";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(118, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 34);
            this.btnSave.TabIndex = 127;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvProductSelection);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1325, 208);
            this.panel2.TabIndex = 72;
            // 
            // dgvProductSelection
            // 
            this.dgvProductSelection.AllowUserToAddRows = false;
            this.dgvProductSelection.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductSelection.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductSelection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBrand,
            this.colProduct,
            this.colProductAmt,
            this.colProductionDate,
            this.colCause,
            this.colComplaintReceivedFormID,
            this.colProductInComplaintReceiveID});
            this.dgvProductSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductSelection.Location = new System.Drawing.Point(0, 0);
            this.dgvProductSelection.MultiSelect = false;
            this.dgvProductSelection.Name = "dgvProductSelection";
            this.dgvProductSelection.RowHeadersWidth = 50;
            this.dgvProductSelection.RowTemplate.Height = 28;
            this.dgvProductSelection.Size = new System.Drawing.Size(1325, 208);
            this.dgvProductSelection.TabIndex = 19;
            this.dgvProductSelection.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvProductSelection_CellBeginEdit);
            this.dgvProductSelection.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductSelection_CellEndEdit);
            this.dgvProductSelection.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvProductSelection_CellValidating);
            this.dgvProductSelection.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvProductSelection_CurrentCellDirtyStateChanged);
            this.dgvProductSelection.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvProductSelection_DataBindingComplete);
            this.dgvProductSelection.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvProductSelection_DataError);
            this.dgvProductSelection.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvProductSelection_EditingControlShowing);
            this.dgvProductSelection.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProductSelection_RowHeaderMouseDoubleClick);
            // 
            // colBrand
            // 
            this.colBrand.DataPropertyName = "BrandID";
            this.colBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colBrand.HeaderText = "အမှတ်တံဆိပ်";
            this.colBrand.Name = "colBrand";
            this.colBrand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBrand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBrand.Width = 120;
            // 
            // colProduct
            // 
            this.colProduct.DataPropertyName = "ProductID";
            this.colProduct.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colProduct.HeaderText = "ထုတ်ကုန်အမည်";
            this.colProduct.Name = "colProduct";
            this.colProduct.Width = 250;
            // 
            // colProductAmt
            // 
            this.colProductAmt.DataPropertyName = "Qty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colProductAmt.DefaultCellStyle = dataGridViewCellStyle2;
            this.colProductAmt.HeaderText = "အရေအတွက်";
            this.colProductAmt.MaxInputLength = 5;
            this.colProductAmt.Name = "colProductAmt";
            this.colProductAmt.Width = 120;
            // 
            // colProductionDate
            // 
            this.colProductionDate.DataPropertyName = "ProductionDate";
            this.colProductionDate.HeaderText = "ထုတ်လုပ်သည့်နေ့";
            this.colProductionDate.Name = "colProductionDate";
            this.colProductionDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colProductionDate.Width = 130;
            // 
            // colCause
            // 
            this.colCause.DataPropertyName = "ComplaintCaseID";
            this.colCause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colCause.HeaderText = "ဖြစ်ပေါ်လာသည့်အကြောင်းအရာ";
            this.colCause.Name = "colCause";
            this.colCause.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCause.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCause.Width = 650;
            // 
            // colComplaintReceivedFormID
            // 
            this.colComplaintReceivedFormID.DataPropertyName = "ComplaintReceiveID";
            this.colComplaintReceivedFormID.HeaderText = "ComplaintReceiveID";
            this.colComplaintReceivedFormID.Name = "colComplaintReceivedFormID";
            this.colComplaintReceivedFormID.Visible = false;
            // 
            // colProductInComplaintReceiveID
            // 
            this.colProductInComplaintReceiveID.HeaderText = "ProductInComplaintReceiveID";
            this.colProductInComplaintReceiveID.Name = "colProductInComplaintReceiveID";
            this.colProductInComplaintReceiveID.Visible = false;
            // 
            // frmProductsPicker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1325, 299);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Name = "frmProductsPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Selection";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSelection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvProductSelection;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewComboBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewComboBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductionDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCause;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComplaintReceivedFormID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductInComplaintReceiveID;
    }
}