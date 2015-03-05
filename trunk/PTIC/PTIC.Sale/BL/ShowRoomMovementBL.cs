using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using System.Data.SqlClient;

namespace PTIC.Sale.BL
{
    public class ShowRoomMovementBL
    {
        ShowRoomMovementDA showRoomMovementDA = new ShowRoomMovementDA();

        #region SELECT
        public DataTable GetScheme()
        {
            return ShowRoomMovementDA.SelectAll();
        }

        public DataTable GetByCondition(DateTime DeliverDate, int SalesPerson, int MoveFrom, int MoveTo,int VenNo)
        {
            return ShowRoomMovementDA.SelectByCondition(DeliverDate, SalesPerson, MoveFrom, MoveTo,VenNo);
        }
        #endregion

        #region INSERT
        //public int Create(ShowRoomMovement showRoomMovement)
        //{
        //    int id;
        //    if (!showRoomMovementDA.isExist(showRoomMovement.ID.ToString()))
        //    {
        //        id = showRoomMovementDA.Insert(showRoomMovement);
        //    }
        //    else
        //    {
        //        id = showRoomMovementDA.Update(showRoomMovement);
        //    }
        //    return id;
        //}

        public int Move(ShowRoomMovement showRoomMovement,SqlConnection conn)
        {
            return ShowRoomMovementDA.Insert(showRoomMovement,conn);
        }
        #endregion

        #region UPDATE
        public int MoveUpdate(ShowRoomMovement showRoomMovement, SqlConnection conn)
        {
            return ShowRoomMovementDA.Update(showRoomMovement, conn);
        }
        #endregion
    }
}
