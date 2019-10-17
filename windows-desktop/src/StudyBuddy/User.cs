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
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }

        public User(string user, string pass, string first, string last, string email)
        {
            username = user;
            password = pass;
            salt = "";
            first_name = first;
            last_name = last;
            this.email = email;
        }

        public User(string user, string pass, string salt, string first, string last, string email)
        {
            username = user;
            password = pass;
            this.salt = salt;
            first_name = first;
            last_name = last;
            this.email = email;
        }
    }
}
