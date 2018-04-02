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

namespace LibraryProject.Models
{
    public class TBUser : RealmObject
    {
        [PrimaryKey]
        public string UserId { get; set; } // = Guid.NewGuid().ToString();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Admin { get; set; }
    }
}