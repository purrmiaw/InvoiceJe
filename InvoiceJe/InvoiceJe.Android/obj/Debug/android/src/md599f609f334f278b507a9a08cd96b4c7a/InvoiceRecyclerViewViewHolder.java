package md599f609f334f278b507a9a08cd96b4c7a;


public class InvoiceRecyclerViewViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("InvoiceJe.Droid.Adapters.InvoiceRecyclerViewViewHolder, InvoiceJe.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", InvoiceRecyclerViewViewHolder.class, __md_methods);
	}


	public InvoiceRecyclerViewViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == InvoiceRecyclerViewViewHolder.class)
			mono.android.TypeManager.Activate ("InvoiceJe.Droid.Adapters.InvoiceRecyclerViewViewHolder, InvoiceJe.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
