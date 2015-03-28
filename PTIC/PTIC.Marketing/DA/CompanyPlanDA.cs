/*
 * Author:  AUNGKOKO <aungkoko@asiagreenleaf.com>
 *              Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: CompanyPlanDA data access class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    public class CompanyPlanDA
    {
        #region SELECT
        public static DataTable SelectCompanyPlanLog()
        {
            DataTable table = null;
            string tableName = "CompanyPlanLog";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandText = "SELECT cmp.Id as cmpId,Convert(varchar,cmpDtl.ArrivedDate,7) as ArrivedDate,CMP.CustomerId as CompanyId,";
                command.CommandText += " Convert(varchar,cmp.TargetedDate,7) as TargetedDate,cust.CusName,cmpDtl.ID as CmpDtlId,";
                command.CommandText += " cp.ConPersonName,cp.MobilePhone,Convert(varchar,cmpDtl.ArrivedTime,8) as ArrivedTime,";
                command.CommandText += " Convert(varchar,cmpDtl.DepatureTime,8) as DepatureTime,cmpDtl.CarCountInCompany,";
                command.CommandText += " dbo.GetUsedBrand(cmpDtl.ID) as UsedBrand,cmpDtl.ToyoComment,cmpDtl.MainTopic,";
                command.CommandText += " cmpDtl.HasOrder,cmpDtl.ConditionOfOtherBrands,emp.EmpName,cmpDtl.Remark";
                command.CommandText += " FROM CompanyPlan cmp JOIN ContactPerson CP ON CMP.CustomerId=CP.CusID";
                command.CommandText += " JOIN Customer cust ON CUST.ID= CMP.CustomerId LEFT JOIN (CompanyPlanDetails cmpDtl JOIN Employee emp ON cmpDtl.EmpId=emp.ID) ";
                command.CommandText += " ON CMP.ID=cmpDtl.CompanyPlanId WHERE CMP.ISCONFIRMED=1";
                SqlDataAdapter adapter = new SqlDataAdapter(command);

               
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public static DataTable SelectCompanyPlanLogWithDateRange(DateTime startDate,DateTime endDate)
        {
            DataTable table = null;
            string tableName = "CompanyPlanLog";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandText = "SELECT cmp.Id as cmpId,Convert(varchar,cmpDtl.ArrivedDate,7) as ArrivedDate,";
                command.CommandText += " Convert(varchar,cmp.TargetedDate,7) as TargetedDate,cust.CusName,cmpDtl.ID as CmpDtlId,";
                command.CommandText += " cp.ConPersonName,cp.MobilePhone,Convert(varchar,cmpDtl.ArrivedTime,8) as ArrivedTime,";
                command.CommandText += " Convert(varchar,cmpDtl.DepatureTime,8) as DepatureTime,cmpDtl.CarCountInCompany,";
                command.CommandText += " dbo.GetUsedBrand(cmpDtl.ID) as UsedBrand,cmpDtl.ToyoComment,cmpDtl.MainTopic,";
                command.CommandText += " cmpDtl.HasOrder,cmpDtl.ConditionOfOtherBrands,emp.EmpName,cmpDtl.Remark";
                command.CommandText += " FROM CompanyPlan cmp JOIN ContactPerson CP ON CMP.CustomerId=CP.CusID";
                command.CommandText += " JOIN Customer cust ON CUST.ID= CMP.CustomerId LEFT JOIN (CompanyPlanDetails cmpDtl JOIN Employee emp ON cmpDtl.EmpId=emp.ID) ";
                command.CommandText += " ON CMP.ID=cmpDtl.CompanyPlanId WHERE CMP.ISCONFIRMED=1 AND CMP.TargetedDate BETWEEN @startDate  AND @endDate ";
                command.Parameters.AddWithValue("@startDate", startDate);
                command.Parameters.AddWithValue("@endDate", endDate);
                SqlDataAdapter adapter = new SqlDataAdapter(command);


                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public static DataTable SelectCompanyPlanUnConfirmedList()
        {
            DataTable table = null;
            string tableName = "CompanyPlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                //command.CommandType = CommandType.StoredProcedure;
                command.CommandText = " SELECT [CompanyPlan].[ID],[CompanyPlanNo],[TargetedDate],[TownshipId],[CustomerId]";
                command.CommandText += " ,[Status],[CreatedDate],[LastModifedDate],cp.ConPersonName ,cp.MobilePhone";
                command.CommandText += " FROM [dbo].[CompanyPlan] Inner Join ContactPerson cp";
                command.CommandText += " ON (CompanyPlan.CustomerId = cp.CusID)";
                command.CommandText += " where CompanyPlan.IsDeleted = 0 and cp.IsDeleted=0 and [IsConfirmed]=0";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }


        public static DataTable SelectCompanyPlanUnConfirmedListByDateRange(DateTime dtStart,DateTime dtEnd)
        {
            DataTable table = null;
            string tableName = "CompanyPlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                //command.CommandType = CommandType.StoredProcedure;
                command.CommandText = " SELECT [CompanyPlan].[ID],[CompanyPlanNo],[TargetedDate],[TownshipId],[CustomerId]";
                command.CommandText += " ,[Status],[CreatedDate],[LastModifedDate],cp.ConPersonName ,cp.MobilePhone";
                command.CommandText += " FROM [dbo].[CompanyPlan] Inner Join ContactPerson cp";
                command.CommandText += " ON (CompanyPlan.CustomerId = cp.CusID)";
                command.CommandText += " where CompanyPlan.IsDeleted = 0 and cp.IsDeleted=0 and [IsConfirmed]=0";
                command.CommandText += " and TargetedDate Between @p_startDate and @p_endDate";
                command.Parameters.AddWithValue("@p_startDate", dtStart);
                command.Parameters.AddWithValue("@p_endDate", dtEnd);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }


      

        private static DataTable SelectCompanyPlanBy(PTIC.Common.Enum.FormStatus formStatus)
        {
            DataTable table = null;
            string tableName = "CompanyPlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandText = " SELECT [CompanyPlan].[ID],[CompanyPlanNo],[TargetedDate],[TownshipId],[CustomerId],[CusName]";
                command.CommandText += " ,[Status],[CreatedDate],[LastModifedDate],cp.ConPersonName ,cp.MobilePhone,[IsConfirmed]";
                command.CommandText += " FROM [dbo].[CompanyPlan] Inner Join ContactPerson cp";
                command.CommandText += " ON (CompanyPlan.CustomerId = cp.CusID) Inner Join Customer cust ON (CompanyPlan.CustomerId=cust.ID)";
                command.CommandText += " where CompanyPlan.IsDeleted = 0 and cp.IsDeleted=0 and [IsConfirmed]=0 AND STATUS=@p_Status";
                command.Parameters.AddWithValue("@p_Status", (int)formStatus);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                command.Parameters.Clear();
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public static DataTable SelectReportedCompanyPlan()
        {
            return SelectCompanyPlanBy(Common.Enum.FormStatus.Reported);
        }

        public static DataTable SelectMobileServiceLogsByInitialCompanyPlanID(int InitialCompanyPlanID)
        {
            DataTable table = null;
            string tableName = "MobileServiceLogTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_MobileServiceLogSelectByInitialMobileServiePlanID";

                command.Parameters.AddWithValue("@p_InitialCompanyPlanID", InitialCompanyPlanID);
                command.Parameters["@p_InitialCompanyPlanID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return table;
        }

        public static DataTable SelectMobileServiceLogsBy(DateTime startDate, DateTime endDate)
        {
            DataTable table = null;
            string tableName = "MobileServiceLogTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_MobileServiceLogSelectBy";

                command.Parameters.AddWithValue("@p_startDate", startDate);
                command.Parameters["@p_startDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_endDate", endDate);
                command.Parameters["@p_endDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return table;
        }


        public static DataTable SelectMobileServiceLogsWithoutDetailsBy(DateTime startDate, DateTime endDate)
        {
            DataTable table = null;
            string tableName = "MobileServiceLogTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_MobileServiceLogWithoutDetailsSelectBy";

                command.Parameters.AddWithValue("@p_startDate", startDate);
                command.Parameters["@p_startDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_endDate", endDate);
                command.Parameters["@p_endDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return table;
        }
        #endregion

        #region INSERT INTO CompanyPlan
        public static int? InsertCompanyPlan(List<CompanyPlan> CompanyPlan)
        {
            SqlTransaction transaction = null;
            int affectedrow = 0;
            SqlCommand cmd = null;
            try
            {
                
                
                SqlConnection con = DBManager.GetInstance().GetDbConnection();
                cmd = new SqlCommand();

                transaction = con.BeginTransaction("SampleTransaction");
                cmd.Connection = con;
                cmd.Transaction = transaction;
                cmd.CommandText = "INSERT INTO [CompanyPlan]([CompanyPlanNo],[TargetedDate],[TownshipId],[CustomerId],[Status],[IsConfirmed],[CreatedDate],[LastModifedDate],[IsDeleted])";
                cmd.CommandText += " OUTPUT inserted.ID  VALUES(@CompanyPlanNo,@TargetedDate,@TownshipId,@CustomerId,@Status,@IsConfirmed,@CreatedDate,@LastModifedDate,@IsDeleted)";

                foreach (CompanyPlan newCompanyPlan in CompanyPlan)
                {
                    cmd.Parameters.AddWithValue("@TownshipId", newCompanyPlan.TownshipID);
                    cmd.Parameters.AddWithValue("@CompanyPlanNo", string.IsNullOrEmpty (newCompanyPlan.CompanyPanNo)?string.Empty:newCompanyPlan.CompanyPanNo);
                    if(newCompanyPlan.TargetedDate.HasValue)
                        cmd.Parameters.AddWithValue("@TargetedDate", newCompanyPlan.TargetedDate.Value);
                    else
                        cmd.Parameters.AddWithValue("@TargetedDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@CustomerId", newCompanyPlan.CustomerID);
                    cmd.Parameters.AddWithValue("@Status", newCompanyPlan.Status);
                    cmd.Parameters.AddWithValue("@IsConfirmed", newCompanyPlan.IsConfirmed);
                    if(newCompanyPlan.CreatedDate.HasValue)
                        cmd.Parameters.AddWithValue("@CreatedDate", newCompanyPlan.IsConfirmed);
                    else
                        cmd.Parameters.AddWithValue("@CreatedDate", DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastModifedDate", newCompanyPlan.LastModifiedDate);
                    cmd.Parameters.AddWithValue("@IsDeleted", newCompanyPlan.IsDeleted);
                    int tmpId = 0;
                    int.TryParse(cmd.ExecuteScalar()+string.Empty,out tmpId);
                    if (tmpId != 0)
                        affectedrow = tmpId;
                    cmd.Parameters.Clear();
                }
                transaction.Commit();
                return affectedrow;
            }
            catch (SqlException sqle)
            {
                return null;
            }
        }
        #endregion

        #region UPDATE CompanyPlan
        public static int? UpdateCompanyPlanByID(CompanyPlan CompanyPlan)
        {
            int affectedrow = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandText = "UPDATE COMPANYPLAN SET [TargetedDate]=@p_TargetedDate, [TownshipId]=@p_TownshipID,[CustomerId]=@p_CusID WHERE ID=@p_CompanyPlanID";

                cmd.Parameters.AddWithValue("@p_TargetedDate", CompanyPlan.CustomerID);
                cmd.Parameters["@p_TargetedDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CompanyPlanID", CompanyPlan.Id);
                cmd.Parameters["@p_CompanyPlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownshipID", CompanyPlan.TownshipID);
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", CompanyPlan.CustomerID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                affectedrow = cmd.ExecuteNonQuery();
                
                return affectedrow;
            }
            catch (SqlException sqle)
            {
                return null;
            }
        }

        private static void UpdateCompanyPlan_FormStatus(
            List<CompanyPlan> CompanyPlans, PTIC.Common.Enum.FormStatus status)
        {
            try
            {
                string cmdUpdate = string.Empty;
                if (status == Common.Enum.FormStatus.Confirmed)
                    cmdUpdate = "UPDATE [CompanyPlan] SET"
                                           + " [TargetedDate] = @p_TargetedDate"
                                           + " ,[Status] = @p_Status"
                                           + ",[IsConfirmed]=1"
                                         + " WHERE [ID] = @p_ID";
                else
                    cmdUpdate = "UPDATE [CompanyPlan] SET"
                                           + " [Status] = @p_Status"
                                         + " WHERE [ID] = @p_ID";
                SqlCommand cmd = new SqlCommand();
                SqlConnection conn=DBManager.GetInstance().GetDbConnection();
                SqlTransaction trans = conn.BeginTransaction("CompanyPlanConfirm");
                cmd.Connection = conn;
                cmd.Transaction = trans;
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdUpdate;
                int effectedRowsCount = 0;
                foreach (CompanyPlan plan in CompanyPlans)
                {
                    if (status == Common.Enum.FormStatus.Confirmed)
                    {
                        cmd.Parameters.AddWithValue("@p_TargetedDate", plan.TargetedDate);
                        cmd.Parameters["@p_TargetedDate"].Direction = ParameterDirection.Input;
                    }
                    cmd.Parameters.AddWithValue("@p_Status", (int)status);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ID", plan.Id);
                    cmd.Parameters["@p_ID"].Direction = ParameterDirection.Input;

                    
                    effectedRowsCount += cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
        }

        public static void UpdateCompanyPlanAsConfirmed(List<CompanyPlan> CompanyPlans)
        {
            UpdateCompanyPlan_FormStatus(CompanyPlans, Common.Enum.FormStatus.Confirmed);
        }

        public static void UpdateCompanyPlanAsRejected(List<CompanyPlan> CompanyPlans)
        {
            UpdateCompanyPlan_FormStatus(CompanyPlans, Common.Enum.FormStatus.Rejected);
        }
        #endregion

        #region DELETE
        public static int DeleteByID(CompanyPlan CompanyPlan)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection conn = DBManager.GetInstance().GetDbConnection();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE  FROM CompanyPlan WHERE ID = @p_Id";
                cmd.Parameters.AddWithValue("@p_Id", CompanyPlan.Id);
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region SEARCH
        public static DataTable SearchByID(DateTime startdate, DateTime enddate)
        {
            DataTable table = null;
            string tableName = "CompanyPlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CompanyPlanSearchByPlanDate";

                cmd.Parameters.AddWithValue("@p_StartDate", startdate);
                cmd.Parameters["@p_StartDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EndDate", enddate);
                cmd.Parameters["@p_EndDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            return table;
        }
        #endregion

        #region

        public static CompanyPlanDetail SelectCompanyPlanDetailsById(int CmpDtlId)
        {
            DataTable table = null;
            CompanyPlanDetail cmpDtl = null;
            string tableName = "CompanyPlanDetails";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandText = "SELECT * FROM CompanyPlanDetails WHERE ID =@id";

                command.Parameters.AddWithValue("@id", CmpDtlId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                command.Parameters.Clear();


                if (table.Rows.Count == 1)
                {
                    cmpDtl = new CompanyPlanDetail();
                    cmpDtl.CompanyPlanDetailId = CmpDtlId;
                    cmpDtl.ApprovedBy = (string)table.Rows[0]["ApprovedBy"];
                    cmpDtl.ArrivedTime = (DateTime)table.Rows[0]["ArrivedTime"];
                    cmpDtl.ArrivedDate = (DateTime)table.Rows[0]["ArrivedDate"];
                    cmpDtl.CarCountInCompany = (int)table.Rows[0]["CarCountInCompany"];
                    cmpDtl.CheckedBy = (string)table.Rows[0]["CheckedBy"];
                    cmpDtl.ConditionOfOtherBrands = (string)table.Rows[0]["CheckedBy"];
                    cmpDtl.DepatureTime = (DateTime)table.Rows[0]["DepatureTime"];
                    cmpDtl.HasOrder = (bool)table.Rows[0]["HasOrder"];
                    cmpDtl.MainTopic = (string)table.Rows[0]["MainTopic"];
                    cmpDtl.PreparedBy = (string)table.Rows[0]["PreparedBy"];
                    cmpDtl.TargetedEmpId = (int)table.Rows[0]["EmpId"];
                    cmpDtl.ToyoComment = (string)table.Rows[0]["ToyoComment"];
                    cmpDtl.HasService = (bool)table.Rows[0]["hasServiced"];
                    if(cmpDtl.HasService)
                        cmpDtl.ServicedDate = (DateTime)table.Rows[0]["ServicedDate"];

                    command = new SqlCommand();
                    command.Connection = DBManager.GetInstance().GetDbConnection();
                    command.CommandText = "SELECT [BrandId] FROM [CompanyPlanDtl_UseBrand] WHERE BrandId is not null and isDelete=0 and CompanyPlanDetailsID=@id";

                    command.Parameters.AddWithValue("@id", CmpDtlId);
                    List<int> ownBrandList = new List<int>();
                    DataTable brandList = new DataTable();
                    new SqlDataAdapter(command).Fill(brandList);
                    foreach (DataRow dr in brandList.Rows)
                    {
                        ownBrandList.Add((int)dr["BrandId"]);
                    }

                    command = new SqlCommand();
                    command.Connection = DBManager.GetInstance().GetDbConnection();
                    command.CommandText = "SELECT CompetitorBrandId FROM [CompanyPlanDtl_UseBrand] WHERE CompetitorBrandId is not null and isDelete=0 and CompanyPlanDetailsID=@id";

                    command.Parameters.AddWithValue("@id", CmpDtlId);
                    List<int> otherBrandList = new List<int>();
                    DataTable other_brandList = new DataTable();
                    new SqlDataAdapter(command).Fill(brandList);
                    foreach (DataRow dr in other_brandList.Rows)
                    {
                        otherBrandList.Add((int)dr["CompetitorBrandId"]);
                    }

                }


            }
            catch (SqlException sqle)
            {
                return null;
            }
            return cmpDtl;
        }


        public static int InsertCompanyPlanDetail(CompanyPlanDetail cmpDtl,int custId) 
        {

            SqlCommand command = new SqlCommand();
            SqlConnection conn = DBManager.GetInstance().GetDbConnection();

            
            
            string townIdSql = "SELECT [Address].TownshipID FROM Customer JOIN [Address] ON Customer.AddrID =[Address].ID WHERE Customer.ID=@p_ID";

            command.CommandText = townIdSql;
            command.Parameters.AddWithValue("@p_ID", custId);
            command.Connection = conn;

            object obj = command.ExecuteScalar();
            if (string.IsNullOrEmpty(obj + string.Empty))
            {
                obj = 0;
            }
            int townId = 0;
            int.TryParse(obj + string.Empty, out townId);

            if (cmpDtl.CompanyPlanId == 0) 
            {
                CompanyPlan cmpPlan = new CompanyPlan()
                {
                    CustomerID = custId,
                    TownshipID = townId,
                    IsConfirmed = true,
                    IsDeleted = false,
                    LastModifiedDate = DateTime.Now,
                    CreatedDate = null,
                    Status = 0,
                    TargetedDate = null,
                };
                List<CompanyPlan> cmpList = new List<CompanyPlan>();
                cmpList.Add(cmpPlan);
                int? cmpId = CompanyPlanDA.InsertCompanyPlan(cmpList);
                if (cmpId.HasValue)
                {
                    cmpDtl.CompanyPlanId = cmpId.Value;

                }
                else 
                {
                    return 0;
                }
            
            }

            SqlTransaction trans = conn.BeginTransaction();
            string sqlCommand = "INSERT INTO [CompanyPlanDetails]([CompanyPlanId],[CarCountInCompany],[ToyoComment],[MainTopic]";
            sqlCommand +=",[ArrivedTime],[DepatureTime],[HasOrder],[ConditionOfOtherBrands],[PreparedBy],[CheckedBy],[ApprovedBy]";
            sqlCommand += ",[ArrivedDate],[EmpId],[Remark],[isDeleted],[hasServiced],[ServicedDate]) OUTPUT inserted.ID   VALUES(@CompanyPlanId,@CarCountInCompany,@ToyoComment";
            sqlCommand+=",@MainTopic,@ArrivedTime,@DepatureTime,@HasOrder,@ConditionOfOtherBrands,@PreparedBy,@CheckedBy,@ApprovedBy";
            sqlCommand+=",@ArrivedDate,@EmpId,@Remark,@isDeleted,@hasServiced,@ServicedDate)";
            try
            {
                command = new SqlCommand();
                command.Connection = conn;
                command.Transaction = trans;
                command.CommandText = sqlCommand;

                command.Parameters.AddWithValue("@CompanyPlanId", cmpDtl.CompanyPlanId);
                command.Parameters.AddWithValue("@CarCountInCompany", cmpDtl.CarCountInCompany);
                command.Parameters.AddWithValue("@ToyoComment", cmpDtl.ToyoComment);
                command.Parameters.AddWithValue("@MainTopic", cmpDtl.MainTopic);
                command.Parameters.AddWithValue("@ArrivedTime", cmpDtl.ArrivedTime);
                command.Parameters.AddWithValue("@DepatureTime", cmpDtl.DepatureTime);
                command.Parameters.AddWithValue("@HasOrder", cmpDtl.HasOrder);
                command.Parameters.AddWithValue("@ConditionOfOtherBrands", cmpDtl.ConditionOfOtherBrands);
                command.Parameters.AddWithValue("@PreparedBy", cmpDtl.PreparedBy);
                command.Parameters.AddWithValue("@CheckedBy", cmpDtl.CheckedBy);
                command.Parameters.AddWithValue("@ApprovedBy", cmpDtl.ApprovedBy);
                command.Parameters.AddWithValue("@ArrivedDate", cmpDtl.ArrivedDate);
                command.Parameters.AddWithValue("@EmpId", cmpDtl.TargetedEmpId);
                command.Parameters.AddWithValue("@Remark", (cmpDtl.Remark==null?"":cmpDtl.Remark));
                command.Parameters.AddWithValue("@isDeleted", false);
                command.Parameters.AddWithValue("@hasServiced", cmpDtl.HasService);
                if(cmpDtl.HasService)
                    command.Parameters.AddWithValue("@ServicedDate", cmpDtl.ServicedDate);
                else
                    command.Parameters.AddWithValue("@ServicedDate", DBNull.Value);
                object insertedId =  command.ExecuteScalar();

                command.Parameters.Clear();
                if (insertedId != null)
                {
                    cmpDtl.CompanyPlanDetailId = (int)insertedId;
                    string usedBrandSqlCommand = "INSERT INTO [CompanyPlanDtl_UseBrand]([CompanyPlanDetailsID],[BrandId],[CompetitorBrandId],[isDelete])";
                    usedBrandSqlCommand += "VALUES (@CompanyPlanDetailsID,@BrandId,@CompetitorBrandId,@isDelete)";
                    foreach (int brandId in cmpDtl.OwnBrandList) 
                    {

                        command.CommandText = usedBrandSqlCommand;
                        command.Parameters.AddWithValue("@CompanyPlanDetailsID", cmpDtl.CompanyPlanDetailId);
                        command.Parameters.AddWithValue("@BrandId", brandId);
                        command.Parameters.AddWithValue("@CompetitorBrandId", DBNull.Value);
                        command.Parameters.AddWithValue("@isDelete", false);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }

                    foreach (int otherBrandId in cmpDtl.OtherBrandList)
                    {
                        command.CommandText = usedBrandSqlCommand;
                        command.Parameters.AddWithValue("@CompanyPlanDetailsID", cmpDtl.CompanyPlanDetailId);
                        command.Parameters.AddWithValue("@BrandId",  DBNull.Value);
                        command.Parameters.AddWithValue("@CompetitorBrandId",otherBrandId);
                        command.Parameters.AddWithValue("@isDelete", false);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }
                    trans.Commit();
                    if (cmpDtl.HasService) 
                    {

                        

                        List<MobileServicePlan> msPlanList= new List<MobileServicePlan> ();
                        msPlanList.Add(new MobileServicePlan() 
                        {
                            CustomerID = custId,
                            CusTypeID = 3,
                            DateAdded = DateTime.Now,
                            IsConfirmed = false,
                            IsDeleted = false,
                            LastModified = DateTime.Now,
                            Status = 1,
                            SvcPlanDate= cmpDtl.ServicedDate,
                            TownshipID = townId
                        });
                        MobileServicePlanDA.InsertMobileServicePlan(msPlanList);
                    }

                    
                    return 1;
                }
                else return 0;




            }
            catch (Exception err)
            {
                throw err;
            }

           
        }

        public static int DeleteCompanyPlanDetail(CompanyPlanDetail cmpDtl)
        {
            string sqlCommand = "DELETE FROM CompanyPlanDtl_UseBrand WHERE CompanyPlanDetailsID=@CompanyPlanDetailsID";
            try
            {
                SqlCommand command = new SqlCommand();
                SqlConnection conn = DBManager.GetInstance().GetDbConnection();

                SqlTransaction trans = conn.BeginTransaction();
                command.Connection = conn;
                command.Transaction = trans;
                command.CommandText = sqlCommand;
                command.Parameters.AddWithValue("@CompanyPlanDetailsID", cmpDtl.CompanyPlanDetailId);


                command.ExecuteNonQuery();

                command.Parameters.Clear();

                sqlCommand = "DELETE FROM CompanyPlanDetails WHERE ID=@CompanyPlanDetailsID";
                command.CommandText = sqlCommand;
                command.Parameters.AddWithValue("@CompanyPlanDetailsID", cmpDtl.CompanyPlanDetailId);
                command.ExecuteNonQuery();

                command.Parameters.Clear();
                trans.Commit();
                return 1;
            }
            catch (Exception err)
            {
                throw err;
            }


        }

        #endregion

    }
}
