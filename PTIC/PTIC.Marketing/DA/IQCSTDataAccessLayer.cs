using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PTIC.Marketing.DA
{
    interface IQCSTDataAccessLayer
    {
        public int Insert(object obj);
        public int Update(object obj);
        public DataTable SelectAll();
        public object SelectById(int id);
    }
}
