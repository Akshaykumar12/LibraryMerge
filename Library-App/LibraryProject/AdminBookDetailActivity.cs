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
    [Activity(Label = "AdminBookDetailActivity")]
    public class AdminBookDetailActivity : Activity
    {
        TextView BookNo, BookName, Author, BookType, Quantity;
        private TBBook book;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Admin_BookDetail);
            // Create your application here
            string bookName = Intent.GetStringExtra("ID");

            BookNo = FindViewById<TextView>(Resource.Id.txtBookTitle);
            BookName = FindViewById<TextView>(Resource.Id.txtBookName);
            Author = FindViewById<TextView>(Resource.Id.txtAuthor);
            BookType = FindViewById<TextView>(Resource.Id.txtBookType);
            Quantity = FindViewById<TextView>(Resource.Id.txtQuantity);
            Button btnDelete = FindViewById<Button>(Resource.Id.btnDelete);

            book = BookMethod.GetBookByName(bookName);
            if (book != null)
            {
                Author.Text = book.EditionNumber.ToString();
                BookName.Text = book.ISBN;
                //_txtQuantity.Text = book.Quantity.ToString();
                //TBAuthor author = AuthorMethod.GetAuthor(book.AuthorId);
                //if (author != null)
                //{
                //    _txtAuthor.Text = author.FirstName + " " + author.LastName;
                //}

                //TBCategory category = CategoryMethod.GetCategory(book.CategoryId);
                //if (author != null)
                //{
                //    _txtBookType.Text = category.CategoryName;
                //}

                btnDelete.Click += OnBtnDeleteClick;
            }
        }

        private void OnBtnDeleteClick(object sender, EventArgs e)
        {
            BookMethod.DeleteBook(book);
            Intent intent = new Intent(this, typeof(Admin_BookSearchActivity));
            this.StartActivity(intent);

        }
    }
}
