namespace PTIC.VC.Sale.OfficeSales
{
    partial class frmTax
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.cmbGate = new System.Windows.Forms.ComboBox();
            this.btnImage = new System.Windows.Forms.Button();
            this.picGateInvoice = new System.Windows.Forms.PictureBox();
            this.cmbTransportType = new System.Windows.Forms.ComboBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTransportInvNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalTaxAmt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTransportCharge = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTaxAmt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInsuranceAmt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSalesAmt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGateInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.cmbGate);
            this.panel1.Controls.Add(this.btnImage);
            this.panel1.Controls.Add(this.picGateInvoice);
            this.panel1.Controls.Add(this.cmbTransportType);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnApprove);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtTransportInvNo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtTotalTaxAmt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtTransportCharge);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtTaxAmt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtInsuranceAmt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSalesAmt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtInvoiceNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(678, 351);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SkyBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblSetup);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(678, 44);
            this.panel3.TabIndex = 208;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(11, 11);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(132, 20);
            this.lblSetup.TabIndex = 3;
            this.lblSetup.Text = "အခြားကုန်ကျစရိတ်";
            // 
            // cmbGate
            // 
            this.cmbGate.DisplayMember = "GateName";
            this.cmbGate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGate.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGate.FormattingEnabled = true;
            this.cmbGate.Location = new System.Drawing.Point(532, 156);
            this.cmbGate.Name = "cmbGate";
            this.cmbGate.Size = new System.Drawing.Size(120, 27);
            this.cmbGate.TabIndex = 6;
            this.cmbGate.ValueMember = "TransportGateID";
            // 
            // btnImage
            // 
            this.btnImage.Enabled = false;
            this.btnImage.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImage.Location = new System.Drawing.Point(393, 221);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(75, 30);
            this.btnImage.TabIndex = 206;
            this.btnImage.Text = "Upload ";
            this.btnImage.UseVisualStyleBackColor = true;
            // 
            // picGateInvoice
            // 
            this.picGateInvoice.Location = new System.Drawing.Point(532, 200);
            this.picGateInvoice.Name = "picGateInvoice";
            this.picGateInvoice.Size = new System.Drawing.Size(122, 139);
            this.picGateInvoice.TabIndex = 205;
            this.picGateInvoice.TabStop = false;
            // 
            // cmbTransportType
            // 
            this.cmbTransportType.DisplayMember = "TransportTypeName";
            this.cmbTransportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransportType.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTransportType.FormattingEnabled = true;
            this.cmbTransportType.Location = new System.Drawing.Point(532, 125);
            this.cmbTransportType.Name = "cmbTransportType";
            this.cmbTransportType.Size = new System.Drawing.Size(120, 27);
            this.cmbTransportType.TabIndex = 5;
            this.cmbTransportType.ValueMember = "TransportTypeID";
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(246, 310);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 34);
            this.btnEdit.TabIndex = 201;
            this.btnEdit.Text = "ပြင်မည်";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(132, 310);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 34);
            this.btnPrint.TabIndex = 200;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.Location = new System.Drawing.Point(18, 310);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(97, 34);
            this.btnApprove.TabIndex = 7;
            this.btnApprove.Text = "အတည်ပြုမည်";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(294, 221);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 20);
            this.label19.TabIndex = 194;
            this.label19.Text = "ကျပ်";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(293, 191);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 20);
            this.label17.TabIndex = 192;
            this.label17.Text = "ကျပ်";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(294, 160);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 20);
            this.label16.TabIndex = 191;
            this.label16.Text = "ကျပ်";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(294, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 20);
            this.label15.TabIndex = 190;
            this.label15.Text = "ကျပ်";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(294, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 20);
            this.label14.TabIndex = 189;
            this.label14.Text = "ကျပ်";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Enabled = false;
            this.dtpDate.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(532, 66);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(121, 28);
            this.dtpDate.TabIndex = 166;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(360, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 20);
            this.label12.TabIndex = 185;
            this.label12.Text = "ပို့‌ဆောင်သည့်ဂိတ်";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(360, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 184;
            this.label9.Text = "ပို့ဆောင်သည့်စနစ်";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(360, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 20);
            this.label10.TabIndex = 183;
            this.label10.Text = "‌နေ့စွဲ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(360, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 20);
            this.label7.TabIndex = 181;
            this.label7.Text = "ပို့‌ဆောင်သည့်‌ပြေစာပုံ";
            // 
            // txtTransportInvNo
            // 
            this.txtTransportInvNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransportInvNo.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransportInvNo.Location = new System.Drawing.Point(532, 97);
            this.txtTransportInvNo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtTransportInvNo.Name = "txtTransportInvNo";
            this.txtTransportInvNo.Size = new System.Drawing.Size(120, 28);
            this.txtTransportInvNo.TabIndex = 4;
            this.txtTransportInvNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(360, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 20);
            this.label8.TabIndex = 179;
            this.label8.Text = "ပို့‌ဆောင်သည့်‌ပြေစာနံပါတ်";
            // 
            // txtTotalTaxAmt
            // 
            this.txtTotalTaxAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalTaxAmt.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalTaxAmt.Location = new System.Drawing.Point(151, 217);
            this.txtTotalTaxAmt.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtTotalTaxAmt.Name = "txtTotalTaxAmt";
            this.txtTotalTaxAmt.ReadOnly = true;
            this.txtTotalTaxAmt.Size = new System.Drawing.Size(137, 28);
            this.txtTotalTaxAmt.TabIndex = 3;
            this.txtTotalTaxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalTaxAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 177;
            this.label5.Text = "စုစု‌ပေါင်းကျသင့်‌ငွေ";
            // 
            // txtTransportCharge
            // 
            this.txtTransportCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransportCharge.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransportCharge.Location = new System.Drawing.Point(151, 187);
            this.txtTransportCharge.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtTransportCharge.Name = "txtTransportCharge";
            this.txtTransportCharge.Size = new System.Drawing.Size(137, 28);
            this.txtTransportCharge.TabIndex = 2;
            this.txtTransportCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTransportCharge.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtTransportCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 20);
            this.label6.TabIndex = 175;
            this.label6.Text = "ပို့ဆောင်မှုကျသင့်‌ငွေ";
            // 
            // txtTaxAmt
            // 
            this.txtTaxAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxAmt.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxAmt.Location = new System.Drawing.Point(151, 157);
            this.txtTaxAmt.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtTaxAmt.Name = "txtTaxAmt";
            this.txtTaxAmt.Size = new System.Drawing.Size(137, 28);
            this.txtTaxAmt.TabIndex = 1;
            this.txtTaxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTaxAmt.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtTaxAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 173;
            this.label3.Text = "အခွန်ကျသင့်‌ငွေ";
            // 
            // txtInsuranceAmt
            // 
            this.txtInsuranceAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInsuranceAmt.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInsuranceAmt.Location = new System.Drawing.Point(151, 127);
            this.txtInsuranceAmt.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtInsuranceAmt.Name = "txtInsuranceAmt";
            this.txtInsuranceAmt.Size = new System.Drawing.Size(137, 28);
            this.txtInsuranceAmt.TabIndex = 0;
            this.txtInsuranceAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInsuranceAmt.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtInsuranceAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 171;
            this.label4.Text = "အာမခံ‌ကြေးကျသင့်‌ငွေ";
            // 
            // txtSalesAmt
            // 
            this.txtSalesAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesAmt.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesAmt.Location = new System.Drawing.Point(151, 97);
            this.txtSalesAmt.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtSalesAmt.Name = "txtSalesAmt";
            this.txtSalesAmt.ReadOnly = true;
            this.txtSalesAmt.Size = new System.Drawing.Size(137, 28);
            this.txtSalesAmt.TabIndex = 170;
            this.txtSalesAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 169;
            this.label2.Text = "အ‌ရောင်းကျသင့်‌ငွေ";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(151, 67);
            this.txtInvoiceNo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.ReadOnly = true;
            this.txtInvoiceNo.Size = new System.Drawing.Size(137, 28);
            this.txtInvoiceNo.TabIndex = 168;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 167;
            this.label1.Text = "Invoice No.";
            // 
            // frmTax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 351);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.Name = "frmTax";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "အခြားကုန်ကျစရိတ်";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTax_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGateInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTransportInvNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalTaxAmt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTransportCharge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTaxAmt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInsuranceAmt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSalesAmt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTransportType;
        private System.Windows.Forms.Button btnImage;
        private System.Windows.Forms.PictureBox picGateInvoice;
        private System.Windows.Forms.ComboBox cmbGate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSetup;
    }
}