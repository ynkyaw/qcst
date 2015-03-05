/* Author   :   Aung Ko Ko
    Date      :   14 Feb 2014
    Description :   Product Entity
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class Product
    {
        #region Properties
        public int ID { get; set; }
        public int? FormulaID { get; set; }
        public int SubCategoryID { get; set; }
        public String ProductName { get; set; }
        public String ProductCode { get; set; }
        public String UsedPlace { get; set; }
        public int NoPerPack { get; set; }
        public int ConLength { get; set; }
        public int ConBase { get; set; }
        public int ConHeight { get; set; }
        public int ConThick { get; set; }
        public int MinOrderQty { get; set; }
        public float Volt { get; set; }
        public int Plate { get; set; }
        public float Amps { get; set; }
        public float Acid { get; set; }
        public float FreeConWeight { get; set; }
        public float LeadWeight { get; set; }
        public String Remark { get; set; }
        public bool HasDiscount { get; set; }
        #endregion



    }
}
