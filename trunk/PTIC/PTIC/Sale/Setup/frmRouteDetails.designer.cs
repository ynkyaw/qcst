namespace PTIC.Sale.Setup
{
    partial class frmRouteDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvsetuptownshipinrout = new System.Windows.Forms.DataGridView();
            this.colTrownshipInRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTownshipInRouteNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColTownshipID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.qcstEntryCtl1 = new QCST.WinFormControl.QCSTEntryCtl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetuptownshipinrout)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Myanmar3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(129, 80);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(184, 72);
            this.txtRemark.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 52);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Myanmar3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(129, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "ပိတ်မည်";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(27, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvsetuptownshipinrout);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 158);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(523, 318);
            this.panel2.TabIndex = 4;
            // 
            // dgvsetuptownshipinrout
            // 
            this.dgvsetuptownshipinrout.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvsetuptownshipinrout.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvsetuptownshipinrout.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvsetuptownshipinrout.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvsetuptownshipinrout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsetuptownshipinrout.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTrownshipInRoute,
            this.colTownshipInRouteNo,
            this.dgvColTownshipID,
            this.colRoute,
            this.dgvColDelete});
            this.dgvsetuptownshipinrout.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvsetuptownshipinrout.Location = new System.Drawing.Point(0, 0);
            this.dgvsetuptownshipinrout.MultiSelect = false;
            this.dgvsetuptownshipinrout.Name = "dgvsetuptownshipinrout";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetuptownshipinrout.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvsetuptownshipinrout.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetuptownshipinrout.RowTemplate.Height = 30;
            this.dgvsetuptownshipinrout.ShowCellToolTips = false;
            this.dgvsetuptownshipinrout.Size = new System.Drawing.Size(523, 318);
            this.dgvsetuptownshipinrout.TabIndex = 0;
            this.dgvsetuptownshipinrout.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvsetuptownshipinrout_CellContentClick);
            this.dgvsetuptownshipinrout.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvsetuptownshipinrout_CellValidating);
            this.dgvsetuptownshipinrout.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvsetuptownshipinrout_RowPostPaint);
            // 
            // colTrownshipInRoute
            // 
            this.colTrownshipInRoute.DataPropertyName = "ID";
            this.colTrownshipInRoute.HeaderText = "colTrownshipInRoute";
            this.colTrownshipInRoute.Name = "colTrownshipInRoute";
            this.colTrownshipInRoute.Visible = false;
            // 
            // colTownshipInRouteNo
            // 
            this.colTownshipInRouteNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTownshipInRouteNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTownshipInRouteNo.HeaderText = "စဉ်";
            this.colTownshipInRouteNo.Name = "colTownshipInRouteNo";
            this.colTownshipInRouteNo.ReadOnly = true;
            this.colTownshipInRouteNo.Width = 47;
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
            // colRoute
            // 
            this.colRoute.DataPropertyName = "RouteID";
            this.colRoute.HeaderText = "colRoute";
            this.colRoute.Name = "colRoute";
            this.colRoute.Visible = false;
            // 
            // dgvColDelete
            // 
            this.dgvColDelete.HeaderText = "Remove";
            this.dgvColDelete.Name = "dgvColDelete";
            this.dgvColDelete.Text = "Remove";
            // 
            // qcstEntryCtl1
            // 
            this.qcstEntryCtl1.ErrorLabelText = "လမ်း‌ကြောင်း Must be Filled.";
            this.qcstEntryCtl1.Font = new System.Drawing.Font("Myanmar3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qcstEntryCtl1.IsNullorEmpayVlaidate = true;
            this.qcstEntryCtl1.LabelText = "လမ်း‌ကြောင်း";
            this.qcstEntryCtl1.Location = new System.Drawing.Point(3, 14);
            this.qcstEntryCtl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.qcstEntryCtl1.Name = "qcstEntryCtl1";
            this.qcstEntryCtl1.Size = new System.Drawing.Size(500, 58);
            this.qcstEntryCtl1.TabIndex = 0;
            this.qcstEntryCtl1.TextBoxText = "";
            // 
            // frmRouteDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 528);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qcstEntryCtl1);
            this.Name = "frmRouteDetails";
            this.Tag = "1";
            this.Text = "လမ်း‌ကြောင်း Details";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetuptownshipinrout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QCST.WinFormControl.QCSTEntryCtl qcstEntryCtl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvsetuptownshipinrout;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrownshipInRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownshipInRouteNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColTownshipID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoute;
        private System.Windows.Forms.DataGridViewButtonColumn dgvColDelete;
    }
}