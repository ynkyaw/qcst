using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class Formula
    {
        #region Properties
        public int FormulaID { get; set; }
        public string ConvertFormula { get; set; }
        public float CalculatedValue { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; } 
        #endregion
    }
}
