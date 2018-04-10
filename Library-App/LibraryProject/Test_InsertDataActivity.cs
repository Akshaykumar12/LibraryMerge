using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Realms;

namespace TermProject_Library_Tatiana
{
    [Activity(Label = "Test_InsertDataActivity")]
    public class Test_InsertDataActivity : Activity
    {
        Realm realmObj;
        Button _addCategories;
        List<string> categories = new List<string>() { "Philosophy"
                                                     , "History"
                                                     , "Music"
                                                     , "Literature"
                                                     , "Medicine"
                                                     , "Technology" };
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Test_InsertData);

            realmObj = Realm.GetInstance();

            _addCategories = FindViewById<Button>(Resource.Id.addCategoryTest);

            _addCategories.Click += delegate
            {
                //Deleting All before adding
                realmObj.Write(() =>
                {
                    realmObj.RemoveAll<TBCategory>();
                });
                Toast.MakeText(ApplicationContext, "Deleted: TBCategory", ToastLength.Long).Show();

                //Adding
                for (int i = 0; i <= categories.Count - 1; i++)
                {
                    var categoryModelObj = new TBCategory();

                    categoryModelObj.CategoryName = categories[i];
                    realmObj.Write(() =>
                    {
                        realmObj.Add(categoryModelObj);
                    });
                    Toast.MakeText(ApplicationContext, "Added: "+ categories[i], ToastLength.Long).Show();
                };
            };   
        }
    }
}