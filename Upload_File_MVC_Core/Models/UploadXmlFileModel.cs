using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Upload_File_MVC_Core.Models
{
    public class UploadXmlFileModel
    {
        public class Transactions
        {
            public List<Transaction> LstTransactions { get; set; }
        }


        public class Transaction
        {

            public DateTime TransactionDate { get; set; }


            public PaymentDetails PaymentDetails { get; set; }


            public string Status { get; set; }


            public string Id { get; set; }
        }

        public class PaymentDetails
        {

            public Decimal Amount { get; set; }


            public string CurrencyCode { get; set; }
        }
    }
}