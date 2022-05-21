using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upload_File_MVC_Core.Common
{
    public class Utility
    {
        #region Transaction Type
        public static readonly string XmlApproved = "Approved";
        public static readonly string XmlRejected = "Rejected";
        public static readonly string XmlDone = "Done";
        public static readonly string CsvApproved = "Approved";
        public static readonly string CsvFailed = "Failed";
        public static readonly string CsvFinished = "Finished";
        public static readonly string OutputStatusApproved = "A";
        public static readonly string OutputStatusRejected = "R";
        public static readonly string OutputStatusFinished = "D";
        #endregion
    }
}
