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
            get; set;
        }
        public Project JobProject
        {
            get; set;
        }
        private List<string> VolunteerEmail
        {
            get; set;
        }
        private int VolunteerCount
        {
            get
            {
                return VolunteerCount;
            }
            set
            {
                if (value == VolunteerEmail.Count())
                    VolunteerCount = value;
                else
                    VolunteerCount = VolunteerEmail.Count();
            }
        }
        private DateTime JobDate
        {
            get; set;
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
        public WorkingJob(string email, Project job,
                          DateTime date, string status = "open")
        {
            LeaderEmail = email;
            JobProject = job;
            JobDate = date;
            JobStatus = status;
        }
    }
}