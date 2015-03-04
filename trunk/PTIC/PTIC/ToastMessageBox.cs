using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PTIC.VC
{
    public partial class ToastMessageBox : Form
    {
        private void ToastMsgBox_Load(object sender, EventArgs e)
        {
            timer.Start();    
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Interval += 1000;
            if (timer.Interval > 1500)
            {
                this.Dispose();
                timer.Stop();
            }
        }

        private ToastMessageBox()
        {
            InitializeComponent();
        }

        private ToastMessageBox(String messageStr)
            : this()
        {
            lblMessage.Text = messageStr;
        }

        public static void Show(String message)
        {
            ToastMessageBox msgBox = new ToastMessageBox(message);
            msgBox.Show();
        }

        private ToastMessageBox(String mStr, Color colour) :this()
        {
            lblMessage.ForeColor = colour;
            lblMessage.Text = mStr;
        }

        public static void Show(String message,Color colour)
        {
            ToastMessageBox msgBox = new ToastMessageBox(message,colour);
            msgBox.Show();
        }
    }
}
