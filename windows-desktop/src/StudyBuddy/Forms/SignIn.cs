using System;
using System.Windows.Forms;
using StudyBuddy.Managers;

namespace StudyBuddy.Forms
{
    public partial class SignIn : Form
    {
        private readonly FormManager _formManager;
        private readonly NetworkManager _networkManager;
        private readonly Validator _validator;

        public SignIn(FormManager formManager, NetworkManager networkManager, Validator validator)
        {
            InitializeComponent();
            maskedTextBox2.PasswordChar = '*';
            _networkManager = networkManager;
            _formManager = formManager;
            _validator = validator;
        }

        private async void button1_Click(object sender, EventArgs e)
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

                try
                {
                    if (await _validator.CheckLoginAsync(username, password))
                    {
                        await _networkManager.SetUserInformationAsync(username);
                        _formManager.Open(this, FormManager.FormType.chatSession);
                    }
                    else
                    {
                        label4.Text = "Incorrect username or password";
                        maskedTextBox1.Focus();
                    }
                }
                catch (AggregateException exc)
                {
                    Console.WriteLine(exc);
                }
            }
        }

        private void SignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            _formManager.CloseAllForms();
        }
    }
}
