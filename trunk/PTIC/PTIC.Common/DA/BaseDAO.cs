using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Reflection;
using System.Configuration;

namespace PTIC.Common.DA
{    
    /// <summary>
    /// Base class for data access
    /// </summary>
    public class BaseDAO
    {
        // TODO: access modifiers of public methods must be changed to protected so that child DataAccess class only can access

        #region Attributes
        public string _ConStr = string.Empty;
        //public static string _XmlPath = "Setting.xml";

        private static readonly string ConnStringName = "PTIC.Properties.Settings.PTICConnectionString";
        private SqlConnection _Con;
        
        public SqlConnection Con
        {
            get { return _Con; }
            set { _Con = value; }
        }
        private SqlCommand _Cmd;

        public SqlCommand Cmd
        {
            get { return _Cmd; }
            set { _Cmd = value; }
        }
        private SqlDataAdapter _Adp;

        public SqlDataAdapter Adp
        {
            get { return _Adp; }
            set { _Adp = value; }
        }
        private SqlDataReader _Rd;

        public SqlDataReader Rd
        {
            get { return _Rd; }
            set { _Rd = value; }
        }

        #endregion

        #region Open/Close Connection
        public BaseDAO()
        {
            //DataSet ds = new DataSet();
            //BaseDAO._XmlPath = System.Environment.CurrentDirectory + "\\Setting.xml";            
            //ds.ReadXml(BaseDAO._XmlPath);
            //this._ConStr = "Data Source=" + ds.Tables["DatabaseConfig"].Rows[0]["Server"];
            //this._ConStr += ";Initial Catalog=" + ds.Tables["DatabaseConfig"].Rows[0]["DataBase"];
            //this._ConStr += ";User ID=" + ds.Tables["DatabaseConfig"].Rows[0]["UserName"];
            //this._ConStr += ";Password=" + ds.Tables["DatabaseConfig"].Rows[0]["Password"];

            this._ConStr = ConfigurationManager.ConnectionStrings[ConnStringName].ConnectionString;
        }
        public void OpenConnection()
        {
            if (_Con == null) this._Con = new SqlConnection(_ConStr);
            CloseConnection();
            _Con.Open();

        }
        public void CloseConnection()
        {
            if (_Con.State == ConnectionState.Open) _Con.Close();
        }
        #endregion
        #region ConvertObj n ConvertValue...

        public object ConvertObj(DataRow dr, object obj)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            object[] valueList = new object[props.Count];

            for (int i = 0; i < props.Count; i++)
            {
                object obj2 = dr[i];
                valueList[i] = obj2;
            }
            for (int i = 0; i < props.Count; i++)
            {
                if (valueList[i] != System.DBNull.Value)
                    props[i].SetValue(obj, valueList[i]);
            }
            return obj;
        }

        public object ConvertObjWithImage(DataRow dr, object obj)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            object[] valueList = new object[props.Count];

            for (int i = 0; i <= props.Count-1; i++)
            {
                object obj2 = dr[i];
                valueList[i] = obj2;
            }
            for (int i = 0; i <= props.Count-1; i++)
            {
                if (valueList[i] != System.DBNull.Value)
                    props[i].SetValue(obj, valueList[i]);
            }
            return obj;
        }

        public object[] ConvertValueList(object obj)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            object[] valueList = new object[props.Count];
            for (int i = 0; i < props.Count; i++)
            {
                if (props[i].GetValue(obj) != null)
                    valueList[i] = props[i].GetValue(obj).ToString();
                else valueList[i] = "";
            }
            return valueList;
        }

        public string[] ConvertColName(object obj)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            string[] valueList = new string[props.Count];
            for (int i = 0; i < props.Count; i++)
                valueList[i] = props[i].Name;
            return valueList;
        }

        public SqlDbType GetDbType(object obj)
        {
            return (obj.GetType() == new decimal().GetType()) ? 
                SqlDbType.Decimal : (obj.GetType() == new DateTime().GetType()) ? 
                SqlDbType.DateTime : (obj.GetType() == true.GetType()) ? 
                SqlDbType.Bit : (obj.GetType() == 1.GetType()) ? 
                SqlDbType.Int : SqlDbType.Binary;
        }

        #endregion

        #region CRUD
        public int InsertInto(string tblName, string[] ColNames, object[] valuesList)
        {
            try
            {
                #region Prepare String...
                int Id = 0;
                string _sql = "INSERT INTO " + tblName;
                _sql += "(";
                for (int i = 1; i < ColNames.Length - 1; i++)
                {
                    _sql += ColNames[i] + ",";
                }
                _sql += ColNames[ColNames.Length - 1];
                _sql += ") OUTPUT INSERTED.ID VALUES(";
                for (int i = 1; i < valuesList.Length - 1; i++)
                {
                    _sql += "@" + ColNames[i] + ",";
                }
                _sql += "@" + ColNames[ColNames.Length - 1] + ")";

                #endregion

                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                for (int i = 1; i < ColNames.Length; i++)
                {
                    if (valuesList[i].GetType() == "".GetType())
                        _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                    else
                        _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];                    
                }
                Id=(int) _Cmd.ExecuteScalar();
                CloseConnection();
                return Id;
            }
            catch (Exception ex)
            { throw ex; }
        }
        
        public int InsertWithImage(string tblName, string[] ColNames, object[] valuesList,byte[] img)
        {
            try
            {
                #region Prepare String...
                int Id = 0;
                string _sql = "INSERT INTO " + tblName;
                _sql += "(";
                for (int i = 1; i < ColNames.Length - 1; i++)
                {
                    _sql += ColNames[i] + ",";
                }
                _sql += ColNames[ColNames.Length - 1];
                _sql += ") OUTPUT INSERTED.ID VALUES(";
                for (int i = 1; i < valuesList.Length - 1; i++)
                {
                    _sql += "@" + ColNames[i] + ",";
                }
                _sql += "@" + ColNames[ColNames.Length - 1] + ")";

                #endregion

                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                for (int i = 1; i < ColNames.Length; i++)
                {
                    if (i == ColNames.Length - 1)
                    {
                        _Cmd.Parameters.Add("@" + ColNames[i], SqlDbType.Image).Value = img;
                    }
                    else
                    {                       
                        if (valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                        else
                            _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                    }
                }
                Id=(int)_Cmd.ExecuteScalar();
                CloseConnection();
                return Id;
            }
            catch (Exception ex)
            { throw ex; }
        }
       
        public int Update(string tblName, string Id, string[] ColNames, object[] valuesList)
        {
            try
            {
                int _effectedRow = 0;
                #region Prepare String...

                string _sql = "UPDATE " + tblName;
                _sql += " SET ";
                for (int i = 1; i < ColNames.Length - 1; i++)
                {
                    _sql += ColNames[i] + "=" + "@" + ColNames[i] + ", ";
                }
                _sql += ColNames[ColNames.Length - 1] + "=" + "@" + ColNames[ColNames.Length - 1] + " WHERE ID=" + Id;

                #endregion
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                for (int i = 1; i < ColNames.Length; i++)
                {
                    if (valuesList[i].GetType() == "".GetType())
                        _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                    else _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                }
                _effectedRow = _Cmd.ExecuteNonQuery();
                CloseConnection();
                return _effectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateWithImage(string tblName, string Id, string[] ColNames, object[] valuesList,byte[] img)
        {
            try
            {
                int _effectedRow = 0;
                #region Prepare String...

                string _sql = "UPDATE " + tblName;
                _sql += " SET ";
                for (int i = 1; i < ColNames.Length - 1; i++)
                {
                    _sql += ColNames[i] + "=" + "@" + ColNames[i] + ", ";
                }
                _sql += ColNames[ColNames.Length - 1] + "=" + "@" + ColNames[ColNames.Length - 1] + " WHERE ID=" + Id;

                #endregion
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                for (int i = 1; i < ColNames.Length; i++)
                {
                    if (i == ColNames.Length - 1)
                    {
                        _Cmd.Parameters.Add("@" + ColNames[i],SqlDbType.Image).Value = img;
                    }
                    else
                    {
                        if (valuesList[i].GetType() == "".GetType())
                            _Cmd.Parameters.Add(ColNames[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                        else _Cmd.Parameters.Add("@" + ColNames[i], GetDbType(valuesList[i])).Value = valuesList[i];
                    }
                }
                _effectedRow = _Cmd.ExecuteNonQuery();
                CloseConnection();
                return _effectedRow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(string tblName, int ID)
        {
            try
            {
                int _effectedRow = 0;
                #region Prepare String..
                string _sql = String.Format("DELETE FROM {0} WHERE ID={1}", tblName, ID);
                #endregion
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                _effectedRow = _Cmd.ExecuteNonQuery();
                CloseConnection();
                return _effectedRow;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int DeleteByCondition(string tblName, string condition)
        {
            try
            {
                int _effectedRow = 0;
                #region Prepare String..
                string _sql = String.Format("DELETE FROM {0} WHERE {1}", tblName, condition);
                #endregion
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                _effectedRow = _Cmd.ExecuteNonQuery();
                CloseConnection();
                return _effectedRow;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DataTable Select(string tblName, string condition)
        {
            try
            {
                DataTable _ResTable = new DataTable();
                string _sql = String.Format("SELECT * FROM {0} WHERE {1}", tblName, condition);
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
                CloseConnection();
                return _ResTable;
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable SelectAll(string tblName)
        {
            try
            {
                DataTable _ResTable = new DataTable();
                string _sql = "SELECT * FROM " + tblName;
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
                CloseConnection();
                return _ResTable;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region SelectMaxID
        public int SelectMaxID(string tblName)
        {
            int Id = 0;
            try
            {
                DataTable _ResTable = new DataTable();
                #region Prepare String
                string _sql = "SELECT MAX(ID) AS ID FROM " + tblName;
                #endregion
                OpenConnection();

                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
                if (_ResTable.Rows.Count > 0)
                    Id = int.Parse(_ResTable.Rows[0][0].ToString());
                CloseConnection();
            }
            catch (Exception ex)
            {
                return Id;
            }
            return Id;
        }
        public string SelectMaxValueID(string tblName, String SetColumnField)
        {
            string value = "";
            try
            {
                DataTable _ResTable = new DataTable();
                #region Prepare String
                string _sql = "SELECT " + SetColumnField + " AS ID FROM " + tblName;
                #endregion
                OpenConnection();

                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
                if (_ResTable.Rows.Count > 0)
                    value = _ResTable.Rows[0][0].ToString();
                CloseConnection();
            }
            catch (Exception ex)
            {
                return value;
            }
            return value;
        }
        #endregion

        #region isExist
        public bool CheckRec(string tblName, string key)
        {
            string _sql = String.Format("SELECT * FROM {0} WHERE ID={1}", tblName, key);
            OpenConnection();
            try
            {
                DataTable _resTable = new DataTable();
                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                Adp.Fill(_resTable);
                CloseConnection();
                return _resTable.Rows.Count > 0;
            }
            catch (Exception ex)
            { 
                throw ex;
            }            
        }
        public bool isExist(string tblName, string condition)
        {
            bool exist = false;
            try            
            {
                DataTable dt = Select(tblName, condition);
                if (dt.Rows.Count > 0)
                    exist = true;
                return exist;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        #endregion

        #region getImageById

        public byte[] getImageById(string tblName,String getValueImage,string id)
        {
            OpenConnection();
            byte[] b = null;
            try
            {
                string _sql = "SELECT " + getValueImage + " FROM " + tblName + " WHERE ID=" + id;
                _Cmd = new SqlCommand(_sql, _Con);
              b= (byte[]) _Cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            CloseConnection();
            return b;
        }

        #endregion
        #region GetColumn
        public DataTable getColumn(string tblName, string columns,string condition)
        {
            DataTable dt=new DataTable();
            OpenConnection();
            try
            {
                string _sql = "SELECT " + columns + " FROM " + tblName + " WHERE " + condition + "";
                _Cmd=new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(dt);
            }
            catch (Exception ex) { throw ex; }
            CloseConnection();

            return dt;
        }

        #endregion

        #region UpdateQuery
        public void UpdateQuery(string tblName, string query)
        {
            string _sql = String.Format("UPDATE {0} SET {1}", tblName, query);
            OpenConnection();

            try
            {
                _Cmd = new SqlCommand(_sql, _Con);
                _Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { throw ex; }

            CloseConnection();
        }
        #endregion
        #region SelectByCondition
        public DataTable SelectByCondition(string tblName, List<string> colName, List<object> valuesList, string extraCondition)
        {
            try
            {
                DataTable _ResTable = new DataTable();
                string _sql = String.Format("SELECT * FROM {0} WHERE ", tblName);
                _sql += extraCondition;
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                for (int i = 0; i < colName.Count; i++)
                {
                    if (valuesList[i].GetType() == "".GetType())
                        _Cmd.Parameters.Add(colName[i], SqlDbType.NVarChar).Value = ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(valuesList[i].ToString()));
                    else _Cmd.Parameters.Add("@" + colName[i], GetDbType(valuesList[i])).Value = valuesList[i];
                }
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);

                CloseConnection();
                return _ResTable;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
        #region SelectByQuery
        public DataTable SelectByQuery(string query)
        {
            DataTable _ResTable = new DataTable();
            string _sql = query;
            try
            {
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                _Adp = new SqlDataAdapter(_Cmd);
                _Adp.Fill(_ResTable);
            }
            catch (Exception ex)
            { throw ex; }
            CloseConnection();
            return _ResTable;
        }
        #endregion

        //public string ReplaceQueryValue(string value)
        //{
        //    return value.Replace("'", "'");
        //}

        public string[] GetFieldNames(object obj)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            //string[] fieldNames = new string[props.Count];
            List<string> fieldNames = new List<string>();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor pd = props[i];
                PropertyInfo property = pd.ComponentType.GetProperty(pd.Name);
                if (Attribute.IsDefined(property, typeof(DBField)))
                    fieldNames.Add(property.Name);
                    //fieldNames[i] = property.Name;
            }
            return fieldNames.ToArray();
        }

        public object[] GetFieldValues(object obj)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            //object[] fieldValues = new object[props.Count];
            List<object> fieldValues = new List<object>();

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor pd = props[i];
                PropertyInfo property = pd.ComponentType.GetProperty(pd.Name);
                if (Attribute.IsDefined(property, typeof(DBField)))
                {
                    object value = property.GetValue(obj, null);
                    if (property.PropertyType.IsEnum)
                        value = (int)value;
                    fieldValues.Add(value);                    
                }
            }
            return fieldValues.ToArray();
        }

        /*************************************************************************************/
        /// <summary>
        /// Insert a new row into database specified by Table, Fields and Values
        /// </summary>
        /// <param name="tblName">Table name</param>
        /// <param name="fieldNames">Database field names</param>
        /// <param name="values">Values</param>
        /// <returns>Return a newly inserted ID</returns>
        public int Insert(string tblName, string[] fieldNames, object[] values)
        {
            try
            {
                // Newly inserted row ID
                int Id = 0;
                /** Prepare statement **/
                StringBuilder _sql = new StringBuilder();
                _sql.Append("INSERT INTO " + tblName);
                _sql.Append("(");
                for (int i = 0; i < fieldNames.Length - 1; i++)
                {
                    _sql.Append(fieldNames[i] + ",");
                }
                _sql.Append(fieldNames[fieldNames.Length - 1]);
                _sql.Append(") OUTPUT INSERTED.ID VALUES(");
                for (int i = 0; i < values.Length - 1; i++)
                {
                    _sql.Append("@" + fieldNames[i] + ",");
                }
                _sql.Append("@" + fieldNames[fieldNames.Length - 1] + ")");

                // Open DB connection
                OpenConnection();
                // Create command
                _Cmd = new SqlCommand(_sql.ToString(), _Con);
                // Add parameter to prepared sql command
                for (int i = 0; i < fieldNames.Length; i++)
                {
                    Type type = values[i].GetType();
                    if (type == typeof(string))
                        _Cmd.Parameters.Add(fieldNames[i], SqlDbType.NVarChar).Value = 
                            ASCIIEncoding.UTF8.GetString(ASCIIEncoding.UTF8.GetBytes(values[i].ToString()));
                    else
                        _Cmd.Parameters.Add("@" + fieldNames[i], GetDbType(values[i])).Value = values[i];
                }
                // Get an inserted ID
                Id = (int)_Cmd.ExecuteScalar();
                // Close DB connection
                CloseConnection();
                // Return newly inserted ID
                return Id;
            }
            catch (Exception ex)
            { throw ex; }
        }

        /// <summary>
        /// Retrieve scalar value
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns>Return scalar value</returns>
        public object SelectScalar(string queryString)
        {
            string _sql = queryString;
            try
            {
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                return _Cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Execute query(Create, Update, Insert, Delete and etc... except Select) and return number of rows affected
        /// </summary>
        /// <param name="queryString">Query string</param>
        /// <returns>Return number of rows affected</returns>
        public int ExecuteNonQuery(string queryString)
        {
            string _sql = queryString;
            try
            {
                OpenConnection();
                _Cmd = new SqlCommand(_sql, _Con);
                return _Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                CloseConnection();
            }
        }
        
    }
}
