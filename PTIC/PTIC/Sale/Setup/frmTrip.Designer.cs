namespace PTIC.Sale.Setup
{
    partial class frmTrip
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.dgvsetuptrip = new System.Windows.Forms.DataGridView();
            this.TripID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TripName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TripPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvsetuptownintrip = new System.Windows.Forms.DataGridView();
            this.TownInTripID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tirp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TownID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTownInTripDelete = new System.Windows.Forms.Button();
            this.btnTownInTripSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetuptrip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetuptownintrip)).BeginInit();
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
            this.panel1.TabIndex = 9;
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
            this.lblHeader.Size = new System.Drawing.Size(70, 17);
            this.lblHeader.TabIndex = 45;
            this.lblHeader.Text = ">    ခရီးစဉ်";
            // 
            // dgvsetuptrip
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvsetuptrip.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvsetuptrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvsetuptrip.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvsetuptrip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvsetuptrip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsetuptrip.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TripID,
            this.No,
            this.TripName,
            this.TripPeriod,
            this.Remark});
            this.dgvsetuptrip.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvsetuptrip.Location = new System.Drawing.Point(12, 64);
            this.dgvsetuptrip.Name = "dgvsetuptrip";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetuptrip.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvsetuptrip.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetuptrip.RowTemplate.Height = 30;
            this.dgvsetuptrip.ShowCellToolTips = false;
            this.dgvsetuptrip.Size = new System.Drawing.Size(899, 203);
            this.dgvsetuptrip.TabIndex = 54;
            this.dgvsetuptrip.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvsetuptrip_CellClick);
            this.dgvsetuptrip.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvsetuptrip_CellValidating);
            this.dgvsetuptrip.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvsetuptrip_DataBindingComplete);
            this.dgvsetuptrip.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvsetuptrip_DataError);
            this.dgvsetuptrip.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvsetuptrip_RowHeaderMouseDoubleClick);
            this.dgvsetuptrip.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvsetuptrip_RowPostPaint);
            // 
            // TripID
            // 
            this.TripID.DataPropertyName = "TripID";
            this.TripID.Name = "TripID";
            this.TripID.Visible = false;
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
            // TripName
            // 
            this.TripName.DataPropertyName = "TripName";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TripName.DefaultCellStyle = dataGridViewCellStyle4;
            this.TripName.HeaderText = "ခရီးစဉ်အမည်";
            this.TripName.Name = "TripName";
            this.TripName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TripName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TripName.Width = 150;
            // 
            // TripPeriod
            // 
            this.TripPeriod.DataPropertyName = "TripPeriod";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TripPeriod.DefaultCellStyle = dataGridViewCellStyle5;
            this.TripPeriod.HeaderText = "ကြာမြင့်ရက်";
            this.TripPeriod.Name = "TripPeriod";
            this.TripPeriod.Width = 80;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.DataPropertyName = "Remark";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.Remark.DefaultCellStyle = dataGridViewCellStyle6;
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dgvsetuptownintrip
            // 
            this.dgvsetuptownintrip.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvsetuptownintrip.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvsetuptownintrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvsetuptownintrip.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvsetuptownintrip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvsetuptownintrip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsetuptownintrip.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TownInTripID,
            this.Tirp,
            this.dataGridViewTextBoxColumn2,
            this.TownID});
            this.dgvsetuptownintrip.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvsetuptownintrip.Location = new System.Drawing.Point(12, 360);
            this.dgvsetuptownintrip.MultiSelect = false;
            this.dgvsetuptownintrip.Name = "dgvsetuptownintrip";
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetuptownintrip.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvsetuptownintrip.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetuptownintrip.RowTemplate.Height = 30;
            this.dgvsetuptownintrip.ShowCellToolTips = false;
            this.dgvsetuptownintrip.Size = new System.Drawing.Size(899, 246);
            this.dgvsetuptownintrip.TabIndex = 55;
            this.dgvsetuptownintrip.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvsetuptownintrip_CellValidating);
            this.dgvsetuptownintrip.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvsetuptownintrip_DataBindingComplete);
            this.dgvsetuptownintrip.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvsetuptownintrip_DataError);
            this.dgvsetuptownintrip.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvsetuptownintrip_EditingControlShowing);
            this.dgvsetuptownintrip.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvsetuptripintown_RowPostPaint);
            // 
            // TownInTripID
            // 
            this.TownInTripID.DataPropertyName = "TownInTripID";
            this.TownInTripID.Name = "TownInTripID";
            this.TownInTripID.Visible = false;
            // 
            // Tirp
            // 
            this.Tirp.DataPropertyName = "TripID";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tirp.DefaultCellStyle = dataGridViewCellStyle10;
            this.Tirp.Name = "Tirp";
            this.Tirp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Tirp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tirp.Visible = false;
            this.Tirp.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn2.HeaderText = "စဉ်";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 47;
            // 
            // TownID
            // 
            this.TownID.DataPropertyName = "TownID";
            this.TownID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.TownID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TownID.HeaderText = "ပါဝင်‌သောမြို့များ";
            this.TownID.Name = "TownID";
            this.TownID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TownID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TownID.Width = 200;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(123, 275);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 61;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(12, 275);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 60;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTownInTripDelete
            // 
            this.btnTownInTripDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTownInTripDelete.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTownInTripDelete.Location = new System.Drawing.Point(123, 614);
            this.btnTownInTripDelete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnTownInTripDelete.Name = "btnTownInTripDelete";
            this.btnTownInTripDelete.Size = new System.Drawing.Size(95, 34);
            this.btnTownInTripDelete.TabIndex = 63;
            this.btnTownInTripDelete.Text = "ဖျက်မည်";
            this.btnTownInTripDelete.UseVisualStyleBackColor = true;
            this.btnTownInTripDelete.Click += new System.EventHandler(this.btnTownInTripDelete_Click);
            // 
            // btnTownInTripSave
            // 
            this.btnTownInTripSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTownInTripSave.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTownInTripSave.Location = new System.Drawing.Point(12, 614);
            this.btnTownInTripSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnTownInTripSave.Name = "btnTownInTripSave";
            this.btnTownInTripSave.Size = new System.Drawing.Size(95, 34);
            this.btnTownInTripSave.TabIndex = 62;
            this.btnTownInTripSave.Text = "သိမ်းမည်";
            this.btnTownInTripSave.UseVisualStyleBackColor = true;
            this.btnTownInTripSave.Click += new System.EventHandler(this.btnTownInTripSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(13, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 17);
            this.label1.TabIndex = 64;
            this.label1.Text = "ခရီးစဉ်တစ်ခုတွင် ပါဝင်‌သောမြို့များ";
            // 
            // frmTrip
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(923, 653);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTownInTripDelete);
            this.Controls.Add(this.btnTownInTripSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvsetuptownintrip);
            this.Controls.Add(this.dgvsetuptrip);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmTrip";
            this.Text = "ခရီးစဉ်";
            this.Load += new System.EventHandler(this.frmTrip_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetuptrip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetuptownintrip)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView dgvsetuptrip;
        private System.Windows.Forms.DataGridView dgvsetuptownintrip;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTownInTripDelete;
        private System.Windows.Forms.Button btnTownInTripSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn TripID;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn TripName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TripPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn TownInTripID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tirp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn TownID;
        private System.Windows.Forms.Label label1;
    }
}