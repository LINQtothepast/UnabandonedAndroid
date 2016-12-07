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
            string sentUser = Intent.GetStringExtra("User");

            // Create your application here
            List<Project> sortedCollection = new List<Project>();
            List<Project> tempCollection = new List<Project>();
            tempCollection = ProjectCollection.AndroidFullList();
            double tempDistance = 0;
            foreach (var element in tempCollection)
            {
                tempDistance = LocationMath.CalcDistance
                    (Convert.ToDouble(element.LatitudeX),
                    Convert.ToDouble(element.LongitudeY));
                tempDistance = Math.Round(tempDistance, 2);
                element.Distance = tempDistance;
            }

            if (sentChoice == "Any")
            {
                if (sentSort == "Nearest")
                {
                    sortedCollection = ProjectCollection.AndroidAny();
                    sortedCollection.OrderByDescending(element => element.Distance);
                }
                else if (sentSort == "Latest")
                {
                    sortedCollection = ProjectCollection.AndroidAny();
                }
            }
            else if (sentChoice == "Yard")
            {
                if (sentSort == "Nearest")
                {
                    sortedCollection = ProjectCollection.AndroidYard();
                    sortedCollection.OrderByDescending(element => element.Distance);
                }
                else if (sentSort == "Latest")
                {
                    sortedCollection = ProjectCollection.AndroidYard();
                }
            }
            else if (sentChoice == "House")
            {
                if (sentSort == "Nearest")
                {
                    sortedCollection = ProjectCollection.AndroidHouse();
                    sortedCollection.OrderByDescending(element => element.Distance);
                }
                else if (sentSort == "Latest")
                {
                    sortedCollection = ProjectCollection.AndroidHouse();
                }
            }
            else if (sentChoice == "Trash")
            {
                if (sentSort == "Nearest")
                {
                    sortedCollection = ProjectCollection.AndroidTrash();
                    sortedCollection.OrderByDescending(element => element.Distance);
                }
                else if (sentSort == "Latest")
                {
                    sortedCollection = ProjectCollection.AndroidTrash();
                }
            }
            else if (sentChoice == "Other")
            {
                if (sentSort == "Nearest")
                {
                    sortedCollection = ProjectCollection.AndroidOther();
                    sortedCollection.OrderByDescending(element => element.Distance);
                }
                else if (sentSort == "Latest")
                {
                    sortedCollection = ProjectCollection.AndroidOther();
                }
            }
            
            ListAdapter = new ArrayAdapter<Project>(this, Android.Resource.Layout.SimpleListItem1, sortedCollection);


            ListView.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) =>
            {
                string key = ListView.GetItemAtPosition(e.Position).ToString();
                
                
                var intent = new Intent(this, typeof(ThreadDemo));
                intent.PutExtra ("Key", key);
                intent.PutExtra("User", sentUser);
                StartActivity(intent);
                
            };

            //List<string> random = new List<string>();
            //random.Add("Total Number of to Choose from : " + Convert.ToString(ProjectCollection.GetCount()));
            //foreach (var element in sortedCollection) {random.Add(element.AddressStreet);}     
            //ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, random);
        }
    }
}