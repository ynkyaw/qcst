namespace PTIC.Marketing.MarketingPlan
{
    partial class frmConfirmMobileServicePlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblMarketing = new System.Windows.Forms.Label();
            this.dgvMobileServicePlan = new System.Windows.Forms.DataGridView();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPlanDate = new AGL.UI.Controls.CalendarColumn();
            this.colSvcNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownship = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colMobileServicePlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobileServicePlan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1070, 46);
            this.panel2.TabIndex = 143;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(89, 13);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(241, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">   Mobile Service Plan Confirmation";
            // 
            // lblMarketing
            // 
            this.lblMarketing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarketing.AutoSize = true;
            this.lblMarketing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMarketing.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketing.Location = new System.Drawing.Point(9, 13);
            this.lblMarketing.Name = "lblMarketing";
            this.lblMarketing.Size = new System.Drawing.Size(62, 20);
            this.lblMarketing.TabIndex = 0;
            this.lblMarketing.Text = "Planning";
            this.lblMarketing.Click += new System.EventHandler(this.lblMarketing_Click);
            // 
            // dgvMobileServicePlan
            // 
            this.dgvMobileServicePlan.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvMobileServicePlan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMobileServicePlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMobileServicePlan.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMobileServicePlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMobileServicePlan.ColumnHeadersHeight = 50;
            this.dgvMobileServicePlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMobileServicePlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colPlanDate,
            this.colSvcNo,
            this.colTownship,
            this.colMobileServicePlanID,
            this.colCusType,
            this.colCusName,
            this.colContactPerson,
            this.colPhone});
            this.dgvMobileServicePlan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvMobileServicePlan.Location = new System.Drawing.Point(7, 52);
            this.dgvMobileServicePlan.MultiSelect = false;
            this.dgvMobileServicePlan.Name = "dgvMobileServicePlan";
            this.dgvMobileServicePlan.RowHeadersWidth = 50;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvMobileServicePlan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMobileServicePlan.RowTemplate.Height = 28;
            this.dgvMobileServicePlan.Size = new System.Drawing.Size(1064, 547);
            this.dgvMobileServicePlan.TabIndex = 144;
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReject.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.Location = new System.Drawing.Point(120, 610);
            this.btnReject.Margin = new System.Windows.Forms.Padding(4);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(95, 34);
            this.btnReject.TabIndex = 150;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(7, 610);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(95, 34);
            this.btnConfirm.TabIndex = 149;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // colSelect
            // 
            this.colSelect.DataPropertyName = "IsConfirmed";
            this.colSelect.HeaderText = "Select";
            this.colSelect.Name = "colSelect";
            this.colSelect.Width = 50;
            // 
            // colPlanDate
            // 
            this.colPlanDate.DataPropertyName = "SvcPlanDate";
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.colPlanDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPlanDate.HeaderText = "သွားရမည့်နေ့";
            this.colPlanDate.Name = "colPlanDate";
            this.colPlanDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPlanDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colSvcNo
            // 
            this.colSvcNo.DataPropertyName = "SvcPlanNo";
            this.colSvcNo.HeaderText = "Service Plan No";
            this.colSvcNo.Name = "colSvcNo";
            this.colSvcNo.ReadOnly = true;
            // 
            // colTownship
            // 
            this.colTownship.DataPropertyName = "TownshipID";
            this.colTownship.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colTownship.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colTownship.HeaderText = "မြို့နယ်";
            this.colTownship.Name = "colTownship";
            this.colTownship.ReadOnly = true;
            this.colTownship.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTownship.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colTownship.Width = 130;
            // 
            // colMobileServicePlanID
            // 
            this.colMobileServicePlanID.DataPropertyName = "MobileServicePlanID";
            this.colMobileServicePlanID.HeaderText = "MobileServicePlanID";
            this.colMobileServicePlanID.Name = "colMobileServicePlanID";
            this.colMobileServicePlanID.Visible = false;
            // 
            // colCusType
            // 
            this.colCusType.DataPropertyName = "CusType";
            this.colCusType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colCusType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colCusType.HeaderText = "Customer အမျိုးအစား";
            this.colCusType.Name = "colCusType";
            this.colCusType.ReadOnly = true;
            this.colCusType.Width = 120;
            // 
            // colCusName
            // 
            this.colCusName.DataPropertyName = "CusName";
            this.colCusName.HeaderText = "Customer အမည်";
            this.colCusName.Name = "colCusName";
            this.colCusName.ReadOnly = true;
            this.colCusName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCusName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCusName.Width = 200;
            // 
            // colContactPerson
            // 
            this.colContactPerson.DataPropertyName = "ConPersonName";
            this.colContactPerson.HeaderText = "ဆက်သွယ်မည့်သူအမည်";
            this.colContactPerson.Name = "colContactPerson";
            this.colContactPerson.ReadOnly = true;
            this.colContactPerson.Width = 140;
            // 
            // colPhone
            // 
            this.colPhone.DataPropertyName = "MobilePhone";
            this.colPhone.HeaderText = "ဖုန်းနံပါတ်";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPhone.Width = 130;
            // 
            // frmConfirmMobileServicePlan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1078, 657);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.dgvMobileServicePlan);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Name = "frmConfirmMobileServicePlan";
            this.Text = "Mobile Service Plan Confirmation";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMobileServicePlan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.DataGridView dgvMobileServicePlan;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private AGL.UI.Controls.CalendarColumn colPlanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSvcNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn colTownship;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobileServicePlanID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCusType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
    }
}