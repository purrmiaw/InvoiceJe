using InvoiceJe.Models;
//using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceJe.Data
{
    public class Repository
    {

        private DataContext _db;

        public Repository(string databasePath)
        {
            _db = new DataContext(databasePath);
        }

        public async System.Threading.Tasks.Task CreateAsync(Invoice invoice)
        {
            _db.Invoices.Add(invoice);
            await _db.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateAsync(Invoice invoice)
        {
           // await _db.UpdateAsync(invoice);
        }

        public IEnumerable<Invoice> GetInvoices()
        {
            // return _db.Table<Invoice>().ToListAsync().Result;
            //return new List<Invoice>();
            return _db.Invoices.ToList();
        }
    }
}
