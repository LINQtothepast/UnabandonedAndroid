using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace UnAbandoned
{
    public class RegisteredUserCollection
    {
        static List<RegisteredUser> RegisteredUserList = new List<RegisteredUser>();

        public static void AndroidAddUserToList(int authLevel, string userFirst,
                              string userLast, string userEmail, string password,
                              decimal latX = 41.662500m,
                              decimal longY = -86.219508m)
        {
            RegisteredUserList.Add(new RegisteredUser(authLevel, userFirst, userLast,
                userEmail, password, latX, longY));
        }

        public static bool AndroidCheckUser(string userEmail)
        {
            bool value = false;
            foreach (var element in RegisteredUserList)
            {
                if (element.Email == userEmail)
                {
                    value = true;
                }
            }
            return value;
        }

        public static bool AndroidCheckPassword(string userEmail, string userPassword)
        {
            bool value = false;
            foreach (var element in RegisteredUserList)
            {
                if (element.Email == userEmail)
                {
                    if (element.Password == userPassword)
                    {
                        value = true;
                    }
                }
            }
            return value;
        }

        public static int AndroidGetLevel(string userEmail, string userPassword)
        {
            int value = -1;
            foreach (var element in RegisteredUserList)
            {
                if (element.Email == userEmail)
                {
                    if (element.Password == userPassword)
                    {
                        value = element.Level;
                    }
                }
            }
            return value;
        }

        public static int AndroidGetCount()
        {
            return RegisteredUserList.Count();
        }
    }
}