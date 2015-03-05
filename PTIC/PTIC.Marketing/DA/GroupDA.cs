using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Common.DA;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.DA
{
    public class GroupDA
    {
        BaseDAO b = new BaseDAO();

        public int Insert(Group group)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.InsertInto("[Group]", b.ConvertColName(group), b.ConvertValueList(group));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }

        public int Delete(Group group)
        {
            int GroupID = 0;
            try
            {
                b.Delete("[Group]", group.ID);
                GroupID = group.ID;
            }
            catch (Exception ex)
            {
                return GroupID = 0;
            }
            return GroupID;
        }

        public int Update(Group group)
        {
            int GroupID = 0;
            try
            {
                b.Update("[Group]", group.ID.ToString(), b.ConvertColName(group), b.ConvertValueList(group));
                GroupID = group.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return GroupID;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("[Group]", key);
        }

        public Group GetByID(int id)
        {
            DataTable dt = Select("ID=" + id + "");
            Group vo = b.ConvertObj(dt.Rows[0], new Group()) as Group;
            return vo;
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = b.Select("[Group]", sql);
            }
            catch (Exception ex)
            { throw ex; }
            return dt;
        }

        #region SELECT
        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM [Group] ORDER BY GroupName";
                dt = b.SelectByQuery(query);
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
