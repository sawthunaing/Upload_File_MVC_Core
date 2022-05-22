using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Upload_File_MVC_Core.Common.Sample;
using Upload_File_MVC_Core.Interfaces;

namespace Upload_File_MVC_Core.ValidationAttribute
{
    public class LogStatusAttribute : Attribute, IActionFilter
    {
        protected ISample logger;


        public LogStatusAttribute()
        {
            logger = new SampleDI();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

             logger.write("OnActionExecuting");
             Console.WriteLine("OnActionExecuting");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("OnActionExecuted");
        }
    }


}
