/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: Employee business logic class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Common.DA;

namespace PTIC.Common.BL
{
    /// <summary>
    /// Employee business logic
    /// </summary>
    public class EmployeeBL
    {
        #region SELECT
        /// <summary>
        /// Get all employees from system
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all employees</returns>
        /// 
        public DataTable GetEmployeeFromMarketingAndSale()
        {
            return EmployeeDA.SelectEmpFromMarketingAndSale();
        }

        public DataTable GetAllByRank()
        {
            return EmployeeDA.SelectAllByRank();
        }

        public DataTable GetEmpByRankANDDept()
        {
            return EmployeeDA.SelectEmpFromSalesMktRank1To7();
        }

        public DataTable GetAll()
        {
            return EmployeeDA.SelectAll();
        }

        public DataTable GetAllExpectParam(int DeptID)
        {
            return EmployeeDA.SelectAllExpectParam(DeptID);
        }

        public DataTable GetByID(int employeeID)
        {
            return new EmployeeDA().SelectByID(employeeID);
        }
        #endregion
    }
}
