using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PTIC.Common.DA
{
    public class RP_AP_BalanceDA
    {
        public static DataTable APBalanceSelectBy(int? DeptID,int? VenID,int? APCategoryID,int? APSubCategoryID,int? APMaterialID)
        {         
                SqlConnection conn = DBManager.GetInstance().GetDbConnection();
                DataSet dataSet = null;
                try
                {
                    dataSet = new DataSet();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_RP_AP_BalancesSelectBy";

                    command.Parameters.AddWithValue("@p_DeptID", DeptID);
                    command.Parameters["@p_DeptID"].Direction = ParameterDirection.Input;

                    command.Parameters.AddWithValue("@p_VenID", VenID);
                    command.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                    command.Parameters.AddWithValue("@p_AP_CategoryID", APCategoryID);
                    command.Parameters["@p_AP_CategoryID"].Direction = ParameterDirection.Input;

                    command.Parameters.AddWithValue("@p_AP_SubCategoryID", APSubCategoryID);
                    command.Parameters["@p_AP_SubCategoryID"].Direction = ParameterDirection.Input;

                    command.Parameters.AddWithValue("@p_AP_MaterialID", APMaterialID);
                    command.Parameters["@p_AP_MaterialID"].Direction = ParameterDirection.Input;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataSet, "AP_BalanceTable");
                }
                catch (SqlException sqle)
                {
                }

                return dataSet.Tables["AP_BalanceTable"];              
           
        }
    }
}
