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
            List<WorkingJob> SortedWorkingJobs = new List<WorkingJob>();
        
            if (sentChoice == "Any")
            {
                if (sentSort == "Soonest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidAny();
                    SortedWorkingJobs.OrderBy(element => element.JobDate).
                        ThenBy(element => element.JobTime);
                }
                else if (sentSort == "Nearest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidAny();
                    SortedWorkingJobs.OrderBy(element => element.JobProject.Distance);
                }
                else if (sentSort == "Latest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidAny();
                    SortedWorkingJobs.OrderBy(element => element.JobProject.DateReported);
                }
            }
            else if (sentChoice == "Yard")
            {
                if (sentSort == "Soonest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidYard();
                    SortedWorkingJobs.OrderBy(element => element.JobDate).
                        ThenBy(element => element.JobTime);
                }
                else if (sentSort == "Nearest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidYard();
                    SortedWorkingJobs.OrderBy(element => element.JobProject.Distance);
                }
                else if (sentSort == "Latest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidYard();
                    SortedWorkingJobs.OrderBy(element => element.JobProject.DateReported);
                }
            }
            else if (sentChoice == "House")
            {
                if (sentSort == "Soonest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidHouse();
                    SortedWorkingJobs.OrderBy(element => element.JobDate).
                        ThenBy(element => element.JobTime);
                }
                else if (sentSort == "Nearest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidHouse();
                    SortedWorkingJobs.OrderBy(element => element.JobProject.Distance);
                }
                else if (sentSort == "Latest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidHouse();
                    SortedWorkingJobs.OrderBy(element => element.JobProject.DateReported);
                }
            }
            else if (sentChoice == "Trash")
            {
                if (sentSort == "Soonest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidTrash();
                    SortedWorkingJobs.OrderBy(element => element.JobDate).
                        ThenBy(element => element.JobTime);
                }
                else if (sentSort == "Nearest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidTrash();
                    SortedWorkingJobs.OrderBy(element => element.JobProject.Distance);
                }
                else if (sentSort == "Latest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidTrash();
                    SortedWorkingJobs.OrderBy(element => element.JobProject.DateReported);
                }
            }
            else if (sentChoice == "Other")
            {
                if (sentSort == "Soonest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidOther();
                    SortedWorkingJobs.OrderBy(element => element.JobDate).
                        ThenBy(element => element.JobTime);
                }
                else if (sentSort == "Nearest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidOther();
                    SortedWorkingJobs.OrderBy(element => element.JobProject.Distance);
                }
                else if (sentSort == "Latest")
                {
                    SortedWorkingJobs = WorkingJobCollection.AndroidOther();
                    SortedWorkingJobs.OrderBy(element => element.JobProject.DateReported);
                }
            }
            
            ListAdapter = new ArrayAdapter<WorkingJob>(this, Android.Resource.Layout.SimpleListItem1, SortedWorkingJobs);

            ListView.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) =>
            {
                string key = ListView.GetItemAtPosition(e.Position).ToString();
                string[] lines = key.Split('\n');
                lines = lines[0].Split(' ');
                string passString = lines[1];

                var intent = new Intent(this, typeof(GuestConfirm));
                intent.PutExtra("Key", passString);
                intent.PutExtra("User", sentUser);
                StartActivity(intent);
            };
        }
    }
}