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

            RegisteredUserCollection.AndroidAddUserToList(0, "guest", "guest", "guest@gmail.com", "guest");
            RegisteredUserCollection.AndroidAddUserToList(1, "leader", "leader", "leader@gmail.com", "leader");
            RegisteredUserCollection.AndroidAddUserToList(2, "admin", "admin", "admin@gmail.com", "admin");

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button LoginButton = FindViewById<Button>(Resource.Id.LoginButton);
            Button SignUpButton = FindViewById<Button>(Resource.Id.SignUpButton);
            EditText EmailText = FindViewById<EditText>(Resource.Id.EmailTextBox);
            EditText PasswordText = FindViewById<EditText>(Resource.Id.PasswordTextBox);

            LoginButton.Click += (object sender, EventArgs e) => {
                if (RegisteredUserCollection.AndroidCheckUser(EmailText.Text) == true)
                {
                    if (RegisteredUserCollection.AndroidCheckPassword(EmailText.Text, PasswordText.Text) == true)
                    {
                        if (RegisteredUserCollection.AndroidGetLevel(EmailText.Text, PasswordText.Text) == 0)
                        {
                            StartActivity(typeof(GuestLogin));
                        }
                        else if (RegisteredUserCollection.AndroidGetLevel(EmailText.Text, PasswordText.Text) == 1)
                        {
                            StartActivity(typeof(LeaderLogin));
                        }
                        else if (RegisteredUserCollection.AndroidGetLevel(EmailText.Text, PasswordText.Text) == 2)
                        {
                            StartActivity(typeof(LeaderLogin));
                        }
                    }
                    else
                    {
                        StartActivity(typeof(MainActivity));
                    }
                }
                else
                {
                    StartActivity(typeof(MainActivity));
                }
            };

            //still needs work, has some weird run-time errors
            SignUpButton.Click += (object sender, EventArgs e) => {
                if (RegisteredUserCollection.AndroidCheckUser(EmailText.Text) == false)
                {
                    RegisteredUserCollection.AndroidAddUserToList(0, "guest", "guest", EmailText.Text, PasswordText.Text);
                    StartActivity(typeof(GuestLogin));
                }
            };
        }
    }
}

