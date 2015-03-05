/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: Customer entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Sale.Entities
{
    /// <summary>
    /// Customer entity bean
    /// </summary>
    public class Customer
    {
        #region Properties
        public int ID { get; set; }
        public int AddrID { get; set; }
        public int? RouteID { get; set; }
        public int? BankID { get; set; }
        public int? TripID { get; set; }

        [DomainValidator(
                    (int)PTIC.Common.Enum.CustomerType.EndUser, (int)PTIC.Common.Enum.CustomerType.RetailOutlet,
                    (int)PTIC.Common.Enum.CustomerType.WholeSaleOutlet, (int)PTIC.Common.Enum.CustomerType.Company,
                    (int)PTIC.Common.Enum.CustomerType.Government, (int)PTIC.Common.Enum.CustomerType.Branch,
                    MessageTemplateResourceName = "Customer_CusType_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int CusType { get; set; }

        public int CusClassID { get; set; }
        public String CusCode { get; set; }

        [NotNullValidator(MessageTemplateResourceName = "Customer_CusName_Require",
            MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        [StringLengthValidator(1, 50,
            MessageTemplateResourceName = "Customer_CusName_Require",
            MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public String CusName { get; set; }

        public String Phone1 { get; set; }
        public String Phone2 { get; set; }
        public String Fax { get; set; }
        public String Email { get; set; }
        public String Website { get; set; }
        public String BankAccNo { get; set; }
        public decimal CreditAmount { get; set; }
        public int CreditLimit { get; set; }
        public DateTime CusDate { get; set; }
        public byte[] Photo1 { get; set; }
        public byte[] Photo2 { get; set; }
        public byte[] Photo3 { get; set; }
        public byte[] Photo4 { get; set; }
        public byte[] Photo5 { get; set; }
        public bool IsPotential { get; set; }
        public bool IsMain { get; set; }
        public bool IsDevice { get; set; }
        public String Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}
