using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace UnAbandoned
{
    [Activity(Label = "UnAbandoned", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //ProjectCollection.FillProjectObjects();
            DateTime value = new DateTime(2016, 11, 1, 5, 20, 00);
            ProjectCollection.AndroidAddProjectToList("street Address", "city", "state", 46637, "ENV-15-00367",
               "Snow", value, 50, 100, "Closed", value);

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

