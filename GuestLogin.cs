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
    [Activity(Label = "Guest Login")]
    public class GuestLogin : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.GuestLandingPage);

            Button Any = FindViewById<Button>(Resource.Id.Any);
            Button Yard = FindViewById<Button>(Resource.Id.Yard);
            Button House = FindViewById<Button>(Resource.Id.House);
            Button Trash = FindViewById<Button>(Resource.Id.Trash);
            Button Other = FindViewById<Button>(Resource.Id.Other);
           

            Any.Click += delegate
            {
                var intent = new Intent(this, typeof(GuestChoice));
                intent.PutExtra("Choice", "Any");
                StartActivity(intent);
            };
            Yard.Click += delegate
            {
                var intent = new Intent(this, typeof(GuestChoice));
                intent.PutExtra("Choice", "Yard");
                StartActivity(intent);
            };
            House.Click += delegate
            {
                var intent = new Intent(this, typeof(GuestChoice));
                intent.PutExtra("Choice", "House");
                StartActivity(intent);
            };
            Trash.Click += delegate
            {
                var intent = new Intent(this, typeof(GuestChoice));
                intent.PutExtra("Choice", "Trash");
                StartActivity(intent);
            };
            Other.Click += delegate
            {
                var intent = new Intent(this, typeof(GuestChoice));
                intent.PutExtra("Choice", "Other");
                StartActivity(intent);
            };
        }
    }
}