using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload_File_MVC_Core.Common;
using Upload_File_MVC_Core.Models;

namespace Upload_File_MVC_Core.Interfaces
{
    public interface IDataAccesses
    {
        bool InsertUsers(TxnContext.TblTransaction txn);
        
    }
}
