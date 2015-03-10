namespace PTIC.Marketing.MarketingPlan.Company_Plan
{
    partial class frmConfirmCompanyPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblMarketing = new System.Windows.Forms.Label();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.dgvCompanyPlan = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTargetedDate = new AGL.UI.Controls.CalendarColumn();
            this.dgvColTownship = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCompanyPlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Location = new System.Drawing.Point(4, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1070, 46);
            this.panel2.TabIndex = 151;
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
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReject.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.Location = new System.Drawing.Point(123, 616);
            this.btnReject.Margin = new System.Windows.Forms.Padding(4);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(95, 34);
            this.btnReject.TabIndex = 154;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(10, 616);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(95, 34);
            this.btnConfirm.TabIndex = 153;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // dgvCompanyPlan
            // 
            this.dgvCompanyPlan.AllowUserToAddRows = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvCompanyPlan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCompanyPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCompanyPlan.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompanyPlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCompanyPlan.ColumnHeadersHeight = 50;
            this.dgvCompanyPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCompanyPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colTargetedDate,
            this.dgvColTownship,
            this.colCompanyPlanID,
            this.colCusName,
            this.colContactPerson,
            this.colPhone});
            this.dgvCompanyPlan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCompanyPlan.Location = new System.Drawing.Point(-8, 62);
            this.dgvCompanyPlan.MultiSelect = false;
            this.dgvCompanyPlan.Name = "dgvCompanyPlan";
            this.dgvCompanyPlan.RowHeadersWidth = 50;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvCompanyPlan.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCompanyPlan.RowTemplate.Height = 28;
            this.dgvCompanyPlan.Size = new System.Drawing.Size(1064, 547);
            this.dgvCompanyPlan.TabIndex = 152;
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "Select";
            this.colSelect.Name = "colSelect";
            // 
            // colTargetedDate
            // 
            this.colTargetedDate.DataPropertyName = "TargetedDate";
            dataGridViewCellStyle7.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle7.NullValue = null;
            this.colTargetedDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.colTargetedDate.HeaderText = "သွားရမည့်နေ့";
            this.colTargetedDate.Name = "colTargetedDate";
            this.colTargetedDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTargetedDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colTargetedDate.Width = 150;
            // 
            // dgvColTownship
            // 
            this.dgvColTownship.DataPropertyName = "TownshipID";
            this.dgvColTownship.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgvColTownship.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvColTownship.HeaderText = "မြို့နယ်";
            this.dgvColTownship.Name = "dgvColTownship";
            this.dgvColTownship.ReadOnly = true;
            this.dgvColTownship.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColTownship.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColTownship.Width = 130;
            // 
            // colCompanyPlanID
            // 
            this.colCompanyPlanID.DataPropertyName = "ID";
            this.colCompanyPlanID.HeaderText = "MobileServicePlanID";
            this.colCompanyPlanID.Name = "colCompanyPlanID";
            this.colCompanyPlanID.Visible = false;
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
            this.colContactPerson.Width = 180;
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
            // frmConfirmCompanyPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 657);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.dgvCompanyPlan);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmConfirmCompanyPlan";
            this.Text = "frmCompanyConfirmList";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyPlan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DataGridView dgvCompanyPlan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private AGL.UI.Controls.CalendarColumn colTargetedDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColTownship;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyPlanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
    }
}