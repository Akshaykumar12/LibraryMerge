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
    public class TBCategory : RealmObject
    {
        [PrimaryKey]
        public string CategoryId { get; set; } // = Guid.NewGuid().ToString();

        public string CategoryName { get; set; }
    }
}