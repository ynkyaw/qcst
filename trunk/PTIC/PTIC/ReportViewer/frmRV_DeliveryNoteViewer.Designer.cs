namespace PTIC.ReportViewer
{
    partial class frmRV_DeliveryNoteViewer
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
            this.rpDeliveryNoteViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpDeliveryNoteViewer
            // 
            this.rpDeliveryNoteViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpDeliveryNoteViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.DeliveryNote.rdlc";
            this.rpDeliveryNoteViewer.Location = new System.Drawing.Point(0, 0);
            this.rpDeliveryNoteViewer.Name = "rpDeliveryNoteViewer";
            this.rpDeliveryNoteViewer.Size = new System.Drawing.Size(837, 609);
            this.rpDeliveryNoteViewer.TabIndex = 0;
            // 
            // frmRV_DeliveryNoteViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 609);
            this.Controls.Add(this.rpDeliveryNoteViewer);
            this.Name = "frmRV_DeliveryNoteViewer";
            this.Text = "Delivery Note";
            this.Load += new System.EventHandler(this.frmRV_DeliveryNoteViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpDeliveryNoteViewer;
    }
}