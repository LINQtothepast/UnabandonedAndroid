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
    public class LeaderSelectDetails : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string sentKey = Intent.GetStringExtra("Key");
            string sentUser = Intent.GetStringExtra("User");

            // Create your application here
            //SetContentView(Resource.Layout.LeaderDetails);
            List<string> testList = new List<string>();
            testList.Add(sentKey);
            //ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, testList);

        }
    }
}