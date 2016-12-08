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
    [Activity(Label = "GuestConfirm")]
    public class GuestConfirm : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string sentKey = Intent.GetStringExtra("Key");
            string sentUser = Intent.GetStringExtra("User");

            // Create your application here
            SetContentView(Resource.Layout.GuestConfirm);

            Button ConfirmButton = FindViewById<Button>(Resource.Id.GuestConfirmButton);
            Button CancelButton = FindViewById<Button>(Resource.Id.GuestCancelButton);

            var intent = new Intent(this, typeof(GuestLogin));
            intent.PutExtra("User", sentUser);

            CancelButton.Click += (object sender, EventArgs e) =>
            {
                StartActivity(intent);
            };

            ConfirmButton.Click += (object sender, EventArgs e) =>
            {

                WorkingJobCollection.AndroidAddVolunteerEmail(sentUser, sentKey);
                StartActivity(intent);
            };


        }
    }
}