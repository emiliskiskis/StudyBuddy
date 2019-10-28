using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyBuddy.Managers;
using StudyBuddy.Models;

namespace StudyBuddy.Forms
{
    public partial class Register : Form
    {
        private readonly FormManager _formManager;
        private readonly NetworkManager _networkManager;
        private readonly Validator _validator;

        public Register(FormManager formManager, NetworkManager networkManager)
        {
            InitializeComponent();
            maskedTextBox2.PasswordChar = '*';
            maskedTextBox3.PasswordChar = '*';
            _formManager = formManager;
            _networkManager = networkManager;
            _validator = new Validator(_networkManager);
        }

        public async void button1_Click(object sender, EventArgs e)
        {
            String username = maskedTextBox1.Text;
            String password1 = maskedTextBox2.Text;
            String password2 = maskedTextBox3.Text;
            String email = maskedTextBox4.Text;
            String firstname = maskedTextBox5.Text;
            String lastname = maskedTextBox6.Text;

            bool err = false;

            if (String.IsNullOrEmpty(username))
            {
                errorProvider1.SetError(maskedTextBox1, "Please enter your username");
                err = true;
            }
            else errorProvider1.SetError(maskedTextBox1, null);

            if (String.IsNullOrEmpty(password1))
            {
                errorProvider2.SetError(maskedTextBox2, "Please enter your password");
                err = true;
            }
            else if (!_validator.CheckPassword(password1))
            {
                errorProvider2.SetError(maskedTextBox2, "The password must contain at least 8 characters, one uppercase and one lowercase letter and at least one digit");
                err = true;
            }
            else errorProvider2.SetError(maskedTextBox2, null);

            if (String.IsNullOrEmpty(password2))
            {
                errorProvider3.SetError(maskedTextBox3, "Please repeat your password");
                err = true;
            }
            else
            {
                if (password1 != password2)
                {
                    errorProvider3.SetError(maskedTextBox3, "Passwords do not match");
                    err = true;
                    maskedTextBox3.Focus();
                }
                else errorProvider3.SetError(maskedTextBox3, null);
            }

            if (String.IsNullOrEmpty(email))
            {
                errorProvider4.SetError(maskedTextBox4, "Please enter your email");
                err = true;
            }
            else
            {
                if (_validator.CheckEmail(email) == true)
                {
                    errorProvider4.SetError(maskedTextBox4, "Invalid email format");
                    err = true;
                    maskedTextBox4.Focus();
                }
                else errorProvider4.SetError(maskedTextBox4, null);
            }

            if (String.IsNullOrEmpty(firstname))
            {
                errorProvider5.SetError(maskedTextBox5, "Please enter your first name");
                err = true;
            }
            else errorProvider5.SetError(maskedTextBox5, null);

            if (String.IsNullOrEmpty(lastname))
            {
                errorProvider6.SetError(maskedTextBox6, "Please enter your last name");
                err = true;
            }
            else errorProvider6.SetError(maskedTextBox6, null);

            if (err == false)
            {
                try
                {
                    string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                    string hashedpassword = BCrypt.Net.BCrypt.HashPassword(password1, salt);
                    User user = new User(username, hashedpassword, salt, firstname, lastname, email);
                    bool result = await _networkManager.CreateUserAsync(user);

                    if (result)
                    {
                        await _networkManager.SetUserInformationAsync(user.username);
                        _formManager.Open(this, FormManager.FormType.chatSession);
                    }
                    else
                    {
                        errorProvider1.SetError(maskedTextBox1, "Username already exists");
                        maskedTextBox1.Focus();
                    }
                }
                catch (ArgumentException exc)
                {
                    Console.WriteLine(exc);
                }
            }
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            _formManager.CloseAllForms();
        }
    }
}
