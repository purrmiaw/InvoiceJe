using InvoiceJe.Models;
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
            _db.Entry(invoice).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public IEnumerable<Invoice> GetInvoices()
        {
            return _db.Invoices.ToList();
        }
    }
}
