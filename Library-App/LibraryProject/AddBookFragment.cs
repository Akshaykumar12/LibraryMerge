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
    public class AddBookFragment : Fragment
    {
        private Spinner categorySpinner;
        private ArrayAdapter arrayAdapter;
        private List<string> Categories = new List<string>();
        private Button btnaddBook;
        private EditText BookName, Author, Quantity, ISBN;
        private Context source;

        public AddBookFragment(Context source, List<string> categories)
        {
            this.source = source;
            this.Categories = categories;
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

            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.Admin_AddBook, container, false);

            categorySpinner = view.FindViewById<Spinner>(Resource.Id.categorySpinner);
            btnaddBook = view.FindViewById<Button>(Resource.Id.btnAddBook);
            ISBN = view.FindViewById<EditText>(Resource.Id.isbn);
            BookName = view.FindViewById<EditText>(Resource.Id.bookName);
            Author = view.FindViewById<EditText>(Resource.Id.author);
            Quantity = view.FindViewById<EditText>(Resource.Id.numberCopies);

            arrayAdapter = new ArrayAdapter(source, Android.Resource.Layout.SimpleListItem1, Categories.ToArray());


            arrayAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            categorySpinner.Adapter = arrayAdapter;
            btnaddBook.Click += AddBook;
            
            return view;
        }
        //Its not working
        private void AddBook(object sender, EventArgs e)
        {
            /* insert into the author table */
            TBAuthor author = new TBAuthor();
            author.AuthorId = Guid.NewGuid().ToString();
            author.FirstName = Author.Text;
            author.LastName = "";
            AuthorMethod.InsertUpdate(author);

            string category = categorySpinner.SelectedItem.ToString();
            TBCategory categoryObj = CategoryMethod.GetCategoryID(category);
            TBBook book = new TBBook();
            book.BookName = BookName.Text;
            book.ISBN = ISBN.Text;
            book.AuthorId = author.AuthorId;
            book.CategoryId = categoryObj.CategoryId;
            book.Quantity = Int32.Parse(Quantity.Text);
            BookMethod.InsertUpdate(book);

            ISBN.Text = "";
            BookName.Text = "";
            Author.Text = "";
            Quantity.Text = "";


        }
    }
}