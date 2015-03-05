using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.BL;
using PTIC.VC.Util;

namespace PTIC.VC.Sale.Inventory
{
    public partial class FinishedGoodRequestRecieve : Form
    {
        public FinishedGoodRequestRecieve()
        {
            InitializeComponent();
            dgvFGRequestIssue.AutoGenerateColumns = false;
            LoadNBind();
        }

        private void LoadNBind()
        {
            dgvFGRequestIssue.DataSource = new FGRequestBL().GetAllFGRequestIssue();
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmInventoryStorePage));
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (dgvFGRequestIssue.SelectedRows.Count > 0)
            {
                int FGRequest = (int)DataTypeParser.Parse(dgvFGRequestIssue.CurrentRow.Cells[colFGRequestID.Index].Value, typeof(int), -1);
                frmFinishedGoodsRequest _frmFinishedGoodRequest = new frmFinishedGoodsRequest(FGRequest);
                UIManager.MdiChildOpenForm(_frmFinishedGoodRequest);
                LoadNBind();
                this.Close();
            }
        }
    }
}
