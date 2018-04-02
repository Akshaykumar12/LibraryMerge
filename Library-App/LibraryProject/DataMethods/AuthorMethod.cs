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
    public static class AuthorMethod
    {
        public static void InsertUpdate(TBAuthor author)
        {
            Realm realm = Realm.GetInstance();
            TBAuthor tempAuthor = realm.All<TBAuthor>().Where(r => r.AuthorId == author.AuthorId).FirstOrDefault();
            using (var transaction = realm.BeginWrite())
            {
                if (tempAuthor != null)
                {
                    realm.Remove(tempAuthor);
                    transaction.Commit();
                }
                realm.Add(author);
                transaction.Commit();
            }
        }

        public static IQueryable<TBAuthor> GetAlls()
        {
            return Realm.GetInstance().All<TBAuthor>();
        }

        public static TBAuthor GetAuthor(string authorId)
        {
            return Realm.GetInstance().All<TBAuthor>().Where(r => r.AuthorId == authorId).FirstOrDefault();
        }

        public static void DeleteAll()
        {
            Realm realm = Realm.GetInstance();
            var authors = realm.All<TBAuthor>();
            using (var transaction = realm.BeginWrite())
            {
                foreach (var bb in authors)
                {
                    realm.Remove(bb);
                }
                transaction.Commit();
            }
            realm.Dispose();
        }
    }
}