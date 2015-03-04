using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PTIC
{
    public partial class frmImageViewer : Form
    {
        public frmImageViewer(Image img)
        {
            InitializeComponent();
            // Show image on PictureBox
            picBx.Image = img;
        }
    }
}
