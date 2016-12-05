using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace UnAbandoned
{
    [Activity(Label = "UnAbandoned", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //ProjectCollection.FillProjectObjects();

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button LoginButton = FindViewById<Button>(Resource.Id.LoginButton);
            EditText EmailText = FindViewById<EditText>(Resource.Id.EmailTextBox);
            EditText PasswordText = FindViewById<EditText>(Resource.Id.PasswordTextBox);

            string checkEmail = EmailText.Text;
            string checkPassword = PasswordText.Text;

            LoginButton.Click += delegate {
                if (checkEmail == "admin")
                {
                    if (checkPassword == "password")
                    {
                        StartActivity(typeof(LeaderLogin));
                    }
                }                
            };

        }
    }
}

