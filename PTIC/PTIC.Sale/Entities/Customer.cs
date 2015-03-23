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

        override public string ToString()
        {
            string str = String.Empty;
            str = String.Concat(str, "ID = ", ID, "\r\n");
            str = String.Concat(str, "AddrID = ", AddrID, "\r\n");
            str = String.Concat(str, "RouteID = ", RouteID, "\r\n");
            str = String.Concat(str, "BankID = ", BankID, "\r\n");
            str = String.Concat(str, "TripID = ", TripID, "\r\n");
            str = String.Concat(str, "CusType = ", CusType, "\r\n");
            str = String.Concat(str, "CusClassID = ", CusClassID, "\r\n");
            str = String.Concat(str, "CusCode = ", CusCode, "\r\n");
            str = String.Concat(str, "CusName = ", CusName, "\r\n");
            str = String.Concat(str, "Phone1 = ", Phone1, "\r\n");
            str = String.Concat(str, "Phone2 = ", Phone2, "\r\n");
            str = String.Concat(str, "Fax = ", Fax, "\r\n");
            str = String.Concat(str, "Email = ", Email, "\r\n");
            str = String.Concat(str, "Website = ", Website, "\r\n");
            str = String.Concat(str, "BankAccNo = ", BankAccNo, "\r\n");
            str = String.Concat(str, "CreditAmount = ", CreditAmount, "\r\n");
            str = String.Concat(str, "CreditLimit = ", CreditLimit, "\r\n");
            str = String.Concat(str, "CusDate = ", CusDate, "\r\n");
            str = String.Concat(str, "Photo1 = ", Photo1, "\r\n");
            str = String.Concat(str, "Photo2 = ", Photo2, "\r\n");
            str = String.Concat(str, "Photo3 = ", Photo3, "\r\n");
            str = String.Concat(str, "Photo4 = ", Photo4, "\r\n");
            str = String.Concat(str, "Photo5 = ", Photo5, "\r\n");
            str = String.Concat(str, "IsPotential = ", IsPotential, "\r\n");
            str = String.Concat(str, "IsMain = ", IsMain, "\r\n");
            str = String.Concat(str, "IsDevice = ", IsDevice, "\r\n");
            str = String.Concat(str, "Remark = ", Remark, "\r\n");
            str = String.Concat(str, "DateAdded = ", DateAdded, "\r\n");
            str = String.Concat(str, "LastModified = ", LastModified, "\r\n");
            str = String.Concat(str, "IsDeleted = ", IsDeleted, "\r\n");
            return str;
        }

    }
}
