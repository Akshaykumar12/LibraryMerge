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

namespace LibraryProject
{
    [Activity(Label = "RegisterAcitivity")]
    public class RegisterAcitivity : Activity
    {
        public EditText FirstName, LastName, Email, Password,Phone;
        private Button Register;
        private ImageView Logo;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);
            FirstName = FindViewById<EditText>(Resource.Id.etFirstName);
            LastName = FindViewById<EditText>(Resource.Id.etLastName);
            Email = FindViewById<EditText>(Resource.Id.etEmail);
            Password = FindViewById<EditText>(Resource.Id.etPassword);
            Phone = FindViewById<EditText>(Resource.Id.etPhone);
            Logo = FindViewById<ImageView>(Resource.Id.logoImage);
            Register = FindViewById<Button>(Resource.Id.btnRegister);

            Register.Click += delegate
            {
                TBUser user = new TBUser();
                user.UserId = Guid.NewGuid().ToString();
                user.FirstName = FirstName.Text;
                user.LastName = LastName.Text;
                user.UserName = "";
                user.Password = Password.Text;
                user.Email = Email.Text;
                user.Phone = Phone.Text;
                user.Admin = false;

                UserMethod.InsertUpdate(user);
                Intent intent = new Intent(this, typeof(LoginActivity));
                this.StartActivity(intent);

            };
          
        }
    }
}