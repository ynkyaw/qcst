using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Validation;

namespace PTIC.Marketing.TripPlan_Request
{
    public partial class frmTripRecord : Form
    {
        #region Events

        #endregion

        #region Private Methods

        #endregion

        #region Constructors
        public frmTripRecord()
        {
            InitializeComponent();
            // Allow only interger
            txtDebitConflictShop.ValidationExpression =
            txtShopWithoutOwnerSign.ValidationExpression =
            txtPrevDebitAmt.ValidationExpression =
            txtRentAmt.ValidationExpression =            
            txtFoodAmt.ValidationExpression =
            txtTransportAmt.ValidationExpression =
            txtCommunicationAmt.ValidationExpression =
            txtOtherExpense.ValidationExpression =
            txtRemittanceAmt.ValidationExpression = PatternRule.NaturalNumberNonZero;
            
        }
        #endregion

    }
}
