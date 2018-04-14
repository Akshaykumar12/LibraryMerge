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
        private ImageView Logo;
        private TextView Register;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.login);
            StudetID = FindViewById<EditText>(Resource.Id.etLoginStudentID);
            Password = FindViewById<EditText>(Resource.Id.etLoginPassword);
            Login = FindViewById<Button>(Resource.Id.btnLogin);
            Logo = FindViewById<ImageView>(Resource.Id.logoImage);
            Register = FindViewById<TextView>(Resource.Id.txtRegister);
            Login.Click += delegate
            {
                string id = StudetID.Text;
                string pwd = Password.Text;
                TBUser user = DataMethods.UserMethod.GetUser(id, pwd);
                
                if (user !=null)
                {
                    if (user.Admin == true)
                    {
                        Intent intent = new Intent(this, typeof(AdminHomeActivity));
                        this.StartActivity(intent);

                    }
                    else
                    {
                        GlobalVariable temp = GlobalVariable.GetInstance();
                        temp.UserName = user.FirstName;
                        Intent intent = new Intent(this, typeof(HomeActivity));
                        this.StartActivity(intent);
                    }
                }
                else
                {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Authentication Failed");
                    alert.SetMessage("Invalid Email or Password !! Please, Try Again.");
                    alert.SetButton("OK", (c, ev) =>
                    {

                    });

                    alert.Show();
                }

            };

            Register.Click += delegate
            {
                Intent intent = new Intent(this, typeof(RegisterAcitivity));
                this.StartActivity(intent);
            };


        }

       
    }
}