using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PTIC.Marketing.DA
{
    interface IQCSTDataAccessLayer
    {
         int Insert(object obj);
         int Update(object obj);
         DataTable SelectAll();
         object SelectById(int id);
    }
}
