namespace PTIC.Sale.Setup
{
    partial class frmBatterySettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSetup = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.dgvsetupbsetting = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new AGL.UI.Controls.CalendarColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNew = new System.Windows.Forms.Button();
            this.TranDate = new AGL.UI.Controls.CalendarColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetupbsetting)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSetup
            // 
            this.lblSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3",9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetup.Location = new System.Drawing.Point(8, 10);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(47, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Setup";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblSetup);
            this.panel1.Controls.Add(this.lblBrand);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 41);
            this.panel1.TabIndex = 2;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Myanmar3",9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblBrand.Location = new System.Drawing.Point(61, 10);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(199, 20);
            this.lblBrand.TabIndex = 17;
            this.lblBrand.Text = ">    အိုးသစ်နှင့် အိုးခွံသတ်မှတ်ချက်";
            // 
            // dgvsetupbsetting
            // 
            this.dgvsetupbsetting.AllowUserToAddRows = false;
            this.dgvsetupbsetting.AllowUserToDeleteRows = false;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Myanmar3",9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvsetupbsetting.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle26;
            this.dgvsetupbsetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvsetupbsetting.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Myanmar3",9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvsetupbsetting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvsetupbsetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsetupbsetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TranDate,
            this.ProductName,
            this.BWeight,
            this.BQty});
            this.dgvsetupbsetting.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvsetupbsetting.Location = new System.Drawing.Point(12, 58);
            this.dgvsetupbsetting.Name = "dgvsetupbsetting";
            this.dgvsetupbsetting.RowHeadersWidth = 50;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Myanmar3",9F);
            this.dgvsetupbsetting.RowsDefaultCellStyle = dataGridViewCellStyle31;
            this.dgvsetupbsetting.RowTemplate.Height = 30;
            this.dgvsetupbsetting.Size = new System.Drawing.Size(939, 472);
            this.dgvsetupbsetting.TabIndex = 18;
            this.dgvsetupbsetting.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvsetupbsetting_CellFormatting);
            this.dgvsetupbsetting.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvsetupbsetting_CellValidating);
            this.dgvsetupbsetting.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvsetupbsetting_CellValueChanged);
            this.dgvsetupbsetting.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvsetupbsetting_DataBindingComplete);
            this.dgvsetupbsetting.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvsetupbsetting_DataError);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3",9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(250, 544);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 34);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Font = new System.Drawing.Font("Myanmar3",9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(131, 544);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 34);
            this.btnAdd.TabIndex = 39;
            this.btnAdd.Text = "သိမ်းမည်";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BatterySettingID";
            this.dataGridViewTextBoxColumn1.HeaderText = global::PTIC.Resource.errSelectRowToEdit;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProductID";
            this.dataGridViewTextBoxColumn2.HeaderText = global::PTIC.Resource.errSelectRowToEdit;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn3.HeaderText = global::PTIC.Resource.errSelectRowToEdit;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.DataPropertyName = "TranDate";
            dataGridViewCellStyle32.Format = "dd-MMM-yyyy";
            dataGridViewCellStyle32.NullValue = null;
            this.calendarColumn1.DefaultCellStyle = dataGridViewCellStyle32;
            this.calendarColumn1.HeaderText = "သတ်မှတ်သည့်‌နေ့";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.calendarColumn1.Width = 123;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TranDate";
            this.dataGridViewTextBoxColumn4.HeaderText = global::PTIC.Resource.errSelectRowToEdit;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ProductName";
            this.dataGridViewTextBoxColumn5.HeaderText = global::PTIC.Resource.errSelectRowToEdit;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Weight";
            this.dataGridViewTextBoxColumn6.HeaderText = "အိုးခွံအ‌လေးချိန်";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Qty";
            this.dataGridViewTextBoxColumn7.HeaderText = "အိုးခွံအ‌ရေအတွက်";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Font = new System.Drawing.Font("Myanmar3",9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(12, 544);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 34);
            this.btnNew.TabIndex = 41;
            this.btnNew.Text = "ထည့်မည်";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // TranDate
            // 
            this.TranDate.DataPropertyName = "TranDate";
            dataGridViewCellStyle28.NullValue = null;
            this.TranDate.DefaultCellStyle = dataGridViewCellStyle28;
            this.TranDate.HeaderText = "သတ်မှတ်သည့်‌နေ့";
            this.TranDate.Name = "TranDate";
            this.TranDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TranDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TranDate.Width = 123;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductID";
            this.ProductName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductName.HeaderText = "ထုတ်ကုန်အမည်";
            this.ProductName.Name = "ProductName";
            this.ProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProductName.Width = 200;
            // 
            // BWeight
            // 
            this.BWeight.DataPropertyName = "Weight";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle29.Format = "N2";
            dataGridViewCellStyle29.NullValue = null;
            this.BWeight.DefaultCellStyle = dataGridViewCellStyle29;
            this.BWeight.HeaderText = "အိုးခွံအ‌လေးချိန်";
            this.BWeight.Name = "BWeight";
            this.BWeight.Width = 107;
            // 
            // BQty
            // 
            this.BQty.DataPropertyName = "Qty";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BQty.DefaultCellStyle = dataGridViewCellStyle30;
            this.BQty.HeaderText = "အိုးခွံအ‌ရေအတွက်";
            this.BQty.Name = "BQty";
            this.BQty.Width = 120;
            // 
            // frmBatterySettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(963, 590);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvsetupbsetting);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3",9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(979, 627);
            this.Name = "frmBatterySettings";
            this.Text = "အိုးသစ်နှင့် အိုးခွံသတ်မှတ်ချက်";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetupbsetting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.DataGridView dgvsetupbsetting;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private AGL.UI.Controls.CalendarColumn calendarColumn1;
        private System.Windows.Forms.Button btnNew;
        private AGL.UI.Controls.CalendarColumn TranDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn BQty;

    }
}