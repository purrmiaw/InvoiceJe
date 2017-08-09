using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InvoiceJe.Data;

namespace InvoiceJeMigrationsBait.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20170808055510_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("InvoiceJe.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<string>("BillTo");

                    b.Property<string>("ReferenceNumber");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });
        }
    }
}
