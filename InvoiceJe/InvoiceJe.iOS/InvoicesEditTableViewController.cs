using Foundation;
using InvoiceJe.Data;
using InvoiceJe.iOS.Extensions;
using InvoiceJe.Models;
using System;
using System.Linq;
using UIKit;

namespace InvoiceJe.iOS
{
    public partial class InvoicesEditTableViewController : UITableViewController
    {
        public int InvoiceId { get; set; }

        public InvoicesEditTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var repository = new Repository(FileAccessHelper.GetLocalDatabasePath());
            var invoice = repository.GetInvoices().Where(x => x.Id == InvoiceId).FirstOrDefault();

            ReferenceNumber.Text = invoice.ReferenceNumber;
            BillTo.Text = invoice.BillTo;
            Amount.Text = invoice.Amount.ToString();

        }
    }
}