namespace PTIC.Sale.Setup
{
    partial class frmCustomerClass
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.dgvsetupcustomerclass = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CusClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetupcustomerclass)).BeginInit();
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
            this.lblHeaderPCat.Size = new System.Drawing.Size(131, 17);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">    Customer Class";
            // 
            // dgvsetupcustomerclass
            // 
            this.dgvsetupcustomerclass.AllowUserToAddRows = false;
            this.dgvsetupcustomerclass.AllowUserToDeleteRows = false;
            this.dgvsetupcustomerclass.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvsetupcustomerclass.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvsetupcustomerclass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvsetupcustomerclass.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvsetupcustomerclass.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvsetupcustomerclass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsetupcustomerclass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.CusClass,
            this.Description,
            this.Remark});
            this.dgvsetupcustomerclass.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvsetupcustomerclass.Location = new System.Drawing.Point(12, 64);
            this.dgvsetupcustomerclass.Name = "dgvsetupcustomerclass";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetupcustomerclass.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvsetupcustomerclass.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetupcustomerclass.RowTemplate.Height = 30;
            this.dgvsetupcustomerclass.ShowCellToolTips = false;
            this.dgvsetupcustomerclass.Size = new System.Drawing.Size(899, 462);
            this.dgvsetupcustomerclass.TabIndex = 51;
            this.dgvsetupcustomerclass.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvsetupcustomerclass_CellValidating);
            this.dgvsetupcustomerclass.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvsetupcustomerclass_RowPostPaint);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.No.HeaderText = "စဉ်";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 47;
            // 
            // CusClass
            // 
            this.CusClass.DataPropertyName = "CusClass";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.CusClass.DefaultCellStyle = dataGridViewCellStyle3;
            this.CusClass.HeaderText = "Customer အဆင့်";
            this.CusClass.Name = "CusClass";
            this.CusClass.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CusClass.Width = 200;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.DefaultCellStyle = dataGridViewCellStyle4;
            this.Description.HeaderText = "သတ်မှတ်ချက်";
            this.Description.Name = "Description";
            this.Description.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Description.Width = 450;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.DataPropertyName = "Remark";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.Remark.DefaultCellStyle = dataGridViewCellStyle5;
            this.Remark.HeaderText = "မှတ်ချက်";
            this.Remark.Name = "Remark";
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
            // frmCustomerClass
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(923, 590);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvsetupcustomerclass);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCustomerClass";
            this.Text = "Customer Class";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetupcustomerclass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.DataGridView dgvsetupcustomerclass;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn CusClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.Button btnNew;
    }
}