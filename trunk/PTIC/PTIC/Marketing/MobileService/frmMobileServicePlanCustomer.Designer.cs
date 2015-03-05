namespace PTIC.Marketing.MobileService
{
    partial class frmMobileServicePlanCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMobileServiceCustomer = new System.Windows.Forms.DataGridView();
            this.colTown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarketorNot = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colMarketingPlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInitialMobileServicePlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MarketingLog = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblMarketing = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobileServiceCustomer)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMobileServiceCustomer
            // 
            this.dgvMobileServiceCustomer.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvMobileServiceCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMobileServiceCustomer.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMobileServiceCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMobileServiceCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMobileServiceCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTown,
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
            this.dgvMobileServiceCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMobileServiceCustomer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvMobileServiceCustomer.Location = new System.Drawing.Point(0, 41);
            this.dgvMobileServiceCustomer.MultiSelect = false;
            this.dgvMobileServiceCustomer.Name = "dgvMobileServiceCustomer";
            this.dgvMobileServiceCustomer.RowHeadersWidth = 50;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvMobileServiceCustomer.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMobileServiceCustomer.RowTemplate.Height = 30;
            this.dgvMobileServiceCustomer.Size = new System.Drawing.Size(968, 363);
            this.dgvMobileServiceCustomer.TabIndex = 133;
            this.dgvMobileServiceCustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlanCustomer_CellContentClick);
            this.dgvMobileServiceCustomer.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPlanCustomer_DataBindingComplete);
            // 
            // colTown
            // 
            this.colTown.DataPropertyName = "Town";
            this.colTown.HeaderText = "မြို့";
            this.colTown.Name = "colTown";
            // 
            // colTownship
            // 
            this.colTownship.DataPropertyName = "Township";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.colTownship.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTownship.HeaderText = "မြို့နယ်";
            this.colTownship.Name = "colTownship";
            this.colTownship.ReadOnly = true;
            this.colTownship.Width = 150;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "CusTypeName";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.colType.DefaultCellStyle = dataGridViewCellStyle4;
            this.colType.HeaderText = "အမျိုးအစား";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 150;
            // 
            // colClass
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.colClass.DefaultCellStyle = dataGridViewCellStyle5;
            this.colClass.HeaderText = "Class";
            this.colClass.Name = "colClass";
            this.colClass.ReadOnly = true;
            this.colClass.Width = 80;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "CusName";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.colName.DefaultCellStyle = dataGridViewCellStyle6;
            this.colName.HeaderText = "အမည်";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // colMarketorNot
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle7.NullValue = "ရွေးရန်";
            this.colMarketorNot.DefaultCellStyle = dataGridViewCellStyle7;
            this.colMarketorNot.HeaderText = "Plan";
            this.colMarketorNot.Name = "colMarketorNot";
            this.colMarketorNot.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMarketorNot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMarketorNot.Width = 180;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.MarketingLog);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 404);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 48);
            this.panel1.TabIndex = 134;
            // 
            // MarketingLog
            // 
            this.MarketingLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MarketingLog.Location = new System.Drawing.Point(12, 6);
            this.MarketingLog.Name = "MarketingLog";
            this.MarketingLog.Size = new System.Drawing.Size(142, 34);
            this.MarketingLog.TabIndex = 134;
            this.MarketingLog.Text = "Marketing Log >>";
            this.MarketingLog.UseVisualStyleBackColor = true;
            this.MarketingLog.Click += new System.EventHandler(this.MarketingLog_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.Location = new System.Drawing.Point(275, 6);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(95, 34);
            this.btnSelect.TabIndex = 133;
            this.btnSelect.Text = "ရွေးမည်";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(968, 41);
            this.panel2.TabIndex = 132;
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
            // 
            // frmMobileServicePlanCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 452);
            this.Controls.Add(this.dgvMobileServiceCustomer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMobileServicePlanCustomer";
            this.Text = "Mobile Service Plan Customer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobileServiceCustomer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMobileServiceCustomer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button MarketingLog;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownship;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewButtonColumn colMarketorNot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarketingPlanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInitialMobileServicePlanID;
    }
}