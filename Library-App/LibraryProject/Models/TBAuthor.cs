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
    public class TBAuthor : RealmObject
    {
        [PrimaryKey]
        public string AuthorId { get; set; } //= Guid.NewGuid().ToString();

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}