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
using LibraryProject.Models;

namespace LibraryProject
{
    public class SearchBookFragment : Fragment
    {
        private List<String> movies;
        private ListView lv1;
        private ArrayAdapter myAdapter;
        private Context main1;
        private Activity main2;
        private List<TBBook> data_books;
        public SearchBookFragment(Context main, List<TBBook> books,Activity home)
        {
            this.main1 = main;
            this.data_books = books;
            this.main2 = home;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

           // return base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.BorrowedBook, container, false);
            view.FindViewById<TextView>(Resource.Id.textView2).Text = "Search Books";

            lv1 = view.FindViewById<ListView>(Resource.Id.listViewBorrowedBook);
            // myAdapter = new ArrayAdapter(main1, Android.Resource.Layout.SimpleListItem1, data_books.Select(b=>b.BookName).ToArray());
            //lv1.Adapter = myAdapter;
            var searchBookAdapter = new SearchBookAdapter(main2, data_books.ToArray());
            lv1.Adapter = searchBookAdapter;
            return view;

        }
    }
}