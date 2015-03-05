/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: (yyyy/MM/dd)
 * Description: Utility class for data manipulation
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;
using System.Collections;
using PTIC.VC.Util;

namespace PTIC.Util
{
    /// <summary>
    /// Data manipulation utility
    /// </summary>
    public class DataUtil
    {
        /// <summary>
        /// Get DataRow by PrimaryKey value 
        /// </summary>
        /// <param name="table">DataTable in which DataRow has to be found</param>
        /// <param name="primaryKey">Primary key of table</param>
        /// <param name="pkValue">Primary key value</param>
        /// <returns>Return DataRow found</returns>
        public static DataRow GetDataRowBy(DataTable table, string primaryKey, object pkValue)
        {
            if (table == null)
                return null;

            if (table.PrimaryKey.Length < 1 || string.IsNullOrEmpty(primaryKey))
            {
                DataColumn[] pkColumns = new DataColumn[1];
                pkColumns[0] = table.Columns[primaryKey];
                table.PrimaryKey = pkColumns;
            }
            return table.Rows.Find(pkValue);
        }

        /// <summary>
        /// Get DataTable by a field value
        /// </summary>
        /// <param name="table">DataTable in which value has to be searched.</param>
        /// <param name="fieldName">Field name</param>
        /// <param name="fieldValue">Field value to be searched.</param>
        /// <returns>Return DataTable containg result records.</returns>
        public static DataTable GetDataTableBy(DataTable table, string fieldName, object fieldValue)
        {
            if (fieldValue == null || table == null)
                return null;

            DataTable dtResult = null;
            DataRow[] rows = table.Select(string.Format("{0} = {1}", fieldName, fieldValue));
            if (rows != null && rows.Length > 0)
            {
                dtResult = rows.CopyToDataTable();
            }
            return dtResult;
        }
            

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="fieldshashtable"></param>
        /// <returns></returns>
        public static DataTable GetDataTableByExactFields(DataTable table, Hashtable fieldshashtable)
        {
            if (fieldshashtable == null || table == null)
                return null;

            DataTable dtResult = null;
            StringBuilder bufQryStr = new StringBuilder();
            int i = 0;
            foreach (DictionaryEntry field in fieldshashtable)
            {
                i++;
                if (field.Value.GetType() != typeof(int))
                {
                    bufQryStr.Append(string.Format("{0} = '{1}'", field.Key, field.Value));
                }
                else
                {
                    bufQryStr.Append(string.Format("{0} = {1}", field.Key, field.Value));
                }
                if (fieldshashtable.Count != i)
                {
                    bufQryStr.Append(" AND ");
                }              
            }
            DataRow[] rows = table.Select(bufQryStr.ToString());
            if (rows != null && rows.Length > 0)
            {
                dtResult = rows.CopyToDataTable();
            }
            return dtResult;
        }

        private static DataTable GetDataTableBy(DataTable table, List<Tuple<string, object>> kv, string logicalOperator)
        {            
            if (kv ==  null || table == null)
                return null;

            DataTable dtResult = null;
            StringBuilder bufQryStr = new StringBuilder();
            int i = 0;
            foreach (Tuple<string, object> fieldVal in kv)
            {
                i++;
                //if (field.Value.GetType() != typeof(int))
                if (fieldVal.Item2.GetType() != typeof(int))
                {
                    //bufQryStr.Append(string.Format("{0} = '{1}'", field.Key, field.Value));
                    bufQryStr.Append(string.Format("{0} = '{1}'", fieldVal.Item1, fieldVal.Item2));
                }
                else
                {
                    //bufQryStr.Append(string.Format("{0} = {1}", field.Key, field.Value));
                    bufQryStr.Append(string.Format("{0} = {1}", fieldVal.Item1, fieldVal.Item2));
                }
                if (kv.Count != i)
                {
                    bufQryStr.Append(string.Format(" {0} ", logicalOperator));
                }
            }
            DataRow[] rows = table.Select(bufQryStr.ToString());
            if (rows != null && rows.Length > 0)
            {
                dtResult = rows.CopyToDataTable();
            }
            return dtResult;
        }

        public static DataTable GetDataTableByAND(DataTable table, List<Tuple<string, object>> kv)
        {
            return GetDataTableBy(table, kv, "AND");
        }

        public static DataTable GetDataTableByOR(DataTable table, List<Tuple<string, object>> kv)
        {
            return GetDataTableBy(table, kv, "OR");
        }

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            DataTable dt = new DataTable();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                //dt.Columns.Add(prop.Name, prop.PropertyType);                
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T t in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(t);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

        public static DataTable ToDataTable<T>(IEnumerable<T> collection)
        {
            DataTable dt = new DataTable();
            Type t = typeof(T);
            PropertyInfo[] pia = t.GetProperties();
            //Create the columns in the DataTable
            foreach (PropertyInfo pi in pia)
            {
                dt.Columns.Add(pi.Name, pi.PropertyType);
            }
            //Populate the table
            foreach (T item in collection)
            {
                DataRow dr = dt.NewRow();
                dr.BeginEdit();
                foreach (PropertyInfo pi in pia)
                {
                    dr[pi.Name] = pi.GetValue(item, null);
                }
                dr.EndEdit();
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// Get random number from range
        /// </summary>
        /// <param name="start">Start of range</param>
        /// <param name="end">End of range</param>
        /// <param name="exclude">Values to be excluded</param>
        /// <returns>A random number</returns>
        public static int GetRandomNumber(int start, int end, int[] exclude)
        { 
            var range = Enumerable.Range(start, end).Where(i => !exclude.Contains(i));
            var rand = new Random();
            int index = rand.Next(start, end - exclude.Length);
            return range.ElementAt(index);
        }

        //public static DataTable GetDataTableBy(DataTable table, string[] fieldNames, object[] fieldValues)
        //{
        //    if (fieldValues == null)
        //        return null;

        //    DataTable dtResult = null;
        //    DataRow[] rows = table.Select(string.Format("{0} = {1}", fieldName, fieldValue));
        //    if (rows != null && rows.Length > 0)
        //    {
        //        dtResult = rows.CopyToDataTable();
        //    }
        //    return dtResult;
        //}

        public static void AddInitialNewRow(DataGridView dgv)
        {
            if (dgv != null && dgv.RowCount == 0)
            {
                DataTable dt = dgv.DataSource as DataTable;
                if (dt == null) return;
                DataRow newRow = dt.NewRow();
                dt.Rows.Add(newRow);
                dgv.DataSource = dt;
            }
        }

        //public static void AddInitialNewRow(DataTable dt)
        //{
        //    if (dt.Rows.Count == 0)
        //    {
        //        DataRow newRow = dt.NewRow();
        //        dt.Rows.Add(newRow);
        //    }
        //}

        public static void AddNewRow(DataTable dt)
        {
            if (dt == null) return;
            DataRow newRow = dt.NewRow();
            dt.Rows.Add(newRow);
        }

        public static object GetFirst(IEnumerable<object> source)
        {
            using (IEnumerator<object> iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    throw new Exception("Cannot get object from IEnumerator");
                }
                return iterator.Current;
            }           
        }

    }
}
