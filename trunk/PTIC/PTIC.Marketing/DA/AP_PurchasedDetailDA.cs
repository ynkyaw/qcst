using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Common.DA;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;

namespace PTIC.Marketing.DA
{
    public class AP_PurchasedDetailDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECT "AP_PurchasedInDetail By AP_EnquiryDetailID"
        public static DataTable SelectAP_PurchasedInDetailByAP_EnquiryID(int AP_EnquiryDetailID)
        {
            DataTable dt;
            try
            {
                string query = "SELECT AP_PurchasedDetail.ID As AP_PurchasedDetailID,AP_EnquiryDetailID,PurchasedDate,EntryPersonID,AP_PurchasedDetail.DeptID,PurchasedQty,AP_PurchasedDetail.Remark, "
                                      + "AP_Material.APMaterialName,AP_MaterialID,AP_SubCategory.APSubCategoryName,AP_SubCategory.ID As AP_SubCategoryID,AP_EnquiryDetail.UnitCost,AP_PurchasedDetail.PresentQty, "
                                       +"Employee.EmpName "  
                                      + "FROM AP_PurchasedDetail "
                                            + "INNER JOIN AP_EnquiryDetail ON AP_EnquiryDetail.ID = AP_PurchasedDetail.AP_EnquiryDetailID "
                                             +"INNER JOIN AP_Material ON AP_Material.ID = AP_EnquiryDetail.AP_MaterialID "
                                                +"INNER JOIN AP_SubCategory ON AP_SubCategory.ID = AP_Material.APSubCategoryID "
                                                 +"INNER JOIN Employee ON Employee.ID = AP_PurchasedDetail.EntryPersonID "
                                                + "WHERE AP_EnquiryDetailID = {0} AND AP_PurchasedDetail.IsDeleted =0";
                //string query = "SELECT AP_StockIn_Detail.BrandID,AP_StockIn_Detail.UnitCost,AP_StockIn_Detail.APMaterialID As AP_MaterialID,AP_SubCategory.ID As AP_SubCategoryID, "
                //                        + "AP_StockIn_Detail.Qty,AP_StockIn_Detail.Remark,AP_StockIn_Detail.APStockInID,AP_StockIn_Detail.ID As APStockInDetailID "
                //                            +"FROM AP_StockIn_Detail INNER JOIN AP_Material ON AP_Material.ID = AP_StockIn_Detail.APMaterialID "
                //                                +"INNER JOIN AP_SubCategory ON AP_SubCategory.ID = AP_Material.APSubCategoryID WHERE APStockInID ={0}";

                dt = b.SelectByQuery(string.Format(query, AP_EnquiryDetailID));
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        #endregion

        #region Insert
        public static int Insert(AP_PurchasedDetail _apPurchasedDetail, int APMaterialID,SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_AP_PurchasedInDetailInsert";

                cmd.Parameters.AddWithValue("@p_AP_EnquiryDetailID", _apPurchasedDetail.AP_EnquiryDetailID);
                cmd.Parameters["@p_AP_EnquiryDetailID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PurchasedDate", _apPurchasedDetail.PurchasedDate);
                cmd.Parameters["@p_PurchasedDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EntryPersonID", _apPurchasedDetail.EntryPersonID);
                cmd.Parameters["@p_EntryPersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DeptID", _apPurchasedDetail.DeptID);
                cmd.Parameters["@p_DeptID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_APMaterialID", APMaterialID);
                cmd.Parameters["@p_APMaterialID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PurchasedQty", _apPurchasedDetail.PurchasedQty);
                cmd.Parameters["@p_PurchasedQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PresentQty", _apPurchasedDetail.PresentQty);
                cmd.Parameters["@p_PresentQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", _apPurchasedDetail.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region SELECT ALL "AP_PurchasedInDetail"
        public static DataTable SelectAllPurchasedInDetail()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT PurchasedDate,PresentQty,EmpName,AP_SubCategory.APSubCategoryName,AP_Material.APMaterialName,PurchasedQty,UnitCost,AP_Material.APMaterialName, "
                                                    +"AP_MaterialID,AP_SubCategory.ID As AP_SubCategoryID "
                                                      +"FROM AP_PurchasedDetail "
                                                        +"INNER JOIN AP_EnquiryDetail ON AP_EnquiryDetail.ID = AP_PurchasedDetail.AP_EnquiryDetailID "
                                                           +"INNER JOIN AP_Material ON AP_Material.ID = AP_EnquiryDetail.AP_MaterialID "
                                                              +"INNER JOIN AP_SubCategory ON AP_SubCategory.ID = AP_Material.APSubCategoryID "
                                                                +"INNER JOIN Employee ON Employee.ID = AP_PurchasedDetail.EntryPersonID "
                                                                    +"WHERE AP_PurchasedDetail.IsDeleted =0");

                // dt = b.SelectAll("AP_StockIn_Detail");
            }
            catch (SqlException Sqle)
            {
                throw;
            }
            return dt;
        }
        #endregion

        #region SELECT ALL "AP_PurchasedInDetailByDate"
        public static DataTable SelectAllPurchasedInDetailByDate(DateTime PurchasedDate)
        {
            DataTable dt;
            try
            {
                string query = "SELECT PurchasedDate,PresentQty,EmpName,AP_SubCategory.APSubCategoryName,AP_Material.APMaterialName,PurchasedQty,UnitCost,AP_Material.APMaterialName, "
                                                    + "AP_MaterialID,AP_SubCategory.ID As AP_SubCategoryID "
                                                      + "FROM AP_PurchasedDetail "
                                                        + "INNER JOIN AP_EnquiryDetail ON AP_EnquiryDetail.ID = AP_PurchasedDetail.AP_EnquiryDetailID "
                                                           + "INNER JOIN AP_Material ON AP_Material.ID = AP_EnquiryDetail.AP_MaterialID "
                                                              + "INNER JOIN AP_SubCategory ON AP_SubCategory.ID = AP_Material.APSubCategoryID "
                                                                + "INNER JOIN Employee ON Employee.ID = AP_PurchasedDetail.EntryPersonID "
                                                                    + "WHERE AP_PurchasedDetail.IsDeleted =0 AND DAY(AP_PurchasedDetail.PurchasedDate) = DAY(CAST('{0}' As DateTime)) AND Month(AP_PurchasedDetail.PurchasedDate) = Month(CAST('{0}' As DateTime)) AND "
                                                                        + "YEAR(AP_PurchasedDetail.PurchasedDate)=YEAR(CAST('{0}' As DateTime))";
                dt = b.SelectByQuery(String.Format(query,PurchasedDate));

                // dt = b.SelectAll("AP_StockIn_Detail");
            }
            catch (SqlException Sqle)
            {
                throw;
            }
            return dt;
        }
        #endregion
    }
}
