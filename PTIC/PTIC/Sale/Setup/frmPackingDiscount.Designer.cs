namespace PTIC.Sale.Setup
{
    partial class frmPackingDiscount
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.dgvsetuppackingdis = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrandID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AmtPerPack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetuppackingdis)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblSetup);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 41);
            this.panel1.TabIndex = 8;
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
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeader.Location = new System.Drawing.Point(61, 10);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(118, 17);
            this.lblHeader.TabIndex = 45;
            this.lblHeader.Text = ">    ပါကင်‌လျော့‌ဈေး";
            // 
            // dgvsetuppackingdis
            // 
            this.dgvsetuppackingdis.AllowUserToAddRows = false;
            this.dgvsetuppackingdis.AllowUserToDeleteRows = false;
            this.dgvsetuppackingdis.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvsetuppackingdis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvsetuppackingdis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvsetuppackingdis.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvsetuppackingdis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvsetuppackingdis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsetuppackingdis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.BrandID,
            this.ProductID,
            this.AmtPerPack,
            this.PackQty});
            this.dgvsetuppackingdis.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvsetuppackingdis.Location = new System.Drawing.Point(12, 64);
            this.dgvsetuppackingdis.Name = "dgvsetuppackingdis";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetuppackingdis.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvsetuppackingdis.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetuppackingdis.RowTemplate.Height = 30;
            this.dgvsetuppackingdis.ShowCellToolTips = false;
            this.dgvsetuppackingdis.Size = new System.Drawing.Size(899, 462);
            this.dgvsetuppackingdis.TabIndex = 53;
            this.dgvsetuppackingdis.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvsetuppackingdis_CellLeave);
            this.dgvsetuppackingdis.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvsetuppackingdis_CellValidating);
            this.dgvsetuppackingdis.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvsetuppackingdis_CellValueChanged);
            this.dgvsetuppackingdis.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvsetuppackingdis_DataError);
            this.dgvsetuppackingdis.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvsetuppackingdis_EditingControlShowing);
            this.dgvsetuppackingdis.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvsetuppackingdis_RowPostPaint);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.No.DefaultCellStyle = dataGridViewCellStyle3;
            this.No.HeaderText = "စဉ်";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 47;
            // 
            // BrandID
            // 
            this.BrandID.DataPropertyName = "BrandID";
            this.BrandID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrandID.HeaderText = "အမှတ်တံဆိပ်";
            this.BrandID.Name = "BrandID";
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductID.DefaultCellStyle = dataGridViewCellStyle4;
            this.ProductID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductID.HeaderText = "ထုတ်ကုန်";
            this.ProductID.Name = "ProductID";
            this.ProductID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductID.Width = 200;
            // 
            // AmtPerPack
            // 
            this.AmtPerPack.DataPropertyName = "AmtPerPack";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.AmtPerPack.DefaultCellStyle = dataGridViewCellStyle5;
            this.AmtPerPack.HeaderText = "(၁) ပါကင်‌လျှော့‌ဈေး";
            this.AmtPerPack.Name = "AmtPerPack";
            this.AmtPerPack.Width = 200;
            // 
            // PackQty
            // 
            this.PackQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PackQty.DataPropertyName = "PackQty";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.PackQty.DefaultCellStyle = dataGridViewCellStyle6;
            this.PackQty.HeaderText = "အနည်းဆုံးဝယ်ရမည့် ပါကင်";
            this.PackQty.Name = "PackQty";
            this.PackQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PackQty.Width = 147;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(250, 542);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 59;
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
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(12, 542);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 34);
            this.btnNew.TabIndex = 60;
            this.btnNew.Text = "ထည့်မည်";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmPackingDiscount
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(923, 590);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvsetuppackingdis);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPackingDiscount";
            this.Text = "ပါကင်‌လျှော့‌ဈေး";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetuppackingdis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView dgvsetuppackingdis;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewComboBoxColumn BrandID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmtPerPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackQty;
    }
}