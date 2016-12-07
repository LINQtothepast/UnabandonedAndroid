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
    [Activity(Label = "GuestGenerateJobs")]
    public class GuestGenerateJobs : ListActivity
    {
        protected override void OnCreate(Bundle Bundle)
        {
            base.OnCreate(Bundle);

            string sentChoice = Intent.GetStringExtra("Choice");
            string sentSort = Intent.GetStringExtra("Sort");
            string sentUser = Intent.GetStringExtra("User");

            // Create your application here
            List<Project> testProjectList = new List<Project>();
            //testProjectList = ProjectCollection.AndroidTenMostRecent();
            List<RegisteredUser> testUserList = new List<RegisteredUser>();
            testUserList = RegisteredUserCollection.ReturnTestList();

            /*
            if (sentChoice == "Any")
            {
                if (sentSort == "Soonest")
                {
                    //sortedCollection = ProjectCollection.AndroidAny();
                }
                else if (sentSort == "Nearest")
                {
                    //needs distance calculations
                }
                else if (sentSort == "Latest")
                {
                    //sortedCollection = ProjectCollection.AndroidAny();
                }
            }
            else if (sentChoice == "Yard")
            {
                if (sentSort == "Soonest")
                {

                }
                else if (sentSort == "Nearest")
                {

                }
                else if (sentSort == "Latest")
                {

                }
            }
            else if (sentChoice == "House")
            {
                if (sentSort == "Soonest")
                {

                }
                else if (sentSort == "Nearest")
                {

                }
                else if (sentSort == "Latest")
                {

                }
            }
            else if (sentChoice == "Trash")
            {
                if (sentSort == "Soonest")
                {

                }
                else if (sentSort == "Nearest")
                {

                }
                else if (sentSort == "Latest")
                {

                }
            }
            else if (sentChoice == "Other")
            {
                if (sentSort == "Soonest")
                {

                }
                else if (sentSort == "Nearest")
                {

                }
                else if (sentSort == "Latest")
                {

                }
            }
            */
            //ListAdapter = new ArrayAdapter<Project>(this, Android.Resource.Layout.SimpleListItem1, testProjectList);
            ListAdapter = new ArrayAdapter<RegisteredUser>(this, Android.Resource.Layout.SimpleListItem1, testUserList);

            ListView.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) =>
            {
                string key = ListView.GetItemAtPosition(e.Position).ToString();

                var intent = new Intent(this, typeof(LeaderSelectDetails));
                intent.PutExtra("Key", key);
                intent.PutExtra("User", sentUser);
                StartActivity(intent);
            };
        }
    }
}