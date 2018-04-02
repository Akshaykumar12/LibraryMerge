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
using LibraryProject.Models;
using LibraryProject.DataMethods;
using LibraryProject.Common;

namespace LibraryProject
{
    [Activity(Label = "BorrowedBookActivity")]
    public class BorrowedBookActivity : Activity
    {

        ListView borrowedBookLV;
        BorrowedBookListViewAdapter borrowedBookAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BorrowedBook);

            /* Temporary data */
            //DataServices.MakeData();

            //IQueryable<TBUser> bu = UserMethod.GetAlls();

            /* Borrowed Book List View */
            borrowedBookLV = FindViewById<ListView>(Resource.Id.listViewBorrowedBook);
            IQueryable<TBBorrowing> borrowings = BorrowingMethod.GetAlls();
            IQueryable<TBBook> books = BookMethod.GetAlls();
            List<string> data_books = new List<string>();
            foreach (var borrowing in borrowings)
            {
                foreach(var book in books)
                {
                    if(borrowing.BookId == book.BookId)
                    {
                        data_books.Add(book.BookName);
                        break;
                    }
                }
            }

            if(data_books.Count > 0)
            {
                borrowedBookAdapter = new BorrowedBookListViewAdapter(this, data_books.ToArray());
                borrowedBookLV.Adapter = borrowedBookAdapter;
            }
        }
    }
}