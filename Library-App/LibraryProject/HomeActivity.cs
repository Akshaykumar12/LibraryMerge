using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LibraryProject.DataMethods;
using LibraryProject.Models;

namespace LibraryProject
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
           
            RequestWindowFeature(WindowFeatures.ActionBar);

            //enable navigation mode to support tab layout
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
          
            //adding audio tab
            AddTab("Search Book", new SearchBookFragment(this));

            //adding video tab 
            AddTab("Borrowed Book", new BorrowedBookFragment(this));
            AddTab("Logout", new LogoutFragment(this));
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.home);


            var editToolbar = FindViewById<Toolbar>(Resource.Id.toolbar1);
            editToolbar.Title = "Toolbar";
            editToolbar.InflateMenu(Resource.Menu.edit_menus);
            editToolbar.MenuItemClick += (sender, e) => {
                Toast.MakeText(this, "Logout button clicking: " + e.Item.TitleFormatted, ToastLength.Short).Show();
            };
        }

        void AddTab(string tabText, Fragment fragment)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
           
           

            // must set event handler for replacing tabs tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e) {

                e.FragmentTransaction.Replace(Resource.Id.fragmentContainer, fragment);
            };

            this.ActionBar.AddTab(tab);
        }

    }
}