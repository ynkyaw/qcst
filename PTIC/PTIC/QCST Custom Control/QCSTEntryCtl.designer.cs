namespace QCST.WinFormControl
{
    partial class QCSTEntryCtl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label23 = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.errorLblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Myanmar3", 11F);
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(138, 20);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 20);
            this.label23.TabIndex = 37;
            this.label23.Text = "*";
            this.label23.Visible = false;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Myanmar3", 11F);
            this.lblText.Location = new System.Drawing.Point(20, 23);
            this.lblText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(81, 20);
            this.lblText.TabIndex = 36;
            this.lblText.Text = "[lblText]";
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Myanmar3", 11F);
            this.txtValue.Location = new System.Drawing.Point(168, 20);
            this.txtValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(185, 27);
            this.txtValue.TabIndex = 35;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            this.txtValue.Leave += new System.EventHandler(this.txtValue_Leave);
            // 
            // errorLblText
            // 
            this.errorLblText.AutoSize = true;
            this.errorLblText.Font = new System.Drawing.Font("Myanmar3", 11F);
            this.errorLblText.ForeColor = System.Drawing.Color.Red;
            this.errorLblText.Location = new System.Drawing.Point(361, 23);
            this.errorLblText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.errorLblText.Name = "errorLblText";
            this.errorLblText.Size = new System.Drawing.Size(121, 20);
            this.errorLblText.TabIndex = 38;
            this.errorLblText.Text = "[errorLblText]";
            this.errorLblText.Visible = false;
            // 
            // QCSTEntryCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.errorLblText);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtValue);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "QCSTEntryCtl";
            this.Size = new System.Drawing.Size(492, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label errorLblText;
    }
}
