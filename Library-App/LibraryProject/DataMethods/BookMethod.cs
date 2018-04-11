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
using Realms;
using LibraryProject.Models;

namespace LibraryProject.DataMethods
{
    public class BookMethod
    {
        public static void InsertUpdate(TBBook book)
        {
            Realm realm = Realm.GetInstance();
            TBBook tempBook = realm.All<TBBook>().Where(r => r.BookId == book.BookId).FirstOrDefault();
            using (var transaction = realm.BeginWrite())
            {
                if (tempBook != null)
                {
                    realm.Remove(tempBook);
                    transaction.Commit();
                }
                realm.Add(book);
                transaction.Commit();
            }
        }

        public static IQueryable<TBBook> GetAlls()
        {
            return Realm.GetInstance().All<TBBook>();
        }

        public static TBBook GetBookByName(string name)
        {
            return Realm.GetInstance().All<TBBook>().Where(r => r.BookName == name).FirstOrDefault();
        }

        public static void DeleteAll()
        {
            Realm realm = Realm.GetInstance();
            var books = realm.All<TBBook>();
            using (var transaction = realm.BeginWrite())
            {
                foreach (var bb in books)
                {
                    realm.Remove(bb);
                }
                transaction.Commit();
            }
            realm.Dispose();
        }

        public static void DeleteBook(TBBook book)
        {
            Realm realm = Realm.GetInstance();
            var books = realm.All<TBBook>();
            using (var transaction = realm.BeginWrite())
            {
                realm.Remove(book);
                transaction.Commit();
            }
            realm.Dispose();

        }
    }
}