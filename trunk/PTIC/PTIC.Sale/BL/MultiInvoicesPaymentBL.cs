using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.Entities;
using PTIC.Sale.DA;
using System.Data;

namespace PTIC.Sale.BL
{
    public class MultiInvoicesPaymentBL
    {
        #region SELECT
        public DataTable GetAll()
        {
            return MultiInvoicesPaymentDA.SelectAll();
        }

        public DataTable GetBy(DateTime? startDate, DateTime? endDate, int? customerID, int? departmentID)
        {
            return MultiInvoicesPaymentDA.SelectBy(startDate, endDate, customerID, departmentID);
        }

        public DataTable GetByReceiptNo(string receiptNo)
        {
            return MultiInvoicesPaymentDA.SelectByReceiptNo(receiptNo);
        }
        #endregion

        #region INSERT
        public int? Add(Payment newPayment, List<Invoice> invoices)
        {
            return MultiInvoicesPaymentDA.Insert(newPayment, invoices);
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion
    }
}
