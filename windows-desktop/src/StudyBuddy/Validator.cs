using System;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using StudyBuddy.Models;
using StudyBuddy.Managers;

namespace StudyBuddy
{
    public class Validator
    {
        private readonly NetworkManager _networkManager;

        public Validator()
        {

        }

        public Validator(NetworkManager networkManager)
        {
            _networkManager = networkManager;
        }

        public bool CheckEmail(String email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public async Task<bool> CheckLoginAsync(String username, String password)
        {
            try
            {
                Salt saltObject = new Salt();
                String saltString;
                saltString = await _networkManager.GetSaltAsync(username);
                saltObject = JsonConvert.DeserializeObject<Salt>(saltString);
                string hashedpassword = BCrypt.Net.BCrypt.HashPassword(password, saltObject.salt);
                bool result = await _networkManager.CheckHashAsync(username, hashedpassword);

                if (result)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            return false;
        }

        //Checks if the password is minimum eight characters, at least one uppercase letter,
        //one lowercase letter and one number
        public bool CheckPassword(string password)
        {
            Regex passwordCheck = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            return passwordCheck.IsMatch(password);
        }
    }
}
