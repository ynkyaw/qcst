using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC;
using System.Drawing;
using PTIC.VC.Util;

namespace PTIC
{
    class UIManager
    {
        public static DateTime ChangeAnotherdtpOndtpChange(DateTimePicker dtp)
        {
            int intMonth = dtp.Value.Month;
            int intYear = dtp.Value.Year;
            int intDaysThisMonth = DateTime.DaysInMonth(intYear, intMonth);
            DateTime oBeginnngOfThisMonth = new DateTime(intYear, intMonth, 1);
            DateTime EndOfThisMonth = new DateTime(intYear, intMonth, intDaysThisMonth);
            // dtpFromDate.Value = oBeginnngOfThisMonth;
            return EndOfThisMonth;
        }

        public static DateTime ChangeOneMonthRange(DateTimePicker dtp)
        {
            int intMonth = dtp.Value.Month;
            int intYear = dtp.Value.Year;
            DateTime EndOfThisMonth=DateTime.Now;
            if (intMonth == 12)
            {
                int intDaysThisMonth = DateTime.DaysInMonth(intYear, intMonth);
                DateTime oBeginnngOfThisMonth = new DateTime(intYear, intMonth, 1);
                EndOfThisMonth = new DateTime(intYear, intMonth, intDaysThisMonth);
            }
            else
            {
                int intDaysThisMonth = DateTime.DaysInMonth(intYear, intMonth + 1);
                DateTime oBeginnngOfThisMonth = new DateTime(intYear, intMonth, 1);
                EndOfThisMonth = new DateTime(intYear, intMonth + 1, intDaysThisMonth);
            }
            // dtpFromDate.Value = oBeginnngOfThisMonth;
            return EndOfThisMonth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetFormType"></param>
        public static void MdiChildOpenForm(Type targetFormType)
        {
            Form frm = null;
            foreach (Form openedForm in Application.OpenForms)
            {
                if (openedForm.GetType() == targetFormType)
                {
                    frm = openedForm;
                    break;
                }
            }
            if (frm == null)
            {
                frm = (Form)Activator.CreateInstance(targetFormType);
                //if(targetFormType.FullName.Contains("PTIC.VC.Marketing"))
                if (Program.module == Program.Module.Marketing)
                {
                    frm.MdiParent = Program.marketintoyo;
                }
                else if (Program.module == Program.Module.Sale)
                {
                    frm.MdiParent = Program.toyo;
                }
                //else if (targetFormType.FullName.Contains("PTIC.Marketing"))
                //{
                //    frm.MdiParent = Program.marketintoyo;
                //}
                //else
                //{
                //    frm.MdiParent = Program.toyo;
                //}

                frm.WindowState = FormWindowState.Maximized;
            }
            frm.BringToFront();
            frm.Show();
        }

        public static void MdiChildOpenForm(Form targetForm)
        {
            Form frm = targetForm;
            foreach (Form openedForm in Application.OpenForms)
            {
                if (openedForm == targetForm)
                {
                    frm = openedForm;
                    break;
                }
            }
            if (frm == null)
            {
                frm = new Form();
            }
            if (Program.module == Program.Module.Marketing)
            {
                frm.MdiParent = Program.marketintoyo;
            }
            else if (Program.module == Program.Module.Sale)
            {
                frm.MdiParent = Program.toyo;
            }

            frm.WindowState = FormWindowState.Maximized;
            frm.BringToFront();
            frm.Show();
        }

        /// <summary>
        /// Open form as dialog
        /// </summary>
        /// <param name="targetFormType"></param>
        public static void OpenForm(Type targetFormType)
        {
            Form frm = (Form)Activator.CreateInstance(targetFormType);
            frm.ShowDialog();
        }

        /// <summary>
        /// Open form as dialog
        /// </summary>
        /// <param name="form"></param>
        public static void OpenForm(Form form)
        {
            if (form != null)
                form.ShowDialog();
        }

        /// <summary>
        /// GroupBox Borderless
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="p"></param>
        public static void PaintBorderlessGroupBox(object sender, PaintEventArgs p)
        {
            GroupBox box = (GroupBox)sender;
            p.Graphics.Clear(SystemColors.Control);
            p.Graphics.DrawString(box.Text, box.Font, Brushes.Black, 0, 0);
        }

        public static void ChangeBorderColorGroupBox(object sender, PaintEventArgs p)
        {
            GroupBox box = (GroupBox)sender;
            ControlPaint.DrawBorder(p.Graphics, box.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
        }

    }
}
