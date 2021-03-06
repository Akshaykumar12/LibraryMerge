﻿using System;
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
    [Activity(Label = "AdminHomeActivity")]
    public class AdminHomeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            RequestWindowFeature(WindowFeatures.ActionBar);

            //enable navigation mode to support tab layout
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
          

            /* categories */
            List<String> Categories = new List<string>();
            var geTbCategories = CategoryMethod.GetAlls();
            foreach (var category in geTbCategories)
            {
                Categories.Add(category.CategoryName);
            }
          

            //adding search tab
            AddTab("Search Book", new AdminSearchBookFragment(this));

            //adding AddBook tab 
            AddTab("Add Book", new AddBookFragment(this, Categories));

            //adding Logout tab 
            AddTab("Logout", new LogoutFragment(this));
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.home);
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