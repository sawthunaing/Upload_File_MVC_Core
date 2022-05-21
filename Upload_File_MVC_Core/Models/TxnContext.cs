using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Upload_File_MVC_Core.Models
{
    public class TxnContext : DbContext
    {

        public TxnContext(DbContextOptions<TxnContext> options) : base(options)
        {

        }
        public DbSet<TblTransaction> tblTransaction { get; set; }

        public class TblTransaction
        {

            [Key]
            public Guid Id { get; set; }
            public string TransactionId { get; set; }
            public string CurrencyCode { get; set; }
            public Decimal Amount { get; set; }
            public DateTime TransactionDate { get; set; }
            public string CSVStatus { get; set; }
            public string XMLStatus { get; set; }

        }
    }
}