using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using PTIC.Sale.DA;

namespace PTIC.Sale.BL
{
    public class DeliveryNoteBL
    {
        #region SELECT FROM OrderTbl
        public DataTable GetByDate(DeliveryNote deliverynote, SqlConnection conn)
        {
            return DeliveryNoteDA.SelectByDeliveryID(deliverynote, conn);
        }

        public DataTable GetDeliveryNoteByDate(DeliveryNote deliverynote)
        {
            return DeliveryNoteDA.SelectDeliveryNoteByDate(deliverynote);
        }

        public DataTable GetFromOriginByDate(DeliveryNote deliverynote)
        {
            return DeliveryNoteDA.SelectByDate(deliverynote);
        }

        public DataTable GetDeliveryNoteDetail(int DeliveryNoteID)
        {
            return DeliveryNoteDA.SelectByDeliveryID(DeliveryNoteID);
        }

        #endregion        

        #region INSERT
         public int? Add(DeliveryNote newDeliveryNote, List<DeliveryNoteDetail> newDeliveryNoteRecords,int warehouseID)
        {
            return DeliveryNoteDA.Insert(newDeliveryNote, newDeliveryNoteRecords,warehouseID);
        }
        #endregion

         #region DELETE
         public int DeleteByDeliveryNoteDetailID(int DeliveryDetailID, SqlConnection conn)
         {
             return DeliveryNoteDA.DeleteByDeliveryDetailID(DeliveryDetailID, conn);
         }
         #endregion
    }
}
