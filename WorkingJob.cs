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
        private List<string> VolunteerEmail
        {
            get { return volunteerEmail; }
            set { volunteerEmail = value; }
        }
        private int VolunteerCount
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
        private DateTime JobDate
        {
            get { return jobDate; }
            set { jobDate = value; }
        }
        private string JobStatus
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
                          int count, DateTime date, string status = "open")
        {
            LeaderEmail = LEmail;
            JobProject = job;
            VolunteerEmail = VEmail;
            VolunteerCount = count;
            JobDate = date;
            JobStatus = status;
        }
    }
}