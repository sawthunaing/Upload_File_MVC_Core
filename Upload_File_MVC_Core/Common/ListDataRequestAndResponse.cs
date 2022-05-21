using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload_File_MVC_Core.Models;

namespace Upload_File_MVC_Core.Common
{
    public class ListData
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<TxnContext.TblTransaction> Rows { get; set; }
    }

    public class RequestListParams
    {
        public string OrderBy { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

    }
    
}
