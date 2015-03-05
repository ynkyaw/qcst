namespace PTIC.VC.Marketing.MarketingPlan
{
    partial class frmConfirmTelemarketingPlan
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
            this.dgvTeleMarketingPlan = new System.Windows.Forms.DataGridView();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlanDate = new AGL.UI.Controls.CalendarColumn();
            this.colTownship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCusType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeleMarketingPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(940, 46);
            this.panel2.TabIndex = 144;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(91, 13);
            this.lblHeaderPCat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(241, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">   Telemarketing Plan Confirmation";
            // 
            // lblMarketing
            // 
            this.lblMarketing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarketing.AutoSize = true;
            this.lblMarketing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMarketing.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketing.Location = new System.Drawing.Point(12, 13);
            this.lblMarketing.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMarketing.Name = "lblMarketing";
            this.lblMarketing.Size = new System.Drawing.Size(62, 20);
            this.lblMarketing.TabIndex = 0;
            this.lblMarketing.Text = "Planning";
            this.lblMarketing.Click += new System.EventHandler(this.lblMarketing_Click);
            // 
            // dgvTeleMarketingPlan
            // 
            this.dgvTeleMarketingPlan.AllowUserToAddRows = false;
            this.dgvTeleMarketingPlan.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeleMarketingPlan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTeleMarketingPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTeleMarketingPlan.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeleMarketingPlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTeleMarketingPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeleMarketingPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colPlanID,
            this.colPlanDate,
            this.colTownship,
            this.colCusType,
            this.colCusName,
            this.colPhone});
            this.dgvTeleMarketingPlan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTeleMarketingPlan.Location = new System.Drawing.Point(16, 54);
            this.dgvTeleMarketingPlan.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTeleMarketingPlan.MultiSelect = false;
            this.dgvTeleMarketingPlan.Name = "dgvTeleMarketingPlan";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.dgvTeleMarketingPlan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTeleMarketingPlan.RowTemplate.Height = 30;
            this.dgvTeleMarketingPlan.Size = new System.Drawing.Size(908, 613);
            this.dgvTeleMarketingPlan.TabIndex = 145;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.Location = new System.Drawing.Point(16, 675);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(95, 34);
            this.btnConfirm.TabIndex = 147;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReject.Location = new System.Drawing.Point(129, 675);
            this.btnReject.Margin = new System.Windows.Forms.Padding(4);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(95, 34);
            this.btnReject.TabIndex = 148;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "Select";
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 50;
            // 
            // colPlanID
            // 
            this.colPlanID.DataPropertyName = "MarketingPlanID";
            this.colPlanID.HeaderText = "PlanID";
            this.colPlanID.Name = "colPlanID";
            this.colPlanID.Visible = false;
            // 
            // colPlanDate
            // 
            this.colPlanDate.DataPropertyName = "PlanDate";
            dataGridViewCellStyle3.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.colPlanDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPlanDate.HeaderText = "ဆက်သွယ်ရမည့်နေ့";
            this.colPlanDate.Name = "colPlanDate";
            this.colPlanDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPlanDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPlanDate.Width = 123;
            // 
            // colTownship
            // 
            this.colTownship.DataPropertyName = "Township";
            this.colTownship.HeaderText = "မြို့နယ်";
            this.colTownship.Name = "colTownship";
            this.colTownship.ReadOnly = true;
            this.colTownship.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTownship.Width = 150;
            // 
            // colCusType
            // 
            this.colCusType.DataPropertyName = "CusType";
            this.colCusType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colCusType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colCusType.HeaderText = "Customer အမျိုးအစား";
            this.colCusType.Name = "colCusType";
            this.colCusType.ReadOnly = true;
            this.colCusType.Width = 150;
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
            // colPhone
            // 
            this.colPhone.DataPropertyName = "Phone1";
            this.colPhone.HeaderText = "ဆက်သွယ်ရမည့်ဖုန်း";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPhone.Width = 150;
            // 
            // frmConfirmTelemarketingPlan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(940, 722);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.dgvTeleMarketingPlan);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmConfirmTelemarketingPlan";
            this.Text = "Telemarketing Plan Confirmation";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeleMarketingPlan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.DataGridView dgvTeleMarketingPlan;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlanID;
        private AGL.UI.Controls.CalendarColumn colPlanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownship;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCusType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
    }
}