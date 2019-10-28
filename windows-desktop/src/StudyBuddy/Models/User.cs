using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Models
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public List<int> chats { get; set; }

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

        public User()
        {
        }
    }

    public class ChatGroupSession
    {
        public User user { get; set; }
        public string groupId { get; set; }

        public ChatGroupSession( User userInfo, string group)
        {
            user = userInfo;
            groupId = group;
        }
    }

    class Salt
    {
        public string salt { get; set; }
    }
}
