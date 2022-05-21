using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Upload_File_MVC_Core.Models;
using Upload_File_MVC_Core.ValidationAttribute;

namespace Upload_File_MVC_Core.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment Environment;

        public HomeController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [LogStatus]
        [HttpPost]
        public IActionResult Index(FileUploadViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string wwwPath = this.Environment.WebRootPath;
                    string contentPath = this.Environment.ContentRootPath;

                    string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    List<string> uploadedFiles = new List<string>();
                    foreach (IFormFile postedFile in model.PostedFiles)
                    {
                        var xml = CheckXmlFormat(postedFile);
                        string fileName = Path.GetFileName(postedFile.FileName);
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                            uploadedFiles.Add(fileName);
                            ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                        }
                    }

                    return View();
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return View();
        }

        public object CheckXmlFormat(IFormFile postedFile)
        {
            var serializer = new XmlSerializer(typeof(UploadXmlFileModel));
            var uploadXmlFileModelResult = serializer.Deserialize(postedFile.OpenReadStream());

            return uploadXmlFileModelResult;
        }








    }
}