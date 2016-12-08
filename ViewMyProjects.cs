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
using SQLite;

namespace UnAbandoned
{
    [Activity(Label = "ViewMyProjects")]
    public class ViewMyProjects : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string sentUser = Intent.GetStringExtra("User");

            // Create your application here
            List<WorkingJob> MyWorkingJobs = new List<WorkingJob>();
            MyWorkingJobs = WorkingJobCollection.AndroidReturnMyJobs(sentUser);
            ListAdapter = new ArrayAdapter<WorkingJob>(this, Android.Resource.Layout.SimpleListItem1, MyWorkingJobs);

            ListView.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) =>
            {
                string key = ListView.GetItemAtPosition(e.Position).ToString();
                string[] lines = key.Split('\n');
                lines = lines[0].Split(' ');
                string passString = lines[2];

                var intent = new Intent(this, typeof(ViewMyProjectsAction));
                intent.PutExtra("Key", passString);
                intent.PutExtra("User", sentUser);
                StartActivity(intent);
            };
        }
    }
}