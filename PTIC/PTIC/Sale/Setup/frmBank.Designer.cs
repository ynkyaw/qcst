namespace PTIC.Sale.Setup
{
    partial class frmBank
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.dgvsetupBank = new System.Windows.Forms.DataGridView();
            this.BankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTown = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BankAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBankID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetupBank)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(923, 41);
            this.panel1.TabIndex = 6;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(8, 10);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(44, 17);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Setup";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(61, 10);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(61, 17);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">    ဘဏ်";
            // 
            // dgvsetupBank
            // 
            this.dgvsetupBank.AllowUserToAddRows = false;
            this.dgvsetupBank.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvsetupBank.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvsetupBank.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvsetupBank.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvsetupBank.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvsetupBank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsetupBank.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BankName,
            this.clnTown,
            this.BankAddress,
            this.Phone,
            this.clnBankID});
            this.dgvsetupBank.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvsetupBank.Location = new System.Drawing.Point(12, 64);
            this.dgvsetupBank.MultiSelect = false;
            this.dgvsetupBank.Name = "dgvsetupBank";
            this.dgvsetupBank.RowHeadersWidth = 50;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetupBank.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvsetupBank.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetupBank.RowTemplate.Height = 30;
            this.dgvsetupBank.ShowCellToolTips = false;
            this.dgvsetupBank.Size = new System.Drawing.Size(899, 462);
            this.dgvsetupBank.TabIndex = 51;
            this.dgvsetupBank.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvsetupBank_CellEndEdit);
            this.dgvsetupBank.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvsetupBank_CurrentCellDirtyStateChanged);
            this.dgvsetupBank.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvsetupBank_DataBindingComplete);
            this.dgvsetupBank.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvsetupBank_DataError);
            this.dgvsetupBank.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvsetupBank_EditingControlShowing);
            this.dgvsetupBank.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvsetupBank_RowHeaderMouseDoubleClick);
            // 
            // BankName
            // 
            this.BankName.DataPropertyName = "Bank";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.BankName.DefaultCellStyle = dataGridViewCellStyle3;
            this.BankName.HeaderText = "ဘဏ်အမည်";
            this.BankName.Name = "BankName";
            this.BankName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BankName.Width = 120;
            // 
            // clnTown
            // 
            this.clnTown.DataPropertyName = "TownID";
            this.clnTown.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.clnTown.HeaderText = "မြို့";
            this.clnTown.Name = "clnTown";
            this.clnTown.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // BankAddress
            // 
            this.BankAddress.DataPropertyName = "BankAddress";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BankAddress.DefaultCellStyle = dataGridViewCellStyle4;
            this.BankAddress.HeaderText = "လိပ်စာ";
            this.BankAddress.Name = "BankAddress";
            this.BankAddress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BankAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BankAddress.Width = 270;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            dataGridViewCellStyle5.Format = "00-000000000";
            dataGridViewCellStyle5.NullValue = null;
            this.Phone.DefaultCellStyle = dataGridViewCellStyle5;
            this.Phone.HeaderText = "ဖုန်းနံပါတ်";
            this.Phone.Name = "Phone";
            this.Phone.Width = 200;
            // 
            // clnBankID
            // 
            this.clnBankID.DataPropertyName = "BankID";
            this.clnBankID.HeaderText = "BankID";
            this.clnBankID.Name = "clnBankID";
            this.clnBankID.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(250, 542);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 55;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(131, 542);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 54;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BankID";
            this.dataGridViewTextBoxColumn1.HeaderText = global::PTIC.Resource.errSelectRowToEdit;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.HeaderText = "စဉ်";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Bank";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.HeaderText = "ဘဏ်အမည်";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "BankAddress";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn4.HeaderText = "လိပ်စာ";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Phone";
            this.dataGridViewTextBoxColumn5.HeaderText = "ဖုန်းနံပါတ်";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Remark";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn6.HeaderText = "မှတ်ချက်";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(12, 542);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 34);
            this.btnNew.TabIndex = 56;
            this.btnNew.Text = "ထည့်မည်";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmBank
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(923, 590);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvsetupBank);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBank";
            this.Text = "ဘဏ်";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetupBank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.DataGridView dgvsetupBank;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankName;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnTown;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBankID;
    }
}