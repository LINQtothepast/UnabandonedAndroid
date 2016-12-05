namespace ProjectUnAbandon
{
    class RegisteredUser
    {
        private int level;
        private string firstName;
        private string lastName;
        private string email;
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
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public List<WorkingJob> JobsParticipating
        {
            get; set;
        }
        public double LatitudeX
        {
            get; set;
        }
        public double LongitudeY
        {
            get; set;
        }


        public RegisteredUser(int authLevel, string userFirst,
                              string userLast, string userEmail,
                              double latX = 41.662500,
                              double longY = -86.219508)
        {
            Level = authLevel;
            FirstName = userFirst;
            LastName = userLast;
            Email = userEmail;
            LatitudeX = latX;
            LongitudeY = longY;
            JobsParticipating = new List<WorkingJob>();
        }
    }
}
