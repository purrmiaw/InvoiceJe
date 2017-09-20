using InvoiceJe.Models;
using InvoiceJe.SharedModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

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

        public async System.Threading.Tasks.Task<IEnumerable<Invoice>> GetInvoicesFromWebserviceAsync()
        {
            IEnumerable<Invoice> invoices = new List<Invoice>();

            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://rabbit.miaw.xyz/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("http://rabbit.miaw.xyz/api/invoices");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    invoices = JsonConvert.DeserializeObject<IEnumerable<Invoice>>(result);
                }
            }

            return invoices;
        }

    }
}
