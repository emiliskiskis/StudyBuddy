using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyBuddy
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            maskedTextBox2.PasswordChar = '*';
            maskedTextBox3.PasswordChar = '*';

        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.CloseAllForms();
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
            else if (!Validator.CheckPassword(password1))
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
                if (Validator.CheckEmail(email) == true)
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
                    if (Validator.CheckRegister(user))
                    {
                        bool result = await NetworkManager.CreateUserAsync(user);

                        if (result)
                        {
                            FormManager.BackToMain(this);
                            FormManager.Open(this, FormManager.FormType.userlist);
                        }
                        else
                        {
                            errorProvider1.SetError(maskedTextBox1, "Username already exists");
                            maskedTextBox1.Focus();
                        }

                    }
                }
                catch(Exception E)
                {
                    Console.WriteLine(E);
                }
            }
        }
    }
}
