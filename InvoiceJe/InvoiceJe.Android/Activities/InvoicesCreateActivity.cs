using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using InvoiceJe.Data;
using InvoiceJe.Droid.Extensions;
using InvoiceJe.Models;

namespace InvoiceJe.Droid.Activities
{
    [Activity(Theme = "@style/MasterTheme")]
    public class InvoicesCreateActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.invoicescreate_activity);

            // Setup toolbar
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetTitle(Resource.String.applicationname); // Set toolbar title here

            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetHomeButtonEnabled(true);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }

            // Setup clicks
            FloatingActionButton button = FindViewById<FloatingActionButton>(Resource.Id.save_button);
            button.Click +=
                delegate
                {
                    var invoice = new Invoice();
                    invoice.ReferenceNumber = "ttt";
                    invoice.BillTo = "xxx";
                    invoice.Amount = 200;

                    using (var db = new DataContext(FileAccessHelper.GetLocalDatabasePath()))
                    {
                        db.Invoices.Add(invoice);
                        db.SaveChanges();
                    }
                };

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case global::Android.Resource.Id.Home:
                    OnBackPressed();
                    break;
            }
            return true;
        }

    }
}