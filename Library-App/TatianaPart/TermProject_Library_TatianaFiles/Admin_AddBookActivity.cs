using Android.App;
using Android.Widget;
using Android.OS;
using Realms;
using Android.Content;
using Java.Util.Concurrent.Atomic;
using System.Linq;

namespace TermProject_Library_Tatiana
{
    [Activity(Label = "TermProject_Library_Tatiana", MainLauncher = true)]
    public class Admin_AddBookActivity : Activity
    {

        EditText _isbn;
        EditText _bookName;
        EditText _author;
        EditText _category;
        EditText _numberCopies;
        TextView _linkSearch;
        Button _btnAddBook;

        Realm realmObj;

    protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Admin_AddBook);
            
            _isbn = FindViewById<EditText>(Resource.Id.isbn);
            _bookName = FindViewById<EditText>(Resource.Id.bookName);
            _author = FindViewById<EditText>(Resource.Id.author);
            _category = FindViewById<EditText>(Resource.Id.category);
            _numberCopies = FindViewById<EditText>(Resource.Id.numberCopies);
            _linkSearch = FindViewById<TextView>(Resource.Id.linkSearch);
            _btnAddBook = FindViewById<Button>(Resource.Id.btnAddBook);

            realmObj = Realm.GetInstance();

            _btnAddBook.Click += delegate
            {
                var bookModelObj = new TBBook();

                bookModelObj.ISBN = _isbn.Text;
                bookModelObj.BookName = _bookName.Text;
                bookModelObj.Author = _author.Text;
                bookModelObj.Category = _category.Text;
                bookModelObj.NumberCopies = _numberCopies.Text;

                realmObj.Write(() =>
                {
                    realmObj.Add(bookModelObj);
                });

                Toast.MakeText(ApplicationContext, "Book added successfully", ToastLength.Long).Show();

                _isbn.Text = "";
                _bookName.Text = "";
                _author.Text = "";
                _category.Text = "";
                _numberCopies.Text = "";
            };

            _linkSearch.Click += delegate
            {
                var linkSearchScreen = new Intent(this, typeof(Admin_SearchBookActivity));
                StartActivity(linkSearchScreen);
            };
        }
    }
}

