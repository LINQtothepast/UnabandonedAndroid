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
    [Activity(Label = "LeaderChoice")]
    public class LeaderChoice : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string sentChoice = Intent.GetStringExtra("Choice");
            string sentUser = Intent.GetStringExtra("User");

            // Create your application here
            SetContentView(Resource.Layout.LeaderChoice);

            Button LeaderNearest = FindViewById<Button>(Resource.Id.LeaderNearest);
            Button LeaderLatest = FindViewById<Button>(Resource.Id.LeaderLatest);

            LeaderNearest.Click += delegate
            {
                var intent = new Intent(this, typeof(LeaderCreateJobs));
                intent.PutExtra("Choice", sentChoice);
                intent.PutExtra("Sort", "Nearest");
                intent.PutExtra("User", sentUser);
                StartActivity(intent);
            };

            LeaderLatest.Click += delegate
            {
                var intent = new Intent(this, typeof(LeaderCreateJobs));
                intent.PutExtra("Choice", sentChoice);
                intent.PutExtra("Sort", "Latest");
                intent.PutExtra("User", sentUser);
                StartActivity(intent);
            };
        }
    }
}