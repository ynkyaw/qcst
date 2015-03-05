namespace PTIC.ReportViewer
{
    partial class frmRV_AP_BalanceViewer
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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.rdoVen = new System.Windows.Forms.RadioButton();
            this.rdoDept = new System.Windows.Forms.RadioButton();
            this.cmbDeptVen = new System.Windows.Forms.ComboBox();
            this.chkAPSubCat = new System.Windows.Forms.CheckBox();
            this.chkPosm = new System.Windows.Forms.CheckBox();
            this.cmbAPSubCat = new System.Windows.Forms.ComboBox();
            this.cmbPOSM = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rpViewerAPBalance = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pTIC_DataSet = new PTIC.PTIC_DataSet();
            this.pTICDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pTIC_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTICDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.rdoVen);
            this.pnlFilter.Controls.Add(this.rdoDept);
            this.pnlFilter.Controls.Add(this.cmbDeptVen);
            this.pnlFilter.Controls.Add(this.chkAPSubCat);
            this.pnlFilter.Controls.Add(this.chkPosm);
            this.pnlFilter.Controls.Add(this.cmbAPSubCat);
            this.pnlFilter.Controls.Add(this.cmbPOSM);
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Controls.Add(this.btnViewAll);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 23);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(882, 79);
            this.pnlFilter.TabIndex = 194;
            // 
            // rdoVen
            // 
            this.rdoVen.AutoSize = true;
            this.rdoVen.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.rdoVen.Location = new System.Drawing.Point(30, 40);
            this.rdoVen.Name = "rdoVen";
            this.rdoVen.Size = new System.Drawing.Size(104, 24);
            this.rdoVen.TabIndex = 200;
            this.rdoVen.TabStop = true;
            this.rdoVen.Text = "အရောင်းကား";
            this.rdoVen.UseVisualStyleBackColor = true;
            // 
            // rdoDept
            // 
            this.rdoDept.AutoSize = true;
            this.rdoDept.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.rdoDept.Location = new System.Drawing.Point(30, 10);
            this.rdoDept.Name = "rdoDept";
            this.rdoDept.Size = new System.Drawing.Size(52, 24);
            this.rdoDept.TabIndex = 199;
            this.rdoDept.TabStop = true;
            this.rdoDept.Text = "ဌာန";
            this.rdoDept.UseVisualStyleBackColor = true;
            this.rdoDept.CheckedChanged += new System.EventHandler(this.rdoDept_CheckedChanged);
            // 
            // cmbDeptVen
            // 
            this.cmbDeptVen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDeptVen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDeptVen.DisplayMember = "APSubCategoryName";
            this.cmbDeptVen.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbDeptVen.FormattingEnabled = true;
            this.cmbDeptVen.Location = new System.Drawing.Point(140, 23);
            this.cmbDeptVen.Name = "cmbDeptVen";
            this.cmbDeptVen.Size = new System.Drawing.Size(150, 27);
            this.cmbDeptVen.TabIndex = 198;
            this.cmbDeptVen.ValueMember = "ID";
            // 
            // chkAPSubCat
            // 
            this.chkAPSubCat.AutoSize = true;
            this.chkAPSubCat.Location = new System.Drawing.Point(332, 9);
            this.chkAPSubCat.Name = "chkAPSubCat";
            this.chkAPSubCat.Size = new System.Drawing.Size(147, 24);
            this.chkAPSubCat.TabIndex = 187;
            this.chkAPSubCat.Text = "A && P အမျိုးအစားခွဲ";
            this.chkAPSubCat.UseVisualStyleBackColor = true;
            this.chkAPSubCat.CheckedChanged += new System.EventHandler(this.chkAPSubCat_CheckedChanged);
            // 
            // chkPosm
            // 
            this.chkPosm.AutoSize = true;
            this.chkPosm.Location = new System.Drawing.Point(332, 42);
            this.chkPosm.Name = "chkPosm";
            this.chkPosm.Size = new System.Drawing.Size(111, 24);
            this.chkPosm.TabIndex = 186;
            this.chkPosm.Text = "POSM အမည်\r\n";
            this.chkPosm.UseVisualStyleBackColor = true;
            this.chkPosm.CheckedChanged += new System.EventHandler(this.chkPosm_CheckedChanged);
            // 
            // cmbAPSubCat
            // 
            this.cmbAPSubCat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAPSubCat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAPSubCat.DisplayMember = "APSubCategoryName";
            this.cmbAPSubCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAPSubCat.FormattingEnabled = true;
            this.cmbAPSubCat.Location = new System.Drawing.Point(486, 8);
            this.cmbAPSubCat.Name = "cmbAPSubCat";
            this.cmbAPSubCat.Size = new System.Drawing.Size(150, 27);
            this.cmbAPSubCat.TabIndex = 185;
            this.cmbAPSubCat.ValueMember = "ID";
            this.cmbAPSubCat.SelectedIndexChanged += new System.EventHandler(this.cmbAPSubCat_SelectedIndexChanged);
            // 
            // cmbPOSM
            // 
            this.cmbPOSM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPOSM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPOSM.DisplayMember = "APMaterialName";
            this.cmbPOSM.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPOSM.FormattingEnabled = true;
            this.cmbPOSM.Location = new System.Drawing.Point(486, 41);
            this.cmbPOSM.Name = "cmbPOSM";
            this.cmbPOSM.Size = new System.Drawing.Size(150, 27);
            this.cmbPOSM.TabIndex = 184;
            this.cmbPOSM.ValueMember = "ID";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1007, 100);
            this.panel3.TabIndex = 174;
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(759, 5);
            this.btnViewAll.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(113, 30);
            this.btnViewAll.TabIndex = 3;
            this.btnViewAll.Text = "အကုန်ကြည့်မည်";
            this.btnViewAll.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(642, 5);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlFilt
            // 
            this.pnlFilt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(131)))), ((int)(((byte)(170)))));
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 0);
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(882, 23);
            this.pnlFilt.TabIndex = 193;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.lblFilter.Location = new System.Drawing.Point(3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(166, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Advance Search";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rpViewerAPBalance);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 474);
            this.panel1.TabIndex = 195;
            // 
            // rpViewerAPBalance
            // 
            this.rpViewerAPBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpViewerAPBalance.Location = new System.Drawing.Point(0, 0);
            this.rpViewerAPBalance.Name = "rpViewerAPBalance";
            this.rpViewerAPBalance.Size = new System.Drawing.Size(882, 474);
            this.rpViewerAPBalance.TabIndex = 0;
            // 
            // pTIC_DataSet
            // 
            this.pTIC_DataSet.DataSetName = "PTIC_DataSet";
            this.pTIC_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pTICDataSetBindingSource
            // 
            this.pTICDataSetBindingSource.DataSource = this.pTIC_DataSet;
            this.pTICDataSetBindingSource.Position = 0;
            // 
            // frmRV_AP_BalanceViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 576);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRV_AP_BalanceViewer";
            this.Text = "A & P လက်ကျန်စာရင်း";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AP_BalanceViewer_FormClosing);
            this.Load += new System.EventHandler(this.AP_BalanceViewer_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pTIC_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTICDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkAPSubCat;
        private System.Windows.Forms.CheckBox chkPosm;
        private System.Windows.Forms.ComboBox cmbAPSubCat;
        private System.Windows.Forms.ComboBox cmbPOSM;
        private System.Windows.Forms.RadioButton rdoVen;
        private System.Windows.Forms.RadioButton rdoDept;
        private System.Windows.Forms.ComboBox cmbDeptVen;
        private System.Windows.Forms.BindingSource pTICDataSetBindingSource;
        private PTIC_DataSet pTIC_DataSet;
        private Microsoft.Reporting.WinForms.ReportViewer rpViewerAPBalance;

    }
}