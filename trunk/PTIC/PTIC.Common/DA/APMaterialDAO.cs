using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Common.DA;

namespace PTIC.Common
{
    public class APMaterialDAO
    {
        BaseDAO b = new BaseDAO();
        public int Insert(APMaterialVO vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.InsertInto("AP_Material", b.ConvertColName(vo), b.ConvertValueList(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Update(APMaterialVO vo)
        {
            int apMaterialID = 0;
            try
            {
                b.Update("AP_Material", vo.Id.ToString(), b.ConvertColName(vo), b.ConvertValueList(vo));
                apMaterialID = vo.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return apMaterialID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("AP_Material", key);
        }

        public int Delete(APMaterialVO vo)
        {
            int APMaterialID = 0;
            try
            {
                b.Delete("AP_Material", vo.Id);
                APMaterialID = vo.Id;
            }
            catch (Exception ex)
            {
                return APMaterialID = 0;
            }
            return APMaterialID;
        }


        //public DataTable SelectAll()
        //{
        //    DataTable dt;
        //    try
        //    {
        //         dt = b.SelectAll("AP_Material");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dt;
        //}

        public DataTable SelectAllWithAPSubCat()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT AP_Material.ID As AP_MaterialID,APSubCategoryID As AP_SubCategoryID,APMaterialName,Description,Size,AP_SubCategory.APSubCategoryName,APCategoryID,AP_Category.CategoryName As APCategoryName "
                                                   + "FROM AP_Material INNER JOIN AP_SubCategory ON AP_SubCategory.ID = AP_Material.APSubCategoryID "
                                                      + "INNER JOIN AP_Category ON AP_Category.ID = AP_SubCategory.APCategoryID "
                                                        + "WHERE AP_SubCategory.IsDeleted = 0 AND AP_Material.IsDeleted =0");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public APMaterialVO GetByID(int id)
        {
            DataTable dt = Select("ID=" + id + "");
            APMaterialVO vo = b.ConvertObj(dt.Rows[0], new APMaterialVO()) as APMaterialVO;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("AP_Material", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

    }
}
