using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace StudyBuddy
{
    class Validator
    {
        public static bool CheckLogin(String username, String password)
        {
            //String salt, hash;
            //TODO http request
            return true;
        }

        public static bool CheckRegister(User user)
        {
            //if() return true;
            return true;
        }

        public static bool CheckEmail(String email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return false;
            }
            catch (FormatException)
            {
                return true;
            }
        }
    }
}
