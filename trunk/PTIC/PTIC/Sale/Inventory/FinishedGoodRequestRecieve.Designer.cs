namespace PTIC.VC.Sale.Inventory
{
    partial class FinishedGoodRequestRecieve
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvFGRequestIssue = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnIssue = new System.Windows.Forms.Button();
            this.colRequestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequesetDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliverPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFGRequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFGRequestIssue)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.panel2.Size = new System.Drawing.Size(928, 46);
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
            this.lblHeaderPCat.Size = new System.Drawing.Size(241, 20);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">    Factory Request / Issue List";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvFGRequestIssue);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(928, 371);
            this.panel3.TabIndex = 69;
            // 
            // dgvFGRequestIssue
            // 
            this.dgvFGRequestIssue.AllowUserToAddRows = false;
            this.dgvFGRequestIssue.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.dgvFGRequestIssue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(175)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFGRequestIssue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFGRequestIssue.ColumnHeadersHeight = 50;
            this.dgvFGRequestIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFGRequestIssue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRequestNo,
            this.colRequesetDate,
            this.colIssueDate,
            this.colRequester,
            this.colDeliverPerson,
            this.colVen,
            this.colFGRequestID});
            this.dgvFGRequestIssue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFGRequestIssue.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvFGRequestIssue.EnableHeadersVisualStyles = false;
            this.dgvFGRequestIssue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(36)))), ((int)(((byte)(60)))));
            this.dgvFGRequestIssue.Location = new System.Drawing.Point(0, 0);
            this.dgvFGRequestIssue.Name = "dgvFGRequestIssue";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(175)))), ((int)(((byte)(130)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFGRequestIssue.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFGRequestIssue.RowHeadersWidth = 50;
            this.dgvFGRequestIssue.RowTemplate.Height = 28;
            this.dgvFGRequestIssue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFGRequestIssue.Size = new System.Drawing.Size(928, 371);
            this.dgvFGRequestIssue.TabIndex = 183;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnIssue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 417);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 47);
            this.panel1.TabIndex = 68;
            // 
            // btnIssue
            // 
            this.btnIssue.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Location = new System.Drawing.Point(12, 6);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(95, 34);
            this.btnIssue.TabIndex = 45;
            this.btnIssue.Text = "ထုတ်ပေးမည်";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // colRequestNo
            // 
            this.colRequestNo.DataPropertyName = "RequestNo";
            this.colRequestNo.HeaderText = "စာအမှတ်";
            this.colRequestNo.Name = "colRequestNo";
            this.colRequestNo.ReadOnly = true;
            this.colRequestNo.Visible = false;
            this.colRequestNo.Width = 150;
            // 
            // colRequesetDate
            // 
            this.colRequesetDate.DataPropertyName = "RequireDate";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.colRequesetDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colRequesetDate.HeaderText = "တောင်းခံသည့်နေ့စွဲ";
            this.colRequesetDate.Name = "colRequesetDate";
            this.colRequesetDate.ReadOnly = true;
            this.colRequesetDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRequesetDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRequesetDate.Width = 130;
            // 
            // colIssueDate
            // 
            this.colIssueDate.DataPropertyName = "IssueDate";
            dataGridViewCellStyle3.Format = "d";
            this.colIssueDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colIssueDate.HeaderText = "ထုတ်ပေးသည့်နေ့စွဲ";
            this.colIssueDate.Name = "colIssueDate";
            this.colIssueDate.ReadOnly = true;
            this.colIssueDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIssueDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colIssueDate.Width = 130;
            // 
            // colRequester
            // 
            this.colRequester.DataPropertyName = "Requster";
            this.colRequester.HeaderText = "တောင်းခံသူ";
            this.colRequester.Name = "colRequester";
            this.colRequester.ReadOnly = true;
            this.colRequester.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRequester.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRequester.Width = 150;
            // 
            // colDeliverPerson
            // 
            this.colDeliverPerson.DataPropertyName = "Transporter";
            this.colDeliverPerson.HeaderText = "သယ်ယူမည့်သူ";
            this.colDeliverPerson.Name = "colDeliverPerson";
            this.colDeliverPerson.Width = 150;
            // 
            // colVen
            // 
            this.colVen.DataPropertyName = "VenNo";
            this.colVen.HeaderText = "သယ်ယူမည့်ကား";
            this.colVen.Name = "colVen";
            this.colVen.Width = 150;
            // 
            // colFGRequestID
            // 
            this.colFGRequestID.DataPropertyName = "FGRequestID";
            this.colFGRequestID.HeaderText = "FGRequestID";
            this.colFGRequestID.Name = "colFGRequestID";
            this.colFGRequestID.Visible = false;
            // 
            // FinishedGoodRequestRecieve
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(928, 464);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Name = "FinishedGoodRequestRecieve";
            this.Text = "Factory Request / Issue List";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFGRequestIssue)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvFGRequestIssue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequesetDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequester;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliverPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFGRequestID;
    }
}