namespace PTIC.Marketing.MarketingPlan
{
    partial class frmEmployeePicker
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSelectedEmployees = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.colTripPlanDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colselEmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colselPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colselDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colselEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeeInTripPlanDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvEmployees);
            this.groupBox1.Location = new System.Drawing.Point(14, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 229);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ဝန်ထမ်းစာရင်း";
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEmployeeName,
            this.colPosition,
            this.colDepartment,
            this.colEmployeeID});
            this.dgvEmployees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvEmployees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvEmployees.Location = new System.Drawing.Point(7, 19);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowHeadersWidth = 50;
            this.dgvEmployees.RowTemplate.Height = 28;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(597, 204);
            this.dgvEmployees.TabIndex = 172;
            this.dgvEmployees.DoubleClick += new System.EventHandler(this.dgvEmployees_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSelectedEmployees);
            this.groupBox2.Location = new System.Drawing.Point(14, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 165);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "သွားမည့်ဝန်ထမ်းများ";
            // 
            // dgvSelectedEmployees
            // 
            this.dgvSelectedEmployees.AllowUserToAddRows = false;
            this.dgvSelectedEmployees.AllowUserToDeleteRows = false;
            this.dgvSelectedEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSelectedEmployees.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelectedEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSelectedEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colselEmpName,
            this.colselPos,
            this.colselDept,
            this.colselEmpID,
            this.colEmployeeInTripPlanDetailID});
            this.dgvSelectedEmployees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvSelectedEmployees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSelectedEmployees.Location = new System.Drawing.Point(7, 25);
            this.dgvSelectedEmployees.Name = "dgvSelectedEmployees";
            this.dgvSelectedEmployees.ReadOnly = true;
            this.dgvSelectedEmployees.RowHeadersWidth = 50;
            this.dgvSelectedEmployees.RowTemplate.Height = 28;
            this.dgvSelectedEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedEmployees.Size = new System.Drawing.Size(597, 135);
            this.dgvSelectedEmployees.TabIndex = 173;
            this.dgvSelectedEmployees.DoubleClick += new System.EventHandler(this.dgvSelectedEmployees_DoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(14, 418);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 32);
            this.btnSave.TabIndex = 202;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "EmpName";
            this.dataGridViewTextBoxColumn1.HeaderText = "၀န္ထမ္းအမည္";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PostID";
            this.dataGridViewTextBoxColumn2.HeaderText = "ရာထူး";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DeptID";
            this.dataGridViewTextBoxColumn3.HeaderText = "ဌာန";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "EmployeeID";
            this.dataGridViewTextBoxColumn4.HeaderText = "EmployeeID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "EmpName";
            this.dataGridViewTextBoxColumn5.HeaderText = "TripPlanDetailID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "EmpName";
            this.dataGridViewTextBoxColumn6.HeaderText = "၀န္ထမ္းအမည္";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PostID";
            this.dataGridViewTextBoxColumn7.HeaderText = "ရာထူး";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DeptID";
            this.dataGridViewTextBoxColumn8.HeaderText = "ဌာန";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 150;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "EmployeeID";
            this.dataGridViewTextBoxColumn9.HeaderText = "EmployeeID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "TripPlanDetailID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // colTripPlanDetailID
            // 
            this.colTripPlanDetailID.HeaderText = "TripPlanDetailID";
            this.colTripPlanDetailID.Name = "colTripPlanDetailID";
            this.colTripPlanDetailID.ReadOnly = true;
            this.colTripPlanDetailID.Visible = false;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.DataPropertyName = "EmpName";
            this.colEmployeeName.HeaderText = "ဝန်ထမ်းအမည်";
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
            this.colPosition.Width = 150;
            // 
            // colDepartment
            // 
            this.colDepartment.DataPropertyName = "DeptName";
            this.colDepartment.HeaderText = "ဌာန";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            this.colDepartment.Width = 150;
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.DataPropertyName = "EmployeeID";
            this.colEmployeeID.HeaderText = "EmployeeID";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.ReadOnly = true;
            this.colEmployeeID.Visible = false;
            // 
            // colselEmpName
            // 
            this.colselEmpName.DataPropertyName = "EmpName";
            this.colselEmpName.HeaderText = "ဝန်ထမ်းအမည်";
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
            this.colselPos.Width = 150;
            // 
            // colselDept
            // 
            this.colselDept.DataPropertyName = "DeptName";
            this.colselDept.HeaderText = "ဌာန";
            this.colselDept.Name = "colselDept";
            this.colselDept.ReadOnly = true;
            this.colselDept.Width = 150;
            // 
            // colselEmpID
            // 
            this.colselEmpID.DataPropertyName = "EmployeeID";
            this.colselEmpID.HeaderText = "EmployeeID";
            this.colselEmpID.Name = "colselEmpID";
            this.colselEmpID.ReadOnly = true;
            this.colselEmpID.Visible = false;
            // 
            // colEmployeeInTripPlanDetailID
            // 
            this.colEmployeeInTripPlanDetailID.DataPropertyName = "ID";
            this.colEmployeeInTripPlanDetailID.HeaderText = "ID";
            this.colEmployeeInTripPlanDetailID.Name = "colEmployeeInTripPlanDetailID";
            this.colEmployeeInTripPlanDetailID.ReadOnly = true;
            this.colEmployeeInTripPlanDetailID.Visible = false;
            // 
            // frmEmployeePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 454);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmployeePicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "သွားမည့်ဝန်ထမ်းများရွေးချယ်ခြင်း";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTripPlanDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridView dgvSelectedEmployees;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colselEmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colselPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colselDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colselEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeeInTripPlanDetailID;
    }
}