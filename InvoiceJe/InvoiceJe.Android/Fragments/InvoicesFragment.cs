﻿using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace InvoiceJe.Droid.Fragments
{
    public class InvoicesFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.invoices_fragment, container, false);
            return view;
        }
    }
}