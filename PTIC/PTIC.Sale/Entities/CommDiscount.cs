using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class CommDiscount
    {
        public int? ID {get; set;}
	    public int? InvoiceID {get; set;}
	    public int? SaleCommID {get; set;}
	    public int? CashCommID {get; set;}
        public decimal PackingAmt { get; set; }
        public decimal SaleCommAmt { get; set; }
        public decimal CashCommAmt { get; set; }
        public decimal OtherCommAmt { get; set; }
        public decimal RefundAmt { get; set; }
        public decimal NeedAmt { get; set; }
        public decimal TotalCommAmt { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }

    }
}
