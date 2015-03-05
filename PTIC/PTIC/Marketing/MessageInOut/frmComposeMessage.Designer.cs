namespace PTIC.VC.Marketing.MessageInOut
{
    partial class frmComposeMessage
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
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.lblMarketing = new System.Windows.Forms.Label();
            this.txtMsgNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSenderDept = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSenderPost = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSenderEmployee = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtRecieverDept = new System.Windows.Forms.TextBox();
            this.txtReciever = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnReply = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnDirectlySend = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Controls.Add(this.lblMarketing);
            this.panel2.Controls.Add(this.txtMsgNo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1066, 41);
            this.panel2.TabIndex = 135;
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblHeaderPCat.Location = new System.Drawing.Point(117, 9);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(159, 19);
            this.lblHeaderPCat.TabIndex = 46;
            this.lblHeaderPCat.Text = ">   ဌာနချင်းဆက်သွယ်စာ";
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
            this.lblMarketing.Click += new System.EventHandler(this.lblMarketing_Click);
            // 
            // txtMsgNo
            // 
            this.txtMsgNo.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsgNo.Location = new System.Drawing.Point(424, 7);
            this.txtMsgNo.Name = "txtMsgNo";
            this.txtMsgNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgNo.Size = new System.Drawing.Size(155, 28);
            this.txtMsgNo.TabIndex = 88;
            this.txtMsgNo.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "စာအမှတ်";
            this.label4.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtSenderDept);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtSenderPost);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbSenderEmployee);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.txtRecieverDept);
            this.panel1.Controls.Add(this.txtReciever);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1066, 131);
            this.panel1.TabIndex = 136;
            // 
            // txtSenderDept
            // 
            this.txtSenderDept.Enabled = false;
            this.txtSenderDept.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderDept.Location = new System.Drawing.Point(81, 85);
            this.txtSenderDept.Name = "txtSenderDept";
            this.txtSenderDept.ReadOnly = true;
            this.txtSenderDept.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSenderDept.Size = new System.Drawing.Size(178, 28);
            this.txtSenderDept.TabIndex = 94;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 20);
            this.label10.TabIndex = 93;
            this.label10.Text = "ဌာန";
            // 
            // txtSenderPost
            // 
            this.txtSenderPost.Enabled = false;
            this.txtSenderPost.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderPost.Location = new System.Drawing.Point(81, 49);
            this.txtSenderPost.Name = "txtSenderPost";
            this.txtSenderPost.ReadOnly = true;
            this.txtSenderPost.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSenderPost.Size = new System.Drawing.Size(178, 28);
            this.txtSenderPost.TabIndex = 92;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 20);
            this.label9.TabIndex = 91;
            this.label9.Text = "ရာထူး";
            // 
            // cmbSenderEmployee
            // 
            this.cmbSenderEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSenderEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSenderEmployee.FormattingEnabled = true;
            this.cmbSenderEmployee.Location = new System.Drawing.Point(81, 14);
            this.cmbSenderEmployee.Name = "cmbSenderEmployee";
            this.cmbSenderEmployee.Size = new System.Drawing.Size(178, 27);
            this.cmbSenderEmployee.TabIndex = 90;
            this.cmbSenderEmployee.SelectedIndexChanged += new System.EventHandler(this.cmbEmployee_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 89;
            this.label8.Text = "ပေးပို့သူ";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(690, 10);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(82, 32);
            this.btnSelect.TabIndex = 87;
            this.btnSelect.Text = "ရွေးမည် ...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtRecieverDept
            // 
            this.txtRecieverDept.Enabled = false;
            this.txtRecieverDept.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecieverDept.Location = new System.Drawing.Point(332, 69);
            this.txtRecieverDept.Multiline = true;
            this.txtRecieverDept.Name = "txtRecieverDept";
            this.txtRecieverDept.ReadOnly = true;
            this.txtRecieverDept.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRecieverDept.Size = new System.Drawing.Size(352, 49);
            this.txtRecieverDept.TabIndex = 86;
            // 
            // txtReciever
            // 
            this.txtReciever.Enabled = false;
            this.txtReciever.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReciever.Location = new System.Drawing.Point(332, 10);
            this.txtReciever.Multiline = true;
            this.txtReciever.Name = "txtReciever";
            this.txtReciever.ReadOnly = true;
            this.txtReciever.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReciever.Size = new System.Drawing.Size(352, 51);
            this.txtReciever.TabIndex = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "ဌာန";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "သို့";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnForward);
            this.panel3.Controls.Add(this.btnReply);
            this.panel3.Controls.Add(this.btnConfirm);
            this.panel3.Controls.Add(this.btnDirectlySend);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 609);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1066, 48);
            this.panel3.TabIndex = 137;
            // 
            // btnForward
            // 
            this.btnForward.Enabled = false;
            this.btnForward.Location = new System.Drawing.Point(833, 7);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(106, 34);
            this.btnForward.TabIndex = 33;
            this.btnForward.Text = "Forward";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnReply
            // 
            this.btnReply.Enabled = false;
            this.btnReply.Location = new System.Drawing.Point(955, 7);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(106, 34);
            this.btnReply.TabIndex = 32;
            this.btnReply.Text = "Reply";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(260, 7);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(106, 34);
            this.btnConfirm.TabIndex = 31;
            this.btnConfirm.Text = "အတည်ပြုမည်";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Visible = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnDirectlySend
            // 
            this.btnDirectlySend.Location = new System.Drawing.Point(138, 7);
            this.btnDirectlySend.Name = "btnDirectlySend";
            this.btnDirectlySend.Size = new System.Drawing.Size(106, 34);
            this.btnDirectlySend.TabIndex = 30;
            this.btnDirectlySend.Text = "ပို့မည်";
            this.btnDirectlySend.UseVisualStyleBackColor = true;
            this.btnDirectlySend.Click += new System.EventHandler(this.btnDirectlySend_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 34);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "ပို့ရန်တင်ပြမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtRemark);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtBody);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtSubject);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 172);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1066, 437);
            this.panel4.TabIndex = 138;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(178, 308);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(860, 112);
            this.txtRemark.TabIndex = 90;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 89;
            this.label7.Text = "မှတ်ချက်";
            // 
            // txtBody
            // 
            this.txtBody.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBody.Location = new System.Drawing.Point(178, 59);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBody.Size = new System.Drawing.Size(860, 241);
            this.txtBody.TabIndex = 88;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 20);
            this.label6.TabIndex = 87;
            this.label6.Text = "အကြောင်းအရာအသေးစိတ်";
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Location = new System.Drawing.Point(178, 23);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSubject.Size = new System.Drawing.Size(860, 28);
            this.txtSubject.TabIndex = 86;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "အကြောင်းအရာ";
            // 
            // frmComposeMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 657);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmComposeMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "စာဝင်";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Label lblMarketing;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMsgNo;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtRecieverDept;
        private System.Windows.Forms.TextBox txtReciever;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSenderDept;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSenderPost;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbSenderEmployee;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDirectlySend;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.Button btnForward;
    }
}