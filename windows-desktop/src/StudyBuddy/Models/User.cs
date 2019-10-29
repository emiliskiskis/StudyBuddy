using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Models
{
    public class ChatGroupSession
    {
        public ChatGroupSession(User userInfo, string group)
        {
            user = userInfo;
            groupId = group;
        }

        public string groupId { get; set; }
        public User user { get; set; }
    }

    public class User
    {
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

        public List<string> chats { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string username { get; set; }
    }

    public class PublicUser
    {
        public PublicUser(string username, string firstname, string lastname)
        {
            this.username = username;
            firstName = firstname;
            lastName = lastname;
        }

        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class ChatGroup
    {
        public string groupName { get; set; }
    }

    internal class Salt
    {
        public string salt { get; set; }
    }
}
