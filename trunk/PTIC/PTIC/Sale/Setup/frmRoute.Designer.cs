namespace PTIC.Sale.Setup
{
    partial class frmRoute
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.dgvsetuproute = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTshipInRouteDelete = new System.Windows.Forms.Button();
            this.btnTshipInRouteSave = new System.Windows.Forms.Button();
            this.dgvsetuptownshipinrout = new System.Windows.Forms.DataGridView();
            this.colTrownshipInRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownshipInRouteNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColTownshipID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColRoutName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColRouteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColTownList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetuproute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetuptownshipinrout)).BeginInit();
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
            this.panel1.TabIndex = 10;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(8, 10);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(48, 16);
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
            this.lblHeader.Size = new System.Drawing.Size(98, 16);
            this.lblHeader.TabIndex = 45;
            this.lblHeader.Text = ">    လမ်း‌ကြောင်း";
            // 
            // dgvsetuproute
            // 
            this.dgvsetuproute.AllowUserToAddRows = false;
            this.dgvsetuproute.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvsetuproute.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvsetuproute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvsetuproute.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvsetuproute.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvsetuproute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsetuproute.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.dgvColRoutName,
            this.dgvColRouteId,
            this.dgvColTownList,
            this.Remark});
            this.dgvsetuproute.Location = new System.Drawing.Point(12, 64);
            this.dgvsetuproute.Name = "dgvsetuproute";
            this.dgvsetuproute.ReadOnly = true;
            this.dgvsetuproute.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetuproute.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvsetuproute.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetuproute.RowTemplate.Height = 30;
            this.dgvsetuproute.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvsetuproute.ShowCellToolTips = false;
            this.dgvsetuproute.Size = new System.Drawing.Size(899, 479);
            this.dgvsetuproute.TabIndex = 55;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(385, 551);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 63;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(274, 551);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 62;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            // 
            // btnTshipInRouteDelete
            // 
            this.btnTshipInRouteDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTshipInRouteDelete.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTshipInRouteDelete.Location = new System.Drawing.Point(122, 551);
            this.btnTshipInRouteDelete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnTshipInRouteDelete.Name = "btnTshipInRouteDelete";
            this.btnTshipInRouteDelete.Size = new System.Drawing.Size(95, 34);
            this.btnTshipInRouteDelete.TabIndex = 66;
            this.btnTshipInRouteDelete.Text = "ဖျက်မည်";
            this.btnTshipInRouteDelete.UseVisualStyleBackColor = true;
            this.btnTshipInRouteDelete.Visible = false;
            // 
            // btnTshipInRouteSave
            // 
            this.btnTshipInRouteSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTshipInRouteSave.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTshipInRouteSave.Location = new System.Drawing.Point(11, 551);
            this.btnTshipInRouteSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnTshipInRouteSave.Name = "btnTshipInRouteSave";
            this.btnTshipInRouteSave.Size = new System.Drawing.Size(95, 34);
            this.btnTshipInRouteSave.TabIndex = 65;
            this.btnTshipInRouteSave.Text = "သိမ်းမည်";
            this.btnTshipInRouteSave.UseVisualStyleBackColor = true;
            this.btnTshipInRouteSave.Visible = false;
            // 
            // dgvsetuptownshipinrout
            // 
            this.dgvsetuptownshipinrout.AllowUserToDeleteRows = false;
            this.dgvsetuptownshipinrout.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvsetuptownshipinrout.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvsetuptownshipinrout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvsetuptownshipinrout.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvsetuptownshipinrout.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvsetuptownshipinrout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsetuptownshipinrout.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTrownshipInRoute,
            this.colRoute,
            this.colTownshipInRouteNo,
            this.dgvColTownshipID});
            this.dgvsetuptownshipinrout.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvsetuptownshipinrout.Location = new System.Drawing.Point(498, 551);
            this.dgvsetuptownshipinrout.MultiSelect = false;
            this.dgvsetuptownshipinrout.Name = "dgvsetuptownshipinrout";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetuptownshipinrout.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvsetuptownshipinrout.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetuptownshipinrout.RowTemplate.Height = 30;
            this.dgvsetuptownshipinrout.ShowCellToolTips = false;
            this.dgvsetuptownshipinrout.Size = new System.Drawing.Size(29, 10);
            this.dgvsetuptownshipinrout.TabIndex = 64;
            this.dgvsetuptownshipinrout.Visible = false;
            // 
            // colTrownshipInRoute
            // 
            this.colTrownshipInRoute.DataPropertyName = "TownshipInRouteID";
            this.colTrownshipInRoute.Name = "colTrownshipInRoute";
            this.colTrownshipInRoute.Visible = false;
            // 
            // colRoute
            // 
            this.colRoute.DataPropertyName = "RouteID";
            this.colRoute.Name = "colRoute";
            this.colRoute.Visible = false;
            // 
            // colTownshipInRouteNo
            // 
            this.colTownshipInRouteNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTownshipInRouteNo.DefaultCellStyle = dataGridViewCellStyle9;
            this.colTownshipInRouteNo.HeaderText = "စဉ်";
            this.colTownshipInRouteNo.Name = "colTownshipInRouteNo";
            this.colTownshipInRouteNo.ReadOnly = true;
            this.colTownshipInRouteNo.Width = 44;
            // 
            // dgvColTownshipID
            // 
            this.dgvColTownshipID.DataPropertyName = "TownshipID";
            this.dgvColTownshipID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvColTownshipID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvColTownshipID.HeaderText = "ပါဝင်‌သောမြို့နယ်များ";
            this.dgvColTownshipID.Name = "dgvColTownshipID";
            this.dgvColTownshipID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColTownshipID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColTownshipID.Width = 200;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(11, 551);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 34);
            this.btnAdd.TabIndex = 67;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(122, 551);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 34);
            this.btnEdit.TabIndex = 68;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(235, 551);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(95, 34);
            this.btnDel.TabIndex = 69;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.No.DataPropertyName = "ROWNUM";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.No.DefaultCellStyle = dataGridViewCellStyle3;
            this.No.HeaderText = "စဉ်";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 47;
            // 
            // dgvColRoutName
            // 
            this.dgvColRoutName.DataPropertyName = "RouteName";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvColRoutName.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvColRoutName.HeaderText = "လမ်း‌ကြောင်းအမည်";
            this.dgvColRoutName.Name = "dgvColRoutName";
            this.dgvColRoutName.ReadOnly = true;
            this.dgvColRoutName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColRoutName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvColRoutName.Width = 150;
            // 
            // dgvColRouteId
            // 
            this.dgvColRouteId.DataPropertyName = "ID";
            this.dgvColRouteId.HeaderText = "RouteId";
            this.dgvColRouteId.Name = "dgvColRouteId";
            this.dgvColRouteId.ReadOnly = true;
            this.dgvColRouteId.Visible = false;
            // 
            // dgvColTownList
            // 
            this.dgvColTownList.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvColTownList.DataPropertyName = "Township";
            this.dgvColTownList.HeaderText = "TownList";
            this.dgvColTownList.Name = "dgvColTownList";
            this.dgvColTownList.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.Remark.DefaultCellStyle = dataGridViewCellStyle5;
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // frmRoute
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(923, 590);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnTshipInRouteDelete);
            this.Controls.Add(this.btnTshipInRouteSave);
            this.Controls.Add(this.dgvsetuptownshipinrout);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvsetuproute);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmRoute";
            this.Text = "လမ်း‌ကြောင်း";
            this.Load += new System.EventHandler(this.frmRoute_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetuproute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetuptownshipinrout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView dgvsetuproute;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTshipInRouteDelete;
        private System.Windows.Forms.Button btnTshipInRouteSave;
        private System.Windows.Forms.DataGridView dgvsetuptownshipinrout;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrownshipInRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownshipInRouteNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColTownshipID;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColRoutName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColRouteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColTownList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}