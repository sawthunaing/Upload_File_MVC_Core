using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload_File_MVC_Core.Interfaces;

namespace Upload_File_MVC_Core.Common.Sample
{
    public class SampleDI : ISample
    {
        public void write(string text)
        {
            Console.WriteLine(text);
        }
    }
    
}
