using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PasswordManagerApplication
{
    [Activity(Label = "PasswordManagerApplication", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button loginButton = FindViewById<Button>(Resource.Id.button_login);
            Button revealPasswordsButton = FindViewById<Button>(Resource.Id.button_revealpasswords);
            Button addNewPasswordButton = FindViewById<Button>(Resource.Id.button_addnewpassword);
            EditText usernameText = FindViewById<EditText>(Resource.Id.text_username);
            EditText passwordText = FindViewById<EditText>(Resource.Id.text_password);

            loginButton.Click += delegate {

                String username = usernameText.Text.Trim().ToUpper();
                String password = passwordText.Text.Trim().ToUpper();

                if (username == "ADMIN" && password == "PASSWORD")
                {
                    revealPasswordsButton.Visibility = ViewStates.Visible;
                    addNewPasswordButton.Visibility = ViewStates.Visible;
                    loginButton.Enabled = false;

                    PasswordStore.GetInstance().Add(new CustomPassword("laptop", "password"));
                }
                else
                {
                    revealPasswordsButton.Visibility = ViewStates.Invisible;
                    addNewPasswordButton.Visibility = ViewStates.Invisible;
                    loginButton.Enabled = true;

                    usernameText.Text = "Invalid user/password";
                    passwordText.Text = "Try again";
                }
               
            };

            revealPasswordsButton.Click += delegate
            {
                StartActivity(typeof(RevealPasswordsActivity));
            };

            addNewPasswordButton.Click += delegate
            {
                StartActivity(typeof(AddNewPasswordActivity));
            };
        }
    }
}

