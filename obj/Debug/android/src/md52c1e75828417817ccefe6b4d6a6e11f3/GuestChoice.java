package md52c1e75828417817ccefe6b4d6a6e11f3;


public class GuestChoice
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
		mono.android.Runtime.register ("UnAbandoned.GuestChoice, UnAbandoned, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GuestChoice.class, __md_methods);
	}


	public GuestChoice () throws java.lang.Throwable
	{
		super ();
		if (getClass () == GuestChoice.class)
			mono.android.TypeManager.Activate ("UnAbandoned.GuestChoice, UnAbandoned, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
