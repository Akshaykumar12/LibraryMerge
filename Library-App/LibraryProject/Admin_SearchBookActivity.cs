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
using Realms;

namespace TermProject_Library_Tatiana
{
    [Activity(Label = "Admin_SearchBookActivity")]
    public class Admin_SearchBookActivity : Activity
    {
        ListView _listView;
        List<string> books = new List<string>();
        //List<string> books = new List<string>() { "Aaaaaa","Bbbbbb","Cccccc"};
        List<string> searchList = new List<string>();

        SearchView _search;
        ArrayAdapter _adapter;

        Realm realmObj;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Admin_SearchBook);

            _listView = FindViewById<ListView>(Resource.Id.myList);
            _search = FindViewById<SearchView>(Resource.Id.search);

            realmObj = Realm.GetInstance();

            //Getting all the realm object from TBBook 
            var bookModelList = realmObj.All<TBBook>();
            foreach (var b in bookModelList)
            {
                Console.WriteLine("\nBook Info " + b.BookName);
                books.Add(b.BookName);
            }

            _adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, books);
            _listView.SetAdapter(_adapter);

            _listView.ItemClick += listItemClicked;
            _search.QueryTextChange += mySearch;
        }

        public void mySearch(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var search = e.NewText;
            bool contains = false;
            searchList.Clear();

            for (int i = 0; i <= books.Count - 1; i++)
            {
                contains = books[i].ToLower().Contains(search.ToLower());
                if (contains)
                {
                    searchList.Add(books[i]);
                }
            }

            _adapter.Clear();
            _adapter.AddAll(searchList);
            _adapter.NotifyDataSetChanged();
        }

        public void listItemClicked (object sender, AdapterView.ItemClickEventArgs e)
        {
            //If searchlist is empty, Add all books to it
            if (!searchList.Any())
            {
                searchList = books.ToList();
            }
            //Toast.MakeText(this, "Item clicked: " + books[e.Position], ToastLength.Long).Show();

            //Redirect to detail page passing book
            var detailScreen = new Intent(this, typeof(Admin_ShowBookDetailActivity));
            detailScreen.PutExtra("book", searchList[e.Position]);
            StartActivity(detailScreen);
        }
    }
}