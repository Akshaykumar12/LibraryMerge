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

namespace TermProject_Library_Tatiana
{
    public class TBBook : RealmObject
    {
        [PrimaryKey]
        public string BookId { get; set; } = Guid.NewGuid().ToString();

        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string NumberCopies { get; set; }
    }
}