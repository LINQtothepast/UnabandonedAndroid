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

            // Create your application here

            SetContentView(Resource.Layout.LeaderPick2);

            Button LeadButton = FindViewById<Button>(Resource.Id.Lead);
            Button LendButton = FindViewById<Button>(Resource.Id.Lend);

            LeadButton.Click += delegate
            {
                StartActivity(typeof(LeadATeam));
            };
            LendButton.Click += delegate
            {
                StartActivity(typeof(GuestLogin));
            };
        }
    }
}