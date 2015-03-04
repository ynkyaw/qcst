namespace PTIC.VC.Sale.Inventory
{
    partial class frmInventoryStorePage
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
            this.btnShowRoomInOut = new System.Windows.Forms.Button();
            this.btnFG_Receive = new System.Windows.Forms.Button();
            this.btnFG_Request = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSalePage = new System.Windows.Forms.Label();
            this.btnVenInOut = new System.Windows.Forms.Button();
            this.btnShowRoomMovement = new System.Windows.Forms.Button();
            this.btnSalesReturn = new System.Windows.Forms.Button();
            this.btnSalesReturnList = new System.Windows.Forms.Button();
            this.btnVanReturn = new System.Windows.Forms.Button();
            this.btnVanReturnList = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowRoomInOut
            // 
            this.btnShowRoomInOut.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowRoomInOut.Location = new System.Drawing.Point(30, 246);
            this.btnShowRoomInOut.Name = "btnShowRoomInOut";
            this.btnShowRoomInOut.Size = new System.Drawing.Size(172, 54);
            this.btnShowRoomInOut.TabIndex = 39;
            this.btnShowRoomInOut.Text = "SSB ပစ္စည်းအဝင်/အထွက်";
            this.btnShowRoomInOut.UseVisualStyleBackColor = true;
            this.btnShowRoomInOut.Visible = false;
            this.btnShowRoomInOut.Click += new System.EventHandler(this.btnWarehouseInOut_Click);
            // 
            // btnFG_Receive
            // 
            this.btnFG_Receive.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFG_Receive.Location = new System.Drawing.Point(30, 168);
            this.btnFG_Receive.Name = "btnFG_Receive";
            this.btnFG_Receive.Size = new System.Drawing.Size(172, 54);
            this.btnFG_Receive.TabIndex = 38;
            this.btnFG_Receive.Text = "Factrory Request / Issue List";
            this.btnFG_Receive.UseVisualStyleBackColor = true;
            this.btnFG_Receive.Click += new System.EventHandler(this.btnFG_Receive_Click);
            // 
            // btnFG_Request
            // 
            this.btnFG_Request.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFG_Request.Location = new System.Drawing.Point(30, 90);
            this.btnFG_Request.Name = "btnFG_Request";
            this.btnFG_Request.Size = new System.Drawing.Size(172, 54);
            this.btnFG_Request.TabIndex = 37;
            this.btnFG_Request.Text = "စက်ရုံသို့ ပစ္စည်း‌တောင်းခံခြင်း";
            this.btnFG_Request.UseVisualStyleBackColor = true;
            this.btnFG_Request.Click += new System.EventHandler(this.btnFG_Request_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.lblSalePage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 41);
            this.panel1.TabIndex = 36;
            // 
            // lblSalePage
            // 
            this.lblSalePage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSalePage.AutoSize = true;
            this.lblSalePage.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalePage.Location = new System.Drawing.Point(8, 9);
            this.lblSalePage.Name = "lblSalePage";
            this.lblSalePage.Size = new System.Drawing.Size(165, 20);
            this.lblSalePage.TabIndex = 0;
            this.lblSalePage.Text = "ကုန်ပစ္စည်း အဝင်/အထွက်";
            // 
            // btnVenInOut
            // 
            this.btnVenInOut.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenInOut.Location = new System.Drawing.Point(30, 324);
            this.btnVenInOut.Name = "btnVenInOut";
            this.btnVenInOut.Size = new System.Drawing.Size(172, 54);
            this.btnVenInOut.TabIndex = 40;
            this.btnVenInOut.Text = "အ‌ရောင်းကား ပစ္စည်းအဝင်/အထွက်";
            this.btnVenInOut.UseVisualStyleBackColor = true;
            this.btnVenInOut.Visible = false;
            this.btnVenInOut.Click += new System.EventHandler(this.btnVenInOut_Click);
            // 
            // btnShowRoomMovement
            // 
            this.btnShowRoomMovement.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowRoomMovement.Location = new System.Drawing.Point(235, 246);
            this.btnShowRoomMovement.Name = "btnShowRoomMovement";
            this.btnShowRoomMovement.Size = new System.Drawing.Size(172, 54);
            this.btnShowRoomMovement.TabIndex = 41;
            this.btnShowRoomMovement.Text = "ShowRooms Movement";
            this.btnShowRoomMovement.UseVisualStyleBackColor = true;
            this.btnShowRoomMovement.Visible = false;
            this.btnShowRoomMovement.Click += new System.EventHandler(this.btnShowRoomMovement_Click);
            // 
            // btnSalesReturn
            // 
            this.btnSalesReturn.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesReturn.Location = new System.Drawing.Point(235, 168);
            this.btnSalesReturn.Name = "btnSalesReturn";
            this.btnSalesReturn.Size = new System.Drawing.Size(172, 54);
            this.btnSalesReturn.TabIndex = 62;
            this.btnSalesReturn.Text = "Sales Return";
            this.btnSalesReturn.UseVisualStyleBackColor = true;
            this.btnSalesReturn.Click += new System.EventHandler(this.btnSalesReturn_Click);
            // 
            // btnSalesReturnList
            // 
            this.btnSalesReturnList.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesReturnList.Location = new System.Drawing.Point(438, 168);
            this.btnSalesReturnList.Name = "btnSalesReturnList";
            this.btnSalesReturnList.Size = new System.Drawing.Size(172, 54);
            this.btnSalesReturnList.TabIndex = 63;
            this.btnSalesReturnList.Text = "Sales Return List";
            this.btnSalesReturnList.UseVisualStyleBackColor = true;
            this.btnSalesReturnList.Visible = false;
            this.btnSalesReturnList.Click += new System.EventHandler(this.btnSalesReturnList_Click);
            // 
            // btnVanReturn
            // 
            this.btnVanReturn.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVanReturn.Location = new System.Drawing.Point(235, 90);
            this.btnVanReturn.Name = "btnVanReturn";
            this.btnVanReturn.Size = new System.Drawing.Size(172, 54);
            this.btnVanReturn.TabIndex = 64;
            this.btnVanReturn.Text = "Van Return";
            this.btnVanReturn.UseVisualStyleBackColor = true;
            this.btnVanReturn.Click += new System.EventHandler(this.btnVanReturn_Click);
            // 
            // btnVanReturnList
            // 
            this.btnVanReturnList.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVanReturnList.Location = new System.Drawing.Point(438, 90);
            this.btnVanReturnList.Name = "btnVanReturnList";
            this.btnVanReturnList.Size = new System.Drawing.Size(172, 54);
            this.btnVanReturnList.TabIndex = 65;
            this.btnVanReturnList.Text = "Van Return List";
            this.btnVanReturnList.UseVisualStyleBackColor = true;
            this.btnVanReturnList.Click += new System.EventHandler(this.btnVanReturnList_Click);
            // 
            // frmInventoryStorePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 458);
            this.Controls.Add(this.btnVanReturnList);
            this.Controls.Add(this.btnShowRoomMovement);
            this.Controls.Add(this.btnVanReturn);
            this.Controls.Add(this.btnVenInOut);
            this.Controls.Add(this.btnSalesReturnList);
            this.Controls.Add(this.btnShowRoomInOut);
            this.Controls.Add(this.btnSalesReturn);
            this.Controls.Add(this.btnFG_Receive);
            this.Controls.Add(this.btnFG_Request);
            this.Controls.Add(this.panel1);
            this.Name = "frmInventoryStorePage";
            this.Text = "InventoryStorePage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowRoomInOut;
        private System.Windows.Forms.Button btnFG_Receive;
        private System.Windows.Forms.Button btnFG_Request;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSalePage;
        private System.Windows.Forms.Button btnVenInOut;
        private System.Windows.Forms.Button btnShowRoomMovement;
        private System.Windows.Forms.Button btnSalesReturn;
        private System.Windows.Forms.Button btnSalesReturnList;
        private System.Windows.Forms.Button btnVanReturn;
        private System.Windows.Forms.Button btnVanReturnList;
    }
}