using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.DA
{
    public class CompanyPlanDA:IQCSTDataAccessLayer
    {

        public int Insert(object obj)
        {
            int effectedRow=0;
            try
            {

            }
            catch (Exception ex)
            {
                
            }

            return effectedRow;
        }

        public int Update(object obj)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable SelectAll()
        {
            throw new NotImplementedException();
        }

        public object SelectById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
