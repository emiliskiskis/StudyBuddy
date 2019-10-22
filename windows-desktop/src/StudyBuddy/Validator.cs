using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Newtonsoft.Json;


namespace StudyBuddy
{
    class Validator
    {
        public static async Task<bool> CheckLoginAsync(String username, String password)
        {
            try
            {
                Salt saltObject = new Salt();
                String saltString;
                saltString = NetworkManager.GetSaltAsync(username).GetAwaiter().GetResult();
                saltObject = JsonConvert.DeserializeObject<Salt>(saltString);
                string hashedpassword = BCrypt.Net.BCrypt.HashPassword(password, saltObject.salt);
                bool result = NetworkManager.CheckHash(username, hashedpassword);

                if (result)
                {
                    return true;
                }
                else return false;
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
            }

            return false;
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

        //Checks if the password is minimum eight characters, at least one uppercase letter, 
        //one lowercase letter and one number
        public static bool CheckPassword(string password)
        {
            Regex passwordCheck = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            return passwordCheck.IsMatch(password);
        }
    }
}
