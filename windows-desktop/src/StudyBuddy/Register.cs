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
            FormManager.Close();
        }
    }
}
