using Android.App;
using Android.Widget;
using Android.OS;
using Realms;
using Android.Content;
using Java.Util.Concurrent.Atomic;
using System.Linq;
using System.Collections.Generic;
using System;

namespace TermProject_Library_Tatiana
{
    [Activity(Label = "TermProject_Library_Tatiana", MainLauncher = true)]
    public class Admin_AddBookActivity : Activity
    {
        TextView linktest;
        TextView _linkSearch;

        EditText _isbn;
        EditText _bookName;
        EditText _author;
        Spinner _category;
        EditText _numberCopies;
        Button _btnAddBook;

        List<string> categoriesList = new List<string>();
        string selectedCategory;

        Realm realmObj;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Admin_AddBook);
            
            _isbn = FindViewById<EditText>(Resource.Id.isbn);
            _bookName = FindViewById<EditText>(Resource.Id.bookName);
            _author = FindViewById<EditText>(Resource.Id.author);
            _category = FindViewById<Spinner>(Resource.Id.category);
            _numberCopies = FindViewById<EditText>(Resource.Id.numberCopies);
            _linkSearch = FindViewById<TextView>(Resource.Id.linkSearch);
            _btnAddBook = FindViewById<Button>(Resource.Id.btnAddBook);

            realmObj = Realm.GetInstance();

            //Getting all the realm object from TBCategories:
            var categoriesModelList = realmObj.All<TBCategory>();
            foreach (var b in categoriesModelList)
            {
                categoriesList.Add(b.CategoryName);
            }
            
            //This is a default Spinner for categories
            var categoriesAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, categoriesList);
            categoriesAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            _category.Adapter = categoriesAdapter;
            
            //Calling spinner
            _category.ItemSelected += categorySelected;

            //Add button click event
            _btnAddBook.Click += delegate
            {
                var bookModelObj = new TBBook();

                bookModelObj.ISBN = _isbn.Text;
                bookModelObj.BookName = _bookName.Text;
                bookModelObj.Author = _author.Text;
                bookModelObj.Category = selectedCategory;
                bookModelObj.NumberCopies = _numberCopies.Text;

                realmObj.Write(() =>
                {
                    realmObj.Add(bookModelObj);
                });

                Toast.MakeText(ApplicationContext, "Book added successfully", ToastLength.Long).Show();

                _isbn.Text = "";
                _bookName.Text = "";
                _author.Text = "";
                _numberCopies.Text = "";
            };

            //Link Search
            _linkSearch.Click += delegate
            {
                var linkSearchScreen = new Intent(this, typeof(Admin_SearchBookActivity));
                StartActivity(linkSearchScreen);
            };

            //LINK TEST
            linktest = FindViewById<TextView>(Resource.Id.linktest);
            linktest.Click += delegate
            {
                var testScreen = new Intent(this, typeof(Test_InsertDataActivity));
                StartActivity(testScreen);
            };
        }

        //Retrieving item clicked on Spinner
        private void categorySelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            selectedCategory = spinner.GetItemAtPosition(e.Position).ToString();
        }
    }
}

