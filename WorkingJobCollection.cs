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
                          int count, DateTime date, string status = "open")
        {
            WorkingJobList.Add(new WorkingJob(LEmail, job, VEmail, count,
                date, status));
        }


    }
}