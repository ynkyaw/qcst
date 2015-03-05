using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Common.DA;

namespace PTIC.Common
{
    public class APSubCategoryDAO
    {
        BaseDAO b = new BaseDAO();
        public int Delete(APSubCategoryVO vo)
        {
            int APSubCategoryID = 0;
            try
            {
                b.Delete("AP_SubCategory", vo.Id);
                APSubCategoryID = vo.Id;
            }
            catch (Exception ex)
            {
                return APSubCategoryID =0;
            }
            return APSubCategoryID;    
        }

        public int Insert(APSubCategoryVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.InsertInto("AP_SubCategory", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(APSubCategoryVO vo)
        {
            int subCategoryID = 0;
            try
            {
                b.Update("AP_SubCategory", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                subCategoryID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return subCategoryID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("AP_SubCategory", key);
        }

        public DataTable SelectAllAPSubCat()
        {
            DataTable dt;
            try
            {
                //dt = b.SelectAll("AP_SubCategory");
                string query = "SELECT AP_SubCategory.ID As AP_SubCategoryID,APSubCategoryName,AP_Category.ID As AP_CategoryID,AP_Category.CategoryName FROM AP_SubCategory "
                                        + "INNER JOIN AP_Category ON AP_Category.ID = AP_SubCategory.APCategoryID "
                                            + "WHERE AP_SubCategory.IsDeleted = 0";
                dt = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelecteAllAPSubCatWithoutNonAP()
        {
            DataTable dt;
            try
            {
                //dt = b.SelectAll("AP_SubCategory");
                string query = "SELECT AP_SubCategory.ID As AP_SubCategoryID,APSubCategoryName,AP_Category.ID As AP_CategoryID,AP_Category.CategoryName FROM AP_SubCategory "
                                        + "INNER JOIN AP_Category ON AP_Category.ID = AP_SubCategory.APCategoryID "
                                            + "WHERE AP_SubCategory.IsDeleted = 0  AND AP_Category.IsNonAP = 0";
                dt = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                //dt = b.SelectAll("AP_SubCategory");
                string query ="SELECT * FROM AP_SubCategory INNER JOIN AP_Category ON AP_Category.ID = AP_SubCategory.APCategoryID "
                                        +"WHERE AP_SubCategory.IsDeleted = 0 AND AP_Category.IsDeleted =0";
                dt = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public APSubCategoryVO GetByID(int id)
        {
            DataTable dt = Select("ID=" + id + "");
            APSubCategoryVO vo = b.ConvertObj(dt.Rows[0], new APSubCategoryVO()) as APSubCategoryVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AP_SubCategory", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

    }
}
