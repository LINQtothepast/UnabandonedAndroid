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

namespace UnAbandoned
{
    [Activity(Label = "LeaderLogin")]
    public class LeaderLogin : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string sentUser = Intent.GetStringExtra("User");


            // Create your application here

            SetContentView(Resource.Layout.LeaderPick2);

            Button LeadButton = FindViewById<Button>(Resource.Id.Lead);
            Button LendButton = FindViewById<Button>(Resource.Id.Lend);
            Button ViewButton = FindViewById<Button>(Resource.Id.LeaderView);


            LeadButton.Click += delegate
            {
                var intent = new Intent(this, typeof(LeadATeam));
                intent.PutExtra("User", sentUser);
                StartActivity(intent);
            };
            LendButton.Click += delegate
            {
                var intent = new Intent(this, typeof(GuestLogin));
                intent.PutExtra("User", sentUser);
                StartActivity(intent);
            };
            ViewButton.Click += delegate
            {
                var intent = new Intent(this, typeof(ViewMyProjects));
                intent.PutExtra("User", sentUser);
                StartActivity(intent);
            };
        }
    }
}