/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/13 (yyyy/MM/dd)
 * Description: 
 */
using System;
using System.Data;
namespace PTIC.Marketing.Entities
{
    public class POSM_UsageDetail
    {
        #region Properties
        public int? ID { get; set; }
        public int A_P_MaterialID { get; set; }
        public int BrandID { get; set; }
        public int POSM_UsageID { get; set; }
        public int Qty { get; set; }
        public int UsagePurpose { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion

        public static DataTable AsClonedDataTable()
        {
            DataTable dtUsageDetail = new DataTable("POSM_UsageDetailTableType");
            dtUsageDetail.Columns.Add("A_P_MaterialID", typeof(int));
            dtUsageDetail.Columns.Add("BrandID", typeof(int));
            dtUsageDetail.Columns.Add("POSM_UsageID", typeof(int));
            dtUsageDetail.Columns.Add("Qty", typeof(int));
            dtUsageDetail.Columns.Add("UsagePurpose", typeof(int));            
            dtUsageDetail.Columns.Add("Remark", typeof(string));

            return dtUsageDetail;
        }
    }
}
