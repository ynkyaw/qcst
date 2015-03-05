namespace PITC.VC.Marketing
{
    partial class Frm_APProductRegister
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblAPMaterialName = new System.Windows.Forms.Label();
            this.rtxtDescription = new System.Windows.Forms.RichTextBox();
            this.txtAPMaterialName = new System.Windows.Forms.TextBox();
            this.lblAPSubCategory = new System.Windows.Forms.Label();
            this.cboSubCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblSetup = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAPCategory = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 343);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 50);
            this.panel1.TabIndex = 31;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(325, 11);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 31);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "ပိတ်မည်";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(230, 11);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 31);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(27, 262);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(59, 20);
            this.lblDescription.TabIndex = 46;
            this.lblDescription.Text = "မှတ်ချက်";
            // 
            // lblAPMaterialName
            // 
            this.lblAPMaterialName.AutoSize = true;
            this.lblAPMaterialName.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAPMaterialName.Location = new System.Drawing.Point(24, 146);
            this.lblAPMaterialName.Name = "lblAPMaterialName";
            this.lblAPMaterialName.Size = new System.Drawing.Size(89, 20);
            this.lblAPMaterialName.TabIndex = 45;
            this.lblAPMaterialName.Text = "A && P အမည်";
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtDescription.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.rtxtDescription.Location = new System.Drawing.Point(178, 218);
            this.rtxtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtxtDescription.Name = "rtxtDescription";
            this.rtxtDescription.Size = new System.Drawing.Size(234, 115);
            this.rtxtDescription.TabIndex = 4;
            this.rtxtDescription.Text = "";
            // 
            // txtAPMaterialName
            // 
            this.txtAPMaterialName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAPMaterialName.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtAPMaterialName.Location = new System.Drawing.Point(178, 142);
            this.txtAPMaterialName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAPMaterialName.Name = "txtAPMaterialName";
            this.txtAPMaterialName.Size = new System.Drawing.Size(234, 28);
            this.txtAPMaterialName.TabIndex = 2;
            // 
            // lblAPSubCategory
            // 
            this.lblAPSubCategory.AutoSize = true;
            this.lblAPSubCategory.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAPSubCategory.Location = new System.Drawing.Point(26, 106);
            this.lblAPSubCategory.Name = "lblAPSubCategory";
            this.lblAPSubCategory.Size = new System.Drawing.Size(128, 20);
            this.lblAPSubCategory.TabIndex = 42;
            this.lblAPSubCategory.Text = "A && P အမျိုးအစားခွဲ";
            // 
            // cboSubCategory
            // 
            this.cboSubCategory.DisplayMember = "APSubCategoryName";
            this.cboSubCategory.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cboSubCategory.FormattingEnabled = true;
            this.cboSubCategory.Location = new System.Drawing.Point(178, 103);
            this.cboSubCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSubCategory.Name = "cboSubCategory";
            this.cboSubCategory.Size = new System.Drawing.Size(234, 27);
            this.cboSubCategory.TabIndex = 1;
            this.cboSubCategory.ValueMember = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "အရွယ်အစား";
            // 
            // txtSize
            // 
            this.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSize.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.txtSize.Location = new System.Drawing.Point(178, 180);
            this.txtSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(234, 28);
            this.txtSize.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SkyBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblHeaderPCat);
            this.panel4.Controls.Add(this.lblSetup);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(430, 42);
            this.panel4.TabIndex = 51;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Zawgyi-One", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.Black;
            this.lblHeaderPCat.Location = new System.Drawing.Point(67, 10);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(67, 21);
            this.lblHeaderPCat.TabIndex = 48;
            this.lblHeaderPCat.Text = ">  A && P";
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Zawgyi-One", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetup.Location = new System.Drawing.Point(13, 10);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(48, 21);
            this.lblSetup.TabIndex = 47;
            this.lblSetup.TabStop = true;
            this.lblSetup.Text = "Setup";
            this.lblSetup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSetup_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "A && P အမျိုးအစား";
            // 
            // cmbAPCategory
            // 
            this.cmbAPCategory.DisplayMember = "APSubCategoryName";
            this.cmbAPCategory.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbAPCategory.FormattingEnabled = true;
            this.cmbAPCategory.Location = new System.Drawing.Point(178, 68);
            this.cmbAPCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbAPCategory.Name = "cmbAPCategory";
            this.cmbAPCategory.Size = new System.Drawing.Size(234, 27);
            this.cmbAPCategory.TabIndex = 52;
            this.cmbAPCategory.ValueMember = "ID";
            // 
            // Frm_APProductRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 393);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAPCategory);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblAPMaterialName);
            this.Controls.Add(this.rtxtDescription);
            this.Controls.Add(this.txtAPMaterialName);
            this.Controls.Add(this.lblAPSubCategory);
            this.Controls.Add(this.cboSubCategory);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Frm_APProductRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A & P";
            this.Load += new System.EventHandler(this.Frm_APProductRegister_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblAPMaterialName;
        private System.Windows.Forms.RichTextBox rtxtDescription;
        private System.Windows.Forms.TextBox txtAPMaterialName;
        private System.Windows.Forms.Label lblAPSubCategory;
        private System.Windows.Forms.ComboBox cboSubCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.LinkLabel lblSetup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAPCategory;
    }
}