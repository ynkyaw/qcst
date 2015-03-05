using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;

namespace PTIC.Sale.DA
{
    public class ServicedCustomerDA
    {
        static BaseDAO b = new BaseDAO();

        public static DataTable SelectAllByServicedCustomerID(int? ServicedCustomerID)
        {
            DataTable dt = null;
            try
            {
                dt = b.SelectByQuery("SELECT ID,CustomerID,TownID,TownshipID,UserName,ContactPerson,ShopName,Phone1,Phone2 "
                                                    +"FROM ServicedCustomer WHERE ID =" + ServicedCustomerID);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return dt;
        }
    }
}
