using InvoiceJe.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace InvoiceJe.Data
{
    public class DataContext : DbContext
    {

        private string _databasePath = "";

        public DataContext()
        {

        }

        public DataContext(string databasePath)
        {

            _databasePath = databasePath;
            Database.EnsureCreated();

            //Database.Migrate();

            //// Android
            //var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "invoiceje.db");

            //// UWP
            //var dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "exrin.db");

            //// iOS
            //var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "exrin.db");

        }

        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionStringBuilder = new SqliteConnectionStringBuilder()
            {
                DataSource = _databasePath
            }
            .ToString();

            var connection = new SqliteConnection(connectionStringBuilder);
            optionsBuilder.UseSqlite(connection);
        }
    }
}
