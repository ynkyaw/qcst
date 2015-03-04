/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: Tax entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    /// <summary>
    /// Tax entity bean
    /// </summary>
    public class Tax
    {
        public int? ID { get; set; }
        public int? InvoiceID { get; set; }
        public decimal InsuranceAmt { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal TransportAmt { get; set; }
        public decimal TotalAmt { get; set; }
        public string GateInvNo { get; set; }
        public byte[] GateInvPhoto{ get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
