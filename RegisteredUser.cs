using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace UnAbandoned
{
    public class RegisteredUser
    {
        private int level;
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private List<WorkingJob> jobsParticipating;
        private decimal latitudeX;
        private decimal longitudeY;

        public int Level
        {
            get
            {
                return level;
            }
            private set
            {
                if (value == 1)
                    level = value;
                else if (value == 2)
                    level = value;
                else
                    level = 0;
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public List<WorkingJob> JobsParticipating
        {
            get { return jobsParticipating; }
            set { jobsParticipating = value; }
        }
        public decimal LatitudeX
        {
            get { return latitudeX; }
            set { latitudeX = value; }
        }
        public decimal LongitudeY
        {
            get { return longitudeY; }
            set { longitudeY = value; }
        }


        public RegisteredUser(int authLevel, string userFirst,
                              string userLast, string userEmail, string pass,
                              decimal latX = 41.662500m,
                              decimal longY = -86.219508m)
        {
            Level = authLevel;
            FirstName = userFirst;
            LastName = userLast;
            Email = userEmail;
            Password = pass;
            LatitudeX = latX;
            LongitudeY = longY;
            JobsParticipating = new List<WorkingJob>();
        }
    }
}