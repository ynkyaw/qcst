/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/04/17 (yyyy/mm/dd)
 * Description: Database field attribute file
 */

using System;
namespace PTIC.Common
{
    /// <summary>
    /// Database field attribute class that the property maps to
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DBField : Attribute
    {
        private string mFieldName;

        private DBField() { }

        /// <summary>
        /// Name of the field that the property will be mapped to
        /// </summary>
        /// <param name="fieldName"></param>
        public DBField(string fieldName)
        {
            this.mFieldName = fieldName;
        }

        public string FieldName
        {
            get { return this.mFieldName; }
        }
    }
}
