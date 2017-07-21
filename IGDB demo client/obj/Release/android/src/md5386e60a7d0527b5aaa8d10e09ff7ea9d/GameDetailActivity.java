package md5386e60a7d0527b5aaa8d10e09ff7ea9d;


public class GameDetailActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("IGDB_demo_client.GameDetailActivity, IGDB demo client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GameDetailActivity.class, __md_methods);
	}


	public GameDetailActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == GameDetailActivity.class)
			mono.android.TypeManager.Activate ("IGDB_demo_client.GameDetailActivity, IGDB demo client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
