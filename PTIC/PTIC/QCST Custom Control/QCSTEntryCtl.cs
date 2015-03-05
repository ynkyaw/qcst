using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QCST.WinFormControl
{
    public partial class QCSTEntryCtl : UserControl
    {
        bool isNullorEmpayVlaidate=false;

        public bool IsNullorEmpayVlaidate
        {
            get { return isNullorEmpayVlaidate; }
            set { isNullorEmpayVlaidate = value; }
        }

        public QCSTEntryCtl()
        {
            InitializeComponent();
        }


        public string LabelText 
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        public string ErrorLabelText
        {
            get { return errorLblText.Text; }
            set { errorLblText.Text = value; }
        }

        public string TextBoxText 
        {
            get { return txtValue.Text; }
            set { txtValue.Text = value; }
        }

        
        

        private void txtValue_Leave(object sender, EventArgs e)
        {
            if (isNullorEmpayVlaidate) 
            {
                if (string.IsNullOrWhiteSpace(txtValue.Text)) 
                {
                    txtValue.BackColor = Color.Yellow;
                    txtValue.Focus();
                    errorLblText.Visible = true;
                }
            }
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (isNullorEmpayVlaidate)
            {
             
                    txtValue.BackColor = Color.White;
                    errorLblText.Visible = false;
             
            }
        } 
    }
}
