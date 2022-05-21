using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload_File_MVC_Core.Interfaces;
using Upload_File_MVC_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;

namespace Upload_File_MVC_Core.Common.DataAccess
{
    public class DataAccesses : IDataAccesses
    {
        private readonly TxnContext _context;
        public DataAccesses(TxnContext context)
        {
            _context = context;
        }

        public ListData GetTxnListById(RequestListParams request,string txnId)
        {

            List<TxnContext.TblTransaction> _rows = new List<TxnContext.TblTransaction>();
            int _count = _context.tblTransaction.Count();
            if (_count > 0)
                _rows = _context.tblTransaction
                    .Where(x => x.TransactionId == txnId)
                    .OrderBy(u => "u." + request.OrderBy)
                    .Skip((request.Page - 1) * request.PageSize)
                    .Take(request.PageSize).ToList();

            return new ListData
            {
                Rows = _rows,
                Page = request.Page,
                Total = _count,
                PageSize = request.PageSize
            };
        }

        public ListData GetTxnListByDateRange(RequestListParams request, DateTime fromDateTime,DateTime toDateTime)
        {

            List<TxnContext.TblTransaction> _rows = new List<TxnContext.TblTransaction>();
            int _count = _context.tblTransaction.Count();
            if (_count > 0)
                _rows = _context.tblTransaction
                    .Where(x => fromDateTime>= x.TransactionDate && x.TransactionDate <= toDateTime)
                    .OrderBy(u => "u." + request.OrderBy)
                    .Skip((request.Page - 1) * request.PageSize)
                    .Take(request.PageSize).ToList();

            return new ListData
            {
                Rows = _rows,
                Page = request.Page,
                Total = _count,
                PageSize = request.PageSize
            };
        }


        public ListData GetTxnListByStatus(RequestListParams request, string status)
        {
            var csvStatus = "";
            var xmlStatus = "";
            List<TxnContext.TblTransaction> _rows = new List<TxnContext.TblTransaction>();
            int _count = _context.tblTransaction.Count();
            if (_count > 0)
            {
                if (status == Common.Utility.OutputStatusApproved)
                {
                    csvStatus = Utility.CsvApproved;
                    xmlStatus = Utility.XmlApproved;
                }
                else if (status == Common.Utility.OutputStatusFinished)
                {
                    csvStatus = Utility.CsvFinished;
                    xmlStatus = Utility.XmlDone;
                }
                else
                {
                    csvStatus = Utility.CsvFailed;
                    xmlStatus = Utility.XmlRejected;
                }

                _rows = _context.tblTransaction
                    .Where(x => x.CSVStatus == csvStatus && x.XMLStatus == xmlStatus)
                    .OrderBy(u => "u." + request.OrderBy)
                    .Skip((request.Page - 1) * request.PageSize)
                    .Take(request.PageSize).ToList();
            }

            return new ListData
            {
                Rows = _rows,
                Page = request.Page,
                Total = _count,
                PageSize = request.PageSize
            };
        }
    }
}
