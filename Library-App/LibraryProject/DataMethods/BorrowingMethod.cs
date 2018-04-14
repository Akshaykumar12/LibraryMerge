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
using Realms;

namespace LibraryProject.DataMethods
{
    public static class BorrowingMethod
    {
        public static void InsertUpdate(TBBorrowing borrowing)
        {
            Realm realm = Realm.GetInstance();
            TBBorrowing tempBook = realm.All<TBBorrowing>().Where(r => r.BorrowingId == borrowing.BorrowingId).FirstOrDefault();
            using (var transaction = realm.BeginWrite())
            {
                if (tempBook != null)
                {
                    realm.Remove(tempBook);
                    transaction.Commit();
                }
                realm.Add(borrowing);
                transaction.Commit();
                System.Diagnostics.Debug.WriteLine("Book Borrowed");
            }
        }

        public static IQueryable<TBBorrowing> GetAlls()
        {
            return Realm.GetInstance().All<TBBorrowing>();
        }

      
        public static TBBorrowing GetBorrowingBook(string borrowingId)
        {
            return Realm.GetInstance().All<TBBorrowing>().Where(r => r.BorrowingId == borrowingId).FirstOrDefault();
        }

        public static TBBorrowing GetBorrowingBookByUserIDAndBookID(string userId, string bookId)
        {
            return Realm.GetInstance().All<TBBorrowing>().Where(r => r.UserId == userId && r.BookId == bookId).FirstOrDefault();
        }

        public static IQueryable<TBBorrowing> GetBorrowingBookByUser(string userId)
        {
            return Realm.GetInstance().All<TBBorrowing>().Where(r => r.UserId == userId);
        }
        public static void Delete(TBBorrowing borrowing)
        {
            Realm realm = Realm.GetInstance();
            TBBorrowing borrowingBook = realm.All<TBBorrowing>().Where(r => r.BorrowingId == borrowing.BorrowingId).FirstOrDefault();
            using (var transaction = realm.BeginWrite())
            {
                if (borrowing != null)
                {
                    realm.Remove(borrowing);
                    transaction.Commit();
                }
            }
        }

        public static void DeleteAll()
        {
            Realm realm = Realm.GetInstance();
            var borrowingBooks = realm.All<TBBorrowing>();
            using (var transaction = realm.BeginWrite())
            {
                foreach (var bb in borrowingBooks)
                {
                    realm.Remove(bb);
                }
                transaction.Commit();
            }
            realm.Dispose();
        }
    }
}