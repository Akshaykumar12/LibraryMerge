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
    class GlobalVariable : Application
    {
        private static GlobalVariable instance;

        GlobalVariable(){ }
        private string username = "";

        public string UserName { get; set; }

        public static GlobalVariable GetInstance()
        {
            if (instance == null)
            {
                instance = new GlobalVariable();
            }

            return instance;
        }
    }
}