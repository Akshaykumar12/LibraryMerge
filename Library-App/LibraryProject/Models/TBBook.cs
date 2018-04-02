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
    public class TBBook : RealmObject
    {
        [PrimaryKey]
        public string BookId { get; set; } // = Guid.NewGuid().ToString();

        public string ISBN { get; set; }
        public string BookName { get; set; }
        public long Quantity { get; set; }
        public long EditionYear { get; set; }
        public long EditionNumber { get; set; }
        public string Publisher { get; set; }

        public string AuthorId { get; set; }
        public string CategoryId { get; set; }
    }
}