using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy
{
    class UtilityFunctions
    {
        public static bool checkLogin(String username, String password)
        {
            //String salt, hash;
            //TODO http request
            return true;
        }

        public static bool checkRegister(String[] data)
        {

            return true;
        }

        public static bool checkEmail(String email)
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
