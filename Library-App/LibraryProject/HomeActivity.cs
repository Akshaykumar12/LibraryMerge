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
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : Activity
    {
        List<string> movies = new List<string> { "moon", "mars", "sun" };
        List<string> songs = new List<string> { "twinlke", "Little", "star" };
        List<TBBook> data_books = new List<TBBook>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
           
            RequestWindowFeature(WindowFeatures.ActionBar);

            //enable navigation mode to support tab layout
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            IQueryable<TBBook> books = BookMethod.GetAlls();

            foreach (var book in books)
            {

                data_books.Add(book);

            }
            //adding audio tab
            AddTab("Seach Book", new SearchBookFragment(this, data_books,this));

            //adding video tab 
            AddTab("Borrowed Book", new BorrowedBookFragment(this, songs));
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