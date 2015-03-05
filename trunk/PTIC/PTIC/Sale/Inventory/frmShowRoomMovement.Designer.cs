namespace PTIC.VC.Sale.Inventory
{
    partial class frmShowRoomMovement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.dgvShowRoomMovement = new System.Windows.Forms.DataGridView();
            this.colProductID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceivedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colShowRoomMovementID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeliver = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReceived = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cmbSalePerson = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbDeliverShowRoom = new System.Windows.Forms.ComboBox();
            this.cmbReceivedShowRoom = new System.Windows.Forms.ComboBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbVen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowRoomMovement)).BeginInit();
            this.SuspendLayout();
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
            this.panel2.Size = new System.Drawing.Size(733, 46);
            this.panel2.TabIndex = 67;
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
            this.lblHeaderPCat.Size = new System.Drawing.Size(255, 20);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">    ShowRoom Request / Receive";
            // 
            // dgvShowRoomMovement
            // 
            this.dgvShowRoomMovement.AllowUserToAddRows = false;
            this.dgvShowRoomMovement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShowRoomMovement.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowRoomMovement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShowRoomMovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowRoomMovement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductID,
            this.colRequest,
            this.colQty,
            this.colReceivedQty,
            this.colStatus,
            this.colShowRoomMovementID});
            this.dgvShowRoomMovement.Location = new System.Drawing.Point(12, 165);
            this.dgvShowRoomMovement.Name = "dgvShowRoomMovement";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowRoomMovement.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvShowRoomMovement.RowHeadersWidth = 50;
            this.dgvShowRoomMovement.RowTemplate.Height = 28;
            this.dgvShowRoomMovement.Size = new System.Drawing.Size(709, 363);
            this.dgvShowRoomMovement.TabIndex = 26;
            this.dgvShowRoomMovement.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShowRoomMovement_CellEndEdit);
            this.dgvShowRoomMovement.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvShowRoomMovement_CellValidating);
            this.dgvShowRoomMovement.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvShowRoomMovement_DataBindingComplete);
            this.dgvShowRoomMovement.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvShowRoomMovement_DataError);
            // 
            // colProductID
            // 
            this.colProductID.DataPropertyName = "ProductID";
            this.colProductID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colProductID.HeaderText = "ထုတ်ကုန်အမည်";
            this.colProductID.Name = "colProductID";
            this.colProductID.Width = 170;
            // 
            // colRequest
            // 
            this.colRequest.DataPropertyName = "RequestQty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colRequest.DefaultCellStyle = dataGridViewCellStyle2;
            this.colRequest.HeaderText = "‌တောင်းခံသည့် အ‌ရေအတွက်";
            this.colRequest.Name = "colRequest";
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "DeliverQty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colQty.HeaderText = "ပို့မည့်အ‌ရေအတွက်";
            this.colQty.Name = "colQty";
            this.colQty.Width = 130;
            // 
            // colReceivedQty
            // 
            this.colReceivedQty.DataPropertyName = "ReceivedQty";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colReceivedQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.colReceivedQty.HeaderText = "လက်ခံရရှိသည့် အ‌ရေအတွက်";
            this.colReceivedQty.Name = "colReceivedQty";
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Received";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colShowRoomMovementID
            // 
            this.colShowRoomMovementID.DataPropertyName = "ID";
            this.colShowRoomMovementID.HeaderText = "ShowRoomMovementID";
            this.colShowRoomMovementID.Name = "colShowRoomMovementID";
            this.colShowRoomMovementID.Visible = false;
            // 
            // btnDeliver
            // 
            this.btnDeliver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeliver.Font = new System.Drawing.Font("Myanmar3",10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeliver.Location = new System.Drawing.Point(12, 544);
            this.btnDeliver.Name = "btnDeliver";
            this.btnDeliver.Size = new System.Drawing.Size(95, 34);
            this.btnDeliver.TabIndex = 28;
            this.btnDeliver.Text = "ပို့မည်";
            this.btnDeliver.UseVisualStyleBackColor = true;
            this.btnDeliver.Click += new System.EventHandler(this.btnDeliver_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "ပို့ရမည့်‌နေ့စွဲ";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(192, 55);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(139, 28);
            this.dtpDate.TabIndex = 30;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(344, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 20);
            this.label6.TabIndex = 146;
            this.label6.Text = "ပို့မည့် ShowRoom အမည်";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(344, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 20);
            this.label1.TabIndex = 148;
            this.label1.Text = "လက်ခံမည့် ShowRoom အမည်\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(681, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 150;
            this.label3.Text = "မှ";
            // 
            // btnReceived
            // 
            this.btnReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReceived.Enabled = false;
            this.btnReceived.Font = new System.Drawing.Font("Myanmar3",10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceived.Location = new System.Drawing.Point(123, 544);
            this.btnReceived.Name = "btnReceived";
            this.btnReceived.Size = new System.Drawing.Size(95, 34);
            this.btnReceived.TabIndex = 151;
            this.btnReceived.Text = "လက်ခံမည်";
            this.btnReceived.UseVisualStyleBackColor = true;
            this.btnReceived.Click += new System.EventHandler(this.btnReceived_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Font = new System.Drawing.Font("Myanmar3",10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(234, 544);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 34);
            this.btnPrint.TabIndex = 152;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // cmbSalePerson
            // 
            this.cmbSalePerson.DisplayMember = "EmpName";
            this.cmbSalePerson.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalePerson.FormattingEnabled = true;
            this.cmbSalePerson.Location = new System.Drawing.Point(190, 90);
            this.cmbSalePerson.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbSalePerson.Name = "cmbSalePerson";
            this.cmbSalePerson.Size = new System.Drawing.Size(139, 27);
            this.cmbSalePerson.TabIndex = 154;
            this.cmbSalePerson.ValueMember = "EmployeeID";
            this.cmbSalePerson.SelectedIndexChanged += new System.EventHandler(this.cmbSalePerson_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(141, 20);
            this.label12.TabIndex = 153;
            this.label12.Text = "အ‌ရောင်းဝန်ထမ်းအမည်";
            // 
            // cmbDeliverShowRoom
            // 
            this.cmbDeliverShowRoom.DisplayMember = "Warehouse";
            this.cmbDeliverShowRoom.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDeliverShowRoom.FormattingEnabled = true;
            this.cmbDeliverShowRoom.Location = new System.Drawing.Point(536, 57);
            this.cmbDeliverShowRoom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbDeliverShowRoom.Name = "cmbDeliverShowRoom";
            this.cmbDeliverShowRoom.Size = new System.Drawing.Size(139, 27);
            this.cmbDeliverShowRoom.TabIndex = 155;
            this.cmbDeliverShowRoom.ValueMember = "ID";
            this.cmbDeliverShowRoom.SelectedIndexChanged += new System.EventHandler(this.cmbDeliverShowRoom_SelectedIndexChanged);
            // 
            // cmbReceivedShowRoom
            // 
            this.cmbReceivedShowRoom.DisplayMember = "Warehouse";
            this.cmbReceivedShowRoom.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReceivedShowRoom.FormattingEnabled = true;
            this.cmbReceivedShowRoom.Location = new System.Drawing.Point(536, 90);
            this.cmbReceivedShowRoom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbReceivedShowRoom.Name = "cmbReceivedShowRoom";
            this.cmbReceivedShowRoom.Size = new System.Drawing.Size(139, 27);
            this.cmbReceivedShowRoom.TabIndex = 156;
            this.cmbReceivedShowRoom.ValueMember = "ID";
            this.cmbReceivedShowRoom.SelectedIndexChanged += new System.EventHandler(this.cmbReceivedShowRoom_SelectedIndexChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "ပို့မည့်အ‌ရေအတွက်";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 130;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(681, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 20);
            this.label4.TabIndex = 157;
            this.label4.Text = "သို့";
            // 
            // cmbVen
            // 
            this.cmbVen.DisplayMember = "VenNo";
            this.cmbVen.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVen.FormattingEnabled = true;
            this.cmbVen.Location = new System.Drawing.Point(190, 126);
            this.cmbVen.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbVen.Name = "cmbVen";
            this.cmbVen.Size = new System.Drawing.Size(139, 27);
            this.cmbVen.TabIndex = 159;
            this.cmbVen.ValueMember = "VehicleID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 20);
            this.label5.TabIndex = 158;
            this.label5.Text = "သယ်မည့် အ‌ရောင်းကားနံပါတ်";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(584, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 28);
            this.button1.TabIndex = 160;
            this.button1.Text = "ရှာမည်";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmShowRoomMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 590);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbVen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbReceivedShowRoom);
            this.Controls.Add(this.cmbDeliverShowRoom);
            this.Controls.Add(this.cmbSalePerson);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReceived);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnDeliver);
            this.Controls.Add(this.dgvShowRoomMovement);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(663, 627);
            this.Name = "frmShowRoomMovement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowRoom Request / Receive";
            this.Load += new System.EventHandler(this.frmShowRoomMovement_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowRoomMovement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.DataGridView dgvShowRoomMovement;
        private System.Windows.Forms.Button btnDeliver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReceived;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cmbSalePerson;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbDeliverShowRoom;
        private System.Windows.Forms.ComboBox cmbReceivedShowRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbVen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewComboBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceivedQty;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShowRoomMovementID;
    }
}