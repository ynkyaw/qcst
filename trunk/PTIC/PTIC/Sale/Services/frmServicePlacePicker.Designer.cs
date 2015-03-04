namespace PTIC.VC.Sale.Services
{
    partial class frmServicePlacePicker
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
            this.cmbVanOrWarehouse = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtTransferOrReturnDate = new System.Windows.Forms.DateTimePicker();
            this.label41 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbVanOrWarehouse
            // 
            this.cmbVanOrWarehouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVanOrWarehouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVanOrWarehouse.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVanOrWarehouse.FormattingEnabled = true;
            this.cmbVanOrWarehouse.Location = new System.Drawing.Point(152, 58);
            this.cmbVanOrWarehouse.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbVanOrWarehouse.Name = "cmbVanOrWarehouse";
            this.cmbVanOrWarehouse.Size = new System.Drawing.Size(174, 25);
            this.cmbVanOrWarehouse.TabIndex = 137;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 17);
            this.label14.TabIndex = 138;
            this.label14.Text = "ပို့မည့်‌နေရာ";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(231, 94);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 139;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtTransferOrReturnDate
            // 
            this.dtTransferOrReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTransferOrReturnDate.Location = new System.Drawing.Point(152, 23);
            this.dtTransferOrReturnDate.Name = "dtTransferOrReturnDate";
            this.dtTransferOrReturnDate.Size = new System.Drawing.Size(174, 26);
            this.dtTransferOrReturnDate.TabIndex = 141;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(12, 28);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(128, 17);
            this.label41.TabIndex = 140;
            this.label41.Text = "Transfer / Return Date";
            // 
            // frmServicePlacePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 139);
            this.Controls.Add(this.dtTransferOrReturnDate);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbVanOrWarehouse);
            this.Font = new System.Drawing.Font("Myanmar3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(16, 144);
            this.Name = "frmServicePlacePicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ပို့မည့်‌နေရာ‌ရွေးခြင်း";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmServicePlacePicker_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbVanOrWarehouse;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtTransferOrReturnDate;
        private System.Windows.Forms.Label label41;
    }
}