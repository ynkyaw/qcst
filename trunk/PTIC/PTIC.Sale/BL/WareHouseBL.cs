using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Sale.DA;
using System.Data.SqlClient;

namespace PTIC.Sale.BL
{
    public class WarehouseBL
    {
        #region SELECT
        public DataTable GetShowRoom()
        {
            return WarehouseDA.ShowRoom();
        }

        public DataTable GetAll()
        {
            return WarehouseDA.SelectAll();
        }

        public DataTable GetAllSubStore()
        {
            return WarehouseDA.SelectAllSubStore();
        }
        #endregion
    }
}
