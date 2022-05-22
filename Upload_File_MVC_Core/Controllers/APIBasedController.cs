using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Upload_File_MVC_Core.Interfaces;

namespace Upload_File_MVC_Core.Controllers
{
    public class APIBasedController : ControllerBase
    {
        protected ISample _sample;
        protected readonly ILogger<ControllerBase> _logger;
        protected IReadDataAccesses _data;
        public APIBasedController(ISample sample, ILogger<APIBasedController> logger, IReadDataAccesses data)
        {
            _sample = sample;
            _logger = logger;
            _data = data;
        }
    }
}
