using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace LibraryProject
{
    [Activity(Label = "LibraryProject", MainLauncher = true)]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Common.DataServices.MakeData();

             StartActivity(typeof(LoginActivity));

        }
    }
}

