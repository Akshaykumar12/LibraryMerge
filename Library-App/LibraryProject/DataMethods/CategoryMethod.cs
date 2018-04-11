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
    public class CategoryMethod
    {
        public static void InsertUpdate(TBCategory category)
        {
            Realm realm = Realm.GetInstance();
            TBCategory tempCategory = realm.All<TBCategory>().Where(r => r.CategoryId == category.CategoryId).FirstOrDefault();
            using (var transaction = realm.BeginWrite())
            {
                if (tempCategory != null)
                {
                    realm.Remove(tempCategory);
                    transaction.Commit();
                }
                realm.Add(category);
                transaction.Commit();
            }
        }

        public static IQueryable<TBCategory> GetAlls()
        {
            return Realm.GetInstance().All<TBCategory>();
        }

        public static TBCategory GetCategory(string categoryId)
        {
            return Realm.GetInstance().All<TBCategory>().Where(r => r.CategoryId == categoryId).FirstOrDefault();
        }

        public static TBCategory GetCategoryID(string CategoryName)
        {
            return Realm.GetInstance().All<TBCategory>().FirstOrDefault(r => r.CategoryName == CategoryName);
        }
        public static void DeleteAll()
        {
            Realm realm = Realm.GetInstance();
            var categories = realm.All<TBCategory>();
            using (var transaction = realm.BeginWrite()) 
            {
                foreach (var bb in categories)
                {
                    realm.Remove(bb);
                }
                transaction.Commit();
            }
            realm.Dispose();
        }
    }
}