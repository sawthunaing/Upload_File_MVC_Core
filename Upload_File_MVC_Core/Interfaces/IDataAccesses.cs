using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload_File_MVC_Core.Common;

namespace Upload_File_MVC_Core.Interfaces
{
    public interface IDataAccesses
    {
        ListData GetTxnListById(RequestListParams request, string txnId);
        ListData GetTxnListByDateRange(RequestListParams request, DateTime fromdate, DateTime toDate);
        ListData GetTxnListByStatus(RequestListParams request, string status);


    }
}
