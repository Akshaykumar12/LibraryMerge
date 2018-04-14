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
using LibraryProject.DataMethods;
using LibraryProject.Models;

namespace LibraryProject
{
    public class BorrowedBookFragment : Fragment
    {
        private List<String> borrowdbooks;
        private ListView lv1;
        private ArrayAdapter myAdapter;
        private Activity Source;
      

        public BorrowedBookFragment(Activity source)
        {  
            this.Source = source;
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
            var view = inflater.Inflate(Resource.Layout.borrowedbooks, container, false);

            lv1 = view.FindViewById<ListView>(Resource.Id.listViewBorrowedBook);

            GlobalVariable temp = GlobalVariable.GetInstance();
            var user = UserMethod.GetUserByName(temp.UserName);
            IQueryable<TBBorrowing> borrowings = BorrowingMethod.GetBorrowingBookByUser(user.UserId);
            IQueryable<TBBook> books = BookMethod.GetAlls();
            borrowdbooks = new List<string>();
            foreach (var borrowing in borrowings)
            {
                foreach (var book in books)
                {
                    if (borrowing.BookId == book.BookId)
                    {
                        borrowdbooks.Add(book.BookName);
                        break;
                    }
                }
            }

            var borroredBookAdapter = new BorrowedBookListViewAdapter(Source, borrowdbooks.ToArray());
            lv1.Adapter = borroredBookAdapter;
            return view;
        }
    }
}