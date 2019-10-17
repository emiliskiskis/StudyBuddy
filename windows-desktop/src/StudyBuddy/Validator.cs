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
        public static async Task<bool> CheckLoginAsync(String username, String password)
        {
            string salt = await NetworkManager.GetSaltAsync(username);
            string hashedpassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            bool result = await NetworkManager.CheckHashAsync(username, hashedpassword);

            if (result)
            {
                return true;
            }
            else return false;
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
