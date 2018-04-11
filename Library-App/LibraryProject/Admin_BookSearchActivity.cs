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
    [Activity(Label = "Admin_BookSearchActivity")]
    public class Admin_BookSearchActivity : Activity
    {
        private ListView BookListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BorrowedBook);
            // Create your application here
            BookListView = FindViewById<ListView>(Resource.Id.listViewBorrowedBook);
            IQueryable<TBBook> books = BookMethod.GetAlls();
            var data_books = new List<TBBook>();
            foreach (var book in books)
            {

                data_books.Add(book);

            }


            var searchBookAdapter = new Admin_SearchBookAdapter(this, data_books.ToArray());
            BookListView.Adapter = searchBookAdapter;

        }
    }
}