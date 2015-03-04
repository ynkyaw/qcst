using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class Invoice
    {
        #region Properties
        [DataMember]
        public int? ID { get; set; }
        [DataMember]
        public int? DeliveryID { get; set; }
        [DataMember]
        public int CusID { get; set; }
        [DataMember]
        public int SalesPersonID { get; set; }
        [DataMember]
        public int SaleType { get; set; } // 0: Credit 1: Cosignment
        [DataMember]
        public int TransportTypeID { get; set; }
        [DataMember]
        public int? TransportGateID { get; set; }
        [DataMember]
        public string InvoiceNo { get; set; }
        [DataMember]        
        public DateTime SalesDate { get; set; }
        [DataMember]
        public string GateInvNo { get; set; }
        [DataMember]
        public int TransportCharges { get; set; }
        [DataMember]
        public decimal TotalAmt { get; set; }
        //[DataMember]
        //public decimal TotalAmt { get; set; }
        ////public int Refree1 {get;set;}
        ////public int Refree2 {get;set;}        
        [DataMember]
        public decimal CommDiscAmt { get; set; }
        [DataMember]
        public decimal OtherAmt { get; set; }
        [DataMember]
        public decimal NetAmt { get; set; }
        //[DataMember]
        //public decimal PaidAmt { get; set; }
        [DataMember]
        public decimal BalanceAmt { get; set; }
        //[DataMember]
        //public bool IsMain { get; set; }
        //[DataMember]
        //public bool IsDevice { get; set; }
        //[DataMember]
        //public int VoucherType { get; set; } // 0 :Credit 1:Cash
        //[DataMember]
        //public bool Paid { get; set; }

        [DataMember]
        public List<SalesInvoiceDetail> InvoiceDetails { get; set; }

        /*** Sold from place ***/
        [DataMember]
        public int? VehicleID { get; set; }
        [DataMember]
        public int? WarehouseID { get; set; }
        #endregion
    }
}