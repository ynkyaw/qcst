namespace PTIC.VC.Marketing.A_P
{
    partial class frmPosmPurchasedIn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPosmPurchasedIn = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.calendarColumn1 = new AGL.UI.Controls.CalendarColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchasedDate = new AGL.UI.Controls.CalendarColumn();
            this.colAPSubCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPosm = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresentQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAP_EnquiryDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAP_PurchasedDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosmPurchasedIn)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(10, 12);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(54, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "A && P";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(149)))), ((int)(((byte)(206)))));
            this.lblHeaderPCat.Location = new System.Drawing.Point(69, 12);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(265, 20);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">  POSM Purchase In / Advertising";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel2.Controls.Add(this.lblSetup);
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(998, 44);
            this.panel2.TabIndex = 170;
            // 
            // dgvPosmPurchasedIn
            // 
            this.dgvPosmPurchasedIn.AllowUserToAddRows = false;
            this.dgvPosmPurchasedIn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.dgvPosmPurchasedIn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(175)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPosmPurchasedIn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPosmPurchasedIn.ColumnHeadersHeight = 50;
            this.dgvPosmPurchasedIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPurchasedDate,
            this.colAPSubCategory,
            this.colPosm,
            this.colQuantity,
            this.colPresentQty,
            this.colUnitCost,
            this.colAmount,
            this.colAP_EnquiryDetailID,
            this.colAP_PurchasedDetailID});
            this.dgvPosmPurchasedIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPosmPurchasedIn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPosmPurchasedIn.EnableHeadersVisualStyles = false;
            this.dgvPosmPurchasedIn.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(36)))), ((int)(((byte)(60)))));
            this.dgvPosmPurchasedIn.Location = new System.Drawing.Point(0, 0);
            this.dgvPosmPurchasedIn.Name = "dgvPosmPurchasedIn";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(175)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPosmPurchasedIn.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPosmPurchasedIn.RowHeadersWidth = 50;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvPosmPurchasedIn.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPosmPurchasedIn.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvPosmPurchasedIn.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvPosmPurchasedIn.RowTemplate.Height = 28;
            this.dgvPosmPurchasedIn.Size = new System.Drawing.Size(998, 382);
            this.dgvPosmPurchasedIn.TabIndex = 10;
            this.dgvPosmPurchasedIn.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPosmPurchasedIn_CellBeginEdit);
            this.dgvPosmPurchasedIn.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPosmPurchasedIn_CellEndEdit);
            this.dgvPosmPurchasedIn.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvPosmPurchasedIn_CellValidating);
            this.dgvPosmPurchasedIn.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPosmPurchasedIn_CellValueChanged);
            this.dgvPosmPurchasedIn.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvPosmPurchasedIn_CurrentCellDirtyStateChanged);
            this.dgvPosmPurchasedIn.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPosmPurchasedIn_DataBindingComplete);
            this.dgvPosmPurchasedIn.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvPosmPurchasedIn_DataError);
            this.dgvPosmPurchasedIn.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPosmPurchasedIn_EditingControlShowing);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSave.Location = new System.Drawing.Point(143, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 32);
            this.btnSave.TabIndex = 170;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnDelete.Location = new System.Drawing.Point(270, 8);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(109, 32);
            this.btnDelete.TabIndex = 171;
            this.btnDelete.Text = "ဖျက်မည်";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnNew.Location = new System.Drawing.Point(16, 8);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(109, 32);
            this.btnNew.TabIndex = 172;
            this.btnNew.Text = "ထည့်မည်";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnNew);
            this.pnlFooter.Controls.Add(this.btnDelete);
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 426);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(998, 47);
            this.pnlFooter.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvPosmPurchasedIn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 44);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(998, 382);
            this.panel5.TabIndex = 175;
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.DataPropertyName = "PurchasedDate";
            this.calendarColumn1.HeaderText = "ဝယ်ယူသည့် နေ့စွဲ";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Qty";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.NullValue = "1";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn1.HeaderText = "အေရအတြက္";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 4;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "UnitCost";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.NullValue = "1";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn2.HeaderText = "Unit Cost";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = "1";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn3.HeaderText = "က်သင့္ေငြ";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 13;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "APStockInID";
            this.dataGridViewTextBoxColumn4.HeaderText = "APStockInID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "APStockInDetailID";
            this.dataGridViewTextBoxColumn5.HeaderText = "APStockInDetailID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // colPurchasedDate
            // 
            this.colPurchasedDate.DataPropertyName = "PurchasedDate";
            this.colPurchasedDate.HeaderText = "ဝယ်ယူသည့် နေ့စွဲ";
            this.colPurchasedDate.Name = "colPurchasedDate";
            this.colPurchasedDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPurchasedDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colAPSubCategory
            // 
            this.colAPSubCategory.DataPropertyName = "AP_SubCategoryID";
            this.colAPSubCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colAPSubCategory.HeaderText = "A & P အမျိုးအစားခွဲ";
            this.colAPSubCategory.Name = "colAPSubCategory";
            this.colAPSubCategory.ReadOnly = true;
            this.colAPSubCategory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAPSubCategory.Width = 220;
            // 
            // colPosm
            // 
            this.colPosm.DataPropertyName = "AP_MaterialID";
            this.colPosm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colPosm.HeaderText = "POSM / Advertising";
            this.colPosm.Name = "colPosm";
            this.colPosm.ReadOnly = true;
            this.colPosm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPosm.Width = 220;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "PurchasedQty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQuantity.HeaderText = "Qty / Frequency";
            this.colQuantity.MaxInputLength = 4;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQuantity.Width = 90;
            // 
            // colPresentQty
            // 
            this.colPresentQty.DataPropertyName = "PresentQty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = "0";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colPresentQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPresentQty.HeaderText = "အပိုပေးသည့် Qty";
            this.colPresentQty.Name = "colPresentQty";
            this.colPresentQty.Width = 90;
            // 
            // colUnitCost
            // 
            this.colUnitCost.DataPropertyName = "UnitCost";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colUnitCost.DefaultCellStyle = dataGridViewCellStyle4;
            this.colUnitCost.HeaderText = "ခွင့်ပြုဈေး";
            this.colUnitCost.MaxInputLength = 8;
            this.colUnitCost.Name = "colUnitCost";
            this.colUnitCost.ReadOnly = true;
            this.colUnitCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colUnitCost.Width = 90;
            // 
            // colAmount
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "1";
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.colAmount.HeaderText = "ကျသင့်ငွေ";
            this.colAmount.MaxInputLength = 13;
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAmount.Width = 130;
            // 
            // colAP_EnquiryDetailID
            // 
            this.colAP_EnquiryDetailID.DataPropertyName = "AP_EnquiryDetailID";
            this.colAP_EnquiryDetailID.HeaderText = "AP_EnquiryDetailID";
            this.colAP_EnquiryDetailID.Name = "colAP_EnquiryDetailID";
            this.colAP_EnquiryDetailID.Visible = false;
            // 
            // colAP_PurchasedDetailID
            // 
            this.colAP_PurchasedDetailID.DataPropertyName = "AP_PurchasedDetailID";
            this.colAP_PurchasedDetailID.HeaderText = "AP_PurchasedDetailID";
            this.colAP_PurchasedDetailID.Name = "colAP_PurchasedDetailID";
            this.colAP_PurchasedDetailID.Visible = false;
            // 
            // frmPosmPurchasedIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(998, 473);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmPosmPurchasedIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POSM Purchased In";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosmPurchasedIn)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvPosmPurchasedIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private AGL.UI.Controls.CalendarColumn calendarColumn1;
        private AGL.UI.Controls.CalendarColumn colPurchasedDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAPSubCategory;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPosm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPresentQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAP_EnquiryDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAP_PurchasedDetailID;
    }
}