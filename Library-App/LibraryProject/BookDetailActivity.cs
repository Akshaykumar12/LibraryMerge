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
        
        TextView ISBN, BookName, Author,Category,Quantity;
        private TBBook book;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BookDetail);
            // Create your application here
            string bookName = Intent.GetStringExtra("ID");

            ISBN = FindViewById<TextView>(Resource.Id.txtISBN);
            BookName = FindViewById<TextView>(Resource.Id.txtBookName);
            Author = FindViewById<TextView>(Resource.Id.txtAuthor);
            Category = FindViewById<TextView>(Resource.Id.txtCategory);
            Quantity = FindViewById<TextView>(Resource.Id.txtQuantity);
            Button btnBorrow = FindViewById<Button>(Resource.Id.btnBorrow);

            book = BookMethod.GetBookByName(bookName);
            if (book != null)
            {
                ISBN.Text = book.ISBN.ToString();
                BookName.Text = book.BookName.ToString();
                Quantity.Text = book.Quantity.ToString();
                TBAuthor author = AuthorMethod.GetAuthor(book.AuthorId);
                if (author != null)
                {
                    Author.Text = author.FirstName + " " + author.LastName;
                }

                TBCategory category = CategoryMethod.GetCategory(book.CategoryId);
                if (category != null)
                {
                    Category.Text = category.CategoryName;
                }

                btnBorrow.Click += OnBtnBorrowClick;
            }
        }

        private void OnBtnBorrowClick(object sender, EventArgs e)
        {
            GlobalVariable temp = GlobalVariable.GetInstance();
            var user = UserMethod.GetUserByName(temp.UserName);
            IQueryable<TBBorrowing> borrowBookByUser = BorrowingMethod.GetBorrowingBookByUser(user.UserId);
            int borrowedcount = borrowBookByUser.Count();

            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alert = dialog.Create();
            if (borrowedcount<5)
            {

                if (book.Quantity > 0)
                {

                    
                    TBBorrowing borrowBook = new TBBorrowing();
                    borrowBook.BorrowingId = Guid.NewGuid().ToString();
                    borrowBook.BorrowDate = new DateTimeOffset(DateTime.Today);
                    borrowBook.ReturnDate = new DateTimeOffset(DateTime.Today.AddDays(5));
                    borrowBook.BookId = book.BookId;
                    borrowBook.UserId = user.UserId;

                    BookMethod.Substract(book, 1);
                    BorrowingMethod.InsertUpdate(borrowBook);
                    alert.SetTitle("You have Borrowed book"+book.BookName);
                    alert.SetMessage("You need to return book in 5 days");
                    alert.SetButton("OK", (c, ev) =>
                    {

                    });

                    alert.Show();
                    Intent intent = new Intent(this, typeof(HomeActivity));
                    this.StartActivity(intent);


                }
                else
                {
                    //book not Available
                  
                    alert.SetTitle("Book Not Available");
                    alert.SetMessage("Sorry!! Copy of this book is not available at this moment. Come Later");
                    alert.SetButton("OK", (c, ev) =>
                    {

                    });

                    alert.Show();
                }
            }
            else
            {
                //Over Limit
                alert.SetTitle("Over Limit");
                alert.SetMessage("You can only borrow maximum 5 book at a time. Thank you.");
                alert.SetButton("OK", (c, ev) =>
                {

                });

                alert.Show();
            }
        }
    }
}