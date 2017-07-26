﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using InvoiceJe.Data;
using InvoiceJe.Models;
using System.Linq;

namespace InvoiceJe.Droid.Activities
{
    [Activity(Theme = "@style/MasterTheme")]
    public class InvoicesEditActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.invoicesedit_activity);

            // Setup toolbar
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetTitle(Resource.String.applicationname); // Set toolbar title here

            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetHomeButtonEnabled(true);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            }

            var repository = new Repository();
            int invoiceId = this.Intent.Extras.GetInt("InvoiceId");
            Invoice invoice = repository.GetInvoices().Where(x => x.Id == invoiceId).FirstOrDefault();

            TextView referenceNumberTextView = FindViewById<TextView>(Resource.Id.invoiceReferenceNumber);
            TextView billToTextView = FindViewById<TextView>(Resource.Id.invoiceBillTo);
            TextView amountTextView = FindViewById<TextView>(Resource.Id.invoiceAmount);

            referenceNumberTextView.Text = invoice.ReferenceNumber;
            billToTextView.Text = invoice.BillTo;
            amountTextView.Text = invoice.Amount.ToString();

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