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
        public EditText StudentID, Name, Email, Password, ConfirmPassword, Phone;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);
            StudentID = FindViewById<EditText>(Resource.Id.etStudentID);
            Name = FindViewById<EditText>(Resource.Id.etName);
            Email = FindViewById<EditText>(Resource.Id.etEmail);
            Password = FindViewById<EditText>(Resource.Id.etPassword);
            ConfirmPassword = FindViewById<EditText>(Resource.Id.etconfirm_pwd);
            Phone = FindViewById<EditText>(Resource.Id.etPhone);

            TBUser student = new TBUser();
            student.UserId = StudentID.Text;
            student.FirstName = Name.Text;
            student.LastName = Name.Text;
            student.Password = "axay";
            student.Email = Email.Text;
            student.Phone = Phone.Text;
            student.Admin = false;

            DataMethods.UserMethod.InsertUpdate(student);

        }
    }
}