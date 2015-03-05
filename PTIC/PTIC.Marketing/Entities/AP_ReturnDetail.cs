/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/13 (yyyy/MM/dd)
 * Description: 
 */
using System;
using System.Data;
namespace PTIC.Marketing.Entities
{
    public class AP_ReturnDetail
    {
        #region Properties
        public int ID { get; set; }
        public int AP_ReturnID { get; set; }
        public int AP_MaterialID { get; set; }
        public int ReturnQty { get; set; }
        public int ReturnPurpose { get; set; }
        public string Remark { get; set; }        
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion

        public static DataTable AsClonedDataTable()
        {
            DataTable dtReturnDetail = new DataTable("AP_ReturnDetailTableType");
            dtReturnDetail.Columns.Add("AP_ReturnID", typeof(int));
            dtReturnDetail.Columns.Add("AP_MaterialID", typeof(int));
            dtReturnDetail.Columns.Add("ReturnQty", typeof(int));
            dtReturnDetail.Columns.Add("ReturnPurpose", typeof(int));            
            dtReturnDetail.Columns.Add("Remark", typeof(string));

            return dtReturnDetail;
        }
    }
}
