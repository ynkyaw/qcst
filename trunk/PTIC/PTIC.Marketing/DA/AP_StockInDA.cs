using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.DA
{
    public class AP_StockInDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECT ALL "AP_StockInDetail"
        public static DataTable SelectAllStockInDetail()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT AP_StockIn_Detail.ID As APStockInDetailID,APStockInID,APMaterialID,Qty,Remark,UnitCost,AP_SubCategory.ID, "
                                                   +"AP_StockIn.EntryDate,AP_StockIn.EntryPersonID,AP_StockIn.DeptID, "
                                                    +"AP_StockIn.DeptID,APMaterialName,APSubCategoryName,EmpName "
                                                    + "FROM AP_StockIn_Detail INNER JOIN AP_Material ON AP_Material.ID = AP_StockIn_Detail.APMaterialID "
                                                        + "INNER JOIN AP_SubCategory ON AP_SubCategory.ID = AP_Material.APSubCategoryID "
                                                            +"INNER JOIN AP_StockIn ON AP_StockIn.ID = AP_StockIn_Detail.APStockInID "
                                                                +"INNER JOIN Employee ON Employee.ID = AP_StockIn.EntryPersonID WHERE AP_StockIn_Detail.IsDeleted =0");

               // dt = b.SelectAll("AP_StockIn_Detail");
            }
            catch (SqlException Sqle)
            {
                throw;
            }
            return dt;
        }

        public static DataTable SelectAllStockInDetailByDate(DateTime EntryDate)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT AP_StockIn_Detail.ID As APStockInDetailID,APStockInID,APMaterialID,Qty,Remark,UnitCost,AP_SubCategory.ID, "
                                                   + "AP_StockIn.EntryDate,AP_StockIn.EntryPersonID,AP_StockIn.DeptID, "
                                                    + "AP_StockIn.DeptID,APMaterialName,APSubCategoryName,EmpName "
                                                    + "FROM AP_StockIn_Detail INNER JOIN AP_Material ON AP_Material.ID = AP_StockIn_Detail.APMaterialID "
                                                        + "INNER JOIN AP_SubCategory ON AP_SubCategory.ID = AP_Material.APSubCategoryID "
                                                            + "INNER JOIN AP_StockIn ON AP_StockIn.ID = AP_StockIn_Detail.APStockInID "
                                                                + "INNER JOIN Employee ON Employee.ID = AP_StockIn.EntryPersonID "
                                                                    +"WHERE CONVERT(VARCHAR(10),EntryDate,103) = CONVERT(VARCHAR(10),CAST('" + EntryDate +"' As DateTime),103)");

                // dt = b.SelectAll("AP_StockIn_Detail");
            }
            catch (SqlException Sqle)
            {
                throw;
            }
            return dt;
        }
        #endregion

        #region SELECT "AP_StockIn By Date"
        public static DataTable SelectAP_StockInByDate(DateTime StockInDate)
        {
            DataTable dt;
            try
            {               
                string query = "SELECT ID As APStockInID,EntryDate,EntryPersonID,DeptID FROM AP_StockIn "
                                        + "WHERE DAY(AP_StockIn.EntryDate) = DAY(CAST('{0}' As DateTime)) AND Month(AP_StockIn.EntryDate) = Month(CAST('{0}' As DateTime)) AND "
                                            + "YEAR(AP_StockIn.EntryDate)=YEAR(CAST('{0}' As DateTime))";
                dt = b.SelectByQuery(string.Format(query, StockInDate));               
            }
            catch (SqlException Sqle)
            {                
                throw;
            }
            return dt;
        }
	    #endregion

        #region SELECT "AP_StockInDetail By AP_StockInID"
        public static DataTable SelectAP_StockInDetailByAP_StockInID(int AP_StockInID)
        {
            DataTable dt;
            try 
	        {
                string query = "SELECT AP_StockIn_Detail.UnitCost,AP_StockIn_Detail.APMaterialID As AP_MaterialID,AP_SubCategory.ID As AP_SubCategoryID, "
                                        + "AP_StockIn_Detail.Qty,AP_StockIn_Detail.Remark,AP_StockIn_Detail.APStockInID,AP_StockIn_Detail.ID As APStockInDetailID "
                                            + "FROM AP_StockIn_Detail INNER JOIN AP_Material ON AP_Material.ID = AP_StockIn_Detail.APMaterialID "
                                                + "INNER JOIN AP_SubCategory ON AP_SubCategory.ID = AP_Material.APSubCategoryID WHERE APStockInID ={0} AND AP_StockIn_Detail.IsDeleted =0";

                //string query = "SELECT AP_StockIn_Detail.BrandID,AP_StockIn_Detail.UnitCost,AP_StockIn_Detail.APMaterialID As AP_MaterialID,AP_SubCategory.ID As AP_SubCategoryID, "
                //                        + "AP_StockIn_Detail.Qty,AP_StockIn_Detail.Remark,AP_StockIn_Detail.APStockInID,AP_StockIn_Detail.ID As APStockInDetailID "
                //                            +"FROM AP_StockIn_Detail INNER JOIN AP_Material ON AP_Material.ID = AP_StockIn_Detail.APMaterialID "
                //                                +"INNER JOIN AP_SubCategory ON AP_SubCategory.ID = AP_Material.APSubCategoryID WHERE APStockInID ={0}";

                dt =b.SelectByQuery(string.Format(query,AP_StockInID));
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }
            return dt;
        }
        #endregion

        #region Insert "AP_StockIn and AP_StockInDetail"
        public static int Insert(AP_StockIn _APStockIn, List<AP_StockInDetail> _APStockInDetail, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new a & p plan
                cmd.CommandText = "usp_AP_StockInInsert";

                cmd.Parameters.AddWithValue("@p_EntryDate", _APStockIn.EntryDate);
                cmd.Parameters["@p_EntryDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EntryPersonID", _APStockIn.EntryPersonID);
                cmd.Parameters["@p_EntryPersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DeptID", _APStockIn.DeptID);
                cmd.Parameters["@p_DeptID"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();

                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                int insertedStockInID = (int)insertedIDObj;
                // clear parameters of usp_AP_StockInInsert
                cmd.Parameters.Clear();

                // insert new StockInDetails
                cmd.CommandText = "usp_AP_StockInDetailInsert";
                foreach (AP_StockInDetail newAPStockInDetail in _APStockInDetail)
                {
                    cmd.Parameters.AddWithValue("@p_APStockInID", insertedStockInID);
                    cmd.Parameters["@p_APStockInID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_APMaterialID", newAPStockInDetail.APMaterialID);
                    cmd.Parameters["@p_APMaterialID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_BrandID", newAPStockInDetail.BrandID);
                    //cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", newAPStockInDetail.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newAPStockInDetail.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_UnitCost", newAPStockInDetail.UnitCost);
                    cmd.Parameters["@p_UnitCost"].Direction = ParameterDirection.Input;
                    
                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_A_P_PlanDetailInsert
                    cmd.Parameters.Clear();
                }
                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    affectedRows = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedRows;
        }
        #endregion

        #region Update
        public static int Update(AP_StockIn newAPStockIn, List<AP_StockInDetail> newAPStockInDetail, SqlConnection conn)
        {
            int affectedrow = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;              

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_AP_StockInDetailUpdateByStockInID";

                foreach (AP_StockInDetail newApPlanDetails in newAPStockInDetail)
                {
                    cmd.Parameters.AddWithValue("@p_APStockInDetailID", newApPlanDetails.ID);
                    cmd.Parameters["@p_APStockInDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_APStockInID", newAPStockIn.ID);
                    cmd.Parameters["@p_APStockInID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_APMaterialID", newApPlanDetails.APMaterialID);
                    cmd.Parameters["@p_APMaterialID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_DeptID", newAPStockIn.DeptID);
                    cmd.Parameters["@p_DeptID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", newApPlanDetails.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newApPlanDetails.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_BrandID", newApPlanDetails.BrandID);
                    //cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_UnitCost", newApPlanDetails.UnitCost);
                    cmd.Parameters["@p_UnitCost"].Direction = ParameterDirection.Input;

                    affectedrow += cmd.ExecuteNonQuery();
                }

                return affectedrow;
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        public static int UpdateByAPStockInID(AP_StockIn newAPStockIn, List<AP_StockInDetail> newAPStockInDetail, SqlConnection conn)
        {
            int affectedrow = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_AP_StockInDetailInsert";

                foreach (AP_StockInDetail newApPlanDetails in newAPStockInDetail)
                {
                    cmd.Parameters.AddWithValue("@p_APStockInID", newAPStockIn.ID);
                    cmd.Parameters["@p_APStockInID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_APMaterialID", newApPlanDetails.APMaterialID);
                    cmd.Parameters["@p_APMaterialID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", newApPlanDetails.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newApPlanDetails.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_BrandID", newApPlanDetails.BrandID);
                    //cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_UnitCost", newApPlanDetails.UnitCost);
                    cmd.Parameters["@p_UnitCost"].Direction = ParameterDirection.Input;

                    affectedrow += cmd.ExecuteNonQuery();
                }

                return affectedrow;
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region Delete
        public static int DeleteByapPosmPurchasedDetailID(int DeleteByAPStockInDetailID, SqlConnection conn)
        {
            int affectedRows = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_APStockInDetailDeleteByID";

                cmd.Parameters.AddWithValue("@p_APStockInDetailID", DeleteByAPStockInDetailID);
                cmd.Parameters["@p_APStockInDetailID"].Direction = ParameterDirection.Input;

                affectedRows = cmd.ExecuteNonQuery();

            }
            catch (SqlException sqle)
            {
                return 0;
            }
            return affectedRows;
        }

        #endregion

    }
}
