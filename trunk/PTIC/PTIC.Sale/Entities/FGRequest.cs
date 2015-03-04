using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class FGRequest
    {
        public int ID {get;set;}
	    public string ReqVouNo {get;set;}
        public DateTime IssueDate { get; set; }
	    public DateTime ReqDate {get;set;}
	    public DateTime RequireDate {get;set;}
        public int? TransportVenID { get; set; }
        public int? TarnsportEmpID { get; set; }
        public int RequesterID { get; set; }
	    public string Remark {get;set;}
        public string FactoryFormRemark { get; set; }
	    public DateTime DateAdded {get;set;}
	    public DateTime LastModified {get;set;}
        public bool IsDeleted { get; set; }

    }
}
