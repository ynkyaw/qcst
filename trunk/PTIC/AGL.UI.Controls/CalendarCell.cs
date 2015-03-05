﻿/* Author   :   Aung Ko Ko
    Date      :   14 Feb 2014
    Description :   
    Credit      :http://msdn.microsoft.com/en-us/library/7tas5c80.aspx
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace AGL.UI.Controls
{
    public class CalendarCell : DataGridViewTextBoxCell
    {
        public CalendarCell()
            : base()
        {
            // Use the short date format. 
            this.Style.Format = "d";
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value. 
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CalendarEditingControl ctl =
                DataGridView.EditingControl as CalendarEditingControl;
           
            // Use the default row value when Value property is null. 
             if (this.Value == null)
            {
                ctl.Value = (DateTime)this.DefaultNewRowValue;
            }
              else
            {               
                //ctl.Value = (DateTime)this.Value;
                ctl.Value = (DateTime)DateTime.Now;
            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that CalendarCell uses. 
                return typeof(CalendarEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains. 

                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value. 
                return DateTime.Now;
            }
        }
    }
}
