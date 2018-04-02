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
    public class UserMethod
    {
        public static void InsertUpdate(TBUser user)
        {
            Realm realm = Realm.GetInstance();
            TBUser tempUser = realm.All<TBUser>().Where(r => r.UserId == user.UserId).FirstOrDefault();
            using (var transaction = realm.BeginWrite())
            {
                if (tempUser != null)
                {
                    realm.Remove(tempUser);
                    transaction.Commit();
                }
                realm.Add(user);
                transaction.Commit();
            }
        }

        public static IQueryable<TBUser> GetAlls()
        {
            return Realm.GetInstance().All<TBUser>();
        }

        public static void DeleteAll()
        {
            Realm realm = Realm.GetInstance();
            var users = realm.All<TBUser>();
            using (var transaction = realm.BeginWrite())
            {
                foreach (var bb in users)
                {
                    realm.Remove(bb);
                }
                transaction.Commit();
            }
            realm.Dispose();
        }
    }
}