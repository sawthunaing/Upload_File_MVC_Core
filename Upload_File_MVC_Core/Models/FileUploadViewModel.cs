using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Upload_File_MVC_Core.ValidationAttribute;

namespace Upload_File_MVC_Core.Models
{
    public class FileUploadViewModel 
    {
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        public IFormFile PostedFile { get; set; }
    }
    
}

