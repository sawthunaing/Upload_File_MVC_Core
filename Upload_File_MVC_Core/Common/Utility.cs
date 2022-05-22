using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

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

        #region Declaration
        public static string dateFormat = "dd/MM/yyyy";
        public static string sLogFormat;
        public static string sErrorTime;
        public static string sLogTime;
        public static string logFilePath = Directory.GetCurrentDirectory() + "\\logs\\";

        public static string ErrorlogFilePath = Directory.GetCurrentDirectory() + "\\errorlogs\\";


        #endregion

        #region Logs
        public static void CreateLog(string sErrMsg)
        {
            //sLogFormat used to create log files format :
            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            sLogFormat = DateTime.Now.ToString("dd/MM/yyyy").ToString() + " " + DateTime.Now.ToLongTimeString() + " ==> ";

            //this variable used to create log filename format "
            //for example filename : ErrorLogYYYYMMDD
            string sPathName;
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            sErrorTime = sYear + sMonth + sDay;

            sPathName = (logFilePath + sErrorTime + ".txt");
            //sPathName = ConfigurationManager.AppSettings["LogPath"].ToString() + sErrorTime;
            //File exists or not
            DirectoryInfo info = new DirectoryInfo(logFilePath);
            if (!info.Exists)
            {
                info.Create();
            }
            StreamWriter sw;
            if (!File.Exists(sPathName))
            {
                sw = File.CreateText(sPathName);
                // sw = new StreamWriter(sPathName+sErrorTime,true);
            }
            else
            {
                sw = File.AppendText(sPathName);

            }
            sw.WriteLine(sLogFormat + sErrMsg);
            sw.Flush();
            sw.Close();
        }

        public static void CreateErrorLog(string sErrMsg)
        {
            //sLogFormat used to create log files format :
            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            sLogFormat = DateTime.Now.ToString("dd/MM/yyyy").ToString() + " " + DateTime.Now.ToLongTimeString() + " ==> ";

            //this variable used to create log filename format "
            //for example filename : ErrorLogYYYYMMDD
            string sPathName;
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            sErrorTime = sYear + sMonth + sDay;

            sPathName = (ErrorlogFilePath + sErrorTime + ".txt");
            //sPathName = ConfigurationManager.AppSettings["LogPath"].ToString() + sErrorTime;
            //File exists or not
            DirectoryInfo info = new DirectoryInfo(ErrorlogFilePath);
            if (!info.Exists)
            {
                info.Create();
            }
            StreamWriter sw;
            if (!File.Exists(sPathName))
            {
                sw = File.CreateText(sPathName);
                // sw = new StreamWriter(sPathName+sErrorTime,true);
            }
            else
            {
                sw = File.AppendText(sPathName);

            }
            sw.WriteLine(sLogFormat + sErrMsg);
            sw.Flush();
            sw.Close();
        }

        #endregion
    }
}
