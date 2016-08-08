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
    [Activity(Label = "AddNewPasswordActivity")]
    public class AddNewPasswordActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "AddNewPassword" layout resource
            SetContentView(Resource.Layout.AddNewPassword);

            // Create your application here
            ImageButton homeButton = FindViewById<ImageButton>(Resource.Id.addnewpassword_home);

            homeButton.Click += delegate {
                StartActivity(typeof(MainActivity));
            };

            // Create your application here
            // Get our button from the layout resource,
            // and attach an event to it
            Button addnewpasswordButton = FindViewById<Button>(Resource.Id.button_addapplicationpassword);

            EditText applicationnameText = FindViewById<EditText>(Resource.Id.text_applicationname);
            EditText passwordText = FindViewById<EditText>(Resource.Id.text_applicationpassword);

            addnewpasswordButton.Click += delegate
            {
                //button.Text = string.Format("{0} clicks!", count++);

                // verify user name and password
                // if successful display the other two buttons

                String applicationname = applicationnameText.Text.Trim().ToUpper();
                String password = passwordText.Text.Trim();

                Boolean add = true;

                if (applicationname == "")
                {
                    applicationnameText.Text = "Mandatory";
                    add = false;
                }
                if (password == "")
                {
                    passwordText.Text = "Mandatory";
                    add = false;
                }

                if (add == true)
                {
                    Boolean added = PasswordStore.GetInstance().Add(new CustomPassword(applicationname, password));

                    if (added == false)
                    {
                        applicationnameText.Text = "Already exists";
                    }
                    else
                    {
                        // take the user to the reveal password activity
                        StartActivity(typeof(RevealPasswordsActivity));
                    }
                }
            };

        }
    }
}