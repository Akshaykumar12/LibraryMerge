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
    [Activity(Label = "Admin_ShowBookDetailActivity")]
    public class Admin_ShowBookDetailActivity : Activity
    {
        TextView _bookName;
        TextView _author;
        TextView _category;
        TextView _numberCopies;
        TextView _isbn;

        Realm realmObj;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Admin_ShowBookDetail);

            //Retrieving session variable
            string book = Intent.GetStringExtra("book") ?? "Data not available";

            _bookName = FindViewById<TextView>(Resource.Id.bookName);
            _author = FindViewById<TextView>(Resource.Id.author);
            _category = FindViewById<TextView>(Resource.Id.category);
            _numberCopies = FindViewById<TextView>(Resource.Id.numberCopies);
            _isbn = FindViewById<TextView>(Resource.Id.isbn);

            realmObj = Realm.GetInstance();

            //Retrieving info from books Model
            var bookModelList = realmObj.All<TBBook>();
            var bookExist = bookModelList.Where(b => b.BookName == book);
            var myBook = bookExist.ToList();

            foreach(var b in myBook)
            {
                _bookName.Text = b.BookName;
                _author.Text = b.Author;
                _category.Text = b.Category;
                _numberCopies.Text = b.NumberCopies;
                _isbn.Text = b.ISBN;
            }
        }
    }
}