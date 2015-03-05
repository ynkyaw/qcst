using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Marketing.DA;
using System.Data;

namespace PTIC.Marketing.BL
{
    public class ComplaintBL
    {
        #region SELECT
        public DataTable GetAll(int ComplaintID,SqlConnection conn)
        {
            return ComplaintDA.SelectAll(ComplaintID,conn);
        }
        #endregion
           

        #region INSERT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newComplaint"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int Insert(Complaint complaint,ComplaintServiceRecord complaintsvrecord, SqlConnection conn)
        {
            return ComplaintDA.Insert(complaint, complaintsvrecord, conn);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UpdateComplaint"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int Update(Complaint complaint, ComplaintServiceRecord complaintsvrecord, SqlConnection conn)
        {
            return ComplaintDA.Update(complaint, complaintsvrecord, conn);
        }
        #endregion
    }
}
