using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;

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

            // Create your application here
            List<Project> sortedCollection = new List<Project>();
            sortedCollection = ProjectCollection.AndroidTenMostRecent();

            //ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, sortedCollection);
        }
    }
}