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
using LibraryProject.DataMethods;
using LibraryProject.Models;

namespace LibraryProject
{
    public class SearchBookFragment : Fragment
    {
        private ListView lv1;
        private ArrayAdapter myAdapter;
        private Activity source;
        private List<TBBook> data_books;
        private SearchView searchView;
        private SearchBookAdapter searchBookAdapter;
        public SearchBookFragment(Activity home)
        {
            this.source = home;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            GlobalVariable temp = GlobalVariable.GetInstance();
            var view = inflater.Inflate(Resource.Layout.BorrowedBook, container, false);
            view.FindViewById<TextView>(Resource.Id.textView2).Text = "Welcome "+temp.UserName+" !!";


            lv1 = view.FindViewById<ListView>(Resource.Id.listViewBorrowedBook);

            IQueryable<TBBook> books1 = BookMethod.GetAlls();
            data_books = new List<TBBook>();
            foreach (var book in books1)
            {
                data_books.Add(book);
            }
            searchView = view.FindViewById<SearchView>(Resource.Id.searchBorrowedBook);
            searchView.QueryTextChange += SearchView_QueryTextChange;

            searchBookAdapter = new SearchBookAdapter(source, data_books.ToArray());
            lv1.Adapter = searchBookAdapter;
            return view;

        }

        private void SearchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            List<TBBook> filter_data_books = data_books.FindAll(book => book.BookName.ToLower().Contains(e.NewText.ToLower()));
            searchBookAdapter.Clear();
            searchBookAdapter.AddAll(filter_data_books);
            searchBookAdapter.NotifyDataSetChanged();
        }
    }
}