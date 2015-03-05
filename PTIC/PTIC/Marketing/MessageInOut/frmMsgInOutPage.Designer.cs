namespace PTIC.Marketing.MessageInOut
{
    partial class frmMsgInOutPage
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMarketing = new System.Windows.Forms.Label();
            this.btnComposeMsg = new System.Windows.Forms.Button();
            this.btnMsgInOutRecord = new System.Windows.Forms.Button();
            this.btnMsgInOut = new System.Windows.Forms.Button();
            this.btnDeptToDeptConfirm = new System.Windows.Forms.Button();
            this.btnExternalComposeMsg = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(988, 41);
            this.panel2.TabIndex = 136;
            // 
            // lblMarketing
            // 
            this.lblMarketing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarketing.AutoSize = true;
            this.lblMarketing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMarketing.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarketing.Location = new System.Drawing.Point(8, 9);
            this.lblMarketing.Name = "lblMarketing";
            this.lblMarketing.Size = new System.Drawing.Size(103, 19);
            this.lblMarketing.TabIndex = 0;
            this.lblMarketing.Text = "စာဝင် / စာထွက်";
            // 
            // btnComposeMsg
            // 
            this.btnComposeMsg.Location = new System.Drawing.Point(40, 90);
            this.btnComposeMsg.Name = "btnComposeMsg";
            this.btnComposeMsg.Size = new System.Drawing.Size(172, 57);
            this.btnComposeMsg.TabIndex = 137;
            this.btnComposeMsg.Text = "ဌာနချင်းဆက်သွယ်စာ";
            this.btnComposeMsg.UseVisualStyleBackColor = true;
            this.btnComposeMsg.Click += new System.EventHandler(this.btnComposeMsg_Click);
            // 
            // btnMsgInOutRecord
            // 
            this.btnMsgInOutRecord.Location = new System.Drawing.Point(40, 252);
            this.btnMsgInOutRecord.Name = "btnMsgInOutRecord";
            this.btnMsgInOutRecord.Size = new System.Drawing.Size(172, 57);
            this.btnMsgInOutRecord.TabIndex = 138;
            this.btnMsgInOutRecord.Text = "ဌာနချင်းဆက်သွယ်စာ မှတ်တမ်း";
            this.btnMsgInOutRecord.UseVisualStyleBackColor = true;
            this.btnMsgInOutRecord.Click += new System.EventHandler(this.btnMsgInOutRecord_Click);
            // 
            // btnMsgInOut
            // 
            this.btnMsgInOut.Location = new System.Drawing.Point(236, 90);
            this.btnMsgInOut.Name = "btnMsgInOut";
            this.btnMsgInOut.Size = new System.Drawing.Size(172, 57);
            this.btnMsgInOut.TabIndex = 139;
            this.btnMsgInOut.Text = "ဝင်စာ / ထွက်စာ";
            this.btnMsgInOut.UseVisualStyleBackColor = true;
            this.btnMsgInOut.Click += new System.EventHandler(this.btnMsgInOut_Click);
            // 
            // btnDeptToDeptConfirm
            // 
            this.btnDeptToDeptConfirm.Location = new System.Drawing.Point(40, 171);
            this.btnDeptToDeptConfirm.Name = "btnDeptToDeptConfirm";
            this.btnDeptToDeptConfirm.Size = new System.Drawing.Size(172, 57);
            this.btnDeptToDeptConfirm.TabIndex = 140;
            this.btnDeptToDeptConfirm.Text = "ဌာနချင်းဆက်သွယ်စာ အတည်ပြုရန်";
            this.btnDeptToDeptConfirm.UseVisualStyleBackColor = true;
            this.btnDeptToDeptConfirm.Click += new System.EventHandler(this.btnDeptToDeptConfirm_Click);
            // 
            // btnExternalComposeMsg
            // 
            this.btnExternalComposeMsg.Location = new System.Drawing.Point(236, 171);
            this.btnExternalComposeMsg.Name = "btnExternalComposeMsg";
            this.btnExternalComposeMsg.Size = new System.Drawing.Size(172, 57);
            this.btnExternalComposeMsg.TabIndex = 141;
            this.btnExternalComposeMsg.Text = "ပြင်ပနှင့်ဆက်သွယ်စာ";
            this.btnExternalComposeMsg.UseVisualStyleBackColor = true;
            this.btnExternalComposeMsg.Click += new System.EventHandler(this.btnExternalComposeMsg_Click);
            // 
            // frmMsgInOutPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 383);
            this.Controls.Add(this.btnExternalComposeMsg);
            this.Controls.Add(this.btnDeptToDeptConfirm);
            this.Controls.Add(this.btnMsgInOut);
            this.Controls.Add(this.btnMsgInOutRecord);
            this.Controls.Add(this.btnComposeMsg);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMsgInOutPage";
            this.Text = "စာဝင် / စာထွက်";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.Button btnComposeMsg;
        private System.Windows.Forms.Button btnMsgInOutRecord;
        private System.Windows.Forms.Button btnMsgInOut;
        private System.Windows.Forms.Button btnDeptToDeptConfirm;
        private System.Windows.Forms.Button btnExternalComposeMsg;
    }
}