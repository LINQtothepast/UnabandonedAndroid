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
    [Activity(Label = "GuestChoice")]
    public class GuestChoice : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string sentChoice = Intent.GetStringExtra("Choice");

            // Create your application here
            SetContentView(Resource.Layout.GuestChoice);

            Button GuestSoonest = FindViewById<Button>(Resource.Id.GuestSoonest);
            Button GuestNearest = FindViewById<Button>(Resource.Id.GuestNearest);
            Button GuestLatest = FindViewById<Button>(Resource.Id.GuestLatest);


            GuestSoonest.Click += delegate
            {
                var intent = new Intent(this, typeof(GuestGenerateJobs));
                intent.PutExtra("Choice", sentChoice);
                intent.PutExtra("Sort", "Soonest");
                StartActivity(intent);
            };

            GuestNearest.Click += delegate
            {
                var intent = new Intent(this, typeof(GuestGenerateJobs));
                intent.PutExtra("Choice", sentChoice);
                intent.PutExtra("Sort", "Nearest");
                StartActivity(intent);
            };

            GuestLatest.Click += delegate
            {
                var intent = new Intent(this, typeof(GuestGenerateJobs));
                intent.PutExtra("Choice", sentChoice);
                intent.PutExtra("Sort", "Latest");
                StartActivity(intent);
            };


        }
    }
}