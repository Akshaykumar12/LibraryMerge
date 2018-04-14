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

namespace LibraryProject
{
    public class BorrowedBookListViewAdapter : BaseAdapter<String>
    {
        String[] datas;
        Activity context;

        public BorrowedBookListViewAdapter(Activity _context, String[] _items) : base()
        {
            this.context = _context;
            this.datas = _items;
        }

        public override String this[int position]
        {
            get
            {
                return datas[position];
            }
        }

        public override int Count
        {
            get
            {
                return datas.Count();
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = datas[position];

            View myOwnView = convertView;

            if (myOwnView == null)
            {
                myOwnView = context.LayoutInflater.Inflate(Resource.Layout.BorrowedBookListView, null);
            }

            myOwnView.FindViewById<TextView>(Resource.Id.txtBookTitle).Text = item;

            Button btn = myOwnView.FindViewById<Button>(Resource.Id.btnBorrowedBook);
            btn.Tag = item;
            btn.Click += Btn_Click;

            return myOwnView;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var borrowedBookDetailActivity = new Intent(this.context, typeof(BorrowedBookDetailActivity));
            borrowedBookDetailActivity.PutExtra("BookName", (string)btn.Tag);
            this.context.StartActivity(borrowedBookDetailActivity);
        }

        internal void Clear()
        {
            this.datas = new string[] { };
        }

        public void AddAll(List<string> dataBooks)
        {
            this.datas = dataBooks.ToArray();
        }
    }
}