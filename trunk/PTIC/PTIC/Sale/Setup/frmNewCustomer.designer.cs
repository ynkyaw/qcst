namespace PTIC.VC.Sale.Setup
{
    partial class frmNewCustomer
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpCusDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCusType = new System.Windows.Forms.ComboBox();
            this.cmbTown = new System.Windows.Forms.ComboBox();
            this.cmbTownship = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPh2 = new System.Windows.Forms.TextBox();
            this.txtPh1 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtContactPersonName = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 399);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(295, 361);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpCusDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbCusType);
            this.groupBox1.Controls.Add(this.cmbTown);
            this.groupBox1.Controls.Add(this.cmbTownship);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPh2);
            this.groupBox1.Controls.Add(this.txtPh1);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.txtContactPersonName);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(17, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 329);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Customer Information";
            // 
            // dtpCusDate
            // 
            this.dtpCusDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpCusDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCusDate.Location = new System.Drawing.Point(178, 285);
            this.dtpCusDate.Name = "dtpCusDate";
            this.dtpCusDate.Size = new System.Drawing.Size(200, 28);
            this.dtpCusDate.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label5.Location = new System.Drawing.Point(21, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 20);
            this.label5.TabIndex = 57;
            this.label5.Text = "Customer ဖြစ်သည့်နေ့";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label3.Location = new System.Drawing.Point(21, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 56;
            this.label3.Text = "Customer အမျိုးအစား";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmbCusType
            // 
            this.cmbCusType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCusType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCusType.DisplayMember = "Township";
            this.cmbCusType.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbCusType.FormattingEnabled = true;
            this.cmbCusType.Location = new System.Drawing.Point(178, 250);
            this.cmbCusType.Name = "cmbCusType";
            this.cmbCusType.Size = new System.Drawing.Size(200, 27);
            this.cmbCusType.TabIndex = 6;
            this.cmbCusType.ValueMember = "TownshipID";
            this.cmbCusType.SelectedIndexChanged += new System.EventHandler(this.cmbCusType_SelectedIndexChanged);
            // 
            // cmbTown
            // 
            this.cmbTown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTown.DisplayMember = "Town";
            this.cmbTown.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbTown.FormattingEnabled = true;
            this.cmbTown.Location = new System.Drawing.Point(178, 180);
            this.cmbTown.Name = "cmbTown";
            this.cmbTown.Size = new System.Drawing.Size(200, 27);
            this.cmbTown.TabIndex = 4;
            this.cmbTown.ValueMember = "TownID";
            this.cmbTown.SelectedIndexChanged += new System.EventHandler(this.cmbTown_SelectedIndexChanged);
            // 
            // cmbTownship
            // 
            this.cmbTownship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTownship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTownship.DisplayMember = "Township";
            this.cmbTownship.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbTownship.FormattingEnabled = true;
            this.cmbTownship.Location = new System.Drawing.Point(178, 215);
            this.cmbTownship.Name = "cmbTownship";
            this.cmbTownship.Size = new System.Drawing.Size(200, 27);
            this.cmbTownship.TabIndex = 5;
            this.cmbTownship.ValueMember = "TownshipID";
            this.cmbTownship.SelectedIndexChanged += new System.EventHandler(this.cmbTownship_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label2.Location = new System.Drawing.Point(22, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "Customer မြို့နယ်";
            // 
            // txtPh2
            // 
            this.txtPh2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPh2.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtPh2.Location = new System.Drawing.Point(178, 144);
            this.txtPh2.Name = "txtPh2";
            this.txtPh2.Size = new System.Drawing.Size(200, 28);
            this.txtPh2.TabIndex = 3;
            this.txtPh2.TextChanged += new System.EventHandler(this.txtPh2_TextChanged);
            // 
            // txtPh1
            // 
            this.txtPh1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPh1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtPh1.Location = new System.Drawing.Point(178, 108);
            this.txtPh1.Name = "txtPh1";
            this.txtPh1.Size = new System.Drawing.Size(200, 28);
            this.txtPh1.TabIndex = 2;
            this.txtPh1.TextChanged += new System.EventHandler(this.txtPh1_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label24.Location = new System.Drawing.Point(22, 146);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(149, 20);
            this.label24.TabIndex = 47;
            this.label24.Text = "Customer ဖုန်းနံပါတ်(၂)";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label27.Location = new System.Drawing.Point(20, 110);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(150, 20);
            this.label27.TabIndex = 48;
            this.label27.Text = "Customer ဖုန်းနံပါတ်(၁)";
            // 
            // txtContactPersonName
            // 
            this.txtContactPersonName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactPersonName.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtContactPersonName.Location = new System.Drawing.Point(178, 72);
            this.txtContactPersonName.Name = "txtContactPersonName";
            this.txtContactPersonName.Size = new System.Drawing.Size(200, 28);
            this.txtContactPersonName.TabIndex = 1;
            this.txtContactPersonName.TextChanged += new System.EventHandler(this.txtContactPersonName_TextChanged);
            this.txtContactPersonName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            this.txtContactPersonName.Validated += new System.EventHandler(this.txtBox_Validated);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtCustomerName.Location = new System.Drawing.Point(178, 36);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(200, 28);
            this.txtCustomerName.TabIndex = 0;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            this.txtCustomerName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            this.txtCustomerName.Validated += new System.EventHandler(this.txtBox_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Custome အမည်";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label13.Location = new System.Drawing.Point(21, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(149, 20);
            this.label13.TabIndex = 46;
            this.label13.Text = "ဆက်သွယ်ရမည့်သူအမည်";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label4.Location = new System.Drawing.Point(22, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "Customer မြို့";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmNewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 399);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Customer";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPh2;
        private System.Windows.Forms.TextBox txtPh1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtContactPersonName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTown;
        private System.Windows.Forms.ComboBox cmbTownship;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCusType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpCusDate;
    }
}