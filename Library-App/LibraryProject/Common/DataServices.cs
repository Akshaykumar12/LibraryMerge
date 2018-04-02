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

namespace LibraryProject.Common
{
    public static class DataServices
    {
        /* this method should be deleted when we have real data */
        /// <summary>
        /// 
        /// </summary>
        public static void MakeData()
        {
            BorrowingMethod.DeleteAll();
            AuthorMethod.DeleteAll();
            BookMethod.DeleteAll();
            CategoryMethod.DeleteAll();
            UserMethod.DeleteAll();

            TBAuthor author = new TBAuthor();
            author.AuthorId = Guid.NewGuid().ToString();
            author.FirstName = "David";
            author.LastName = "Ng";
            AuthorMethod.InsertUpdate(author);

            TBCategory category = new TBCategory();
            category.CategoryId = Guid.NewGuid().ToString();
            category.CategoryName = "Adventure";
            CategoryMethod.InsertUpdate(category);

            TBCategory category1 = new TBCategory();
            category1.CategoryId = Guid.NewGuid().ToString();
            category1.CategoryName = "Novel";
            CategoryMethod.InsertUpdate(category1);

            TBBook book = new TBBook();
            book.BookId = Guid.NewGuid().ToString();
            book.BookName = "Book1";
            book.ISBN = "45556";
            book.Quantity = 5;
            book.EditionYear = 1987;
            book.EditionNumber = 6;
            book.AuthorId = author.AuthorId;
            book.CategoryId = category.CategoryId;
            BookMethod.InsertUpdate(book);

            TBBook book1 = new TBBook();
            book1.BookId = Guid.NewGuid().ToString();
            book1.BookName = "Book2";
            book1.ISBN = "45557";
            book1.Quantity = 3;
            book1.EditionYear = 1998;
            book1.EditionNumber = 2;
            book1.AuthorId = author.AuthorId;
            book1.CategoryId = category1.CategoryId;
            BookMethod.InsertUpdate(book1);

            TBUser user = new TBUser();
            user.UserId = Guid.NewGuid().ToString();
            user.FirstName = "Anh";
            user.LastName = "Tran";
            user.UserName = "anhtran";
            user.Password = "1234";
            user.Email = "anhtran@gmail.com";
            user.Phone = "64875858595";
            user.Admin = true;
            UserMethod.InsertUpdate(user);

            TBBorrowing borrowing1 = new TBBorrowing();
            borrowing1.BorrowingId = Guid.NewGuid().ToString();
            borrowing1.BorrowDate = new DateTimeOffset(DateTime.Today);
            borrowing1.ReturnDate = new DateTimeOffset(DateTime.Today.AddDays(5));
            borrowing1.BookId = book.BookId;
            borrowing1.UserId = user.UserId;
            BorrowingMethod.InsertUpdate(borrowing1);

            TBBorrowing borrowing2 = new TBBorrowing();
            borrowing2.BorrowingId = Guid.NewGuid().ToString();
            borrowing2.BorrowDate = new DateTimeOffset(DateTime.Today);
            borrowing2.ReturnDate = new DateTimeOffset(DateTime.Today.AddDays(5));
            borrowing2.BookId = book1.BookId;
            borrowing2.UserId = user.UserId;
            BorrowingMethod.InsertUpdate(borrowing2);          

            IQueryable<TBBorrowing> bb = BorrowingMethod.GetAlls();
            IQueryable<TBBook> bk = BookMethod.GetAlls();
            IQueryable<TBAuthor> ba = AuthorMethod.GetAlls();
            IQueryable<TBCategory> bc = CategoryMethod.GetAlls();
            IQueryable<TBUser> bu = UserMethod.GetAlls();

        }
    }
}