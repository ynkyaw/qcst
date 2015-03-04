using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AGL.UI.Controls
{
    public partial class EditTextBox : System.Windows.Forms.TextBox
    {
        ErrorProvider errprovider = new ErrorProvider();

        // Pattern from TextBox for Matching
        protected string validationPattern = string.Empty;

        // RegEx object that's used to perform the validation.
        protected Regex _ValidationExpression;
        
        #region Properties
        public string ErrorMessage { get; set; }

        public Color ErrorColor { get; set; }

        [DefaultValue("")]
        public string ValidationExpression
        {
            get
            {
                return validationPattern;
            }
            set
            {
                _ValidationExpression = new Regex(value);
                validationPattern = value;
            }
        }

        #endregion

        #region Private Method
        public bool IsValid
        {
            get
            {
                if (_ValidationExpression != null)
                {
                    return _ValidationExpression.IsMatch(this.Text);
                }
                else
                {
                    return true;
                }
            }

        }
        #endregion

        #region Override Method
        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {                            
            if (!this.IsValid)
            {
                this.ForeColor = ErrorColor;
                errprovider.SetError(this, ErrorMessage);
                e.Cancel = true;
            }
            else
            {
                this.ForeColor = System.Drawing.Color.Black;
                errprovider.SetError(this, "");
            }

            // Any time you inherit a control, and override one of
            // the On... subs, it's critical that you call the On...
            // method of the base class, or the control won't fire
            // events like it's supposed to.
            base.OnValidating(e);
        }
        #endregion

    }
    
}
