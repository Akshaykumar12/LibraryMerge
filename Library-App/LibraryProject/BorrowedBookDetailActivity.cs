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
using System.Globalization;

namespace LibraryProject
{
    [Activity(Label = "BorrowedBookDetailActivity")]
    public class BorrowedBookDetailActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BorrowedBookDetail);

            string bookName = Intent.GetStringExtra("BookName");

            TextView _txtBorrowedBookNo = FindViewById<TextView>(Resource.Id.txtBorrowedBookNo);
            TextView _txtBorrowedName = FindViewById<TextView>(Resource.Id.txtBorrowedName);
            TextView _txtBorrowedAuthor = FindViewById<TextView>(Resource.Id.txtBorrowedAuthor);
            TextView _txtBorrowedType = FindViewById<TextView>(Resource.Id.txtBorrowedCategory);
            TextView _txtBorrowedReturnDate = FindViewById<TextView>(Resource.Id.txtBorrowedReturnDate);

            TBBook book = BookMethod.GetBookByName(bookName);
            if(book != null)
            {
                _txtBorrowedBookNo.Text = book.ISBN;
                _txtBorrowedName.Text = book.BookName;

                TBAuthor author = AuthorMethod.GetAuthor(book.AuthorId);
                if(author != null)
                {
                    _txtBorrowedAuthor.Text = author.FirstName + " " + author.LastName;
                }

                TBCategory category = CategoryMethod.GetCategory(book.CategoryId);
                if (author != null)
                {
                    _txtBorrowedType.Text = category.CategoryName;
                }

                TBBorrowing borrowing = BorrowingMethod.GetBorrowingBookByUserIDAndBookID("70e7424a-399a-4b6f-9ff4-9459b6b182cb", book.BookId);
                if(borrowing != null)
                {
                    _txtBorrowedReturnDate.Text = borrowing.ReturnDate.ToString("MM-dd-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                }
            }
        }
    }
}