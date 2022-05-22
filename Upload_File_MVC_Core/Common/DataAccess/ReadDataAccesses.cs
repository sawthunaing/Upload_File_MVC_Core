using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload_File_MVC_Core.Interfaces;
using Upload_File_MVC_Core.Models;

namespace Upload_File_MVC_Core.Common.DataAccess
{
    public class ReadDataAccesses : IReadDataAccesses
    {
        private readonly ReadTxnContext _context;
        public ReadDataAccesses(ReadTxnContext context)
        {
            _context = context;
        }
        public ListData GetTxnListById(RequestListParams request, string txnId)
        {

            List<ReadTxnContext.TblTransaction> _rows = new List<ReadTxnContext.TblTransaction>();
            int _count = _context.tblTransaction.Count();
            if (_count > 0)
                _rows = _context.tblTransaction
                    .Where(x => x.TransactionId == txnId)
                    .OrderBy(u => "u." + request.OrderBy)
                    .Skip((request.Page - 1) * request.PageSize)
                    .Take(request.PageSize).ToList();

            var outputRows = ConvertOutputResult(_rows);

            return new ListData
            {
                Rows = outputRows,
                Page = request.Page,
                Total = _count,
                PageSize = request.PageSize
            };
        }

        public ListData GetTxnListByDateRange(RequestListParams request, DateTime fromDateTime, DateTime toDateTime)
        {

            List<ReadTxnContext.TblTransaction> _rows = new List<ReadTxnContext.TblTransaction>();
            int _count = _context.tblTransaction.Count();
            if (_count > 0)
                _rows = _context.tblTransaction
                    .Where(x => fromDateTime >= x.TransactionDate && x.TransactionDate <= toDateTime)
                    .OrderBy(u => "u." + request.OrderBy)
                    .Skip((request.Page - 1) * request.PageSize)
                    .Take(request.PageSize).ToList();



            var outputRows = ConvertOutputResult(_rows);

            return new ListData
            {
                Rows = outputRows,
                Page = request.Page,
                Total = _count,
                PageSize = request.PageSize
            };
        }


        public ListData GetTxnListByStatus(RequestListParams request, string status)
        {

            List<ReadTxnContext.TblTransaction> _rows = new List<ReadTxnContext.TblTransaction>();
            int _count = _context.tblTransaction.Count();
            if (_count > 0)
            {


                _rows = _context.tblTransaction
                    .Where(x => x.OutputStatus == status)
                    .OrderBy(u => "u." + request.OrderBy)
                    .Skip((request.Page - 1) * request.PageSize)
                    .Take(request.PageSize).ToList();
            }
            var outputRows = ConvertOutputResult(_rows);

            return new ListData
            {
                Rows = outputRows,
                Page = request.Page,
                Total = _count,
                PageSize = request.PageSize
            };
        }


        public List<OutputTxnModel> ConvertOutputResult(List<ReadTxnContext.TblTransaction> _rows)
        {
            var lstOutputTxn = new List<OutputTxnModel>();
            foreach (var row in _rows)
            {
                var outputtxn = new OutputTxnModel();
                outputtxn.Id = row.TransactionId;
                outputtxn.payment = row.Amount.ToString() + " " + row.CurrencyCode;
                outputtxn.Status = row.OutputStatus;
                lstOutputTxn.Add(outputtxn);
            }

            return lstOutputTxn;
        }
    }
}
