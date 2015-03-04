namespace PTIC.Marketing.MarketingPlan
{
    partial class frmDailyMarketingPlanCustomers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblMarketing = new System.Windows.Forms.Label();
            this.calendarColumn1 = new AGL.UI.Controls.CalendarColumn();
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
            this.colPlanDate = new AGL.UI.Controls.CalendarColumn();
            this.colTown = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.colInitialMarketingPlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 48);
            this.panel1.TabIndex = 133;
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
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomers.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlanDate,
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
            this.colInitialMarketingPlanID});
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCustomers.Location = new System.Drawing.Point(0, 41);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowHeadersWidth = 50;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvCustomers.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCustomers.RowTemplate.Height = 30;
            this.dgvCustomers.Size = new System.Drawing.Size(962, 300);
            this.dgvCustomers.TabIndex = 135;
            this.dgvCustomers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCustomers_DataBindingComplete);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(962, 41);
            this.panel2.TabIndex = 134;
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
            // calendarColumn1
            // 
            this.calendarColumn1.HeaderText = "Date";
            this.calendarColumn1.Name = "calendarColumn1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Township";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn1.HeaderText = "မြို့နယ်";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CusTypeName";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn2.HeaderText = "အမျိုးအစား";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn3.HeaderText = "Class";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CusName";
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn4.HeaderText = "အမည်";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "MarketingPlanID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "CusType";
            this.dataGridViewTextBoxColumn6.HeaderText = "CusTypeID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CusClassID";
            this.dataGridViewTextBoxColumn7.HeaderText = "CusClassID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TownID";
            this.dataGridViewTextBoxColumn8.HeaderText = "TownID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "CustomerID";
            this.dataGridViewTextBoxColumn9.HeaderText = "CustomerID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "InitialMarketingPlanID";
            this.dataGridViewTextBoxColumn10.HeaderText = "InitialMarketingPlanID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // colPlanDate
            // 
            this.colPlanDate.HeaderText = "Date";
            this.colPlanDate.Name = "colPlanDate";
            this.colPlanDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            dataGridViewCellStyle7.NullValue = false;
            this.colMarketorNot.DefaultCellStyle = dataGridViewCellStyle7;
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
            // colInitialMarketingPlanID
            // 
            this.colInitialMarketingPlanID.DataPropertyName = "InitialMarketingPlanID";
            this.colInitialMarketingPlanID.HeaderText = "InitialMarketingPlanID";
            this.colInitialMarketingPlanID.Name = "colInitialMarketingPlanID";
            this.colInitialMarketingPlanID.Visible = false;
            // 
            // frmDailyMarketingPlanCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 389);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDailyMarketingPlanCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DailyMarketingPlan Customers များရွေးချယ်ခြင်း";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblMarketing;
        private AGL.UI.Controls.CalendarColumn calendarColumn1;
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
        private AGL.UI.Controls.CalendarColumn colPlanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTown;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colInitialMarketingPlanID;
    }
}