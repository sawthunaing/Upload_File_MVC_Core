using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Upload_File_MVC_Core.Interfaces;
using Upload_File_MVC_Core.Models;
using Upload_File_MVC_Core.ValidationAttribute;

namespace Upload_File_MVC_Core.Controllers
{
    [LogStatus]
    public class HomeController : Controller
    {
        private IHostingEnvironment _environment;
        protected readonly ILogger<ControllerBase> _logger;
        protected IDataAccesses _data;
        protected ISample _sample;
       
        public HomeController(IHostingEnvironment environment, ILogger<APIBasedController> logger, IDataAccesses data, ISample sample)
        {
            _environment = environment;
            _logger = logger;
            _data = data;
            _sample = sample;
        }

        public IActionResult Index()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(FileUploadViewModel model)
        {
            string fileName = "";
            try
            {
                if (ModelState.IsValid)
                {
                    var uploadFile = model.PostedFile;

                    fileName = Path.GetFileName(model.PostedFile.FileName);
                    var fileTypeArr = fileName.Split(".");
                    var fileType = fileTypeArr[1];

                    if (!CheckFileType(fileType))
                    {
                        return View();
                    }

                    if (!CheckFileSize(uploadFile))
                    {
                        return View();
                    }

                    string wwwPath = this._environment.WebRootPath;
                    string contentPath = this._environment.ContentRootPath;

                    string path = Path.Combine(this._environment.WebRootPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    List<string> uploadedFiles = new List<string>();
                    if (fileType == "xml")
                    {
                        var xml = CheckXmlFormat(model.PostedFile, path);
                        if (!xml.Any())
                        {
                            ViewBag.ErrorMessage += string.Format("<b>{0}</b> Unknown format.<br />", fileName);
                            return View();
                        }

                        if (!SaveTxnXml(xml))
                        {
                            ViewBag.ErrorMessage += string.Format("<b>{0}</b> System Error.<br />", fileName);
                            return View();
                        }


                    }
                    else
                    {
                        var csv = CheckCsvFormat(model.PostedFile,path);
                        if (!csv.Any())
                        {
                            ViewBag.ErrorMessage += string.Format("<b>{0}</b> Unknown format.<br />", fileName);
                            return View();
                        }

                        if (!SaveTxnCsv(csv))
                        {
                            ViewBag.ErrorMessage += string.Format("<b>{0}</b> System Error.<br />", fileName);
                            return View();
                        }
                    }

                   
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        model.PostedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);
                        ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                    }
                    
                    return View();
                }
                
                ViewBag.ErrorMessage += string.Format("Please select a file.");


            }
            catch (Exception e)
            {
                _sample.writetextfile(e.Message + string.Format("<b>{0} </b> Unknown format.<br /> ", fileName));
                ViewBag.ErrorMessage += string.Format("<b>{0}</b> Unknown format.<br />", fileName);
                
            }
            return View();
        }


        #region CSV Utility
        public List<UploadXmlFileModel.Transaction> CheckCsvFormat(IFormFile postedFile, string path)
        {
            var fileName = "";
            try
            {
                var lstXmlTxn = new List<UploadXmlFileModel.Transaction>();

                if (postedFile != null)
                {
                    fileName = postedFile.FileName;
                    var fileUrl = Path.Combine(path, fileName);
                    using (FileStream stream = new FileStream(fileUrl, FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                      
                    }

                    using (StreamReader sr = new StreamReader(fileUrl))
                    {

                        string line;
                        string[] rows = new string[5];
                        while ((line = sr.ReadLine()) != null)
                        {
                            var xmlTxn = new UploadXmlFileModel.Transaction();
                            var xmlPaymentDetail = new UploadXmlFileModel.PaymentDetails();
                        

                            rows = line.Split(',');

                            if (!CheckCsvData(rows))
                                break;

                            xmlTxn.Id = rows[0];

                            xmlTxn.Status = rows[4];

                            xmlTxn.TransactionDate = ConvertDateTimeForCsv(rows[3].Trim());
                            xmlPaymentDetail.Amount = decimal.Parse(rows[1]);
                            xmlPaymentDetail.CurrencyCode = rows[2];

                            xmlTxn.PaymentDetails = xmlPaymentDetail;
                            lstXmlTxn.Add(xmlTxn);

                        }
                    }



                    return lstXmlTxn;
                }
                else
                {
                    return lstXmlTxn;
                }


            }
            catch (Exception e)
            {
                _sample.writetextfile(e.Message +  "CheckXmlFormat : fileName " + fileName);
                throw;
            }

        }

        public bool CheckCsvData(string[] rows)
        {
            if (rows[0] == null)
            {
                return false;
            }
            else if (rows[0].Length > 50)
            {
                return false;
            }
            else if (rows[4] == null)
            {
                return false;
            }
            else if (rows[3] == null)
            {
                return false;
            }
           
            else if (rows[1] == null)
            {
                return false;
            }
            else if (rows[2] == null)
            {
                return false;
            }
            else
            {
               
                if (!CheckStatusForXmlAndCsv(rows[4], "csv")) return false;

                decimal deciAmt = 0;
                string strAmt = rows[1];
                if (!decimal.TryParse(strAmt, out deciAmt))
                {
                    return false;
                }

                var symbol = rows[2];
                if (string.IsNullOrEmpty(symbol)) return false;


                return true;
            }
        }

        public bool SaveTxnCsv(List<UploadXmlFileModel.Transaction> lstTransactions)
        {
            bool isSuccess = true;
            try
            {
                foreach (var transaction in lstTransactions)
                {
                    var tblTransaction = new TxnContext.TblTransaction();
                    tblTransaction.TransactionId = transaction.Id;
                    tblTransaction.Amount = transaction.PaymentDetails.Amount;
                    tblTransaction.CurrencyCode = transaction.PaymentDetails.CurrencyCode;
                    tblTransaction.TransactionDate = transaction.TransactionDate;
                    tblTransaction.CSVStatus = transaction.Status;
                    if (tblTransaction.CSVStatus == Common.Utility.CsvFailed)
                    {
                        tblTransaction.OutputStatus = "R";
                    }
                    else if (tblTransaction.CSVStatus == Common.Utility.CsvApproved)
                    {
                        tblTransaction.OutputStatus = "A";
                    }
                    else
                    {
                        tblTransaction.OutputStatus = "D";
                    }

                    if (!_data.InsertUsers(tblTransaction))
                    {
                        isSuccess = false;
                    }

                }
            }
            catch (Exception e)
            {
                return false;
            }
            return isSuccess;
        }

        public DateTime ConvertDateTimeForCsv(string datetimestr)
        {
            var aaaa = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            //2022-05-22T07:12:23
            //2019-01-23T13:45:10
            string format = "dd/MM/yyyy hh:mm:ss";
            DateTime dateTime;
            if (DateTime.TryParseExact(datetimestr, format, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }
            return dateTime;
        }
        #endregion


        #region XML Utility

        public bool SaveTxnXml(List<UploadXmlFileModel.Transaction> lstTransactions)
        {
            bool isSuccess = true;
            try
            {
                foreach (var transaction in lstTransactions)
                {
                    var tblTransaction = new TxnContext.TblTransaction();
                    tblTransaction.TransactionId = transaction.Id;
                    tblTransaction.Amount = transaction.PaymentDetails.Amount;
                    tblTransaction.CurrencyCode = transaction.PaymentDetails.CurrencyCode;
                    tblTransaction.TransactionDate = transaction.TransactionDate;
                    tblTransaction.XMLStatus = transaction.Status;
                    if (tblTransaction.XMLStatus == Common.Utility.XmlRejected)
                    {
                        tblTransaction.OutputStatus = "R";
                    }
                    else if (tblTransaction.XMLStatus == Common.Utility.XmlApproved)
                    {
                        tblTransaction.OutputStatus = "A";
                    }
                    else
                    {
                        tblTransaction.OutputStatus = "D";
                    }

                    if (!_data.InsertUsers(tblTransaction))
                    {
                        isSuccess = false;
                    }

                }
            }
            catch (Exception e)
            {
                return false;
            }
            return isSuccess;
        }
        
        public List<UploadXmlFileModel.Transaction> CheckXmlFormat(IFormFile postedFile,string path)
        {
            var fileName = "";
            try
            {
                var lstXmlTxn = new List<UploadXmlFileModel.Transaction>();

                if (postedFile != null)
                {
                    fileName = postedFile.FileName;
                    var fileUrl = Path.Combine(path, fileName);
                    using (FileStream stream = new FileStream(fileUrl, FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                    }
                   
                    var xmlInputData = System.IO.File.ReadAllText(fileUrl);

                    XDocument _doc = XDocument.Load(fileUrl);

                   
                    IEnumerable<XElement> therows = _doc.Descendants("Transactions").Elements("Transaction");

                    foreach (XElement el in therows)
                    {
                        var xmlTxn = new UploadXmlFileModel.Transaction();
                        var xmlPaymentDetail = new UploadXmlFileModel.PaymentDetails();
                        if(!CheckXmlData(el)) break;
                        
                        xmlTxn.Id = el.FirstAttribute.Value;
                       
                        xmlTxn.Status = el.Element("Status")?.Value;
                       
                        xmlTxn.TransactionDate = ConvertDateTimeForXml(el.Element("TransactionDate").Value.Trim());
                        xmlPaymentDetail.Amount = decimal.Parse(el.Element("PaymentDetails").Element("Amount").Value);
                        xmlPaymentDetail.CurrencyCode = el.Element("PaymentDetails").Element("CurrencyCode").Value;

                        xmlTxn.PaymentDetails = xmlPaymentDetail;
                        lstXmlTxn.Add(xmlTxn);

                    }
                   
                    return lstXmlTxn;
                }
                else
                {
                    return lstXmlTxn;
                }
                
            
            }
            catch (Exception e)
            {
                _logger.LogError(e, "CheckXmlFormat : fileName " + fileName);
                throw;
            }
           
        }
        
        public bool CheckXmlData(XElement xElement)
        {
            if (xElement.FirstAttribute.Value == null)
            {
                return false;
            }
            else if (xElement.FirstAttribute.Value.Length  > 50)
            {
                return false;
            }
            else if (xElement.Element("Status") == null)
            {
                return false;
            }
            else if (xElement.Element("TransactionDate") == null)
            {
                return false;

            }
            else if (xElement.Element("TransactionDate") == null)
            {
                return false;
            }
            else if (xElement.Element("PaymentDetails") == null)
            {
                return false;
            }
            else if (xElement.Element("PaymentDetails")?.Element("Amount") == null)
            {
                return false;
            }
            else if(xElement.Element("PaymentDetails")?.Element("CurrencyCode") == null)
            {
                return false;
            }
            else
            {

                if(!CheckStatusForXmlAndCsv(xElement.Element("Status")?.Value, "xml")) return false;
               
                decimal deciAmt = 0;
                string strAmt = xElement.Element("PaymentDetails")?.Element("Amount").Value;
                if (!decimal.TryParse(strAmt,out deciAmt))
                {
                    return false;
                }

                var symbol = GetCurrencySymbol(xElement.Element("PaymentDetails")?.Element("CurrencyCode").Value);
                if (string.IsNullOrEmpty(symbol)) return false;


                return true;
            }
        }

        public string GetCurrencySymbol(string currencyCode)
        {
            string symbol = string.Empty;
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            ArrayList Result = new ArrayList();
            foreach (CultureInfo ci in cultures)
            {
                RegionInfo ri = new RegionInfo(ci.LCID);
                if (ri.ISOCurrencySymbol == currencyCode)
                {
                    symbol = ri.CurrencySymbol;
                    return symbol;
                }
            }
            return symbol;
        }

        public bool CheckStatusForXmlAndCsv(string status, string filetype)
        {
            if (filetype == "xml")
            {
                if (status != Common.Utility.XmlApproved && status != Common.Utility.XmlDone &&
                    status != Common.Utility.XmlRejected)
                {
                    return false;
                }

                return true;
            }
            else
            {
                if (status != Common.Utility.CsvApproved && status != Common.Utility.CsvFailed &&
                    status != Common.Utility.CsvFinished)
                {
                    return false;
                }
                return true;
            }

        }

        public bool CheckFileType(string fileType)
        {
            var IsValidFileType = false;
          
            try
            {
                if (fileType == "xml" || fileType == "csv")
                    return true;
                else
                {
                    ViewBag.ErrorMessage += string.Format("Only support xml and csv file type. This <b>{0}</b> do not support. <br />", fileType);
                    _sample.writetextfile(string.Format("Only support xml and csv file type. This <b>{0}</b> do not support. <br />", fileType));

                    return false;
                }
            }
            catch (Exception e)
            {
                _sample.writetextfile(e.Message + "CheckFileType");
            }
            
            return IsValidFileType;
        }

        public bool CheckFileSize(IFormFile postedFile)
        {
            var IsValidTypeSize = false;
            try
            {
                int maxFileSize = 1;
                var fileSize = postedFile.Length;
                if (fileSize > (maxFileSize * 1024 * 1024))
                {
                    ViewBag.ErrorMessage += string.Format("File size is too large. Maximum file size permitted is <b>{0}</b> MB <br />",maxFileSize);
                    _sample.writetextfile(string.Format("File size is too large. Maximum file size permitted is <b>{0}</b> MB <br />", maxFileSize));
                    return false;
                }

                return true;
            
            }
            catch (Exception e)
            {
                _sample.writetextfile(e.Message + "CheckFileSize");
            }

            return IsValidTypeSize;
        }

        public DateTime ConvertDateTimeForXml(string datetimestr)
        {
            var aaaa = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss");
            
            string format = "yyyy-MM-ddThh:mm:ss";
            DateTime dateTime;
            if (DateTime.TryParseExact(aaaa, format, CultureInfo.CurrentCulture,
                DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }
            return dateTime;
        }

        #endregion






    }
}