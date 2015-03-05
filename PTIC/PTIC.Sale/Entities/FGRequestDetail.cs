using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class FGRequestDetail
    {
        public int ID {get;set;}
	    public int FGReqID {get;set;}
	    public int ProductID {get;set;}
        public int IssueQty { get; set; }
	    public int Qty {get;set;}
        public string FactoryRemark { get; set; }
	    public string Remark {get;set;}
	    public DateTime DateAdded {get;set;}
	    public DateTime LastModified {get;set;}
	    public bool IsDeleted {get;set;}
    }
}
