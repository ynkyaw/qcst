namespace PTIC.Sale.Setup
{
	partial class frmTripDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.qcstEntryCtl1 = new QCST.WinFormControl.QCSTEntryCtl();
            this.qcstEntryCtl2 = new QCST.WinFormControl.QCSTEntryCtl();
            this.colTownshipInRouteNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvColTownshipID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colTrownshipInRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvsetuptownshipinrout = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetuptownshipinrout)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // qcstEntryCtl1
            // 
            this.qcstEntryCtl1.ErrorLabelText = "ခရီးစဉ်အမည် Must Be Filled";
            this.qcstEntryCtl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qcstEntryCtl1.IsNullorEmpayVlaidate = false;
            this.qcstEntryCtl1.LabelText = "ခရီးစဉ်အမည်";
            this.qcstEntryCtl1.Location = new System.Drawing.Point(-10, 4);
            this.qcstEntryCtl1.Margin = new System.Windows.Forms.Padding(4);
            this.qcstEntryCtl1.Name = "qcstEntryCtl1";
            this.qcstEntryCtl1.Size = new System.Drawing.Size(492, 58);
            this.qcstEntryCtl1.TabIndex = 0;
            this.qcstEntryCtl1.TextBoxText = "";
            // 
            // qcstEntryCtl2
            // 
            this.qcstEntryCtl2.ErrorLabelText = "ကြာမြင့်ရက် Must be Numeric";
            this.qcstEntryCtl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qcstEntryCtl2.IsNullorEmpayVlaidate = false;
            this.qcstEntryCtl2.LabelText = "ကြာမြင့်ရက်";
            this.qcstEntryCtl2.Location = new System.Drawing.Point(-10, 52);
            this.qcstEntryCtl2.Margin = new System.Windows.Forms.Padding(4);
            this.qcstEntryCtl2.Name = "qcstEntryCtl2";
            this.qcstEntryCtl2.Size = new System.Drawing.Size(492, 58);
            this.qcstEntryCtl2.TabIndex = 1;
            this.qcstEntryCtl2.TextBoxText = "";
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
            // dgvColDelete
            // 
            this.dgvColDelete.HeaderText = "Remove";
            this.dgvColDelete.Name = "dgvColDelete";
            this.dgvColDelete.Text = "Remove";
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
            // colTrownshipInRoute
            // 
            this.colTrownshipInRoute.DataPropertyName = "ID";
            this.colTrownshipInRoute.HeaderText = "colTrownshipInRoute";
            this.colTrownshipInRoute.Name = "colTrownshipInRoute";
            this.colTrownshipInRoute.Visible = false;
            // 
            // colRoute
            // 
            this.colRoute.DataPropertyName = "RouteID";
            this.colRoute.HeaderText = "colRoute";
            this.colRoute.Name = "colRoute";
            this.colRoute.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvsetuptownshipinrout);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 294);
            this.panel2.TabIndex = 8;
            // 
            // dgvsetuptownshipinrout
            // 
            this.dgvsetuptownshipinrout.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvsetuptownshipinrout.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvsetuptownshipinrout.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvsetuptownshipinrout.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvsetuptownshipinrout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsetuptownshipinrout.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTrownshipInRoute,
            this.colTownshipInRouteNo,
            this.dgvColTownshipID,
            this.colRoute,
            this.dgvColDelete});
            this.dgvsetuptownshipinrout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvsetuptownshipinrout.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvsetuptownshipinrout.Location = new System.Drawing.Point(0, 0);
            this.dgvsetuptownshipinrout.MultiSelect = false;
            this.dgvsetuptownshipinrout.Name = "dgvsetuptownshipinrout";
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetuptownshipinrout.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvsetuptownshipinrout.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Myanmar3", 9F);
            this.dgvsetuptownshipinrout.RowTemplate.Height = 30;
            this.dgvsetuptownshipinrout.ShowCellToolTips = false;
            this.dgvsetuptownshipinrout.Size = new System.Drawing.Size(582, 294);
            this.dgvsetuptownshipinrout.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 489);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 52);
            this.panel1.TabIndex = 7;
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
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Myanmar3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(157, 117);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(184, 72);
            this.txtRemark.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Remark";
            // 
            // frmTripDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 541);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qcstEntryCtl2);
            this.Controls.Add(this.qcstEntryCtl1);
            this.MaximumSize = new System.Drawing.Size(598, 580);
            this.MinimumSize = new System.Drawing.Size(598, 580);
            this.Name = "frmTripDetails";
            this.Text = "frmTripDetails";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsetuptownshipinrout)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private QCST.WinFormControl.QCSTEntryCtl qcstEntryCtl1;
        private QCST.WinFormControl.QCSTEntryCtl qcstEntryCtl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTownshipInRouteNo;
        private System.Windows.Forms.DataGridViewButtonColumn dgvColDelete;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColTownshipID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrownshipInRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoute;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvsetuptownshipinrout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label1;
	}
}