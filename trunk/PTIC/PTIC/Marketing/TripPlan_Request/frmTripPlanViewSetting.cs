using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PTIC.Marketing.TripPlan_Request
{
    public partial class frmTripPlanViewSetting : Form
    {
        DataGridView dgv = null;
        List<string> invisibleColumnList = null;
        public frmTripPlanViewSetting()
        {
            InitializeComponent();
        }

        public frmTripPlanViewSetting(DataGridView dgv,List<string> invisibleColumnsList)
        {
            InitializeComponent();
            this.dgv = dgv;
            this.invisibleColumnList = invisibleColumnsList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int treeCount = 0;
            for (int i = 0; i < dgv.Columns.Count;i++ )
            {
                if(!invisibleColumnList.Contains(dgv.Columns[i].Name)&&treeCount<treeView1.Nodes.Count)
                    dgv.Columns[i].Visible = treeView1.Nodes[treeCount++].Checked;
            }
        }

        private void frmTripPlanViewSetting_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn dgvCol in dgv.Columns) 
            {
                if(!invisibleColumnList.Contains(dgvCol.Name))
                {
                    treeView1.Nodes.Add(dgvCol.HeaderText);
                    treeView1.Nodes[treeView1.Nodes.Count-1].Checked = dgvCol.Visible;
                }
            }
        }
    }
}
