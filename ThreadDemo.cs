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
    [Activity(Label = "ThreadDemo")]
    public class ThreadDemo : Activity
    {
        TextView textview;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            string sentKey = Intent.GetStringExtra("Key");

            // Create a new TextView and set it as our view
            textview = new TextView(this);
            textview.Text = "text";

            SetContentView(textview);
        }
    }
}