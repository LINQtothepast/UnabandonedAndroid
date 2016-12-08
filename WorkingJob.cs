using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace UnAbandoned
{
    public class WorkingJob
    {
        private string leaderEmail;
        private Project jobProject;
        private List<string> volunteerEmail;
        private int volunteerCount;
        private DateTime jobDate;
        private DateTime jobTime;
        private string jobStatus;

        public string LeaderEmail
        {
            get { return leaderEmail; }
            set { leaderEmail = value; }
        }
        public Project JobProject
        {
            get { return jobProject; }
            set { jobProject = value; }
        }
        public List<string> VolunteerEmail
        {
            get { return volunteerEmail; }
            set { volunteerEmail = value; }
        }
        public int VolunteerCount
        {
            get
            {
                return volunteerCount;
            }
            set
            {
                if (value == VolunteerEmail.Count())
                    volunteerCount = value;
                else
                    volunteerCount = VolunteerEmail.Count();
            }
        }
        public DateTime JobDate
        {
            get { return jobDate; }
            set { jobDate = value; }
        }
        public DateTime JobTime
        {
            get { return jobDate; }
            set { jobDate = value; }
        }
        public string JobStatus
        {
            get
            {
                return jobStatus;
            }
            set
            {
                jobStatus = value.ToLower();
            }
        }
        public WorkingJob(string LEmail, Project job, List<string> VEmail,
                          int count, DateTime date, DateTime time, string status = "open")
        {
            LeaderEmail = LEmail;
            JobProject = job;
            VolunteerEmail = VEmail;
            VolunteerCount = count;
            JobDate = date;
            JobTime = time;
            JobStatus = status;
        }

        public override string ToString()
        {
            return string.Format("Case Number: {0}\n" +
                "Leader Contact Info : {1}\n" +
                "Date : {2}\n" +
                "Time : {3}\n" +
                "Street Address : {4}\n" +
                "City : {5}   Zip Code : {6}\n" +
                "Distance Away : {7} Miles\n" +
                "Project Type : {8}",
                JobProject.RecordID,
                LeaderEmail, JobDate.ToShortDateString(),
                JobTime.ToShortTimeString(),
                JobProject.AddressStreet, JobProject.AddressCity,
                JobProject.AddressZipCode, JobProject.Distance,
                JobProject.ViolationType);
        }
    }
}