using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Upload_File_MVC_Core.Models
{
    public class TxnModel
    {
        public Guid Id { get; set; }
        public string InvoiceId { get; set; }
        public string CurrencyCode { get; set; }
        public Decimal Amount { get; set; }
        public DateTime TxnDateTime { get; set; }
        public string CSVStatus { get; set; }
        public string XMLStatus { get; set; }
        public string Status { get; set; }
    }

  

}



   



