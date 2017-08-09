using Foundation;
using InvoiceJe.Data;
using InvoiceJe.iOS.Extensions;
using InvoiceJe.Models;
using System;
using UIKit;

namespace InvoiceJe.iOS
{
    public partial class InvoicesCreateTableViewController : UITableViewController
    {
        public InvoicesCreateTableViewController (IntPtr handle) : base (handle)
        {

        }

        partial void UIButton3265_TouchUpInside(UIButton sender)
        {
            Invoice invoice = new Invoice();
            invoice.ReferenceNumber = ReferenceNumber.Text;
            invoice.BillTo = BillTo.Text;
            invoice.Amount = Decimal.Parse(Amount.Text);

            using (var db = new DataContext(FileAccessHelper.GetLocalDatabasePath()))
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
            }
        }
    }
}