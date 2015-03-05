namespace PTIC.Marketing.MobileService
{
    partial class frmMobileServicePlanCustomers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.colPlanDate = new AGL.UI.Controls.CalendarColumn();
            this.colTownship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarketorNot = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMarketingPlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInitialMobileServicePlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblMarketing = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCustomers.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlanDate,
            this.colTownship,
            this.colType,
            this.colClass,
            this.colName,
            this.colMarketorNot,
            this.colMarketingPlanID,
            this.colCusTypeID,
            this.colCusClassID,
            this.colTownID,
            this.colCustomerID,
            this.colInitialMobileServicePlanID});
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCustomers.Location = new System.Drawing.Point(0, 41);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowHeadersWidth = 50;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvCustomers.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvCustomers.RowTemplate.Height = 30;
            this.dgvCustomers.Size = new System.Drawing.Size(932, 294);
            this.dgvCustomers.TabIndex = 138;
            this.dgvCustomers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCustomers_DataBindingComplete);
            // 
            // colPlanDate
            // 
            this.colPlanDate.HeaderText = "Date";
            this.colPlanDate.Name = "colPlanDate";
            this.colPlanDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colTownship
            // 
            this.colTownship.DataPropertyName = "Township";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.colTownship.DefaultCellStyle = dataGridViewCellStyle11;
            this.colTownship.HeaderText = "မြို့နယ်";
            this.colTownship.Name = "colTownship";
            this.colTownship.ReadOnly = true;
            this.colTownship.Width = 150;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "CusTypeName";
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.colType.DefaultCellStyle = dataGridViewCellStyle12;
            this.colType.HeaderText = "အမျိုးအစား";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 150;
            // 
            // colClass
            // 
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.colClass.DefaultCellStyle = dataGridViewCellStyle13;
            this.colClass.HeaderText = "Class";
            this.colClass.Name = "colClass";
            this.colClass.ReadOnly = true;
            this.colClass.Width = 80;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "CusName";
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.colName.DefaultCellStyle = dataGridViewCellStyle14;
            this.colName.HeaderText = "အမည်";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // colMarketorNot
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle15.NullValue = false;
            this.colMarketorNot.DefaultCellStyle = dataGridViewCellStyle15;
            this.colMarketorNot.HeaderText = "Plan or Not";
            this.colMarketorNot.Name = "colMarketorNot";
            this.colMarketorNot.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMarketorNot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMarketorNot.Width = 130;
            // 
            // colMarketingPlanID
            // 
            this.colMarketingPlanID.HeaderText = "MarketingPlanID";
            this.colMarketingPlanID.Name = "colMarketingPlanID";
            this.colMarketingPlanID.Visible = false;
            this.colMarketingPlanID.Width = 150;
            // 
            // colCusTypeID
            // 
            this.colCusTypeID.DataPropertyName = "CusType";
            this.colCusTypeID.HeaderText = "CusTypeID";
            this.colCusTypeID.Name = "colCusTypeID";
            this.colCusTypeID.Visible = false;
            // 
            // colCusClassID
            // 
            this.colCusClassID.DataPropertyName = "CusClassID";
            this.colCusClassID.HeaderText = "CusClassID";
            this.colCusClassID.Name = "colCusClassID";
            this.colCusClassID.Visible = false;
            // 
            // colTownID
            // 
            this.colTownID.DataPropertyName = "TownID";
            this.colTownID.HeaderText = "TownID";
            this.colTownID.Name = "colTownID";
            this.colTownID.Visible = false;
            // 
            // colCustomerID
            // 
            this.colCustomerID.DataPropertyName = "CustomerID";
            this.colCustomerID.HeaderText = "CustomerID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.Visible = false;
            // 
            // colInitialMobileServicePlanID
            // 
            this.colInitialMobileServicePlanID.DataPropertyName = "InitialMobileServicePlanID";
            this.colInitialMobileServicePlanID.HeaderText = "InitialMobileServicePlanID";
            this.colInitialMobileServicePlanID.Name = "colInitialMobileServicePlanID";
            this.colInitialMobileServicePlanID.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(932, 41);
            this.panel2.TabIndex = 137;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(76, 9);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(250, 19);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">   သွားရမည့် Customers ရွေးချယ်ခြင်း";
            // 
            // lblMarketing
            // 
            this.lblMarketing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarketing.AutoSize = true;
            this.lblMarketing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMarketing.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketing.Location = new System.Drawing.Point(8, 9);
            this.lblMarketing.Name = "lblMarketing";
            this.lblMarketing.Size = new System.Drawing.Size(62, 20);
            this.lblMarketing.TabIndex = 0;
            this.lblMarketing.Text = "Planning";
            this.lblMarketing.Click += new System.EventHandler(this.lblMarketing_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 48);
            this.panel1.TabIndex = 136;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.Location = new System.Drawing.Point(337, 6);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(95, 34);
            this.btnSelect.TabIndex = 133;
            this.btnSelect.Text = "ရွေးမည်";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // frmMobileServicePlanCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 383);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMobileServicePlanCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mobile Service Plan Customers";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSelect;
        private AGL.UI.Controls.CalendarColumn colPlanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownship;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMarketorNot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarketingPlanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInitialMobileServicePlanID;
    }
}