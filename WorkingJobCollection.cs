using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace UnAbandoned
{
    public class WorkingJobCollection
    {
        static List<WorkingJob> WorkingJobList = new List<WorkingJob>();

        public static void AndroidAddWorkingJobToList(string LEmail, Project job, List<string> VEmail,
                          int count, DateTime date, DateTime time, string status = "open")
        {
            WorkingJobList.Add(new WorkingJob(LEmail, job, VEmail, count,
                date, time, status));
        }

        public static List<WorkingJob> AndroidAny()
        {
            var Any = WorkingJobList.
                Where(element => element.JobStatus == "open").
                //Where(element => element.VolunteerEmail.Count() < element.VolunteerCount).
                OrderByDescending(element => element.JobProject.RecordID);

            List<WorkingJob> theList = new List<WorkingJob>();
            foreach (var element in Any)
            {
                theList.Add(element);
            }
            return theList;
        }

        public static List<WorkingJob> AndroidYard()
        {
            var GrassAndWeeds = WorkingJobList.
                Where(element => element.JobStatus == "open").
                Where(element => element.VolunteerEmail.Count() != element.VolunteerCount).
                Where(element => element.JobProject.ViolationType == "Grass and Weeds").
                 OrderByDescending(element => element.JobProject.DateReported);

            var Vegetation = WorkingJobList.
                Where(element => element.JobStatus == "open").
                Where(element => element.VolunteerEmail.Count() != element.VolunteerCount).
                Where(element => element.JobProject.ViolationType == "Vegetation").
                 OrderByDescending(element => element.JobProject.DateReported);

            List<WorkingJob> theList = new List<WorkingJob>();
            theList.AddRange(GrassAndWeeds);
            theList.AddRange(Vegetation);
            return theList;
        }

        public static List<WorkingJob> AndroidHouse()
        {
            var Graffiti = WorkingJobList.
                Where(element => element.JobStatus == "open").
                Where(element => element.VolunteerEmail.Count() != element.VolunteerCount).
                Where(element => element.JobProject.ViolationType == "Graffiti").
                 OrderByDescending(element => element.JobProject.DateReported);

            List<WorkingJob> theList = new List<WorkingJob>();
            theList.AddRange(Graffiti);
            return theList;
        }
        public static List<WorkingJob> AndroidTrash()
        {
            var Litter = WorkingJobList.
                Where(element => element.JobStatus == "open").
                Where(element => element.VolunteerEmail.Count() != element.VolunteerCount).
                Where(element => element.JobProject.ViolationType == "Litter").
                 OrderByDescending(element => element.JobProject.DateReported);

            List<WorkingJob> theList = new List<WorkingJob>();
            theList.AddRange(Litter);
            return theList;
        }
        public static List<WorkingJob> AndroidOther()
        {
            var ContinuousEnforcement = WorkingJobList.
                Where(element => element.JobStatus == "open").
                Where(element => element.VolunteerEmail.Count() != element.VolunteerCount).
                Where(element => element.JobProject.ViolationType == "Continuous Enforcement").
                 OrderByDescending(element => element.JobProject.DateReported);

            var ContinuousEnforcementGrass = WorkingJobList.
                Where(element => element.JobStatus == "open").
                Where(element => element.VolunteerEmail.Count() != element.VolunteerCount).
                Where(element => element.JobProject.ViolationType == "Continuous Enforcement Grass").
                 OrderByDescending(element => element.JobProject.DateReported);

            var Snow = WorkingJobList.
                Where(element => element.JobStatus == "open").
                Where(element => element.VolunteerEmail.Count() != element.VolunteerCount).
                Where(element => element.JobProject.ViolationType == "Snow").
                 OrderByDescending(element => element.JobProject.DateReported);

            List<WorkingJob> theList = new List<WorkingJob>();
            theList.AddRange(ContinuousEnforcement);
            theList.AddRange(ContinuousEnforcementGrass);
            theList.AddRange(Snow);

            return theList;
        }

        public static List<WorkingJob> AndroidReturnMyJobs(string UserEmail)
        {
            List<WorkingJob> theList = new List<WorkingJob>();
            var LeadJobs = WorkingJobList.
                Where(element => element.JobStatus == "open").
                Where(element => element.LeaderEmail == UserEmail).
                 OrderByDescending(element => element.JobProject.DateReported);

            var HelpJobs = WorkingJobList.
                Where(element => element.JobStatus == "open").
                Where(element => element.VolunteerEmail.Contains(UserEmail)).
                 OrderByDescending(element => element.JobProject.DateReported);

            theList.AddRange(LeadJobs);
            theList.AddRange(HelpJobs);
            return theList;
        }

        public static void AndroidAddVolunteerEmail(string sentUser, string sentKey)
        {
            foreach (var element in WorkingJobList)
            {
                if (element.JobProject.RecordID == sentKey)
                {
                    element.VolunteerEmail.Add(sentUser);
                }
            }
        }

        public static void AndroidMarkAsClosed(string sentKey)
        {
            foreach (var element in WorkingJobList)
            {
                if (element.JobProject.RecordID == sentKey)
                {
                    element.JobStatus = "closed";
                }
            }
        }

        public static void AndroidRemoveMyEmail(string sentKey, string sentUser)
        {
            foreach (var element in WorkingJobList)
            {
                if (element.JobProject.RecordID == sentKey)
                {
                    if (element.LeaderEmail == sentUser)
                    {
                        AndroidMarkAsClosed(sentKey);
                    }
                    else
                    {
                        element.VolunteerEmail.Remove(sentUser);
                    }
                }
            }
        }
    }
}