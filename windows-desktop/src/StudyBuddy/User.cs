using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        public User(string user, string pass, string first, string last, string email)
        {
            username = user;
            password = pass;
            salt = "";
            firstName = first;
            lastName = last;
            this.email = email;
        }

        public User(string user, string pass, string salt, string first, string last, string email)
        {
            username = user;
            password = pass;
            this.salt = salt;
            firstName = first;
            lastName = last;
            this.email = email;
        }
    }
}
