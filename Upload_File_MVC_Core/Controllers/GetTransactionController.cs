using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Upload_File_MVC_Core.Common;
using Upload_File_MVC_Core.Interfaces;
using Upload_File_MVC_Core.ValidationAttribute;

namespace Upload_File_MVC_Core.Controllers
{
    [LogStatus]
    [ApiController]
    [Route("[controller]/[action]")]
    public class GetTransactionController : APIBasedController
    {
        
        public GetTransactionController(ISample sample, ILogger<APIBasedController> logger, IDataAccesses data) : base(sample, logger, data)
        {
        }



        [HttpGet(Name = "GetTxnListById")]
        public ListData GetTxnListById(string txnId)
        {
            try
            {
                return _data.GetTxnListById(new RequestListParams()
                {
                    Page = 1,
                    PageSize = 20
                }, txnId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        [HttpGet(Name = "GetTxnListByDateRange")]
        public ListData GetTxnListByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                return _data.GetTxnListByDateRange(new RequestListParams()
                {
                    Page = 1,
                    PageSize = 20
                }, fromDate,toDate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


        [HttpGet(Name = "GetTxnListByStatus")]
        public ListData GetTxnListByStatus(string status)
        {
            try
            {
                return _data.GetTxnListByStatus(new RequestListParams()
                {
                    Page = 1,
                    PageSize = 20
                }, status);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


    }

    
}
