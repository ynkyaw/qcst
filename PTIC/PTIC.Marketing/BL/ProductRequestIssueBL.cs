using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.VC.Marketing.Entities;

namespace PTIC.Marketing.BL
{
    public class ProductRequestIssueBL
    {
        public DataTable GetAllByProductReqIssueID(int ProductRequestIssueID)
        {
            return ProductRequestIssueDA.SelectByProductReqIssueID(ProductRequestIssueID);
        }

        public int Add(ProductRequestIssue _ProductRequestIssue, List<ProductRequestIssueDetail> _ProductRequestIssueDetail)
        {
            return ProductRequestIssueDA.Insert(_ProductRequestIssue, _ProductRequestIssueDetail);
        }

        public int Edit(ProductRequestIssue _ProductRequestIssue, List<ProductRequestIssueDetail> _ProductRequestIssueDetail)
        {
            return ProductRequestIssueDA.Update(_ProductRequestIssue, _ProductRequestIssueDetail);
        }

        public ProductRequestIssue GetProductRequestIssueById(int ProductRequestIssueID) 
        {
            return ProductRequestIssueDA.GetProductRequestIssueById(ProductRequestIssueID);
        }
    }
}
