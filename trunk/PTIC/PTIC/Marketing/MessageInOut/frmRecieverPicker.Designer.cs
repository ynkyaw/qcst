namespace PTIC.Marketing.MessageInOut
{
    partial class frmRecieverPicker
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSelectedEmployees = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.colEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.colselEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colselPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colselDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colselEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedEmployees)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSelectedEmployees);
            this.groupBox2.Location = new System.Drawing.Point(12, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(689, 174);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ရွေးချယ်ထားသောဝန်ထမ်းများ";
            // 
            // dgvSelectedEmployees
            // 
            this.dgvSelectedEmployees.AllowUserToAddRows = false;
            this.dgvSelectedEmployees.AllowUserToDeleteRows = false;
            this.dgvSelectedEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSelectedEmployees.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelectedEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSelectedEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colselEmpName,
            this.colselPos,
            this.colselDept,
            this.colselEmpID});
            this.dgvSelectedEmployees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvSelectedEmployees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSelectedEmployees.Location = new System.Drawing.Point(13, 27);
            this.dgvSelectedEmployees.Name = "dgvSelectedEmployees";
            this.dgvSelectedEmployees.ReadOnly = true;
            this.dgvSelectedEmployees.RowHeadersWidth = 50;
            this.dgvSelectedEmployees.RowTemplate.Height = 28;
            this.dgvSelectedEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedEmployees.Size = new System.Drawing.Size(659, 131);
            this.dgvSelectedEmployees.TabIndex = 173;
            this.dgvSelectedEmployees.DoubleClick += new System.EventHandler(this.dgvSelectedEmployees_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvEmployees);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 182);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ဝန်ထမ်းများ";
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEmployeeName,
            this.colPosition,
            this.colDepartment,
            this.colEmployeeID});
            this.dgvEmployees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvEmployees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvEmployees.Location = new System.Drawing.Point(13, 27);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowHeadersWidth = 50;
            this.dgvEmployees.RowTemplate.Height = 28;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(659, 139);
            this.dgvEmployees.TabIndex = 172;
            this.dgvEmployees.DoubleClick += new System.EventHandler(this.dgvEmployees_DoubleClick);
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.DataPropertyName = "EmpName";
            this.colEmployeeName.HeaderText = "ဝန်ထမ်းမည်";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.ReadOnly = true;
            this.colEmployeeName.Width = 150;
            // 
            // colPosition
            // 
            this.colPosition.DataPropertyName = "PostName";
            this.colPosition.HeaderText = "ရာထူး";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            this.colPosition.Width = 200;
            // 
            // colDepartment
            // 
            this.colDepartment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDepartment.DataPropertyName = "DeptName";
            this.colDepartment.HeaderText = "ဌာန";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.DataPropertyName = "EmployeeID";
            this.colEmployeeID.HeaderText = "EmployeeID";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.ReadOnly = true;
            this.colEmployeeID.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 386);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 203;
            this.btnSave.Text = "ရွေးမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // colselEmpName
            // 
            this.colselEmpName.DataPropertyName = "EmpName";
            this.colselEmpName.HeaderText = "ဝန်ထမ်းမည်";
            this.colselEmpName.Name = "colselEmpName";
            this.colselEmpName.ReadOnly = true;
            this.colselEmpName.Width = 150;
            // 
            // colselPos
            // 
            this.colselPos.DataPropertyName = "PostName";
            this.colselPos.HeaderText = "ရာထူး";
            this.colselPos.Name = "colselPos";
            this.colselPos.ReadOnly = true;
            this.colselPos.Width = 200;
            // 
            // colselDept
            // 
            this.colselDept.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colselDept.DataPropertyName = "DeptName";
            this.colselDept.HeaderText = "ဌာန";
            this.colselDept.Name = "colselDept";
            this.colselDept.ReadOnly = true;
            // 
            // colselEmpID
            // 
            this.colselEmpID.DataPropertyName = "EmployeeID";
            this.colselEmpID.HeaderText = "EmployeeID";
            this.colselEmpID.Name = "colselEmpID";
            this.colselEmpID.ReadOnly = true;
            this.colselEmpID.Visible = false;
            // 
            // frmRecieverPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 432);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRecieverPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "စာလက်ခံမည့် ဝန်ထမ်းများရွေးရန်";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedEmployees)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSelectedEmployees;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colselEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colselPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colselDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colselEmpID;
    }
}