using Android.App;
using Android.OS;
using Android.Support.V7.App;
using InvoiceJe.Data;
using InvoiceJe.Droid.Extensions;
using Android.Support.V7.Widget;
using InvoiceJe.Droid.Adapters;
using System.Threading.Tasks;
using System.Collections.Generic;
using InvoiceJe.Models;

namespace InvoiceJe.Droid.Activities
{
    [Activity(Theme = "@style/MasterTheme")]
    public class InvoicesOnlineActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            // set layout
            SetContentView(Resource.Layout.activity_invoicesonline);

            // set toolbar

            // others
            var repository = new Repository(FileAccessHelper.GetLocalDatabasePath());
            IEnumerable<Invoice> invoices = new List<Invoice>();

            var t = Task.Run( async () => {
                invoices = await repository.GetInvoicesFromWebserviceAsync();
            });
            t.Wait();

            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerview_invoicesonline);
            LinearLayoutManager layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            InvoicesRecyclerViewAdapter adapter = new InvoicesRecyclerViewAdapter(invoices);
            //adapter.ItemClick += OnItemClick; // register onItemClick
            recyclerView.SetAdapter(adapter);

            // divider
            // ref: https://stackoverflow.com/questions/24618829/how-to-add-dividers-and-spaces-between-items-in-recyclerview
            recyclerView.AddItemDecoration(new DividerItemDecoration(this, DividerItemDecoration.Vertical));

        }
    }
}