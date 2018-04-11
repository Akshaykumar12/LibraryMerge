﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LibraryProject.Models;

namespace LibraryProject
{
    class Admin_SearchBookAdapter:BaseAdapter<string>
    {
        private Activity context;
        private TBBook[] books;

        public Admin_SearchBookAdapter(Activity context, TBBook[] books)
        {
            this.context = context;
            this.books = books;
        }


        public override long GetItemId(int position)
        {

            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = books[position];
            View myOwnView = convertView;

            if (myOwnView == null)
            {
                myOwnView = context.LayoutInflater.Inflate(Resource.Layout.BorrowedBookListView, null);


            }

            myOwnView.FindViewById<TextView>(Resource.Id.txtBookTitle).Text = item.BookName;

            Button btn = myOwnView.FindViewById<Button>(Resource.Id.btnBorrowedBook);
            btn.Tag = item.BookName;
            btn.Click += ViewBtnClicked;

            return myOwnView;
        }

        private void ViewBtnClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var adminBookDetailActivity = new Intent(this.context, typeof(AdminBookDetailActivity));
            adminBookDetailActivity.PutExtra("ID", (string)btn.Tag);
            this.context.StartActivity(adminBookDetailActivity);
        }

        public override int Count
        {
            get
            {
                return books.Count();

            }
        }

        public override string this[int position]
        {
            get { return books[position].BookId.ToString(); }
        }
    }
}
