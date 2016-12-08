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
    [Activity(Label = "ViewMyProjectsAction")]
    public class ViewMyProjectsAction : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string sentUser = Intent.GetStringExtra("User");
            string sentKey = Intent.GetStringExtra("Key");

            // Create your application here
            SetContentView(Resource.Layout.MyProjectsChoices);

            Button EndParticipation = FindViewById<Button>(Resource.Id.MyCancelButton);
            Button MarkAsClosed = FindViewById<Button>(Resource.Id.CloseJobButton);
            Button DoNothing = FindViewById<Button>(Resource.Id.DoNothingButton);

            var intent = new Intent(this, typeof(LeaderLogin));
            intent.PutExtra("User", sentUser);

            DoNothing.Click += (object sender, EventArgs e) =>
            {
                StartActivity(intent);
            };

            MarkAsClosed.Click += (object sender, EventArgs e) =>
            {
                WorkingJobCollection.AndroidMarkAsClosed(sentKey);
                StartActivity(intent);
            };

            EndParticipation.Click += (object sender, EventArgs e) =>
            {
                WorkingJobCollection.AndroidRemoveMyEmail(sentKey, sentUser);
                StartActivity(intent);
            };

        }
    }
}