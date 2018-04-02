using System;
using System.Collections.Generic;
using System.Globalization;
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
    [Activity(Label = "BookDetailActivity")]
    public class BookDetailActivity : Activity
    {
        
        TextView BookNo, BookName, Author, BookType, Quantity;
        private TBBook book;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BookDetailayout);
            // Create your application here
            string bookName = Intent.GetStringExtra("ID");

            BookNo = FindViewById<TextView>(Resource.Id.txtBookTitle);
            BookName = FindViewById<TextView>(Resource.Id.txtBookName);
            Author = FindViewById<TextView>(Resource.Id.txtAuthor);
            BookType = FindViewById<TextView>(Resource.Id.txtBookType);
            Quantity = FindViewById<TextView>(Resource.Id.txtQuantity);
            Button btnBorrow = FindViewById<Button>(Resource.Id.btnBorrow);

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

                btnBorrow.Click += OnBtnBorrowClick;
            }
        }

        private void OnBtnBorrowClick(object sender, EventArgs e)
        {
            TBBorrowing borrowBook = new TBBorrowing();
            borrowBook.BookId = book.BookId;
            borrowBook.UserId = "1";
            borrowBook.BorrowDate = DateTime.Today;
            borrowBook.ReturnDate = DateTime.Today.AddDays(3);
            BorrowingMethod.InsertUpdate(borrowBook);
        }
    }
}