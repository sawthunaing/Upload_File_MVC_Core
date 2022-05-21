using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Upload_File_MVC_Core.Models
{
    public partial class UploadXmlFileModel
    {
        public partial class Transactions
        {
            [JsonProperty("Transaction")]
            public Transaction[] Transaction { get; set; }
        }

        public partial class Transaction
        {
            [JsonProperty("TransactionDate")]
            public DateTimeOffset TransactionDate { get; set; }

            [JsonProperty("PaymentDetails")]
            public PaymentDetails PaymentDetails { get; set; }

            [JsonProperty("Status")]
            public string Status { get; set; }

            [JsonProperty("_id")]
            public string Id { get; set; }
        }

        public partial class PaymentDetails
        {
            [JsonProperty("Amount")]
            public string Amount { get; set; }

            [JsonProperty("CurrencyCode")]
            public string CurrencyCode { get; set; }
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
        }
    }
}