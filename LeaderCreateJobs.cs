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
    [Activity(Label = "LeaderCreateJobs")]
    public class LeaderCreateJobs : ListActivity
    {
        protected override void OnCreate(Bundle Bundle)
        {
            base.OnCreate(Bundle);

            string sentChoice = Intent.GetStringExtra("Choice");
            string sentSort = Intent.GetStringExtra("Sort");

            // Create your application here
            List<Project> sortedCollection = new List<Project>();
            sortedCollection = ProjectCollection.AndroidTenMostRecent();

            ListAdapter = new ArrayAdapter<Project>(this, Android.Resource.Layout.SimpleListItem1, sortedCollection);

            ListView.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) =>
            {
                string key = ListView.GetItemAtPosition(e.Position).ToString();

                var intent = new Intent(this, typeof(LeaderSelectDetails));
                intent.PutExtra("Key", key);
                StartActivity(intent);
            };

            //List<string> random = new List<string>();
            //random.Add("Total Number of to Choose from : " + Convert.ToString(ProjectCollection.GetCount()));
            //foreach (var element in sortedCollection) {random.Add(element.AddressStreet);}     
            //ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, random);
        }
    }
}