namespace PTIC.VC.Marketing.A_P
{
    partial class frmPosmRecieve
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPosmRecieve = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGiver = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbReciever = new System.Windows.Forms.ComboBox();
            this.cmbGiverDept = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpSearchIssueDate = new System.Windows.Forms.DateTimePicker();
            this.chkRequestDept = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbAPSubCat = new System.Windows.Forms.ComboBox();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlFilt = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSetup = new System.Windows.Forms.Label();
            this.lblHeaderPCat = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAPSubCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestPurpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAP_MaterialID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosmRecieve)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlFilt.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPosmRecieve
            // 
            this.dgvPosmRecieve.AllowUserToAddRows = false;
            this.dgvPosmRecieve.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPosmRecieve.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(131)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPosmRecieve.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPosmRecieve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPosmRecieve.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAPSubCategory,
            this.colPosm,
            this.colDescription,
            this.colQuantity,
            this.colIssueQty,
            this.colRemark,
            this.colRequestPurpose,
            this.colIssueDetailID,
            this.colRequestDetailID,
            this.colAP_MaterialID});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPosmRecieve.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPosmRecieve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPosmRecieve.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPosmRecieve.EnableHeadersVisualStyles = false;
            this.dgvPosmRecieve.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(165)))), ((int)(((byte)(255)))));
            this.dgvPosmRecieve.Location = new System.Drawing.Point(0, 201);
            this.dgvPosmRecieve.Name = "dgvPosmRecieve";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(131)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Myanmar3", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPosmRecieve.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPosmRecieve.RowHeadersWidth = 50;
            this.dgvPosmRecieve.RowTemplate.Height = 28;
            this.dgvPosmRecieve.Size = new System.Drawing.Size(975, 202);
            this.dgvPosmRecieve.TabIndex = 187;
            this.dgvPosmRecieve.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPosmRecieve_CellEndEdit);
            this.dgvPosmRecieve.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvPosmRecieve_CellValidating);
            this.dgvPosmRecieve.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPosmRecieve_DataBindingComplete);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 403);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(975, 50);
            this.pnlFooter.TabIndex = 186;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSave.Location = new System.Drawing.Point(20, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 34);
            this.btnSave.TabIndex = 170;
            this.btnSave.Text = "သိမ်းမည်";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.label5);
            this.pnlGrid.Controls.Add(this.cmbGiver);
            this.pnlGrid.Controls.Add(this.label4);
            this.pnlGrid.Controls.Add(this.label3);
            this.pnlGrid.Controls.Add(this.cmbReciever);
            this.pnlGrid.Controls.Add(this.cmbGiverDept);
            this.pnlGrid.Controls.Add(this.textBox1);
            this.pnlGrid.Controls.Add(this.label1);
            this.pnlGrid.Controls.Add(this.dtpIssueDate);
            this.pnlGrid.Controls.Add(this.label2);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrid.Location = new System.Drawing.Point(0, 118);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(975, 83);
            this.pnlGrid.TabIndex = 185;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label5.Location = new System.Drawing.Point(582, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 204;
            this.label5.Text = "ထုတ်ပေးသူ";
            // 
            // cmbGiver
            // 
            this.cmbGiver.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGiver.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGiver.DisplayMember = "APSubCategoryName";
            this.cmbGiver.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbGiver.FormattingEnabled = true;
            this.cmbGiver.Location = new System.Drawing.Point(706, 45);
            this.cmbGiver.Name = "cmbGiver";
            this.cmbGiver.Size = new System.Drawing.Size(150, 27);
            this.cmbGiver.TabIndex = 203;
            this.cmbGiver.Validating += new System.ComponentModel.CancelEventHandler(this.cmbGiver_Validating);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label4.Location = new System.Drawing.Point(323, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 202;
            this.label4.Text = "လက်ခံသူ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label3.Location = new System.Drawing.Point(582, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 201;
            this.label3.Text = "ထုတ်ပေးသည့် ဌာန";
            // 
            // cmbReciever
            // 
            this.cmbReciever.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbReciever.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReciever.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbReciever.FormattingEnabled = true;
            this.cmbReciever.Location = new System.Drawing.Point(390, 11);
            this.cmbReciever.Name = "cmbReciever";
            this.cmbReciever.Size = new System.Drawing.Size(150, 27);
            this.cmbReciever.TabIndex = 200;
            // 
            // cmbGiverDept
            // 
            this.cmbGiverDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGiverDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGiverDept.DisplayMember = "APSubCategoryName";
            this.cmbGiverDept.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbGiverDept.FormattingEnabled = true;
            this.cmbGiverDept.Location = new System.Drawing.Point(706, 11);
            this.cmbGiverDept.Name = "cmbGiverDept";
            this.cmbGiverDept.Size = new System.Drawing.Size(150, 27);
            this.cmbGiverDept.TabIndex = 195;
            this.cmbGiverDept.SelectedIndexChanged += new System.EventHandler(this.cmbGiverDept_SelectedIndexChanged);
            this.cmbGiverDept.Validating += new System.ComponentModel.CancelEventHandler(this.cmbGiverDept_Validating);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.textBox1.Location = new System.Drawing.Point(138, 47);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 28);
            this.textBox1.TabIndex = 199;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label1.Location = new System.Drawing.Point(16, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 198;
            this.label1.Text = "စာအမှတ်";
            // 
            // dtpIssueDate
            // 
            this.dtpIssueDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpIssueDate.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIssueDate.Location = new System.Drawing.Point(138, 12);
            this.dtpIssueDate.Name = "dtpIssueDate";
            this.dtpIssueDate.Size = new System.Drawing.Size(150, 28);
            this.dtpIssueDate.TabIndex = 197;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 196;
            this.label2.Text = "ထုတ်ပေးသည့် နေ့စွဲ";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.panel3);
            this.pnlFilter.Controls.Add(this.dtpSearchIssueDate);
            this.pnlFilter.Controls.Add(this.chkRequestDept);
            this.pnlFilter.Controls.Add(this.label7);
            this.pnlFilter.Controls.Add(this.cmbAPSubCat);
            this.pnlFilter.Controls.Add(this.btnViewAll);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 67);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(975, 51);
            this.pnlFilter.TabIndex = 184;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1007, 100);
            this.panel3.TabIndex = 174;
            // 
            // dtpSearchIssueDate
            // 
            this.dtpSearchIssueDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpSearchIssueDate.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.dtpSearchIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSearchIssueDate.Location = new System.Drawing.Point(98, 10);
            this.dtpSearchIssueDate.Name = "dtpSearchIssueDate";
            this.dtpSearchIssueDate.Size = new System.Drawing.Size(150, 28);
            this.dtpSearchIssueDate.TabIndex = 180;
            // 
            // chkRequestDept
            // 
            this.chkRequestDept.AutoSize = true;
            this.chkRequestDept.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.chkRequestDept.Location = new System.Drawing.Point(298, 14);
            this.chkRequestDept.Name = "chkRequestDept";
            this.chkRequestDept.Size = new System.Drawing.Size(133, 24);
            this.chkRequestDept.TabIndex = 183;
            this.chkRequestDept.Text = "တောင်းခံသည့်ဌာန";
            this.chkRequestDept.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.label7.Location = new System.Drawing.Point(16, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 20);
            this.label7.TabIndex = 179;
            this.label7.Text = "နေ့စွဲ";
            // 
            // cmbAPSubCat
            // 
            this.cmbAPSubCat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAPSubCat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAPSubCat.DisplayMember = "APSubCategoryName";
            this.cmbAPSubCat.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.cmbAPSubCat.FormattingEnabled = true;
            this.cmbAPSubCat.Location = new System.Drawing.Point(437, 12);
            this.cmbAPSubCat.Name = "cmbAPSubCat";
            this.cmbAPSubCat.Size = new System.Drawing.Size(150, 27);
            this.cmbAPSubCat.TabIndex = 13;
            this.cmbAPSubCat.ValueMember = "ID";
            // 
            // btnViewAll
            // 
            this.btnViewAll.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnViewAll.Location = new System.Drawing.Point(745, 10);
            this.btnViewAll.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(111, 30);
            this.btnViewAll.TabIndex = 3;
            this.btnViewAll.Text = "အကုန်ကြည့်မည်";
            this.btnViewAll.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.btnSearch.Location = new System.Drawing.Point(618, 10);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "ရှာမည်";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // pnlFilt
            // 
            this.pnlFilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilt.Controls.Add(this.lblFilter);
            this.pnlFilt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilt.Location = new System.Drawing.Point(0, 44);
            this.pnlFilt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlFilt.Name = "pnlFilt";
            this.pnlFilt.Size = new System.Drawing.Size(975, 23);
            this.pnlFilt.TabIndex = 183;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.Blue;
            this.lblFilter.Location = new System.Drawing.Point(3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(145, 20);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "▲ Hide Advance Search";
            this.lblFilter.Click += new System.EventHandler(this.lblFilter_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(145)))), ((int)(((byte)(131)))));
            this.panel2.Controls.Add(this.lblSetup);
            this.panel2.Controls.Add(this.lblHeaderPCat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 11, 3, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(975, 44);
            this.panel2.TabIndex = 182;
            // 
            // lblSetup
            // 
            this.lblSetup.AutoSize = true;
            this.lblSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetup.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblSetup.Location = new System.Drawing.Point(10, 12);
            this.lblSetup.Name = "lblSetup";
            this.lblSetup.Size = new System.Drawing.Size(54, 20);
            this.lblSetup.TabIndex = 0;
            this.lblSetup.Text = "A && P";
            this.lblSetup.Click += new System.EventHandler(this.lblSetup_Click);
            // 
            // lblHeaderPCat
            // 
            this.lblHeaderPCat.AutoSize = true;
            this.lblHeaderPCat.Font = new System.Drawing.Font("Myanmar3", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.lblHeaderPCat.Location = new System.Drawing.Point(70, 12);
            this.lblHeaderPCat.Name = "lblHeaderPCat";
            this.lblHeaderPCat.Size = new System.Drawing.Size(166, 20);
            this.lblHeaderPCat.TabIndex = 45;
            this.lblHeaderPCat.Text = ">  POSM ထုတ်ပေးခြင်း";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "APSubCategoryName";
            this.dataGridViewTextBoxColumn1.HeaderText = "A & P အမျိုးအစားခွဲ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 160;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "APMaterialName";
            this.dataGridViewTextBoxColumn2.HeaderText = "POSM";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "အကြောင်းအရာ";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "RequestQty";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.NullValue = "1";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn4.HeaderText = "Required Qty";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.NullValue = "1";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn5.HeaderText = "Issue Qty";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "မှတ်ချက်";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "RequestPurpose";
            this.dataGridViewTextBoxColumn7.HeaderText = "RequestPurpose";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "AP_IssueDetailID";
            this.dataGridViewTextBoxColumn8.HeaderText = "IssueDetailID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "AP_RequestDetailID";
            this.dataGridViewTextBoxColumn9.HeaderText = "RequestDetailID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "AP_MaterialID";
            this.dataGridViewTextBoxColumn10.HeaderText = "AP_MaterialID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // colAPSubCategory
            // 
            this.colAPSubCategory.DataPropertyName = "APSubCategoryName";
            this.colAPSubCategory.HeaderText = "A & P အမျိုးအစားခွဲ";
            this.colAPSubCategory.Name = "colAPSubCategory";
            this.colAPSubCategory.ReadOnly = true;
            this.colAPSubCategory.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAPSubCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAPSubCategory.Width = 160;
            // 
            // colPosm
            // 
            this.colPosm.DataPropertyName = "APMaterialName";
            this.colPosm.HeaderText = "POSM";
            this.colPosm.Name = "colPosm";
            this.colPosm.ReadOnly = true;
            this.colPosm.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPosm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPosm.Width = 180;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "အကြောင်းအရာ";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDescription.Width = 200;
            // 
            // colQuantity
            // 
            this.colQuantity.DataPropertyName = "RequestQty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.colQuantity.HeaderText = "Required Qty";
            this.colQuantity.MaxInputLength = 6;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colQuantity.Width = 90;
            // 
            // colIssueQty
            // 
            this.colIssueQty.DataPropertyName = "IssueQty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = "0";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colIssueQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colIssueQty.HeaderText = "Issue Qty";
            this.colIssueQty.MaxInputLength = 6;
            this.colIssueQty.Name = "colIssueQty";
            this.colIssueQty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colIssueQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colIssueQty.Width = 90;
            // 
            // colRemark
            // 
            this.colRemark.HeaderText = "မှတ်ချက်";
            this.colRemark.Name = "colRemark";
            this.colRemark.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colRemark.Width = 200;
            // 
            // colRequestPurpose
            // 
            this.colRequestPurpose.DataPropertyName = "RequestPurpose";
            this.colRequestPurpose.HeaderText = "RequestPurpose";
            this.colRequestPurpose.Name = "colRequestPurpose";
            this.colRequestPurpose.Visible = false;
            // 
            // colIssueDetailID
            // 
            this.colIssueDetailID.DataPropertyName = "AP_IssueDetailID";
            this.colIssueDetailID.HeaderText = "IssueDetailID";
            this.colIssueDetailID.Name = "colIssueDetailID";
            this.colIssueDetailID.Visible = false;
            // 
            // colRequestDetailID
            // 
            this.colRequestDetailID.DataPropertyName = "AP_RequestDetailID";
            this.colRequestDetailID.HeaderText = "RequestDetailID";
            this.colRequestDetailID.Name = "colRequestDetailID";
            this.colRequestDetailID.Visible = false;
            // 
            // colAP_MaterialID
            // 
            this.colAP_MaterialID.DataPropertyName = "AP_MaterialID";
            this.colAP_MaterialID.HeaderText = "AP_MaterialID";
            this.colAP_MaterialID.Name = "colAP_MaterialID";
            this.colAP_MaterialID.Visible = false;
            // 
            // frmPosmRecieve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(975, 453);
            this.Controls.Add(this.dgvPosmRecieve);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFilt);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Myanmar3", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPosmRecieve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POSM ထုတ်ပေးခြင်း";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosmRecieve)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlFilt.ResumeLayout(false);
            this.pnlFilt.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPosmRecieve;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGiver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbReciever;
        private System.Windows.Forms.ComboBox cmbGiverDept;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpIssueDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpSearchIssueDate;
        private System.Windows.Forms.CheckBox chkRequestDept;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbAPSubCat;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlFilt;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSetup;
        private System.Windows.Forms.Label lblHeaderPCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAPSubCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestPurpose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAP_MaterialID;

    }
}