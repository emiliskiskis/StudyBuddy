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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
            maskedTextBox2.PasswordChar = '*';
        }

        private void SignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.CloseAllForms();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String username = maskedTextBox1.Text;
            String password = maskedTextBox2.Text;
            bool err = false;

            label4.Text = "";

            if (String.IsNullOrEmpty(username))
            {
                errorProvider1.SetError(maskedTextBox1, "Please enter your username");
                err = true;
            }
            if (String.IsNullOrEmpty(password))
            {
                errorProvider2.SetError(maskedTextBox2, "Please enter your password");
                err = true;
            }

            

            if (err == false)
            {
                errorProvider1.SetError(maskedTextBox1, null);
                errorProvider2.SetError(maskedTextBox2, null);

                Console.WriteLine("I'm before the loginCheck");
                try
                {
                    if (Validator.CheckLoginAsync(username, password).GetAwaiter().GetResult())
                    {
                        FormManager.Open(this, FormManager.FormType.userlist);
                        Console.WriteLine("Login Successful!");
                    }
                    else
                    {
                        label4.Text = "Incorrect username or password";
                        maskedTextBox1.Focus();
                    }
                }
                catch (AggregateException exc) {
                    Console.WriteLine(exc);
                }
            }
            
        }

    }
}
