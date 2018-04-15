using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace LibraryProject
{
    public class LogoutFragment : Fragment
    {
        private Button Logout;
        private Activity Source;
        public LogoutFragment(Activity source)
        {
            this.Source = source;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
           
            var view = inflater.Inflate(Resource.Layout.logout, container, false);
            Logout = view.FindViewById<Button>(Resource.Id.btnLogout);
         
            Logout.Click += delegate
            {
                GlobalVariable temp = GlobalVariable.GetInstance();
                temp.UserName = "";
                Intent intent = new Intent(Source, typeof(LoginActivity));
                this.StartActivity(intent);
            };

            return view;
            

        }
    }
}