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
using Android.Runtime;
using Android.Views;
using Android.Content;

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
            ProjectCollection.AndroidAddProjectToList("street Address1", "city1", "state1", 46637, "ENV-15-00367",
               "Snow", value, 41.73553569m, -86.24336583m, "Open", value);
            ProjectCollection.AndroidAddProjectToList("street Address2", "city2", "state2", 46638, "ENV-15-00368",
               "Litter", value, 41.74287198m, -86.26281856m, "Open", value);
            ProjectCollection.AndroidAddProjectToList("street Address3", "city3", "state3", 46639, "ENV-15-00369",
               "Grass and Weeds", value, 41.74287198m, -86.26281856m, "Open", value);

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
                            var intent = new Intent(this, typeof(GuestLogin));
                            intent.PutExtra("User", EmailText.Text);
                            StartActivity(intent);
                        }
                        else if (RegisteredUserCollection.AndroidGetLevel(EmailText.Text, PasswordText.Text) == 1)
                        {
                            var intent = new Intent(this, typeof(LeaderLogin));
                            intent.PutExtra("User", EmailText.Text);
                            StartActivity(intent);
                        }
                        else if (RegisteredUserCollection.AndroidGetLevel(EmailText.Text, PasswordText.Text) == 2)
                        {
                            var intent = new Intent(this, typeof(LeaderLogin));
                            intent.PutExtra("User", EmailText.Text);
                            StartActivity(intent);
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
                    var intent = new Intent(this, typeof(GuestLogin));
                    intent.PutExtra("User", EmailText.Text);
                    StartActivity(intent);
                }
                else { StartActivity(typeof(MainActivity)); }
            };
        }
    }
}

