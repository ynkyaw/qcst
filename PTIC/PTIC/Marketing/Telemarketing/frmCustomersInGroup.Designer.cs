namespace PTIC.Marketing.Telemarketing
{
    partial class frmCustomersInGroup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvGroupCustomer = new System.Windows.Forms.DataGridView();
            this.colCustomerType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblMarketing = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomersInGroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStreet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuartar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStateDivision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupCustomer)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvGroupCustomer
            // 
            this.dgvGroupCustomer.AllowUserToAddRows = false;
            this.dgvGroupCustomer.AllowUserToDeleteRows = false;
            this.dgvGroupCustomer.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvGroupCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGroupCustomer.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGroupCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvGroupCustomer.ColumnHeadersHeight = 50;
            this.dgvGroupCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGroupCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomerType,
            this.colCustomerName,
            this.colPhone,
            this.colAddress,
            this.colCustomerID,
            this.colCustomersInGroupID,
            this.colHno,
            this.colStreet,
            this.colQuartar,
            this.colTown,
            this.colTownship,
            this.colCountry,
            this.colStateDivision,
            this.colPhone1,
            this.colPhone2});
            this.dgvGroupCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroupCustomer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvGroupCustomer.Location = new System.Drawing.Point(0, 93);
            this.dgvGroupCustomer.MultiSelect = false;
            this.dgvGroupCustomer.Name = "dgvGroupCustomer";
            this.dgvGroupCustomer.RowHeadersWidth = 50;
            this.dgvGroupCustomer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvGroupCustomer.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvGroupCustomer.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvGroupCustomer.RowTemplate.Height = 28;
            this.dgvGroupCustomer.ShowCellToolTips = false;
            this.dgvGroupCustomer.Size = new System.Drawing.Size(1215, 317);
            this.dgvGroupCustomer.TabIndex = 196;
            this.dgvGroupCustomer.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvGroupCustomer_CellBeginEdit);
            this.dgvGroupCustomer.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroupCustomer_CellEndEdit);
            this.dgvGroupCustomer.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvGroupCustomer_CellValidating);
            this.dgvGroupCustomer.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroupCustomer_CellValueChanged);
            this.dgvGroupCustomer.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvGroupCustomer_CurrentCellDirtyStateChanged);
            this.dgvGroupCustomer.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvGroupCustomer_DataBindingComplete);
            this.dgvGroupCustomer.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvGroupCustomer_DataError);
            this.dgvGroupCustomer.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvGroupCustomer_EditingControlShowing);
            // 
            // colCustomerType
            // 
            this.colCustomerType.DataPropertyName = "CusType";
            this.colCustomerType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colCustomerType.HeaderText = "Customer အမျိုးအစား";
            this.colCustomerType.Name = "colCustomerType";
            this.colCustomerType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCustomerType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCustomerType.Width = 160;
            // 
            // colCustomerName
            // 
            this.colCustomerName.DataPropertyName = "CustomerID";
            this.colCustomerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colCustomerName.HeaderText = "Customer အမည်";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCustomerName.Width = 270;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.txtGroupName);
            this.pnlGrid.Controls.Add(this.label1);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrid.Location = new System.Drawing.Point(0, 41);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1215, 52);
            this.pnlGrid.TabIndex = 194;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Enabled = false;
            this.txtGroupName.Location = new System.Drawing.Point(75, 13);
            this.txtGroupName.Multiline = true;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(142, 27);
            this.txtGroupName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group :";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(238, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 124;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(127, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 133;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(16, 7);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 34);
            this.btnNew.TabIndex = 132;
            this.btnNew.Text = "ထည့်မည်";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Controls.Add(this.btnNew);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 410);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1215, 46);
            this.panel4.TabIndex = 195;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1215, 41);
            this.panel2.TabIndex = 193;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(76, 10);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(152, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">   Customer Group";
            // 
            // lblMarketing
            // 
            this.lblMarketing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarketing.AutoSize = true;
            this.lblMarketing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMarketing.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblMarketing.Location = new System.Drawing.Point(8, 10);
            this.lblMarketing.Name = "lblMarketing";
            this.lblMarketing.Size = new System.Drawing.Size(54, 20);
            this.lblMarketing.TabIndex = 0;
            this.lblMarketing.Text = "Group";
            this.lblMarketing.Click += new System.EventHandler(this.lblMarketing_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Phone";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Address";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "CustomerID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CustomersInGroupID";
            this.dataGridViewTextBoxColumn4.HeaderText = "CustomersInGroupID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Hno";
            this.dataGridViewTextBoxColumn5.HeaderText = "Hno";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Street";
            this.dataGridViewTextBoxColumn6.HeaderText = "Street";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Quartar";
            this.dataGridViewTextBoxColumn7.HeaderText = "Quartar";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Town";
            this.dataGridViewTextBoxColumn8.HeaderText = "Town";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Township";
            this.dataGridViewTextBoxColumn9.HeaderText = "Township";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Country";
            this.dataGridViewTextBoxColumn10.HeaderText = "Country";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "StateDivisionName";
            this.dataGridViewTextBoxColumn11.HeaderText = "StateDivision";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Phone1";
            this.dataGridViewTextBoxColumn12.HeaderText = "Phone1";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Phone2";
            this.dataGridViewTextBoxColumn13.HeaderText = "Phone2";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // colPhone
            // 
            this.colPhone.HeaderText = "Phone";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Width = 250;
            // 
            // colAddress
            // 
            this.colAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAddress.HeaderText = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            // 
            // colCustomerID
            // 
            this.colCustomerID.HeaderText = "CustomerID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.Visible = false;
            // 
            // colCustomersInGroupID
            // 
            this.colCustomersInGroupID.DataPropertyName = "CustomersInGroupID";
            this.colCustomersInGroupID.HeaderText = "CustomersInGroupID";
            this.colCustomersInGroupID.Name = "colCustomersInGroupID";
            this.colCustomersInGroupID.Visible = false;
            // 
            // colHno
            // 
            this.colHno.DataPropertyName = "Hno";
            this.colHno.HeaderText = "Hno";
            this.colHno.Name = "colHno";
            this.colHno.Visible = false;
            // 
            // colStreet
            // 
            this.colStreet.DataPropertyName = "Street";
            this.colStreet.HeaderText = "Street";
            this.colStreet.Name = "colStreet";
            this.colStreet.Visible = false;
            // 
            // colQuartar
            // 
            this.colQuartar.DataPropertyName = "Quartar";
            this.colQuartar.HeaderText = "Quartar";
            this.colQuartar.Name = "colQuartar";
            this.colQuartar.Visible = false;
            // 
            // colTown
            // 
            this.colTown.DataPropertyName = "Town";
            this.colTown.HeaderText = "Town";
            this.colTown.Name = "colTown";
            this.colTown.Visible = false;
            // 
            // colTownship
            // 
            this.colTownship.DataPropertyName = "Township";
            this.colTownship.HeaderText = "Township";
            this.colTownship.Name = "colTownship";
            this.colTownship.Visible = false;
            // 
            // colCountry
            // 
            this.colCountry.DataPropertyName = "Country";
            this.colCountry.HeaderText = "Country";
            this.colCountry.Name = "colCountry";
            this.colCountry.Visible = false;
            // 
            // colStateDivision
            // 
            this.colStateDivision.DataPropertyName = "StateDivisionName";
            this.colStateDivision.HeaderText = "StateDivision";
            this.colStateDivision.Name = "colStateDivision";
            this.colStateDivision.Visible = false;
            // 
            // colPhone1
            // 
            this.colPhone1.DataPropertyName = "Phone1";
            this.colPhone1.HeaderText = "Phone1";
            this.colPhone1.Name = "colPhone1";
            this.colPhone1.Visible = false;
            // 
            // colPhone2
            // 
            this.colPhone2.DataPropertyName = "Phone2";
            this.colPhone2.HeaderText = "Phone2";
            this.colPhone2.Name = "colPhone2";
            this.colPhone2.Visible = false;
            // 
            // frmCustomersInGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 456);
            this.Controls.Add(this.dgvGroupCustomer);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCustomersInGroup";
            this.Text = "Customers Group";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupCustomer)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGroupCustomer;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCustomerType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomersInGroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStreet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuartar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownship;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStateDivision;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
    }
}