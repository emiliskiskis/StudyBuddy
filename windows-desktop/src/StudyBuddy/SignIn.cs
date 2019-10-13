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
            maskedTextBox1.Text = "";
            maskedTextBox1.MaxLength = 30;
            maskedTextBox2.Text = "";
            maskedTextBox2.PasswordChar = '*';
            maskedTextBox2.MaxLength = 30;
        }

        private void SignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.Close();
        }
    }
}
