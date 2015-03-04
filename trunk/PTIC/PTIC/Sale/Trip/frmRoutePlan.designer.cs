namespace PTIC.VC.Sale.Trip
{
    partial class frmRoutePlan
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtRplanNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSalePage = new System.Windows.Forms.Label();
            this.cmbVanNo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSalePerson = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvRoutePlan = new System.Windows.Forms.DataGridView();
            this.cmbRouteName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpPlanDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTranDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.clnRoutePlanNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPlanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRouteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnSalePerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVanNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnEmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRoutePlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnVenID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRouteID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutePlan)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(432, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 17);
            this.label4.TabIndex = 144;
            this.label4.Text = "‌နေ့စွဲ";
            // 
            // txtRplanNo
            // 
            this.txtRplanNo.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRplanNo.Location = new System.Drawing.Point(137, 54);
            this.txtRplanNo.Name = "txtRplanNo";
            this.txtRplanNo.Size = new System.Drawing.Size(150, 26);
            this.txtRplanNo.TabIndex = 143;
            this.txtRplanNo.TextChanged += new System.EventHandler(this.txtRplanNo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Route Plan No";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cmbVanNo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbSalePerson);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dgvRoutePlan);
            this.panel1.Controls.Add(this.cmbRouteName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpPlanDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpTranDate);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtRplanNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 543);
            this.panel1.TabIndex = 38;
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(120, 505);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 34);
            this.btnEdit.TabIndex = 167;
            this.btnEdit.Text = "ပြင်မည်";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(228, 505);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 166;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lblSalePage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(716, 41);
            this.panel2.TabIndex = 165;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(78, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = ">  လမ်း‌ကြောင်း Plan";
            // 
            // lblSalePage
            // 
            this.lblSalePage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSalePage.AutoSize = true;
            this.lblSalePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalePage.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalePage.Location = new System.Drawing.Point(12, 9);
            this.lblSalePage.Name = "lblSalePage";
            this.lblSalePage.Size = new System.Drawing.Size(65, 17);
            this.lblSalePage.TabIndex = 2;
            this.lblSalePage.Text = "Planning";
            this.lblSalePage.Click += new System.EventHandler(this.lblSalePage_Click);
            // 
            // cmbVanNo
            // 
            this.cmbVanNo.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVanNo.FormattingEnabled = true;
            this.cmbVanNo.Location = new System.Drawing.Point(532, 125);
            this.cmbVanNo.Name = "cmbVanNo";
            this.cmbVanNo.Size = new System.Drawing.Size(150, 25);
            this.cmbVanNo.TabIndex = 164;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(432, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 17);
            this.label6.TabIndex = 163;
            this.label6.Text = "အ‌ရောင်းကားနံပါတ်";
            // 
            // cmbSalePerson
            // 
            this.cmbSalePerson.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalePerson.FormattingEnabled = true;
            this.cmbSalePerson.Location = new System.Drawing.Point(137, 125);
            this.cmbSalePerson.Name = "cmbSalePerson";
            this.cmbSalePerson.Size = new System.Drawing.Size(150, 25);
            this.cmbSalePerson.TabIndex = 162;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 161;
            this.label5.Text = "အ‌ရောင်းဝန်ထမ်းအမည်";
            // 
            // dgvRoutePlan
            // 
            this.dgvRoutePlan.AllowUserToAddRows = false;
            this.dgvRoutePlan.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoutePlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoutePlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoutePlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnRoutePlanNo,
            this.clnPlanDate,
            this.clnRouteName,
            this.clnSalePerson,
            this.clnVanNo,
            this.clnEmpID,
            this.clnRoutePlanID,
            this.clnVenID,
            this.clnRouteID});
            this.dgvRoutePlan.Location = new System.Drawing.Point(12, 169);
            this.dgvRoutePlan.Name = "dgvRoutePlan";
            this.dgvRoutePlan.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoutePlan.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRoutePlan.RowHeadersWidth = 50;
            this.dgvRoutePlan.RowTemplate.Height = 28;
            this.dgvRoutePlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoutePlan.Size = new System.Drawing.Size(694, 330);
            this.dgvRoutePlan.TabIndex = 160;
            this.dgvRoutePlan.VirtualMode = true;
            this.dgvRoutePlan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoutePlan_CellClick);
            this.dgvRoutePlan.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRoutePlan_DataBindingComplete);
            this.dgvRoutePlan.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvRoutePlan_DefaultValuesNeeded);
            // 
            // cmbRouteName
            // 
            this.cmbRouteName.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRouteName.FormattingEnabled = true;
            this.cmbRouteName.Location = new System.Drawing.Point(137, 88);
            this.cmbRouteName.Name = "cmbRouteName";
            this.cmbRouteName.Size = new System.Drawing.Size(150, 25);
            this.cmbRouteName.TabIndex = 159;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 158;
            this.label3.Text = "လမ်း‌ကြောင်းအမည်";
            // 
            // dtpPlanDate
            // 
            this.dtpPlanDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpPlanDate.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPlanDate.Location = new System.Drawing.Point(532, 88);
            this.dtpPlanDate.Name = "dtpPlanDate";
            this.dtpPlanDate.Size = new System.Drawing.Size(150, 26);
            this.dtpPlanDate.TabIndex = 157;
            this.dtpPlanDate.Value = new System.DateTime(2014, 4, 10, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(432, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 156;
            this.label2.Text = "သွားရမည့်‌နေ့";
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpTranDate.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTranDate.Location = new System.Drawing.Point(532, 54);
            this.dtpTranDate.Name = "dtpTranDate";
            this.dtpTranDate.Size = new System.Drawing.Size(150, 26);
            this.dtpTranDate.TabIndex = 155;
            this.dtpTranDate.Value = new System.DateTime(2014, 3, 14, 0, 0, 0, 0);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(12, 505);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 152;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // clnRoutePlanNo
            // 
            this.clnRoutePlanNo.DataPropertyName = "RoutePlanNo";
            this.clnRoutePlanNo.HeaderText = "Route Plan No";
            this.clnRoutePlanNo.Name = "clnRoutePlanNo";
            this.clnRoutePlanNo.ReadOnly = true;
            this.clnRoutePlanNo.Width = 110;
            // 
            // clnPlanDate
            // 
            this.clnPlanDate.DataPropertyName = "PlanDate";
            this.clnPlanDate.HeaderText = "သွားရမည့်‌နေ့";
            this.clnPlanDate.Name = "clnPlanDate";
            this.clnPlanDate.ReadOnly = true;
            this.clnPlanDate.Width = 120;
            // 
            // clnRouteName
            // 
            this.clnRouteName.DataPropertyName = "RouteName";
            this.clnRouteName.HeaderText = "လမ်း‌ကြောင်းအမည်";
            this.clnRouteName.Name = "clnRouteName";
            this.clnRouteName.ReadOnly = true;
            this.clnRouteName.Width = 150;
            // 
            // clnSalePerson
            // 
            this.clnSalePerson.DataPropertyName = "EmpName";
            this.clnSalePerson.HeaderText = "အ‌ရောင်းဝန်ထမ်းအမည်";
            this.clnSalePerson.Name = "clnSalePerson";
            this.clnSalePerson.ReadOnly = true;
            this.clnSalePerson.Width = 150;
            // 
            // clnVanNo
            // 
            this.clnVanNo.DataPropertyName = "VenNo";
            this.clnVanNo.HeaderText = "အ‌ရောင်းကားနံပါတ်";
            this.clnVanNo.Name = "clnVanNo";
            this.clnVanNo.ReadOnly = true;
            this.clnVanNo.Width = 105;
            // 
            // clnEmpID
            // 
            this.clnEmpID.DataPropertyName = "EmpID";
            this.clnEmpID.HeaderText = "EmployeeID";
            this.clnEmpID.Name = "clnEmpID";
            this.clnEmpID.ReadOnly = true;
            this.clnEmpID.Visible = false;
            // 
            // clnRoutePlanID
            // 
            this.clnRoutePlanID.DataPropertyName = "RoutePlanID";
            this.clnRoutePlanID.HeaderText = "RoutePlanID";
            this.clnRoutePlanID.Name = "clnRoutePlanID";
            this.clnRoutePlanID.ReadOnly = true;
            this.clnRoutePlanID.Visible = false;
            // 
            // clnVenID
            // 
            this.clnVenID.DataPropertyName = "VenID";
            this.clnVenID.HeaderText = "Ven ID";
            this.clnVenID.Name = "clnVenID";
            this.clnVenID.ReadOnly = true;
            this.clnVenID.Visible = false;
            // 
            // clnRouteID
            // 
            this.clnRouteID.DataPropertyName = "RouteID";
            this.clnRouteID.HeaderText = "RouteID";
            this.clnRouteID.Name = "clnRouteID";
            this.clnRouteID.ReadOnly = true;
            this.clnRouteID.Visible = false;
            // 
            // frmRoutePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 543);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "frmRoutePlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "လမ်း‌ကြောင်း Plan";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoutePlan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRplanNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpPlanDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTranDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRouteName;
        private System.Windows.Forms.DataGridView dgvRoutePlan;
        private System.Windows.Forms.ComboBox cmbSalePerson;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbVanNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSalePage;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRoutePlanNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRouteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSalePerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVanNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnEmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRoutePlanID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnVenID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRouteID;
    }
}