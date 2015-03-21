namespace PTIC.Sale.Order
{
    partial class frmOrderMain
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
            this.lblSetup = new System.Windows.Forms.Label();
            this.btnLostOrder = new System.Windows.Forms.Button();
            this.btnOrderList = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnDeliveredList = new System.Windows.Forms.Button();
            this.btnDelivery = new System.Windows.Forms.Button();
            this.btnDeliveryNote = new System.Windows.Forms.Button();
            this.btnDeliveryPlan = new System.Windows.Forms.Button();
            this.btnDeliveryNoteList = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblSetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 41);
            this.panel1.TabIndex = 26;
            // 
            // lblSetup
            // 
            this.lblSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSetup.AutoSize = true;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetup.Location = new System.Drawing.Point(8, 9);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(145, 19);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "Order && Delivery";
            // 
            // btnLostOrder
            // 
            this.btnLostOrder.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLostOrder.Location = new System.Drawing.Point(234, 324);
            this.btnLostOrder.Name = "btnLostOrder";
            this.btnLostOrder.Size = new System.Drawing.Size(172, 54);
            this.btnLostOrder.TabIndex = 29;
            this.btnLostOrder.Text = "မပို့နိုင်‌သော Order စာရင်း";
            this.btnLostOrder.UseVisualStyleBackColor = true;
            this.btnLostOrder.Click += new System.EventHandler(this.btnLostOrder_Click);
            // 
            // btnOrderList
            // 
            this.btnOrderList.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderList.Location = new System.Drawing.Point(30, 168);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(172, 54);
            this.btnOrderList.TabIndex = 28;
            this.btnOrderList.Text = "Order စာရင်း";
            this.btnOrderList.UseVisualStyleBackColor = true;
            this.btnOrderList.Click += new System.EventHandler(this.btnOrderList_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Location = new System.Drawing.Point(30, 90);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(172, 54);
            this.btnOrder.TabIndex = 27;
            this.btnOrder.Text = "Order လက်ခံခြင်း";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnDeliveredList
            // 
            this.btnDeliveredList.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeliveredList.Location = new System.Drawing.Point(234, 246);
            this.btnDeliveredList.Name = "btnDeliveredList";
            this.btnDeliveredList.Size = new System.Drawing.Size(172, 54);
            this.btnDeliveredList.TabIndex = 32;
            this.btnDeliveredList.Text = "ပို့ပြီးစာရင်း";
            this.btnDeliveredList.UseVisualStyleBackColor = true;
            this.btnDeliveredList.Click += new System.EventHandler(this.btnDeliver_Click);
            // 
            // btnDelivery
            // 
            this.btnDelivery.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelivery.Location = new System.Drawing.Point(234, 168);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(172, 54);
            this.btnDelivery.TabIndex = 31;
            this.btnDelivery.Text = "ပို့ရန်စာရင်း";
            this.btnDelivery.UseVisualStyleBackColor = true;
            this.btnDelivery.Click += new System.EventHandler(this.btnUnDeliver_Click);
            // 
            // btnDeliveryNote
            // 
            this.btnDeliveryNote.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeliveryNote.Location = new System.Drawing.Point(30, 246);
            this.btnDeliveryNote.Name = "btnDeliveryNote";
            this.btnDeliveryNote.Size = new System.Drawing.Size(172, 54);
            this.btnDeliveryNote.TabIndex = 33;
            this.btnDeliveryNote.Text = "Delivery Note";
            this.btnDeliveryNote.UseVisualStyleBackColor = true;
            this.btnDeliveryNote.Click += new System.EventHandler(this.btnDeliveryNote_Click);
            // 
            // btnDeliveryPlan
            // 
            this.btnDeliveryPlan.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeliveryPlan.Location = new System.Drawing.Point(234, 92);
            this.btnDeliveryPlan.Name = "btnDeliveryPlan";
            this.btnDeliveryPlan.Size = new System.Drawing.Size(172, 54);
            this.btnDeliveryPlan.TabIndex = 34;
            this.btnDeliveryPlan.Text = "ပို့ရန်စီစဉ်ခြင်း";
            this.btnDeliveryPlan.UseVisualStyleBackColor = true;
            this.btnDeliveryPlan.Click += new System.EventHandler(this.btnDeliveryPlan_Click);
            // 
            // btnDeliveryNoteList
            // 
            this.btnDeliveryNoteList.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeliveryNoteList.Location = new System.Drawing.Point(30, 324);
            this.btnDeliveryNoteList.Name = "btnDeliveryNoteList";
            this.btnDeliveryNoteList.Size = new System.Drawing.Size(172, 54);
            this.btnDeliveryNoteList.TabIndex = 35;
            this.btnDeliveryNoteList.Text = "Delivery Note List";
            this.btnDeliveryNoteList.UseVisualStyleBackColor = true;
            this.btnDeliveryNoteList.Click += new System.EventHandler(this.btnDeliveryNoteList_Click);
            // 
            // frmOrderMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 574);
            this.Controls.Add(this.btnDeliveryNoteList);
            this.Controls.Add(this.btnDeliveryPlan);
            this.Controls.Add(this.btnDeliveryNote);
            this.Controls.Add(this.btnDeliveredList);
            this.Controls.Add(this.btnDelivery);
            this.Controls.Add(this.btnLostOrder);
            this.Controls.Add(this.btnOrderList);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Name = "frmOrderMain";
            this.Text = "Order and Delivery Page";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Button btnLostOrder;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnDeliveredList;
        private System.Windows.Forms.Button btnDelivery;
        private System.Windows.Forms.Button btnDeliveryNote;
        private System.Windows.Forms.Button btnDeliveryPlan;
        private System.Windows.Forms.Button btnDeliveryNoteList;
    }
}