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

namespace PasswordManagerApplication
{
    [Activity(Label = "RevealPasswordsActivity")]
    public class RevealPasswordsActivity : ListActivity
    {
        String[] items = new String[2];

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RevealPasswords);
            items[0] = "Laptop1";
            items[1] = "Laptop2";
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,items);
            ListAdapter = adapter;
        }
    }
}