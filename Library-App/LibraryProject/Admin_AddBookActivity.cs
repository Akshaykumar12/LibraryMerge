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
    [Activity(Label = "Admin_AddBookActivity")]
    public class Admin_AddBookActivity : Activity
    {
        private Spinner categorySpinner;
        private ArrayAdapter arrayAdapter;
        private List<string> Categories = new List<string>();
        private Button btnaddBook;
        private EditText BookName, Author, Quantity, ISBN;

       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Admin_AddBook);
            categorySpinner = FindViewById<Spinner>(Resource.Id.categorySpinner);
            btnaddBook = FindViewById<Button>(Resource.Id.btnAddBook);
            ISBN = FindViewById<EditText>(Resource.Id.isbn);
            BookName = FindViewById<EditText>(Resource.Id.bookName);
            Author = FindViewById<EditText>(Resource.Id.author);
            Quantity = FindViewById<EditText>(Resource.Id.numberCopies);
            var geTbCategories = CategoryMethod.GetAlls();
            foreach (var category in geTbCategories)
            {
                Categories.Add(category.CategoryName);
            }
            arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, Categories.ToArray());


            arrayAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            categorySpinner.Adapter = arrayAdapter;
            btnaddBook.Click += AddBook;
        }

        private void AddBook(object sender, EventArgs e)
        {
            string category = categorySpinner.SelectedItem.ToString();
            TBCategory categoryObj = CategoryMethod.GetCategoryID(category);
             TBBook book = new TBBook();
            book.BookName = BookName.Text;
            book.ISBN = ISBN.Text;
            book.AuthorId = "1";
            book.CategoryId = categoryObj.CategoryId;
            book.Quantity = Int32.Parse(Quantity.Text);
            BookMethod.InsertUpdate(book);
        }
    }
}