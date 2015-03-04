using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Common.DA;

namespace PTIC.Common
{
    public class APCategoryDAO
    {
        BaseDAO b = new BaseDAO();
        public int Insert(APCategoryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.InsertInto("AP_Category", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Delete(APCategoryVO vo)
        {
            int APCategoryID = 0;
            try
            {
                b.Delete("AP_Category", vo.Id);
                APCategoryID =vo.Id;
            }
            catch (Exception ex)
            {                
                return APCategoryID =0;
            }
            return APCategoryID;          
        }

        public int Update(APCategoryVO vo)
        {
            int categoryID = 0;
            try
            {
                b.Update("AP_Category", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                categoryID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categoryID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("AP_Category", key);
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectAll("AP_Category");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public APCategoryVO GetByID(int id)
        {
            DataTable dt = Select("ID=" + id + "");
            APCategoryVO vo = b.ConvertObj(dt.Rows[0], new APCategoryVO()) as APCategoryVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AP_Category", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

    }
}
