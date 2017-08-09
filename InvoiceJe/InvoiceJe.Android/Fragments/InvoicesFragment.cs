using System;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using InvoiceJe.Models;
using System.Collections.Generic;
using System.Linq;
using InvoiceJe.Data;
using InvoiceJe.Droid.Adapters;
using Android.Content;
using InvoiceJe.Droid.Activities;
using InvoiceJe.Droid.Extensions;

namespace InvoiceJe.Droid.Fragments
{
    public class InvoicesFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.invoices_fragment, container, false);

            var repository = new Repository(FileAccessHelper.GetLocalDatabasePath());
            var invoices = repository.GetInvoices();

            RecyclerView recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            LinearLayoutManager layoutManager = new LinearLayoutManager(view.Context);
            recyclerView.SetLayoutManager(layoutManager);
            InvoicesRecyclerViewAdapter adapter = new InvoicesRecyclerViewAdapter(invoices);
            adapter.ItemClick += OnItemClick; // register onItemClick
            recyclerView.SetAdapter(adapter);

            // divider
            // ref: https://stackoverflow.com/questions/24618829/how-to-add-dividers-and-spaces-between-items-in-recyclerview
            recyclerView.AddItemDecoration(new DividerItemDecoration(view.Context, DividerItemDecoration.Vertical));

            return view;
        }

        void OnItemClick(object sender, int invoiceId)
        {
            //Toast.MakeText(this.Context, "This is invoice " + invoiceId.ToString(), ToastLength.Short).Show();

            Intent intent = new Intent(this.Context, typeof(InvoicesEditActivity));
            intent.PutExtra("InvoiceId", invoiceId);
            StartActivity(intent);
        }
    }
}