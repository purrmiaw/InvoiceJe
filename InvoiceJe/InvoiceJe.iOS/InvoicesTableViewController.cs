using Foundation;
using InvoiceJe.Data;
using InvoiceJe.iOS.Extensions;
using InvoiceJe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace InvoiceJe.iOS
{
    public partial class InvoicesTableViewController : UITableViewController
    {

        private IEnumerable<Invoice> _invoices;

        public InvoicesTableViewController (IntPtr handle) : base (handle)
        {
            var repository = new Repository(FileAccessHelper.GetLocalDatabasePath());
            _invoices = repository.GetInvoices();
        }

        /// <summary>
        /// Happens every time a view loads
        /// </summary>
        /// <param name="animated"></param>
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            TableView.Source = new InvoicesTableSource(_invoices);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {            
            base.PrepareForSegue(segue, sender);

            if (segue.Identifier == "ShowInvoicesEditViewController")
            {
                var editViewController = segue.DestinationViewController as InvoicesEditTableViewController;
                var row = TableView.IndexPathForSelectedRow;
                var invoice = _invoices.ElementAt(row.Row);
                editViewController.InvoiceId = invoice.Id;
            }
        }
    }


    public class InvoicesTableSource : UITableViewSource
    {

        private IEnumerable<Invoice> _invoices;
        private string _cellIdentifier = "TaskCell";

        public InvoicesTableSource(IEnumerable<Invoice> invoices)
        {
            _invoices = invoices;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(_cellIdentifier);

            // If there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, _cellIdentifier);
            }

            Invoice invoice = _invoices.ElementAt(indexPath.Row);
            cell.TextLabel.Text = invoice.ReferenceNumber;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _invoices.Count();
        }

    }

}