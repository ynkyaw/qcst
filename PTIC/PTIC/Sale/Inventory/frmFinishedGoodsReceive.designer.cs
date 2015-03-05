namespace PTIC.VC.Sale.Inventory
{
    partial class frmFinishedGoodsReceive
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnApprove = new System.Windows.Forms.Button();
            this.dgvFGReceive = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new AGL.UI.Controls.CalendarColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRequestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProductionDate = new AGL.UI.Controls.CalendarColumn();
            this.clnRequestQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnReceiveQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnFactoryRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFGReqID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFGReceive)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApprove.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.Location = new System.Drawing.Point(12, 522);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(106, 34);
            this.btnApprove.TabIndex = 27;
            this.btnApprove.Text = "အတည်ပြုမည်";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // dgvFGReceive
            // 
            this.dgvFGReceive.AllowUserToAddRows = false;
            this.dgvFGReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFGReceive.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFGReceive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFGReceive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFGReceive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnRequestNo,
            this.clnProductName,
            this.clnProductionDate,
            this.clnRequestQty,
            this.clnReceiveQty,
            this.clnFactoryRemark,
            this.colProductID,
            this.colFGReqID});
            this.dgvFGReceive.Location = new System.Drawing.Point(12, 89);
            this.dgvFGReceive.Name = "dgvFGReceive";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFGReceive.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFGReceive.RowHeadersWidth = 50;
            this.dgvFGReceive.RowTemplate.Height = 28;
            this.dgvFGReceive.Size = new System.Drawing.Size(890, 427);
            this.dgvFGReceive.TabIndex = 25;
            this.dgvFGReceive.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFGReceive_CellEndEdit);
            this.dgvFGReceive.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvFGReceive_CellValidating);
            this.dgvFGReceive.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvFGReceive_DataError);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrint.Enabled = false;
            this.btnPrint.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(167, 522);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 34);
            this.btnPrint.TabIndex = 26;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(52, 56);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(139, 28);
            this.dtpDate.TabIndex = 24;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "‌နေ့စွဲ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblSetup);
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(912, 46);
            this.panel2.TabIndex = 66;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(12, 11);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(165, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "ကုန်ပစ္စည်း အဝင်/အထွက်";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(164, 11);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(222, 20);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">    စက်ရုံမှ ပစ္စည်းလက်ခံရရှိခြင်း";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ReqVouNo";
            this.dataGridViewTextBoxColumn1.HeaderText = "ပစ္စည်း‌တောင်းခံသည့် Voucher No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProductName";
            this.dataGridViewTextBoxColumn2.HeaderText = "ထုတ်ကုန်အမည်";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.DataPropertyName = "ProduceDate";
            this.calendarColumn1.HeaderText = "ထုတ်လုပ်သည့် ‌နေ့စွဲ";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Qty";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.HeaderText = "‌တောင်းခံသည့် အ‌ရေအတွက်";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "IssueQty";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn4.HeaderText = "စက်ရုံမှ‌ပေးနိုင်သည့် အ‌ရေအတွက်";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ReceiveRemark";
            this.dataGridViewTextBoxColumn5.HeaderText = "စက်ရုံမှ မှတ်ချက်";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ProductID";
            this.dataGridViewTextBoxColumn6.HeaderText = "ProductID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FGRequestID";
            this.dataGridViewTextBoxColumn7.HeaderText = "FGRequestID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // clnRequestNo
            // 
            this.clnRequestNo.DataPropertyName = "ReqVouNo";
            this.clnRequestNo.HeaderText = "ပစ္စည်း‌တောင်းခံသည့် Voucher No";
            this.clnRequestNo.Name = "clnRequestNo";
            this.clnRequestNo.Visible = false;
            this.clnRequestNo.Width = 120;
            // 
            // clnProductName
            // 
            this.clnProductName.DataPropertyName = "ProductName";
            this.clnProductName.HeaderText = "ထုတ်ကုန်အမည်";
            this.clnProductName.Name = "clnProductName";
            this.clnProductName.ReadOnly = true;
            this.clnProductName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnProductName.Width = 150;
            // 
            // clnProductionDate
            // 
            this.clnProductionDate.DataPropertyName = "ProduceDate";
            this.clnProductionDate.HeaderText = "ထုတ်လုပ်သည့် ‌နေ့စွဲ";
            this.clnProductionDate.Name = "clnProductionDate";
            this.clnProductionDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnProductionDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clnRequestQty
            // 
            this.clnRequestQty.DataPropertyName = "Qty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clnRequestQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.clnRequestQty.HeaderText = "‌တောင်းခံသည့် အ‌ရေအတွက်";
            this.clnRequestQty.Name = "clnRequestQty";
            this.clnRequestQty.ReadOnly = true;
            // 
            // clnReceiveQty
            // 
            this.clnReceiveQty.DataPropertyName = "IssueQty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clnReceiveQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.clnReceiveQty.HeaderText = "စက်ရုံမှ‌ပေးနိုင်သည့် အ‌ရေအတွက်";
            this.clnReceiveQty.Name = "clnReceiveQty";
            this.clnReceiveQty.Width = 120;
            // 
            // clnFactoryRemark
            // 
            this.clnFactoryRemark.DataPropertyName = "ReceiveRemark";
            this.clnFactoryRemark.HeaderText = "စက်ရုံမှ မှတ်ချက်";
            this.clnFactoryRemark.Name = "clnFactoryRemark";
            this.clnFactoryRemark.Width = 200;
            // 
            // colProductID
            // 
            this.colProductID.DataPropertyName = "ProductID";
            this.colProductID.HeaderText = "ProductID";
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = false;
            // 
            // colFGReqID
            // 
            this.colFGReqID.DataPropertyName = "FGRequestID";
            this.colFGReqID.HeaderText = "FGRequestID";
            this.colFGReqID.Name = "colFGReqID";
            this.colFGReqID.Visible = false;
            // 
            // frmFinishedGoodsReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 562);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.dgvFGReceive);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmFinishedGoodsReceive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "စက်ရုံမှ ပစ္စည်းလက်ခံရရှိခြင်း";
            this.Load += new System.EventHandler(this.frmFinishedGoodsReceive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFGReceive)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.DataGridView dgvFGReceive;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRequestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductName;
        private AGL.UI.Controls.CalendarColumn clnProductionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRequestQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnReceiveQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFactoryRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFGReqID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private AGL.UI.Controls.CalendarColumn calendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

    }
}