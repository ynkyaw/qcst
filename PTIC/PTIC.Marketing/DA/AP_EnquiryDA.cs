using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    public class AP_EnquiryDA
    {
        public static BaseDAO b = new BaseDAO();

        #region SELECT

        public static DataTable SelectAllEnquiry()
        {
            DataTable dtAP_Enquiry;
            try
            {
                string query = "SELECT [ID],[OpenDate],[CloseDate],[COORemark],[DateAdded],[LastModified],[IsDeleted],SUBSTRING('Jan Feb Mar Apr May Jun Jul Aug Sep Oct Nov Dec ', (MONTH(ap_planMonth) * 4) - 3, 3)+' , '+DateName(Year,AP_PlanMonth) AP_PlanMonth FROM [AP_Enquiry]";
                dtAP_Enquiry = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dtAP_Enquiry;
        }

        public static DataTable SelectBalanceByAPMaterialID(int APMaterialID)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT AP_StockInDepartment.Qty,AP_Material.APMaterialName,DeptID "
                                                + "FROM AP_StockInDepartment "
                                                    + " JOIN AP_Material ON AP_Material.ID = AP_StockInDepartment.AP_MaterialID "
                                                        + "WHERE AP_MaterialID =" + APMaterialID + "AND AP_StockInDepartment.IsDeleted =0");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable SelectBalanceByAPMaterialIDVenID(int APMaterialID, int VenID)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT AP_StockInVehicle.Qty,AP_Material.APMaterialName "
                                     +"FROM AP_StockInVehicle "
                                     +"JOIN AP_Material ON AP_Material.ID = AP_StockInVehicle.AP_MaterialID "
                                     +"WHERE AP_MaterialID =" + APMaterialID +" AND VehicleID ="+ VenID +"AND AP_StockInVehicle.IsDeleted =0");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public static DataTable SelectBalanceByAPMaterialIDDeptID(int APMaterialID, int DeptID)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT AP_StockInDepartment.Qty,AP_Material.APMaterialName "
                                                + "FROM AP_StockInDepartment "
                                                    + " JOIN AP_Material ON AP_Material.ID = AP_StockInDepartment.AP_MaterialID "
                                                        + "WHERE AP_MaterialID =" + APMaterialID + "AND DeptID=" + DeptID + "AND AP_StockInDepartment.IsDeleted =0");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable SelectAllEnquiryByDate(DateTime StartDate, DateTime EndDate)
        {
            DataTable dtAP_Enquiry = null;
            try
            {

                string query = "SELECT [ID],[OpenDate],[CloseDate],[COORemark],[DateAdded],[LastModified],[IsDeleted],SUBSTRING('Jan Feb Mar Apr May Jun Jul Aug Sep Oct Nov Dec ', (MONTH(ap_planMonth) * 4) - 3, 3)+' , '+DateName(Year,AP_PlanMonth) AP_PlanMonth FROM [AP_Enquiry]"
                                + "WHERE CAST(OpenDate As Date) BETWEEN "
                                + "CAST('{0}' As Date) AND CAST('{1}' As Date)";

                dtAP_Enquiry = b.SelectByQuery(string.Format(query,StartDate,EndDate));
            }
            catch (Exception ex)
            {
            }
            return dtAP_Enquiry;
        }

        public static DataTable SelectAllAP_EnquiryDetail(DateTime? EnquiryDate)
        {
            DataTable dtAP_EnquiryDetail;
            try
            {
                dtAP_EnquiryDetail = b.SelectByQuery("SELECT AP_EnquiryDetail.ID As AP_EnquiryDetailID,AP_EnquiryID,SupplierID,OpenDate,Total, "
                                            + "AP_MaterialID,EnquiryDate,ApprovedQty,UnitCost,IsAccepted,Remark, "
                                                + "Supplier.SupplierName,AP_Material.APMaterialName,LastRequireDate, "
                                                    + "AP_SubCategory.ID As AP_SubCategoryID,AP_SubCategory.APSubCategoryName,AP_Enquiry.COORemark "
                                                        + "FROM AP_EnquiryDetail "
                                                            + "INNER JOIN AP_Enquiry ON AP_Enquiry.ID = AP_EnquiryDetail.AP_EnquiryID "
                                                                + "INNER JOIN Supplier ON Supplier.ID = AP_EnquiryDetail.SupplierID "
                                                                    + "INNER JOIN AP_Material ON AP_Material.ID = AP_EnquiryDetail.AP_MaterialID "
                                                                        + "LEFT JOIN	AP_SubCategory ON AP_SubCategory.ID = AP_Material.APSubCategoryID WHERE AP_EnquiryDetail.IsDeleted = 0 AND OpenDate=" + "'" + EnquiryDate + "'");
            }
            catch (SqlException Sqle)
            {
                throw Sqle;
            }
            return dtAP_EnquiryDetail;
        }

        public static DataTable SelectAllAP_EnquiryDetailByIsAccepted()
        {
            DataTable dtAP_EnquiryDetail;
            try
            {
                dtAP_EnquiryDetail = b.SelectByQuery("SELECT AP_EnquiryDetail.ID As AP_EnquiryDetailID,AP_EnquiryID,SupplierID,OpenDate,CloseDate,Total, "
                                            + "PurchasedQty = ISNULL((SELECT SUM(PurchasedQty) FROM AP_PurchasedDetail WHERE AP_PurchasedDetail.AP_EnquiryDetailID = AP_EnquiryDetail.ID), 0), "
                                            + "AP_MaterialID,EnquiryDate,ApprovedQty,RevisedQty,UnitCost,IsAccepted,Remark, "
                                                + "Supplier.SupplierName,AP_Material.APMaterialName,LastRequireDate, "
                                                    + "AP_SubCategory.ID As AP_SubCategoryID,AP_SubCategory.APSubCategoryName,AP_Enquiry.COORemark "
                                                        + "FROM AP_EnquiryDetail "
                                                            + "INNER JOIN AP_Enquiry ON AP_Enquiry.ID = AP_EnquiryDetail.AP_EnquiryID "
                                                                + "INNER JOIN Supplier ON Supplier.ID = AP_EnquiryDetail.SupplierID "
                                                                    + "INNER JOIN AP_Material ON AP_Material.ID = AP_EnquiryDetail.AP_MaterialID "
                                                                        + "LEFT JOIN	AP_SubCategory ON AP_SubCategory.ID = AP_Material.APSubCategoryID WHERE AP_EnquiryDetail.IsDeleted = 0 AND IsAccepted=1");
            }
            catch (SqlException Sqle)
            {
                throw Sqle;
            }
            return dtAP_EnquiryDetail;
        }

        public static DataTable SelectAP_EnquiryDetailByIsAccepted()
        {
            DataTable dtAP_EnquiryDetail;
            try
            {
                dtAP_EnquiryDetail = b.SelectByQuery("SELECT AP_EnquiryDetail.ID As AP_EnquiryDetailID,AP_EnquiryID,SupplierID,OpenDate,CloseDate,Total, "
                                            + "PurchasedQty = ISNULL((SELECT SUM(PurchasedQty) FROM AP_PurchasedDetail WHERE AP_PurchasedDetail.AP_EnquiryDetailID = AP_EnquiryDetail.ID), 0), "
                                            + "AP_MaterialID,EnquiryDate,ApprovedQty,RevisedQty,UnitCost,IsAccepted,Remark, "
                                                + "Supplier.SupplierName,AP_Material.APMaterialName,LastRequireDate, "
                                                    + "AP_SubCategory.ID As AP_SubCategoryID,AP_SubCategory.APSubCategoryName,AP_Enquiry.COORemark "
                                                        + "FROM AP_EnquiryDetail "
                                                            + "INNER JOIN AP_Enquiry ON AP_Enquiry.ID = AP_EnquiryDetail.AP_EnquiryID "
                                                                + "INNER JOIN Supplier ON Supplier.ID = AP_EnquiryDetail.SupplierID "
                                                                    + "INNER JOIN AP_Material ON AP_Material.ID = AP_EnquiryDetail.AP_MaterialID "
                                                                        + "LEFT JOIN	AP_SubCategory ON AP_SubCategory.ID = AP_Material.APSubCategoryID WHERE AP_EnquiryDetail.IsDeleted = 0 AND IsAccepted=1 "
                                                                        + "AND AP_EnquiryDetail.Qty > ISNULL((SELECT SUM(PurchasedQty) FROM AP_PurchasedDetail WHERE AP_PurchasedDetail.AP_EnquiryDetailID = AP_EnquiryDetail.ID), 0)");
            }
            catch (SqlException Sqle)
            {
                throw Sqle;
            }
            return dtAP_EnquiryDetail;
        }

        public static DataTable SelectAcceptEnquiryAP_SubCategoryListByDate(int StartMonth, int EndMonth, int Year)
        {

            DataTable dt = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                string query = String.Format("SELECT DISTINCT(APSubCategoryID) As AP_SubCategoryID,APSubCategoryName FROM A_P_PlanDetail "
                                                + "INNER JOIN A_P_Plan ON A_P_Plan.ID = A_P_PlanDetail.A_P_PlanID "
                                                + "INNER JOIN AP_Material ON AP_Material.ID =A_P_MaterialID "
                                                + "INNER JOIN AP_SubCategory ON AP_SubCategory.ID = AP_Material.APSubCategoryID "
                                                 + "WHERE MONTH(A_P_PlanDate) = @StartMonth AND YEAR(A_P_PlanDate) = @Year");
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartMonth", StartMonth);
                cmd.Parameters.AddWithValue("@EndMonth", EndMonth);
                cmd.Parameters.AddWithValue("@Year", Year);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable SelectAcceptEnquiryAP_MaterialListByDate(int StartMonth, int EndMonth,int Year)
        {

            DataTable dt = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                string query = String.Format("SELECT DISTINCT(A_P_MaterialID)As AP_MaterialID,APMaterialName,APSubCategoryID As AP_SubCategoryID,APSubCategoryName FROM A_P_PlanDetail "
                                                +"INNER JOIN A_P_Plan ON A_P_Plan.ID = A_P_PlanDetail.A_P_PlanID "
                                                +"INNER JOIN AP_Material ON AP_Material.ID =A_P_MaterialID "
                                                +"INNER JOIN AP_SubCategory ON AP_SubCategory.ID = AP_Material.APSubCategoryID "
                                                 + "WHERE MONTH(A_P_PlanDate) = @StartMonth AND YEAR(A_P_PlanDate) = @Year");
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartMonth", StartMonth);
                cmd.Parameters.AddWithValue("@EndMonth", EndMonth);
                cmd.Parameters.AddWithValue("@Year", Year);
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

        #region INSERT
        public static int UpdateAPEnquiry(AP_Enquiry _AP_Enquiry)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new a & p plan
                cmd.CommandText = "usp_APEnquiryUpdate";

                cmd.Parameters.AddWithValue("@p_APEnquiryID", _AP_Enquiry.ID);
                cmd.Parameters["@p_APEnquiryID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OpenDate", _AP_Enquiry.OpenDate);
                cmd.Parameters["@p_OpenDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CloseDate", _AP_Enquiry.CloseDate);
                cmd.Parameters["@p_CloseDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_COORemark", _AP_Enquiry.COORemrak);
                cmd.Parameters["@p_COORemark"].Direction = ParameterDirection.Input;

                affectedRows += cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

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

        public static int Insert(AP_Enquiry _AP_Enquiry, List<AP_EnquiryDetail> _AP_EnquiryDetail)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new AP Enquiry
                cmd.CommandText = "usp_APEnquiryInsert";

                cmd.Parameters.AddWithValue("@p_OpenDate", _AP_Enquiry.OpenDate);
                cmd.Parameters["@p_OpenDate"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_CloseDate", _AP_Enquiry.CloseDate);
                //cmd.Parameters["@p_CloseDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_COORemark", _AP_Enquiry.COORemrak);
                cmd.Parameters["@p_COORemark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_AP_PlanMonth", _AP_Enquiry.AP_PlanMoth);
                cmd.Parameters["@p_AP_PlanMonth"].Direction = ParameterDirection.Input;
                object insertedIDObj = cmd.ExecuteScalar();

                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                int insertedAP_EnquiryID = (int)insertedIDObj;
                // clear parameters of usp_APEnquiryInsert
                cmd.Parameters.Clear();

                // insert new AP_EnquiryDetail
                cmd.CommandText = "usp_AP_EnquiryDetailInsert";
                foreach (AP_EnquiryDetail newAP_EnquiryDetail in _AP_EnquiryDetail)
                {
                    cmd.Parameters.AddWithValue("@p_AP_EnquiryID", insertedAP_EnquiryID);
                    cmd.Parameters["@p_AP_EnquiryID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_EnquiryDate", newAP_EnquiryDetail.EnquiryDate);
                    cmd.Parameters["@p_EnquiryDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SupplierID", newAP_EnquiryDetail.SupplierID);
                    cmd.Parameters["@p_SupplierID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_AP_MaterialID", newAP_EnquiryDetail.AP_MaterialID);
                    cmd.Parameters["@p_AP_MaterialID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ApprovedQty", newAP_EnquiryDetail.ApprovedQty);
                    cmd.Parameters["@p_ApprovedQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_UnitCost", newAP_EnquiryDetail.UnitCost);
                    cmd.Parameters["@p_UnitCost"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_IsAccepted", newAP_EnquiryDetail.IsAccepted);
                    cmd.Parameters["@p_IsAccepted"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newAP_EnquiryDetail.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_LastRequireDate", newAP_EnquiryDetail.LastRequireDate);
                    cmd.Parameters["@p_LastRequireDate"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_FGRequstDetailInsert
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

        #region UPDATE
        public static int Update(AP_Enquiry _AP_Enquiry, List<AP_EnquiryDetail> _UpdateAP_EnquiryDetail, List<AP_EnquiryDetail> _InsertAPEnquiryList)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a upade a & p enquiry
                cmd.CommandText = "usp_APEnquiryUpdate";

                cmd.Parameters.AddWithValue("@p_APEnquiryID", _AP_Enquiry.ID);
                cmd.Parameters["@p_APEnquiryID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OpenDate", _AP_Enquiry.OpenDate);
                cmd.Parameters["@p_OpenDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CloseDate", _AP_Enquiry.CloseDate);
                cmd.Parameters["@p_CloseDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_COORemark", _AP_Enquiry.COORemrak);
                cmd.Parameters["@p_COORemark"].Direction = ParameterDirection.Input;

                affectedRows += cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();


                if (_UpdateAP_EnquiryDetail.Count > 0)
                {
                    cmd.CommandText = "usp_APEnquiryDetailUpdateByID";
                    foreach (AP_EnquiryDetail newAPEnquiryDetail in _UpdateAP_EnquiryDetail)
                    {
                        cmd.Parameters.AddWithValue("@p_APEnquiryDetailID", newAPEnquiryDetail.ID);
                        cmd.Parameters["@p_APEnquiryDetailID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_APEnquiryID", _AP_Enquiry.ID);
                        cmd.Parameters["@p_APEnquiryID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_EnquiryDate", newAPEnquiryDetail.EnquiryDate);
                        cmd.Parameters["@p_EnquiryDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_SupplierID", newAPEnquiryDetail.SupplierID);
                        cmd.Parameters["@p_SupplierID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_APMaterialID", newAPEnquiryDetail.AP_MaterialID);
                        cmd.Parameters["@p_APMaterialID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_ApprovedQty", newAPEnquiryDetail.ApprovedQty);
                        cmd.Parameters["@p_ApprovedQty"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_RevisedQty", 0);
                        cmd.Parameters["@p_RevisedQty"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_UnitCost", newAPEnquiryDetail.UnitCost);
                        cmd.Parameters["@p_UnitCost"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_IsAccepted", newAPEnquiryDetail.IsAccepted);
                        cmd.Parameters["@p_IsAccepted"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Remark", newAPEnquiryDetail.Remark);
                        cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_LastRequireDate", newAPEnquiryDetail.LastRequireDate);
                        cmd.Parameters["@p_LastRequireDate"].Direction = ParameterDirection.Input;

                        affectedRows += cmd.ExecuteNonQuery();
                        // clear parameters of each 
                        cmd.Parameters.Clear();
                    }
                }

                if (_InsertAPEnquiryList.Count > 0)
                {
                    // insert new AP_EnquiryDetail
                    cmd.CommandText = "usp_AP_EnquiryDetailInsert";
                    foreach (AP_EnquiryDetail newAP_EnquiryDetail in _InsertAPEnquiryList)
                    {
                        cmd.Parameters.AddWithValue("@p_AP_EnquiryID", _AP_Enquiry.ID);
                        cmd.Parameters["@p_AP_EnquiryID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_EnquiryDate", newAP_EnquiryDetail.EnquiryDate);
                        cmd.Parameters["@p_EnquiryDate"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_SupplierID", newAP_EnquiryDetail.SupplierID);
                        cmd.Parameters["@p_SupplierID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_AP_MaterialID", newAP_EnquiryDetail.AP_MaterialID);
                        cmd.Parameters["@p_AP_MaterialID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_ApprovedQty", newAP_EnquiryDetail.ApprovedQty);
                        cmd.Parameters["@p_ApprovedQty"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_UnitCost", newAP_EnquiryDetail.UnitCost);
                        cmd.Parameters["@p_UnitCost"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_IsAccepted", newAP_EnquiryDetail.IsAccepted);
                        cmd.Parameters["@p_IsAccepted"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Remark", newAP_EnquiryDetail.Remark);
                        cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_LastRequireDate", newAP_EnquiryDetail.LastRequireDate);
                        cmd.Parameters["@p_LastRequireDate"].Direction = ParameterDirection.Input;

                        //cmd.Parameters.AddWithValue("@p_Remark", newfgRequestDetails.Remark);
                        //cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                        affectedRows += cmd.ExecuteNonQuery();
                        // clear parameters of each 
                        cmd.Parameters.Clear();

                    }
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
                throw;
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedRows;
        }

        public static int UpdateByID(AP_EnquiryDetail newAPEnquiryDetail, SqlConnection conn)
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

                cmd.CommandText = "usp_APEnquiryDetailUpdateByID";

                cmd.Parameters.AddWithValue("@p_APEnquiryDetailID", newAPEnquiryDetail.ID);
                cmd.Parameters["@p_APEnquiryDetailID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_APEnquiryID", newAPEnquiryDetail.AP_EnquiryID);
                cmd.Parameters["@p_APEnquiryID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EnquiryDate", newAPEnquiryDetail.EnquiryDate);
                cmd.Parameters["@p_EnquiryDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SupplierID", newAPEnquiryDetail.SupplierID);
                cmd.Parameters["@p_SupplierID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_APMaterialID", newAPEnquiryDetail.AP_MaterialID);
                cmd.Parameters["@p_APMaterialID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ApprovedQty", newAPEnquiryDetail.ApprovedQty);
                cmd.Parameters["@p_ApprovedQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RevisedQty", newAPEnquiryDetail.RevisedQty);
                cmd.Parameters["@p_RevisedQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UnitCost", newAPEnquiryDetail.UnitCost);
                cmd.Parameters["@p_UnitCost"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsAccepted", newAPEnquiryDetail.IsAccepted);
                cmd.Parameters["@p_IsAccepted"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", newAPEnquiryDetail.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                affectedRows += cmd.ExecuteNonQuery();
                // clear parameters of each 
                cmd.Parameters.Clear();

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

        #region select
        public static DataTable Get_AviliablePlanAmountByAP_MaterialID(int ap_materialId,DateTime planDate) 
        {

            DataTable dt = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                string query = "SELECT * FROM vw_A_P_Plan_Enquiry_Balance WHERE [A_P_MaterialID]=@p_AP_MaterialId AND [A_P_PlanDate]=@p_PlanDate";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@p_AP_MaterialId", ap_materialId);
                cmd.Parameters.AddWithValue("@p_PlanDate", planDate);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(conn.State==ConnectionState.Open)
                    conn.Close();
           
            }
            return dt;
        }

        #endregion
    }
}
