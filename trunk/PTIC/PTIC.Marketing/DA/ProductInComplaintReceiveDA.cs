using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;
using System.Data.SqlClient;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    public class ProductInComplaintReceiveDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECT
        public static DataTable SelectProductInComplaintReceiveByComplaintReceiveID(int ComplaintReceiveID)
        {
            DataTable dt=new DataTable();
            SqlConnection conn = null;
            try
            {
                conn= DBManager.GetInstance().GetDbConnection();
                string query = String.Format("SELECT Brand.ID As BrandID,ProductInComplaintReceive.ID As ProductInComplaintReceiveID, "
                                                +"ComplaintReceiveID,ComplaintCaseID,ProductID,Qty,ProductionDate FROM ProductInComplaintReceive "
                                                    +"INNER JOIN Product ON Product.ID = ProductInComplaintReceive.ProductID "
                                                        +"INNER JOIN ProdSubCategory ON ProdSubCategory.ID = Product.SubCategoryID "
                                                           +"INNER JOIN ProdCategory ON ProdCategory.ID = ProdSubCategory.CategoryID "
                                                               +"INNER JOIN Brand ON Brand.ID = ProdCategory.BrandID "
                                                                    + "WHERE ComplaintReceiveID=@ID");
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", ComplaintReceiveID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion
    }
}
