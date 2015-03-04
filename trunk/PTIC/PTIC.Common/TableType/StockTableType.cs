using System;
using System.Data;

namespace PTIC.Common.TableType
{
    public class StockTableType
    {
        public int ProductID { get; set; }
        public int PlaceID { get; set; }
        public int Place { get; set; } // 0 = warehouse, 1 = vehicle
        public int? SalePersonID { get; set; }
        // If Place is warehouse, 0 = Factory, 1 = Warehouse, 2 = Vehicle, 3 = CustomerOrSale, 4 = Opening.
        // Else if vehicle, 0 = Warehouse, 1 = CustomerOrSale, 2 = Service.
        public int StockBy { get; set; }
        public int Qty { get; set; }
        public DateTime Date { get; set; }
        public string Remark { get; set; }

        /// <summary>
        /// Clones the structure of the DataTable StockTableType.
        /// </summary>
        /// <returns></returns>
        public static DataTable AsClonedDataTable()
        {
            DataTable dtStock = new DataTable("StockTableType");
            dtStock.Columns.Add("ProductID", typeof(int));
            dtStock.Columns.Add("PlaceID", typeof(int));
            dtStock.Columns.Add("Place", typeof(int));
            dtStock.Columns.Add("SalePersonID", typeof(int));
            dtStock.Columns.Add("StockBy", typeof(int));
            dtStock.Columns.Add("Qty", typeof(int));
            dtStock.Columns.Add("Date", typeof(DateTime));
            dtStock.Columns.Add("Remark", typeof(string));

            return dtStock;
        }
    }
}
