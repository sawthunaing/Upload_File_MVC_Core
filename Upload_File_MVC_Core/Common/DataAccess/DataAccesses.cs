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

        #region InsertUsers
        public bool InsertUsers(TxnContext.TblTransaction txn)
        {

            try
            {
                _context.Add(txn);
                _context.SaveChanges();
            }
            catch (System.Exception e)
            {

                throw;
            }

            return true;


        }
        #endregion
        
     
    }
}
