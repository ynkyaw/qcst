using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Sale.DA;
using System.Data.SqlClient;
using PTIC.Sale.Entities;

namespace PTIC.Sale.BL
{
    public class SalesPlanBL
    {
        public DataTable GetbyMonth(DateTime month)
        {
            return SalesPlanDA.GetbyMonth(month);
        }

        public DataTable GetbyMonthAndBrand(DateTime month,int BrandID)
        {
            return SalesPlanDA.GetbyMonthAndBrand(month,BrandID);
        }

        public DataTable GetDetailBySalesPlanID(int p)
        {
            return SPDetailDA.GetDetailBySalesPlanID(p);
        }

        public int InsertSalesPlan(SalesPlan saleplan, SqlConnection conn)
        {
            return SalesPlanDA.Insert(saleplan, conn);
        }

        public int InsertDetails(SalesPlanDetail spdetail, SqlConnection conn)
        {
            return SPDetailDA.Insert(spdetail, conn);
        }

        public int Save(SalesPlan saleplan, List<SalesPlanDetail> spdetails, SqlConnection conn)
        {
            try
            {
                return SalesPlanDA.Save(saleplan, spdetails, conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public int UpdateSaleplan(SalesPlan saleplan, SqlConnection conn)
        {
            return SalesPlanDA.Update(saleplan,conn);
        }

        public int UpdateDetails(SalesPlanDetail spdetail, SqlConnection conn)
        {
            return SPDetailDA.Update(spdetail,conn);
        }

        public int DeleteSPDetail(int spDetailID,SalesPlan newSalesPlan)
        {
            return SPDetailDA.Delete(spDetailID,newSalesPlan);
        }
    }
}
