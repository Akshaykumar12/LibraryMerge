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

namespace LibraryProject
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        private EditText StudetID, Password;
        private Button Login;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.login);
            StudetID = FindViewById<EditText>(Resource.Id.etLoginStudentID);
            Password = FindViewById<EditText>(Resource.Id.etLoginPassword);
            Login = FindViewById<Button>(Resource.Id.btnLogin);


            Login.Click += delegate
            {
                string id = StudetID.Text;
                string pwd = Password.Text;
                TBUser user = DataMethods.UserMethod.GetUser(id, pwd);

                if (user !=null)
                {
                    GlobalVariable temp = GlobalVariable.GetInstance();
                    temp.UserName = user.FirstName;
                    Intent intent = new Intent(this, typeof(HomeActivity));
                    this.StartActivity(intent);
                }
            };


        }

       
    }
}