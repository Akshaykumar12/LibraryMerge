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
    public class TBBorrowing : RealmObject
    {
        [PrimaryKey]
        public string BorrowingId { get; set; } // = Guid.NewGuid().ToString();

        public string BookId { get; set; }
        public string UserId { get; set; } 

        public DateTimeOffset BorrowDate { get; set; }
        public DateTimeOffset ReturnDate { get; set; }
    }
}