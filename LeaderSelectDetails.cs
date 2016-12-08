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
using static Android.Widget.Adapter;

namespace UnAbandoned
{
    [Activity(Label = "LeaderSelectDetails")]
    public class LeaderSelectDetails : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string sentParse = Intent.GetStringExtra("Parse");
            string sentUser = Intent.GetStringExtra("User");

            // Create your application here
            SetContentView(Resource.Layout.LeaderDetails);

            List<Project> tempList = new List<Project>();
            List<string> tempVEmail = new List<string>();
            tempList = ProjectCollection.AndroidFullList();

            var tempList2 =
                from element in tempList
                where element.RecordID == sentParse
                select element;

            EditText VolunteerCount = FindViewById<EditText>(Resource.Id.VolunteersEntry);
            EditText Time = FindViewById<EditText>(Resource.Id.TimeEntry);
            EditText Date = FindViewById<EditText>(Resource.Id.DateEntry);
           
            //database call?

            Button CancelButton = FindViewById<Button>(Resource.Id.LeaderCancelButton);
            Button ConfirmButton = FindViewById<Button>(Resource.Id.LeaderConfirmButton);

            var intent = new Intent(this, typeof(LeaderLogin));
            intent.PutExtra("User", sentUser);

            CancelButton.Click += (object sender, EventArgs e) =>
            {
                StartActivity(intent);
            };

            ConfirmButton.Click += (object sender, EventArgs e) =>
            {
                if (Convert.ToInt32(VolunteerCount.Text) < 0)
                {
                    intent = new Intent(this, typeof(LeaderSelectDetails));
                    intent.PutExtra("User", sentUser);
                    intent.PutExtra("Parse", sentParse);
                    StartActivity(intent);
                }
                else if ((Convert.ToInt32(VolunteerCount.Text)) > 20)
                {
                    intent = new Intent(this, typeof(LeaderSelectDetails));
                    intent.PutExtra("User", sentUser);
                    intent.PutExtra("Parse", sentParse);
                    StartActivity(intent);
                }
                /*else if (Convert.ToInt32(Time.Text) > 2400)
                {
                    intent = new Intent(this, typeof(LeaderSelectDetails));
                    intent.PutExtra("User", sentUser);
                    intent.PutExtra("Parse", sentParse);
                    StartActivity(intent);
                }
                else if (Convert.ToInt32(Time.Text) < 0)
                {
                    intent = new Intent(this, typeof(LeaderSelectDetails));
                    intent.PutExtra("User", sentUser);
                    intent.PutExtra("Parse", sentParse);
                    StartActivity(intent);
                }*/
                else
                {
                    DateTime JobDate = DateTime.Parse(Date.Text);
                    DateTime JobTime = new DateTime();
                    string[] tempTime = Time.Text.Split(':');
                    JobTime = JobDate.Date.AddHours(Convert.ToDouble(tempTime[0]))
                    .AddMinutes(Convert.ToDouble(tempTime[1]));
                    tempList2.First().InUse = true;

                    WorkingJobCollection.AndroidAddWorkingJobToList(sentUser,
                    tempList2.First(), tempVEmail, Convert.ToInt32(VolunteerCount.Text), 
                    JobDate, JobTime);
                    StartActivity(intent);
                }            
            };

        }
    }
}