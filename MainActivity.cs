using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Java.IO;

namespace LearnXhosaApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        private List<Person> mItems;
        private ListView items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            items = FindViewById<ListView>(Resource.Id.myListView);

            mItems = new List<Person>()
            {
                new Person()
                {
                    Age = "10",
                    Gender = "Male",
                    Name = "Ace",
                    Surname = "Sawulisi"
                },
                new Person()
                {
                    Age = "32",
                    Gender = "Male",
                    Name = "Ayanda",
                    Surname = "Sawulisi"
                }
            };
            
            var adapter = new ListViewAdapter(this, mItems);
            var counter = adapter.Count;
            //var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItems);
            items.Adapter = adapter;

            items.ItemClick += Items_ItemClick;
            //Toast.MakeText(this, "Successfully logged in!", ToastLength.Short).Show();
        }

        private void Items_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            System.Console.WriteLine(mItems[e.Position].Name);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}