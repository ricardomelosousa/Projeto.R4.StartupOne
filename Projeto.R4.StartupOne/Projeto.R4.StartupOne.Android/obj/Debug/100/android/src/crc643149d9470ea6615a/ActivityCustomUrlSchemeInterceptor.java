package crc643149d9470ea6615a;


public class ActivityCustomUrlSchemeInterceptor
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
		mono.android.Runtime.register ("Projeto.R4.StartupOne.Droid.ActivityCustomUrlSchemeInterceptor, Projeto.R4.StartupOne.Android", ActivityCustomUrlSchemeInterceptor.class, __md_methods);
	}


	public ActivityCustomUrlSchemeInterceptor ()
	{
		super ();
		if (getClass () == ActivityCustomUrlSchemeInterceptor.class)
			mono.android.TypeManager.Activate ("Projeto.R4.StartupOne.Droid.ActivityCustomUrlSchemeInterceptor, Projeto.R4.StartupOne.Android", "", this, new java.lang.Object[] {  });
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
