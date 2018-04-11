package md5efe10b4c95b20ad12781e35cad0c4ad4;


public class Admin_AddBookActivity
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
		mono.android.Runtime.register ("LibraryProject.Admin_AddBookActivity, LibraryProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Admin_AddBookActivity.class, __md_methods);
	}


	public Admin_AddBookActivity ()
	{
		super ();
		if (getClass () == Admin_AddBookActivity.class)
			mono.android.TypeManager.Activate ("LibraryProject.Admin_AddBookActivity, LibraryProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
