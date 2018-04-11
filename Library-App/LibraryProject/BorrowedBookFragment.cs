using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace LibraryProject
{
    public class BorrowedBookFragment : Fragment
    {
        private List<String> borrowdbooks;
        private ListView lv1;
        private ArrayAdapter myAdapter;
        private Activity main1;
      

        public BorrowedBookFragment(Activity main, List<String> borrowdbooks)
        {
            this.borrowdbooks = borrowdbooks;
            this.main1 = main;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.BorrowedBook, container, false);

            lv1 = view.FindViewById<ListView>(Resource.Id.listViewBorrowedBook);

            var borroredBookAdapter = new BorrowedBookListViewAdapter(main1, borrowdbooks.ToArray());
            lv1.Adapter = borroredBookAdapter;
            return view;
        }
    }
}