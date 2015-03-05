namespace PTIC.Marketing.MessageInOut
{
    partial class frmMessageInOut
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblMarketing = new System.Windows.Forms.Label();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.rdoOut = new System.Windows.Forms.RadioButton();
            this.rdoIn = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvMessage = new System.Windows.Forms.DataGridView();
            this.colMessageThreadID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmsgOutDate = new AGL.UI.Controls.CalendarColumn();
            this.colMsgNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBody = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSenderAction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSenderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiverID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1324, 41);
            this.panel2.TabIndex = 138;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(117, 9);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(136, 20);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">   ဝင်စာ / ထွက်စာ";
            // 
            // lblMarketing
            // 
            this.lblMarketing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarketing.AutoSize = true;
            this.lblMarketing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMarketing.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblMarketing.Location = new System.Drawing.Point(8, 9);
            this.lblMarketing.Name = "lblMarketing";
            this.lblMarketing.Size = new System.Drawing.Size(111, 20);
            this.lblMarketing.TabIndex = 0;
            this.lblMarketing.Text = "စာဝင် / စာထွက်";
            this.lblMarketing.Click += new System.EventHandler(this.lblMarketing_Click);
            // 
            // pnlFilt
            // 
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 41);
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(1324, 23);
            this.pnlFilt.TabIndex = 206;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.Blue;
            this.lblFilter.Location = new System.Drawing.Point(3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(145, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Advance Search";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.rdoOut);
            this.pnlFilter.Controls.Add(this.rdoIn);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Controls.Add(this.cmbDept);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.dtpEndDate);
            this.pnlFilter.Controls.Add(this.panel1);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Controls.Add(this.dtpStartDate);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 64);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1324, 90);
            this.pnlFilter.TabIndex = 207;
            // 
            // rdoOut
            // 
            this.rdoOut.AutoSize = true;
            this.rdoOut.Location = new System.Drawing.Point(338, 48);
            this.rdoOut.Name = "rdoOut";
            this.rdoOut.Size = new System.Drawing.Size(72, 24);
            this.rdoOut.TabIndex = 189;
            this.rdoOut.Text = "ထွက်စာ";
            this.rdoOut.UseVisualStyleBackColor = true;
            // 
            // rdoIn
            // 
            this.rdoIn.AutoSize = true;
            this.rdoIn.Checked = true;
            this.rdoIn.Location = new System.Drawing.Point(262, 48);
            this.rdoIn.Name = "rdoIn";
            this.rdoIn.Size = new System.Drawing.Size(61, 24);
            this.rdoIn.TabIndex = 188;
            this.rdoIn.TabStop = true;
            this.rdoIn.Text = "ဝင်စာ";
            this.rdoIn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label4.Location = new System.Drawing.Point(258, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 20);
            this.label4.TabIndex = 187;
            this.label4.Text = "ဌာန";
            // 
            // cmbDept
            // 
            this.cmbDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDept.DisplayMember = "ID";
            this.cmbDept.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(311, 12);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(269, 27);
            this.cmbDept.TabIndex = 183;
            this.cmbDept.ValueMember = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label2.Location = new System.Drawing.Point(203, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 176;
            this.label2.Text = "ထိ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label1.Location = new System.Drawing.Point(31, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 175;
            this.label1.Text = "နေ့စွဲ";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(71, 44);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 28);
            this.dtpEndDate.TabIndex = 86;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 176);
            this.panel1.TabIndex = 174;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label3.Location = new System.Drawing.Point(203, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 85;
            this.label3.Text = "မှ";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSearch.Location = new System.Drawing.Point(602, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(71, 8);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 28);
            this.dtpStartDate.TabIndex = 84;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvMessage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 154);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1324, 477);
            this.panel3.TabIndex = 208;
            // 
            // dgvMessage
            // 
            this.dgvMessage.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvMessage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMessage.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMessage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMessageThreadID,
            this.colmsgOutDate,
            this.colMsgNo,
            this.colDescription,
            this.colFromDept,
            this.colToDept,
            this.colBody,
            this.colSenderAction,
            this.colSenderID,
            this.colReceiverID,
            this.colRemark});
            this.dgvMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMessage.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvMessage.Location = new System.Drawing.Point(0, 0);
            this.dgvMessage.MultiSelect = false;
            this.dgvMessage.Name = "dgvMessage";
            this.dgvMessage.RowHeadersWidth = 50;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dgvMessage.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMessage.RowTemplate.Height = 30;
            this.dgvMessage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMessage.Size = new System.Drawing.Size(1324, 477);
            this.dgvMessage.TabIndex = 141;
            this.dgvMessage.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMessage_CellDoubleClick);
            // 
            // colMessageThreadID
            // 
            this.colMessageThreadID.DataPropertyName = "MessageThreadID";
            this.colMessageThreadID.HeaderText = "MessageThreadID";
            this.colMessageThreadID.Name = "colMessageThreadID";
            this.colMessageThreadID.Visible = false;
            // 
            // colmsgOutDate
            // 
            this.colmsgOutDate.DataPropertyName = "Date";
            this.colmsgOutDate.HeaderText = "နေ့စွဲ";
            this.colmsgOutDate.Name = "colmsgOutDate";
            this.colmsgOutDate.ReadOnly = true;
            this.colmsgOutDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colmsgOutDate.Width = 110;
            // 
            // colMsgNo
            // 
            this.colMsgNo.DataPropertyName = "MsgNo";
            this.colMsgNo.HeaderText = "စာအမှတ်";
            this.colMsgNo.Name = "colMsgNo";
            this.colMsgNo.ReadOnly = true;
            this.colMsgNo.Width = 130;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Subject";
            this.colDescription.HeaderText = "အကြောင်းအရာ";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 500;
            // 
            // colFromDept
            // 
            this.colFromDept.DataPropertyName = "FromDept";
            this.colFromDept.HeaderText = "မှ";
            this.colFromDept.Name = "colFromDept";
            this.colFromDept.ReadOnly = true;
            this.colFromDept.Width = 200;
            // 
            // colToDept
            // 
            this.colToDept.DataPropertyName = "ToDept";
            this.colToDept.HeaderText = "သို့";
            this.colToDept.Name = "colToDept";
            this.colToDept.ReadOnly = true;
            this.colToDept.Width = 200;
            // 
            // colBody
            // 
            this.colBody.DataPropertyName = "Body";
            this.colBody.HeaderText = "Body";
            this.colBody.Name = "colBody";
            this.colBody.Visible = false;
            // 
            // colSenderAction
            // 
            this.colSenderAction.DataPropertyName = "SenderAction";
            this.colSenderAction.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colSenderAction.HeaderText = "Action";
            this.colSenderAction.Name = "colSenderAction";
            this.colSenderAction.ReadOnly = true;
            // 
            // colSenderID
            // 
            this.colSenderID.DataPropertyName = "SenderID";
            this.colSenderID.HeaderText = "SenderID";
            this.colSenderID.Name = "colSenderID";
            this.colSenderID.Visible = false;
            // 
            // colReceiverID
            // 
            this.colReceiverID.DataPropertyName = "ReceiverID";
            this.colReceiverID.HeaderText = "ReceiverID";
            this.colReceiverID.Name = "colReceiverID";
            this.colReceiverID.Visible = false;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "Remark";
            this.colRemark.HeaderText = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = false;
            // 
            // frmMessageInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 631);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMessageInOut";
            this.Text = "Message In / Out";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdoOut;
        private System.Windows.Forms.RadioButton rdoIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMessageThreadID;
        private AGL.UI.Controls.CalendarColumn colmsgOutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMsgNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBody;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSenderAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSenderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiverID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;


    }
}